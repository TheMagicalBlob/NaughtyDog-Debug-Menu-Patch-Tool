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
                if(control.Name.Contains("PathBox") || control.Name.Contains("DirectoryBox")) {
                    control.MouseEnter += (sender, _) => ((Control)sender).Font = new Font(((Control)sender).Font.FontFamily, ((Control)sender).Font.Size, ((Control)sender).Font.Underline ? FontStyle.Bold : FontStyle.Bold | FontStyle.Underline);
                    control.MouseLeave += (sender, _) => ((Control)sender).Font = new Font(((Control)sender).Font.FontFamily, ((Control)sender).Font.Size, ((Control)sender).Font.Underline ? FontStyle.Bold : FontStyle.Bold | FontStyle.Underline);
                }
            }

            InfoLabel.AccessibleRole = AccessibleRole;

            // TODO: Maintain Settings For Page When Swapping Between gp4/pkg Creation Pages.. Or Just In General.

            OutputPath = Directory.GetCurrentDirectory();
            TempDirectoryBtn.Variable = false;
        }



        //////////////////\\\\\\\\\\\\\\\\\
        ///--     Page Variables      --\\\
        //////////////////\\\\\\\\\\\\\\\\\

#if DEBUG
        public static object[] DebugPeek() {
            return new object[] {
                OrbisToolPath,
                GP4Path,
                TMPDirectory,
                OutputPath,
                //VerboseOutput,
                //UseCstmTMPDirectory
            };
        }

        private static string
#else
        private string
#endif
            OrbisToolPath = "?",
            GP4Path       = "?",
            TMPDirectory  = "?",
            OutputPath    = "?"
        ;

        
        private bool
            VerboseOutput,
            UseCstmTMPDirectory
        ;

        public OpenFileDialog fileDialogue;
        public FolderBrowserDialog folderDialogue;



        //=====================================\\
        //--|   Page Background Functions   |--\\
        //=====================================\\
        #region [Page Background Functions]
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
                        OrbisCmdPathBox.Text = OrbisToolPath = file;

                        Print($"{file}\\{OrbisToolPath} Set As OrbisPubCmdPath");
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



        
        private void LaunchOrbisPubCmdBtn_Click(object sender, EventArgs e) {

            // Verfiy Publishing Tool Directory
            if(!File.Exists(OrbisToolPath)) {
                if (MessageBox.Show("A Valid Path To The Fake Package / fpkg Toolset Was Not Provided, Would You Like To Scan The Current Folder For Publishing Tools Folder?", "Toolset Not Found, Provide A Valid Path", MessageBoxButtons.YesNo) == DialogResult.OK)
                    ScanForOrbisPubTools(); // Maybe Just Remove This And Make Them Do It Themselves

                // Force Reset Control Highlight, As The Message Box Stops The Control From Ever Resetting Automatically (Fix The Underlying Issue//!!!) 
                ((Control)sender).ForeColor = Color.FromArgb(255, 255, 255);
                return;
            }

            // Verfiy .gp4 Project Path
            else if(!File.Exists(GP4Path)) {
                MessageBox.Show($"Error: The Path Provided For The .gp4 Project Wasn't Valid. A Valid .gp4 Is Mandatory For .pkg Creation.\n\nProvided Path: {GP4Path}", "Invalid .gp4 Project File Path");

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


            // Set Output Directory As The Current Directory Dobby's In
            if(!Directory.Exists(OutputPath))
                OutputPath = GP4Path.Remove(GP4Path.LastIndexOf(@"\"));

            string Parameters = $"img_create --oformat pkg  {(VerboseOutput ? "--no_progress_bar" : string.Empty)} --skip_digest {(UseCstmTMPDirectory ? $"--tmp_path \"{TMPDirectory}\"" : string.Empty)} \"{GP4Path}\" \"{OutputPath}\" > \"C:\\Users\\Blob\\Desktop\\out.txt\"";
#if DEBUG
            Dev.StartReadLogTest();
#endif
            System.Diagnostics.Process.Start(OrbisToolPath, Parameters);
            Print(Parameters);
#if !DEBUG
            MessageBox.Show(Parameters);
#endif

            MessageBox.Show(".pkg Creation Started; If The CMD Window Just Closes Immediately, Something Is Wrong With Your .gp4 Or Gamedata (Likely The Latter). Check Info/Help Page -> Pkg Creation Page Help");
        }


        /// <summary> Invert the VerboseOutput bool And Replace The Last Word In The Button Text To Reflect The Change
        /// </summary>
        private void VerbosityBtn_Click(object sender, EventArgs e) => ToggleBtnVar<bool>(sender);

        /// <summary> Toggle Whether Or Not To Add The -tmp-
        /// </summary>
        private void TempDirectoryBtn_Click(object sender, EventArgs e) {
            ToggleBtnVar<bool>(sender);

            if(!(UseCstmTMPDirectory ^= true)) {
                TMPDirectory = string.Empty;
                TMPDirectoryBox.Text = "Using This PC's Default TMP Directory";
                return;
            }

            TMPDirectoryBox.Text = TMPDirectory = $"{Directory.GetCurrentDirectory()}\\TMP";
            Update();
        }
#endregion


        /////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Path Box/Button Interactions      --\\\
        /////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary> Load orbis-pub-cmd.exe Binary And The Reqired .gp4 file If The Path Is Right
        /// </summary>
        private void OrbisCmdPathBrowseBtn_Click(object sender, EventArgs e) {
            using(var fileDialog = new OpenFileDialog {
                    Filter = "Executable|*.exe",
                    Title = "Select orbis-pub-cmd.exe"
            })
            if(fileDialog.ShowDialog() == DialogResult.OK)
                OrbisCmdPathBox.Text = OrbisToolPath = fileDialog.FileName;

         
            ((Dobby.Button)sender).ForeColor = Color.White;
        }

        /// <summary>
        /// addme
        /// </summary>
        private void GP4Path_Interact(object sender, EventArgs e) {
            if(((Control)sender).GetType() == typeof(Button)) {
                using(fileDialogue = new OpenFileDialog { Filter = ".gp4 Project File|*.gp4", Title = "Select Your .gp4 File"  })
                    if(fileDialogue.ShowDialog() == DialogResult.OK)
                        GP4PathBox.Text = GP4Path = fileDialogue.FileName;
            }
            else
                if(File.Exists(((Control)sender).Text.Replace("\"", "")))
                    GP4PathBox.Text = GP4Path = ((Control)sender).Text.Replace("\"", "");


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
                OutputDirectoryBox.Text = OutputPath = folderDialogue.SelectedPath;

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
                TMPDirectoryBox.Text = TMPDirectory = folderDialogue.SelectedPath;


            ((Dobby.Button)sender).ForeColor = Color.White;
        }

        


        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        private void Gp4PageBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.Gp4CreationPage);


        private Label SeperatorLine0;
        private Label SeperatorLine1;
        private Label SeperatorLine2;
        private Label OrbisToolPathLabel;
        private Label Gp4PathLabel;
        private Label OutputDirectoryLabel;
        private Label TmpDirectoryLabel;
        private Button CreditsBtn;
        private Label MainLabel;
        private Button Gp4PageBtn;
        private TextBox OrbisCmdPathBox;
        private Button CmdPathBtn;
        private TextBox GP4PathBox;
        private Button GP4PathBtn;
        private TextBox OutputDirectoryBox;
        private Button OutputDirectoryBtn;
        private TextBox TMPDirectoryBox;
        private Button TMPDirectoryBtn;
        private Button InfoHelpBtn;
        private Button BackBtn;
        private Label Info;
        #endregion
    }
}
