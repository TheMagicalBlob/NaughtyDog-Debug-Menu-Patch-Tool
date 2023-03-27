using System.Windows.Forms;
using System;
using System.Drawing;
using static Dobby.Common;

namespace Dobby
{
    public partial class Dobby
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        /// <summary>
        /// Required method for Designer support - dO nOt MoDiFy
        /// the contents of method with the code editor.
        /// </summary>
        ///
        public void InitializeComponent() {
            this.MainLabel = new System.Windows.Forms.Label();
            this.PopupBox = new System.Windows.Forms.GroupBox();
            this.DebugLabel = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.PS4DebugPageBtn = new System.Windows.Forms.Button();
            this.EbootPatchPageBtn = new System.Windows.Forms.Button();
            this.MiscPatchesBtn = new System.Windows.Forms.Button();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BorderBox = new System.Windows.Forms.GroupBox();
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
            this.MainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MainLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // PopupBox
            // 
            this.PopupBox.Location = new System.Drawing.Point(0, 0);
            this.PopupBox.Name = "PopupBox";
            this.PopupBox.Size = new System.Drawing.Size(200, 100);
            this.PopupBox.TabIndex = 0;
            this.PopupBox.TabStop = false;
            // 
            // DebugLabel
            // 
            this.DebugLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DebugLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 7F, System.Drawing.FontStyle.Bold);
            this.DebugLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.DebugLabel.Location = new System.Drawing.Point(207, 7);
            this.DebugLabel.Name = "DebugLabel";
            this.DebugLabel.Size = new System.Drawing.Size(36, 19);
            this.DebugLabel.TabIndex = 20;
            this.DebugLabel.Text = "(Dev)";
            this.DebugLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.DebugLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.DebugLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
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
            this.MinimizeBtn.Location = new System.Drawing.Point(270, 1);
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
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(9, 201);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=====================================";
            this.Info.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Info.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.Info.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // PS4DebugPageBtn
            // 
            this.PS4DebugPageBtn.BackColor = System.Drawing.Color.DimGray;
            this.PS4DebugPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PS4DebugPageBtn.FlatAppearance.BorderSize = 0;
            this.PS4DebugPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PS4DebugPageBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.PS4DebugPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PS4DebugPageBtn.Location = new System.Drawing.Point(1, 33);
            this.PS4DebugPageBtn.Name = "PS4DebugPageBtn";
            this.PS4DebugPageBtn.Size = new System.Drawing.Size(262, 23);
            this.PS4DebugPageBtn.TabIndex = 20;
            this.PS4DebugPageBtn.Text = "Enable Debug Mode With PS4Debug...";
            this.PS4DebugPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PS4DebugPageBtn.UseVisualStyleBackColor = false;
            this.PS4DebugPageBtn.Click += new System.EventHandler(this.PS4DebugPageBtn_Click);
            this.PS4DebugPageBtn.MouseEnter += new System.EventHandler(this.PS4DebugPageBtnMH);
            this.PS4DebugPageBtn.MouseLeave += new System.EventHandler(this.PS4DebugPageBtnML);
            // 
            // EbootPatchPageBtn
            // 
            this.EbootPatchPageBtn.BackColor = System.Drawing.Color.DimGray;
            this.EbootPatchPageBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.EbootPatchPageBtn.FlatAppearance.BorderSize = 0;
            this.EbootPatchPageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EbootPatchPageBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.EbootPatchPageBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.EbootPatchPageBtn.Location = new System.Drawing.Point(1, 62);
            this.EbootPatchPageBtn.Name = "EbootPatchPageBtn";
            this.EbootPatchPageBtn.Size = new System.Drawing.Size(312, 23);
            this.EbootPatchPageBtn.TabIndex = 25;
            this.EbootPatchPageBtn.Text = "Patch An Executable To Enable Debug Mode...";
            this.EbootPatchPageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EbootPatchPageBtn.UseVisualStyleBackColor = false;
            this.EbootPatchPageBtn.Click += new System.EventHandler(this.EbootPatchPageBtn_Click);
            this.EbootPatchPageBtn.MouseEnter += new System.EventHandler(this.EbootPatchPageBtnMH);
            this.EbootPatchPageBtn.MouseLeave += new System.EventHandler(this.EbootPatchPageBtnML);
            // 
            // MiscPatchesBtn
            // 
            this.MiscPatchesBtn.BackColor = System.Drawing.Color.DimGray;
            this.MiscPatchesBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MiscPatchesBtn.FlatAppearance.BorderSize = 0;
            this.MiscPatchesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MiscPatchesBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.MiscPatchesBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MiscPatchesBtn.Location = new System.Drawing.Point(1, 113);
            this.MiscPatchesBtn.Name = "MiscPatchesBtn";
            this.MiscPatchesBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MiscPatchesBtn.Size = new System.Drawing.Size(202, 23);
            this.MiscPatchesBtn.TabIndex = 27;
            this.MiscPatchesBtn.Text = "Misc. Debug Menu Patches...";
            this.MiscPatchesBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MiscPatchesBtn.UseVisualStyleBackColor = false;
            this.MiscPatchesBtn.Click += new System.EventHandler(this.MiscPatchesBtn_Click);
            this.MiscPatchesBtn.MouseEnter += new System.EventHandler(this.MiscPatchesBtnMH);
            this.MiscPatchesBtn.MouseLeave += new System.EventHandler(this.MiscPatchesBtnML);
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.DimGray;
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 174);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(75, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            this.CreditsBtn.MouseEnter += new System.EventHandler(this.CreditsBtnMH);
            this.CreditsBtn.MouseLeave += new System.EventHandler(this.CreditsBtnML);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 148);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InfoHelpBtn.Size = new System.Drawing.Size(147, 23);
            this.InfoHelpBtn.TabIndex = 29;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            this.InfoHelpBtn.MouseEnter += new System.EventHandler(this.InfoHelpBtnMH);
            this.InfoHelpBtn.MouseLeave += new System.EventHandler(this.InfoHelpBtnML);
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 14);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine1.TabIndex = 31;
            this.SeperatorLine1.Text = "______________________________________________________________";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label5.Location = new System.Drawing.Point(2, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(316, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "______________________________________________________________";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(1, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Build PKG";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // BorderBox
            // 
            this.BorderBox.Location = new System.Drawing.Point(0, -6);
            this.BorderBox.Name = "BorderBox";
            this.BorderBox.Size = new System.Drawing.Size(320, 231);
            this.BorderBox.TabIndex = 34;
            this.BorderBox.TabStop = false;
            // 
            // Dobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 225);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PS4DebugPageBtn);
            this.Controls.Add(this.EbootPatchPageBtn);
            this.Controls.Add(this.MiscPatchesBtn);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.DebugLabel);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BorderBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dobby";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.ResumeLayout(false);

        }
        public void MoveForm(object sender, MouseEventArgs e) => Common.MoveForm(sender, e);
        public void MouseUpFunc(object sender, MouseEventArgs e) => Common.MouseUpFunc(sender, e);
        public void MouseDownFunc(object sender, MouseEventArgs e) => Common.MouseDownFunc(sender, e);

        void InfoHelpBtn_Click(object sender, EventArgs e) {
            ChangeForm(5, false); //!
            
            /*
            if (ActiveForm.Name == "Dobby")
                MainForm = ActiveForm;
            LastForm = ActiveForm;
            LastPos = LastForm.Location;
            InfoHelpPage NewPage = new InfoHelpPage();
            NewPage.Show();
            LastForm.Hide();
            */
        }
        public void InfoHelpBtnMH(object sender, EventArgs e) => HoverString(InfoHelpBtn, "Additional Information On Verious Pages");
        public void InfoHelpBtnML(object sender, EventArgs e) => HoverLeave(InfoHelpBtn, 1);
        public void CreditsBtn_Click(object sender, EventArgs e) {
            ChangeForm(8, false);
            
            /*
            if (MainForm == null && ActiveForm.Name == "Dobby")
                MainForm = ActiveForm;
            LastForm = ActiveForm;
            LastPos = LastForm.Location;
            CreditsPage NewPage = new CreditsPage();
            NewPage.Show();
            LastForm.Hide();
            if (!Dev.REL) PageInfo(ActiveForm.Controls);
            */
        }
        public void CreditsBtnMH(object sender, EventArgs e) => HoverString(CreditsBtn, "View Credits For The Tool And Included Patches");
        public void CreditsBtnML(object sender, EventArgs e) => HoverLeave(CreditsBtn, 1);
        public void ExitBtn_Click(object sender, EventArgs e) => Environment.Exit(0);
        public void ExitBtnMH(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void ExitBtnML(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 255, 255);

        public void MinimizeBtn_Click(object sender, EventArgs e) => ActiveForm.WindowState = FormWindowState.Minimized;
        public void MinimizeBtnMH(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void MinimizeBtnML(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 255, 255);

        #endregion
        public static System.Windows.Forms.Button CustomOptDebugBtn;
        public static System.Windows.Forms.Button BackBtn;
        public static System.Windows.Forms.Button BaseDebugBtn;
        public static System.Windows.Forms.Button ExtraDebugBtn;
        public static System.Windows.Forms.Button TLL100Btn;
        public static System.Windows.Forms.Button TLL109Btn;
        public static System.Windows.Forms.Button T1R100Btn;
        public static System.Windows.Forms.Button T2100Btn;
        public static System.Windows.Forms.Button T1R111Btn;
        public static System.Windows.Forms.Button T2109Btn;
        public static System.Windows.Forms.Button UC4133Btn;
        public static System.Windows.Forms.Button UC4100Btn;
        public static System.Windows.Forms.Button UC1Btn;
        public static System.Windows.Forms.Button UC2Btn;
        public static System.Windows.Forms.Button UC3Btn;
        public static System.Windows.Forms.Button ExtraBtn;
        public static System.Windows.Forms.Button ConfirmBtn;
        public static System.Windows.Forms.Label label1;
        public static Label label2;
        public static Button Debug_X_Btn;
        public static Button ManualConnectBtn;
        public static TextBox IPBOX_E;
        public static Button DebugPayloadBtn;
        public static TextBox PortBox;
        public static Button IPLabelBtn;
        public static Button PortLabelBtn;
        public static Label label3;
        public static Button DisableDebugModeBtn;
        public static Button EPPBackBtn;
        public static Label label4;
        public static Button CustomDebugBtn;
        public static Button RestoredDebugBtn;
        public static Button PS4DebugHelpBtn;
        public Label MainLabel;
        public GroupBox PopupBox;
        public Button PS4DebugPageBtn;
        public Button EbootPatchPageBtn;
        public Button MiscPatchesBtn;
        public Button CreditsBtn;
        public Button InfoHelpBtn;
        public Label DebugLabel;
        public Label Info;
        public Button ExitBtn;
        public Button MinimizeBtn;
        public Label SeperatorLine1;
        public Label label5;
        public Button button1;
        private GroupBox BorderBox;
    }
}

