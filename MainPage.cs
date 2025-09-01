using System;
using System.Linq;
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
            
            Venat = this;
            Dev = new Testing();

            InitializeAdditionalEventHandlers(this);
            
            // Create/Initialize the thread for updating the yellow info label at the bottom of the screen
            CreateInfoLabelUpdater();

            #if DEBUG
            NoDraw = false;


            // Force a page to open immediately to save a smidge of time constantly opening the damn thing
            Venat.Shown += (unused, bleh) =>
            {
                if (Pages.All(page => page == PageID.MainPage) && Testing.PageToForce != ActivePage)
                {
                    Pages.Add(Testing.PageToForce);
                    OpenNewPage(Testing.PageToForce);
                }
            };
#endif
            }



        private void button1_Click(object sender, EventArgs e)
        {
            ShowPopup(new string('F', 123), new string('H', 24));
        }


        
        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]
        private void PS4DebugPageBtn_Click(object sender, EventArgs e)        => OpenNewPage(PageID.PS4DebugPage);
        private void EbootPatchPageBtn_Click(object sender, EventArgs e)      => OpenNewPage(PageID.EbootPatchPage);
        private void PS4MenuSettingsPageBtn_Click(object sender, EventArgs e) => OpenNewPage(PageID.PS4MenuSettingsPage);
        private void PkgPageBtn_Click(object sender, EventArgs e)             => OpenNewPage(PageID.PkgCreationPage);
        private void PCDebugMenuPageBtn_Click(object sender, EventArgs e)     => OpenNewPage(PageID.PCDebugMenuPage);
        private void DownloadSourceBtn_Click(object sender, EventArgs e)      => System.Diagnostics.Process.Start(@"https://github.com/TheMagicalBlob/NaughtyDog-Debug-Menu-Patch-Tool/archive/refs/heads/master.zip");
        #endregion
    }
}