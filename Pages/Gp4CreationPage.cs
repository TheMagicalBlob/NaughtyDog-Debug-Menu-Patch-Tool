using libgp4;
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using static Dobby.Common;



namespace Dobby {
    internal partial class GP4CreationPage : Form {

        public GP4CreationPage() { //! Page Unfinished, Only Base Functionality Added
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
            

            // StyleTestBtn
            Button styleTestButton; 
            Controls.Add(styleTestButton = new Button()
            {
                Name = "StyleTestBtn",
                Size = new Size(112, 24),
                Location = new Point(294, 1),
                Text = "Toggle Style Test",
                Font = new Font("Verdana", 8F),
                BackColor = Color.FromArgb(100, 100, 100),
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                ForeColor = SystemColors.Control,
                Cursor = Cursors.Cross
            });
            styleTestButton.Click += StyleTestBtn_Click;
            styleTestButton.FlatAppearance.BorderSize = 0;
            styleTestButton.BringToFront();

            // TODO:
            // * Maintain Settings For Page When Swapping Between gp4/pkg Creation Pages.. Or Just In General.
        }





        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]
        private GP4Creator gp4;
        
        private OpenFileDialog fileDialogue;
        private FolderBrowserDialog folderDialogue;
        #endregion

        //=============================================\\
        //--|   Background Function Delcarations   |---\\
        //=============================================\\
        #region [Background Function Delcarations]

        private void ApplyandVerifyGP4Options(GP4Creator gp4)
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
                    SetInfoLabelText("Please Assign A Valid Gamedata Folder Before Building.\n");
                    return;
                }
            }
            else // Read Current Gamedata Folder Path From The Text Box
            {
                gp4.GamedataFolder = GamedataPathBox.Text.Replace("\"", string.Empty);
                SetInfoLabelText($"Set \"{gp4.GamedataFolder}\" as Gamedata Folder.");
            }


            // Ensure Keystone is Present if Applicable
            if (gp4.SfoParams.category == "gd" && !gp4.IgnoreKeystone && !File.Exists($@"{gp4.GamedataFolder}\sce_sys\keystone"))
            {
                FlashLabel("Info");
                SetInfoLabelText($"ERROR; No keystone File Found In Project Folder.\n\n");
                return;
            }


            // Assign blacklist contents
            gp4.FileBlacklist = FileBlacklistPathBox.Text.Split(',', ';', '|');


            // Set Package Passcode
            gp4.Passcode = PasscodePathBox.Text;


            // Load these two twats
            gp4.UseAbsoluteFilePaths = (bool) AbsoluteFilePathsBtn.Variable;
            gp4.IgnoreKeystone       = (bool) IgnoreKeystoneBtn.Variable;
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

        
        private void StyleTestBtn_Click(object sender, EventArgs e)
        {
            foreach (var item in Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    var control = (TextBox) item;
                    control.TextAlign ^= HorizontalAlignment.Center;
                }
            }
        }


        /// <summary>
        /// Apply all the non-default .gp4 options and attempt project file creation.
        /// </summary>
        private void GP4CreationBtn_Click(object sender, EventArgs e)
        {
            ApplyandVerifyGP4Options(gp4);
            BeginGP4Creation(gp4);
        }



        /// <summary>
        /// Initialize a new FolderBrowserDialogue instance in which to select the gamedata folder.
        /// <br/> TODO: Implement switch.
        /// </summary>
        private void GamedataPathBrowseBtn_Click(object sender, EventArgs e)
        {
            // Use the ghastly Directory Tree Dialogue to Choose A Folder
            if (true)
            {
                using (folderDialogue = new FolderBrowserDialog { Description = "Please Select the Desired Gamedata Folder" })
                {
                    if (folderDialogue.ShowDialog() == DialogResult.OK) {
                        GamedataPathBox.Set(folderDialogue.SelectedPath);
                    }
                }

            }
            // Use The Newer "Hackey" Method //!
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
                    GamedataPathBox.Set(fileDialogue.FileName.Remove(fileDialogue.FileName.LastIndexOf('\\')));
            }
            

            // Lazy fix
            ((Dobby.Button)sender).ForeColor = Color.White;
        }



        /// <summary>
        /// Initialize a new FolderBrowserDialogue Instance in which to choose the output directory for the created .gp4 project.
        /// </summary>
        private void Gp4OutputDirectoryBrowseBtn_Click(object sender, EventArgs e)
        {
            using(folderDialogue = new FolderBrowserDialog {
                Description = "Select the intended output directory of the .gp4 project file."
            })
            if(folderDialogue.ShowDialog() == DialogResult.OK)
                GP4OutputDirectoryPathBox.Set(folderDialogue.SelectedPath);

            
            ((Dobby.Button)sender).ForeColor = Color.White;
        }



        /// <summary>
        /// Initialize a new OpenFileDialogue instance in which to select the base application package, for use in creating patch .gp4/.pkg's
        /// </summary>
        private void BaseGamePackageBrowseBtn_Click(object sender, EventArgs e)
        {
            using(fileDialogue = new OpenFileDialog {
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
            using(fileDialogue = new OpenFileDialog {
                Title = "Select files you wish to exclude from the .gp4 project file (folders must be added manually, blame MS)",
                Multiselect = true
            })
            if(fileDialogue.ShowDialog() == DialogResult.OK)
                BaseGamePackagePathBox.Set(string.Join("; ", fileDialogue.FileNames));


            ((Dobby.Button)sender).ForeColor = Color.White;
        }

        

        private void AbsoluteFilePathsBtn_Click(object control, MouseEventArgs eventArgs) => CycleButtonVariable<bool>(control);
        
        private void IgnoreKeystoneBtn_Click(object control, MouseEventArgs eventArgs)    => CycleButtonVariable<bool>(control);
        #endregion
    }
}
