using libdebug;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Dobby {

    /// <summary>
    /// Lazy/Messy class for general debugging/testing-related stuff.
    /// </summary>
    public class Dev : Common {
        /*//////////\\\\\\\\\\\\
        ///-- DEBUG CLASS  --\\\
        ////////////\\\\\\\\\\*/
        
        /// <summary>
        /// Default message output function. Prints to the debug window if present, as well as the standard output
        /// </summary>
        /// <param name="obj"></param>
        public static void Print(object obj = null) {
#if DEBUG
            string str;

            // Some formatting stuff
            if(obj == null || obj.ToString().Length < 1)
                str = " ";
            else
                str = obj.ToString();

            if(str.Contains("\n"))
                str = str.Replace("\n", "\n "); // So It Still Has A Size (for log window scaling purposes)
            //^



            LogWindow.LogOut(str);
            Debug.WriteLine(str);
            if (!Console.IsInputRedirected)
                Console.WriteLine(str);
#endif
        }
        
        /// <summary>
        /// Basic error logging function (not yet fully implemented)
        /// </summary>
        public static void PrintError(Exception tabarnack) {
#if DEBUG
            Print($"!! ERROR: {tabarnack.Message}\n{tabarnack.StackTrace.Replace("\n", "  \n")}");
            
            // placeholder
#endif
        }



#if DEBUG


        public static Control[] GetControlsInOrder(Form Parent) {
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


        public static void StartReadLogTest() => ReadTest.Start();

        private static Thread ReadTest = new Thread(new ThreadStart(rTst));

        private static void rTst() {
            try {
                string[] chk = Array.Empty<string>(), lines;

            start:
                while(!File.Exists(@"C:\Users\Blob\Desktop\out.txt")) ;

                lines = File.ReadAllLines(@"C:\Users\Blob\Desktop\out.txt");
                if(chk.Equals(Array.Empty<string>()) || lines.SequenceEqual(chk))

                    foreach(var line in lines)
                        Print(line);

                chk = lines;
                goto start;
            }
            catch(Exception e) {
                Print($"rTst Failed, Cause: {e.Message}");
            }
        }

        public static void DebugControlHover(object sender, EventArgs e) => HoveredControl = (Control)sender;

        public static bool OverrideMsgOut;

        private static int OutputStringIndex = 0, ShiftIndex = 0;



        public static string[] OutputStrings = new string[35];


        public static Control HoveredControl = new Label(); // Just so the debugger doesn't bitch

        public delegate void Rendering(Control control);

        public static Rendering RenderPause = new Rendering(PauseRendering);
        public static Rendering RenderResume = new Rendering(ResumeRendering);

        private static void PauseRendering(Control control) => UpdateRendering((IntPtr)0, control);
        private static void ResumeRendering(Control control) => UpdateRendering((IntPtr)1, control);
        private static void UpdateRendering(IntPtr toggle, Control control) {
            var Window = NativeWindow.FromHandle(control.Handle);
            var Msg = Message.Create(control.Handle, 11, toggle, IntPtr.Zero);

            Window.DefWndProc(ref Msg);

            if((int)toggle != 0)
                control.Update();
        }
        
        /// <summary>
        /// Calculates A Size Exactly Large Enough (Hopefully)
        /// To Fit The Item's Text Content
        /// </summary>
        /// <returns> A New Size For cunt </returns>
        private static Size TryAutosize(Control cunt) {
            var gr = cunt.CreateGraphics();

            var size = gr.MeasureString(cunt.Text, cunt.Font);
            return new Size((int)size.Width + 15, (int)size.Height + 10);
        }

        // Style Test (fuck it, too annoying dealing with overlapping controls, and I've wasted enough time on this already)
        #region [Style Test]
        private static Point[] OldPositions = new Point[1] { Point.Empty };
        private static Size OldFormScale;
        private static string EditedForm;
        private static int Next_Base;
        private static void ResizeTest() {
            return;

            var Mommy = LogWindow.ParentPtr;
            int index = 0,
                PAD = 1
            ;

            var Controls = new List<Control>(GetControlsInOrder(Mommy));
            for(; Controls[0].Name != "SeperatorLine0"; Controls.Remove(Controls[index - index++]));

            if((index ^= 3) != 0) { MessageBox.Show($"Unexpected Form Structure {index}"); Environment.Exit(1); }
            if(OldPositions.Length == 1 || EditedForm != Mommy.Name) {
                Print("Beeg");

                // Save Orignal Item Locations
                for(OldPositions = new Point[Mommy.Controls.Count]; index < Controls.Count;)
                    OldPositions[index] = Controls[index++].Location;

                // Avoid Breaking The Form If Used On Another Page Without Reseting
                EditedForm = Mommy.Name;
                // Start At The First Control After The Title Section Seperator Line
                Next_Base = Controls[index = 0].Location.Y + Controls[index++].Size.Height + PAD;

                OldFormScale = Mommy.Size;

                // Attempt To Adjust Control Positions To Consistent Locations
                for(; index != Controls.Count; index++) {
                    var Last_Pos = Controls[index].Location;

                    Controls[index].Location = new Point(Controls[index].Location.X, Next_Base);
                    Next_Base = Controls[index].Location.Y + Controls[index].Size.Height + PAD;


                    if(index < Controls.Count - 1 && Controls[index + 1].Location.Y < Next_Base) {
                        var Diff = Controls[index].Location.Y - Last_Pos.Y;
                        Controls[index + 1].Location = new Point(Controls[index + 1].Location.X, Controls[index + 1].Location.Y + Diff);
                        if(Controls[index + 1].Name.Contains("SeperatorLine")) {
                            Next_Base = Controls[index + 1].Location.Y + Controls[index + 1].Size.Height + PAD + 1;
                        }
                        index++;
                    }

                    // Adjust Form Size If The Control Has Been Moved Off The Form
                    if(Controls[index].Location.Y + Controls[index].Size.Height > Mommy.Size.Height) {//UwU
                        Print($"Control Went Passed Form Border, Extending Form ({Controls[index].Location.Y} > {Mommy.Size.Height})");
                        Mommy.Size = new Size(Mommy.Size.Width, Controls[index].Location.Y + Controls[index].Size.Height + 1);
                        Mommy.Update();
                        Mommy.Refresh();
                        Mommy.Update();
                    }
                }
                return;
            }

            Print("Smol");
            foreach(Control bitch in Controls) {
                Print($"{bitch.Location} -> {OldPositions[index]}");
                bitch.Location = OldPositions[index++];
            }
            Mommy.Size = OldFormScale;
            Mommy.Update();

            OldPositions = new Point[1] { Point.Empty };
            EditedForm = string.Empty;
        }
        #endregion [Style Test]


        /// <summary>
        /// Log Window Class
        /// </summary>
        public partial class LogWindow : Form {
            public LogWindow(Form Gaia) {
                Font DButtonFont = new Font("Cambria", 7F, FontStyle.Bold);

                var DButtons = new Button[] {
                    new Button {
                        TabIndex = 1,
                        ForeColor = SystemColors.Control,
                        Font = DButtonFont,
                        Text = "LogTxt",
                        Name = "DebugControl"
                    },
                    new Button {
                        TabIndex = 2,
                        ForeColor = SystemColors.Control,
                        Font = DButtonFont,
                        Text = "Boot Release",
                        Name = "DebugControl"
                    },
                    new Button {
                        TabIndex = 2,
                        ForeColor = SystemColors.Control,
                        Font = DButtonFont,
                        Text = "Clear Info Label",
                        Name = "DebugControl"
                    }
                };

                var Handlers = new EventHandler[] {
                    new EventHandler((_, __) => { 
                        if(MessageBox.Show("Open Log?", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                            return;

                        System.Diagnostics.Process.Start($"{Directory.GetCurrentDirectory()}\\out.txt");
                        LogWindowExit();
                        Environment.Exit(0);
                    }),
                    new EventHandler((_, __) => {
                        LogWindowExit();
                        System.Diagnostics.Process.Start($@"{Directory.GetParent(Directory.GetCurrentDirectory())}\Release\ND Debug Enabler.exe");
                        Environment.Exit(1);
                    }),
                    new EventHandler((control, args) => ActiveForm?.Invoke(SetInfoText)),
                    new EventHandler((control, args) => ActiveForm?.Invoke(SetInfoText))
                };




                // LogWindow Form And Control Initializations
                BackColor = Gaia.BackColor;
                FormBorderStyle = FormBorderStyle.None;
                Name = "LogWindow";
                foreach(Button debugControl in DButtons) {
                    Controls.Add(debugControl);
                    debugControl.FlatStyle = FlatStyle.Flat;
                    debugControl.FlatAppearance.BorderSize = 0;
                    debugControl.Click += Handlers[debugControl.TabIndex];
                    debugControl.Size = TryAutosize(debugControl);
                    debugControl.BringToFront();

                }


                // LogWindow Event Handlers
                MouseEnter += DebugControlHover;
                MouseDown  += MouseDownFunc;
                MouseUp    += MouseUpFunc;


                LogPtr = this;
                LogWindowRenderer = CreateGraphics();
                SetParent(Gaia);

                LogFile = File.CreateText($"{Directory.GetCurrentDirectory()}\\out.txt");
                logThread.Start();
            }

            public static Form LogPtr, ParentPtr;
            public static Size FormScale;

            private static Graphics LogWindowRenderer;

            private static StreamWriter LogFile;
            public static string[] LogBuffer;

            #region timer crap
            private static float Delay = 0;
            private static bool TimerThreadStarted = false;
            public static bool LogShouldRefresh, LogShouldPause;
            private static readonly System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            private static readonly Thread TimerThread = new Thread(StartTimer);
            private static float TimerTicks = 0;
            private static void Timer_Tick(object sender, EventArgs e) => TimerTicks+= 0.001f;
            private static void StartTimer() {
                if(!timer.Enabled) {
                    timer.Interval = 1;
                    timer.Tick += Timer_Tick;
                    timer.Start();
                }
            }
            #endregion

            public static void Pause() => LogShouldPause ^= true;

            // Sets The Form To Attach The Log Window To
            public static void SetParent(Form Gaia) {
                
                ParentPtr = Gaia;
                Gaia.LocationChanged -= MoveLogToAppEdge;
            }
            // mmbeep
            public static Form GetParent() { return ParentPtr; }

            private void MouseDownFunc(object sender, MouseEventArgs e) => MouseIsDown = true;
            private void MouseUpFunc(object sender, MouseEventArgs e) => MouseScrolled = MouseIsDown = false;
            public static void MoveLogToAppEdge(object mommy, EventArgs e)
            {
                LogPtr.BringToFront();
                ((Form) mommy).BringToFront();
                LogPtr.Location = new Point(((Form)mommy).Location.X - LogPtr.Size.Width, ((Form)mommy).Location.Y);
            }
            public static void MoveLogToAppEdge(Point Loc) => LogPtr.Location = new Point(Loc.X - LogPtr.Size.Width, Loc.Y);


            public delegate void scaling();
            public static scaling ResizeLog = new scaling(() =>
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


            public static void LogWindowExit() {
                logThread.Abort();
                LogPtr.Dispose();
            }



            /// <summary>
            /// what the fuck
            /// </summary>
            public static void LogOut(string str) {
                while(LogFile == null);

                LogFile.WriteLine(str);
                LogFile.Flush();

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


            private static readonly Thread logThread = new Thread(new ThreadStart(UpdateConsoleOutput));
            public static void UpdateConsoleOutput() {
                if(ActiveForm != null && !TimerThreadStarted) {
                    TimerThread.Start(); TimerThreadStarted = true;
                }

                string Out;
                string[] Output, chk1 = Array.Empty<string>(), chk2 = Array.Empty<string>();

                Pen pen = new Pen(Color.White);
                Font DFont = new Font("Consolas", 8.5f, FontStyle.Bold);

                while(true) {
                    try {
                        Out = string.Empty;
                        var StartTime = TimerTicks;
                        var ControlType = HoveredControl?.GetType().ToString();

                        var DynamicVars = PS4MenuSettingsPage.PeekGameSpecificPatchValues();

                        try {

                            // Lazy way to pause output.
                            while(LogShouldPause);

                            // Switch between various formats of debug output based on the current page.
                            switch(Page) {
                                default:
                                    //Output = new string[] {
                                    //    $"Build: {Ver.Build} | [Delay: ~{Delay}ms]",
                                    //    $"Build: {Ver.Build} | [Delay: ~{Delay}ms]",
                                    //    $"Build: {Ver.Build} | [Delay: ~{Delay}ms]",
                                    //};
                                    //break;
                                case PageID.EbootPatchPage:
                                    Output = new string[] {
                                        $"Build: {Ver.Build} ~{Delay}ms",
                                        " ",
                                        $"Parent Form: {(ActiveForm != null ? $"{ActiveForm?.Name} | # Of Children: {ActiveForm?.Controls?.Count}" : "Console")}",
                                        " ",
                                        $"TitleID: {(PS4DebugPage.TitleID == "?" ? "UNK" : PS4DebugPage.TitleID)} | Game Version: {PS4DebugPage.GameVersion}",
                                        $"GameID: {ActiveGameID}",
                                        $"ProcessName: {PS4DebugPage.ProcessName} | PDbg Connected: {PS4DebugPage.PS4DebugIsConnected}",
                                        " ",
                                        $"MouseIsDown: {MouseIsDown} | MouseScrolled: {MouseScrolled}",
                                        $"Control: {HoveredControl?.Name} | {ControlType?.Substring(ControlType.LastIndexOf('.') + 1)}",
                                        $"{(HoveredControl?.GetType() == typeof(Button) ? ((Button)HoveredControl)?.Variable : " ")}",
                                        $" Size: {HoveredControl?.Size} | Pos: {HoveredControl?.Location}",
                                        $" Parent [{HoveredControl?.Parent?.Name}]",
                                        $" Nex_Pos' [{Next_Base}]",

                                        (MainStreamIsOpen ? " " : ""),

                                        $"{(MainStreamIsOpen ? $"PS4Stream: {MainStream.Name}" : (PCDebugMenuPage.MainStreamIsOpen ? " " : ""))}",
                                        $"{(MainStreamIsOpen ? $"Length: {(MainStream.Length.ToString().Length > 6 ? $"{MainStream.Length.ToString().Remove(2)}MB" : $"{MainStream.Length} bytes")} | Read: {MainStream.CanRead} | Write: {MainStream.CanWrite}" : (PCDebugMenuPage.MainStreamIsOpen ? " " : ""))}",
                                    };
                                break;
                                case PageID.PS4MenuSettingsPage:
                                    Output = new string[] {
                                        "",
                                        $"| Game Index:           {PS4MenuSettingsPage.GameIndex}",
                                        $"| Disable FPS:          {PS4MenuSettingsPage.UniversalPatchValues[0]}",
                                        $"| Paused Icon:          {PS4MenuSettingsPage.UniversalPatchValues[1]}",
                                        $"| ProgPauseOnOpen:      {PS4MenuSettingsPage.UniversalPatchValues[2]}",
                                        $"| ProgPauseOnExit:      {PS4MenuSettingsPage.UniversalPatchValues[3]}",
                                        $"| Novis:                {PS4MenuSettingsPage.UniversalPatchValues[4]}",
                                         "| ",
                                        $"| Menu Scale:           {DynamicVars[0]}",
                                        $"| Menu Alpha:           {DynamicVars[1]}",
                                        $"| Non-ADS FOV:          {DynamicVars[2]}",
                                        $"| Camera X-Align:       {DynamicVars[3]}",
                                        $"| Shadowed Text:        {DynamicVars[4]}",
                                        $"| Swap Square & Circle: {DynamicVars[5]}",
                                        $"| Right Align:          {DynamicVars[6]}",
                                        $"|    Right Margin:      {DynamicVars[7]}\n"
                                    };
                                break;
                                case PageID.PkgCreationPage:
                                    var arr = PkgCreationPage.DebugPeek();
                                    Output = new string[] {
                                        $"| Build Is Ready: {!(arr[0].Equals("?") && arr[1].Equals("?"))}",
                                        $"| ",
                                        $"| ",
                                        $"| ",
                                        $"| ",
                                        $"| ",
                                        $"| ",
                                    };
                                break;
                            }
                        }
                        catch(Exception e) {
                            Output = new string[] { "Error.", e.Message };
                            Print($"!! ERROR: an exception occured during debug output loop while setting \"frame\"");
                        }

                        if(LogShouldRefresh || !chk1.SequenceEqual(Output) || chk1 == null || !chk2.SequenceEqual(OutputStrings)) {
                            chk1 = Output;
                            chk2 = OutputStrings;
                            SizeF TextSize;
                            FormScale = Size.Empty;

                            // Resize LogWindow To Fit Rendered Text, With A Padding of 6 Pixels (Half Because It's Also Placed 6 Pixles In On Each Axis Below)
                            foreach(string line in Output) {
                                TextSize = LogWindowRenderer.MeasureString(line, DFont);

                                if((int)TextSize.Width > (int)FormScale.Width - 12)
                                    FormScale.Width = (int)TextSize.Width + 12;

                                FormScale.Height += (int)TextSize.Height;

                                if(line != "")
                                    Out += $"{line}\n";
                            }

                            Out += " \n";
                            
                            foreach(string line in OutputStrings) {
                                TextSize = LogWindowRenderer.MeasureString(line, DFont);

                                if(TextSize.Width > FormScale.Width - 12)
                                    FormScale.Width = (int)TextSize.Width + 12;

                                FormScale.Height += (int)TextSize.Height;

                                if(line != "")
                                    Out += $"{line}\n";

                                else
                                    Out += "!\n";
                            }

                            FormScale.Height += 50; // Border Offset + Padding

                            // Resize Form Back On Main LogWindow Thread
                            try { LogPtr.Invoke(ResizeLog); }

                            catch(InvalidOperationException) { MessageBox.Show("Resize Error Noti"); }


                            // Border Setup
                            Point[] Border = new Point[] {
                                    Point.Empty,
                                    new Point(LogPtr.Width-1, 0),
                                    new Point(LogPtr.Width-1, LogPtr.Height-1),
                                    new Point(0, LogPtr.Height-1),
                                    Point.Empty
                            };

                            // Clear Last "Frame", Draw Text And Border
                            LogWindowRenderer.Clear(Color.FromArgb(100, 100, 100));
                            LogWindowRenderer.DrawLine(pen, 0f, 30f, (float)LogPtr.Width, 30f);
                            LogWindowRenderer.DrawLines(pen, Border);
                            LogWindowRenderer.DrawString(Out, DFont, Brushes.White, new PointF(6f, 35f));
                            LogShouldRefresh ^= LogShouldRefresh;
                        }

                        Delay = TimerTicks - StartTime;

                    }
                    catch(System.ObjectDisposedException) { }
                }
            }
        }
#endif
    }
}