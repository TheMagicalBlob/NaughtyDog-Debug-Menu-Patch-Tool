using System;
using System.Diagnostics;
using System.Windows.Forms;
using static Dobby.Common;
using System.Drawing;
using Dobby.Properties;

namespace Dobby {
    public class EbootPatchHelpPage : Form {
        public EbootPatchHelpPage() {
            InitializeComponent();
            
            AddEventHandlersToControls(Controls);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EbootPatchHelpPage));
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.MainLabel = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.5F, System.Drawing.FontStyle.Bold);
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ExitBtn.Location = new System.Drawing.Point(296, 1);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(23, 23);
            this.ExitBtn.TabIndex = 8;
            this.ExitBtn.Text = "X";
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitBtn.UseVisualStyleBackColor = false;
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MinimizeBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.5F, System.Drawing.FontStyle.Bold);
            this.MinimizeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimizeBtn.Location = new System.Drawing.Point(273, 1);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new System.Drawing.Size(23, 23);
            this.MinimizeBtn.TabIndex = 7;
            this.MinimizeBtn.Text = "---";
            this.MinimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MinimizeBtn.UseVisualStyleBackColor = false;
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
            this.MainLabel.Text = "Eboot Patch Page Information";
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
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 416);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine2.TabIndex = 40;
            this.SeperatorLine2.Text = "--------------------------------------------------------------";
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine0.TabIndex = 39;
            this.SeperatorLine0.Text = "--------------------------------------------------------------";
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
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(9, 483);
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
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
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
            this.DefaultQuestionBtn.Size = new System.Drawing.Size(316, 290);
            this.DefaultQuestionBtn.TabIndex = 0;
            this.DefaultQuestionBtn.Text = resources.GetString("DefaultQuestionBtn.Text");
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 320);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine1.TabIndex = 38;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
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
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 506);
            this.Controls.Add(this.Question3Btn);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine0);
            this.Controls.Add(this.WithSomeExceptionsLabel);
            this.Controls.Add(this.Question2Btn);
            this.Controls.Add(this.Question1Btn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.DefaultQuestionBtn);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.Question0Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EbootPatchHelpPage";
            this.ResumeLayout(false);

        }
        #endregion


        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        ///--     Page-Specific Functions     --\\\
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        #region Page-Specific Functions
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


        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Repeated Page Functions & Control Declarations     --\\\
        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Repeat Functions & Control Declarations
        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.CreditsPage);
        private void BackBtn_Click(object sender, EventArgs e) => ReturnToPreviousPage();
        public Button MinimizeBtn;
        public Label Info;
        public Label MainLabel;
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
