using System;
using System.Diagnostics;
using System.Windows.Forms;
using static Dobby.Common;

namespace Dobby { //!      <<<<< Marker For "Remove/Check Me Before Release lol"
    internal partial class Main : Form {
        public Main() {
            InitializeComponent();
            
            InfoLabel = Info;
            Page = PageID.MainPage;
            SaveMainForm(this);

#if DEBUG
            new Testing(this);
#endif
            InitializeAdditionalEventHandlers(Controls);
        }


        
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        ///--     Page-Specific Functions     --\\\
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        #region Page-Specific Functions
        private void PS4DebugPageBtn_Click(object sender, EventArgs e)        => ChangeForm(PageID.PS4DebugPage);
        private void EbootPatchPageBtn_Click(object sender, EventArgs e)      => ChangeForm(PageID.EbootPatchPage);
        private void PS4MenuSettingsPageBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.PS4MenuSettingsPage);
        private void PkgPageBtn_Click(object sender, EventArgs e)             => ChangeForm(PageID.PkgCreationPage);
        private void PCDebugMenuPageBtn_Click(object sender, EventArgs e)     => ChangeForm(PageID.PCDebugMenuPage);
        private void DownloadSourceBtn_Click(object sender, EventArgs e)      => System.Diagnostics.Process.Start(@"https://github.com/TheMagicalBlob/NaughtyDog-Debug-Menu-Patch-Tool/archive/refs/heads/master.zip");
        #endregion

        

        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        public Label MainLabel;
        public Button PS4DebugPageBtn;
        public Button EbootPatchPageBtn;
        public Button PS4MenuSettingsPageBtn;
        public Label Info;
        public Label SeperatorLine0;
        public Label SeperatorLine3;
        public Button PkgCreationPageBtn;
        public Label SeperatorLine1;
        public Button PCDebugMenuPageBtn;
        public Button CreditsBtn;
        public Button InfoHelpBtn;
        public Label Playstation4Label;
        public Label PCLabel;
        public Button DownloadSourceBtn;
        #endregion
    }
}