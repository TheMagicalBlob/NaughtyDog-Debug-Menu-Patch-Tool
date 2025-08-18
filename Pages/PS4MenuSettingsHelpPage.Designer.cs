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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EbootPatchHelpPage));
            this.MainLabel = new Dobby.Label();
            this.Question3Btn = new Button();
            this.SeperatorLine2 = new Dobby.Label();
            this.SeperatorLine0 = new Dobby.Label();
            this.WithSomeExceptionsLabel = new Dobby.Label();
            this.Question2Btn = new Button();
            this.Question1Btn = new Button();
            this.Info = new Dobby.Label();
            this.CreditsBtn = new Button();
            this.BackBtn = new Button();
            this.DefaultQuestionBtn = new Dobby.Label();
            this.SeperatorLine1 = new Dobby.Label();
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
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 9.25F);
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
            // 
            // EbootPatchHelpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 506);
            this.Controls.Add(this.Question3Btn);
            this.Controls.Add(this.SeperatorLine2);
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
        private Label DefaultQuestionBtn;
        private Label WithSomeExceptionsLabel;
        public Label SeperatorLine0;
        public Label SeperatorLine1;
        public Label SeperatorLine2;
        #endregion
    }
}
