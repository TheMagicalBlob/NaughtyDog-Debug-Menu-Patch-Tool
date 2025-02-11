
namespace Dobby
{
    internal partial class Gp4CreationPage
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
            this.Info = new System.Windows.Forms.Label();
            this.MainLabel = new System.Windows.Forms.Label();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.SeperatorLine4 = new System.Windows.Forms.Label();
            this.GamedataPathLabel = new System.Windows.Forms.Label();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.Gp4OutputPathLabel = new System.Windows.Forms.Label();
            this.PasscodeLabel = new System.Windows.Forms.Label();
            this.FileBlacklistPathLabel = new System.Windows.Forms.Label();
            this.BaseGamePackagePathLabel = new System.Windows.Forms.Label();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.IgnoreKeystoneBtn = new Dobby.Button();
            this.AbsoluteFilePathsBtn = new Dobby.Button();
            this.BaseGamePackagePathTextBox = new Dobby.TextBox();
            this.BaseGamePackageBrowseBtn = new Dobby.Button();
            this.PasscodeTextBox = new Dobby.TextBox();
            this.FileBlacklistTextBox = new Dobby.TextBox();
            this.FileBlacklistBrowseBtn = new Dobby.Button();
            this.Gp4OutputDirectoryTextBox = new Dobby.TextBox();
            this.Gp4OutputDirectoryBrowseBtn = new Dobby.Button();
            this.GamedataPathTextBox = new Dobby.TextBox();
            this.GamedataPathBrowseBtn = new Dobby.Button();
            this.StartGp4CreationBtn = new Dobby.Button();
            this.InfoHelpBtn = new Dobby.Button();
            this.BackBtn = new Dobby.Button();
            this.CreditsBtn = new Dobby.Button();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(6, 451);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(395, 19);
            this.Info.TabIndex = 7;
            this.Info.Text = "======================================";
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
            // SeperatorLine4
            // 
            this.SeperatorLine4.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine4.Location = new System.Drawing.Point(2, 368);
            this.SeperatorLine4.Name = "SeperatorLine4";
            this.SeperatorLine4.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine4.TabIndex = 29;
            this.SeperatorLine4.Text = "--------------------------------------------------------------";
            // 
            // GamedataPathLabel
            // 
            this.GamedataPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GamedataPathLabel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.GamedataPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.GamedataPathLabel.Location = new System.Drawing.Point(4, 64);
            this.GamedataPathLabel.Name = "GamedataPathLabel";
            this.GamedataPathLabel.Size = new System.Drawing.Size(342, 15);
            this.GamedataPathLabel.TabIndex = 73;
            this.GamedataPathLabel.Text = "Application/Patch Data Path:";
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 48);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(391, 15);
            this.SeperatorLine1.TabIndex = 64;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // Gp4OutputPathLabel
            // 
            this.Gp4OutputPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Gp4OutputPathLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.Gp4OutputPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.Gp4OutputPathLabel.Location = new System.Drawing.Point(4, 121);
            this.Gp4OutputPathLabel.Name = "Gp4OutputPathLabel";
            this.Gp4OutputPathLabel.Size = new System.Drawing.Size(342, 15);
            this.Gp4OutputPathLabel.TabIndex = 76;
            this.Gp4OutputPathLabel.Text = ".gp4 Project Output Directory:";
            // 
            // PasscodeLabel
            // 
            this.PasscodeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasscodeLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.PasscodeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PasscodeLabel.Location = new System.Drawing.Point(4, 256);
            this.PasscodeLabel.Name = "PasscodeLabel";
            this.PasscodeLabel.Size = new System.Drawing.Size(342, 15);
            this.PasscodeLabel.TabIndex = 82;
            this.PasscodeLabel.Text = "Package Passcode:";
            // 
            // FileBlacklistPathLabel
            // 
            this.FileBlacklistPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileBlacklistPathLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.FileBlacklistPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.FileBlacklistPathLabel.Location = new System.Drawing.Point(4, 211);
            this.FileBlacklistPathLabel.Name = "FileBlacklistPathLabel";
            this.FileBlacklistPathLabel.Size = new System.Drawing.Size(342, 15);
            this.FileBlacklistPathLabel.TabIndex = 79;
            this.FileBlacklistPathLabel.Text = "File/Folder Blacklist:";
            // 
            // BaseGamePackagePathLabel
            // 
            this.BaseGamePackagePathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BaseGamePackagePathLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.BaseGamePackagePathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.BaseGamePackagePathLabel.Location = new System.Drawing.Point(4, 166);
            this.BaseGamePackagePathLabel.Name = "BaseGamePackagePathLabel";
            this.BaseGamePackagePathLabel.Size = new System.Drawing.Size(342, 15);
            this.BaseGamePackagePathLabel.TabIndex = 85;
            this.BaseGamePackagePathLabel.Text = "Base Game Package Directory:                               (patches/updates only)" +
    "";
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 104);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(391, 15);
            this.SeperatorLine2.TabIndex = 86;
            this.SeperatorLine2.Text = "--------------------------------------------------------------";
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 300);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine3.TabIndex = 87;
            this.SeperatorLine3.Text = "--------------------------------------------------------------";
            // 
            // IgnoreKeystoneBtn
            // 
            this.IgnoreKeystoneBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.IgnoreKeystoneBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.IgnoreKeystoneBtn.FlatAppearance.BorderSize = 0;
            this.IgnoreKeystoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IgnoreKeystoneBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.IgnoreKeystoneBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.IgnoreKeystoneBtn.Location = new System.Drawing.Point(3, 343);
            this.IgnoreKeystoneBtn.Name = "IgnoreKeystoneBtn";
            this.IgnoreKeystoneBtn.Size = new System.Drawing.Size(225, 23);
            this.IgnoreKeystoneBtn.TabIndex = 89;
            this.IgnoreKeystoneBtn.Text = "Ignore Keystone: ";
            this.IgnoreKeystoneBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IgnoreKeystoneBtn.UseVisualStyleBackColor = false;
            this.IgnoreKeystoneBtn.Variable = null;
            this.IgnoreKeystoneBtn.Click += new System.EventHandler(this.IgnoreKeystoneBtn_Click);
            // 
            // AbsoluteFilePathsBtn
            // 
            this.AbsoluteFilePathsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.AbsoluteFilePathsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.AbsoluteFilePathsBtn.FlatAppearance.BorderSize = 0;
            this.AbsoluteFilePathsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AbsoluteFilePathsBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.AbsoluteFilePathsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.AbsoluteFilePathsBtn.Location = new System.Drawing.Point(3, 318);
            this.AbsoluteFilePathsBtn.Name = "AbsoluteFilePathsBtn";
            this.AbsoluteFilePathsBtn.Size = new System.Drawing.Size(225, 23);
            this.AbsoluteFilePathsBtn.TabIndex = 88;
            this.AbsoluteFilePathsBtn.Text = "Use Absolute File Paths: ";
            this.AbsoluteFilePathsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AbsoluteFilePathsBtn.UseVisualStyleBackColor = false;
            this.AbsoluteFilePathsBtn.Variable = null;
            this.AbsoluteFilePathsBtn.Click += new System.EventHandler(this.AbsoluteFilePathsBtn_Click);
            // 
            // BaseGamePackagePathTextBox
            // 
            this.BaseGamePackagePathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BaseGamePackagePathTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
            this.BaseGamePackagePathTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.BaseGamePackagePathTextBox.Location = new System.Drawing.Point(11, 184);
            this.BaseGamePackagePathTextBox.MaxLength = 32;
            this.BaseGamePackagePathTextBox.Name = "BaseGamePackagePathTextBox";
            this.BaseGamePackagePathTextBox.Size = new System.Drawing.Size(335, 21);
            this.BaseGamePackagePathTextBox.TabIndex = 83;
            this.BaseGamePackagePathTextBox.Text = "Base Game Package Path";
            // 
            // BaseGamePackageBrowseBtn
            // 
            this.BaseGamePackageBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BaseGamePackageBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BaseGamePackageBrowseBtn.FlatAppearance.BorderSize = 0;
            this.BaseGamePackageBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaseGamePackageBrowseBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.BaseGamePackageBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BaseGamePackageBrowseBtn.Location = new System.Drawing.Point(350, 184);
            this.BaseGamePackageBrowseBtn.Name = "BaseGamePackageBrowseBtn";
            this.BaseGamePackageBrowseBtn.Size = new System.Drawing.Size(51, 19);
            this.BaseGamePackageBrowseBtn.TabIndex = 84;
            this.BaseGamePackageBrowseBtn.Text = "Browse";
            this.BaseGamePackageBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BaseGamePackageBrowseBtn.UseVisualStyleBackColor = false;
            this.BaseGamePackageBrowseBtn.Variable = null;
            this.BaseGamePackageBrowseBtn.Click += new System.EventHandler(this.BaseGamePackageBrowseBtn_Click);
            // 
            // PasscodeTextBox
            // 
            this.PasscodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PasscodeTextBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.PasscodeTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.PasscodeTextBox.Location = new System.Drawing.Point(11, 274);
            this.PasscodeTextBox.MaxLength = 32;
            this.PasscodeTextBox.Name = "PasscodeTextBox";
            this.PasscodeTextBox.Size = new System.Drawing.Size(335, 23);
            this.PasscodeTextBox.TabIndex = 80;
            this.PasscodeTextBox.Text = "00000000000000000000000000000000000";
            // 
            // FileBlacklistTextBox
            // 
            this.FileBlacklistTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FileBlacklistTextBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.FileBlacklistTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.FileBlacklistTextBox.Location = new System.Drawing.Point(11, 229);
            this.FileBlacklistTextBox.Name = "FileBlacklistTextBox";
            this.FileBlacklistTextBox.Size = new System.Drawing.Size(335, 23);
            this.FileBlacklistTextBox.TabIndex = 77;
            this.FileBlacklistTextBox.Text = "Blacklisted Files/Folders To Exclude, Seperated By ; or ,";
            // 
            // FileBlacklistBrowseBtn
            // 
            this.FileBlacklistBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.FileBlacklistBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.FileBlacklistBrowseBtn.FlatAppearance.BorderSize = 0;
            this.FileBlacklistBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileBlacklistBrowseBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.FileBlacklistBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.FileBlacklistBrowseBtn.Location = new System.Drawing.Point(350, 229);
            this.FileBlacklistBrowseBtn.Name = "FileBlacklistBrowseBtn";
            this.FileBlacklistBrowseBtn.Size = new System.Drawing.Size(51, 19);
            this.FileBlacklistBrowseBtn.TabIndex = 78;
            this.FileBlacklistBrowseBtn.Text = "Browse";
            this.FileBlacklistBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FileBlacklistBrowseBtn.UseVisualStyleBackColor = false;
            this.FileBlacklistBrowseBtn.Variable = null;
            this.FileBlacklistBrowseBtn.Click += new System.EventHandler(this.FileBlacklistBrowseBtn_Click);
            // 
            // Gp4OutputDirectoryTextBox
            // 
            this.Gp4OutputDirectoryTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Gp4OutputDirectoryTextBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.Gp4OutputDirectoryTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Gp4OutputDirectoryTextBox.Location = new System.Drawing.Point(11, 139);
            this.Gp4OutputDirectoryTextBox.Name = "Gp4OutputDirectoryTextBox";
            this.Gp4OutputDirectoryTextBox.Size = new System.Drawing.Size(335, 23);
            this.Gp4OutputDirectoryTextBox.TabIndex = 74;
            this.Gp4OutputDirectoryTextBox.Text = "Using Default Output Directory";
            // 
            // Gp4OutputDirectoryBrowseBtn
            // 
            this.Gp4OutputDirectoryBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Gp4OutputDirectoryBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Gp4OutputDirectoryBrowseBtn.FlatAppearance.BorderSize = 0;
            this.Gp4OutputDirectoryBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gp4OutputDirectoryBrowseBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.Gp4OutputDirectoryBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.Gp4OutputDirectoryBrowseBtn.Location = new System.Drawing.Point(350, 139);
            this.Gp4OutputDirectoryBrowseBtn.Name = "Gp4OutputDirectoryBrowseBtn";
            this.Gp4OutputDirectoryBrowseBtn.Size = new System.Drawing.Size(51, 19);
            this.Gp4OutputDirectoryBrowseBtn.TabIndex = 75;
            this.Gp4OutputDirectoryBrowseBtn.Text = "Browse";
            this.Gp4OutputDirectoryBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Gp4OutputDirectoryBrowseBtn.UseVisualStyleBackColor = false;
            this.Gp4OutputDirectoryBrowseBtn.Variable = null;
            this.Gp4OutputDirectoryBrowseBtn.Click += new System.EventHandler(this.Gp4OutputDirectoryBrowseBtn_Click);
            // 
            // GamedataPathTextBox
            // 
            this.GamedataPathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GamedataPathTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
            this.GamedataPathTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GamedataPathTextBox.Location = new System.Drawing.Point(11, 82);
            this.GamedataPathTextBox.Name = "GamedataPathTextBox";
            this.GamedataPathTextBox.Size = new System.Drawing.Size(335, 21);
            this.GamedataPathTextBox.TabIndex = 65;
            this.GamedataPathTextBox.Text = "Paste Gamedata Folder Path Here (or use the Browse button)";
            // 
            // GamedataPathBrowseBtn
            // 
            this.GamedataPathBrowseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GamedataPathBrowseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GamedataPathBrowseBtn.FlatAppearance.BorderSize = 0;
            this.GamedataPathBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GamedataPathBrowseBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.GamedataPathBrowseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.GamedataPathBrowseBtn.Location = new System.Drawing.Point(350, 82);
            this.GamedataPathBrowseBtn.Name = "GamedataPathBrowseBtn";
            this.GamedataPathBrowseBtn.Size = new System.Drawing.Size(51, 19);
            this.GamedataPathBrowseBtn.TabIndex = 69;
            this.GamedataPathBrowseBtn.Text = "Browse";
            this.GamedataPathBrowseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GamedataPathBrowseBtn.UseVisualStyleBackColor = false;
            this.GamedataPathBrowseBtn.Variable = null;
            this.GamedataPathBrowseBtn.Click += new System.EventHandler(this.GamedataPathBtn_Click);
            // 
            // StartGp4CreationBtn
            // 
            this.StartGp4CreationBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.StartGp4CreationBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.StartGp4CreationBtn.FlatAppearance.BorderSize = 0;
            this.StartGp4CreationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartGp4CreationBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.StartGp4CreationBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.StartGp4CreationBtn.Location = new System.Drawing.Point(3, 29);
            this.StartGp4CreationBtn.Name = "StartGp4CreationBtn";
            this.StartGp4CreationBtn.Size = new System.Drawing.Size(309, 23);
            this.StartGp4CreationBtn.TabIndex = 23;
            this.StartGp4CreationBtn.Text = "Build .gp4 File";
            this.StartGp4CreationBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StartGp4CreationBtn.UseVisualStyleBackColor = false;
            this.StartGp4CreationBtn.Variable = null;
            this.StartGp4CreationBtn.Click += new System.EventHandler(this.StartGp4CreationBtn_Click);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 382);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(403, 23);
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
            this.BackBtn.Location = new System.Drawing.Point(1, 428);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(403, 23);
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
            this.CreditsBtn.Location = new System.Drawing.Point(1, 404);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(403, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Variable = null;
            // 
            // Gp4CreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(405, 474);
            this.Controls.Add(this.IgnoreKeystoneBtn);
            this.Controls.Add(this.AbsoluteFilePathsBtn);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.BaseGamePackagePathLabel);
            this.Controls.Add(this.BaseGamePackagePathTextBox);
            this.Controls.Add(this.BaseGamePackageBrowseBtn);
            this.Controls.Add(this.PasscodeLabel);
            this.Controls.Add(this.PasscodeTextBox);
            this.Controls.Add(this.FileBlacklistPathLabel);
            this.Controls.Add(this.FileBlacklistTextBox);
            this.Controls.Add(this.FileBlacklistBrowseBtn);
            this.Controls.Add(this.Gp4OutputPathLabel);
            this.Controls.Add(this.Gp4OutputDirectoryTextBox);
            this.Controls.Add(this.Gp4OutputDirectoryBrowseBtn);
            this.Controls.Add(this.GamedataPathLabel);
            this.Controls.Add(this.GamedataPathTextBox);
            this.Controls.Add(this.GamedataPathBrowseBtn);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.StartGp4CreationBtn);
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
            this.Name = "Gp4CreationPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
