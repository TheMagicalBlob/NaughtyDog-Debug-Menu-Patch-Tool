
using System.Windows.Forms;

namespace Dobby
{
    internal partial class GP4CreationPage : System.Windows.Forms.Form
    {
        //=====================================\\
        //--|   Designer Crap, No Touchie   |--\\
        //=====================================\\
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
        public void InitializeComponent() {
            this.Info = new Dobby.Label();
            this.MainLabel = new Dobby.Label();
            this.SeperatorLine0 = new Dobby.Label();
            this.SeperatorLine4 = new Dobby.Label();
            this.GamedataPathLabel = new Dobby.Label();
            this.GP4OutputPathLabel = new Dobby.Label();
            this.PasscodeLabel = new Dobby.Label();
            this.FileBlacklistPathLabel = new Dobby.Label();
            this.BaseGamePackagePathLabel = new Dobby.Label();
            this.SeperatorLine2 = new Dobby.Label();
            this.SeperatorLine3 = new Dobby.Label();
            this.SeperatorLine1 = new Dobby.Label();
            this.GP4CreationBtn = new Dobby.Button();
            this.IgnoreKeystoneBtn = new Dobby.Button();
            this.AbsoluteFilePathsBtn = new Dobby.Button();
            this.BaseGamePackagePathBox = new Dobby.TextBox();
            this.BaseGamePackageBrowseBtn = new Dobby.Button();
            this.PasscodePathBox = new Dobby.TextBox();
            this.FileBlacklistPathBox = new Dobby.TextBox();
            this.FileBlacklistBrowseBtn = new Dobby.Button();
            this.GP4OutputDirectoryPathBox = new Dobby.TextBox();
            this.GP4OutputDirectoryBrowseBtn = new Dobby.Button();
            this.GamedataPathBox = new Dobby.TextBox();
            this.GamedataPathBrowseBtn = new Dobby.Button();
            this.InfoHelpBtn = new Dobby.Button();
            this.BackBtn = new Dobby.Button();
            this.CreditsBtn = new Dobby.Button();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 9.25F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(4, 475);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(459, 19);
            this.Info.TabIndex = 7;
            this.Info.Text = "============================================================================";
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(1, 1);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(465, 23);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "GP4 Creation Page";
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 20);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine0.TabIndex = 33;
            this.SeperatorLine0.Text = "--------------------------------------------------------------";
            this.SeperatorLine0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SeperatorLine4
            // 
            this.SeperatorLine4.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine4.Location = new System.Drawing.Point(2, 382);
            this.SeperatorLine4.Name = "SeperatorLine4";
            this.SeperatorLine4.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine4.TabIndex = 29;
            this.SeperatorLine4.Text = "--------------------------------------------------------------";
            this.SeperatorLine4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GamedataPathLabel
            // 
            this.GamedataPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GamedataPathLabel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.GamedataPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.GamedataPathLabel.Location = new System.Drawing.Point(3, 38);
            this.GamedataPathLabel.Name = "GamedataPathLabel";
            this.GamedataPathLabel.Size = new System.Drawing.Size(342, 16);
            this.GamedataPathLabel.TabIndex = 73;
            this.GamedataPathLabel.Text = "Application/Patch Data Path:";
            // 
            // GP4OutputPathLabel
            // 
            this.GP4OutputPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GP4OutputPathLabel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.GP4OutputPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.GP4OutputPathLabel.Location = new System.Drawing.Point(3, 97);
            this.GP4OutputPathLabel.Name = "GP4OutputPathLabel";
            this.GP4OutputPathLabel.Size = new System.Drawing.Size(342, 16);
            this.GP4OutputPathLabel.TabIndex = 76;
            this.GP4OutputPathLabel.Text = ".gp4 Project Output Directory:";
            // 
            // PasscodeLabel
            // 
            this.PasscodeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasscodeLabel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.PasscodeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PasscodeLabel.Location = new System.Drawing.Point(3, 238);
            this.PasscodeLabel.Name = "PasscodeLabel";
            this.PasscodeLabel.Size = new System.Drawing.Size(342, 16);
            this.PasscodeLabel.TabIndex = 82;
            this.PasscodeLabel.Text = "Package Passcode:";
            // 
            // FileBlacklistPathLabel
            // 
            this.FileBlacklistPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileBlacklistPathLabel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.FileBlacklistPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.FileBlacklistPathLabel.Location = new System.Drawing.Point(3, 191);
            this.FileBlacklistPathLabel.Name = "FileBlacklistPathLabel";
            this.FileBlacklistPathLabel.Size = new System.Drawing.Size(342, 16);
            this.FileBlacklistPathLabel.TabIndex = 79;
            this.FileBlacklistPathLabel.Text = "File/Folder Blacklist:";
            // 
            // BaseGamePackagePathLabel
            // 
            this.BaseGamePackagePathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BaseGamePackagePathLabel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.BaseGamePackagePathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.BaseGamePackagePathLabel.Location = new System.Drawing.Point(3, 144);
            this.BaseGamePackagePathLabel.Name = "BaseGamePackagePathLabel";
            this.BaseGamePackagePathLabel.Size = new System.Drawing.Size(396, 16);
            this.BaseGamePackagePathLabel.TabIndex = 85;
            this.BaseGamePackagePathLabel.Text = "Base Game Package Directory:                               (patches/updates only)" +
    "";
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 82);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(295, 15);
            this.SeperatorLine2.TabIndex = 86;
            this.SeperatorLine2.Text = "--------------------------------------------------------------";
            this.SeperatorLine2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 282);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine3.TabIndex = 87;
            this.SeperatorLine3.Text = "--------------------------------------------------------------";
            this.SeperatorLine3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 318);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(326, 15);
            this.SeperatorLine1.TabIndex = 91;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            this.SeperatorLine1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GP4CreationBtn
            // 
            this.GP4CreationBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GP4CreationBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GP4CreationBtn.FlatAppearance.BorderSize = 0;
            this.GP4CreationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GP4CreationBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.GP4CreationBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.GP4CreationBtn.Location = new System.Drawing.Point(3, 297);
            this.GP4CreationBtn.Name = "GP4CreationBtn";
            this.GP4CreationBtn.Size = new System.Drawing.Size(192, 24);
            this.GP4CreationBtn.TabIndex = 90;
            this.GP4CreationBtn.Text = "Build New .gp4 Project File";
            this.GP4CreationBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GP4CreationBtn.UseVisualStyleBackColor = false;
            this.GP4CreationBtn.Variable = null;
            this.GP4CreationBtn.Click += new System.EventHandler(this.GP4CreationBtn_Click);
            // 
            // IgnoreKeystoneBtn
            // 
            this.IgnoreKeystoneBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.IgnoreKeystoneBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.IgnoreKeystoneBtn.FlatAppearance.BorderSize = 0;
            this.IgnoreKeystoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IgnoreKeystoneBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.IgnoreKeystoneBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.IgnoreKeystoneBtn.Location = new System.Drawing.Point(3, 362);
            this.IgnoreKeystoneBtn.Name = "IgnoreKeystoneBtn";
            this.IgnoreKeystoneBtn.Size = new System.Drawing.Size(109, 23);
            this.IgnoreKeystoneBtn.TabIndex = 89;
            this.IgnoreKeystoneBtn.Text = "Keystone: ";
            this.IgnoreKeystoneBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IgnoreKeystoneBtn.UseVisualStyleBackColor = false;
            this.IgnoreKeystoneBtn.Variable = null;
            // 
            // AbsoluteFilePathsBtn
            // 
            this.AbsoluteFilePathsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.AbsoluteFilePathsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.AbsoluteFilePathsBtn.FlatAppearance.BorderSize = 0;
            this.AbsoluteFilePathsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AbsoluteFilePathsBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.AbsoluteFilePathsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.AbsoluteFilePathsBtn.Location = new System.Drawing.Point(3, 334);
            this.AbsoluteFilePathsBtn.Name = "AbsoluteFilePathsBtn";
            this.AbsoluteFilePathsBtn.Size = new System.Drawing.Size(191, 23);
            this.AbsoluteFilePathsBtn.TabIndex = 88;
            this.AbsoluteFilePathsBtn.Text = "Use Absolute File Paths: ";
            this.AbsoluteFilePathsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AbsoluteFilePathsBtn.UseVisualStyleBackColor = false;
            this.AbsoluteFilePathsBtn.Variable = null;
            // 
            // BaseGamePackagePathBox
            // 
            this.BaseGamePackagePathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BaseGamePackagePathBox.Font = new System.Drawing.Font("Cambria", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.BaseGamePackagePathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.BaseGamePackagePathBox.Location = new System.Drawing.Point(7, 164);
            this.BaseGamePackagePathBox.Name = "BaseGamePackagePathBox";
            this.BaseGamePackagePathBox.Size = new System.Drawing.Size(395, 23);
            this.BaseGamePackagePathBox.TabIndex = 83;
            this.BaseGamePackagePathBox.Text = "No Base Game .pkg Path Provided";
            this.BaseGamePackagePathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BaseGamePackageBrowseBtn
            // 
            this.BaseGamePackageBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BaseGamePackageBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BaseGamePackageBrowseBtn.FlatAppearance.BorderSize = 0;
            this.BaseGamePackageBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaseGamePackageBrowseBtn.Font = new System.Drawing.Font("Verdana", 8F);
            this.BaseGamePackageBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BaseGamePackageBrowseBtn.Location = new System.Drawing.Point(407, 165);
            this.BaseGamePackageBrowseBtn.Name = "BaseGamePackageBrowseBtn";
            this.BaseGamePackageBrowseBtn.Size = new System.Drawing.Size(57, 19);
            this.BaseGamePackageBrowseBtn.TabIndex = 84;
            this.BaseGamePackageBrowseBtn.Text = "Browse";
            this.BaseGamePackageBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BaseGamePackageBrowseBtn.UseVisualStyleBackColor = false;
            this.BaseGamePackageBrowseBtn.Variable = null;
            this.BaseGamePackageBrowseBtn.Click += new System.EventHandler(this.BaseGamePackageBrowseBtn_Click);
            // 
            // PasscodePathBox
            // 
            this.PasscodePathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PasscodePathBox.Font = new System.Drawing.Font("Cambria", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.PasscodePathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.PasscodePathBox.Location = new System.Drawing.Point(7, 258);
            this.PasscodePathBox.MaxLength = 32;
            this.PasscodePathBox.Name = "PasscodePathBox";
            this.PasscodePathBox.Size = new System.Drawing.Size(395, 23);
            this.PasscodePathBox.TabIndex = 80;
            this.PasscodePathBox.Text = "00000000000000000000000000000000";
            this.PasscodePathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FileBlacklistPathBox
            // 
            this.FileBlacklistPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FileBlacklistPathBox.Font = new System.Drawing.Font("Cambria", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.FileBlacklistPathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.FileBlacklistPathBox.Location = new System.Drawing.Point(7, 211);
            this.FileBlacklistPathBox.Name = "FileBlacklistPathBox";
            this.FileBlacklistPathBox.Size = new System.Drawing.Size(395, 23);
            this.FileBlacklistPathBox.TabIndex = 77;
            this.FileBlacklistPathBox.Text = "Blacklisted Files/Folders To Exclude, Seperated By ; or ,";
            this.FileBlacklistPathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FileBlacklistBrowseBtn
            // 
            this.FileBlacklistBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FileBlacklistBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.FileBlacklistBrowseBtn.FlatAppearance.BorderSize = 0;
            this.FileBlacklistBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileBlacklistBrowseBtn.Font = new System.Drawing.Font("Verdana", 8F);
            this.FileBlacklistBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.FileBlacklistBrowseBtn.Location = new System.Drawing.Point(407, 212);
            this.FileBlacklistBrowseBtn.Name = "FileBlacklistBrowseBtn";
            this.FileBlacklistBrowseBtn.Size = new System.Drawing.Size(57, 19);
            this.FileBlacklistBrowseBtn.TabIndex = 78;
            this.FileBlacklistBrowseBtn.Text = "Browse";
            this.FileBlacklistBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileBlacklistBrowseBtn.UseVisualStyleBackColor = false;
            this.FileBlacklistBrowseBtn.Variable = null;
            this.FileBlacklistBrowseBtn.Click += new System.EventHandler(this.FileBlacklistBrowseBtn_Click);
            // 
            // GP4OutputDirectoryPathBox
            // 
            this.GP4OutputDirectoryPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GP4OutputDirectoryPathBox.Font = new System.Drawing.Font("Cambria", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.GP4OutputDirectoryPathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GP4OutputDirectoryPathBox.Location = new System.Drawing.Point(7, 117);
            this.GP4OutputDirectoryPathBox.Name = "GP4OutputDirectoryPathBox";
            this.GP4OutputDirectoryPathBox.Size = new System.Drawing.Size(395, 23);
            this.GP4OutputDirectoryPathBox.TabIndex = 74;
            this.GP4OutputDirectoryPathBox.Text = "Using Default Output Directory";
            this.GP4OutputDirectoryPathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GP4OutputDirectoryBrowseBtn
            // 
            this.GP4OutputDirectoryBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GP4OutputDirectoryBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GP4OutputDirectoryBrowseBtn.FlatAppearance.BorderSize = 0;
            this.GP4OutputDirectoryBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GP4OutputDirectoryBrowseBtn.Font = new System.Drawing.Font("Verdana", 8F);
            this.GP4OutputDirectoryBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.GP4OutputDirectoryBrowseBtn.Location = new System.Drawing.Point(407, 118);
            this.GP4OutputDirectoryBrowseBtn.Name = "GP4OutputDirectoryBrowseBtn";
            this.GP4OutputDirectoryBrowseBtn.Size = new System.Drawing.Size(57, 19);
            this.GP4OutputDirectoryBrowseBtn.TabIndex = 75;
            this.GP4OutputDirectoryBrowseBtn.Text = "Browse";
            this.GP4OutputDirectoryBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GP4OutputDirectoryBrowseBtn.UseVisualStyleBackColor = false;
            this.GP4OutputDirectoryBrowseBtn.Variable = null;
            this.GP4OutputDirectoryBrowseBtn.Click += new System.EventHandler(this.GP4OutputDirectoryBrowseBtn_Click);
            // 
            // GamedataPathBox
            // 
            this.GamedataPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GamedataPathBox.Font = new System.Drawing.Font("Cambria", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.GamedataPathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GamedataPathBox.Location = new System.Drawing.Point(7, 58);
            this.GamedataPathBox.Name = "GamedataPathBox";
            this.GamedataPathBox.Size = new System.Drawing.Size(395, 23);
            this.GamedataPathBox.TabIndex = 65;
            this.GamedataPathBox.Text = "No Gamedata Folder Path Chosen";
            this.GamedataPathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GamedataPathBrowseBtn
            // 
            this.GamedataPathBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GamedataPathBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GamedataPathBrowseBtn.FlatAppearance.BorderSize = 0;
            this.GamedataPathBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GamedataPathBrowseBtn.Font = new System.Drawing.Font("Verdana", 8F);
            this.GamedataPathBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.GamedataPathBrowseBtn.Location = new System.Drawing.Point(407, 59);
            this.GamedataPathBrowseBtn.Name = "GamedataPathBrowseBtn";
            this.GamedataPathBrowseBtn.Size = new System.Drawing.Size(57, 19);
            this.GamedataPathBrowseBtn.TabIndex = 69;
            this.GamedataPathBrowseBtn.Text = "Browse";
            this.GamedataPathBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GamedataPathBrowseBtn.UseVisualStyleBackColor = false;
            this.GamedataPathBrowseBtn.Variable = null;
            this.GamedataPathBrowseBtn.Click += new System.EventHandler(this.GamedataPathBrowseBtn_Click);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 397);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(162, 23);
            this.InfoHelpBtn.TabIndex = 15;
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
            this.BackBtn.Location = new System.Drawing.Point(1, 447);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(58, 23);
            this.BackBtn.TabIndex = 13;
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
            this.CreditsBtn.Location = new System.Drawing.Point(1, 422);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(68, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Variable = null;
            // 
            // GP4CreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(467, 498);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.GP4CreationBtn);
            this.Controls.Add(this.IgnoreKeystoneBtn);
            this.Controls.Add(this.AbsoluteFilePathsBtn);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.BaseGamePackagePathLabel);
            this.Controls.Add(this.BaseGamePackagePathBox);
            this.Controls.Add(this.BaseGamePackageBrowseBtn);
            this.Controls.Add(this.PasscodeLabel);
            this.Controls.Add(this.PasscodePathBox);
            this.Controls.Add(this.FileBlacklistPathLabel);
            this.Controls.Add(this.FileBlacklistPathBox);
            this.Controls.Add(this.FileBlacklistBrowseBtn);
            this.Controls.Add(this.GP4OutputPathLabel);
            this.Controls.Add(this.GP4OutputDirectoryPathBox);
            this.Controls.Add(this.GP4OutputDirectoryBrowseBtn);
            this.Controls.Add(this.GamedataPathLabel);
            this.Controls.Add(this.GamedataPathBox);
            this.Controls.Add(this.GamedataPathBrowseBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.SeperatorLine4);
            this.Controls.Add(this.SeperatorLine0);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GP4CreationPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        
        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        private Label MainLabel;
        private Label SeperatorLine0;
        private Label SeperatorLine1;
        private Label SeperatorLine2;
        private Label SeperatorLine3;
        private Label SeperatorLine4;
        private Label GamedataPathLabel;
        private TextBox GamedataPathBox;
        private Button GamedataPathBrowseBtn;
        private Button GP4OutputDirectoryBrowseBtn;
        private TextBox GP4OutputDirectoryPathBox;
        private Label GP4OutputPathLabel;
        private Label PasscodeLabel;
        private TextBox PasscodePathBox;
        private Button GP4CreationBtn;
        private Button AbsoluteFilePathsBtn;
        private Label FileBlacklistPathLabel;
        private TextBox FileBlacklistPathBox;
        private Button FileBlacklistBrowseBtn;
        private Label BaseGamePackagePathLabel;
        private TextBox BaseGamePackagePathBox;
        private Button BaseGamePackageBrowseBtn;
        private Button IgnoreKeystoneBtn;
        private Button InfoHelpBtn;
        private Button CreditsBtn;
        private Button BackBtn;
        private Label Info;
        #endregion
    }
}
