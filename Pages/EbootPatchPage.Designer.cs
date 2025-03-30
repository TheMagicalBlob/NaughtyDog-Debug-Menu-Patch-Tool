using System.Windows.Forms;

namespace Dobby
{
    public partial class EbootPatchPage
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
            Common.fileStream?.Dispose();
            Common.Game = Common.GameID.Empty;
            base.Dispose(disposing);
        }

        public void InitializeComponent() {
            this.GameInfoLabel = new System.Windows.Forms.Label();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.MainLabel = new System.Windows.Forms.Label();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.BrowseButton = new Dobby.Button();
            this.ExecutablePathBox = new Dobby.TextBox();
            this.RestoredDebugBtn = new Dobby.Button();
            this.InfoHelpBtn = new Dobby.Button();
            this.BackBtn = new Dobby.Button();
            this.DisableDebugBtn = new Dobby.Button();
            this.CreditsBtn = new Dobby.Button();
            this.EnableDebugBtn = new Dobby.Button();
            this.SuspendLayout();
            // 
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new System.Drawing.Font("Cambria", 10F);
            this.GameInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GameInfoLabel.Location = new System.Drawing.Point(1, 142);
            this.GameInfoLabel.Name = "GameInfoLabel";
            this.GameInfoLabel.Size = new System.Drawing.Size(316, 19);
            this.GameInfoLabel.TabIndex = 32;
            this.GameInfoLabel.Text = "No File Selected";
            this.GameInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 98);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine1.TabIndex = 29;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 155);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine2.TabIndex = 14;
            this.SeperatorLine2.Text = "--------------------------------------------------------------";
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(3, 240);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(313, 19);
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
            this.MainLabel.Text = "Eboot Patch Page";
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
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BrowseButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Cambria", 8.5F, System.Drawing.FontStyle.Bold);
            this.BrowseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BrowseButton.Location = new System.Drawing.Point(238, 116);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(67, 19);
            this.BrowseButton.TabIndex = 31;
            this.BrowseButton.Tag = "Search for a decrypted/unsigned eboot.bin to patch";
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Variable = null;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ExecutablePathBox
            // 
            this.ExecutablePathBox.BackColor = System.Drawing.Color.Gray;
            this.ExecutablePathBox.Font = new System.Drawing.Font("Cambria", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ExecutablePathBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ExecutablePathBox.Location = new System.Drawing.Point(6, 116);
            this.ExecutablePathBox.Name = "ExecutablePathBox";
            this.ExecutablePathBox.Size = new System.Drawing.Size(233, 23);
            this.ExecutablePathBox.TabIndex = 30;
            this.ExecutablePathBox.Text = " Select A .bin/.elf To Modify";
            this.ExecutablePathBox.TextChanged += new System.EventHandler(this.ExecutablePathBox_TextChanged);
            // 
            // RestoredDebugBtn
            // 
            this.RestoredDebugBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.RestoredDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.RestoredDebugBtn.FlatAppearance.BorderSize = 0;
            this.RestoredDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestoredDebugBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.RestoredDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.RestoredDebugBtn.Location = new System.Drawing.Point(1, 80);
            this.RestoredDebugBtn.Name = "RestoredDebugBtn";
            this.RestoredDebugBtn.Size = new System.Drawing.Size(283, 23);
            this.RestoredDebugBtn.TabIndex = 23;
            this.RestoredDebugBtn.Tag = "Enable the debug menu, and appy various patches to it";
            this.RestoredDebugBtn.Text = "Enable Debug Mode - Restored/Custom";
            this.RestoredDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RestoredDebugBtn.UseVisualStyleBackColor = false;
            this.RestoredDebugBtn.Variable = null;
            this.RestoredDebugBtn.Click += new System.EventHandler(this.RestoredDebugBtn_Click);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 168);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(147, 23);
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
            this.BackBtn.Location = new System.Drawing.Point(1, 215);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Variable = null;
            // 
            // DisableDebugBtn
            // 
            this.DisableDebugBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.DisableDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisableDebugBtn.FlatAppearance.BorderSize = 0;
            this.DisableDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisableDebugBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.DisableDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DisableDebugBtn.Location = new System.Drawing.Point(1, 28);
            this.DisableDebugBtn.Name = "DisableDebugBtn";
            this.DisableDebugBtn.Size = new System.Drawing.Size(150, 23);
            this.DisableDebugBtn.TabIndex = 12;
            this.DisableDebugBtn.Tag = "Disable the debug menu (Does not remove other patches)";
            this.DisableDebugBtn.Text = "Disable Debug Mode";
            this.DisableDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisableDebugBtn.UseVisualStyleBackColor = false;
            this.DisableDebugBtn.Variable = null;
            this.DisableDebugBtn.Click += new System.EventHandler(this.DisableDebugBtn_Click);
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 191);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(74, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Variable = null;
            // 
            // EnableDebugBtn
            // 
            this.EnableDebugBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.EnableDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.EnableDebugBtn.FlatAppearance.BorderSize = 0;
            this.EnableDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnableDebugBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.EnableDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.EnableDebugBtn.Location = new System.Drawing.Point(1, 53);
            this.EnableDebugBtn.Name = "EnableDebugBtn";
            this.EnableDebugBtn.Size = new System.Drawing.Size(205, 23);
            this.EnableDebugBtn.TabIndex = 9;
            this.EnableDebugBtn.Tag = "Enable the debug menu without editing anything";
            this.EnableDebugBtn.Text = "Enable Debug Mode - Default";
            this.EnableDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EnableDebugBtn.UseVisualStyleBackColor = false;
            this.EnableDebugBtn.Variable = null;
            this.EnableDebugBtn.Click += new System.EventHandler(this.EnableDebugBtn_Click);
            // 
            // EbootPatchPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 264);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.GameInfoLabel);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.ExecutablePathBox);
            this.Controls.Add(this.RestoredDebugBtn);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.DisableDebugBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.EnableDebugBtn);
            this.Controls.Add(this.SeperatorLine0);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EbootPatchPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        
        
        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        public Label GameInfoLabel;
        private Button BrowseButton;
        private TextBox ExecutablePathBox;
        private Label SeperatorLine1;
        private Button RestoredDebugBtn;
        private Button InfoHelpBtn;
        private Label SeperatorLine2;
        private Button BackBtn;
        private Button DisableDebugBtn;
        private Button EnableDebugBtn;
        private Label Info;
        private Button CreditsBtn;
        private Label MainLabel;
        private Label SeperatorLine0;
        #endregion
    }
}
