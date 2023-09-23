using libdebug;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Drawing;
using System.Net.Sockets;
using static Dobby.Common;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace Dobby {
    public class PkgCreationPage : Form {

        public PkgCreationPage() {
            InitializeComponent();
            AddControlEventHandlers(Controls);
        }

        string
            GP4Path,
            TMPPath,
            OrbisPubCmdPath,
            OutputDirectory
        ;

        bool VerboseOutput = true, SpecifyTMPDirectory = false, IsFirstOpen = true, IsBuildReady;

        public void InitializeComponent() {
            this.CmdPathLabel = new System.Windows.Forms.Label();
            this.LoadFilesButton = new System.Windows.Forms.Button();
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.SeperatorLabel2 = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.MainLabel = new System.Windows.Forms.Label();
            this.SeperatorLabel0 = new System.Windows.Forms.Label();
            this.BorderBox = new System.Windows.Forms.GroupBox();
            this.StartPkgCreationBtn = new System.Windows.Forms.Button();
            this.VerbosityBtn = new System.Windows.Forms.Button();
            this.GP4PathLabel = new System.Windows.Forms.Label();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.SeperatorLabel1 = new System.Windows.Forms.Label();
            this.OutputDirectoryLabel = new System.Windows.Forms.Label();
            this.TMPPathLabel = new System.Windows.Forms.Label();
            this.TempDirectoryBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmdPathLabel
            // 
            this.CmdPathLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.CmdPathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.CmdPathLabel.Location = new System.Drawing.Point(1, 116);
            this.CmdPathLabel.Name = "CmdPathLabel";
            this.CmdPathLabel.Size = new System.Drawing.Size(317, 19);
            this.CmdPathLabel.TabIndex = 32;
            this.CmdPathLabel.Text = "No Program Path Loaded";
            this.CmdPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadFilesButton
            // 
            this.LoadFilesButton.BackColor = System.Drawing.Color.DimGray;
            this.LoadFilesButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.LoadFilesButton.FlatAppearance.BorderSize = 0;
            this.LoadFilesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadFilesButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.LoadFilesButton.ForeColor = System.Drawing.SystemColors.Control;
            this.LoadFilesButton.Location = new System.Drawing.Point(1, 236);
            this.LoadFilesButton.Name = "LoadFilesButton";
            this.LoadFilesButton.Size = new System.Drawing.Size(317, 23);
            this.LoadFilesButton.TabIndex = 31;
            this.LoadFilesButton.Text = "Browse For OrbisPubCmd And .gp4 Paths...";
            this.LoadFilesButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoadFilesButton.UseVisualStyleBackColor = false;
            this.LoadFilesButton.Click += new System.EventHandler(this.LoadFilesButton_Click);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 270);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(317, 23);
            this.InfoHelpBtn.TabIndex = 15;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            // 
            // SeperatorLabel2
            // 
            this.SeperatorLabel2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel2.Location = new System.Drawing.Point(2, 249);
            this.SeperatorLabel2.Name = "SeperatorLabel2";
            this.SeperatorLabel2.Size = new System.Drawing.Size(316, 20);
            this.SeperatorLabel2.TabIndex = 14;
            this.SeperatorLabel2.Text = "____________________________________________";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 320);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(317, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(3, 345);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(313, 19);
            this.Info.TabIndex = 7;
            this.Info.Text = "======================================";
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.DimGray;
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 295);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(317, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.BackColor = System.Drawing.Color.DimGray;
            this.MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MinimizeBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimizeBtn.Location = new System.Drawing.Point(273, 2);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new System.Drawing.Size(23, 23);
            this.MinimizeBtn.TabIndex = 19;
            this.MinimizeBtn.Text = "--";
            this.MinimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MinimizeBtn.UseVisualStyleBackColor = false;
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.DimGray;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ExitBtn.Location = new System.Drawing.Point(295, 2);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(23, 23);
            this.ExitBtn.TabIndex = 18;
            this.ExitBtn.Text = "X";
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitBtn.UseVisualStyleBackColor = false;
            // 
            // MainBox
            // 
            this.MainBox.Location = new System.Drawing.Point(1, -4);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(318, 32);
            this.MainBox.TabIndex = 5;
            this.MainBox.TabStop = false;
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.25F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(2, 3);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(314, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "fPKG Creation Page";
            // 
            // SeperatorLabel0
            // 
            this.SeperatorLabel0.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel0.Location = new System.Drawing.Point(2, 12);
            this.SeperatorLabel0.Name = "SeperatorLabel0";
            this.SeperatorLabel0.Size = new System.Drawing.Size(316, 20);
            this.SeperatorLabel0.TabIndex = 33;
            this.SeperatorLabel0.Text = "____________________________________________";
            // 
            // BorderBox
            // 
            this.BorderBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.BorderBox.Location = new System.Drawing.Point(0, -6);
            this.BorderBox.Name = "BorderBox";
            this.BorderBox.Size = new System.Drawing.Size(319, 373);
            this.BorderBox.TabIndex = 34;
            this.BorderBox.TabStop = false;
            // 
            // StartPkgCreationBtn
            // 
            this.StartPkgCreationBtn.BackColor = System.Drawing.Color.DimGray;
            this.StartPkgCreationBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.StartPkgCreationBtn.FlatAppearance.BorderSize = 0;
            this.StartPkgCreationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartPkgCreationBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.StartPkgCreationBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.StartPkgCreationBtn.Location = new System.Drawing.Point(1, 33);
            this.StartPkgCreationBtn.Name = "StartPkgCreationBtn";
            this.StartPkgCreationBtn.Size = new System.Drawing.Size(317, 23);
            this.StartPkgCreationBtn.TabIndex = 23;
            this.StartPkgCreationBtn.Text = "Build .pkg File";
            this.StartPkgCreationBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StartPkgCreationBtn.UseVisualStyleBackColor = false;
            this.StartPkgCreationBtn.Click += new System.EventHandler(this.StartPkgCreationBtn_Click);
            // 
            // VerbosityBtn
            // 
            this.VerbosityBtn.BackColor = System.Drawing.Color.DimGray;
            this.VerbosityBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.VerbosityBtn.FlatAppearance.BorderSize = 0;
            this.VerbosityBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerbosityBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.VerbosityBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.VerbosityBtn.Location = new System.Drawing.Point(1, 56);
            this.VerbosityBtn.Name = "VerbosityBtn";
            this.VerbosityBtn.Size = new System.Drawing.Size(317, 23);
            this.VerbosityBtn.TabIndex = 35;
            this.VerbosityBtn.Text = "orbis-pub-cmd Output Mode: Details";
            this.VerbosityBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VerbosityBtn.UseVisualStyleBackColor = false;
            this.VerbosityBtn.Click += new System.EventHandler(this.VerbosityBtn_Click);
            // 
            // GP4PathLabel
            // 
            this.GP4PathLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.GP4PathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GP4PathLabel.Location = new System.Drawing.Point(1, 139);
            this.GP4PathLabel.Name = "GP4PathLabel";
            this.GP4PathLabel.Size = new System.Drawing.Size(317, 19);
            this.GP4PathLabel.TabIndex = 36;
            this.GP4PathLabel.Text = "No .gp4 Selected";
            this.GP4PathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PathBox
            // 
            this.PathBox.BackColor = System.Drawing.Color.Gray;
            this.PathBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.PathBox.ForeColor = System.Drawing.SystemColors.Window;
            this.PathBox.Location = new System.Drawing.Point(3, 208);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(313, 23);
            this.PathBox.TabIndex = 32;
            this.PathBox.Text = "Paste Any File Path Here, Or Use The Browse Button";
            this.PathBox.TextChanged += new System.EventHandler(this.ExecutablePathBox_TextChanged);
            // 
            // SeperatorLabel1
            // 
            this.SeperatorLabel1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel1.Location = new System.Drawing.Point(2, 97);
            this.SeperatorLabel1.Name = "SeperatorLabel1";
            this.SeperatorLabel1.Size = new System.Drawing.Size(316, 20);
            this.SeperatorLabel1.TabIndex = 29;
            this.SeperatorLabel1.Text = "____________________________________________";
            // 
            // OutputDirectoryLabel
            // 
            this.OutputDirectoryLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.OutputDirectoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.OutputDirectoryLabel.Location = new System.Drawing.Point(1, 162);
            this.OutputDirectoryLabel.Name = "OutputDirectoryLabel";
            this.OutputDirectoryLabel.Size = new System.Drawing.Size(317, 19);
            this.OutputDirectoryLabel.TabIndex = 38;
            this.OutputDirectoryLabel.Text = "Using Current Directory For .pkg Output";
            this.OutputDirectoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TMPPathLabel
            // 
            this.TMPPathLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.TMPPathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.TMPPathLabel.Location = new System.Drawing.Point(1, 185);
            this.TMPPathLabel.Name = "TMPPathLabel";
            this.TMPPathLabel.Size = new System.Drawing.Size(317, 19);
            this.TMPPathLabel.TabIndex = 37;
            this.TMPPathLabel.Text = "Using This PC\'s Default TMP Directory";
            this.TMPPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TempDirectoryBtn
            // 
            this.TempDirectoryBtn.BackColor = System.Drawing.Color.DimGray;
            this.TempDirectoryBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.TempDirectoryBtn.FlatAppearance.BorderSize = 0;
            this.TempDirectoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TempDirectoryBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.TempDirectoryBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.TempDirectoryBtn.Location = new System.Drawing.Point(1, 81);
            this.TempDirectoryBtn.Name = "TempDirectoryBtn";
            this.TempDirectoryBtn.Size = new System.Drawing.Size(317, 23);
            this.TempDirectoryBtn.TabIndex = 39;
            this.TempDirectoryBtn.Text = "Use Custom Temp Directory: No";
            this.TempDirectoryBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TempDirectoryBtn.UseVisualStyleBackColor = false;
            this.TempDirectoryBtn.Click += new System.EventHandler(this.TempDirectoryBtn_Click);
            // 
            // PkgCreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 366);
            this.Controls.Add(this.TempDirectoryBtn);
            this.Controls.Add(this.OutputDirectoryLabel);
            this.Controls.Add(this.TMPPathLabel);
            this.Controls.Add(this.LoadFilesButton);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.GP4PathLabel);
            this.Controls.Add(this.VerbosityBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.CmdPathLabel);
            this.Controls.Add(this.StartPkgCreationBtn);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.SeperatorLabel2);
            this.Controls.Add(this.SeperatorLabel1);
            this.Controls.Add(this.SeperatorLabel0);
            this.Controls.Add(this.BorderBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PkgCreationPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary> Open A File Dialog Window To Select The orbis-pub-cmd.exe Binary And The Reqired .gp4 file
        /// </summary>
        private void LoadFilesButton_Click(object sender, EventArgs e) {
            bool SelectedFileWasExe;
            FileDialog file = new OpenFileDialog {
                Filter = ".gp4 or .exe|*.gp4;*.exe",
                Title = "Select Your .gp4 File/orbis-pub-cmd.exe (The Order Doesn't Matter)"
            };

            if(file.ShowDialog() == DialogResult.OK)
                SelectedFileWasExe = LoadFilesFromSelectedPath(file.FileName);
            else return;


            file = new OpenFileDialog {
                Filter = (SelectedFileWasExe ? "gp4 Project|*.gp4" : "orbis-pub-cmd path|*.exe"),
                Title = $"Select {(SelectedFileWasExe ? "Your .gp4 Path" : "orbis-pub-cmd")}"
            };
            if(file.ShowDialog() == DialogResult.OK)
                LoadFilesFromSelectedPath(file.FileName);
            else return;

            FolderBrowserDialog Folder = new FolderBrowserDialog {
                Description = "Chose A Directory You Want The Finished .pkg To Go, Or Close This Window To Use The App Directory"
            };
            if(Folder.ShowDialog() == DialogResult.OK)
                OutputDirectoryLabel.Text = OutputDirectory = Folder.SelectedPath;
            else {
                OutputDirectoryLabel.Text = "Using Current Directory For.pkg Output";
                OutputDirectory = Directory.GetCurrentDirectory();
            }
        }

        /// <summary> Load orbis-pub-cmd.exe Binary And The Reqired .gp4 file If The Path Is Right
        /// </summary>
        private void ExecutablePathBox_TextChanged(object sender, EventArgs e) {
            var TextBox = ((Control)sender);

            if(File.Exists(TextBox.Text.Replace("\"", "")))
                LoadFilesFromSelectedPath(TextBox.Text.Replace("\"", ""));
        }

        /// <summary> Edit Related Labels
        /// </summary>
        public bool LoadFilesFromSelectedPath(string Path) {
            if(Path.Contains(".exe")) CmdPathLabel.Text = OrbisPubCmdPath = Path;
            if(Path.Contains(".gp4")) GP4PathLabel.Text = GP4Path = Path;

            if(OrbisPubCmdPath != "" && GP4Path != "" && OutputDirectory != "") IsBuildReady = true;
            return Path.Contains(".exe") ? true : false; 
        }



        private void StartPkgCreationBtn_Click(object sender, EventArgs e) {
            if(!IsBuildReady) {
                MessageBox.Show("orbis-pub-cmd.exe And A .gp4 Are Necessary For .pkg Creation");
                return;
            }

            string Parameters = $"img_create --oformat pkg  {(VerboseOutput ? "--no_progress_bar" : string.Empty)} --skip_digest {(SpecifyTMPDirectory ? $"--tmp_path {TMPPath}" : string.Empty)} {GP4Path} {OutputDirectory}";
            System.Diagnostics.Process.Start(OrbisPubCmdPath, Parameters);

            MessageBox.Show(".pkg Creation Started; If The CMD Window Closes Immediately, You Did Something Wrong. Try ");
        }

        private void VerbosityBtn_Click(object sender, EventArgs e) {
            VerboseOutput = !VerboseOutput;
            ((Control)sender).Text = ((Control)sender).Text.Remove(((Control)sender).Text.LastIndexOf(' ') + 1) + (VerboseOutput ? "Details" : "Bar");
        }
        private void TempDirectoryBtn_Click(object sender, EventArgs e) {
            ((Control)sender).Text = ((Control)sender).Text.Remove(((Control)sender).Text.LastIndexOf(' ') + 1) + (SpecifyTMPDirectory ? "No" : "Yes");
            Refresh();

            if(!SpecifyTMPDirectory) {
                FolderBrowserDialog Folder = new FolderBrowserDialog {
                    Description = "Select Your Preffered Temp Directory"
                };
                if(Folder.ShowDialog() == DialogResult.OK)
                    TMPPathLabel.Text = TMPPath = Folder.SelectedPath;
                else {
                    ((Control)sender).Text = ((Control)sender).Text.Remove(((Control)sender).Text.LastIndexOf(' ') + 1) + (SpecifyTMPDirectory ? "Yes" : "No");
                    return;
                }
            }
            else {
                TMPPath = "";
                TMPPathLabel.Text = "Using This PC's Default TMP Directory";
            }

            SpecifyTMPDirectory = !SpecifyTMPDirectory;
        }



        #region RepeatedButtonFunctions
        /////////////////\\\\\\\\\\\\\\\\\\
        ///--     Repeat Buttons      --\\\
        /////////////////\\\\\\\\\\\\\\\\\\\

        public void BackBtn_Click(object sender, EventArgs e) {
            LabelShouldFlash = false;
            BackFunc();
        }

        public void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(5, false);

        public void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(8, false);
        #endregion

        #region ControlDeclarations
        ///////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     PS4DebugPage Control Declarations     --\\\
        ///////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\

        public Label CmdPathLabel;
        private Button LoadFilesButton;
        private Button InfoHelpBtn;
        private Label SeperatorLabel2;
        private Button BackBtn;
        private Label Info;
        private Button CreditsBtn;
        private Button MinimizeBtn;
        private Button ExitBtn;
        private GroupBox MainBox;
        private Label MainLabel;
        private GroupBox BorderBox;
        private Button VerbosityBtn;
        private Button StartPkgCreationBtn;
        public Label GP4PathLabel;
        private TextBox PathBox;
        private Label SeperatorLabel1;
        public Label OutputDirectoryLabel;
        private Button TempDirectoryBtn;
        public Label TMPPathLabel;
        private Label SeperatorLabel0;
        #endregion
    }
}
