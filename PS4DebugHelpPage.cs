using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dobby.Common;
using System.Drawing;

namespace Dobby {
    public class PS4DebugHelpPage : Form {
        public PS4DebugHelpPage() {
            InitializeComponent();
            AddControlEventHandlers(Controls);
        }
        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PS4DebugHelpPage));
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.MainLabel = new System.Windows.Forms.Label();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PS4DebugAnswerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.PS4DebugQuestionLabel = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
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
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.25F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(2, 7);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(259, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "PS4Debug Page Information";
            // 
            // MainBox
            // 
            this.MainBox.Controls.Add(this.label2);
            this.MainBox.Controls.Add(this.ExitBtn);
            this.MainBox.Controls.Add(this.MinimizeBtn);
            this.MainBox.Controls.Add(this.MainLabel);
            this.MainBox.Controls.Add(this.PS4DebugAnswerLabel);
            this.MainBox.Controls.Add(this.label1);
            this.MainBox.Controls.Add(this.SeperatorLine3);
            this.MainBox.Controls.Add(this.PS4DebugQuestionLabel);
            this.MainBox.Controls.Add(this.Info);
            this.MainBox.Controls.Add(this.CreditsBtn);
            this.MainBox.Controls.Add(this.BackBtn);
            this.MainBox.Location = new System.Drawing.Point(0, -6);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(320, 435);
            this.MainBox.TabIndex = 5;
            this.MainBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label2.Location = new System.Drawing.Point(2, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "_______________________________________________________________";
            // 
            // PS4DebugAnswerLabel
            // 
            this.PS4DebugAnswerLabel.Font = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold);
            this.PS4DebugAnswerLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PS4DebugAnswerLabel.Location = new System.Drawing.Point(1, 57);
            this.PS4DebugAnswerLabel.Name = "PS4DebugAnswerLabel";
            this.PS4DebugAnswerLabel.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.PS4DebugAnswerLabel.Size = new System.Drawing.Size(317, 306);
            this.PS4DebugAnswerLabel.TabIndex = 30;
            this.PS4DebugAnswerLabel.Text = resources.GetString("PS4DebugAnswerLabel.Text");
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label1.Location = new System.Drawing.Point(1, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "_______________________________________________________________";
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine3.TabIndex = 31;
            this.SeperatorLine3.Text = "_______________________________________________________________";
            // 
            // PS4DebugQuestionLabel
            // 
            this.PS4DebugQuestionLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.PS4DebugQuestionLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PS4DebugQuestionLabel.Location = new System.Drawing.Point(1, 34);
            this.PS4DebugQuestionLabel.Name = "PS4DebugQuestionLabel";
            this.PS4DebugQuestionLabel.Size = new System.Drawing.Size(313, 18);
            this.PS4DebugQuestionLabel.TabIndex = 29;
            this.PS4DebugQuestionLabel.Text = "\"How Do I Enable The Debug Mode With This?\"\r\n";
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(8, 414);
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
            this.CreditsBtn.Location = new System.Drawing.Point(1, 367);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(75, 23);
            this.CreditsBtn.TabIndex = 28;
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
            this.BackBtn.Location = new System.Drawing.Point(1, 390);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // PS4DebugHelpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 428);
            this.Controls.Add(this.MainBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PS4DebugHelpPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.MainBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #region RepeatedButtonFunctions
        /////////////////\\\\\\\\\\\\\\\\\\
        ///--     Repeat Buttons      --\\\
        /////////////////\\\\\\\\\\\\\\\\\\\
        public void ExitBtn_Click(object sender, EventArgs e) => Environment.Exit(0);
        public void ExitBtnMH(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void ExitBtnML(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 255, 255);
        public void MinimizeBtn_Click(object sender, EventArgs e) => ActiveForm.WindowState = FormWindowState.Minimized;
        public void MinimizeBtnMH(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void MinimizeBtnML(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 255, 255);

        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(CreditsPageId);
        private void BackBtn_Click(object sender, EventArgs e) => BackFunc();
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
        private Label PS4DebugQuestionLabel;
        private Label PS4DebugAnswerLabel;
        public Label label1;
        public Label SeperatorLine3;
        public Label label2;
        public Button ExitBtn;
        #endregion
    }
}
