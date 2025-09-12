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
            this.PopupTestIndexBtn = new Dobby.Button();
            this.EditorModeBtn = new Dobby.Button();
            this.PopupTestBtn = new Dobby.Button();
            this.DebugLogTextBox = new Dobby.RichTextBox();
            this.PCLabel = new Dobby.Label();
            this.label1 = new Dobby.Label();
            this.NoDrawBtn = new Dobby.Button();
            this.Playstation4Label = new Dobby.Label();
            this.separatorLine1 = new Dobby.Label();
            this.MainLabel = new Dobby.Label();
            this.separatorLine0 = new Dobby.Label();
            this.SuspendLayout();
            // 
            // PopupTestIndexBtn
            // 
            this.PopupTestIndexBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PopupTestIndexBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PopupTestIndexBtn.FlatAppearance.BorderSize = 0;
            this.PopupTestIndexBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PopupTestIndexBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.PopupTestIndexBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PopupTestIndexBtn.Location = new System.Drawing.Point(1, 63);
            this.PopupTestIndexBtn.Name = "PopupTestIndexBtn";
            this.PopupTestIndexBtn.Size = new System.Drawing.Size(82, 24);
            this.PopupTestIndexBtn.TabIndex = 48;
            this.PopupTestIndexBtn.Tag = "";
            this.PopupTestIndexBtn.Text = "PopupTestIndex: ";
            this.PopupTestIndexBtn.Variable = 0;
            this.PopupTestIndexBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PopupTestIndexBtn.UseVisualStyleBackColor = false;
            this.PopupTestIndexBtn.Variable = null;
            // 
            // EditorModeBtn
            // 
            this.EditorModeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.EditorModeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.EditorModeBtn.FlatAppearance.BorderSize = 0;
            this.EditorModeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditorModeBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.EditorModeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.EditorModeBtn.Location = new System.Drawing.Point(1, 117);
            this.EditorModeBtn.Name = "EditorModeBtn";
            this.EditorModeBtn.Size = new System.Drawing.Size(118, 24);
            this.EditorModeBtn.TabIndex = 47;
            this.EditorModeBtn.Tag = "";
            this.EditorModeBtn.Text = "Editor Mode: ";
            this.EditorModeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditorModeBtn.UseVisualStyleBackColor = false;
            this.EditorModeBtn.Variable = false;
            this.EditorModeBtn.Click += new System.EventHandler(this.EditorModeBtn_Click);
            // 
            // PopupTestBtn
            // 
            this.PopupTestBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PopupTestBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PopupTestBtn.FlatAppearance.BorderSize = 0;
            this.PopupTestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PopupTestBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.PopupTestBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PopupTestBtn.Location = new System.Drawing.Point(12, 87);
            this.PopupTestBtn.Name = "PopupTestBtn";
            this.PopupTestBtn.Size = new System.Drawing.Size(82, 24);
            this.PopupTestBtn.TabIndex = 46;
            this.PopupTestBtn.Tag = "";
            this.PopupTestBtn.Text = "PopupTest";
            this.PopupTestBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PopupTestBtn.UseVisualStyleBackColor = false;
            this.PopupTestBtn.Variable = null;
            this.PopupTestBtn.Click += new System.EventHandler(this.PopupTestBtn_Click);
            // 
            // DebugLogTextBox
            // 
            this.DebugLogTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.DebugLogTextBox.ForeColor = System.Drawing.SystemColors.Control;
            this.DebugLogTextBox.Location = new System.Drawing.Point(1, 176);
            this.DebugLogTextBox.Name = "DebugLogTextBox";
            this.DebugLogTextBox.Size = new System.Drawing.Size(316, 127);
            this.DebugLogTextBox.TabIndex = 45;
            this.DebugLogTextBox.Text = "";
            // 
            // PCLabel
            // 
            this.PCLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.PCLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PCLabel.IsSeparatorLine = false;
            this.PCLabel.Location = new System.Drawing.Point(119, 159);
            this.PCLabel.Name = "PCLabel";
            this.PCLabel.Size = new System.Drawing.Size(70, 14);
            this.PCLabel.StretchToFitForm = true;
            this.PCLabel.TabIndex = 37;
            this.PCLabel.Text = "Log Window";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Cambria", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label1.IsSeparatorLine = false;
            this.label1.Location = new System.Drawing.Point(2, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 15);
            this.label1.StretchToFitForm = true;
            this.label1.TabIndex = 44;
            this.label1.Text = "--------------------------------------------------------------";
            // 
            // NoDrawBtn
            // 
            this.NoDrawBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.NoDrawBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.NoDrawBtn.FlatAppearance.BorderSize = 0;
            this.NoDrawBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoDrawBtn.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.NoDrawBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.NoDrawBtn.Location = new System.Drawing.Point(1, 42);
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
            // Playstation4Label
            // 
            this.Playstation4Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Playstation4Label.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.Playstation4Label.ForeColor = System.Drawing.SystemColors.Control;
            this.Playstation4Label.IsSeparatorLine = false;
            this.Playstation4Label.Location = new System.Drawing.Point(126, 30);
            this.Playstation4Label.Name = "Playstation4Label";
            this.Playstation4Label.Size = new System.Drawing.Size(57, 15);
            this.Playstation4Label.StretchToFitForm = true;
            this.Playstation4Label.TabIndex = 36;
            this.Playstation4Label.Text = "Functions";
            // 
            // separatorLine1
            // 
            this.separatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.separatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.separatorLine1.IsSeparatorLine = false;
            this.separatorLine1.Location = new System.Drawing.Point(2, 144);
            this.separatorLine1.Name = "separatorLine1";
            this.separatorLine1.Size = new System.Drawing.Size(316, 15);
            this.separatorLine1.StretchToFitForm = true;
            this.separatorLine1.TabIndex = 36;
            this.separatorLine1.Text = "--------------------------------------------------------------";
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
            this.MainLabel.StretchToFitForm = true;
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
            this.separatorLine0.StretchToFitForm = true;
            this.separatorLine0.TabIndex = 31;
            this.separatorLine0.Text = "--------------------------------------------------------------";
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 309);
            this.Controls.Add(this.PopupTestIndexBtn);
            this.Controls.Add(this.EditorModeBtn);
            this.Controls.Add(this.PopupTestBtn);
            this.Controls.Add(this.DebugLogTextBox);
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
        private RichTextBox DebugLogTextBox;
        private Button PopupTestBtn;
        private Button EditorModeBtn;
        private Button PopupTestIndexBtn;
    }
}
#endif
