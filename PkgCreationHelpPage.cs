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
    public class PkgCreationHelpPage : Form {
        public PkgCreationHelpPage() {
            InitializeComponent();
            AddControlEventHandlers(Controls);
        }

        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PkgCreationHelpPage));
            this.MainLabel = new System.Windows.Forms.Label();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UsingGenGP4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TroubleshootingLabel = new System.Windows.Forms.Label();
            this.PkgCreationInfoLabel1 = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SeperatorLabel3 = new System.Windows.Forms.Label();
            this.SeperatorLabel2 = new System.Windows.Forms.Label();
            this.ObtainingFilesLabel = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.PkgCreationInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.MainLabel.Text = "Pkg Creation Help Page";
            this.MainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MainLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // MainBox
            // 
            this.MainBox.Controls.Add(this.PkgCreationInfo);
            this.MainBox.Controls.Add(this.label4);
            this.MainBox.Controls.Add(this.label1);
            this.MainBox.Controls.Add(this.label3);
            this.MainBox.Controls.Add(this.UsingGenGP4);
            this.MainBox.Controls.Add(this.label2);
            this.MainBox.Controls.Add(this.TroubleshootingLabel);
            this.MainBox.Controls.Add(this.PkgCreationInfoLabel1);
            this.MainBox.Controls.Add(this.ExitBtn);
            this.MainBox.Controls.Add(this.MinimizeBtn);
            this.MainBox.Controls.Add(this.MainLabel);
            this.MainBox.Controls.Add(this.label5);
            this.MainBox.Controls.Add(this.SeperatorLabel3);
            this.MainBox.Controls.Add(this.SeperatorLabel2);
            this.MainBox.Controls.Add(this.ObtainingFilesLabel);
            this.MainBox.Controls.Add(this.Info);
            this.MainBox.Controls.Add(this.BackBtn);
            this.MainBox.Location = new System.Drawing.Point(0, -6);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(320, 485);
            this.MainBox.TabIndex = 5;
            this.MainBox.TabStop = false;
            this.MainBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.MainBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Gadugi", 9.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(1, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 22);
            this.label3.TabIndex = 43;
            this.label3.Text = "\"CUSA00552-patch\"";
            // 
            // UsingGenGP4
            // 
            this.UsingGenGP4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsingGenGP4.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.UsingGenGP4.ForeColor = System.Drawing.SystemColors.Control;
            this.UsingGenGP4.Location = new System.Drawing.Point(1, 157);
            this.UsingGenGP4.Name = "UsingGenGP4";
            this.UsingGenGP4.Size = new System.Drawing.Size(318, 22);
            this.UsingGenGP4.TabIndex = 42;
            this.UsingGenGP4.Text = "Getting A .gp4 File With gengp4.exe:";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(1, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 82);
            this.label2.TabIndex = 41;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // TroubleshootingLabel
            // 
            this.TroubleshootingLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TroubleshootingLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.75F, System.Drawing.FontStyle.Bold);
            this.TroubleshootingLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.TroubleshootingLabel.Location = new System.Drawing.Point(1, 273);
            this.TroubleshootingLabel.Name = "TroubleshootingLabel";
            this.TroubleshootingLabel.Size = new System.Drawing.Size(318, 22);
            this.TroubleshootingLabel.TabIndex = 40;
            this.TroubleshootingLabel.Text = "Troubleshooting:";
            this.TroubleshootingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PkgCreationInfoLabel1
            // 
            this.PkgCreationInfoLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PkgCreationInfoLabel1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.PkgCreationInfoLabel1.ForeColor = System.Drawing.SystemColors.Control;
            this.PkgCreationInfoLabel1.Location = new System.Drawing.Point(1, 52);
            this.PkgCreationInfoLabel1.Name = "PkgCreationInfoLabel1";
            this.PkgCreationInfoLabel1.Size = new System.Drawing.Size(318, 22);
            this.PkgCreationInfoLabel1.TabIndex = 39;
            this.PkgCreationInfoLabel1.Text = "orbis-pub-cmd.exe and gengp4.exe:";
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
            // SeperatorLabel3
            // 
            this.SeperatorLabel3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel3.Location = new System.Drawing.Point(2, 417);
            this.SeperatorLabel3.Name = "SeperatorLabel3";
            this.SeperatorLabel3.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLabel3.TabIndex = 37;
            this.SeperatorLabel3.Text = "______________________________________________________________";
            // 
            // SeperatorLabel2
            // 
            this.SeperatorLabel2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel2.Location = new System.Drawing.Point(2, 257);
            this.SeperatorLabel2.Name = "SeperatorLabel2";
            this.SeperatorLabel2.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLabel2.TabIndex = 36;
            this.SeperatorLabel2.Text = "______________________________________________________________";
            // 
            // ObtainingFilesLabel
            // 
            this.ObtainingFilesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ObtainingFilesLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.75F, System.Drawing.FontStyle.Bold);
            this.ObtainingFilesLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.ObtainingFilesLabel.Location = new System.Drawing.Point(1, 31);
            this.ObtainingFilesLabel.Name = "ObtainingFilesLabel";
            this.ObtainingFilesLabel.Size = new System.Drawing.Size(318, 22);
            this.ObtainingFilesLabel.TabIndex = 34;
            this.ObtainingFilesLabel.Text = "Optaining The Files Needed:";
            this.ObtainingFilesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(8, 463);
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
            this.BackBtn.Location = new System.Drawing.Point(1, 438);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // PkgCreationInfo
            // 
            this.PkgCreationInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PkgCreationInfo.Font = new System.Drawing.Font("Gadugi", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PkgCreationInfo.ForeColor = System.Drawing.SystemColors.Control;
            this.PkgCreationInfo.Location = new System.Drawing.Point(1, 75);
            this.PkgCreationInfo.Name = "PkgCreationInfo";
            this.PkgCreationInfo.Size = new System.Drawing.Size(318, 66);
            this.PkgCreationInfo.TabIndex = 33;
            this.PkgCreationInfo.Text = "All I Can Say Is Search For \"FakePkgTools For PS4\" On Google,\r\nI Can\'t Provide So" +
    "ny\'s Copyrighted SDK Tools.\r\nThey\'re Very Easy To Find, Thankfully.\r\n\r\n";
            this.PkgCreationInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.PkgCreationInfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.PkgCreationInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Gadugi", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(1, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 22);
            this.label1.TabIndex = 44;
            this.label1.Text = "Common Error Causes:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label4.Location = new System.Drawing.Point(2, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(316, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "______________________________________________________________";
            // 
            // PkgCreationHelpPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 478);
            this.Controls.Add(this.MainBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PkgCreationHelpPage";
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

        void BackBtn_Click(object sender, EventArgs e) => BackFunc();

        public Button MinimizeBtn;
        public Label MainLabel;
        public GroupBox MainBox;
        public Button BackBtn;
        public Button ExitBtn;
        public Label PkgCreationInfo;
        public Label ObtainingFilesLabel;
        public Label Info;
        public Label label5;
        public Label SeperatorLabel3;
        public Label PkgCreationInfoLabel1;
        public Label TroubleshootingLabel;
        public Label UsingGenGP4;
        public Label label2;
        public Label label3;
        public Label label1;
        public Label label4;
        public Label SeperatorLabel2;
    }
}
