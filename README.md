# Naughty Dog Debug Menu Enabler
_**Themed After Naughty Dog's Simple Debug Menus**_
A windows application which can be used to enable the debug menus/mode in Naughty Dog's various PS4 games (as well as the PC release, in a limited form).

The tool can either:
  - enable the debug mode/menus that shipped with the game (local .bin patch, or RTM) without any extra modifications.
  - _disable_ the debug menu if desired, assuming it was enabled with the same patch as the tool would use.
  - patch out some jumps and apply a few fixes to force submenus normally exclusive to devkits to load anyway (with some issues due to the lack of a debug memory pool)
  - patch in a thoroughly restored version of the debug menus (The Last of Us Remastered specifically)
  - apply custom patches to the debug menu to add some additional functionality which was never normally present in the menu (unstripped or otherwise)
 
There is also an additional page for creating packages with the edited executable(s) from the eboot patch page and/or ps4 menu settings page.
****
(ps4debug Payload Available [Here](https://github.com/jogolden/ps4debug/releases), Plus A Lightweight Payload Sender To Inject It [Here](https://github.com/TheMagicalBlob/Blobs-Payload-Sender/releases/download/1.7.1-Final/Payload.Sender.1.7.1.exe))

Debug Mode/Menus Usage:
- Access The Quick Menu With L3 + Touchpad Left
- Access The Dev Menu With L3 + Touchpad Right
- Access The Favorites Menu With L3 + Options (This Is Useless Without A Devkit)
- Toggle Debug Fly (Noclip) With L3 + R3
- L3 + Triangle Normally Toggles Debug Rendering, Though I Changed It To An FPS Toggle In Most Versions Since There's No Debug Rendering To Toggle

## Page Functionality:

### PS4 Debug Patch Page
This page connects to a PS4 on the same internal network as the machine running the patch tool, and uses ps4debug to read the debug menu boolean pointer and toggle the byte at the read RAM address.

The payload can be sent from the application itself, but it's also widely available elsewhere.

The app will automatically attempt to connect (or reconnect if the game has changed) to the provided IP when a game button is selected, I've left an actual connection button just in case someone thinks it's necessary, lol.


### Eboot Patch Page
This page can apply either a basic debug menu patch, or a large restoration (or custom modification if there's nothing really left to restore) to a provided executable (eboot.bin, generally) for any of NaughtyDog's PS4 releases- even UC4's mp beta.


### Misc. Debug Menu Settings Page
This page is for patching in a custom settings function for that will apply various user-selected options to the game on-boot.


#### `(These following two pages aren't technically NaughtyDog-related, but they might be found useful)`
### PKG Creation Page
This page can create a custom fpkg from a provided .gp4 project file- assuming a valid path to a folder containing the required build tools is provided (fpkg toolset- not liborbispkg)


### GP4 Creation Page
This page uses my libgp4 library to create a .gp4 project from a provided gamedata folder, which can be used to build said gamedata in to a fakesigned orbis package (fpkg).
****



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
**-** TheMagicalBlob
