using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
#if DEBUG
#endif


namespace Dobby {
    
    internal class Common : MainPage, IDisposable {
        //#error version

        // Spacing:
        // Info & Back Btn; Info: Form.Size.Y - Info.Size.Y | BackBtn Pos: (Info Vertical Pos - BackBtn.Size.Y - 3)

        //==================================================\\
        //                 Design Bullshit                  \\
        //__________________________________________________\\
        // * FONT USAGE: (Use Bold For Both)                \\
        // - Use Franklin Gothic 10pt For Basic Controls    \\
        // - Use Cambria 9.75pt For Information Pages       \\
        //                                                  \\
        // * Borders And Seperator Lines                    \\
        // - Keep Controls At Least 1 Pixel From Form Edge  \\
        // - Lines Should Be 2 Pixels From Either Form Edge \\
        //==================================================\\


        // TODO:
        // * MAJOR
        //  - Create Remaining Two Help Pages
        //  - Refactor EbootPatchPage Code. Check The Others, Too
        //  - Gp4CreationPage Unfinished, Only Base Functionality Added
        //  - Standardize Help Page Styles
        // * MINOR 
        //  - Update PKG Creation Page To Be More Like GP4 Creation Page
        //  - Standardize Info Label And Back Button Positioning / Spacing
        //  - Standardize Spaceing Between Controls
        //  - PS4DebugPage Consistency Fix (Can't Seem To Reproduce? [The Bug, I Mean. Not That I Don't Want The Other Thing])


        //========================================\\
        //--|   Global Variable Declarations   |--\\
        //========================================\\
        #region [Global Variable Declarations]

        //#
        //## Basic Form Functionality
        //#
        #region (Basic Form Functionality)
        
        /// <summary> ID for the active game. </summary>
        public static GameID Game;

        /// <summary> ID for the currently loaded form. </summary>
        public static PageID? Page;
        public static List<PageID?> Pages = new List<PageID?>();

        public static bool
            MouseScrolled,
            MouseIsDown,
            LabelShouldFlash,
            DisableFormChange
        ;

        public static MouseButtons ActiveMouseButton = MouseButtons.None;

        public static Point
            LastFormPosition = Point.Empty,
            MousePos,
            MouseDif
        ;

        public static Point[] OriginalControlPositions;

        public static Size OriginalFormScale = Size.Empty;

        public static Color NDYellow = Color.FromArgb(255, 227, 0);

        public static string
            ActiveGameID = "UNK"
        ;
        
        
    #if DEBUG
        /// <summary> Debug class instance. </summary>
        public static Testing Dev;
        private static DebugWindow Log;
    #endif
        #endregion



        //#
        //## Control Refferences
        //#
        #region [Control Refferences]

        public static Control HoveredControl;


        /// <summary> Refference to the originally launched form. </summary>
        private static Form MainForm;
        public static Form PopupBox;

        /// <summary> Static refference to the active form's "Info" label control for usage in static functions. (because I'm lazy) </summary>
        public static Label InfoLabel;

        /// <summary> GroupBox for eventual use in yet-unfinished custom popup box function. (so they fit the app's "theme") </summary>
        public static GroupBox PopupGroupBox;
        #endregion Control Refferences
        
        

        //#
        //## Design-Related Components
        //#
        #region [Design Components]

        public static bool StyleTest = false;

        public static Font ControlFont = new Font("Cambria", 9.75F, FontStyle.Bold);
        public static Font AltControlFont = new Font("Consolas", 9.75F, FontStyle.Bold);
        public static Font SmallControlFont = new Font("Verdana", 8F);

        public static Font TextFont = new Font("Cambria", 10F);
        public static Font DefaultTextFont = new Font("Cambria", 10F, FontStyle.Italic);


        public static Color MainColour = Color.FromArgb(100, 100, 100);
        public static Color HighlightColour {
            get => BorderPen.Color;

            set {
                BorderPen.Color = value;
                ActiveForm?.PerformLayout();
                ActiveForm?.Update();
            }
        }

        ///<summary> Form Border Pen </summary>
        private static Pen BorderPen = new Pen(Color.White);
        #endregion
        


        //#
        //## Threading Components
        //#
        #region [Threading Components]

        private static string infoText;

        private static int flashes = -1;

        private static Thread LabelUpdateThread;

        private delegate void LabelUpdateCallback(Label control, Color colour, string infoText = null);
        #endregion



        //#
        //## Network-Related Components
        //#
        #region [Network-Related Components]

        //public static TcpClient TcpClient;
        //public static NetworkStream NetStream;
        #endregion

        #endregion (global variable declarations)




        //========================================\\
        //--|   Global Function Declarations   |--\\
        //========================================\\
        #region [Global Function Declarations]


        //#
        //## Unsorted
        //#
        #region (unsorted)

        /// <summary>
        /// Dev.Print overload, for some reason. //!
        /// </summary>
        public static void Print(object message)
        {
            #if Logging
            Testing.Print(message);
            #endif
        }

        /// <summary>
        /// Basic error logging function (not yet fully implemented)
        /// </summary>
        public static void PrintError(Exception error)
        {
            var message = $"{error.Message}";
#if DEBUG
            message += $"\n{error.StackTrace.Replace("\n", "  \n")}";
#endif

            Print($"!! ERROR: {message}");
        }



        /// <summary>
        /// Update the current label text and/or apply a flashing effect to the label to signify an error.
        /// </summary>
        /// <param name="newText"> The string to apply to the label's Text property. </param>
        /// <param name="flashLabel"> If true, flash the label to indicate an error or otherwise get the user's attention. (switches between white/yellow) </param>
        public static void UpdateLabel(string newText, bool flashLabel = false)
        {
            if ((infoText == " " || infoText == null) && newText != null && InfoLabel.Text != newText)
            {
                infoText = newText;
            }

            if (flashLabel)
            {
                flashes = 15;
            }
        }


        
        /// <summary>
        /// Hash a specific chunk of data in the provided exectutable's file stream to determine the current game, then return the game's name &amp; app version.<br/>
        /// TODO: rework it or figure out why tf it's hashing 160 bytes and then just checking the first four bytes of said hash
        /// </summary>
        /// <returns>
        /// The name of the game, followed by the app version.
        /// </returns>
        /// <param name="stream"> The active file stream for the loaded executable. </param>
        public static string GetGameID(FileStream stream)
        {
            byte[] LocalExecutableCheck;


            // Ensure the provided executable has been unsigned (check for ".elf" file magic)
            stream.Position = 0;
            stream.Read(LocalExecutableCheck = new byte[4], 0, 4);

            if (BitConverter.ToInt32(LocalExecutableCheck, 0) != 1179403647)
                MessageBox.Show($"Executable Still Encrypted (self) | Must Be Decrypted/Unsigned");


            // Read a string of data at a specific address to determine the current game (why is it 160 bytes??? I thought it was a 32-bit integer)
            stream.Position = 0x5100;
            stream.Read(LocalExecutableCheck = new byte[160], 0, 160);


            switch (Game = (GameID) BitConverter.ToInt32(SHA256.Create().ComputeHash(LocalExecutableCheck), 0))
            {
                case GameID.UC1100: return "Uncharted 1 1.00";
                case GameID.UC1102: return "Uncharted 1 1.02";
                case GameID.UC2100: return "Uncharted 2 1.00";
                case GameID.UC2102: return "Uncharted 2 1.02";
                case GameID.UC3100: return "Uncharted 3 1.00";
                case GameID.UC3102: return "Uncharted 3 1.02";
                case GameID.UC4100: return "Uncharted 4 1.00";
                case GameID.UC4101: return "Uncharted 4 1.01";
                case GameID.UC4102: return "Uncharted 4 1.02";
                case GameID.UC4103: return "Uncharted 4 1.03";
                case GameID.UC4104: return "Uncharted 4 1.04";
                case GameID.UC4105: return "Uncharted 4 1.05";
                case GameID.UC4106: return "Uncharted 4 1.06";
                case GameID.UC4108: return "Uncharted 4 1.08";
                case GameID.UC4110: return "Uncharted 4 1.10";
                case GameID.UC4111: return "Uncharted 4 1.11";
                case GameID.UC4112: return "Uncharted 4 1.12";
                case GameID.UC4113: return "Uncharted 4 1.13";
                case GameID.UC4115: return "Uncharted 4 1.15";
                case GameID.UC4116: return "Uncharted 4 1.16";
                case GameID.UC4117: return "Uncharted 4 1.17";
                case GameID.UC4118: return "Uncharted 4 1.18 SP/MP";
                case GameID.UC4119: return "Uncharted 4 1.19 SP/MP";
                case GameID.UC4120MP: return "Uncharted 4 1.20 MP";
                case GameID.UC4120: return "Uncharted 4 1.20 SP";
                case GameID.UC4121MP: return "Uncharted 4 1.21 MP";
                case GameID.UC4121: return "Uncharted 4 1.21 SP";
                case GameID.UC4122MP: return "Uncharted 4 1.22 MP";
                case GameID.UC4122_23: return "Uncharted 4 1.22/23 SP";
                case GameID.UC4123MP: return "Uncharted 4 1.23 MP";
                case GameID.UC4124MP: return "Uncharted 4 1.24 MP";
                case GameID.UC4124_25: return "Uncharted 4 1.24/25 SP";
                case GameID.UC4125MP: return "Uncharted 4 1.25 MP";
                case GameID.UC4127_28MP: return "Uncharted 4 1.27/28 MP";
                case GameID.UC4127_133: return "Uncharted 4 1.27+ SP";
                case GameID.UC4129MP: return "Uncharted 4 1.29 MP";
                case GameID.UC4130MP: return "Uncharted 4 1.30 MP";
                case GameID.UC4131MP: return "Uncharted 4 1.31 MP";
                case GameID.UC4132MP: return "Uncharted 4 1.32/TLL 1.08 MP";
                case GameID.UC4133MP: return "Uncharted 4 1.33/TLL 1.09 MP";
                case GameID.UC4MPBETA100: return "Uncharted 4 MP Beta 1.00";
                case GameID.UC4MPBETA109: return "Uncharted 4 MP Beta 1.09";
                case GameID.TLL100MP: return "Uncharted Lost Legacy 1.00 MP";
                case GameID.TLL100: return "Uncharted Lost Legacy 1.00 SP";
                case GameID.TLL10X: return "Uncharted Lost Legacy 1.08/9 SP";
                case GameID.T1R100: return "The Last Of Us 1.00";
                case GameID.T1R109: return "The Last Of Us 1.09";
                case GameID.T1R110: return "The Last Of Us 1.10";
                case GameID.T1R111: return "The Last Of Us 1.11";
                case GameID.T2100: return "The Last Of Us 2 1.00";
                case GameID.T2101: return "The Last Of Us 2 1.01";
                case GameID.T2102: return "The Last Of Us 2 1.02";
                case GameID.T2105: return "The Last Of Us 2 1.05";
                case GameID.T2107: return "The Last Of Us 2 1.07";
                case GameID.T2108: return "The Last Of Us 2 1.08";
                case GameID.T2109: return "The Last Of Us 2 1.09";

                default:
                    return $"Unknown Game (Game ID: {Game})";
            }
        }




        /* [deprecated SetInfoLabelStringOnControlHover(Control Sender, float FontAdjustment = 10f)]
        /// <summary> [deprecated] Sets The Info Label String Based On The Currently Hovered Control </summary>
        /// <param name="Sender">The Hovered Control</param>
        public static void SetInfoLabelStringOnControlHover(Control Sender, float FontAdjustment = 10f) {
            throw new NotImplementedException();

            // SetInfo
            // TODO: this is fucking stupid, change or delete it.

#pragma warning disable CS0162 // Unreachable code detected
            var InfoLabelString = "";

            switch (Sender.Name) {
                default:
                    return;

                //
                // Const
                case "CreditsBtn":
                    InfoLabelString = "View Credits For The Tool And Included Patches";
                    break;
                case "InfoHelpBtn":
                    InfoLabelString = "View Help For Each Page As Well As The App Itself";
                    break;
                case "BackBtn":
                    InfoLabelString = "Return To The Previous Page";
                    break;
                //
                // Main Page
                case "PS4DebugPageBtn":
                    InfoLabelString = "Use A Lan Or Wifi Connection To Enable The Debug Mode";
                    break;
                case "EbootPatchPageBtn":
                    InfoLabelString = "Patch An Executable To Be Added To A .pkg";
                    break;
                case "DownloadSourceBtn":
                    InfoLabelString = "This Opens An External Link";
                    break;
                case "PCDebugMenuPageBtn":
                    InfoLabelString = "Enable The Default Or Restored Debug Menu";
                    break;
                case "PCQOLPageBtn":
                    InfoLabelString = "Enable The Default Or Restored Debug Menu";
                    break;
                //
                // PS4DebugPage
                case "UC1Btn":
                    break;
                case "UC2Btn":
                    break;
                case "UC3Btn":
                    break;
                case "UC4Btn":
                    break;
                case "UC4MPBetaBtn":
                    InfoLabelString = "Supports: 1.09 - Use .bin Patch For 1.00";
                    break;
                case "T1RBtn":
                    break;
                case "T2Btn":
                    break;
                case "DebugPayloadBtn":
                    InfoLabelString = "Sends ctn123's Port Of PS4Debug";
                    break;
                case "ManualConnectBtn":
                    InfoLabelString = "Tool Also Auto-Connects When An Option's Selected";
                    break;
                case "IgnoreTitleIDBtn":
                    InfoLabelString = "Enable This If You've Changed The Title ID";
                    break;
                //
                // EbootPatchPage
                case "EnableDebugBtn":
                    InfoLabelString = "Enable Debug Mode As-Is With No Edits";
                    break;
                case "DisableDebugBtn":
                    InfoLabelString = "Disable Debug Mode. Doesn't Undo Other Patches";
                    break;
                case "RestoredDebugBtn":
                    InfoLabelString = "Restores The Menu As Authentically As Possible";
                    break;
                case "CustomDebugBtn":
                    InfoLabelString = "Patches In My Customized Version Of The Debug Menu";
                    break;
                case "PS4MenuSettingsPageBtn":
                    InfoLabelString = "Adds A Function To Write To Selected Settings On Game Boot";
                    break;
                //
                // PkgCreationPage
                case "Gp4CreationPageBtn":
                    InfoLabelString = "A .gp4 Is Required For .pkg Creation";
                    break;

            }

            //UpdateLabel(InfoLabelString);
#pragma warning restore CS0162 // Unreachable code detected
        }
        */
        #endregion



        //#
        //## Form Functionality
        //#
        #region (form functionality)
        
        /// <summary> Save a refference to the orignal launch form. (why is this a function, again? //!) </summary>
        /// <param name="form"> The orignal form </param>
        public static void SaveMainForm(Form form) => MainForm = form;


        /// <summary>
        /// Loads The Specified Page From The PageId Group (E.g. ChangeForm(PageID.PS4MiscPageId))
        /// </summary>
        /// <param name="Page"> The Page To Change To. </param>
        public static void ChangeForm(PageID? Page, bool ReturningToPreviousPage = false)
        {
            if (DisableFormChange) {
                UpdateLabel("Disabled during .gp4 / .pkg Creation Process.");
                Print($"Ignoring request to change form to \"{Page ?? 0}\".");
                return;
            }
            else {
                flashes = -1;
                infoText = null;
                LabelUpdateThread.Abort();
            }


            var NewPage = ActiveForm;
            
            switch (Page)
            {
                case PageID.MainPage:
                    NewPage = MainForm;
                    break;
                case PageID.PS4DebugPage:
                    NewPage = new PS4DebugPage();
                    break;

                case PageID.PS4DebugHelpPage:
                    NewPage = new PS4DebugHelpPage();
                    break;

                case PageID.EbootPatchPage:
                    NewPage = new EbootPatchPage();
                    break;

                case PageID.EbootPatchHelpPage:
                    NewPage = new EbootPatchHelpPage();
                    break;

                case PageID.PS4MenuSettingsPage:
                    NewPage = new PS4MenuSettingsPage();
                    break;

                case PageID.PS4MenuSettingsHelpPage:
                    //PS4MiscPatchesHelpPage PS4MiscPatchesHelpPage = new PS4MiscPatchesHelpPage();
                    //PS4MiscPatchesHelpPage.Show();
                    break;

                case PageID.PkgCreationPage:
                    NewPage = new PkgCreationPage();
                    break;

                case PageID.PkgCreationHelpPage:
                    NewPage = new PkgCreationHelpPage();
                    break;

                case PageID.Gp4CreationPage:
                    NewPage = new GP4CreationPage();
                    break;

                case PageID.Gp4CreationHelpPage:
                    break;

                case PageID.PCDebugMenuPage:
                    NewPage = new PCDebugMenuPage();
                    //MessageBox.Show("Note:\nI'v Only Got The Executables For Either The Epic Or Steam Version, And I Don't Even Know Which...\n\nIf The Tools Says Your Executable Is Unknown, Send It To Me And I'll Add Support For It\nI Would Advise Alternate Methods, Though");
                    break;

                case PageID.InfoHelpPage:
                    NewPage = new InfoHelpPage();
                    break;

                case PageID.CreditsPage:
                    NewPage = new CreditsPage();
                    break;

                case null:
                    ChangeForm(Pages.Last(), true);
                    return;

                default:
                    Print($"{Page} Is Not A Page!");
                    return;
            }

            
            LastFormPosition = ActiveForm.Location;
            var PageToClose = ActiveForm;

            
            if (ReturningToPreviousPage)
                Pages.RemoveAt(Pages.Count - 1);
            else
                Pages.Add(Common.Page);


            NewPage?.Show();
#if DEBUG
            Log?.SetLogParent(NewPage);
#endif
            Common.Page = Page;
            ActiveForm.Location = LastFormPosition;


            if (PageToClose.Name == "MainPage")
                PageToClose.Hide();
            else
                PageToClose.Close();
        }




        /// <summary>
        /// Mass-Apply Basic Event Handlers To Form And It's Items. (I got sick of manually editing InitializeComponent())
        /// </summary>
        /// <param name="Controls">Collection of Controls to Apply Event Handlers to.</param>
        public static void InitializeAdditionalEventHandlers(Control.ControlCollection Controls)
        {
            var ConstantControls = new string[] { "Info", "InfoHelpBtn", "CreditsBtn", "BackBtn" };
            var Parent = Controls.Owner.Name;


            // Mass-Apply handler methods to basic MouseDown/Up, MouseEnter/Leave and MouseMove events
            foreach (Control item in Controls)
            {
                item.MouseDown += new MouseEventHandler(MouseDownFunc);
                item.MouseUp += new MouseEventHandler(MouseUpFunc);


                if (item.Name.Contains("SeperatorLine") && item.GetType() == typeof(Label))
                    item.Paint += DrawSeperatorLine;

                if (!(item.Name.Contains("Box") && (item.GetType() == typeof(TextBox) || item.GetType() == typeof(RichTextBox)))) // So You Can Drag Select The Text Lol
                    item.MouseMove += new MouseEventHandler(MoveForm);


                // Avoid assigning a hover arrow to unintended controls (blacklisted ones, and any non-button controls)
                var blacklistedItems = new string[] {
                    "DebugControl",
                    "ExitBtn",
                    "MinimizeBtn",
                    "LabelBtn", //! LabelBtn!? The hell's that one for?
                    "PathBox"
                };

                if ((item.GetType() == typeof(Dobby.Button) || item.GetType() == typeof(System.Windows.Forms.Button)) && !blacklistedItems.Contains(item.Name))
                {
                    item.MouseEnter += (sender, e) => HoverLeave(((Control)sender), true);
                    item.MouseLeave += (sender, e) => HoverLeave(((Control)sender), false);
                }
            }


            // Apply border application method to paint event
            Controls.Owner.Paint += DrawBorder;
            
            // Apply Info label reset string to form
            Controls.Owner.Tag = " ";
            Controls.Owner.MouseEnter += Common.HoverString;



            // Attempt to assign static Info label refference for globals
            try {
                InfoLabel = (Label) Controls.Find("Info", true)[0] ?? null;
            }
            catch (IndexOutOfRangeException) {
                Print($"ERROR: \"Info\" label not found on form \"{Controls.Owner.Name}\".");
                InfoLabel = null;
            }

            // Inititialize Info label thread
            if (InfoLabel != null)
            {
                LabelUpdateThread = new Thread(new ParameterizedThreadStart(LabelUpdateMethod)) {
                    Name = $"{Controls.Owner.Name} Label Update Worker"
                };

                LabelUpdateThread.Start(InfoLabel);
            }
            else
                LabelUpdateThread = null;



            // Create Exit And Minimize Buttons, And Add Them To The Top Right Of The Form
            var Gray = Color.FromArgb(100, 100, 100);

            Button ExitBtn = new Button() {
                Location = new Point(Controls.Owner.Size.Width - 24, 1),
                Size = new Size(23, 23),
                Name = "ExitBtn",
                Font = new Font("Franklin Gothic Medium", 7.5F, FontStyle.Bold),
                Text = "X",
                FlatStyle = FlatStyle.Flat,
                BackColor = Gray,
                ForeColor = SystemColors.Control,
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Cross
            },
            MinimizeBtn = new Button() {
                Location = new Point(Controls.Owner.Size.Width - 47, 1),
                Size = new Size(23, 23),
                Name = "MinimizeBtn",
                Font = new Font("Franklin Gothic Medium", 7.5F, FontStyle.Bold),
                Text = "--",
                FlatStyle = FlatStyle.Flat,
                BackColor = Gray,
                ForeColor = SystemColors.Control,
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Cross
            }
            #if DEBUG
            ,LogBtn = new Button() {
                Location = new Point(Controls.Owner.Size.Width - 70, 1),
                Size = new Size(23, 23),
                Name = "LogBtn",
                Font = new Font("Franklin Gothic Medium", 6.5F, FontStyle.Bold),
                Text = "Log",
                FlatStyle = FlatStyle.Flat,
                BackColor = Gray,
                ForeColor = SystemColors.Control,
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Cross
            }
            #endif
            ;

            // Minimize Button Properties
            MinimizeBtn.FlatAppearance.BorderSize = 0;
            Controls.Owner.Controls.Add(MinimizeBtn);
            MinimizeBtn.BringToFront();

            MinimizeBtn.Click += new EventHandler(MinimizeBtn_Click);
            MinimizeBtn.MouseEnter += new EventHandler(WindowBtnMH);
            MinimizeBtn.MouseLeave += new EventHandler(WindowBtnML);

            // Exit Button Properties
            ExitBtn.FlatAppearance.BorderSize = 0;
            Controls.Owner.Controls.Add(ExitBtn);
            ExitBtn.BringToFront();
            
            ExitBtn.Click += new EventHandler(ExitBtn_Click);
            ExitBtn.MouseEnter += new EventHandler(WindowBtnMH);
            ExitBtn.MouseLeave += new EventHandler(WindowBtnML);

            #if DEBUG
            // Log Window Button Properties
            LogBtn.FlatAppearance.BorderSize = 0;
            Controls.Owner.Controls.Add(LogBtn);
            LogBtn.BringToFront();
            
            LogBtn.Click += LogBtn_Click;
            LogBtn.MouseEnter += new EventHandler(WindowBtnMH);
            LogBtn.MouseLeave += new EventHandler(WindowBtnML);
            #endif


            // Avoid searching for back button on Main page
            if (Parent != "MainPage")
                Controls.Owner.Controls.Find(ConstantControls[3], true)[0].Click += (_, __) => ChangeForm(null);

            try {
                if (!Parent.Contains("Help") && Parent != "CreditsPage")
                    Controls.Owner.Controls.Find(ConstantControls[1], true)[0].Click += (_, __) => ChangeForm(PageID.InfoHelpPage);
                
                Controls.Owner.Controls.Find(ConstantControls[2], true)[0].Click += (_, __) => ChangeForm(PageID.CreditsPage);
                Controls.Owner.Controls.Find(ConstantControls[0], true)[0].Text = string.Empty;
            }
            catch (Exception) {}
        }

        #endregion




        
        //#
        //## Form/Control Drawing
        //#
        #region (form/control drawing)

        /// <summary>
        /// Appends a > to a hovered control, or removes it when the mouse leaves it's bounds. (also resizes the control by the arrow's size in pixels)
        /// </summary>
        /// <param name="PassedControl"> The control to append the arrow to. </param>
        /// <param name="EventIsMouseEnter"> Whether or not the  </param>
        public static void HoverLeave(Control PassedControl, bool EventIsMouseEnter) {
            int ArrowWidth;

            try {
                ArrowWidth = (int) PassedControl.CreateGraphics().MeasureString(">", PassedControl.Font).Width;
            }
            catch (Exception ex) {
                Print($"Error Getting Width Of Hover Arror From Control ({PassedControl.Name}: {(EventIsMouseEnter ? "Hover" : "Leave")})");
                PrintError(ex);
                return;
            }



            if (MouseScrolled = EventIsMouseEnter) //! <-- is this intentional? could swear it should only be set to false in one of the cases and left alone in the other, not set to true
            {
                HoveredControl = PassedControl;

                HoveredControl.Text = '>' + HoveredControl.Text;
            }
            else {
                //ArrowWidth = ~ArrowWidth ^ 1; I'm an idiot
                ArrowWidth = -ArrowWidth;

                if (HoveredControl == PassedControl)
                    HoveredControl = null;

                if (PassedControl.Text.Contains('>'))
                PassedControl.Text = PassedControl.Text.Substring(1);
            }


            // Avoid resizing controls when they're already horizontally flush with the form
            if (PassedControl.Size.Width + PassedControl.Location.X == PassedControl.Parent.Size.Width - 1)
                return;


            // Resize controls to fit the arrow
            PassedControl.Size = new Size(PassedControl.Width + ArrowWidth, PassedControl.Height);
        }




        ///<summary>
        /// Create And Apply A Thin Border To The Form
        ///</summary>
        public static void DrawBorder(object sender, PaintEventArgs e)
        {
            var itemPtr = sender as Form;

            e.Graphics.Clear(Color.FromArgb(100, 100, 100));
            e.Graphics.DrawLines(BorderPen, new Point[] {
                Point.Empty,
                new Point(itemPtr.Width - 1, 0),
                new Point(itemPtr.Width - 1, itemPtr.Height - 1),
                new Point(0, itemPtr.Height - 1),
                Point.Empty
            });
        }


        /// <summary> Create and draw a thin white line from one end of the form to the other. (placeholder code atm)
        ///</summary>
        public static void DrawSeperatorLine(object sender, PaintEventArgs @event)
        {
            var item = sender as Label;

            if (item == null) {
                Print("!! ERROR: Invalid control passed as Seperator line.");
                Print($"  - Control \"{item.Name}\" location: {item.Location}.");
            }
            if (item.Name == "Se" && item.Location != new Point(2, 20)) {
                Print($"Seperator Line 0 Improperly positioned on {item.Parent.Name}");
            }
            if (item.Height != 15) {
                Print($"# WARNING: \"{item.Name}\" has an invalid height!!! (Label is {item.Height} pixels in hight)");
                //item.Size = new Size(item.Size.Width, 15);
            }
            if (!(item.Location.X == 2 && item.Width == item.Parent.Width - 4)) {
                //Print($"# WARNING: A label on page \"{item.Parent.Name}\" has an invalid width and / or horizontal location!!! (Label at {item.Location} is {item.Width} pixels in width)");

                Print($"Moved And Resized {item.Name} ({item.Parent.Name}).");
                item.Location = new Point(2, item.Location.Y);
                item.Width = item.Parent.Width - 4;
            }


            @event.Graphics.Clear(Color.FromArgb(100, 100, 100));
            @event.Graphics.DrawLines(BorderPen, new Point[] {
                new Point(0, 9),
                new Point(item.Parent.Width, 9)
            });
        }



        /// <summary>
        /// Flash the Info label white/yellow to get the user's attention/indicate a skill issue.
        /// </summary>
        /// <param name="Label"> The Control.Name property of the label to flash </param>
        internal static void LabelUpdateMethod(object Label)
        {
            LabelUpdateCallback SetLabelState = (label, colour, text) => {
                try {
                    while (ActiveForm == null)
                        Thread.Sleep(1);
                
                    if (ActiveForm != null && label != null)
                    {
                        if (text != null)
                            label.Text = text;

                        if (colour != null)
                            label.ForeColor = colour;

                        ActiveForm?.Update();
                    }

                    ActiveForm?.Update();
                }
                catch (Exception) {
                    Print("Error setting label text and / or colour.");
                }
            };

            while (true) {
                try {
                    // Wait for something to do
                    for (;flashes == -1 && infoText == null; Thread.Sleep(1))
                        


                    // Try to avoid hiding hint strings with the label reset
                    if (infoText != null && infoText == " ")
                    {
                        for (var time = 0; infoText == " " && time++ < 75; Thread.Sleep(1));
                    }


                    // Flash the label if applicable
                    for (var msg = infoText; flashes > -1 || (infoText == " " && (infoText = null) == null);)
                    {
                        while (ActiveForm == null)
                            Thread.Sleep(1);

                        ActiveForm?.Invoke(SetLabelState, Label, (flashes-- & 1) == 0 ? Color.FromArgb(255, 227, 0) : Color.White, msg);
                        Thread.Sleep(135);
                    }

                    // Set The Text of The Yellow Label At The Bottom Of The Form
                    if (infoText != null)
                    {
                        ActiveForm?.Invoke(SetLabelState, Label, Color.FromArgb(255, 227, 0), infoText);
                        infoText = null;
                    }
                }
                catch (Exception) {
                    Print("Form Changed or Lost Focus, Killing Label Flash");

                    while (ActiveForm == null)
                        Thread.Sleep(1);
                }
            }
        }

        #endregion (form/control drawing-related functions)

        //## END
        #endregion [Static Background Function Declarations]



        //=============================================\\
        //--|   Static Event Handler Declarations   |--\\
        //=============================================\\
        #region [Static Event Handler Declarations]

        #if DEBUG
        public static void LogBtn_Click(object sender, EventArgs args) {
            if (Log != null) {
                Log?.Dispose();
                Log = null;
            }
            else
                (Log = new DebugWindow(((Control)sender).FindForm())).Show();
        }
        #endif
        
        internal static void ExitBtn_Click(object sender, EventArgs e)
        {
            MainForm.Dispose();  //! 90% sure neither of these are implemented properly.
            Environment.Exit(0); // off we fuck
        }
        internal static void WindowBtnMH(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 227, 0);
        internal static void WindowBtnML(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);
        internal static void MinimizeBtn_Click(object sender, EventArgs e) => ((Control)sender).FindForm().WindowState = FormWindowState.Minimized;
        
        internal static void MouseDownFunc(object sender, MouseEventArgs e)
        {
            ActiveMouseButton = e.Button;
            MouseIsDown = true;
            
            LastFormPosition = ActiveForm?.Location ?? LastFormPosition;
            MouseDif = new Point(MousePosition.X - LastFormPosition.X, MousePosition.Y - LastFormPosition.Y);

        }

        internal static void MouseUpFunc(object sender, MouseEventArgs e) {
            MouseScrolled = MouseIsDown = false;

            ActiveMouseButton = MouseButtons.None;
        }

        public static void MoveForm(object sender, MouseEventArgs e)
        {
            if (!MouseIsDown || ActiveForm == null)
                return;

            ActiveForm.Location = new Point(MousePosition.X - MouseDif.X, MousePosition.Y - MouseDif.Y);
            ActiveForm.Update();

            #if DEBUG
            Log?.MoveLogToAppEdge();
            #endif
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public static void ControlHover(Control control)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public static void ControlLeave(Control control)
        {

        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void HoverString(object sender, EventArgs e)
        {
            // TODO:
            // Make this avoid assigning Hint string when the label flash thread is active
            try {
                if (((string) ((Control)sender).Tag ?? string.Empty).Length > 0) //! test this
                {
                    UpdateLabel((string) ((Control)sender).Tag);
                }
                else Print($"Label not updated due to empty tag or active flash thread {flashes} {infoText?.Length ?? 0xDEADDAD}");
            }
            catch (InvalidCastException)
            {
                Print("ERROR: A Non-string value was assigned to a control tag");
            }
        }
        #endregion



        //=======================\\
        //--|   Enumerators   |--\\
        //=======================\\
        #region [Enumerators]

        /// <summary> ID's for the various pages (forms) in the application. </summary>
        public enum PageID : byte {
            MainPage = 0,
            PS4DebugPage = 1,
            PS4DebugHelpPage = 11,
            EbootPatchPage = 2,
            EbootPatchHelpPage = 21,
            PS4MenuSettingsPage = 3,
            PS4MenuSettingsHelpPage = 31,
            PkgCreationPage = 4,
            PkgCreationHelpPage = 41,
            Gp4CreationPage = 5,
            Gp4CreationHelpPage = 51,
            PCDebugMenuPage = 6,
            InfoHelpPage = 7,
            CreditsPage = 8
        }



        public enum GameID : long {
            // Read 160 bytes at 0x5100 as SHA256 Then Checked As Int32 Because I'm An Idiot And Don't Feel Like Correcting It Since It Works
            UC1100 = -679355525,
            UC1102 = 104877429,
            UC2100 = 414674483,
            UC2102 = 216080152,
            UC3100 = 823868754,
            UC3102 = 1911044661,
            UC4100 = 308820129,
            UC4101 = -1879120502,
            UC4102 = 1084389925,
            UC4103 = 1009654146,
            UC4104 = 1174607918,
            UC4105 = 1397785573,
            UC4106 = 1880438911,
            UC4108 = -1521275605,
            UC4110 = 556134345,
            UC4111 = 533967079,
            UC4112 = -1876292260,
            UC4113 = 441673980,
            UC4115 = 1382306251,
            UC4116 = -1865276990,
            UC4117 = -2002709567,
            UC4118 = 1337597197,
            UC4119 = 853166708,
            UC4120MP = 948532543,
            UC4120 = 1044003518,
            UC4121MP = 1404274247,
            UC4121 = -538479879,
            UC4122MP = -605975924,
            UC4122_23 = 1849401718,
            UC4123MP = -959800645,
            UC4124MP = 1301857603,
            UC4124_25 = -1166682695,
            UC4125MP = -634367694,
            UC4127_28MP = -1449571981,
            UC4127_133 = -400040687, // 1.27+, SP exe Never Changed After 1.27 Released
            UC4129MP = -1725079303,
            UC4130MP = 931397679,
            UC4131MP = 1212014389,
            UC4132MP = 1923471472, // Also The Lost Legacy 1.08 MP
            UC4133MP = 486460629,  // Also The Lost Legacy 1.09 MP
            UC4MPBETA100 = 1813169088,  // CUSA04051
            UC4MPBETA109 = -1103269419, // CUSA04051
            TLL100MP = 469274180,
            TLL100 = -1269602830,
            TLL10X = 2141223617,  // UCTLL 1.08/1.09 SP Identical
            T1R100 = 306377542,
            T1R109 = -1391237605,
            T1R110 = -915963582,
            T1R111 = -866651344,
            T2100 = -1496529414,
            T2101 = -777844382,
            T2102 = -357372043,
            T2105 = -342416055,
            T2107 = 154664618,
            T2108 = 537380869,
            T2109 = 1174398197,
            
            // PC Eboot Identifiers - Very Limited Though | 0x1EC + 0x1F8 (Kept Seperate Through Immense Laziness)
            T1X101 = 42695168 + 16007532,
            T1XL101 = 42670080 + 16010844,
            T1X1015 = 2228464 + 95625728,
            T1XL1015 = 2228464 + 95627776,
            T1X1016 = 42698752 + 16007532,
            T1XL1016 = 42673664 + 16010828,
            T1X1017 = 42702336 + 16007852,
            T1XL1017 = 42677248 + 16011148,
            T1X102 = 2228464 + 95631360,
            T1XL102 = 2228464 + 95634432,

            Empty = 0xDEADBEEF
        }



        /// <summary> .elf Addresses For Enabling The Debug Mode In Various PS4 Naughty Dog Games<br/>[On: 0xEB]<br/>[Off: 0x74]</summary>
        public enum DebugJumpAddress : int {
            T1R100Debug = 0x5C5A,
            T1R109Debug = 0x61A0,
            T1R110Debug = 0x61A0,
            T1R111Debug = 0x61A0,
            T2100Debug = 0x1D6394,
            T2101Debug = 0x1D6414,
            T2102Debug = 0x1D6464,
            T2105Debug = 0x1D66A4,
            T2107Debug = 0x1D66B4,
            T2108Debug = 0x6181F4,
            T2109Debug = 0x6181F4,
            UC1100Debug = 0x102057,
            UC1102Debug = 0x102187,
            UC2100Debug = 0x1EB297,
            UC2102Debug = 0x3F7A26,
            UC3100Debug = 0x168EB7,
            UC3102Debug = 0x578227,
            UC4100Debug = 0x5257DA,       //! TEST ME
            UC4101_106Debug = 0x12980E,   //! TEST ME
            UC4108_111Debug = 0x1C738B,   //! TEST ME
            UC4112_113Debug = 0x1C7CAB,   //! TEST ME
            UC4115Debug = 0x41885E,       //! TEST ME
            UC4116Debug = 0x41886E,       //! TEST ME
            UC4117Debug = 0x4188DD,       //! TEST ME
            UC4118_119Debug = 0x1CCC36,   //! TEST ME
            UC4120MPDebug = 0x1CCDAA,     //! TEST ME
            UC4120SPDebug = 0x1CCC0A,     //! TEST ME
            UC4121MPDebug = 0x1CCE25,     //! TEST ME
            UC4121SPDebug = 0x1CCDEA,     //! TEST ME
            UC4122_125MPDebug = 0x1CCE25, //! TEST ME
            UC4122_125SPDebug = 0x1CCDEA, //! TEST ME
            UC4127_132MPDebug = 0x1CCE85, //! TEST ME
            UC4127_133SPDebug = 0x1CCDEA, //! TEST ME
            UC4133MPDebug = 0x1CCEA5,     //! TEST ME
            UC4MPBETA100Debug = 0x4C1B54,
            UC4MPBETA109Debug = 0x4C1CC6,
            TLL100MPDebug = 0x1CCE25,
            TLL100Debug = 0x1CCFDA,
            TLLMP108Debug = 0x1CCE85,
            TLLMP109Debug = 0x1CCEA5,
            TLL10XDebug = 0x1CD01A,
            
            // PC Debug Offsets (0x97 -> 0x8F)
            T1X101Debug = 0x3B66CD,
            T1XL101Debug = 0x3B64B9,
            T1X1015Debug = 0x3B68FD,
            T1XL1015Debug = 0x3B66E9,
            T1X1016Debug = 0x3B690D,
            T1XL1016Debug = 0x3B66E9,
            T1X1017Debug = 0x3B6A2E,
            T1XL1017Debug = 0x03B680A,
            T1X102Debug = 0x3B6AA9,
            T1XL102Debug = 0x3B6885,

            Empty = 0xDEADDAD
        }

    #endregion
    }




    //=================================\\
    //-|   Custom Class Extensions   |-\\
    //=================================\\
    #region [Class Extensions]
    

    /// <summary>
    /// Custom TextBox Class to Better Handle Default TextBox Contents.
    /// </summary>
    public class TextBox : System.Windows.Forms.TextBox
    {
        /// <summary> Create New Control Instance. </summary>
        public TextBox()
        {
            IsDefault = true;
            TextChanged += SetDefaultText; // Save the first Text assignment as the DefaultText

            GotFocus += ReadyControl;
            LostFocus += ResetControl; // Reset control if nothing was entered, or the text is a portion of the default text
        }




        // Default Control Text to Be Displayed When "Empty".
        private string DefaultText;

        // Help Better Keep Track of Whether the User's Changed the Text, Because I'm a Moron.
        public bool IsDefault { get; private set; }


  

        /// <summary> Yoink Default Text From First Text Assignment (Ideally right after being created). </summary>
        private void SetDefaultText(object _, EventArgs __)
        {
            DefaultText = Text;

            TextChanged -= SetDefaultText;
            TextChanged += (sender, e) =>
            {
                IsDefault = false;
                Text = Text.Replace("\"", string.Empty);
            };
        }


        private void ReadyControl(object eat, EventArgs pant)
        {
            if(IsDefault) {
                IsDefault = false;
                Clear();

                Font = Common.TextFont;
                //TextAlign = HorizontalAlignment.Left; // Disabled alignment change until I can figure out the looping logic that results from it
            }
        }

        public void Reset() => ResetControl(true, null);
        private void ResetControl(object bite, EventArgs me)
        {
            if(Text.Length < 1 || DefaultText.Contains(Text) || (me == null && (bool)bite)) {
                IsDefault = true;
                Text = DefaultText;

                Font = Common.DefaultTextFont;
                //TextAlign = HorizontalAlignment.Center; // Disabled alignment change until I can figure out the looping logic that results from it (seriously, what the fuck?)
            }
        }


        /// <summary> Set Control Text and State Properly (meh). </summary>
        public void Set(string text)
        {
            if (text != string.Empty && !DefaultText.Contains(text))
            {   
                Font = Common.DefaultTextFont;
                IsDefault = false;
                Text = text;
            }
        }
    }



    /// <summary>
    /// Custom Button Class extention so I can attach a value to them. (saving the Tag property for hint text later on)
    /// </summary>
    public class Button : System.Windows.Forms.Button
    {
        /// <summary> Initialize a new instance of the Dobby.Button class extention. </summary>
        public Button()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(100, 100, 100);

            Font = new Font("Cambria", 9.25F, FontStyle.Bold);
            Cursor = Cursors.Cross;


            //Variable = null;
            VariableTags = null;
            hasEvents = false;
            

            MouseDown += (sender, _) => ForeColor = Color.FromArgb(255, 227, 0);
            MouseUp += (sender, _) => ForeColor = Color.FromArgb(255, 255, 255);
        }



        //#
        //## Variable Declarations
        //#

        /// <summary>
        /// Custom value associated with the control to be rendered alongside it, and edited via manually assigned per-control events.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // Designer autogenerates code settings the Variable & VariableTags properties to null, annoyingly. More of an issue for the former though, due to the Properties window not letting you edit objects
        [TypeConverter(typeof(BooleanConverter))]
        //[DefaultValue(false)]
        public object Variable
        {
            get => _Variable;

            set {
                if (value != null && value.ToString().Length > 0)
                {
                    _Variable = value;
                    this.ResetFlagsandPaint();

                    if (!hasEvents) {
                        Paint += DrawButtonVariable;

                        MouseDown += (eugh, meh) => SavePreInputVariable(Variable);
                        MouseUp += CycleButtonVariable;
                        MouseWheel += CycleButtonVariable;

                        hasEvents = true;
                    }
                }
                else {
                    if (hasEvents) {
                        Paint -= DrawButtonVariable;

                        MouseDown -= (eugh, meh) => SavePreInputVariable(Variable);
                        MouseUp -= CycleButtonVariable;
                        MouseWheel -= CycleButtonVariable;
                        
                        hasEvents = false;
                    }

                    _Variable = value;
                }
            }
        }
        private object _Variable;
        private object _preInputvariable;


        /// <summary>
        /// An Array of names to display in place of basic values.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public string[] VariableTags;



        /// <summary>
        /// //! Write a fuckin' summary, dicksneeze.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object MinimumValue
        {
            get => minValue;

            set {
                if (value != null)
                {
                    if (MaximumValue != null)
                    {
                        if (!value.GetType().Equals(MaximumValue.GetType()))
                        {
                            Common.Print($"ERROR: Mismatch in {Name} Min/Max Value Types. (Min: {MinimumValue.GetType()} && Max: {MaximumValue.GetType()})");
                        }
                    }

                    if (Variable != null)
                    {
                        if (!value.GetType().Equals(Variable.GetType()))
                        {
                            Common.Print($"ERROR: Mismatch in {Name} MinimumValue and Variable Types. (Min: {MinimumValue.GetType()} && Variable: {Variable.GetType()})");
                        }
                    }
                }

                minValue = value;
            }
        }
        private object minValue;


        
        /// <summary>
        /// //! Write a fuckin' summary, dicksneeze.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object MaximumValue
        {
            get => maxValue;

            set {
                if (value != null)
                {
                    if (MinimumValue != null)
                    {
                        if (!value.GetType().Equals(MinimumValue.GetType()))
                        {
                            Common.Print($"ERROR: Mismatch in {Name} Min/Max Value Types. (Min: {MinimumValue.GetType()} && Max: {MaximumValue.GetType()})");
                        }
                    }

                    if (Variable != null)
                    {
                        if (!value.GetType().Equals(Variable.GetType()))
                        {
                            Common.Print($"ERROR: Mismatch in {Name} MaximumValue and Variable Types. (Max: {MaximumValue.GetType()} && Variable: {Variable.GetType()})");
                        }
                    }
                }

                maxValue = value;
            }
        }
        private object maxValue;


        private bool hasEvents; // Lazy Fix


        new public object Tag
        {
            get => base.Tag;
            
            set {
                if (value?.ToString()?.Length > 0)
                {
                    MouseEnter += Common.HoverString;
                }
                else {
                    MouseEnter -= Common.HoverString;
                }

                base.Tag = value;
            }
        } 



        //#
        //## Function Declarations
        //#
        
        private void SavePreInputVariable(object variable)
        {
            _preInputvariable = variable;
        }



        /// <summary>
        /// Lazy (potential) fix
        /// </summary>
        private void CycleButtonVariable(object sender, EventArgs args) => CycleButtonVariable(sender, new MouseEventArgs(MouseButtons.Right, 1, MousePosition.X, MousePosition.Y, 0));

        /// <summary>
        /// Toggle between various states of custom Button controls
        /// </summary>
        /// <param name="sender"> The control to edit the variable of. </param>
        private void CycleButtonVariable(object sender, MouseEventArgs eventArgs)
        {
            var type = Variable?.GetType();
            var inc = 1f;


            // Not entirely certain this is actually required anymore
            if (((Control)sender) != Common.HoveredControl)
            {
                Common.Print("CycleButtonVariable(): Control changed, aborting variable cycling.");
                return;
            }



            // Check for null variable / type.                (not that I know how the latter would be null without the former being null as well, rendering the following check redundant... meh, I'm leaving both checks anyway)
            if (Variable == null) {
                Common.Print("CycleButtonVariable(): Control's variable type was somehow null (wtf??), fix your trash.");
                return;
            }
            if (type == null) {
                Common.Print("CycleButtonVariable(): Control's variable was null, fix your trash.");
                return;
            }


            // Avoid incrementing options on MouseUp events when the scroll wheel was already used
            if (Variable != _preInputvariable && eventArgs.GetType().Name != "HandledMouseEventArgs")
            {
                Common.Print("Variable has been scrolled, avoiding click incrementation");
                return;
            }



            //
            if (type == typeof(bool))
            {
                goto Bool;
            }


            // Assign the value that the control's variable is to be incremented by
            if (eventArgs.Delta != 0)
            {
                // 
                if (type == typeof(float))
                {
                    inc = eventArgs.Delta / 1200.0f;
                }
                if (type == typeof(int) || type == typeof(byte))
                {
                    inc = eventArgs.Delta / 12;

                }

                //
                if (Common.MouseIsDown)
                {
                    if (Common.ActiveMouseButton == MouseButtons.Right) {
                        inc *= .1f;
                    }
                    else {
                        inc *= 10.0f;
                    }
                }
            }
            else
            {
                if (type == typeof(float))
                {
                    inc = 0.25f;
                }
                if (type == typeof(int) || type == typeof(byte))
                {
                    inc = 5;

                }


                if (eventArgs.Button == MouseButtons.Right) {
                    inc = -inc;
                }
            }



            //#
            //## Booleans (default)
            //#
            Bool:
            if (type == typeof(bool))
            {
                if (MaximumValue != null)
                    Common.Print("WARNING: A maximum value was for some reason provided for a button with a boolean variable attached");

                Variable = !(bool) Variable;
                return;
            }


            
            //#
            //## Integers
            //#
            if (type == typeof(int))
            {
                if (MaximumValue == null)
                {
                    Variable = (int) ((int)Variable + inc);
                }
                else {
                    // avoid going out of bounds in the VariableTags array
                    if (VariableTags.Length < (long)MaximumValue)
                    {
                        MaximumValue = VariableTags.Length;
                        Common.Print($"ERROR: Maximum value for control Variable was larger than the amount of provided VariableTags; lowered maxValue to [{MaximumValue}]");
                    }

                    if (MaximumValue == Variable) //! this might compare types when they're both objects...
                    {
                        Variable = MinimumValue ?? 0;
                    }

                }

                return;
            }


            
            //#
            //## Bytes
            //#
            if (type == typeof(byte))
            {
                if (MaximumValue == null)
                {
                    Variable = (byte) ((byte)Variable + inc);
                }
                else {
                    // Avoid going out of bounds in the VariableTags array
                    if (VariableTags.Length < (long)MaximumValue)
                    {
                        MaximumValue = VariableTags.Length;
                        Common.Print($"ERROR: Maximum value for control Variable was larger than the amount of provided VariableTags; lowered maxValue to [{MaximumValue}]");
                    }

                    if (MaximumValue.Equals(Variable))
                    {
                        Variable = MinimumValue ?? 0;
                    }

                }

                return;
            }


            
            
            //#
            //## Floating-Points
            //#
            if (type == typeof(float))
            {
                Variable = (float) Math.Round((float)Variable + inc, 3);

                if (MaximumValue != null)
                {
                    if ((float)Variable >= (float)MaximumValue)
                    {
                        Variable = (float) Math.Round((float)(MinimumValue ?? 0), 2);
                    }

                    else if ((float)Variable <= (float)MinimumValue)
                    {
                        Variable = (float) Math.Round((float)(MinimumValue ?? 10), 2);
                    }
                }
            }
        }




        /// <summary>
        /// Draw the string representation of the Dobby.Button's Variable property to the right of the control text.
        ///</summary>
        private void DrawButtonVariable(object item, PaintEventArgs paintEvent)
        {
            // Convert control to avoid constant casting
            var control = item as Dobby.Button;
            string variableText = null;
            var padding = 5; // distance from the right-most bounds of the control to the start of the control's Text (at least, seems to be for the font and size most of the buttons are using)


            float
                controlTextSize = paintEvent.Graphics.MeasureString(control.Text, control.Font).Width,
                variableSize,
                expectedSize,
                baseContentSize
            ;


            // Check for stupidity.
            if (control.Variable == null) {
                Common.Print($"!! ERROR: Variable property for control \"{control.Name}\" was null");
                return;
            }

            
            

            //#
            //## Boolean
            //#
            if (control.Variable.GetType() == typeof(bool))
            {
                if (control.VariableTags != null)
                {
                    if (control.VariableTags.Length > 2)
                        Common.Print($"WARNING: Invalid VariableTags array provided for boolean toggle; ignoring [{control.VariableTags.Length-2}] tag(s)");
                    
                    if (control.VariableTags.Length < 2)
                        Common.Print($"ERROR: Invalid VariableTags array provided for boolean toggle; less than two options provided ({control.VariableTags.Length})"); // output tag array length in case it's somehow negative, I suppose

                    else
                        variableText = control.VariableTags[(bool)control.Variable ? 1 : 0];
                    
                }
                else {
                    variableText = (bool) control.Variable ? "Yes" : "No";
                }
            }

            
            //#
            //## Integer
            //#
            if (control.Variable.GetType() == typeof(int) || control.Variable.GetType() == typeof(byte))
            {
                if (control.VariableTags != null)
                {
                    if (control.VariableTags.Length > (int)control.Variable)
                        Common.Print($"WARNING: Invalid VariableTags array provided for boolean toggle; ignoring [{control.VariableTags.Length-2}] tag(s)");
                    
                    else if (control.VariableTags.Length < (int)control.Variable)
                        Common.Print($"ERROR: Invalid VariableTags array provided for boolean toggle; less than two options provided ({control.VariableTags.Length})"); // output tag array length in case it's somehow negative, I suppose

                    variableText = control.VariableTags[(int)control.Variable];
                    
                }
                else {
                    variableText = control.Variable.ToString();
                }
            }
            
            //#
            //## Floating-Points
            //#
            if (control.Variable.GetType() == typeof(float) || control.Variable.GetType() == typeof(double))
            {
                if (control.VariableTags != null)
                {
                    Common.Print("WARNING: variable tags provided for floating-point button variable, cannot use a floating-point as array index. (obviously)");
                    return;
                }

                variableText = control.Variable.ToString();
            }


            //#
            //## Unexpected formats
            //#
            if (variableText == null)
            {
                Common.Print($"WARNING: An unexpected data type was provided for the Variable tied to control \"{control.Name}\". Using unformatted string representation. (Type: {control.Variable.GetType()})");
                variableText = $"{(control.Variable ?? (object) "null")}";
            }




            // Design-related bits //!
            variableSize = paintEvent.Graphics.MeasureString(variableText, control.Font).Width;
            baseContentSize = controlTextSize + padding;
            expectedSize = baseContentSize + variableSize + (padding * 2);

            if (expectedSize != control.Width)
            {
                control.Width = (int) expectedSize - 1;
            }
            


            // Draw the Variable's string representation appended to the control's text (visually)
            paintEvent.Graphics.DrawString(variableText, Common.SmallControlFont, Brushes.LightGreen, new Point((int) baseContentSize + (padding * 2), 5));
        }

    }
    #endregion [Class Extensions]
}
