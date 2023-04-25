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

namespace Dobby {
    internal class PS4QOLPatchesPage : Form {
        public PS4QOLPatchesPage() {
            InitializeComponent();
        }

        public Label MainLabel;
        public Button CreditsBtn;
        public Button InfoHelpBtn;
        public Label Info;
        public Button ExitBtn;
        public Button MinimizeBtn;
        public Label SeperatorLabel0;
        private GroupBox BorderBox;
        public Label SeperatorLabel2;
        public Label GameInfoLabel;
        private Button BrowseButton;
        private TextBox ExecutablePathBox;
        public Button DisableDebugTextBtn;
        public Button ProgPauseBtn;
        public Button RightMarginBtn;
        public Button MenuRightAlignBtn;
        public Button MenuScaleBtn;
        public Button MenuAlphaBtn;
        public Label UniversalPatchesLabel;
        public Label GameSpecificPatchesLabel;
        public Label SeperatorLabel3;
        public Label SeperatorLabel1;
        public Label LoadExecutableForOptionsLabel;
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
            this.LoadExecutableForOptionsLabel = new System.Windows.Forms.Label();
            this.UniversalPatchesLabel = new System.Windows.Forms.Label();
            this.GameSpecificPatchesLabel = new System.Windows.Forms.Label();
            this.ProgPauseBtn = new System.Windows.Forms.Button();
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
            this.Info.Location = new System.Drawing.Point(5, 355);
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
            this.CreditsBtn.Location = new System.Drawing.Point(1, 308);
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
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 285);
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
            this.BorderBox.Controls.Add(this.LoadExecutableForOptionsLabel);
            this.BorderBox.Controls.Add(this.UniversalPatchesLabel);
            this.BorderBox.Controls.Add(this.GameSpecificPatchesLabel);
            this.BorderBox.Controls.Add(this.ProgPauseBtn);
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
            this.BorderBox.Controls.Add(this.MinimizeBtn);
            this.BorderBox.Controls.Add(this.MainLabel);
            this.BorderBox.Controls.Add(this.SeperatorLabel0);
            this.BorderBox.Location = new System.Drawing.Point(0, -6);
            this.BorderBox.Name = "BorderBox";
            this.BorderBox.Size = new System.Drawing.Size(320, 379);
            this.BorderBox.TabIndex = 34;
            this.BorderBox.TabStop = false;
            // 
            // LoadExecutableForOptionsLabel
            // 
            this.LoadExecutableForOptionsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoadExecutableForOptionsLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadExecutableForOptionsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.LoadExecutableForOptionsLabel.Location = new System.Drawing.Point(3, 190);
            this.LoadExecutableForOptionsLabel.Name = "LoadExecutableForOptionsLabel";
            this.LoadExecutableForOptionsLabel.Size = new System.Drawing.Size(316, 19);
            this.LoadExecutableForOptionsLabel.TabIndex = 54;
            this.LoadExecutableForOptionsLabel.Text = "(Load An Executable To Show Game-Specific Options)";
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
            this.GameSpecificPatchesLabel.Location = new System.Drawing.Point(96, 166);
            this.GameSpecificPatchesLabel.Name = "GameSpecificPatchesLabel";
            this.GameSpecificPatchesLabel.Size = new System.Drawing.Size(127, 19);
            this.GameSpecificPatchesLabel.TabIndex = 52;
            this.GameSpecificPatchesLabel.Text = "Game-Specific Patches";
            // 
            // ProgPauseBtn
            // 
            this.ProgPauseBtn.BackColor = System.Drawing.Color.DimGray;
            this.ProgPauseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ProgPauseBtn.FlatAppearance.BorderSize = 0;
            this.ProgPauseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProgPauseBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.ProgPauseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ProgPauseBtn.Location = new System.Drawing.Point(1, 130);
            this.ProgPauseBtn.Name = "ProgPauseBtn";
            this.ProgPauseBtn.Size = new System.Drawing.Size(301, 23);
            this.ProgPauseBtn.TabIndex = 51;
            this.ProgPauseBtn.Text = "Disable Debug Pause On Menu Open:";
            this.ProgPauseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProgPauseBtn.UseVisualStyleBackColor = false;
            // 
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.GameInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GameInfoLabel.Location = new System.Drawing.Point(2, 256);
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
            this.SeperatorLabel3.Location = new System.Drawing.Point(2, 266);
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
            this.BackBtn.Location = new System.Drawing.Point(1, 331);
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
            this.BrowseButton.Location = new System.Drawing.Point(239, 230);
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
            this.ExecutablePathBox.Location = new System.Drawing.Point(7, 230);
            this.ExecutablePathBox.Name = "ExecutablePathBox";
            this.ExecutablePathBox.Size = new System.Drawing.Size(233, 23);
            this.ExecutablePathBox.TabIndex = 38;
            this.ExecutablePathBox.Text = " Select An exe To Modify";
            // 
            // SeperatorLabel1
            // 
            this.SeperatorLabel1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel1.Location = new System.Drawing.Point(2, 145);
            this.SeperatorLabel1.Name = "SeperatorLabel1";
            this.SeperatorLabel1.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLabel1.TabIndex = 37;
            this.SeperatorLabel1.Text = "______________________________________________________________";
            // 
            // SeperatorLabel2
            // 
            this.SeperatorLabel2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel2.Location = new System.Drawing.Point(2, 203);
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
            this.ClientSize = new System.Drawing.Size(320, 372);
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

        public void ExitBtn_Click(object sender, EventArgs e) => Environment.Exit(0);
        public void ExitBtnMH(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void ExitBtnML(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 255, 255);

        public void MinimizeBtn_Click(object sender, EventArgs e) => ActiveForm.WindowState = FormWindowState.Minimized;
        public void MinimizeBtnMH(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void MinimizeBtnML(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 255, 255);




        bool[] CustomDebugOptions = new bool[3];
        public static Button[] ExtraOptions = new Button[4]; // Menu Alpha, Menu Scale, others...



        public void Invert(Control Control, int OptionIndex) {
            if (MouseScrolled == 1 || MouseIsDown == 0 || CurrentControl != Control.Name) {
                Dev.DebugOut($"MouseScrolled: {MouseScrolled}\nMouseIsDown: {MouseIsDown}\n CurrentControl: {CurrentControl}\nC.Name: {Control.Name}");
                return;
            }
            tmp = Control.Text;
            CustomDebugOptions[OptionIndex] = !CustomDebugOptions[OptionIndex];
            tmp = $"{tmp.Remove(tmp.LastIndexOf(' '))} {(CustomDebugOptions[OptionIndex] ? "On" : "Off")}";
            Control.Text = tmp;
        }

        public void LoadGameSpecificMenuOptions() {
            string[] ButtonTextArray = new string[] {
                "MenuScaleBtn;Set Dev Menu Scale: 0.6F;Hint",
                "MenuAlphaBtn;Set Dev Menu Background Opacity: 0.85F;Hint",
                "TestName;TestText;TestHint",
                "MenuShadowTextBtn;Enable Debug Menu Text Shadow: Off;Hint"
            };
            var Border = ActiveForm.Controls.Find("BorderBox", false)[0];
            int Y_Axis_Addative = 0;

            Control[] cnts = new Control[] {
                Border.Controls.Find("SeperatorLabel2", false)[0],
                Border.Controls.Find("SeperatorLabel3", false)[0],
                Border.Controls.Find("BrowseButton", false)[0],
                Border.Controls.Find("ExecutablePathBox", false)[0],
                Border.Controls.Find("GameInfoLabel", false)[0],
                Border.Controls.Find("InfoHelpBtn", false)[0],
                Border.Controls.Find("CreditsBtn", false)[0],
                Border.Controls.Find("BackBtn", false)[0],
                Border.Controls.Find("Info", false)[0]
            };
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
                    ExtraOptions[0] = new Button();
                    ExtraOptions[1] = new Button();
                    ExtraOptions[3] = new Button();
                    BorderBox.Controls.Add(ExtraOptions[0]);
                    BorderBox.Controls.Add(ExtraOptions[1]);
                    BorderBox.Controls.Add(ExtraOptions[3]);
                    break;
                case T2107:
                    break;
                case T2109:
                    break;
            }
            int ButtonIndex = 0, RealSize = 0, Y_Pos = GameSpecificPatchesLabel.Location.Y + 20;
            foreach (Control _ in ExtraOptions){
            if (_ != null) RealSize++; Dev.DebugOut($"{RealSize}"); }

            switch (RealSize) {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    Y_Axis_Addative = 11;
                    break;
                case 3:
                    Y_Axis_Addative = 16;
                    break;
            }

            LoadExecutableForOptionsLabel.Visible = false;

            foreach (Control A in cnts) {
                A.Location = new Point(A.Location.X, A.Location.Y + Y_Axis_Addative * RealSize);
            }
            this.BorderBox.Size = new Size(this.BorderBox.Size.Width, this.BorderBox.Size.Height + (Y_Axis_Addative * RealSize));
            this.Size = new Size(this.Size.Width, this.Size.Height + (Y_Axis_Addative * RealSize));
            
#if DEBUG
            SetInfoString(this.Size.ToString());//!
#endif


            void BtnHoverString(object sender, EventArgs e) => SetInfoString(ButtonTextArray[((Control)sender).TabIndex].Substring(ButtonTextArray[((Control)sender).TabIndex].LastIndexOf(';') + 1));

CreateButton:
            if (ExtraOptions[ButtonIndex] == null) {
                ButtonIndex++;
                if (ButtonIndex != ExtraOptions.Length)
                goto CreateButton;
                return;
            }

            ExtraOptions[ButtonIndex].BackColor = System.Drawing.Color.DimGray;
            ExtraOptions[ButtonIndex].Cursor = System.Windows.Forms.Cursors.Cross;
            ExtraOptions[ButtonIndex].FlatAppearance.BorderSize = 0;
            ExtraOptions[ButtonIndex].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ExtraOptions[ButtonIndex].Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            ExtraOptions[ButtonIndex].ForeColor = System.Drawing.SystemColors.Control;
            ExtraOptions[ButtonIndex].Location = new System.Drawing.Point(1, Y_Pos);
            ExtraOptions[ButtonIndex].Size = new Size(ActiveForm.Width - 11, 23);
            ExtraOptions[ButtonIndex].Name = ButtonTextArray[ButtonIndex].Remove(ButtonTextArray[ButtonIndex].IndexOf(';'));
            ExtraOptions[ButtonIndex].TabIndex = ButtonIndex;
            ExtraOptions[ButtonIndex].Text = (ButtonTextArray[ButtonIndex].Remove(ButtonTextArray[ButtonIndex].LastIndexOf(';'))).Substring(ButtonTextArray[ButtonIndex].IndexOf(';') + 1);
            ExtraOptions[ButtonIndex].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ExtraOptions[ButtonIndex].UseVisualStyleBackColor = false;
            ExtraOptions[ButtonIndex].BringToFront();
            ExtraOptions[ButtonIndex].MouseEnter += ControlHover;
            ExtraOptions[ButtonIndex].MouseEnter += BtnHoverString;
            ExtraOptions[ButtonIndex].MouseLeave += ControlLeave;


            ButtonIndex++;
            if (ButtonIndex == ExtraOptions.Length) return;
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
            var VersionString = $"Unknown Version {BitConverter.ToString(chk):X}";

            switch (Game) {
                default:
                    Dev.DebugOut($"Unknown Game Verson: {Game} / {Game:X}");
                    break;
                case T1X101:
                    VersionString = "Original Release";
                    if (!ByteCmp(0x3B66B6, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL101:
                    VersionString = "Original Release Non-AVX";
                    if (!ByteCmp(0x3B64A2, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1X1015:
                    VersionString = "1.01.5 Release";
                    if (!ByteCmp(0x3B68E6, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL1015:
                    VersionString = "1.01.5 Release Non-AVX";
                    if (!ByteCmp(0x3B66D2, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1X1016:
                    VersionString = "1.01.6 Release";
                    if (!ByteCmp(0x3B68F6, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL1016:
                    VersionString = "1.01.6 Release Non-AVX";
                    if (!ByteCmp(0x3B66D2, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1X1017:
                    VersionString = "1.01.7 Release";
                    if (!ByteCmp(0x3B6A17, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL1017:
                    VersionString = "1.01.7 Release Non-AVX";
                    if (!ByteCmp(0x3B67F3, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1X102:
                    VersionString = "1.02 Release";
                    if (!ByteCmp(0x3B6A92, DebugDat))
                        VersionString += " | Debug Enabled";
                    break;
                case T1XL102:
                    VersionString = "1.02 Release Non-AVX";
                    if (!ByteCmp(0x3B686E, DebugDat))
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
                Filter = "Executable|*.elf;*.bin",
                Title = "Select Either Of The Game's Executables"
            };
            if (f.ShowDialog() == DialogResult.OK) {
                ActiveFilePath = ExecutablePathBox.Text = f.FileName;

                MainStream = new FileStream(f.FileName, FileMode.Open, FileAccess.ReadWrite);
                MainStream.Position = 0x60; MainStream.Read(chk, 0, 4);
                Game = BitConverter.ToInt32(chk, 0);

                GameInfoLabel.Text = UpdateGameInfoLabel();
                MainStreamIsOpen = true;
                IsActiveFilePCExe = false;
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
    }
}
