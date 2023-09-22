# Naughty Dog Debug Mode Patch Tool
_**Themed After Naughty Dog's Simple Debug Menus**_

Can Be Either Used With ps4debug.bin &amp; A Modded PS4 (Currently 9.00 Or Lower)
Connected To The Same Connection As The PC In Order To Toggle The Debug Menus As-Is.

Or Be Used On A Dumped Game/Game Patch's eboot.bin (or .elf) To Enable The Debug Menu And Patch In Hidden Menu Options (Assuming Any Are Available,
And I've Made A Patch For It) Which Normally Get Skipped After A Failed Debug Memory Check (Ignoring PS4 Devkits, Obviously)

(ps4debug Payload Available [Here](https://github.com/jogolden/ps4debug/releases), Plus A Lightweight Payload Sender To Inject It [Here](https://github.com/TheMagicalBlob/Blobs-Payload-Sender/releases/download/1.7.1-Final/Payload.Sender.1.7.1.exe))

Debug Mode/Menus Usage:
- Access The Quick Menu With L3 + Touchpad Left
- Access The Dev Menu With L3 + Touchpad Right
- Access The Favorites Menu With L3 + Options (This Is Useless Without A Devkit)
- Toggle Debug Fly (Noclip) With L3 + R3
- L3 + Triangle Normally Toggles Debug Rendering, Though I Changed It To An FPS Toggle In Most Versions Since There's No Debug Rendering To Toggle

# Pages:

- The First (PS4Debug Page) Uses libdebug &amp; PS4Debug to enable the debug modes of any of the PS4 Naughty Dog games - Though Once The Game's Booted, Applying The Restoration Patches (Or Any Others) Won't Unlock Anything Since The Menu's Already Loaded; *It Can Only Be Toggled*

- The Second (EbootPatch Page) Can Be Used On An Unsigned/Decrypted Game's Executable (usually named eboot.bin, But May Also Be self Files) 
To Enable Or Disable The Default Debug Mode For Whichever Game's Selected, Or, If Available; Patch In A Restored Version Of The Debug Menu Through Various Methods, Or A Customized One If There's Not Enough Left To Really "Restore" It.

- The Third (MiscPatch Page) I'll Type This Later, My Back's Starting To Hurt...

- The Fourth (PkgCreation Page) This Page Hasn't Been Finished Yet, But It'll Just Use Orbis-pub-cmd.exe To Build A Pkg For The User


# Methods For Restoring Debug Submenus/Options In Naughty Dog's Debug Menus

_For The Uncharted Collection, Uncharted 4 1.15, 1.16, And 1.17 (SP), Plus All It's MP .elf's Starting At 1.21 And The Lost Legacy MP (All Of 'Em):_
- Devkit Checks That Fail On Retail Consoles/Testkits Without Debug Memory Skip Large Portions Of The Menu. Not Everything's Functionality Can Be Restored, But An Attempt At Restoring As Much As Possible Can Be Done By Skipping Memory Push/Pop Allocators That Just End Up Crashing The Game On A Console Mising Debug Memory, And Fixing The Other Issues That Arise For Various Reasons.

_For The Last Of Us Remastered:_
- The Game Doesn't Seem To Ever Check For/Use Debug Memory, So The Compiler Optimization Outright Deleted Things That Were Just Skipped In The Uncharted Collection &amp; UC4/Lost Legacy Multiplayer- Leaving Less To Work With Than UC4 MP, But Still Far More Than We Have In Most Other Single Player Executables, So I Used Some Padding Space The Executable Never Touches To: Rebuild A Large Amount Of The Functions Calling Various Submenus, Rebuild Submenus Themselves And Call The Leftover Options, Or Outright Rebuild An Entire Submenu Like I Had To With The **Menu...** Submenu Which Only Had The Still-Read Toggles It Used To Work With, Plus The Tiny ProgPauseOnMenuOpen Function I Had To Remake.
I Looked At Other Games Plus Tlou Dev Footage To See Where Things Should Go To Try And Be As Accurate As Possible.

_In Case This Crossed Your Mind:_
- The Most Obvious Solution Of Simply Making The Debug Memory Check Return Successful Will Cause Numerous Entirely Unusable Things To Load, And Break Far More Than I'd Like, So Individually Loading Skipped Bits Is Still The Best Solution


All Debug Offsets & Patches Are From Myself Only (For Now...), But I Have No Part In PS4Debug/libdebug's Creation.
[illusion](https://github.com/illusion0001) &amp; I Also Worked Together To A Small Extent On The UC4 1.33 MP Restoration (Which, Is Also The Lost Legacy 1.09 MP Rest Since The .elf Is Identical...)

*Special Thanks To illusion For Introducing Me To Ghidra A Few Years Back, Plus kiwidog, Al Azif And Plenty Of Others For Miscellaneous Help Over Time.*
[Naughty Dog Debug Patch Tool.zip](https://github.com/TheMagicalBlob/NaughtyDog-Debug-Menu-Patch-Tool/files/10361168/Naughty.Dog.Debug.Patch.Tool.zip)

**-** TheMagicalBlob
