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
            Paint += PaintBorder;
            AddControlEventHandlers(Controls);

            foreach(Control control in Controls) {
                if(control.Name.Contains("PathLabel")) {
                    control.MouseEnter += new EventHandler(HighlightPathLabel);
                    control.MouseLeave += new EventHandler(HighlightPathLabel);
                }
            }
        }
        private void InitializeComponent() {
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MainLabel = new System.Windows.Forms.Label();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.LaunchOrbisPubCmdBtn = new System.Windows.Forms.Button();
            this.VerbosityBtn = new System.Windows.Forms.Button();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.TempDirectoryBtn = new System.Windows.Forms.Button();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.Gp4CreationPageBtn = new System.Windows.Forms.Button();
            this.CmdPathLabel = new System.Windows.Forms.Label();
            this.CmdPathBtn = new System.Windows.Forms.Button();
            this.GP4PathLabel = new System.Windows.Forms.Label();
            this.GP4PathBtn = new System.Windows.Forms.Button();
            this.OutputDirectoryLabel = new System.Windows.Forms.Label();
            this.OutputDirectoryBtn = new System.Windows.Forms.Button();
            this.TMPDirectoryLabel = new System.Windows.Forms.Label();
            this.TMPDirectoryBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 248);
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
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 200);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 20);
            this.SeperatorLine2.TabIndex = 14;
            this.SeperatorLine2.Text = "____________________________________________";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 298);
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
            this.Info.Location = new System.Drawing.Point(4, 325);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(313, 19);
            this.Info.TabIndex = 7;
            this.Info.Text = "======================================";
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 273);
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
            this.MinimizeBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
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
            this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
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
            // LaunchOrbisPubCmdBtn
            // 
            this.LaunchOrbisPubCmdBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.LaunchOrbisPubCmdBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.LaunchOrbisPubCmdBtn.FlatAppearance.BorderSize = 0;
            this.LaunchOrbisPubCmdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LaunchOrbisPubCmdBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.LaunchOrbisPubCmdBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.LaunchOrbisPubCmdBtn.Location = new System.Drawing.Point(1, 33);
            this.LaunchOrbisPubCmdBtn.Name = "LaunchOrbisPubCmdBtn";
            this.LaunchOrbisPubCmdBtn.Size = new System.Drawing.Size(317, 23);
            this.LaunchOrbisPubCmdBtn.TabIndex = 23;
            this.LaunchOrbisPubCmdBtn.Text = "Build .pkg File";
            this.LaunchOrbisPubCmdBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LaunchOrbisPubCmdBtn.UseVisualStyleBackColor = false;
            this.LaunchOrbisPubCmdBtn.Click += new System.EventHandler(this.LaunchOrbisPubCmdBtn_Click);
            // 
            // VerbosityBtn
            // 
            this.VerbosityBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
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
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 93);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 20);
            this.SeperatorLine1.TabIndex = 29;
            this.SeperatorLine1.Text = "____________________________________________";
            // 
            // TempDirectoryBtn
            // 
            this.TempDirectoryBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
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
            this.TempDirectoryBtn.Click += new System.EventHandler(this.TMPDirectoryBtn_Click);
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 230);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 20);
            this.SeperatorLine3.TabIndex = 40;
            this.SeperatorLine3.Text = "____________________________________________";
            // 
            // Gp4CreationPageBtn
            // 
            this.Gp4CreationPageBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.Gp4CreationPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Gp4CreationPageBtn.FlatAppearance.BorderSize = 0;
            this.Gp4CreationPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gp4CreationPageBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Gp4CreationPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.Gp4CreationPageBtn.Location = new System.Drawing.Point(1, 218);
            this.Gp4CreationPageBtn.Name = "Gp4CreationPageBtn";
            this.Gp4CreationPageBtn.Size = new System.Drawing.Size(317, 23);
            this.Gp4CreationPageBtn.TabIndex = 41;
            this.Gp4CreationPageBtn.Text = "Build .gp4 File From Gamedata...";
            this.Gp4CreationPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Gp4CreationPageBtn.UseVisualStyleBackColor = false;
            this.Gp4CreationPageBtn.Click += new System.EventHandler(this.Gp4CreationPageBtn_Click);
            // 
            // CmdPathLabel
            // 
            this.CmdPathLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdPathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.CmdPathLabel.Location = new System.Drawing.Point(2, 114);
            this.CmdPathLabel.Name = "CmdPathLabel";
            this.CmdPathLabel.Size = new System.Drawing.Size(266, 19);
            this.CmdPathLabel.TabIndex = 50;
            this.CmdPathLabel.Text = "No Program Path Loaded";
            this.CmdPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdPathLabel.Click += new System.EventHandler(this.CmdPathLabel_Click);
            // 
            // CmdPathBtn
            // 
            this.CmdPathBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.CmdPathBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CmdPathBtn.FlatAppearance.BorderSize = 0;
            this.CmdPathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdPathBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F);
            this.CmdPathBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CmdPathBtn.Location = new System.Drawing.Point(270, 112);
            this.CmdPathBtn.Name = "CmdPathBtn";
            this.CmdPathBtn.Size = new System.Drawing.Size(46, 23);
            this.CmdPathBtn.TabIndex = 55;
            this.CmdPathBtn.Text = "Browse";
            this.CmdPathBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdPathBtn.UseVisualStyleBackColor = false;
            this.CmdPathBtn.Click += new System.EventHandler(this.CmdPathBtn_Click);
            // 
            // GP4PathLabel
            // 
            this.GP4PathLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.GP4PathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GP4PathLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GP4PathLabel.Location = new System.Drawing.Point(2, 138);
            this.GP4PathLabel.Name = "GP4PathLabel";
            this.GP4PathLabel.Size = new System.Drawing.Size(266, 19);
            this.GP4PathLabel.TabIndex = 53;
            this.GP4PathLabel.Text = "No .gp4 Selected";
            this.GP4PathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GP4PathLabel.Click += new System.EventHandler(this.GP4PathLabel_Click);
            // 
            // GP4PathBtn
            // 
            this.GP4PathBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.GP4PathBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GP4PathBtn.FlatAppearance.BorderSize = 0;
            this.GP4PathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GP4PathBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F);
            this.GP4PathBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.GP4PathBtn.Location = new System.Drawing.Point(270, 136);
            this.GP4PathBtn.Name = "GP4PathBtn";
            this.GP4PathBtn.Size = new System.Drawing.Size(46, 23);
            this.GP4PathBtn.TabIndex = 56;
            this.GP4PathBtn.Text = "Browse";
            this.GP4PathBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GP4PathBtn.UseVisualStyleBackColor = false;
            this.GP4PathBtn.Click += new System.EventHandler(this.GP4PathBtn_Click);
            // 
            // OutputDirectoryLabel
            // 
            this.OutputDirectoryLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.OutputDirectoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.OutputDirectoryLabel.Location = new System.Drawing.Point(2, 163);
            this.OutputDirectoryLabel.Name = "OutputDirectoryLabel";
            this.OutputDirectoryLabel.Size = new System.Drawing.Size(266, 19);
            this.OutputDirectoryLabel.TabIndex = 51;
            this.OutputDirectoryLabel.Text = "Using Current Directory For .pkg Output";
            this.OutputDirectoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutputDirectoryLabel.Click += new System.EventHandler(this.OutputDirectoryLabel_Click);
            // 
            // OutputDirectoryBtn
            // 
            this.OutputDirectoryBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.OutputDirectoryBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.OutputDirectoryBtn.FlatAppearance.BorderSize = 0;
            this.OutputDirectoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutputDirectoryBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F);
            this.OutputDirectoryBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.OutputDirectoryBtn.Location = new System.Drawing.Point(270, 161);
            this.OutputDirectoryBtn.Name = "OutputDirectoryBtn";
            this.OutputDirectoryBtn.Size = new System.Drawing.Size(46, 23);
            this.OutputDirectoryBtn.TabIndex = 57;
            this.OutputDirectoryBtn.Text = "Browse";
            this.OutputDirectoryBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutputDirectoryBtn.UseVisualStyleBackColor = false;
            this.OutputDirectoryBtn.Click += new System.EventHandler(this.OutputDirectoryBtn_Click);
            // 
            // TMPDirectoryLabel
            // 
            this.TMPDirectoryLabel.Font = new System.Drawing.Font("Georgia", 9.75F);
            this.TMPDirectoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.TMPDirectoryLabel.Location = new System.Drawing.Point(2, 189);
            this.TMPDirectoryLabel.Name = "TMPDirectoryLabel";
            this.TMPDirectoryLabel.Size = new System.Drawing.Size(266, 19);
            this.TMPDirectoryLabel.TabIndex = 52;
            this.TMPDirectoryLabel.Text = "Using This PC\'s Default TMP Directory";
            this.TMPDirectoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TMPDirectoryLabel.Click += new System.EventHandler(this.TMPDirectoryLabel_Click);
            // 
            // TMPDirectoryBtn
            // 
            this.TMPDirectoryBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.TMPDirectoryBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.TMPDirectoryBtn.FlatAppearance.BorderSize = 0;
            this.TMPDirectoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TMPDirectoryBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F);
            this.TMPDirectoryBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.TMPDirectoryBtn.Location = new System.Drawing.Point(270, 187);
            this.TMPDirectoryBtn.Name = "TMPDirectoryBtn";
            this.TMPDirectoryBtn.Size = new System.Drawing.Size(46, 23);
            this.TMPDirectoryBtn.TabIndex = 58;
            this.TMPDirectoryBtn.Text = "Browse";
            this.TMPDirectoryBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TMPDirectoryBtn.UseVisualStyleBackColor = false;
            this.TMPDirectoryBtn.Click += new System.EventHandler(this.TMPDirectoryBtn_Click);
            // 
            // PkgCreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.ClientSize = new System.Drawing.Size(320, 348);
            this.Controls.Add(this.Gp4CreationPageBtn);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.TempDirectoryBtn);
            this.Controls.Add(this.VerbosityBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.LaunchOrbisPubCmdBtn);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.TMPDirectoryLabel);
            this.Controls.Add(this.TMPDirectoryBtn);
            this.Controls.Add(this.CmdPathLabel);
            this.Controls.Add(this.CmdPathBtn);
            this.Controls.Add(this.GP4PathLabel);
            this.Controls.Add(this.GP4PathBtn);
            this.Controls.Add(this.OutputDirectoryLabel);
            this.Controls.Add(this.OutputDirectoryBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.SeperatorLine0);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PkgCreationPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }

        static public string
            GP4Path,
            TMPPath,
            OrbisPubCmdPath = "?",
            OutputDirectory = "?"
        ;

        bool VerboseOutput = true, SpecifyTMPDirectory = false, IsFirstOpen = true, IsBuildReady;

        void ScanForOrbisPubTools() {                                                                                                              //DirectoryDirectoryDirectoryDirectoryDirectoryDirectoryDirectoryDirectoryDirectoryDirectoryDirectoryDirectoryDirectoryDirectoryDirectory
            var FilesInCurrentDirectory   = Directory.GetFiles(Directory.GetCurrentDirectory());
            var FoldersInCurrentDirectory = Directory.GetDirectories(Directory.GetCurrentDirectory());

            FileStream stream;
            byte[] Check = new byte[4];

            CheckFiles:
            foreach(var file in FilesInCurrentDirectory) {
                stream = File.OpenRead(file);
                
                stream.Position = 0x100;
                stream.Read(Check, 0, 4);

                if(file.Contains("orbis-pub-cmd") || Check.SequenceEqual(new byte[] { 0x46, 0xD1, 0xB8 }) || Check.SequenceEqual(new byte[] { 0x50, 0x45, 0x00 })) {
                    CmdPathLabel.Text = OrbisPubCmdPath = file;

                    Dev.DebugOut($"{file}\\{OrbisPubCmdPath} Set As OrbisPubCmdPath");
                    return;
                }
            }

            foreach(var folder in FoldersInCurrentDirectory) {
                if(folder.Contains("3.37") || folder.Contains("FPackage") || folder.Contains("3.87")) {
                    FilesInCurrentDirectory = Directory.GetFiles(folder);
                    goto CheckFiles;
                }
            }
        }
        private void HighlightPathLabel(object sender, EventArgs e) {
            var Sender = sender as Control;
            if (Sender.Font.Underline)
            Sender.Font = new Font("Georgia", 9.75F);
            else
            Sender.Font = new Font("Georgia", 9.75F, FontStyle.Underline);
        }



        private void LaunchOrbisPubCmdBtn_Click(object sender, EventArgs e) {
            if(!IsBuildReady) {
                ScanForOrbisPubTools();
                MessageBox.Show("orbis-pub-cmd.exe And A .gp4 Are Necessary For .pkg Creation");
                return;
            }

            if(OutputDirectory == "?") {
                OutputDirectory = GP4Path.Remove(GP4Path.LastIndexOf(@"\"));
            }

            string Parameters = $"img_create --oformat pkg  {(VerboseOutput ? "--no_progress_bar" : string.Empty)} --skip_digest {(SpecifyTMPDirectory ? $"--tmp_path \"{TMPPath}\"" : string.Empty)} \"{GP4Path}\" \"{OutputDirectory}\"";
            System.Diagnostics.Process.Start(OrbisPubCmdPath, Parameters);
            Dev.DebugOut(Parameters);

            MessageBox.Show(".pkg Creation Started; If The CMD Window Closes Immediately, You Did Something Wrong. Check Info/Help Page -> Pkg Creation Page Help");
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
                GP4PathLabel.Text = OutputDirectory = Folder.SelectedPath;
            else {
                GP4PathLabel.Text = "Using Current Directory For.pkg Output";
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
        private bool LoadFilesFromSelectedPath(string Path) {
            if(Path.Contains(".exe")) TMPDirectoryLabel.Text = OrbisPubCmdPath = Path;
            if(Path.Contains(".gp4")) GP4PathLabel.Text = GP4Path = Path;

            if(OrbisPubCmdPath != "" && GP4Path != "" && OutputDirectory != "") IsBuildReady = true;
            return Path.Contains(".exe") ? true : false; 
        }


        private void VerbosityBtn_Click(object sender, EventArgs e) {
            VerboseOutput = !VerboseOutput;
            ((Control)sender).Text = ((Control)sender).Text.Remove(((Control)sender).Text.LastIndexOf(' ') + 1) + (VerboseOutput ? "Details" : "Bar");
        }



        private void CmdPathBtn_Click(object sender, EventArgs e) => CmdPathLabel_Click(CmdPathBtn, null);
        private void CmdPathLabel_Click(object sender, EventArgs e) {
            FileDialog file = new OpenFileDialog {
                Filter = "Executable|*.exe",
                Title = "Select orbis-pub-cmd.exe"
            };

            if(file.ShowDialog() == DialogResult.OK)
                LoadFilesFromSelectedPath(file.FileName);
            else return;
        }

        private void GP4PathBtn_Click(object sender, EventArgs e) => GP4PathLabel_Click(GP4PathBtn, null);
        private void GP4PathLabel_Click(object sender, EventArgs e) {
            FileDialog file = new OpenFileDialog {
                Filter = ".gp4 Project File|*.gp4",
                Title = "Select Your .gp4 File"
            };

            if(file.ShowDialog() == DialogResult.OK)
                LoadFilesFromSelectedPath(file.FileName);
            else return;
        }

        private void OutputDirectoryLabel_Click(object sender, EventArgs e) => OutputDirectoryBtn_Click(OutputDirectoryBtn, null);
        private void OutputDirectoryBtn_Click(object sender, EventArgs e) {
            FolderBrowserDialog Folder = new FolderBrowserDialog {
                Description = "Chose A Directory You Want The Finished .pkg To Go, Or Close This Window To Use The App Directory"
            };
            if(Folder.ShowDialog() == DialogResult.OK)
                GP4PathLabel.Text = OutputDirectory = Folder.SelectedPath;
            else {
                GP4PathLabel.Text = "Using Current Directory For .pkg Output";
                OutputDirectory = Directory.GetCurrentDirectory();
            }
        }

        private void TMPDirectoryLabel_Click(object sender, EventArgs e) => TMPDirectoryBtn_Click(TempDirectoryBtn, null);
        private void TMPDirectoryBtn_Click(object sender, EventArgs e) {
            ((Control)sender).Text = ((Control)sender).Text.Remove(((Control)sender).Text.LastIndexOf(' ') + 1) + (SpecifyTMPDirectory ? "No" : "Yes");
            Refresh();

            if(!SpecifyTMPDirectory) {
                FolderBrowserDialog Folder = new FolderBrowserDialog {
                    Description = "Select Your Preffered Temp Directory"
                };
                if(Folder.ShowDialog() == DialogResult.OK)
                    TMPDirectoryLabel.Text = TMPPath = Folder.SelectedPath;
                else {
                    ((Control)sender).Text = ((Control)sender).Text.Remove(((Control)sender).Text.LastIndexOf(' ') + 1) + (SpecifyTMPDirectory ? "Yes" : "No");
                    return;
                }
            }
            else {
                TMPPath = "";
                TMPDirectoryLabel.Text = "Using This PC's Default TMP Directory";
            }

            SpecifyTMPDirectory = !SpecifyTMPDirectory;
        }
        private void Gp4CreationPageBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.Gp4CreationPage);


        /////////////////\\\\\\\\\\\\\\\\\\
        ///--     Repeat Buttons      --\\\
        /////////////////\\\\\\\\\\\\\\\\\\\
        #region RepeatedButtonFunctions
        public void BackBtn_Click(object sender, EventArgs e) {
            LabelShouldFlash = false;
            ReturnToPreviousPage();
        }

        private void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.InfoHelpPage);

        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.CreditsPage);
        #endregion

        ///////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     PS4DebugPage Control Declarations     --\\\
        ///////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region ControlDeclarations
        private Button InfoHelpBtn;
        private Label SeperatorLine2;
        private Button BackBtn;
        private Label Info;
        private Label SeperatorLine3;
        private Button Gp4CreationPageBtn;
        private Button CreditsBtn;
        private Button MinimizeBtn;
        private Button ExitBtn;
        
        private Label MainLabel;
        
        private Button VerbosityBtn;
        private Button LaunchOrbisPubCmdBtn;
        private Label SeperatorLine1;
        private Button TempDirectoryBtn;
        private Label SeperatorLine0;
        private Label CmdPathLabel;
        private Button CmdPathBtn;

        private void OutputDirectoryLabel_Click_1(object sender, EventArgs e) {

        }

        private Label GP4PathLabel;
        private Button GP4PathBtn;
        private Label OutputDirectoryLabel;
        private Button OutputDirectoryBtn;
        private Label TMPDirectoryLabel;
        private Button TMPDirectoryBtn;
        #endregion
    }
}
