using System;
using System.CodeDom;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Serialization;
using static Dobby.Common;

namespace Dobby {
    internal class PS4MenuSettingsPage : Form {
        public PS4MenuSettingsPage() {
            InitializeComponent();
            

            DisableDebugTextBtn.Variable = UniversaPatchValues[0];
            DisablePausedIconBtn.Variable = UniversaPatchValues[2];
            ProgPauseOnOpenBtn.Variable = UniversaPatchValues[3];
            ProgPauseOnCloseBtn.Variable = UniversaPatchValues[4];
            NovisBtn.Variable = UniversaPatchValues[5];

            AddControlEventHandlers(Controls);


            if(Game != 0 && gsButtons.Buttons != null) ResetCustomDebugOptions();
            FormActive = true;
        }

        private void InitializeComponent() {
            this.ProgPauseOnCloseBtn = new Dobby.Common.vButton();
            this.ProgPauseOnOpenBtn = new Dobby.Common.vButton();
            this.DisableDebugTextBtn = new Dobby.Common.vButton();
            this.DisablePausedIconBtn = new Dobby.Common.vButton();
            this.MainLabel = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.CustomDebugOptionsLabel = new System.Windows.Forms.Label();
            this.UniversalPatchesLabel = new System.Windows.Forms.Label();
            this.GameSpecificPatchesLabel = new System.Windows.Forms.Label();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ExecutablePathBox = new System.Windows.Forms.TextBox();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.GameInfoLabel = new System.Windows.Forms.Label();
            this.NovisBtn = new Dobby.Common.vButton();
            this.SuspendLayout();
            // 
            // ProgPauseOnCloseBtn
            // 
            this.ProgPauseOnCloseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ProgPauseOnCloseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ProgPauseOnCloseBtn.FlatAppearance.BorderSize = 0;
            this.ProgPauseOnCloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProgPauseOnCloseBtn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.ProgPauseOnCloseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ProgPauseOnCloseBtn.Location = new System.Drawing.Point(1, 119);
            this.ProgPauseOnCloseBtn.Name = "ProgPauseOnCloseBtn";
            this.ProgPauseOnCloseBtn.Size = new System.Drawing.Size(318, 24);
            this.ProgPauseOnCloseBtn.TabIndex = 56;
            this.ProgPauseOnCloseBtn.Text = "Disable Debug Pause On Menu Close: ";
            this.ProgPauseOnCloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProgPauseOnCloseBtn.UseVisualStyleBackColor = false;
            this.ProgPauseOnCloseBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProgPauseOnCloseBtn_Click);
            // 
            // ProgPauseOnOpenBtn
            // 
            this.ProgPauseOnOpenBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ProgPauseOnOpenBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ProgPauseOnOpenBtn.FlatAppearance.BorderSize = 0;
            this.ProgPauseOnOpenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProgPauseOnOpenBtn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.ProgPauseOnOpenBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ProgPauseOnOpenBtn.Location = new System.Drawing.Point(1, 96);
            this.ProgPauseOnOpenBtn.Name = "ProgPauseOnOpenBtn";
            this.ProgPauseOnOpenBtn.Size = new System.Drawing.Size(318, 24);
            this.ProgPauseOnOpenBtn.TabIndex = 51;
            this.ProgPauseOnOpenBtn.Text = "Disable Debug Pause On Menu Open: ";
            this.ProgPauseOnOpenBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProgPauseOnOpenBtn.UseVisualStyleBackColor = false;
            this.ProgPauseOnOpenBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProgPauseOnOpenBtn_Click);
            // 
            // DisableDebugTextBtn
            // 
            this.DisableDebugTextBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.DisableDebugTextBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisableDebugTextBtn.FlatAppearance.BorderSize = 0;
            this.DisableDebugTextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisableDebugTextBtn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.DisableDebugTextBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DisableDebugTextBtn.Location = new System.Drawing.Point(1, 52);
            this.DisableDebugTextBtn.Name = "DisableDebugTextBtn";
            this.DisableDebugTextBtn.Size = new System.Drawing.Size(318, 24);
            this.DisableDebugTextBtn.TabIndex = 46;
            this.DisableDebugTextBtn.Text = "Disable 2D Debug Text On Startup: ";
            this.DisableDebugTextBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisableDebugTextBtn.UseVisualStyleBackColor = false;
            this.DisableDebugTextBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DisableDebugTextBtn_Click);
            this.DisableDebugTextBtn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DisableDebugTextBtn_Click);
            // 
            // DisablePausedIconBtn
            // 
            this.DisablePausedIconBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.DisablePausedIconBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisablePausedIconBtn.FlatAppearance.BorderSize = 0;
            this.DisablePausedIconBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisablePausedIconBtn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.DisablePausedIconBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DisablePausedIconBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisablePausedIconBtn.Location = new System.Drawing.Point(1, 74);
            this.DisablePausedIconBtn.Name = "DisablePausedIconBtn";
            this.DisablePausedIconBtn.Size = new System.Drawing.Size(318, 24);
            this.DisablePausedIconBtn.TabIndex = 49;
            this.DisablePausedIconBtn.Text = "Disable Debug PAUSED Icon:";
            this.DisablePausedIconBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisablePausedIconBtn.UseVisualStyleBackColor = false;
            this.DisablePausedIconBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PausedIconBtn_Click);
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(1, 1);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(314, 24);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Misc. PS4  Patches Page";
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ExitBtn.Location = new System.Drawing.Point(293, 1);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(23, 23);
            this.ExitBtn.TabIndex = 18;
            this.ExitBtn.Text = "X";
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitBtn.UseVisualStyleBackColor = false;
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MinimizeBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimizeBtn.Location = new System.Drawing.Point(268, 1);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new System.Drawing.Size(23, 23);
            this.MinimizeBtn.TabIndex = 19;
            this.MinimizeBtn.Text = "--";
            this.MinimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MinimizeBtn.UseVisualStyleBackColor = false;
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(8, 366);
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
            this.CreditsBtn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 319);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(85, 22);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 297);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InfoHelpBtn.Size = new System.Drawing.Size(162, 22);
            this.InfoHelpBtn.TabIndex = 29;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 12);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine0.TabIndex = 31;
            this.SeperatorLine0.Text = "______________________________________________________________";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 341);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BackBtn.Size = new System.Drawing.Size(65, 22);
            this.BackBtn.TabIndex = 41;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // CustomDebugOptionsLabel
            // 
            this.CustomDebugOptionsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomDebugOptionsLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.CustomDebugOptionsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CustomDebugOptionsLabel.Location = new System.Drawing.Point(3, 202);
            this.CustomDebugOptionsLabel.Name = "CustomDebugOptionsLabel";
            this.CustomDebugOptionsLabel.Size = new System.Drawing.Size(316, 19);
            this.CustomDebugOptionsLabel.TabIndex = 54;
            this.CustomDebugOptionsLabel.Text = "(Load An Executable To Show Game-Specific Options)";
            // 
            // UniversalPatchesLabel
            // 
            this.UniversalPatchesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UniversalPatchesLabel.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
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
            this.GameSpecificPatchesLabel.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.GameSpecificPatchesLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.GameSpecificPatchesLabel.Location = new System.Drawing.Point(88, 177);
            this.GameSpecificPatchesLabel.Name = "GameSpecificPatchesLabel";
            this.GameSpecificPatchesLabel.Size = new System.Drawing.Size(136, 15);
            this.GameSpecificPatchesLabel.TabIndex = 52;
            this.GameSpecificPatchesLabel.Text = "Game-Specific Patches";
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 278);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine3.TabIndex = 32;
            this.SeperatorLine3.Text = "______________________________________________________________";
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BrowseButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Bold);
            this.BrowseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BrowseButton.Location = new System.Drawing.Point(237, 241);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(78, 23);
            this.BrowseButton.TabIndex = 39;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ExecutablePathBox
            // 
            this.ExecutablePathBox.BackColor = System.Drawing.Color.Gray;
            this.ExecutablePathBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.ExecutablePathBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ExecutablePathBox.Location = new System.Drawing.Point(3, 241);
            this.ExecutablePathBox.Name = "ExecutablePathBox";
            this.ExecutablePathBox.Size = new System.Drawing.Size(233, 23);
            this.ExecutablePathBox.TabIndex = 38;
            this.ExecutablePathBox.Text = " Select A .elf To Patch";
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 156);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine1.TabIndex = 37;
            this.SeperatorLine1.Text = "______________________________________________________________";
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 216);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine2.TabIndex = 36;
            this.SeperatorLine2.Text = "______________________________________________________________";
            // 
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.GameInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GameInfoLabel.Location = new System.Drawing.Point(2, 267);
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
            this.NovisBtn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold);
            this.NovisBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.NovisBtn.Location = new System.Drawing.Point(1, 141);
            this.NovisBtn.Name = "NovisBtn";
            this.NovisBtn.Size = new System.Drawing.Size(318, 24);
            this.NovisBtn.TabIndex = 57;
            this.NovisBtn.Text = "Disable Culling Of Level Geometry:";
            this.NovisBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NovisBtn.UseVisualStyleBackColor = false;
            this.NovisBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(DisableAllVisibilityBtn_Click);
            // 
            // PS4MenuSettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 387);
            this.Controls.Add(this.NovisBtn);
            this.Controls.Add(this.ProgPauseOnCloseBtn);
            this.Controls.Add(this.MinimizeBtn);
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
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PS4MenuSettingsPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Misc Patches Page Variables    --\\\
        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        #region Misc Patches Page Variables

        /// <summary> Array of Controls to Move When Loading >1 Game-Specific Debug Options
        ///</summary>
        private static Control[] ControlsToMove;
        private static FileStream MainStream;
        private static DynamicPatchButtons gsButtons;

        /// <summary> Variable Used When Adjusting Form Scale And Control Positions
        ///</summary>
        private static int
            ButtonIndex = 0,
            RB_StartPos,
            Game
        ;

        private static bool MultipleButtonsEnabled;

        private static string[] ResultStrings = new string[] {
            "Debug Menus Disabled",
            "Debug Menus Enabled",
            "Restored Menu Applied",
            "Custom Menu Applied",
        };

        private static byte[] LocalExecutableCheck;
        private static string ActiveFilePath;
        private static bool IsActiveFilePCExe, MainStreamIsOpen;
        
        public static void WriteBytes(int? offset = null, byte[] data = null) {
#if DEBUG
            var msg = $"Data {BitConverter.ToString(data).Replace("-", "")} Written To ";
            if(offset != null)
                MainStream.Position = (int)offset;
            msg += MainStream.Position.ToString("X"); // trust issues

            MainStream.Write(data, 0, data.Length);
            Dev.DebugOut(msg);
            Dev.DebugOut();
#else
            if (offset != null)
            MainStream.Position = (int)offset;
            MainStream.Write(data, 0, data.Length);
#endif
        }
        public static void WriteByte(int? offset = null, byte data = 0) {
#if DEBUG
            var msg = $"Byte {data:X} Written To ";
            if(offset != null)
                MainStream.Position = (int)offset;
            msg += MainStream.Position.ToString("X"); // trust issues

            MainStream.WriteByte(data);
            Dev.DebugOut(msg);
#else
            if(offset != null)
            MainStream.Position = (int)offset;
            MainStream.WriteByte(data);
#endif
        }
        public static void WriteVar(int? offset = null, object data = null) {
#if DEBUG
            var msg = " Written To ";

            if(offset != null)
                MainStream.Position = (int)offset;
            msg += MainStream.Position.ToString("X");


            if(data.GetType() == typeof(byte) && data.GetType() == typeof(bool)) {
                MainStream.WriteByte(BitConverter.GetBytes((byte)data)[0]);
                msg = (byte)data + msg;
            }

            else {
                MainStream.Write(BitConverter.GetBytes((float)data), 0, BitConverter.GetBytes((float)data).Length);
                msg = (float)data + msg;
            }
            
            Dev.DebugOut("var " + msg);

#else
            if(offset != null)
                MainStream.Position = (int)offset;

            if(data.GetType() != typeof(byte) && data.GetType() != typeof(bool))
                MainStream.WriteByte(BitConverter.GetBytes((byte)data)[0]);
            else
                MainStream.Write(BitConverter.GetBytes((float)data), 0, BitConverter.GetBytes((float)data).Length);
#endif
        }
        /// <summary> Compare Data Read At The Given Address
        /// </summary>
        /// <returns> True If The Data Read Matches The Array Given </returns>
        public static bool ArrayCmp(int Address, byte[] DataToCompare) {
            MainStream.Position = Address;
            byte[] DataPresent = new byte[DataToCompare.Length];
            MainStream.Read(DataPresent, 0, DataToCompare.Length);
            return DataPresent.SequenceEqual<byte>(DataToCompare);
        }
#endregion

        /// <summary>
        /// 0:  UC1100<br/>
        /// 1:  UC1102<br/>
        /// 2:  UC2100<br/>
        /// 3:  UC2102<br/>
        /// 4:  UC3100<br/>
        /// 5:  UC3102<br/>
        /// 6:  UC4100<br/>
        /// 7:  UC4101<br/>
        /// 8:  UC4133<br/>
        /// 9:  UC4133MP<br/>
        /// 10: TLL100<br/>
        /// 11: TLL10X<br/>
        /// 12: T1R100<br/>
        /// 13: T1R109<br/>
        /// 14: T1R11X<br/>
        /// 15: T2100<br/>
        /// 16: T2107<br/>
        /// 17: T2109<br/>
        /// </summary>
#if DEBUG
        public static int GameIndex;
#else
        private int GameIndex;
#endif

        /// <summary>
        /// MenuAlphaBtn        <br/>
        /// MenuScaleBtn        <br/>
        /// FOVBtn              <br/>
        /// MenuShadowedTextBtn <br/>
        /// RightAlignBtn       <br/>
        /// RightMarginBtn
        /// </summary>
        private enum IDS {
            MenuAlphaBtn,
            MenuScaleBtn,
            FOVBtn,
            MenuShadowedTextBtn,
            RightAlignBtn,
            RightMarginBtn
        }


        ///////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///-- QUALITY OF LIFE/BOOTSETTINGS OFFSET POINTERS  --\\\
        ///////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region BootSettingsPointers
        
        /*|Template
        new byte[][] {
            new byte[] {  }, // 0x | UC1100
            new byte[] {  }, // 0x | UC1102
            new byte[] {  }, // 0x | UC2100
            new byte[] {  }, // 0x | UC2102
            new byte[] {  }, // 0x | UC3100
            new byte[] {  }, // 0x | UC3102
            new byte[] {  }, // 0x | UC4100
            new byte[] {  }, // 0x | UC4101
            new byte[] {  }, // 0x | UC4133
            new byte[] {  }, // 0x | UC4133MP
            new byte[] {  }, // 0x | TLL100
            new byte[] {  }, // 0x | TLL109
            new byte[] {  }, // 0x | T1R100
            new byte[] {  }, // 0x | T1R109
            
            new byte[] {  }, // 0x | T1R111
            new byte[] {  }, // 0x | T2100
            new byte[] {  }, // 0x | T2107
            new byte[] {  }  // 0x | T2109
        }
        */

        /// <summary>
        /// Byte arrays to be used as pointers with the BootSettings custom function<br/><br/>
        /// 32-Bit Ones Are Pointers To Data In Executable Space.<br/>
        /// Chunky Fucks Are a 32-bit Pointer to A 64-bit Pointer + An Offset to Add.
        /// <br/><br/>
        /// Patch Type Index:<br/>
        ///   0:  Disable FPS<br/>
        ///   1:  Suppress Active task Display<br/>
        ///   2:  Show Paused Indicator<br/>
        ///   3:  ProgPauseOnMenuOpen<br/>
        ///   4:  ProgPauseOnMenuClose<br/>
        ///   5:  novis<br/>
        ///</summary>
        private static readonly byte[][][] UniversalBootSettingsPointers = new byte[][][] {  // fill null bytes just in case of repeat uses with alternate options
                // 4 = 0xfe | 8 = 0xff

            //|Disable FPS
            new byte[][] {
                new byte[] { 0x70, 0x89, 0x99, 0x00 }, // UC1100
                new byte[] { 0xF0, 0xC9, 0x95, 0x00 }, // UC1102
                new byte[] { 0x31, 0x14, 0xE7, 0x00 }, // UC2100
                new byte[] { 0x61, 0xDE, 0x05, 0x01 }, // UC2102
                new byte[] { 0xC9, 0x66, 0x43, 0x01 }, // UC3100
                new byte[] { 0x69, 0xAF, 0x7B, 0x01 }, // UC3102
                new byte[] {  }, // UC4100
                new byte[] {  }, // UC4101
                new byte[] {  }, // UC4133
                new byte[] {  }, // UC4133MP
                new byte[] {  }, // TLL100
                new byte[] {  }, // TLL109
                new byte[] {  }, // T1R100
                new byte[] {  }, // T1R109
                new byte[] {  }, // T1R111
                new byte[] {  }, // T2100
                new byte[] {  }, // T2107
                new byte[] { 0x30, 0xb4, 0x77, 0x03, 0xb8, 0x3a, 0x00, 0x00 }  // T2109
            },
            
            //|Suppress Active task Display
            new byte[][] {
                new byte[] { 0x41, 0x7B, 0x99, 0x00 }, // 0xD97B41  | UC1100
                new byte[] { 0x41, 0x7B, 0x99, 0x00 }, // 0xFA7E41  | UC1102
                new byte[] { 0xC9, 0x05, 0xE7, 0x00 }, // 0x12705C9 | UC2100
                new byte[] { 0xF9, 0xCF, 0x05, 0x01 }, // 0x145cff9 | UC2102
                new byte[] { 0x90, 0x1F, 0xA2, 0x01 }, // 0x1e21f90 | UC3100
                new byte[] { 0x60, 0xEE, 0xB3, 0x01 }, // 0x1f3ee60 | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] {  }, // 0x | T2100
                new byte[] {  }, // T2107
                new byte[] { 0x30, 0xb4, 0x77, 0x03, 0xcd, 0x3a, 0x00, 0x00 }  // T2109
            },

            //|Show Paused Indicator
            new byte[][] {
                new byte[] { 0x8A, 0xF9, 0xA9, 0x00 }, // 0xD98970  | UC1100
                new byte[] { 0x8A, 0x38, 0xA6, 0x00 }, // 0xE6388A  | UC1102
                new byte[] { 0x7A, 0xC7, 0xEB, 0x00 }, // 0x12bc77a | UC2100
                new byte[] { 0xE2, 0x95, 0x05, 0x00 }, // 0x14595e2 | UC2102
                new byte[] { 0x32, 0xFA, 0x42, 0x00 }, // 0x182fa32 | UC3100
                new byte[] { 0x52, 0x4A, 0x7B, 0x00 }, // 0x1bb4a52 | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] {  }, // 0x | T2100
                new byte[] { 0xBB, 0x67, 0x24, 0x03 }, // 0x36467bb | T2107
                new byte[] { 0x3B, 0xA6, 0x25, 0x03 }  // 0x365a63b | T2109
            },

            //|ProgPauseOnMenuOpen
            new byte[][] {
                new byte[] { 0x88, 0xF9, 0xA9, 0x00 }, // 0xE9F988  | UC1100 
                new byte[] { 0x88, 0x38, 0xA6, 0x00 }, // 0xE63888  | UC1102
                new byte[] { 0x78, 0xC7, 0xEB, 0x00 }, // 0x12bc778 | UC2100
                new byte[] { 0xE0, 0x95, 0x05, 0x01 }, // 0x14595e0 | UC2102
                new byte[] { 0x30, 0xFA, 0x42, 0x01 }, // 0x182fa30 | UC3100
                new byte[] { 0x50, 0x4A, 0x7B, 0x01 }, // 0x1bb4a50 | UC3102
                new byte[] {  }, // UC4100
                new byte[] {  }, // UC4101
                new byte[] {  }, // UC4133
                new byte[] {  }, // UC4133MP
                new byte[] {  }, // TLL100
                new byte[] {  }, // TLL109
                new byte[] {  }, // T1R100
                new byte[] {  }, // T1R109
                new byte[] {  }, // T1R110
                new byte[] {  }, // T1R111
                new byte[] {  }, // T2100
                new byte[] { 0xB9, 0x67, 0x24, 0x03 }, // 0x36467b9 | T2107
                new byte[] { 0x39, 0xA6, 0x25, 0x03 }  // 0x365a639 | T2109
            },

            //|ProgPauseOnMenuClose
            new byte[][] {
                new byte[] { 0x8C, 0xF9, 0xA9, 0x00 }, // 0xE9F98C  | UC1100
                new byte[] { 0x89, 0x38, 0xA6, 0x00 }, // 0xE63889  | UC1102
                new byte[] { 0x79, 0xC7, 0xEB, 0x00 }, // 0x12bc779 | UC2100
                new byte[] { 0xE1, 0x95, 0x05, 0x01 }, // 0x14595e1 | UC2102
                new byte[] {  }, // 0x | UC3100
                new byte[] {  }, // 0x | UC3102 USELESS?
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] {  }, // 0x | T2100
                new byte[] { 0xBA, 0x67, 0x24, 0x03 }, // 0x36467ba | T2107
                new byte[] { 0x3a, 0xA6, 0x25, 0x03 }  // 0x365a63a | T2109
            },

            //|novis
            new byte[][] {
                new byte[] { 0x6B, 0xF9, 0x98, 0x00 }, // 0xd8f96b  | UC1100
                new byte[] { 0x9B, 0x59, 0x95, 0x00 }, // 0xD5599B  | UC1102
                new byte[] { 0xFB, 0x61, 0xE6, 0x00 }, // 0x12661fb | UC2100
                new byte[] { 0xCB, 0x0D, 0x05, 0x01 }, // 0x1450dcb | UC2102
                new byte[] { 0x34, 0xFA, 0x42, 0x01 }, // 0x182FA34 | UC3100
                new byte[] { 0x8B, 0x80, 0x6E, 0x01 }, // 0x1ae808b | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] { 0x2C, 0x62, 0x01, 0x03 }, // 0x341622c | T2100
                new byte[] { 0x2C, 0x60, 0x01, 0x03 }, // 0x341602c | T2107
                new byte[] { 0x2C, 0x9E, 0x04, 0x03 }  // 0x3449e2c | T2109
            }
        };

        /// <summary>
        /// Byte arrays to be used as pointers with the BootSettings custom function<br/><br/>
        /// 32-Bit Ones Are Pointers To Data In Executable Space.<br/>
        /// Chunky Fucks Are a 32-bit Pointer to A 64-bit Pointer + An Offset to Add.
        /// 0 to UC1100 - UC4100
        /// <br/><br/>
        /// Patch Type Index:<br/>
        ///   0:  Menu Alpha<br/>
        ///   1:  Menu Scale<br/>
        ///   2:  Main Camera Fov<br/>
        ///   3:  Shadow Menu Text<br/>
        ///   4:  Swap Circle And Square<br/>
        ///   5:  Right Margin<br/>
        ///   6:  Right Align<br/>
        ///</summary>
        private static readonly byte[][][] GameSpecificBootSettingsPointers = new byte[][][] {  // fill null bytes just in case of repeat uses with alternate options
                

            //|Menu Alpha
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] {  }, // 0x | UC3100
                new byte[] {  }, // 0x | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] {  }, // 0x | T2100
                new byte[] { 0xC4, 0x67, 0x24, 0x03 }, // 0x36467c4 | T2107
                new byte[] { 0x44, 0xA6, 0x25, 0x03 }  // 0x365a644 | T2109
            },

            //|Menu Scale
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] {  }, // 0x | UC3100
                new byte[] {  }, // 0x | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] {  }, // 0x | T2100
                new byte[] { 0xC8, 0x67, 0x24, 0x03 }, // 0x36467c8 | T2107
                new byte[] { 0x48, 0xA6, 0x25, 0x03 }  // 0x365a648 | T2109
            },
            
            //|Main Camera Fov (camera-fov)
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] {  }, // 0x | UC3100
                new byte[] {  }, // 0x | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] {  }, // 0x | T2100
                new byte[] {  }, // 0x | T2107
                new byte[] {  }  // 0x | T2109
            },

            //|Shadow Menu Text
            new byte[][] {
                new byte[] { 0x87, 0xF9, 0xA9, 0x00 }, // 0xE9F988  | UC1100 
                new byte[] { 0x87, 0x38, 0xA6, 0x00 }, // 0xE63888  | UC1102
                new byte[] { 0x77, 0xC7, 0xEB, 0x00 }, // 0x12bc778 | UC2100
                new byte[] { 0xDF, 0x95, 0x05, 0x01 }, // 0x14595df | UC2102
                new byte[] { 0x2f, 0xFA, 0x42, 0x01 }, // 0x182fa2f | UC3100
                new byte[] { 0x4f, 0x4A, 0x7B, 0x01 }, // 0x1bb4a4f | UC3102
                new byte[] {  }, // UC4100
                new byte[] {  }, // UC4101
                new byte[] {  }, // UC4133
                new byte[] {  }, // UC4133MP
                new byte[] {  }, // TLL100
                new byte[] {  }, // TLL109
                new byte[] {  }, // T1R100
                new byte[] {  }, // T1R109
                new byte[] {  }, // T1R111
                new byte[] {  }, // T2100
                new byte[] { 0xB8, 0x67, 0x24, 0x03 }, // 0x36467b8 | T2107
                new byte[] { 0x38, 0xA6, 0x25, 0x03 }  // 0x365a638 | T2109
            },
            
            //|Swap Circle & Square
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] {  }, // 0x | UC3100
                new byte[] {  }, // 0x | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] {  }, // 0x | T2100
                new byte[] { 0xBD, 0x67, 0x24, 0x03 }, // 0x36467bd | T2107
                new byte[] { 0x3D, 0xA6, 0x25, 0x03 }  // 0x365a63d | T2109
            },

            //|Right Align
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] { 0x34, 0xFA, 0x42, 0x01 }, // 0x182FA34 | UC3100
                new byte[] { 0x54, 0x4A, 0x7B, 0x01 }, // 0x1bb4a54 | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] {  }, // 0x | T2100
                new byte[] { 0xBE, 0x67, 0x24, 0x03 }, // 0x36467be | T2107
                new byte[] { 0x3E, 0xA6, 0x25, 0x03 }  // 0x365a63e | T2109
            },
            
            //|Right Margin
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] { 0x38, 0xFA, 0x42, 0x01 }, // 0x182FA38 | UC3100
                new byte[] { 0x58, 0x4A, 0x7B, 0x01 }, // 0x1bb4a58 | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] {  }, // 0x | T2100
                new byte[] { 0xC0, 0x67, 0x24, 0x03 }, // 0x36467c0 | T2107
                new byte[] { 0x40, 0xA6, 0x25, 0x03 }  // 0x365a640 | T2109
            }
        };

        #endregion


        /// <summary>
        ///      Booleans Used For Universal Patch Values
        ///<br/> Defaults Are All False, So That's Nice. Simplifies Things
        ///<br/>
        ///<br/> 0: Disable FPS
        ///<br/> 1: Suppress Active Task Display (Toggled Alongside FPS)
        ///<br/> 2: Disable Paused Indicator
        ///<br/> 3: Prog Pause On Open 
        ///<br/> 4: Prog Pause On Close
        ///<br/> 5: novis (Addme)
        /// </summary>
#if !DEBUG
        private bool[] UniversaPatchValues = new bool[6];
#else
        public static bool[] UniversaPatchValues { get; private set; } = new bool[6];
        public static object[] PeekGameSpecificPatchValues() { return DynamicPatchButtons.GameSpecificPatchValues; }
#endif

        // this doesn't need to be a struct, but whatever
        /// <summary> Struct For Creating Dynamic Patch Buttons
        /// </summary>

        private struct DynamicPatchButtons {
            public DynamicPatchButtons(IDS[] Ids, int VerticalStartIndex = 0) {
                Buttons = new vButton[ControlText.Length + 1];
                ButtonsVerticalStartPos = VerticalStartIndex;

                if(Ids != null && Ids.Length < 2)
                    EnableDynamicPatchButton(Ids[0]);
                else
                    EnableDynamicPatchButtons(Ids);
            }




            /// <summary>
            /// 0: Menu Alpha <br/>
            /// 1: Menu Scale <br/>
            /// 2: Non-ADS FOV <br/>
            /// 3: Swap Square And Circle In Debug <br/>
            /// 4: Menu Shadowed Text <br/>
            /// 5: Align Menus Right <br/>
            /// 6: Right Margin <br/>
            /// </summary>

            public static object[] GameSpecificPatchValues { get; private set; } = new object[] {
                0.85f,
                0.60f,
                1f,
                false,
                false,
                false,
                (byte)10
            };

            public static readonly object[] DefaultPatchValues = new object[] {
                0.85f,
                0.60f,
                1f,
                false,
                false,
                false,
                (byte)10
            };

        /// <summary>
        /// Variable Used In Dynamic Button Cration For Game-Specific Patches
        /// </summary>
        private static readonly string[] Name = new string[] {
                    "MenuAlphaBtn",
                    "MenuScaleBtn",
                    "FOVBtn",
                    "SwapCircleInDebugBtn",
                    "MenuShadowTextBtn",
                    "MenuRightAlignBtn",
                    "RightMarginBtn"
            };

            private static readonly string[] ControlText = new string[] {
                    "Set DMenu BG Opacity:",             // default=0.85
                    "Set Dev Menu Scale:",               // default=0.60
                    "Adjust Non-ADS FOV:",               // default=1.00
                    "Swap Circle With Square In DMenu:", // default=No
                    "Enable Debug Menu Text Shadow:",    // default=No
                    "Align Debug Menus To The Right:",   // default=No
                    "Set Distance From Right Side:"      // default=10
            };

            private static readonly string[] Hint = new string[] {
                    "Hint",
                    "Hint",
                    "Only Effects The Camera While Not Aiming",
                    "Hint",
                    "Moves The Dev/Quick Menus To The Right Of The Screen",
                    "Hint",
                    "Hint"
            };

            private int ButtonsVerticalStartPos;


            /// <summary> Buttons For Game-Specific Debug Options Loaded Based On The Game Chosen <br/><br/>
            /// 0: MenuAlphaBtn                                                                        <br/>
            /// 1: MenuScaleBtn                                                                        <br/>
            /// 2: FOVBtn                                                                              <br/>
            /// 3: SwapCircleInDebugBtn                                                                <br/>
            /// 4: MenuShadowTextBtn                                                                   <br/>
            /// 5: RightAlignBtn                                                                       <br/>
            /// 6: RightMarginBtn
            /// </summary>
            public vButton[] Buttons; // Initialized Once An Executable's Selected


            /////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\
            ///--     Dynamic Buttons Main Functions    --\\\
            /////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\
            #region Dynamic Buttons Main Functions

            /// <summary> Enable A Specific Button
            ///</summary>
            public void EnableDynamicPatchButton(IDS button) {
                Buttons[(int)button] = new vButton();
                ActiveForm.Controls.Add(Buttons[(int)button]);
            }

            /// <summary> Enable Specific Buttons
            ///</summary>
            public void EnableDynamicPatchButtons(IDS[] buttons) {
                if(buttons == null) {
                    EnableDynamicPatchButtons();
                    return;
                }


                Dev.DebugOut($"Enabling {buttons.Length} Buttons");
                foreach(int id in buttons) {
                    Buttons[id] = new vButton();
                    ActiveForm.Controls.Add(Buttons[id]);
                }
                MultipleButtonsEnabled = true;
            }

            /// <summary> Enable All Buttons
            ///</summary>
            public void EnableDynamicPatchButtons() { Dev.DebugOut("Enabling All Buttons");
                for(index = 0; index < Buttons.Length - 1; index++) {
                    Buttons[index] = new vButton();
                    ActiveForm.Controls.Add(Buttons[index]);
                }
                MultipleButtonsEnabled = true;
            }

            /// <summary> Nuke Dynamic Patch Buttons And Reset Option Variables
            ///</summary>
            public void Reset() {
                foreach(Button button in Buttons)
                    button?.Dispose();

                Buttons = null;
                GameSpecificPatchValues = DefaultPatchValues;
            }

            public Button[] CreateDynamicButtons() {
            RunCheck:
                if(ButtonIndex >= gsButtons.Buttons.Length - 1) return Buttons;

                // Skip disabled buttons or return if the end of the collection is reached
                if(gsButtons.Buttons[ButtonIndex] == null) {
                    ButtonIndex++;
                    goto RunCheck;
                }

                // Create The Button
                Buttons[ButtonIndex].Name = Name[ButtonIndex];
                Buttons[ButtonIndex].TabIndex = ButtonIndex;
                Buttons[ButtonIndex].Location = new Point(1, ButtonsVerticalStartPos);
                Buttons[ButtonIndex].Size = new Size(ActiveForm.Width - 2, 23);
                Buttons[ButtonIndex].Font = MainFont;
                Buttons[ButtonIndex].Text = ControlText[ButtonIndex];
                Buttons[ButtonIndex].Variable = GameSpecificPatchValues[ButtonIndex];
                Buttons[ButtonIndex].TextAlign = ContentAlignment.MiddleLeft;
                Buttons[ButtonIndex].FlatAppearance.BorderSize = 0;
                Buttons[ButtonIndex].FlatStyle = FlatStyle.Flat;
                Buttons[ButtonIndex].ForeColor = SystemColors.Control;
                Buttons[ButtonIndex].BackColor = MainColour;
                Buttons[ButtonIndex].Cursor = Cursors.Cross;
                Buttons[ButtonIndex].MouseEnter += ControlHover;
                Buttons[ButtonIndex].MouseDown += new MouseEventHandler(MouseDownFunc);
                Buttons[ButtonIndex].MouseUp += new MouseEventHandler(MouseUpFunc);
                Buttons[ButtonIndex].MouseEnter += HoverString;
                Buttons[ButtonIndex].MouseLeave += ControlLeave;
                Buttons[ButtonIndex].Paint += DrawButtonVar;
                Buttons[ButtonIndex].BringToFront();


                if(GameSpecificPatchValues[ButtonIndex].GetType() == typeof(bool))
                    Buttons[ButtonIndex].Click += DynamicBtn_Click;

                else if(GameSpecificPatchValues[ButtonIndex].GetType() == typeof(float)) {
                    Buttons[ButtonIndex].MouseWheel += FloatFunc;
                    Buttons[ButtonIndex].MouseDown += FloatClick;
                }

                else if(GameSpecificPatchValues[ButtonIndex].GetType() == typeof(byte)) {
                    Buttons[ButtonIndex].MouseWheel += IntFunc;
                    Buttons[ButtonIndex].MouseDown += IntClick;
                }

                ButtonsVerticalStartPos += 23; ButtonIndex++;
                goto RunCheck;
            }
            #endregion


            /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            ///--     Event Handlers And Functions For Dynamic Button   --\\\
            /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            #region Event Handlers And Functions For Dynamic Button
            private void DynamicBtn_Click(object sender, EventArgs e) => ToggleFunc((vButton)sender, ((Control)sender).TabIndex);
            private void ToggleFunc(vButton Control, int ButtonIndex) {
                if(MouseScrolled || !MouseIsDown || CurrentControl != Control.Name) return;

                GameSpecificPatchValues[ButtonIndex] = !(bool)GameSpecificPatchValues[ButtonIndex];
                Control.Variable = GameSpecificPatchValues[ButtonIndex];
                Control.Refresh();
            }


            private void FloatClick(object sender, MouseEventArgs e) => FloatClickFunc((vButton)sender, ((vButton)sender).TabIndex, e.Button);
            private void FloatClickFunc(vButton Control, int ButtonIndex, MouseButtons Button) {
                if(CurrentControl != Control.Name) return;
                var currentFloat = (float)GameSpecificPatchValues[ButtonIndex]; // Avoid CS0445

                if(Button == MouseButtons.Left) GameSpecificPatchValues[ButtonIndex] = (float)Math.Round(currentFloat += 0.1f, 4);
                else GameSpecificPatchValues[ButtonIndex] = (float)Math.Round(currentFloat -= 0.1f, 4);

                Control.Variable = GameSpecificPatchValues[ButtonIndex];
                Control.Refresh();
            }

            private void FloatFunc(object sender, MouseEventArgs e) => FloatScrollFunc((vButton)sender, ((vButton)sender).TabIndex, e.Delta);
            private void FloatScrollFunc(vButton Control, int ButtonIndex, int WheelDelta) {
                if(CurrentControl != Control.Name) return;
                var currentFloat = (float)GameSpecificPatchValues[ButtonIndex]; // Avoid CS0445

                GameSpecificPatchValues[ButtonIndex] = (float)Math.Round(currentFloat += WheelDelta / 12000.0F, 4);
                Control.Variable = GameSpecificPatchValues[ButtonIndex];
                Control.Refresh();
            }


            private void IntClick(object sender, MouseEventArgs e) => IntClickFunc((vButton)sender, ((vButton)sender).TabIndex, e.Button);
            private void IntClickFunc(vButton Control, int ButtonIndex, MouseButtons Button) {
                if(CurrentControl != Control.Name) return;
                var currentInt = (byte)GameSpecificPatchValues[ButtonIndex]; // Avoid CS0445

                if(Button == MouseButtons.Left) currentInt += 5;
                else currentInt -= 5;

                GameSpecificPatchValues[ButtonIndex] = currentInt;
             
                Control.Variable = GameSpecificPatchValues[ButtonIndex];
                Control.Refresh();
            }

            private void IntFunc(object sender, MouseEventArgs e) => IntScrollFunc((vButton)sender, ((vButton)sender).TabIndex, e.Delta);
            private void IntScrollFunc(vButton Control, int ButtonIndex, int WheelDelta) {
                if(CurrentControl != Control.Name) return;
                var currentInt = (byte)GameSpecificPatchValues[ButtonIndex]; // Avoid CS0445

                currentInt += (byte)(WheelDelta / 120);
                GameSpecificPatchValues[ButtonIndex] = currentInt;

                Control.Variable = GameSpecificPatchValues[ButtonIndex];
                Control.Refresh();
            }

            private void HoverString(object sender, EventArgs e) => SetInfoLabelText(Hint[((Control)sender).TabIndex]);
            #endregion
        }



        ///////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Event Handlers For Basic Patches Available For Each Game     --\\\
        ///////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Event Handlers For Basic Patches Available For Each Game
        private void DisableDebugTextBtn_Click(object sender, MouseEventArgs e) {
            DefaultButtonClick((vButton)sender, e.Delta != 0, 0); // Disable FPS
            DefaultButtonClick((vButton)sender, e.Delta != 0, 1); // Suppress Active Task Display
        }
        private void PausedIconBtn_Click(object sender, MouseEventArgs e) => DefaultButtonClick((vButton)sender, e.Delta != 0, 2);
        private void ProgPauseOnOpenBtn_Click(object sender, MouseEventArgs e) => DefaultButtonClick((vButton)sender, e.Delta != 0, 3);
        private void ProgPauseOnCloseBtn_Click(object sender, MouseEventArgs e) => DefaultButtonClick((vButton)sender, e.Delta != 0, 4);
        private void DisableAllVisibilityBtn_Click(object sender, MouseEventArgs e) => DefaultButtonClick((vButton)sender, e.Delta != 0, 5);
        private void DefaultButtonClick(vButton cnt, bool scrolled, int PatchIndex) { ToggleBool(cnt, PatchIndex); MouseScrolled = scrolled; }
        private void ToggleBool(vButton Control, int OptionIndex) {
            if(MouseScrolled || !MouseIsDown || CurrentControl != Control.Name)
                return;

            UniversaPatchValues[OptionIndex] = !(bool)UniversaPatchValues[OptionIndex];
            Control.Variable = UniversaPatchValues[OptionIndex];
            Control.Refresh();
        }
        #endregion


        // Only Gonna Be Useful If I End Up Using A Monospace Font
#if false
        /// <summary> Takes A Control & Variable, and Appends The Variable (As A String) To The Right Of The Control
        ///</summary>
        /// <param name="Variable"> The Variable To Append To The Right Side </param>
        /// <returns>Formatted String</returns>
        public static string AppendControlVariable(Control control, object Variable) {
            var padding = string.Empty;

            var buffer = control.Size - TextRenderer.MeasureText(control.Text, control.Font) - TextRenderer.MeasureText($"{Variable}", control.Font);

            for(; TextRenderer.MeasureText(padding, control.Font).Width < buffer.Width;)
                padding += " ";

            return $"{control.Text}{padding}{Variable}";
        }

#endif


        //////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Misc Patches Page Main Functions    --\\\
        //////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Misc Patches Page Main Functions
        private void BrowseButton_Click(object sender, EventArgs e) {
            FileDialog OpenedFile = new OpenFileDialog {
                Filter = "Executable|*.elf;*.bin",
                Title = "Select Either Of The Game's Executables"
            };

            if(OpenedFile.ShowDialog() == DialogResult.OK) {
                if(OriginalFormScale != Size.Empty || MainStreamIsOpen)
                    ResetCustomDebugOptions();
                
                ExecutablePathBox.Text = OpenedFile.FileName;
                MainStream = File.Open(OpenedFile.FileName, FileMode.Open, FileAccess.ReadWrite);


                Game = GetGameID(MainStream);
                GameIndex = (int)GetBootSettingsGameIndexAndAddresses()[0];
                GameInfoLabel.Text = GetGameLabelFromID(Game);

                MainStreamIsOpen = true;
                CustomDebugOptionsLabel.Visible = IsActiveFilePCExe = false;

                LoadGameSpecificMenuOptions();
            }
        }



        private static void ResetCustomDebugOptions(object _ = null, EventArgs __ = null) {
            if(Game == 0) return;
#if DEBUG
            Dev.DebugOut("Resetting Form And Main Stream");
#endif
            index = 0;

            // Reset Form Size
            if(ActiveForm.Name != "Dobby") //! Lazy Fix 
                ActiveForm.Size = OriginalFormScale;
            OriginalFormScale = Size.Empty;

            // Kill MainStream
            MainStreamIsOpen = false;
            MainStream?.Dispose();

            // Nuke Dynamic Patch Buttons
            gsButtons.Reset();

            // Move Controls Back To Their Original Positions
            for(; index < ControlsToMove.Length; index++)
                ControlsToMove[index].Location = OriginalControlPositions[index];

            // Nudge Remaining Controls Back To Their Default Positions
            if(FormActive) {
                ActiveForm.Controls.Find("ResetBtn", true)[0]?.Dispose();
                ActiveForm.Controls.Find("ConfirmPatchesBtn", true)[0]?.Dispose();
                ActiveForm.Controls.Find("CustomDebugOptionsLabel", true)[0].Visible = true;
                ActiveForm.Controls.Find("ExecutablePathBox", true)[0].Text = " Select A .elf To Patch";
            }

            Game = 0;
            ActiveFilePath = null;
            MultipleButtonsEnabled = false;
        }

        /// <summary> Resize Form And Move Buttons, Then Add Enabled Custom Buttons To Form Based On The Current Game And Patch
        ///</summary>
        public void LoadGameSpecificMenuOptions() {

            // Assign values to variables made to keep track of the default form size/control postions for the reset button. Doing it on page init is annoying 'cause designer memes
            if(OriginalFormScale == Size.Empty) {
                Dev.DebugOut("Setting Original Scale Variables");

                // Every Control Below The "Game Specific Patches" Label
                ControlsToMove = new Control[] {
                    Controls.Find("SeperatorLine2", true)[0],
                    Controls.Find("BrowseButton", true)[0],
                    Controls.Find("ExecutablePathBox", true)[0],
                    Controls.Find("GameInfoLabel", true)[0],
                    Controls.Find("SeperatorLine3", true)[0],
                    Controls.Find("InfoHelpBtn", true)[0],
                    Controls.Find("CreditsBtn", true)[0],
                    Controls.Find("BackBtn", true)[0],
                    Controls.Find("Info", true)[0]
                };
                OriginalFormScale = Size;
                OriginalControlPositions = new Point[ControlsToMove.Length];

                for(index = 0; index < ControlsToMove.Length; index++) // Save Original Y Loc Of Controls
                    OriginalControlPositions[index] = ControlsToMove[index].Location;
            }

            RB_StartPos = GameInfoLabel.Location.Y + GameInfoLabel.Size.Height + 1; // Right Below The GameInfoLabel
            CustomDebugOptionsLabel.Visible = false;                                // Label Hide

            // In Case Of Repeat Uses
            ButtonIndex = 0;

            IDS[] GameButtonIds = new IDS[1];
            // Enable Buttons Based On Which Patches Are Available For The Current Game
            switch(Game) {
                case UC1100:
                case UC1102:
                case UC2100:
                case UC2102:
                case UC3100:
                case UC3102:

                case T1R100:
                case T1R109:
                case T1R110:
                case T1R111:

                case T2100:
                    break;

                case T2101:
                    GameButtonIds = new IDS[] { IDS.MenuScaleBtn, IDS.MenuShadowedTextBtn };
                    break;
                case T2102:
                    GameButtonIds = new IDS[] { IDS.MenuScaleBtn, IDS.MenuShadowedTextBtn, IDS.FOVBtn };
                    break;
                case T2105:
                    GameButtonIds = new IDS[] { IDS.MenuScaleBtn, IDS.MenuShadowedTextBtn, IDS.FOVBtn, IDS.RightAlignBtn };
                    break;
                case T2107:
                case T2108:
                case T2109:
                    GameButtonIds = null;
                    break;
            }

            gsButtons = new DynamicPatchButtons(GameButtonIds, GameSpecificPatchesLabel.Location.Y + GameSpecificPatchesLabel.Size.Height + 1);

            foreach (var Btn in gsButtons.CreateDynamicButtons())


            index = 0;

            // Only Needed If Multiple Buttons Are Being Added, As The Form Can Already Fit One More After hiding The Label
            if(MultipleButtonsEnabled) {

                // Set The Amount of Pixels To Move Shit Based On How Much Shit Has Been Shat.                                                                                                                  shit
                foreach(Control control in gsButtons.Buttons)
                    if(control != null) {
                        if(index++ != 0) {
                            // Move Each Control, Then Resize The BorderBox & Form
                            foreach(Control A in ControlsToMove)
                                A.Location = new Point(A.Location.X, A.Location.Y + 23);

                            Size = new Size(Size.Width, Size.Height + 23);
                        }
                    }
            }


            Size = new Size(Size.Width, Size.Height + 46);


            // Move The Controls Below The Confirm And Reset Buttons A Bit Farther Down To Make Room For Them
            for(int i = 4; i < ControlsToMove.Length; i++)
                ControlsToMove[i].Location = new Point(ControlsToMove[i].Location.X, ControlsToMove[i].Location.Y + 46);



            // Create Confirm And Reset Buttons Once The Rest Are Created
            RB_StartPos = GameInfoLabel.Location.Y + GameInfoLabel.Size.Height + 1; // Right Below The GameInfoLabel
            Button ConfirmPatchesBtn = new Button();
            Controls.Add(ConfirmPatchesBtn);
            ConfirmPatchesBtn.TabIndex = ButtonIndex;
            ConfirmPatchesBtn.Name = "ConfirmPatchesBtn";
            ConfirmPatchesBtn.Location = new Point(1, RB_StartPos);
            ConfirmPatchesBtn.Size = new Size(Width - 11, 23);
            ConfirmPatchesBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            ConfirmPatchesBtn.Text = "Confirm And Apply Patches";
            ConfirmPatchesBtn.TextAlign = ContentAlignment.MiddleLeft;
            ConfirmPatchesBtn.FlatAppearance.BorderSize = 0;
            ConfirmPatchesBtn.FlatStyle = FlatStyle.Flat;
            ConfirmPatchesBtn.ForeColor = SystemColors.Control;
            ConfirmPatchesBtn.BackColor = Color.FromArgb(100, 100, 100);
            ConfirmPatchesBtn.Cursor = Cursors.Cross;
            ConfirmPatchesBtn.MouseEnter += ControlHover;
            ConfirmPatchesBtn.MouseLeave += ControlLeave;
            ConfirmPatchesBtn.Click += ConfirmBtn_Click;
            ConfirmPatchesBtn.BringToFront();

            Button ResetBtn = new Button();
            Controls.Add(ResetBtn);
            ResetBtn.BackColor = Color.FromArgb(100, 100, 100);
            ResetBtn.Cursor = Cursors.Cross;
            ResetBtn.FlatAppearance.BorderSize = 0;
            ResetBtn.FlatStyle = FlatStyle.Flat;
            ResetBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            ResetBtn.ForeColor = SystemColors.Control;
            ResetBtn.ImageAlign = ContentAlignment.TopRight;
            ResetBtn.Location = new Point(1, RB_StartPos + 24);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(Width - 11, 23);
            ResetBtn.Text = "Reset";
            ResetBtn.TextAlign = ContentAlignment.MiddleLeft;
            ResetBtn.UseVisualStyleBackColor = false;
            ResetBtn.Click += new EventHandler(ResetCustomDebugOptions);
            ResetBtn.MouseEnter += ControlHover;
            ResetBtn.MouseLeave += ControlLeave;
            ResetBtn.BringToFront();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e) {
            ApplyMenuSettings();
        }


        private int ApplyMenuSettings() {

            using(MainStream) {

#if DEBUG
                if(UniversaPatchValues.Length != UniversalBootSettingsPointers.Length || DynamicPatchButtons.GameSpecificPatchValues.Length != GameSpecificBootSettingsPointers.Length)
                    MessageBox.Show($"Universal:\n  Vars: {UniversaPatchValues.Length}\n  Pointers: {UniversalBootSettingsPointers.Length}\nDynamic:\n  Vars: {DynamicPatchButtons.GameSpecificPatchValues.Length}\n  Pointers: {GameSpecificBootSettingsPointers.Length}", "Mismatch In Array Value vs pointer Length.");
#endif
                index = 0;
                byte ValueType = 0xf0;
                int BootSettingsAddress;
                var Addresses = GetBootSettingsGameIndexAndAddresses();

                // Write Function Call To Call BootSettings
                WriteBytes((int)Addresses[1], GetBootSettingsFunctionCall());

                // Write BootSettings Function's Assembly To Game Executable
                BootSettingsAddress = (int)Addresses[2];
                WriteBytes(BootSettingsAddress, GetBootSettingsBytes(GameIndex));

                // Universal Options
                byte[] PatchData;
                foreach(var Bool in UniversaPatchValues) {
                    if(!Bool)
                        continue;

                    PatchData = UniversalBootSettingsPointers[index][GameIndex];

                    if(PatchData.Length == 4) ValueType = 0xFE;
                    else if(PatchData.Length == 8) ValueType = 0xFF;
                    else {
                        Dev.DebugOut($"Invalid Data Size. ({PatchData.Length})");
                        continue;
                    }


                    WriteByte(data: ValueType);

                    WriteBytes(data: PatchData);
                    WriteByte(data: 1);
                    index++;
                }
                index = 0;

                // Game-Specific Options
                foreach(var val in DynamicPatchButtons.GameSpecificPatchValues) {

                    if(val == DynamicPatchButtons.DefaultPatchValues[index]) {
                        Dev.DebugOut($"{val} == {DynamicPatchButtons.DefaultPatchValues[index]} (#{index})");
                        index++;
                        continue;
                    }

                    else Dev.DebugOut($"{val} != {DynamicPatchButtons.DefaultPatchValues[index]} (#{index})");

                    PatchData = GameSpecificBootSettingsPointers[index][GameIndex];

                    if(PatchData.Length == 4) ValueType = 0xFE;
                    else if(PatchData.Length == 8) ValueType = 0xFF;
                    else continue;

                    WriteByte(data: ValueType);

                    WriteBytes(data: PatchData);
                    WriteVar(data: val);
                    index++;
                }

                WriteBytes(data: new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x81, 0x08 });
            }

            return 1;
        }


        /// <summary> Returns a byte[] containing the constructed bootsettings function data
        /// </summary>
        /// <param name="GameIndex">  </param>
        /// <returns></returns>
        private static byte[] GetBootSettingsBytes(int GameIndex = 18) {
            byte[] BootSettingsData,
                   BootSettingsFunction = new byte[] { 0x48, 0x8d, 0x0d, 0x43, 0x00, 0x00, 0x00, 0x80, 0x3c, 0x21, 0xfe, 0x75, 0x12, 0x8a, 0x59, 0x05, 0x8b, 0x54, 0x21, 0x01, 0x01, 0xc2, 0x67, 0x88, 0x1a, 0x48, 0x83, 0xc1, 0x06, 0xeb, 0xe8, 0x80, 0x3c, 0x21, 0xff, 0x75, 0x23, 0x8b, 0x94, 0x21, 0x01, 0x00, 0x00, 0x00, 0x01, 0xc2, 0x48, 0x8d, 0x14, 0x22, 0x48, 0x8b, 0x12, 0x8b, 0x5c, 0x21, 0x05, 0x48, 0x01, 0xda, 0x8a, 0x59, 0x09, 0x40, 0x88, 0x1a, 0x48, 0x83, 0xc1, 0x0a, 0xeb, 0xbf, 0x5b, 0xc3 }
            ;

            // new byte { (Quick Menu Function Call), (Ptr to Base Addr) }
            byte[][] BootSettingsBaseAddressPointers = new byte[][] {
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC1 1.00 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC1 1.02 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC2 1.00 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC2 1.02 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC3 1.00 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC3 1.02 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC4 1.00 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC4 1.01 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC4 1.33 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC4 1.33 MP //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // TLL 1.00 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // TLL 1.09 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // T1R 1.00 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // T1R 1.09 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // T1R 1.11 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // T2 1.00  //!
                new byte [] { 0xe8, 0xcb, 0xd0, 0x3d, 0x00, 0x53, 0x48, 0x8d, 0x05, 0xc3, 0x8c, 0xff, 0xff }, // T2 1.07  //!
                new byte [] { 0xe8, 0x9b, 0x45, 0x82, 0x00, 0x53, 0x48, 0x8d, 0x05, 0x03, 0xea, 0xff, 0xff }  // T2 1.09  //!
            };

            BootSettingsData = new byte[BootSettingsFunction.Length + BootSettingsBaseAddressPointers[GameIndex].Length];

            Buffer.BlockCopy(BootSettingsBaseAddressPointers[GameIndex], 0,
                             BootSettingsData, 0,
                             BootSettingsBaseAddressPointers[GameIndex].Length
                             );

            Buffer.BlockCopy(BootSettingsFunction, 0,
                             BootSettingsData, BootSettingsBaseAddressPointers[GameIndex].Length,
                             BootSettingsFunction.Length
                            );

            return BootSettingsData;
        }

        /// <summary>
        /// Merged A Few Functions With The Same Switch Case In To This Since There Wasn't Any Downside Anyway <br/>
        /// 
        /// Gets The "GameIndex" Of The Selected Game, Followed By The Address To Call, Then Write The BootSettings Function
        /// </summary>
        /// <returns>
        ///      0: GameIndex
        /// <br/>1: GetBootSettingsFunctionCallAddress
        /// <br/>2: Address To Write Boot Settings
        /// </returns>
        private object[] GetBootSettingsGameIndexAndAddresses() {
            var ret = new object[] { 0, 0, 0 };


            switch(Game) {
                default:
                    ret[0] = 99999999999999;
                    break;

                case UC1100:
                case UC1102:
                case UC2100:
                case UC2102:
                case UC3100:
                case UC3102:
                case UC4100:
                case UC4101:
                case UC4127_133:
                case UC4133MP:
                case TLL100:
                case TLL10X:

                case T1R100:
                case T1R109:
                case T1R110:case T1R111:
                case T2100:
                case T2107:
                    ret[0] = 16;
                    ret[1] = 0x1f217a; // 0x5ee17a
                    ret[2] = 0xb330;   // 0x407330
                    break;
                case T2108:
                case T2109:
                    ret[0] = 17;
                    ret[1] = 0x633cba; // 0xa2fcba
                    ret[2] = 0x55f0;   // 0x4015f0
                    break;
            }

            return ret;
        }


        /// <summary> Returns The Data For The Custom Function Used To Call BootSettings To Write Over The Quick Menu Function Call
        ///</summary>
        private static byte[] GetBootSettingsFunctionCall() {
            switch(Game) {
                case UC1100: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case UC1102: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case UC2100: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case UC2102: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case UC3100: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case UC3102: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case T1R100: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case T1R109: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case T1R110:
                case T1R111: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case T2100: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 };  // 

                case T2107: return new byte[] { 0xe8, 0xb1, 0x91, 0xe1, 0xff };  // CALL 0x407330

                case T2108:
                case T2109: return new byte[] { 0xe8, 0x31, 0x19, 0x9d, 0xff };  // CALL 0x4015f0
                default:
                    return Array.Empty<byte>();
            }
        }
        #endregion




        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        ///--     Repeated Page Functions     --\\\
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        #region Repeated Page Functions
        private void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.InfoHelpPage);
        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.CreditsPage);
        private void BackBtn_Click(object sender, EventArgs e) => ReturnToPreviousPage();
        #endregion


        ////////////////////\\\\\\\\\\\\\\\\\\\\
        ///--     Control Declarations     --\\\
        ////////////////////\\\\\\\\\\\\\\\\\\\\
        #region Control Declarations
        private Button BrowseButton;
        private Button MinimizeBtn;
        private Button InfoHelpBtn;
        private Button CreditsBtn;
        private Button ExitBtn;
        private Button BackBtn;
        private vButton DisableDebugTextBtn;
        private vButton DisablePausedIconBtn;
        private vButton ProgPauseOnCloseBtn;
        private vButton ProgPauseOnOpenBtn;
        private vButton NovisBtn; 
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
    }
}