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
            SetPageInfo(this);
            BuildLabel.Text += Build;
        }

        public Label label5;
        public Label label1;
        public Label label2;
        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoHelpPage));
            this.MainLabel = new System.Windows.Forms.Label();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.MiscPatchPageHelpBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BlobLabel = new System.Windows.Forms.Label();
            this.BuildLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.MainBox.Controls.Add(this.ExitBtn);
            this.MainBox.Controls.Add(this.MinimizeBtn);
            this.MainBox.Controls.Add(this.MainLabel);
            this.MainBox.Controls.Add(this.label5);
            this.MainBox.Controls.Add(this.MiscPatchPageHelpBtn);
            this.MainBox.Controls.Add(this.label1);
            this.MainBox.Controls.Add(this.BlobLabel);
            this.MainBox.Controls.Add(this.BuildLabel);
            this.MainBox.Controls.Add(this.label2);
            this.MainBox.Controls.Add(this.PS4DebugHelpBtn);
            this.MainBox.Controls.Add(this.label4);
            this.MainBox.Controls.Add(this.EbootPatchPageHelpBtn);
            this.MainBox.Controls.Add(this.Info);
            this.MainBox.Controls.Add(this.BackBtn);
            this.MainBox.Controls.Add(this.GeneralInfoLabel);
            this.MainBox.Location = new System.Drawing.Point(0, -6);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(320, 366);
            this.MainBox.TabIndex = 5;
            this.MainBox.TabStop = false;
            this.MainBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.MainBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
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
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label5.Location = new System.Drawing.Point(2, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(316, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "______________________________________________________________";
            // 
            // MiscPatchPageHelpBtn
            // 
            this.MiscPatchPageHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.MiscPatchPageHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MiscPatchPageHelpBtn.FlatAppearance.BorderSize = 0;
            this.MiscPatchPageHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MiscPatchPageHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.MiscPatchPageHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MiscPatchPageHelpBtn.Location = new System.Drawing.Point(1, 283);
            this.MiscPatchPageHelpBtn.Name = "MiscPatchPageHelpBtn";
            this.MiscPatchPageHelpBtn.Size = new System.Drawing.Size(172, 23);
            this.MiscPatchPageHelpBtn.TabIndex = 35;
            this.MiscPatchPageHelpBtn.Text = "Misc. Patch Page Help...";
            this.MiscPatchPageHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MiscPatchPageHelpBtn.UseVisualStyleBackColor = false;
            this.MiscPatchPageHelpBtn.Click += new System.EventHandler(this.MiscPatchPageHelpBtn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label1.Location = new System.Drawing.Point(2, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "______________________________________________________________";
            // 
            // BlobLabel
            // 
            this.BlobLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlobLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F, System.Drawing.FontStyle.Bold);
            this.BlobLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.BlobLabel.Location = new System.Drawing.Point(149, 207);
            this.BlobLabel.Name = "BlobLabel";
            this.BlobLabel.Size = new System.Drawing.Size(170, 22);
            this.BlobLabel.TabIndex = 32;
            this.BlobLabel.Text = "Created By TheMagicalBlob";
            // 
            // BuildLabel
            // 
            this.BuildLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BuildLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Bold);
            this.BuildLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.BuildLabel.Location = new System.Drawing.Point(1, 208);
            this.BuildLabel.Name = "BuildLabel";
            this.BuildLabel.Size = new System.Drawing.Size(304, 22);
            this.BuildLabel.TabIndex = 20;
            this.BuildLabel.Text = "Build: ";
            this.BuildLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BuildLabel_Click);
            this.BuildLabel.MouseEnter += new System.EventHandler(this.BuildLabelMH);
            this.BuildLabel.MouseLeave += new System.EventHandler(this.BuildLabelML);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label2.Location = new System.Drawing.Point(2, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "______________________________________________________________";
            // 
            // PS4DebugHelpBtn
            // 
            this.PS4DebugHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.PS4DebugHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PS4DebugHelpBtn.FlatAppearance.BorderSize = 0;
            this.PS4DebugHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PS4DebugHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.PS4DebugHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PS4DebugHelpBtn.Location = new System.Drawing.Point(1, 235);
            this.PS4DebugHelpBtn.Name = "PS4DebugHelpBtn";
            this.PS4DebugHelpBtn.Size = new System.Drawing.Size(166, 23);
            this.PS4DebugHelpBtn.TabIndex = 14;
            this.PS4DebugHelpBtn.Text = "PS4Debug Page Help...";
            this.PS4DebugHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PS4DebugHelpBtn.UseVisualStyleBackColor = false;
            this.PS4DebugHelpBtn.Click += new System.EventHandler(this.PS4DebugHelpBtn_Click);
            this.PS4DebugHelpBtn.MouseEnter += new System.EventHandler(this.PS4DebugHelpBtnMH);
            this.PS4DebugHelpBtn.MouseLeave += new System.EventHandler(this.PS4DebugHelpBtnML);
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
            this.EbootPatchPageHelpBtn.Location = new System.Drawing.Point(1, 259);
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
            this.Info.Location = new System.Drawing.Point(8, 342);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=====================================";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 317);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            this.BackBtn.MouseEnter += new System.EventHandler(this.BackBtnMH);
            this.BackBtn.MouseLeave += new System.EventHandler(this.BackBtnML);
            // 
            // GeneralInfoLabel
            // 
            this.GeneralInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GeneralInfoLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.GeneralInfoLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.GeneralInfoLabel.Location = new System.Drawing.Point(3, 54);
            this.GeneralInfoLabel.Name = "GeneralInfoLabel";
            this.GeneralInfoLabel.Size = new System.Drawing.Size(302, 171);
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
            this.ClientSize = new System.Drawing.Size(320, 359);
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
        public void MoveForm(object sender, MouseEventArgs e) => Common.MoveForm(sender, e);
        public void MouseUpFunc(object sender, MouseEventArgs e) => Common.MouseUpFunc(sender, e);
        public void MouseDownFunc(object sender, MouseEventArgs e) => Common.MouseDownFunc(sender, e);
        public void ExitBtn_Click(object sender, EventArgs e) => Environment.Exit(0);
        public void ExitBtnMH(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void ExitBtnML(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 255, 255);

        public void MinimizeBtn_Click(object sender, EventArgs e) => ActiveForm.WindowState = FormWindowState.Minimized;
        public void MinimizeBtnMH(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void MinimizeBtnML(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 255, 255);
        void BackBtn_Click(object sender, EventArgs e) {
            LabelShouldFlash = false;
            Form ClosingForm = ActiveForm;
            LastPos = ClosingForm.Location;
            MainForm.Show();
            ActiveForm.Location = LastPos;
            ClosingForm.Close();
            Dobby.Page = ActiveForm.Name;
            SetPageInfo(MainForm);
            HoverLeave(BackBtn, 1);
        }
        public void BackBtnMH(object sender, EventArgs e) => HoverString(BackBtn, $"{(Dev.REL ? "" : LastForm.Name)}");
        public void BackBtnML(object sender, EventArgs e) => HoverLeave(BackBtn, 1);

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
        public Button MiscPatchPageHelpBtn;
        public Label Info;

        public void PS4DebugHelpBtn_Click(object sender, EventArgs e) {
            LastForm = ActiveForm;
            LastPos = LastForm.Location;
            PS4InfoPage NewPage = new PS4InfoPage();
            NewPage.Show();
            LastForm.Hide();
            if (!Dev.REL) PageInfo(ActiveForm.Controls);
        }
        public void PS4DebugHelpBtnMH(object sender, EventArgs e) => HoverLeave(PS4DebugHelpBtn, 0);
        public void PS4DebugHelpBtnML(object sender, EventArgs e) => HoverLeave(PS4DebugHelpBtn, 1);

        private void BuildLabel_Click(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                File.WriteAllLines(Directory.GetCurrentDirectory() + @"\ChangeLog.txt", Common.ChangeList );
                MessageBox.Show($"Changelist Dumped To {Directory.GetCurrentDirectory()}\\ChangeLog.txt");
            }
        }

        void BuildLabelMH(object sender, EventArgs e) => HoverString(BuildLabel, "Display ChangeList");
        void BuildLabelML(object sender, EventArgs e) => HoverLeave(BuildLabel, 1);

        private void MiscPatchPageHelpBtn_Click(object sender, EventArgs e) {

        }
        void MiscPatchPageHelpBtnMH(object sender, EventArgs e) => HoverLeave(MiscPatchPageHelpBtn, 0);

        void MiscPatchPageHelpBtnML(object sender, EventArgs e) => HoverLeave(MiscPatchPageHelpBtn, 1);

        private void EbootPatchPageHelpBtn_Click(object sender, EventArgs e) {
            LastForm = this;
            LastPos = LastForm.Location;
            EbootPatchHelpPage page = new EbootPatchHelpPage();
            page.Show();
            LastForm.Hide();
        }
    }
}
//fuck_yourself:
