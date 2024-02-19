﻿using libdebug;
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

#else
        public const bool REL = false;

        /// <summary> Dev Label Event Handler Function </summary>
        public static void MiscDebugFunc(object sender, EventArgs e) {
            LogWindow.SewerSlide();
        }

        public static void OpenLog(object _ = null, EventArgs __ = null) {

            if(MessageBox.Show("Open Log?", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            System.Diagnostics.Process.Start($"{Directory.GetCurrentDirectory()}\\out.txt");
            LogWindow.SewerSlide();
            Environment.Exit(0);
        }

        public static void StartReadLogTest() => ReadTest.Start();

        private static Thread ReadTest = new Thread(new ThreadStart(rTst));

        private static void rTst() {
            string[] chk = Array.Empty<string>(), lines;

        start:
            while(!File.Exists(@"C:\Users\Blob\Desktop\out.txt"));

            lines = File.ReadAllLines(@"C:\Users\Blob\Desktop\out.txt");
            if (chk.Equals(Array.Empty<string>()) || lines.SequenceEqual(chk))

            foreach(var line in lines)
                    Dev.MsgOut(line);

            chk = lines;
            goto start;
        }

        public static void DebugControlHover(object sender, EventArgs e) => HoveredControl = (Control)sender;

        public static bool OverrideMsgOut;

        private static int OutputStringIndex = 0;

        private static float TimerTicks = 0;


        public static string[] OutputStrings = new string[35];

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

            if((int)toggle != 0)
                control.Update();
        }


        /// <summary>
        /// Log Window Class
        /// </summary>
        public partial class LogWindow : Form {
            public LogWindow(Form Gaia) {

                // LogWindow Form And Control Initializations
                BackColor = Gaia.BackColor;
                FormBorderStyle = FormBorderStyle.None;
                Name = "LogWindow";
                Button DebugLabel = new Button {
                    TabIndex = 0,
                    ForeColor = SystemColors.Control,
                    Font = new Font("Cambria", 7F, FontStyle.Bold),
                    Text = "(Dev)",
                    Name = "!!!"
                };
                DebugLabel.Size = FitControlText(DebugLabel);
                DebugLabel.FlatStyle = FlatStyle.Flat;
                DebugLabel.FlatAppearance.BorderSize = 0;
                DebugLabel.Click += new EventHandler(MiscDebugFunc);
                DebugLabel.BringToFront();

                Button OpenLogFileAndQuit = new Button {
                    TabIndex = 1,
                    ForeColor = SystemColors.Control,
                    Font = new Font("Cambria", 7F, FontStyle.Bold),
                    Text = "LogTxt",
                    Name = "!!!"
                };
                OpenLogFileAndQuit.Size = FitControlText(OpenLogFileAndQuit);
                OpenLogFileAndQuit.Click += new EventHandler(OpenLog);
                OpenLogFileAndQuit.FlatStyle = FlatStyle.Flat;
                OpenLogFileAndQuit.FlatAppearance.BorderSize = 0;
                OpenLogFileAndQuit.BringToFront();
                Controls.Add(DebugLabel);
                Controls.Add(OpenLogFileAndQuit);
                //\\

                // LogWindow Event Handlers
                MouseEnter += DebugControlHover;
                MouseDown  += MouseDownFunc;
                MouseUp    += MouseUpFunc;
                //\\

                LogWindowRenderer = this.CreateGraphics();
                LogWindowPtr = this;
                SetParent(Gaia);

                LogFile = File.CreateText($"{Directory.GetCurrentDirectory()}\\out.txt");
                logThread.Start();
            }

            private static Form LogWindowPtr, ParentFormPtr;
            public static Size formScale;

            private static Graphics LogWindowRenderer;

            private static StreamWriter LogFile;
            public static string[] LogBuffer;

            #region timer crap
            private static float Delay = 0;
            private static bool TimerThreadStarted = false;
            public static bool LogShouldRefresh;
            private static readonly System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            private static readonly Thread TimerThread = new Thread(StartTimer);
            private static void Timer_Tick(object sender, EventArgs e) => TimerTicks+= 0.001f;
            private static void StartTimer() {
                if(!timer.Enabled) {
                    timer.Interval = 1;
                    timer.Tick += Timer_Tick;
                    timer.Start();
                }
            }
            #endregion

            // Sets The Form To Attach The Log Window To
            public static void SetParent(Form Gaia) {
                
                ParentFormPtr = Gaia;
                Gaia.LocationChanged -= MoveLogToAppEdge;
            }
            private void MouseDownFunc(object sender, MouseEventArgs e) => MouseIsDown = true;
            private void MouseUpFunc(object sender, MouseEventArgs e) => MouseScrolled = MouseIsDown = false;
            public static void MoveLogToAppEdge(object mommy, EventArgs e) => LogWindowPtr.Location = new Point(((Form)mommy).Location.X - LogWindowPtr.Size.Width, ((Form)mommy).Location.Y);
            public static void MoveLogToAppEdge(Point Loc) => LogWindowPtr.Location = new Point(Loc.X - LogWindowPtr.Size.Width, Loc.Y);


            public delegate void Scaling();
            public static Scaling resize = new Scaling(ResizeLog);
            private static void ResizeLog() {
                LogWindowPtr.Size = formScale;
                LogWindowRenderer = LogWindowPtr.CreateGraphics();

                LogWindowPtr.Location = new Point(ParentFormPtr.Location.X - LogWindowPtr.Size.Width, ParentFormPtr.Location.Y);
                LogWindowPtr.Update();

                var ControlOffset = 0;
                foreach(Control c in LogWindowPtr.Controls) {
                    c.Location = new Point(LogWindowPtr.Size.Width - c.Size.Width - ControlOffset - 1, 1);
                    ControlOffset += c.Size.Width;
                }
            }

            public static void SewerSlide() {
                logThread.Abort();
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
                        float StartTime = TimerTicks;

                        string ControlType = HoveredControl?.GetType().ToString();
                        Out = string.Empty;

                        var DynamicVars = PS4MenuSettingsPage.PeekGameSpecificPatchValues();

                        try {
                            if(OverrideMsgOut)
                                Output = new string[] {
                                    $"| Game Index: {PS4MenuSettingsPage.GameIndex}",
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
                            else
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

                                    (MainStreamIsOpen ? " " : ""),

                                    $"{(MainStreamIsOpen ? $"PS4Stream: {MainStream.Name}" : (PCDebugMenuPage.MainStreamIsOpen ? " " : ""))}",
                                    $"{(MainStreamIsOpen ? $"Length: {(MainStream.Length.ToString().Length > 6 ? $"{MainStream.Length.ToString().Remove(2)}MB" : $"{MainStream.Length} bytes")} | Read: {MainStream.CanRead} | Write: {MainStream.CanWrite}" : (PCDebugMenuPage.MainStreamIsOpen ? " " : ""))}",
                                };
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

                                if(TextSize.Width > formScale.Width - 12)
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


                            // Resize Form Back On Main LogWindow Thread
                            try { LogWindowPtr.Invoke(resize); }

                            catch(InvalidOperationException) { MessageBox.Show("Resize Error Noti"); }


                            // Border Setup
                            Point[] Border = new Point[] {
                                    Point.Empty,
                                    new Point(LogWindowPtr.Width-1, 0),
                                    new Point(LogWindowPtr.Width-1, LogWindowPtr.Height-1),
                                    new Point(0, LogWindowPtr.Height-1),
                                    Point.Empty
                            };

                            // Clear Last "Frame", Draw Text And Border
                            LogWindowRenderer.Clear(Color.FromArgb(100, 100, 100));
                            LogWindowRenderer.DrawLine(pen, 0f, 30f, (float)LogWindowPtr.Width, 30f);
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

        public static void MsgOut(object obj = null) {
#if DEBUG
            string str;

            if(obj == null) str = " ";

            else str = obj.ToString();
            
            if(str.Contains("\n"))
                str = str.Replace("\n", "\n "); // So It Still Has A Size (for log window scaling purposes)

            LogWindow.LogOut(str);
#endif
        }
    }
}
/*
#region BootSettingsPointers
///////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///-- QUALITY OF LIFE/BOOTSETTINGS OFFSET POINTERS  --\\\
///////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


// 32-Bit Ones Are Pointers To Data In Executable Space 
// Chunky Fucks Are a 32-bit Pointer to A 64-bit Pointer + an offset to add


/// <summary> Byte arrays to be used as pointers with the BootSettings custom function </summary>
public static readonly byte[]
    UC1100DisableFPS = new byte[] { 0x70, 0x89, 0x99, 0x00 }, // fill null bytes just in case of repeat uses with alternate options
    UC1102DisableFPS = new byte[] { 0xF0, 0xC9, 0x95, 0x00 }, // 
    UC2100DisableFPS = new byte[] { 0x31, 0x14, 0xE7, 0x00 }, // 
    UC2102DisableFPS = new byte[] { 0x61, 0xDE, 0x05, 0x01 }, // 
    UC3100DisableFPS = new byte[] { 0xC9, 0x66, 0x43, 0x01 }, // 
    UC3102DisableFPS = new byte[] { 0x69, 0xAF, 0x7B, 0x01 }, // 
    UC4100DisableFPS = new byte[] { }, // 
    UC4133DisableFPS = new byte[] { }, // 
  UC4133MPDisableFPS = new byte[] { }, // 
    TLL100DisableFPS = new byte[] { }, // 
    TLL107DisableFPS = new byte[] { }, // 
    TLL108DisableFPS = new byte[] { }, // 
    TLL109DisableFPS = new byte[] { }, // 
    T1R100DisableFPS = new byte[] { }, // 
    T1R109DisableFPS = new byte[] { }, // 
    T1R110DisableFPS = new byte[] { }, // 
    T1R111DisableFPS = new byte[] { }, // 
    T2100DisableFPS  = new byte[] { }, // 
    T2101DisableFPS  = new byte[] { }, // 
    T2102DisableFPS  = new byte[] { }, // 
    T2105DisableFPS  = new byte[] { }, // 
    T2107DisableFPS  = new byte[] { }, // 
    T2108DisableFPS  = new byte[] { 0xff, 0x30, 0xb4, 0x77, 0x03, 0xb8, 0x3a, 0x00, 0x00 }, 
    T2109DisableFPS  = new byte[] { 0xff, 0x30, 0xb4, 0x77, 0x03, 0xb8, 0x3a, 0x00, 0x00 }
;

/// <summary> ProgPauseOnOpen Offsets </summary>
public static readonly byte[]
    UC1100ProgPause = new byte[] { 0x88, 0xF9, 0xA9, 0x00 }, // 0xE9F988
    UC1102ProgPause = new byte[] { 0x88, 0x38, 0xA6, 0x00 }, // 0xE63888
    UC2100ProgPause = new byte[] { 0x78, 0xC7, 0xEB, 0x00 }, // 0x12bc778
    UC2102ProgPause = new byte[] { 0xE0, 0x95, 0x05, 0x01 }, // 0x14595e0
    UC3100ProgPause = new byte[] { 0x30, 0xFA, 0x42, 0x01 }, // 0x182fa30
    UC3102ProgPause = new byte[] { 0x50, 0x4A, 0x7B, 0x01 }, // 0x1bb4a50
    UC4100ProgPause = new byte[] { }, // 
    UC4133ProgPause = new byte[] { }, // 
  UC4133MPProgPause = new byte[] { }, // 
    TLL100ProgPause = new byte[] { }, // 
    TLL107ProgPause = new byte[] { }, // 
    TLL108ProgPause = new byte[] { }, // 
    TLL109ProgPause = new byte[] { }, // 
    T1R100ProgPause = new byte[] { }, // 
    T1R109ProgPause = new byte[] { }, // 
    T1R110ProgPause = new byte[] { }, // 
    T1R111ProgPause = new byte[] { }, // 
    T2100ProgPause  = new byte[] { }, // 
    T2101ProgPause  = new byte[] { }, // 
    T2102ProgPause  = new byte[] { }, // 
    T2105ProgPause  = new byte[] { }, // 
    T2107ProgPause  = new byte[] { 0xB9, 0x67, 0x24, 0x03 }, // 0x36467b9
    T2108ProgPause  = new byte[] { }, // 
    T2109ProgPause  = new byte[] { }  // 
;

/// <summary> ProgPauseOnExitOffsets </summary>
public static readonly byte[]
    UC1100ProgPauseOnExit = new byte[] { 0x8C, 0xF9, 0xA9, 0x00 }, // 0xE9F98C
    UC1102ProgPauseOnExit = new byte[] { 0x89, 0x38, 0xA6, 0x00 }, // 0xE63889 
    UC2100ProgPauseOnExit = new byte[] { 0x79, 0xC7, 0xEB, 0x00 }, // 0x12bc779
    UC2102ProgPauseOnExit = new byte[] { 0xE1, 0x95, 0x05, 0x01 }, // 0x14595e1
    UC3100ProgPauseOnExit = new byte[] { 0x31, 0xFA, 0x42, 0x01 }, // 0x14595e1
    UC3102ProgPauseOnExit = new byte[] { 0x51, 0x4A, 0x7B, 0x01 }, // 0x1bb4a51 USELESS
    UC4100ProgPauseOnExit = new byte[] { }, // 
    UC4133ProgPauseOnExit = new byte[] { }, // 
  UC4133MPProgPauseOnExit = new byte[] { }, // 
    TLL100ProgPauseOnExit = new byte[] { }, // 
    TLL107ProgPauseOnExit = new byte[] { }, // 
    TLL108ProgPauseOnExit = new byte[] { }, // 
    TLL109ProgPauseOnExit = new byte[] { }, // 
    T1R100ProgPauseOnExit = new byte[] { }, // 
    T1R109ProgPauseOnExit = new byte[] { }, // 
    T1R110ProgPauseOnExit = new byte[] { }, // 
    T1R111ProgPauseOnExit = new byte[] { }, // 
    T2100ProgPauseOnExit  = new byte[] { }, // 
    T2101ProgPauseOnExit  = new byte[] { }, // 
    T2102ProgPauseOnExit  = new byte[] { }, // 
    T2105ProgPauseOnExit  = new byte[] { }, // 
    T2107ProgPauseOnExit  = new byte[] { 0xBA, 0x67, 0x24, 0x03 }, // 0x36467ba
    T2108ProgPauseOnExit  = new byte[] { }, // 
    T2109ProgPauseOnExit  = new byte[] { } // 
;

/// <summary> Swap Circle And Square Offsets </summary>
public static readonly byte[]
    UC1100PausedIcon = new byte[] { 0x8A, 0xF9, 0xA9, 0x00 }, // 0xD98970
    UC1102PausedIcon = new byte[] { 0x8A, 0x38, 0xA6, 0x00 }, // 0xE6388A
    UC2100PausedIcon = new byte[] { 0x7A, 0xC7, 0xEB, 0x00 }, // 0x12bc77a
    UC2102PausedIcon = new byte[] { 0xE2, 0x95, 0x05, 0x00 }, // 0x14595e2
    UC3100PausedIcon = new byte[] { 0x32, 0xFA, 0x42, 0x00 }, // 0x182fa32
    UC3102PausedIcon = new byte[] { 0x52, 0x4A, 0x7B, 0x00 }, // 0x1bb4a52
    UC4100PausedIcon = new byte[] { }, // 
    UC4133PausedIcon = new byte[] { }, // 
  UC4133MPPausedIcon = new byte[] { }, // 
    TLL100PausedIcon = new byte[] { }, // 
    TLL107PausedIcon = new byte[] { }, // 
    TLL108PausedIcon = new byte[] { }, // 
    TLL109PausedIcon = new byte[] { }, // 
    T1R100PausedIcon = new byte[] { }, // 
    T1R109PausedIcon = new byte[] { }, // 
    T1R110PausedIcon = new byte[] { }, // 
    T1R111PausedIcon = new byte[] { }, // 
    T2100PausedIcon  = new byte[] { }, // 
    T2101PausedIcon  = new byte[] { }, // 
    T2102PausedIcon  = new byte[] { }, // 
    T2105PausedIcon  = new byte[] { }, // 
    T2107PausedIcon  = new byte[] { }, // 
    T2108PausedIcon  = new byte[] { }, // 
    T2109PausedIcon  = new byte[] { }  // 
;

/// <summary> Swap Circle And Square Offsets </summary>
public static readonly byte[]
    UC4100SwapCircle = new byte[] { }, // 
    UC4133SwapCircle = new byte[] { }, // 
  UC4133MPSwapCircle = new byte[] { }, // 
    TLL100SwapCircle = new byte[] { }, // 
    TLL107SwapCircle = new byte[] { }, // 
    TLL108SwapCircle = new byte[] { }, // 
    TLL109SwapCircle = new byte[] { }, // 
    T1R100SwapCircle = new byte[] { }, // 
    T1R109SwapCircle = new byte[] { }, // 
    T1R110SwapCircle = new byte[] { }, // 
    T1R111SwapCircle = new byte[] { }, // 
    T2100SwapCircle  = new byte[] { }, // 
    T2101SwapCircle  = new byte[] { }, // 
    T2102SwapCircle  = new byte[] { }, // 
    T2105SwapCircle  = new byte[] { }, // 
    T2107SwapCircle  = new byte[] { }, // 
    T2108SwapCircle  = new byte[] { }, // 
    T2109SwapCircle  = new byte[] { }  // 
;

/// <summary> Swap Circle And Square Offsets </summary>
public static readonly byte[]
    UC4100ShadowMenuText = new byte[] { }, // 
    UC4133ShadowMenuText = new byte[] { }, // 
  UC4133MPShadowMenuText = new byte[] { }, // 
    TLL100ShadowMenuText = new byte[] { }, // 
    TLL107ShadowMenuText = new byte[] { }, // 
    TLL108ShadowMenuText = new byte[] { }, // 
    TLL109ShadowMenuText = new byte[] { }, // 
    T1R100ShadowMenuText = new byte[] { }, // 
    T1R109ShadowMenuText = new byte[] { }, // 
    T1R110ShadowMenuText = new byte[] { }, // 
    T1R111ShadowMenuText = new byte[] { }, // 
    T2100ShadowMenuText  = new byte[] { }, // 
    T2101ShadowMenuText  = new byte[] { }, // 
    T2102ShadowMenuText  = new byte[] { }, // 
    T2105ShadowMenuText  = new byte[] { }, // 
    T2107ShadowMenuText  = new byte[] { }, // 
    T2108ShadowMenuText  = new byte[] { }, // 
    T2109ShadowMenuText  = new byte[] { 0xfe, 0x3d, 0xa6, 0x25, 0x03 }  // 
;


/// <summary> Suppress Active Task Display </summary>
public static readonly byte[]
    UC1100HideTaskInfo = new byte[] { 0x41, 0x7B, 0x99, 0x00 }, // 0xD97B41
    UC1102HideTaskInfo = new byte[] { 0x41, 0x7B, 0x99, 0x00 }, // 0xFA7E41
    UC2100HideTaskInfo = new byte[] { 0xC9, 0x05, 0xE7, 0x00 }, // 0x12705C9
    UC2102HideTaskInfo = new byte[] { 0xF9, 0xCF, 0x05, 0x01 }, // 0x145cff9
    UC3100HideTaskInfo = new byte[] { 0x90, 0x1F, 0xA2, 0x01 }, // 0x1e21f90
    UC3102HideTaskInfo = new byte[] { 0x60, 0xEE, 0xB3, 0x01 }, // 0x1f3ee60
    UC4100HideTaskInfo = new byte[] { }, // 
    UC4133HideTaskInfo = new byte[] { }, // 
  UC4133MPHideTaskInfo = new byte[] { }, // 
    TLL100HideTaskInfo = new byte[] { }, // 
    TLL107HideTaskInfo = new byte[] { }, // 
    TLL108HideTaskInfo = new byte[] { }, // 
    TLL109HideTaskInfo = new byte[] { }, // 
    T2100HideTaskInfo  = new byte[] { }, // 
    T2101HideTaskInfo  = new byte[] { }, // 
    T2102HideTaskInfo  = new byte[] { }, // 
    T2105HideTaskInfo  = new byte[] { }, // 
    T2107HideTaskInfo  = new byte[] { }, // 
    T2108HideTaskInfo  = new byte[] { }, // 
    T2109HideTaskInfo  = new byte[] { }  // 
;

/// <summary> Menu Right Align Offsets </summary>
public static readonly byte[]
    UC3100RightAlign = new byte[] { 0x34, 0xFA, 0x42, 0x01 }, // 0x182FA34
    UC3102RightAlign = new byte[] { 0x54, 0x4A, 0x7B, 0x01 }, // 0x1bb4a54
    UC4100RightAlign = new byte[] { }, // 
    UC4133RightAlign = new byte[] { }, // 
  UC4133MPRightAlign = new byte[] { }, // 
    TLL100RightAlign = new byte[] { }, // 
    TLL107RightAlign = new byte[] { }, // 
    TLL108RightAlign = new byte[] { }, // 
    TLL109RightAlign = new byte[] { }, // 
    T1R100RightAlign = new byte[] { }, // 
    T1R109RightAlign = new byte[] { }, // 
    T1R110RightAlign = new byte[] { }, // 
    T1R111RightAlign = new byte[] { }, // 
    T2100RightAlign  = new byte[] { }, // 
    T2101RightAlign  = new byte[] { }, // 
    T2102RightAlign  = new byte[] { }, // 
    T2105RightAlign  = new byte[] { }, // 
    T2107RightAlign  = new byte[] { }, // 
    T2108RightAlign  = new byte[] { }, // 
    T2109RightAlign  = new byte[] { }  // 
;

/// <summary> Right Margin Offsets </summary>
public static readonly byte[]
    UC3100RightMargin = new byte[] { 0x38, 0xFA, 0x42, 0x01 }, // 0x182FA38
    UC3102RightMargin = new byte[] { 0x58, 0x4A, 0x7B, 0x01 }, // 0x1bb4a58
    UC4100RightMargin = new byte[] { }, // 
    UC4133RightMargin = new byte[] { }, // 
  UC4133MPRightMargin = new byte[] { }, // 
    TLL100RightMargin = new byte[] { }, // 
    TLL107RightMargin = new byte[] { }, // 
    TLL108RightMargin = new byte[] { }, // 
    TLL109RightMargin = new byte[] { }, // 
    T1R100RightMargin = new byte[] { }, // 
    T1R109RightMargin = new byte[] { }, // 
    T1R110RightMargin = new byte[] { }, // 
    T1R111RightMargin = new byte[] { }, // 
    T2100RightMargin  = new byte[] { }, // 
    T2101RightMargin  = new byte[] { }, // 
    T2102RightMargin  = new byte[] { }, // 
    T2105RightMargin  = new byte[] { }, // 
    T2107RightMargin  = new byte[] { }, // 
    T2108RightMargin  = new byte[] { }, // 
    T2109RightMargin  = new byte[] { }  // 
;

/// <summary> novis (Disable All Visibility) Offsets, with the memory addresses as comments </summary>
public static readonly byte[]
    UC1100Novis = new byte[] { 0x6B, 0xF9, 0x98, 0x00 }, // 0xd8f96b
    UC1102Novis = new byte[] { 0x9B, 0x59, 0x95, 0x00 }, // 0xD5599B
    UC2100Novis = new byte[] { 0xFB, 0x61, 0xE6, 0x00 }, // 0x12661fb 
    UC2102Novis = new byte[] { 0xCB, 0x0D, 0x05, 0x01 }, // 0x1450dcb
    UC3100Novis = new byte[] { 0x34, 0xFA, 0x42, 0x01 }, // 0x182FA34
    UC3102Novis = new byte[] { 0x8B, 0x80, 0x6E, 0x01 }, // 0x1ae808b
 // UC4100Novis = new byte[] { }, // 
    UC4101Novis = new byte[] { }, // 
    UC4133Novis = new byte[] { }, // 
  UC4133MPNovis = new byte[] { }, // 
    TLL100Novis = new byte[] { }, // 
    TLL107Novis = new byte[] { }, // 
    TLL108Novis = new byte[] { }, // 
    TLL109Novis = new byte[] { }, // 
    T1R100Novis = new byte[] { }, // 
    T1R109Novis = new byte[] { }, // 
    T1R110Novis = new byte[] { }, // 
    T1R111Novis = new byte[] { }, // 
    T2100Novis  = new byte[] { 0x2C, 0x62, 0x01, 0x03 }, // 0x341622c
    T2101Novis  = new byte[] { }, // 
    T2102Novis  = new byte[] { }, // 
    T2105Novis  = new byte[] { }, // 
    T2107Novis  = new byte[] { 0x2C, 0x60, 0x01, 0x03 }, // 0x341602c
    T2108Novis  = new byte[] { 0x2C, 0x9E, 0x04, 0x03 }, // 0x3449e2c
    T2109Novis  = new byte[] { 0x2C, 0x9E, 0x04, 0x03 }  // 0x3449e2c
;
#endregion
*/