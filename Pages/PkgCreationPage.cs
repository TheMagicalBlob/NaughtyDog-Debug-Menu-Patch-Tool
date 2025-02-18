using System;
using System.IO;
using System.Drawing;
using static Dobby.Common;
using System.Windows.Forms;
#if DEBUG
using System.Linq;
#endif


namespace Dobby {
    public partial class PkgCreationPage : Form {
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

            // TODO: Maintain Settings For Page When Swapping Between gp4/pkg Creation Pages.. Or Just In General.
        }



        //==========================\\
        //--|   Page Variables   |--\\
        //==========================\\
        #region [Page Variables]

        private bool
            VerboseOutput,
            UseCstmTMPDirectory
        ;

        public OpenFileDialog fileDialogue;
        public FolderBrowserDialog folderDialogue;
        #endregion




        //=====================================\\
        //--|   Page Background Functions   |--\\
        //=====================================\\
        #region [Page Background Functions]
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

        private void DebugBtn2_Click(object sender, EventArgs e)
        {

        }

        private void Gp4PageBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.Gp4CreationPage);


        private void ScanForOrbisPubTools() {
#if DEBUG // Too Sus

            FileStream stream;
            byte[] Check = new byte[4];
            
            var FilesInCurrentDirectory = Directory.GetFiles(Directory.GetCurrentDirectory());

            foreach(var file in FilesInCurrentDirectory) {
                if(file.Contains("out.txt"))
                    continue;

                using(stream = File.OpenRead(file)) {
                    stream.Position = 0x100;
                    stream.Read(Check, 0, 4);

                    if(Check.SequenceEqual(new byte[] { 0x46, 0xD1, 0xB8 }) || Check.SequenceEqual(new byte[] { 0x50, 0x45, 0x00 }) || file.Contains("orbis-pub-cmd") || file.Contains("-keystone")) {
                        OrbisToolPathBox.Set(file);

                        SetInfoLabelText("Successfully found orbis-pub-cmd.exe");
                        Print($"  - \"{file}\" Set As OrbisPubCmdPath");
                        return;
                    }
                }
            }

            /*
            // A Bit Of An Intrusion, And Still Sus Even If The Exact Intent's Explicitly Stated
            for(; i < FoldersInCurrentDirectory.Length; ) {
                FilesInCurrentDirectory = Directory.GetFiles(FoldersInCurrentDirectory[++i]);
                goto CheckFiles;
            }
            */
#else
            SetInfoLabelText("Disabled Because it's sus to AV's.");
#endif
        }



        
        private void LaunchOrbisPubCmdBtn_Click(object sender, EventArgs e)
        {
            string
                orbisToolPath,
                gp4Path,
                outputPath,
                tempDirectory
            ;


            if (OrbisToolPathBox.IsDefault)
            {
                FlashLabel("Info");
                SetInfoLabelText("Please provide a path to the FPKG tools before building.");
                return;
            }
            else
                orbisToolPath = OrbisToolPathBox.Text.Replace("\n", string.Empty);

            
            if (GP4PathBox.IsDefault)
            {
                FlashLabel("Info");
                SetInfoLabelText("Please provide a valid .gp4 path before building.");
                return;
            }
            else
                gp4Path = GP4PathBox.Text.Replace("\n", string.Empty);
            

            if (OutputDirectoryPathBox.IsDefault)
            {
                Print("Output directory unset, using same folder as .gp4 path");
                outputPath = Directory.GetParent(gp4Path).FullName;
            }
            else
                outputPath = OutputDirectoryPathBox.Text.Replace("\n", string.Empty);


            if (TempDirectoryPathBox.IsDefault)
            {
                Print("//!");
                tempDirectory = null;
            }
            else
                tempDirectory = TempDirectoryPathBox.Text.Replace("\n", string.Empty);




            // Verfiy Publishing Tool Directory
            if(!File.Exists(orbisToolPath)) {
                if (MessageBox.Show("A Valid Path To The Fake Package / fpkg Toolset Was Not Provided, Would You Like To Scan The Current Folder For Publishing Tools Folder?", "Toolset Not Found, Provide A Valid Path", MessageBoxButtons.YesNo) == DialogResult.OK)
                    ScanForOrbisPubTools(); // Maybe Just Remove This And Make Them Do It Themselves

                // Force Reset Control Highlight, As The Message Box Stops The Control From Ever Resetting Automatically (Fix The Underlying Issue//!!!) 
                ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);
                return;
            }

            // Verfiy .gp4 Project Path
            else if(!File.Exists(gp4Path)) {
                MessageBox.Show($"Error: The Path Provided For The .gp4 Project Wasn't Valid. A Valid .gp4 Is Mandatory For .pkg Creation.\n\nProvided Path: {gp4Path}", "Invalid .gp4 Project File Path");

                // Force Reset Control Highlight, As The Message Box Stops The Control From Ever Resetting Automatically (Fix The Underlying Issue//!!!) 
                ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);

                if (MessageBox.Show("orbis-pub-cmd.exe And A .gp4 Are Necessary For .pkg Creation, Create New .gp4?", string.Empty,
                    MessageBoxButtons.YesNo) == DialogResult.OK)
                {
                    var gp4 = new libgp4.GP4Creator();
                    gp4.CreateGP4();
                }
                return;
            }


            // Set Output Directory as the current
            if(!Directory.Exists(outputPath))
                outputPath = gp4Path.Remove(gp4Path.LastIndexOf("\\"));

            string Parameters = $"img_create --oformat pkg  {(VerboseOutput ? "--no_progress_bar" : string.Empty)} --skip_digest {(UseCstmTMPDirectory ? $"--tmp_path \"{tempDirectory}\"" : string.Empty)} \"{gp4Path}\" \"{outputPath}\" > \"C:\\Users\\Blob\\Desktop\\out.txt\"";
#if DEBUG
            Dev.StartReadLogTest();
#endif
            var buildProcess = System.Diagnostics.Process.Start(orbisToolPath, Parameters);
            Print(Parameters);
#if !DEBUG
            MessageBox.Show(Parameters);
#endif

            MessageBox.Show(".pkg Creation Started; If The CMD Window Just Closes Immediately, Something Is Wrong With Your .gp4 Or Gamedata (Likely The Latter). Check Info/Help Page -> Pkg Creation Page Help");
        }

        #endregion



        //=================================\\
        //--|   Control Event Methods   |--\\
        //=================================\\
        #region [Control Event Methods]
        /// <summary>
        /// Load orbis-pub-cmd.exe Binary And The Reqired .gp4 file If The Path Is Right
        /// </summary>
        private void OrbisCmdPathBrowseBtn_Click(object sender, EventArgs e) {
            using(fileDialogue = new OpenFileDialog {
                    Filter = "Executable|*.exe",
                    Title = "Select orbis-pub-cmd.exe"
            })
            if(fileDialogue.ShowDialog() == DialogResult.OK)
                OrbisToolPathBox.Set(fileDialogue.FileName);

         
            ((Dobby.Button)sender).ForeColor = Color.White;
        }


        /// <summary>
        /// addme
        /// </summary>
        private void GP4PathBrowseBtn_Click(object sender, EventArgs e) {
            using(fileDialogue = new OpenFileDialog {
                Filter = ".gp4 Project File|*.gp4",
                Title = "Select Your .gp4 File" 
            })
            if(fileDialogue.ShowDialog() == DialogResult.OK)
                GP4PathBox.Set(fileDialogue.FileName);


            ((Dobby.Button)sender).ForeColor = Color.White;
        }

        /// <summary>
        /// addme
        /// </summary>
        private void OutputDirectory_Click(object sender, EventArgs e) {
            using(folderDialogue = new FolderBrowserDialog {
                Description = "Chose A Directory You Want The Finished .pkg To Go, Or Close This Window To Use The App Directory"
            })
            if(folderDialogue.ShowDialog() == DialogResult.OK)
                OutputDirectoryPathBox.Set(folderDialogue.SelectedPath);

            ((Dobby.Button)sender).ForeColor = Color.White;
        }

        /// <summary>
        /// addme
        /// </summary>
        private void TMPDirectoryItem_Click(object sender, EventArgs e) {
            using(folderDialogue = new FolderBrowserDialog {
                Description = "Chose A Temp Directory For Files Created During The .pkg Build Process"
            })
            if(folderDialogue.ShowDialog() == DialogResult.OK)
                TempDirectoryPathBox.Set(folderDialogue.SelectedPath);


            ((Dobby.Button)sender).ForeColor = Color.White;
        }

        


        private void VerbosityBtn_Click(object sender, EventArgs e) => CycleButtonVariable<bool>(sender);
        #endregion
    }
}
