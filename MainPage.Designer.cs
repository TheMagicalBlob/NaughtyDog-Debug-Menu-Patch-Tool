using System.Windows.Forms;

namespace Dobby
{
    internal partial class MainPage
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

        public void InitializeComponent() {
            this.MainLabel = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.Playstation4Label = new System.Windows.Forms.Label();
            this.PCLabel = new System.Windows.Forms.Label();
            this.DownloadSourceBtn = new Dobby.Button();
            this.InfoHelpBtn = new Dobby.Button();
            this.CreditsBtn = new Dobby.Button();
            this.PCDebugMenuPageBtn = new Dobby.Button();
            this.PkgCreationPageBtn = new Dobby.Button();
            this.PS4DebugPageBtn = new Dobby.Button();
            this.EbootPatchPageBtn = new Dobby.Button();
            this.PS4MenuSettingsPageBtn = new Dobby.Button();
            this.SuspendLayout();
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
            this.MainLabel.Text = "Naughty Dog Debug Tool";
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(7, 286);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=====================================";
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine0.TabIndex = 31;
            this.SeperatorLine0.Text = "--------------------------------------------------------------";
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 194);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine3.TabIndex = 32;
            this.SeperatorLine3.Text = "--------------------------------------------------------------";
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 144);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine1.TabIndex = 36;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // Playstation4Label
            // 
            this.Playstation4Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Playstation4Label.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.Playstation4Label.ForeColor = System.Drawing.SystemColors.Control;
            this.Playstation4Label.Location = new System.Drawing.Point(119, 30);
            this.Playstation4Label.Name = "Playstation4Label";
            this.Playstation4Label.Size = new System.Drawing.Size(73, 15);
            this.Playstation4Label.TabIndex = 36;
            this.Playstation4Label.Text = "Playstation 4";
            // 
            // PCLabel
            // 
            this.PCLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.PCLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PCLabel.Location = new System.Drawing.Point(146, 158);
            this.PCLabel.Name = "PCLabel";
            this.PCLabel.Size = new System.Drawing.Size(20, 15);
            this.PCLabel.TabIndex = 37;
            this.PCLabel.Text = "PC";
            // 
            // DownloadSourceBtn
            // 
            this.DownloadSourceBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.DownloadSourceBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DownloadSourceBtn.FlatAppearance.BorderSize = 0;
            this.DownloadSourceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadSourceBtn.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.DownloadSourceBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DownloadSourceBtn.Location = new System.Drawing.Point(1, 258);
            this.DownloadSourceBtn.Name = "DownloadSourceBtn";
            this.DownloadSourceBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DownloadSourceBtn.Size = new System.Drawing.Size(275, 23);
            this.DownloadSourceBtn.TabIndex = 30;
            this.DownloadSourceBtn.Text = "Download Latest Source Code (Download Link)";
            this.DownloadSourceBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DownloadSourceBtn.UseVisualStyleBackColor = false;
            this.DownloadSourceBtn.Variable = null;
            this.DownloadSourceBtn.Click += new System.EventHandler(this.DownloadSourceBtn_Click);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 210);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InfoHelpBtn.Size = new System.Drawing.Size(139, 23);
            this.InfoHelpBtn.TabIndex = 29;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Variable = null;
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 233);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(68, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Variable = null;
            // 
            // PCDebugMenuPageBtn
            // 
            this.PCDebugMenuPageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PCDebugMenuPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PCDebugMenuPageBtn.FlatAppearance.BorderSize = 0;
            this.PCDebugMenuPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PCDebugMenuPageBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.PCDebugMenuPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PCDebugMenuPageBtn.Location = new System.Drawing.Point(1, 177);
            this.PCDebugMenuPageBtn.Name = "PCDebugMenuPageBtn";
            this.PCDebugMenuPageBtn.Size = new System.Drawing.Size(240, 23);
            this.PCDebugMenuPageBtn.TabIndex = 37;
            this.PCDebugMenuPageBtn.Text = "Patch .exe With The Debug Menu...";
            this.PCDebugMenuPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PCDebugMenuPageBtn.UseVisualStyleBackColor = false;
            this.PCDebugMenuPageBtn.Variable = null;
            this.PCDebugMenuPageBtn.Click += new System.EventHandler(this.PCDebugMenuPageBtn_Click);
            // 
            // PkgCreationPageBtn
            // 
            this.PkgCreationPageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PkgCreationPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PkgCreationPageBtn.FlatAppearance.BorderSize = 0;
            this.PkgCreationPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PkgCreationPageBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.PkgCreationPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PkgCreationPageBtn.Location = new System.Drawing.Point(1, 127);
            this.PkgCreationPageBtn.Name = "PkgCreationPageBtn";
            this.PkgCreationPageBtn.Size = new System.Drawing.Size(260, 23);
            this.PkgCreationPageBtn.TabIndex = 35;
            this.PkgCreationPageBtn.Tag = "Build a .pkg with the edited .elf";
            this.PkgCreationPageBtn.Text = "Build New Patch Or Base Game .pkg...";
            this.PkgCreationPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PkgCreationPageBtn.UseVisualStyleBackColor = false;
            this.PkgCreationPageBtn.Variable = null;
            this.PkgCreationPageBtn.Click += new System.EventHandler(this.PkgPageBtn_Click);
            // 
            // PS4DebugPageBtn
            // 
            this.PS4DebugPageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PS4DebugPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PS4DebugPageBtn.FlatAppearance.BorderSize = 0;
            this.PS4DebugPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PS4DebugPageBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.PS4DebugPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PS4DebugPageBtn.Location = new System.Drawing.Point(1, 51);
            this.PS4DebugPageBtn.Name = "PS4DebugPageBtn";
            this.PS4DebugPageBtn.Size = new System.Drawing.Size(262, 23);
            this.PS4DebugPageBtn.TabIndex = 20;
            this.PS4DebugPageBtn.Tag = "Enable the debug mode via memory editing";
            this.PS4DebugPageBtn.Text = "Enable Debug Mode With PS4Debug...";
            this.PS4DebugPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PS4DebugPageBtn.UseVisualStyleBackColor = false;
            this.PS4DebugPageBtn.Variable = null;
            this.PS4DebugPageBtn.Click += new System.EventHandler(this.PS4DebugPageBtn_Click);
            // 
            // EbootPatchPageBtn
            // 
            this.EbootPatchPageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.EbootPatchPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.EbootPatchPageBtn.FlatAppearance.BorderSize = 0;
            this.EbootPatchPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EbootPatchPageBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.EbootPatchPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.EbootPatchPageBtn.Location = new System.Drawing.Point(1, 76);
            this.EbootPatchPageBtn.Name = "EbootPatchPageBtn";
            this.EbootPatchPageBtn.Size = new System.Drawing.Size(275, 23);
            this.EbootPatchPageBtn.TabIndex = 25;
            this.EbootPatchPageBtn.Tag = "Apply patches locally to a provided .elf/.bin";
            this.EbootPatchPageBtn.Text = "Patch eboot.bin With The Debug Menu...";
            this.EbootPatchPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EbootPatchPageBtn.UseVisualStyleBackColor = false;
            this.EbootPatchPageBtn.Variable = null;
            this.EbootPatchPageBtn.Click += new System.EventHandler(this.EbootPatchPageBtn_Click);
            // 
            // PS4MenuSettingsPageBtn
            // 
            this.PS4MenuSettingsPageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PS4MenuSettingsPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PS4MenuSettingsPageBtn.FlatAppearance.BorderSize = 0;
            this.PS4MenuSettingsPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PS4MenuSettingsPageBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.PS4MenuSettingsPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PS4MenuSettingsPageBtn.Location = new System.Drawing.Point(1, 102);
            this.PS4MenuSettingsPageBtn.Name = "PS4MenuSettingsPageBtn";
            this.PS4MenuSettingsPageBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PS4MenuSettingsPageBtn.Size = new System.Drawing.Size(223, 23);
            this.PS4MenuSettingsPageBtn.TabIndex = 27;
            this.PS4MenuSettingsPageBtn.Tag = "Patch a .elf with user-selected menu settings";
            this.PS4MenuSettingsPageBtn.Text = "Apply Misc. Debug Menu Settings...";
            this.PS4MenuSettingsPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PS4MenuSettingsPageBtn.UseVisualStyleBackColor = false;
            this.PS4MenuSettingsPageBtn.Variable = null;
            this.PS4MenuSettingsPageBtn.Click += new System.EventHandler(this.PS4MenuSettingsPageBtn_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(319, 307);
            this.Controls.Add(this.DownloadSourceBtn);
            this.Controls.Add(this.PCLabel);
            this.Controls.Add(this.Playstation4Label);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.PCDebugMenuPageBtn);
            this.Controls.Add(this.PkgCreationPageBtn);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.PS4DebugPageBtn);
            this.Controls.Add(this.EbootPatchPageBtn);
            this.Controls.Add(this.PS4MenuSettingsPageBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine0);
            this.Controls.Add(this.SeperatorLine3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPage";
            this.ResumeLayout(false);

        }
        #endregion


        
        

        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        public Label MainLabel;
        public Button PS4DebugPageBtn;
        public Button EbootPatchPageBtn;
        public Button PS4MenuSettingsPageBtn;
        public Label Info;
        public Label SeperatorLine0;
        public Label SeperatorLine3;
        public Button PkgCreationPageBtn;
        public Label SeperatorLine1;
        public Button PCDebugMenuPageBtn;
        public Button CreditsBtn;
        public Button InfoHelpBtn;
        public Label Playstation4Label;
        public Label PCLabel;
        public Button DownloadSourceBtn;
        #endregion
    }
}
