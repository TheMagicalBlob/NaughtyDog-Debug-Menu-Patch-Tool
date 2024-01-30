using System;
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
    public class PkgCreationHelpPage : Form {
        public PkgCreationHelpPage() {
            InitializeComponent();
            
            AddControlEventHandlers(Controls);

            Question0Btn.Text = "- Button Text Here";
            Question1Btn.Text = "- Button Text Here";
            Question2Btn.Text = "- Button Text Here";
            Question3Btn.Text = "- Button Text Here";
        }
        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PkgCreationHelpPage));
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.MainLabel = new System.Windows.Forms.Label();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.Question3Btn = new System.Windows.Forms.Button();
            this.Question2Btn = new System.Windows.Forms.Button();
            this.Question1Btn = new System.Windows.Forms.Button();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.PopupLabel = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.DefaultQuestionBtn = new System.Windows.Forms.Label();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.Question0Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
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
            this.MinimizeBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
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
            this.MainLabel.Size = new System.Drawing.Size(265, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Pkg Creation Help Information";
            this.MainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MainLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // MainBox
            // 
            this.Controls.Add(this.Question3Btn);
            this.Controls.Add(this.Question2Btn);
            this.Controls.Add(this.Question1Btn);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.PopupLabel);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.DefaultQuestionBtn);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.Question0Btn);
            this.Location = new System.Drawing.Point(0, -6);
            this.Name = "MainBox";
            this.Size = new System.Drawing.Size(320, 483);
            this.TabIndex = 5;
            this.TabStop = false;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            // 
            // Question3Btn
            // 
            this.Question3Btn.FlatAppearance.BorderSize = 0;
            this.Question3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question3Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Bold);
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
            this.Question2Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Bold);
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
            this.Question1Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Bold);
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
            this.SeperatorLine3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 394);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine3.TabIndex = 40;
            this.SeperatorLine3.Text = "______________________________________________________________";
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine1.TabIndex = 39;
            this.SeperatorLine1.Text = "______________________________________________________________";
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
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(9, 461);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=====================================";
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 415);
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
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 437);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
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
            this.SeperatorLine2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 291);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine2.TabIndex = 38;
            this.SeperatorLine2.Text = "______________________________________________________________";
            // 
            // Question0Btn
            // 
            this.Question0Btn.FlatAppearance.BorderSize = 0;
            this.Question0Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question0Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Bold);
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
            this.BackColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.ClientSize = new System.Drawing.Size(320, 476);
            this.Controls.Add(this.MainBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PkgCreationHelpPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        string[] Headers = new string[] {
            "                [Page Title]\n",
            "                [Page Title]\n",
            "                [Page Title]\n",
            "                [Page Title]\n"
        };

        bool[] Questions = new bool[4];
        bool DefaultQuestionIsActive = true;


        /////////////////\\\\\\\\\\\\\\\\\\
        ///--     Repeat Buttons      --\\\
        /////////////////\\\\\\\\\\\\\\\\\\\
        #region RepeatedButtonFunctions
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
        void BackBtn_Click(object sender, EventArgs e) => ReturnToPreviousPage();
        #endregion


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
        public Button ExitBtn;
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
