using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dobby.Common;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Dobby {
    internal class PS4QOLPatchesPage : Form {
        public PS4QOLPatchesPage() {
            InitializeComponent();
#if DEBUG
            if (FormResetThread.ThreadState != ThreadState.Running)
            FormResetThread.Start();
#endif
        }

        public Label MainLabel;
        public Button CreditsBtn;
        public Button InfoHelpBtn;
        public Label Info;
        public Button ExitBtn;
        public Button MinimizeBtn;
        public Label SeperatorLabel0;
        public GroupBox BorderBox;
        public Label SeperatorLabel2;
        public Label GameInfoLabel;
        private Button BrowseButton;
        private TextBox ExecutablePathBox;
        public Button DisableDebugTextBtn;
        public Button ProgPauseOnOpenBtn;
        public Button RightMarginBtn;
        public Button MenuRightAlignBtn;
        public Button MenuScaleBtn;
        public Button MenuAlphaBtn;
        public Label UniversalPatchesLabel;
        public Label GameSpecificPatchesLabel;
        public Label SeperatorLabel3;
        public Label SeperatorLabel1;
        public Label CustomDebugOptionsLabel;
        public Button ResetBtn;
        public Button ProgPauseOnCloseBtn;
        public Button BackBtn;

        public void InitializeComponent() {
            this.MainLabel = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.SeperatorLabel0 = new System.Windows.Forms.Label();
            this.BorderBox = new System.Windows.Forms.GroupBox();
            this.ProgPauseOnCloseBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.CustomDebugOptionsLabel = new System.Windows.Forms.Label();
            this.UniversalPatchesLabel = new System.Windows.Forms.Label();
            this.GameSpecificPatchesLabel = new System.Windows.Forms.Label();
            this.ProgPauseOnOpenBtn = new System.Windows.Forms.Button();
            this.GameInfoLabel = new System.Windows.Forms.Label();
            this.SeperatorLabel3 = new System.Windows.Forms.Label();
            this.DisableDebugTextBtn = new System.Windows.Forms.Button();
            this.RightMarginBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.MenuRightAlignBtn = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ExecutablePathBox = new System.Windows.Forms.TextBox();
            this.SeperatorLabel1 = new System.Windows.Forms.Label();
            this.SeperatorLabel2 = new System.Windows.Forms.Label();
            this.MenuScaleBtn = new System.Windows.Forms.Button();
            this.MenuAlphaBtn = new System.Windows.Forms.Button();
            this.BorderBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.25F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(2, 7);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(314, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Misc. PS4  Patches Page";
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
            this.ExitBtn.Location = new System.Drawing.Point(293, 7);
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
            this.MinimizeBtn.Location = new System.Drawing.Point(270, 7);
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
            this.Info.Location = new System.Drawing.Point(5, 379);
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
            this.CreditsBtn.Location = new System.Drawing.Point(1, 332);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(75, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            this.CreditsBtn.MouseEnter += new System.EventHandler(this.CreditsBtnMH);
            this.CreditsBtn.MouseLeave += new System.EventHandler(this.CreditsBtnML);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 309);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InfoHelpBtn.Size = new System.Drawing.Size(147, 23);
            this.InfoHelpBtn.TabIndex = 29;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            this.InfoHelpBtn.MouseEnter += new System.EventHandler(this.InfoHelpBtnMH);
            this.InfoHelpBtn.MouseLeave += new System.EventHandler(this.InfoHelpBtnML);
            // 
            // SeperatorLabel0
            // 
            this.SeperatorLabel0.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel0.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLabel0.Name = "SeperatorLabel0";
            this.SeperatorLabel0.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLabel0.TabIndex = 31;
            this.SeperatorLabel0.Text = "______________________________________________________________";
            // 
            // BorderBox
            // 
            this.BorderBox.Controls.Add(this.ProgPauseOnCloseBtn);
            this.BorderBox.Controls.Add(this.MinimizeBtn);
            this.BorderBox.Controls.Add(this.ResetBtn);
            this.BorderBox.Controls.Add(this.CustomDebugOptionsLabel);
            this.BorderBox.Controls.Add(this.UniversalPatchesLabel);
            this.BorderBox.Controls.Add(this.GameSpecificPatchesLabel);
            this.BorderBox.Controls.Add(this.ProgPauseOnOpenBtn);
            this.BorderBox.Controls.Add(this.GameInfoLabel);
            this.BorderBox.Controls.Add(this.SeperatorLabel3);
            this.BorderBox.Controls.Add(this.DisableDebugTextBtn);
            this.BorderBox.Controls.Add(this.RightMarginBtn);
            this.BorderBox.Controls.Add(this.BackBtn);
            this.BorderBox.Controls.Add(this.MenuRightAlignBtn);
            this.BorderBox.Controls.Add(this.BrowseButton);
            this.BorderBox.Controls.Add(this.ExecutablePathBox);
            this.BorderBox.Controls.Add(this.Info);
            this.BorderBox.Controls.Add(this.InfoHelpBtn);
            this.BorderBox.Controls.Add(this.CreditsBtn);
            this.BorderBox.Controls.Add(this.SeperatorLabel1);
            this.BorderBox.Controls.Add(this.SeperatorLabel2);
            this.BorderBox.Controls.Add(this.ExitBtn);
            this.BorderBox.Controls.Add(this.MainLabel);
            this.BorderBox.Controls.Add(this.SeperatorLabel0);
            this.BorderBox.Location = new System.Drawing.Point(0, -6);
            this.BorderBox.Name = "BorderBox";
            this.BorderBox.Size = new System.Drawing.Size(320, 401);
            this.BorderBox.TabIndex = 34;
            this.BorderBox.TabStop = false;
            // 
            // ProgPauseOnCloseBtn
            // 
            this.ProgPauseOnCloseBtn.BackColor = System.Drawing.Color.DimGray;
            this.ProgPauseOnCloseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ProgPauseOnCloseBtn.FlatAppearance.BorderSize = 0;
            this.ProgPauseOnCloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProgPauseOnCloseBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.ProgPauseOnCloseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ProgPauseOnCloseBtn.Location = new System.Drawing.Point(1, 155);
            this.ProgPauseOnCloseBtn.Name = "ProgPauseOnCloseBtn";
            this.ProgPauseOnCloseBtn.Size = new System.Drawing.Size(301, 23);
            this.ProgPauseOnCloseBtn.TabIndex = 56;
            this.ProgPauseOnCloseBtn.Text = "Disable Debug Pause On Menu Close:";
            this.ProgPauseOnCloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProgPauseOnCloseBtn.UseVisualStyleBackColor = false;
            // 
            // ResetBtn
            // 
            this.ResetBtn.BackColor = System.Drawing.Color.DimGray;
            this.ResetBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ResetBtn.FlatAppearance.BorderSize = 0;
            this.ResetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.5F);
            this.ResetBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ResetBtn.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.ResetBtn.Location = new System.Drawing.Point(227, 7);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(39, 22);
            this.ResetBtn.TabIndex = 55;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ResetBtn.UseVisualStyleBackColor = false;
            this.ResetBtn.Visible = false;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // CustomDebugOptionsLabel
            // 
            this.CustomDebugOptionsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomDebugOptionsLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomDebugOptionsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CustomDebugOptionsLabel.Location = new System.Drawing.Point(3, 214);
            this.CustomDebugOptionsLabel.Name = "CustomDebugOptionsLabel";
            this.CustomDebugOptionsLabel.Size = new System.Drawing.Size(316, 19);
            this.CustomDebugOptionsLabel.TabIndex = 54;
            this.CustomDebugOptionsLabel.Text = "(Load An Executable To Show Game-Specific Options)";
            // 
            // UniversalPatchesLabel
            // 
            this.UniversalPatchesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UniversalPatchesLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.UniversalPatchesLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.UniversalPatchesLabel.Location = new System.Drawing.Point(105, 35);
            this.UniversalPatchesLabel.Name = "UniversalPatchesLabel";
            this.UniversalPatchesLabel.Size = new System.Drawing.Size(102, 19);
            this.UniversalPatchesLabel.TabIndex = 53;
            this.UniversalPatchesLabel.Text = "Universal Patches";
            // 
            // GameSpecificPatchesLabel
            // 
            this.GameSpecificPatchesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameSpecificPatchesLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.GameSpecificPatchesLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.GameSpecificPatchesLabel.Location = new System.Drawing.Point(96, 190);
            this.GameSpecificPatchesLabel.Name = "GameSpecificPatchesLabel";
            this.GameSpecificPatchesLabel.Size = new System.Drawing.Size(127, 19);
            this.GameSpecificPatchesLabel.TabIndex = 52;
            this.GameSpecificPatchesLabel.Text = "Game-Specific Patches";
            // 
            // ProgPauseOnOpenBtn
            // 
            this.ProgPauseOnOpenBtn.BackColor = System.Drawing.Color.DimGray;
            this.ProgPauseOnOpenBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ProgPauseOnOpenBtn.FlatAppearance.BorderSize = 0;
            this.ProgPauseOnOpenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProgPauseOnOpenBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.ProgPauseOnOpenBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ProgPauseOnOpenBtn.Location = new System.Drawing.Point(1, 130);
            this.ProgPauseOnOpenBtn.Name = "ProgPauseOnOpenBtn";
            this.ProgPauseOnOpenBtn.Size = new System.Drawing.Size(301, 23);
            this.ProgPauseOnOpenBtn.TabIndex = 51;
            this.ProgPauseOnOpenBtn.Text = "Disable Debug Pause On Menu Open:";
            this.ProgPauseOnOpenBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProgPauseOnOpenBtn.UseVisualStyleBackColor = false;
            // 
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.GameInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GameInfoLabel.Location = new System.Drawing.Point(2, 280);
            this.GameInfoLabel.Name = "GameInfoLabel";
            this.GameInfoLabel.Size = new System.Drawing.Size(316, 19);
            this.GameInfoLabel.TabIndex = 40;
            this.GameInfoLabel.Text = "No File Selected";
            this.GameInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SeperatorLabel3
            // 
            this.SeperatorLabel3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel3.Location = new System.Drawing.Point(2, 290);
            this.SeperatorLabel3.Name = "SeperatorLabel3";
            this.SeperatorLabel3.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLabel3.TabIndex = 32;
            this.SeperatorLabel3.Text = "______________________________________________________________";
            // 
            // DisableDebugTextBtn
            // 
            this.DisableDebugTextBtn.BackColor = System.Drawing.Color.DimGray;
            this.DisableDebugTextBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisableDebugTextBtn.FlatAppearance.BorderSize = 0;
            this.DisableDebugTextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisableDebugTextBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.DisableDebugTextBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DisableDebugTextBtn.Location = new System.Drawing.Point(1, 55);
            this.DisableDebugTextBtn.Name = "DisableDebugTextBtn";
            this.DisableDebugTextBtn.Size = new System.Drawing.Size(269, 23);
            this.DisableDebugTextBtn.TabIndex = 46;
            this.DisableDebugTextBtn.Text = "Disable 2D Debug Text On Startup: ";
            this.DisableDebugTextBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisableDebugTextBtn.UseVisualStyleBackColor = false;
            this.DisableDebugTextBtn.Click += new System.EventHandler(this.DisableDebugTextBtn_Click);
            this.DisableDebugTextBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.DisableDebugTextBtn.MouseEnter += new System.EventHandler(this.DisableDebugTextBtnMH);
            this.DisableDebugTextBtn.MouseLeave += new System.EventHandler(this.DisableDebugTextBtnML);
            this.DisableDebugTextBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.DisableDebugTextBtn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DisableDebugTextBtn_SClick);
            // 
            // RightMarginBtn
            // 
            this.RightMarginBtn.BackColor = System.Drawing.Color.DimGray;
            this.RightMarginBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.RightMarginBtn.FlatAppearance.BorderSize = 0;
            this.RightMarginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightMarginBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.RightMarginBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.RightMarginBtn.Location = new System.Drawing.Point(1, 105);
            this.RightMarginBtn.Name = "RightMarginBtn";
            this.RightMarginBtn.Size = new System.Drawing.Size(231, 23);
            this.RightMarginBtn.TabIndex = 50;
            this.RightMarginBtn.Text = "Distance From Right Side:";
            this.RightMarginBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RightMarginBtn.UseVisualStyleBackColor = false;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 355);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 41;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            this.BackBtn.MouseEnter += new System.EventHandler(this.BackBtnMH);
            this.BackBtn.MouseLeave += new System.EventHandler(this.BackBtnML);
            // 
            // MenuRightAlignBtn
            // 
            this.MenuRightAlignBtn.BackColor = System.Drawing.Color.DimGray;
            this.MenuRightAlignBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MenuRightAlignBtn.FlatAppearance.BorderSize = 0;
            this.MenuRightAlignBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuRightAlignBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.MenuRightAlignBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MenuRightAlignBtn.Location = new System.Drawing.Point(1, 80);
            this.MenuRightAlignBtn.Name = "MenuRightAlignBtn";
            this.MenuRightAlignBtn.Size = new System.Drawing.Size(301, 23);
            this.MenuRightAlignBtn.TabIndex = 49;
            this.MenuRightAlignBtn.Text = "Align Menu\'s To Right Side Of Screen: ";
            this.MenuRightAlignBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MenuRightAlignBtn.UseVisualStyleBackColor = false;
            this.MenuRightAlignBtn.Click += new System.EventHandler(this.MenuRightAlignBtn_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.DimGray;
            this.BrowseButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BrowseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BrowseButton.Location = new System.Drawing.Point(239, 254);
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
            this.ExecutablePathBox.Location = new System.Drawing.Point(7, 254);
            this.ExecutablePathBox.Name = "ExecutablePathBox";
            this.ExecutablePathBox.Size = new System.Drawing.Size(233, 23);
            this.ExecutablePathBox.TabIndex = 38;
            this.ExecutablePathBox.Text = " Select An exe To Modify";
            // 
            // SeperatorLabel1
            // 
            this.SeperatorLabel1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel1.Location = new System.Drawing.Point(2, 169);
            this.SeperatorLabel1.Name = "SeperatorLabel1";
            this.SeperatorLabel1.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLabel1.TabIndex = 37;
            this.SeperatorLabel1.Text = "______________________________________________________________";
            // 
            // SeperatorLabel2
            // 
            this.SeperatorLabel2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel2.Location = new System.Drawing.Point(2, 227);
            this.SeperatorLabel2.Name = "SeperatorLabel2";
            this.SeperatorLabel2.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLabel2.TabIndex = 36;
            this.SeperatorLabel2.Text = "______________________________________________________________";
            // 
            // MenuScaleBtn
            // 
            this.MenuScaleBtn.Location = new System.Drawing.Point(0, 0);
            this.MenuScaleBtn.Name = "MenuScaleBtn";
            this.MenuScaleBtn.Size = new System.Drawing.Size(75, 23);
            this.MenuScaleBtn.TabIndex = 0;
            // 
            // MenuAlphaBtn
            // 
            this.MenuAlphaBtn.Location = new System.Drawing.Point(0, 0);
            this.MenuAlphaBtn.Name = "MenuAlphaBtn";
            this.MenuAlphaBtn.Size = new System.Drawing.Size(75, 23);
            this.MenuAlphaBtn.TabIndex = 0;
            // 
            // PS4QOLPatchesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 394);
            this.Controls.Add(this.BorderBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PS4QOLPatchesPage";
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
        public static void ControlHover(object sender, EventArgs e) => HoverLeave((Control)sender, 0);
        public static void ControlLeave(object sender, EventArgs e) => HoverLeave((Control)sender, 1);

        public static Size OriginalFormScale = Size.Empty;
        public static Size OriginalBorderScale;
        public static Point[] OriginalControlPositions;

        /// <summary> 1: Disable FPS<br/>2: Menu Right Align<br/>3: Menu Shadowed Text<br/>4: Prog Pause On Open<br/>5: Prog Pause On Close </summary>
        static bool[] UniversalDebugBooleans = new bool[5];
        /// <summary> 1: <br/>2: <br/>3: <br/>4: <br/>5:  </summary>
        static bool[] GameSpecificDebugBooleans = new bool[3];
        /// <summary>1: Menu Alpha<br/>2: Menu Scale<br/>3: Non-ADS Field of View</summary>
        static float[] GameSpecificDebugFloats = new float[] { 0.85f, 0.6f, 1F };
        /// <summary> Variable Used When Adjusting Form Scale And Control Positions </summary>
        static int ButtonIndex = 0, RealSize = 0, Y_Axis_Addative = 0, Y_Pos;

        static int RightMargin = 10;

        static string[] ButtonTextArray = new string[] {
                "MenuScaleBtn;Set Dev Menu Scale: 0.6F;Hint",
                "MenuAlphaBtn;Set Dev Menu Background Opacity: 0.85F;Hint",
                "TestName_1;TestText_1;TestHint_1",
                "MenuShadowTextBtn;Enable Debug Menu Text Shadow: Off;Hint",
                "TestName_2;TestText_2;TestHint2",
                "FOVBtn;Adjust Non-ADS FOV;Only Effects The Camera While Not Aiming"
        };

        public static Button[] GSDebugOptions = new Button[ButtonTextArray.Length];
        /// <summary> Controls to Move When Loading >1 Extra Options </summary>
        public static Control[] ControlsToMove;


        public void ExitBtn_Click(object sender, EventArgs e) => Environment.Exit(0);
        public void ExitBtnMH(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void ExitBtnML(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 255, 255);

        public void MinimizeBtn_Click(object sender, EventArgs e) => ActiveForm.WindowState = FormWindowState.Minimized;
        public void MinimizeBtnMH(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void MinimizeBtnML(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 255, 255);

        public void ResetBtn_Click(object sender, EventArgs e) => ResetCustomOptions(true);
        public void ResetBtnMH(object sender, EventArgs e) {
            ResetBtn.ForeColor = Color.FromArgb(255, 227, 0);
            SetInfoString("Reset Page To It's Default State");
        }
        public void ResetBtnML(object sender, EventArgs e) => ResetBtn.ForeColor = Color.FromArgb(255, 255, 255);


        public void Invert(Control Control, int OptionIndex) {
            if (MouseScrolled == 1 || MouseIsDown == 0 || CurrentControl != Control.Name) {
                Dev.DebugOut($"MouseScrolled: {MouseScrolled}\nMouseIsDown: {MouseIsDown}\n CurrentControl: {CurrentControl}\nC.Name: {Control.Name}");
                return;
            }
            tmp = Control.Text;
            UniversalDebugBooleans[OptionIndex] = !UniversalDebugBooleans[OptionIndex];
            tmp = $"{tmp.Remove(tmp.LastIndexOf(' '))} {(UniversalDebugBooleans[OptionIndex] ? "On" : "Off")}";
            Control.Text = tmp;
        }

        public void LoadGameSpecificMenuOptions() {
            
            void BtnHoverString(object sender, EventArgs e) => SetInfoString(ButtonTextArray[((Control)sender).TabIndex].Substring(ButtonTextArray[((Control)sender).TabIndex].LastIndexOf(';') + 1));

            if (OriginalFormScale == Size.Empty) { // Assign values to variables made to keep track of the default form size/control postions. Going it on page init is annoying 'cause designer memes
                Dev.DebugOut("Setting Original Scale Variables");
                ControlsToMove = new Control[] {
                    ActiveForm.Controls.Find("SeperatorLabel2", true)[0],
                    ActiveForm.Controls.Find("SeperatorLabel3", true)[0],
                    ActiveForm.Controls.Find("BrowseButton", true)[0],
                    ActiveForm.Controls.Find("ExecutablePathBox", true)[0],
                    ActiveForm.Controls.Find("GameInfoLabel", true)[0],
                    ActiveForm.Controls.Find("InfoHelpBtn", true)[0],
                    ActiveForm.Controls.Find("CreditsBtn", true)[0],
                    ActiveForm.Controls.Find("BackBtn", true)[0],
                    ActiveForm.Controls.Find("Info", true)[0]
                };
                OriginalFormScale = Size;
                OriginalBorderScale = ActiveForm.Controls.Find("BorderBox", true)[0].Size;
                OriginalControlPositions = new Point[ControlsToMove.Length];
                for (int Index = 0; Index < ControlsToMove.Length - 1; Index++) {
                    OriginalControlPositions[Index] = ControlsToMove[Index].Location;
                    Dev.DebugOut($"{OriginalControlPositions[Index]}");
                }
            }
            else ResetCustomOptions(false); // if if isn't the first time using the option this boot

            Y_Pos = GameSpecificPatchesLabel.Location.Y + 20; // Right Below The Label

            switch (Game) {
                case UC1100:
                    break;
                case UC1102:
                    break;
                case UC2100:
                    break;
                case UC2102:
                    break;
                case UC3100:
                    break;
                case UC3102:
                    break;
                case T1R100:
                    break;
                case T1R109:
                    break;
                case T1R11X:
                    break;
                case T2100:
                    Dev.DebugOut("Tlou 2 1.00");
                    GSDebugOptions[0] = new Button();
                    GSDebugOptions[1] = new Button();
                    GSDebugOptions[2] = new Button();
                    GSDebugOptions[3] = new Button();
                    GSDebugOptions[4] = new Button();
                    BorderBox.Controls.Add(GSDebugOptions[0]);
                    BorderBox.Controls.Add(GSDebugOptions[1]);
                    BorderBox.Controls.Add(GSDebugOptions[2]);
                    BorderBox.Controls.Add(GSDebugOptions[3]);
                    BorderBox.Controls.Add(GSDebugOptions[4]);
                    break;
                case T2107:
                    break;
                case T2109:
                    break;
            }

            // Set The Amount of Pixels To Move Shit Based On How Much Shit has been shat.                                                                                                                  shit
            foreach (Control _ in GSDebugOptions)
            if (_ != null) RealSize++;
            switch (RealSize) {
                case 2:
                    Y_Axis_Addative = 10;
                    break;
                case 3:
                    Y_Axis_Addative = 14;
                    break;
                case 4:
                    Y_Axis_Addative = 16;
                    break;
                case 5:
                    Y_Axis_Addative = 18;
                    break;
            }

            // Move Each Control, And Resize The Form & BorderBox
            foreach (Control A in ControlsToMove)
            A.Location = new Point(A.Location.X, A.Location.Y + Y_Axis_Addative * RealSize);
            BorderBox.Size = new Size(BorderBox.Size.Width, BorderBox.Size.Height + (Y_Axis_Addative * RealSize));
            Size = new Size(Size.Width, Size.Height + (Y_Axis_Addative * RealSize));

CreateButton:
            try {
                if (GSDebugOptions[ButtonIndex] == null) {
                    ButtonIndex++;
                    if (ButtonIndex != GSDebugOptions.Length)
                        goto CreateButton;
                    RealSize = ButtonIndex = 0;
                    return;
                }
            }
            catch(IndexOutOfRangeException) { Dev.DebugOut("!!!"); }

            GSDebugOptions[ButtonIndex].BackColor = System.Drawing.Color.DimGray;
            GSDebugOptions[ButtonIndex].Cursor = System.Windows.Forms.Cursors.Cross;
            GSDebugOptions[ButtonIndex].FlatAppearance.BorderSize = 0;
            GSDebugOptions[ButtonIndex].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            GSDebugOptions[ButtonIndex].Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            GSDebugOptions[ButtonIndex].ForeColor = System.Drawing.SystemColors.Control;
            GSDebugOptions[ButtonIndex].Location = new System.Drawing.Point(1, Y_Pos);
            GSDebugOptions[ButtonIndex].Size = new Size(ActiveForm.Width - 11, 23);
            GSDebugOptions[ButtonIndex].Name = ButtonTextArray[ButtonIndex].Remove(ButtonTextArray[ButtonIndex].IndexOf(';'));
            GSDebugOptions[ButtonIndex].TabIndex = ButtonIndex;
            GSDebugOptions[ButtonIndex].Text = (ButtonTextArray[ButtonIndex].Remove(ButtonTextArray[ButtonIndex].LastIndexOf(';'))).Substring(ButtonTextArray[ButtonIndex].IndexOf(';') + 1);
            GSDebugOptions[ButtonIndex].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            GSDebugOptions[ButtonIndex].UseVisualStyleBackColor = false;
            GSDebugOptions[ButtonIndex].BringToFront();
            GSDebugOptions[ButtonIndex].MouseEnter += ControlHover;
            GSDebugOptions[ButtonIndex].MouseEnter += BtnHoverString;
            GSDebugOptions[ButtonIndex].MouseLeave += ControlLeave;


            ButtonIndex++;
            if (ButtonIndex == GSDebugOptions.Length) {
                RealSize = ButtonIndex = 0;
                return;
            }
            Y_Pos += 23;
            goto CreateButton;
        }
        public void ExtraBtnMH(object sender, EventArgs e) => HoverLeave((Control)sender, 0);
        public void ExtraBtnML(object sender, EventArgs e) => HoverLeave((Control)sender, 1);

        private void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(5, false);
        public void InfoHelpBtnMH(object sender, EventArgs e) => HoverLeave(InfoHelpBtn, 0);
        public void InfoHelpBtnML(object sender, EventArgs e) => HoverLeave(InfoHelpBtn, 1);

        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(8, false);
        public void CreditsBtnMH(object sender, EventArgs e) => HoverLeave(CreditsBtn, 0);
        public void CreditsBtnML(object sender, EventArgs e) => HoverLeave(CreditsBtn, 1);

        private void BackBtn_Click(object sender, EventArgs e) => BackFunc();
        public void BackBtnMH(object sender, EventArgs e) => HoverLeave(BackBtn, 0);
        public void BackBtnML(object sender, EventArgs e) => HoverLeave(BackBtn, 1);

        public string UpdateGameInfoLabel() { //!

            var GameString = "Unknown Game";
            var AddString = "No Debug";

            MainStream.Position = 0;
            MainStream.Read(chk, 0, 4);
            if (BitConverter.ToInt32(chk, 0) != 1179403647) {// Make Sure The File's Actually Even A .elf
                GameString = "Executable Still Encrypted";
                AddString = "Must Be Decrypted/Unsigned";
                return $"{GameString} | {AddString}";
            }

            bool CheckDebugState(int[] offsets, byte[] Data) {
                int i = 0; // Just Returns True If The Bytes Read At The Specified Address Match The Byte Given
                foreach (int addr in offsets) {
                    Read: if (ReadByte(addr) == Data[i]) return true;

                    if (Data[i] == 0x75) { // Go back and check for an unconditional jump
                        Data[i] = 0xEB;
                        goto Read;
                    }
                    i++;
                }
                return false;
            }

            switch (Game) {
                default:
                    MessageBox.Show($"Couldn't Determine The Game This Executable Belongs To, Send It To Blob To Have It's Title ID Supported\n{Game}");
                    break;
                case T1R100:
                    GameString = "The Last Of Us Remastered 1.00";
                    break;
                case T1R109:
                    GameString = "The Last Of Us Remastered 1.09";
                    break;
                case T1R11X:
                    MainStream.Position = 0x18;
                    GameString = $"The Last Of Us Remastered 1.1{((byte)MainStream.ReadByte() == 0x10 ? 1 : 0)}";
                    break;
                case T2100:
                    GameString = "The Last Of Us Part II 1.00";
                    break;
                case T2101:
                    GameString = "The Last Of Us Part II 1.01";
                    break;
                case T2102:
                    GameString = "The Last Of Us Part II 1.02";
                    break;
                case T2105:
                    GameString = "The Last Of Us Part II 1.05";
                    break;
                case T2107:
                    GameString = "The Last Of Us Part II 1.07";
                    break;
                case T2108:
                    GameString = "The Last Of Us Part II 1.08";
                    break;
                case T2109:
                    GameString = "The Last Of Us Part II 1.09";
                    break;
                case UC1100:
                    if (CheckDebugState(new int[] { 0x102056, 0x102057, 0x10207B }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 1 1.00";
                    break;
                case UC1102:
                    if (CheckDebugState(new int[] { 0x102186, 0x102187, 0x1021AB }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 1 1.02";
                    break;
                case UC2100:
                    if (CheckDebugState(new int[] { 0x1EB296, 0x1EB297, 0x1EB2BB }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 2 1.00";
                    break;
                case UC2102:
                    if (CheckDebugState(new int[] { 0x3F7A25, 0x3F7A26, 0x3F7A4A }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 2 1.02";
                    break;
                case UC3100:
                    if (CheckDebugState(new int[] { 0x168EB6, 0x168EB7, 0x168EDB }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 3 1.00";
                    break;
                case UC3102:
                    if (CheckDebugState(new int[] { 0x578226, 0x578227, 0x57824B }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 3 1.02";
                    break;
                case UC4100:
                    GameString = "Uncharted 4: A Thief's End 1.00";
                    break;
                case UC413X:
                    GameString = "Uncharted 4: A Thief's End 1.32/1.33";
                    break;
                case UC4133MP:
                    GameString = "Uncharted 4: A Thief's End 1.33 Multiplayer";
                    break;
                case TLL100:
                    GameString = "Uncharted: The Lost Legacy 1.00";
                    break;
                case TLL10X:
                    GameString = "Uncharted: The Lost Legacy 1.08/1.09";
                    break;
            }
            return $"{GameString} | {AddString}";
        }
        private void BrowseButton_Click(object sender, EventArgs e) {
            FileDialog f = new OpenFileDialog {
                Filter = "Executable|*.elf;*.bin",
                Title = "Select Either Of The Game's Executables"
            };
            if (f.ShowDialog() == DialogResult.OK) {
                ActiveFilePath = ExecutablePathBox.Text = f.FileName;

                MainStream = new FileStream(f.FileName, FileMode.Open, FileAccess.ReadWrite);
                MainStream.Position = 0x60; MainStream.Read(chk, 0, 4);
                Game = BitConverter.ToInt32(chk, 0);

                GameInfoLabel.Text = UpdateGameInfoLabel();

                ResetBtn.Visible = MainStreamIsOpen = true;
                CustomDebugOptionsLabel.Visible = IsActiveFilePCExe = false;
                LoadGameSpecificMenuOptions();
                if (!Dev.REL) Console.Clear();
            }
        }
        private void DisableDebugTextBtn_SClick(object sender, EventArgs e) {
            DisableDebugTextBtn_Click(sender, e); MouseScrolled = 1;
        }
        private void DisableDebugTextBtn_Click(object sender, EventArgs e) => Invert(DisableDebugTextBtn, 0);
        public void DisableDebugTextBtnMH(object sender, EventArgs e) => HoverLeave(DisableDebugTextBtn, 0);
        public void DisableDebugTextBtnML(object sender, EventArgs e) => HoverLeave(DisableDebugTextBtn, 1);

        private void MenuRightAlignBtn_Click(object sender, EventArgs e) {

        }

#if DEBUG
        public delegate void ResetDelegate(bool ToggleLabelVisibility);
        public static ResetDelegate ResetDelegateInstance = new ResetDelegate(ResetCustomOptions);
        public static bool FormShouldReset;


        public static Thread FormResetThread = new Thread(new ThreadStart(Wait));
        public static void Wait() {
            for (;;) {
                if (FormShouldReset) {
                    Dev.DebugOut("Initiating Reset");
                    ActiveForm.Invoke(ResetDelegateInstance);
                }
            }
        }
#endif
        public static void ResetCustomOptions(bool ToggleLabelVisibility) {
            Dev.DebugOut("Resetting Form");
            ActiveForm.Controls.Find("BorderBox", true)[0].Size = OriginalBorderScale;
            ActiveForm.Size = OriginalFormScale;

            for (int index = 0; index < ControlsToMove.Length - 1; index++) {
                ControlsToMove[index].Location = OriginalControlPositions[index];
                Dev.DebugOut($"Moved {ControlsToMove[index].Name} back to {{{ControlsToMove[index].Location.X}, {ControlsToMove[index].Location.Y}}}");
            }
            for (int i = 0; i < GSDebugOptions.Length; i++)
            if (GSDebugOptions[i] != null) GSDebugOptions[i].Dispose();
            
            MainStream.Dispose();
            MainStreamIsOpen = false;
            Dev.DebugOut("MainStream Closed");
            
            FormShouldReset ^= FormShouldReset;
            
            if (!ToggleLabelVisibility) return;
            ActiveForm.Controls.Find("CustomDebugOptionsLabel", true)[0].Visible ^= ActiveForm.Controls.Find("ResetBtn", true)[0].Visible;
            ActiveForm.Controls.Find("ResetBtn", true)[0].Visible ^= ActiveForm.Controls.Find("CustomDebugOptionsLabel", true)[0].Visible;
        }
    }
}
