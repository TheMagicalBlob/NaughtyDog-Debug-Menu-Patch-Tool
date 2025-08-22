using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
#if DEBUG
#endif


namespace Dobby {
    
    internal partial class Common : MainPage, IDisposable
    {
        //#error version

        // Spacing:
        // Info & Back Btn; Info: Form.Size.Y - Info.Size.Y | BackBtn Pos: (Info Vertical Pos - BackBtn.Size.Y - 3)

        //! \/ Pretty sure this shit is outdated now lol, check it 
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
        //  - Standardize Help Page Styles
        // * MINOR 
        //  - Standardize Info Label And Back Button Positioning / Spacing
        //  - Standardize Spacing Between Controls
        //  - PS4DebugPage Consistency Fix (Can't Seem To Reproduce? [The Bug, I Mean. Not That I Don't Want The Other Thing])


        //========================================\\
        //--|   Global Variable Declarations   |--\\
        //========================================\\
        #region [Global Variable Declarations]

        //#
        //## Basic Form Functionality
        //#
        #region (Basic Form Functionality)
        
        /// <summary>
        /// GameID for the active executable.
        /// </summary>
        public static GameID Game = GameID.Empty;

        /// <summary> ID for the currently loaded form. </summary>
        public static PageID? ActivePage;
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


        /// <summary>
        /// A string used as a frontend label for the active game (patch version for PS4 games, build number for PC)
        /// </summary>
        public static string ActiveGameID = string.Empty;

        public static string ActiveFilePath = string.Empty;


        
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
        public static Form Venat
        {
            get {
                if (_venat == null)
                {
                    // bitch and mosn
                    return ActiveForm ?? null;
                }

                return _venat;
            }
            set {
                _venat = value;
            }
        }
        private static Form _venat;

        
        /// <summary> Refference to the originally launched form. </summary>
        public static MainPageDummy YoshiP
        {
            get {
                if (_yoshiP == null)
                {
                    // bitch and mosn
                    return null;
                }

                return _yoshiP;
            }
            set {
                _yoshiP = value;
            }
        }
        private static MainPageDummy _yoshiP;

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
            get => FormDecorationPen.Color;

            set {
                FormDecorationPen.Color = value;

                Venat?.PerformLayout();
                Venat?.Update();
            }
        }

        ///<summary> Form Border Pen </summary>
        private static Pen FormDecorationPen = new Pen(Color.White);
        

        /// <summary> An array of Point() arrays with the start and end points of a line to draw. </summary>
        private static Point[][] HSeparatorLines;
        
        /// <summary> An array of Point() arrays with the start and end points of a line to draw. </summary>
        private static Point[][] VSeparatorLines;


#if DEBUG
        /// <summary> Disable drawing of form border/separator lines </summary>
        public static bool NoDraw
        {
            get => _noDraw;
            
            set {
                _noDraw = value;

                Venat?.Update();
                Venat?.Refresh();
            }
        }
        private static bool _noDraw;
#endif
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

        // None

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
        public static void WriteVar(FileStream fileStream, int address, byte[] data)
        {
            #if DEBUG
            var msg = $"] Written To 0x{fileStream?.Position:X} ({data?.Length ?? 0xDEADDAD})\n";
            #endif

            if (fileStream == null)
            {
                Dev.Print("ERROR: Filestream was disposed before the patch application process was finished.");
                UpdateLabel("Internal patch-application error. My apologies.");
                return;
            }



            fileStream.Position = address;

            // Write provided data
            if (data.Length == 1)
            {
                fileStream?.WriteByte(data[0]);

                #if DEBUG
                msg = $"[{$"{data[0]:X}".PadLeft(2, '0')}" + msg;
                #endif
            }
            else if (data.Length > 1)
            {
                fileStream?.Write(data, 0, data.Length);

                #if DEBUG
                msg = $"[0x{BitConverter.ToString(data).Replace("-", ", 0x")}" + msg;
                #endif
            }
            else {
                Dev?.Print($"ERROR: Zero-length array provided.");
            }


            // Manually flush the stream just in case
            fileStream?.Flush(true);
                
            #if DEBUG
            Dev?.Print(msg);
            #endif
        }
        
        
        /// <summary>
        /// WriteVar() shorthand for writing the same data to multiple addresses.
        /// </summary>
        /// <param name="data"> The data to write to the provided addresses. </param>
        /// <param name="addresses"> The addresses to write the data to each of. </param>
        public static void WriteVar(FileStream fileStream, object addresses, byte data)
        {
            if (addresses.GetType() == typeof(int[]))
            {
                foreach (var address in (int[])addresses)
                {
                    WriteVar(fileStream, address, new [] { data });
                }
            }
            else {
                WriteVar(fileStream, (int)addresses, new [] { data });
            }
        }
        
        
        /// <summary>
        /// WriteVar() shorthand for writing the same data to multiple addresses.
        /// </summary>
        /// <param name="data"> The data to write to the provided addresses. </param>
        /// <param name="addresses"> The addresses to write the data to each of. </param>
        public static void WriteVar(FileStream fileStream, object addresses, byte[] data)
        {
            if (addresses.GetType() == typeof(int[]))
            {
                foreach (var address in (int[])addresses)
                {
                    WriteVar(fileStream, address, data);
                }
            }
            else {
                WriteVar(fileStream, (int)addresses, data);
            }
        }
        


        /// <summary>
        /// Iterate through <paramref name="array"/>, searching for a provided pattern.<br/>
        /// Searches backwards since that init function seems to be fairly low in the exe.<br/><br/>
        /// 
        /// Note: Does not check for duplicates, simply returns the first instance found.
        /// </summary>
        /// <param name="array"> The array in which to scan for a sub-array </param>
        /// <param name="subarray"> The sub-array to scan for. </param>
        /// <returns>
        /// If <paramref name="subarray"/> is found, the address of the first byte of <paramref name="subarray"/>; otherwise, -1.
        /// </returns>
        public static int FindSubArray(byte[] array, byte[] subarray)
        {
            for (var i = array.Length - 1; i >= subarray.Length; --i)
            {
                if (array[i] == subarray.Last())
                {
                    var j = subarray.Length;

                    for (; j > 0; --j)
                    {
                        if (array[i - (j - 1)] != subarray[subarray.Length - j])
                            break;

                    }
                    if (j == 0)
                        return i;
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

        #endregion





        //#
        //## Form Functionality
        //#
        #region (form functionality)


        /// <summary>
        /// Update the current label text and/or apply a flashing effect to the label to signify an error.
        /// </summary>
        /// <param name="newText"> The string to apply to the label's Text property. </param>
        /// <param name="flashLabel"> If true, flash the label to indicate an error or otherwise get the user's attention. (switches between white/yellow) </param>
        public static void UpdateLabel(string newText, bool flashLabel = false)
        {
            if ((InfoText == " " || InfoText == null) && newText != null)
            {
                InfoText = newText;
            }

            if (flashLabel)
            {
                InfoFlashes = 15;
            }
        }


        /// <summary>
        /// Initialize the thread responsible for setting the status of the Info label at the bottom of each form.
        /// </summary>
        public static void CreateInfoLabelUpdater()
        {
            LabelUpdateThread = new Thread(LabelUpdateMethod)
            {
                Name = "MainPage Label Update Worker"
            };

            LabelUpdateThread.Start();
        }

        

        public static void OpenNewPage(PageID NewPage)
        {
            Pages.Add(NewPage);
            ChangePage(Pages.Last());
        }

        public static void ReturnToPreviousPage()
        {
            var prevPage = Pages.Last();
            Pages.RemoveAt(Pages.Count - 1);
            
            ChangePage(prevPage);
        }


        /// <summary>
        /// Loads The Specified Page From The PageId Group (E.g. ChangeForm(PageID.PS4MiscPageId))
        /// </summary>
        /// <param name="Page"> The Page To Change To. </param>
        private static void ChangePage(PageID? Page = null)
        {
            if (DisableFormChange)
            {
                UpdateLabel("Disabled during .gp4 / .pkg Creation Process.");
                Dev?.Print($"Ignoring request to change form to \"{Page}\".");
                return;
            }
            else {
                InfoFlashes = -1;

                InfoText = null;
                InfoLabel = null;
            }



            Form NewPage;
            switch (Page)
            {
                case PageID.MainPage:
                    NewPage = new MainPage();
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
                    NewPage = new PS4MenuSettingsHelpPage();
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
                    NewPage = null;
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


                default:
                    Dev?.Print($"{Page} Is Not A Page!");
                    return;
            }


            
            LastFormPosition = Venat.Location;

            Common.ActivePage = Page;
            

#if DEBUG
            DebugWindow?.SetDebugWindowParent(NewPage);
#endif
            

            // Show the new form, then hide or dispose of the previous page
            var PageToClose = Venat;

            Venat = NewPage;
            Venat.Show();
            Venat.Location = LastFormPosition;
            
            PageToClose.Close();
        }


        
        /// <summary>
        /// Post-InitializeComponent Configuration. <br/><br/>
        /// Create Assign Anonomous Event Handlers to Parent and Children.
        /// </summary>
        public static void InitializeAdditionalEventHandlers(Form Venat)
        {
            var controls = Venat.Controls.Cast<Control>().ToArray();

            var hSeparatorLineScanner = new List<Point[]>();
            var vSeparatorLineScanner = new List<Point[]>();



            // Apply the seperator drawing function to any seperator lines
            foreach (var line in controls.OfType<Dobby.Label>())
            {
                if (line.IsSeparatorLine)
                {
                    if (line.Size.Width > line.Size.Height)
                    {
                        // Horizontal Lines
                        hSeparatorLineScanner.Add(new []
                        { 
                            new Point(line.StretchToFitForm ? 1 : line.Location.X, line.Location.Y + 9),
                            new Point(line.StretchToFitForm ? line.Parent.Width - 2 : line.Location.X + line.Width, line.Location.Y + 9)
                        });

                        line.Height = 2;
                    }
                    else {
                        // Vertical Lines (the + 3 is to center the line with the displayed lines in the editor)
                        vSeparatorLineScanner.Add(new []
                        {
                            new Point(line.Location.X + 3, line.StretchToFitForm ? 1 : line.Location.Y),
                            new Point(line.Location.X + 3, line.StretchToFitForm ? line.Parent.Height - 2 : line.Location.Y + line.Height)
                        });

                        line.Height = 2;
                    }
                }
            }

            if (hSeparatorLineScanner.Count > 0) {
                HSeparatorLines = hSeparatorLineScanner.ToArray();
            }
            if (vSeparatorLineScanner.Count > 0) {
                VSeparatorLines = vSeparatorLineScanner.ToArray();
            }


            

            // Buttons to avoid assigning a hover arrow to
            var blacklistedItems = new[]
            {
                "DebugControl",
                "ExitBtn",
                "MinimizeBtn",
                "LabelBtn",
                "PathBox"
            };
            foreach (var button in controls.OfType<Dobby.Button>().Where(item => blacklistedItems.Contains(item.Name)))
            {
                button.MouseEnter += (sender, e) => HoverLeave((Control)sender, true);
                button.MouseLeave += (sender, e) => HoverLeave((Control)sender, false);
            }



            
            // Set appropriate event handlers for the controls on the form as well, as well as other miscellaneous shit
            foreach (var item in controls.Where(item => !item.Name.Contains("TextBox")))
            {
                if (item.Name == "SwapBrowseModeBtn") // lazy fix to avoid the mouse down event confliciting with the button
                    continue;

                item.TabStop = false;
     
                item.MouseDown += (sender, args) => MouseDownFunc(args);
                item.MouseUp   += (sender, _) => MouseUpFunc();
                
                
                // Apply the Hint function to the mouse enter event, applying the resetter tag to any controls sans Tags.
                if (item.Tag == null)
                {
                    item.Tag = " ";
                }

                // Add the event handler to everything that's not a text container
                item.MouseMove += new MouseEventHandler((sender, e) => MoveForm());


                // Avoid applying MouseMove and KeyDown event handlers to text containters (to retain the ability to drag-select text)
                item.KeyDown += (sender, arg) =>
                {
                    if (arg.KeyData == Keys.Escape)
                    {
                        Venat.Focus();
                    }
                };
            }




            // Set Event Handlers for Form Dragging
            Venat.MouseDown += (sender, args) => MouseDownFunc(args);
            Venat.MouseUp   += (sender, _) => MouseUpFunc();
            
            Venat.MouseEnter += (sender, _) => HoverString(sender);
            Venat.MouseMove += (sender, _) => MoveForm();
            
            Venat.Paint += (venat, yoshiP) => DrawFormDecorations((Form)venat, yoshiP);
            

            // Apply Info label reset string to form
            Venat.Tag = " ";





            
            //#
            //## Create Exit And Minimize Buttons, And Add Them To The Top Right Of The Form
            //#
            var Gray = Color.FromArgb(100, 100, 100);

            Button ExitBtn = new Button() {
                Location = new Point(Venat.Size.Width - 24, 1),
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
                Location = new Point(Venat.Size.Width - 47, 1),
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
                Location = new Point(Venat.Size.Width - 70, 1),
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
            Venat.Controls.Add(MinimizeBtn);
            MinimizeBtn.BringToFront();

            MinimizeBtn.Click += new EventHandler(MinimizeBtn_Click);
            MinimizeBtn.MouseEnter += new EventHandler(WindowBtnMH);
            MinimizeBtn.MouseLeave += new EventHandler(WindowBtnML);

            // Exit Button Properties
            ExitBtn.FlatAppearance.BorderSize = 0;
            Venat.Controls.Add(ExitBtn);
            ExitBtn.BringToFront();
            
            ExitBtn.Click += new EventHandler(ExitBtn_Click);
            ExitBtn.MouseEnter += new EventHandler(WindowBtnMH);
            ExitBtn.MouseLeave += new EventHandler(WindowBtnML);

            #if DEBUG
            // Log Window Button Properties
            LogBtn.FlatAppearance.BorderSize = 0;
            Venat.Controls.Add(LogBtn);
            LogBtn.BringToFront();
            
            LogBtn.Click += LogBtn_Click;
            LogBtn.MouseEnter += new EventHandler(WindowBtnMH);
            LogBtn.MouseLeave += new EventHandler(WindowBtnML);
            #endif



            //#
            //## Apply event handlers and tags to the common buttons at the bottom of each page
            //#

            // Apply Info & Credits page crap, unless we're on one of those pages already
            if (!new [] { "InfoHelpPage", "CreditsPage" }.Contains(Venat.Name))
            {
                var helpPageButton = Venat.Controls.Find("InfoHelpBtn", true)?.FirstOrDefault();

                if (helpPageButton != null) {
                    helpPageButton.Click += (_, __) => OpenNewPage(PageID.InfoHelpPage);
                    helpPageButton.Tag = "View explanations for each page/other info";
                }
                

                var creditsPageButton = Venat.Controls.Find("CreditsBtn", true)?.FirstOrDefault();

                if (creditsPageButton != null) {
                    creditsPageButton.Click += (_, __) => OpenNewPage(PageID.CreditsPage);
                    creditsPageButton.Tag = "View various credits for the application.";
                }
            }


            // Avoid searching for a back button on Main page
            if (Venat.Name != "MainPage")
            {
                var backButton = Venat.Controls.Find("BackBtn", true)?[0];

                backButton.Click += (_, __) => ReturnToPreviousPage();
                backButton.Tag = "Return to the previous page";
            }


            // Attempt to assign static Info label refference for bs globals
            try {
                int num;
                InfoLabel = (Label)Venat.Controls.Find("Info", true)?.Last();

                InfoLabel.Text = string.Empty;
                InfoLabel.Tag = ((num = new Random().Next() & 1) + (num >> num & 1)) == 0 ? "hey get that mouse off my face >:(" : " "; // apply a joke tag if a two random numbers are both even (for shits and giggles)
            }
            catch (InvalidOperationException) {
                Dev?.Print("ERROR: Form does not contain an info label (or it has not been named \"Info\").");
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
                Dev?.Print($"Error Getting Width Of Hover Arror From Control ({PassedControl.Name}: {(EventIsMouseEnter ? "Hover" : "Leave")})");
                Dev?.PrintError(ex);
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



        
        
        /// <summary>
        /// Draw a thin border over the for edges on repaint.
        /// <br/>Draw a thin line from one end of the painted control to the other.
        ///</summary>
        public static void DrawFormDecorations(Form venat, PaintEventArgs yoshiP)
        {
            yoshiP.Graphics.Clear(venat.BackColor); // Clear line bounds with the current form's background colour

            # if DEBUG
            if (NoDraw)
            {
                return;
            }
            #endif
            
            //## Draw Vertical Lines
            foreach (var line in VSeparatorLines ?? Array.Empty<Point[]>())
            {
                yoshiP?.Graphics.DrawLine(FormDecorationPen, line[0], line[1]);
            }

            //## Draw Horizontal Lines
            foreach (var line in HSeparatorLines ?? Array.Empty<Point[]>())
            {
                yoshiP?.Graphics.DrawLine(FormDecorationPen, line[0], line[1]);
            }

            // Draw a thin (1 pixel) border around the form with the current Pen
            yoshiP?.Graphics.DrawLines(FormDecorationPen, new [] {
                Point.Empty,
                new Point(venat.Width-1, 0),
                new Point(venat.Width-1, venat.Height-1),
                new Point(0, venat.Height-1),
                Point.Empty
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

                        Venat?.Update();
                    }

                    Venat?.Update();
                }
                catch (Exception) {
                    Dev?.Print("Error setting label text and / or colour.");
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

                        Venat?.Invoke(setLabelState, InfoLabel, (InfoFlashes-- & 1) == 0 ? Color.FromArgb(255, 227, 0) : Color.White, notifyMessage);
                        
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
                        Venat?.Invoke(setLabelState, InfoLabel, Color.FromArgb(255, 227, 0), InfoText);
                        InfoText = null;
                    }
                }
                catch (Exception) {
                    Dev?.Print("Form Changed or Lost Focus, Killing Label Flash");

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
            Venat.Dispose();  //! 90% sure this isn't implemented properly.
            Environment.Exit(0); // off we fuck
        }
        internal static void WindowBtnMH(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 227, 0);
        internal static void WindowBtnML(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);
        internal static void MinimizeBtn_Click(object sender, EventArgs e) => ((Control)sender).FindForm().WindowState = FormWindowState.Minimized;
        
        internal static void MouseDownFunc(MouseEventArgs e)
        {
            ActiveMouseButton = e.Button;
            MouseIsDown = true;
            
            LastFormPosition = Venat?.Location ?? LastFormPosition;
            MouseDif = new Point(MousePosition.X - LastFormPosition.X, MousePosition.Y - LastFormPosition.Y);

        }

        internal static void MouseUpFunc() {
            MouseScrolled = MouseIsDown = false;

            ActiveMouseButton = MouseButtons.None;
        }

        public static void MoveForm()
        {
            if (!MouseIsDown || ActiveForm == null)
                return;

            if (Venat != null)
            {
                Venat.Location = new Point(MousePosition.X - MouseDif.X, MousePosition.Y - MouseDif.Y);
                Venat.Update();
            }


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
        /// <param name="args"></param>
        public static void HoverString(object sender)
        {
            try {
                // Oh my god fuck it, lazy fix for winforms stupid fucking asynchronous contol initialization, god I fucking hate this stupid clunky bullshit sometimes, how the fuck is the control null after being created, initialzed, and added to the form??? I CAN LITERALLY SEE THE CONTROL, IT'S NOT FUCKING NULL
                if (InfoLabel == null && ((Control)sender).FindForm().Name == "MainPage")
                {
                    InfoLabel = (Label) Venat.Controls.Find("Info", true)?[0];
                }

                if (((string) ((Control)sender).Tag ?? string.Empty).Length > 0) //! test this
                {
                    UpdateLabel((string) ((Control)sender).Tag);
                }
                else
                    Dev?.Print($"Label not updated due to empty tag or active flash thread {InfoFlashes} {InfoText?.Length ?? 0xDEADDAD}");
            }
            catch (InvalidCastException)
            {
                Dev?.Print("ERROR: A Non-string value was assigned to a control tag");
            }
        }
        #endregion
    }
}
