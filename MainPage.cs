using System;
using System.Windows.Forms;
using static Dobby.Common;


namespace Dobby {
    internal partial class MainPage : Form {

        /// <summary>
        /// Initialize the main instance of the MainPage form.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            Page = PageID.MainPage;
            
            SaveMainForm(this);
            Dev = new Testing();

            InitializeAdditionalEventHandlers(this);
            
            // Create/Initialize the thread for updating the yellow info label at the bottom of the screen
            CreateInfoLabelUpdater();
        }


        
        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]
        private void PS4DebugPageBtn_Click(object sender, EventArgs e)        => ChangeForm(PageID.PS4DebugPage);
        private void EbootPatchPageBtn_Click(object sender, EventArgs e)      => ChangeForm(PageID.EbootPatchPage);
        private void PS4MenuSettingsPageBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.PS4MenuSettingsPage);
        private void PkgPageBtn_Click(object sender, EventArgs e)             => ChangeForm(PageID.PkgCreationPage);
        private void PCDebugMenuPageBtn_Click(object sender, EventArgs e)     => ChangeForm(PageID.PCDebugMenuPage);
        private void DownloadSourceBtn_Click(object sender, EventArgs e)      => System.Diagnostics.Process.Start(@"https://github.com/TheMagicalBlob/NaughtyDog-Debug-Menu-Patch-Tool/archive/refs/heads/master.zip");
        #endregion
    }
}