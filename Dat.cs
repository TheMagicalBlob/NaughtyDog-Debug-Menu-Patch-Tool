using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dobby {
    /// <summary>
    /// This Page Just Holds Backups Of The Patch Lists For The Restored Debug Menus
    /// </summary>
    internal class Dat {
/*

Uncharted 4 1.33 MP .elf

Debug Mode

0x1CCEB8 0x01
----------

Stop Crash On Selecting SP Tasks

0x1643862 0x01 
--------------------------------
Restore Main Task Menu

0x24E5C8 0x01
----------------------
Swap Debug Rendering & Disable FPS In The L3 + Triangle Toggle

0x20760B & 0x207615 | 0x88
0x207629 | 0x7f
--------------------------------------------------------------

Unlock Devkit And Other Locked Submenus On Retail/Testkit

Submenu                   | .elf address | Data |

Relaunch...                  0x1BBCF00     0x85  <= "Quick Menu" Option

Neo Reolution Mode...        0x18725CA     0x00 <= Just Stops The Menu Entry From Being Skipped On Non-Pro Models
HDR Mode...                  0x1872662     0x0000 <= Similar Deal To Neo Resolution Mode Menu

Optimization...              0x18737BC     0x01 <= Normally Only Has One Option

Render Pause                 0x18762C6     0x00

Rendering Menu P1            0x18768C7     0x0000
                             0x1876C69     0x4C8D2518DCA900E9C2540000
                             0x18768E9     0xE900000000

Rendering Menu P2            0x187D6D6     0x01 Invert Skip Parameters (CMP) 'Cause Fuck Yo Devkits
                             0x187D702     0xE900000000 Skip First Crashing Function (PushAlloc)
                             0x187F8D0     0xE900000000 Skip Second Crashing Function (PopAlloc)

Post Processing P1...        0x1B4ABB7     0x85
                             0x1B4ABE1     0xE900000000
                             0x1B5209A     0xE900000000

Post Processing P2...        0x1B52533     0x01
                             0x1B52558     0xE900000000
                             0x1B55062     0xE900000000

Lighting...                  0x1894771     0x85
                             0x189479B     0xE900000000
                             0x189B921     0xE900000000
                             0x189F096     0x0000
                             0x189F0B8     0xE900000000
                             0x18A06E7     0xE900000000

Rendering Menu P3            0x187F972     0x01
                             0x187F997     0xE900000000
                             0x188DB53     0xE900000000

Spawn Character...           0x404833      0x0000
                             0x40485B      0xE900000000
                             0x405057      0xE90D000000
                             0x40497F      0xE900000000
                             0x42357A      0xE900000000
                             0x404AB4      0xE900000000
                             0x4245CA      0xE900000000

Spawn Vehicle...             0x40508D      0xE900000000
                             0x40530C      0xE900000000

Game Objects...              0x40727C      0x01
                             0x4072A7      0xE900000000
                             0x4073C2      0xE900000000

Levels...                    0x4073CD      0x01
                             0x4073F8      0xE900000000
                             0x408CF3      0xE900000000 (Or 0xE905000000 For Two "Levels..." Submenus)

Collision (Havok)            0x407013      0x01
                             0x40703E      0xE900000000
                             0x40715A      0xE900000000

Camera...                    0x241157      0x85
                             0x241182      0xE900000000
                             0x2412D3      0xE900000000
                             0x2412FE      0xE900000000
                             0x241329      0xE900000000
                             0x241351      0xE900000000
                             0x7E074F      0xE900000000
                             0x7E73A9      0xE900000000

Camera Shake...              0x7E62F9      0xE904000000


Menu...                      0x40FF83      0x01
                             0x40FFB5      0xE900000000
                             0x4115BF      0xE900000000

Audio...                     0x15673A2     0x01
                             0x15673D2     0xE900000000
                             0x156E314     0xE900000000
                             0x156E3B7     0x01
                             0x156E3DC     0xE900000000
                             0x156EEC6     0xE900000000
                             0x156F363     0x01
                             0x156F388     0xE900000000
                             0x1570A85     0xE900000000
                             0x1570B22     0x01
                             0x1570B47     0xE900000000
                             0x1570E96     0xE900000000

Level BugFix...              0x41526F      0x01
                             0x41529A      0xE900000000
                             0x415A38      0xE900000000

Cinematics...                0x24BE55      0x01
                             0x24BE82      0xE900000000
                             0x24C5DB      0xE900000000



Play Task...                 0x24E5C8      0x01

Complete Task...             0x24E851      0x01
&Complete SP-DLC1 Task...    0x24E88B      0xE900000000
&Complete Test Task...       0x24EE94      0xE900000000

Play Test Task...            0x24E929      0x85
Complete Test Task...        0x24ED59      0x85


*/
    }
}
