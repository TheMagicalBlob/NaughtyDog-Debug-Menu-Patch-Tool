using libgp4;
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using static Dobby.Common;



namespace Dobby {
    internal partial class GP4CreationPage : Form {

        /// <summary>
        /// Initialize a new instance of the GP4CreationPage Form.
        /// </summary>
        public GP4CreationPage()
        {
            InitializeComponent();
            InitializeAdditionalEventHandlers(this);
            
            foreach(Control control in Controls) {
                if(control.Name.Contains("PathBox")) {
                    control.TabStop = false;
                    control.MouseEnter += (sender, _) => ((Control)sender).Font = new Font(((Control)sender).Font.FontFamily, ((Control)sender).Font.Size, ((Control)sender).Font.Style ^ FontStyle.Underline);
                    control.MouseLeave += (sender, _) => ((Control)sender).Font = new Font(((Control)sender).Font.FontFamily, ((Control)sender).Font.Size, ((Control)sender).Font.Style ^ FontStyle.Underline);
                }
                else if (control.Name.Contains("Btn"))
                    control.TabStop = false;
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
                LoggingMethod = (object msg) => Dev?.Print(msg)
            };
            GP4Creator.DebugOutput = true;
            

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

        /// <summary>
        /// Apply selected (or default) options for the .gp4 project file creation process, making sure there aren't any obvious errors that might otherwise cause the process to fail.
        /// </summary>
        /// <param name="gp4"> The current GP4Creator instance to apply &amp; verify options for. </param>
        /// <returns> True if all seems well with the current options. </returns>
        private bool ApplyandVerifyGP4Options(GP4Creator gp4)
        {
            // Verify provided gamedata folder path for the .gp4 creation process.
            if (GamedataPathBox.IsDefault())
            {
#if DEBUG
                if ((Testing.TestGamedataFolder?.Length ?? 0) != 0)
                {
                    if (Directory.Exists(Testing.TestGamedataFolder ?? "nani??"))
                    {
                        Dev?.Print("Using assigned TestGamedataFolder Path.");
                        gp4.GamedataFolder = Testing.TestGamedataFolder;
                    }
                    else {
                        Dev?.Print("A value was assigned to TestGamedataFolder, but the path is not currently valid");

                        UpdateLabel("Invalid TestGamedataFolder Path Provided.");
                        return false;
                    }
                }
                else
#endif
                {
                    UpdateLabel("Please assign a valid Gamedata folder before building.", true);
                    return false;
                }
            }
            else if (!Directory.Exists(GamedataPathBox?.Text?.Replace("\"", string.Empty)))
            {
                UpdateLabel("Invalid Gamedata folder path provided.", true);
                return false;
            }
            else {
                gp4.GamedataFolder = GamedataPathBox?.Text?.Replace("\"", string.Empty);
            }



            // Apply output directory for .gp4 project if one's been provided
            if (!GP4OutputDirectoryPathBox.IsDefault()) {
                gp4.OutputDirectory = GP4OutputDirectoryPathBox?.Text?.Replace("\n", string.Empty);
            }
            else {
                Dev?.Print("Using default output directory for .gp4 project file.");
            }



            // Ensure Keystone is Present in base game packages, if included
            if (gp4.SfoParams.category == "gd" && !gp4.IgnoreKeystone && !File.Exists($@"{gp4.GamedataFolder}\sce_sys\keystone"))
            {
                UpdateLabel($"ERROR: No keystone File Found In Project Folder. (sce_sys\\keystone)", true);
                return false;
            }



            // Assign blacklist contents
            if (!FileBlacklistPathBox.IsDefault())
            {
                if (new char[] { ',', ';', '|' }.Any(separator => FileBlacklistPathBox.Text.Contains(separator)))
                {
                    gp4.FileBlacklist = FileBlacklistPathBox?.Text?.Split(',', ';', '|');
                }
                else
                    gp4.FileBlacklist = new string[] { FileBlacklistPathBox?.Text };
            }



            // Set Package Passcode
            if (PasscodePathBox.IsDefault())
            {
                gp4.Passcode = PasscodePathBox?.Text ?? "00000000000000000000000000000000";
            }
            else {
                // Format improper passcodes
                if (PasscodePathBox.Text.Length < 32)
                {
                    Dev?.Print($"Padding provided passcode ({32 - PasscodePathBox.Text.Length} characters missing)");
                    PasscodePathBox.Set(gp4.Passcode = PasscodePathBox.Text.PadRight(32, '0'));
                }
                else if (PasscodePathBox.Text.Length > 32)
                {
                    Dev?.Print($"Truncating provided passcode ({PasscodePathBox.Text.Length - 32} additional characters provided)");
                    PasscodePathBox.Set(gp4.Passcode = PasscodePathBox.Text.Remove(32));
                }
                else
                    gp4.Passcode = PasscodePathBox.Text;
            }


            // Load these two twats
            gp4.UseAbsoluteFilePaths = (bool) AbsoluteFilePathsBtn.Variable;
            gp4.IgnoreKeystone       = (bool) IgnoreKeystoneBtn.Variable;

            return true;
        }



        /// <summary>
        /// Begin the .gp4 creation process for the current GP4Creator instance, then report the result via the info label.
        /// </summary>
        /// <param name="gp4"> The GP4Creator instance in which to begin the .gp4 creation process. </param>
        private void BeginGP4Creation(GP4Creator gp4)
        {
            var newGp4 = gp4.CreateGP4();

            // Check return value
            if (!File.Exists(newGp4))
            {
                if (newGp4 == string.Empty) {
                    UpdateLabel("One or multiple errors were detected during .gp4 creation");
                }
                else {
                    UpdateLabel("An unexpected error occured during .gp4 creation.");
                }


                Dev?.Print($"  - newGp4: \"{newGp4}\")");
            }
            else {
                UpdateLabel(".gp4 Creation Successful.");
                Dev?.Print($"  - .gp4 saved at: \"{newGp4}\"");
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
                Dev?.Print("ApplyandVerifyGP4Options(GP4Creator) returned false, .gp4 creation not attempted.");
            }
        }


        /// <summary>
        /// Initialize either a new OpenFileDialogue or FolderBrowserDialog instance in which to select the gamedata folder.
        /// </summary>
        private void GamedataPathBrowseBtn_Click(object sender, EventArgs e)
        {
            if (StyleTest) { // Try The Newer "Hackey" Method //!
                using(var fileDialogue = new OpenFileDialog
                {
                    ValidateNames   = false,
                    CheckPathExists = false,
                    CheckFileExists = false,

                    Title    = "Please Select the Desired Gamedata Folder", 
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
            

            ((Dobby.Button)sender).ForeColor = Color.White;
        }


        /// <summary>
        /// Initialize either a new OpenFileDialogue or FolderBrowserDialog instance in which to choose the output directory for the created .gp4 project.
        /// </summary>
        private void GP4OutputDirectoryBrowseBtn_Click(object sender, EventArgs e)
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
        /// Initialize a new OpenFileDialogue instance in which to select the base game package necessary in the creation of PS4 patch .pkg's.
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
        /// Initialize a new OpenFileDialogue instance in which to select the desired files to exclude from the .gp4's file listing.
        /// </summary>
        private void FileBlacklistBrowseBtn_Click(object sender, EventArgs e)
        {
            using(var fileDialogue = new OpenFileDialog {
                Title = "Select files you wish to exclude from the .gp4 project file (folders must be added manually, blame MS)",
                Multiselect = true
            })
            if(fileDialogue.ShowDialog() == DialogResult.OK)
                FileBlacklistPathBox.Set((FileBlacklistPathBox.IsDefault() ? FileBlacklistPathBox.Text : "") + string.Join(";", fileDialogue.FileNames));


            ((Dobby.Button)sender).ForeColor = Color.White;
        }
        #endregion
    }
}
