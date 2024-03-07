using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using static Dobby.Dev;

namespace Dobby {
    public class Common : Main {
        //#error version
        #pragma warning disable CS0472

        // Spacing:
        // Info & Back Btn; Info: Form.Size.Y - Info.Size.Y | BackBtn Pos: (Info Vertical Pos - BackBtn.Size.Y - 3)

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
      "* 3-beta.25.76.177 | I have no idea anymore. new feature tho",
           "* 3.26.77.180 | Arbitrarily Increased Build Number As I've Forgotten Everything I've Done. Changed More Than The Increase Might Imply. Don't Kid Drugs, Do",
           "* 3.26.77.192 | Fixed A String In ExecutableNames Array that I for some reason stopped typing mid-way, EbootPatchPage GroupBox Adjust, Added Uncharted Pointers, Seperated Debug Offsets & Pointers A Bit More",
           "* 3.26.78.204 | Added A DebugMemoryWrite Function TO TOggle Shit Quickly, Added InfiniteAmmo As A QOL Option, And More UC4 identifiers up to 1.12",
           "* 3.26.79.205 | Added the ability to send the ps4debug oayload with W then S, Removed Infinite Ammo And Invincible Player As PS4QOLPage Options, 'cause Natives go brr",
           "* 3.26.80.208 | Fixed UC3 1.00 Debug Offsets, One Was Wrong And The Other Was Missing (how did I manage that? only the dev menu bool was right) Reordered UC1 Debug Offsets To Make It Appear To Work Slightly faster (Enables FPS First Now lol), Misc tweaks to debug functions",
           "* 3.26.80.208 | Formatting ",
           "* 3.27.80.208 | Deleted Second PC Button On Main Form.",
           "* 3.28.84.210 | Reworked Connection Method To Be On Another Thread, and added an asynchronous function to wait for a proper connection before trying to write to memory, Fleshed Out CheckGameVersion code, Fixed ToggleAlt function and related code",
           "* 3.28.85.213 | Made More PS4Debug Methods Asynchronous, Forgot a Couple",
           "* 3.28.86.219 | Working More On PS4QOLPatchPage",
           "* 3.28.88.228 | Added Proper Support For All Lost Legacy Versions, Added A Check To Reset The Page Before Repeat BrowseBtn Uses On PS4QOLPatchesPage, Misc Changes",
           "* 3.28.88.229 | Adeed Missing VersionIndex++, Still Need To Add TLL MP 1.08 Debuug",
           "* 3.28.90.234 | Finished TLL Debug, Replaced Hardcoded Offsets With Method To Read Current Memory Address From Executable Space; Will Apply To Other Games' Toggle Functions For Consistency Later On. Other Miscellaneous Changes",
           "* 3.28.90.236 | Minor Changes, Comments",
           "* 3.28.91.240 | Added Uncharted 4 Check To GetGameVersion Up To 1.12, Plus 1.3X. Shortened PS4Debug Successful Connect Dialogue To Fit Form",
           "* 3.28.91.243 | Minor Code Tweaks",
           "* 3.28.92.249 | Replaced UC4 PS4DBG Checks, Supports All But The Missing 1.28 executables. Need To Add Pointer Addresses Next, Added up to 1.21 MP",
           "* 3.28.92.252 | Added for-some-reason missing exception handling to payload sender button. removed unneccessary debug text and fixed output length",
           "* 3.28.93.253 | Replaced References To IPBOX_E.Text In Static Functions To PS4DebugPage.IP() calls to avoid having to change the control to static every time the designer f*cks it up. Renamed to IPBOX",
           "* 3.28.93.254 | Added The Remaining Uncharted 4 Debug Pointer Addresses",
           "* 3.28.94.256 | Fixed Uncharted 4 PS4 Debug Arrays- I Was Tired. They Were NOT Finished. Other Misc Changes",
           "* 3.28.95.260 | Replaced Inconsistent Memory Tlou2 Debug Addresses With Addresses To The Base Pointer It's Read From. Other Misc Stuff",
           "* 3.28.96.262 | Removed Info String On Control Hover From Most PS4DebugPage Buttons, Going To Use Info Label For Status Only",
           "* 3.28.97.264 | Fixed Some UC3 Addresses That Were Somehow Missing",
           "* 3.28.97.267 | HoverString For Ignore TitleID Button, Misc Formatting Changes",
           "* 3.29.98.270 | Replaced Method For Checking Games With Similar Hash Function To PS4DebugPage, As Checking 0x60 Doesn't Give Different Results For Each exe Once All Are Supported. Related Changes, Formatting",
           "* 3.29.99.271 | Commented Out Old Group Of Labeled Int32 Checks Used In EbootPatchPage, Replaced With More Thorough Version Supporting Every Executable It Needs To And Replaced EbootPathPageCheck ints with them",
           "* 3.29.99.277 | Added Try/Catch For EbootPatchPage Stream Creation In Case Same File Is Selected Twice In A Row, Misc Changes And Formatting",
          "* 3.29.100.281 | Added New UC4 1.00 - 1.33 Debug 0xEB/0x75 Offsets (UC4 MP Beta 1.00 & 1.09 Still Missing, All Others Only Need Testing), Misc Changes. Formatting",
          "* 3.29.102.281 | Added UC4 MP Beta Pointer Addresses, Replaced SINGLE Harcoded RAM Address (tf?), Added Params For UC4 MP Beta Detection On PS4DebugPage, Replaced Two Outright Wrong Title ID's For UC4, And Added One For TlouR | Retroactively fixed Previous Build #, I Didn't update It Correctly.",
          "* 3.29.103.285 | Added Missing UC4 MP Beta Switch Case For PS4DebugPage, Game Would Never Have Been Detected :/. Also Added Error Popups In Case Game Check Fails (Backported .elf go brr)",
          "* 3.29.103.288 | Removed Title ID From UC4 MP Beta Game ID, Formatting. Minor Debug Output Tweak",
          "* 3.29.103.289 | Misc Changes",
          "* 3.29.103.291 | Deleted Useless Check In BrowseBtn Function I Forgot About. Comments, Misc Changes",
          "* 3.29.105.294 | Deleted Ueless/Outdated Code, Commented Out One I Wanna Keep For Sh*ts And Giggles. Reworked EbootPatchPage Restored Debug Functions, Misc Changes",
          "* 3.30.109.304 | PkgCreationPage Base Creation. Made The TextBox In EbootPatchPage Actually Functional, Moved GetGameID() And AssignButtonText() Part To Seperate Function Below. Stopped Path Boxes From Getting MoveForm Functionality So the User Can Drag-Select The Text, Comments, Other Crap",
          "* 3.31.109.304 | PkgCreationHelpPage Created",
          "* 3.31.109.306 | Strikeout For Misc Patches Button, Misc Debug Function Fix",
          "* 3.31.110.307 | Updated Contact Info",
          "* 3.31.112.308 | Fixed Tlou2 Debug Offset Assignment, Copy Pasted Cases Still All Had 1.00. Fixed Tlou2 Custom Debug novis Patch, I Copied The Default Hex Data...",
          "* 3.31.112.311 | Added Missing \" Trim From Path Names If The ExecutablePathBox Is Pasted To Directly (Where did it go? I already did that), Misc Changes",
          "* 3.33.113.315 | Font Changes, PkgCreationHelp Page Initial Creation And Partial Completion, Finished EbootPatchHelp Page I Forgot Was Hilariously Unfinished But Still Accessible. Misc Changes, Comments",
          "* 3.33.115.323 | Added Page Id Variable For Readability, Formatting For Many Pages, Comments, Other Changes My Dumb Arse Can't Recall Fully",
          "* 3.33.116.325 | Added Click Functionality To PkgCreationPage Path Labels 'Cause Why Not, Misc Changes",
          "* 3.33.117.325 | Added Underline On Path Label Hover For PkgCreationPage Path Labels",
          "* 3.33.117.325 | Misc Changes",
          "* 3.33.119.325 | Fixed Missing DebugModePointerOffset Assignment For T1R and T2; My Bad.",
          "* 3.33.120.326 | Added Missing AddControlEventHandlers(Controls) In Ps4DebugHelpPage Class init, Misc Formatting.",
          "* 3.34.120.326 | Initial Gp4CreationPage Creation",
          "* 3.34.121.327 | Basic Gp4CreationPage Work- Not Even Remotely Finished, Just Got The Basic Layout Done- Zero Functionality Yet. Removed A Few Prints",
          "* 3.34.122.331 | Created Basic Popup TexBox Function, Minor Changes",
          "* 3.34.122.334 | Minor Popup TexBox Work, Comments",
          "* 3.34.123.336 | Misc Changes",
          "* 3.34.123.337 | Misc Fixes",
          "* 3.34.125.340 | Lots Of MiscPatchesPage Work, Misc Changes, Comments And Formatting",
          "* 3.34.125.342 | Minor MiscPatchesPage Work; Adding BootSettings Function.",
          "* 3.34.126.345 | PS4MiscPatches Page Mostly Finished, Need To Fix For Resizing Though. Other Misc Changes",
          "* 3.35.126.346 | Finished PS4MiscPatchPage Dynamic Buttons' Form Resizing Crap, Misc Changes",
          "* 3.35.126.347 | Small Change To Fix PKG Creation; I Forgot To Add \"'s In Case Any Paths Have Spaces...",
          "* 3.35.126.348 | GP4CreationPage Patch; New gp4 instance was being created pre-build for some reason, resetting all gp4 options",
          "* 3.35.126.349 | Main Page Control Spacing Fix",
          "* 3.35.126.350 | Added Warning To GP4 Creation Page As Base Game .pkg's Are Broken Still- I Haven't Got The Chunk Crap Added",
          "* 3.35.126.351 | Deleted Redundant Button On wip Form",
          "* 3.35.130.358 | Different Help Page Fonts, Homebrew Store Link. Misc Background Changes, Comments",
          "* 3.35.131.360 | Label Fix, App was cutting out my own alias on the credits page, Misc Changes",
          "* 3.35.133.363 | Deleted Unused Page; Deleted Unfinished Item. Replaced Border In PC Patch Page With Dynamic One. Added Border Func To Common.cs. Misc Changes",
          "* 3.36.133.363 | Added Newer T2 Custom Menu Patch (1.08/1.09)",
          "* 3.36.133.364 | Font Fix",
          "* 3.36.136.365 | Updated T2 Custom Debug, Added Formatting Script to Source JIC; Other Misc Changes",
          "* 3.36.137.366 | Fixed EbootPatchPage Action Info Output So It's Not Applied To The Hover Info Label Instead of The Game Info One, Other Changes (I'm Forgetful, who cares)",
          "* 3.36.138.370 | EbootPatchHelpPage Tweaks, Minor background changes",
          "* 3.36.140.372 | PS4MiscPatchesPage Work, EbootPatchHelpPage: fixed double file load",
          "* 3.36.141.375 | More PS4MiscPatchesPage Work, Tweaks To Related EbootPatchPage, Removed Redundant Variable Assignment. My bad.",
          "* 3.36.143.380 | Renamed W.I.P. Page (PS4MiscPatchesPage => PS4MenuSettingsPage) And Related Controls, As Well As A Few Unrelated Ones. Misc. Changes",
          "* 3.36.144.380 | AppendControlVariable POC",
          "* 3.36.145.383 | Added Tlou 2 1.07 Custom Menu, Other Misc Changes",
          "* 3.37.147.388 | Slightly Darkened All Form Background Colours, Added Button Class \"Overload\" (VarButton) To Store Button Variables For Simpler Access. Created DrawButtonVar() Function For Appending Variables To VarButtons. Dynamic Button Function Work. Other Random Crap",
          "* 3.37.148.392 | More Dynamic Patch Button Work",
          "* 3.37.150.403 | Added Many Pointers And Created Jagged Array To Store Them Better",
          "* 3.37.152.405 | Reworked Misc Patch Page Event Handlers, Other Misc Changes",
          "* 3.38.154.440 | Debug Output Overhaul, Misc Changes",
          "* 3.38.159.445 | Replaced BorderFunc And Replaced All Static Borders, Moved Platform Labels, Other Crap I've Forgotten",
          "* 3.38.161.447 | Removed Unused Page Function, Other Work",
          "* 3.39.165.451 | Reworked Several Functions, Moved Dev Class In TO Seperate File. Other Blah Blah Blah",
          "* 3.40.166.455 | Deleted Page, Moved More Crap",
          "* 3.40.172.470 | Large Code Cleaup, Deleted Resource, Reworked And Cleaned Up PCDebugMenuPatchPage, Added PaintBorder() Function Call Inside Of EventHandler Func And Removed All Instances That Came Before Said Function Originally, Many Minor Tweaks/Changes",
          "* 3.40.175.474 | PS4MenuSettingsPatchPage Work (Reworked Page Structure, Made Some Other Minor Changes). Fixed Designer Bs With VarButton class",
          "* 3.40.176.478 | Minor EbootPatchPage Fix, Debug Tweaks",
          "* 3.40.178.481 | PS4MenuSettingsPatchPage Work, Renamed Some Game Identifiers (Ones Used To Check Against GetGameID())",
          "* 3.40.179.484 | PS4MenuSettingsPatchPage Work, Event Handler Fix, Debug Text Fix",
          "* 3.40.182.489 | PS4MenuSettingsPatchPage Work, Debug Output Fix",
          "* 3.40.182.491 | PS4MenuSettingsPatchPage Work, Removed Old Debug Output Calls",
          "* 3.42.183.494 | PS4MenuSettingsPatchPage Now Functions, Pointers Still Need To Be Added For The Majority Of Cases, Debug Output Changes",
          "* 3.42.184.496 | Replaced BootSettings data with updated code, Debug Output Tweak",
          "* 3.42.186.501 | Small BootSettings Fix, Basic Formatting Changes",
          "* 3.43.188.507 | Menu Settings Page Work.",
          "* 3.43.190.510 | Added Newer T2 1.07 Custom Menu. Menu Settings Page Work.",
          "* 3.43.191.511 | Fixed Issue With Boot Settings Func",
          "* 3.43.192.516 | PS4 Menu Settings Page - Added Some More Pointers. Debug Edits",
          "* 3.43.193.517 | EbootPatchPage Line Adjustment",
          "* 3.43.194.519 | Moved Some Common Variables To Where They Should've Been, Deleted Useless Ones",
          "* 3.43.194.520 | Line Adjustment",
          "* 3.43.195.522 | Log Window Fix (Was For Some Reason Calling AddControlEventHandlers(ControlCollection C) And The Border Function Was Deleting Things)",
          "* 3.43.199.527 | Changed Exit And Minimize Button Fonts Back, Line Fix On Another Page. Misc Patches Page Work (Changing Method For Enabling Buttons To Be Based On What's Available, Rather Than Manually Specifying Each Button To Be Enabled For Each Case- Jfc What Was I Thinking Before)",
          "* 3.43.203.540 | Debug Output Changes, Plenty Of Other Crap I Forgot. Go Away",
          "* 3.43.203.540 | PS4 Menu Settings Page Universal Patch Section Work, Removed Some Debug Output Calls For Finished Function",
          "* 4.46.212.560 | PS4 Menu Settings Page Release, Code Restructuring For Most Pages. (Moved PS4DebugPage Related Variables From Common.cs In To PS4DebugPage.cs, Small Tweaks), Log Window Fixes" +
                          " (Properly Follows The Parent Form Now Instead Of Snapping To It). Standardized Seperator Label Heights And Adjusted Various Control Positions Application-Wide.",
          "* 4.46.213.561 | Added BootSettings Function Data For T1R 1.00, Most Pointers Still Missing",
          "* 4.46.213.563 | Label Font Size Fix And Position Adjustment",
          "* 4.46.215.583 | Standardized MainLabel, SeperatorLabel0, And Exit/Minimize Buttons, Positions And Sizes (Excuding Width For The Former Two) Shrumk Minimize/Exit Button Fonts (8f => 7.5f). Replaced The Control Hover Highlight With Mouse Down highlight To More Match ND's DMenu (Might Add Boolean Option Highlight To Match It Further)",
          "* 4.46.216.583 | HoverLeave Function No Longer Widens Controls If They Already FIt The Form Width Rather Than Only Themselves",
          "* 4.46.217.585 | Style Testing Wip, Debug Fix",
          "* 4.46.218.585 | Temporarily Removed GP4 Creation Page Access, Going To Replace With Automatic GP4 Creation Until Gp4 lib is fleshed out",
          "* 4.47.224.603 | PkgCreationPage Work, Changed Seperator Line Positioning And Sizing Replaced Static Exit/Minimize Buttons With Dynamic Initialization During Form Init (Through AddEventHandlersToControls()), Other Misc Changes",
          "* 4.47.225.609 | PkgCreationPage Work, Trying To Get A \"Good\" Look Down "




            // TODO:
            // * MAJOR
            //  - Create Remaining Two Help Pages
            //  - Refactor EbootPatchPage Code. Check The Others, Too
            //  - Gp4CreationPage Unfinished, Only Base Functionality Added
            // * MINOR 
            //  - Label Flash Stays On White If Inturrupted at the right time
            //  - Update PKG Creation Page To Be More Like GP4 Creation Page
            //  - Standardize Help Page Styles
            //  - Standardize Info Label And Back Button Positioning, As Well As Space Between Controls
            //  - PS4DebugPage Consistency Fix (Can't Seem To Reproduce? [The Bug, I Mean. Not That I Don't Want The Other Thing])
        };
        public static string Build = ChangeList[ChangeList.Length - 1].Substring(2).Substring(0, ChangeList[ChangeList.Length - 1].IndexOf('|') - 3); // Trims The Last ChangeList String For Latest The Build Number

        ////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///                 Design Bullshit                  \\\
        ///__________________________________________________\\\
        /// * FONT USAGE: (Use Bold For Both)                \\\
        /// - Use Franklin Gothic 10pt For Basic Controls    \\\
        /// - Use Cambria 9.75pt For Information Pages       \\\
        ///                                                  \\\
        /// * Borders And Seperator Lines                    \\\
        /// - Keep Controls At Least 1 Pixel From Form Edge  \\\
        /// - Lines Should Be 2 Pixels From Either Form Edge \\\
        ////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\





        //////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--  MAIN APPLICATION VARIABLES & Functions  --\\\
        //////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Application-Wide Functions And Variable Declarations

        // Custom Button Class So I Can Attach A Value To Them. This Is Probably The Wrong Way To Do This, But Whatever
        public class VarButton : Button { public object Variable; }

        public enum PageID : int {
            MainPage = 0,
            PS4DebugPage = 1,
            PS4DebugHelpPage = 11,
            EbootPatchPage = 2,
            EbootPatchHelpPage = 21,
            PS4MenuSettingsPage = 3,
            PS4MenuSettingsHelpPage = 31,
            PkgCreationPage = 4,
            PkgCreationHelpPage = 41,
            Gp4CreationPage = 5,
            Gp4CreationHelpPage = 51,
            PCDebugMenuPage = 6,
            InfoHelpPage = 7,
            CreditsPage = 8,
            PlaceholderPage = 0xbad
        }


        public static string
            CurrentControl,
            TempStringStore,
            ActiveGameID = "UNK"
        ;

        public static int Game, index;
        public static PageID Page;
        public static PageID?[] Pages = new PageID?[5];
        public static bool
            MouseScrolled,
            MouseIsDown,
            FormActive,
            InfoHasImportantStr,
            IsPageGoingBack,
            LastMsgOutputWasInfoString,
            LabelShouldFlash,
            FlashThreadHasStarted,
            IsActiveFilePCExe,
            MainStreamIsOpen
        ;

        public static byte[] buffer;

        public static Point LastPos, MousePos, MouseDif;
        public static Point[] OriginalControlPositions;

        public static Size OriginalFormScale = Size.Empty;
        public static Size OriginalBorderScale;

        public static Form MainForm, PopupBox;
        public static Control YellowInformationLabel;
        public static GroupBox PopupGroupBox;

        public static TcpClient tcp_client;
        public static NetworkStream net_stream;
        public static FileStream MainStream;

        public static Font MainFont = new Font("Consolas", 9.75F, FontStyle.Bold);
        public static Color MainColour = Color.FromArgb(100, 100, 100);



        ////////////////////\\\\\\\\\\\\\\\\\\\
        ///--  Basic Form Event Handlers  --\\\
        ////////////////////\\\\\\\\\\\\\\\\\\\
        #region Basic Form Event Handlers
        private static void ExitBtn_Click(object sender, EventArgs e) {
#if DEBUG
            LogWindow.Exit();
#endif
            MainStream?.Dispose();
            Environment.Exit(0);
        }
        private static void ExitBtnMH(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 227, 0);
        private static void ExitBtnML(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);
        private static void MinimizeBtn_Click(object sender, EventArgs e) => ((Control)sender).FindForm().WindowState = FormWindowState.Minimized;
        private static void MinimizeBtnMH(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 227, 0);
        private static void MinimizeBtnML(object sender, EventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);

        public static void ControlHover(object sender, EventArgs e) => HoverLeave((Control)sender, true);
        public static void ControlLeave(object sender, EventArgs e) => HoverLeave((Control)sender, false);
        public static void MouseDownFunc(object sender, MouseEventArgs e) {
            MouseIsDown = true; LastPos = ActiveForm.Location;
            MouseDif = new Point(MousePosition.X - ActiveForm.Location.X, MousePosition.Y - ActiveForm.Location.Y);
        }
        public static void MouseUpFunc(object sender, MouseEventArgs e) { MouseScrolled = false; MouseIsDown = false; }

        public static void MoveForm(object sender, MouseEventArgs e) {
            if(!MouseIsDown)
                return;

            ActiveForm.Location = new Point(MousePosition.X - MouseDif.X, MousePosition.Y - MouseDif.Y);
            ActiveForm.Update();

#if DEBUG
            LogWindow.MoveLogToAppEdge(ActiveForm.Location);
#endif
        }
        #endregion


        ///////////////////\\\\\\\\\\\\\\\\\\
        ///--   Form Drawing Functions  --\\\
        ///////////////////\\\\\\\\\\\\\\\\\\
        #region Form Drawing Functions
        /// <summary> Highlights A Control In Yellow With A > Preceeding It When Hovered Over </summary>
        /// <param name="PassedControl">The Control To Highlight</param>
        /// <param name="EventIsMouseEnter">Highlight If True</param>
        public static void HoverLeave(Control PassedControl, bool EventIsMouseEnter) {
            int ArrowWidth;

            //if(!InfoHasImportantStr & !EventIsMouseEnter) SetInfoLabelText("");
            
            try {
                ArrowWidth = (int)PassedControl.CreateGraphics().MeasureString(">", PassedControl.Font).Width;
            }
            catch(ObjectDisposedException) { return; }

            if(MouseScrolled = EventIsMouseEnter) {
#if DEBUG
                HoveredControl = PassedControl;
#endif
                CurrentControl = PassedControl.Name;
                PassedControl.MouseDown += HighlightItemOnCLick;
                PassedControl.MouseUp   += ResetItemHighlight;
            }
            else {
                PassedControl.MouseDown -= HighlightItemOnCLick;
                PassedControl.MouseUp   -= ResetItemHighlight;
                SetInfoLabelStringOnControlHover(PassedControl);
            }

            PassedControl.Text = EventIsMouseEnter ? ($">{PassedControl.Text}") : PassedControl.Text.Substring(1);

            if(PassedControl.Size.Width + PassedControl.Location.X != PassedControl.Parent.Size.Width - 1)
                PassedControl.Size = new Size(EventIsMouseEnter ? PassedControl.Width + ArrowWidth : PassedControl.Width - ArrowWidth, PassedControl.Height);
        }

        private static void HighlightItemOnCLick(object sender, MouseEventArgs e) => ((Control)sender).ForeColor = Color.FromArgb(255, 227, 0);
        private static void ResetItemHighlight(object sender, MouseEventArgs e)   => ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);

        /// <summary> Draw The Variable Tied To The Sender Control, Aligned To The Right Of The Form
        ///</summary>
        public static void DrawButtonVar(object sender, PaintEventArgs e) {
            var control = sender as VarButton;
            var Variable = control.Variable?.ToString();

            var X_Pos = (int)(control.Width - e.Graphics.MeasureString(Variable, control.Font).Width - 5);

            e.Graphics.DrawString(Variable, MainFont, Brushes.LightGreen, new Point(X_Pos, 5));
        }

        ///<summary> Form Border Pen </summary>
        public static Pen pen = new Pen(Color.White);
        ///<summary> Create And Apply A Thin Border To The Form </summary>
        public static void PaintBorder(object sender, PaintEventArgs e) {
            var ItemPtr = (Form)sender;
            
            Point[] Border = new Point[] {
                Point.Empty,
                new Point(ItemPtr.Width-1, 0),
                new Point(ItemPtr.Width-1, ItemPtr.Height-1),
                new Point(0, ItemPtr.Height-1),
                Point.Empty
            };

            e.Graphics.Clear(Color.FromArgb(100, 100, 100));
            e.Graphics.DrawLines(pen, Border);
        }

        /// <summary> Create And Apply A Thin Line From One End Of The Form To The Other (placeholder code atm)
        ///</summary>
        public static void PaintSeperatorLine(object sender, PaintEventArgs e) {
            var ItemPtr = (Label)sender;

            if(ItemPtr.Size.Height != 15 && MsgOut($"Label On Page {ItemPtr.Parent.Name} Has An Ivalid Height ({ItemPtr.Size.Height})")!=null)
                ItemPtr.Size = new Size(ItemPtr.Size.Width, 15);

            var LineVerticalPos = 9; 
            Point[] Line = new Point[] {
                new Point(1, LineVerticalPos),
                new Point(ItemPtr.Parent.Size.Width - 1, LineVerticalPos)
            };

            e.Graphics.Clear(Color.FromArgb(100, 100, 100));
            e.Graphics.DrawLines(pen, Line);
        }



        public delegate void LabelFlashDelegate(string str);
        public static readonly LabelFlashDelegate Yellow = new LabelFlashDelegate(FlashYellow);
        public static readonly LabelFlashDelegate White = new LabelFlashDelegate(FlashWhite);
        public static Thread FlashThread = new Thread(new ThreadStart(FlashLabel));
        private static void FlashLabel() {
            while(!LabelShouldFlash) { Thread.Sleep(7); }
            try {
                for(int Flashes = 0; Flashes < 8; Flashes++) {
                    ActiveForm?.Invoke(White, "cracker");
                    Thread.Sleep(135);
                    ActiveForm?.Invoke(Yellow, "asian");
                    Thread.Sleep(135);
                }
            }
            catch(Exception) {
                MsgOut("Killing Label Flash");
            }
            LabelShouldFlash = false;
            FlashLabel();
        }
        private static void FlashWhite(string str) {
            try {
                ActiveForm.Controls.Find("GameInfoLabel", true)[0].ForeColor = Color.White;
                ActiveForm?.Update();
            }
            catch(Exception){ FlashThread.Abort(); }
        }
        private static void FlashYellow(string str) {
            try {
                ActiveForm.Controls.Find("GameInfoLabel", true)[0].ForeColor = Color.FromArgb(255, 227, 0);
                ActiveForm?.Update();
            }
            catch(Exception){ FlashThread.Abort(); }
        }

        #endregion



        #region Basic Form Functions

        /// <summary>
        /// Loads The Specified Page From The PageId Group (E.g. ChangeForm(PageID.PS4MiscPageId))
        /// </summary>
        /// <param name="Page"> Page To Change To </param>
        /// <param name="IsPageGoingBack"> Whether We're Returning Or Loading A New Page </param>
        public static void ChangeForm(PageID Page) {
            LastPos = ActiveForm.Location;
            var ClosingForm = ActiveForm;

            if(!IsPageGoingBack) {
                for(int i = 0; i < 5; i++) {
                    if(Pages[i] == null) {
                        Pages[i] = Common.Page;
                        break;
                    }
                }
            }
            else IsPageGoingBack ^= true;
            Form NewPage = null;

            Common.Page = Page;

            switch(Page) {
                case PageID.MainPage:
                    NewPage = MainForm;
                    break;
                case PageID.PS4DebugPage:
                    NewPage = new PS4DebugPage();
                    break;

                case PageID.PS4DebugHelpPage:
                    NewPage = new PS4DebugHelpPage();
                    break;

                case PageID.EbootPatchPage:
                    NewPage = new EbootPatchPage();
                    break;

                case PageID.EbootPatchHelpPage:
                    NewPage = new EbootPatchHelpPage();
                    break;

                case PageID.PS4MenuSettingsPage:
                    NewPage = new PS4MenuSettingsPage();
                    break;

                case PageID.PS4MenuSettingsHelpPage:
                    //PS4MiscPatchesHelpPage PS4MiscPatchesHelpPage = new PS4MiscPatchesHelpPage();
                    //PS4MiscPatchesHelpPage.Show();
                    break;

                case PageID.PkgCreationPage:
                    NewPage = new PkgCreationPage();
                    break;

                case PageID.PkgCreationHelpPage:
                    NewPage = new PkgCreationHelpPage();
                    break;

                case PageID.Gp4CreationPage:
                    NewPage = new Gp4CreationPage();
                    break;

                case PageID.Gp4CreationHelpPage:
                    break;

                case PageID.PCDebugMenuPage:
                    NewPage = new PCDebugMenuPage();
                    MessageBox.Show("Note:\nI'v Only Got The Executables For Either The Epic Or Steam Version, And I Don't Even Know Which...\n\nIf The Tools Says Your Executable Is Unknown, Send It To Me And I'll Add Support For It\nI Would Advise Alternate Methods, Though");
                    break;

                case PageID.PlaceholderPage:
                    MessageBox.Show("Nani The Fuck?");
                    Environment.Exit(1);
                    break;

                case PageID.InfoHelpPage:
                    NewPage = new InfoHelpPage();
                    break;

                case PageID.CreditsPage:
                    NewPage = new CreditsPage();
                    break;

                default: MsgOut($"{Page} Is Not A Page!"); break;
            }

            NewPage?.Show();
#if DEBUG
            LogWindow.SetParent(NewPage);
#endif

            YellowInformationLabel = ActiveForm.Controls.Find("Info", true)[0];
            ActiveForm.Location = LastPos;

            if(ClosingForm.Name == "Main") {
                MainForm = ClosingForm;
                ClosingForm.Hide();
                return;
            }

            ClosingForm.Close();
        }

        public static void ReturnToPreviousPage() {
            IsPageGoingBack ^= true;

            for(int i = 4; i >= 0; i--)
                if(Pages[i] != null) {
                    ChangeForm((PageID)Pages[i]);
                    Pages[i] = null;
                    break;
                }
            FormActive = false;
        }



        /// <summary> Buttons To Avoid Prepending The Hover Arrow To </summary>
        private static readonly string[] Blacklist = new string[] {
                "!!!",
                "ExitBtn",
                "MinimizeBtn",
                "LabelBtn",
                "CmdPathBox",
                "Gp4PathBox"
        };
        /// <summary>
        /// Apply Basic Event Handlers To Form And It's Items
        /// </summary>
        public static void ApplyEventHandlersToControl(object sender) {
            var Item = sender as Control;

#if DEBUG
            Item.MouseEnter += new EventHandler(DebugControlHover);
#endif

            Item.MouseDown += new MouseEventHandler(MouseDownFunc);
            Item.MouseUp += new MouseEventHandler(MouseUpFunc);

            if(Item.Name.Contains("Seperator") && sender.GetType() == typeof(Label))
                Item.Paint += PaintSeperatorLine;

            if(!Item.Name.Contains("PathBox")) // So You Can Drag Select The Text Lol
                Item.MouseMove += new MouseEventHandler(MoveForm);

            if((Item.GetType() == typeof(Button) || Item.GetType() == typeof(VarButton)) && !Blacklist.Contains(Item.Name)) {
                Item.MouseEnter += new EventHandler(ControlHover);
                Item.MouseLeave += new EventHandler(ControlLeave);
            }

            if(Item.GetType() == typeof(VarButton))
                Item.Paint += DrawButtonVar;
        }

        /// <summary>
        /// Mass-Apply Basic Event Handlers To Form And It's Items
        /// </summary>
        /// <param name="Controls"></param>
        public static void AddEventHandlersToControls(Control.ControlCollection Controls) { // Got Sick of Manually Editing InitializeComponent()

            Controls.Owner.Paint += PaintBorder;
            foreach(Control Item in Controls) {
                ApplyEventHandlersToControl(Item);

                if(Item.HasChildren) // Designer Adds Some Things To Other Controls Sometimes. I Am Lazy
                    foreach(Control Child in Item.Controls)
                        ApplyEventHandlersToControl(Child);
            }

            // Create Exit And Minimize Buttons, And Add Them To The Top Right Of The Form
            var Gray = Color.FromArgb(100, 100, 100);
            Button ExitBtn = new Button() {
                Location = new Point(Controls.Owner.Size.Width - 24, 1),
                Size = new Size(23, 23),
                Name = "ExitBtn",
                Font = new Font("Franklin Gothic Medium", 7.5F, FontStyle.Bold),
                Text = "X",
                FlatStyle = FlatStyle.Flat,
                BackColor = Gray,
                ForeColor = SystemColors.Control,
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Cross
            },
            MinimizeBtn = new Button() {
                Location = new Point(Controls.Owner.Size.Width - 47, 1),
                Size = new Size(23, 23),
                Name = "MinimizeBtn",
                Font = new Font("Franklin Gothic Medium", 7.5F, FontStyle.Bold),
                Text = "--",
                FlatStyle = FlatStyle.Flat,
                BackColor = Gray,
                ForeColor = SystemColors.Control,
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Cross,
            };
            
            MinimizeBtn.FlatAppearance.BorderSize = 0;
            Controls.Owner.Controls.Add(MinimizeBtn);
            ExitBtn.FlatAppearance.BorderSize = 0;
            Controls.Owner.Controls.Add(ExitBtn);
            MinimizeBtn.BringToFront();
            ExitBtn.BringToFront();

            MinimizeBtn.Click      += new EventHandler(MinimizeBtn_Click);
            MinimizeBtn.MouseEnter += new EventHandler(MinimizeBtnMH);
            MinimizeBtn.MouseLeave += new EventHandler(MinimizeBtnML);
            ExitBtn    .Click      += new EventHandler(ExitBtn_Click);
            ExitBtn    .MouseEnter += new EventHandler(ExitBtnMH);
            ExitBtn    .MouseLeave += new EventHandler(ExitBtnML);


            // Clear Info Label Text
            try { Controls.Owner.Controls.Find("Info", true)[0].Text = string.Empty; } catch(Exception){ MsgOut("Info Label Mising"); }
        }

        /// <summary>
        /// Set The Text of The Yellow Label At The Bottom Of The Form
        /// </summary>
        public static void SetInfoLabelText(string s) {
            if(ActiveForm != null)
            YellowInformationLabel.Text = s;
        }
        #endregion


        /// <summary> Add A Summary, You Lazy Fuck </summary>
        /// <returns> The Game Name And App Version Respectively </returns>
        public static int GetGameID(FileStream stream) {

            byte[] LocalExecutableCheck = new byte[160];

            // Make Sure The File's Actually Even A .elf
            stream.Position = 0;
            stream.Read(LocalExecutableCheck, 0, 4);
            if(BitConverter.ToInt32(LocalExecutableCheck, 0) != 1179403647)
                MessageBox.Show($"Executable Still Encrypted (self) | Must Be Decrypted/Unsigned");


            stream.Position = 0x5100; stream.Read(LocalExecutableCheck, 0, 160);
            var Hash = SHA256.Create();
            var HashArray = Hash.ComputeHash(LocalExecutableCheck);
            return BitConverter.ToInt32(HashArray, 0);
        }

        /// <summary> Write A Byte To The MainStream And Flush The Data </summary>
        public static void WriteByte(int offset, byte data) {
            if(MainStream == null) { MessageBox.Show($"No Active Data Stream To Write To ({MainStreamIsOpen})", $"Addr: {offset:X} Byte: 0x{data:X}"); return; }

            MainStream.Position = offset;
            MainStream.WriteByte(data);
            MainStream.Flush();
        }

        public static string GetGameLabelFromID(int GameID) {
            switch(GameID) {
                case UC1100: return "Uncharted 1 1.00";
                case UC1102: return "Uncharted 1 1.02";
                case UC2100: return "Uncharted 2 1.00";
                case UC2102: return "Uncharted 2 1.02";
                case UC3100: return "Uncharted 3 1.00";
                case UC3102: return "Uncharted 3 1.02";
                case UC4100: return "Uncharted 4 1.00";
                case UC4101: return "Uncharted 4 1.01";
                case UC4102: return "Uncharted 4 1.02";
                case UC4103: return "Uncharted 4 1.03";
                case UC4104: return "Uncharted 4 1.04";
                case UC4105: return "Uncharted 4 1.05";
                case UC4106: return "Uncharted 4 1.06";
                case UC4108: return "Uncharted 4 1.08";
                case UC4110: return "Uncharted 4 1.10";
                case UC4111: return "Uncharted 4 1.11";
                case UC4112: return "Uncharted 4 1.12";
                case UC4113: return "Uncharted 4 1.13";
                case UC4115: return "Uncharted 4 1.15";
                case UC4116: return "Uncharted 4 1.16";
                case UC4117: return "Uncharted 4 1.17";
                case UC4118: return "Uncharted 4 1.18 SP/MP";
                case UC4119: return "Uncharted 4 1.19 SP/MP";
                case UC4120MP: return "Uncharted 4 1.20 MP";
                case UC4120: return "Uncharted 4 1.20 SP";
                case UC4121MP: return "Uncharted 4 1.21 MP";
                case UC4121: return "Uncharted 4 1.21 SP";
                case UC4122MP: return "Uncharted 4 1.22 MP";
                case UC4122_23: return "Uncharted 4 1.22/23 SP";
                case UC4123MP: return "Uncharted 4 1.23 MP";
                case UC4124MP: return "Uncharted 4 1.24 MP";
                case UC4124_25: return "Uncharted 4 1.24/25 SP";
                case UC4125MP: return "Uncharted 4 1.25 MP";
                case UC4127_28MP: return "Uncharted 4 1.27/28 MP";
                case UC4127_133: return "Uncharted 4 1.27+ SP";
                case UC4129MP: return "Uncharted 4 1.29 MP";
                case UC4130MP: return "Uncharted 4 1.30 MP";
                case UC4131MP: return "Uncharted 4 1.31 MP";
                case UC4132MP: return "Uncharted 4 1.32/TLL 1.08 MP";
                case UC4133MP: return "Uncharted 4 1.33/TLL 1.09 MP";
                case UC4MPBETA100: return "Uncharted 4 MP Beta 1.00";
                case UC4MPBETA109: return "Uncharted 4 MP Beta 1.09";
                case TLL100MP: return "Uncharted Lost Legacy 1.00 MP";
                case TLL100: return "Uncharted Lost Legacy 1.00 SP";
                case TLL10X: return "Uncharted Lost Legacy 1.08/9 SP";
                case T1R100: return "The Last Of Us 1.00";
                case T1R109: return "The Last Of Us 1.09";
                case T1R110: return "The Last Of Us 1.10";
                case T1R111: return "The Last Of Us 1.11";
                case T2100: return "The Last Of Us 2 1.00";
                case T2101: return "The Last Of Us 2 1.01";
                case T2102: return "The Last Of Us 2 1.02";
                case T2105: return "The Last Of Us 2 1.05";
                case T2107: return "The Last Of Us 2 1.07";
                case T2108: return "The Last Of Us 2 1.08";
                case T2109: return "The Last Of Us 2 1.09";
                default: return $"Unknown Game ({GameID})";
            }
        }


        // TODO: this is fucking stupid, change it.
        /// <summary> Sets The Info Label String Based On The Currently Hovered Control </summary>
        /// <param name="Sender">The Hovered Control</param>
        public static void SetInfoLabelStringOnControlHover(Control Sender, float FontAdjustment = 10f) { // SetInfo
            string InfoLabelString = "";
            switch(Sender.Name) {
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
                // _______________
                //
                // Main Page
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
                // _______________
                //
                // PS4DebugPage
                //
                case "UC1Btn":
                    break;
                case "UC2Btn":
                    break;
                case "UC3Btn":
                    break;
                case "UC4Btn":
                    break;
                case "UC4MPBetaBtn":
                    InfoLabelString = "Supports: 1.09 - Use .bin Patch For 1.00";
                    break;
                case "T1RBtn":
                    break;
                case "T2Btn":
                    break;
                case "DebugPayloadBtn":
                    InfoLabelString = "Sends ctn123's Port Of PS4Debug";
                    break;
                case "ManualConnectBtn":
                    YellowInformationLabel.Font = new Font(YellowInformationLabel.Font.FontFamily, 9F);
                    InfoLabelString = "Tool Also Auto-Connects When An Option's Selected";
                    break;
                case "IgnoreTitleIDBtn":
                    InfoLabelString = "Enable This If You've Changed The Title ID";
                    break;
                // _______________
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
                case "PS4MenuSettingsPageBtn":
                    InfoLabelString = "Adds A Function To Write To Selected Settings On Game Boot";
                    break;
                // _______________
                //
                // PkgCreationPage
                //
                // _______________
                //
                // PkgCreationHelpPage
                //
                // _______________
                //
                // Gp4CreationPage
                //
                case "Gp4CreationPageBtn":
                    InfoLabelString = "A .gp4 Is Required For .pkg Creation";
                    break;
                    //
                    // Gp4CreationHelpPage
                    //
                    // _______________
                    //
                    // PS4MiscPatchesPage
                    //
                    // _______________
                    //
                    // PCExePatchPage
                    //
                    // _______________
                    //
                    // PCQOLPatchPage
                    //
                    // _______________
                    //
                    // InfoHelpPage
                    //
                    // _______________
                    //
                    // CreditsPage
                    //
                    // _______________
                    //
                    // PCQOLPatchPage
                    //
                    // _______________

            }
            SetInfoLabelText(InfoLabelString);
        }

        public static RichTextBox CreateTextBox(string Title) {
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

        private static void KillTextBox(object sender, MouseEventArgs e) => PopupGroupBox?.Dispose();
        #endregion



        public static void LoadPresentExecutableInStream(string OpenedFile) {
            MainStream?.Dispose();
            MainStream = File.Open(OpenedFile, FileMode.Open, FileAccess.ReadWrite);
        }

        /////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///-- DEBUG MODE OFFSETS AND GAME INDENTIFIERS --\\\
        /////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Debug Offsets & Game Identifiers
        public const int
            // Read 160 bytes at 0x5100 as SHA256 Then Checked As Int32 Because I'm An Idiot And Don't Feel Like Correcting It Since It Works
            UC1100 = -679355525,
            UC1102 = 104877429,
            UC2100 = 414674483,
            UC2102 = 216080152,
            UC3100 = 823868754,
            UC3102 = 1911044661,
            UC4100 = 308820129,
            UC4101 = -1879120502,
            UC4102 = 1084389925,
            UC4103 = 1009654146,
            UC4104 = 1174607918,
            UC4105 = 1397785573,
            UC4106 = 1880438911,
            UC4108 = -1521275605,
            UC4110 = 556134345,
            UC4111 = 533967079,
            UC4112 = -1876292260,
            UC4113 = 441673980,
            UC4115 = 1382306251,
            UC4116 = -1865276990,
            UC4117 = -2002709567,
            UC4118 = 1337597197,
            UC4119 = 853166708,
            UC4120MP = 948532543,
            UC4120 = 1044003518,
            UC4121MP = 1404274247,
            UC4121 = -538479879,
            UC4122MP = -605975924,
            UC4122_23 = 1849401718,
            UC4123MP = -959800645,
            UC4124MP = 1301857603,
            UC4124_25 = -1166682695,
            UC4125MP = -634367694,
            UC4127_28MP = -1449571981,
            UC4127_133 = -400040687, // 1.27+, SP exe Never Changed After 1.27 Released
            UC4129MP = -1725079303,
            UC4130MP = 931397679,
            UC4131MP = 1212014389,
            UC4132MP = 1923471472, // Also The Lost Legacy 1.08 MP
            UC4133MP = 486460629,  // Also The Lost Legacy 1.09 MP
            UC4MPBETA100 = 1813169088,  // CUSA04051
            UC4MPBETA109 = -1103269419, // CUSA04051
            TLL100MP = 469274180,
            TLL100 = -1269602830,
            TLL10X = 2141223617,  // UCTLL 1.08/1.09 SP Identical
            T1R100 = 306377542,
            T1R109 = -1391237605,
            T1R110 = -915963582,
            T1R111 = -866651344,
            T2100 = -1496529414,
            T2101 = -777844382,
            T2102 = -357372043,
            T2105 = -342416055,
            T2107 = 154664618,
            T2108 = 537380869,
            T2109 = 1174398197
        ;



        /// <summary> .elf Addresses For Enabling The Debug Mode In Various PS4 Naughty Dog Games<br/>[On: 0xEB]<br/>[Off: 0x74]</summary>
        public const int
            T1R100Debug = 0x5C5A,
            T1R109Debug = 0x61A0,
            T1R110Debug = 0x61A0,
            T1R111Debug = 0x61A0,
            T2100Debug = 0x1D6394,
            T2101Debug = 0x1D6414,
            T2102Debug = 0x1D6464,
            T2105Debug = 0x1D66A4,
            T2107Debug = 0x1D66B4,
            T2108Debug = 0x6181F4,
            T2109Debug = 0x6181F4,
            UC1100Debug = 0x102057,
            UC1102Debug = 0x102187,
            UC2100Debug = 0x1EB297,
            UC2102Debug = 0x3F7A26,
            UC3100Debug = 0x168EB7,
            UC3102Debug = 0x578227,
            UC4100Debug = 0x5257DA,       //! TEST ME
            UC4101_106Debug = 0x12980E,   //! TEST ME
            UC4108_111Debug = 0x1C738B,   //! TEST ME
            UC4112_113Debug = 0x1C7CAB,   //! TEST ME
            UC4115Debug = 0x41885E,       //! TEST ME
            UC4116Debug = 0x41886E,       //! TEST ME
            UC4117Debug = 0x4188DD,       //! TEST ME
            UC4118_119Debug = 0x1CCC36,   //! TEST ME
            UC4120MPDebug = 0x1CCDAA,     //! TEST ME
            UC4120SPDebug = 0x1CCC0A,     //! TEST ME
            UC4121MPDebug = 0x1CCE25,     //! TEST ME
            UC4121SPDebug = 0x1CCDEA,     //! TEST ME
            UC4122_125MPDebug = 0x1CCE25, //! TEST ME
            UC4122_125SPDebug = 0x1CCDEA, //! TEST ME
            UC4127_132MPDebug = 0x1CCE85, //! TEST ME
            UC4127_133SPDebug = 0x1CCDEA, //! TEST ME
            UC4133MPDebug = 0x1CCEA5,     //! TEST ME
            UC4MPBETA100Debug = 0x4C1B54,
            UC4MPBETA109Debug = 0x4C1CC6,
            TLL100MPDebug = 0x1CCE25,
            TLL100Debug = 0x1CCFDA,
            TLLMP108Debug = 0x1CCE85,
            TLLMP109Debug = 0x1CCEA5,
            TLL10XDebug = 0x1CD01A
        ;

        /// <summary> Int Value Used To Identify The Specific Executable Selected By The User.<br/>(0x1EC + 0x1F8) <br/>VERY LIMITED </summary>
        public const int
            // PC Eboot Identifiers - Very Limited Though | 0x1EC + 0x1F8 (Kept Seperate Through Immense Laziness)
            T1X101 = 42695168 + 16007532,
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

        /// <summary> Offsets To Enable The Debug Mode in the pc version of the game<br/>(0x97 -> 0x8F) </summary>
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
        #endregion
    }
}
