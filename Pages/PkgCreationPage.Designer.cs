using System;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;


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
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.MainLabel = new System.Windows.Forms.Label();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.OrbisCmdPathLabel = new System.Windows.Forms.Label();
            this.GP4FilePathLabel = new System.Windows.Forms.Label();
            this.OutputDirectoryLabel = new System.Windows.Forms.Label();
            this.TempDirectoryPathLabel = new System.Windows.Forms.Label();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.InfoHelpBtn = new Dobby.Button();
            this.BackBtn = new Dobby.Button();
            this.CreditsBtn = new Dobby.Button();
            this.VerbosityBtn = new Dobby.Button();
            this.BuildPackageBtn = new Dobby.Button();
            this.GP4PageBtn = new Dobby.Button();
            this.TempDirectoryPathBox = new Dobby.TextBox();
            this.TempDirectoryBrowseBtn = new Dobby.Button();
            this.OrbisToolPathBox = new Dobby.TextBox();
            this.OrbisCmdPathBrowseBtn = new Dobby.Button();
            this.GP4FilePathBox = new Dobby.TextBox();
            this.GP4FilePathBrowseBtn = new Dobby.Button();
            this.OutputDirectoryPathBox = new Dobby.TextBox();
            this.OutputDirectoryBrowseBtn = new Dobby.Button();
            this.CleanTempFilesBtn = new Dobby.Button();
            this.SuspendLayout();
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 223);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(391, 15);
            this.SeperatorLine2.TabIndex = 14;
            this.SeperatorLine2.Text = "--------------------------------------------------------------";
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(1, 1);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(465, 23);
            this.MainLabel.TabIndex = 1;
            this.MainLabel.Text = "Package (fpkg) Creation Page";
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 20);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(391, 15);
            this.SeperatorLine0.TabIndex = 33;
            this.SeperatorLine0.Text = "--------------------------------------------------------------";
            // 
            // OrbisCmdPathLabel
            // 
            this.OrbisCmdPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OrbisCmdPathLabel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.OrbisCmdPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.OrbisCmdPathLabel.Location = new System.Drawing.Point(3, 38);
            this.OrbisCmdPathLabel.Name = "OrbisCmdPathLabel";
            this.OrbisCmdPathLabel.Size = new System.Drawing.Size(220, 16);
            this.OrbisCmdPathLabel.TabIndex = 59;
            this.OrbisCmdPathLabel.Text = "FPKG/Fake Package Tools Folder Path:";
            // 
            // GP4FilePathLabel
            // 
            this.GP4FilePathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GP4FilePathLabel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.GP4FilePathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.GP4FilePathLabel.Location = new System.Drawing.Point(3, 85);
            this.GP4FilePathLabel.Name = "GP4FilePathLabel";
            this.GP4FilePathLabel.Size = new System.Drawing.Size(228, 16);
            this.GP4FilePathLabel.TabIndex = 60;
            this.GP4FilePathLabel.Text = ".gp4 Project File/Gamedata Folder Path:";
            // 
            // OutputDirectoryLabel
            // 
            this.OutputDirectoryLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputDirectoryLabel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.OutputDirectoryLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.OutputDirectoryLabel.Location = new System.Drawing.Point(3, 132);
            this.OutputDirectoryLabel.Name = "OutputDirectoryLabel";
            this.OutputDirectoryLabel.Size = new System.Drawing.Size(167, 16);
            this.OutputDirectoryLabel.TabIndex = 61;
            this.OutputDirectoryLabel.Text = "Finished .pkg Output Folder:";
            // 
            // TempDirectoryPathLabel
            // 
            this.TempDirectoryPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TempDirectoryPathLabel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.TempDirectoryPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.TempDirectoryPathLabel.Location = new System.Drawing.Point(3, 179);
            this.TempDirectoryPathLabel.Name = "TempDirectoryPathLabel";
            this.TempDirectoryPathLabel.Size = new System.Drawing.Size(198, 16);
            this.TempDirectoryPathLabel.TabIndex = 62;
            this.TempDirectoryPathLabel.Text = "Temp Directory For .pkg Creation:";
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 295);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(391, 15);
            this.SeperatorLine3.TabIndex = 67;
            this.SeperatorLine3.Text = "--------------------------------------------------------------";
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(6, 448);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(452, 19);
            this.Info.TabIndex = 68;
            this.Info.Text = "======================================";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Cambria", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label1.Location = new System.Drawing.Point(2, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 15);
            this.label1.TabIndex = 72;
            this.label1.Text = "--------------------------------------------------------------";
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 372);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(142, 23);
            this.InfoHelpBtn.TabIndex = 70;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 422);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(58, 23);
            this.BackBtn.TabIndex = 0;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 397);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(68, 23);
            this.CreditsBtn.TabIndex = 71;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            // 
            // VerbosityBtn
            // 
            this.VerbosityBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.VerbosityBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.VerbosityBtn.FlatAppearance.BorderSize = 0;
            this.VerbosityBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerbosityBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.VerbosityBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.VerbosityBtn.Location = new System.Drawing.Point(1, 312);
            this.VerbosityBtn.Name = "VerbosityBtn";
            this.VerbosityBtn.Size = new System.Drawing.Size(218, 23);
            this.VerbosityBtn.TabIndex = 65;
            this.VerbosityBtn.Text = "orbis-pub-cmd Output Mode: ";
            this.VerbosityBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VerbosityBtn.UseVisualStyleBackColor = false;
            this.VerbosityBtn.Click += new System.EventHandler(this.VerbosityBtn_Click);
            // 
            // BuildPackageBtn
            // 
            this.BuildPackageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BuildPackageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BuildPackageBtn.FlatAppearance.BorderSize = 0;
            this.BuildPackageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuildPackageBtn.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.BuildPackageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BuildPackageBtn.Location = new System.Drawing.Point(2, 240);
            this.BuildPackageBtn.Name = "BuildPackageBtn";
            this.BuildPackageBtn.Size = new System.Drawing.Size(185, 25);
            this.BuildPackageBtn.TabIndex = 64;
            this.BuildPackageBtn.Text = "Build Package/.pkg File";
            this.BuildPackageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BuildPackageBtn.UseVisualStyleBackColor = false;
            this.BuildPackageBtn.Click += new System.EventHandler(this.LaunchOrbisPubCmdBtn_Click);
            // 
            // GP4PageBtn
            // 
            this.GP4PageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GP4PageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GP4PageBtn.FlatAppearance.BorderSize = 0;
            this.GP4PageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GP4PageBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.GP4PageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.GP4PageBtn.Location = new System.Drawing.Point(2, 271);
            this.GP4PageBtn.Name = "GP4PageBtn";
            this.GP4PageBtn.Size = new System.Drawing.Size(356, 23);
            this.GP4PageBtn.TabIndex = 63;
            this.GP4PageBtn.Text = "Create a New .gp4 File for Fake Package (fPKG) Creation...";
            this.GP4PageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GP4PageBtn.UseVisualStyleBackColor = false;
            this.GP4PageBtn.Click += new System.EventHandler(this.GP4CreationPageBtn_Click);
            // 
            // TempDirectoryPathBox
            // 
            this.TempDirectoryPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TempDirectoryPathBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.TempDirectoryPathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.TempDirectoryPathBox.Location = new System.Drawing.Point(7, 199);
            this.TempDirectoryPathBox.Name = "TempDirectoryPathBox";
            this.TempDirectoryPathBox.Size = new System.Drawing.Size(395, 23);
            this.TempDirectoryPathBox.TabIndex = 52;
            this.TempDirectoryPathBox.Text = "Using This PC\'s Default TMP Directory";
            this.TempDirectoryPathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TempDirectoryBrowseBtn
            // 
            this.TempDirectoryBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TempDirectoryBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.TempDirectoryBrowseBtn.FlatAppearance.BorderSize = 0;
            this.TempDirectoryBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TempDirectoryBrowseBtn.Font = new System.Drawing.Font("Verdana", 8F);
            this.TempDirectoryBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.TempDirectoryBrowseBtn.Location = new System.Drawing.Point(407, 200);
            this.TempDirectoryBrowseBtn.Name = "TempDirectoryBrowseBtn";
            this.TempDirectoryBrowseBtn.Size = new System.Drawing.Size(57, 19);
            this.TempDirectoryBrowseBtn.TabIndex = 58;
            this.TempDirectoryBrowseBtn.Text = "Browse";
            this.TempDirectoryBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TempDirectoryBrowseBtn.UseVisualStyleBackColor = false;
            this.TempDirectoryBrowseBtn.Click += new System.EventHandler(this.TMPDirectoryItem_Click);
            // 
            // OrbisToolPathBox
            // 
            this.OrbisToolPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.OrbisToolPathBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.OrbisToolPathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.OrbisToolPathBox.Location = new System.Drawing.Point(7, 58);
            this.OrbisToolPathBox.Name = "OrbisToolPathBox";
            this.OrbisToolPathBox.Size = new System.Drawing.Size(395, 23);
            this.OrbisToolPathBox.TabIndex = 50;
            this.OrbisToolPathBox.Text = "No Program Path Loaded";
            this.OrbisToolPathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OrbisCmdPathBrowseBtn
            // 
            this.OrbisCmdPathBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.OrbisCmdPathBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.OrbisCmdPathBrowseBtn.FlatAppearance.BorderSize = 0;
            this.OrbisCmdPathBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrbisCmdPathBrowseBtn.Font = new System.Drawing.Font("Verdana", 8F);
            this.OrbisCmdPathBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.OrbisCmdPathBrowseBtn.Location = new System.Drawing.Point(407, 59);
            this.OrbisCmdPathBrowseBtn.Name = "OrbisCmdPathBrowseBtn";
            this.OrbisCmdPathBrowseBtn.Size = new System.Drawing.Size(57, 19);
            this.OrbisCmdPathBrowseBtn.TabIndex = 55;
            this.OrbisCmdPathBrowseBtn.Text = "Browse";
            this.OrbisCmdPathBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OrbisCmdPathBrowseBtn.UseVisualStyleBackColor = false;
            this.OrbisCmdPathBrowseBtn.Click += new System.EventHandler(this.OrbisCmdPathBrowseBtn_Click);
            // 
            // GP4FilePathBox
            // 
            this.GP4FilePathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GP4FilePathBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.GP4FilePathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GP4FilePathBox.Location = new System.Drawing.Point(7, 105);
            this.GP4FilePathBox.Name = "GP4FilePathBox";
            this.GP4FilePathBox.Size = new System.Drawing.Size(395, 23);
            this.GP4FilePathBox.TabIndex = 53;
            this.GP4FilePathBox.Text = "No .gp4 Or Gamedata Folder Path Selected";
            this.GP4FilePathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GP4FilePathBrowseBtn
            // 
            this.GP4FilePathBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GP4FilePathBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GP4FilePathBrowseBtn.FlatAppearance.BorderSize = 0;
            this.GP4FilePathBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GP4FilePathBrowseBtn.Font = new System.Drawing.Font("Verdana", 8F);
            this.GP4FilePathBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.GP4FilePathBrowseBtn.Location = new System.Drawing.Point(407, 106);
            this.GP4FilePathBrowseBtn.Name = "GP4FilePathBrowseBtn";
            this.GP4FilePathBrowseBtn.Size = new System.Drawing.Size(57, 19);
            this.GP4FilePathBrowseBtn.TabIndex = 56;
            this.GP4FilePathBrowseBtn.Text = "Browse";
            this.GP4FilePathBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GP4FilePathBrowseBtn.UseVisualStyleBackColor = false;
            this.GP4FilePathBrowseBtn.Click += new System.EventHandler(this.GP4FilePathBrowseBtn_Click);
            // 
            // OutputDirectoryPathBox
            // 
            this.OutputDirectoryPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.OutputDirectoryPathBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.OutputDirectoryPathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.OutputDirectoryPathBox.Location = new System.Drawing.Point(7, 152);
            this.OutputDirectoryPathBox.Name = "OutputDirectoryPathBox";
            this.OutputDirectoryPathBox.Size = new System.Drawing.Size(395, 23);
            this.OutputDirectoryPathBox.TabIndex = 51;
            this.OutputDirectoryPathBox.Text = "Using App Folder For .pkg Output";
            this.OutputDirectoryPathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OutputDirectoryBrowseBtn
            // 
            this.OutputDirectoryBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.OutputDirectoryBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.OutputDirectoryBrowseBtn.FlatAppearance.BorderSize = 0;
            this.OutputDirectoryBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutputDirectoryBrowseBtn.Font = new System.Drawing.Font("Verdana", 8F);
            this.OutputDirectoryBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.OutputDirectoryBrowseBtn.Location = new System.Drawing.Point(407, 153);
            this.OutputDirectoryBrowseBtn.Name = "OutputDirectoryBrowseBtn";
            this.OutputDirectoryBrowseBtn.Size = new System.Drawing.Size(57, 19);
            this.OutputDirectoryBrowseBtn.TabIndex = 57;
            this.OutputDirectoryBrowseBtn.Text = "Browse";
            this.OutputDirectoryBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutputDirectoryBrowseBtn.UseVisualStyleBackColor = false;
            this.OutputDirectoryBrowseBtn.Click += new System.EventHandler(this.OutputDirectory_Click);
            // 
            // CleanTempFilesBtn
            // 
            this.CleanTempFilesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CleanTempFilesBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CleanTempFilesBtn.FlatAppearance.BorderSize = 0;
            this.CleanTempFilesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CleanTempFilesBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.CleanTempFilesBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CleanTempFilesBtn.Location = new System.Drawing.Point(1, 337);
            this.CleanTempFilesBtn.Name = "CleanTempFilesBtn";
            this.CleanTempFilesBtn.Size = new System.Drawing.Size(218, 23);
            this.CleanTempFilesBtn.TabIndex = 73;
            this.CleanTempFilesBtn.Text = "Clean Temporary Files Post-Build: ";
            this.CleanTempFilesBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CleanTempFilesBtn.UseVisualStyleBackColor = false;
            this.CleanTempFilesBtn.Click += new System.EventHandler(this.CleanTempFilesBtn_Click);
            // 
            // PkgCreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(467, 472);
            this.Controls.Add(this.CleanTempFilesBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.VerbosityBtn);
            this.Controls.Add(this.BuildPackageBtn);
            this.Controls.Add(this.GP4PageBtn);
            this.Controls.Add(this.TempDirectoryPathLabel);
            this.Controls.Add(this.OutputDirectoryLabel);
            this.Controls.Add(this.GP4FilePathLabel);
            this.Controls.Add(this.OrbisCmdPathLabel);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.TempDirectoryPathBox);
            this.Controls.Add(this.TempDirectoryBrowseBtn);
            this.Controls.Add(this.OrbisToolPathBox);
            this.Controls.Add(this.OrbisCmdPathBrowseBtn);
            this.Controls.Add(this.GP4FilePathBox);
            this.Controls.Add(this.GP4FilePathBrowseBtn);
            this.Controls.Add(this.OutputDirectoryPathBox);
            this.Controls.Add(this.OutputDirectoryBrowseBtn);
            this.Controls.Add(this.SeperatorLine2);
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
        
        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        private Label SeperatorLine0;
        private Label SeperatorLine2;
        private Label OrbisCmdPathLabel;
        private Label GP4FilePathLabel;
        private Label OutputDirectoryLabel;
        private Label TempDirectoryPathLabel;
        private Label MainLabel;
        private TextBox OrbisToolPathBox;
        private Button GP4PageBtn;
        private Button OrbisCmdPathBrowseBtn;
        private TextBox GP4FilePathBox;
        private Button GP4FilePathBrowseBtn;
        private TextBox OutputDirectoryPathBox;
        private Button OutputDirectoryBrowseBtn;
        private TextBox TempDirectoryPathBox;
        private Button TempDirectoryBrowseBtn;
        private Button VerbosityBtn;
        private Button BuildPackageBtn;
        private System.Windows.Forms.Label SeperatorLine3;
        private Button InfoHelpBtn;
        private Button BackBtn;
        private Button CreditsBtn;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Label label1;
        #endregion

        private Button CleanTempFilesBtn;
    }
}