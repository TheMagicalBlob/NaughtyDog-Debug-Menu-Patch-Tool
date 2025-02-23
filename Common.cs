using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using libdebug;
#if DEBUG
using System.Diagnostics;
#endif

namespace Dobby {
    
    internal class Common : Main, IDisposable {
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
            FormActive,
            InfoHasImportantStr,
            IsPageGoingBack,
            LastMsgOutputWasInfoString,
            LabelShouldFlash,
            FlashThreadHasStarted,
            IsActiveFilePCExe,
            DisableFormChange
        ;

        public static Point
            LastFormPosition,
            MousePos,
            MouseDif
        ;

        public static Point[] OriginalControlPositions;

        public static Size OriginalFormScale = Size.Empty;
        public static Size OriginalBorderScale;

        public static string
            CurrentControl,
            ActiveGameID = "UNK"
        ;
        
        
    #if DEBUG
        /// <summary> Debug class instance. </summary>
        public static Testing Dev;
        //!
        public static int tmp = 1;
    #endif
        #endregion



        //#
        //## Control Refferences
        //#
        #region [Control Refferences]
        /// <summary> Refference to the originally launched form. </summary>
        private static Form MainForm;
        public static Form PopupBox;

        /// <summary> Refference to the current form's Info label. </summary>
        public static Control InfoLabel;

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

            set { BorderPen.Color = value; ActiveForm?.PerformLayout(); ActiveForm?.Update(); }
        }

        ///<summary> Form Border Pen </summary>
        private static Pen BorderPen = new Pen(Color.White);
        #endregion
        


        //#
        //## Threading Components
        //#
        #region [Threading Components]

        public static Thread LabelFlashThread;

        public delegate void LabelUpdateCallback(string InfoText);

        public delegate void LabelFlashCallback(Label control, System.Drawing.Color colour);
        #endregion



        //#
        //## Network-Related Components
        //#
        #region [Network-Related Components]

        public static TcpClient TcpClient;
        public static NetworkStream NetStream;
        #endregion

        #endregion (global variable declarations)

        
        //========================================\\
        //--|   Global Function Declarations   |--\\
        //========================================\\
        #region [Global Function Declarations]

        /// <summary>
        /// Dev.Print overload, for some reason. //!
        /// </summary>
        public static void Print(object message = null)
        {
            #if DEBUG
            Dev.Print(message);
            #endif
        }

        /// <summary>
        /// Basic error logging function (not yet fully implemented)
        /// </summary>
        public static void PrintError(Exception tabarnack) {
#if DEBUG
            Print($"!! ERROR: {tabarnack.Message}\n{tabarnack.StackTrace.Replace("\n", "  \n")}");
#endif
        }


        
        public static void FlashLabel(Label label, string error = null)
        {
            if (LabelFlashThread == null || LabelFlashThread.ThreadState == System.Threading.ThreadState.Stopped)
                (LabelFlashThread = new Thread(LabelFlashMethod)).Start(label);
        }

        
        public static string GetCurrentGame(FileStream stream) {
            var LocalExecutableCheck = new byte[160];

             
            stream.Position = 0;
            stream.Read(LocalExecutableCheck, 0, 4);
            if (BitConverter.ToInt32(LocalExecutableCheck, 0) != 1179403647)
                MessageBox.Show($"Executable Still Encrypted (self) | Must Be Decrypted/Unsigned");


            stream.Position = 0x5100;
            stream.Read(LocalExecutableCheck, 0, 160);
            Game = (GameID)BitConverter.ToInt32(SHA256.Create().ComputeHash(LocalExecutableCheck), 0);

            switch (Game) {
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


        /// <summary> Save a refference to the orignal launch form. (why is this a function, again? //!) </summary>
        /// <param name="form"> The orignal form </param>
        public static void SaveMainForm(Form form) => MainForm = form;

                
        /// <summary>
        /// Toggle between various states of custom Button controls
        /// </summary>
        /// <param name="sender"> The control to edit the variable of </param>
        public static void CycleButtonVariable<T>(object sender, object maxValue = null, object minValue = null, MouseEventArgs eventArgs = null)
        {
            var control = (Dobby.Button) sender;
            Type type = typeof(T);

            if (control.Variable == null) {
                Print("CycleButtonVariable(): Control's variable was null, fix your trash.");
            }



            //#
            //## Booleans
            //#
            if (type == typeof(bool))
            {
                if (maxValue != null)
                    Print("WARNING: A maximum value was for some reason provided for a button with a boolean variable attached");


                control.Variable = !(bool) control.Variable;
                return;
            }

            
            //#
            //## Integers
            //#
            if (type == typeof(int) || type == typeof(long))
            {
                if (maxValue == null) {
                    control.Variable = (long)control.Variable + 1;
                }
                else {
                    // avoid going out of bounds in the VariableTags array
                    if (control.VariableTags.Length < (long)maxValue)
                    {
                        maxValue = control.VariableTags.Length;
                        Print($"ERORR: Maximum value for control Variable was larger than the amount of provided VariableTags; lowered maxValue to [{maxValue}]");
                    }

                    if (maxValue == control.Variable) //! this might compare types when they're both objects...
                    {
                        control.Variable = minValue ?? 0;
                    }

                }

                return;
            }
            
            
            //#
            //## Floating-Points
            //#
            if (type == typeof(float) || type == typeof(double))
            {
                control.Variable = (double)control.Variable + eventArgs.Delta != 0 ? eventArgs.Delta / 2 : .1f;

                if (maxValue != null)
                {
                    if ((double)control.Variable >= (double)maxValue)
                        control.Variable = minValue ?? 0;

                    else if ((double)control.Variable <= (double)minValue)
                        control.Variable = minValue ?? 10;
                }
            }
        }


        public static RichTextBox CreateTextBox(string Title) {
            PopupGroupBox?.Dispose();

            PopupGroupBox = new GroupBox() {
                Cursor = Cursors.Cross,
                Size = new Size(250, ActiveForm.Size.Height - 65),
                Location = new Point(35, ActiveForm.Controls.Find("SeperatorLine0", true)[0].Location.Y + 8),
                BackColor = Color.FromArgb(255, Color.FromArgb(100, 100, 100))
            };

            var popupBoxLabel = new Label() {
                Text = Title,
                Font = new Font("Microsoft YaHei UI", 7.5F),
                Size = new Size(217, 21),
                Location = new Point(4, 8),
                ForeColor = SystemColors.Control,
                BackColor = Color.FromArgb(100, 100, 100)
            };
            var closeBtn = new Button() {
                Text = "X",
                Cursor = Cursors.Cross,
                Size = new Size(19, 19),
                BackColor = Color.FromArgb(100, 100, 100),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(228, 9),
                ForeColor = SystemColors.Control,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Cambria", 6.5F)

            };
            var textBox = new RichTextBox() {
                ReadOnly = true,
                Cursor = Cursors.Cross,
                Size = new Size(242, PopupGroupBox.Size.Height - 35),
                Location = new Point(4, 29),
                BackColor = Color.FromArgb(255, Color.DarkGray)
            };

            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.MouseClick += KillTextBox;
            PopupGroupBox.Controls.Add(textBox);
            PopupGroupBox.Controls.Add(closeBtn);
            PopupGroupBox.Controls.Add(popupBoxLabel);
            ActiveForm.Controls.Add(PopupGroupBox);

            PopupGroupBox.BringToFront(); textBox.BringToFront();
            closeBtn.BringToFront(); popupBoxLabel.BringToFront();

            return textBox;
        }

        private static void KillTextBox(object sender, MouseEventArgs e) => PopupGroupBox?.Dispose();


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
            SetInfoLabelText(InfoLabelString);
#pragma warning restore CS0162 // Unreachable code detected
        }
        #endregion



        
        //====================================================\\
        //--|   Static Background Function Delcarations   |---\\
        //====================================================\\
        #region [Static Background Function Delcarations]

        //#
        //## Form Functionality
        //#
        #region (form functionality)
        /// <summary>
        /// Loads The Specified Page From The PageId Group (E.g. ChangeForm(PageID.PS4MiscPageId))
        /// </summary>
        /// <param name="Page"> The Page To Change To. </param>
        public static void ChangeForm(PageID? Page, bool ReturningToPreviousPage = false)
        {
            if (DisableFormChange) {
                SetInfoLabelText("Disabled during .gp4 ? .pkg Creation Process.");
                Print($"Ignoring request to change form to \"{Page ?? 0}\".");
                return;
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
                    FormActive = false;
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
            Dev.ActivePage = NewPage;
#endif
            Common.Page = Page;
            InfoLabel = (Control)ActiveForm.Controls.Find("Info", true)[0];
            ActiveForm.Location = LastFormPosition;


            if (PageToClose.Name == "Main")
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
            void ApplyEventHandlersToControl(object sender) {

                // Convert the item to a basic control
                var Item = sender as Control;

    #if DEBUG
                Item.MouseEnter += new EventHandler((control, e) => Testing.HoveredControl = Item);
    #endif
                Item.MouseDown += new MouseEventHandler(MouseDownFunc);
                Item.MouseUp += new MouseEventHandler(MouseUpFunc);


                if (Item.Name.Contains("Seperator") && sender.GetType() == typeof(Label))
                    Item.Paint += DrawSeperatorLine;

                if (!(Item.Name.ToLower().Contains("box") && (sender.GetType() == typeof(TextBox) || sender.GetType() == typeof(RichTextBox)))) // So You Can Drag Select The Text Lol
                    Item.MouseMove += new MouseEventHandler(MoveForm);


                // Avoid assigning a hover arrow to unintended controls (blacklisted ones, and any non-button controls)
                if ((Item.GetType() == typeof(Dobby.Button) || Item.GetType() == typeof(System.Windows.Forms.Button)) && !new string[] { "DebugControl", "ExitBtn", "MinimizeBtn", "LabelBtn", "CmdPathBox", "Gp4PathBox"}.Contains(Item.Name))
                {
                    Item.MouseEnter += new EventHandler(ControlHover);
                    Item.MouseLeave += new EventHandler(ControlLeave);
                }
            }
            
            var ConstantControls = new string[] { "Info", "InfoHelpBtn", "CreditsBtn", "BackBtn" };
            var Parent = Controls.Owner.Name;

            Controls.Owner.Paint += DrawBorder;
            foreach (Control Item in Controls) {
                ApplyEventHandlersToControl(Item);

                if (Item.HasChildren) // Designer Adds Some Things To Other Controls Sometimes. This should fix those controls until I notice it. (I Am Lazy.)
                    foreach (Control Child in Item.Controls)
                        ApplyEventHandlersToControl(Child);
            }
            InfoLabel = (Control)(Controls.Find("Info", true)[0] ?? null);


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
                Cursor = Cursors.Cross,
            };

            MinimizeBtn.FlatAppearance.BorderSize = 0;
            Controls.Owner.Controls.Add(MinimizeBtn);
            MinimizeBtn.BringToFront();
            MinimizeBtn.Click += new EventHandler(MinimizeBtn_Click);
            MinimizeBtn.MouseEnter += new EventHandler(MinimizeBtnMH);
            MinimizeBtn.MouseLeave += new EventHandler(MinimizeBtnML);

            ExitBtn.FlatAppearance.BorderSize = 0;
            Controls.Owner.Controls.Add(ExitBtn);
            ExitBtn.BringToFront();
            
            ExitBtn.Click += new EventHandler(ExitBtn_Click);
            ExitBtn.MouseEnter += new EventHandler(ExitBtnMH);
            ExitBtn.MouseLeave += new EventHandler(ExitBtnML);



            // Avoid searching for back button on Main page
            if (Parent != "Main")
                Controls.Owner.Controls.Find(ConstantControls[3], true)[0].Click += (_, __) => ChangeForm(null);

            try {
                if (!Parent.Contains("Help") && Parent != "CreditsPage")
                    Controls.Owner.Controls.Find(ConstantControls[1], true)[0].Click += (_, __) => ChangeForm(PageID.InfoHelpPage);
                
                Controls.Owner.Controls.Find(ConstantControls[2], true)[0].Click += (_, __) => ChangeForm(PageID.CreditsPage);
                Controls.Owner.Controls.Find(ConstantControls[0], true)[0].Text = string.Empty;
            }
            catch (Exception) {}
        }


        /// <summary>
        /// Set The Text of The Yellow Label At The Bottom Of The Form
        /// </summary>
        internal static void SetInfoLabelText(string s)
        {
            if (ActiveForm != null)
                InfoLabel.Text = s;

            Print($"[info]: {s}");
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

            void HighlightItemOnMouseDown(object sender, MouseEventArgs e = null) => ((Control)sender).ForeColor = Color.FromArgb(255, 227, 0);
            void ResetItemHighlight(object sender, MouseEventArgs e = null) => ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);

            try {
                ArrowWidth = (int)PassedControl.CreateGraphics().MeasureString(">", PassedControl.Font).Width;
            }
            catch (Exception ex) {
                Print($"Error Getting Width Of Hover Arror From Control ({PassedControl.Name}: {(EventIsMouseEnter ? "Hover" : "Leave")})\n\nException Of Type: {ex.GetType()}\n{ex.Message}");
                return;
            }



            if (MouseScrolled = EventIsMouseEnter) { //! is this intentional? could swear it should only be set to false in one of the cases and left alone in the other, not set to true
#if DEBUG
                Testing.HoveredControl = PassedControl;
#endif
                CurrentControl = PassedControl.Name;
                PassedControl.MouseDown += HighlightItemOnMouseDown;
                PassedControl.MouseUp += ResetItemHighlight;

                PassedControl.Text = '>' + PassedControl.Text;
            }
            else {
                //ArrowWidth = ~ArrowWidth ^ 1; I'm an idiot, this is excessive lmao. keeping it as a reminder
                ArrowWidth = -ArrowWidth;

                PassedControl.MouseDown -= HighlightItemOnMouseDown;
                PassedControl.MouseUp -= ResetItemHighlight;

                PassedControl.Text = PassedControl.Text.Substring(1);
            }


            // Avoid resizing controls when they're already horizontally flush with the form
            if (PassedControl.Size.Width + PassedControl.Location.X == PassedControl.Parent.Size.Width - 1)
                return;


            // Resize controls to fit the arrow
            PassedControl.Size = new Size(PassedControl.Width + ArrowWidth, PassedControl.Height);
        }



        /// <summary>
        /// Draw the string representation of the Dobby.Button's Variable property to the right of the control text.
        ///</summary>
        public static void DrawButtonVariable(object item, PaintEventArgs paintEvent)
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
                Print($"!! ERROR: Variable property for control \"{control.Name}\" was null");
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
                        Print($"WARNING: Invalid VariableTags array provided for boolean toggle; ignoring [{control.VariableTags.Length-2}] tag(s)");
                    
                    if (control.VariableTags.Length < 2)
                        Print($"ERROR: Invalid VariableTags array provided for boolean toggle; less than two options provided ({control.VariableTags.Length})"); // output tag array length in case it's somehow negative, I suppose

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
            if (control.Variable.GetType() == typeof(int))
            {
                if (control.VariableTags != null)
                {
                    if (control.VariableTags.Length > (int)control.Variable)
                        Print($"WARNING: Invalid VariableTags array provided for boolean toggle; ignoring [{control.VariableTags.Length-2}] tag(s)");
                    
                    else if (control.VariableTags.Length < (int)control.Variable)
                        Print($"ERROR: Invalid VariableTags array provided for boolean toggle; less than two options provided ({control.VariableTags.Length})"); // output tag array length in case it's somehow negative, I suppose

                    variableText = control.VariableTags[(int)control.Variable];
                    
                }
                else {
                    variableText = (string) control.Variable;
                }
            }
            
            //#
            //## Floating-Points
            //#
            if (control.Variable.GetType() == typeof(float) || control.Variable.GetType() == typeof(double))
            {
                if (control.VariableTags != null)
                {
                    Print("WARNING: variable tags provided for floating-point button variable, cannot use a floating-point as array index. (obviously)");
                    return;
                }
            }


            //#
            //## Unexpected formats
            //#
            if (variableText == null)
            {
                Print($"WARNING: An unexpected data type was provided for the Variable tied to control \"{control.Name}\". Using unformatted string representation. (Type: {control.Variable.GetType()})");
                variableText = (string) (control.Variable ?? (object) "null");
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
            paintEvent.Graphics.DrawString(variableText, SmallControlFont, Brushes.LightGreen, new Point((int) baseContentSize + (padding * 2), 5));
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


        public static LabelUpdateCallback SetLabelText = value =>
        {
            if(ActiveForm != null)
                InfoLabel.Text = value;

            Print($"[info]: {value}");
        };


        /// <summary> Info Label Flash Delegate- for Cross-Threaded Label Setting. (I still suck with threads) </summary>
        public static readonly LabelFlashCallback SetLabelColour = (control, colour) =>
        {
            try {
                while (ActiveForm == null)
                    Thread.Sleep(1);

                control.ForeColor = colour;
                ActiveForm?.Update();
            }
            catch (Exception) {
                Print("Label Flash Interrupted.");
            }
        };


        /// <summary>
        /// Flash the Info label white/yellow to get the user's attention/indicate a skill issue.
        /// </summary>
        /// <param name="label"> The Control.Name property of the label to flash </param>
        public static void LabelFlashMethod(dynamic label) {
            try {
                for (int flashes = 0; flashes < 16; flashes++)
                {
                    ActiveForm?.Invoke(SetLabelColour, label, (flashes & 1) == 0 ? Color.FromArgb(255, 227, 0) : Color.White);
                    Thread.Sleep(135);
                }
            }
            catch (Exception) {
                Print("Form Changed or Lost Focus, Killing Label Flash");
                while (ActiveForm == null);
            }
            finally {
                ActiveForm?.Invoke(SetLabelColour, label, Color.FromArgb(255, 227, 0));
            }
        }
        #endregion
        #endregion

        

        //=============================================\\
        //--|   Static Event Handler Declarations   |--\\
        //=============================================\\
        #region [Static Event Handler Declarations]
        internal static void ExitBtn_Click(object sender, EventArgs e)
        {
            MainForm.Dispose();  //! 90% sure neither of these are implemented properly.
            #if DEBUG
            Dev.Dispose();       // ^
            #endif

            Environment.Exit(0); // off we fuck
        }
        internal static void ExitBtnMH(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 227, 0);
        internal static void ExitBtnML(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);
        internal static void MinimizeBtn_Click(object sender, EventArgs e) => ((Control)sender).FindForm().WindowState = FormWindowState.Minimized;
        internal static void MinimizeBtnMH(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 227, 0);
        internal static void MinimizeBtnML(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);

        internal static void MouseDownFunc(object sender, MouseEventArgs e)
        {
            MouseIsDown = true;
            
            LastFormPosition = ActiveForm?.Location ?? LastFormPosition; //! Lazy fix(?)
            MouseDif = new Point(MousePosition.X - LastFormPosition.X, MousePosition.Y - LastFormPosition.Y);
        }

        internal static void MouseUpFunc(object sender, MouseEventArgs e) {
            MouseScrolled = MouseIsDown = false;
        }

        public static void MoveForm(object sender, MouseEventArgs e)
        {
            if (!MouseIsDown || ActiveForm == null)
                return;

            ActiveForm.Location = new Point(MousePosition.X - MouseDif.X, MousePosition.Y - MouseDif.Y);
            ActiveForm.Update();
        }

        public static void ControlHover(object sender, EventArgs _ = null) => HoverLeave((Control)sender, true);
        public static void ControlLeave(object sender, EventArgs _ = null) => HoverLeave((Control)sender, false);
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
            TextChanged += SetDefaultText; // Save the first Text assignment as the DefaultText
            IsDefault = true;

            GotFocus += ReadyControl;
            LostFocus += ResetControl; // Reset control if nothing was entered, or the text is a portion of the default text
        }
  

        /// <summary> Yoink Default Text From First Text Assignment (Ideally right after being created). </summary>
        private void SetDefaultText(object _, EventArgs __) {
            DefaultText = Text;
            TextChanged -= SetDefaultText;
            TextChanged += (sender, e) => { Text = Text.Replace("\"", string.Empty); IsDefault = false; };
        }


        private void ReadyControl(object eat, EventArgs pant)
        {
            if(IsDefault) {
                Clear();
                IsDefault = false;

                Font = Common.TextFont;
                Console.WriteLine($"Readying Control \"{((Control)eat).Name}\"");
                //TextAlign = HorizontalAlignment.Left; // Disabled alignment change until I can figure out the looping logic that results from it
            }
        }


        private void ResetControl(object bite, EventArgs me)
        {
            if(Text.Length < 1 || DefaultText.Contains(Text)) {
                Text = DefaultText;
                IsDefault = true;

                Font = Common.DefaultTextFont;
                //TextAlign = HorizontalAlignment.Center; // Disabled alignment change until I can figure out the looping logic that results from it (seriously, what the fuck?)
            }
        }


        /// <summary> Set Control Text and State Properly (meh). </summary>
        public void Set(string text) {
            if (text != string.Empty && !DefaultText.Contains(text))
            {   
                Font = Common.DefaultTextFont;
                Text = text;
                IsDefault = false;
            }
        }





        // Default Control Text to Be Displayed When "Empty".
        private string DefaultText;

        // Help Better Keep Track of Whether the User's Changed the Text, Because I'm a Moron.
        public bool IsDefault { get; private set; }
        
    }



    /// <summary>
    /// Custom Button Class extention so I can attach a value to them. (saving the Tag property for hint text later on)
    /// </summary>
    public class Button : System.Windows.Forms.Button
    {
        public Button()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(100, 100, 100);

            Font = new Font("Cambria", 9.25F, FontStyle.Bold);
            Cursor = Cursors.Cross;


            Variable = null;
            VariableTags = null;
        }


        /// <summary>
        /// Custom value associated with the control to be rendered alongside it, and edited via manually assigned per-control events.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // Designer autogenerates code settings the Variable & VariableTags properties to null, annoyingly. More of an issue for the former though, due to the Properties window not letting you edit objects
        [DefaultValue(null)]
        [Browsable(false)]
        public object Variable
        {
            get => _Variable;

            set {
                if (value != null && value.ToString().Length > 0)
                    Paint += Common.DrawButtonVariable;
                else
                    Paint -= Common.DrawButtonVariable;

                _Variable = value;
            }
        }
        private object _Variable;


        /// <summary>
        /// An Array of names to display in place of basic values.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public string[] VariableTags
        {
            get => _VariableTags;

            set {
                //Common.Print($"{value}");
                //if (value != null)
                //{
                //    if (value.GetType() != typeof(int) && value.GetType() != typeof(bool)) {
                //        Common.Print("Invalid VariableTags usage; only supports integers and booleans at the moment");
                //        return;
                //    }
                //}

                _VariableTags = value;
            }
        }
        
        private string[] _VariableTags;
    }
    #endregion [Class Extensions]
}
