﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dobby.Common;
using System.Drawing;
using Dobby.Properties;
using System.Windows.Forms.VisualStyles;

namespace Dobby {
    public class EbootPatchHelpPage : Form {
        public EbootPatchHelpPage() {
            InitializeComponent();
            AddControlEventHandlers(Controls);
            Question1Btn.Text = "- How Do I Get My Game's eboot.bin?";
            Question2Btn.Text = "- How Do I Extract My Game's .pkg?";
            Question3Btn.Text = "- How Do I Make A New .pkg?";
            Question4Btn.Text = "- My .pkg Won't Install!";
        }
        public string[] headers = new string[] {
            "",
            "                [Getting The Game's Executable]\n",
            "     [Extracting Your Game's .pkg \\ Dumping It]\n",
            "                [Building A New .pkg]\n",
            "                [\"Fixing\" A Broken .pkg]\n"
        };

        private Label WithSomeExceptionsLabel;
        public bool[] Questions = new bool[] { false, false, false, false };
        public Label SeperatorLine3;
        public Label SeperatorLine1;
        public Label SeperatorLine2;
        public static int tst = 0;

        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EbootPatchHelpPage));
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.MainLabel = new System.Windows.Forms.Label();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.Question4Btn = new System.Windows.Forms.Button();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.WithSomeExceptionsLabel = new System.Windows.Forms.Label();
            this.Question3Btn = new System.Windows.Forms.Button();
            this.Question2Btn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.Question0Btn = new System.Windows.Forms.Label();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.Question1Btn = new System.Windows.Forms.Button();
            this.MainBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = Color.DimGray;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = SystemColors.Control;
            this.ExitBtn.Location = new Point(293, 7);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new Size(23, 23);
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
            this.MinimizeBtn.BackColor = Color.DimGray;
            this.MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MinimizeBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBtn.Font = new Font("Franklin Gothic Medium", 8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBtn.ForeColor = SystemColors.Control;
            this.MinimizeBtn.Location = new Point(270, 7);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new Size(23, 23);
            this.MinimizeBtn.TabIndex = 19;
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
            this.MainLabel.Font = new Font("Franklin Gothic Medium", 12.25F, FontStyle.Bold);
            this.MainLabel.ForeColor = SystemColors.Control;
            this.MainLabel.Location = new Point(2, 7);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new Size(265, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Eboot Patch Page Information";
            this.MainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MainLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // MainBox
            // 
            this.MainBox.Controls.Add(this.Question4Btn);
            this.MainBox.Controls.Add(this.SeperatorLine3);
            this.MainBox.Controls.Add(this.ExitBtn);
            this.MainBox.Controls.Add(this.MinimizeBtn);
            this.MainBox.Controls.Add(this.MainLabel);
            this.MainBox.Controls.Add(this.SeperatorLine1);
            this.MainBox.Controls.Add(this.WithSomeExceptionsLabel);
            this.MainBox.Controls.Add(this.Question3Btn);
            this.MainBox.Controls.Add(this.Question2Btn);
            this.MainBox.Controls.Add(this.Info);
            this.MainBox.Controls.Add(this.CreditsBtn);
            this.MainBox.Controls.Add(this.BackBtn);
            this.MainBox.Controls.Add(this.Question0Btn);
            this.MainBox.Controls.Add(this.SeperatorLine2);
            this.MainBox.Controls.Add(this.Question1Btn);
            this.MainBox.Location = new Point(0, -6);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new Size(320, 448);
            this.MainBox.TabIndex = 5;
            this.MainBox.TabStop = false;
            this.MainBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.MainBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            // 
            // Question4Btn
            // 
            this.Question4Btn.FlatAppearance.BorderSize = 0;
            this.Question4Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question4Btn.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold);
            this.Question4Btn.ForeColor = SystemColors.Control;
            this.Question4Btn.Location = new Point(1, 350);
            this.Question4Btn.Name = "Question4Btn";
            this.Question4Btn.Size = new Size(154, 22);
            this.Question4Btn.TabIndex = 33;
            this.Question4Btn.Text = "- The First Way Is With The Official PS4 SDK Tools,Get Em Urself\r\n\r\n- The Second " +
    "Way Is With The Patch Builder App From ModdedWarfrare\r\n (Add A Link)";
            this.Question4Btn.Click += new System.EventHandler(this.Question4Btn_Click);
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine3.ForeColor = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new Point(2, 362);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new Size(316, 16);
            this.SeperatorLine3.TabIndex = 40;
            this.SeperatorLine3.Text = "______________________________________________________________";
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine1.ForeColor = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new Point(2, 15);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new Size(316, 16);
            this.SeperatorLine1.TabIndex = 39;
            this.SeperatorLine1.Text = "______________________________________________________________";
            // 
            // WithSomeExceptionsLabel
            // 
            this.WithSomeExceptionsLabel.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold);
            this.WithSomeExceptionsLabel.ForeColor = SystemColors.Control;
            this.WithSomeExceptionsLabel.Location = new Point(7, 86);
            this.WithSomeExceptionsLabel.Name = "WithSomeExceptionsLabel";
            this.WithSomeExceptionsLabel.Size = new Size(157, 17);
            this.WithSomeExceptionsLabel.TabIndex = 36;
            this.WithSomeExceptionsLabel.Text = "*(With Some Exceptions)";
            this.WithSomeExceptionsLabel.Click += new System.EventHandler(this.WithSomeExceptionsLabel_Click);
            this.WithSomeExceptionsLabel.MouseEnter += new System.EventHandler(this.WithSomeExceptionsLabelMH);
            this.WithSomeExceptionsLabel.MouseLeave += new System.EventHandler(this.WithSomeExceptionsLabelML);
            // 
            // Question3Btn
            // 
            this.Question3Btn.FlatAppearance.BorderSize = 0;
            this.Question3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question3Btn.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold);
            this.Question3Btn.ForeColor = SystemColors.Control;
            this.Question3Btn.Location = new Point(1, 328);
            this.Question3Btn.Name = "Question3Btn";
            this.Question3Btn.Size = new Size(189, 22);
            this.Question3Btn.TabIndex = 32;
            this.Question3Btn.Text = resources.GetString("Question3Btn.Text");
            this.Question3Btn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Question3Btn.Click += new System.EventHandler(this.Question3Btn_Click);
            // 
            // Question2Btn
            // 
            this.Question2Btn.FlatAppearance.BorderSize = 0;
            this.Question2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question2Btn.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold);
            this.Question2Btn.ForeColor = SystemColors.Control;
            this.Question2Btn.Location = new Point(1, 307);
            this.Question2Btn.Name = "Question2Btn";
            this.Question2Btn.Size = new Size(227, 22);
            this.Question2Btn.TabIndex = 29;
            this.Question2Btn.Text = resources.GetString("Question2Btn.Text");
            this.Question2Btn.Click += new System.EventHandler(this.Question2Btn_Click);
            // 
            // Info
            // 
            this.Info.Font = new Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new Point(9, 427);
            this.Info.Name = "Info";
            this.Info.Size = new Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=====================================";
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = Color.DimGray;
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.CreditsBtn.ForeColor = SystemColors.Control;
            this.CreditsBtn.Location = new Point(1, 381);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new Size(75, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.BackBtn.ForeColor = SystemColors.Control;
            this.BackBtn.Location = new Point(1, 403);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new Size(60, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // Question0Btn
            // 
            this.Question0Btn.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold);
            this.Question0Btn.ForeColor = SystemColors.Control;
            this.Question0Btn.Location = new Point(3, 36);
            this.Question0Btn.Name = "Question0Btn";
            this.Question0Btn.Size = new Size(316, 244);
            this.Question0Btn.TabIndex = 34;
            this.Question0Btn.Text = resources.GetString("Question0Btn.Text");
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine2.ForeColor = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new Point(2, 268);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new Size(316, 16);
            this.SeperatorLine2.TabIndex = 38;
            this.SeperatorLine2.Text = "______________________________________________________________";
            // 
            // Question1Btn
            // 
            this.Question1Btn.FlatAppearance.BorderSize = 0;
            this.Question1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question1Btn.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold);
            this.Question1Btn.ForeColor = SystemColors.Control;
            this.Question1Btn.Location = new Point(1, 287);
            this.Question1Btn.Name = "Question1Btn";
            this.Question1Btn.Size = new Size(236, 21);
            this.Question1Btn.TabIndex = 30;
            this.Question1Btn.Text = resources.GetString("Question1Btn.Text");
            this.Question1Btn.Click += new System.EventHandler(this.Question1Btn_Click);
            // 
            // EbootPatchHelpPage
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.DimGray;
            this.ClientSize = new Size(320, 442);
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
        public void MoveForm(object sender, MouseEventArgs e) => Common.MoveForm(sender, e);
        public void MouseUpFunc(object sender, MouseEventArgs e) => Common.MouseUpFunc(sender, e);
        public void MouseDownFunc(object sender, MouseEventArgs e) => Common.MouseDownFunc(sender, e);
        public void ExitBtn_Click(object sender, EventArgs e) => Environment.Exit(0);
        public void ExitBtnMH(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void ExitBtnML(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 255, 255);

        public void MinimizeBtn_Click(object sender, EventArgs e) => ActiveForm.WindowState = FormWindowState.Minimized;
        public void MinimizeBtnMH(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void MinimizeBtnML(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 255, 255);
        void BackBtn_Click(object sender, EventArgs e) {//!!
            BackFunc();
        }

        public void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(8, false);

        public Button MinimizeBtn;
        public Label Info;
        public Label MainLabel;
        public GroupBox MainBox;
        public Button CreditsBtn;
        public Button BackBtn;
        private Button Question1Btn;
        private Button Question2Btn;
        private Button Question3Btn; // User Is An Idiot
        private Button Question4Btn;
        private Label Question0Btn;
        public Button ExitBtn;


        void LoadQuestions(int Index) {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EbootPatchHelpPage));
            Question0Btn.Text = headers[Questions[Index - 1] ? 0 : Index] + resources.GetString($"Question{(Questions[Index - 1] ? 0 : Index)}Btn.Text");

            for (int i = 0; i < Questions.Length - 1; i++) // Reset The Other Buttons
                Questions[i] = i == Index - 1 ? Questions[i] : false;
            Questions[Index-1] = !Questions[Index-1];
            WithSomeExceptionsLabel.Visible = !Questions[Index - 1];
        }
        private void Question1Btn_Click(object sender, EventArgs e) => LoadQuestions(1);
        private void Question2Btn_Click(object sender, EventArgs e) => LoadQuestions(2);
        private void Question3Btn_Click(object sender, EventArgs e) => LoadQuestions(3);
        private void Question4Btn_Click(object sender, EventArgs e) => LoadQuestions(4);

        private void WithSomeExceptionsLabel_Click(object sender, EventArgs e) => MessageBox.Show("Some Misc. Patches Will Be Applied To Uncharted 4/Lost Legacy Multiplayer Eboots To Make The Game Playable");
        private void WithSomeExceptionsLabelMH(object sender, EventArgs e) => WithSomeExceptionsLabel.ForeColor = Color.Aqua;
        private void WithSomeExceptionsLabelML(object sender, EventArgs e) => WithSomeExceptionsLabel.ForeColor = Color.White;

    }
}
