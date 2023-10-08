﻿using System;
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


        public static int GuessedDebug, Game;
        public static Thread DebugScanThread = new Thread(new ThreadStart(ScanForDebugAddr));

        public void InitializeComponent() {
            this.MainLabel = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.BorderBox = new System.Windows.Forms.GroupBox();
            this.GameInfoLabel = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ExecutablePathBox = new System.Windows.Forms.TextBox();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.BaseDebugBtn = new System.Windows.Forms.Button();
            this.DownloadIllusionPluginBtn = new System.Windows.Forms.Button();
            this.DisableDebugBtn = new System.Windows.Forms.Button();
            this.BorderBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.25F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(2, 4);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(314, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "PC Debug Menu Page";
            this.MainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MainLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.DimGray;
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
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            this.ExitBtn.MouseEnter += new System.EventHandler(this.ExitBtnMH);
            this.ExitBtn.MouseLeave += new System.EventHandler(this.ExitBtnML);
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.BackColor = System.Drawing.Color.DimGray;
            this.MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MinimizeBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimizeBtn.Location = new System.Drawing.Point(270, 1);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new System.Drawing.Size(23, 23);
            this.MinimizeBtn.TabIndex = 19;
            this.MinimizeBtn.Text = "--";
            this.MinimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MinimizeBtn.UseVisualStyleBackColor = false;
            this.MinimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            this.MinimizeBtn.MouseEnter += new System.EventHandler(this.MinimizeBtnMH);
            this.MinimizeBtn.MouseLeave += new System.EventHandler(this.MinimizeBtnML);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(9, 272);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=====================================";
            this.Info.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Info.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.Info.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.DimGray;
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 223);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(75, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 198);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InfoHelpBtn.Size = new System.Drawing.Size(147, 23);
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
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 14);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine0.TabIndex = 31;
            this.SeperatorLine0.Text = "______________________________________________________________";
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(3, 172);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine2.TabIndex = 32;
            this.SeperatorLine2.Text = "______________________________________________________________";
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
            this.BorderBox.Location = new System.Drawing.Point(0, -6);
            this.BorderBox.Name = "BorderBox";
            this.BorderBox.Size = new System.Drawing.Size(320, 295);
            this.BorderBox.TabIndex = 34;
            this.BorderBox.TabStop = false;
            // 
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.GameInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GameInfoLabel.Location = new System.Drawing.Point(2, 163);
            this.GameInfoLabel.Name = "GameInfoLabel";
            this.GameInfoLabel.Size = new System.Drawing.Size(316, 19);
            this.GameInfoLabel.TabIndex = 40;
            this.GameInfoLabel.Text = "No File Selected";
            this.GameInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 248);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 41;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.DimGray;
            this.BrowseButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BrowseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BrowseButton.Location = new System.Drawing.Point(239, 137);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 39;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ExecutablePathBox
            // 
            this.ExecutablePathBox.BackColor = System.Drawing.Color.Gray;
            this.ExecutablePathBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.ExecutablePathBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ExecutablePathBox.Location = new System.Drawing.Point(7, 137);
            this.ExecutablePathBox.Name = "ExecutablePathBox";
            this.ExecutablePathBox.Size = new System.Drawing.Size(233, 23);
            this.ExecutablePathBox.TabIndex = 38;
            this.ExecutablePathBox.Text = " Select An exe To Modify";
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 103);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine1.TabIndex = 36;
            this.SeperatorLine1.Text = "______________________________________________________________";
            // 
            // BaseDebugBtn
            // 
            this.BaseDebugBtn.BackColor = System.Drawing.Color.DimGray;
            this.BaseDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BaseDebugBtn.FlatAppearance.BorderSize = 0;
            this.BaseDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaseDebugBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BaseDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BaseDebugBtn.Location = new System.Drawing.Point(1, 60);
            this.BaseDebugBtn.Name = "BaseDebugBtn";
            this.BaseDebugBtn.Size = new System.Drawing.Size(231, 23);
            this.BaseDebugBtn.TabIndex = 20;
            this.BaseDebugBtn.Text = "Enable The Default Debug Menus";
            this.BaseDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BaseDebugBtn.UseVisualStyleBackColor = false;
            this.BaseDebugBtn.Click += new System.EventHandler(this.BaseDebugBtn_Click);
            // 
            // DownloadIllusionPluginBtn
            // 
            this.DownloadIllusionPluginBtn.BackColor = System.Drawing.Color.DimGray;
            this.DownloadIllusionPluginBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DownloadIllusionPluginBtn.FlatAppearance.BorderSize = 0;
            this.DownloadIllusionPluginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadIllusionPluginBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.DownloadIllusionPluginBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DownloadIllusionPluginBtn.Location = new System.Drawing.Point(1, 85);
            this.DownloadIllusionPluginBtn.Name = "DownloadIllusionPluginBtn";
            this.DownloadIllusionPluginBtn.Size = new System.Drawing.Size(318, 23);
            this.DownloadIllusionPluginBtn.TabIndex = 37;
            this.DownloadIllusionPluginBtn.Text = "Download Illusion\'s Restored Menu Plugin...";
            this.DownloadIllusionPluginBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DownloadIllusionPluginBtn.UseVisualStyleBackColor = false;
            this.DownloadIllusionPluginBtn.Click += new System.EventHandler(this.DownloadIllusionPluginBtn_Click);
            // 
            // DisableDebugBtn
            // 
            this.DisableDebugBtn.BackColor = System.Drawing.Color.DimGray;
            this.DisableDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisableDebugBtn.FlatAppearance.BorderSize = 0;
            this.DisableDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisableDebugBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
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
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 288);
            this.Controls.Add(this.DownloadIllusionPluginBtn);
            this.Controls.Add(this.DisableDebugBtn);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.BaseDebugBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine0);
            this.Controls.Add(this.SeperatorLine2);
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


        #region RepeatedButtonFunctions
        /////////////////\\\\\\\\\\\\\\\\\\
        ///--     Repeat Buttons      --\\\
        /////////////////\\\\\\\\\\\\\\\\\\\
        public void MoveForm(object sender, MouseEventArgs e) => Common.MoveForm(sender, e);
        public void MouseUpFunc(object sender, MouseEventArgs e) => Common.MouseUpFunc(sender, e);
        public void MouseDownFunc(object sender, MouseEventArgs e) => Common.MouseDownFunc(sender, e);

        public void ExitBtn_Click(object sender, EventArgs e) => Environment.Exit(0);
        public void ExitBtnMH(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void ExitBtnML(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 255, 255);

        public void MinimizeBtn_Click(object sender, EventArgs e) => ActiveForm.WindowState = FormWindowState.Minimized;
        public void MinimizeBtnMH(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void MinimizeBtnML(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 255, 255);

        private void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(InfoHelpPageId);
        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(CreditsPageId);
        private void BackBtn_Click(object sender, EventArgs e) => BackFunc();
        #endregion

        #region Page-Specific Functions
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        ///--     Page-Specific Functions     --\\\
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        private void BrowseButton_Click(object sender, EventArgs e) {
            if(e == null) {
                GameInfoLabel.Text = "Select An Executable To Patch First.";
                Refresh();
            }
            FileDialog f = new OpenFileDialog {
                Filter = "Executable|*.exe",
                Title = "Select Either Of The Game's Executables"
            };
            if(f.ShowDialog() == DialogResult.OK) {
                ActiveFilePath = ExecutablePathBox.Text = f.FileName;
                MainStream = new FileStream(f.FileName, FileMode.Open, FileAccess.ReadWrite);

                MainStream.Position = 0x1EC; MainStream.Read(LocalExecutableCheck, 0, 4);
                Game = BitConverter.ToInt32(LocalExecutableCheck, 0);
                MainStream.Position = 0x1F8; MainStream.Read(LocalExecutableCheck, 0, 4);
                Game += BitConverter.ToInt32(LocalExecutableCheck, 0);

                GameInfoLabel.Text = UpdateGameInfoLabel();
                IsActiveFilePCExe = true;
                MainStreamIsOpen = true;
                if(!Dev.REL) Console.Clear();
            }
        }

        private static void ScanForDebugAddr() { 
            int TmpAddr = 0;
            LocalExecutableCheck = new byte[28];
            string StartTime = DateTime.Now.ToString();
Read:       MainStream.Position = TmpAddr;
            MainStream.Read(LocalExecutableCheck, 0, 28);
            TmpAddr++;
            if (LocalExecutableCheck.SequenceEqual(DebugDat)) {
                GuessedDebug = (int)MainStream.Position - 5;
                MainStream.Position = GuessedDebug;
                MainStream.WriteByte(0x8F);
                MessageBox.Show($"0x8F Written At {GuessedDebug:X}\nStart Time: {StartTime} -> End Time: {DateTime.Now}");
                return;
            }
            else goto Read;
        }

        public string UpdateGameInfoLabel() { //!
            var VersionString = $"Unknown Version {BitConverter.ToString(LocalExecutableCheck):X}";

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

        private void DisableDebugBtn_Click(object sender, EventArgs e) {
            if(Game == 0) {
                if(!FlashThreadHasStarted) {
                    FlashThread.Start();
                    FlashThreadHasStarted = true;
                }
                LabelShouldFlash = true;
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
        private void DownloadIllusionPluginBtn_Click(object sender, EventArgs e) { //!
            //  System.Diagnostics.Process.Start("Download Link Here");
            MessageBox.Show("W.I.P., I Was Too Lazy To Find The Link So Here's A Temp Message Box Explaining It", "Temp Message Box");
        }
        #endregion

        #region ControlDeclarations
        ////////////////////\\\\\\\\\\\\\\\\\\\\
        ///--     Control Declarations     --\\\
        ////////////////////\\\\\\\\\\\\\\\\\\\\
        public Label MainLabel;
        public Button CreditsBtn;
        public Button InfoHelpBtn;
        public Label Info;
        public Button ExitBtn;
        public Button MinimizeBtn;
        public Label SeperatorLine0;
        public Label SeperatorLine2;
        private GroupBox BorderBox;
        public Label SeperatorLine1;
        public Label GameInfoLabel;
        private Button BrowseButton;
        private TextBox ExecutablePathBox;
        public Button DownloadIllusionPluginBtn;
        public Button BackBtn;
        public Button DisableDebugBtn;
        public Button BaseDebugBtn;
        #endregion
    }
}
