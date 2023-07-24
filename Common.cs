using Dobby.Properties;
using libdebug;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;
using static Dobby.Common.Dev;
using System.Runtime.ConstrainedExecution;

namespace Dobby {
    public class Common : Dobby {


        // MajorFeature.Feature.Minor.Patch
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
           "* 2.19.54.118 | Fixed An Issue With The Yellow Label Not Upating",
           "* 2.19.55.120 | Re-enabled EbootPatchHelpPage In Release Mode, Temporarily Redirected MakeTextBox output to default windows text box until I finish centering the custom one, Further Debug Output Changes",
           "* 2.19.55.123 | Replaced Border Background Images On Dobby And EbootPatchPage With A Group Box, For Obvious Reasons, Repositioned The ManualConnectButton, It Was Too Close To The Seperator Line Below",
           "* 2.20.56.127 | Overhauled The Page Change Method; Now Remembers Pages Properly (Made And Forgot The Specifics Of Many Changes During The Same Time), Fixed an issue where the CreditsPage and InfoHelPage's back buttons were ignoring the last form and just loading the main one (my bad)",
           "* 2.20.57.131 | Added The Ability To Right-Click The Links On The Credits Page To View And Copy Them, Removed Highlight From Build Label And Changed It's Info Text, Debug Output Changes",
       "* 2.21-tmp.58.131 | Added Buttons For Still Uncreated PC-Specific Pages, Credits page text and spacing changes",
           "* 2.21.61.140 | Split main form in to seperate PS4 and PC sections, added two pages for the new pc section. Changed contact details line on the InfoHelpPage. Merged Main.Designer.cs with Main.cs, Moved MainStream variable EbootPatchPage.cs -> Common.cs for use with PC Patch Pages",
           "* 2.21.61.142 | Fixed CheckDebugState bug; forgot to go back by one before checking for 0xEB, Added MainStream killswitch to debugger (ctrl k)",
           "* 2.21.62.144 | Added Base Debug To PCPatchPage, Other Misc Changes",
           "* 2.21.63.148 | Fixed Credits page crash caused by deleting unused info label (was still being called on page creation), Added Mouse Hover/Leave Event Handlers To Multiple Neglected Controls, Changed chk On PCPatchPage To Check Bot 0x1EC and 0x1F8 and add them together for the result",
           "* 2.21.65.158 | PCQOLPatchesPAge Work, Changed Hover Info For Multiple Controls, Other Changes I've Made But forgot the specifics of",
           "* 2.21.67.160 | Page Sizing Changes, Clarification MEssages, Additional Debug Info (MainStream)",
           "* 2.21.67.161 | Made PS4 and PC labels larger",
           "* 2.21.67.164 | Added Debug Offsets",
           "* 2.21.67.170 | Added Most offsets, Replaced T1R 1.00 Debug Offset, Added All T2 JNZ Debug Offsets, Seperator Label Border Overlap Fix",
           "* 2.22.67.170 | Overhauled Output Code, Old Method Was Cumbersome To Edit",
           "* 2.22.68.170 | Added Preprocessor Directives To Avoid Compilation of Debug Code",
           "* 2.22.69.171 | Just Realized I Can Cast sender to a control ptr... Overhauled Mouse Hover/Leave Functionality, Merged PC and PS4 arrays",
      "* 3-beta.22.69.163 | Removed Redundant Custom W/ Options Button From Eboot Patch Page, Many, MANY Other Forgotten Changes. Don't code drunk for your changelog's sake...",
      "* 3-beta.24.74.175 | I have no idea anymore",
      "* 3-beta.25.76.177 | I have no idea anymore",
           "* 3.26.77.180 | Arbitrarily Increased Build Number As I've Forgotten Everything I've Done. Changed More Than The Increase Might Imply",
           "* 3.26.77.190 | , Added Uncharted Pointers, Seperated Debug Offsets & Pointers A Bit More"

            // TODO:
            // - Finish EbootPatchHelpPage
            // - Finish EbootPatchPage GameInfoLabel Functionality
            // - Implement New Info Label String Method, Prob A Thread idk
            
            // KNOWN BUGS:
            // - Occasional String Duplication In Debug Output (DebugOutputStr / UpdateConsoleOutput)

        };
        public static string Build = ChangeList[ChangeList.Length - 1].Substring(2).Substring(0, ChangeList[ChangeList.Length - 1].IndexOf('|') - 3); // Trims The Last ChangeList String For Latest The Build Number
        

        #region Application-Wide Functions And Variable Declarations

        public static string CurrentControl, tmp;

        public static int Page;
        public static int?[] Pages = new int?[5];
        public static bool InfoHasImportantStr, LastDebugOutputWasInfoString = false, LabelShouldFlash = false, FlashThreadHasStarted = false;

        public static Point LastPos, MousePos, MouseDif;
        public static Point[] OriginalControlPositions;

        public static Size OriginalFormScale = Size.Empty;
        public static Size OriginalBorderScale;

        public static Form MainForm, PopupBox;
        public static Control YellowInformationLabel;

        public static TcpClient tcp_client;
        public static NetworkStream net_stream;

        public static Font MainFont = new Font("Franklin Gothic Medium", 6.5F, FontStyle.Bold);


        public static void ExitBtn_Click(object sender, EventArgs e) { MainStream?.Dispose(); Environment.Exit(0); }
        public static void ExitBtnMH(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 227, 0);
        public static void ExitBtnML(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);
        public static void MinimizeBtn_Click(object sender, EventArgs e) => ((Control)sender).FindForm().WindowState = FormWindowState.Minimized;
        public static void MinimizeBtnMH(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 227, 0);
        public static void MinimizeBtnML(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);
        public static void ControlHover(object sender, EventArgs e) => HoverLeave((Control)sender, true);
        public static void ControlLeave(object sender, EventArgs e) => HoverLeave((Control)sender, false);
        public static void MouseDownFunc(object sender, MouseEventArgs e) {
            MouseIsDown = 1; LastPos = ActiveForm.Location;
            MouseDif = new Point(MousePosition.X - ActiveForm.Location.X, MousePosition.Y - ActiveForm.Location.Y);
        }
        public static void MouseUpFunc(object sender, MouseEventArgs e) {
            MouseScrolled = MouseIsDown = 0;
        }
        public static void MoveForm(object sender, MouseEventArgs e) {
            if (MouseIsDown != 0) {
                ActiveForm.Location = new Point(MousePosition.X - MouseDif.X, MousePosition.Y - MouseDif.Y);
                ActiveForm.Update();
            }
        }


        public static string UpdateGameInfoLabel() {

            var GameString = "Unknown Game";
            var AddString = "No Debug";

            MainStream.Position = 0;
            MainStream.Read(chk, 0, 4);
            if (BitConverter.ToInt32(chk, 0) != 1179403647) {// Make Sure The File's Actually Even A .elf
                GameString = "Executable Still Encrypted";
                AddString = "Must Be Decrypted/Unsigned";
                return $"{GameString} | {AddString}";
            }

            bool CheckDebugState(int[] offsets, byte[] Data) {
                int i = 0; // Just Returns True If The Bytes Read At The Specified Address Match The Byte Given
                foreach (int addr in offsets) {
                    Read:if (ReadByte(addr) == Data[i]) return true;

                    if (Data[i] == 0x75) { // Go back and check for an unconditional jump
                        Data[i] = 0xEB;
                        goto Read;
                    }
                    i++;
                }
                return false;
            }

            switch (Game) {
                default:
                    MessageBox.Show($"Couldn't Determine The Game This Executable Belongs To, Send It To Blob To Have It's Title ID Supported\n{Game}");
                    break;
                case T1R100:
                    GameString = "The Last Of Us Remastered 1.00";
                    break;
                case T1R109:
                    GameString = "The Last Of Us Remastered 1.09";
                    break;
                case T1R11X:
                    MainStream.Position = 0x18;
                    GameString = $"The Last Of Us Remastered 1.1{((byte)MainStream.ReadByte() == 0x10 ? 1 : 0)}";
                    break;
                case T2100:
                    GameString = "The Last Of Us Part II 1.00";
                    break;
                case T2101:
                    GameString = "The Last Of Us Part II 1.01";
                    break;
                case T2102:
                    GameString = "The Last Of Us Part II 1.02";
                    break;
                case T2105:
                    GameString = "The Last Of Us Part II 1.05";
                    break;
                case T2107:
                    GameString = "The Last Of Us Part II 1.07";
                    break;
                case T2108:
                    GameString = "The Last Of Us Part II 1.08";
                    break;
                case T2109:
                    GameString = "The Last Of Us Part II 1.09";
                    break;
                case UC1100:
                    if (CheckDebugState(new int[] { 0x102056, 0x102057, 0x10207B }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 1 1.00";
                    break;
                case UC1102:
                    if (CheckDebugState(new int[] { 0x102186, 0x102187, 0x1021AB }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 1 1.02";
                    break;
                case UC2100:
                    if (CheckDebugState(new int[] { 0x1EB296, 0x1EB297, 0x1EB2BB }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 2 1.00";
                    break;
                case UC2102:
                    if (CheckDebugState(new int[] { 0x3F7A25, 0x3F7A26, 0x3F7A4A }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 2 1.02";
                    break;
                case UC3100:
                    if (CheckDebugState(new int[] { 0x168EB6, 0x168EB7, 0x168EDB }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 3 1.00";
                    break;
                case UC3102:
                    if (CheckDebugState(new int[] { 0x578226, 0x578227, 0x57824B }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 3 1.02";
                    break;
                case UC4100:
                    GameString = "Uncharted 4: A Thief's End 1.00";
                    break;
                case UC413X:
                    GameString = "Uncharted 4: A Thief's End 1.32/1.33";
                    break;
                case UC4133MP:
                    GameString = "Uncharted 4: A Thief's End 1.33 Multiplayer";
                    break;
                case TLL100:
                    GameString = "Uncharted: The Lost Legacy 1.00";
                    break;
                case TLL10X:
                    GameString = "Uncharted: The Lost Legacy 1.08/1.09";
                    break;
            }
            return $"{GameString} | {AddString}";
        }

        /// <summary> Sets The Info Label String Based On The Currently Hovered Control </summary>
        /// <param name="Sender">The Hovered Control</param>
        public static void SetInfoLabelStringOnControlHover(Control Sender) { // 
            string InfoLabelString = "Unknown Label Error";
            switch (Sender.Name) {
                default: return;
                //
                // Const
                //
                case "CreditsBtn":
                    InfoLabelString = "View Credits For The Tool And Included Patches";
                    break;
                case "InfoHelpBtn":
                    YellowInformationLabel.Font = new Font(YellowInformationLabel.Font.FontFamily, 9.5F);
                    InfoLabelString = "View Help For Each Page As Well As The App Itself";
                    break; 
                case "BackBtn":
                    InfoLabelString = "Return To The Previous Page";
                    break;
                //
                // Main
                //
                case "PS4DebugPageBtn":
                    YellowInformationLabel.Font = new Font(YellowInformationLabel.Font.FontFamily, 9F);
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
                //
                // PS4DebugPage
                //
                case "UC1Btn":
                    InfoLabelString = "Supports: 1.00 | 1.02";
                    break;
                case "UC2Btn":
                    InfoLabelString = "Supports: 1.00";
                    break;
                case "UC3Btn":
                    InfoLabelString = "Supports: 1.00";
                    break;
                case "UC4Btn":
                    InfoLabelString = "Supports: 1.00 | 1.32 | 1.33";
                    break;
                case "UC4MPBetaBtn":
                    InfoLabelString = "Supports: 1.09 - Use .bin Patch For 1.00";
                    break;
                case "T1RBtn":
                    InfoLabelString = "Supports: 1.00 | 1.09 | 1.10 | 1.11";
                    break;
                case "T2Btn":
                    InfoLabelString = "Supports: 1.00 | 1.07 | 1.08 | 1.09";
                    break;
                case "DebugPayloadBtn":
                    InfoLabelString = "Sends ctn123's Port Of PS4Debug";
                    break;
                case "ManualConnectBtn":
                    InfoLabelString = "Tool Also Auto-Connects When An Option's Selected";
                    break;
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
                case "CustomOptDebugBtn":
                    InfoLabelString = REL ? "Temporarily Disabled" : "change me //!";
                    break;
                //
                // PS4QOLPatchesPage
                //
                case "2":
                    break;
                //
                // PCExePatchPage
                //
                case "3":
                    break;
                //
                // PCQOLPatchPage
                //
                case "4":
                    break;
                //
                // InfoHelpPage
                //
                case "5":
                    break;
                //
                // CreditsPage
                //
                case "6":
                    break;
                //
                // PCQOLPatchPage
                //
                case "7":
                    break;

            }
            SetInfoLabelText(InfoLabelString);
        }

        public static void ChangeForm(int Page, bool IsGoingBack) {
            LastPos = ActiveForm.Location;
            var ClosingForm = ActiveForm;
            if (!IsGoingBack) {
                for (int i = 0; i < 5; i++) {
                    if (Pages[i] == null) {
                        Pages[i] = Common.Page;
                        break;
                    }
                }
            }
            Common.Page = Page;
            switch (Page) {
                default:
                    Dev.DebugOut($"{Page} Is Not A Page!");
                    break;
                case 0:
                    MainForm.Show();
                    break;
                case 1:
                    PS4DebugPage PS4Debug = new PS4DebugPage();
                    PS4Debug.Show();
                    break;
                case 2:
                    EbootPatchPage EbootPatch = new EbootPatchPage();
                    EbootPatch.Show();
                    break;
                case 3:
                    PS4QOLPatchesPage PS4QOLPage = new PS4QOLPatchesPage();
                    PS4QOLPage.Show();
                    break;
                case 4:
                    PS4QOLPatchesPage tmp = new PS4QOLPatchesPage();
                    tmp.Show();
                    break;
                case 5:
                    InfoHelpPage InfoHelp = new InfoHelpPage();
                    InfoHelp.Show();
                    break;
                case 6:
                    PS4DebugHelpPage PS4DebugHelp = new PS4DebugHelpPage();
                    PS4DebugHelp.Show();
                    break;
                case 7:
                    EbootPatchHelpPage EbootPatchHelp = new EbootPatchHelpPage();
                    EbootPatchHelp.Show();
                    break;
                case 8:
                    CreditsPage Credits = new CreditsPage();
                    Credits.Show();
                    break;
                case 9:
                    PCDebugMenuPage PCDebugMenu = new PCDebugMenuPage();
                    PCDebugMenu.Show();
                    MessageBox.Show("Important Note:\nI'v Only Got The Executables For Either The Epic Or Steam Version, And I Don't Even Know Which...\n\nIf The Tools Says Your Executable Is Unknown, Send It To Me And I'll Add Support For It\nI Would Advise Alternate Methods, Though");
                    break;
                case 10:
                    PCQOLPatchesPage PCQOLPatches = new PCQOLPatchesPage();
                    PCQOLPatches.Show();
                    MessageBox.Show("Important Note:\nI'v Only Got The Executables For Either The Epic Or Steam Version, And I Don't Even Know Which...\n\nIf The Tools Says Your Executable Is Unknown, Send It To Me And I'll Add Support For It\nI Would Advise Alternate Methods, Though");
                    break;
            }
            YellowInformationLabel = ActiveForm.Controls.Find("Info", true)[0];
            ActiveForm.Location = LastPos;
            if (ClosingForm.Name != "Dobby") {
                ClosingForm.Close();
                return;
            }
            MainForm = ClosingForm;
            ClosingForm.Hide();
        }

        public static void BackFunc() {

            for (int i = 4; i >= 0; i--)

            if (Pages[i] != null) {
                ChangeForm((int)Pages[i], true);
                DebugOut($"Pages[i]: {Pages[i]}");
                Pages[i] = null;
                break;
            }
        }

        public static void AddControlEventHandlers(Control.ControlCollection Controls) { // Got Sick of Manually Editing InitializeComponent()
            #region DebugLabel
#if DEBUG
            Label DebugLabel = new Label();
            DebugLabel.Size = new Size(36, 19);
            DebugLabel.Location = new Point(230, 1);
            DebugLabel.ForeColor = SystemColors.Control;
            DebugLabel.BorderStyle = BorderStyle.FixedSingle;
            DebugLabel.Font = new Font("Franklin Gothic Medium", 7F, FontStyle.Bold);
            DebugLabel.Text = "(Dev)";
            DebugLabel.Click += new EventHandler(MiscDebugFunc);
            Controls.Add(DebugLabel);
            DebugLabel.BringToFront();
#endif
            #endregion
            string[] Blacklist = new string[] { "ExitBtn", "MinimizeBtn", "IPLabelBtn", "PortLabelBtn" };

            foreach (Control Item in Controls) {
                if (Item.HasChildren) { // Designer Added Some Things To The Form, And Some To The Group Box Used To Make The Border. This is me bing lazy. as long as it's not noticably slower
                    foreach (Control Child in Item.Controls) {
                        Child.MouseDown += new MouseEventHandler(MouseDownFunc);
                        Child.MouseMove += new MouseEventHandler(MoveForm);
                        Child.MouseUp += new MouseEventHandler(MouseUpFunc);
                        if ($"{Child.GetType()}" == "System.Windows.Forms.Button" && !Blacklist.Contains(Child.Name)) {
                            Child.MouseEnter += new EventHandler(ControlHover);
                            Child.MouseLeave += new EventHandler(ControlLeave);
                        }
#if DEBUG
                        else Child.MouseEnter += new EventHandler(DebugControlHover);
#endif
                    }
                }
                if ($"{Item.GetType()}" == "System.Windows.Forms.Button" && !Blacklist.Contains(Item.Name)) {
                    Item.MouseEnter += new EventHandler(ControlHover);
                    Item.MouseLeave += new EventHandler(ControlLeave);
                }
#if DEBUG
                else Item.MouseEnter += new EventHandler(DebugControlHover);
#endif
                Item.MouseDown += new MouseEventHandler(MouseDownFunc);
                Item.MouseMove += new MouseEventHandler(MoveForm);
                Item.MouseUp += new MouseEventHandler(MouseUpFunc);
            }
            try {
                Controls.Find("MinimizeBtn", true)[0].Click += new EventHandler(MinimizeBtn_Click);
                Controls.Find("MinimizeBtn", true)[0].MouseEnter += new EventHandler(MinimizeBtnMH);
                Controls.Find("MinimizeBtn", true)[0].MouseLeave += new EventHandler(MinimizeBtnML);
                Controls.Find("ExitBtn", true)[0].Click += new EventHandler(ExitBtn_Click);
                Controls.Find("ExitBtn", true)[0].MouseEnter += new EventHandler(ExitBtnMH);
                Controls.Find("ExitBtn", true)[0].MouseLeave += new EventHandler(ExitBtnML);
            }
            catch (IndexOutOfRangeException) { DebugOut("Form Lacks MinimizeBtn And / Or ExitBtn"); }
        }

        /// <summary> Set The Text of The Yellow Label At The Bottom Of The Form </summary>
        public static void SetInfoLabelText(string s) => YellowInformationLabel.Text = s; // I used to have this output to the debugger as well, hence the presence of function call as opposed to just the text change itself

        /// <summary> Highlights A Control In Yellow With A > Preceeding It When Hovered Over </summary>
        /// <param name="PassedControl">The Control To Highlight</param>
        /// <param name="EventIsMouseEnter">Highlight If True</param>
        public static void HoverLeave(Control PassedControl, bool EventIsMouseEnter) {
            CurrentControl = PassedControl.Name;
            PassedControl.ForeColor     = EventIsMouseEnter ? Color.FromArgb(255, 227, 0) : Color.FromArgb(255, 255, 255);
            PassedControl.Text          = EventIsMouseEnter ? $">{PassedControl.Text}"    : PassedControl.Text.Substring(PassedControl.Text.IndexOf('>') + 1);
            PassedControl.Size = new Size(EventIsMouseEnter ? PassedControl.Width + 9     : PassedControl.Width - 9, PassedControl.Height);

            if (!InfoHasImportantStr & !EventIsMouseEnter) SetInfoLabelText("");
            if (!EventIsMouseEnter)  { MouseScrolled = 0; return; }
            else SetInfoLabelStringOnControlHover(PassedControl);
            #if DEBUG
            HoveredControl = PassedControl;
            #endif
        }

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
                DebugOut("Killing Label Flash");
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
                DebugOut("Killing Label Flash WH");
            }
        }
        static void FlashYellow() {
            try {
                ActiveForm.Controls.Find("GameInfoLabel", true)[0].ForeColor = Color.FromArgb(255, 227, 0);
                ActiveForm.Refresh();
            }
            catch (Exception) {
                DebugOut("Killing Label Flash YL");
            }
        }
        #endregion
        #region PS4 / PC exe Patch Page Shared Variables And Functions




        /////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///-- DEBUG MODE OFFSETS AND GAME INDENTIFIERS --\\\
        /////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\
        
        // Yes, I know an array could be easier to deal with in code, but I want them all labeled individually so bite me
        public const int
            
            // Game Identifiers. Read 4 bytes at 0x60 as an integer to get it
            T1R100 = 22033680,
            T1R109 = 21444016,
            T1R11X = 21446072,
            T2100  = 46552012,
            T2101  = 46785692,
            T2102  = 46718028,
            T2105  = 46826436,
            T2107  = 46832260,
            T2108  = 48176392,
            T2109  = 48176456,
            UC1100 = 9818208,
            UC1102 = 9568920,
            UC2100 = 14655236,
            UC2102 = 16663728,
            UC3100 = 20277852,
            UC3102 = 23365872,
            UC4100 = 36229424,
            UC413X = 33886256,
            UC4133MP = 35877432,
            TLL100 = 35178432,
            TLL10X = 35227448,
            T1X101 = 42695168 + 16007532,  // 0x1EC + 0x1F8 | Fuck you, I'm keeping them seperate
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

        public const int 
            // Debug Offsets (0xEB)
            T1R100Debug = 0x5C5A,
            T1R109Debug = 0x61A4,
            T1R110Debug = 0x61A4,
            T1R111Debug = 0x61A4,
            T2100Debug = 0x1D6398,
            T2101Debug = 0x1D6418,
            T2102Debug = 0x1D6468,
            T2105Debug = 0x1D66A8,
            T2107Debug = 0x1D66B8,
            T2108Debug = 0x6181F8,
            T2109Debug = 0x6181F8,
            UC1100Debug = 0x102057,
            UC1102Debug = 0x102187,
            UC2100Debug = 0x1EB297,
            UC2102Debug = 0x3F7A26,
            UC3100Debug = 0x168EB7,
            UC3102Debug = 0x578227,
            UC4100Debug = 0x1297DE,   //! TEST ME
            UC413XDebug = 0x1CCDEE,   //! TEST ME
            UC4133MPDebug = 0x1CCEA9, //! TEST ME
            TLL100Debug = 0x1CCFDE,   //! TEST ME
            TLL10XDebug = 0x1CD01E    //! TEST ME
        ;

        /// <summary> Offsets To Enable The Debug Mode in the pc version of the game </summary>
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




        //////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///-- QUALITY OF LIFE/BOOTSETTINGS OFFSET POINTERS--\\\
        //////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        ///  Byte arrays to be used as pointers with the BootSettings custom function
        /// </summary>
        public static readonly byte[]
            UC1100DisableFPS = new byte[] { 0x70, 0x89, 0x99, 0x00 }, // fill null bytes just in case of repeat uses with alternate options
            UC1102DisableFPS = new byte[] {},
            UC2100DisableFPS = new byte[] { 0x31, 0x14, 0xE7, 0x00 },
            UC2102DisableFPS = new byte[] { 0x61, 0xde, 0x05, 0x01 },
            UC3100DisableFPS = new byte[] {},
            UC3102DisableFPS = new byte[] {},
            UC4100DisableFPS = new byte[] {},
            UC4133DisableFPS = new byte[] {},
            UC4133MPDisableFPS = new byte[] {},
            TLL100DisableFPS = new byte[] {},
            TLL107DisableFPS = new byte[] {},
            TLL108DisableFPS = new byte[] {},
            TLL109DisableFPS = new byte[] {},
            T1R100DisableFPS = new byte[] {},
            T1R109DisableFPS = new byte[] {},
            T1R110DisableFPS = new byte[] {},
            T1R111DisableFPS = new byte[] {},
            T2100DisableFPS = new byte[] {},
            T2101DisableFPS = new byte[] { },
            T2102DisableFPS = new byte[] {},
            T2105DisableFPS = new byte[] {},
            T2107DisableFPS = new byte[] {},
            T2108DisableFPS = new byte[] {},
            T2109DisableFPS = new byte[] {}
        ;

        /// <summary>
        ///  ProgPauseOnOpen Offsets
        /// </summary>
        public static readonly byte[]
            UC1100ProgPause = new byte[] { 0x88, 0xF9, 0xA9, 0x00 }, 
            UC1102ProgPause = new byte[] {},
            UC2100ProgPause = new byte[] { 0x78, 0xC7, 0xEB, 0x00 },
            UC2102ProgPause = new byte[] { 0xe0, 0x95, 0x05, 0x01 },
            UC3100ProgPause = new byte[] {},
            UC3102ProgPause = new byte[] {},
            UC4100ProgPause = new byte[] {},
            UC4133ProgPause = new byte[] {},
          UC4133MPProgPause = new byte[] {},
            TLL100ProgPause = new byte[] {},
            TLL107ProgPause = new byte[] {},
            TLL108ProgPause = new byte[] {},
            TLL109ProgPause = new byte[] {},
            T1R100ProgPause = new byte[] {},
            T1R109ProgPause = new byte[] {},
            T1R110ProgPause = new byte[] {},
            T1R111ProgPause = new byte[] {},
            T2100ProgPause = new byte[] {},
            T2101ProgPause = new byte[] {},
            T2102ProgPause = new byte[] {},
            T2105ProgPause = new byte[] {},
            T2107ProgPause = new byte[] {},
            T2108ProgPause = new byte[] {},
            T2109ProgPause = new byte[] {}
        ;

        /// <summary>
        ///  ProgPauseOnExitOffsets
        /// </summary>
        public static readonly byte[]
            UC1100ProgPauseOnExit = new byte[] { 0x8C, 0xF9, 0xA9, 0x00 },
            UC1102ProgPauseOnExit = new byte[] { },
            UC2100ProgPauseOnExit = new byte[] { 0x79, 0xC7, 0xEB, 0x00 },
            UC2102ProgPauseOnExit = new byte[] { },
            UC3100ProgPauseOnExit = new byte[] { },
            UC3102ProgPauseOnExit = new byte[] { },
            UC4100ProgPauseOnExit = new byte[] { },
            UC4133ProgPauseOnExit = new byte[] { },
          UC4133MPProgPauseOnExit = new byte[] { },
            TLL100ProgPauseOnExit = new byte[] { },
            TLL107ProgPauseOnExit = new byte[] { },
            TLL108ProgPauseOnExit = new byte[] { },
            TLL109ProgPauseOnExit = new byte[] { },
            T1R100ProgPauseOnExit = new byte[] { },
            T1R109ProgPauseOnExit = new byte[] { },
            T1R110ProgPauseOnExit = new byte[] { },
            T1R111ProgPauseOnExit = new byte[] { },
            T2100ProgPauseOnExit = new byte[] { },
            T2101ProgPauseOnExit = new byte[] { },
            T2102ProgPauseOnExit = new byte[] { },
            T2105ProgPauseOnExit = new byte[] { },
            T2107ProgPauseOnExit = new byte[] { },
            T2108ProgPauseOnExit = new byte[] { },
            T2109ProgPauseOnExit = new byte[] { }
        ;

        /// <summary>
        ///  Swap Circle And Square Offsets
        /// </summary>
        public static readonly byte[]
            UC1100PausedIcon = new byte[] { 0x8A, 0xF9, 0xA9, 0x00 }, // CHECK, TOOL WAS BROKEN
            UC1102PausedIcon = new byte[] { 0x8A, 0x38, 0xA6, 0x00 }, // CHECK, TOOL WAS BROKEN
            UC2100PausedIcon = new byte[] { 0x7A, 0xC7, 0xEB, 0x00 }, // Test Me!!
            UC2102PausedIcon = new byte[] { 0xE2, 0x95, 0x05, 0x00 }, // CHECK, TOOL WAS BROKEN
            UC3100PausedIcon = new byte[] { 0x32, 0xFA, 0x42, 0x00 }, // CHECK, TOOL WAS BROKEN
            UC3102PausedIcon = new byte[] { 0x52, 0x4A, 0x7B, 0x00 }, // CHECK, TOOL WAS BROKEN
            UC4100PausedIcon = new byte[] { },
            UC4133PausedIcon = new byte[] { },
          UC4133MPPausedIcon = new byte[] { },
            TLL100PausedIcon = new byte[] { },
            TLL107PausedIcon = new byte[] { },
            TLL108PausedIcon = new byte[] { },
            TLL109PausedIcon = new byte[] { },
            T1R100PausedIcon = new byte[] { },
            T1R109PausedIcon = new byte[] { },
            T1R110PausedIcon = new byte[] { },
            T1R111PausedIcon = new byte[] { },
            T2100PausedIcon = new byte[] { },
            T2101PausedIcon = new byte[] { },
            T2102PausedIcon = new byte[] { },
            T2105PausedIcon = new byte[] { },
            T2107PausedIcon = new byte[] { },
            T2108PausedIcon = new byte[] { },
            T2109PausedIcon = new byte[] { }
        ;

        /// <summary>
        ///  Swap Circle And Square Offsets
        /// </summary>
        public static readonly byte[]
            UC4100SwapCircle = new byte[] {},
            UC4133SwapCircle = new byte[] {},
            UC4133MPSwapCircle = new byte[] {},
            TLL100SwapCircle = new byte[] {},
            TLL107SwapCircle = new byte[] {},
            TLL108SwapCircle = new byte[] {},
            TLL109SwapCircle = new byte[] {},
            T1R100SwapCircle = new byte[] {},
            T1R109SwapCircle = new byte[] {},
            T1R110SwapCircle = new byte[] {},
            T1R111SwapCircle = new byte[] {},
            T2100SwapCircle = new byte[] {},
            T2101SwapCircle = new byte[] {},
            T2102SwapCircle = new byte[] {},
            T2105SwapCircle = new byte[] {},
            T2107SwapCircle = new byte[] {},
            T2108SwapCircle = new byte[] {},
            T2109SwapCircle = new byte[] {}
        ;


        /// <summary>
        ///  Hide Task / Build Info Display
        /// </summary>
        public static readonly byte[]
            UC1100HideTaskInfo = new byte[] { 0x41, 0x7B, 0x99, 0x00},
            UC1102HideTaskInfo = new byte[] {},
            UC2100HideTaskInfo = new byte[] {},
            UC2102HideTaskInfo = new byte[] { 0xf9, 0xcf, 0x05, 0x01 },
            UC3100HideTaskInfo = new byte[] {},
            UC3102HideTaskInfo = new byte[] {},
            UC4100HideTaskInfo = new byte[] {},
            UC4133HideTaskInfo = new byte[] {},
          UC4133MPHideTaskInfo = new byte[] {},
            TLL100HideTaskInfo = new byte[] {},
            TLL107HideTaskInfo = new byte[] {},
            TLL108HideTaskInfo = new byte[] {},
            TLL109HideTaskInfo = new byte[] {},
            T2100HideTaskInfo = new byte[] {},
            T2101HideTaskInfo = new byte[] {},
            T2102HideTaskInfo = new byte[] {},
            T2105HideTaskInfo = new byte[] {},
            T2107HideTaskInfo = new byte[] {},
            T2108HideTaskInfo = new byte[] {},
            T2109HideTaskInfo = new byte[] {}
        ;
        
        public static readonly byte[]

            // Right Align Offsets
            UC3100RightAlign = new byte[] { 0x34, 0xFA, 0x42, 0x01 },
            UC3102RightAlign = new byte[] {},
            UC4100RightAlign = new byte[] {},
            UC4133RightAlign = new byte[] {},
          UC4133MPRightAlign = new byte[] {},
            TLL100RightAlign = new byte[] {},
            TLL107RightAlign = new byte[] {},
            TLL108RightAlign = new byte[] {},
            TLL109RightAlign = new byte[] {},
            T1R100RightAlign = new byte[] {},
            T1R109RightAlign = new byte[] {},
            T1R110RightAlign = new byte[] {},
            T1R111RightAlign = new byte[] {},
            T2100RightAlign = new byte[] {},
            T2101RightAlign = new byte[] {},
            T2102RightAlign = new byte[] {},
            T2105RightAlign = new byte[] {},
            T2107RightAlign = new byte[] {},
            T2108RightAlign = new byte[] {},
            T2109RightAlign = new byte[] {}
        ;

        /// <summary>
        ///  Right Align Offsets
        /// </summary>
        public static readonly byte[]
            UC3100RightMargin = new byte[] { 0x38, 0xFA, 0x42, 0x01 },
            UC3102RightMargin = new byte[] {},
            UC4100RightMargin = new byte[] {},
            UC4133RightMargin = new byte[] {},
          UC4133MPRightMargin = new byte[] {},
            TLL100RightMargin = new byte[] {},
            TLL107RightMargin = new byte[] {},
            TLL108RightMargin = new byte[] {},
            TLL109RightMargin = new byte[] {},
            T1R100RightMargin = new byte[] {},
            T1R109RightMargin = new byte[] {},
            T1R110RightMargin = new byte[] {},
            T1R111RightMargin = new byte[] {},
            T2100RightMargin = new byte[] {},
            T2101RightMargin = new byte[] {},
            T2102RightMargin = new byte[] {},
            T2105RightMargin = new byte[] {},
            T2107RightMargin = new byte[] {},
            T2108RightMargin = new byte[] {},
            T2109RightMargin = new byte[] {}
        ;


        /// <summary>
        ///  Invincible Player Offsets
        /// </summary>
        public static readonly byte[]
            UC1100InvinciblePlayer = new byte[] { 0xF8, 0x20, 0xAE, 0x00 },
            UC1102InvinciblePlayer = new byte[] { },
            UC2100InvinciblePlayer = new byte[] { },
            UC2102InvinciblePlayer = new byte[] { },
            UC3100InvinciblePlayer = new byte[] { },
            UC3102InvinciblePlayer = new byte[] { },
            UC4100InvinciblePlayer = new byte[] { },
            UC4133InvinciblePlayer = new byte[] { },
          UC4133MPInvinciblePlayer = new byte[] { },
            TLL100InvinciblePlayer = new byte[] { },
            TLL107InvinciblePlayer = new byte[] { },
            TLL108InvinciblePlayer = new byte[] { },
            TLL109InvinciblePlayer = new byte[] { },
            T1R100InvinciblePlayer = new byte[] { },
            T1R109InvinciblePlayer = new byte[] { },
            T1R110InvinciblePlayer = new byte[] { },
            T1R111InvinciblePlayer = new byte[] { },
            T2100InvinciblePlayer = new byte[] { },
            T2101InvinciblePlayer = new byte[] { },
            T2102InvinciblePlayer = new byte[] { },
            T2105InvinciblePlayer = new byte[] { },
            T2107InvinciblePlayer = new byte[] { },
            T2108InvinciblePlayer = new byte[] { },
            T2109InvinciblePlayer = new byte[] { }
        ;

        public static byte[]
            chk = new byte[4],
            E9Jump = new byte[] { 0xE9, 0x00, 0x00, 0x00, 0x00 },
            DebugDat = new byte[] { 0x8a, 0x8f, 0xf2, 0x3e, 0x00, 0x00, 0x84, 0xc9, 0x0f, 0x94, 0xc2, 0x84, 0xc9, 0x0f, 0x95, 0xc1, 0x88, 0x8f, 0x3d, 0x3f, 0x00, 0x00, 0x88, 0x97, 0x2f, 0x3f, 0x00, 0x00 },
            T2Debug = new byte[] { 0xb2, 0x00, 0xb0, 0x01 }, // Turns "Disable Debug Rendering" Off (b2 00) & Debug Mode On (b0 01)
            T2DebugOff = new byte[] { 0xb2, 0x01, 0x31, 0xc0 }
        ;

        public static byte
            MouseScrolled,
            MouseIsDown
        ;

        public static FileStream MainStream;

        public static string ActiveFilePath;

        public static bool IsActiveFilePCExe, MainStreamIsOpen;

        public static int Game;

        public static void WriteBytes(int offset, byte[] data) {
            MainStream.Position = offset;
            MainStream.Write(data, 0, data.Length);
        }
        public static void WriteBytes(int[] offset, byte[] data) {
            foreach (int ofs in offset) {
                MainStream.Position = ofs;
                MainStream.Write(data, 0, data.Length);
            }
        }
        public static void WriteBytes(int[] offset, byte[][] data) {
            int i = 0;
            foreach (byte[] bytes in data) {
                MainStream.Position = offset[i];
                MainStream.Write(bytes, 0, data.Length);
                i++;
            }
        }
        public static void WriteByte(int offset, byte data) {
            MainStream.Position = offset;
            MainStream.WriteByte(data);
            MainStream.Flush();
            DebugOut($"Wrote {data:X} at {offset:X}");
        }
        public static void WriteByte(int[] offset, byte data) {
            foreach (int ofs in offset) {
                MainStream.Position = ofs;
                MainStream.WriteByte(data);
                DebugOut($"Wrote {data:X} at {offset:X}");
            }
        }
        public static byte ReadByte(int offset) {
            MainStream.Position = offset;
            return (byte)MainStream.ReadByte();
        }
        public static bool ByteCmp(int Address, byte ByteToCompare) {
            MainStream.Position = Address;
            return (byte)MainStream.ReadByte() == ByteToCompare;
        }
        /// <summary>
        /// Compare Data Read At The Given Address
        /// </summary>
        /// <returns>True If The Data Read Matches The Array Given</returns>
        public static bool ArrayCmp(int Address, byte[] DataToCompare) {
            MainStream.Position = Address;
            byte[] DataPresent = new byte[DataToCompare.Length];
            MainStream.Read(DataPresent, 0, DataToCompare.Length);
            return DataPresent.SequenceEqual<byte>(DataToCompare);
        }
        //
        /////////////////////////////////////////////////////////////////////////////////
        //
        #endregion


        public class Dev {
#if !DEBUG
            public const bool REL = true;

#elif DEBUG
            public const bool REL = false;
            public static void MiscDebugFunc(object sender, EventArgs e) => DebugOut($"{tst_int++}");
            public static void DebugControlHover(object sender, EventArgs e) => HoveredControl = (Control)sender;

            public static bool OverrideDebugOut;

            static int tst_int = 0;

            static int TimerTicks = 0, OutputStringIndex = 0;

            public delegate void TimerDelegate();
            public static TimerDelegate TimerThread = new TimerDelegate(StartTimer);
            public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

            public static void Timer_Tick(object sender, EventArgs e) => TimerTicks++;
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
                    switch (ReadKey(true).Key) {
                        case ConsoleKey.R:
                            Clear();
                            break;
                        case ConsoleKey.C:
                            OutputStrings = new string[OutputStrings.Length];
                            OutputStringIndex = 0;
                            Clear(); Thread.Sleep(42); Clear(); // First Clear Doesn't Get It All
                            break;
                        case ConsoleKey.M:
                            if (MainStreamIsOpen) {
                                MainStream.Dispose();
                                MainStreamIsOpen = false;
                                DebugOut("MainStream Closed");
                                if (Page == 3) {
                                    Wait:
                                    if (ActiveForm == null) goto Wait;
                                    DebugOut("FormShouldReset = true");
                                    PS4QOLPatchesPage.FormShouldReset = true;
                                }
                            }
                            break;
                        case ConsoleKey.Z:
                            if (OutputStringIndex < 0)
                            OutputStringIndex--;
                            Clear();
                            break;
                    }                        
                }
            }

            public static string[] OutputStrings;
            public static int ShiftIndex = 0;


            public static Thread DebuggerThread = new Thread(new ThreadStart(UpdateConsoleOutput));
            public static void DebuggerInfo() => DebuggerThread.Start();
            public static Control HoveredControl = new Label(); // Just so the debugger doesn't bitch

            public static void UpdateConsoleOutput() { if (OverrideDebugOut) return;
#if DEBUG
                bool TimerThreadStarted = false;
                int Interval = 0;

Begin_Again:    // IN THE NIIIIIIGGGHHHTTT, LET'S    SWAAAAAAYYYY AGAIIN, TONIIIIIIGHT
                WindowHeight = 35; SetWindowPosition(0,0);
                OutputStrings = new string[WindowHeight - 14];
                CursorVisible = false;
                Point OriginalConsoleScale = new Point(WindowHeight, WindowWidth);
                if (ActiveForm != null && !TimerThreadStarted) { ActiveForm.Invoke(TimerThread); TimerThreadStarted = true; }
                try {
                    while (OriginalConsoleScale == new Point(WindowHeight, WindowWidth) & !OverrideDebugOut) {
                        CursorLeft = 0; // Lazy Fix
                        int StartTime = TimerTicks, Cursor = 0, String = 0; Form frm = ActiveForm;
                        string ControlType = HoveredControl.GetType().ToString();
                        string[] Output = new string[] {
                            $"Build: {Build} | ~{Interval}ms | {OutputStrings.Length} ({OutputStringIndex})",
                            "",
                            $"Form: {(ActiveForm != null ? $"{ActiveForm.Name} | Form Position: {ActiveForm.Location}" : "Console")}",
                            $"Pages: {Pages?[0]}, {Pages?[1]}, {Pages?[2]}, {Pages?[3]}",
                            $"Active Page ID: {Page} | InfoHasImportantString: {InfoHasImportantStr}",
                            $"Game: {Game}",
                            "",
                            $"MouseIsDown: {MouseIsDown} | MouseScrolled: {MouseScrolled} | MousePos: {MousePosition}",
                            $"Control: {HoveredControl.Name} | {ControlType.Substring(ControlType.LastIndexOf('.') + 1)}",
                            $" Size: {HoveredControl.Size} | Pos: {HoveredControl.Location}",
                            $" Parent {HoveredControl.Parent?.Name}",
                            "",
                            $"MainStream: {(MainStreamIsOpen ? MainStream.Name : "null")}",
                            $"{(MainStreamIsOpen ? $"Length: {(MainStream.Length.ToString().Length > 6 ? $"{MainStream.Length.ToString().Remove(2)}MB" : $"{MainStream.Length} bytes")} | Read: {MainStream.CanRead} | Write: {MainStream.CanWrite}" : null)}"
                        };

                        for (; String < Output.Length ; String++) { CursorTop = Cursor++; Write(BlankSpace(Output[String])); }

                        CursorTop = MainStreamIsOpen? Cursor+=1: Cursor;
                        for (int i = 0; i <= OutputStringIndex; ) {
                            Write(BlankSpace(OutputStrings[i++]));
                            Cursor++;
                        }

                        Interval = TimerTicks - StartTime;
                        }
                    }
                catch (System.ObjectDisposedException) { }
                Clear();
                if (OverrideDebugOut) return;
                goto Begin_Again;
                #endif
            }
#endif
            public static void DebugOut() => DebugOut(" ");
            public static void DebugOut(object obj, int NewCursorTop) {
                CursorTop = NewCursorTop;
                WriteLine(obj);
            }
            public static void DebugOut(object obj) {
#if DEBUG
                if (OverrideDebugOut) return; string s = obj.ToString();
                if (s.Contains("\n")) {
                    s = s.Replace("\n", "");
                    s += " (Use Seperate Calls For New Line!!!)";
                }

                if (OutputStringIndex != OutputStrings.Length - 1) {
                    for (; OutputStringIndex < OutputStrings.Length - 1; OutputStringIndex++) {
                        if (OutputStrings[OutputStringIndex] == null) {
                            OutputStrings[OutputStringIndex] = s;
                            break;
                        }
                    }
                    return;
                }
                for (ShiftIndex = 0; ShiftIndex < OutputStrings.Length - 1 ; ShiftIndex++)
                    OutputStrings[ShiftIndex] = OutputStrings[ShiftIndex + 1];
                OutputStrings[ShiftIndex] = s;
#endif
            }
#if DEBUG      

            public static string BlankSpace(string String) {
                if (String == null) return " ";
                for (int i = BufferWidth - String.Length; i > 0; i--)
                String += " ";
                return String;
            }

            public static void DebugForceOpenFile(string FilePath) { if (MainStreamIsOpen) { MainStream.Dispose(); }
                ActiveFilePath = FilePath;
                MainStream = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite);
                MainStream.Position = 0x60; MainStream.Read(chk, 0, 4);
                Game = BitConverter.ToInt32(chk, 0);
                try {
                    ActiveForm.Controls.Find("GameInfoLabel", true)[0].Text = UpdateGameInfoLabel();
                    ActiveForm.Controls.Find("ResetBtn", true)[0].Visible = MainStreamIsOpen = true;
                    ActiveForm.Controls.Find("CustomDebugOptionsLabel", true)[0].Visible = IsActiveFilePCExe = false;
                }
                catch (IndexOutOfRangeException) { }
                MainStreamIsOpen = true;
                Clear();
            }
#endif
        }
    }
}
