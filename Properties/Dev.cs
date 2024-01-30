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


        public static string[] OutputStrings;
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
                string[] Output, chk = Array.Empty<string>();
                string Bool(object In) { return (bool)In == true ? "Enabled" : "Disabled"; }

                Pen pen = new Pen(Color.White);

                while(true) {
                    try {
                        float StartTime = TimerTicks;

                        string ControlType = HoveredControl?.GetType().ToString();
                        Out = string.Empty;

                        if (OverrideDebugOut)
                        Output = new string[] {
                                $"| Disable FPS:          {Bool(PS4MenuSettingsPage.UniversalDebugBooleans[0])}",
                                $"| Paused Icon:          {Bool(PS4MenuSettingsPage.UniversalDebugBooleans[1])}",
                                $"| ProgPauseOnOpen:      {Bool(PS4MenuSettingsPage.UniversalDebugBooleans[2])}",
                                $"| ProgPauseOnExit:      {Bool(PS4MenuSettingsPage.UniversalDebugBooleans[3])}",
                                 "| ",
                                $"| Menu Scale:           {PS4MenuSettingsPage.GameSpecificPatchValues[0]}",
                                $"| Menu Alpha:           {PS4MenuSettingsPage.GameSpecificPatchValues[1]}",
                                $"| Non-ADS FOV:          {PS4MenuSettingsPage.GameSpecificPatchValues[2]}",
                                $"| Swap Square & Circle: {Bool(PS4MenuSettingsPage.GameSpecificPatchValues[3])}",
                                $"| Shadowed Text:        {Bool(PS4MenuSettingsPage.GameSpecificPatchValues[4])}",
                                $"| Version Text:         {Bool(PS4MenuSettingsPage.GameSpecificPatchValues[5])}",
                                $"| Right Align:          {Bool(PS4MenuSettingsPage.GameSpecificPatchValues[6])}",
                                $"|    Right Margin:      {PS4MenuSettingsPage.GameSpecificPatchValues[7]}",
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
                            (PCDebugMenuPage.MainStreamIsOpen || EbootPatchPage.MainStreamIsOpen ? " " : null),
                            $"{(EbootPatchPage.MainStreamIsOpen ? $"PS4Stream: {EbootPatchPage.MainStream.Name}" : (PCDebugMenuPage.MainStreamIsOpen ? " " : null))}",
                            $"{(EbootPatchPage.MainStreamIsOpen ? $"Length: {(EbootPatchPage.MainStream.Length.ToString().Length > 6 ? $"{EbootPatchPage.MainStream.Length.ToString().Remove(2)}MB" : $"{EbootPatchPage.MainStream.Length} bytes")} | Read: {EbootPatchPage.MainStream.CanRead} | Write: {EbootPatchPage.MainStream.CanWrite}" : (PCDebugMenuPage.MainStreamIsOpen ? " " : null))}",
                            (PCDebugMenuPage.MainStreamIsOpen ? " " : null),
                            $"{(PCDebugMenuPage.MainStreamIsOpen ? $"PCStream: {PCDebugMenuPage.MainStream.Name}" : null)}",
                            $"{(PCDebugMenuPage.MainStreamIsOpen ? $"Length: {(PCDebugMenuPage.MainStream.Length.ToString().Length > 6 ? $"{PCDebugMenuPage.MainStream.Length.ToString().Remove(2)}MB" : $"{PCDebugMenuPage.MainStream.Length} bytes")} | Read: {PCDebugMenuPage.MainStream.CanRead} | Write: {PCDebugMenuPage.MainStream.CanWrite}" : null)}",
                        };

                        if(!chk.SequenceEqual(Output)) {
                            chk = Output;
                            SizeF TextSize;
                            formScale = Size.Empty;


                            foreach(string line in Output) {
                                TextSize = rend.MeasureString(line, MainFont);

                                if(TextSize.Width > formScale.Width - 12)
                                    formScale.Width = (int)TextSize.Width + 12;
                                formScale.Height += (int)TextSize.Height;

                                Out = string.Join("\n", Output);
                            }
                            formScale.Height += 12;

                            try {
                                AppRef.Invoke(resize);
                            }
                            catch(InvalidOperationException) { }

                            Point[] Border = new Point[] {
                                    Point.Empty,
                                    new Point(AppRef.Width-1, 0),
                                    new Point(AppRef.Width-1, AppRef.Height-1),
                                    new Point(0, AppRef.Height-1),
                                    Point.Empty
                            };

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
        public static void DebugOut(object obj) {
#if DEBUG


            return; // Rest Of This Freezes The PS4DebugPage After The Output Overhaul And Isn't Used Anyway

            if(OverrideDebugOut) return; string s = obj.ToString();
            if(s.Contains("\n")) {
                s = s.Replace("\n", "");
                s += " (Use Seperate Calls For New Line!!!)";
            }

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
