using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static Dobby.Common;
using System.IO;

namespace Dobby {
    internal class PCQOLPatchesPage : Form {
        public PCQOLPatchesPage() {
            InitializeComponent();
            AddControlEventHandlers(Controls);
        }


        public static int Game;

        public void InitializeComponent() {
            this.MainLabel = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.SeperatorLabel0 = new System.Windows.Forms.Label();
            this.SeperatorLabel2 = new System.Windows.Forms.Label();
            this.BorderBox = new System.Windows.Forms.GroupBox();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.GameInfoLabel = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ExecutablePathBox = new System.Windows.Forms.TextBox();
            this.ProgPauseBtn = new System.Windows.Forms.Button();
            this.RightMarginBtn = new System.Windows.Forms.Button();
            this.MenuRightAlignBtn = new System.Windows.Forms.Button();
            this.MenuScaleBtn = new System.Windows.Forms.Button();
            this.MenuAlphaBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.SeperatorLabel1 = new System.Windows.Forms.Label();
            this.DisableDebugTextBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.MainLabel.Text = "Quality Of Life Patches Page";
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
            this.Info.Location = new Point(9, 381);
            this.Info.Name = "Info";
            this.Info.Size = new Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "      This Page Assumes .cfg\'s Still Don\'t Work";
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
            this.CreditsBtn.Location = new Point(1, 332);
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
            this.InfoHelpBtn.Location = new Point(1, 307);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InfoHelpBtn.Size = new Size(147, 23);
            this.InfoHelpBtn.TabIndex = 29;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            // 
            // SeperatorLabel0
            // 
            this.SeperatorLabel0.Font = new Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel0.ForeColor = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel0.Location = new Point(2, 14);
            this.SeperatorLabel0.Name = "SeperatorLabel0";
            this.SeperatorLabel0.Size = new Size(316, 16);
            this.SeperatorLabel0.TabIndex = 31;
            this.SeperatorLabel0.Text = "______________________________________________________________";
            // 
            // SeperatorLabel2
            // 
            this.SeperatorLabel2.Font = new Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel2.ForeColor = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel2.Location = new Point(2, 287);
            this.SeperatorLabel2.Name = "SeperatorLabel2";
            this.SeperatorLabel2.Size = new Size(316, 16);
            this.SeperatorLabel2.TabIndex = 32;
            this.SeperatorLabel2.Text = "______________________________________________________________";
            // 
            // BorderBox
            // 
            this.BorderBox.Controls.Add(this.ApplyBtn);
            this.BorderBox.Controls.Add(this.SeperatorLabel1);
            this.BorderBox.Controls.Add(this.button1);
            this.BorderBox.Controls.Add(this.GameInfoLabel);
            this.BorderBox.Controls.Add(this.SeperatorLabel2);
            this.BorderBox.Controls.Add(this.BrowseButton);
            this.BorderBox.Controls.Add(this.ExecutablePathBox);
            this.BorderBox.Controls.Add(this.ProgPauseBtn);
            this.BorderBox.Controls.Add(this.RightMarginBtn);
            this.BorderBox.Controls.Add(this.MenuRightAlignBtn);
            this.BorderBox.Controls.Add(this.MenuScaleBtn);
            this.BorderBox.Controls.Add(this.MenuAlphaBtn);
            this.BorderBox.Controls.Add(this.BackBtn);
            this.BorderBox.Controls.Add(this.Info);
            this.BorderBox.Controls.Add(this.InfoHelpBtn);
            this.BorderBox.Controls.Add(this.CreditsBtn);
            this.BorderBox.Location = new Point(0, -6);
            this.BorderBox.Name = "BorderBox";
            this.BorderBox.Size = new Size(320, 405);
            this.BorderBox.TabIndex = 34;
            this.BorderBox.TabStop = false;
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.BackColor = Color.DimGray;
            this.ApplyBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ApplyBtn.FlatAppearance.BorderSize = 0;
            this.ApplyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.ApplyBtn.ForeColor = SystemColors.Control;
            this.ApplyBtn.Location = new Point(101, 216);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new Size(107, 23);
            this.ApplyBtn.TabIndex = 46;
            this.ApplyBtn.Text = "Apply Patches";
            this.ApplyBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.ApplyBtn.UseVisualStyleBackColor = false;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new Font("Franklin Gothic Medium", 10F);
            this.GameInfoLabel.ForeColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GameInfoLabel.Location = new Point(2, 278);
            this.GameInfoLabel.Name = "GameInfoLabel";
            this.GameInfoLabel.Size = new Size(316, 19);
            this.GameInfoLabel.TabIndex = 40;
            this.GameInfoLabel.Text = "No File Selected";
            this.GameInfoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = Color.DimGray;
            this.BrowseButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.BrowseButton.ForeColor = SystemColors.Control;
            this.BrowseButton.Location = new Point(239, 252);
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
            this.ExecutablePathBox.Location = new Point(7, 252);
            this.ExecutablePathBox.Name = "ExecutablePathBox";
            this.ExecutablePathBox.Size = new Size(233, 23);
            this.ExecutablePathBox.TabIndex = 38;
            this.ExecutablePathBox.Text = " Select An exe To Modify";
            // 
            // ProgPauseBtn
            // 
            this.ProgPauseBtn.BackColor = Color.DimGray;
            this.ProgPauseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ProgPauseBtn.FlatAppearance.BorderSize = 0;
            this.ProgPauseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProgPauseBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.ProgPauseBtn.ForeColor = SystemColors.Control;
            this.ProgPauseBtn.Location = new Point(1, 158);
            this.ProgPauseBtn.Name = "ProgPauseBtn";
            this.ProgPauseBtn.Size = new Size(281, 23);
            this.ProgPauseBtn.TabIndex = 45;
            this.ProgPauseBtn.Text = "Disable Debug Pause On Menu Open: Off";
            this.ProgPauseBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.ProgPauseBtn.UseVisualStyleBackColor = false;
            this.ProgPauseBtn.Click += new System.EventHandler(this.ProgPauseBtn_Click);
            // 
            // RightMarginBtn
            // 
            this.RightMarginBtn.BackColor = Color.DimGray;
            this.RightMarginBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.RightMarginBtn.FlatAppearance.BorderSize = 0;
            this.RightMarginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightMarginBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.RightMarginBtn.ForeColor = SystemColors.Control;
            this.RightMarginBtn.Location = new Point(1, 157);
            this.RightMarginBtn.Name = "RightMarginBtn";
            this.RightMarginBtn.Size = new Size(231, 23);
            this.RightMarginBtn.TabIndex = 44;
            this.RightMarginBtn.Text = "Distance From Right SIde: 10";
            this.RightMarginBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.RightMarginBtn.UseVisualStyleBackColor = false;
            this.RightMarginBtn.Click += new System.EventHandler(this.RightMarginBtn_Click);
            // 
            // MenuRightAlignBtn
            // 
            this.MenuRightAlignBtn.BackColor = Color.DimGray;
            this.MenuRightAlignBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MenuRightAlignBtn.FlatAppearance.BorderSize = 0;
            this.MenuRightAlignBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuRightAlignBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.MenuRightAlignBtn.ForeColor = SystemColors.Control;
            this.MenuRightAlignBtn.Location = new Point(1, 128);
            this.MenuRightAlignBtn.Name = "MenuRightAlignBtn";
            this.MenuRightAlignBtn.Size = new Size(301, 23);
            this.MenuRightAlignBtn.TabIndex = 43;
            this.MenuRightAlignBtn.Text = "Alight Menu\'s To Right Side Of Screen: Off";
            this.MenuRightAlignBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.MenuRightAlignBtn.UseVisualStyleBackColor = false;
            this.MenuRightAlignBtn.Click += new System.EventHandler(this.MenuRightAlignBtn_Click);
            // 
            // MenuScaleBtn
            // 
            this.MenuScaleBtn.BackColor = Color.DimGray;
            this.MenuScaleBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MenuScaleBtn.FlatAppearance.BorderSize = 0;
            this.MenuScaleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuScaleBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.MenuScaleBtn.ForeColor = SystemColors.Control;
            this.MenuScaleBtn.Location = new Point(1, 99);
            this.MenuScaleBtn.Name = "MenuScaleBtn";
            this.MenuScaleBtn.Size = new Size(207, 23);
            this.MenuScaleBtn.TabIndex = 42;
            this.MenuScaleBtn.Text = "Set Dev Menu Scale: 0.6F";
            this.MenuScaleBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.MenuScaleBtn.UseVisualStyleBackColor = false;
            this.MenuScaleBtn.Click += new System.EventHandler(this.MenuScaleBtn_Click);
            // 
            // MenuAlphaBtn
            // 
            this.MenuAlphaBtn.BackColor = Color.DimGray;
            this.MenuAlphaBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MenuAlphaBtn.FlatAppearance.BorderSize = 0;
            this.MenuAlphaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuAlphaBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.MenuAlphaBtn.ForeColor = SystemColors.Control;
            this.MenuAlphaBtn.Location = new Point(1, 70);
            this.MenuAlphaBtn.Name = "MenuAlphaBtn";
            this.MenuAlphaBtn.Size = new Size(301, 23);
            this.MenuAlphaBtn.TabIndex = 37;
            this.MenuAlphaBtn.Text = "Set Dev Menu Background Opacity: 0.85F";
            this.MenuAlphaBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.MenuAlphaBtn.UseVisualStyleBackColor = false;
            this.MenuAlphaBtn.Click += new System.EventHandler(this.MenuAlphaBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.BackBtn.ForeColor = SystemColors.Control;
            this.BackBtn.Location = new Point(1, 357);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BackBtn.Size = new Size(75, 23);
            this.BackBtn.TabIndex = 41;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // SeperatorLabel1
            // 
            this.SeperatorLabel1.Font = new Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel1.ForeColor = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel1.Location = new Point(2, 228);
            this.SeperatorLabel1.Name = "SeperatorLabel1";
            this.SeperatorLabel1.Size = new Size(316, 16);
            this.SeperatorLabel1.TabIndex = 36;
            this.SeperatorLabel1.Text = "______________________________________________________________";
            // 
            // DisableDebugTextBtn
            // 
            this.DisableDebugTextBtn.BackColor = Color.DimGray;
            this.DisableDebugTextBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisableDebugTextBtn.FlatAppearance.BorderSize = 0;
            this.DisableDebugTextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisableDebugTextBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.DisableDebugTextBtn.ForeColor = SystemColors.Control;
            this.DisableDebugTextBtn.Location = new Point(1, 35);
            this.DisableDebugTextBtn.Name = "DisableDebugTextBtn";
            this.DisableDebugTextBtn.Size = new Size(316, 23);
            this.DisableDebugTextBtn.TabIndex = 20;
            this.DisableDebugTextBtn.Text = "Disable 2D Debug Text On Startup: Off";
            this.DisableDebugTextBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.DisableDebugTextBtn.UseVisualStyleBackColor = false;
            this.DisableDebugTextBtn.Click += new System.EventHandler(this.DisableDebugTextBtn_Click);
            this.DisableDebugTextBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.DisableDebugTextBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.DisableDebugTextBtn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DisableDebugTextBtn_SClick);
            // 
            // button1
            // 
            this.button1.BackColor = Color.DimGray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.button1.ForeColor = SystemColors.Control;
            this.button1.Location = new Point(1, 187);
            this.button1.Name = "button1";
            this.button1.Size = new Size(281, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "Disable Debug Pause On Menu Open: Off";
            this.button1.TextAlign = ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // PCQOLPatchesPage
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.DimGray;
            this.ClientSize = new Size(320, 398);
            this.Controls.Add(this.DisableDebugTextBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLabel0);
            this.Controls.Add(this.BorderBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PCQOLPatchesPage";
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



        public static Size OriginalFormScale = Size.Empty;
        public static Size OriginalBorderScale;
        public static Point[] OriginalControlPositions;

        public bool[] CustomDebugBooleans = new bool[3];
        public static Button[] CustomDebugOptions = new Button[5]; // Menu Alpha, Menu Scale, others...
        public static Control[] ControlsToMove;

        float[] CustomDebugFloats = new float[] { 0.85f, 0.6f };

        int RightMargin = 10;


        public void Invert(Control Control, int OptionIndex) {
            if (MouseScrolled == 1 || MouseIsDown == 0 || CurrentControl != Control.Name) {
                Dev.DebugOut($"MouseScrolled: {MouseScrolled}\nMouseIsDown: {MouseIsDown}\n CurrentControl: {CurrentControl}\nC.Name: {Control.Name}");
                return;
            }
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

            TempStringStore = Control.Text;
            CustomDebugBooleans[OptionIndex] = !CustomDebugBooleans[OptionIndex];
            TempStringStore = $"{TempStringStore.Remove(TempStringStore.LastIndexOf(' '))} {(CustomDebugBooleans[OptionIndex] ? "On" : "Off")}";
            Control.Text = TempStringStore;
        }

        public void FloatFunc() {
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

        }

        public void IntFunc() {
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

        }

        public string UpdateGameInfoLabel() { //!
            var VersionString = $"Unknown Version {BitConverter.ToString(LocalExecutableCheck):X}";

            switch (Game) {
                default:
                    MessageBox.Show($"Unknown Game Verson: {Game} / {Game:X} (:X)");
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

        public void ReadCurrentSettings() {

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

                MainStream.Position = 0x1EC; MainStream.Read(LocalExecutableCheck, 0, 4);
                Game = BitConverter.ToInt32(LocalExecutableCheck, 0);
                MainStream.Position = 0x1F8; MainStream.Read(LocalExecutableCheck, 0, 4);
                Game += BitConverter.ToInt32(LocalExecutableCheck, 0);

                GameInfoLabel.Text = UpdateGameInfoLabel();
                IsActiveFilePCExe = true;
                MainStreamIsOpen = true;
                if (!Dev.REL) Console.Clear();
            }
        }
        private void DisableDebugTextBtn_SClick(object sender, EventArgs e) {
            DisableDebugTextBtn_Click(sender, e); MouseScrolled = 1;
        }
        private void DisableDebugTextBtn_Click(object sender, EventArgs e) => Invert(DisableDebugTextBtn, 0);

        private void MenuAlphaBtn_Click(object sender, EventArgs e) {

        }

        private void MenuScaleBtn_Click(object sender, EventArgs e) {

        }

        private void MenuRightAlignBtn_Click(object sender, EventArgs e) {

        }

        private void RightMarginBtn_Click(object sender, EventArgs e) {

        }

        private void ProgPauseBtn_Click(object sender, EventArgs e) => Invert(ProgPauseBtn, 3);

        private void ApplyBtn_Click(object sender, EventArgs e) {

        }

        private void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(5, false);

        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(8, false);

        private void BackBtn_Click(object sender, EventArgs e) => BackFunc();


#if DEBUG
        public static void ResetCustomOptions() {
            ActiveForm.Controls.Find("BorderBox", true)[0].Size = OriginalBorderScale;
            ActiveForm.Size = OriginalFormScale;

            Dev.DebugOut("                X | Y");
            for (int index = 0; index < ControlsToMove.Length - 1; index++) {
                ControlsToMove[index].Location = OriginalControlPositions[index];
                Dev.DebugOut($"Moved {ControlsToMove[index].Name} to {{{ControlsToMove[index].Location.X}, {ControlsToMove[index].Location.Y}}}");
            }
            foreach (Control C in CustomDebugOptions) {
                if (ActiveForm.Controls.Contains(C))
                    Dev.DebugOut($"Removing: {C.Name}");
                ActiveForm.Controls.Remove(C);
            }
            Dev.DebugOut($"Form Size: {ActiveForm.Size}");
        }
#endif


        public Label MainLabel;
        public Button CreditsBtn;
        public Button InfoHelpBtn;
        public Label Info;
        public Button ExitBtn;
        public Button MinimizeBtn;
        public Label SeperatorLabel0;
        public Label SeperatorLabel2;
        private GroupBox BorderBox;
        public Label SeperatorLabel1;
        public Label GameInfoLabel;
        private Button BrowseButton;
        private TextBox ExecutablePathBox;
        public Button BackBtn;
        public Button RightMarginBtn;
        public Button MenuRightAlignBtn;
        public Button MenuScaleBtn;
        public Button MenuAlphaBtn;
        public Button ProgPauseBtn;
        private Button ApplyBtn;
        public Button button1;
        public Button DisableDebugTextBtn;
    }

}
