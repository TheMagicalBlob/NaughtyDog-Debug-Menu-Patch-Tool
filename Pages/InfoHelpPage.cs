using System;
using libdebug;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Dobby.Common;

namespace Dobby {
    public class InfoHelpPage : Form {
        public InfoHelpPage() {
            InitializeComponent();
            
            InitializeAdditionalEventHandlers(Controls);
            BuildLabel.Text += Ver.Build;
        }


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoHelpPage));
            this.MainLabel = new System.Windows.Forms.Label();
            this.BlobLabel = new System.Windows.Forms.Label();
            this.PkgHelpPageBtn = new Dobby.Button();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.PS4QOLPageHelpBtn = new Dobby.Button();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.BuildLabel = new System.Windows.Forms.Label();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.PS4DebugHelpBtn = new Dobby.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.EbootPatchPageHelpBtn = new Dobby.Button();
            this.Info = new System.Windows.Forms.Label();
            this.BackBtn = new Dobby.Button();
            this.GeneralInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(1, 1);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(266, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Information / Help";
            // 
            // BlobLabel
            // 
            this.BlobLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlobLabel.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlobLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.BlobLabel.Location = new System.Drawing.Point(149, 247);
            this.BlobLabel.Name = "BlobLabel";
            this.BlobLabel.Size = new System.Drawing.Size(170, 22);
            this.BlobLabel.TabIndex = 32;
            this.BlobLabel.Text = "Created By TheMagicalBlob";
            // 
            // PkgHelpPageBtn
            // 
            this.PkgHelpPageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PkgHelpPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PkgHelpPageBtn.FlatAppearance.BorderSize = 0;
            this.PkgHelpPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PkgHelpPageBtn.Font = new System.Drawing.Font("Cambria", 9.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.PkgHelpPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PkgHelpPageBtn.Location = new System.Drawing.Point(1, 347);
            this.PkgHelpPageBtn.Name = "PkgHelpPageBtn";
            this.PkgHelpPageBtn.Size = new System.Drawing.Size(203, 23);
            this.PkgHelpPageBtn.TabIndex = 39;
            this.PkgHelpPageBtn.Text = "Pkg Creation Page Help";
            this.PkgHelpPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PkgHelpPageBtn.UseVisualStyleBackColor = false;
            this.PkgHelpPageBtn.Variable = null;
            this.PkgHelpPageBtn.Click += new System.EventHandler(this.PkgHelpPageBtn_Click);
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine0.TabIndex = 38;
            this.SeperatorLine0.Text = "--------------------------------------------------------------";
            // 
            // PS4QOLPageHelpBtn
            // 
            this.PS4QOLPageHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PS4QOLPageHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PS4QOLPageHelpBtn.FlatAppearance.BorderSize = 0;
            this.PS4QOLPageHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PS4QOLPageHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.PS4QOLPageHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PS4QOLPageHelpBtn.Location = new System.Drawing.Point(1, 324);
            this.PS4QOLPageHelpBtn.Name = "PS4QOLPageHelpBtn";
            this.PS4QOLPageHelpBtn.Size = new System.Drawing.Size(172, 23);
            this.PS4QOLPageHelpBtn.TabIndex = 35;
            this.PS4QOLPageHelpBtn.Text = "Misc. Patch Page Help...";
            this.PS4QOLPageHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PS4QOLPageHelpBtn.UseVisualStyleBackColor = false;
            this.PS4QOLPageHelpBtn.Variable = null;
            this.PS4QOLPageHelpBtn.Click += new System.EventHandler(this.PS4QOLPageHelpBtn_Click);
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 367);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine2.TabIndex = 37;
            this.SeperatorLine2.Text = "--------------------------------------------------------------";
            // 
            // BuildLabel
            // 
            this.BuildLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BuildLabel.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold);
            this.BuildLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.BuildLabel.Location = new System.Drawing.Point(1, 248);
            this.BuildLabel.Name = "BuildLabel";
            this.BuildLabel.Size = new System.Drawing.Size(304, 22);
            this.BuildLabel.TabIndex = 20;
            this.BuildLabel.Text = "Build: ";
            this.BuildLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BuildLabel_Click);
            this.BuildLabel.MouseEnter += new System.EventHandler(this.BuildLabelMH);
            this.BuildLabel.MouseLeave += new System.EventHandler(this.BuildLabelML);
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 265);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine1.TabIndex = 36;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // PS4DebugHelpBtn
            // 
            this.PS4DebugHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PS4DebugHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PS4DebugHelpBtn.FlatAppearance.BorderSize = 0;
            this.PS4DebugHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PS4DebugHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.PS4DebugHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PS4DebugHelpBtn.Location = new System.Drawing.Point(1, 278);
            this.PS4DebugHelpBtn.Name = "PS4DebugHelpBtn";
            this.PS4DebugHelpBtn.Size = new System.Drawing.Size(166, 23);
            this.PS4DebugHelpBtn.TabIndex = 14;
            this.PS4DebugHelpBtn.Text = "PS4Debug Page Help...";
            this.PS4DebugHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PS4DebugHelpBtn.UseVisualStyleBackColor = false;
            this.PS4DebugHelpBtn.Variable = null;
            this.PS4DebugHelpBtn.Click += new System.EventHandler(this.PS4DebugHelpBtn_Click);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(84, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 22);
            this.label4.TabIndex = 34;
            this.label4.Text = "General App Info";
            // 
            // EbootPatchPageHelpBtn
            // 
            this.EbootPatchPageHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.EbootPatchPageHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.EbootPatchPageHelpBtn.FlatAppearance.BorderSize = 0;
            this.EbootPatchPageHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EbootPatchPageHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.EbootPatchPageHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.EbootPatchPageHelpBtn.Location = new System.Drawing.Point(1, 300);
            this.EbootPatchPageHelpBtn.Name = "EbootPatchPageHelpBtn";
            this.EbootPatchPageHelpBtn.Size = new System.Drawing.Size(253, 23);
            this.EbootPatchPageHelpBtn.TabIndex = 29;
            this.EbootPatchPageHelpBtn.Text = "Eboot\\Executable Patch Page Help...";
            this.EbootPatchPageHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EbootPatchPageHelpBtn.UseVisualStyleBackColor = false;
            this.EbootPatchPageHelpBtn.Variable = null;
            this.EbootPatchPageHelpBtn.Click += new System.EventHandler(this.EbootPatchPageHelpBtn_Click);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(7, 411);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(309, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "========================================";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 383);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Variable = null;
            // 
            // GeneralInfoLabel
            // 
            this.GeneralInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GeneralInfoLabel.Font = new System.Drawing.Font("Sitka Text", 9F, System.Drawing.FontStyle.Bold);
            this.GeneralInfoLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.GeneralInfoLabel.Location = new System.Drawing.Point(3, 54);
            this.GeneralInfoLabel.Name = "GeneralInfoLabel";
            this.GeneralInfoLabel.Size = new System.Drawing.Size(302, 195);
            this.GeneralInfoLabel.TabIndex = 33;
            this.GeneralInfoLabel.Text = resources.GetString("GeneralInfoLabel.Text");
            // 
            // InfoHelpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 434);
            this.Controls.Add(this.BlobLabel);
            this.Controls.Add(this.PkgHelpPageBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine0);
            this.Controls.Add(this.PS4QOLPageHelpBtn);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.BuildLabel);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.PS4DebugHelpBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EbootPatchPageHelpBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.GeneralInfoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InfoHelpPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }

        #endregion


        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        ///--     Page-Specific Functions     --\\\
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        #region Page-Specific Functions
        private void BuildLabel_Click(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Right) {
                File.WriteAllLines(Directory.GetCurrentDirectory() + @"\ChangeLog.txt", Ver.ChangeList);
                MessageBox.Show($"Changelist Dumped To {Directory.GetCurrentDirectory()}\\ChangeLog.txt");
            }
        }
        void BuildLabelMH(object sender, EventArgs e) { UpdateLabel("Right Click To Dump ChangeList"); }
        void BuildLabelML(object sender, EventArgs e) => UpdateLabel("");

        private void PS4DebugHelpBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.PS4DebugHelpPage);
        private void EbootPatchPageHelpBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.EbootPatchHelpPage);
        private void PS4QOLPageHelpBtn_Click(object sender, EventArgs e) {
            #if false
            ChangeForm(PageID.PS4MiscPatchesHelpPage);
            #endif
        }
        private void PkgHelpPageBtn_Click(object sender, EventArgs e) {
            #if false
            ChangeForm(PageID.PkgCreationHelpPage);
            #endif
        }
        #endregion


        
        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        public Label MainLabel;
        public Button BackBtn;
        public Button PS4DebugHelpBtn;
        public Button EbootPatchPageHelpBtn;
        public Label BuildLabel;
        public Label BlobLabel;
        public Label GeneralInfoLabel;
        public Label label4;
        public Button PS4QOLPageHelpBtn;
        public Label Info;
        public Label SeperatorLine0;
        public Label SeperatorLine2;
        public Button PkgHelpPageBtn;
        public Label SeperatorLine1;
        #endregion
    }
}
