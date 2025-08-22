using System.Windows.Forms;

namespace Dobby
{
    internal partial class CreditsPage
    {
        //=====================================\\
        //--|   Designer Crap, No Touchie   |--\\
        //=====================================\\
        #region [Designer Crap, No Touchie]
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditsPage));
            this.MainLabel = new Dobby.Label();
            this.SeperatorLine0 = new Dobby.Label();
            this.IllusionBlogBtn = new Dobby.Label();
            this.SeperatorLine3 = new Dobby.Label();
            this.ContributorsLabel = new Dobby.Label();
            this.SeperatorLine2 = new Dobby.Label();
            this.NarcissismLabel = new Dobby.Label();
            this.SeperatorLine1 = new Dobby.Label();
            this.BlobGithubBtn = new Dobby.Label();
            this.Info = new Dobby.Label();
            this.BackBtn = new Dobby.Button();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.IsSeparatorLine = false;
            this.MainLabel.Location = new System.Drawing.Point(1, 1);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(268, 22);
            this.MainLabel.StretchToFitForm = false;
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Credits";
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.IsSeparatorLine = true;
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine0.StretchToFitForm = false;
            this.SeperatorLine0.TabIndex = 39;
            this.SeperatorLine0.Text = "--------------------------------------------------------------";
            // 
            // IllusionBlogBtn
            // 
            this.IllusionBlogBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IllusionBlogBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IllusionBlogBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.IllusionBlogBtn.IsSeparatorLine = true;
            this.IllusionBlogBtn.Location = new System.Drawing.Point(1, 336);
            this.IllusionBlogBtn.Name = "IllusionBlogBtn";
            this.IllusionBlogBtn.Size = new System.Drawing.Size(318, 23);
            this.IllusionBlogBtn.StretchToFitForm = false;
            this.IllusionBlogBtn.TabIndex = 32;
            this.IllusionBlogBtn.Text = "illusion\'s Blog";
            this.IllusionBlogBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.IllusionBlogBtn_RightClick);
            this.IllusionBlogBtn.MouseEnter += new System.EventHandler(this.IllusionBlogBtnMH);
            this.IllusionBlogBtn.MouseLeave += new System.EventHandler(this.IllusionBlogBtnML);
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.IsSeparatorLine = false;
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 351);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine3.StretchToFitForm = false;
            this.SeperatorLine3.TabIndex = 38;
            this.SeperatorLine3.Text = "--------------------------------------------------------------";
            // 
            // ContributorsLabel
            // 
            this.ContributorsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContributorsLabel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.ContributorsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ContributorsLabel.IsSeparatorLine = true;
            this.ContributorsLabel.Location = new System.Drawing.Point(1, 74);
            this.ContributorsLabel.Name = "ContributorsLabel";
            this.ContributorsLabel.Size = new System.Drawing.Size(317, 232);
            this.ContributorsLabel.StretchToFitForm = false;
            this.ContributorsLabel.TabIndex = 35;
            this.ContributorsLabel.Text = resources.GetString("ContributorsLabel.Text");
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.IsSeparatorLine = false;
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 297);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine2.StretchToFitForm = false;
            this.SeperatorLine2.TabIndex = 37;
            this.SeperatorLine2.Text = "--------------------------------------------------------------";
            // 
            // NarcissismLabel
            // 
            this.NarcissismLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NarcissismLabel.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold);
            this.NarcissismLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.NarcissismLabel.IsSeparatorLine = false;
            this.NarcissismLabel.Location = new System.Drawing.Point(1, 30);
            this.NarcissismLabel.Name = "NarcissismLabel";
            this.NarcissismLabel.Size = new System.Drawing.Size(311, 39);
            this.NarcissismLabel.StretchToFitForm = false;
            this.NarcissismLabel.TabIndex = 20;
            this.NarcissismLabel.Text = "GUI and all game patches developed\r\nBy: TheMagicalBlob/TheMagicalDildo";
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.IsSeparatorLine = true;
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 61);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine1.StretchToFitForm = false;
            this.SeperatorLine1.TabIndex = 36;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // BlobGithubBtn
            // 
            this.BlobGithubBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlobGithubBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlobGithubBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BlobGithubBtn.IsSeparatorLine = false;
            this.BlobGithubBtn.Location = new System.Drawing.Point(1, 312);
            this.BlobGithubBtn.Name = "BlobGithubBtn";
            this.BlobGithubBtn.Size = new System.Drawing.Size(318, 23);
            this.BlobGithubBtn.StretchToFitForm = false;
            this.BlobGithubBtn.TabIndex = 31;
            this.BlobGithubBtn.Text = "TheMagicalBlob\'s Github";
            this.BlobGithubBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BlobGithubBtn_RightClick);
            this.BlobGithubBtn.MouseEnter += new System.EventHandler(this.BlobGithubBtnMH);
            this.BlobGithubBtn.MouseLeave += new System.EventHandler(this.BlobGithubBtnML);
            // 
            // Info
            // 
            this.Info.IsSeparatorLine = false;
            this.Info.Location = new System.Drawing.Point(0, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(0, 0);
            this.Info.StretchToFitForm = false;
            this.Info.TabIndex = 6;
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 367);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 22);
            this.BackBtn.TabIndex = 14;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Variable = null;
            // 
            // CreditsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 394);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine0);
            this.Controls.Add(this.IllusionBlogBtn);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.ContributorsLabel);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.NarcissismLabel);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.BlobGithubBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.Info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreditsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }
        #endregion

        
        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        public Label MainLabel;
        public Label NarcissismLabel;
        public Label BlobGithubBtn;
        public Label IllusionBlogBtn;
        public Label ContributorsLabel;
        public Button BackBtn;
        public Label SeperatorLine1;
        public Label Info;
        public Label SeperatorLine3;
        public Label SeperatorLine2;
        public Label SeperatorLine0;
        #endregion
    }
}
