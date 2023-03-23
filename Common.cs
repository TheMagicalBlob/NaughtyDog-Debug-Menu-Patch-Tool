using Dobby.Properties;
using libdebug;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static Dobby.Common.Dev;

namespace Dobby {
    public class Common : Dobby {


        /* Old Changelist
         *
         */

        public static string[] ChangeList = new string[] {
            "* ------------",
            "* |ChangeList|",
            "* ------------",
            "* 2.3.12     | Added PS4Debug 1.1.15 Payload & Edited Credits Page",
            "* 2.3.13     | Added UC4 MP Button (PS4Debug) Addatives",
            "* 2.3.14     | Misc. Option Positioning Adjustment",
            "* 2.3.18     | Localized A Few Functions In Credits.cs",
            "* 2.3.20     | Localized A Few Functions In InfoHelpPage.cs",
            "* 2.4.20     | Reworking UC4 Restored Debug - Improved Rendering Menu",
            "* 2.4.21     | Added Menu Error SP Boot Skip To UC4 1.33 MP Debug",
            "* 2.5.21     | Significant Tweaks To EbootPatchPage.cs To Be More User Friendly",
            "* 2.6.22     | Added T2 Check, Misc Tweaks",
            "* 2.6.23     | Added A Toggle() Alternative That Doesn't Try To Connect, In Order To Avoid Taking Twice As Long To Fail When An Invalid IP Is Given",
            "* 2.7.24     | Added Full Gameplay Menu To Uncharted 4 1.33 MP Debug",
            "* 2.7.25     | Added GBuffer Option Skip For Uncharted 4 1.33 MP Debug",
            "* 2.7.27     | Added Post-Processing Part 1 & 2 For Uncharted 4 1.33 MP Debug",
            "* 2.7.28     | Added Lighting Menu Chunk 1",
            "* 2.7.29     | Chunk 2",
            "* 2.8.30     | Added Overload For HoverLeave() To Lower Font Scale & Redid The Credits Page Again",
            "* 2.9.31     | Added PS4Debug Info Page - Added LastForm Info String To BackBtnMH In Dev Mode",
            "* 2.9.32     | PS4DebugInfo Page Edits",
            "* 2.9.0.33   | Start Of New Versioning - Added HoverLeave Params To PS4DebugHelpPage Init Button",
            "* 2.9.0.34   | Improved Root InfoHelpPage",
            "* 2.9.1.34   | Added ChangeListDisplay",
            "* 2.9.1.35   | ChangeListDisplay Tweaks",
            "* 2.9.2.36   | Added Inf() Overload For Important Strings, Fixed Info String Output With Connect(). Deleted Some Redundant BS",
            "* 2.10.4.39  | Removed Requirement For Info Param From Inf() & HoverLeave() -  - Various Changes To Root InfoHelpPage",
            "* 2.10.5.39  | Creation Of SetPageInfo(this) - Application Still In Progress",
            "* 2.10.7.39  | SetPageInfo(this) Application - BackBtn Function Edits",
            "* 2.10.7.40  | Added Particles... Menu To UC4 1.33 MP Debug",
            "* 2.10.7.41  | Added Game Objects..., The Full Levels... Menu, Spawn Character..., And Spawn Vehicles...",
            "* 2.10.8.41  | Removed Need For Redundant Build String",
            "* 2.10.8.42  | Added Camera... Menu To UC4 1.33 MP Debug",
        "* 2.10.8-tmp.43  | Prepping To Change The Way Remembering Pages Works, Added Build Label Hover Params",
            "* 2.10.9.43  | Removed Pointless Width / Height Params From The Main HoverLeave Function And It's Overloads Since Just Adding/Removing 9 In The Function Works Perfectly",
            "* 2.10.10.43 | Adding Eboot Patch Info Page",
            "* 2.10.11.44 | Added Navigtion... Menu And Fixed Some Previous Offsets I Added Incorrectly",
            "* 2.10.17.44 | Added Multiple Submenus (UC4 1.33 MP)",
            "* 2.10.17.45 | Hid Changelist For Release Mode",
            "* 2.10.20.45 | Added Multiple Submenus (UC4 1.33 MP)",
            "* 2.10.20.46 | Commented Out A Submenu For UC4, Uncommented Another (Memory Reasons... The PS4's Memory, I Mean)",
            "* 2.10.21.46 | Added Some Info To EbootPatchHelpPage Before Work",
        "* 2.11-tmp.21.46 | EbootPatchInformationPage Work - Disabled For Release (As If I Ever Release Anything...)",
        "* 2.11-tmp.21.47 | EbootPatchInformationPage Tweaked A Couple Lines",
       "* 2.11-beta.22.48 | EbootPatchInformationPage Added Info, Font Change For Readability",
            "* 2.12.22.49 | deleted old debug output shit, and removed the pointless integer paramater, re-doing debugger style/type, half finished- sort-of borked, adding custom TextBox popup",
            "* 2.12.23.50 | Misc Changes I Can't Recall",
            "* 2.13.25.51 | Replaced StackOverflow Code Used To Move The Borderless Form With My Own, Debugger Tweaks",
            "* 2.13.26.55 | Swapped Out FormMove Func On More Forms, Credits Page Spacing And Text Tweak, Moved The CreditsBtn Function For The Main Page And Tweaked Button Positioning, Other",
            "* 2.14.27.57 | Resized All Forms To Simplify Message Box Creation, Message Box Changes (Almost Done...), Other Things I Forget But Know I Did Because I Updated The Build # After Doing 'Em...",
            "* 2.15.27.57 | Moved The Page Title To The Top Of The Page Now That I Can Use Controls As Drag Anchors Instead Of Only The Form",
            "* 2.17.28.66 | UC4 1.3X MP Restored Debug Finally Finished, Only Need To Add Alternative With The Skipped Stuff, Plus Illusions's Stuff | Added Function Pointers For Form Move Functions To CSTMDebugPage | Repositioned The Page Titles",
            "* 2.17.28.66 | Changed Configuration To Release For Github Release",
            "* 2.17.29.69 | Minor EbootPatchPage Code Changes, Other Misc. Stuff",
            "* 2.17.30.69 | Uncharted 2 1.00 Restored Debug Work",
            "* 2.17.31.69 | Uncharted 2 1.00 Restored Debug Work Near-Final",
            "* 2.17.32.75 | Moving Debug Restoration Code To Seperate Functions Outside Of Switch Case Because Reasons, Other Misc. Changes",
        "* 2.18-tmp.33.75 | Reworking EbootPatchPage To Better Show Which Patch Types Are Available For The Intended Executable, Start Of Visual Rework (EbootPatchPage Only So Far)",
        "* 2.18-tmp.35.77 | Further EbootPatchPage Additions, Deleted Various Pointless bits of code, other Misc. UI changes.",
        "* 2.18-tmp.36.78 | Added Rendering Menu Patch For T1R 1.00, Misc.",
            "* 2.18.38.80 | Added T1R 1.11 Restored Menu, Other Misc Changes",
            "* 2.19.39.82 | Upated PS4DebugPage Look, Other Various Changes (I'm Tired Go Away)",
            "* 2.19.42.86 | Added Border To The Rest of The Pages",
            "* 2.19.42.87 | Minor Patch",
            "* 2.19.42.91 | Minor Exec Patch Functions Optimizations",
            "* 2.19.42.92 | Fixed Main Page Seperator Lines",
            "* 2.19.44.92 | Added Form Move Event Handlers To InfoHelpPage Credits Page",
            "* 2.19.44.94 | Fixed Discord Contact on Info/Help Page, Misc Move Form Tweaks",
            "* 2.19.45.94 | Simple Flashing Label Implementation For EbootPatchPage",
           "* 2.19.46.100 | More Flashing Label Edits And A Bunch Of Tiny Changes I Can't Recall",
           "* 2.19.48.102 | UC3 1.00 Restored Debug Additions, Plus It Actually Works Now..., Removed Tag From Debug Output, Changed MakeTextBox BG Colour Back To Black",
           "* 2.19.49.103 | Debug Output Additions, Added Scrolling Array Of Output Strings Rather Than Only Showing The Last One. Label Flash Exceptions Catch",
           "* 2.19.49.105 | Removed Test Code, Increased Output String Array Length",
           "* 2.19.49.107 | Debug Output Improvements; Debug Window Resizing Support",
           "* 2.19.49.108 | Removed Test Code Again...",
           "* 2.19.50.109 | GameInfoLabel Base Implementation, Check For Signed Executables",
           "* 2.19.52.112 | EbootPatchHelpPage Progress, Creation Of Local Function To Reduce Bloat When Checking If An Executable Is Debug Enabled Or Not, Debug Output And Other Misc Tweaks",
           "* 2.19.53.113 | Added A Couple Lines To Reset The EbootPatchHelpPage Question Array For Proper Functionality, Debug Output Tweak",
           "* 2.19.54.115 | More Debug Output Alterations, Other Misc Changes (That Means I Forgot What I've Done...)",
           "* 2.19.54.118 | Fixed An Issue With The Yellow Label Not Upating"

            // TODO:
            // - Fix Messy Back Button Implementation
            // - Finish EbootPatchHelpPage
            // - Finish EbootPatchPage GameInfoLabel Functionality
            
            // KNOWN BUGS:
            // - Occasional String Duplication In Debug Output (DebugOutputStr / UpdateConsoleOutput)

        };
        public static string Build = ChangeList[ChangeList.Length - 1].Substring(2).Substring(0, ChangeList[ChangeList.Length - 1].IndexOf('|') - 3); // Trims The Last ChangeList String For Latest The Build Number
        public static string CurrentControl, tmp;

        public static byte
            MouseScrolled,
            MouseIsDown
        ;

        public static Control YellowInformationLabel;

        public static int game;

        public static Point LastPos;
        public static Form LastForm;
        public static Form MainForm;
        public static Form PopupBox;

        public static Form[] Pages;

        public static bool LastDebugOutputWasInfoString = false, LabelShouldFlash = false, FlashThreadHasStarted = false;

        public static Font MainFont = new Font("Franklin Gothic Medium", 6.5F, System.Drawing.FontStyle.Bold);
        public static void SetPageInfo(Form f) {
            f.Location = LastPos; Page = f.Name;
            YellowInformationLabel = f.Controls.Find("Info", true)[0];
        }

        public static void MakeTextBox(string Text) { //!
            if (PopupBox != null) {
                PopupBox.Close();
                return;
            }

            PopupBox = new Form();
            Label Label = new Label();
            Label.ForeColor = PopupBox.ForeColor = Color.White;
            Label.BackColor = Color.Gray;
            PopupBox.BackColor = Color.Gray;
            PopupBox.Controls.Add(Label);
            Label.Font = MainFont;
            Label.TextAlign = ContentAlignment.MiddleCenter;
            switch (ActiveForm.Name) { // Center Based On Active Form
                default:
                    Dev.DebugOutStr("Page Unknown, Default Location Used");
                    PopupBox.Location = new Point(100, 300);
                    return;
                case "EbootPatchHelpPage":
                    PopupBox.Location = new Point(100, 300);
                    break;
            }
            PopupBox.Size = new Size(200, 110);
            Label.Location = new Point(1, 1);
            Label.Size = new Size(PopupBox.Size.Width - 2 , PopupBox.Size.Height - 3);
            Label.Text = Text;
            PopupBox.Name = "PopupBox";
            PopupBox.FormBorderStyle = FormBorderStyle.None;
            PopupBox.Show();
        }
        public static void Inf(string s) => YellowInformationLabel.Text = s;
        public static string BlankSpace(string String) {
            if (String == null) return "";
            string Blanks = string.Empty;
            for (int i = Console.BufferWidth - String.Length; i > 0; i--)
                Blanks += " ";
            String += Blanks;
            return String;
        }
        public static void HoverLeave(Control c, byte HoverOrLeave) { //! Fix Readability
            YellowInformationLabel.Font = new Font("Franklin Gothic Medium", 10F); // Reset Font Size To Default
            CurrentControl = c.Name;
            c.ForeColor = HoverOrLeave == 0 ? Color.FromArgb(255, 227, 0) : Color.FromArgb(255, 255, 255);
            c.Text = HoverOrLeave == 0 ? $">{c.Text}" : c.Text.Substring(c.Text.IndexOf('>') + 1);
            c.Size = new Size(HoverOrLeave == 0 ? c.Width + 9 : c.Width - 9, c.Height);
            if (!InfoHasImportantStr) Inf("");
            if (HoverOrLeave == 1) MouseScrolled = 0;
        }

        public static void HoverString(Control c, string InfoString) { //! Fix Readability
            CurrentControl = c.Name;
            c.ForeColor = Color.FromArgb(255, 227, 0);
            c.Text = $">{c.Text}";
            Inf(InfoString);
            c.Size = new Size(c.Width + 9, c.Size.Height);
            InfoHasImportantStr = false;
        }
        public static void HoverStringAlt(Control Info, Control c, string info, float FontScale) { //! Fix Readability
            CurrentControl = c.Name;
            Info.Font = new Font("Franklin Gothic Medium", FontScale); // Decrease Font Size To Fit String In Info Bar
            c.ForeColor = Color.FromArgb(255, 227, 0);
            c.Text = $">{c.Text}";
            Inf(info);
            c.Size = new Size(c.Width + 9, c.Height);
            InfoHasImportantStr = false;
        }
        public static void PageInfo(Control.ControlCollection cunts) { // Might use it again so it stays
            //if (Dev.REL)
                return;
            
            DebugOutStr("-------------------------------------------------------------------");
            int id = 1;
            foreach (Control C in cunts) {
                DebugOutStr($"Control #{id} - {C.Name} | Text = [{C.Text}]\nVisible = {C.Visible} | Enabled = {C.Enabled}\n");
                id++;
            }
            DebugOutStr($"Page: {Page}\n");
            DebugOutStr("-------------------------------------------------------------------");
        }


        public static new void MouseDownFunc(object sender, MouseEventArgs e) {
            MouseIsDown = 1; LastPos = ActiveForm.Location;
            MouseDif = new Point(MousePosition.X - ActiveForm.Location.X, MousePosition.Y - ActiveForm.Location.Y);
        }
        public static new void MouseUpFunc(object sender, MouseEventArgs e) {
            MouseScrolled = MouseIsDown = 0;
        }

        public static new void MoveForm(object sender, MouseEventArgs e) {
            if (MouseIsDown != 0) {
                ActiveForm.Location = new Point(MousePosition.X - MouseDif.X, MousePosition.Y - MouseDif.Y);
                ActiveForm.Update();
            }
        }

        public class Dev {

            public const bool REL = false
                                        ;

            static int TimerTicks = 0, OutputStringIndex = 0;


            delegate void LabelFlashDelegate();
            static LabelFlashDelegate Yellow = new LabelFlashDelegate(FlashYellow);
            static LabelFlashDelegate White = new LabelFlashDelegate(FlashWhite);
            public static Thread FlashThread = new Thread(new ThreadStart(FlashLabel));

            static void FlashLabel() {
                while (!LabelShouldFlash) { Thread.Sleep(7); }
                try {
                    for (int Flashes = 0; Flashes < 8; Flashes++) {
                        while (ActiveForm == null) { } // Just Chill Here 'Till The Form Gets Focus Again
                        ActiveForm.Invoke(White);
                        Thread.Sleep(135);
                        while (ActiveForm == null) { }
                        ActiveForm.Invoke(Yellow);
                        Thread.Sleep(135);
                    }
                }
                catch (Exception) {
                    DebugOutStr("Killing Label Flash");
                }
                LabelShouldFlash = false;
                FlashLabel();
            }
            static void FlashWhite() {
                try {
                    ActiveForm.Controls.Find("GameInfoLabel", true)[0].ForeColor = Color.White;
                    ActiveForm.Refresh();
                }
                catch (Exception) {
                    DebugOutStr("Killing Label Flash WH");
                }
            }
            static void FlashYellow() {
                try {
                    ActiveForm.Controls.Find("GameInfoLabel", true)[0].ForeColor = Color.FromArgb(255, 227, 0);
                    ActiveForm.Refresh();
                }
                catch (Exception) {
                    DebugOutStr("Killing Label Flash YL");
                }
            }


            public delegate void TimerDelegate();
            public static TimerDelegate TimerThread = new TimerDelegate(StartTimer);
            static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

            private static void Timer_Tick(object sender, EventArgs e) => TimerTicks++;
            static void StartTimer() {
                if (ActiveForm != null) ActiveForm.Location = new Point(10, 10);
                if (!timer.Enabled) {
                    timer.Interval = 1;
                    timer.Tick += Timer_Tick;
                    timer.Start();
                }
            }


            public static Thread InputThread = new Thread(new ThreadStart(ReadInput));
            public static void ReadCurrentKey() => InputThread.Start();
            static void ReadInput() {
                while (true) {
                    switch (Console.ReadKey(true).Key) {
                        case ConsoleKey.R:
                            Console.Clear();
                            break;
                        case ConsoleKey.C:
                            OutputStrings = new string[OutputStrings.Length];
                            OutputStringIndex = 0;
                            Console.Clear(); Thread.Sleep(42); Console.Clear(); // First Clear Doesn't Get It All
                            break;
                    }                        
                }
            }

            public static string[] OutputStrings = new string[Console.WindowHeight - 13];


            public static Thread DebuggerThread = new Thread(new ThreadStart(UpdateConsoleOutput));
            public static void DebuggerInfo() => DebuggerThread.Start();
            public static void UpdateConsoleOutput() { if (REL) return;
                bool TimerThreadStarted = false;
                int Interval = 0;

Begin_Again:    // IN THE NIIIIIIGGGHHHTTT, LET'S    SWAAAAAAYYYY AGAIIN, TONIIIIIIGHT
                Console.CursorVisible = false;
                Point OriginalConsoleScale = new Point(Console.WindowHeight, Console.WindowWidth);
                while (OriginalConsoleScale == new Point(Console.WindowHeight, Console.WindowWidth)) {
                    int StartTime = TimerTicks;
                    Form frm = ActiveForm;
                    Console.CursorTop = 0; Console.Write(BlankSpace($"Build: {Build} | ~{Interval}ms"));
                    Console.CursorTop = 2; Console.Write(BlankSpace($"MouseIsDown: {MouseIsDown} | MouseScrolled: {MouseScrolled}"));
                    Console.CursorTop = 4; Console.Write(BlankSpace($"Page: {Page} | InfoHasImportantString: {InfoHasImportantStr}"));
                    Console.CursorTop = 5; Console.Write(BlankSpace($"Form: {(ActiveForm != null ? ActiveForm.Name : "Console")}"));
                    Console.CursorTop = 7; Console.Write(BlankSpace($"MousePos: {MousePosition}"));
                    Console.CursorTop = 12; foreach (string msg in OutputStrings)
                    Console.Write(BlankSpace(msg), Console.CursorTop = Console.CursorTop++);

                    Interval = TimerTicks - StartTime;

                    if (frm != null && !TimerThreadStarted) { frm.Invoke(TimerThread); TimerThreadStarted = true; }
                }
                Console.Clear();
                goto Begin_Again;
            }
            public static void DebugOutStr(string s) { if (REL) return;
                if (s.Contains("\n")) { // Line Breaks Fuck The Console Up lol
                    s = s.Replace("\n", "");
                    s += " (Use Seperate Calls For New Line!!!)";
                }

                if (OutputStringIndex != OutputStrings.Length - 1) {
                    for (;OutputStringIndex < OutputStrings.Length - 1; OutputStringIndex++) {
                        if (OutputStrings[OutputStringIndex] == null) {
                            OutputStrings[OutputStringIndex] = s;
                            break;
                        }
                    }
                    return;
                }
                int ShiftIndex = 0;
                for (; ShiftIndex < OutputStrings.Length - 1; ShiftIndex++)
                    OutputStrings[ShiftIndex] = OutputStrings[ShiftIndex + 1];
                OutputStrings[ShiftIndex] = s;
            }
        }
    }
}
