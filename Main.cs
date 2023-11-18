using System;
using libdebug;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using static Dobby.Common;

namespace Dobby { //!      <<<<< Marker For "Remove/Check Me Before Release"
    public partial class Dobby : Form {
        public Dobby() {
#if DEBUG
            if (Pages[1] == null) {
                try {
                    Console.WindowWidth = 75; Console.BufferWidth = 75;
                }
                catch (Exception) { } // These Caused A Crash I Couldn't Recreate, So I Got Lazy Put Them In A Try/Catch
                Dev.StartDebugOutputThread();
                Dev.StartInputReadThread();
            }
#endif
            InitializeComponent();
            YellowInformationLabel = Info;
            Info.Text = "";
            Page = 0;
            AddControlEventHandlers(Controls);

#if !DEBUG
            PS4QOLPageBtn.Enabled = false;
#endif
        }

        public void InitializeComponent() {
            this.MainLabel = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.PS4DebugPageBtn = new System.Windows.Forms.Button();
            this.EbootPatchPageBtn = new System.Windows.Forms.Button();
            this.PS4QOLPageBtn = new System.Windows.Forms.Button();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.BorderBox = new System.Windows.Forms.GroupBox();
            this.DownloadSourceBtn = new System.Windows.Forms.Button();
            this.PCLabel = new System.Windows.Forms.Label();
            this.Playstation4Label = new System.Windows.Forms.Label();
            this.PkgPageBtn = new System.Windows.Forms.Button();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.PCDebugMenuPageBtn = new System.Windows.Forms.Button();
            this.BorderBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.25F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(2, 4);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(314, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Naughty Dog Debug Tool";
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.DimGray;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ExitBtn.Location = new System.Drawing.Point(293, 1);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(23, 23);
            this.ExitBtn.TabIndex = 18;
            this.ExitBtn.Text = "X";
            this.ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitBtn.UseVisualStyleBackColor = false;
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.BackColor = System.Drawing.Color.DimGray;
            this.MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MinimizeBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimizeBtn.Location = new System.Drawing.Point(270, 1);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new System.Drawing.Size(23, 23);
            this.MinimizeBtn.TabIndex = 19;
            this.MinimizeBtn.Text = "--";
            this.MinimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MinimizeBtn.UseVisualStyleBackColor = false;
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(7, 282);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=====================================";
            // 
            // PS4DebugPageBtn
            // 
            this.PS4DebugPageBtn.BackColor = System.Drawing.Color.DimGray;
            this.PS4DebugPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PS4DebugPageBtn.FlatAppearance.BorderSize = 0;
            this.PS4DebugPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PS4DebugPageBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.PS4DebugPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PS4DebugPageBtn.Location = new System.Drawing.Point(1, 51);
            this.PS4DebugPageBtn.Name = "PS4DebugPageBtn";
            this.PS4DebugPageBtn.Size = new System.Drawing.Size(262, 23);
            this.PS4DebugPageBtn.TabIndex = 20;
            this.PS4DebugPageBtn.Text = "Enable Debug Mode With PS4Debug...";
            this.PS4DebugPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PS4DebugPageBtn.UseVisualStyleBackColor = false;
            this.PS4DebugPageBtn.Click += new System.EventHandler(this.PS4DebugPageBtn_Click);
            // 
            // EbootPatchPageBtn
            // 
            this.EbootPatchPageBtn.BackColor = System.Drawing.Color.DimGray;
            this.EbootPatchPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.EbootPatchPageBtn.FlatAppearance.BorderSize = 0;
            this.EbootPatchPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EbootPatchPageBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.EbootPatchPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.EbootPatchPageBtn.Location = new System.Drawing.Point(1, 76);
            this.EbootPatchPageBtn.Name = "EbootPatchPageBtn";
            this.EbootPatchPageBtn.Size = new System.Drawing.Size(275, 23);
            this.EbootPatchPageBtn.TabIndex = 25;
            this.EbootPatchPageBtn.Text = "Patch eboot.bin With The Debug Menu...";
            this.EbootPatchPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EbootPatchPageBtn.UseVisualStyleBackColor = false;
            this.EbootPatchPageBtn.Click += new System.EventHandler(this.EbootPatchPageBtn_Click);
            // 
            // PS4QOLPageBtn
            // 
            this.PS4QOLPageBtn.BackColor = System.Drawing.Color.DimGray;
            this.PS4QOLPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PS4QOLPageBtn.FlatAppearance.BorderSize = 0;
            this.PS4QOLPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PS4QOLPageBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.PS4QOLPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PS4QOLPageBtn.Location = new System.Drawing.Point(1, 102);
            this.PS4QOLPageBtn.Name = "PS4QOLPageBtn";
            this.PS4QOLPageBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PS4QOLPageBtn.Size = new System.Drawing.Size(202, 23);
            this.PS4QOLPageBtn.TabIndex = 27;
            this.PS4QOLPageBtn.Text = "Misc. Debug Menu Patches...";
            this.PS4QOLPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PS4QOLPageBtn.UseVisualStyleBackColor = false;
            this.PS4QOLPageBtn.Click += new System.EventHandler(this.MiscPatchesBtn_Click);
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.DimGray;
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 240);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(75, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 216);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InfoHelpBtn.Size = new System.Drawing.Size(147, 23);
            this.InfoHelpBtn.TabIndex = 29;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 14);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine0.TabIndex = 31;
            this.SeperatorLine0.Text = "______________________________________________________________";
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(3, 192);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine3.TabIndex = 32;
            this.SeperatorLine3.Text = "______________________________________________________________";
            // 
            // BorderBox
            // 
            this.BorderBox.Controls.Add(this.DownloadSourceBtn);
            this.BorderBox.Controls.Add(this.PCLabel);
            this.BorderBox.Controls.Add(this.Playstation4Label);
            this.BorderBox.Controls.Add(this.InfoHelpBtn);
            this.BorderBox.Controls.Add(this.CreditsBtn);
            this.BorderBox.Location = new System.Drawing.Point(0, -6);
            this.BorderBox.Name = "BorderBox";
            this.BorderBox.Size = new System.Drawing.Size(320, 310);
            this.BorderBox.TabIndex = 34;
            this.BorderBox.TabStop = false;
            // 
            // DownloadSourceBtn
            // 
            this.DownloadSourceBtn.BackColor = System.Drawing.Color.DimGray;
            this.DownloadSourceBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DownloadSourceBtn.FlatAppearance.BorderSize = 0;
            this.DownloadSourceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadSourceBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold);
            this.DownloadSourceBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DownloadSourceBtn.Location = new System.Drawing.Point(1, 264);
            this.DownloadSourceBtn.Name = "DownloadSourceBtn";
            this.DownloadSourceBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DownloadSourceBtn.Size = new System.Drawing.Size(292, 23);
            this.DownloadSourceBtn.TabIndex = 30;
            this.DownloadSourceBtn.Text = "Download Latest Source Code (Download Link)";
            this.DownloadSourceBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DownloadSourceBtn.UseVisualStyleBackColor = false;
            this.DownloadSourceBtn.Click += new System.EventHandler(this.DownloadSourceBtn_Click);
            // 
            // PCLabel
            // 
            this.PCLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F, System.Drawing.FontStyle.Bold);
            this.PCLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PCLabel.Location = new System.Drawing.Point(146, 166);
            this.PCLabel.Name = "PCLabel";
            this.PCLabel.Size = new System.Drawing.Size(24, 19);
            this.PCLabel.TabIndex = 37;
            this.PCLabel.Text = "PC";
            // 
            // Playstation4Label
            // 
            this.Playstation4Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Playstation4Label.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F, System.Drawing.FontStyle.Bold);
            this.Playstation4Label.ForeColor = System.Drawing.SystemColors.Control;
            this.Playstation4Label.Location = new System.Drawing.Point(116, 38);
            this.Playstation4Label.Name = "Playstation4Label";
            this.Playstation4Label.Size = new System.Drawing.Size(86, 19);
            this.Playstation4Label.TabIndex = 36;
            this.Playstation4Label.Text = "Playstation 4";
            // 
            // PkgPageBtn
            // 
            this.PkgPageBtn.BackColor = System.Drawing.Color.DimGray;
            this.PkgPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PkgPageBtn.FlatAppearance.BorderSize = 0;
            this.PkgPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PkgPageBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.PkgPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PkgPageBtn.Location = new System.Drawing.Point(1, 128);
            this.PkgPageBtn.Name = "PkgPageBtn";
            this.PkgPageBtn.Size = new System.Drawing.Size(260, 23);
            this.PkgPageBtn.TabIndex = 35;
            this.PkgPageBtn.Text = "Build New Patch Or Base Game .pkg...";
            this.PkgPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PkgPageBtn.UseVisualStyleBackColor = false;
            this.PkgPageBtn.Click += new System.EventHandler(this.PkgPageBtn_Click);
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 142);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine1.TabIndex = 36;
            this.SeperatorLine1.Text = "______________________________________________________________";
            // 
            // PCDebugMenuPageBtn
            // 
            this.PCDebugMenuPageBtn.BackColor = System.Drawing.Color.DimGray;
            this.PCDebugMenuPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PCDebugMenuPageBtn.FlatAppearance.BorderSize = 0;
            this.PCDebugMenuPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PCDebugMenuPageBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.PCDebugMenuPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PCDebugMenuPageBtn.Location = new System.Drawing.Point(1, 178);
            this.PCDebugMenuPageBtn.Name = "PCDebugMenuPageBtn";
            this.PCDebugMenuPageBtn.Size = new System.Drawing.Size(240, 23);
            this.PCDebugMenuPageBtn.TabIndex = 37;
            this.PCDebugMenuPageBtn.Text = "Patch .exe With The Debug Menu...";
            this.PCDebugMenuPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PCDebugMenuPageBtn.UseVisualStyleBackColor = false;
            this.PCDebugMenuPageBtn.Click += new System.EventHandler(this.PCDebugMenuPageBtn_Click);
            // 
            // Dobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 303);
            this.Controls.Add(this.PCDebugMenuPageBtn);
            this.Controls.Add(this.PkgPageBtn);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.PS4DebugPageBtn);
            this.Controls.Add(this.EbootPatchPageBtn);
            this.Controls.Add(this.PS4QOLPageBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine0);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.BorderBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dobby";
            this.BorderBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #region Page Functions
        /////////////////\\\\\\\\\\\\\\\\\
        ///--     Page Functions     --\\\
        /////////////////\\\\\\\\\\\\\\\\\
        private void PS4DebugPageBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.PS4DebugPage);
        private void EbootPatchPageBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.EbootPatchPage);
        private void MiscPatchesBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.PS4MiscPage);
        private void PkgPageBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.PkgCreationPage);
        private void PCDebugMenuPageBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.PCDebugMenuPage);
        #endregion

        #region Repeated Page Functions
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        ///--     Repeated Page Functions     --\\\
        //////////////////////\\\\\\\\\\\\\\\\\\\\\
        private void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.InfoHelpPage);
        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.CreditsPage);
        private void DownloadSourceBtn_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(@"https://github.com/TheMagicalBlob/NaughtyDog-Debug-Menu-Patch-Tool/archive/refs/heads/master.zip");
        #endregion

        #region Control Declarations
        ////////////////////\\\\\\\\\\\\\\\\\\\\
        ///--     Control Declarations     --\\\
        ////////////////////\\\\\\\\\\\\\\\\\\\\
        public Label MainLabel;
        public Button PS4DebugPageBtn;
        public Button EbootPatchPageBtn;
        public Button PS4QOLPageBtn;
        public Button CreditsBtn;
        public Button InfoHelpBtn;
        public Label Info;
        public Button ExitBtn;
        public Button MinimizeBtn;
        public Label SeperatorLine0;
        public Label SeperatorLine3;
        private GroupBox BorderBox;
        public Button DownloadSourceBtn;
        public Button PkgPageBtn;
        public Label PCLabel;
        public Label Playstation4Label;
        public Label SeperatorLine1;
        public Button PCDebugMenuPageBtn;
        #endregion
    }
}