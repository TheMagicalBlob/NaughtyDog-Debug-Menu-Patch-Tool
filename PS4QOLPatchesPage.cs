﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dobby.Common;
using System.Drawing;
using System.IO;
using System.Threading;

namespace Dobby {
    internal class PS4QOLPatchesPage : Form {
        public PS4QOLPatchesPage() {
            InitializeComponent();
            AddControlEventHandlers(Controls);
#if DEBUG
            if (FormResetThread.ThreadState != ThreadState.Running)
            FormResetThread.Start();
#endif
        }

        /// <summary> 0: Disable FPS<br/>1: Menu Right Align<br/>2: Menu Shadowed Text<br/>3: Prog Pause On Open<br/>4: Prog Pause On Close </summary>
        static bool[] UniversalDebugBooleans = new bool[5];
        /// <summary> 1: Debug Shadowed Text<br/>2: Disable Version Text<br/>3: <br/>4: <br/>5:  </summary>
        static bool[] GSDebugBooleans = new bool[3];
        /// <summary> Game-Specific Debug Floats <br/>1: Menu Alpha<br/>2: Menu Scale<br/>3: Non-ADS Field of View</summary>
        static float[] GSDebugFloats = new float[] { 0.85f, 0.6f, 1F };
        /// <summary> Variable Used When Adjusting Form Scale And Control Positions </summary>
        static int ButtonIndex = 0, RealSize = 0, Y_Axis_Addative = 0, Y_Pos;

        static byte RightMargin = 10;

        static string[] GSButtonTextArray = new string[] {
                $"MenuScaleBtn;Set Dev Menu Scale: default;Hint:0",
                $"MenuAlphaBtn;Set DMenu BG Opacity: default;Hint:1",
                $"MenuShadowTextBtn;Enable Debug Menu Text Shadow: No;Hint:0",
                $"FOVBtn;Adjust Non-ADS FOV: 1.00;Only Effects The Camera While Not Aiming:2",
                $"VersionTxtBtn;Disable Version Text: No;Hint:1"
        };
        /// <summary> Game-Specific Debug Options Loaded Based On The Game Chosen. <br/>1: MenuScaleBtn<br/>2: MenuScaleBtn <br/>3: MenuShadowTextBtn<br/>4: FOVBtn<br/>5: VersionTxtBtn</summary>
        public static Button[] GSDebugOptions = new Button[GSButtonTextArray.Length];
        /// <summary> Array of Controls to Move When Loading >1 Game-SpecificDebugOptions </summary>
        public static Control[] ControlsToMove;

        private Label MainLabel;
        private Button CreditsBtn;
        private Button InfoHelpBtn;
        private Label Info;
        private Button ExitBtn;
        private Button MinimizeBtn;
        private Label SeperatorLabel0;
        private GroupBox BorderBox;
        private Label SeperatorLabel2;
        private Label GameInfoLabel;
        private Button BrowseButton;
        private TextBox ExecutablePathBox;
        private Button DisableDebugTextBtn;
        private Button ProgPauseOnOpenBtn;
        private Button RightMarginBtn;
        private Button MenuRightAlignBtn;
        private Button MenuScaleBtn;
        private Button MenuAlphaBtn;
        private Label UniversalPatchesLabel;
        private Label GameSpecificPatchesLabel;
        private Label SeperatorLabel3;
        private Label SeperatorLabel1;
        private Label CustomDebugOptionsLabel;
        private Button ProgPauseOnCloseBtn;
        private Button BackBtn;

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
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.25F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(2, 3);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(314, 24);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Misc. PS4  Patches Page";
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
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.DimGray;
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 331);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(75, 22);
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
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 309);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InfoHelpBtn.Size = new System.Drawing.Size(147, 22);
            this.InfoHelpBtn.TabIndex = 29;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            // 
            // SeperatorLabel0
            // 
            this.SeperatorLabel0.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel0.Location = new System.Drawing.Point(2, 12);
            this.SeperatorLabel0.Name = "SeperatorLabel0";
            this.SeperatorLabel0.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLabel0.TabIndex = 31;
            this.SeperatorLabel0.Text = "______________________________________________________________";
            // 
            // BorderBox
            // 
            this.BorderBox.Location = new System.Drawing.Point(0, -6);
            this.BorderBox.Name = "BorderBox";
            this.BorderBox.Size = new System.Drawing.Size(320, 409);
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
            this.ProgPauseOnCloseBtn.Text = "Disable Debug Pause On Menu Close: ";
            this.ProgPauseOnCloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProgPauseOnCloseBtn.UseVisualStyleBackColor = false;
            this.ProgPauseOnCloseBtn.Click += new System.EventHandler(this.ProgPauseOnCloseBtn_Click);
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
            this.ProgPauseOnOpenBtn.Text = "Disable Debug Pause On Menu Open: ";
            this.ProgPauseOnOpenBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProgPauseOnOpenBtn.UseVisualStyleBackColor = false;
            this.ProgPauseOnOpenBtn.Click += new System.EventHandler(this.ProgPauseOnOpenBtn_Click);
            // 
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.5F);
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
            this.RightMarginBtn.Text = "Distance From Right Side: ";
            this.RightMarginBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RightMarginBtn.UseVisualStyleBackColor = false;
            this.RightMarginBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightMarginBtn_Click);
            this.RightMarginBtn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.RightMarginBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 353);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BackBtn.Size = new System.Drawing.Size(75, 22);
            this.BackBtn.TabIndex = 41;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
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
            this.ClientSize = new System.Drawing.Size(320, 403);
            this.Controls.Add(this.ProgPauseOnCloseBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.CustomDebugOptionsLabel);
            this.Controls.Add(this.UniversalPatchesLabel);
            this.Controls.Add(this.GameSpecificPatchesLabel);
            this.Controls.Add(this.ProgPauseOnOpenBtn);
            this.Controls.Add(this.GameInfoLabel);
            this.Controls.Add(this.SeperatorLabel3);
            this.Controls.Add(this.DisableDebugTextBtn);
            this.Controls.Add(this.RightMarginBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.MenuRightAlignBtn);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.ExecutablePathBox);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.SeperatorLabel1);
            this.Controls.Add(this.SeperatorLabel2);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLabel0);
            this.Controls.Add(this.BorderBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PS4QOLPatchesPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(5, false);
        public void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(8, false);
        public void BackBtn_Click(object sender, EventArgs e) => BackFunc();
        public void ResetBtn_Click(object sender, EventArgs e) => ResetCustomOptions();

        
        public void Invert(Control Control, int OptionIndex) {
            if (MouseScrolled == 1 || MouseIsDown == 0 || CurrentControl != Control.Name) return;

            if (Control.Location.Y > GameSpecificPatchesLabel.Location.Y) {
                Dev.DebugOut($"Button Is GSDegug Btn, Option Index: {OptionIndex}");
                GSDebugBooleans[OptionIndex] =! GSDebugBooleans[OptionIndex];
                Control.Text = $"{Control.Text.Remove(Control.Text.LastIndexOf(' '))} {(GSDebugBooleans[OptionIndex] ? "Yes" : "No")}";
                return;
            }

            UniversalDebugBooleans[OptionIndex] =! UniversalDebugBooleans[OptionIndex];
            Control.Text = $"{Control.Text.Remove(Control.Text.LastIndexOf(' '))} {(UniversalDebugBooleans[OptionIndex] ? "Yes" : "No")}";
        }

        public void FloatFunc(Control Control, int OptionIndex, int WheelDelta) {
            if (CurrentControl != Control.Name) return;

            GSDebugFloats[OptionIndex] = (float)Math.Round(GSDebugFloats[OptionIndex] += WheelDelta / 12000.0F, 4);
            Control.Text = $"{Control.Text.Remove(Control.Text.LastIndexOf(' '))} {GSDebugFloats[OptionIndex]}";
        }

        public void LoadGameSpecificMenuOptions() {
            
            void GSBtn_Click(object sender, EventArgs e) => Invert((Control)sender, ((Control)sender).TabIndex);
            void GSBtn_FloatFunc(object sender, MouseEventArgs e) => FloatFunc((Control)sender, ((Control)sender).TabIndex, e.Delta);
            void GSBtn_HoverString(object sender, EventArgs e) => SetInfoLabelText(GSButtonTextArray[((Control)sender).TabIndex].Remove(GSButtonTextArray[((Control)sender).TabIndex].Length - 2).Substring(GSButtonTextArray[((Control)sender).TabIndex].LastIndexOf(';') + 1)); // disgusting, I know
            void GSBtn_EnableButtons(int[] buttons) { for (int i = 0; i < buttons.Length; i++) { GSDebugOptions[i] = new Button(); Controls.Add(GSDebugOptions[i]); } }

            if (OriginalFormScale == Size.Empty) { // Assign values to variables made to keep track of the default form size/control postions. Going it on page init is annoying 'cause designer memes
                Dev.DebugOut("Setting Original Scale Variables");
                ControlsToMove = new Control[] {
                    ActiveForm.Controls.Find("SeperatorLabel2", true)[0],
                    ActiveForm.Controls.Find("BrowseButton", true)[0],
                    ActiveForm.Controls.Find("ExecutablePathBox", true)[0],
                    ActiveForm.Controls.Find("GameInfoLabel", true)[0],
                    ActiveForm.Controls.Find("SeperatorLabel3", true)[0],
                    ActiveForm.Controls.Find("InfoHelpBtn", true)[0],
                    ActiveForm.Controls.Find("CreditsBtn", true)[0],
                    ActiveForm.Controls.Find("BackBtn", true)[0],
                    ActiveForm.Controls.Find("Info", true)[0]
                };
                OriginalFormScale = Size;
                OriginalBorderScale = ActiveForm.Controls.Find("BorderBox", true)[0].Size;
                OriginalControlPositions = new Point[ControlsToMove.Length];
                for (int Index = 0; Index < ControlsToMove.Length; Index++) {
                    OriginalControlPositions[Index] = ControlsToMove[Index].Location;
                }
            }

            Y_Pos = GameSpecificPatchesLabel.Location.Y + GameSpecificPatchesLabel.Size.Height + 1; // Right Below The Label
            RealSize = ButtonIndex = 0; // In Case Of Repeat Uses
            CustomDebugOptionsLabel.Visible = false; // gee, I wonder what this does

            switch (Game) {
                case UC1100: GSBtn_EnableButtons(new int[] { 4 });
                    Dev.DebugOut("UC1 1.00");
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
                case T2100: GSBtn_EnableButtons(new int[] { 0, 1, 2, 3 });
                    Dev.DebugOut("Tlou 2 1.00");
                    break;
                case T2107:
                    break;
                case T2109:
                    break;
            }

            // Set The Amount of Pixels To Move Shit Based On How Much Shit Has Been Shat.                                                                                                                  shit
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

            // Move Each Control, Then Resize The Form & BorderBox
            foreach (Control A in ControlsToMove)
            A.Location = new Point(A.Location.X, A.Location.Y + Y_Axis_Addative * RealSize);
            BorderBox.Size = new Size(BorderBox.Size.Width, BorderBox.Size.Height + (Y_Axis_Addative * RealSize) + 50);
            Size = new Size(Size.Width, Size.Height + (Y_Axis_Addative * RealSize) + 50);
            // Move The Controls Below The Confirm And Reset Buttons A Bit Farther Down To Make Room For Them
            for (int i = 4; i < ControlsToMove.Length; i++) {
                ControlsToMove[i].Location = new Point(ControlsToMove[i].Location.X, ControlsToMove[i].Location.Y + 46);
            }

RunCheck:   if (ButtonIndex >= GSDebugOptions.Length - 1) goto CreateConfirmBtn;
            Dev.DebugOut($"Checking, ButtonIndex:{ButtonIndex}");
            if (GSDebugOptions[ButtonIndex] == null) { // Skip disabled buttons or return if the end of the collection is reached
                Dev.DebugOut($"Skipping Button {ButtonIndex}");
                ButtonIndex++; goto RunCheck;
            }

            Dev.DebugOut("Creating GSDebug Button");
            GSDebugOptions[ButtonIndex].TabIndex = int.Parse(GSButtonTextArray[ButtonIndex].Substring(GSButtonTextArray[ButtonIndex].LastIndexOf(':') + 1));
            GSDebugOptions[ButtonIndex].Name = GSButtonTextArray[ButtonIndex].Remove(GSButtonTextArray[ButtonIndex].IndexOf(';'));
            GSDebugOptions[ButtonIndex].Location = new Point(1, Y_Pos);
            GSDebugOptions[ButtonIndex].Size = new Size(ActiveForm.Width - 11, 23);
            GSDebugOptions[ButtonIndex].Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            GSDebugOptions[ButtonIndex].Text = (GSButtonTextArray[ButtonIndex].Remove(GSButtonTextArray[ButtonIndex].LastIndexOf(';'))).Substring(GSButtonTextArray[ButtonIndex].IndexOf(';') + 1);
            GSDebugOptions[ButtonIndex].TextAlign = ContentAlignment.MiddleLeft;
            GSDebugOptions[ButtonIndex].FlatAppearance.BorderSize = 0;
            GSDebugOptions[ButtonIndex].FlatStyle = FlatStyle.Flat;
            GSDebugOptions[ButtonIndex].ForeColor = SystemColors.Control;
            GSDebugOptions[ButtonIndex].BackColor = Color.DimGray;
            GSDebugOptions[ButtonIndex].Cursor = Cursors.Cross;
            GSDebugOptions[ButtonIndex].MouseEnter += ControlHover;
            GSDebugOptions[ButtonIndex].MouseDown += new MouseEventHandler(MouseDownFunc);
            GSDebugOptions[ButtonIndex].MouseUp += new MouseEventHandler(MouseUpFunc);
            GSDebugOptions[ButtonIndex].MouseEnter += GSBtn_HoverString;
            GSDebugOptions[ButtonIndex].MouseLeave += ControlLeave;
            if (ButtonIndex == 2) GSDebugOptions[ButtonIndex].Click += GSBtn_Click;
            else GSDebugOptions[ButtonIndex].MouseWheel += GSBtn_FloatFunc;
            GSDebugOptions[ButtonIndex].BringToFront();


            Y_Pos += 23; ButtonIndex++;
            goto RunCheck;

            CreateConfirmBtn:
            // Create Confirm And Reset Buttons Once The Rest Are Created
            Button ConfirmPatchesBtn = new Button();
            ActiveForm.Controls.Add(ConfirmPatchesBtn);
            ConfirmPatchesBtn.TabIndex = ButtonIndex;
            ConfirmPatchesBtn.Name = "ConfirmPatchesBtn";
            ConfirmPatchesBtn.Location = new Point(1, GameInfoLabel.Location.Y + 21);
            ConfirmPatchesBtn.Size = new Size(ActiveForm.Width - 11, 23);
            ConfirmPatchesBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            ConfirmPatchesBtn.Text = "Confirm And Apply Patches";
            ConfirmPatchesBtn.TextAlign = ContentAlignment.MiddleLeft;
            ConfirmPatchesBtn.FlatAppearance.BorderSize = 0;
            ConfirmPatchesBtn.FlatStyle = FlatStyle.Flat;
            ConfirmPatchesBtn.ForeColor = SystemColors.Control;
            ConfirmPatchesBtn.BackColor = Color.DimGray;
            ConfirmPatchesBtn.Cursor = Cursors.Cross;
            ConfirmPatchesBtn.MouseEnter += ControlHover;
            ConfirmPatchesBtn.MouseLeave += ControlLeave;
            ConfirmPatchesBtn.Click += ConfirmBtn_Click;
            ConfirmPatchesBtn.BringToFront();

            Button ResetBtn = new Button();
            ActiveForm.Controls.Add(ResetBtn);
            ResetBtn.BackColor = Color.DimGray;
            ResetBtn.Cursor = Cursors.Cross;
            ResetBtn.FlatAppearance.BorderSize = 0;
            ResetBtn.FlatStyle = FlatStyle.Flat;
            ResetBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            ResetBtn.ForeColor = SystemColors.Control;
            ResetBtn.ImageAlign = ContentAlignment.TopRight;
            ResetBtn.Location = new Point(1, GameInfoLabel.Location.Y + 46);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(ActiveForm.Width - 11, 23);
            ResetBtn.Text = "Reset";
            ResetBtn.TextAlign = ContentAlignment.MiddleLeft;
            ResetBtn.UseVisualStyleBackColor = false;
            ResetBtn.Click += new EventHandler(ResetBtn_Click);
            ResetBtn.MouseEnter += ControlHover;
            ResetBtn.MouseLeave += ControlLeave;
            ResetBtn.BringToFront();
        }

        private void BrowseButton_Click(object sender, EventArgs e) { goto skip;
            Dev.DebugForceOpenFile(@"C:\Users\BlobL\OneDrive\Desktop\testboot.bin");
            LoadGameSpecificMenuOptions();
            return;
            skip:
            FileDialog OpenedFile = new OpenFileDialog {
                Filter = "Executable|*.elf;*.bin",
                Title = "Select Either Of The Game's Executables"
            };
            if (OpenedFile.ShowDialog() == DialogResult.OK) {
                ResetCustomOptions();
                ActiveFilePath = ExecutablePathBox.Text = OpenedFile.FileName;

                MainStream = File.Open(OpenedFile.FileName, FileMode.Open, FileAccess.ReadWrite);
                MainStream.Position = 0x60; MainStream.Read(chk, 0, 4);
                Game = BitConverter.ToInt32(chk, 0);

                GameInfoLabel.Text = UpdateGameInfoLabel();

                MainStreamIsOpen = true;
                CustomDebugOptionsLabel.Visible = IsActiveFilePCExe = false;
                LoadGameSpecificMenuOptions();
                if (!Dev.REL) Console.Clear();
            }
        }

        private void ConfirmBtn_Click(object sender, EventArgs e) {
            using (MainStream) {
                int i = 0,
                PointerAddress = GetPatchDataPointerAddress();

                // Universal Options
                while (i < 5)
                if (UniversalDebugBooleans[i]) {
                    WriteBytes(PointerAddress, GetPatchPointerData(i++));
                    PointerAddress += 8;
                }

                // Game-Specific Options
                WriteByte(0x0, (byte)(GSDebugBooleans[4] ? 0x01 : 0));
                WriteByte(0x0, (byte)(GSDebugBooleans[4] ? 0x01 : 0));
                WriteByte(0x0, (byte)(GSDebugBooleans[4] ? 0x01 : 0));
                WriteByte(0x0, (byte)(GSDebugBooleans[4] ? 0x01 : 0));
            }
        }

        /// <summary>  </summary>
        /// <param name="PatchIndex">0: Disable FPS<br/>1: Align Menus Right<br/>2: Prog Pause On Menu Open<br/>3: Prog Pause On Menu Close (The Former + 1)<br/> 4: Swap Circle</param>
        /// <returns> The Desired Address, Based On The Game<br/>(Determined by bytes read at 0x60 in the selected executable),<br/>as well as PatchIndex for the type of patch</returns>
        public byte[] GetPatchPointerData(int PatchIndex) {
            switch (Game) {
                case UC1100:
                    switch (PatchIndex) {
                        default: return null;
                        case 0: return UC1100DisableFPS;
                        case 1: return UC1100RightAlign;
                        case 2: return UC1100ProgPause;
                        case 3: return new byte[] { UC1100ProgPause[0], UC1100ProgPause[1], (byte)(UC1100ProgPause[2] + 1) }; //prog pause on close
                        case 4: return UC1100SwapCircle;
                    }

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
                    break;
                     
                case T2107:
                    break;

                case T2109:
                    break;
            }
            return new byte[] { 0x00, 0x00, 0x00, 0x00 };
        }

        public static int GetPatchDataPointerAddress() {
            switch (Game) {
                case UC1100: return 0x94ed8d;

                case UC1102: return 0x915531;

                case UC2100: return 0;

                case UC2102: return 0;

                case UC3100: return 0;

                case UC3102: return 0;

                case T1R100: return 0;

                case T1R109: return 0;

                case T1R11X: return 0;

                case T2100: return 0;

                case T2107: return 0;

                case T2109: return 0;
            }
            return 0;
        }
        private void DisableDebugTextBtn_SClick(object sender, EventArgs e) { DisableDebugTextBtn_Click(sender, e); MouseScrolled = 1; }
        private void DisableDebugTextBtn_Click(object sender, EventArgs e) => Invert((Control)sender, 0);
        private void MenuRightAlignBtn_Click(object sender, EventArgs e) => Invert((Control)sender, 1);
        private void RightMarginBtn_Click(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.None) RightMargin += (byte)(e.Delta / 120);
            else RightMargin += 5;
            ((Control)sender).Text = $"{((Control)sender).Text.Remove(((Control)sender).Text.LastIndexOf(' '))} {RightMargin}";
        }
        private void ProgPauseOnOpenBtn_Click(object sender, EventArgs e) => Invert((Control)sender, 2);
        private void ProgPauseOnCloseBtn_Click(object sender, EventArgs e) => Invert((Control)sender, 3);



#if DEBUG
        public delegate void ResetDelegate();
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
        public static void ResetCustomOptions() {
            #if DEBUG
            FormShouldReset = false;
            Dev.DebugOut("Resetting Form And Main Stream");
            #endif
            if (Game == 0) return;

            ActiveForm.Controls.Find("BorderBox", true)[0].Size = OriginalBorderScale;
            ActiveForm.Size = OriginalFormScale;

            for (int index = 0; index < ControlsToMove.Length; index++) {
                ControlsToMove[index].Location = OriginalControlPositions[index];
            }
            for (int i = 0; i < GSDebugOptions.Length; i++)
            if (GSDebugOptions[i] != null) GSDebugOptions[i].Dispose();
            
            MainStreamIsOpen = false;
            MainStream.Dispose();
            ActiveForm.Controls.Find("CustomDebugOptionsLabel", true)[0].Visible = true;
            ActiveForm.Controls.Find("ConfirmPatchesBtn", true)[0].Dispose();
            ActiveForm.Controls.Find("ResetBtn", true)[0].Dispose();
            Game = 0;
        }
    }
}