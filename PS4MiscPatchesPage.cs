using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dobby.Common;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Data.SqlTypes;
using System.Drawing.Text;

namespace Dobby {
    internal class PS4MiscPatchesPage : Form {
        public PS4MiscPatchesPage() {
            InitializeComponent();
            BorderFunc(this);
            AddControlEventHandlers(Controls);
#if false
            if (FormResetThread.ThreadState != ThreadState.Running)
            FormResetThread.Start();
            if (DebugOutputOverrideThread.ThreadState != ThreadState.Running)
                DebugOutputOverrideThread.Start();

#endif
        }
        public void InitializeComponent() {
            this.MainLabel = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.ProgPauseOnCloseBtn = new System.Windows.Forms.Button();
            this.CustomDebugOptionsLabel = new System.Windows.Forms.Label();
            this.UniversalPatchesLabel = new System.Windows.Forms.Label();
            this.GameSpecificPatchesLabel = new System.Windows.Forms.Label();
            this.ProgPauseOnOpenBtn = new System.Windows.Forms.Button();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.DisableDebugTextBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.PausedIconBtn = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ExecutablePathBox = new System.Windows.Forms.TextBox();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.MenuScaleBtn = new System.Windows.Forms.Button();
            this.MenuAlphaBtn = new System.Windows.Forms.Button();
            this.GameInfoLabel = new System.Windows.Forms.Label();
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
            this.Info.Location = new System.Drawing.Point(5, 348);
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
            this.CreditsBtn.Location = new System.Drawing.Point(1, 300);
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
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 278);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InfoHelpBtn.Size = new System.Drawing.Size(147, 22);
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
            // ProgPauseOnCloseBtn
            // 
            this.ProgPauseOnCloseBtn.BackColor = System.Drawing.Color.DimGray;
            this.ProgPauseOnCloseBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ProgPauseOnCloseBtn.FlatAppearance.BorderSize = 0;
            this.ProgPauseOnCloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProgPauseOnCloseBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.ProgPauseOnCloseBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ProgPauseOnCloseBtn.Location = new System.Drawing.Point(1, 122);
            this.ProgPauseOnCloseBtn.Name = "ProgPauseOnCloseBtn";
            this.ProgPauseOnCloseBtn.Size = new System.Drawing.Size(286, 23);
            this.ProgPauseOnCloseBtn.TabIndex = 56;
            this.ProgPauseOnCloseBtn.Text = "Disable Debug Pause On Menu Close: Yes";
            this.ProgPauseOnCloseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProgPauseOnCloseBtn.UseVisualStyleBackColor = false;
            this.ProgPauseOnCloseBtn.Click += new System.EventHandler(this.ProgPauseOnCloseBtn_Click);
            // 
            // CustomDebugOptionsLabel
            // 
            this.CustomDebugOptionsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomDebugOptionsLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomDebugOptionsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CustomDebugOptionsLabel.Location = new System.Drawing.Point(3, 183);
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
            this.UniversalPatchesLabel.Location = new System.Drawing.Point(105, 34);
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
            this.GameSpecificPatchesLabel.Location = new System.Drawing.Point(96, 159);
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
            this.ProgPauseOnOpenBtn.Location = new System.Drawing.Point(1, 99);
            this.ProgPauseOnOpenBtn.Name = "ProgPauseOnOpenBtn";
            this.ProgPauseOnOpenBtn.Size = new System.Drawing.Size(283, 23);
            this.ProgPauseOnOpenBtn.TabIndex = 51;
            this.ProgPauseOnOpenBtn.Text = "Disable Debug Pause On Menu Open: Yes";
            this.ProgPauseOnOpenBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProgPauseOnOpenBtn.UseVisualStyleBackColor = false;
            this.ProgPauseOnOpenBtn.Click += new System.EventHandler(this.ProgPauseOnOpenBtn_Click);
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 259);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine3.TabIndex = 32;
            this.SeperatorLine3.Text = "______________________________________________________________";
            // 
            // DisableDebugTextBtn
            // 
            this.DisableDebugTextBtn.BackColor = System.Drawing.Color.DimGray;
            this.DisableDebugTextBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisableDebugTextBtn.FlatAppearance.BorderSize = 0;
            this.DisableDebugTextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisableDebugTextBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.DisableDebugTextBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DisableDebugTextBtn.Location = new System.Drawing.Point(1, 53);
            this.DisableDebugTextBtn.Name = "DisableDebugTextBtn";
            this.DisableDebugTextBtn.Size = new System.Drawing.Size(267, 23);
            this.DisableDebugTextBtn.TabIndex = 46;
            this.DisableDebugTextBtn.Text = "Disable 2D Debug Text On Startup: Yes";
            this.DisableDebugTextBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisableDebugTextBtn.UseVisualStyleBackColor = false;
            this.DisableDebugTextBtn.Click += new System.EventHandler(this.DisableDebugTextBtn_Click);
            this.DisableDebugTextBtn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.DisableDebugTextBtn_SClick);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 322);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BackBtn.Size = new System.Drawing.Size(75, 22);
            this.BackBtn.TabIndex = 41;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // PausedIconBtn
            // 
            this.PausedIconBtn.BackColor = System.Drawing.Color.DimGray;
            this.PausedIconBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PausedIconBtn.FlatAppearance.BorderSize = 0;
            this.PausedIconBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PausedIconBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.PausedIconBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PausedIconBtn.Location = new System.Drawing.Point(1, 76);
            this.PausedIconBtn.Name = "PausedIconBtn";
            this.PausedIconBtn.Size = new System.Drawing.Size(230, 23);
            this.PausedIconBtn.TabIndex = 49;
            this.PausedIconBtn.Text = "Disable Debug PAUSED Icon: Yes";
            this.PausedIconBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PausedIconBtn.UseVisualStyleBackColor = false;
            this.PausedIconBtn.Click += new System.EventHandler(this.MenuRightAlignBtn_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.DimGray;
            this.BrowseButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BrowseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BrowseButton.Location = new System.Drawing.Point(237, 222);
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
            this.ExecutablePathBox.Location = new System.Drawing.Point(3, 222);
            this.ExecutablePathBox.Name = "ExecutablePathBox";
            this.ExecutablePathBox.Size = new System.Drawing.Size(233, 23);
            this.ExecutablePathBox.TabIndex = 38;
            this.ExecutablePathBox.Text = " Select An exe To Modify";
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 137);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine1.TabIndex = 37;
            this.SeperatorLine1.Text = "______________________________________________________________";
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 197);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine2.TabIndex = 36;
            this.SeperatorLine2.Text = "______________________________________________________________";
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
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 8.5F);
            this.GameInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GameInfoLabel.Location = new System.Drawing.Point(2, 248);
            this.GameInfoLabel.Name = "GameInfoLabel";
            this.GameInfoLabel.Size = new System.Drawing.Size(316, 19);
            this.GameInfoLabel.TabIndex = 40;
            this.GameInfoLabel.Text = "No File Selected";
            this.GameInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PS4MiscPatchesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 370);
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
            this.Controls.Add(this.PausedIconBtn);
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
            this.Name = "PS4MiscPatchesPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private static void BorderFunc(Form form) {
            BorderBox = new GroupBox();
            BorderBox.Location = new Point(0, -6);
            BorderBox.Name = "BorderBox";
            BorderBox.Size = new Size(form.Size.Width, form.Size.Height + 7);
            form.Controls.Add(BorderBox);
        }


        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Misc Patches Page Variables    --\\\
        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        #region Misc Patches Page Variables

        /// <summary> Array of Controls to Move When Loading >1 Game-Specific Debug Options
        /// </summary>
        private static Control[] ControlsToMove;

        /// <summary> Variable Used When Adjusting Form Scale And Control Positions
        /// </summary>
        private static int
            ButtonIndex = 0,
            RealSize = 0,
            RB_StartPos
        ;

        /// <summary> Var Used In Adjusting Form Size To Fit Extra Buttons
        /// </summary>
        private static float Y_Axis_Addative = 6;

        /// <summary>
        /// MenuScaleBtn        <br/>
        /// MenuAlphaBtn        <br/>
        /// FOVBtn              <br/>
        /// MenuShadowedTextBtn <br/>
        /// VersionTxtBtn       <br/>
        /// RightAlignBtn       <br/>
        /// RightMarginBtn
        /// </summary>
        private enum IDS {
            MenuScaleBtn,
            MenuAlphaBtn,
            FOVBtn,
            MenuShadowedTextBtn,
            VersionTxtBtn,
            RightAlignBtn,
            RightMarginBtn
        }

        /// <summary>
        ///      0: Disable FPS
        ///<br/> 1: Paused Icon
        ///<br/> 2: Prog Pause On Open 
        ///<br/> 3: Prog Pause On Close
        /// </summary>
        private static bool[] UniversalDebugBooleans = new bool[4];


        /// <summary> Struct For Creating Dynamic Patch Buttons
        /// </summary>
        private struct DynamicPatchButtons {

                public static object[] PatchValues = new object[] {
                    0.60f,
                    0.85f,
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
                    "MenuScaleBtn_f",
                    "MenuAlphaBtn_f",
                    "FOVBtn_f",
                    "MenuShadowTextBtn_b",
                    "VersionTxtBtn_b",
                    "MenuRightAlignBtn_b",
                    "RightMarginBtn_i"
                };

                private static readonly string[] Text = new string[] {
                    "Set Dev Menu Scale: ",             // default=0.60
                    "Set DMenu BG Opacity: ",           // default=0.85
                    "Adjust Non-ADS FOV: ",             // default=1.00
                    "Enable Debug Menu Text Shadow: ",  // default=No
                    "Disable Version Text: ",           // default=No
                    "Align Debug Menus To The Right: ", // default=No
                    "Set Distance From Right Side: "    // default=10
                };

                private static readonly string[] Hint = new string[] {
                    "Hint",
                    "Hint",
                    "Only Effects The Camera While Not Aiming",
                    "Hint",
                    "Hint",
                    "Moves The Dev/Quick Menus To The Right Of The Screen",
                    "Hint",
                };

                /// <summary> Buttons For Game-Specific Debug Options Loaded Based On The Game Chosen <br/><br/>
                /// 1: MenuScaleBtn                                                                        <br/>
                /// 2: MenuScaleBtn                                                                        <br/>
                /// 3: MenuShadowTextBtn                                                                   <br/>
                /// 4: FOVBtn                                                                              <br/>
                /// 5: VersionTxtBtn
                /// </summary>
                public static Button[] Buttons { get; private set; } // Initialized Once An Executable's Selected


                /////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\
                ///--     Dynamic Buttons Main Functions    --\\\
                /////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\
                #region Dynamic Buttons Main Functions
                /// <summary> Enable Specific Buttons
                /// </summary>
                public void EnableDynamicPatchButtons(IDS[] buttons) {
                    Buttons = new Button[Text.Length + 1];
                    if(buttons == null) goto EnableAll;

                    foreach(int id in buttons) {
                        Buttons[id] = new Button();
                        ActiveForm.Controls.Add(Buttons[id]);
                    }
                    return;

                EnableAll: for(index = 0; index < Buttons.Length - 1; index++) {
                        Buttons[index] = new Button();
                        ActiveForm.Controls.Add(Buttons[index]);
                    }
                }

                /// <summary> Enable A Specific Button
                /// </summary>
                public void EnableDynamicPatchButtons(IDS button) {
                    Buttons = new Button[Text.Length + 1];

                    Buttons[(int)button] = new Button();
                    ActiveForm.Controls.Add(Buttons[(int)button]);
                }
                public static void ResetCustomOptions() => ResetCustomOptions(null, null);
                public static void ResetCustomOptions(object _, EventArgs __) {
                    if(Game == 0) return;
    #if DEBUG
                    FormShouldReset = false;
                    Dev.DebugOut("Resetting Form And Main Stream");
    #endif
                    int index = 0;

                    ActiveForm.Controls.Find("BorderBox", true)[0].Size = OriginalBorderScale;
                    ActiveForm.Size = OriginalFormScale;
                    OriginalFormScale = Size.Empty;

                    for(; index < ControlsToMove.Length; index++)
                        ControlsToMove[index].Location = OriginalControlPositions[index];

                    foreach(Button button in Buttons)
                        button?.Dispose();

                    MainStreamIsOpen = false;
                    MainStream?.Dispose();

                    ActiveForm.Controls.Find("CustomDebugOptionsLabel", true)[0].Visible = true;
                    ActiveForm.Controls.Find("ConfirmPatchesBtn", true)[0].Dispose();
                    ActiveForm.Controls.Find("ResetBtn", true)[0].Dispose();
                    Game = 0;
                }

                public void AddDynamicButtonsToForm(Form activeForm, int ButtonsVerticalStartPos) {
                    // Set The Amount of Pixels To Move Shit Based On How Much Shit Has Been Shat.                                                                                                                  shit
                    foreach(Control control in Buttons)
                        if(control != null) RealSize++;

                    // Move The Shit
                    if(RealSize > 1) {
                        Y_Axis_Addative = 6;
                        for(int i = RealSize; i > 0; i--) {
                            Y_Axis_Addative += 2.5f;
                        }
                    }


                    // Resize The BorderBox & Form, Then Move Each Control
                    BorderBox.Size = new Size(BorderBox.Size.Width, BorderBox.Size.Height + (int)(Y_Axis_Addative * RealSize) + 50);
                    activeForm.Size = new Size(activeForm.Size.Width, activeForm.Size.Height + (int)(Y_Axis_Addative * RealSize) + 50);
                    foreach(Control A in ControlsToMove)
                        A.Location = new Point(A.Location.X, A.Location.Y + (int)(Y_Axis_Addative * RealSize));

                    // Move The Controls Below The Confirm And Reset Buttons A Bit Farther Down To Make Room For Them
                    for(int i = 4; i < ControlsToMove.Length; i++)
                        ControlsToMove[i].Location = new Point(ControlsToMove[i].Location.X, ControlsToMove[i].Location.Y + 46);

                    RunCheck:
                    if(ButtonIndex >= Buttons.Length - 1) return;

                    // Skip disabled buttons or return if the end of the collection is reached
                    if(Buttons[ButtonIndex] == null) {
                        ButtonIndex++;
                        goto RunCheck;
                    }

                    Buttons[ButtonIndex].Name = Name[ButtonIndex];
                    Buttons[ButtonIndex].TabIndex = ButtonIndex;
                    Buttons[ButtonIndex].Location = new Point(1, ButtonsVerticalStartPos);
                    Buttons[ButtonIndex].Size = new Size(ActiveForm.Width - 11, 23);
                    Buttons[ButtonIndex].Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
                    Buttons[ButtonIndex].Text = $"{Text[ButtonIndex]}{PatchValues[ButtonIndex]}";
                    Buttons[ButtonIndex].TextAlign = ContentAlignment.MiddleLeft;
                    Buttons[ButtonIndex].FlatAppearance.BorderSize = 0;
                    Buttons[ButtonIndex].FlatStyle = FlatStyle.Flat;
                    Buttons[ButtonIndex].ForeColor = SystemColors.Control;
                    Buttons[ButtonIndex].BackColor = Color.DimGray;
                    Buttons[ButtonIndex].Cursor = Cursors.Cross;
                    Buttons[ButtonIndex].MouseEnter += ControlHover;
                    Buttons[ButtonIndex].MouseDown += new MouseEventHandler(MouseDownFunc);
                    Buttons[ButtonIndex].MouseUp += new MouseEventHandler(MouseUpFunc);
                    Buttons[ButtonIndex].MouseEnter += HoverString;
                    Buttons[ButtonIndex].MouseLeave += ControlLeave;
                    Buttons[ButtonIndex].BringToFront();

                    if(PatchValues[ButtonIndex].GetType().ToString() == "System.Boolean")
                        Buttons[ButtonIndex].Click += DBtn_Click;

                    else if(PatchValues[ButtonIndex].GetType().ToString() == "System.Single") {
                        Buttons[ButtonIndex].MouseWheel += FloatFunc;
                        Buttons[ButtonIndex].MouseDown += FloatClick;
                    }

                    else if(PatchValues[ButtonIndex].GetType().ToString() == "System.Byte") {
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
                private void DBtn_Click(object sender, EventArgs e) => ToggleFunc((Control)sender, ((Control)sender).TabIndex);
                private void ToggleFunc(Control Control, int ButtonIndex) {
                    if(MouseScrolled == 1 || MouseIsDown == 0 || CurrentControl != Control.Name) return;

                    PatchValues[ButtonIndex] = !(bool)PatchValues[ButtonIndex];
                    Control.Text = $"{Control.Text.Remove(Control.Text.LastIndexOf(' '))} {(bool)PatchValues[ButtonIndex]}";
                }
            

                private void FloatClick(object sender, MouseEventArgs e) => FloatClickFunc((Control)sender, ((Control)sender).TabIndex, e.Button);
                private void FloatClickFunc(Control Control, int ButtonIndex, MouseButtons Button) {
                    if(CurrentControl != Control.Name) return;
                    var currentFloat = (float)PatchValues[ButtonIndex]; // Avoid CS0445

                    if(Button == MouseButtons.Left) PatchValues[ButtonIndex] = (float)Math.Round(currentFloat += 0.1f, 4);
                    else PatchValues[ButtonIndex] = (float)Math.Round(currentFloat -= 0.1f, 4);

                    Control.Text = $"{Control.Text.Remove(Control.Text.LastIndexOf(' '))} {PatchValues[ButtonIndex]}";
                }

                private void FloatFunc(object sender, MouseEventArgs e) => FloatScrollFunc((Control)sender, ((Control)sender).TabIndex, e.Delta);
                private void FloatScrollFunc(Control Control, int ButtonIndex, int WheelDelta) {
                    if(CurrentControl != Control.Name) return;
                    var currentFloat = (float)PatchValues[ButtonIndex]; // Avoid CS0445

                    PatchValues[ButtonIndex] = (float)Math.Round(currentFloat += WheelDelta / 12000.0F, 4);
                    Control.Text = $"{Control.Text.Remove(Control.Text.LastIndexOf(' '))} {PatchValues[ButtonIndex]}";
                }


                private void IntClick(object sender, MouseEventArgs e) => IntClickFunc((Control)sender, ((Control)sender).TabIndex, e.Button);
                private void IntClickFunc(Control Control, int ButtonIndex, MouseButtons Button) {
                    if(CurrentControl != Control.Name) return;
                    var currentInt = (byte)PatchValues[ButtonIndex]; // Avoid CS0445

                    if(Button == MouseButtons.Left) currentInt += 5;
                    else currentInt -= 5;
                    PatchValues[ButtonIndex] = currentInt;
                    Control.Text = $"{Control.Text.Remove(Control.Text.LastIndexOf(' '))} {PatchValues[ButtonIndex]}";
                }

                private void IntFunc(object sender, MouseEventArgs e) => IntScrollFunc((Control)sender, ((Control)sender).TabIndex, e.Delta);
                private void IntScrollFunc(Control Control, int ButtonIndex, int WheelDelta) {
                    if(CurrentControl != Control.Name) return;
                    var currentInt = (byte)PatchValues[ButtonIndex]; // Avoid CS0445

                    currentInt += (byte)(WheelDelta / 120);
                    PatchValues[ButtonIndex] = currentInt;

                    Control.Text = $"{Control.Text.Remove(Control.Text.LastIndexOf(' '))} {PatchValues[ButtonIndex]}";
                }

                private void HoverString(object sender, EventArgs e) => SetInfoLabelText(Hint[((Control)sender).TabIndex]);
                #endregion
        }
        #endregion



        #region Event Handlers For Basic Patches Available For Each Game
        ///////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Event Handlers For Basic Patches Available For Each Game     --\\\
        ///////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private void DisableDebugTextBtn_SClick(object sender, EventArgs e) {
            DisableDebugTextBtn_Click(sender, e);
            MouseScrolled = 1;
        }
        private void DisableDebugTextBtn_Click(object sender, EventArgs e) => Invert((Control)sender, 0);
        private void MenuRightAlignBtn_Click(object sender, EventArgs e)   => Invert((Control)sender, 1);
        private void ProgPauseOnOpenBtn_Click(object sender, EventArgs e)  => Invert((Control)sender, 2);
        private void ProgPauseOnCloseBtn_Click(object sender, EventArgs e) => Invert((Control)sender, 3);


        void Invert(Control Control, int OptionIndex) {
            if(MouseScrolled == 1 || MouseIsDown == 0 || CurrentControl != Control.Name) return;

            UniversalDebugBooleans[OptionIndex] = !UniversalDebugBooleans[OptionIndex];
            Control.Text = $"{Control.Text.Remove(Control.Text.LastIndexOf(' '))} {(UniversalDebugBooleans[OptionIndex] ? "Yes" : "No")}";
        }
        #endregion



        //////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Misc Patches Page Main Functions    --\\\
        //////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Misc Patches Page Main Functions
        private void BrowseButton_Click(object sender, EventArgs e) {
            if(OriginalFormScale != Size.Empty) DynamicPatchButtons.ResetCustomOptions(null, null);

            FileDialog OpenedFile = new OpenFileDialog {
                Filter = "Executable|*.elf;*.bin",
                Title = "Select Either Of The Game's Executables"
            };
            if(OpenedFile.ShowDialog() == DialogResult.OK) {
                DynamicPatchButtons.ResetCustomOptions();
                ActiveFilePath = ExecutablePathBox.Text = OpenedFile.FileName;
                LocalExecutableCheck = new byte[4];

                MainStream = File.Open(OpenedFile.FileName, FileMode.Open, FileAccess.ReadWrite);
                MainStream.Position = 0x60; MainStream.Read(LocalExecutableCheck, 0, 4);
                Game = BitConverter.ToInt32(LocalExecutableCheck, 0);

                GameInfoLabel.Text = EbootPatchPage.GetGameId();

                MainStreamIsOpen = true;
                CustomDebugOptionsLabel.Visible = IsActiveFilePCExe = false;
                LoadGameSpecificMenuOptions();
                if(!Dev.REL) Console.Clear();
            }
        }

        public void LoadGameSpecificMenuOptions() {
            DynamicPatchButtons gsButtons = new DynamicPatchButtons();

            // Assign values to variables made to keep track of the default form size/control postions for the reset button. Doing it on page init is annoying 'cause designer memes
            if(OriginalFormScale == Size.Empty) {
                Dev.DebugOut("Setting Original Scale Variables");

                // Every Control Below The "Game Specific Patches" Label
                ControlsToMove = new Control[] {
                    ActiveForm.Controls.Find("SeperatorLine2", true)[0],
                    ActiveForm.Controls.Find("BrowseButton", true)[0],
                    ActiveForm.Controls.Find("ExecutablePathBox", true)[0],
                    ActiveForm.Controls.Find("GameInfoLabel", true)[0],
                    ActiveForm.Controls.Find("SeperatorLine3", true)[0],
                    ActiveForm.Controls.Find("InfoHelpBtn", true)[0],
                    ActiveForm.Controls.Find("CreditsBtn", true)[0],
                    ActiveForm.Controls.Find("BackBtn", true)[0],
                    ActiveForm.Controls.Find("Info", true)[0]
                };
                OriginalFormScale = Size;
                OriginalBorderScale = ActiveForm.Controls.Find("BorderBox", true)[0].Size;
                OriginalControlPositions = new Point[ControlsToMove.Length];

                for(index = 0; index < ControlsToMove.Length; index++)
                OriginalControlPositions[index] = ControlsToMove[index].Location;
            }

            RB_StartPos = GameInfoLabel.Location.Y + GameInfoLabel.Size.Height + 1; // Right Below The GameInfoLabel
            CustomDebugOptionsLabel.Visible = false;

            // In Case Of Repeat Uses
            RealSize = ButtonIndex = 0;

            // Enable Buttons Based On Which Patches Are Available For The Current Game
            switch (Game) {
                case UC1100: gsButtons.EnableDynamicPatchButtons(IDS.VersionTxtBtn);
                    Dev.DebugOut("UC1 1.00");
                    break;
                case UC1102: gsButtons.EnableDynamicPatchButtons(IDS.VersionTxtBtn);
                    Dev.DebugOut("UC1 1.02");
                    break;
                case UC2100: gsButtons.EnableDynamicPatchButtons(IDS.VersionTxtBtn);
                    Dev.DebugOut("UC2 1.00");
                    break;
                case UC2102: gsButtons.EnableDynamicPatchButtons(IDS.VersionTxtBtn);
                    Dev.DebugOut("UC2 1.02");
                    break;
                case UC3100: gsButtons.EnableDynamicPatchButtons(IDS.VersionTxtBtn);
                    Dev.DebugOut("UC3 1.00");
                    break;
                case UC3102: gsButtons.EnableDynamicPatchButtons(IDS.VersionTxtBtn);
                    Dev.DebugOut("UC3 1.02");
                    break;
                case T1R100: gsButtons.EnableDynamicPatchButtons(IDS.VersionTxtBtn);
                    Dev.DebugOut("T1R 1.00");
                    break;
                case T1R109: gsButtons.EnableDynamicPatchButtons(IDS.VersionTxtBtn);
                    Dev.DebugOut("T1R 1.09");
                    break;
                case T1R110:
                case T1R111: gsButtons.EnableDynamicPatchButtons(IDS.VersionTxtBtn);
                    Dev.DebugOut("T1R 1.1X");
                    break;
                case T2100: gsButtons.EnableDynamicPatchButtons(new IDS[] { IDS.MenuScaleBtn, IDS.MenuShadowedTextBtn, IDS.VersionTxtBtn, IDS.RightAlignBtn });
                    Dev.DebugOut("Tlou 2 1.00");
                    break;
                case T2107: gsButtons.EnableDynamicPatchButtons(new IDS[] { IDS.MenuScaleBtn, IDS.MenuAlphaBtn, IDS.MenuShadowedTextBtn, IDS.VersionTxtBtn, IDS.RightAlignBtn });
                    Dev.DebugOut("Tlou 2 1.07"); //! /\
                    break;
                case T2109: gsButtons.EnableDynamicPatchButtons(null);
                    Dev.DebugOut("Tlou 2 1.09");
                    break;
            }

            gsButtons.AddDynamicButtonsToForm(this, (GameSpecificPatchesLabel.Location.Y + GameSpecificPatchesLabel.Size.Height + 1));



            // Create Confirm And Reset Buttons Once The Rest Are Created
            RB_StartPos = GameInfoLabel.Location.Y + GameInfoLabel.Size.Height + 1; // Right Below The GameInfoLabel
            Button ConfirmPatchesBtn = new Button();
            ActiveForm.Controls.Add(ConfirmPatchesBtn);
            ConfirmPatchesBtn.TabIndex = ButtonIndex;
            ConfirmPatchesBtn.Name = "ConfirmPatchesBtn";
            ConfirmPatchesBtn.Location = new Point(1, RB_StartPos);
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
            ResetBtn.Location = new Point(1, RB_StartPos + 24);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(ActiveForm.Width - 11, 23);
            ResetBtn.Text = "Reset";
            ResetBtn.TextAlign = ContentAlignment.MiddleLeft;
            ResetBtn.UseVisualStyleBackColor = false;
            ResetBtn.Click += new EventHandler(DynamicPatchButtons.ResetCustomOptions);
            ResetBtn.MouseEnter += ControlHover;
            ResetBtn.MouseLeave += ControlLeave;
            ResetBtn.BringToFront();
        }

        private static void ConfirmBtn_Click(object sender, EventArgs e) {
            using (MainStream) {
                index = 0;
                int BootSettingsCallerAddress,

                // Write BootSettings Function's Assembly To Game Executable
                BootSettingsAddress = GetAddressToWriteBootSettings();
                WriteBytes(BootSettingsAddress, GetBootSettingsBytes());

                // Write Function Call To Call BootSettings
                BootSettingsCallerAddress = GetAddressToCallBootSettings();
                WriteBytes(BootSettingsCallerAddress, GetBytesToCallBootSettings());

                // Universal Options
                while(index < UniversalDebugBooleans.Length)
                if (UniversalDebugBooleans[index]) {
                    WriteBytes((BootSettingsAddress + 0x28), GetPatchPointerData(index++));
                    BootSettingsAddress += 8;
                }
                
                // Game-Specific Options
                for(index = 0; ; index++) {

                    WriteByte(BootSettingsAddress, (byte)(DynamicPatchButtons.PatchValues[4] ? 0x01 : 0));
                    BootSettingsAddress += 8;
                }
            }
        }


        /// <summary>
        ///  0: Disable FPS<br/>
        ///  1: Align Menus Right<br/>
        ///  2: Prog Pause On Menu Open<br/>
        ///  3: Prog Pause On Menu Close (The Former + 1)<br/>
        ///  4: Swap Circle
        /// </summary>
        /// <param name="PatchIndex"> The Patch To Get The Pointer For
        /// </param>
        /// <returns>
        /// The Desired Address, Based On The Current Game Value (Determined by bytes read at 0x60 in the selected executable), <br/>
        /// as well as PatchIndex for the type of patch
        /// </returns>
        private static byte[] GetPatchPointerData(int PatchIndex) {
            switch (Game) {
                case UC1100:
                switch (PatchIndex) {
                    default: Dev.DebugOut($"Game Was UC1 1.00, But Patch Index Was Invalid ({PatchIndex})"); return null;
                    case 0: return UC1100DisableFPS;
                    case 1: return UC1100PausedIcon;
                    case 2: return UC1100ProgPause;
                    case 3: return UC1100ProgPauseOnExit;
                }

                case UC1102:
                switch (PatchIndex) {
                    default: Dev.DebugOut($"Game Was UC1 1.02, But Patch Index Was Invalid ({PatchIndex})"); return null;
                    case 0: return UC1102DisableFPS;
                    case 1: return UC1102PausedIcon;
                    case 2: return UC1102ProgPause;
                    case 3: return UC1102ProgPauseOnExit;
                }

                case UC2100:
                switch (PatchIndex) {
                    default: Dev.DebugOut($"Game Was UC2 1.00, But Patch Index Was Invalid ({PatchIndex})"); return null;
                    case 0: return UC2100DisableFPS;
                    case 1: return UC2100PausedIcon;
                    case 2: return UC2100ProgPause;
                    case 3: return UC2100ProgPauseOnExit;
                }
                
                case UC2102:
                switch (PatchIndex) {
                    default: Dev.DebugOut($"Game Was UC2 1.02, But Patch Index Was Invalid ({PatchIndex})"); return null;
                    case 0: return UC2102DisableFPS;
                    case 1: return UC2102PausedIcon;
                    case 2: return UC2102ProgPause;
                    case 3: return UC2102ProgPauseOnExit;
                }

                case UC3100:
                switch (PatchIndex) {
                    default: Dev.DebugOut($"Game Was UC3 1.00, But Patch Index Was Invalid ({PatchIndex})"); return null;
                    case 0: return UC3100DisableFPS;
                    case 1: return UC3100RightAlign;
                    case 2: return UC3100ProgPause;
                    case 3: return UC3100ProgPauseOnExit;
                }

                case UC3102:
                switch (PatchIndex) {
                    default: Dev.DebugOut($"Game Was UC3 1.02, But Patch Index Was Invalid ({PatchIndex})"); return null;
                    case 0: return UC3102DisableFPS;
                    case 1: return UC3102RightAlign;
                    case 2: return UC3102ProgPause;
                    case 3: return UC3102ProgPauseOnExit;
                }

                case T1R100:
                    break;

                case T1R109:
                    break;

                case T1R110:
                case T1R111:
                    break;

                case T2100:
                switch (PatchIndex) {
                    default: Dev.DebugOut($"Game Was T2 1.00, But Patch Index Was Invalid ({PatchIndex})"); return null;
                    case 0: return T2100DisableFPS;
                    case 1: return T2100RightAlign;
                    case 2: return T2100ProgPause;
                    case 3: return T2100ProgPauseOnExit;
                    case 4: return T2100SwapCircle;
                }
                     
                case T2107:
                switch (PatchIndex) {
                    default: Dev.DebugOut($"Game Was T2 1.07, But Patch Index Was Invalid ({PatchIndex})"); return null;
                    case 0: return T2107DisableFPS;
                    case 1: return T2107RightAlign;
                    case 2: return T2107ProgPause;
                    case 3: return T2107ProgPauseOnExit;
                    case 4: return T2107SwapCircle;
                }

                case T2109:
                switch (PatchIndex) {
                    default: Dev.DebugOut($"Game Was T2 1.09, But Patch Index Was Invalid ({PatchIndex})"); return null;
                    case 0: return T2109DisableFPS;
                    case 1: return T2109RightAlign;
                    case 2: return T2109ProgPause;
                    case 3: return T2109ProgPauseOnExit;
                    case 4: return T2109SwapCircle;
                }
            }

            return new byte[] { 0x00, 0x00, 0x00, 0x00 };
        }


        private static byte[] GetBootSettingsBytes() {
            byte[] BootSettingsData = new byte[41];

            byte[][] BootSettingsBaseAdressPointers = new byte[][] {
                new byte [] { 0x96, 0x52, 0x6b, 0xff }, // UC1 1.00
                new byte [] { 0xc6, 0xea, 0x6e, 0xff }, // UC1 1.02
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // UC2 1.00
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // UC2 1.02
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // UC3 1.00
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // UC3 1.02
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // UC4 1.00
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // UC4 1.32
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // TLL 1.00
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // TLL 1.08
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // TLL 1.09
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // T2 1.00
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // T2 1.01
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // T2 1.02
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // T2 1.05
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // T2 1.07
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // T2 1.08
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // T2 1.09
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // T1R 1.00
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // T1R 1.06
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // T1R 1.08
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // T1R 1.10
                new byte [] { 0x00, 0x00, 0x00, 0x00 }, // T1R 1.11
                new byte [] { 0x00, 0x00, 0x00, 0x00 }
            };

            Buffer.BlockCopy(new byte[] { 0x41, 0x56, 0x48, 0x8d, 0x05 }, 0, BootSettingsData, 0, 5);
            Buffer.BlockCopy(BootSettingsBaseAdressPointers[0], 0, BootSettingsData, 0, 4);
            Buffer.BlockCopy(new byte[] { 0x48, 0x8d, 0x0d, 0x19, 0x00, 0x00, 0x00, 0x4c, 0x8b, 0x31, 0x49, 0x83, 0xfe, 0x00, 0x74, 0x0d, 0x49, 0x01, 0xc6, 0x41, 0x80, 0x36, 0x01, 0x48, 0x8d, 0x49, 0x08, 0xeb, 0xea, 0x41, 0x5e, 0xc3 },
                0, BootSettingsData, 0, 32
            );

            return BootSettingsData;
        }

        /// <summary> Returns The Address For The BootSettings Function. Pointer Data Starts At 0x28
        /// </summary>
        private static int GetAddressToWriteBootSettings() { // Address Is For BootSettings 0x28 For Pointers
            switch (Game) {
                case UC1100: return 0x94ED61; // 0x94ed8d;

                case UC1102: return 0x915531;  // 

                case UC2100: return 0; // 

                case UC2102: return 0; // 

                case UC3100: return 0; // 

                case UC3102: return 0; // 

                case T1R100: return 0; // 

                case T1R109: return 0; // 

                case T1R110:
                case T1R111: return 0; // 

                case T2100: return 0;  // 

                case T2107: return 0;  // 

                case T2109: return 0;  // 
            }
            return 0;
        }

        /// <summary>
        /// Returns The Address To Write A Function Call For The BootSettings Function,<br/>
        /// With The Data Being Gotten From 
        /// </summary>
        private static int GetAddressToCallBootSettings() {
            switch(Game) {
                case UC1100: return 0; // 

                case UC1102: return 0; // 

                case UC2100: return 0; // 

                case UC2102: return 0; // 

                case UC3100: return 0; // 

                case UC3102: return 0; // 

                case T1R100: return 0; // 

                case T1R109: return 0; // 

                case T1R110:
                case T1R111: return 0; // 

                case T2100: return 0; // 

                case T2107: return 0; // 

                case T2109: return 0; // 
            }
            return 0;
        }

        /// <summary> Returns The Data For The Custom Function Used To Call BootSettings
        /// </summary>
        private static byte[] GetBytesToCallBootSettings() {
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

                case T2107: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 };  // 

                case T2109: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 };  // 
            }
            return Array.Empty<byte>();
        }
        #endregion




        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        ///--     Repeated Page Functions     --\\\
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        #region Repeated Page Functions
        private void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.InfoHelpPage);
        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.CreditsPage);
        private void BackBtn_Click(object sender, EventArgs e) => BackFunc();
        #endregion


        ////////////////////\\\\\\\\\\\\\\\\\\\\
        ///--     Control Declarations     --\\\
        ////////////////////\\\\\\\\\\\\\\\\\\\\
        #region Control Declarations
        private static GroupBox BorderBox;

        private Label GameInfoLabel;
        private Label MainLabel;
        private Button CreditsBtn;
        private Button InfoHelpBtn;
        private Label Info;
        private Button ExitBtn;
        private Button MinimizeBtn;
        private Label SeperatorLine0;
        private Label SeperatorLine2;
        private Button BrowseButton;
        private TextBox ExecutablePathBox;
        private Button DisableDebugTextBtn;
        private Button ProgPauseOnOpenBtn;
        private Button PausedIconBtn;
        private Button MenuScaleBtn;
        private Button MenuAlphaBtn;
        private Label UniversalPatchesLabel;
        private Label GameSpecificPatchesLabel;
        private Label SeperatorLine3;
        private Label SeperatorLine1;
        private Label CustomDebugOptionsLabel;
        private Button ProgPauseOnCloseBtn;
        private Button BackBtn;
        #endregion

        ////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Debug Output Override For Misc Patches Page     --\\\
        ////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Debug Output Override For Misc Patches Page
#if DEBUG
        public delegate void ResetDelegate();
        public static ResetDelegate ResetDelegateInstance = new ResetDelegate(DynamicPatchButtons.ResetCustomOptions);
        public static bool FormShouldReset;


        public static Thread FormResetThread = new Thread(new ThreadStart(Wait));
        public static void Wait() {
            for(; ; ) {
                if(FormShouldReset) {
                    Dev.DebugOut("Initiating Reset");
                    ActiveForm.Invoke(ResetDelegateInstance);
                }
            }
        }


        public static Thread DebugOutputOverrideThread = new Thread(new ThreadStart(DebugOutputOverride));
        public static void DebugOutputOverride() {
            Dev.OverrideDebugOut = true;
            Console.Clear();
            for(int i = 8; ;) { // Create alt debugout that writes to specific spot in the array
                Console.CursorLeft = 0;
                Dev.DebugOut(Dev.BlankSpace($"FPS: {UniversalDebugBooleans[0]} | PausedIcon: {UniversalDebugBooleans[1]}"), 0);
                Dev.DebugOut(Dev.BlankSpace($"ProgPauseOnOpen: {UniversalDebugBooleans[2]} | ProgPauseOnExit: {UniversalDebugBooleans[3]}"), 2);
                /*Dev.DebugOut(Dev.BlankSpace($"Shadow: {GSDebugBooleans[0]} | VersionText: {GSDebugBooleans[1]} | Disable Version Text: {GSDebugBooleans[2]}"), 4);
                  Dev.DebugOut(Dev.BlankSpace($"Scale: {GSDebugFloats[0]} | Alpha: {GSDebugFloats[1]} | FoV: {GSDebugFloats[2]}"), 6);
                  Dev.DebugOut(Dev.BlankSpace($"Right Align: {GSDebugBooleans[3]}"));
                */
                foreach(Control c in DynamicPatchButtons.Buttons)
                    if(c != null) Dev.DebugOut(Dev.BlankSpace($"{c.Name} | {c.Location} | {c.TabIndex}"), i++);
                i = 8;
            }
        }
#endif
        #endregion
    }
}