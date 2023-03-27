using System;
using libdebug;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Linq;
using System.Threading;
using static Dobby.Common;

namespace Dobby { //!      <<<<< Marker For "Remove/Check Me Before rel"
    public partial class Dobby : Form {
        public Dobby() {
            InitializeComponent();
            if (!Dev.REL && Pages[0] == null) {
                PageInfo(Controls);
                try { Console.WindowWidth = 75; Console.BufferWidth = 75; }
                catch (Exception) {} // These Caused A Crash I Couldn't Recreate, So I Put Them In A Try/Catch
                Dev.DebuggerInfo();
                Dev.ReadCurrentKey();
            }
            else DebugLabel.Visible = false;

            Info.Text = "";
            Page = 0;
            YellowInformationLabel = Info;
        }

        public static TcpClient me;
        public static NetworkStream stream;
        public static int Page;
        public static bool InfoHasImportantStr;
        public static Point MouseDif;
        public static Point MousePos;
        public void PS4DebugPageBtn_Click(object sender, EventArgs e) => ChangeForm(1, false);
        public void PS4DebugPageBtnMH(object sender, EventArgs e) => HoverString(PS4DebugPageBtn, "Use A Lan Or Wifi Connection To Enable The Debug Mode");
        public void PS4DebugPageBtnML(object sender, EventArgs e) => HoverLeave(PS4DebugPageBtn, 1);

        public void EbootPatchPageBtn_Click(object sender, EventArgs e) => ChangeForm(2, false);
        public void EbootPatchPageBtnMH(object sender, EventArgs e) => HoverString(EbootPatchPageBtn, "Patch An Executable To Be Added To A .pkg");
        public void EbootPatchPageBtnML(object sender, EventArgs e) => HoverLeave(EbootPatchPageBtn, 1);

        private void MiscPatchesBtn_Click(object sender, EventArgs e) { }
        public void MiscPatchesBtnMH(object sender, EventArgs e) => HoverString(MiscPatchesBtn, "Not Yet Implemented");
        public void MiscPatchesBtnML(object sender, EventArgs e) => HoverLeave(MiscPatchesBtn, 1);
    }
}