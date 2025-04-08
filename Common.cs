using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
#if DEBUG
#endif


namespace Dobby {
    
    internal partial class Common : MainPage, IDisposable {
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
        public static GameID Game = GameID.Empty;

        /// <summary> ID for the currently loaded form. </summary>
        public static PageID? Page;
        public static List<PageID?> Pages = new List<PageID?>();

        public static bool
            MouseScrolled,
            MouseIsDown,
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

        public static string ActiveGameID = string.Empty;


        
        /// <summary>
        /// The FileStream used for checking and patching the provided executable (well, ideally an executable. I'm not their boss).
        /// </summary>
        public static FileStream fileStream;
        
        
        /// <summary> Debug class instance. </summary>
        public static Testing Dev;
    #if DEBUG
        private static DebugWindow DebugWindow;
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
        public static Font DefaultTextFont = new Font("Cambria", 10F, FontStyle.Bold | FontStyle.Italic);


        public static Color MainColour = Color.FromArgb(100, 100, 100);
        public static Color HighlightColour
        {
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

        private static string InfoText;

        private static int InfoFlashes = -1;

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
        /// Convert a provided object in to a byte array, then writes it to the current position in the active file stream.
        /// </summary>
        /// <param name="data"> The object to convert and write. </param>
        public static void WriteVar(FileStream fileStream, long address, object data)
        {
            var type = data?.GetType();
            #if DEBUG
            var msg = $"] Written To 0x{fileStream.Position:X} ({type})\n";
            #endif


            if (address != 0xDEADDAD)
            {
                fileStream.Position = address;
            }
            if (data == null)
            {
                data = (byte) 0x00;
            }



            // Write provided data
            if (type == typeof(int))
            {
                fileStream.Write(BitConverter.GetBytes((int)data), 0, 4);

                #if DEBUG
                msg = $"[{(int)data} => {BitConverter.ToString(BitConverter.GetBytes((int)data)).Replace("-", ", 0x")}" + msg;
                #endif
            }
            else if (type == typeof(byte))
            {
                data = Convert.ToByte(data); // why the fuck does casting a byte throw an invalid cast exception?? and why only for 1's but not 0's???
                fileStream.WriteByte((byte)data);

                #if DEBUG
                msg = $"[{(byte)data} => {((byte)data).ToString("X").PadLeft(2, '0')}" + msg;
                #endif
            }
            else if (type == typeof(byte[]))
            {
                fileStream.Write((byte[])data, 0, ((byte[])data).Length);

                #if DEBUG
                msg = $"[0x{BitConverter.ToString((byte[])data).Replace("-", ", 0x")}" + msg;
                #endif
            }
            else if (type == typeof(bool))
            {
                fileStream.WriteByte((byte)((bool)data ? 1 : 0));

                #if DEBUG
                msg = $"[{(bool)data} => {((bool)data ? 1 : 0)}" + msg;
                #endif
            }
            else if (type == typeof(float))
            {
                fileStream.Write(BitConverter.GetBytes((float)data), 0, BitConverter.GetBytes((float)data).Length);

                #if DEBUG
                msg = $"[{(float)data} => 0x{BitConverter.ToString(BitConverter.GetBytes((float)data)).Replace("-", ", 0x")}" + msg;
                #endif
            }

            else
                Dev.Print($"ERROR: Unexpected Variable type ({type}).");


            // Manually flush the stream just in case
            fileStream.Flush(true);
                
            #if DEBUG
            Dev.Print(msg);
            #endif
        }
        
        
        /// <summary>
        /// WriteVar() shorthand for writing the same data to multiple addresses.
        /// </summary>
        /// <param name="data"> The data to write to the provided addresses. </param>
        /// <param name="addresses"> The addresses to write the data to each of. </param>
        public static void WriteVar(FileStream fileStream, long[] addresses, object data) => Array.ForEach(addresses, address => WriteVar(fileStream, address, data));

        /// <summary>
        /// WriteVar() shorthand for writing to the file without seaking to a different position in the stream.
        /// </summary>
        /// <param name="data"> The data to write to the provided addresses. </param>
        public static void WriteVar(FileStream fileStream, object data) => WriteVar(fileStream, 0xDEADDAD, data);



        public static int FindSubArray(byte[] array, byte[] subarray)
        {
            for (var i = array.Length - 1; i >= subarray.Length; --i)
            {
                if (array[i] == subarray.Last())
                {
                    var j = subarray.Length;

                    for (; j > 0; --j)
                    {
                        if (array[i - (j - 1)] != subarray[(subarray.Length) - (j)])
                            break;

                    }
                    if (j == 0) {
                        return i - subarray.Length + 1;
                    }
                }
            }

            return -1;
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

        public static void CreateInfoLabelUpdater()
        {
            LabelUpdateThread = new Thread(LabelUpdateMethod) {
                Name = "MainPage Label Update Worker"
            };

            LabelUpdateThread.Start();
        }

        /// <summary>
        /// Update the current label text and/or apply a flashing effect to the label to signify an error.
        /// </summary>
        /// <param name="newText"> The string to apply to the label's Text property. </param>
        /// <param name="flashLabel"> If true, flash the label to indicate an error or otherwise get the user's attention. (switches between white/yellow) </param>
        public static void UpdateLabel(string newText, bool flashLabel = false)
        {
            if ((InfoText == " " || InfoText == null) && newText != null && InfoLabel.Text != newText)
            {
                InfoText = newText;
            }

            if (flashLabel)
            {
                InfoFlashes = 15;
            }
        }

        /// <summary>
        /// Loads The Specified Page From The PageId Group (E.g. ChangeForm(PageID.PS4MiscPageId))
        /// </summary>
        /// <param name="Page"> The Page To Change To. </param>
        public static void ChangeForm(PageID? Page, bool ReturningToPreviousPage = false)
        {
            if (DisableFormChange) {
                UpdateLabel("Disabled during .gp4 / .pkg Creation Process.");
                Dev.Print($"Ignoring request to change form to \"{Page ?? 0}\".");
                return;
            }
            else {
                InfoFlashes = -1;
                InfoText = null;
                InfoLabel = null;
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
                    Dev.Print($"{Page} Is Not A Page!");
                    return;
            }

            
            LastFormPosition = ActiveForm.Location;
            var PageToClose = ActiveForm;

            
            // Subtract a page from the list of previous pages when going back one
            if (ReturningToPreviousPage)
                Pages.RemoveAt(Pages.Count - 1);
            else
                Pages.Add(Common.Page);

            
            NewPage?.Show();
#if DEBUG
            DebugWindow?.SetDebugWindowParent(NewPage);
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
            var Venat = Controls.Owner;

            //#
            //## Mass-Apply handler methods to basic MouseDown/Up, MouseEnter/Leave and MouseMove events
            //#
            foreach (Control item in Controls)
            {
                item.MouseDown += new MouseEventHandler(MouseDownFunc);
                item.MouseUp += new MouseEventHandler(MouseUpFunc);

                // Apply the seperator drawing function to any seperator lines
                if (item.Name.Contains("SeperatorLine") && item.GetType() == typeof(Label))
                {
                    item.Paint += DrawSeperatorLine;
                }

                // Apply the event used in dragging the form, avoiding text boxes to avoid removing the ability to drag-select text.
                if (!(item.Name.Contains("Box") && (item.GetType() == typeof(TextBox) || item.GetType() == typeof(RichTextBox)))) // So You Can Drag Select The Text Lol
                {
                    item.MouseMove += new MouseEventHandler(MoveForm);
                }

                // Apply the Hint function to the mouse enter event, applying the resetter tag to any controls sans Tags.
                if (item.Tag == null)
                {
                    item.Tag = " ";
                }
                item.MouseEnter += HoverString;



                // Avoid assigning a hover arrow to unintended controls (blacklisted ones, and any non-button controls)
                var blacklistedItems = new string[] {
                    "DebugControl",
                    "ExitBtn",
                    "MinimizeBtn",
                    "LabelBtn",
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



            //#
            //## Create Exit And Minimize Buttons, And Add Them To The Top Right Of The Form
            //#
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



            //#
            //## Apply event handlers and tags to the common buttons at the bottom of each page
            //#

            // Apply Info & Credits page crap, unless we're on one of those pages already
            if (!new string[] { "InfoHelpPage", "CreditsPage" }.Contains(Venat.Name))
            {
                var helpPageButton = Controls.Owner.Controls.Find("InfoHelpBtn", true)?.Last();
                helpPageButton.Click += (_, __) => ChangeForm(PageID.InfoHelpPage);
                helpPageButton.Tag = "View explanations for each page/other info";
                
                var creditsPageButton = Controls.Owner.Controls.Find("CreditsBtn", true)?.Last();
                creditsPageButton.Click += (_, __) => ChangeForm(PageID.CreditsPage);
                creditsPageButton.Tag = "View various credits for the application.";
            }


            // Avoid searching for a back button on Main page
            if (Venat.Name != "MainPage")
            {
                var backButton = Controls.Owner.Controls.Find("BackBtn", true)?.Last();

                backButton.Click += (_, __) => ChangeForm(null);
                backButton.Tag = "Return to the previous page";
            }


            // Attempt to assign static Info label refference for bs globals
            try {
                int num;
                InfoLabel = (Label)Controls.Owner.Controls.Find("Info", true)?.Last();

                InfoLabel.Text = string.Empty;
                InfoLabel.Tag = ((num = new Random().Next() & 1) + (num >> num & 1)) == 0 ? "hey get that mouse off my face >:(" : " "; // appy a joke tag if a two random numbers are both even (for shits and giggles)
            }
            catch (InvalidOperationException) {
                Dev.Print("ERROR: Form does not contain an info label (or it has not been named \"Info\").");
            }
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
                Dev.Print($"Error Getting Width Of Hover Arror From Control ({PassedControl.Name}: {(EventIsMouseEnter ? "Hover" : "Leave")})");
                Dev.PrintError(ex);
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

            if (item == null)
            {
                Dev.Print("!! ERROR: Invalid control passed as Seperator line.");
                Dev.Print($"  - Control \"{item.Name}\" location: {item.Location}.");
            }
            if (item.Name == "SeperatorLine0" && item.Location != new Point(2, 20))
            {
                Dev.Print($"Seperator Line 0 Improperly positioned on {item.Parent.Name}");
            }
            if (item.Height != 15)
            {
                Dev.Print($"# WARNING: \"{item.Name}\" has an invalid height!!! (Label is {item.Height} pixels in hight)");
            }
            if (!(item.Location.X == 2 && item.Width == item.Parent.Width - 4))
            {
                Dev.Print($"Moved And Resized {item.Name} ({item.Parent.Name}).");

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
        private static void LabelUpdateMethod()
        {
            LabelUpdateCallback setLabelState = (label, colour, text) => {
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
                    Dev.Print("Error setting label text and / or colour.");
                }
            };


            // Main thread loop
            while (true) {
                try {
                    // Wait for something to do
                    for (;InfoLabel == null || InfoFlashes == -1 && InfoText == null; Thread.Sleep(1));
                        

                    // Try to avoid hiding hint strings with the label reset
                    if (InfoText != null && InfoText == " ")
                    {
                        for (var time = 0; InfoText == " " && time++ < 35; Thread.Sleep(1));
                    }


                    // Flash the label if applicable
                    for (var notifyMessage = InfoText; InfoFlashes != -1;)
                    {
                        while (ActiveForm == null)
                            Thread.Sleep(1);

                        ActiveForm?.Invoke(setLabelState, InfoLabel, (InfoFlashes-- & 1) == 0 ? Color.FromArgb(255, 227, 0) : Color.White, notifyMessage);
                        
                        if (InfoFlashes == -1)
                        {
                            InfoText = null;
                            break;
                        }

                        Thread.Sleep(135);
                    }

                    // Set The Text of The Yellow Label At The Bottom Of The Form
                    if (InfoText != null)
                    {
                        ActiveForm?.Invoke(setLabelState, InfoLabel, Color.FromArgb(255, 227, 0), InfoText);
                        InfoText = null;
                    }
                }
                catch (Exception) {
                    Dev.Print("Form Changed or Lost Focus, Killing Label Flash");

                    while (ActiveForm == null)
                        Thread.Sleep(1);
                }
            }
        }

        #endregion (form/control drawing-related functions)

        #endregion [Static Background Function Declarations]





        //=============================================\\
        //--|   Static Event Handler Declarations   |--\\
        //=============================================\\
        #region [Static Event Handler Declarations]

        #if DEBUG
        public static void LogBtn_Click(object sender, EventArgs args) {
            if (DebugWindow != null) {
                DebugWindow?.Dispose();
                DebugWindow = null;
            }
            else
            {
                // Create the log window and make it invisible until it's been moved to the parent form.
                DebugWindow = new DebugWindow(((Control)sender).FindForm()) {
                    Visible = false
                };

                DebugWindow.Show();
                DebugWindow.MoveLogToAppEdge();
                DebugWindow.Visible = true;
            }
        }
        #endif
        
        internal static void ExitBtn_Click(object sender, EventArgs e)
        {
            MainForm.Dispose();  //! 90% sure this isn't implemented properly.
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
            DebugWindow?.MoveLogToAppEdge();
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
            try {
                // Oh my god fuck it, lazy fix for winforms stupid fucking asynchronous contol initialization, god I fucking hate this stupid clunky bullshit sometimes, how the fuck is the control null after being created, initialzed, and added to the form??? I CAN LITERALLY SEE THE CONTROL, IT'S NOT FUCKING NULL
                if (InfoLabel == null && ((Control)sender).FindForm().Name == "MainPage")
                {
                    InfoLabel = (Label) MainForm.Controls.Find("Info", true)?[0];
                }

                if (((string) ((Control)sender).Tag ?? string.Empty).Length > 0) //! test this
                {
                    UpdateLabel((string) ((Control)sender).Tag);
                }
                else
                    Dev.Print($"Label not updated due to empty tag or active flash thread {InfoFlashes} {InfoText?.Length ?? 0xDEADDAD}");
            }
            catch (InvalidCastException)
            {
                Dev.Print("ERROR: A Non-string value was assigned to a control tag");
            }
        }
        #endregion
    }
}
