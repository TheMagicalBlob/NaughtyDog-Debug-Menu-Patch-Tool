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
using System.Xml.Linq;
using System.ComponentModel;

namespace Dobby {
    public class Dev : Common {
        ////////////\\\\\\\\\\\\
        ///-- DEBUG CLASS  --\\\
        ////////////\\\\\\\\\\\\

#if !DEBUG
            public const bool REL = true;

#elif DEBUG
        public const bool REL = false;

        /// <summary> Dev Label Event Handler Function </summary>
        public static void MiscDebugFunc(object sender, EventArgs e) {
            OverrideDebugOut ^= true;
        }

        public static void DebugControlHover(object sender, EventArgs e) => HoveredControl = (Control)sender;

        public static bool OverrideDebugOut;

        private static int OutputStringIndex = 0;

        private static float TimerTicks = 0;


        public static string[] OutputStrings = new string[20];

        public static int ShiftIndex = 0;


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

            if((int)toggle != 0) {
                control.Update();
            }
        }

        public partial class LogWindow : Form {
            public LogWindow() {
                InitializeComponent();

                MouseDown += MouseDownFunc;
                MouseEnter += DebugControlHover;
                MouseUp += MouseUpFunc;
                MouseMove += MoveForm;

                AppRef = this;
                rend = CreateGraphics();

                AddControlEventHandlers(Controls);
                logThread.Start();
                Location = Point.Empty;
                Click += DebugOut;
            }

            private static Form AppRef;
            private static Graphics rend;
            private static Size formScale;

            #region timer crap
            private static float Delay = 0;
            private static bool TimerThreadStarted = false;
            private static readonly System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            private static readonly Thread TimerThread = new Thread(StartTimer);
            private static void Timer_Tick(object sender, EventArgs e) => TimerTicks+= 0.0001f;
            private static void StartTimer() {
                if(!timer.Enabled) {
                    timer.Interval = 1;
                    timer.Tick += Timer_Tick;
                    timer.Start();
                }
            }
            #endregion

            private void InitializeComponent() {
                BackColor = Color.FromArgb(100, 100, 100);
                FormBorderStyle = FormBorderStyle.None;
                Name = "LogWindow";
                Location = Point.Empty;
            }
            #region Movement
            private void MouseDownFunc(object sender, MouseEventArgs e) {
                MouseIsDown = true; LastPos = ActiveForm.Location;
                MouseDif = new Point(MousePosition.X - ActiveForm.Location.X, MousePosition.Y - ActiveForm.Location.Y);
            }
            private void MouseUpFunc(object sender, MouseEventArgs e) { MouseScrolled = false; MouseIsDown = false; }
            private void MoveForm(object sender, MouseEventArgs e) {
                if(!MouseIsDown)
                    return;

                ActiveForm.Location = new Point(MousePosition.X - MouseDif.X, MousePosition.Y - MouseDif.Y);
                ActiveForm.Update();
            }
            #endregion

            public delegate void Scaling();
            public static Scaling resize = new Scaling(ResizeLog);
            private static void ResizeLog() {
                AppRef.Size = formScale;
                rend = AppRef.CreateGraphics();
            }


            private static readonly Thread logThread = new Thread(new ThreadStart(UpdateConsoleOutput));
            public static void UpdateConsoleOutput() {
#if DEBUG
                if(ActiveForm != null && !TimerThreadStarted) {
                    TimerThread.Start(); TimerThreadStarted = true;
                }

                string Out = string.Empty;
                string[] Output, chk1 = Array.Empty<string>(), chk2 = Array.Empty<string>();

                Pen pen = new Pen(Color.White);

                while(true) {
                    try {
                        float StartTime = TimerTicks;

                        string ControlType = HoveredControl?.GetType().ToString();
                        Out = string.Empty;

                        var DynamicVars = PS4MenuSettingsPage.PeekGameSpecificPatchValues();

                        if (OverrideDebugOut)
                        Output = new string[] {
                                $"| Game Index: {PS4MenuSettingsPage.GameIndex}",
                                $"| Disable FPS:          {PS4MenuSettingsPage.UniversaPatchValues[0]}|{PS4MenuSettingsPage.UniversaPatchValues[1]}",
                                $"| Paused Icon:          {PS4MenuSettingsPage.UniversaPatchValues[2]}",
                                $"| ProgPauseOnOpen:      {PS4MenuSettingsPage.UniversaPatchValues[3]}",
                                $"| ProgPauseOnExit:      {PS4MenuSettingsPage.UniversaPatchValues[4]}",
                                $"| Novis:                {PS4MenuSettingsPage.UniversaPatchValues[5]}",
                                 "| ",
                                $"| Menu Scale:           {DynamicVars[0]}",
                                $"| Menu Alpha:           {DynamicVars[1]}",
                                $"| Non-ADS FOV:          {DynamicVars[2]}",
                                $"| Swap Square & Circle: {DynamicVars[3]}",
                                $"| Shadowed Text:        {DynamicVars[4]}",
                                $"| Right Align:          {DynamicVars[5]}",
                                $"|    Right Margin:      {DynamicVars[6]}\n",
                        };

                        else
                        Output = new string[] {
                            $"Build: {Build}                   [Delay: ~{Delay}ms]",
                            " ",
                            $"Parent Form: {(ActiveForm != null ? $"{ActiveForm?.Name} | # Of Children: {ActiveForm?.Controls?.Count}" : "Console")}",
                            " ",
                            $"TitleID: {(TitleID == "?" ? "UNK" : TitleID)} | Game Version: {GameVersion}",
                            $"GameID: {ActiveGameID}",
                            $"ProcessName: {ProcessName} | PDbg Connected: {PS4DebugIsConnected}",
                            " ",
                            $"MouseIsDown: {MouseIsDown} | MouseScrolled: {MouseScrolled}",
                            $"Control: {HoveredControl?.Name} | {ControlType?.Substring(ControlType.LastIndexOf('.') + 1)}",
                            $"{(HoveredControl?.GetType() == typeof(vButton) ? ((vButton)HoveredControl)?.Variable : " ")}",
                            $" Size: {HoveredControl?.Size} | Pos: {HoveredControl?.Location}",
                            $" Parent [{HoveredControl?.Parent?.Name}]",

                            (EbootPatchPage.MainStreamIsOpen || PCDebugMenuPage.MainStreamIsOpen ? " ": ""),

                            $"{(EbootPatchPage.MainStreamIsOpen ? $"PS4Stream: {EbootPatchPage.MainStream.Name}" : (PCDebugMenuPage.MainStreamIsOpen ? " " : ""))}",
                            $"{(EbootPatchPage.MainStreamIsOpen ? $"Length: {(EbootPatchPage.MainStream.Length.ToString().Length > 6 ? $"{EbootPatchPage.MainStream.Length.ToString().Remove(2)}MB" : $"{EbootPatchPage.MainStream.Length} bytes")} | Read: {EbootPatchPage.MainStream.CanRead} | Write: {EbootPatchPage.MainStream.CanWrite}" : (PCDebugMenuPage.MainStreamIsOpen ? " " : ""))}",

                            (PCDebugMenuPage.MainStreamIsOpen ? " ": ""),

                            $"{(PCDebugMenuPage.MainStreamIsOpen ? $"PCStream: {PCDebugMenuPage.MainStream.Name}" : "")}",
                            $"{(PCDebugMenuPage.MainStreamIsOpen ? $"Length: {(PCDebugMenuPage.MainStream.Length.ToString().Length > 6 ? $"{PCDebugMenuPage.MainStream.Length.ToString().Remove(2)}MB" : $"{PCDebugMenuPage.MainStream.Length} bytes")} | Read: {PCDebugMenuPage.MainStream.CanRead} | Write: {PCDebugMenuPage.MainStream.CanWrite}" : "")}",
                        };

                        if(!chk1.SequenceEqual(Output) || chk1 == null || !chk2.SequenceEqual(OutputStrings)) {
                            chk1 = Output;
                            chk2 = OutputStrings;
                            SizeF TextSize;
                            formScale = Size.Empty;

                            // Resize LogWindow To Fit Rendered Text, With A Padding of 6 Pixels (Half Because It's Also Placed 6 Pixles In On Each Axis Below)
                            foreach(string line in Output) {
                                TextSize = rend.MeasureString(line, MainFont);

                                if(TextSize.Width > formScale.Width - 12)
                                    formScale.Width = (int)TextSize.Width + 12;

                                formScale.Height += (int)TextSize.Height;

                                if(line != "")
                                    Out += $"{line}\n";
                            }

                            Out += " \n";
                            
                            foreach(string line in OutputStrings) {
                                TextSize = rend.MeasureString(line, MainFont);

                                if(TextSize.Width > formScale.Width - 12)
                                    formScale.Width = (int)TextSize.Width + 12;

                                formScale.Height += (int)TextSize.Height;

                                if(line != "")
                                    Out += $"{line}\n";
                            }


                            formScale.Height += 12;


                            // Resize Form Back On Main LogWindow Thread
                            try {
                                AppRef.Invoke(resize);
                            }
                            catch(InvalidOperationException) { MessageBox.Show("Resize Error Noti"); }

                            // Inlined PaintBorder Function Setup
                            Point[] Border = new Point[] {
                                    Point.Empty,
                                    new Point(AppRef.Width-1, 0),
                                    new Point(AppRef.Width-1, AppRef.Height-1),
                                    new Point(0, AppRef.Height-1),
                                    Point.Empty
                            };

                            // Clear Last "Frame", Draw Text And Border
                            rend.Clear(Color.FromArgb(100, 100, 100));
                            rend.DrawLines(pen, Border);
                            rend.DrawString(Out, MainFont, Brushes.White, new Point(6, 6));
                        }

                        Delay = TimerTicks - StartTime;

                    }
                    catch(System.ObjectDisposedException) { }
                }
#endif
            }
        }


#endif
        private static void DebugOut(object sender, EventArgs e) => DebugOut("Output Test");

        public static void DebugOut(object obj) {
#if DEBUG
            //return; // Rest Of This Freezes The PS4DebugPage After The Output Overhaul And Isn't Used Anyway

            string s = obj.ToString();
            
            if(s.Contains("\n"))
                s = s.Replace("\n", "\n ");

        Wait:
            if(OutputStrings == null) goto Wait; // Try And Avoid Rare Crash On Boot In Dev Build When The App Doesn't Boot Fast Enough
            if(OutputStringIndex != OutputStrings.Length - 1) {
                for(; OutputStringIndex < OutputStrings.Length - 1; OutputStringIndex++) {
                    if(OutputStrings[OutputStringIndex] == null) {
                        OutputStrings[OutputStringIndex] = s;
                        break;
                    }
                }
                return;
            }
            for(ShiftIndex = 0; ShiftIndex < OutputStrings.Length - 1; ShiftIndex++)
                OutputStrings[ShiftIndex] = OutputStrings[ShiftIndex + 1];
            OutputStrings[ShiftIndex] = s;
#endif
        }
#if DEBUG

        public static void DebugFunctionCall() {
            DebugConnect();
            DebugOut(geo.Call(Executable, geo.InstallRPC(Executable), 0x52e060, new object[] { 0x105f83d240, 4 })); // 0x105f83d240
        }
        public static byte DebugConnect() {
            try {
                geo = new PS4DBG(PS4DebugPage.IP());
                geo.Connect();
                foreach(libdebug.Process prc in geo.GetProcessList().processes) {
                    foreach(string id in ExecutablesNames) {
                        if(prc.name == id) {
                            string title = geo.GetProcessInfo(prc.pid).titleid;
                            if(title == "FLTZ00003" || title == "ITEM00003") {
                                DebugOut($"Skipping Lightning's Stuff {title}");
                                break;
                            } // Code To Avoid Connecting To HB Store Stuff

                            Executable = prc.pid;
                            ProcessName = prc.name;
                            TitleID = geo.GetProcessInfo(prc.pid).titleid;
                            PS4DebugIsConnected = true;
                        }
                    }
                }
                GameVersion = PS4DebugPage.GetGameVersion();
                return 0;
            }
            catch(Exception tabarnack) {
                MessageBox.Show(tabarnack.Message);
                return 1;
            }
        }

#endif
    }
}
