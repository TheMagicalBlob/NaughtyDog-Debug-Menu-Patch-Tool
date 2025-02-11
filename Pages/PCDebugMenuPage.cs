using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static Dobby.Common;
using System.IO;
using System.Threading;

namespace Dobby {
    internal class PCDebugMenuPage : Form {
        public PCDebugMenuPage() {
            InitializeComponent();
            InitializeAdditionalEventHandlers(Controls);
        }

        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Designer Crap, No Touchie      --\\\
        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        #region Designer Crap, No Touchie
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
            this.CreditsBtn = new Button();
            this.InfoHelpBtn = new Button();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.GameInfoLabel = new System.Windows.Forms.Label();
            this.BackBtn = new Button();
            this.BrowseButton = new Button();
            this.ExecutablePathBox = new Dobby.TextBox();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.BaseDebugBtn = new Button();
            this.DisableDebugBtn = new Button();
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
            this.MainLabel.Text = "PC Debug Menu Page";
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(9, 235);
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
            this.CreditsBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 184);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(75, 23);
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
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 159);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InfoHelpBtn.Size = new System.Drawing.Size(147, 23);
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
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(3, 141);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine2.TabIndex = 32;
            this.SeperatorLine2.Text = "--------------------------------------------------------------";
            // 
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new System.Drawing.Font("Cambria", 10F);
            this.GameInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GameInfoLabel.Location = new System.Drawing.Point(2, 131);
            this.GameInfoLabel.Name = "GameInfoLabel";
            this.GameInfoLabel.Size = new System.Drawing.Size(316, 19);
            this.GameInfoLabel.TabIndex = 40;
            this.GameInfoLabel.Text = "No File Selected";
            this.GameInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 209);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 41;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BrowseButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Cambria", 8.5F, System.Drawing.FontStyle.Bold);
            this.BrowseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BrowseButton.Location = new System.Drawing.Point(239, 99);
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
            this.ExecutablePathBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.ExecutablePathBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ExecutablePathBox.Location = new System.Drawing.Point(7, 99);
            this.ExecutablePathBox.Name = "ExecutablePathBox";
            this.ExecutablePathBox.Size = new System.Drawing.Size(233, 23);
            this.ExecutablePathBox.TabIndex = 38;
            this.ExecutablePathBox.Text = " Select An exe To Modify";
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 78);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine1.TabIndex = 36;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // BaseDebugBtn
            // 
            this.BaseDebugBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BaseDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BaseDebugBtn.FlatAppearance.BorderSize = 0;
            this.BaseDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaseDebugBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.BaseDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BaseDebugBtn.Location = new System.Drawing.Point(1, 59);
            this.BaseDebugBtn.Name = "BaseDebugBtn";
            this.BaseDebugBtn.Size = new System.Drawing.Size(231, 23);
            this.BaseDebugBtn.TabIndex = 20;
            this.BaseDebugBtn.Text = "Enable The Default Debug Menus";
            this.BaseDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BaseDebugBtn.UseVisualStyleBackColor = false;
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
            this.DisableDebugBtn.Location = new System.Drawing.Point(1, 35);
            this.DisableDebugBtn.Name = "DisableDebugBtn";
            this.DisableDebugBtn.Size = new System.Drawing.Size(184, 23);
            this.DisableDebugBtn.TabIndex = 38;
            this.DisableDebugBtn.Text = "Disable The Debug Menus";
            this.DisableDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisableDebugBtn.UseVisualStyleBackColor = false;
            this.DisableDebugBtn.Click += new System.EventHandler(this.DisableDebugBtn_Click);
            // 
            // PCDebugMenuPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 260);
            this.Controls.Add(this.GameInfoLabel);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.BaseDebugBtn);
            this.Controls.Add(this.DisableDebugBtn);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine0);
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


        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        ///--     Page-Specific Variables     --\\\
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        #region Page-Specific Variables

        private Thread DebugScanThread;
        public static bool IsActiveFilePCExe, MainStreamIsOpen;

        private static string ActiveFilePath;

        private int
            GuessedDebug,
            Game
        ;

        /// <summary> Byte Array Used To Find The Address To Enable The Debug Mode In T1X PC </summary>
        private readonly byte[]
            DebugDat = new byte[] { 0x8a, 0x8f, 0xf2, 0x3e, 0x00, 0x00, 0x84, 0xc9, 0x0f, 0x94, 0xc2, 0x84, 0xc9, 0x0f, 0x95, 0xc1, 0x88, 0x8f, 0x3d, 0x3f, 0x00, 0x00, 0x88, 0x97, 0x2f, 0x3f, 0x00, 0x00 } // Used To Find Debug Mode Addr In PC Executables, From What I Remember
        ;

        private byte[] LocalExecutableCheck;

        #endregion

        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        ///--     Page-Specific Functions     --\\\
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        #region Page-Specific Functions

        private void BrowseButton_Click(object sender, EventArgs e) {
            FileDialog FileDialog = new OpenFileDialog {
                Filter = "Executable|*.exe",
                Title = "Select Either Of The Game's Executables"
            };

            if(FileDialog.ShowDialog() == DialogResult.OK) {
                BrowseButtonOverride ^= true;
                LocalExecutableCheck = new byte[8];
                ActiveFilePath = ExecutablePathBox.Text = FileDialog.FileName;
                FileDialog.Dispose();

                MainStream = new FileStream(FileDialog.FileName, FileMode.Open, FileAccess.ReadWrite);

                MainStreamIsOpen = true;

                MainStream.Position = 0x1EC; MainStream.Read(LocalExecutableCheck, 0, 4);
                Game = BitConverter.ToInt32(LocalExecutableCheck, 0);
                MainStream.Position = 0x1F8; MainStream.Read(LocalExecutableCheck, 0, 4);
                Game += BitConverter.ToInt32(LocalExecutableCheck, 0);

                Common.ActiveGameID = GameInfoLabel.Text = UpdateGameInfoLabel();
            }
        }

        bool BrowseButtonOverride = false;
        /// <summary> Load A File For Checking/Patching If The Path In The ExecutablePathBox Exists </summary>
        private void ExecutablePathBox_TextChanged(object sender, EventArgs e) {
            if(BrowseButtonOverride) {
                BrowseButtonOverride ^= true;
                return;
            }

            var TextBoxData = ((Control)sender).Text.Replace("\"", "");
            if(!File.Exists(TextBoxData))
                return;

            ActiveFilePath = TextBoxData;
            MainStream = new FileStream(ActiveFilePath, FileMode.Open, FileAccess.ReadWrite);
            MainStreamIsOpen = true;
            
            var LocalExecutableCheck = new byte[8];
            MainStream.Position = 0x1EC; MainStream.Read(LocalExecutableCheck, 0, 4);
            Game = BitConverter.ToInt32(LocalExecutableCheck, 0);
            MainStream.Position = 0x1F8; MainStream.Read(LocalExecutableCheck, 0, 4);
            Game += BitConverter.ToInt32(LocalExecutableCheck, 0);

            GameInfoLabel.Text = UpdateGameInfoLabel();
        }

        /// <summary> Compare Data Read At The Given Address
        /// </summary>
        /// <returns> True If The Data Read Matches The Array Given </returns>
        public bool CompareBytes(int Address, byte[] DataToCompare) {
            var DataPresent = new byte[DataToCompare.Length];

            MainStream.Position = Address;
            MainStream.Read(DataPresent, 0, DataToCompare.Length);

            return DataPresent.SequenceEqual(DataToCompare);
        }

        private void ScanForDebugAddr() { 
            int TmpAddr = 0;
            LocalExecutableCheck = new byte[28];
            string StartTime = DateTime.Now.ToString();

Read:       MainStream.Position = TmpAddr++;
            MainStream.Read(LocalExecutableCheck, 0, 28);
            if (LocalExecutableCheck.SequenceEqual(DebugDat))
                goto Read;

            GuessedDebug = (int)MainStream.Position - 5;
            MainStream.Position = GuessedDebug;
            MainStream.WriteByte(0x8F);
            
            MessageBox.Show($"0x8F Written At {GuessedDebug:X}\nStart Time: {StartTime} -> End Time: {DateTime.Now}", "That Should Work");
        }

        public string UpdateGameInfoLabel() {
            var VersionString = $"Unknown Version {BitConverter.ToString(LocalExecutableCheck):X}";

            switch (Game) {
                default:

                    var MBB = MessageBoxButtons.YesNo;
                    if(MessageBox.Show("Couldn't Determine The Version You Selected, So The Debug Offset Can't Be Guessed.\nScan Exe For Dev Menu Offset Instead?\n\n(If nothing's found after ~5 minutes, it probably never will.)", "This Might Take A Couple Minutes", MBB)
                        == DialogResult.No)
                        break;
                        
                    DebugScanThread = new Thread(new ThreadStart(ScanForDebugAddr));
                    DebugScanThread.Start();

                    break;
                case T1X101:
                    VersionString = "Original Release";
                     if (!CompareBytes(0x3B66B6, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL101:
                    VersionString = "Original Release Non-AVX";
                    if (!CompareBytes(0x3B64A2, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1X1015:
                    VersionString = "1.01.5 Release";
                    if (!CompareBytes(0x3B68E6, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL1015:
                    VersionString = "1.01.5 Release Non-AVX";
                    if (!CompareBytes(0x3B66D2, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1X1016:
                    VersionString = "1.01.6 Release";
                    if (!CompareBytes(0x3B68F6, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL1016:
                    VersionString = "1.01.6 Release Non-AVX";
                    if (!CompareBytes(0x3B66D2, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1X1017:
                    VersionString = "1.01.7 Release";
                    if (!CompareBytes(0x3B6A17, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL1017:
                    VersionString = "1.01.7 Release Non-AVX";
                    if (!CompareBytes(0x3B67F3, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1X102:
                    VersionString = "1.02 Release";
                    if (!CompareBytes(0x3B6A92, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL102:
                    VersionString = "1.02 Release Non-AVX";
                    if (!CompareBytes(0x3B686E, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
            }
            return VersionString;
        }

        private void DisableDebugBtn_Click(object sender, EventArgs e) {
            if(Game == 0) {
                (FlashThread = new Thread(LabelFlashMethod)).Start("GameInfoLabel");
                
                SetInfoLabelText("Please Select A Game's Executable First");
                Common.InfoHasImportantStr = true;
                return;
            }

            int DebugAddr = 0xBADBEEF;

            switch(Game) {
                case T1X101:
                    DebugAddr = T1X101Debug;
                    break;
                case T1XL101:
                    DebugAddr = T1XL101Debug;
                    break;
                case T1X1015:
                    DebugAddr = T1X1015Debug;
                    break;
                case T1XL1015:
                    DebugAddr = T1XL1015Debug;
                    break;
                case T1X1016:
                    DebugAddr = T1X1016Debug;
                    break;
                case T1XL1016:
                    DebugAddr = T1XL1016Debug;
                    break;
                case T1X1017:
                    DebugAddr = T1X1017Debug;
                    break;
                case T1XL1017:
                    DebugAddr = T1XL1017Debug;
                    break;
                case T1X102:
                    DebugAddr = T1X102Debug;
                    break;
                case T1XL102:
                    DebugAddr = T1XL102Debug;
                    break;
            }
            WriteByte(DebugAddr, 0x97);
        }

        private void BaseDebugBtn_Click(object sender, EventArgs e) {
            if (Game == 0) {
                (FlashThread = new Thread(LabelFlashMethod)).Start("GameInfoLabel");
            
                SetInfoLabelText("Please Select A Game's Executable First");
                InfoHasImportantStr = true;
                return;
            }

            int DebugAddr = 0xBADBEEF;

            switch (Game) {
                case T1X101:
                    DebugAddr = T1X101Debug;
                    break;
                case T1XL101:
                    DebugAddr = T1XL101Debug;
                    break;
                case T1X1015:
                    DebugAddr = T1X1015Debug;
                    break;
                case T1XL1015:
                    DebugAddr = T1XL1015Debug;
                    break;
                case T1X1016:
                    DebugAddr = T1X1016Debug;
                    break;
                case T1XL1016:
                    DebugAddr = T1XL1016Debug;
                    break;
                case T1X1017:
                    DebugAddr = T1X1017Debug;
                    break;
                case T1XL1017:
                    DebugAddr = T1XL1017Debug;
                    break;
                case T1X102:
                    DebugAddr = T1X102Debug;
                    break;
                case T1XL102:
                    DebugAddr = T1XL102Debug;
                    break;
            }
            WriteByte(DebugAddr, 0x8F);
        }
        #endregion


        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Repeated Page Functions & Control Declarations     --\\\
        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Repeat Functions & Control Declarations
        
        
        public Label MainLabel;
        public Button CreditsBtn;
        public Button InfoHelpBtn;
        public Label Info;
        public Label SeperatorLine0;
        public Label SeperatorLine2;
        public Label SeperatorLine1;
        public Label GameInfoLabel;
        private Button BrowseButton;
        private TextBox ExecutablePathBox;
        public Button BackBtn;
        public Button DisableDebugBtn;
        public Button BaseDebugBtn;
        #endregion
    }
}
