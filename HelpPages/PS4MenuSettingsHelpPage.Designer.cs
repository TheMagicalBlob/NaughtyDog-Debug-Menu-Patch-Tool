using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Dobby.Common;

namespace Dobby
{
    public partial class PS4MenuSettingsHelpPage
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
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PkgCreationHelpPage));
            this.Question3Btn = new Dobby.Button();
            this.separatorLine2 = new Dobby.Label();
            this.MainLabel = new Dobby.Label();
            this.separatorLine0 = new Dobby.Label();
            this.Question2Btn = new Dobby.Button();
            this.Question1Btn = new Dobby.Button();
            this.Info = new Dobby.Label();
            this.CreditsBtn = new Dobby.Button();
            this.BackBtn = new Dobby.Button();
            this.ActiveQuestionBtn = new Dobby.Label();
            this.separatorLine1 = new Dobby.Label();
            this.Question0Btn = new Dobby.Button();
            this.SuspendLayout();
            // 
            // Question3Btn
            // 
            this.Question3Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Question3Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Question3Btn.FlatAppearance.BorderSize = 0;
            this.Question3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question3Btn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.Question3Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question3Btn.Location = new System.Drawing.Point(1, 399);
            this.Question3Btn.Name = "Question3Btn";
            this.Question3Btn.Size = new System.Drawing.Size(318, 24);
            this.Question3Btn.TabIndex = 4;
            this.Question3Btn.Text = "- Why Is The Restored/Custom Button Disabled?";
            this.Question3Btn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Question3Btn.UseVisualStyleBackColor = false;
            this.Question3Btn.Variable = null;
            // 
            // separatorLine2
            // 
            this.separatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.separatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.separatorLine2.IsSeparatorLine = true;
            this.separatorLine2.Location = new System.Drawing.Point(2, 416);
            this.separatorLine2.Name = "separatorLine2";
            this.separatorLine2.Size = new System.Drawing.Size(316, 15);
            this.separatorLine2.StretchToFitForm = true;
            this.separatorLine2.TabIndex = 40;
            this.separatorLine2.Text = "--------------------------------------------------------------";
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.IsSeparatorLine = false;
            this.MainLabel.Location = new System.Drawing.Point(1, 1);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(265, 22);
            this.MainLabel.StretchToFitForm = true;
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Eboot Patch Page Information";
            // 
            // separatorLine0
            // 
            this.separatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.separatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.separatorLine0.IsSeparatorLine = true;
            this.separatorLine0.Location = new System.Drawing.Point(2, 15);
            this.separatorLine0.Name = "separatorLine0";
            this.separatorLine0.Size = new System.Drawing.Size(316, 15);
            this.separatorLine0.StretchToFitForm = true;
            this.separatorLine0.TabIndex = 39;
            this.separatorLine0.Text = "--------------------------------------------------------------";
            // 
            // Question2Btn
            // 
            this.Question2Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Question2Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Question2Btn.FlatAppearance.BorderSize = 0;
            this.Question2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question2Btn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.Question2Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question2Btn.Location = new System.Drawing.Point(1, 377);
            this.Question2Btn.Name = "Question2Btn";
            this.Question2Btn.Size = new System.Drawing.Size(318, 24);
            this.Question2Btn.TabIndex = 3;
            this.Question2Btn.Text = "- How Do I Make A New .pkg Afterwards?";
            this.Question2Btn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Question2Btn.UseVisualStyleBackColor = false;
            this.Question2Btn.Variable = null;
            // 
            // Question1Btn
            // 
            this.Question1Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Question1Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Question1Btn.FlatAppearance.BorderSize = 0;
            this.Question1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question1Btn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.Question1Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question1Btn.Location = new System.Drawing.Point(1, 356);
            this.Question1Btn.Name = "Question1Btn";
            this.Question1Btn.Size = new System.Drawing.Size(318, 24);
            this.Question1Btn.TabIndex = 2;
            this.Question1Btn.Text = "- How Do I Extract My Game\'s .pkg?";
            this.Question1Btn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Question1Btn.UseVisualStyleBackColor = false;
            this.Question1Btn.Variable = null;
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 9.25F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.IsSeparatorLine = false;
            this.Info.Location = new System.Drawing.Point(9, 483);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.StretchToFitForm = true;
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
            this.CreditsBtn.Variable = null;
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
            this.BackBtn.Variable = null;
            // 
            // ActiveQuestionBtn
            // 
            this.ActiveQuestionBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActiveQuestionBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ActiveQuestionBtn.IsSeparatorLine = false;
            this.ActiveQuestionBtn.Location = new System.Drawing.Point(3, 36);
            this.ActiveQuestionBtn.Name = "ActiveQuestionBtn";
            this.ActiveQuestionBtn.Size = new System.Drawing.Size(316, 290);
            this.ActiveQuestionBtn.StretchToFitForm = true;
            this.ActiveQuestionBtn.TabIndex = 0;
            this.ActiveQuestionBtn.Text = resources.GetString("ActiveQuestionBtn.Text");
            // 
            // separatorLine1
            // 
            this.separatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.separatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.separatorLine1.IsSeparatorLine = true;
            this.separatorLine1.Location = new System.Drawing.Point(2, 320);
            this.separatorLine1.Name = "separatorLine1";
            this.separatorLine1.Size = new System.Drawing.Size(316, 15);
            this.separatorLine1.StretchToFitForm = true;
            this.separatorLine1.TabIndex = 38;
            this.separatorLine1.Text = "--------------------------------------------------------------";
            // 
            // Question0Btn
            // 
            this.Question0Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.Question0Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Question0Btn.FlatAppearance.BorderSize = 0;
            this.Question0Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Question0Btn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.Question0Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Question0Btn.Location = new System.Drawing.Point(1, 336);
            this.Question0Btn.Name = "Question0Btn";
            this.Question0Btn.Size = new System.Drawing.Size(318, 24);
            this.Question0Btn.TabIndex = 1;
            this.Question0Btn.Text = "- How Do I Get My Game\'s eboot.bin?";
            this.Question0Btn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Question0Btn.UseVisualStyleBackColor = false;
            this.Question0Btn.Variable = null;
            // 
            // PkgCreationHelpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 506);
            this.Controls.Add(this.Question3Btn);
            this.Controls.Add(this.separatorLine2);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.separatorLine0);
            this.Controls.Add(this.Question2Btn);
            this.Controls.Add(this.Question1Btn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.ActiveQuestionBtn);
            this.Controls.Add(this.separatorLine1);
            this.Controls.Add(this.Question0Btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PkgCreationHelpPage";
            this.ResumeLayout(false);

        }
        #endregion

        
        
        
        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        
        public Label Info;
        public Label MainLabel;
        public Button CreditsBtn;
        public Button BackBtn;
        private Button Question0Btn;
        private Button Question1Btn;
        private Button Question2Btn;
        private Button Question3Btn;
        private Label ActiveQuestionBtn;
        public Label separatorLine0;
        public Label separatorLine1;
        public Label separatorLine2;
        #endregion
    }
}
