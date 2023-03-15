using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dobby.Common;
using System.Drawing;

namespace Dobby {
    public class EbootPatchHelpPage : Form {
        public EbootPatchHelpPage() {
            InitializeComponent();
            SetPageInfo(this);
        }

        private Label WithSomeExceptionsLabel;
        bool[] questions = new bool[] { false, false, false, false };
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
            this.User_Is_An_IdiotBtn = new System.Windows.Forms.Button();
            this.Question2Btn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.GeneralLabel = new System.Windows.Forms.Label();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.Question1Btn = new System.Windows.Forms.Button();
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
            this.MainLabel.Size = new System.Drawing.Size(265, 22);
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
            this.MainBox.Controls.Add(this.User_Is_An_IdiotBtn);
            this.MainBox.Controls.Add(this.Question2Btn);
            this.MainBox.Controls.Add(this.Info);
            this.MainBox.Controls.Add(this.CreditsBtn);
            this.MainBox.Controls.Add(this.BackBtn);
            this.MainBox.Controls.Add(this.GeneralLabel);
            this.MainBox.Controls.Add(this.SeperatorLine2);
            this.MainBox.Controls.Add(this.Question1Btn);
            this.MainBox.Location = new System.Drawing.Point(0, -6);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(320, 448);
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
            this.Question4Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Question4Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question4Btn.Location = new System.Drawing.Point(1, 351);
            this.Question4Btn.Name = "Question4Btn";
            this.Question4Btn.Size = new System.Drawing.Size(155, 21);
            this.Question4Btn.TabIndex = 33;
            this.Question4Btn.Text = "- My Game Won\'t Start!";
            this.Question4Btn.Click += new System.EventHandler(this.Question4Btn_Click);
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 362);
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
            // WithSomeExceptionsLabel
            // 
            this.WithSomeExceptionsLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.WithSomeExceptionsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.WithSomeExceptionsLabel.Location = new System.Drawing.Point(7, 86);
            this.WithSomeExceptionsLabel.Name = "WithSomeExceptionsLabel";
            this.WithSomeExceptionsLabel.Size = new System.Drawing.Size(157, 17);
            this.WithSomeExceptionsLabel.TabIndex = 36;
            this.WithSomeExceptionsLabel.Text = "*(With Some Exceptions)";
            this.WithSomeExceptionsLabel.Click += new System.EventHandler(this.WithSomeExceptionsLabel_Click);
            this.WithSomeExceptionsLabel.MouseEnter += new System.EventHandler(this.WithSomeExceptionsLabelMH);
            this.WithSomeExceptionsLabel.MouseLeave += new System.EventHandler(this.WithSomeExceptionsLabelML);
            // 
            // User_Is_An_IdiotBtn
            // 
            this.User_Is_An_IdiotBtn.FlatAppearance.BorderSize = 0;
            this.User_Is_An_IdiotBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.User_Is_An_IdiotBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.User_Is_An_IdiotBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.User_Is_An_IdiotBtn.Location = new System.Drawing.Point(1, 328);
            this.User_Is_An_IdiotBtn.Name = "User_Is_An_IdiotBtn";
            this.User_Is_An_IdiotBtn.Size = new System.Drawing.Size(154, 21);
            this.User_Is_An_IdiotBtn.TabIndex = 32;
            this.User_Is_An_IdiotBtn.Text = "- My .pkg Won\'t Install!\r\n\r\n\r\n\r\nDumbass.";
            this.User_Is_An_IdiotBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.User_Is_An_IdiotBtn.Click += new System.EventHandler(this.User_Is_An_IdiotBtn_Click);
            // 
            // Question2Btn
            // 
            this.Question2Btn.FlatAppearance.BorderSize = 0;
            this.Question2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question2Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Question2Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question2Btn.Location = new System.Drawing.Point(1, 307);
            this.Question2Btn.Name = "Question2Btn";
            this.Question2Btn.Size = new System.Drawing.Size(275, 22);
            this.Question2Btn.TabIndex = 29;
            this.Question2Btn.Text = "- How Do I Add A Patched .bin To My Game?";
            this.Question2Btn.Click += new System.EventHandler(this.Question2Btn_Click);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(9, 427);
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
            this.CreditsBtn.Location = new System.Drawing.Point(1, 381);
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
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 403);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            this.BackBtn.MouseEnter += new System.EventHandler(this.BackBtnMH);
            this.BackBtn.MouseLeave += new System.EventHandler(this.BackBtnML);
            // 
            // GeneralLabel
            // 
            this.GeneralLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.GeneralLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.GeneralLabel.Location = new System.Drawing.Point(3, 39);
            this.GeneralLabel.Name = "GeneralLabel";
            this.GeneralLabel.Size = new System.Drawing.Size(316, 244);
            this.GeneralLabel.TabIndex = 34;
            this.GeneralLabel.Text = resources.GetString("GeneralLabel.Text");
            this.GeneralLabel.Click += new System.EventHandler(this.GeneralLabel_Click);
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 268);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine2.TabIndex = 38;
            this.SeperatorLine2.Text = "______________________________________________________________";
            // 
            // Question1Btn
            // 
            this.Question1Btn.FlatAppearance.BorderSize = 0;
            this.Question1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question1Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.Question1Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question1Btn.Location = new System.Drawing.Point(1, 287);
            this.Question1Btn.Name = "Question1Btn";
            this.Question1Btn.Size = new System.Drawing.Size(236, 21);
            this.Question1Btn.TabIndex = 30;
            this.Question1Btn.Text = resources.GetString("Question1Btn.Text");
            this.Question1Btn.Click += new System.EventHandler(this.Question1Btn_Click);
            // 
            // EbootPatchHelpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 442);
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
            Form f = ActiveForm;
            LastPos = f.Location;
            Dev.DebugOutStr($"Loading: {LastForm.Name}");
            if (LastForm.Name == ActiveForm.Name) {
                Dev.DebugOutStr("We're trying to boot the same form again. Showing Main Form Instead");
                MainForm.Show();
                Dobby.Page = MainForm.Name;
                goto skip;
            }
            LastForm.Show();
skip: ActiveForm.Location = LastPos;
            f.Close();
            Dobby.Page = ActiveForm.Name;
            if (!Dev.REL) PageInfo(ActiveForm.Controls);
        }
        public void BackBtnMH(object sender, EventArgs e) => HoverString(BackBtn, $"{(Dev.REL ? "" : LastForm.Name)}");
        public void BackBtnML(object sender, EventArgs e) => HoverLeave(BackBtn, 1);

        public void CreditsBtn_Click(object sender, EventArgs e) {
            if (MainForm == null && ActiveForm.Name == "Dobby")
                MainForm = ActiveForm;
            LastForm = ActiveForm;
            LastPos = LastForm.Location;
            CreditsPage NewPage = new CreditsPage();
            NewPage.Show();
            LastForm.Hide();
            if (!Dev.REL) PageInfo(ActiveForm.Controls);
        }
        public void CreditsBtnMH(object sender, EventArgs e) => HoverString(CreditsBtn, "View Credits For The Tool And Included Patches");
        public void CreditsBtnML(object sender, EventArgs e) => HoverLeave(CreditsBtn, 1);

        public Button MinimizeBtn;
        public Label Info;
        public Label MainLabel;
        public GroupBox MainBox;
        public Button CreditsBtn;
        public Button BackBtn;
        private Button Question1Btn;
        private Button Question2Btn;
        private Button User_Is_An_IdiotBtn; // Question3Btn
        private Button Question4Btn;
        private Label GeneralLabel;
        public Button ExitBtn;

        private void Question1Btn_Click(object sender, EventArgs e) {
            questions[0] = !questions[0];
            Question1Btn.Location = questions[0] ? GeneralLabel.Location : new Point(1, 287);
            Question1Btn.Size = questions[0] ? GeneralLabel.Size : new Size(240, 21);
            Question1Btn.BringToFront();
            GeneralLabel.Visible = !questions[0];
            WithSomeExceptionsLabel.Visible = !questions[0];
        }

        private void Question2Btn_Click(object sender, EventArgs e) { // TMP //!
            questions[1] = !questions[1];
            if (questions[1]) {
                Question2Btn.Location = new Point(0, 0);
            }
            else {
                Question2Btn.Location = new Point(-1, 331);
                Question2Btn.Size = new Size(312, 21);
            }

        }

        private void User_Is_An_IdiotBtn_Click(object sender, EventArgs e) { // TMP //!
            questions[2] = !questions[2];
            User_Is_An_IdiotBtn.Location = questions[2] ? GeneralLabel.Location : new Point(-5, 365);
            User_Is_An_IdiotBtn.Size = questions[2] ? GeneralLabel.Size : new Size(147, 21);
            User_Is_An_IdiotBtn.BringToFront();
            GeneralLabel.Visible = !questions[2];
            WithSomeExceptionsLabel.Visible = !questions[2];
        }

        private void Question4Btn_Click(object sender, EventArgs e) { // TMP //!
            questions[0] = !questions[0];
            if (questions[0]) {
                Question1Btn.Location = new Point(0, 0);
            }
            else {
                Question1Btn.Location = new Point(-5, 385);
                Question1Btn.Size = new Size(147, 21);
            }
        }

        private void WithSomeExceptionsLabel_Click(object sender, EventArgs e) => MakeTextBox(1, "*Some Misc. Patches Will Be Applied To Uncharted 4/Lost Legacy Multiplayer Eboots To Make The Game Playable");

        private void WithSomeExceptionsLabelMH(object sender, EventArgs e) => WithSomeExceptionsLabel.ForeColor = Color.Aqua;
        private void WithSomeExceptionsLabelML(object sender, EventArgs e) => WithSomeExceptionsLabel.ForeColor = Color.White;

        private void GeneralLabel_Click(object sender, EventArgs e) {
            this.Controls.Remove(PopUpBox1);
            this.Controls.Remove(PopUpBox2);
            switch (tst) {
                case 0:
                    MakeTextBox(0, "Small");
                    break;
                case 1:
                    MakeTextBox(1, "Medium");
                    break;
                case 2:
                    MakeTextBox(2, "Large");
                    break;
                default:
                    tst = 0;
                    MakeTextBox(0, "Tiny");
                    break;
            }
            tst++;
        }
    }
}
