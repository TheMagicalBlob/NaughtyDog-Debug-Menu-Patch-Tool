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
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.MainLabel = new System.Windows.Forms.Label();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.OrbisCmdPathBox = new Dobby.TextBox();
            this.OrbisCmdPathBrowseBtn = new Dobby.Button();
            this.GP4PathBox = new Dobby.TextBox();
            this.GP4PathBrowseBtn = new Dobby.Button();
            this.OutputDirectoryPathBox = new Dobby.TextBox();
            this.OutputDirectoryBrowseBtn = new Dobby.Button();
            this.TMPDirectoryPathBox = new Dobby.TextBox();
            this.TMPDirectoryBrowseBtn = new Dobby.Button();
            this.OrbisCmdPathLabel = new System.Windows.Forms.Label();
            this.Gp4PathLabel = new System.Windows.Forms.Label();
            this.OutputDirectoryLabel = new System.Windows.Forms.Label();
            this.TmpDirectoryPathLabel = new System.Windows.Forms.Label();
            this.Gp4PageBtn = new Dobby.Button();
            this.TempDirectoryBtn = new Dobby.Button();
            this.VerbosityBtn = new Dobby.Button();
            this.LaunchOrbisPubCmdBtn = new Dobby.Button();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.InfoHelpBtn = new Dobby.Button();
            this.BackBtn = new Dobby.Button();
            this.CreditsBtn = new Dobby.Button();
            this.Info = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.MainLabel.Size = new System.Drawing.Size(393, 23);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "fPKG Creation Page";
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
            // OrbisCmdPathBox
            // 
            this.OrbisCmdPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.OrbisCmdPathBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.OrbisCmdPathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.OrbisCmdPathBox.Location = new System.Drawing.Point(7, 58);
            this.OrbisCmdPathBox.Name = "OrbisCmdPathBox";
            this.OrbisCmdPathBox.Size = new System.Drawing.Size(395, 23);
            this.OrbisCmdPathBox.TabIndex = 50;
            this.OrbisCmdPathBox.Text = "No Program Path Loaded";
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
            this.OrbisCmdPathBrowseBtn.Variable = null;
            this.OrbisCmdPathBrowseBtn.Click += new System.EventHandler(this.OrbisCmdPathBrowseBtn_Click);
            // 
            // GP4PathBox
            // 
            this.GP4PathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GP4PathBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.GP4PathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GP4PathBox.Location = new System.Drawing.Point(7, 105);
            this.GP4PathBox.Name = "GP4PathBox";
            this.GP4PathBox.Size = new System.Drawing.Size(395, 23);
            this.GP4PathBox.TabIndex = 53;
            this.GP4PathBox.Text = "No .gp4 Or Gamedata Folder Path Selected";
            // 
            // GP4PathBrowseBtn
            // 
            this.GP4PathBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GP4PathBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GP4PathBrowseBtn.FlatAppearance.BorderSize = 0;
            this.GP4PathBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GP4PathBrowseBtn.Font = new System.Drawing.Font("Verdana", 8F);
            this.GP4PathBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.GP4PathBrowseBtn.Location = new System.Drawing.Point(407, 106);
            this.GP4PathBrowseBtn.Name = "GP4PathBrowseBtn";
            this.GP4PathBrowseBtn.Size = new System.Drawing.Size(57, 19);
            this.GP4PathBrowseBtn.TabIndex = 56;
            this.GP4PathBrowseBtn.Text = "Browse";
            this.GP4PathBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GP4PathBrowseBtn.UseVisualStyleBackColor = false;
            this.GP4PathBrowseBtn.Variable = null;
            this.GP4PathBrowseBtn.Click += new System.EventHandler(this.GP4Path_Interact);
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
            this.OutputDirectoryPathBox.Click += new System.EventHandler(this.OutputDirectory_Click);
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
            this.OutputDirectoryBrowseBtn.Variable = null;
            this.OutputDirectoryBrowseBtn.Click += new System.EventHandler(this.OutputDirectory_Click);
            // 
            // TMPDirectoryPathBox
            // 
            this.TMPDirectoryPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TMPDirectoryPathBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.TMPDirectoryPathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.TMPDirectoryPathBox.Location = new System.Drawing.Point(7, 199);
            this.TMPDirectoryPathBox.Name = "TMPDirectoryPathBox";
            this.TMPDirectoryPathBox.Size = new System.Drawing.Size(395, 23);
            this.TMPDirectoryPathBox.TabIndex = 52;
            this.TMPDirectoryPathBox.Text = "Using This PC\'s Default TMP Directory";
            // 
            // TMPDirectoryBrowseBtn
            // 
            this.TMPDirectoryBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TMPDirectoryBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.TMPDirectoryBrowseBtn.FlatAppearance.BorderSize = 0;
            this.TMPDirectoryBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TMPDirectoryBrowseBtn.Font = new System.Drawing.Font("Verdana", 8F);
            this.TMPDirectoryBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.TMPDirectoryBrowseBtn.Location = new System.Drawing.Point(407, 200);
            this.TMPDirectoryBrowseBtn.Name = "TMPDirectoryBrowseBtn";
            this.TMPDirectoryBrowseBtn.Size = new System.Drawing.Size(57, 19);
            this.TMPDirectoryBrowseBtn.TabIndex = 58;
            this.TMPDirectoryBrowseBtn.Text = "Browse";
            this.TMPDirectoryBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TMPDirectoryBrowseBtn.UseVisualStyleBackColor = false;
            this.TMPDirectoryBrowseBtn.Variable = null;
            this.TMPDirectoryBrowseBtn.Click += new System.EventHandler(this.TMPDirectoryItem_Click);
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
            // Gp4PathLabel
            // 
            this.Gp4PathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Gp4PathLabel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.Gp4PathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.Gp4PathLabel.Location = new System.Drawing.Point(3, 85);
            this.Gp4PathLabel.Name = "Gp4PathLabel";
            this.Gp4PathLabel.Size = new System.Drawing.Size(228, 16);
            this.Gp4PathLabel.TabIndex = 60;
            this.Gp4PathLabel.Text = ".gp4 Project File/Gamedata Folder Path:";
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
            // TmpDirectoryPathLabel
            // 
            this.TmpDirectoryPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TmpDirectoryPathLabel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.TmpDirectoryPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.TmpDirectoryPathLabel.Location = new System.Drawing.Point(3, 179);
            this.TmpDirectoryPathLabel.Name = "TmpDirectoryPathLabel";
            this.TmpDirectoryPathLabel.Size = new System.Drawing.Size(198, 16);
            this.TmpDirectoryPathLabel.TabIndex = 62;
            this.TmpDirectoryPathLabel.Text = "Temp Directory For .pkg Creation:";
            // 
            // Gp4PageBtn
            // 
            this.Gp4PageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Gp4PageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Gp4PageBtn.FlatAppearance.BorderSize = 0;
            this.Gp4PageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gp4PageBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.Gp4PageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.Gp4PageBtn.Location = new System.Drawing.Point(2, 271);
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
            this.TempDirectoryBtn.Location = new System.Drawing.Point(1, 340);
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
            this.VerbosityBtn.Location = new System.Drawing.Point(1, 312);
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
            this.LaunchOrbisPubCmdBtn.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.LaunchOrbisPubCmdBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.LaunchOrbisPubCmdBtn.Location = new System.Drawing.Point(2, 240);
            this.LaunchOrbisPubCmdBtn.Name = "LaunchOrbisPubCmdBtn";
            this.LaunchOrbisPubCmdBtn.Size = new System.Drawing.Size(185, 25);
            this.LaunchOrbisPubCmdBtn.TabIndex = 64;
            this.LaunchOrbisPubCmdBtn.Text = "Build Package/.pkg File";
            this.LaunchOrbisPubCmdBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LaunchOrbisPubCmdBtn.UseVisualStyleBackColor = false;
            this.LaunchOrbisPubCmdBtn.Variable = null;
            this.LaunchOrbisPubCmdBtn.Click += new System.EventHandler(this.LaunchOrbisPubCmdBtn_Click);
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
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 375);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(142, 23);
            this.InfoHelpBtn.TabIndex = 70;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Variable = null;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 425);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(58, 23);
            this.BackBtn.TabIndex = 69;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Variable = null;
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 400);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(68, 23);
            this.CreditsBtn.TabIndex = 71;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Variable = null;
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(6, 450);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(452, 19);
            this.Info.TabIndex = 68;
            this.Info.Text = "======================================";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Cambria", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label1.Location = new System.Drawing.Point(2, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 15);
            this.label1.TabIndex = 72;
            this.label1.Text = "--------------------------------------------------------------";
            // 
            // PkgCreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(467, 471);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.TempDirectoryBtn);
            this.Controls.Add(this.VerbosityBtn);
            this.Controls.Add(this.LaunchOrbisPubCmdBtn);
            this.Controls.Add(this.Gp4PageBtn);
            this.Controls.Add(this.TmpDirectoryPathLabel);
            this.Controls.Add(this.OutputDirectoryLabel);
            this.Controls.Add(this.Gp4PathLabel);
            this.Controls.Add(this.OrbisCmdPathLabel);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.TMPDirectoryPathBox);
            this.Controls.Add(this.TMPDirectoryBrowseBtn);
            this.Controls.Add(this.OrbisCmdPathBox);
            this.Controls.Add(this.OrbisCmdPathBrowseBtn);
            this.Controls.Add(this.GP4PathBox);
            this.Controls.Add(this.GP4PathBrowseBtn);
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

        private Button TempDirectoryBtn;
        private Button VerbosityBtn;
        private Button LaunchOrbisPubCmdBtn;
        private System.Windows.Forms.Label SeperatorLine3;
        private Button InfoHelpBtn;
        private Button BackBtn;
        private Button CreditsBtn;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Label label1;
    }
}