using libgp4;
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using static Dobby.Common;



namespace Dobby {
    internal partial class GP4CreationPage : Form {

        /// <summary> Initialize a new instance of the GP4CreationPage Form. </summary>
        public GP4CreationPage() {
            InitializeComponent();
            InitializeAdditionalEventHandlers(Controls);
            
            foreach(Control control in Controls) {
                if(control.Name.Contains("PathBox")) {
                    control.MouseEnter += (sender, _) => ((Control)sender).Font = new Font(((Control)sender).Font.FontFamily, ((Control)sender).Font.Size, ((Control)sender).Font.Style ^ FontStyle.Underline);
                    control.MouseLeave += (sender, _) => ((Control)sender).Font = new Font(((Control)sender).Font.FontFamily, ((Control)sender).Font.Size, ((Control)sender).Font.Style ^ FontStyle.Underline);
                }
            }

            
            IgnoreKeystoneBtn.Variable = false;
            IgnoreKeystoneBtn.VariableTags = new string[] { "Include", "Ignore" };
            
            AbsoluteFilePathsBtn.Variable = false;
            AbsoluteFilePathsBtn.VariableTags = new string[] { "Relative", "Absolute" };


            gp4 = new GP4Creator() {
        #if DEBUG
                VerboseOutput = true,
        #endif
                SkipEndComment = true,
                SkipIntegrityCheck = false,
                LoggingMethod = (object msg) => Print(msg)
            };
            

            Testing.AddStyleTestButton(this);
            // TODO:
            // * Maintain Settings For Page When Swapping Between gp4/pkg Creation Pages.. Or Just In General.
        }



        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]

        private GP4Creator gp4;
        #endregion



        //=============================================\\
        //--|   Background Function Delcarations   |---\\
        //=============================================\\
        #region [Background Function Delcarations]

        private bool ApplyandVerifyGP4Options(GP4Creator gp4)
        {
            // Check for Unassigned Gamedata Path Before Proceeding
            if (GamedataPathBox.IsDefault)
            {
#if DEBUG
                if (gp4.GamedataFolder.Remove(gp4.GamedataFolder.LastIndexOf('-')) == Testing.TestGamedataFolder.Remove(Testing.TestGamedataFolder.LastIndexOf('-'))) {
                    Print("Using Test Gamedata Folder.");
                }
                else
#endif
                {
                    FlashLabel("Info");
                    SetInfoLabelText("Please assign a valid Gamedata folder before building.\n");
                    return false;
                }
            }
            else if (Directory.Exists(GamedataPathBox.Text.Replace("\"", string.Empty)))
            {
                // Read Current Gamedata Folder Path From The Text Box
                gp4.GamedataFolder = GamedataPathBox.Text.Replace("\"", string.Empty);
                Print($"Set \"{gp4.GamedataFolder}\" as Gamedata folder.");
            }

            else {
                FlashLabel("Info");
                SetInfoLabelText("Invalid Gamedata folder path provided.\n");
                return false;
            }


            // Ensure Keystone is Present if Applicable
            if (gp4.SfoParams.category == "gd" && !gp4.IgnoreKeystone && !File.Exists($@"{gp4.GamedataFolder}\sce_sys\keystone"))
            {
                FlashLabel("Info");
                SetInfoLabelText($"ERROR; No keystone File Found In Project Folder.\n\n");
                return false;
            }


            // Assign blacklist contents
            gp4.FileBlacklist = FileBlacklistPathBox.Text.Split(',', ';', '|');


            // Set Package Passcode
            gp4.Passcode = PasscodePathBox.Text;


            // Load these two twats
            gp4.UseAbsoluteFilePaths = (bool) AbsoluteFilePathsBtn.Variable;
            gp4.IgnoreKeystone       = (bool) IgnoreKeystoneBtn.Variable;

            return true;
        }


        private void BeginGP4Creation(GP4Creator gp4)
        {
            var newGp4 = gp4.CreateGP4();

            // Check return value
            if (!File.Exists(newGp4))
            {
                if (newGp4 == string.Empty) {
                    SetInfoLabelText("One or multiple errors were detected during .gp4 creation");
                }
                else {
                    SetInfoLabelText("An unexpected error occured during .gp4 creation.");
                }


                Print($"  - newGp4: \"{newGp4}\")");
            }
            else {
                SetInfoLabelText(".gp4 Creation Successful.");
                Print($"  - .gp4 saved at: \"{newGp4}\"");
            }
        }
        #endregion



        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]


        /// <summary>
        /// Apply all the non-default .gp4 options and attempt project file creation.
        /// </summary>
        private void GP4CreationBtn_Click(object sender, EventArgs e)
        {
            if (ApplyandVerifyGP4Options(gp4))
            {
                BeginGP4Creation(gp4);
            }
            else {
                Print("Ahh fuck, eh.");
            }
        }



        /// <summary>
        /// Initialize a new FolderBrowserDialogue instance in which to select the gamedata folder.
        /// <br/> TODO: Implement switch.
        /// </summary>
        private void GamedataPathBrowseBtn_Click(object sender, EventArgs e)
        {
            if (StyleTest) { // Try The Newer "Hackey" Method //!
                using(var fileDialogue = new OpenFileDialog
                {
                    ValidateNames   = false,
                    CheckPathExists = false,
                    CheckFileExists = false,

                    Title    = "(Don't click anything IN the desired folder, this dialogue is terrible)", 
                    Filter   = "Folder Selection|*.",
                    FileName = "Enter the desired Folder, and press \"Open\"."
                })
                if (fileDialogue.ShowDialog() == DialogResult.OK)
                    GamedataPathBox.Set(fileDialogue.FileName.Remove(fileDialogue.FileName.LastIndexOf('\\')));

            }
            
            else { // Use the ghastly Directory Tree Dialogue to Choose A Folder
                using (var folderDialogue = new FolderBrowserDialog { Description = "Please Select the Desired Gamedata Folder" })
                {
                    if (folderDialogue.ShowDialog() == DialogResult.OK)
                        GamedataPathBox.Set(folderDialogue.SelectedPath);
                }
            }
            

            // Lazy fix
            ((Dobby.Button)sender).ForeColor = Color.White;
        }



        /// <summary>
        /// Initialize a new FolderBrowserDialogue Instance in which to choose the output directory for the created .gp4 project.
        /// </summary>
        private void Gp4OutputDirectoryBrowseBtn_Click(object sender, EventArgs e)
        {
            if (StyleTest) { // Try The Newer "Hackey" Method //!
                using(var fileDialogue = new OpenFileDialog
                {
                    ValidateNames   = false,
                    CheckPathExists = false,
                    CheckFileExists = false,
                    
                    Title    = "Select the intended output directory of the .gp4 project file.", 
                    Filter   = "Folder Selection|*.",
                    FileName = "Enter the desired Folder, and press \"Open\"."
                })
                if (fileDialogue.ShowDialog() == DialogResult.OK)
                    GP4OutputDirectoryPathBox.Set(fileDialogue.FileName.Remove(fileDialogue.FileName.LastIndexOf('\\')));

            }
            
            else { // Use the ghastly Directory Tree Dialogue to Choose A Folder
                using (var folderDialogue = new FolderBrowserDialog { Description = "Select the intended output directory of the .gp4 project file." })
                {
                    if (folderDialogue.ShowDialog() == DialogResult.OK)
                        GP4OutputDirectoryPathBox.Set(folderDialogue.SelectedPath);
                }
            }
            

            ((Dobby.Button)sender).ForeColor = Color.White;
        }



        /// <summary>
        /// Initialize a new OpenFileDialogue instance in which to select the base application package, for use in creating patch .gp4/.pkg's
        /// </summary>
        private void BaseGamePackageBrowseBtn_Click(object sender, EventArgs e)
        {
            using(var fileDialogue = new OpenFileDialog {
                Filter = "PS4 Application Package|*.pkg",
                Title = "Select the package /.pkg the patch package will be installed to."
            })
            if(fileDialogue.ShowDialog() == DialogResult.OK)
                BaseGamePackagePathBox.Set(fileDialogue.FileName);
            
            
            ((Dobby.Button)sender).ForeColor = Color.White;
        }


        /// <summary>
        /// Initialize a new OpenFileDialogue instance in which to select the desired files to exclude from the .gp4's file listing
        /// </summary>
        private void FileBlacklistBrowseBtn_Click(object sender, EventArgs e)
        {
            using(var fileDialogue = new OpenFileDialog {
                Title = "Select files you wish to exclude from the .gp4 project file (folders must be added manually, blame MS)",
                Multiselect = true
            })
            if(fileDialogue.ShowDialog() == DialogResult.OK)
                BaseGamePackagePathBox.Set(string.Join(";", fileDialogue.FileNames));


            ((Dobby.Button)sender).ForeColor = Color.White;
        }

        

        private void AbsoluteFilePathsBtn_Click(object control, EventArgs args) => CycleButtonVariable<bool>(control);
        
        private void IgnoreKeystoneBtn_Click(object control, EventArgs eventArgs)    => CycleButtonVariable<bool>(control);
        #endregion
    }
}
