using System.Windows.Forms;

namespace Dobby
{
    internal partial class MainPageDummy
    {
        //======================================\\
        //--|   Designer Crap, No Touchie   |--\\\
        //======================================\\
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

        public void InitializeComponent() {
            this.SeperatorLine0 = new Dobby.Label();
            this.SeperatorLine3 = new Dobby.Label();
            this.SeperatorLine1 = new Dobby.Label();
            this.SuspendLayout();
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.IsSeparatorLine = true;
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine0.StretchToFitForm = true;
            this.SeperatorLine0.TabIndex = 31;
            this.SeperatorLine0.Text = "--------------------------------------------------------------";
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.IsSeparatorLine = true;
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 194);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine3.StretchToFitForm = true;
            this.SeperatorLine3.TabIndex = 32;
            this.SeperatorLine3.Text = "--------------------------------------------------------------";
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.IsSeparatorLine = true;
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 144);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine1.StretchToFitForm = true;
            this.SeperatorLine1.TabIndex = 36;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(319, 307);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.SeperatorLine0);
            this.Controls.Add(this.SeperatorLine3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPage";
            this.ResumeLayout(false);

        }
        #endregion


        
        

        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        public Label SeperatorLine0;
        public Label SeperatorLine1;
        public Label SeperatorLine3;
        #endregion
    }
}
