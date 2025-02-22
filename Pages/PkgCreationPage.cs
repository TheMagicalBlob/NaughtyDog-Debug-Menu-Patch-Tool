using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using static Dobby.Common;
#if DEBUG
#endif



namespace Dobby {
    public partial class PkgCreationPage : Form {
        /// <summary> Initialize a new instance of the PkgCreationPage Form. </summary>
        public PkgCreationPage() {
            InitializeComponent();
            InitializeAdditionalEventHandlers(Controls);

            foreach(Control control in Controls) {
                if(control.Name.Contains("PathBox")) {
                    control.MouseEnter += (sender, _) => ((Control)sender).Font = new Font(((Control)sender).Font.FontFamily, ((Control)sender).Font.Size, ((Control)sender).Font.Style ^ FontStyle.Underline);
                    control.MouseLeave += (sender, _) => ((Control)sender).Font = new Font(((Control)sender).Font.FontFamily, ((Control)sender).Font.Size, ((Control)sender).Font.Style ^ FontStyle.Underline);
                }
            }


            VerbosityBtn.Variable = true;
            CleanTempFilesBtn.Variable = true;

            Testing.AddStyleTestButton(this);
            // TODO:
            // * Maintain Settings For Page When Swapping Between gp4/pkg Creation Pages.. Or Just In General.
        }


        
        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]
        
        // :3 |\\
        #endregion



        
        //=============================================\\
        //--|   Background Function Delcarations   |---\\
        //=============================================\\
        #region [Background Function Delcarations]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orbisToolPath"></param>
        /// <param name="verbosity"></param>
        /// <param name="gp4Path"></param>
        /// <param name="outputPath"></param>
        /// <param name="tempDirectory"></param>
        /// <returns></returns>
        private bool ApplyAndVerifyPkgOptions(ref string orbisToolPath, ref string verbosity, ref string tempDirectory, ref string gp4Path, ref string outputPath)
        {
            if (!OrbisToolPathBox.IsDefault)
            {
                orbisToolPath = OrbisToolPathBox.Text.Replace("\n", string.Empty);

                if (Directory.Exists(orbisToolPath))
                {
                    Print($"Directory provided in place of .exe path. Searching the following folder for publishing tools...\n - {orbisToolPath}");

                    var files = Directory.GetFiles(orbisToolPath);

                    foreach (var file in files)
                    {
                        if (file.ToLower().Contains("pub-cmd")) {
                            orbisToolPath = file;
                            Print($"Using \"{orbisToolPath}\" as publishing tool path.");
                            break;
                        }
                        else if (file == files.Last()) {

                        }
                    }


                }
                else if (File.Exists(orbisToolPath)) {

                }
            }
            else {
                FlashLabel("Info");
                SetInfoLabelText("Please provide a path to the FPKG tools before building.");
                return false;
            }

            
            if (!GP4FilePathBox.IsDefault)
            {
                gp4Path = GP4FilePathBox.Text.Replace("\n", string.Empty);
            }
            else {
                FlashLabel("Info");
                SetInfoLabelText("Please provide a valid .gp4 path before building.");
                return false;
            }
            

            if (!OutputDirectoryPathBox.IsDefault)
            {
                outputPath = OutputDirectoryPathBox.Text.Replace("\n", string.Empty);
            }
            else {
                Print("Output directory unset, using same folder as .gp4 path");
                outputPath = Directory.GetParent(gp4Path).FullName;
            }

            


            // Assign chosen verbosity option
            if ((bool)VerbosityBtn.Variable)
            {
                verbosity = "--no_progress_bar ";
            }

            // Assign custom temp directory if one's been provided
            if (!TempDirectoryPathBox.IsDefault)
            {
                tempDirectory = $"--tmp_path \"{TempDirectoryPathBox.Text.Replace("\n", string.Empty)}\"";
            }


            // Verfiy Publishing Tool Directory
            if(!File.Exists(orbisToolPath)) {
                return false;
            }

            // Verfiy .gp4 Project Path
            else if(!File.Exists(gp4Path)) {
                MessageBox.Show($"Error: The Path Provided For The .gp4 Project Wasn't Valid. A Valid .gp4 Is Mandatory For .pkg Creation.\n\nProvided Path: {gp4Path}", "Invalid .gp4 Project File Path");

                // Force Reset Control Highlight, As The Message Box Stops The Control From Ever Resetting Automatically (Fix The Underlying Issue//!!!) 
                BuildPackageBtn.ForeColor = Color.FromArgb(255, 255, 255);

                if (MessageBox.Show("orbis-pub-cmd.exe And A .gp4 Are Necessary For .pkg Creation, Create New .gp4?", string.Empty,
                    MessageBoxButtons.YesNo) == DialogResult.OK)
                {
                    var gp4 = new libgp4.GP4Creator();
                    gp4.CreateGP4();
                }
                return false;
            }


            // Set Output Directory as the current
            if(!Directory.Exists(outputPath))
                outputPath = gp4Path.Remove(gp4Path.LastIndexOf("\\"));


            // Return successfully
            return true;
        }


        /// <summary>
        /// Create and initialize a new Process in which to run the selected publishing tool
        /// </summary>
        /// <param name="orbisToolPath"></param>
        /// <param name="verbosity"></param>
        /// <param name="tempDirectory"></param>
        /// <param name="gp4Path"></param>
        /// <param name="outputPath"></param>
        private void BeginPkgCreation(string orbisToolPath, string verbosity, string tempDirectory, string gp4Path, string outputPath)
        {
            // Put the provided options together
            var parameters = $"img_create --oformat pkg {verbosity ?? ""}--skip_digest {tempDirectory ?? ""} \"{gp4Path}\" \"{outputPath}\"";
            
            var buildProcess = new System.Diagnostics.Process() {
                StartInfo = new System.Diagnostics.ProcessStartInfo(orbisToolPath, parameters)
            };

            buildProcess.StartInfo.UseShellExecute = false;
            buildProcess.StartInfo.RedirectStandardOutput = true;
            buildProcess.OutputDataReceived += (prc, data) => Print($"[orbis-pub-cmd]: {data.Data}");

            buildProcess.BeginOutputReadLine();
            buildProcess.Start();

            MessageBox.Show(".pkg Creation Started; If The CMD Window Just Closes Immediately, Something Is Wrong With Your .gp4 Or Gamedata (Likely The Latter). Check Info/Help Page -> Pkg Creation Page Help");
        }
        #endregion



        //===================================\\
        //--|   Event Handler Functions   |--\\
        //===================================\\
        #region [Event Handler Functions]

        /// <summary>
        /// Switch to the GP4CreationPage to utilize libgp4.dll and make a new .gp4 project file.
        /// </summary>
        private void GP4CreationPageBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.Gp4CreationPage);


        /// <summary>
        /// Save the selected options and / or apply defaults to package creation options, then begin the pkg build process.
        /// </summary>
        private void LaunchOrbisPubCmdBtn_Click(object sender, EventArgs e)
        {
            string
                orbisToolPath = null,
                verbosity = null,
                tempDirectory = null,
                gp4Path = null,
                outputPath = null
            ;

            if (ApplyAndVerifyPkgOptions(ref orbisToolPath, ref verbosity, ref tempDirectory, ref gp4Path, ref outputPath))
            {
                BeginPkgCreation(orbisToolPath, verbosity, tempDirectory, gp4Path, outputPath);
            }
            else {
                Print("ERROR: Unable to begin package creation.");
            }
        }

        #endregion



        //=================================\\
        //--|   Control Event Handlers  |--\\
        //=================================\\
        #region [Control Event Handlers]
        /// <summary>
        /// Load orbis-pub-cmd.exe Binary And The Reqired .gp4 file If The Path Is Right
        /// </summary>
        private void OrbisCmdPathBrowseBtn_Click(object sender, EventArgs e)
        {
            using(var fileDialogue = new OpenFileDialog {
                    Filter = "Executable|*.exe",
                    Title = "Select orbis-pub-cmd.exe"
            })
            if(fileDialogue.ShowDialog() == DialogResult.OK)
                OrbisToolPathBox.Set(fileDialogue.FileName);

         
            ((Dobby.Button)sender).ForeColor = Color.White;
        }


        /// <summary>
        /// addme//!
        /// </summary>
        private void GP4FilePathBrowseBtn_Click(object sender, EventArgs e)
        {
            using(var fileDialogue = new OpenFileDialog {
                Filter = ".gp4 Project File|*.gp4",
                Title = "Select Your .gp4 File" 
            })
            if(fileDialogue.ShowDialog() == DialogResult.OK)
                GP4FilePathBox.Set(fileDialogue.FileName);


            ((Dobby.Button)sender).ForeColor = Color.White;
        }

        /// <summary>
        /// addme//!
        /// </summary>
        private void OutputDirectory_Click(object sender, EventArgs e)
        {
            if (StyleTest) { // Try The Newer "Hackey" Method
                using(var fileDialogue = new OpenFileDialog
                {
                    ValidateNames   = false,
                    CheckPathExists = false,
                    CheckFileExists = false,

                    Title    = "Choose A Directory You Want The Finished .pkg To Go, Or Close This Window To Use The App Directory",
                    Filter   = "Folder Selection|*.",
                    FileName = "Enter the desired Folder, and press \"Open\"."
                })
                if (fileDialogue.ShowDialog() == DialogResult.OK)
                    OutputDirectoryPathBox.Set(fileDialogue.FileName.Remove(fileDialogue.FileName.LastIndexOf('\\')));

            }
            
            else { // Use the ghastly Directory Tree Dialogue to Choose A Folder
                using (var folderDialogue = new FolderBrowserDialog { Description = "Choose A Directory You Want The Finished .pkg To Go, Or Close This Window To Use The App Directory" })
                {
                    if (folderDialogue.ShowDialog() == DialogResult.OK)
                        OutputDirectoryPathBox.Set(folderDialogue.SelectedPath);
                }
            }
        }

        /// <summary>
        /// addme//!
        /// </summary>
        private void TMPDirectoryItem_Click(object sender, EventArgs e)
        {
            if (StyleTest) { // Try The Newer "Hackey" Method
                using(var fileDialogue = new OpenFileDialog
                {
                    ValidateNames   = false,
                    CheckPathExists = false,
                    CheckFileExists = false,

                    Title    = "Choose A Temp Directory For Files Created During The .pkg Build Process",
                    Filter   = "Folder Selection|*.",
                    FileName = "Enter the desired Folder, and press \"Open\"."
                })
                if (fileDialogue.ShowDialog() == DialogResult.OK)
                    TempDirectoryPathBox.Set(fileDialogue.FileName.Remove(fileDialogue.FileName.LastIndexOf('\\')));

            }
            
            else { // Use the ghastly Directory Tree Dialogue to Choose A Folder
                using (var folderDialogue = new FolderBrowserDialog { Description = "Choose A Temp Directory For Files Created During The .pkg Build Process" })
                {
                    if (folderDialogue.ShowDialog() == DialogResult.OK)
                        TempDirectoryPathBox.Set(folderDialogue.SelectedPath);
                }
            }
        }


        
        /// <summary>
        /// Cycle between using the detailed output for orbis-pub-cmd, or the less informative progress bar
        /// </summary>
        private void VerbosityBtn_Click(object sender, EventArgs e) => CycleButtonVariable<bool>(sender);

        
        /// <summary>
        /// Toggle the option to delete the "ps4pub" folder orbis-pub-cmd creates during the image creation process
        /// </summary>
        private void CleanTempFilesBtn_Click(object sender, EventArgs e) => CycleButtonVariable<bool>(sender);
        #endregion
    }
}
