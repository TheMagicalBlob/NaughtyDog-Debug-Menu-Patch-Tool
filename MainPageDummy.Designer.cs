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
            this.separatorLine0 = new Dobby.Label();
            this.separatorLine3 = new Dobby.Label();
            this.separatorLine1 = new Dobby.Label();
            this.SuspendLayout();
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
            this.separatorLine0.TabIndex = 31;
            this.separatorLine0.Text = "--------------------------------------------------------------";
            // 
            // separatorLine3
            // 
            this.separatorLine3.Font = new System.Drawing.Font("Cambria", 10F);
            this.separatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.separatorLine3.IsSeparatorLine = true;
            this.separatorLine3.Location = new System.Drawing.Point(2, 194);
            this.separatorLine3.Name = "separatorLine3";
            this.separatorLine3.Size = new System.Drawing.Size(316, 15);
            this.separatorLine3.StretchToFitForm = true;
            this.separatorLine3.TabIndex = 32;
            this.separatorLine3.Text = "--------------------------------------------------------------";
            // 
            // separatorLine1
            // 
            this.separatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.separatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.separatorLine1.IsSeparatorLine = true;
            this.separatorLine1.Location = new System.Drawing.Point(2, 144);
            this.separatorLine1.Name = "separatorLine1";
            this.separatorLine1.Size = new System.Drawing.Size(316, 15);
            this.separatorLine1.StretchToFitForm = true;
            this.separatorLine1.TabIndex = 36;
            this.separatorLine1.Text = "--------------------------------------------------------------";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(319, 307);
            this.Controls.Add(this.separatorLine1);
            this.Controls.Add(this.separatorLine0);
            this.Controls.Add(this.separatorLine3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPage";
            this.ResumeLayout(false);

        }
        #endregion


        
        

        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        public Label separatorLine0;
        public Label separatorLine1;
        public Label separatorLine3;
        #endregion
    }
}
