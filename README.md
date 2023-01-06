# Naughty Dog Debug Mode Patch Tool

This Tool Can Be Used To Enable The Debug Mode/Menus That Shipped With Any Naughty Dog Made PS4 Games, Or Even Unlock More
Than Is Available In The Normal Debug Menu In Certain Games.

Quick Notes:
- Access The Quick Menu With L3 + Touchpad Left
- Access The Dev Menu With L3 + Touchpad Right
- Access The Favorites Menu With L3 + Options (This Is Useless Without A Devkit)
- Toggle Debug Fly (Noclip) With L3 + R3
- L3 + Triangle Normally Toggles Debug Rendering, Though I Changed It To An FPS Toggle In Most Versions Since There's No Debug Rendering To Toggle

**It Has A Few Methods Of Doing So:**

- The First (PS4Debug Page) Uses libdebug &amp; PS4Debug to enable the debug modes of any of the PS4 Naughty Dog games - Though Once The Game's Booted, Applying The Restoration Patches (Or Any Others) Won't Unlock Anything Since The Menu's Already Loaded; *It Can Only Be Toggled*

- The Second (Default Debug) Enables The Debug Mode As-is In The Game, (Default Debug)

- The Third (Restored Debug) Applies Dozens (Or 132 In UC4's MP Exec...) Of Patches To The Executable To Restore As Much Of The Menu As Possible, As Many Of These Games Have Unloaded Portions Of The Menu That Generally Only Load On Devkits Or While Signed In To PSN (Can't Fix Any Of The "Net..." Menus Yet :/)

- The Fourth (Custom Debug) Is For Games Without Many Submenus To Restore (Like Tlou2), It Applies My Custom Version With A Few Additional Options Like The Ability To Disable Culling, Or Alter The Field Of View Far More Than The Game Normally Allows

- A Page For Miscellaneous Patches Will Be Added In The Future


All Offsets & Codes Are From Myself Only (For Now...), But I Have No Part In PS4Debug/libdebug

*Special Thanks To illusion For Introducing Me To Ghidra A Few Years Back*
[Naughty Dog Debug Patch Tool.zip](https://github.com/TheMagicalBlob/NaughtyDog-Debug-Menu-Patch-Tool/files/10361168/Naughty.Dog.Debug.Patch.Tool.zip)

**-** TheMagicalBlob
