#if DEBUG
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dobby
{
    partial class DebugWindow
    {
        public void InitializeComponent()
        {
            this.MainLabel = new Dobby.Label();
            this.separatorLine0 = new Dobby.Label();
            this.separatorLine1 = new Dobby.Label();
            this.Playstation4Label = new Dobby.Label();
            this.PCLabel = new Dobby.Label();
            this.NoDrawBtn = new Dobby.Button();
            this.label1 = new Dobby.Label();
            this.richTextBox1 = new Dobby.RichTextBox();
            this.PopupTestBtn = new Dobby.Button();
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
            this.MainLabel.Size = new System.Drawing.Size(80, 22);
            this.MainLabel.StretchToFitForm = false;
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "DevPanel";
            // 
            // separatorLine0
            // 
            this.separatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.separatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.separatorLine0.IsSeparatorLine = false;
            this.separatorLine0.Location = new System.Drawing.Point(2, 15);
            this.separatorLine0.Name = "separatorLine0";
            this.separatorLine0.Size = new System.Drawing.Size(316, 15);
            this.separatorLine0.StretchToFitForm = false;
            this.separatorLine0.TabIndex = 31;
            this.separatorLine0.Text = "--------------------------------------------------------------";
            // 
            // separatorLine1
            // 
            this.separatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.separatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.separatorLine1.IsSeparatorLine = false;
            this.separatorLine1.Location = new System.Drawing.Point(2, 144);
            this.separatorLine1.Name = "separatorLine1";
            this.separatorLine1.Size = new System.Drawing.Size(316, 15);
            this.separatorLine1.StretchToFitForm = false;
            this.separatorLine1.TabIndex = 36;
            this.separatorLine1.Text = "--------------------------------------------------------------";
            // 
            // Playstation4Label
            // 
            this.Playstation4Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Playstation4Label.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.Playstation4Label.ForeColor = System.Drawing.SystemColors.Control;
            this.Playstation4Label.IsSeparatorLine = false;
            this.Playstation4Label.Location = new System.Drawing.Point(119, 30);
            this.Playstation4Label.Name = "Playstation4Label";
            this.Playstation4Label.Size = new System.Drawing.Size(73, 15);
            this.Playstation4Label.StretchToFitForm = false;
            this.Playstation4Label.TabIndex = 36;
            this.Playstation4Label.Text = "Functions";
            // 
            // PCLabel
            // 
            this.PCLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.PCLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PCLabel.IsSeparatorLine = false;
            this.PCLabel.Location = new System.Drawing.Point(118, 159);
            this.PCLabel.Name = "PCLabel";
            this.PCLabel.Size = new System.Drawing.Size(70, 14);
            this.PCLabel.StretchToFitForm = false;
            this.PCLabel.TabIndex = 37;
            this.PCLabel.Text = "Log Window";
            // 
            // NoDrawBtn
            // 
            this.NoDrawBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.NoDrawBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.NoDrawBtn.FlatAppearance.BorderSize = 0;
            this.NoDrawBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoDrawBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.NoDrawBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.NoDrawBtn.Location = new System.Drawing.Point(1, 44);
            this.NoDrawBtn.Name = "NoDrawBtn";
            this.NoDrawBtn.Size = new System.Drawing.Size(93, 24);
            this.NoDrawBtn.TabIndex = 43;
            this.NoDrawBtn.Tag = "";
            this.NoDrawBtn.Text = "NoDraw:";
            this.NoDrawBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NoDrawBtn.UseVisualStyleBackColor = false;
            this.NoDrawBtn.Variable = false;
            this.NoDrawBtn.Click += new System.EventHandler(this.NoDrawBtn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Cambria", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label1.IsSeparatorLine = false;
            this.label1.Location = new System.Drawing.Point(2, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 15);
            this.label1.StretchToFitForm = false;
            this.label1.TabIndex = 44;
            this.label1.Text = "--------------------------------------------------------------";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Location = new System.Drawing.Point(2, 180);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(316, 127);
            this.richTextBox1.TabIndex = 45;
            this.richTextBox1.Text = "";
            // 
            // PopupTestBtn
            // 
            this.PopupTestBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PopupTestBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PopupTestBtn.FlatAppearance.BorderSize = 0;
            this.PopupTestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PopupTestBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.PopupTestBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PopupTestBtn.Location = new System.Drawing.Point(1, 70);
            this.PopupTestBtn.Name = "PopupTestBtn";
            this.PopupTestBtn.Size = new System.Drawing.Size(105, 24);
            this.PopupTestBtn.TabIndex = 46;
            this.PopupTestBtn.Tag = "";
            this.PopupTestBtn.Text = "PopupTest";
            this.PopupTestBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PopupTestBtn.UseVisualStyleBackColor = false;
            this.PopupTestBtn.Variable = false;
            this.PopupTestBtn.Click += new System.EventHandler(this.PopupTestBtn_Click);
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 309);
            this.Controls.Add(this.PopupTestBtn);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.PCLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NoDrawBtn);
            this.Controls.Add(this.Playstation4Label);
            this.Controls.Add(this.separatorLine1);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.separatorLine0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DebugWindow";
            this.ResumeLayout(false);

        }

        

        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        public Label MainLabel;
        public Label separatorLine0;
        public Label separatorLine1;
        public Label Playstation4Label;
        public Label PCLabel;
        #endregion

        private Button NoDrawBtn;
        public Label label1;
        private RichTextBox richTextBox1;
        private Button PopupTestBtn;
    }
}
#endif
