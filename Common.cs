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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Console;
using static Dobby.Common.Dev;
using System.Runtime.CompilerServices;

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
           "* 2.22.69.171 | Just Realized I Can Cast sender to a control ptr... Overhauled Mouse Hover/Leave Functionality, Merged PC and PS4 arrays"

            // TODO:
            // - Finish EbootPatchHelpPage
            // - Finish EbootPatchPage GameInfoLabel Functionality
            
            // KNOWN BUGS:
            // - Occasional String Duplication In Debug Output (DebugOutputStr / UpdateConsoleOutput)

        };
        public static string Build = ChangeList[ChangeList.Length - 1].Substring(2).Substring(0, ChangeList[ChangeList.Length - 1].IndexOf('|') - 3); // Trims The Last ChangeList String For Latest The Build Number
        
        public static string CurrentControl, tmp;


        #region PS4 / PC exe Patch Page Shared Variables And Functions
        public const int // Games. Read 4 bytes at 0x60 as an integer to get it
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
            T1X101 = 42695168 + 16007532,  // 0x1EC + 0x1F8, Yes, I was too lazy to add them together. for now
            T1XL101 = 42670080 + 16010844,
            T1X1015 = 2228464 + 95625728,
            T1XL1015 = 2228464 + 95627776,
            T1X1016 = 42698752 + 16007532,
            T1XL1016 = 42673664 + 16010828,
            T1X1017 = 42702336 + 16007852,
            T1XL1017 = 42677248 + 16011148,
            T1X102 = 2228464 + 95631360,
            T1XL102 = 2228464 + 95634432, //
            // End Of Checks, Start Of Debug Offsets
            T1R100Debug = 0x5C5A,// (0x579F <- 00 to 01)
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
            TLL10XDebug = 0x1CD01E,   //! TEST ME
            T1X101Debug = 0x3B66CD,   // PC Debug Offsets (0x97 -> 0x8F)
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
        }
        public static void WriteByte(int[] offset, byte data) {
            foreach (int ofs in offset) {
                MainStream.Position = ofs;
                MainStream.WriteByte(data);
            }
        }
        public static byte ReadByte(int offset) {
            MainStream.Position = offset;
            return (byte)MainStream.ReadByte();
        }
        public static bool ByteCmp(int addr, byte dat) {
            MainStream.Position = addr;
            return (byte)MainStream.ReadByte() == dat;
        }
        public static bool ByteCmp(int addr, byte[] dat) {
            MainStream.Position = addr;
            byte[] DataPresent = new byte[dat.Length];
            MainStream.Read(DataPresent, 0, dat.Length);
            return DataPresent.SequenceEqual<byte>(dat);
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>
        #endregion

        #region Application-Wide Functions And Variable Declarations
        public static Control YellowInformationLabel;

        public static Point LastPos;
        public static int?[] Pages = new int?[5];
        public static Form MainForm;
        public static Form PopupBox;

        public static bool LastDebugOutputWasInfoString = false, LabelShouldFlash = false, FlashThreadHasStarted = false;

        public static Font MainFont = new Font("Franklin Gothic Medium", 6.5F, System.Drawing.FontStyle.Bold);
        public static void SetPageInfo(Form f) {
            YellowInformationLabel = f.Controls.Find("Info", true)[0];
            f.Location = LastPos;
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
            SetPageInfo(ActiveForm);
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
                Dev.DebugOut($"Pages[i]: {Pages[i]}");
                Pages[i] = null;
                break;
            }
        }

        public static void MakeTextBox(string Text) { //!

            if (Dev.REL) {
                MessageBox.Show(Text, "CSTM Text Box Not Centered Yet, Using WIN MessageBox For Now");
                return;
            }

            if (PopupBox != null && PopupBox.Name != "") {
                PopupBox.Close();
                PopupBox.Name = "";
                return;
            }

            Point ParentPos = ActiveForm.Location;

            Label Label = new Label {
                ForeColor = PopupBox.ForeColor = Color.White,
                BackColor = Color.Gray,
                Font = MainFont,
                TextAlign = ContentAlignment.MiddleCenter
            };
            PopupBox = new Form();
            PopupBox.BackColor = Color.Gray;
            PopupBox.Controls.Add(Label);
            switch (ActiveForm.Name) { // Center Based On Active Form
                default:
                    Dev.DebugOut("Page Unknown, Default Location Used");
                    PopupBox.Location = new Point(100, 300);
                    return;
                case "EbootPatchHelpPage":
                    PopupBox.Location = new Point(MainForm.Location.X + 50, MainForm.Location.Y + 300);
                    break;
            }
            PopupBox.Size = new Size(200, 110);
            Label.Location = new Point(1, 1);
            Label.Size = new Size(PopupBox.Size.Width - 2 , PopupBox.Size.Height - 3);
            Label.Text = Text;
            PopupBox.Name = "PopupBox";
            PopupBox.FormBorderStyle = FormBorderStyle.None;
            PopupBox.Show();
            PopupBox.Location = new Point(ParentPos.X + 75, ParentPos.Y + 150);
        }


        /// <summary>Set The Text of The Yellow Label At The Bottom Of The Form</summary>
        public static void SetInfoString(string s) => YellowInformationLabel.Text = s;

        /// <summary>Highlights A Control In Yellow With A > Preceeding It When Hovered Over</summary>
        /// <param name="PassedControl">The Control To Highlight</param>
        /// <param name="HoverOrLeave">0 If Hovering</param>
        public static void HoverLeave(Control PassedControl, byte HoverOrLeave) { //! Fix Readability
            CurrentControl = PassedControl.Name;
            PassedControl.ForeColor     = HoverOrLeave == 0 ? Color.FromArgb(255, 227, 0) : Color.FromArgb(255, 255, 255);
            PassedControl.Text          = HoverOrLeave == 0 ? $">{PassedControl.Text}"    : PassedControl.Text.Substring(PassedControl.Text.IndexOf('>') + 1);
            PassedControl.Size = new Size(HoverOrLeave == 0 ? PassedControl.Width + 9     : PassedControl.Width - 9, PassedControl.Height);

            if (!InfoHasImportantStr) SetInfoString("");
            if (HoverOrLeave == 1) MouseScrolled = 0;
        }

        /// <summary>Highlights A Control In Yellow With A > Preceeding It When Hovered Over, And Changes The Infno Label Text</summary>
        /// <param name="PassedControl">The Control To Highlight</param>
        /// <param name="InfoString">The String To Send If Hovered Over</param>
        public static void HoverString(Control PassedControl, string InfoString) {
            CurrentControl = PassedControl.Name;
            PassedControl.ForeColor = Color.FromArgb(255, 227, 0);
            PassedControl.Text = $">{PassedControl.Text}";
            PassedControl.Size = new Size(PassedControl.Width + 9, PassedControl.Size.Height);
            InfoHasImportantStr = false;
            SetInfoString(InfoString);
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

        public class Dev {
#if !DEBUG
            public const bool REL = true;

#elif DEBUG
            public const bool REL = false;
            static int TimerTicks = 0, OutputStringIndex = 0;


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
                            }
                            break;
                    }                        
                }
            }

            public static string[] OutputStrings;
            public static int ShiftIndex = 0;


            public static Thread DebuggerThread = new Thread(new ThreadStart(UpdateConsoleOutput));
            public static void DebuggerInfo() => DebuggerThread.Start();
#endif

            public static void UpdateConsoleOutput() { if (REL) return;
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
                    while (OriginalConsoleScale == new Point(WindowHeight, WindowWidth)) {
                        int StartTime = TimerTicks, Cursor = 0, String = 0; Form frm = ActiveForm;

                        string[] Output = new string[] {
                            $"Build: {Build} | ~{Interval}ms | {OutputStrings.Length} ({OutputStringIndex})",
                            $"Form: {(ActiveForm != null ? ActiveForm.Name : "Console")}",
                            "",
                            $"MouseIsDown: {MouseIsDown} | MouseScrolled: {MouseScrolled}",
                            $"MousePos: {MousePosition}",
                            "",
                            $"Pages: {(Pages[0] == null ? "null" : $"{Pages[0]}")}, {(Pages[1] == null ? "null" : $"{Pages[1]}")}, {(Pages[2] == null ? "null" : $"{Pages[2]}")}, {(Pages[3] == null ? "null" : $"{Pages[3]}")}",
                            $"Active Page ID: {Page} | InfoHasImportantString: {InfoHasImportantStr}",
                            $"MainStream: {(MainStreamIsOpen ? MainStream.Name : "null")}",
                            $"{(MainStreamIsOpen ? $"Length: {(MainStream.Length.ToString().Length > 6 ? $"{MainStream.Length.ToString().Remove(2)}MB" : $"{MainStream.Length} bytes")} | Read: {MainStream.CanRead} | Write: {MainStream.CanWrite}" : null)}"
                        };

                        for (; String < Output.Length ; String++) { CursorTop = Cursor++; Write(BlankSpace(Output[String])); }

                        CursorTop = MainStreamIsOpen? Cursor+=1: Cursor;
                        foreach (string msg in OutputStrings)
                        Write(BlankSpace(msg), Cursor++);

                        Interval = TimerTicks - StartTime;
                        }
                    }
                catch (System.ObjectDisposedException) { }
                Clear();
                goto Begin_Again;
                #endif
            }
            public static void DebugOut(string s) { if (REL) return;
            #if DEBUG
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
            public static string BlankSpace(string String) {
                #if !DEBUG
                return string.Empty;

                #elif DEBUG
                if (String == null) return "";
                string Blanks = string.Empty;
                for (int i = BufferWidth - String.Length; i > 0; i--)
                    Blanks += " ";
                String += Blanks;
                return String;
                #endif
            }
        }
    }
}
