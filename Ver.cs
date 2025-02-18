﻿namespace Dobby {
    public static class Ver {

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
          "* 4.46.212.560 | PS4 Menu Settings Page Release, Code Restructuring For Most Pages. (Moved PS4DebugPage Related Variables From Common.cs In To PS4DebugPage.cs, Small Tweaks), Log Window Fixes (Properly Follows The Parent Form Now Instead Of Snapping To It). Standardized Seperator Label Heights And Adjusted Various Control Positions Application-Wide.",
          "* 4.46.213.561 | Added BootSettings Function Data For T1R 1.00, Most Pointers Still Missing",
          "* 4.46.213.563 | Label Font Size Fix And Position Adjustment",
          "* 4.46.215.583 | Standardized MainLabel, SeperatorLabel0, And Exit/Minimize Buttons, Positions And Sizes (Excuding Width For The Former Two) Shrumk Minimize/Exit Button Fonts (8f => 7.5f). Replaced The Control Hover Highlight With Mouse Down highlight To More Match ND's DMenu (Might Add Boolean Option Highlight To Match It Further)",
          "* 4.46.216.583 | HoverLeave Function No Longer Widens Controls If They Already FIt The Form Width Rather Than Only Themselves",
          "* 4.46.217.585 | Style Testing Wip, Debug Fix",
          "* 4.46.218.585 | Temporarily Removed GP4 Creation Page Access, Going To Replace With Automatic GP4 Creation Until Gp4 lib is fleshed out",
          "* 4.47.224.603 | PkgCreationPage Work, Changed Seperator Line Positioning And Sizing Replaced Static Exit/Minimize Buttons With Dynamic Initialization During Form Init (Through AddEventHandlersToControls()), Other Misc Changes",
          "* 4.47.225.609 | PkgCreationPage Work, Trying To Get A \"Good\" Look Down ",
          "* 4.47.225.611 | Font Styling Fix In EbootPatchPage ",
          "* 4.47.226.613 | Fixed Incorrect File Access In Port Function Catch Block That Was Just Re-Trowing The Same Exception, Soft-blocking Access To The PS4DebugPage.",
          "* 4.47.227.617 | Changed ResetItemHighlight(sender, MouseEventArgs) Access Level For Manual Resetting. Message Boxes Are Rude.",
          "* 4.47.228.621 | Moved Payload Sending Method To It's Own Thread, Minor Tweaks",
          "* 4.48-alpha.231.641 | gp4 creation page \"work\", Many Misc Changes",
          "* 4.48-alpha.232.643 | Renamed Debug (MsgOut -> WLog), Misc Changes",
          "* 4.48-alpha.233.648 | Minor gp4 Page Work",
          "* 4.48-alpha.233.649 | Jic",
          "* 4.48-alpha.233.650 | Minor Formatting Fixes (Eat Shite, VS)",
          "* 4.48-alpha.233.651 | JIC, Been a While",
          "* 4.49-alpha.234.653 | Added support for the 1.08 version of The Last of Us Remastered; Disabled the clunky, half-arsed pkg creation page (not very user friendly, and needs testing after gp4 library overhaul)",
          "* 4.49-alpha.234.655 | Cleaning up project/solution.",
          "* 4.49-alpha.234.655 | PS4 Debug Page fixes. I broke the ip box at some point; now THAT takes skill ;_;.",
          "* 4.49-alpha.234.659 | General code cleanup, and some PS4DebugPage \"work\".",
          "* 4.49-alpha.234.662 | Port fix. I should pay attention. Or just sleep.",
          "* 4.49-alpha.234.665 | Cleaned up PS4Debug Page",
          "* 4.49-alpha.237.671 | More code cleanup; misc background changes for my own damn sanity. (bite me, nobody's gonna actually read these, anyway)",
          "* 4.49-alpha.238.681 | More code cleanup; fixed inability to drag-select the text in the IP and Port boxes. Still reworking the connection / payload injection functions.",
          "* 4.49-alpha.239.683 | Slight Dev.LogWindow output tweaks. Removed odd click functionality of scroll wheel on ps4debug page (no idea why that was there)",
          "* 4.49-alpha.244.693 | More code cleanup; PS4DebugPage bs. ADHD hard.",
          "* 4.49-beta.245.695 | Fixed BackBtn memes after moving back functionality to dynamic initialization.",
          "* 4.49-beta.247.700 | Misc Dev.LogWindow stuff, more code cleanup.",
          "* 4.49-beta.252.706 | Slight PS4DBG usage tweak in PS4DebugPage.Toggle() methods, *mostly finished reworking PS4DBG connection thread setup and other related background functionality *(I have a migraine and need to clean it up later, but it works)",
          "* 4.49-beta.256.723 | Reworking Dobby.Dev and Dobby.Dev.LogWindow classes; renamed Dobby.Dev => Dobby.Testing. Small PS4DebugPage fix.",
          "* 4.49-beta.261.728 | Removed duplicate Credits and Info/Help Page intialization events from main page (forgot to remove 'em after making that dynamic), fixed the previously half-reworked ChangeForm function. NOTE: Debug builds randomly ignore mouse click events now. kill me.",
          "* 4.49.264.741 | Finished neglected GP4CreationPage base to remove that damn beta tag, Added check to see whether Click events are being dropped in release builds as well",
          "* 4.49.266.748 | Slight update to the DrawSeperatorLine method. (Just realized the lines aren't centered >:(. ), Changed label flash method to be less clunky, as well as support the main info label (or any control with a Color property, really...)",
          "* 4.49.266.750 | Slight LabelFlash tweaks, again.",
          "* 4.49.268.754 | Slightly sorted Common variables/properties, Misc.",
          "* 4.49.271.761 | Misc GP4 Creation Page / libgp4 BS.",
          "* 4.50.272.764 | GP4CreationPage base functionality implemented",
          "* 4.50.272.765 | Tiny PKGCreationPage fix. Oops.",
          "* 4.51.275.772 | GP4CreationPage should be alright to go now, other misc formatting and background tweaks",
          "* 4.51.279.778 | Replaced mass int declarations with enums (for GameID's and Debug Addresses), Reworking non-ps4debug patch pages (background, not user-side).",
          "* 4.51.280.781 | Miscellaneous crap",
          "* 4.51.281.783 | Slight DebugButtons tweak",
          "* 4.51.285.790 | GP4CreationPage design tweak (will update PkgCreationPage later), Small Dobby.TextBox addition; Yet another font change (kill me), other random sh7t",
          "* 4.51.286.791 | Removed that dumb label highlight on the Pkg & GP4 Creation Pages- added the text box underline to gp4 page.",
          "* 4.51.288.792 | \"Standardized\" Pkg & GP4 Creation Page designs.",
          "* 4.51.288.796 | Slight design tweaks (mostly adjusting things by a few pixles every time I say that)",
          "* 4.51.288.796 | Misc PkgCreationPage fixes (controls had inconsistent names for some reason- designer must've borked something, 'cause I never renamed 'em...)",
          "* 4.51.289.807 | Disabled alignment bs until I can figure out the cause",
          "* 4.52.293.811 | Removed pointless Temp Directory toggle on PkgCreationPage (why tf wasn't it already tied to the temp path box's state!? Drunk-ass...), Directory/path text box underline fix for GP4 & PKG creation pages, Tiny HoverLeave() tweaks.",
          "* 4.52.294.811 | oops.",
          "* 4.52.296.813 | oops 2, electric boogaloo (left in a random line of code after earlier tests). Also renamed and duplicated DebugBtn1 to the gp4 creation page as StyleTestBtn",
          "* 4.52.299.822 | I forgot to write this message and have forgotten what I did. Meh.",
          "* 4.52.301.822 | Added attributes to Variable & VariableTags properties in Button class extension to remove Variable from the Properties panel/window, since it can't be assigned to in there anyway, as well as stop the designer from assigning them both as null in InitializeComponent()",
          "* 4.52.310.826 | tweaking DrawButtonVariable() to replace rightmost-side alignment with consistent placement, as well as resize controls to fit the contents neatly",
          "* 4.52.314.835 | misc testing",
        };


        public static string Build = ChangeList[ChangeList.Length - 1].Substring(2).Substring(0, ChangeList[ChangeList.Length - 1].IndexOf('|') - 3); // Trims The Last ChangeList String For Latest The Build Number
    }
}
