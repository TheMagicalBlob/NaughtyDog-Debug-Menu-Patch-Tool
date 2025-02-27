using System;
using System.IO;
using System.Windows.Forms;

namespace Dobby {
    internal partial class InfoHelpPage : Form {

        /// <summary>
        /// Initialize a new instance of the InfoHelpPage Form.
        /// </summary>
        public InfoHelpPage() {
            InitializeComponent();
            
            Common.InitializeAdditionalEventHandlers(Controls);
            BuildLabel.Text += Ver.Build;
        }

        
        
        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]

        private void BuildLabel_Click(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Right) {
                File.WriteAllLines(Directory.GetCurrentDirectory() + @"\ChangeLog.txt", Ver.ChangeList);
                MessageBox.Show($"Changelist Dumped To {Directory.GetCurrentDirectory()}\\ChangeLog.txt");
            }
        }
        private void BuildLabelMH(object sender, EventArgs e) { Common.UpdateLabel("Right Click To Dump ChangeList"); }
        private void BuildLabelML(object sender, EventArgs e) => Common.UpdateLabel("");

        private void PS4DebugHelpBtn_Click(object sender, EventArgs e) => Common.ChangeForm(Common.PageID.PS4DebugHelpPage);
        private void EbootPatchPageHelpBtn_Click(object sender, EventArgs e) => Common.ChangeForm(Common.PageID.EbootPatchHelpPage);
        private void PS4QOLPageHelpBtn_Click(object sender, EventArgs e) {
            #if false
            ChangeForm(PageID.PS4MiscPatchesHelpPage);
            #endif
        }
        private void PkgHelpPageBtn_Click(object sender, EventArgs e) {
            #if false
            ChangeForm(PageID.PkgCreationHelpPage);
            #endif
        }
        #endregion
    }
}
