using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Dobby.Common;


namespace Dobby {
    public class PkgCreationHelpPage : Form {
        public PkgCreationHelpPage() {
            InitializeComponent();
            
            InitializeAdditionalEventHandlers(Controls);

            Question0Btn.Text = "- Button Text Here";
            Question1Btn.Text = "- Button Text Here";
            Question2Btn.Text = "- Button Text Here";
            Question3Btn.Text = "- Button Text Here";
        }



        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Designer Crap, No Touchie      --\\\
        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        #region Designer Crap, No Touchie
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PkgCreationHelpPage));
            this.MainLabel = new System.Windows.Forms.Label();
            this.Question3Btn = new Button();
            this.Question2Btn = new Button();
            this.Question1Btn = new Button();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.PopupLabel = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new Button();
            this.BackBtn = new Button();
            this.DefaultQuestionBtn = new System.Windows.Forms.Label();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.Question0Btn = new Button();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(1, 1);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(265, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Pkg Creation Help Information";
            // 
            // Question3Btn
            // 
            this.Question3Btn.FlatAppearance.BorderSize = 0;
            this.Question3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question3Btn.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold);
            this.Question3Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question3Btn.Location = new System.Drawing.Point(1, 379);
            this.Question3Btn.Name = "Question3Btn";
            this.Question3Btn.Size = new System.Drawing.Size(236, 24);
            this.Question3Btn.TabIndex = 43;
            this.Question3Btn.Text = "- Obtaining The Files Needed";
            this.Question3Btn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Question3Btn.Click += new System.EventHandler(this.Question4Btn_Click);
            // 
            // Question2Btn
            // 
            this.Question2Btn.FlatAppearance.BorderSize = 0;
            this.Question2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question2Btn.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold);
            this.Question2Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question2Btn.Location = new System.Drawing.Point(1, 356);
            this.Question2Btn.Name = "Question2Btn";
            this.Question2Btn.Size = new System.Drawing.Size(236, 24);
            this.Question2Btn.TabIndex = 42;
            this.Question2Btn.Text = "- Obtaining The Files Needed";
            this.Question2Btn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Question2Btn.Click += new System.EventHandler(this.Question3Btn_Click);
            // 
            // Question1Btn
            // 
            this.Question1Btn.FlatAppearance.BorderSize = 0;
            this.Question1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question1Btn.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold);
            this.Question1Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question1Btn.Location = new System.Drawing.Point(1, 332);
            this.Question1Btn.Name = "Question1Btn";
            this.Question1Btn.Size = new System.Drawing.Size(236, 24);
            this.Question1Btn.TabIndex = 41;
            this.Question1Btn.Text = "- Obtaining The Files Needed";
            this.Question1Btn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Question1Btn.Click += new System.EventHandler(this.Question2Btn_Click);
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 394);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine3.TabIndex = 40;
            this.SeperatorLine3.Text = "--------------------------------------------------------------";
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine1.TabIndex = 39;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // PopupLabel
            // 
            this.PopupLabel.Font = new System.Drawing.Font("Cambria", 9.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.PopupLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PopupLabel.Location = new System.Drawing.Point(127, 81);
            this.PopupLabel.Name = "PopupLabel";
            this.PopupLabel.Size = new System.Drawing.Size(96, 16);
            this.PopupLabel.TabIndex = 36;
            this.PopupLabel.Text = "orbis-pub-cmd";
            this.PopupLabel.Click += new System.EventHandler(this.PopupLabel_Click);
            this.PopupLabel.MouseEnter += new System.EventHandler(this.PopupLabelMH);
            this.PopupLabel.MouseLeave += new System.EventHandler(this.PopupLabelML);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(9, 461);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=====================================";
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 415);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(75, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 437);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            // 
            // DefaultQuestionBtn
            // 
            this.DefaultQuestionBtn.Font = new System.Drawing.Font("Cambria", 9.5F, System.Drawing.FontStyle.Bold);
            this.DefaultQuestionBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DefaultQuestionBtn.Location = new System.Drawing.Point(3, 36);
            this.DefaultQuestionBtn.Name = "DefaultQuestionBtn";
            this.DefaultQuestionBtn.Size = new System.Drawing.Size(316, 270);
            this.DefaultQuestionBtn.TabIndex = 34;
            this.DefaultQuestionBtn.Text = resources.GetString("DefaultQuestionBtn.Text");
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 291);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine2.TabIndex = 38;
            this.SeperatorLine2.Text = "--------------------------------------------------------------";
            // 
            // Question0Btn
            // 
            this.Question0Btn.FlatAppearance.BorderSize = 0;
            this.Question0Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question0Btn.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold);
            this.Question0Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question0Btn.Location = new System.Drawing.Point(1, 309);
            this.Question0Btn.Name = "Question0Btn";
            this.Question0Btn.Size = new System.Drawing.Size(236, 24);
            this.Question0Btn.TabIndex = 30;
            this.Question0Btn.Text = resources.GetString("Question0Btn.Text");
            this.Question0Btn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Question0Btn.Click += new System.EventHandler(this.Question1Btn_Click);
            // 
            // PkgCreationHelpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 476);
            this.Controls.Add(this.Question3Btn);
            this.Controls.Add(this.Question2Btn);
            this.Controls.Add(this.Question1Btn);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.PopupLabel);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.DefaultQuestionBtn);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.Question0Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PkgCreationHelpPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }
        #endregion


        private static readonly string[] Headers = new string[] {
            "                [Page Title]\n",
            "                [Page Title]\n",
            "                [Page Title]\n",
            "                [Page Title]\n"
        };

        private static bool[] Questions = new bool[4];
        private static bool DefaultQuestionIsActive = true;


        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        ///--     Page-Specific Functions     --\\\
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        #region Page-Specific Functions
        void LoadQuestions(int Index) {

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PkgCreationHelpPage));

            for(int i = 0; i < Questions.Length; i++) // Reset The Other Buttons
                if(i != Index) Questions[i] = false;

            Questions[Index] = !Questions[Index];

            if(Questions[Index] == false) {
                DefaultQuestionIsActive = true;
                DefaultQuestionBtn.Text = resources.GetString("DefaultQuestionBtn.Text");
                return;
            }
            else DefaultQuestionIsActive = false;

            DefaultQuestionBtn.Text = Headers[Index] + resources.GetString($"Question{Index}Btn.Text");
            PopupLabel.Visible = DefaultQuestionIsActive;
        }
        private void Question1Btn_Click(object sender, EventArgs e) => LoadQuestions(0);
        private void Question2Btn_Click(object sender, EventArgs e) => LoadQuestions(1);
        private void Question3Btn_Click(object sender, EventArgs e) => LoadQuestions(2);
        private void Question4Btn_Click(object sender, EventArgs e) => LoadQuestions(3);

        private void PopupLabel_Click(object sender, EventArgs e) { }
        private void PopupLabelMH(object sender, EventArgs e) => PopupLabel.ForeColor = Color.Aqua;
        private void PopupLabelML(object sender, EventArgs e) => PopupLabel.ForeColor = Color.White;
        #endregion


        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Repeated Page Functions & Control Declarations     --\\\
        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Repeat Functions & Control Declarations
        public Label Info;
        public Label MainLabel;
        public Button CreditsBtn;
        public Button BackBtn;
        private Button Question0Btn;
        private Label PopupLabel;
        public Label SeperatorLine1;
        public Label SeperatorLine2;
        public Label SeperatorLine3;
        private Label DefaultQuestionBtn;
        private Button Question3Btn;
        private Button Question2Btn;
        private Button Question1Btn;
        #endregion
    }
}
