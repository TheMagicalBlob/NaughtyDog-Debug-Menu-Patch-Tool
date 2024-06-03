using System;
using System.IO;
using System.Drawing;
using static Dobby.Common;
using System.Windows.Forms;
using libdebug;
using libgp4;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Dobby {
    public class Gp4CreationPage : Form {

        public Gp4CreationPage() { //! Page Unfinished, Only Base Functionality Added
            InitializeComponent();
            
            AddEventHandlersToControls(Controls);


            foreach(Control control in Controls) {
                if(control.Name.Contains("PathLabel")) {
                    control.MouseEnter += new EventHandler(HighlightPathLabel);
                    control.MouseLeave += new EventHandler(HighlightPathLabel);
                }
            }
        }

        bool VerboseOutput = true, SpecifyTMPDirectory = false, IsFirstOpen = true, IsBuildReady;
        private GP4Creator gp4;


        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Designer Crap, No Touchie      --\\\
        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        #region Designer Crap, No Touchie
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public void InitializeComponent() {
            this.GamedataPathLabel = new System.Windows.Forms.Label();
            this.InfoHelpBtn = new Button();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.BackBtn = new Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new Button();
            this.MainLabel = new System.Windows.Forms.Label();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.Gp4FilterBrowseBtn = new Button();
            this.SourcePkgPathBrowseBtn = new Button();
            this.OutputPathBrowseBtn = new Button();
            this.GamedataFolderBrowseBtn = new Button();
            this.StartGp4CreationBtn = new Button();
            this.SourcePkgPathLabel = new System.Windows.Forms.Label();
            this.FilterArrayTextBox = new System.Windows.Forms.TextBox();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.OutputPathLabel = new System.Windows.Forms.Label();
            this.FilterArrayLabel = new System.Windows.Forms.Label();
            this.PasscodeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GamedataPathLabel
            // 
            this.GamedataPathLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GamedataPathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GamedataPathLabel.Location = new System.Drawing.Point(4, 30);
            this.GamedataPathLabel.Name = "GamedataPathLabel";
            this.GamedataPathLabel.Size = new System.Drawing.Size(264, 19);
            this.GamedataPathLabel.TabIndex = 32;
            this.GamedataPathLabel.Text = "(No Gamedata Folder Directory Selected)";
            this.GamedataPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GamedataPathLabel.Click += new System.EventHandler(this.GamedataPathLabel_Click);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 223);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(309, 23);
            this.InfoHelpBtn.TabIndex = 15;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 179);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine2.TabIndex = 14;
            this.SeperatorLine2.Text = "--------------------------------------------------------------";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 269);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(309, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(3, 297);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(313, 19);
            this.Info.TabIndex = 7;
            this.Info.Text = "======================================";
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 245);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(309, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(1, 1);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(314, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "GP4 Creation Page";
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine0.TabIndex = 33;
            this.SeperatorLine0.Text = "--------------------------------------------------------------";
            // 
            // Gp4FilterBrowseBtn
            // 
            this.Gp4FilterBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Gp4FilterBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Gp4FilterBrowseBtn.FlatAppearance.BorderSize = 0;
            this.Gp4FilterBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gp4FilterBrowseBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.Gp4FilterBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.Gp4FilterBrowseBtn.Location = new System.Drawing.Point(265, 134);
            this.Gp4FilterBrowseBtn.Name = "Gp4FilterBrowseBtn";
            this.Gp4FilterBrowseBtn.Size = new System.Drawing.Size(45, 19);
            this.Gp4FilterBrowseBtn.TabIndex = 49;
            this.Gp4FilterBrowseBtn.Text = "Browse";
            this.Gp4FilterBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Gp4FilterBrowseBtn.UseVisualStyleBackColor = false;
            this.Gp4FilterBrowseBtn.Click += new System.EventHandler(this.Gp4FilterBrowseBtn_Click);
            // 
            // SourcePkgPathBrowseBtn
            // 
            this.SourcePkgPathBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.SourcePkgPathBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.SourcePkgPathBrowseBtn.FlatAppearance.BorderSize = 0;
            this.SourcePkgPathBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SourcePkgPathBrowseBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.SourcePkgPathBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.SourcePkgPathBrowseBtn.Location = new System.Drawing.Point(265, 79);
            this.SourcePkgPathBrowseBtn.Name = "SourcePkgPathBrowseBtn";
            this.SourcePkgPathBrowseBtn.Size = new System.Drawing.Size(45, 19);
            this.SourcePkgPathBrowseBtn.TabIndex = 47;
            this.SourcePkgPathBrowseBtn.Text = "Browse";
            this.SourcePkgPathBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SourcePkgPathBrowseBtn.UseVisualStyleBackColor = false;
            this.SourcePkgPathBrowseBtn.Click += new System.EventHandler(this.SourcePkgPathBrowseBtn_Click);
            // 
            // OutputPathBrowseBtn
            // 
            this.OutputPathBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.OutputPathBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.OutputPathBrowseBtn.FlatAppearance.BorderSize = 0;
            this.OutputPathBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutputPathBrowseBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.OutputPathBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.OutputPathBrowseBtn.Location = new System.Drawing.Point(265, 54);
            this.OutputPathBrowseBtn.Name = "OutputPathBrowseBtn";
            this.OutputPathBrowseBtn.Size = new System.Drawing.Size(45, 19);
            this.OutputPathBrowseBtn.TabIndex = 46;
            this.OutputPathBrowseBtn.Text = "Browse";
            this.OutputPathBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutputPathBrowseBtn.UseVisualStyleBackColor = false;
            this.OutputPathBrowseBtn.Click += new System.EventHandler(this.OutputPathBrowseBtn_Click);
            // 
            // GamedataFolderBrowseBtn
            // 
            this.GamedataFolderBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GamedataFolderBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GamedataFolderBrowseBtn.FlatAppearance.BorderSize = 0;
            this.GamedataFolderBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GamedataFolderBrowseBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.GamedataFolderBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.GamedataFolderBrowseBtn.Location = new System.Drawing.Point(265, 30);
            this.GamedataFolderBrowseBtn.Name = "GamedataFolderBrowseBtn";
            this.GamedataFolderBrowseBtn.Size = new System.Drawing.Size(45, 19);
            this.GamedataFolderBrowseBtn.TabIndex = 45;
            this.GamedataFolderBrowseBtn.Text = "Browse";
            this.GamedataFolderBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GamedataFolderBrowseBtn.UseVisualStyleBackColor = false;
            this.GamedataFolderBrowseBtn.Click += new System.EventHandler(this.GamedataFolderBrowseBtn_Click);
            // 
            // StartGp4CreationBtn
            // 
            this.StartGp4CreationBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.StartGp4CreationBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.StartGp4CreationBtn.FlatAppearance.BorderSize = 0;
            this.StartGp4CreationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartGp4CreationBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.StartGp4CreationBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.StartGp4CreationBtn.Location = new System.Drawing.Point(1, 192);
            this.StartGp4CreationBtn.Name = "StartGp4CreationBtn";
            this.StartGp4CreationBtn.Size = new System.Drawing.Size(309, 23);
            this.StartGp4CreationBtn.TabIndex = 23;
            this.StartGp4CreationBtn.Text = "Build .gp4 File";
            this.StartGp4CreationBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StartGp4CreationBtn.UseVisualStyleBackColor = false;
            this.StartGp4CreationBtn.Click += new System.EventHandler(this.StartGp4CreationBtn_Click);
            // 
            // SourcePkgPathLabel
            // 
            this.SourcePkgPathLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.SourcePkgPathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.SourcePkgPathLabel.Location = new System.Drawing.Point(4, 79);
            this.SourcePkgPathLabel.Name = "SourcePkgPathLabel";
            this.SourcePkgPathLabel.Size = new System.Drawing.Size(264, 19);
            this.SourcePkgPathLabel.TabIndex = 36;
            this.SourcePkgPathLabel.Text = "Base Game Source .pkg Path: .gp4 Relative";
            this.SourcePkgPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SourcePkgPathLabel.Click += new System.EventHandler(this.SourcePkgPathLabel_Click);
            // 
            // FilterArrayTextBox
            // 
            this.FilterArrayTextBox.BackColor = System.Drawing.Color.Gray;
            this.FilterArrayTextBox.Font = new System.Drawing.Font("Cambria", 9F);
            this.FilterArrayTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.FilterArrayTextBox.Location = new System.Drawing.Point(3, 158);
            this.FilterArrayTextBox.Name = "FilterArrayTextBox";
            this.FilterArrayTextBox.Size = new System.Drawing.Size(313, 22);
            this.FilterArrayTextBox.TabIndex = 32;
            this.FilterArrayTextBox.Text = "Filter Out Files Or Folders Here";
            this.FilterArrayTextBox.TextChanged += new System.EventHandler(this.FilterArrayTextBox_TextChanged);
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 209);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine1.TabIndex = 29;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // OutputPathLabel
            // 
            this.OutputPathLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.OutputPathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.OutputPathLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutputPathLabel.Location = new System.Drawing.Point(4, 54);
            this.OutputPathLabel.Name = "OutputPathLabel";
            this.OutputPathLabel.Size = new System.Drawing.Size(264, 19);
            this.OutputPathLabel.TabIndex = 38;
            this.OutputPathLabel.Text = ".gp4 Output Path: Default";
            this.OutputPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutputPathLabel.Click += new System.EventHandler(this.OutputPathLabel_Click);
            // 
            // FilterArrayLabel
            // 
            this.FilterArrayLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.FilterArrayLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.FilterArrayLabel.Location = new System.Drawing.Point(4, 134);
            this.FilterArrayLabel.Name = "FilterArrayLabel";
            this.FilterArrayLabel.Size = new System.Drawing.Size(264, 19);
            this.FilterArrayLabel.TabIndex = 37;
            this.FilterArrayLabel.Text = "No Files/Folders Added To gp4 Filter";
            this.FilterArrayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FilterArrayLabel.Click += new System.EventHandler(this.FilterArrayLabel_Click);
            // 
            // PasscodeLabel
            // 
            this.PasscodeLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.PasscodeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.PasscodeLabel.Location = new System.Drawing.Point(4, 106);
            this.PasscodeLabel.Name = "PasscodeLabel";
            this.PasscodeLabel.Size = new System.Drawing.Size(314, 19);
            this.PasscodeLabel.TabIndex = 44;
            this.PasscodeLabel.Text = ".pkg Passcode: Default";
            this.PasscodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PasscodeLabel.Click += new System.EventHandler(this.PasscodeLabel_Click);
            // 
            // Gp4CreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 323);
            this.Controls.Add(this.PasscodeLabel);
            this.Controls.Add(this.OutputPathLabel);
            this.Controls.Add(this.FilterArrayLabel);
            this.Controls.Add(this.FilterArrayTextBox);
            this.Controls.Add(this.SourcePkgPathLabel);
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
            this.Controls.Add(this.Gp4FilterBrowseBtn);
            this.Controls.Add(this.SourcePkgPathBrowseBtn);
            this.Controls.Add(this.OutputPathBrowseBtn);
            this.Controls.Add(this.GamedataFolderBrowseBtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Gp4CreationPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion



        private void LabelTextBoxToggle(Control sender) {

        }


        private void PasscodeLabel_Click(object sender, EventArgs e) {

        }

        /// <summary> Load orbis-pub-cmd.exe Binary And The Reqired .gp4 file If The Path Is Right
        private void FilterArrayTextBox_TextChanged(object sender, EventArgs e) { // tst : eboot.bin, keystone, discname.txt; param.sfo
            if(((TextBox)sender).Text == "") {
                gp4.UserBlacklist = null;
                return;
            }


            int filter_strings_length = 0, char_index = 0;
            StringBuilder Builder;

            foreach(char c in (FilterArrayTextBox.Text + ';').ToCharArray())
                if(c == ';' || c == ',')
                    filter_strings_length++;

            gp4.UserBlacklist = new string[filter_strings_length];
            buffer = Encoding.UTF8.GetBytes((FilterArrayTextBox.Text + ';').ToCharArray());

            try {
                for(var array_index = 0; array_index < gp4.UserBlacklist.Length; array_index++) {
                    Builder = new StringBuilder();

                    while(buffer[char_index] != 0x3B && buffer[char_index] != 0x2C)
                        Builder.Append(Encoding.UTF8.GetString(new byte[] { buffer[char_index++] }));

                    char_index++;
                    gp4.UserBlacklist[array_index] = Builder.ToString().Trim(' ');
                }
            }
            catch (IndexOutOfRangeException ex) {
#if DEBUG
                Console.WriteLine($"\n{ex.StackTrace}");
#endif
            }
        }

        private void StartGp4CreationBtn_Click(object sender, EventArgs e) {
            gp4.LogTextBox = CreateTextBox(".gp4 Log");
        }

        void HighlightPathLabel(object sender, EventArgs e) {
            var Sender = sender as Control;

            if(Sender.Font.Underline)
                Sender.Font = new Font("Georgia", 9.75F);
            else
                Sender.Font = new Font("Georgia", 9.75F, FontStyle.Underline);
        }

        private void GamedataPathLabel_Click(object sender, EventArgs e) {
        }

        private void GamedataFolderBrowseBtn_Click(object sender, EventArgs e) {
            FileDialog file = new OpenFileDialog {
                Filter = "Folder|*.???",
                Title = "Select The Game's Data Folder"
            };

            if(file.ShowDialog() == DialogResult.OK) {
                GamedataPathLabel.Text = file.FileName.Remove(file.FileName.LastIndexOf(@"\"));
                Dev.MsgOut($"dta folder: {GamedataPathLabel.Text}");
                gp4 = new GP4Creator(GamedataPathLabel.Text);
            }

            else return;
        }

        private void SourcePkgPathLabel_Click(object sender, EventArgs e) {

        }
        private void SourcePkgPathBrowseBtn_Click(object sender, EventArgs e) {
            FileDialog file = new OpenFileDialog {
                Filter = ".gp4 Project File|*.gp4",
                Title = "Select Your .gp4 File"
            };

            if(file.ShowDialog() == DialogResult.OK)
                gp4.SourcePkgPath = file.FileName;
            else return;
        }


        private void OutputPathLabel_Click(object sender, EventArgs e) {
        }
        private void OutputPathBrowseBtn_Click(object sender, EventArgs e) {
            FolderBrowserDialog Folder = new FolderBrowserDialog {
                Description = "Chose A Directory You Want The Finished .pkg To Go, Or Close This Window To Use The App Directory"
            };
            if(Folder.ShowDialog() == DialogResult.OK) {
                gp4 = new GP4Creator(Folder.SelectedPath);
                OutputPathLabel.Text = $".gp4 Output Path: {Folder.SelectedPath}";
            }
            else {
                OutputPathLabel.Text = "Using Current Directory For .gp4 Output";
                gp4 = new GP4Creator(Directory.GetCurrentDirectory());
            }
        }

        private void Gp4CreationPageBtn_Click(object sender, EventArgs e) {

        }

        private void LoadBaseGamePkgPathBtn_Click(object sender, EventArgs e) {

        }

        private void FilterArrayLabel_Click(object sender, EventArgs e) {

        }
        private void Gp4FilterBrowseBtn_Click(object sender, EventArgs e) {

        }



        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Repeated Page Functions & Control Declarations     --\\\
        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Repeat Functions & Control Declarations
        public void BackBtn_Click(object sender, EventArgs e) {
            LabelShouldFlash = false;
            ReturnToPreviousPage();
        }

        private void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.InfoHelpPage);

        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.CreditsPage);
        public Label GamedataPathLabel;
        private Button InfoHelpBtn;
        private Label SeperatorLine2;
        private Button BackBtn;
        private Label Info;
        private Button CreditsBtn;
        private Label PasscodeLabel;
        private Button Gp4FilterBrowseBtn;
        private Button SourcePkgPathBrowseBtn;
        private Button OutputPathBrowseBtn;
        private Button GamedataFolderBrowseBtn;
        private Label MainLabel;
        private Button StartGp4CreationBtn;
        public Label SourcePkgPathLabel;
        private TextBox FilterArrayTextBox;
        private Label SeperatorLine1;
        public Label OutputPathLabel;
        public Label FilterArrayLabel;
        private Label SeperatorLine0;
        #endregion
    }
}
