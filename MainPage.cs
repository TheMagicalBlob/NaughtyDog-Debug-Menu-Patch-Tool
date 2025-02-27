using System;
using System.Windows.Forms;
using static Dobby.Common;


//! == Marker For "Remove/Check Me Before Release lol"
namespace Dobby {
    internal partial class MainPage : Form {

        /// <summary>
        /// Initialize the new instance of the MainPage form.
        /// </summary>
        public MainPage() {
            InitializeComponent();
            
            InfoLabel = Info;
            Page = PageID.MainPage;
            SaveMainForm(this);

#if DEBUG
            new Testing(this);
            #else
            PS4MenuSettingsPageBtn.Font = new System.Drawing.Font(PS4MenuSettingsPageBtn.Font.FontFamily , PS4MenuSettingsPageBtn.Font.Size, PS4MenuSettingsPageBtn.Font.Style | System.Drawing.FontStyle.Strikeout);
            PS4MenuSettingsPageBtn.Enabled = false;
#endif
            InitializeAdditionalEventHandlers(Controls);
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