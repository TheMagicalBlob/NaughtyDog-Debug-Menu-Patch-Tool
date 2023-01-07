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
            if (!Dev.REL) {
                PageInfo(Controls);
                Console.WindowHeight = 36;
                Console.WindowWidth = 130;
            }
            else DebugLabel.Visible = false;
            
            Info.Text = "";
            Page = "Dobby";
            YellowInformationLabel = Info;
            Common.Pages = new Form[] { this };
            Dev.DebuggerInfo();
        }

        public static TcpClient me;
        public static NetworkStream stream;
        public static string Page = "Dobby";
        public static bool InfoHasImportantStr;
        public static Point MouseDif;
        public static Point MousePos;
        public void PS4DebugPageBtn_Click(object sender, EventArgs e) {
            //EbootPatchPageBtn_Click(sender, e);
            //return; //!

            LastForm = MainForm = ActiveForm;
            LastPos = LastForm.Location;
            PS4DebugPage NewPage = new PS4DebugPage();
            NewPage.Show();
            LastForm.Hide();
        }
        public void PS4DebugPageBtnMH(object sender, EventArgs e) => HoverStringAlt(Info, PS4DebugPageBtn, "Use A Lan Or Wifi Connection To Enable The Debug Mode", 9F);
        public void PS4DebugPageBtnML(object sender, EventArgs e) => HoverLeave(PS4DebugPageBtn, 1);

        public void EbootPatchPageBtn_Click(object sender, EventArgs e) {
            LastForm = MainForm = ActiveForm;
            LastPos = LastForm.Location;
            EbootPatchPage NewPage = new EbootPatchPage();
            NewPage.Show();
            LastForm.Hide();
        }
        public void EbootPatchPageBtnMH(object sender, EventArgs e) => HoverString(EbootPatchPageBtn, "Patch An Executable To Be Added To A .pkg");
        public void EbootPatchPageBtnML(object sender, EventArgs e) => HoverLeave(EbootPatchPageBtn, 1);

        private void MiscPatchesBtn_Click(object sender, EventArgs e) { }
        public void MiscPatchesBtnMH(object sender, EventArgs e) => HoverString(MiscPatchesBtn, "Not Yet Implemented");
        public void MiscPatchesBtnML(object sender, EventArgs e) => HoverLeave(MiscPatchesBtn, 1);
    }
}