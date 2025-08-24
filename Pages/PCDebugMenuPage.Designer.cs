using System.Windows.Forms;

namespace Dobby
{
    internal partial class PCDebugMenuPage
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

            DebugScanThread?.Abort();
            Common.fileStream?.Dispose();
            Common.Game = Common.GameID.Empty;

            base.Dispose(disposing);
        }

        public void InitializeComponent()
        {
            this.MainLabel = new Dobby.Label();
            this.Info = new Dobby.Label();
            this.separatorLine0 = new Dobby.Label();
            this.separatorLine2 = new Dobby.Label();
            this.GameInfoLabel = new Dobby.Label();
            this.separatorLine1 = new Dobby.Label();
            this.separatorLine3 = new Dobby.Label();
            this.DisableFPSBtn = new Dobby.Button();
            this.BaseDebugBtn = new Dobby.Button();
            this.DisableDebugBtn = new Dobby.Button();
            this.BackBtn = new Dobby.Button();
            this.BrowseButton = new Dobby.Button();
            this.ExecutablePathBox = new Dobby.TextBox();
            this.InfoHelpBtn = new Dobby.Button();
            this.CreditsBtn = new Dobby.Button();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.IsSeparatorLine = false;
            this.MainLabel.Location = new System.Drawing.Point(1, 1);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(314, 22);
            this.MainLabel.StretchToFitForm = false;
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "PC Debug Menu Page";
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 9.25F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.IsSeparatorLine = false;
            this.Info.Location = new System.Drawing.Point(4, 254);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(312, 17);
            this.Info.StretchToFitForm = false;
            this.Info.TabIndex = 7;
            this.Info.Text = "===========================================";
            // 
            // separatorLine0
            // 
            this.separatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.separatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.separatorLine0.IsSeparatorLine = true;
            this.separatorLine0.Location = new System.Drawing.Point(2, 15);
            this.separatorLine0.Name = "separatorLine0";
            this.separatorLine0.Size = new System.Drawing.Size(316, 15);
            this.separatorLine0.StretchToFitForm = false;
            this.separatorLine0.TabIndex = 31;
            this.separatorLine0.Text = "--------------------------------------------------------------";
            // 
            // separatorLine2
            // 
            this.separatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.separatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.separatorLine2.IsSeparatorLine = true;
            this.separatorLine2.Location = new System.Drawing.Point(3, 130);
            this.separatorLine2.Name = "separatorLine2";
            this.separatorLine2.Size = new System.Drawing.Size(316, 15);
            this.separatorLine2.StretchToFitForm = false;
            this.separatorLine2.TabIndex = 32;
            this.separatorLine2.Text = "--------------------------------------------------------------";
            // 
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new System.Drawing.Font("Cambria", 9.25F);
            this.GameInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GameInfoLabel.IsSeparatorLine = false;
            this.GameInfoLabel.Location = new System.Drawing.Point(2, 116);
            this.GameInfoLabel.Name = "GameInfoLabel";
            this.GameInfoLabel.Size = new System.Drawing.Size(316, 19);
            this.GameInfoLabel.StretchToFitForm = false;
            this.GameInfoLabel.TabIndex = 40;
            this.GameInfoLabel.Text = "No File Selected";
            this.GameInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // separatorLine1
            // 
            this.separatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.separatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.separatorLine1.IsSeparatorLine = true;
            this.separatorLine1.Location = new System.Drawing.Point(2, 71);
            this.separatorLine1.Name = "separatorLine1";
            this.separatorLine1.Size = new System.Drawing.Size(316, 15);
            this.separatorLine1.StretchToFitForm = false;
            this.separatorLine1.TabIndex = 36;
            this.separatorLine1.Text = "--------------------------------------------------------------";
            // 
            // separatorLine3
            // 
            this.separatorLine3.Font = new System.Drawing.Font("Cambria", 10F);
            this.separatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.separatorLine3.IsSeparatorLine = true;
            this.separatorLine3.Location = new System.Drawing.Point(2, 162);
            this.separatorLine3.Name = "separatorLine3";
            this.separatorLine3.Size = new System.Drawing.Size(316, 15);
            this.separatorLine3.StretchToFitForm = false;
            this.separatorLine3.TabIndex = 42;
            this.separatorLine3.Text = "--------------------------------------------------------------";
            // 
            // DisableFPSBtn
            // 
            this.DisableFPSBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.DisableFPSBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisableFPSBtn.FlatAppearance.BorderSize = 0;
            this.DisableFPSBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisableFPSBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.DisableFPSBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DisableFPSBtn.Location = new System.Drawing.Point(1, 144);
            this.DisableFPSBtn.Name = "DisableFPSBtn";
            this.DisableFPSBtn.Size = new System.Drawing.Size(195, 23);
            this.DisableFPSBtn.TabIndex = 43;
            this.DisableFPSBtn.Tag = "Disable the FPS and build-related debug text ";
            this.DisableFPSBtn.Text = "Disable Performance Stats: ";
            this.DisableFPSBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisableFPSBtn.UseVisualStyleBackColor = false;
            this.DisableFPSBtn.Variable = false;
            // 
            // BaseDebugBtn
            // 
            this.BaseDebugBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BaseDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BaseDebugBtn.FlatAppearance.BorderSize = 0;
            this.BaseDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaseDebugBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.BaseDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BaseDebugBtn.Location = new System.Drawing.Point(1, 53);
            this.BaseDebugBtn.Name = "BaseDebugBtn";
            this.BaseDebugBtn.Size = new System.Drawing.Size(158, 23);
            this.BaseDebugBtn.TabIndex = 20;
            this.BaseDebugBtn.Tag = "Enable the unedited debug mode/menus";
            this.BaseDebugBtn.Text = "Enable the Debug Mode";
            this.BaseDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BaseDebugBtn.UseVisualStyleBackColor = false;
            this.BaseDebugBtn.Variable = null;
            this.BaseDebugBtn.Click += new System.EventHandler(this.BaseDebugBtn_Click);
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
            this.DisableDebugBtn.Size = new System.Drawing.Size(161, 23);
            this.DisableDebugBtn.TabIndex = 38;
            this.DisableDebugBtn.Tag = "Disable the debug mode/menus";
            this.DisableDebugBtn.Text = "Disable the Debug Mode";
            this.DisableDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisableDebugBtn.UseVisualStyleBackColor = false;
            this.DisableDebugBtn.Variable = null;
            this.DisableDebugBtn.Click += new System.EventHandler(this.DisableDebugBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 226);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 41;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Variable = null;
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BrowseButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Cambria", 8.5F, System.Drawing.FontStyle.Bold);
            this.BrowseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BrowseButton.Location = new System.Drawing.Point(239, 88);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(67, 19);
            this.BrowseButton.TabIndex = 39;
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
            this.ExecutablePathBox.Location = new System.Drawing.Point(7, 88);
            this.ExecutablePathBox.Name = "ExecutablePathBox";
            this.ExecutablePathBox.Size = new System.Drawing.Size(233, 23);
            this.ExecutablePathBox.TabIndex = 38;
            this.ExecutablePathBox.Text = " Select An exe To Modify";
            this.ExecutablePathBox.TextChanged += new System.EventHandler(this.ExecutablePathBox_TextChanged);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 176);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InfoHelpBtn.Size = new System.Drawing.Size(147, 23);
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
            this.CreditsBtn.Location = new System.Drawing.Point(1, 201);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(75, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Variable = null;
            // 
            // PCDebugMenuPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 275);
            this.Controls.Add(this.DisableFPSBtn);
            this.Controls.Add(this.separatorLine3);
            this.Controls.Add(this.GameInfoLabel);
            this.Controls.Add(this.separatorLine2);
            this.Controls.Add(this.BaseDebugBtn);
            this.Controls.Add(this.DisableDebugBtn);
            this.Controls.Add(this.separatorLine1);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.separatorLine0);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.ExecutablePathBox);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.CreditsBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PCDebugMenuPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        

        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]

        public Label MainLabel;
        public Button CreditsBtn;
        public Button InfoHelpBtn;
        public Label Info;
        public Label separatorLine0;
        public Label separatorLine2;
        public Label separatorLine1;
        public Label GameInfoLabel;
        private Button BrowseButton;
        private TextBox ExecutablePathBox;
        public Button BackBtn;
        public Button DisableDebugBtn;
        public Button BaseDebugBtn;
        public Label separatorLine3;
        private Button DisableFPSBtn;
        #endregion
    }
}
