using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
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
        /// Apply selected (or default) options for the package creation process, making sure there aren't any obvious errors that would cause the creation process to fail.
        /// </summary>
        /// <param name="orbisToolPath"> Absolute path to the PS4 package creation tools- specifically orbis-pub-cmd(-keystone).exe. Optionally takes a folder that it then searches for the tool inside of (by file name). </param>
        /// <param name="verbosity"> Switch between verbose (detailed / --no_progress_bar), and the default progress bar output modes for the build tool </param>
        /// <param name="tempDirectory"> An Alternate working/temporary directory for package creation process. </param>
        /// <param name="gp4Path"> Absolute path to the .gp4 Project file that's to be used in the package creation process. </param>
        /// <param name="outputPath"> The intended output directory for the completed package. </param>
        /// <returns> True if all seems well with the current options. </returns>
        private bool ApplyAndVerifyPkgOptions(ref string orbisToolPath, ref string verbosity, ref string tempDirectory, ref string gp4Path, ref string outputPath)
        {
            if (!OrbisToolPathBox.IsDefault)
            {
                orbisToolPath = OrbisToolPathBox.Text.Replace("\n", string.Empty);
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
                verbosity = "--no_progress_bar ";


            // Assign custom temp directory if one's been provided
            if (!TempDirectoryPathBox.IsDefault)
                tempDirectory = $"--tmp_path \"{TempDirectoryPathBox.Text.Replace("\n", string.Empty)}\"";
            


            // Verfiy Publishing Tool Directory
            if (Directory.Exists(orbisToolPath))
            {
                Print($"Directory provided in place of .exe path. Searching the following folder for publishing tools...\n - {orbisToolPath}");

                var files = Directory.GetFiles(orbisToolPath);

                foreach (var file in files)
                {
                    if (file.ToLower().Contains("-cmd")) {
                        orbisToolPath = file;
                        Print($"Using \"{orbisToolPath}\" as publishing tool path.");
                        break;
                    }
                    else if (file == files.Last())
                    {
                        FlashLabel("Info");
                        SetInfoLabelText("Build tool not found in provided folder (Expected Name: *-cmd*)");
                        return false;
                    }
                }
            }
            else if (!File.Exists(orbisToolPath))
            {
                FlashLabel("Info");
                SetInfoLabelText("Invalid path provided for fpkg build tool. (file doesn't exist)");
                return false;
            }



            // Verfiy .gp4 Project Path
            else if(!File.Exists(gp4Path))
            {
                FlashLabel("Info");
                SetInfoLabelText("Invalid path provided for .gp4 project file. (file doesn't exist)");
                return false;
            }


            // Set Output Directory as the current
            if (!Directory.Exists(outputPath))
            {
                FlashLabel("Info");
                SetInfoLabelText("Invalid output directory provided for finished package file. (directory doesn't exist)");
                return false;
            }



            // Return successfully
            return true;
        }


        /// <summary>
        /// Create and initialize a new Process in which to run the selected publishing tool
        /// </summary>
        /// <param name="orbisToolPath"> Absolute path to the PS4 package creation tools- specifically orbis-pub-cmd(-keystone).exe. Optionally takes a folder that it then searches for the tool inside of (by file name). </param>
        /// <param name="verbosity"> Switch between verbose (detailed / --no_progress_bar), and the default progress bar output modes for the build tool </param>
        /// <param name="tempDirectory"> An Alternate working/temporary directory for package creation process. </param>
        /// <param name="gp4Path"> Absolute path to the .gp4 Project file that's to be used in the package creation process. </param>
        /// <param name="outputPath"> The intended output directory for the completed package. </param>
        private void BeginPkgCreation(string orbisToolPath, string verbosity, string tempDirectory, string gp4Path, string outputPath)
        {
            // Put the provided options together
            var parameters = $"img_create --oformat pkg {verbosity ?? ""}--skip_digest {tempDirectory ?? ""} \"{gp4Path}\" \"{outputPath}\"";
            var errors = new List<string>();


            var buildProcess = new System.Diagnostics.Process() {
                StartInfo = new System.Diagnostics.ProcessStartInfo(orbisToolPath, parameters)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                },

                EnableRaisingEvents = true
            };

            buildProcess.OutputDataReceived += (_, data) =>
            {
                Print($"[orbis-pub-cmd]: {data?.Data ?? "null"}");
                
                if (data?.Data?.Length > 0)
                {
                    // TODO:
                    // * Have the section of errors orbis-pub-cmd outputs wrapped in braces appear before the more general part which otherwise preceeds it (so the useful part doesn't get cut off first)
                    if (data.Data.Contains("[Error]"))
                        errors.Add(data.Data.Replace("[Error]", "[ERROR] "));
                }
            };

            

            DisableFormChange = true;
            buildProcess.Start();
            buildProcess.BeginOutputReadLine();

            buildProcess.Exited += (prc, args) =>
            {
                if (buildProcess.ExitCode == 0)
                {
                    ActiveForm?.Invoke(SetInfoText, "Fake-Package creation process completed without errors.");
                }
                else if (buildProcess.ExitCode == 1)
                {
                    FlashLabel("Info");
                    ActiveForm?.Invoke(SetInfoText, $"{errors.First()}.{(errors.Count > 1 ? $" ({errors.Count - 1} more errors)" : string.Empty)}");
                }
                else {
                    FlashLabel("Info");
                    ActiveForm?.Invoke(SetInfoText, $"WARNING: Unexpected Exit Code from build tool ({buildProcess.ExitCode})");
                }

                DisableFormChange = false;
            };
        }
        #endregion




        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]

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
        /// Initialize a new OpenFileDialogue instance in which to select the .pkg build tool
        /// </summary>
        private void OrbisCmdPathBrowseBtn_Click(object sender, EventArgs e)
        {
            using(var fileDialogue = new OpenFileDialog {
                Filter = "Executable|*.exe",
                Title = "Select the fpkg creation tool"
            })
            if(fileDialogue.ShowDialog() == DialogResult.OK)
                OrbisToolPathBox.Set(fileDialogue.FileName);

         
            ((Dobby.Button)sender).ForeColor = Color.White;
        }


        /// <summary>
        /// Initialize a new OpenFileDialogue instance in which to choose the .gp4 project file
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
        /// Initialize either a new OpenFileDialogue or FolderBrowserDialog instance in which to choose the output directory of the finished package file.
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


            ((Dobby.Button)sender).ForeColor = Color.White;
        }

        /// <summary>
        /// Initialize either a new OpenFileDialogue or FolderBrowserDialog instance in which to choose a custom path for the temporary files created during the package creation process. (the ps4pub folder)
        /// </summary>
        private void TempDirectoryBrowseBtn_Click(object sender, EventArgs e)
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


            ((Dobby.Button)sender).ForeColor = Color.White;
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
