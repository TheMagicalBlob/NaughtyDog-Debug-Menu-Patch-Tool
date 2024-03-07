using libdebug;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dobby {
    public class Dev : Common {
        ////////////\\\\\\\\\\\\
        ///-- DEBUG CLASS  --\\\
        ////////////\\\\\\\\\\\\

        public const bool REL =
#if !DEBUG
        true;
#else
        false;

        /// <summary> Dev Label Event Handler Function </summary>
        public static void MiscDebugFunc(object sender, EventArgs e) {
            if(((Control)sender).Text == "(Dev)") {
                foreach(var v in GetControlsInOrder(LogWindow.GetParent())) {
                    MsgOut($"|RET {v.Name} at {v.Location}|");
                }


                LogWindow.Pause();
                return;
            }


        }
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

        public static void OpenLog(object _ = null, EventArgs __ = null) {

            if(MessageBox.Show("Open Log?", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            System.Diagnostics.Process.Start($"{Directory.GetCurrentDirectory()}\\out.txt");
            LogWindow.Exit();
            Environment.Exit(0);
        }
        public static void SwitchToRelease(object _ = null, EventArgs __ = null) {
            LogWindow.Exit();
            System.Diagnostics.Process.Start($@"{Directory.GetParent(Directory.GetCurrentDirectory())}\Release\ND Debug Enabler.exe");
            Environment.Exit(1);
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
                        MsgOut(line);

                chk = lines;
                goto start;
            }
            catch(Exception e) {
                MsgOut($"rTst Failed, Cause: {e.Message}");
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
        private static Point[] OldPositions = new Point[1] { Point.Empty };
        private static Size OldFormScale;
        private static string EditedForm;
        private static int Next_Base;
        private static void ResizeTest() {
            return;

            var Mommy = LogWindow.GetParent();
            int index = 0,
                PAD = 1
            ;

            var Controls = new List<Control>(GetControlsInOrder(Mommy));
            for(; Controls[0].Name != "SeperatorLine0"; Controls.Remove(Controls[index - index++]));

            if((index ^= 3) != 0) { MessageBox.Show($"Unexpected Form Structure {index}"); Environment.Exit(1); }
            if(OldPositions.Length == 1 || EditedForm != Mommy.Name) {
                MsgOut("Beeg");

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
                        MsgOut($"Control Went Passed Form Border, Extending Form ({Controls[index].Location.Y} > {Mommy.Size.Height})");
                        Mommy.Size = new Size(Mommy.Size.Width, Controls[index].Location.Y + Controls[index].Size.Height + 1);
                        Mommy.Update();
                        Mommy.Refresh();
                        Mommy.Update();
                    }
                }
                return;
            }

            MsgOut("Smol");
            foreach(Control bitch in Controls) {
                MsgOut($"{bitch.Location} -> {OldPositions[index]}");
                bitch.Location = OldPositions[index++];
            }
            Mommy.Size = OldFormScale;
            Mommy.Update();

            OldPositions = new Point[1] { Point.Empty };
            EditedForm = string.Empty;
        }

        /// <summary>
        /// Log Window Class
        /// </summary>
        public partial class LogWindow : Form {
            public LogWindow(Form Gaia) {
                Font DButtonFont = new Font("Cambria", 7F, FontStyle.Bold);

                Button[] DButtons = new Button[] {
                    new Button {
                        TabIndex = 0,
                        ForeColor = SystemColors.Control,
                        Font = DButtonFont,
                        Text = "(Dev)",
                        Name = "!!!"
                    },
                    new Button {
                        TabIndex = 1,
                        ForeColor = SystemColors.Control,
                        Font = DButtonFont,
                        Text = "LogTxt",
                        Name = "!!!"
                    },
                    new Button {
                        TabIndex = 2,
                        ForeColor = SystemColors.Control,
                        Font = DButtonFont,
                        Text = "Boot Release",
                        Name = "!!!"
                    }
                };

                EventHandler[] Handlers = new EventHandler[] {
                    new EventHandler(MiscDebugFunc),
                    new EventHandler(OpenLog),
                    new EventHandler(SwitchToRelease),
                };


                // LogWindow Form And Control Initializations
                BackColor = Gaia.BackColor;
                FormBorderStyle = FormBorderStyle.None;
                Name = "LogWindow";
                foreach(Button c in DButtons) {
                    Controls.Add(c);
                    c.FlatStyle = FlatStyle.Flat;
                    c.FlatAppearance.BorderSize = 0;
                    c.Click += Handlers[c.TabIndex];
                    c.Size = TryAutosize(c);
                    c.BringToFront();

                }
                //\\

                // LogWindow Event Handlers
                MouseEnter += DebugControlHover;
                MouseDown  += MouseDownFunc;
                MouseUp    += MouseUpFunc;
                //\\

                LogWindowRenderer = this.CreateGraphics();
                LogPtr = this;
                SetParent(Gaia);

                LogFile = File.CreateText($"{Directory.GetCurrentDirectory()}\\out.txt");
                logThread.Start();
            }

            private static Form LogPtr, ParentPtr;
            public static Size formScale;

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
            public static void MoveLogToAppEdge(object mommy, EventArgs e) => LogPtr.Location = new Point(((Form)mommy).Location.X - LogPtr.Size.Width, ((Form)mommy).Location.Y);
            public static void MoveLogToAppEdge(Point Loc) => LogPtr.Location = new Point(Loc.X - LogPtr.Size.Width, Loc.Y);


            public delegate void Scaling();
            public static Scaling resize = new Scaling(ResizeLog);
            private static void ResizeLog() {
                LogPtr.Size = formScale;
                LogWindowRenderer = LogPtr.CreateGraphics();

            Reset:
                LogPtr.Location = new Point(ParentPtr.Location.X - LogPtr.Size.Width, ParentPtr.Location.Y);
                LogPtr.Update();


                var ControlOffset = 0;
                foreach(Control c in LogPtr.Controls) { 
                    c.Location = new Point(LogPtr.Size.Width - c.Size.Width - ControlOffset - 1, 1);
                    if(c.Location.X < 0) {
                        LogPtr.Size = new Size(LogPtr.Size.Width + c.Size.Width + 1, LogPtr.Size.Height);
                        goto Reset;
                    }

                    ControlOffset += c.Size.Width;
                }
                if(PkgCreationPage.debug && !REL) Console.WriteLine($"Should be: {formScale} \\ Is: {LogPtr.Size}");
            }

            public static void Exit() {
                logThread.Abort();
                LogPtr.Dispose();
            }

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
                            while(LogShouldPause);

                            switch(Page) {
                                default:
                                    Output = new string[] {
                                        $"Build: {Build}                   [Delay: ~{Delay}ms]",
                                        " ",
                                        $"Parent Form: {(ActiveForm != null ? $"{ActiveForm?.Name} | # Of Children: {ActiveForm?.Controls?.Count}" : "Console")}",
                                        " ",
                                        $"TitleID: {(PS4DebugPage.TitleID == "?" ? "UNK" : PS4DebugPage.TitleID)} | Game Version: {PS4DebugPage.GameVersion}",
                                        $"GameID: {ActiveGameID}",
                                        $"ProcessName: {PS4DebugPage.ProcessName} | PDbg Connected: {PS4DebugPage.PS4DebugIsConnected}",
                                        " ",
                                        $"MouseIsDown: {MouseIsDown} | MouseScrolled: {MouseScrolled}",
                                        $"Control: {HoveredControl?.Name} | {ControlType?.Substring(ControlType.LastIndexOf('.') + 1)}",
                                        $"{(HoveredControl?.GetType() == typeof(VarButton) ? ((VarButton)HoveredControl)?.Variable : " ")}",
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
                                        $"| Game Index:           {PS4MenuSettingsPage.GameIndex}",
                                        $"| Disable FPS:          {PS4MenuSettingsPage.UniversaPatchValues[0]}",
                                        $"| Paused Icon:          {PS4MenuSettingsPage.UniversaPatchValues[1]}",
                                        $"| ProgPauseOnOpen:      {PS4MenuSettingsPage.UniversaPatchValues[2]}",
                                        $"| ProgPauseOnExit:      {PS4MenuSettingsPage.UniversaPatchValues[3]}",
                                        $"| Novis:                {PS4MenuSettingsPage.UniversaPatchValues[4]}",
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
                            Output = new string[] { "Error", e.Message };
                        }

                        if(LogShouldRefresh || !chk1.SequenceEqual(Output) || chk1 == null || !chk2.SequenceEqual(OutputStrings)) {
                            chk1 = Output;
                            chk2 = OutputStrings;
                            SizeF TextSize;
                            formScale = Size.Empty;

                            // Resize LogWindow To Fit Rendered Text, With A Padding of 6 Pixels (Half Because It's Also Placed 6 Pixles In On Each Axis Below)
                            foreach(string line in Output) {
                                TextSize = LogWindowRenderer.MeasureString(line, DFont);

                                if((int)TextSize.Width > (int)formScale.Width - 12)
                                    formScale.Width = (int)TextSize.Width + 12;

                                formScale.Height += (int)TextSize.Height;

                                if(line != "")
                                    Out += $"{line}\n";
                            }

                            Out += " \n";
                            
                            foreach(string line in OutputStrings) {
                                TextSize = LogWindowRenderer.MeasureString(line, DFont);

                                if(TextSize.Width > formScale.Width - 12)
                                    formScale.Width = (int)TextSize.Width + 12;

                                formScale.Height += (int)TextSize.Height;

                                if(line != "")
                                    Out += $"{line}\n";

                                else
                                    Out += "!\n";
                            }

                            formScale.Height += 50; // Border Offset + Padding

                            Console.WriteLine(formScale);
                            // Resize Form Back On Main LogWindow Thread
                            try { LogPtr.Invoke(resize); }

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
        public static void LineOut(string StringToEnclose = null) {
#if DEBUG
            var str = string.Empty;

            if(StringToEnclose != null && LogWindow.formScale.Width < TextRenderer.MeasureText(StringToEnclose, MainFont).Width)
                LogWindow.formScale.Width = TextRenderer.MeasureText(StringToEnclose, MainFont).Width;

            while(TextRenderer.MeasureText(str, MainFont).Width < LogWindow.formScale.Width)
                str += '-';

            MsgOut($"\n{str}\n{StringToEnclose}\n{str}");
#endif
        }

        public static bool MsgOut(object obj = null) {
#if DEBUG
            string str;

            if(obj == null) str = " ";

            else str = obj.ToString();
            
            if(str.Contains("\n"))
                str = str.Replace("\n", "\n "); // So It Still Has A Size (for log window scaling purposes)

            LogWindow.LogOut(str);
#endif
            return obj == null;
        }
    }
}