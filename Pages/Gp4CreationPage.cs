using System;
using System.IO;
using System.Drawing;
using static Dobby.Common;
using System.Windows.Forms;
using libgp4;
using System.Linq;



namespace Dobby {
    internal partial class Gp4CreationPage : PkgCreationPage {

        public Gp4CreationPage() { //! Page Unfinished, Only Base Functionality Added
            InitializeComponent();
            
            InitializeAdditionalEventHandlers(Controls);


            //! Why am I doing this?
            foreach(Control control in Controls) {
                if(control.Name.Contains("PathLabel")) {
                    control.MouseEnter += new EventHandler((sender, args) => ((Control)sender).Font = new Font(((Control)sender).Font.FontFamily, ((Control)sender).Font.Size, FontStyle.Bold | FontStyle.Underline));
                    control.MouseLeave += new EventHandler((sender, args) => ((Control)sender).Font = new Font(((Control)sender).Font.FontFamily, ((Control)sender).Font.Size, FontStyle.Bold));
                }
            }
            
            AbsoluteFilePathsBtn.Variable = false;
            IgnoreKeystoneBtn.Variable = false;

            gp4 = new GP4Creator();
        }


        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]
        private GP4Creator gp4;

        #endregion



        
        //=================================\\
        //--|   Function Declarations   |--\\
        //=================================\\
        #region [Function Declarations]

        private void StartGp4CreationBtn_Click(object sender, EventArgs e) {
            

            //#
            //## Assign Defaults/Verify Options.
            //#
            #region [Assign Defaults/Verify Options]


            // Check for Unassigned Gamedata Path Before Proceeding
            if (GamedataPathTextBox.IsDefault)
            {
#if DEBUG
                if (gp4.GamedataFolder.Remove(gp4.GamedataFolder.LastIndexOf('-')) == Testing.TestGamedataFolder.Remove(Testing.TestGamedataFolder.LastIndexOf('-')))
                  Print("Using Test Gamedata Folder.");
                else
#endif
                {
                    Print("Please Assign A Valid Gamedata Folder Before Building.\n");
                    return;
                }
            }
            // Read Current Gamedata Folder Path From The Text Box
            else gp4.GamedataFolder = GamedataPathTextBox.Text.Replace("\"", string.Empty);


            // Ensure Keystone is Present if Applicable
            if (gp4.SfoParams.category == "gd" && !gp4.IgnoreKeystone && !File.Exists($@"{gp4.GamedataFolder}\sce_sys\keystone"))
            {
                Print($"ERROR; No keystone File Found In Project Folder.\n\n");
                return;
            }


            gp4.UseAbsoluteFilePaths = (bool) AbsoluteFilePathsBtn.Variable;

            gp4.IgnoreKeystone = (bool) IgnoreKeystoneBtn.Variable;

            #endregion [Assign Defaults/Verify Options]



            //#
            //## Begin .gp4 Creation if all's well
            //#
            gp4.CreateGP4();
        }



        
        private void GamedataPathBrowseBtn_Click(object sender, EventArgs e)
        {//! TODO: Implement switch.
            // Use the ghastly Directory Tree Dialogue to Choose A Folder
            if (true)
            {
                using (var FBrowser = new FolderBrowserDialog { Description = "Please Select the Desired Gamedata Folder" })
                {
                    if (FBrowser.ShowDialog() == DialogResult.OK) {
                        GamedataPathTextBox.Set(FBrowser.SelectedPath);
                    }
                }

            }
            // Use The Newer "Hackey" Method
            else {
                using(fileDialogue = new OpenFileDialog {
                    ValidateNames   = false,
                    CheckPathExists = false,
                    CheckFileExists = false,
                    Title    = "(Don't click anything IN the desired folder, this dialogue is terrible)", 
                    Filter   = "Folder Selection|*.",
                    FileName = "Press 'Open' Inside The Desired Folder."
                })
                if (fileDialogue.ShowDialog() == DialogResult.OK)
                    GamedataPathTextBox.Set(fileDialogue.FileName.Remove(fileDialogue.FileName.LastIndexOf('\\')));
            }
            

            // Lazy fix
            ((Dobby.Button)sender).ForeColor = Color.White;
        }

        private void Gp4OutputDirectoryBrowseBtn_Click(object sender, EventArgs e)
        {
            using(fileDialogue = new OpenFileDialog {
                Filter = ".gp4 Project File|*.gp4",
                Title = "Select Your .gp4 File"
            })
            if(fileDialogue.ShowDialog() == DialogResult.OK)
                Gp4OutputDirectoryTextBox.Set(fileDialogue.FileName);

            
            ((Dobby.Button)sender).ForeColor = Color.White;
        }

        private void BaseGamePackageBrowseBtn_Click(object sender, EventArgs e)
        {
            using(fileDialogue = new OpenFileDialog {
                Filter = ".gp4 Project File|*.gp4",
                Title = "Select Your .gp4 File"
            })
            if(fileDialogue.ShowDialog() == DialogResult.OK)
                BaseGamePackagePathTextBox.Set(fileDialogue.FileName);
            
            
            ((Dobby.Button)sender).ForeColor = Color.White;
        }

        private void FileBlacklistBrowseBtn_Click(object sender, EventArgs e)
        {
            using(fileDialogue = new OpenFileDialog {
                Title = "Select Your .gp4 File"
            })
            if(fileDialogue.ShowDialog() == DialogResult.OK)
                BaseGamePackagePathTextBox.Set(string.Join("; ", fileDialogue.FileNames));


            ((Dobby.Button)sender).ForeColor = Color.White;
        }

        

        private void AbsoluteFilePathsBtn_Click(object control, EventArgs _) => ((Dobby.Button)control).Variable = !(bool) ((Dobby.Button)control).Variable;
        
        private void IgnoreKeystoneBtn_Click(object control, EventArgs e) => ((Dobby.Button)control).Variable = !(bool) ((Dobby.Button)control).Variable;

        #endregion





        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        private Label GamedataPathLabel;
        private TextBox GamedataPathTextBox;
        private Button GamedataPathBrowseBtn;
        private Button Gp4OutputDirectoryBrowseBtn;
        private TextBox Gp4OutputDirectoryTextBox;
        private Label Gp4OutputPathLabel;
        private Label PasscodeLabel;
        private TextBox PasscodeTextBox;
        private Label FileBlacklistPathLabel;
        private TextBox FileBlacklistTextBox;
        private Button FileBlacklistBrowseBtn;
        private Label BaseGamePackagePathLabel;
        private TextBox BaseGamePackagePathTextBox;
        private Button BaseGamePackageBrowseBtn;
        private Label SeperatorLine2;
        private Label SeperatorLine3;
        private Button AbsoluteFilePathsBtn;
        private Button IgnoreKeystoneBtn;
        private Button InfoHelpBtn;
        private Button BackBtn;
        private Label Info;
        private Button CreditsBtn;
        private Label MainLabel;
        private Label SeperatorLine4;
        private Label SeperatorLine0;
        #endregion
    }

}
