﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using static Dobby.Common;
using System.Drawing;
using Dobby.Properties;

namespace Dobby {
    public class EbootPatchHelpPage : Form {
        public EbootPatchHelpPage() {
            InitializeComponent();
            AddControlEventHandlers(Controls);

            Question0Btn.Text = "- How Do I Get My Game's eboot.bin?";
            Question1Btn.Text = "- How Do I Extract My Game's .pkg?";
            Question2Btn.Text = "- How Do I Make A New .pkg Afterwards?";
            Question3Btn.Text = "- Why Is The Restored/Custom Button Disabled?";
        }

        public string[] headers = new string[] {
            "                  [Getting The Game's Executable]\n",
            "       [Extracting Your Game's .pkg \\ Dumping It]\n",
            "                             [Building A New .pkg]\n",
            "           [Why Is \"Restored/Custom\" Disabled?]\n"
        };

        /// <summary>
        /// #1 How Do I Get My Game's eboot.bin?<br/>
        /// #2 How Do I Extract My Game's .pkg?<br/>
        /// #3 How Do I Make A New .pkg Afterwards?<br/>
        /// #4 Why Is The Restored/Custom Button Disabled?<br/>
        /// </summary>
        bool[] Questions = new bool[4];
        bool DefaultQuestion = true;
        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EbootPatchHelpPage));
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.MainLabel = new System.Windows.Forms.Label();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.Question3Btn = new System.Windows.Forms.Button();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.WithSomeExceptionsLabel = new System.Windows.Forms.Label();
            this.Question2Btn = new System.Windows.Forms.Button();
            this.Question1Btn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.DefaultQuestionBtn = new System.Windows.Forms.Label();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.Question0Btn = new System.Windows.Forms.Button();
            this.MainBox.SuspendLayout();
            this.SuspendLayout();
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
            this.ExitBtn.TabIndex = 8;
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
            this.MinimizeBtn.TabIndex = 7;
            this.MinimizeBtn.Text = "--";
            this.MinimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MinimizeBtn.UseVisualStyleBackColor = false;
            this.MinimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            this.MinimizeBtn.MouseEnter += new System.EventHandler(this.MinimizeBtnMH);
            this.MinimizeBtn.MouseLeave += new System.EventHandler(this.MinimizeBtnML);
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.25F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(2, 7);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(265, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Eboot Patch Page Information";
            this.MainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MainLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // MainBox
            // 
            this.MainBox.Controls.Add(this.Question3Btn);
            this.MainBox.Controls.Add(this.SeperatorLine2);
            this.MainBox.Controls.Add(this.ExitBtn);
            this.MainBox.Controls.Add(this.MinimizeBtn);
            this.MainBox.Controls.Add(this.MainLabel);
            this.MainBox.Controls.Add(this.SeperatorLine0);
            this.MainBox.Controls.Add(this.WithSomeExceptionsLabel);
            this.MainBox.Controls.Add(this.Question2Btn);
            this.MainBox.Controls.Add(this.Question1Btn);
            this.MainBox.Controls.Add(this.Info);
            this.MainBox.Controls.Add(this.CreditsBtn);
            this.MainBox.Controls.Add(this.BackBtn);
            this.MainBox.Controls.Add(this.DefaultQuestionBtn);
            this.MainBox.Controls.Add(this.SeperatorLine1);
            this.MainBox.Controls.Add(this.Question0Btn);
            this.MainBox.Location = new System.Drawing.Point(0, -6);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(320, 507);
            this.MainBox.TabIndex = 5;
            this.MainBox.TabStop = false;
            this.MainBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.MainBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            // 
            // Question3Btn
            // 
            this.Question3Btn.FlatAppearance.BorderSize = 0;
            this.Question3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question3Btn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.Question3Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question3Btn.Location = new System.Drawing.Point(1, 399);
            this.Question3Btn.Name = "Question3Btn";
            this.Question3Btn.Size = new System.Drawing.Size(318, 24);
            this.Question3Btn.TabIndex = 4;
            this.Question3Btn.Text = resources.GetString("Question3Btn.Text");
            this.Question3Btn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Question3Btn.Click += new System.EventHandler(this.Question3Btn_Click);
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 411);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine2.TabIndex = 40;
            this.SeperatorLine2.Text = "______________________________________________________________";
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine0.TabIndex = 39;
            this.SeperatorLine0.Text = "______________________________________________________________";
            // 
            // WithSomeExceptionsLabel
            // 
            this.WithSomeExceptionsLabel.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold);
            this.WithSomeExceptionsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.WithSomeExceptionsLabel.Location = new System.Drawing.Point(184, 83);
            this.WithSomeExceptionsLabel.Name = "WithSomeExceptionsLabel";
            this.WithSomeExceptionsLabel.Size = new System.Drawing.Size(130, 17);
            this.WithSomeExceptionsLabel.TabIndex = 36;
            this.WithSomeExceptionsLabel.Text = "*(With Some Exceptions)";
            this.WithSomeExceptionsLabel.Click += new System.EventHandler(this.WithSomeExceptionsLabel_Click);
            this.WithSomeExceptionsLabel.MouseEnter += new System.EventHandler(this.WithSomeExceptionsLabelMH);
            this.WithSomeExceptionsLabel.MouseLeave += new System.EventHandler(this.WithSomeExceptionsLabelML);
            // 
            // Question2Btn
            // 
            this.Question2Btn.FlatAppearance.BorderSize = 0;
            this.Question2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question2Btn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.Question2Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question2Btn.Location = new System.Drawing.Point(1, 377);
            this.Question2Btn.Name = "Question2Btn";
            this.Question2Btn.Size = new System.Drawing.Size(318, 24);
            this.Question2Btn.TabIndex = 3;
            this.Question2Btn.Text = resources.GetString("Question2Btn.Text");
            this.Question2Btn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Question2Btn.Click += new System.EventHandler(this.Question2Btn_Click);
            // 
            // Question1Btn
            // 
            this.Question1Btn.FlatAppearance.BorderSize = 0;
            this.Question1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question1Btn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.Question1Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question1Btn.Location = new System.Drawing.Point(1, 356);
            this.Question1Btn.Name = "Question1Btn";
            this.Question1Btn.Size = new System.Drawing.Size(318, 24);
            this.Question1Btn.TabIndex = 2;
            this.Question1Btn.Text = resources.GetString("Question1Btn.Text");
            this.Question1Btn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Question1Btn.Click += new System.EventHandler(this.Question1Btn_Click);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(9, 483);
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
            this.CreditsBtn.Location = new System.Drawing.Point(1, 433);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(75, 23);
            this.CreditsBtn.TabIndex = 5;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 456);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 23);
            this.BackBtn.TabIndex = 6;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // DefaultQuestionBtn
            // 
            this.DefaultQuestionBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultQuestionBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DefaultQuestionBtn.Location = new System.Drawing.Point(3, 36);
            this.DefaultQuestionBtn.Name = "DefaultQuestionBtn";
            this.DefaultQuestionBtn.Size = new System.Drawing.Size(316, 291);
            this.DefaultQuestionBtn.TabIndex = 0;
            this.DefaultQuestionBtn.Text = resources.GetString("DefaultQuestionBtn.Text");
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 314);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine1.TabIndex = 38;
            this.SeperatorLine1.Text = "______________________________________________________________";
            // 
            // Question0Btn
            // 
            this.Question0Btn.FlatAppearance.BorderSize = 0;
            this.Question0Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question0Btn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.Question0Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question0Btn.Location = new System.Drawing.Point(1, 336);
            this.Question0Btn.Name = "Question0Btn";
            this.Question0Btn.Size = new System.Drawing.Size(318, 24);
            this.Question0Btn.TabIndex = 1;
            this.Question0Btn.Text = resources.GetString("Question0Btn.Text");
            this.Question0Btn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Question0Btn.Click += new System.EventHandler(this.Question0Btn_Click);
            // 
            // EbootPatchHelpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 500);
            this.Controls.Add(this.MainBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EbootPatchHelpPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.MainBox.ResumeLayout(false);
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
        public void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.CreditsPage);
        private void BackBtn_Click(object sender, EventArgs e) => BackFunc();
        #endregion


        #region Page-Specific Functions
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        ///--     Page-Specific Functions     --\\\
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        void LoadQuestions(int Index) {
            
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EbootPatchHelpPage));

            for (int i = 0; i < Questions.Length; i++) // Reset The Other Buttons
                if(i != Index) Questions[i] = false;

            Questions[Index] = !Questions[Index];

            if(Questions[Index] == false) {
                DefaultQuestion = true;
                DefaultQuestionBtn.Text = resources.GetString("DefaultQuestionBtn.Text");

                WithSomeExceptionsLabel.Size = new Size(130, 17);
                WithSomeExceptionsLabel.Location = new Point(184, 83);
                WithSomeExceptionsLabel.Text = "*(With Some Exceptions)";
                WithSomeExceptionsLabel.Font = new Font("Cambria", 8F, FontStyle.Bold);
                WithSomeExceptionsLabel.Visible = true;
                return;
            }
            else DefaultQuestion = false;

            DefaultQuestionBtn.Text = headers[Index] + resources.GetString($"Question{Index}Btn.Text");
            WithSomeExceptionsLabel.Visible = DefaultQuestion;

            if(Questions[1]) {
                WithSomeExceptionsLabel.Size = new Size(108, 15);
                WithSomeExceptionsLabel.Location = new Point(12, 80);
                WithSomeExceptionsLabel.Text = "Homebrew Store";
                WithSomeExceptionsLabel.Font = new Font("Cambria", 9.5F, FontStyle.Bold | FontStyle.Underline);
                WithSomeExceptionsLabel.Visible = true;
            }
        }
        private void Question0Btn_Click(object sender, EventArgs e) => LoadQuestions(0);
        private void Question1Btn_Click(object sender, EventArgs e) => LoadQuestions(1);
        private void Question2Btn_Click(object sender, EventArgs e) => LoadQuestions(2);
        private void Question3Btn_Click(object sender, EventArgs e) => LoadQuestions(3);

        private void WithSomeExceptionsLabel_Click(object sender, EventArgs e) {
            if (DefaultQuestion)
            MessageBox.Show("Some Misc. Patches Will Be Applied To Uncharted 4/Lost Legacy Multiplayer Eboots To Make The Game Playable");
            else
                if(MessageBox.Show("Do You Want To Open Your Browser To The Homebrew Store/Itemzflow Download Page?", "Open Itemzflow Download Page On pkg-zone?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Process.Start("https://pkg-zone.com/details/ITEM00001");
        }
        private void WithSomeExceptionsLabelMH(object sender, EventArgs e) => WithSomeExceptionsLabel.ForeColor = Color.Aqua;
        private void WithSomeExceptionsLabelML(object sender, EventArgs e) => WithSomeExceptionsLabel.ForeColor = Color.White;
        #endregion

        #region ControlDeclarations
        ////////////////////\\\\\\\\\\\\\\\\\\\\
        ///--     Control Declarations     --\\\
        ////////////////////\\\\\\\\\\\\\\\\\\\\
        public Button MinimizeBtn;
        public Label Info;
        public Label MainLabel;
        public GroupBox MainBox;
        public Button CreditsBtn;
        public Button BackBtn;
        private Button Question0Btn;
        private Button Question1Btn;
        private Button Question2Btn;
        private Button Question3Btn;
        private Label DefaultQuestionBtn;
        public Button ExitBtn;
        private Label WithSomeExceptionsLabel;
        public Label SeperatorLine0;
        public Label SeperatorLine1;
        public Label SeperatorLine2;
        #endregion
    }
}
