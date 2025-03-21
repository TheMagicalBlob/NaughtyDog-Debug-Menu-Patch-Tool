# if DEBUG
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static Dobby.Common;
using static Dobby.Testing;

namespace Dobby
{
    /// <summary>
    /// Class for standard debug display / logging;
    /// </summary>
    partial class DebugWindow : Form
    {
        public DebugWindow(Form Gaia)
        {
            InitializeComponent();

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
                },
                new Button {
                    ForeColor = SystemColors.Control,
                    Font = DButtonFont,
                    Text = "GS_Btn tst",
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
                new EventHandler((control, args) => HighlightColour = Color.FromArgb(255, 0, 255)),
                new EventHandler((control, args) => ActivePage.TestGSButtons())
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
            ParentPtr.LocationChanged += (sender, args) => MoveLogToAppEdge();

            LogWindowRenderer = CreateGraphics();

            LogFile = File.CreateText($"{Directory.GetCurrentDirectory()}\\out.txt");
            (LogThread = new Thread(new ThreadStart(UpdateConsoleOutput))).Start();
        }

        

        public static Form ParentPtr;
        public static Form LogPtr;
        
        public static Size FormScale;

        private static Graphics LogWindowRenderer;

        private static StreamWriter LogFile;

        public static string[] LogBuffer;

        public static bool LogShouldRefresh, LogShouldPause;

        private static int OutputStringIndex = 0, ShiftIndex = 0;

        public static string[] OutputStrings = new string[35];
            
        
        /// <summary> Active Page reference for debug output loop. </summary>
        private dynamic ActivePage {
            get => activePage;
            set {
                activePage = value;
                SetLogParent(value);
            }
        }
        private dynamic activePage;


            
        /// <summary>
        /// Sets the form to anchor the log window to.
        /// </summary>
        /// <param name="Gaia"> The anchor form. </param>
        public void SetLogParent(Form Gaia)
        {
            ParentPtr = Gaia;
        }


        public void MoveLogToAppEdge()
        {
            if (LogPtr == null)
            {
                return;
            }


            LogPtr.BringToFront();
            ParentPtr.BringToFront();

            LogPtr.Location = new Point(ParentPtr.Location.X - LogPtr.Size.Width, ParentPtr.Location.Y);
            LogPtr.Update();
        }

            
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
            PageID? activePage;
            string output;
            string[] rawOutput;
            string[]
                chk1 = Array.Empty<string>(),
                chk2 = Array.Empty<string>()
            ;

            var logPen  = new Pen(Common.HighlightColour);
            var logFont = new Font("Consolas", 8.5f, FontStyle.Bold);

            while(true) {
                try {
                    // Lazy way to pause output.
                    while(LogShouldPause);

                    output = string.Empty;
                    var controlType = HoveredControl?.GetType().ToString();

                    try {
                        activePage = OverrideDynamicOutput ? PageID.MainPage : Common.Page;

                        // Switch between various formats of debug output based on the current page.
                        switch(activePage) {
                            default:
                                rawOutput = new string[] {
                                    $"Build: {Ver.Build}",
                                    " ",
                                    $"Parent Form: {(ActiveForm != null ? $"{ActiveForm?.Name} | # Of Children: {ActiveForm?.Controls?.Count}" : "Console")}",
                                    " ",
                                    $"Active Page: {Common.Page}",
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
                                    $"GameID: {ActiveGameID} | {(Common.Page == PageID.PS4DebugPage ? $"Peek Test: {ActivePage.TitleID}" : "load the page, fucker")}",
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
                                rawOutput = ActivePage.PeekMenuSettingsOptions();
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
}
#endif
