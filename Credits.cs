using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using static Dobby.Common;

namespace Dobby {
    internal class CreditsPage : Form {
        public CreditsPage() {
            InitializeComponent();
            SetPageInfo(this);
        }
        public Button ExitBtn;
        public Button MinimizeBtn;
        public GroupBox MainBox;
        public Label MainLabel;
        public Label label1;
        public Label BlobGithubBtn;
        public Label IllusionBlogBtn;
        public Label label2;
        public Label label3;
        public Label label4;
        public Label label5;
        public Button BackBtn;
        public Label Info;

        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditsPage));
            this.MainLabel = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BlobGithubBtn = new System.Windows.Forms.Label();
            this.IllusionBlogBtn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MainBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.25F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(2, 7);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(314, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Credits";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(-4, 362);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 22);
            this.BackBtn.TabIndex = 14;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            this.BackBtn.MouseEnter += new System.EventHandler(this.BackBtnMH);
            this.BackBtn.MouseLeave += new System.EventHandler(this.BackBtnML);
            // 
            // MainBox
            // 
            this.MainBox.Controls.Add(this.ExitBtn);
            this.MainBox.Controls.Add(this.MinimizeBtn);
            this.MainBox.Controls.Add(this.MainLabel);
            this.MainBox.Location = new System.Drawing.Point(1, -4);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(317, 32);
            this.MainBox.TabIndex = 5;
            this.MainBox.TabStop = false;
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
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(3, 384);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=====================================";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(-2, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(324, 19);
            this.label5.TabIndex = 30;
            this.label5.Text = "___________________________________________________";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(2, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 36);
            this.label1.TabIndex = 20;
            this.label1.Text = "App And Game Patches Developed By:\r\nTheMagicalBlob";
            // 
            // BlobGithubBtn
            // 
            this.BlobGithubBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlobGithubBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlobGithubBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BlobGithubBtn.Location = new System.Drawing.Point(-1, 308);
            this.BlobGithubBtn.Name = "BlobGithubBtn";
            this.BlobGithubBtn.Size = new System.Drawing.Size(170, 23);
            this.BlobGithubBtn.TabIndex = 31;
            this.BlobGithubBtn.Text = "TheMagicalBlob\'s Github";
            this.BlobGithubBtn.Click += new System.EventHandler(this.BlobGithubBtn_Click);
            this.BlobGithubBtn.MouseEnter += new System.EventHandler(this.BlobGithubBtnMH);
            this.BlobGithubBtn.MouseLeave += new System.EventHandler(this.BlobGithubBtnML);
            // 
            // IllusionBlogBtn
            // 
            this.IllusionBlogBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IllusionBlogBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IllusionBlogBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.IllusionBlogBtn.Location = new System.Drawing.Point(2, 331);
            this.IllusionBlogBtn.Name = "IllusionBlogBtn";
            this.IllusionBlogBtn.Size = new System.Drawing.Size(100, 23);
            this.IllusionBlogBtn.TabIndex = 32;
            this.IllusionBlogBtn.Text = "illusion\'s Blog";
            this.IllusionBlogBtn.Click += new System.EventHandler(this.IllusionBlogBtn_Click);
            this.IllusionBlogBtn.MouseEnter += new System.EventHandler(this.IllusionBlogBtnMH);
            this.IllusionBlogBtn.MouseLeave += new System.EventHandler(this.IllusionBlogBtnML);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "___________________________________________________";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-8, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 19);
            this.label3.TabIndex = 34;
            this.label3.Text = "___________________________________________________";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(0, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 231);
            this.label4.TabIndex = 35;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // CreditsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 404);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.IllusionBlogBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BlobGithubBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.MainBox);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreditsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.MainBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        void ExitBtn_Click(object sender, EventArgs e) => Environment.Exit(0);
        void ExitBtnMH(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 227, 0);
        void ExitBtnML(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 255, 255);
        void MinimizeBtn_Click(object sender, EventArgs e) => ActiveForm.WindowState = FormWindowState.Minimized;
        void MinimizeBtnMH(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 227, 0);
        void MinimizeBtnML(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 255, 255);

        void BackBtn_Click(object sender, EventArgs e) {//!!
            Form f = ActiveForm;
            LastPos = f.Location;
            if (LastForm.Name == MainForm.Name) {
                MainForm.Show();
                Dobby.Page = MainForm.Name;
                LastForm = null;
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

        public void BlobGithubBtn_Click(object sender, EventArgs e) => Process.Start("https://github.com/TheMagicalBlob");
        public void BlobGithubBtnMH(object sender, EventArgs e) => BlobGithubBtn.ForeColor = Color.MediumBlue;
        public void BlobGithubBtnML(object sender, EventArgs e) => BlobGithubBtn.ForeColor = Color.White;

        public void IllusionBlogBtn_Click(object sender, EventArgs e) => Process.Start("https://illusion0001.com/");
        public void IllusionBlogBtnMH(object sender, EventArgs e) => IllusionBlogBtn.ForeColor = Color.MediumBlue;
        public void IllusionBlogBtnML(object sender, EventArgs e) => IllusionBlogBtn.ForeColor = Color.White;
    }
}
