using System;
using System.IO;
using System.Windows.Forms;
using static Dobby.Common;

namespace Dobby {
    internal partial class InfoHelpPage : Form {

        /// <summary>
        /// Initialize a new instance of the InfoHelpPage Form.
        /// </summary>
        public InfoHelpPage()
        {
            InitializeComponent();
            
            InitializeAdditionalEventHandlers(this);
            BuildLabel.Text += Ver.Build;

            #if !DEBUG
            // DIsable these until finished
            PS4QOLPageHelpBtn.Enabled = false;
            PkgHelpPageBtn.Enabled = false;

            PS4QOLPageHelpBtn.Font = new System.Drawing.Font(PkgHelpPageBtn.Font.FontFamily, PkgHelpPageBtn.Font.Size, System.Drawing.FontStyle.Strikeout);
            PkgHelpPageBtn.Font = new System.Drawing.Font(PkgHelpPageBtn.Font.FontFamily, PkgHelpPageBtn.Font.Size, System.Drawing.FontStyle.Strikeout);
            #endif
        }

        
        
        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]

        private void BuildLabel_Click(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                File.WriteAllLines(Directory.GetCurrentDirectory() + @"\ChangeLog.txt", Ver.ChangeList);
                ShowPopup($"Changelist Dumped To {Directory.GetCurrentDirectory()}\\ChangeLog.txt");
            }
        }
        private void BuildLabelMH(object sender, EventArgs e) => UpdateLabel("Right Click To Dump ChangeList");
        private void BuildLabelML(object sender, EventArgs e) => UpdateLabel(string.Empty);

        private void PS4DebugHelpBtn_Click(object sender, EventArgs e) => OpenNewPage(PageID.PS4DebugHelpPage);
        private void EbootPatchPageHelpBtn_Click(object sender, EventArgs e) => OpenNewPage(PageID.EbootPatchHelpPage);
        private void PS4QOLPageHelpBtn_Click(object sender, EventArgs e) { OpenNewPage(PageID.PS4MenuSettingsHelpPage); }
        private void PkgHelpPageBtn_Click(object sender, EventArgs e) { OpenNewPage(PageID.PkgCreationHelpPage); }
        #endregion
    }
}
