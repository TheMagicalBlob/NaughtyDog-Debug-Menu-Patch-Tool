using System;
using System.Drawing;
using System.Windows.Forms;
#if DEBUG
using System.IO;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using static Dobby.Common;
#endif


namespace Dobby {

    /// <summary>
    /// Lazy/Messy class for general debugging/testing-related stuff.
    /// </summary>
    public class Testing {
        //=======================================\\
        //--  Debug/Testing Class Declaration  --\\
        //=======================================\\
        
#if DEBUG
        /// <summary>
        /// Create the Dobby.Dev instance which will be running for the Program's whole runtime.
        /// </summary>
        /// <param name="Gaia"> Main form refference to set initial ActivePage value. (otherwise set during page change) </param>
        public Testing(Form Gaia)
        {
            Dev = this;
            ActivePage = Gaia;

            TestGamedataFolder = @"C:\Users\msblob\Misc\gp4_tst\CUSA00009-app";
            TestPubToolPath = @"C:\Users\msblob\App\FPackageTools3.87\orbis-pub-cmd.exe";
            TestEbootPath = @"C:\Users\blob\Misc\dobby tst\CUSA07820-app\eboot.bin";
            TestGP4Path = @"C:\Users\msblob\Misc\gp4_tst\CUSA00009-app.gp4";
        }
#endif

        



        
        //=======================================\\
        //--|   Debug Variable Declarations   |--\\
        //=======================================\\
        #region [Debug Variable Declarations]

        public static bool ForceDebugInRelease = true;

#if DEBUG
        public static Control HoveredControl;
        private LogWindow Log;

        /// <summary> Active Page reference for debug output loop. </summary>
        private dynamic ActivePage {
            get => activePage;
            set {
                activePage = value;
                Log?.SetLogParent(ActivePage);
            }
        }
        private dynamic activePage;

        public static Form LogPtr, ParentPtr;

        public static string TestGamedataFolder;
        public static string TestPubToolPath;
        public static string TestEbootPath;
        public static string TestGP4Path;

        public bool OverrideMsgOut;


        internal int ClickErrors = 0;
        internal int ClickEventCheck = 0;
        
        public static Size FormScale;

        private static Graphics LogWindowRenderer;

        private static StreamWriter LogFile;
        public static string[] LogBuffer;

        public static bool LogShouldRefresh, LogShouldPause;

        private static int OutputStringIndex = 0, ShiftIndex = 0;

        public static string[] OutputStrings = new string[35];



        public delegate void Rendering(Control control);

        public static Rendering RenderPause = new Rendering(PauseRendering);
        public static Rendering RenderResume = new Rendering(ResumeRendering);
        #endif
        #endregion



        
        //========================================\\
        //--|   Debug Function Delcarations   |---\\
        //========================================\\
        #region [Debug Function Delcarations]

        /// <summary>
        /// Toggle a few different things to try and get a feel for which is prefferable
        /// </summary>
        public static void AddStyleTestButton(System.Windows.Forms.Form form)
        {
            // StyleTestBtn
            Button styleTestButton; 

            form.Controls.Add(styleTestButton = new Button()
            {
                Name = "StyleTestBtn",
                Size = new Size(120, 24),
                Location = new Point(272, 1),
                Text = "Toggle Style Test",
                Font = new Font("Verdana", 8F),
                BackColor = Color.FromArgb(100, 100, 100),
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                ForeColor = SystemColors.Control,
                Cursor = Cursors.Cross
            });
            styleTestButton.Click += (sender, args) => {
                foreach (var item in ((Control)sender).Parent.Controls)
                {
                    if (item.GetType() == typeof(TextBox) && !((TextBox)item).ReadOnly)
                    {
                        var control = (TextBox) item;
                        control.TextAlign ^= HorizontalAlignment.Center;
                    }
                }

                Common.StyleTest ^= true;
            };
            styleTestButton.FlatAppearance.BorderSize = 0;
            styleTestButton.BringToFront();
        }


        
        /// <summary>
        /// Default message output function. Prints to the debug window if present, as well as the standard output
        /// </summary>
        /// <param name="obj"> An object to print the string representation of. </param>
        public static void Print(object obj = null) {
            string str;

            // Some formatting stuff
            if(obj == null || obj.ToString().Length < 1)
                str = " ";
            else
                str = obj.ToString();

            if(str.Contains("\n"))
                str = str.Replace("\n", "\n "); // So It Still Has A Size (for log window scaling purposes)
            //^


            System.Diagnostics.Debug.WriteLine(str);
            if (!Console.IsInputRedirected)
                Console.WriteLine(str);
        }



        /* [unused & incomplete test function]
        public static RichTextBox CreateTextBox(Form ActiveForm, string Title) {
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
        private static void KillTextBox(object sender, MouseEventArgs e) => Common.PopupGroupBox?.Dispose();
        */



        #if DEBUG
        public void SetActivePage(Form form) => ActivePage = form;


        public void ToggleLogWindow() {
            if (Log != null) {
                Log.Dispose();
                Log = null;
            }
            else
                (Log = new LogWindow(ActivePage, this)).Show();
        }

        public void MoveLogWindow() => Log?.MoveLogToAppEdge(ParentPtr, null);

        private static void PauseRendering(Control control) => UpdateRendering((IntPtr)0, control);
        private static void ResumeRendering(Control control) => UpdateRendering((IntPtr)1, control);
        private static void UpdateRendering(IntPtr toggle, Control control) {
            var Window = NativeWindow.FromHandle(control.Handle);
            var Msg = Message.Create(control.Handle, 11, toggle, IntPtr.Zero);

            Window.DefWndProc(ref Msg);

            if(toggle != IntPtr.Zero)
                control.Update();
        }



        public Control[] GetControlsInOrder(Form Parent) {
            var Cunts = new List<Control>();
            
            int X, Y = 0;
            do {
                X = 0;
                do
                    foreach(Control Item in Parent.Controls)
                        if(Item.Location.Y == Y & Item.Location.X == X)
                            Cunts.Add(Item);

                while(X++ < Parent.Size.Width);
            }
            while(Y++ < Parent.Size.Height);
            return Cunts.ToArray();
        }


        public static void DebugControlHover(object sender, EventArgs e) => HoveredControl = (Control)sender;


        /// <summary>
        /// Calculates A Size Exactly Large Enough (Hopefully)
        /// To Fit The Item's Text Content
        /// </summary>
        /// <returns> A new size for the little cunt. </returns>
        private Size TryAutosize(Control cunt) {
            var size = cunt.CreateGraphics().MeasureString(cunt.Text, cunt.Font);
            return new Size((int)size.Width + 15, (int)size.Height + 10);
        }


        public void Dispose() => Log?.Dispose();

        #endif
        #endregion



        #if DEBUG
        //============================================\\
        //--|   Debug Log Window Initialization   |---\\
        //============================================\\
        #region [Debug Log Window Initialization]

        /// <summary>
        /// Class for standard debug display / logging;
        /// </summary>
        private partial class LogWindow : Form, IDisposable
        {
            public LogWindow(Form Gaia, Testing dev)
            {
                var DButtonFont = new Font("Cambria", 7F, FontStyle.Bold);

                var DButtons = new Button[] {
                    new Button {
                        ForeColor = SystemColors.Control,
                        Font = DButtonFont,
                        Text = "LogTxt",
                        Name = "DebugControl"
                    },
                    new Button {
                        ForeColor = SystemColors.Control,
                        Font = DButtonFont,
                        Text = "Boot Release",
                        Name = "DebugControl"
                    },
                    new Button {
                        ForeColor = SystemColors.Control,
                        Font = DButtonFont,
                        Text = "Clear Info Label",
                        Name = "DebugControl"
                    },
                    new Button {
                        ForeColor = SystemColors.Control,
                        Font = DButtonFont,
                        Text = "Theme tst",
                        Name = "DebugControl"
                    }
                };

                var Handlers = new EventHandler[] {
                    new EventHandler((_, __) => { 
                        if(MessageBox.Show("Open Log?", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                            return;

                        System.Diagnostics.Process.Start($"{Directory.GetCurrentDirectory()}\\out.txt");
                        Dispose();
                        Environment.Exit(0);
                    }),
                    new EventHandler((_, __) => {
                        Dispose();
                        System.Diagnostics.Process.Start($@"{Directory.GetParent(Directory.GetCurrentDirectory())}\Release\ND Debug Enabler.exe");
                        Environment.Exit(1);
                    }),
                    new EventHandler((control, args) => UpdateLabel(string.Empty)),
                    new EventHandler((control, args) => HighlightColour = Color.FromArgb(255, 0, 255))
                };




                // LogWindow Form And Control Initializations
                BackColor = Gaia.BackColor;
                FormBorderStyle = FormBorderStyle.None;
                Name = "LogWindow";
                for (int i = 0; i < DButtons.Length; i++)
                {
                    var debugControl = DButtons[i];
                    var debugMethod = Handlers[i];


                    Controls.Add(debugControl);
                    debugControl.FlatStyle = FlatStyle.Flat;
                    debugControl.FlatAppearance.BorderSize = 0;
                    debugControl.Click += debugMethod;
                    debugControl.Size = Dev.TryAutosize(debugControl);
                    debugControl.BringToFront();

                }


                // LogWindow Event Handlers
                MouseEnter += DebugControlHover;
                MouseDown  += MouseDownFunc;
                MouseUp    += MouseUpFunc;


                LogPtr = this;
                ParentPtr = Gaia;
                LogWindowRenderer = CreateGraphics();

                LogFile = File.CreateText($"{Directory.GetCurrentDirectory()}\\out.txt");
                (LogThread = new Thread(new ThreadStart(UpdateConsoleOutput))).Start();

                Dev = dev;

            }


            
            
            /// <summary>
            /// Sets the form to anchor the log window to.
            /// </summary>
            /// <param name="Gaia"> The anchor form. </param>
            public void SetLogParent(Form Gaia)
            {
                (ParentPtr = Gaia).LocationChanged += MoveLogToAppEdge;
            }

            public void MoveLogToAppEdge(object mommy, EventArgs e)
            {
                if (LogPtr == null) return;

                LogPtr.BringToFront();
                ((Form) mommy).BringToFront();
                LogPtr.Location = new Point(((Form)mommy).Location.X - LogPtr.Size.Width, ((Form)mommy).Location.Y);
                LogPtr.Update();
            }
            public static void MoveLogToAppEdge(Point Loc) => LogPtr.Location = new Point(Loc.X - LogPtr.Size.Width, Loc.Y);

            
            private void MouseDownFunc(object sender, MouseEventArgs e) => MouseIsDown = true;
            private void MouseUpFunc(object sender, MouseEventArgs e) => MouseScrolled = MouseIsDown = false;



            public delegate void Scaling();

            public static Scaling ResizeLog = new Scaling(() =>
            { 
                LogPtr.Size = FormScale;
                LogWindowRenderer = LogPtr.CreateGraphics();

            Reset:
                LogPtr.Location = new Point(ParentPtr.Location.X - LogPtr.Size.Width, ParentPtr.Location.Y);
                LogPtr.Update();
                //ParentPtr.BringToFront();

                var ControlOffset = 0;
                foreach(Control control in LogPtr.Controls)
                {
                    control.Location = new Point(LogPtr.Size.Width - control.Size.Width - ControlOffset - 1, 1);
                    if(control.Location.X < 0) {
                        LogPtr.Size = new Size(LogPtr.Size.Width + control.Size.Width + 1, LogPtr.Size.Height);
                        goto Reset;
                    }

                    ControlOffset += control.Size.Width;
                }
            });




            /// <summary> ugly, uuglyy, UGLY!!! </summary>
            public static void LogOut(string str) {
                while(LogFile == null);

                LogFile.WriteLine(str);
                LogFile.Flush();
                return;

                LogShouldRefresh = true;

                if(OutputStringIndex != OutputStrings.Length - 1) {
                    for(; OutputStringIndex < OutputStrings.Length - 1; OutputStringIndex++) {
                        if(OutputStrings[OutputStringIndex] == null) {
                            OutputStrings[OutputStringIndex] = str;
                            break;
                        }
                    }
                    return;
                }
                for(ShiftIndex = 0; ShiftIndex < OutputStrings.Length - 1; ShiftIndex++)
                    OutputStrings[ShiftIndex] = OutputStrings[ShiftIndex + 1];
                OutputStrings[ShiftIndex] = str;

                LogShouldRefresh = true;
            }


            private readonly Thread LogThread;


            /// <summary> Main LogWindow output loop. </summary>
            public void UpdateConsoleOutput()
            {
                string output;
                string[] rawOutput;
                string[]
                    chk1 = Array.Empty<string>(),
                    chk2 = Array.Empty<string>()
                ;

                var logPen   = new Pen(Common.HighlightColour);
                var logFont = new Font("Consolas", 8.5f, FontStyle.Bold);

                while(true) {
                    try {
                        // Lazy way to pause output.
                        while(LogShouldPause);

                        output = string.Empty;
                        var controlType = HoveredControl?.GetType().ToString();

                        var dynamicVars = PS4MenuSettingsPage.PeekGameSpecificPatchValues();

                        try {

                            // Switch between various formats of debug output based on the current page.
                            switch(Page) {
                                default:
                                    rawOutput = new string[] {
                                        $"Build: {Ver.Build}",
                                        " ",
                                        $"Parent Form: {(ActiveForm != null ? $"{ActiveForm?.Name} | # Of Children: {ActiveForm?.Controls?.Count}" : "Console")}",
                                        " ",
                                        $"Active Page: {Page}",
                                        $"  Pages: {string.Join(", ", Pages)}",
                                        " ",
                                        $"MouseIsDown: {MouseIsDown} | MouseScrolled: {MouseScrolled}",
                                        $"Control: {HoveredControl?.Name} | {controlType?.Substring(controlType.LastIndexOf('.') + 1)} | {HoveredControl?.ForeColor.Name}",
                                        $"{(HoveredControl?.GetType() == typeof(Button) ? ((Button)HoveredControl)?.Variable : " ")}",
                                        $" Size: {HoveredControl?.Size} | Pos: {HoveredControl?.Location}",
                                        $" Parent [{HoveredControl?.Parent?.Name}]",
                                    };
                                    break;
                                case PageID.PS4DebugHelpPage:

                                    rawOutput = new string[] {
                                        $"Build: {Ver.Build}",
                                        " ",
                                        $"Parent Form: {(ActiveForm != null ? $"{ActiveForm?.Name} | # Of Children: {ActiveForm?.Controls?.Count}" : "Console")}",
                                        " ",
                                        //$"TitleID: {(PS4DebugPage.TitleID == "?" ? "UNK" : PS4DebugPage.TitleID)} | Game Version: {PS4DebugPage.GameVersion}",
                                        $"GameID: {ActiveGameID} | {(Page == PageID.PS4DebugPage ? $"Peek Test: {Dev.ActivePage.TitleID}" : "load the page, fucker")}",
                                        //$"ProcessName: {PS4DebugPage.ProcessName} | PDbg Connected: {PS4DebugPage.PS4DebugIsConnected}",
                                        " ",
                                        $"MouseIsDown: {MouseIsDown} | MouseScrolled: {MouseScrolled}",
                                        $"Control: {HoveredControl?.Name} | {controlType?.Substring(controlType.LastIndexOf('.') + 1)}",
                                        $"{(HoveredControl?.GetType() == typeof(Button) ? ((Button)HoveredControl)?.Variable : " ")}",
                                        $" Size: {HoveredControl?.Size} | Pos: {HoveredControl?.Location}",
                                        $" Parent [{HoveredControl?.Parent?.Name}]",
                                    };
                                break;
                                case PageID.PS4MenuSettingsPage:
                                    rawOutput = new string[] {
                                        "",
                                        $"| Disable FPS:          {PS4MenuSettingsPage.UniversalPatchValues[0]}",
                                        $"| Paused Icon:          {PS4MenuSettingsPage.UniversalPatchValues[1]}",
                                        $"| ProgPauseOnOpen:      {PS4MenuSettingsPage.UniversalPatchValues[2]}",
                                        $"| ProgPauseOnExit:      {PS4MenuSettingsPage.UniversalPatchValues[3]}",
                                        $"| Novis:                {PS4MenuSettingsPage.UniversalPatchValues[4]}",
                                         "| ",
                                        $"| Menu Scale:           {dynamicVars[0]}",
                                        $"| Menu Alpha:           {dynamicVars[1]}",
                                        $"| Non-ADS FOV:          {dynamicVars[2]}",
                                        $"| Camera X-Align:       {dynamicVars[3]}",
                                        $"| Shadowed Text:        {dynamicVars[4]}",
                                        $"| Swap Square & Circle: {dynamicVars[5]}",
                                        $"| Right Align:          {dynamicVars[6]}",
                                        $"|    Right Margin:      {dynamicVars[7]}\n"
                                    };
                                break;
                            }
                        }
                        catch(Exception e) {
                            rawOutput = new string[] { "Error.", e.Message };
                            Testing.Print($"!! ERROR: an exception occured during debug output loop while setting \"frame\".\nException: {e.Message}");
                        }

                        if(LogShouldRefresh || !chk1.SequenceEqual(rawOutput) || chk1 == null || !chk2.SequenceEqual(OutputStrings)) {
                            chk1 = rawOutput;
                            chk2 = OutputStrings;
                            SizeF TextSize;
                            FormScale = Size.Empty;

                            // Resize LogWindow To Fit Rendered Text, With A Padding of 6 Pixels (Half Because It's Also Placed 6 Pixles In On Each Axis Below)
                            foreach(string line in rawOutput) {
                                TextSize = LogWindowRenderer.MeasureString(line, logFont);

                                if((int)TextSize.Width > FormScale.Width - 12)
                                    FormScale.Width = (int)TextSize.Width + 12;

                                FormScale.Height += (int)TextSize.Height;

                                if(line != "")
                                    output += $"{line}\n";
                            }

                            output += " \n";
                            
                            foreach(string line in OutputStrings)
                            {
                                TextSize = LogWindowRenderer.MeasureString(line, logFont);

                                if(TextSize.Width > FormScale.Width - 12)
                                    FormScale.Width = (int)TextSize.Width + 12;

                                FormScale.Height += (int)TextSize.Height;

                                if(line == "")
                                    output += "!\n";
                                else
                                    output += $"{line}\n";
                            }

                            FormScale.Height += 50; // Border Offset + Padding

                            // Resize Form Back On Main LogWindow Thread
                            try {
                                LogPtr.Invoke(ResizeLog);
                            }
                            catch(InvalidOperationException) {
                                MessageBox.Show("Error Resizing Log Form");
                            }


                            // Clear Last "Frame", Draw Text And Border
                            LogWindowRenderer.Clear(Common.MainColour);
                            LogWindowRenderer.DrawLine(logPen, 0f, 30f, (float)LogPtr.Width, 30f);

                            LogWindowRenderer.DrawLines(logPen, new Point[] {
                                    Point.Empty,
                                    new Point(LogPtr.Width-1, 0),
                                    new Point(LogPtr.Width-1, LogPtr.Height-1),
                                    new Point(0, LogPtr.Height-1),
                                    Point.Empty
                            });

                            // Draw 
                            LogWindowRenderer.DrawString(output, logFont, Brushes.White, new PointF(6f, 35f));
                            LogShouldRefresh ^= LogShouldRefresh;
                        }
                    }
                    catch(System.ObjectDisposedException) { }
                }
            }




            /// <summary>
            /// Dispose of the log thread
            /// TODO: Implement this properly.
            /// </summary>
            new public void Dispose()
            {
                LogThread?.Abort();
                LogPtr?.Dispose();
                LogFile?.Dispose();

                base.Dispose();
            }
        }
        #endregion
#endif
    }
}