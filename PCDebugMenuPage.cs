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
            AddControlEventHandlers(Controls);

            if (ActiveFilePath != null && IsActiveFilePCExe)
                ExecutablePathBox.Text = ActiveFilePath;
        }

        public Label MainLabel;
        public Button CreditsBtn;
        public Button InfoHelpBtn;
        public Label Info;
        public Button ExitBtn;
        public Button MinimizeBtn;
        public Label SeperatorLine1;
        public Label label5;
        private GroupBox BorderBox;
        public Label label6;
        public Label GameInfoLabel;
        private Button BrowseButton;
        private TextBox ExecutablePathBox;
        public Button RestoredDebugBtn;
        public Button BackBtn;
        public Button DisableDebugBtn;
        public Button BaseDebugBtn;

        public static int GuessedDebug;

        public void InitializeComponent() {
            this.MainLabel = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BorderBox = new System.Windows.Forms.GroupBox();
            this.GameInfoLabel = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ExecutablePathBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BaseDebugBtn = new System.Windows.Forms.Button();
            this.RestoredDebugBtn = new System.Windows.Forms.Button();
            this.DisableDebugBtn = new System.Windows.Forms.Button();
            this.BorderBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new Font("Franklin Gothic Medium", 12.25F, FontStyle.Bold);
            this.MainLabel.ForeColor = SystemColors.Control;
            this.MainLabel.Location = new Point(2, 4);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new Size(314, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "PC Debug Menu Page";
            this.MainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MainLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = Color.DimGray;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = SystemColors.Control;
            this.ExitBtn.Location = new Point(293, 1);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new Size(23, 23);
            this.ExitBtn.TabIndex = 18;
            this.ExitBtn.Text = "X";
            this.ExitBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            this.ExitBtn.MouseEnter += new System.EventHandler(this.ExitBtnMH);
            this.ExitBtn.MouseLeave += new System.EventHandler(this.ExitBtnML);
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.BackColor = Color.DimGray;
            this.MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MinimizeBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBtn.Font = new Font("Franklin Gothic Medium", 8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBtn.ForeColor = SystemColors.Control;
            this.MinimizeBtn.Location = new Point(270, 1);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new Size(23, 23);
            this.MinimizeBtn.TabIndex = 19;
            this.MinimizeBtn.Text = "--";
            this.MinimizeBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.MinimizeBtn.UseVisualStyleBackColor = false;
            this.MinimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            this.MinimizeBtn.MouseEnter += new System.EventHandler(this.MinimizeBtnMH);
            this.MinimizeBtn.MouseLeave += new System.EventHandler(this.MinimizeBtnML);
            // 
            // Info
            // 
            this.Info.Font = new Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new Point(9, 272);
            this.Info.Name = "Info";
            this.Info.Size = new Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=====================================";
            this.Info.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Info.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.Info.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = Color.DimGray;
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.CreditsBtn.ForeColor = SystemColors.Control;
            this.CreditsBtn.Location = new Point(1, 223);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new Size(75, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = Color.DimGray;
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = SystemColors.Control;
            this.InfoHelpBtn.Location = new Point(1, 198);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InfoHelpBtn.Size = new Size(147, 23);
            this.InfoHelpBtn.TabIndex = 29;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine1.ForeColor = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new Point(2, 14);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new Size(316, 16);
            this.SeperatorLine1.TabIndex = 31;
            this.SeperatorLine1.Text = "______________________________________________________________";
            // 
            // label5
            // 
            this.label5.Font = new Font("Franklin Gothic Medium", 10F);
            this.label5.ForeColor = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label5.Location = new Point(3, 172);
            this.label5.Name = "label5";
            this.label5.Size = new Size(316, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "______________________________________________________________";
            // 
            // BorderBox
            // 
            this.BorderBox.Controls.Add(this.GameInfoLabel);
            this.BorderBox.Controls.Add(this.BackBtn);
            this.BorderBox.Controls.Add(this.BrowseButton);
            this.BorderBox.Controls.Add(this.ExecutablePathBox);
            this.BorderBox.Controls.Add(this.Info);
            this.BorderBox.Controls.Add(this.InfoHelpBtn);
            this.BorderBox.Controls.Add(this.CreditsBtn);
            this.BorderBox.Location = new Point(0, -6);
            this.BorderBox.Name = "BorderBox";
            this.BorderBox.Size = new Size(320, 295);
            this.BorderBox.TabIndex = 34;
            this.BorderBox.TabStop = false;
            // 
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new Font("Franklin Gothic Medium", 10F);
            this.GameInfoLabel.ForeColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GameInfoLabel.Location = new Point(2, 163);
            this.GameInfoLabel.Name = "GameInfoLabel";
            this.GameInfoLabel.Size = new Size(316, 19);
            this.GameInfoLabel.TabIndex = 40;
            this.GameInfoLabel.Text = "No File Selected";
            this.GameInfoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.BackBtn.ForeColor = SystemColors.Control;
            this.BackBtn.Location = new Point(1, 248);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BackBtn.Size = new Size(75, 23);
            this.BackBtn.TabIndex = 41;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = Color.DimGray;
            this.BrowseButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.BrowseButton.ForeColor = SystemColors.Control;
            this.BrowseButton.Location = new Point(239, 137);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new Size(75, 23);
            this.BrowseButton.TabIndex = 39;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.TextAlign = ContentAlignment.MiddleLeft;
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ExecutablePathBox
            // 
            this.ExecutablePathBox.BackColor = Color.Gray;
            this.ExecutablePathBox.Font = new Font("Franklin Gothic Medium", 10F);
            this.ExecutablePathBox.ForeColor = SystemColors.Window;
            this.ExecutablePathBox.Location = new Point(7, 137);
            this.ExecutablePathBox.Name = "ExecutablePathBox";
            this.ExecutablePathBox.Size = new Size(233, 23);
            this.ExecutablePathBox.TabIndex = 38;
            this.ExecutablePathBox.Text = " Select An exe To Modify";
            // 
            // label6
            // 
            this.label6.Font = new Font("Franklin Gothic Medium", 10F);
            this.label6.ForeColor = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label6.Location = new Point(2, 103);
            this.label6.Name = "label6";
            this.label6.Size = new Size(316, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "______________________________________________________________";
            // 
            // BaseDebugBtn
            // 
            this.BaseDebugBtn.BackColor = Color.DimGray;
            this.BaseDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BaseDebugBtn.FlatAppearance.BorderSize = 0;
            this.BaseDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaseDebugBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.BaseDebugBtn.ForeColor = SystemColors.Control;
            this.BaseDebugBtn.Location = new Point(1, 35);
            this.BaseDebugBtn.Name = "BaseDebugBtn";
            this.BaseDebugBtn.Size = new Size(231, 23);
            this.BaseDebugBtn.TabIndex = 20;
            this.BaseDebugBtn.Text = "Enable The Default Debug Menus";
            this.BaseDebugBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.BaseDebugBtn.UseVisualStyleBackColor = false;
            this.BaseDebugBtn.Click += new System.EventHandler(this.BaseDebugBtn_Click);
            // 
            // RestoredDebugBtn
            // 
            this.RestoredDebugBtn.BackColor = Color.DimGray;
            this.RestoredDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.RestoredDebugBtn.FlatAppearance.BorderSize = 0;
            this.RestoredDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestoredDebugBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.RestoredDebugBtn.ForeColor = SystemColors.Control;
            this.RestoredDebugBtn.Location = new Point(1, 60);
            this.RestoredDebugBtn.Name = "RestoredDebugBtn";
            this.RestoredDebugBtn.Size = new Size(299, 23);
            this.RestoredDebugBtn.TabIndex = 37;
            this.RestoredDebugBtn.Text = "Enable Debug Menu And Restore Submenus";
            this.RestoredDebugBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.RestoredDebugBtn.UseVisualStyleBackColor = false;
            this.RestoredDebugBtn.Click += new System.EventHandler(this.RestoredDebugBtn_Click);
            // 
            // DisableDebugBtn
            // 
            this.DisableDebugBtn.BackColor = Color.DimGray;
            this.DisableDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisableDebugBtn.FlatAppearance.BorderSize = 0;
            this.DisableDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisableDebugBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.DisableDebugBtn.ForeColor = SystemColors.Control;
            this.DisableDebugBtn.Location = new Point(1, 85);
            this.DisableDebugBtn.Name = "DisableDebugBtn";
            this.DisableDebugBtn.Size = new Size(184, 23);
            this.DisableDebugBtn.TabIndex = 38;
            this.DisableDebugBtn.Text = "Disable The Debug Menus";
            this.DisableDebugBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.DisableDebugBtn.UseVisualStyleBackColor = false;
            this.DisableDebugBtn.Click += new System.EventHandler(this.DisableDebugBtn_Click);
            // 
            // PCDebugMenuPage
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.DimGray;
            this.ClientSize = new Size(320, 288);
            this.Controls.Add(this.RestoredDebugBtn);
            this.Controls.Add(this.DisableDebugBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BaseDebugBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BorderBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PCDebugMenuPage";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.BorderBox.ResumeLayout(false);
            this.BorderBox.PerformLayout();
            this.ResumeLayout(false);

        }
        public void MoveForm(object sender, MouseEventArgs e) => Common.MoveForm(sender, e);
        public void MouseUpFunc(object sender, MouseEventArgs e) => Common.MouseUpFunc(sender, e);
        public void MouseDownFunc(object sender, MouseEventArgs e) => Common.MouseDownFunc(sender, e);

        public void ExitBtn_Click(object sender, EventArgs e) => Environment.Exit(0);
        public void ExitBtnMH(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void ExitBtnML(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 255, 255);

        public void MinimizeBtn_Click(object sender, EventArgs e) => ActiveForm.WindowState = FormWindowState.Minimized;
        public void MinimizeBtnMH(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void MinimizeBtnML(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 255, 255);

        public static Thread DebugScanThread = new Thread(new ThreadStart(ScanForDebugAddr));
        public static void ScanForDebugAddr() { 
            int TmpAddr = 0;
            chk = new byte[28];
            string StartTime = DateTime.Now.ToString();
Read:       MainStream.Position = TmpAddr;
            MainStream.Read(chk, 0, 28);
            TmpAddr++;
            if (chk.SequenceEqual(DebugDat)) {
                GuessedDebug = (int)MainStream.Position - 5;
                MainStream.Position = GuessedDebug;
                MainStream.WriteByte(0x8F);
                MessageBox.Show($"0x8F Written At {GuessedDebug:X}\nStart Time: {StartTime} -> End Time: {DateTime.Now}");
                return;
            }
            else goto Read;
        }

        public string UpdateGameInfoLabel() { //!
            var VersionString = $"Unknown Version {BitConverter.ToString(chk):X}";

            switch (Game) {
                default:
                    MessageBoxButtons MBB = MessageBoxButtons.YesNo;
                    if (MessageBox.Show("Couldn't Determine The Version You Selected, So The Debug Offset Can't Be Guessed.\nScan Exe For Dev Menu Offset Instead?\n\n(If nothing's found after ~5 minutes, it probably never will.)", "This Might Take A Couple Minutes", MBB) == DialogResult.Yes)
                        DebugScanThread.Start();

                    break;
                case T1X101:
                    VersionString = "Original Release";
                     if (!ArrayCmp(0x3B66B6, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL101:
                    VersionString = "Original Release Non-AVX";
                    if (!ArrayCmp(0x3B64A2, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1X1015:
                    VersionString = "1.01.5 Release";
                    if (!ArrayCmp(0x3B68E6, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL1015:
                    VersionString = "1.01.5 Release Non-AVX";
                    if (!ArrayCmp(0x3B66D2, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1X1016:
                    VersionString = "1.01.6 Release";
                    if (!ArrayCmp(0x3B68F6, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL1016:
                    VersionString = "1.01.6 Release Non-AVX";
                    if (!ArrayCmp(0x3B66D2, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1X1017:
                    VersionString = "1.01.7 Release";
                    if (!ArrayCmp(0x3B6A17, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL1017:
                    VersionString = "1.01.7 Release Non-AVX";
                    if (!ArrayCmp(0x3B67F3, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1X102:
                    VersionString = "1.02 Release";
                    if (!ArrayCmp(0x3B6A92, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL102:
                    VersionString = "1.02 Release Non-AVX";
                    if (!ArrayCmp(0x3B686E, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
            }
            return VersionString;
        }

        private void BrowseButton_Click(object sender, EventArgs e) {
            if (e == null) {
                GameInfoLabel.Text = "Select An Executable To Patch First.";
                Refresh();
            }
            FileDialog f = new OpenFileDialog {
                Filter = "Executable|*.exe",
                Title = "Select Either Of The Game's Executables"
            };
            if (f.ShowDialog() == DialogResult.OK) {
                ActiveFilePath = ExecutablePathBox.Text = f.FileName;
                MainStream = new FileStream(f.FileName, FileMode.Open, FileAccess.ReadWrite);

                MainStream.Position = 0x1EC; MainStream.Read(chk, 0, 4);
                Game = BitConverter.ToInt32(chk, 0);
                MainStream.Position = 0x1F8; MainStream.Read(chk, 0, 4);
                Game += BitConverter.ToInt32(chk, 0);

                GameInfoLabel.Text = UpdateGameInfoLabel();
                IsActiveFilePCExe = true;
                MainStreamIsOpen = true;
                if (!Dev.REL) Console.Clear();
            }
        }

        private void BaseDebugBtn_Click(object sender, EventArgs e) {
            if (Game == 0) {
                if (!FlashThreadHasStarted) {
                    FlashThread.Start();
                    FlashThreadHasStarted = true;
                }
                LabelShouldFlash = true;
                SetInfoLabelText("Please Select A Game's Executable First");
                Common.InfoHasImportantStr = true;
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

        private void RestoredDebugBtn_Click(object sender, EventArgs e) {
            if (Game == 0) {
                if (!FlashThreadHasStarted) {
                    FlashThread.Start();
                    FlashThreadHasStarted = true;
                }
                LabelShouldFlash = true;
                SetInfoLabelText("Please Select A Game's Executable First");
                Common.InfoHasImportantStr = true;
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
            SetInfoLabelText("Heap Rederict By: "); //!
        }

        private void DisableDebugBtn_Click(object sender, EventArgs e) {
            if (Game == 0) {
                if (!FlashThreadHasStarted) {
                    FlashThread.Start();
                    FlashThreadHasStarted = true;
                }
                LabelShouldFlash = true;
                SetInfoLabelText("Please Select A Game's Executable First");
                Common.InfoHasImportantStr = true;
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
            WriteByte(DebugAddr, 0x97);
        }

        private void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(5, false);

        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(8, false);

        private void BackBtn_Click(object sender, EventArgs e) => BackFunc();
    }
}
