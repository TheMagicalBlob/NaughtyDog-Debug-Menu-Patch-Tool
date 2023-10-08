using System;
using System.IO;
using System.Drawing;
using static Dobby.Common;
using System.Windows.Forms;
using libdebug;
using libgp4;
using System.Linq;

namespace Dobby {
    public class Gp4CreationPage : Form {

        public Gp4CreationPage() {
            InitializeComponent();
            AddControlEventHandlers(Controls);

            foreach(Control control in Controls) {
                if(control.Name.Contains("PathLabel")) {
                    control.MouseEnter += new EventHandler(HighlightPathLabel);
                    control.MouseLeave += new EventHandler(HighlightPathLabel);
                }
            }
        }

        string
            GP4Path,
            TMPPath,
            OrbisPubCmdPath,
            OutputDirectory
        ;

        bool VerboseOutput = true, SpecifyTMPDirectory = false, IsFirstOpen = true, IsBuildReady;
        private Label SeperatorLine3;
        private Button LoadBaseGamePkgPathBtn;
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        public Label PasscodeLabel;
        private Button Gp4CreationPageBtn;

        public void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.GamedataPathLabel = new System.Windows.Forms.Label();
            this.LoadGamedataFolderButton = new System.Windows.Forms.Button();
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.MainLabel = new System.Windows.Forms.Label();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.BorderBox = new System.Windows.Forms.GroupBox();
            this.StartGp4CreationBtn = new System.Windows.Forms.Button();
            this.SourcePkgPathLabel = new System.Windows.Forms.Label();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.OutputPathLabel = new System.Windows.Forms.Label();
            this.FilterArrayLabel = new System.Windows.Forms.Label();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.Gp4CreationPageBtn = new System.Windows.Forms.Button();
            this.LoadBaseGamePkgPathBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PasscodeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GamedataPathLabel
            // 
            this.GamedataPathLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GamedataPathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GamedataPathLabel.Location = new System.Drawing.Point(1, 63);
            this.GamedataPathLabel.Name = "GamedataPathLabel";
            this.GamedataPathLabel.Size = new System.Drawing.Size(317, 19);
            this.GamedataPathLabel.TabIndex = 32;
            this.GamedataPathLabel.Text = "No Gamedata Folder Directory Selected";
            this.GamedataPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GamedataPathLabel.Click += new System.EventHandler(this.CmdPathLabel_Click);
            // 
            // LoadGamedataFolderButton
            // 
            this.LoadGamedataFolderButton.BackColor = System.Drawing.Color.DimGray;
            this.LoadGamedataFolderButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.LoadGamedataFolderButton.FlatAppearance.BorderSize = 0;
            this.LoadGamedataFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadGamedataFolderButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.LoadGamedataFolderButton.ForeColor = System.Drawing.SystemColors.Control;
            this.LoadGamedataFolderButton.Location = new System.Drawing.Point(1, 183);
            this.LoadGamedataFolderButton.Name = "LoadGamedataFolderButton";
            this.LoadGamedataFolderButton.Size = new System.Drawing.Size(317, 23);
            this.LoadGamedataFolderButton.TabIndex = 31;
            this.LoadGamedataFolderButton.Text = "Browse For App Folder/Gamedata Path...";
            this.LoadGamedataFolderButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoadGamedataFolderButton.UseVisualStyleBackColor = false;
            this.LoadGamedataFolderButton.Click += new System.EventHandler(this.LoadFilesButton_Click);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 308);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(317, 23);
            this.InfoHelpBtn.TabIndex = 15;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 248);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 20);
            this.SeperatorLine2.TabIndex = 14;
            this.SeperatorLine2.Text = "____________________________________________";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 358);
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
            this.Info.Location = new System.Drawing.Point(3, 383);
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
            this.CreditsBtn.Location = new System.Drawing.Point(1, 333);
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
            this.MainLabel.Text = "GP4 Creation Page";
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 12);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 20);
            this.SeperatorLine0.TabIndex = 33;
            this.SeperatorLine0.Text = "____________________________________________";
            // 
            // BorderBox
            // 
            this.BorderBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.BorderBox.Location = new System.Drawing.Point(0, -6);
            this.BorderBox.Name = "BorderBox";
            this.BorderBox.Size = new System.Drawing.Size(319, 412);
            this.BorderBox.TabIndex = 34;
            this.BorderBox.TabStop = false;
            // 
            // StartGp4CreationBtn
            // 
            this.StartGp4CreationBtn.BackColor = System.Drawing.Color.DimGray;
            this.StartGp4CreationBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.StartGp4CreationBtn.FlatAppearance.BorderSize = 0;
            this.StartGp4CreationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartGp4CreationBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.StartGp4CreationBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.StartGp4CreationBtn.Location = new System.Drawing.Point(1, 31);
            this.StartGp4CreationBtn.Name = "StartGp4CreationBtn";
            this.StartGp4CreationBtn.Size = new System.Drawing.Size(317, 23);
            this.StartGp4CreationBtn.TabIndex = 23;
            this.StartGp4CreationBtn.Text = "Build .gp4 File";
            this.StartGp4CreationBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StartGp4CreationBtn.UseVisualStyleBackColor = false;
            this.StartGp4CreationBtn.Click += new System.EventHandler(this.StartPkgCreationBtn_Click);
            // 
            // SourcePkgPathLabel
            // 
            this.SourcePkgPathLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.SourcePkgPathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.SourcePkgPathLabel.Location = new System.Drawing.Point(1, 109);
            this.SourcePkgPathLabel.Name = "SourcePkgPathLabel";
            this.SourcePkgPathLabel.Size = new System.Drawing.Size(317, 19);
            this.SourcePkgPathLabel.TabIndex = 36;
            this.SourcePkgPathLabel.Text = "No Source .pkg Path Given";
            this.SourcePkgPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SourcePkgPathLabel.Click += new System.EventHandler(this.GP4PathLabel_Click);
            // 
            // PathBox
            // 
            this.PathBox.BackColor = System.Drawing.Color.Gray;
            this.PathBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F);
            this.PathBox.ForeColor = System.Drawing.SystemColors.Window;
            this.PathBox.Location = new System.Drawing.Point(3, 235);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(313, 21);
            this.PathBox.TabIndex = 32;
            this.PathBox.Text = "Paste The Names Of Files/Folders You Want To Exclude Here";
            this.PathBox.TextChanged += new System.EventHandler(this.ExecutablePathBox_TextChanged);
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 44);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 20);
            this.SeperatorLine1.TabIndex = 29;
            this.SeperatorLine1.Text = "____________________________________________";
            // 
            // OutputPathLabel
            // 
            this.OutputPathLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.OutputPathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.OutputPathLabel.Location = new System.Drawing.Point(1, 86);
            this.OutputPathLabel.Name = "OutputPathLabel";
            this.OutputPathLabel.Size = new System.Drawing.Size(317, 19);
            this.OutputPathLabel.TabIndex = 38;
            this.OutputPathLabel.Text = "Using Gamedata Folder\'s Directory As Output";
            this.OutputPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OutputPathLabel.Click += new System.EventHandler(this.OutputDirectoryLabel_Click);
            // 
            // FilterArrayLabel
            // 
            this.FilterArrayLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.FilterArrayLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.FilterArrayLabel.Location = new System.Drawing.Point(1, 155);
            this.FilterArrayLabel.Name = "FilterArrayLabel";
            this.FilterArrayLabel.Size = new System.Drawing.Size(317, 19);
            this.FilterArrayLabel.TabIndex = 37;
            this.FilterArrayLabel.Text = "No Files/Folders Added To Filter";
            this.FilterArrayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 286);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 20);
            this.SeperatorLine3.TabIndex = 40;
            this.SeperatorLine3.Text = "____________________________________________";
            // 
            // Gp4CreationPageBtn
            // 
            this.Gp4CreationPageBtn.BackColor = System.Drawing.Color.DimGray;
            this.Gp4CreationPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Gp4CreationPageBtn.Enabled = false;
            this.Gp4CreationPageBtn.FlatAppearance.BorderSize = 0;
            this.Gp4CreationPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gp4CreationPageBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Gp4CreationPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.Gp4CreationPageBtn.Location = new System.Drawing.Point(1, 270);
            this.Gp4CreationPageBtn.Name = "Gp4CreationPageBtn";
            this.Gp4CreationPageBtn.Size = new System.Drawing.Size(317, 23);
            this.Gp4CreationPageBtn.TabIndex = 41;
            this.Gp4CreationPageBtn.Text = "Build .gp4 File From Gamedata...";
            this.Gp4CreationPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Gp4CreationPageBtn.UseVisualStyleBackColor = false;
            // 
            // LoadBaseGamePkgPathBtn
            // 
            this.LoadBaseGamePkgPathBtn.BackColor = System.Drawing.Color.DimGray;
            this.LoadBaseGamePkgPathBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.LoadBaseGamePkgPathBtn.FlatAppearance.BorderSize = 0;
            this.LoadBaseGamePkgPathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadBaseGamePkgPathBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.LoadBaseGamePkgPathBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.LoadBaseGamePkgPathBtn.Location = new System.Drawing.Point(1, 208);
            this.LoadBaseGamePkgPathBtn.Name = "LoadBaseGamePkgPathBtn";
            this.LoadBaseGamePkgPathBtn.Size = new System.Drawing.Size(317, 23);
            this.LoadBaseGamePkgPathBtn.TabIndex = 42;
            this.LoadBaseGamePkgPathBtn.Text = "Browse For Base Game .pkg...";
            this.LoadBaseGamePkgPathBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoadBaseGamePkgPathBtn.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // PasscodeLabel
            // 
            this.PasscodeLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.PasscodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.PasscodeLabel.Location = new System.Drawing.Point(2, 132);
            this.PasscodeLabel.Name = "PasscodeLabel";
            this.PasscodeLabel.Size = new System.Drawing.Size(317, 19);
            this.PasscodeLabel.TabIndex = 44;
            this.PasscodeLabel.Text = "Using Default Passcode";
            this.PasscodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Gp4CreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 406);
            this.Controls.Add(this.PasscodeLabel);
            this.Controls.Add(this.LoadBaseGamePkgPathBtn);
            this.Controls.Add(this.Gp4CreationPageBtn);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.OutputPathLabel);
            this.Controls.Add(this.FilterArrayLabel);
            this.Controls.Add(this.LoadGamedataFolderButton);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.SourcePkgPathLabel);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.GamedataPathLabel);
            this.Controls.Add(this.StartGp4CreationBtn);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.SeperatorLine0);
            this.Controls.Add(this.BorderBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Gp4CreationPage";
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
                OutputPathLabel.Text = OutputDirectory = Folder.SelectedPath;
            else {
                OutputPathLabel.Text = "Using Current Directory For.pkg Output";
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
            if(Path.Contains(".exe")) GamedataPathLabel.Text = OrbisPubCmdPath = Path;
            if(Path.Contains(".gp4")) SourcePkgPathLabel.Text = GP4Path = Path;

            if(OrbisPubCmdPath != "" && GP4Path != "" && OutputDirectory != "") IsBuildReady = true;
            return Path.Contains(".exe") ? true : false;
        }



        private void StartPkgCreationBtn_Click(object sender, EventArgs e) {
            var outbox = CreateTextBox();
            GP4 gp4 = new GP4() {
                gamedata_folder = GamedataPathLabel.Text,
                passcode =
                    PasscodeLabel.Text == "Using Default Passcode"
                    ? "00000000000000000000000000000000"
                    : PasscodeLabel.Text,

                gp4_output_directory =
                    OutputPathLabel.Text == "Using Gamedata Folder's Directory As Output"
                    ? $"{GamedataPathLabel.Text.Remove(GamedataPathLabel.Text.LastIndexOf('\\') - 1)}"
                    : OutputPathLabel.Text,

                pkg_source = @"F:\PS4\PKG\UP9000-CUSA00552_00-THELASTOFUS00000-A0111-V0100.pkg",
                filter_array = new string[] { "illueboot", "Restored_Menu" },
                ignore_keystone = true
            };
            gp4.Build();
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
                    FilterArrayLabel.Text = TMPPath = Folder.SelectedPath;
                else {
                    ((Control)sender).Text = ((Control)sender).Text.Remove(((Control)sender).Text.LastIndexOf(' ') + 1) + (SpecifyTMPDirectory ? "Yes" : "No");
                    return;
                }
            }
            else {
                TMPPath = "";
                FilterArrayLabel.Text = "Using This PC's Default TMP Directory";
            }

            SpecifyTMPDirectory = !SpecifyTMPDirectory;
        }

        void HighlightPathLabel(object sender, EventArgs e) {
            var Sender = sender as Control;
            if(Sender.Font.Underline)
                Sender.Font = new Font("Georgia", 9.75F);
            else
                Sender.Font = new Font("Georgia", 9.75F, FontStyle.Underline);
        }

        private void CmdPathLabel_Click(object sender, EventArgs e) {
            FileDialog file = new OpenFileDialog {
                Filter = "Executable|*.exe",
                Title = "Select orbis-pub-cmd.exe"
            };

            if(file.ShowDialog() == DialogResult.OK)
                LoadFilesFromSelectedPath(file.FileName);
            else return;
        }


        private void GP4PathLabel_Click(object sender, EventArgs e) {
            FileDialog file = new OpenFileDialog {
                Filter = ".gp4 Project File|*.gp4",
                Title = "Select Your .gp4 File"
            };

            if(file.ShowDialog() == DialogResult.OK)
                LoadFilesFromSelectedPath(file.FileName);
            else return;
        }

        private void OutputDirectoryLabel_Click(object sender, EventArgs e) {
            FolderBrowserDialog Folder = new FolderBrowserDialog {
                Description = "Chose A Directory You Want The Finished .pkg To Go, Or Close This Window To Use The App Directory"
            };
            if(Folder.ShowDialog() == DialogResult.OK)
                OutputPathLabel.Text = OutputDirectory = Folder.SelectedPath;
            else {
                OutputPathLabel.Text = "Using Current Directory For.pkg Output";
                OutputDirectory = Directory.GetCurrentDirectory();
            }
        }



        #region RepeatedButtonFunctions
        /////////////////\\\\\\\\\\\\\\\\\\
        ///--     Repeat Buttons      --\\\
        /////////////////\\\\\\\\\\\\\\\\\\\
        public void BackBtn_Click(object sender, EventArgs e) {
            LabelShouldFlash = false;
            BackFunc();
        }

        private void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(InfoHelpPageId);

        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(CreditsPageId);
        #endregion

        #region Control Declarations
        ////////////////////\\\\\\\\\\\\\\\\\\\\
        ///--     Control Declarations     --\\\
        ////////////////////\\\\\\\\\\\\\\\\\\\\
        public Label GamedataPathLabel;
        private Button LoadGamedataFolderButton;
        private Button InfoHelpBtn;
        private Label SeperatorLine2;
        private Button BackBtn;
        private Label Info;
        private Button CreditsBtn;
        private Button MinimizeBtn;
        private Button ExitBtn;
        private GroupBox MainBox;
        private Label MainLabel;
        private GroupBox BorderBox;
        private Button StartGp4CreationBtn;
        public Label SourcePkgPathLabel;
        private TextBox PathBox;
        private Label SeperatorLine1;
        public Label OutputPathLabel;
        public Label FilterArrayLabel;
        private Label SeperatorLine0;
        #endregion
    }
}
