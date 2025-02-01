using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace Dobby {

    public class Common : Main {
        //#error version

        // Spacing:
        // Info & Back Btn; Info: Form.Size.Y - Info.Size.Y | BackBtn Pos: (Info Vertical Pos - BackBtn.Size.Y - 3)

        /*
        ////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///                 Design Bullshit                  \\\
        ///__________________________________________________\\\
        /// * FONT USAGE: (Use Bold For Both)                \\\
        /// - Use Franklin Gothic 10pt For Basic Controls    \\\
        /// - Use Cambria 9.75pt For Information Pages       \\\
        ///                                                  \\\
        /// * Borders And Seperator Lines                    \\\
        /// - Keep Controls At Least 1 Pixel From Form Edge  \\\
        /// - Lines Should Be 2 Pixels From Either Form Edge \\\
        ////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        */


        // TODO:
        // * MAJOR
        //  - Create Remaining Two Help Pages
        //  - Refactor EbootPatchPage Code. Check The Others, Too
        //  - Gp4CreationPage Unfinished, Only Base Functionality Added
        // * MINOR 
        //  - Label Flash Stays On White If Inturrupted at the right time
        //  - Update PKG Creation Page To Be More Like GP4 Creation Page
        //  - Standardize Help Page Styles
        //  - Standardize Info Label And Back Button Positioning, As Well As Space Between Controls
        //  - PS4DebugPage Consistency Fix (Can't Seem To Reproduce? [The Bug, I Mean. Not That I Don't Want The Other Thing])


        /*
        //////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--  MAIN APPLICATION VARIABLES & Functions  --\\\
        //////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\
        */
        #region Main Application Functions & Variable Declarations

        #if DEBUG
        /// <summary> Debug class instance. </summary>
        public static Testing Dev;
        #endif

        /// <summary>
        /// ID's for the various pages (forms) in the application.
        /// </summary>
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


        public static string
            CurrentControl,
            TempStringStore,
            ActiveGameID = "UNK"
        ;

        /// <summary> ID for the active game. </summary>
        public static GameIDs Game;

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
            MainStreamIsOpen
        ;

        
        public static Point LastFormPosition, MousePos, MouseDif;
        public static Point[] OriginalControlPositions;

        public static Size OriginalFormScale = Size.Empty;
        public static Size OriginalBorderScale;

        public static Form MainForm, PopupBox;
        public static Control InfoLabel;
        public static GroupBox PopupGroupBox;

        public static TcpClient TcpClient;
        public static NetworkStream NetStream;
        public static FileStream MainStream;


        #region    Design-Related
        public static Font MainFont = new Font("Consolas", 9.75F, FontStyle.Bold);
        public static Color MainColour = Color.FromArgb(100, 100, 100);
        
        ///<summary> Form Border Pen </summary>
        public static Pen BorderPen = new Pen(Color.White);
        #endregion Design-Related

        
        public delegate void InfoLabelUpdateCallback(string InfoText);

        public delegate void LabelFlashDelegate();



        public static void Print(object message = null)
        {
            #if DEBUG
            Dev.Print(message);
            #endif
        }


        /// <summary> Write A Byte To The MainStream And Flush The Data </summary>
        public static void WriteByte(int offset, byte data) {
            if (MainStream == null) {
                MessageBox.Show($"!! ERROR: No Active Data Stream To Write To ({MainStreamIsOpen})", $"Addr: {offset:X} Byte: 0x{data:X}");
                return;
            }

            MainStream.Position = offset;
            MainStream.WriteByte(data);
            MainStream.Flush();
        }



        public static string GetCurrentGame(FileStream stream) {
            var LocalExecutableCheck = new byte[160];

            // 
            stream.Position = 0;
            stream.Read(LocalExecutableCheck, 0, 4);
            if (BitConverter.ToInt32(LocalExecutableCheck, 0) != 1179403647)
                MessageBox.Show($"Executable Still Encrypted (self) | Must Be Decrypted/Unsigned");


            stream.Position = 0x5100;
            stream.Read(LocalExecutableCheck, 0, 160);
            Game = (GameIDs)BitConverter.ToInt32(SHA256.Create().ComputeHash(LocalExecutableCheck), 0);

            switch (Game) {
                case GameIDs.UC1100: return "Uncharted 1 1.00";
                case GameIDs.UC1102: return "Uncharted 1 1.02";
                case GameIDs.UC2100: return "Uncharted 2 1.00";
                case GameIDs.UC2102: return "Uncharted 2 1.02";
                case GameIDs.UC3100: return "Uncharted 3 1.00";
                case GameIDs.UC3102: return "Uncharted 3 1.02";
                case GameIDs.UC4100: return "Uncharted 4 1.00";
                case GameIDs.UC4101: return "Uncharted 4 1.01";
                case GameIDs.UC4102: return "Uncharted 4 1.02";
                case GameIDs.UC4103: return "Uncharted 4 1.03";
                case GameIDs.UC4104: return "Uncharted 4 1.04";
                case GameIDs.UC4105: return "Uncharted 4 1.05";
                case GameIDs.UC4106: return "Uncharted 4 1.06";
                case GameIDs.UC4108: return "Uncharted 4 1.08";
                case GameIDs.UC4110: return "Uncharted 4 1.10";
                case GameIDs.UC4111: return "Uncharted 4 1.11";
                case GameIDs.UC4112: return "Uncharted 4 1.12";
                case GameIDs.UC4113: return "Uncharted 4 1.13";
                case GameIDs.UC4115: return "Uncharted 4 1.15";
                case GameIDs.UC4116: return "Uncharted 4 1.16";
                case GameIDs.UC4117: return "Uncharted 4 1.17";
                case GameIDs.UC4118: return "Uncharted 4 1.18 SP/MP";
                case GameIDs.UC4119: return "Uncharted 4 1.19 SP/MP";
                case GameIDs.UC4120MP: return "Uncharted 4 1.20 MP";
                case GameIDs.UC4120: return "Uncharted 4 1.20 SP";
                case GameIDs.UC4121MP: return "Uncharted 4 1.21 MP";
                case GameIDs.UC4121: return "Uncharted 4 1.21 SP";
                case GameIDs.UC4122MP: return "Uncharted 4 1.22 MP";
                case GameIDs.UC4122_23: return "Uncharted 4 1.22/23 SP";
                case GameIDs.UC4123MP: return "Uncharted 4 1.23 MP";
                case GameIDs.UC4124MP: return "Uncharted 4 1.24 MP";
                case GameIDs.UC4124_25: return "Uncharted 4 1.24/25 SP";
                case GameIDs.UC4125MP: return "Uncharted 4 1.25 MP";
                case GameIDs.UC4127_28MP: return "Uncharted 4 1.27/28 MP";
                case GameIDs.UC4127_133: return "Uncharted 4 1.27+ SP";
                case GameIDs.UC4129MP: return "Uncharted 4 1.29 MP";
                case GameIDs.UC4130MP: return "Uncharted 4 1.30 MP";
                case GameIDs.UC4131MP: return "Uncharted 4 1.31 MP";
                case GameIDs.UC4132MP: return "Uncharted 4 1.32/TLL 1.08 MP";
                case GameIDs.UC4133MP: return "Uncharted 4 1.33/TLL 1.09 MP";
                case GameIDs.UC4MPBETA100: return "Uncharted 4 MP Beta 1.00";
                case GameIDs.UC4MPBETA109: return "Uncharted 4 MP Beta 1.09";
                case GameIDs.TLL100MP: return "Uncharted Lost Legacy 1.00 MP";
                case GameIDs.TLL100: return "Uncharted Lost Legacy 1.00 SP";
                case GameIDs.TLL10X: return "Uncharted Lost Legacy 1.08/9 SP";
                case GameIDs.T1R100: return "The Last Of Us 1.00";
                case GameIDs.T1R109: return "The Last Of Us 1.09";
                case GameIDs.T1R110: return "The Last Of Us 1.10";
                case GameIDs.T1R111: return "The Last Of Us 1.11";
                case GameIDs.T2100: return "The Last Of Us 2 1.00";
                case GameIDs.T2101: return "The Last Of Us 2 1.01";
                case GameIDs.T2102: return "The Last Of Us 2 1.02";
                case GameIDs.T2105: return "The Last Of Us 2 1.05";
                case GameIDs.T2107: return "The Last Of Us 2 1.07";
                case GameIDs.T2108: return "The Last Of Us 2 1.08";
                case GameIDs.T2109: return "The Last Of Us 2 1.09";

                default:
                    return $"Unknown Game (Game ID: {Game})";
            }
        }



        /// <summary> [deprecated] Sets The Info Label String Based On The Currently Hovered Control </summary>
        /// <param name="Sender">The Hovered Control</param>
        public static void SetInfoLabelStringOnControlHover(Control Sender, float FontAdjustment = 10f) {
            // SetInfo
            // TODO: this is fucking stupid, change or delete it.

            string InfoLabelString = "";

            switch (Sender.Name) {
                default:
                    return;

                //
                // Const
                //
                case "CreditsBtn":
                    InfoLabelString = "View Credits For The Tool And Included Patches";
                    break;
                case "InfoHelpBtn":
                    InfoLabel.Font = new Font(InfoLabel.Font.FontFamily, 9.5F);
                    InfoLabelString = "View Help For Each Page As Well As The App Itself";
                    break;
                case "BackBtn":
                    InfoLabelString = "Return To The Previous Page";
                    break;
                // _______________
                //
                // Main Page
                //
                case "PS4DebugPageBtn":
                    InfoLabel.Font = new Font(InfoLabel.Font.FontFamily, 9F);
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
                // _______________
                //
                // PS4DebugPage
                //
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
                    InfoLabel.Font = new Font(InfoLabel.Font.FontFamily, 9F);
                    InfoLabelString = "Tool Also Auto-Connects When An Option's Selected";
                    break;
                case "IgnoreTitleIDBtn":
                    InfoLabelString = "Enable This If You've Changed The Title ID";
                    break;
                // _______________
                //
                // EbootPatchPage
                //
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
                // _______________
                //
                // PkgCreationPage
                //
                // _______________
                //
                // PkgCreationHelpPage
                //
                // _______________
                //
                // Gp4CreationPage
                //
                case "Gp4CreationPageBtn":
                    InfoLabelString = "A .gp4 Is Required For .pkg Creation";
                    break;
                    //
                    // Gp4CreationHelpPage
                    //
                    // _______________
                    //
                    // PS4MiscPatchesPage
                    //
                    // _______________
                    //
                    // PCExePatchPage
                    //
                    // _______________
                    //
                    // PCQOLPatchPage
                    //
                    // _______________
                    //
                    // InfoHelpPage
                    //
                    // _______________
                    //
                    // CreditsPage
                    //
                    // _______________
                    //
                    // PCQOLPatchPage
                    //
                    // _______________

            }
            SetInfoLabelText(InfoLabelString);
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


        ///////////////////\\\\\\\\\\\\\\\\\\
        ///--   Form Drawing Functions  --\\\
        ///////////////////\\\\\\\\\\\\\\\\\\
        #region Form Drawing Functions
        /// <summary> Highlights A Control In Yellow With A > Preceeding It When Hovered Over </summary>
        /// <param name="PassedControl">The Control To Highlight</param>
        /// <param name="EventIsMouseEnter">Highlight If True</param>
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

            if (MouseScrolled = EventIsMouseEnter) {
#if DEBUG
                Testing.HoveredControl = PassedControl;
#endif
                CurrentControl = PassedControl.Name;
                PassedControl.MouseDown += HighlightItemOnMouseDown;
                PassedControl.MouseUp += ResetItemHighlight;
            }
            else {
                PassedControl.MouseDown -= HighlightItemOnMouseDown;
                PassedControl.MouseUp -= ResetItemHighlight;
            }

            PassedControl.Text = EventIsMouseEnter ? ($">{PassedControl.Text}") : PassedControl.Text.Substring(1);

            if (PassedControl.Size.Width + PassedControl.Location.X != PassedControl.Parent.Size.Width - 1)
                PassedControl.Size = new Size(EventIsMouseEnter ? PassedControl.Width + ArrowWidth : PassedControl.Width - ArrowWidth, PassedControl.Height);
        }



        /// <summary>
        /// Draw the string representation of the Dobby.Button's Variable property to the right of the control text.
        ///</summary>
        public static void DrawButtonVariable(object item, PaintEventArgs args)
        {
            // Convert control to avoid constant casting
            var control = item as Dobby.Button;

            // Load the string representation of the Variable property
            var Variable = control.Variable?.ToString();

            // Check for stupidity.
            if (Variable == null) {
                Print($"!! ERROR: Variable property for control \"{control.Name}\" was null");
                return;
            }


            // Format boolean values
            if (control.Variable.GetType() == typeof(bool))
                Variable = (bool) control.Variable ? "Yes" : "No";

            // Draw the Variable's string representation appended to the rightmost side of the control's bounds
            args.Graphics.DrawString(Variable, MainFont, Brushes.LightGreen, new Point((int) (control.Width - args.Graphics.MeasureString(Variable, control.Font).Width - 5), 5));
        }



        ///<summary> Create And Apply A Thin Border To The Form </summary>
        public static void DrawBorder(object sender, PaintEventArgs e)
        {
            var ItemPtr = (Form)sender;

            Point[] Border = new Point[] {
                Point.Empty,
                new Point(ItemPtr.Width-1, 0),
                new Point(ItemPtr.Width-1, ItemPtr.Height-1),
                new Point(0, ItemPtr.Height-1),
                Point.Empty
            };

            e.Graphics.Clear(Color.FromArgb(100, 100, 100));
            e.Graphics.DrawLines(BorderPen, Border);
        }

        /// <summary> Create and draw a thin white line from one end of the form to the other. (placeholder code atm)
        ///</summary>
        public static void DrawSeperatorLine(object sender, PaintEventArgs e)
        {
            var item = sender as Label;

            if (item == null) {
                Print("!! ERROR: Invalid control passed as Seperator line.");
                Print($"  - Control \"{(((Control)sender).Name)}\" location: {((Control)sender).Location}.");
            }
            if (item.Size.Height != 15) {
                Print($"# WARNING: A label on page \"{item.Parent.Name}\" has an invalid height!!! (Label at {item.Location} is {item.Size.Height} pixels in height)");
                //item.Size = new Size(item.Size.Width, 15);
            }


            e.Graphics.Clear(Color.FromArgb(100, 100, 100));
            e.Graphics.DrawLines(BorderPen, new Point[] {
                new Point(1, 9),
                new Point(item.Parent.Size.Width - 1, 9)
            });
        }


        public static void WriteLabel(Form form, string message) => form.Invoke(SetInfoText, message);


        
        public static InfoLabelUpdateCallback SetInfoText = value =>
        {
            if(ActiveForm != null)
                InfoLabel.Text = value;

            Print($"[info]: {value}");
        };



        // TODO: rework this crap
        public static readonly LabelFlashDelegate White = () => {
            ActiveForm.Controls.Find("GameInfoLabel", true)[0].ForeColor = Color.White;
            ActiveForm?.Update();
        };
        public static readonly LabelFlashDelegate Yellow = () => {
            ActiveForm.Controls.Find("GameInfoLabel", true)[0].ForeColor = Color.FromArgb(255, 227, 0);
            ActiveForm?.Update();
        };

        public static Thread FlashThread = new Thread(() => {
            while (true)
            {
                while (!LabelShouldFlash)
                    Thread.Sleep(1);
                
                try {
                    for (int Flashes = 0; Flashes < 8; Flashes++)
                    {
                        ActiveForm?.Invoke(White);
                        Thread.Sleep(135);
                        ActiveForm?.Invoke(Yellow);
                        Thread.Sleep(135);
                    }
                }
                catch (Exception) {
                    Print("Form Changed or Lost Focus, Killing Label Flash");
                    while (ActiveForm == null);
                }
                finally {
                    LabelShouldFlash = false;
                    ActiveForm?.Invoke(Yellow);
                }

            }
        });
        #endregion


        //================================\\
        //--|   Basic Form Functions   |--\\
        //================================\\
        #region [Basic Form Functions]

        /// <summary>
        /// Loads The Specified Page From The PageId Group (E.g. ChangeForm(PageID.PS4MiscPageId))
        /// </summary>
        /// <param name="Page"> The Page To Change To. </param>
        public static void ChangeForm(PageID? Page, bool ReturningToPreviousPage = false)
        {
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
                    NewPage = new Gp4CreationPage();
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
            InfoLabel = ActiveForm.Controls.Find("Info", true)[0];
            ActiveForm.Location = LastFormPosition;


            if (PageToClose.Name == "Main")
                PageToClose.Hide();
            else
                PageToClose.Close();
        }




        /// <summary>
        /// Apply Basic Event Handlers To Form And It's Items
        /// </summary>


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


            Controls.Owner.Paint += DrawBorder;
            foreach (Control Item in Controls) {
                ApplyEventHandlersToControl(Item);

                if (Item.HasChildren) // Designer Adds Some Things To Other Controls Sometimes. This should fix those controls until I notice it. (I Am Lazy.)
                    foreach (Control Child in Item.Controls)
                        ApplyEventHandlersToControl(Child);
            }
            InfoLabel = Controls.Find("Info", true)[0] ?? null;


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


            // Clear Info Label Text
            var ConstantControls = new string[] { "Info", "InfoHelpBtn", "CreditsBtn", "BackBtn" };
            var Parent = Controls.Owner.Name;

            // Avoid searching for back button on Main page
            if (Parent != "Main")
                Controls.Owner.Controls.Find(ConstantControls[3], true)[0].Click += (_, __) => ChangeForm(null);

            try {
                if (Parent != "InfoHelpPage" && Parent != "CreditsPage")
                {
                    Controls.Owner.Controls.Find(ConstantControls[1], true)[0].Click += (_, __) => ChangeForm(PageID.InfoHelpPage);
                    Controls.Owner.Controls.Find(ConstantControls[2], true)[0].Click += (_, __) => ChangeForm(PageID.CreditsPage);
                }

                Controls.Owner.Controls.Find(ConstantControls[0], true)[0].Text = string.Empty;
            }
            catch (Exception) {}
        }

        /// <summary>
        /// Set The Text of The Yellow Label At The Bottom Of The Form
        /// </summary>
        public static void SetInfoLabelText(string s)
        {
            if (ActiveForm != null)
                InfoLabel.Text = s;
        }
        #endregion


        //=============================\\
        //|    Form Event Handlers    |\\
        //=============================\\
        #region [Form Event Handlers]
        private static void ExitBtn_Click(object sender, EventArgs e)
        {
            MainStream?.Dispose();
            Environment.Exit(0);
        }
        private static void ExitBtnMH(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 227, 0);
        private static void ExitBtnML(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);
        private static void MinimizeBtn_Click(object sender, EventArgs e) => ((Control)sender).FindForm().WindowState = FormWindowState.Minimized;
        private static void MinimizeBtnMH(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 227, 0);
        private static void MinimizeBtnML(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);

        public static void MouseDownFunc(object sender, MouseEventArgs e)
        {
            MouseIsDown = true;
            LastFormPosition = ActiveForm.Location;
            MouseDif = new Point(MousePosition.X - LastFormPosition.X, MousePosition.Y - LastFormPosition.Y);
        }

        public static void MouseUpFunc(object sender, MouseEventArgs e) =>
            MouseScrolled = MouseIsDown = false;


        public static void MoveForm(object sender, MouseEventArgs e)
        {
            if (!MouseIsDown)
                return;

            ActiveForm.Location = new Point(MousePosition.X - MouseDif.X, MousePosition.Y - MouseDif.Y);
            ActiveForm.Update();

#if DEBUG
            //Dev.MoveLogToAppEdge(ActiveForm.Location);
#endif
        }
        public static void ControlHover(object sender, EventArgs _ = null) => HoverLeave((Control)sender, true);
        public static void ControlLeave(object sender, EventArgs _ = null) => HoverLeave((Control)sender, false);
        #endregion
        #endregion



        //================================================\\
        ///-- DEBUG MODE OFFSETS AND GAME INDENTIFIERS --\\\
        //================================================\\
        #region Debug Offsets & Game Identifiers
        public enum GameIDs : long {
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

            Empty = 0xDEADBEEF
            }
        ;



        /// <summary> .elf Addresses For Enabling The Debug Mode In Various PS4 Naughty Dog Games<br/>[On: 0xEB]<br/>[Off: 0x74]</summary>
        public const int
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
            TLL10XDebug = 0x1CD01A
        ;

        /// <summary> Int Value Used To Identify The Specific Executable Selected By The User.<br/>(0x1EC + 0x1F8) <br/>VERY LIMITED </summary>
        public const int
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
            T1XL102 = 2228464 + 95634432
        ;

        /// <summary> Offsets To Enable The Debug Mode in the pc version of the game<br/>(0x97 -> 0x8F) </summary>
        public const int
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
            T1XL102Debug = 0x3B6885
        ;
        #endregion
    }




    //=================================\\
    //-|   Custom Class Extensions   |-\\
    //=================================\\
    #region [Class Extensions]


    
    public class TextBox : System.Windows.Forms.TextBox {
        public TextBox() {

            Info         = ((string)Tag) ?? string.Empty;
            TextChanged += Set;
            IsDefault    = true;

            GotFocus += (object _, EventArgs __) => {
                if(IsDefault) {
                    Font = new Font("Microsoft YaHei UI", 8.25F);
                    Clear();
                    IsDefault = false;
                }
            };

            Click += (object _, EventArgs __) => { // Just In Case, I Suppose.
                if(IsDefault) {
                    Font = new Font("Microsoft YaHei UI", 8.25F);
                    Clear();
                    IsDefault = false;
                }
            };

            LostFocus += (object _, EventArgs __) => {
                if(Text.Length <= 0 || Text.Trim().Length <= 0) {
                    Font = new Font("Microsoft YaHei UI", 8.25F, FontStyle.Italic);
                    Text = DefaultText;
                    IsDefault = true;
                }
            };
        }


        public bool IsDefault { get; private set; }
        public string Info    { get; private set; }
        
        private string DefaultText;

        /// <summary> Yoink Default Text From First Text Assignment.
        ///</summary>
        void Set(object s, EventArgs e) {
            DefaultText = Text;

            TextChanged -= Set;
            TextChanged += (object control, EventArgs _) => {
                if(IsDefault && Text.Length > 0) {
                    Font = new Font("Microsoft YaHei UI", 8.25F);
                    IsDefault = false;
                }
            };
        }
    }


    /// <summary>
    /// Custom Button Class extention so I can attach a value to them. 
    /// </summary>
    public class Button : System.Windows.Forms.Button {


        /// <summary>
        /// Custom value associated with the control to be rendered alongside it, and edited via manually assigned per-control events.
        /// </summary>
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
    }
    #endregion [Class Extensions]
}
