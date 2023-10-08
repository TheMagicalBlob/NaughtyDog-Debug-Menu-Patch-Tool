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
            AddControlEventHandlers(Controls);
            BuildLabel.Text += Build;
        }

        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoHelpPage));
            this.MainLabel = new System.Windows.Forms.Label();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.BlobLabel = new System.Windows.Forms.Label();
            this.PkgHelpPageBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.PS4QOLPageHelpBtn = new System.Windows.Forms.Button();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.BuildLabel = new System.Windows.Forms.Label();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.PS4DebugHelpBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.EbootPatchPageHelpBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.GeneralInfoLabel = new System.Windows.Forms.Label();
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
            this.MainLabel.Size = new System.Drawing.Size(266, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Information / Help";
            this.MainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MainLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // MainBox
            // 
            this.MainBox.Controls.Add(this.BlobLabel);
            this.MainBox.Controls.Add(this.PkgHelpPageBtn);
            this.MainBox.Controls.Add(this.ExitBtn);
            this.MainBox.Controls.Add(this.MinimizeBtn);
            this.MainBox.Controls.Add(this.MainLabel);
            this.MainBox.Controls.Add(this.SeperatorLine0);
            this.MainBox.Controls.Add(this.PS4QOLPageHelpBtn);
            this.MainBox.Controls.Add(this.SeperatorLine2);
            this.MainBox.Controls.Add(this.BuildLabel);
            this.MainBox.Controls.Add(this.SeperatorLine1);
            this.MainBox.Controls.Add(this.PS4DebugHelpBtn);
            this.MainBox.Controls.Add(this.label4);
            this.MainBox.Controls.Add(this.EbootPatchPageHelpBtn);
            this.MainBox.Controls.Add(this.Info);
            this.MainBox.Controls.Add(this.BackBtn);
            this.MainBox.Controls.Add(this.GeneralInfoLabel);
            this.MainBox.Location = new System.Drawing.Point(0, -6);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(320, 424);
            this.MainBox.TabIndex = 5;
            this.MainBox.TabStop = false;
            this.MainBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.MainBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            // 
            // BlobLabel
            // 
            this.BlobLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlobLabel.Font = new System.Drawing.Font("Sitka Text", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlobLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.BlobLabel.Location = new System.Drawing.Point(149, 248);
            this.BlobLabel.Name = "BlobLabel";
            this.BlobLabel.Size = new System.Drawing.Size(170, 22);
            this.BlobLabel.TabIndex = 32;
            this.BlobLabel.Text = "Created By TheMagicalBlob";
            // 
            // PkgHelpPageBtn
            // 
            this.PkgHelpPageBtn.BackColor = System.Drawing.Color.DimGray;
            this.PkgHelpPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PkgHelpPageBtn.FlatAppearance.BorderSize = 0;
            this.PkgHelpPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PkgHelpPageBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.PkgHelpPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PkgHelpPageBtn.Location = new System.Drawing.Point(1, 346);
            this.PkgHelpPageBtn.Name = "PkgHelpPageBtn";
            this.PkgHelpPageBtn.Size = new System.Drawing.Size(203, 23);
            this.PkgHelpPageBtn.TabIndex = 39;
            this.PkgHelpPageBtn.Text = "Pkg Creation Page Help";
            this.PkgHelpPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PkgHelpPageBtn.UseVisualStyleBackColor = false;
            this.PkgHelpPageBtn.Click += new System.EventHandler(this.PkgHelpPageBtn_Click);
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
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine0.TabIndex = 38;
            this.SeperatorLine0.Text = "______________________________________________________________";
            // 
            // PS4QOLPageHelpBtn
            // 
            this.PS4QOLPageHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.PS4QOLPageHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PS4QOLPageHelpBtn.FlatAppearance.BorderSize = 0;
            this.PS4QOLPageHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PS4QOLPageHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.PS4QOLPageHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PS4QOLPageHelpBtn.Location = new System.Drawing.Point(1, 323);
            this.PS4QOLPageHelpBtn.Name = "PS4QOLPageHelpBtn";
            this.PS4QOLPageHelpBtn.Size = new System.Drawing.Size(172, 23);
            this.PS4QOLPageHelpBtn.TabIndex = 35;
            this.PS4QOLPageHelpBtn.Text = "Misc. Patch Page Help...";
            this.PS4QOLPageHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PS4QOLPageHelpBtn.UseVisualStyleBackColor = false;
            this.PS4QOLPageHelpBtn.Click += new System.EventHandler(this.PS4QOLPageHelpBtn_Click);
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 359);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine2.TabIndex = 37;
            this.SeperatorLine2.Text = "______________________________________________________________";
            // 
            // BuildLabel
            // 
            this.BuildLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BuildLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Bold);
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
            this.SeperatorLine1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 256);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine1.TabIndex = 36;
            this.SeperatorLine1.Text = "______________________________________________________________";
            // 
            // PS4DebugHelpBtn
            // 
            this.PS4DebugHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.PS4DebugHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PS4DebugHelpBtn.FlatAppearance.BorderSize = 0;
            this.PS4DebugHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PS4DebugHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.PS4DebugHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PS4DebugHelpBtn.Location = new System.Drawing.Point(1, 277);
            this.PS4DebugHelpBtn.Name = "PS4DebugHelpBtn";
            this.PS4DebugHelpBtn.Size = new System.Drawing.Size(166, 23);
            this.PS4DebugHelpBtn.TabIndex = 14;
            this.PS4DebugHelpBtn.Text = "PS4Debug Page Help...";
            this.PS4DebugHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PS4DebugHelpBtn.UseVisualStyleBackColor = false;
            this.PS4DebugHelpBtn.Click += new System.EventHandler(this.PS4DebugHelpBtn_Click);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(84, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 22);
            this.label4.TabIndex = 34;
            this.label4.Text = "General App Info";
            // 
            // EbootPatchPageHelpBtn
            // 
            this.EbootPatchPageHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.EbootPatchPageHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.EbootPatchPageHelpBtn.FlatAppearance.BorderSize = 0;
            this.EbootPatchPageHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EbootPatchPageHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.EbootPatchPageHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.EbootPatchPageHelpBtn.Location = new System.Drawing.Point(1, 299);
            this.EbootPatchPageHelpBtn.Name = "EbootPatchPageHelpBtn";
            this.EbootPatchPageHelpBtn.Size = new System.Drawing.Size(253, 23);
            this.EbootPatchPageHelpBtn.TabIndex = 29;
            this.EbootPatchPageHelpBtn.Text = "Eboot\\Executable Patch Page Help...";
            this.EbootPatchPageHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EbootPatchPageHelpBtn.UseVisualStyleBackColor = false;
            this.EbootPatchPageHelpBtn.Click += new System.EventHandler(this.EbootPatchPageHelpBtn_Click);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(1, 405);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(318, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "========================================";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 379);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
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
            this.GeneralInfoLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.GeneralInfoLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.GeneralInfoLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // InfoHelpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 417);
            this.Controls.Add(this.MainBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InfoHelpPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.MainBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #region Page-Specific Functions
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        ///--     Page-Specific Functions     --\\\
        //////////////////////\\\\\\\\\\\\\\\\\\\\\

        private void BuildLabel_Click(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Right) {
                File.WriteAllLines(Directory.GetCurrentDirectory() + @"\ChangeLog.txt", Common.ChangeList);
                MessageBox.Show($"Changelist Dumped To {Directory.GetCurrentDirectory()}\\ChangeLog.txt");
            }
        }
        void BuildLabelMH(object sender, EventArgs e) { SetInfoLabelText("Right Click To Dump ChangeList"); }
        void BuildLabelML(object sender, EventArgs e) => SetInfoLabelText("");

        private void PS4DebugHelpBtn_Click(object sender, EventArgs e) => ChangeForm(PS4DebugHelpPageId);
        private void EbootPatchPageHelpBtn_Click(object sender, EventArgs e) => ChangeForm(EbootPatchHelpPageId);
        private void PS4QOLPageHelpBtn_Click(object sender, EventArgs e) {
            return;
            ChangeForm(PS4QOLHelpPageId);
        }
        private void PkgHelpPageBtn_Click(object sender, EventArgs e) {
            if(Dev.REL) return;
            ChangeForm(PkgCreationHelpPageId);
        }
        #endregion

        #region RepeatedButtonFunctions
        /////////////////\\\\\\\\\\\\\\\\\\
        ///--     Repeat Buttons      --\\\
        /////////////////\\\\\\\\\\\\\\\\\\\
        public void MoveForm(object sender, MouseEventArgs e) => Common.MoveForm(sender, e);
        public void MouseUpFunc(object sender, MouseEventArgs e) => Common.MouseUpFunc(sender, e);
        public void MouseDownFunc(object sender, MouseEventArgs e) => Common.MouseDownFunc(sender, e);
        public void ExitBtn_Click(object sender, EventArgs e) => Environment.Exit(0);
        public void ExitBtnMH(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void ExitBtnML(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 255, 255);
        public void MinimizeBtn_Click(object sender, EventArgs e) => ActiveForm.WindowState = FormWindowState.Minimized;
        public void MinimizeBtnMH(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void MinimizeBtnML(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 255, 255);
        void BackBtn_Click(object sender, EventArgs e) => BackFunc();
        #endregion

        #region ControlDeclarations
        ////////////////////\\\\\\\\\\\\\\\\\\\\
        ///--     Control Declarations     --\\\
        ////////////////////\\\\\\\\\\\\\\\\\\\\
        public Button MinimizeBtn; 
        public Label MainLabel;
        public GroupBox MainBox;
        public Button BackBtn;
        public Button ExitBtn;
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
