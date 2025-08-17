using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using static Dobby.Common;

namespace Dobby {
    internal partial class CreditsPage : Form {

        /// <summary>
        /// Initialize a new instance of the CreditsPage Form.
        /// </summary>
        public CreditsPage() {
            InitializeComponent();
            
            InitializeAdditionalEventHandlers(this);
        }



        

        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]

        public void BlobGithubBtn_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("https://github.com/TheMagicalBlob");
            }
            else
                Process.Start("https://github.com/TheMagicalBlob");
        }

        public void BlobGithubBtnMH(object sender, EventArgs e) => BlobGithubBtn.ForeColor = Color.MediumBlue;
        
        public void BlobGithubBtnML(object sender, EventArgs e) => BlobGithubBtn.ForeColor = Color.White;
        
        public void IllusionBlogBtn_RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("https://illusion0001.com/");
            }
            else
                Process.Start("https://illusion0001.com/");
        
        }
        
        public void IllusionBlogBtnMH(object sender, EventArgs e) => IllusionBlogBtn.ForeColor = Color.MediumBlue;
        
        public void IllusionBlogBtnML(object sender, EventArgs e) => IllusionBlogBtn.ForeColor = Color.White;
        #endregion
    }
}