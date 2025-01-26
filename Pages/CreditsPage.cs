using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using static Dobby.Common;

namespace Dobby {
    internal partial class CreditsPage : Form {
        public CreditsPage() {
            InitializeComponent();
            
            InitializeAdditionalEventHandlers(Controls);
            foreach (Control control in Controls)
                control.TabStop = false;
        }

        public void BlobGithubBtn_RightClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) MessageBox.Show("https://github.com/TheMagicalBlob");

            else Process.Start("https://github.com/TheMagicalBlob");
        }
        public void BlobGithubBtnMH(object sender, EventArgs e) => BlobGithubBtn.ForeColor = Color.MediumBlue;
        public void BlobGithubBtnML(object sender, EventArgs e) => BlobGithubBtn.ForeColor = Color.White;
        public void IllusionBlogBtn_RightClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) MessageBox.Show("https://illusion0001.com/");

            else Process.Start("https://illusion0001.com/");
        }
        public void IllusionBlogBtnMH(object sender, EventArgs e) => IllusionBlogBtn.ForeColor = Color.MediumBlue;
        public void IllusionBlogBtnML(object sender, EventArgs e) => IllusionBlogBtn.ForeColor = Color.White;




        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Repeated Page Functions & Control Declarations     --\\\
        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Repeat Functions & Control Declarations
        void BackBtn_Click(object sender, EventArgs e) {
            ReturnToPreviousPage();
            HoverLeave((Control)sender, false);
        }
        public Label MainLabel;
        public Label NarcissismLabel;
        public Label BlobGithubBtn;
        public Label IllusionBlogBtn;
        public Label ContributorsLabel;
        public Button BackBtn;
        public Label SeperatorLine1;
        public Label Info;
        public Label SeperatorLine2;
        public Label label1;
        public Label SeperatorLine0;
        #endregion
    }
}