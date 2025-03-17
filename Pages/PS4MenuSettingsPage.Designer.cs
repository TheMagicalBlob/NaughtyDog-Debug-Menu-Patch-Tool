using System.Windows.Forms;

namespace Dobby
{
    public partial class PS4MenuSettingsPage
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
            fileStream?.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent() {
            this.ProgPauseOnCloseBtn = new Dobby.Button();
            this.ProgPauseOnOpenBtn = new Dobby.Button();
            this.DisableDebugTextBtn = new Dobby.Button();
            this.DisablePausedIconBtn = new Dobby.Button();
            this.MainLabel = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new Dobby.Button();
            this.InfoHelpBtn = new Dobby.Button();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.BackBtn = new Dobby.Button();
            this.CustomDebugOptionsLabel = new System.Windows.Forms.Label();
            this.UniversalPatchesLabel = new System.Windows.Forms.Label();
            this.GameSpecificPatchesLabel = new System.Windows.Forms.Label();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.BrowseButton = new Dobby.Button();
            this.ExecutablePathBox = new Dobby.TextBox();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.GameInfoLabel = new System.Windows.Forms.Label();
            this.NovisBtn = new Dobby.Button();
            this.DebugButtonCycleBtn = new Dobby.Button();
            this.SuspendLayout();
            // 
            // ProgPauseOnCloseBtn
            // 
            this.ProgPauseOnCloseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ProgPauseOnCloseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ProgPauseOnCloseBtn.FlatAppearance.BorderSize = 0;
            this.ProgPauseOnCloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProgPauseOnCloseBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.ProgPauseOnCloseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ProgPauseOnCloseBtn.Location = new System.Drawing.Point(1, 119);
            this.ProgPauseOnCloseBtn.MaximumValue = null;
            this.ProgPauseOnCloseBtn.MinimumValue = null;
            this.ProgPauseOnCloseBtn.Name = "ProgPauseOnCloseBtn";
            this.ProgPauseOnCloseBtn.Size = new System.Drawing.Size(269, 24);
            this.ProgPauseOnCloseBtn.TabIndex = 45;
            this.ProgPauseOnCloseBtn.Text = "Disable Debug Pause On Menu Close: ";
            this.ProgPauseOnCloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProgPauseOnCloseBtn.UseVisualStyleBackColor = false;
            // 
            // ProgPauseOnOpenBtn
            // 
            this.ProgPauseOnOpenBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ProgPauseOnOpenBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ProgPauseOnOpenBtn.FlatAppearance.BorderSize = 0;
            this.ProgPauseOnOpenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProgPauseOnOpenBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.ProgPauseOnOpenBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ProgPauseOnOpenBtn.Location = new System.Drawing.Point(1, 96);
            this.ProgPauseOnOpenBtn.MaximumValue = null;
            this.ProgPauseOnOpenBtn.MinimumValue = null;
            this.ProgPauseOnOpenBtn.Name = "ProgPauseOnOpenBtn";
            this.ProgPauseOnOpenBtn.Size = new System.Drawing.Size(269, 24);
            this.ProgPauseOnOpenBtn.TabIndex = 44;
            this.ProgPauseOnOpenBtn.Text = "Disable Debug Pause On Menu Open: ";
            this.ProgPauseOnOpenBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProgPauseOnOpenBtn.UseVisualStyleBackColor = false;
            // 
            // DisableDebugTextBtn
            // 
            this.DisableDebugTextBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.DisableDebugTextBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisableDebugTextBtn.FlatAppearance.BorderSize = 0;
            this.DisableDebugTextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisableDebugTextBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.DisableDebugTextBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DisableDebugTextBtn.Location = new System.Drawing.Point(1, 52);
            this.DisableDebugTextBtn.MaximumValue = null;
            this.DisableDebugTextBtn.MinimumValue = null;
            this.DisableDebugTextBtn.Name = "DisableDebugTextBtn";
            this.DisableDebugTextBtn.Size = new System.Drawing.Size(251, 24);
            this.DisableDebugTextBtn.TabIndex = 42;
            this.DisableDebugTextBtn.Tag = "Disable the 2D performance  & build stats";
            this.DisableDebugTextBtn.Text = "Disable 2D Debug Text On Startup: ";
            this.DisableDebugTextBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisableDebugTextBtn.UseVisualStyleBackColor = false;
            // 
            // DisablePausedIconBtn
            // 
            this.DisablePausedIconBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.DisablePausedIconBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisablePausedIconBtn.FlatAppearance.BorderSize = 0;
            this.DisablePausedIconBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisablePausedIconBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.DisablePausedIconBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DisablePausedIconBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisablePausedIconBtn.Location = new System.Drawing.Point(1, 74);
            this.DisablePausedIconBtn.MaximumValue = null;
            this.DisablePausedIconBtn.MinimumValue = null;
            this.DisablePausedIconBtn.Name = "DisablePausedIconBtn";
            this.DisablePausedIconBtn.Size = new System.Drawing.Size(205, 24);
            this.DisablePausedIconBtn.TabIndex = 43;
            this.DisablePausedIconBtn.Tag = "Show the flashing PAUSED box on-screen when the debug menu pause is active";
            this.DisablePausedIconBtn.Text = "Show Debug PAUSED Icon:";
            this.DisablePausedIconBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisablePausedIconBtn.UseVisualStyleBackColor = false;
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
            this.MainLabel.Text = "Misc. PS4  Patches Page";
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(8, 360);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=====================================";
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 313);
            this.CreditsBtn.MaximumValue = null;
            this.CreditsBtn.MinimumValue = null;
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(85, 22);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 291);
            this.InfoHelpBtn.MaximumValue = null;
            this.InfoHelpBtn.MinimumValue = null;
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InfoHelpBtn.Size = new System.Drawing.Size(162, 22);
            this.InfoHelpBtn.TabIndex = 29;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
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
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 334);
            this.BackBtn.MaximumValue = null;
            this.BackBtn.MinimumValue = null;
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BackBtn.Size = new System.Drawing.Size(65, 22);
            this.BackBtn.TabIndex = 41;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            // 
            // CustomDebugOptionsLabel
            // 
            this.CustomDebugOptionsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomDebugOptionsLabel.Font = new System.Drawing.Font("Cambria", 8.75F, System.Drawing.FontStyle.Bold);
            this.CustomDebugOptionsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CustomDebugOptionsLabel.Location = new System.Drawing.Point(7, 201);
            this.CustomDebugOptionsLabel.Name = "CustomDebugOptionsLabel";
            this.CustomDebugOptionsLabel.Size = new System.Drawing.Size(303, 19);
            this.CustomDebugOptionsLabel.TabIndex = 54;
            this.CustomDebugOptionsLabel.Text = "(Load An Executable To Show Game-Specific Options)";
            // 
            // UniversalPatchesLabel
            // 
            this.UniversalPatchesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UniversalPatchesLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.UniversalPatchesLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.UniversalPatchesLabel.Location = new System.Drawing.Point(102, 33);
            this.UniversalPatchesLabel.Name = "UniversalPatchesLabel";
            this.UniversalPatchesLabel.Size = new System.Drawing.Size(111, 14);
            this.UniversalPatchesLabel.TabIndex = 53;
            this.UniversalPatchesLabel.Text = "Universal Patches";
            // 
            // GameSpecificPatchesLabel
            // 
            this.GameSpecificPatchesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameSpecificPatchesLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.GameSpecificPatchesLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.GameSpecificPatchesLabel.Location = new System.Drawing.Point(88, 177);
            this.GameSpecificPatchesLabel.Name = "GameSpecificPatchesLabel";
            this.GameSpecificPatchesLabel.Size = new System.Drawing.Size(136, 15);
            this.GameSpecificPatchesLabel.TabIndex = 52;
            this.GameSpecificPatchesLabel.Text = "Game-Specific Patches";
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 274);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine3.TabIndex = 32;
            this.SeperatorLine3.Text = "--------------------------------------------------------------";
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BrowseButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Cambria", 8.5F, System.Drawing.FontStyle.Bold);
            this.BrowseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BrowseButton.Location = new System.Drawing.Point(237, 236);
            this.BrowseButton.MaximumValue = null;
            this.BrowseButton.MinimumValue = null;
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(67, 19);
            this.BrowseButton.TabIndex = 39;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ExecutablePathBox
            // 
            this.ExecutablePathBox.BackColor = System.Drawing.Color.Gray;
            this.ExecutablePathBox.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.ExecutablePathBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ExecutablePathBox.Location = new System.Drawing.Point(3, 235);
            this.ExecutablePathBox.Name = "ExecutablePathBox";
            this.ExecutablePathBox.Size = new System.Drawing.Size(233, 23);
            this.ExecutablePathBox.TabIndex = 38;
            this.ExecutablePathBox.Text = "Select an executable to patch";
            this.ExecutablePathBox.TextChanged += new System.EventHandler(this.ExecutablePathBox_TextChanged);
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 158);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine1.TabIndex = 37;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 217);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine2.TabIndex = 36;
            this.SeperatorLine2.Text = "--------------------------------------------------------------";
            // 
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new System.Drawing.Font("Cambria", 10F);
            this.GameInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GameInfoLabel.Location = new System.Drawing.Point(2, 261);
            this.GameInfoLabel.Name = "GameInfoLabel";
            this.GameInfoLabel.Size = new System.Drawing.Size(316, 19);
            this.GameInfoLabel.TabIndex = 40;
            this.GameInfoLabel.Text = "No File Selected";
            this.GameInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NovisBtn
            // 
            this.NovisBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.NovisBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.NovisBtn.FlatAppearance.BorderSize = 0;
            this.NovisBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NovisBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.NovisBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.NovisBtn.Location = new System.Drawing.Point(1, 141);
            this.NovisBtn.MaximumValue = null;
            this.NovisBtn.MinimumValue = null;
            this.NovisBtn.Name = "NovisBtn";
            this.NovisBtn.Size = new System.Drawing.Size(251, 24);
            this.NovisBtn.TabIndex = 46;
            this.NovisBtn.Text = "Disable Culling Of Level Geometry:";
            this.NovisBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NovisBtn.UseVisualStyleBackColor = false;
            // 
            // DebugButtonCycleBtn
            // 
            this.DebugButtonCycleBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.DebugButtonCycleBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DebugButtonCycleBtn.FlatAppearance.BorderSize = 0;
            this.DebugButtonCycleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DebugButtonCycleBtn.Font = new System.Drawing.Font("Cambria", 8.5F, System.Drawing.FontStyle.Bold);
            this.DebugButtonCycleBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DebugButtonCycleBtn.Location = new System.Drawing.Point(7, 27);
            this.DebugButtonCycleBtn.MaximumValue = null;
            this.DebugButtonCycleBtn.MinimumValue = null;
            this.DebugButtonCycleBtn.Name = "DebugButtonCycleBtn";
            this.DebugButtonCycleBtn.Size = new System.Drawing.Size(18, 19);
            this.DebugButtonCycleBtn.TabIndex = 55;
            this.DebugButtonCycleBtn.Text = "C";
            this.DebugButtonCycleBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DebugButtonCycleBtn.UseVisualStyleBackColor = false;
            this.DebugButtonCycleBtn.Click += new System.EventHandler(this.TestGSButtons);
            // 
            // PS4MenuSettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 383);
            this.Controls.Add(this.DebugButtonCycleBtn);
            this.Controls.Add(this.NovisBtn);
            this.Controls.Add(this.ProgPauseOnCloseBtn);
            this.Controls.Add(this.CustomDebugOptionsLabel);
            this.Controls.Add(this.UniversalPatchesLabel);
            this.Controls.Add(this.GameSpecificPatchesLabel);
            this.Controls.Add(this.ProgPauseOnOpenBtn);
            this.Controls.Add(this.GameInfoLabel);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.DisableDebugTextBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.DisablePausedIconBtn);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.ExecutablePathBox);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PS4MenuSettingsPage";
            this.Tag = "";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        

        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        private Button BrowseButton;
        private Button InfoHelpBtn;
        private Button CreditsBtn;
        private Button BackBtn;
        private Button DisableDebugTextBtn;
        private Button DisablePausedIconBtn;
        private Button ProgPauseOnCloseBtn;
        private Button ProgPauseOnOpenBtn;
        private Button NovisBtn; 
        private TextBox ExecutablePathBox;
        private Label GameSpecificPatchesLabel;
        private Label CustomDebugOptionsLabel;
        private Label UniversalPatchesLabel;
        private Label SeperatorLine0;
        private Label SeperatorLine1;
        private Label SeperatorLine2;
        private Label SeperatorLine3;
        private Label GameInfoLabel;
        private Label MainLabel;
        private Label Info;
        #endregion

        private Button DebugButtonCycleBtn;
    }
}
