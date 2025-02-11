using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Dobby
{
    public partial class PkgCreationPage
    {
        //======================================\\
        //--|   Designer Crap, No Touchie   |--\\\
        //======================================\\
        #region [Designer Crap, No Touchie]
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
        private void InitializeComponent() {
            this.InfoHelpBtn = new Dobby.Button();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.BackBtn = new Dobby.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new Dobby.Button();
            this.MainLabel = new System.Windows.Forms.Label();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.OrbisCmdPathBox = new Dobby.TextBox();
            this.CmdPathBtn = new Dobby.Button();
            this.GP4PathBox = new Dobby.TextBox();
            this.GP4PathBtn = new Dobby.Button();
            this.OutputDirectoryBox = new Dobby.TextBox();
            this.OutputDirectoryBtn = new Dobby.Button();
            this.TMPDirectoryBox = new Dobby.TextBox();
            this.TMPDirectoryBtn = new Dobby.Button();
            this.OrbisToolPathLabel = new System.Windows.Forms.Label();
            this.Gp4PathLabel = new System.Windows.Forms.Label();
            this.OutputDirectoryLabel = new System.Windows.Forms.Label();
            this.TmpDirectoryLabel = new System.Windows.Forms.Label();
            this.Gp4PageBtn = new Dobby.Button();
            this.TempDirectoryBtn = new Dobby.Button();
            this.VerbosityBtn = new Dobby.Button();
            this.LaunchOrbisPubCmdBtn = new Dobby.Button();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 335);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(151, 21);
            this.InfoHelpBtn.TabIndex = 15;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Variable = null;
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 234);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(391, 15);
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
            this.BackBtn.Location = new System.Drawing.Point(1, 382);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(151, 21);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Variable = null;
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(1, 410);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(393, 19);
            this.Info.TabIndex = 7;
            this.Info.Text = "================================================";
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 358);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(151, 20);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Variable = null;
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(1, 1);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(393, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "fPKG Creation Page";
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(391, 15);
            this.SeperatorLine0.TabIndex = 33;
            this.SeperatorLine0.Text = "--------------------------------------------------------------";
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 50);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(391, 15);
            this.SeperatorLine1.TabIndex = 29;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // CmdPathBox
            // 
            this.OrbisCmdPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.OrbisCmdPathBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.OrbisCmdPathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.OrbisCmdPathBox.Location = new System.Drawing.Point(11, 82);
            this.OrbisCmdPathBox.Name = "CmdPathBox";
            this.OrbisCmdPathBox.Size = new System.Drawing.Size(335, 23);
            this.OrbisCmdPathBox.TabIndex = 50;
            this.OrbisCmdPathBox.Text = "No Program Path Loaded";
            // 
            // CmdPathBtn
            // 
            this.CmdPathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CmdPathBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CmdPathBtn.FlatAppearance.BorderSize = 0;
            this.CmdPathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdPathBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.CmdPathBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CmdPathBtn.Location = new System.Drawing.Point(350, 82);
            this.CmdPathBtn.Name = "CmdPathBtn";
            this.CmdPathBtn.Size = new System.Drawing.Size(51, 19);
            this.CmdPathBtn.TabIndex = 55;
            this.CmdPathBtn.Text = "Browse";
            this.CmdPathBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdPathBtn.UseVisualStyleBackColor = false;
            this.CmdPathBtn.Variable = null;
            this.CmdPathBtn.Click += new System.EventHandler(this.OrbisCmdPathBrowseBtn_Click);
            // 
            // GP4PathBox
            // 
            this.GP4PathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GP4PathBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.GP4PathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GP4PathBox.Location = new System.Drawing.Point(11, 124);
            this.GP4PathBox.Name = "GP4PathBox";
            this.GP4PathBox.Size = new System.Drawing.Size(335, 23);
            this.GP4PathBox.TabIndex = 53;
            this.GP4PathBox.Text = "No .gp4 Or Gamedata Folder Path Selected";
            // 
            // GP4PathBtn
            // 
            this.GP4PathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GP4PathBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GP4PathBtn.FlatAppearance.BorderSize = 0;
            this.GP4PathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GP4PathBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.GP4PathBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.GP4PathBtn.Location = new System.Drawing.Point(350, 123);
            this.GP4PathBtn.Name = "GP4PathBtn";
            this.GP4PathBtn.Size = new System.Drawing.Size(51, 19);
            this.GP4PathBtn.TabIndex = 56;
            this.GP4PathBtn.Text = "Browse";
            this.GP4PathBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GP4PathBtn.UseVisualStyleBackColor = false;
            this.GP4PathBtn.Variable = null;
            this.GP4PathBtn.Click += new System.EventHandler(this.GP4Path_Interact);
            // 
            // OutputDirectoryBox
            // 
            this.OutputDirectoryBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.OutputDirectoryBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.OutputDirectoryBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.OutputDirectoryBox.Location = new System.Drawing.Point(11, 166);
            this.OutputDirectoryBox.Name = "OutputDirectoryBox";
            this.OutputDirectoryBox.Size = new System.Drawing.Size(335, 23);
            this.OutputDirectoryBox.TabIndex = 51;
            this.OutputDirectoryBox.Text = "Using App Folder For .pkg Output";
            this.OutputDirectoryBox.Click += new System.EventHandler(this.OutputDirectory_Click);
            // 
            // OutputDirectoryBtn
            // 
            this.OutputDirectoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.OutputDirectoryBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.OutputDirectoryBtn.FlatAppearance.BorderSize = 0;
            this.OutputDirectoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutputDirectoryBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.OutputDirectoryBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.OutputDirectoryBtn.Location = new System.Drawing.Point(350, 164);
            this.OutputDirectoryBtn.Name = "OutputDirectoryBtn";
            this.OutputDirectoryBtn.Size = new System.Drawing.Size(51, 19);
            this.OutputDirectoryBtn.TabIndex = 57;
            this.OutputDirectoryBtn.Text = "Browse";
            this.OutputDirectoryBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutputDirectoryBtn.UseVisualStyleBackColor = false;
            this.OutputDirectoryBtn.Variable = null;
            this.OutputDirectoryBtn.Click += new System.EventHandler(this.OutputDirectory_Click);
            // 
            // TMPDirectoryBox
            // 
            this.TMPDirectoryBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TMPDirectoryBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.TMPDirectoryBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.TMPDirectoryBox.Location = new System.Drawing.Point(11, 208);
            this.TMPDirectoryBox.Name = "TMPDirectoryBox";
            this.TMPDirectoryBox.Size = new System.Drawing.Size(335, 23);
            this.TMPDirectoryBox.TabIndex = 52;
            this.TMPDirectoryBox.Text = "Using This PC\'s Default TMP Directory";
            // 
            // TMPDirectoryBtn
            // 
            this.TMPDirectoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TMPDirectoryBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.TMPDirectoryBtn.FlatAppearance.BorderSize = 0;
            this.TMPDirectoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TMPDirectoryBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.TMPDirectoryBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.TMPDirectoryBtn.Location = new System.Drawing.Point(350, 205);
            this.TMPDirectoryBtn.Name = "TMPDirectoryBtn";
            this.TMPDirectoryBtn.Size = new System.Drawing.Size(51, 19);
            this.TMPDirectoryBtn.TabIndex = 58;
            this.TMPDirectoryBtn.Text = "Browse";
            this.TMPDirectoryBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TMPDirectoryBtn.UseVisualStyleBackColor = false;
            this.TMPDirectoryBtn.Variable = null;
            this.TMPDirectoryBtn.Click += new System.EventHandler(this.TMPDirectoryItem_Click);
            // 
            // OrbisToolPathLabel
            // 
            this.OrbisToolPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OrbisToolPathLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.OrbisToolPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.OrbisToolPathLabel.Location = new System.Drawing.Point(4, 65);
            this.OrbisToolPathLabel.Name = "OrbisToolPathLabel";
            this.OrbisToolPathLabel.Size = new System.Drawing.Size(201, 14);
            this.OrbisToolPathLabel.TabIndex = 59;
            this.OrbisToolPathLabel.Text = "FPKG/Fake Package Tools Folder Path:";
            // 
            // Gp4PathLabel
            // 
            this.Gp4PathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Gp4PathLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.Gp4PathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.Gp4PathLabel.Location = new System.Drawing.Point(5, 107);
            this.Gp4PathLabel.Name = "Gp4PathLabel";
            this.Gp4PathLabel.Size = new System.Drawing.Size(209, 14);
            this.Gp4PathLabel.TabIndex = 60;
            this.Gp4PathLabel.Text = ".gp4 Project File/Gamedata Folder Path:";
            // 
            // OutputDirectoryLabel
            // 
            this.OutputDirectoryLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputDirectoryLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.OutputDirectoryLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.OutputDirectoryLabel.Location = new System.Drawing.Point(4, 149);
            this.OutputDirectoryLabel.Name = "OutputDirectoryLabel";
            this.OutputDirectoryLabel.Size = new System.Drawing.Size(152, 14);
            this.OutputDirectoryLabel.TabIndex = 61;
            this.OutputDirectoryLabel.Text = "Finished .pkg Output Folder:";
            // 
            // TmpDirectoryLabel
            // 
            this.TmpDirectoryLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TmpDirectoryLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.TmpDirectoryLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.TmpDirectoryLabel.Location = new System.Drawing.Point(4, 191);
            this.TmpDirectoryLabel.Name = "TmpDirectoryLabel";
            this.TmpDirectoryLabel.Size = new System.Drawing.Size(177, 14);
            this.TmpDirectoryLabel.TabIndex = 62;
            this.TmpDirectoryLabel.Text = "Temp Directory For .pkg Creation:";
            // 
            // Gp4PageBtn
            // 
            this.Gp4PageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Gp4PageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Gp4PageBtn.FlatAppearance.BorderSize = 0;
            this.Gp4PageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gp4PageBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.Gp4PageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.Gp4PageBtn.Location = new System.Drawing.Point(2, 31);
            this.Gp4PageBtn.Name = "Gp4PageBtn";
            this.Gp4PageBtn.Size = new System.Drawing.Size(146, 23);
            this.Gp4PageBtn.TabIndex = 63;
            this.Gp4PageBtn.Text = "Create New .gp4 File...";
            this.Gp4PageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Gp4PageBtn.UseVisualStyleBackColor = false;
            this.Gp4PageBtn.Variable = null;
            this.Gp4PageBtn.Click += new System.EventHandler(this.Gp4PageBtn_Click);
            // 
            // TempDirectoryBtn
            // 
            this.TempDirectoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TempDirectoryBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.TempDirectoryBtn.FlatAppearance.BorderSize = 0;
            this.TempDirectoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TempDirectoryBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.TempDirectoryBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.TempDirectoryBtn.Location = new System.Drawing.Point(3, 300);
            this.TempDirectoryBtn.Name = "TempDirectoryBtn";
            this.TempDirectoryBtn.Size = new System.Drawing.Size(209, 23);
            this.TempDirectoryBtn.TabIndex = 66;
            this.TempDirectoryBtn.Text = "Use Custom Temp Directory: ";
            this.TempDirectoryBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TempDirectoryBtn.UseVisualStyleBackColor = false;
            this.TempDirectoryBtn.Variable = null;
            // 
            // VerbosityBtn
            // 
            this.VerbosityBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.VerbosityBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.VerbosityBtn.FlatAppearance.BorderSize = 0;
            this.VerbosityBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerbosityBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.VerbosityBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.VerbosityBtn.Location = new System.Drawing.Point(3, 275);
            this.VerbosityBtn.Name = "VerbosityBtn";
            this.VerbosityBtn.Size = new System.Drawing.Size(270, 23);
            this.VerbosityBtn.TabIndex = 65;
            this.VerbosityBtn.Text = "orbis-pub-cmd Output Mode: Details";
            this.VerbosityBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VerbosityBtn.UseVisualStyleBackColor = false;
            this.VerbosityBtn.Variable = null;
            // 
            // LaunchOrbisPubCmdBtn
            // 
            this.LaunchOrbisPubCmdBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.LaunchOrbisPubCmdBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.LaunchOrbisPubCmdBtn.FlatAppearance.BorderSize = 0;
            this.LaunchOrbisPubCmdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LaunchOrbisPubCmdBtn.Font = new System.Drawing.Font("Cambria", 10.25F, System.Drawing.FontStyle.Bold);
            this.LaunchOrbisPubCmdBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.LaunchOrbisPubCmdBtn.Location = new System.Drawing.Point(3, 250);
            this.LaunchOrbisPubCmdBtn.Name = "LaunchOrbisPubCmdBtn";
            this.LaunchOrbisPubCmdBtn.Size = new System.Drawing.Size(101, 24);
            this.LaunchOrbisPubCmdBtn.TabIndex = 64;
            this.LaunchOrbisPubCmdBtn.Text = "Build .pkg File";
            this.LaunchOrbisPubCmdBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LaunchOrbisPubCmdBtn.UseVisualStyleBackColor = false;
            this.LaunchOrbisPubCmdBtn.Variable = null;
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 319);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(391, 15);
            this.SeperatorLine3.TabIndex = 67;
            this.SeperatorLine3.Text = "--------------------------------------------------------------";
            // 
            // PkgCreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(402, 431);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.TempDirectoryBtn);
            this.Controls.Add(this.VerbosityBtn);
            this.Controls.Add(this.LaunchOrbisPubCmdBtn);
            this.Controls.Add(this.Gp4PageBtn);
            this.Controls.Add(this.TmpDirectoryLabel);
            this.Controls.Add(this.OutputDirectoryLabel);
            this.Controls.Add(this.Gp4PathLabel);
            this.Controls.Add(this.OrbisToolPathLabel);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.TMPDirectoryBox);
            this.Controls.Add(this.TMPDirectoryBtn);
            this.Controls.Add(this.OrbisCmdPathBox);
            this.Controls.Add(this.CmdPathBtn);
            this.Controls.Add(this.GP4PathBox);
            this.Controls.Add(this.GP4PathBtn);
            this.Controls.Add(this.OutputDirectoryBox);
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
            this.PerformLayout();

        }
        #endregion

        private Button TempDirectoryBtn;
        private Button VerbosityBtn;
        private Button LaunchOrbisPubCmdBtn;
        private System.Windows.Forms.Label SeperatorLine3;
    }
}