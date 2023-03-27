using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using static Dobby.Common;
using Dobby.Properties;
using System.Net;

namespace Dobby {
    public class EbootPatchPage : Form {

        public EbootPatchPage() {
            InitializeComponent();
        }

        FileStream MainStream;

        public bool[] CDO = new bool[11]; // Custom Debug Options - 11th is For Eventually Keeping Track Of Whether The Options Were Left Default (true if changed)

        const byte    // Simple Readability Addition
            on = 0x01,
            off = 0x00
        ;

        public readonly byte[]
            T2Debug = new byte[] { 0xb2, 0x00, 0xb0, 0x01 }, // Turns "Disable Debug Rendering" Off (b2 00) & Debug Mode On (b0 01)
            T2DebugOff = new byte[] { 0xb2, 0x01, 0x31, 0xc0 }
        ;

        byte[]
            chk    = new byte[4],
            E9Jump = new byte[] { 0xE9, 0x00, 0x00, 0x00, 0x00 }
        ;

        public int
            MenuScale,
            MenuOpacity = 2
        ;

        public const int // Games. Read 4 bytes at 0x60 as an integer to get it
            T1R100 = 22033680,
            T1R109 = 21444016,
            T1R11X = 21446072,
            T2100 = 46552012,
            T2101 = 46785692,
            T2102 = 46718028,
            T2105 = 46826436,
            T2107 = 46832260,
            T2108 = 48176392,
            T2109 = 48176456,
            UC1100 = 9818208,
            UC1102 = 9568920,
            UC2100 = 14655236,
            UC2102 = 16663728,
            UC3100 = 20277852,
            UC3102 = 23365872,
            UC4100 = 36229424,
            UC413X = 33886256,
            UC4133MP = 35877432,
            TLL100 = 35178432,
            TLL10X = 35227448,
            // End Of Checks, Start Of Debug Offsets
            T1R100Debug = 0x579F
        /* T1R109Debug = ,
         T1R11XDebug = ,
         T2100Debug = ,
         T2101Debug = ,
         T2102Debug = ,
         T2105Debug = ,
         T2107Debug = ,
         T2108Debug = ,
         T2109Debug = ,
         UC1100Debug = ,
         UC1102Debug = ,
         UC2100Debug = ,
         UC2102Debug = ,
         UC3100Debug = 0x168EB7, // 0xEB
         UC3102Debug = ,
         UC4100Debug = ,
         UC413XDebug = ,
         UC4133MPDebug = ,
         TLL100Debug = ,
         TLL10XDebug = */
        ;

        public Label GameInfoLabel;
        private Button BrowseButton;
        private TextBox ExecutablePathBox;
        private Label label1;
        private Button RestoredDebugBtn;
        private Button CustomDebugBtn;
        private Button InfoHelpBtn;
        private Label label4;
        private Button BackBtn;
        private Button DisableDebugBtn;
        private Button CustomOptDebugBtn;
        private Button EnableDebugBtn;
        private Label Info;
        private Button CreditsBtn;
        private Button MinimizeBtn;
        private Button ExitBtn;
        private GroupBox MainBox;
        private Label MainLabel;
        private GroupBox groupBox1;
        private Label label2;

        public void InitializeComponent() {
            this.GameInfoLabel = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ExecutablePathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RestoredDebugBtn = new System.Windows.Forms.Button();
            this.CustomDebugBtn = new System.Windows.Forms.Button();
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.DisableDebugBtn = new System.Windows.Forms.Button();
            this.CustomOptDebugBtn = new System.Windows.Forms.Button();
            this.EnableDebugBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.MainLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // GameInfoLabel
            // 
            this.GameInfoLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.GameInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GameInfoLabel.Location = new System.Drawing.Point(1, 205);
            this.GameInfoLabel.Name = "GameInfoLabel";
            this.GameInfoLabel.Size = new System.Drawing.Size(316, 19);
            this.GameInfoLabel.TabIndex = 32;
            this.GameInfoLabel.Text = "No File Selected";
            this.GameInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.DimGray;
            this.BrowseButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BrowseButton.ForeColor = System.Drawing.SystemColors.Control;
            this.BrowseButton.Location = new System.Drawing.Point(238, 179);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 31;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ExecutablePathBox
            // 
            this.ExecutablePathBox.BackColor = System.Drawing.Color.Gray;
            this.ExecutablePathBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.ExecutablePathBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ExecutablePathBox.Location = new System.Drawing.Point(6, 179);
            this.ExecutablePathBox.Name = "ExecutablePathBox";
            this.ExecutablePathBox.Size = new System.Drawing.Size(233, 23);
            this.ExecutablePathBox.TabIndex = 30;
            this.ExecutablePathBox.Text = " Select A .bin/.elf To Modify";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label1.Location = new System.Drawing.Point(2, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "____________________________________________";
            // 
            // RestoredDebugBtn
            // 
            this.RestoredDebugBtn.BackColor = System.Drawing.Color.DimGray;
            this.RestoredDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.RestoredDebugBtn.FlatAppearance.BorderSize = 0;
            this.RestoredDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestoredDebugBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.RestoredDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.RestoredDebugBtn.Location = new System.Drawing.Point(1, 88);
            this.RestoredDebugBtn.Name = "RestoredDebugBtn";
            this.RestoredDebugBtn.Size = new System.Drawing.Size(215, 23);
            this.RestoredDebugBtn.TabIndex = 23;
            this.RestoredDebugBtn.Text = "Enable Debug Mode - Restored";
            this.RestoredDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RestoredDebugBtn.UseVisualStyleBackColor = false;
            this.RestoredDebugBtn.Click += new System.EventHandler(this.RestoredDebugBtn_Click);
            this.RestoredDebugBtn.MouseEnter += new System.EventHandler(this.RestoredDebugBtnMH);
            this.RestoredDebugBtn.MouseLeave += new System.EventHandler(this.RestoredDebugBtnML);
            // 
            // CustomDebugBtn
            // 
            this.CustomDebugBtn.BackColor = System.Drawing.Color.DimGray;
            this.CustomDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CustomDebugBtn.FlatAppearance.BorderSize = 0;
            this.CustomDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomDebugBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CustomDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CustomDebugBtn.Location = new System.Drawing.Point(1, 117);
            this.CustomDebugBtn.Name = "CustomDebugBtn";
            this.CustomDebugBtn.Size = new System.Drawing.Size(206, 23);
            this.CustomDebugBtn.TabIndex = 22;
            this.CustomDebugBtn.Text = "Enable Debug Mode - Custom";
            this.CustomDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CustomDebugBtn.UseVisualStyleBackColor = false;
            this.CustomDebugBtn.Click += new System.EventHandler(this.CustomDebugBtn_Click);
            this.CustomDebugBtn.MouseEnter += new System.EventHandler(this.CustomDebugBtnMH);
            this.CustomDebugBtn.MouseLeave += new System.EventHandler(this.CustomDebugBtnML);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 237);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(147, 23);
            this.InfoHelpBtn.TabIndex = 15;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            this.InfoHelpBtn.MouseEnter += new System.EventHandler(this.InfoHelpBtnMH);
            this.InfoHelpBtn.MouseLeave += new System.EventHandler(this.InfoHelpBtnML);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label4.Location = new System.Drawing.Point(2, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(316, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "____________________________________________";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 287);
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
            // DisableDebugBtn
            // 
            this.DisableDebugBtn.BackColor = System.Drawing.Color.DimGray;
            this.DisableDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisableDebugBtn.FlatAppearance.BorderSize = 0;
            this.DisableDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisableDebugBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.DisableDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DisableDebugBtn.Location = new System.Drawing.Point(1, 33);
            this.DisableDebugBtn.Name = "DisableDebugBtn";
            this.DisableDebugBtn.Size = new System.Drawing.Size(150, 23);
            this.DisableDebugBtn.TabIndex = 12;
            this.DisableDebugBtn.Text = "Disable Debug Mode";
            this.DisableDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisableDebugBtn.UseVisualStyleBackColor = false;
            this.DisableDebugBtn.Click += new System.EventHandler(this.DisableDebugBtn_Click);
            this.DisableDebugBtn.MouseEnter += new System.EventHandler(this.DisableDebugBtnMH);
            this.DisableDebugBtn.MouseLeave += new System.EventHandler(this.DisableDebugBtnML);
            // 
            // CustomOptDebugBtn
            // 
            this.CustomOptDebugBtn.BackColor = System.Drawing.Color.DimGray;
            this.CustomOptDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CustomOptDebugBtn.FlatAppearance.BorderSize = 0;
            this.CustomOptDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomOptDebugBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CustomOptDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CustomOptDebugBtn.Location = new System.Drawing.Point(1, 145);
            this.CustomOptDebugBtn.Name = "CustomOptDebugBtn";
            this.CustomOptDebugBtn.Size = new System.Drawing.Size(309, 23);
            this.CustomOptDebugBtn.TabIndex = 21;
            this.CustomOptDebugBtn.Text = "Enable Debug Mode - Custom + User Settings";
            this.CustomOptDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CustomOptDebugBtn.UseVisualStyleBackColor = false;
            this.CustomOptDebugBtn.Click += new System.EventHandler(this.CustomOptDebugBtn_Click);
            this.CustomOptDebugBtn.MouseEnter += new System.EventHandler(this.CustomOptDebugBtnMH);
            this.CustomOptDebugBtn.MouseLeave += new System.EventHandler(this.CustomOptDebugBtnML);
            // 
            // EnableDebugBtn
            // 
            this.EnableDebugBtn.BackColor = System.Drawing.Color.DimGray;
            this.EnableDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.EnableDebugBtn.FlatAppearance.BorderSize = 0;
            this.EnableDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnableDebugBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.EnableDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.EnableDebugBtn.Location = new System.Drawing.Point(1, 61);
            this.EnableDebugBtn.Name = "EnableDebugBtn";
            this.EnableDebugBtn.Size = new System.Drawing.Size(205, 23);
            this.EnableDebugBtn.TabIndex = 9;
            this.EnableDebugBtn.Text = "Enable Debug Mode - Default";
            this.EnableDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EnableDebugBtn.UseVisualStyleBackColor = false;
            this.EnableDebugBtn.Click += new System.EventHandler(this.EnableDebugBtn_Click);
            this.EnableDebugBtn.MouseEnter += new System.EventHandler(this.EnableDebugBtnMH);
            this.EnableDebugBtn.MouseLeave += new System.EventHandler(this.EnableDebugBtnML);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(3, 310);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(313, 19);
            this.Info.TabIndex = 7;
            this.Info.Text = "======================================";
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.DimGray;
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 261);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(74, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            this.CreditsBtn.MouseEnter += new System.EventHandler(this.CreditsBtnMH);
            this.CreditsBtn.MouseLeave += new System.EventHandler(this.CreditsBtnML);
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.BackColor = System.Drawing.Color.DimGray;
            this.MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MinimizeBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimizeBtn.Location = new System.Drawing.Point(273, 1);
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
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.DimGray;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ExitBtn.Location = new System.Drawing.Point(295, 1);
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
            // MainBox
            // 
            this.MainBox.Location = new System.Drawing.Point(1, -4);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(318, 32);
            this.MainBox.TabIndex = 5;
            this.MainBox.TabStop = false;
            this.MainBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.MainBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.25F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(2, 5);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(314, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Eboot Patch Page";
            this.MainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MainLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.label2.Location = new System.Drawing.Point(2, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "____________________________________________";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 339);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // EbootPatchPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 332);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.GameInfoLabel);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.ExecutablePathBox);
            this.Controls.Add(this.RestoredDebugBtn);
            this.Controls.Add(this.CustomDebugBtn);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.DisableDebugBtn);
            this.Controls.Add(this.CustomOptDebugBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnableDebugBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EbootPatchPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public void MoveForm(object sender, MouseEventArgs e) => Common.MoveForm(sender, e);
        public void MouseUpFunc(object sender, MouseEventArgs e) => Common.MouseUpFunc(sender, e);
        public void MouseDownFunc(object sender, MouseEventArgs e) => Common.MouseDownFunc(sender, e);
        public void ExitBtn_Click(object sender, EventArgs e) => Environment.Exit(0);
        public void ExitBtnMH(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void ExitBtnML(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 255, 255);
        public int TestInt = 0;
        public void MinimizeBtn_Click(object sender, EventArgs e) {
            if (Dev.REL) ActiveForm.WindowState = FormWindowState.Minimized;
            
            else { // For Tests
                {
                    Dev.DebugOutStr($"Test String: {TestInt}");
                    TestInt++;
                }
                //ActiveForm.WindowState = FormWindowState.Minimized;
            }
        }
        public void MinimizeBtnMH(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 227, 0);
        public void MinimizeBtnML(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 255, 255);

        public void BackBtn_Click(object sender, EventArgs e) {
            LabelShouldFlash = false;

            GoBackAPage();
        }
        public void BackBtnMH(object sender, EventArgs e) => HoverLeave(BackBtn, 0);
        public void BackBtnML(object sender, EventArgs e) => HoverLeave(BackBtn, 1);

        public void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(5, false);
        public void InfoHelpBtnMH(object sender, EventArgs e) => HoverString(InfoHelpBtn, "Get Additional Information On Verious Pages");
        public void InfoHelpBtnML(object sender, EventArgs e) => HoverLeave(InfoHelpBtn, 1);

        public void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(8, false);
        public void CreditsBtnMH(object sender, EventArgs e) => HoverString(CreditsBtn, "View Credits For The Tool And Included Patches");
        public void CreditsBtnML(object sender, EventArgs e) => HoverLeave(CreditsBtn, 1);

        /* End Of Repeated Functions
============================================================================================================================================================================
        // Start Of PS4Debug Page Specific Functions                                                                                                                      */

        public void WriteBytes(int offset, byte[] data) {
            MainStream.Position = offset;
            MainStream.Write(data, 0, data.Length);
        }
        public void WriteBytes(int[] offset, byte[] data) {
            foreach (int ofs in offset) {
                MainStream.Position = ofs;
                MainStream.Write(data, 0, data.Length);
            }
        }
        public void WriteBytes(int[] offset, byte[][] data) {
            int i = 0;
            foreach (byte[] bytes in data) {
                MainStream.Position = offset[i];
                MainStream.Write(bytes, 0, data.Length);
                i++;
            }
        }
        public void WriteByte(int offset, byte data) {
            MainStream.Position = offset;
            MainStream.WriteByte(data);
        }
        public void WriteByte(int[] offset, byte data) {
            foreach (int ofs in offset) {
                MainStream.Position = ofs;
                MainStream.WriteByte(data);
            }
        }
        string UpdateGameInfoLabel(int game) { //!        
            string NewString = string.Empty;

            var IsDebugChk = new bool[7];
            var GameString = "Unknown Game";
            var AddString = "No Debug";

            MainStream.Position = 0;
            MainStream.Read(chk, 0, 4);
            if (BitConverter.ToInt32(chk, 0) != 1179403647) {// Make Sure The File's Actually Even A .elf
                GameString = "Executable Still Encrypted";
                AddString = "Must Be Decrypted/Unsigned";
                return $"{GameString} | {AddString}";
            }

            bool CheckDebugState(int[] offsets, byte[] Data) {
                int i = 0; // Just Returns True If The Bytes Read At The Specified Address Match The Byte Given
                foreach (int addr in offsets) {
                    MainStream.Position = addr; Read:
                    if ((byte)MainStream.ReadByte() == Data[i])
                        return true;

                    if (Data[i] == 0x75) {
                        Data[i] = 0xEB;
                        goto Read;
                    }

                    i++;
                }
                return false;
            }

            Common.game = game;
            switch (game) {
                default:
                    MessageBox.Show($"Couldn't Determine The Game This Executable Belongs To, Send It To Blob To Have It's Title ID Supported\n{game}");
                    break;
                case T1R100:
                    CustomDebugBtn.Enabled = true;
                    GameString = "The Last Of Us Remastered 1.00";
                    break;
                case T1R109:
                    CustomDebugBtn.Enabled = true;
                    GameString = "The Last Of Us Remastered 1.09";
                    break;
                case T1R11X:
                    CustomDebugBtn.Enabled = true;
                    MainStream.Position = 0x18;
                    GameString = $"The Last Of Us Remastered 1.1{((byte)MainStream.ReadByte() == 0x10 ? 1 : 0)}";
                    break;
                case T2100:
                    GameString = "The Last Of Us Part II 1.00";
                    break;
                case T2101:
                    GameString = "The Last Of Us Part II 1.01";
                    break;
                case T2102:
                    GameString = "The Last Of Us Part II 1.02";
                    break;
                case T2105:
                    GameString = "The Last Of Us Part II 1.05";
                    break;
                case T2107:
                    GameString = "The Last Of Us Part II 1.07";
                    break;
                case T2108:
                    GameString = "The Last Of Us Part II 1.08";
                    break;
                case T2109:
                    GameString = "The Last Of Us Part II 1.09";
                    break;
                case UC1100:
                    if (CheckDebugState(new int[] { 0x102056, 0x102057, 0x10207B }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 1 1.00";
                    break;
                case UC1102:
                    if (CheckDebugState(new int[] { 0x102186, 0x102187, 0x1021AB }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 1 1.02";
                    break;
                case UC2100:
                    if (CheckDebugState(new int[] { 0x1EB296, 0x1EB297, 0x1EB2BB }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 2 1.00";
                    break;
                case UC2102:
                    if (CheckDebugState(new int[] { 0x3F7A25, 0x3F7A26, 0x3F7A4A }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 2 1.02";
                    break;
                case UC3100:
                    if (CheckDebugState(new int[] { 0x168EB6, 0x168EB7, 0x168EDB }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 3 1.00";
                    break;
                case UC3102:
                    if (CheckDebugState(new int[] { 0x578226, 0x578227, 0x57824B }, new byte[] { 0x01, 0x75, 0x01 }) == true)
                        AddString = "Debug";

                    GameString = "Uncharted 3 1.02";
                    break;
                case UC4100:
                    GameString = "Uncharted 4: A Thief's End 1.00";
                    break;
                case UC413X:
                    GameString = "Uncharted 4: A Thief's End 1.32/1.33";
                    break;
                case UC4133MP:
                    GameString = "Uncharted 4: A Thief's End 1.33 Multiplayer";
                    break;
                case TLL100:
                    GameString = "Uncharted: The Lost Legacy 1.00";
                    break;
                case TLL10X:
                    GameString = "Uncharted: The Lost Legacy 1.08/1.09";
                    break;
            }
            return $"{GameString} | {AddString}";
        }
        private void BrowseButton_Click(object sender, EventArgs e) {
            if (e == null) {
                GameInfoLabel.Text = "Select An Executable To Patch First.";
                Refresh();
            }
            FileDialog f = new OpenFileDialog {
                Filter = "Unsigned/Decrypted Executable|*.bin;*.elf",
                Title = "Select A .elf/.bin Format Executable. The File Must Be Unsigned / Decrypted (The First 4 Bytes Will Be .elf If It Is)"
            };
            if (f.ShowDialog() == DialogResult.OK) {
                ExecutablePathBox.Text = f.FileName;
                MainStream = new FileStream(f.FileName, FileMode.Open, FileAccess.ReadWrite);
                MainStream.Position = 0x60; MainStream.Read(chk, 0, 4);
                GameInfoLabel.Text = UpdateGameInfoLabel(BitConverter.ToInt32(chk, 0));
            }
        }


        void BaseDebugFunction(byte OnOrOff) {
            var Type = OnOrOff == on ? "Enable" : "Disable";
            switch (game) {
                default:
                    MessageBox.Show("Couldn't Determine The Game This Executable Belongs To, Send It To Blob To Have It's Title ID Supported");
                    break;
                case T1R100:
                    T1R100_Patches(Type);
                    Inf(GameInfoLabel.Text.Substring(GameInfoLabel.Text.LastIndexOf("/n")) + "\nDefault Debug Menus Enabled");
                    break;
                case T1R109:
                    T1R11X_Patches(Type);
                    Inf("Patch Applied");
                    break;
                case T1R11X:
                    T1R11X_Patches(Type);
                    Inf("Patch Applied");
                    break;
                case T2100:
                    T2100_Patches(Type);
                    Inf("The Last Of Us Part II 1.00 Debug Enabled");
                    break;
                case T2101:
                    Inf("Sorry, This Old Version Isn't Supported Just Yet");
                    break;
                case T2102:
                    Inf("Sorry, This Old Version Isn't Supported Just Yet");
                    break;
                case T2105:
                    Inf("Sorry, This Old Version Isn't Supported Just Yet");
                    break;
                case T2107:
                    T2107_Patches(Type);
                    Inf("The Last Of Us Part II 1.07 Debug Enabled");
                    break;
                case T2108:
                    T2109_Patches(Type);
                    Inf("The Last Of Us Part II 1.08 Debug Enabled");
                    break;
                case T2109:
                    T2109_Patches(Type);
                    Inf("The Last Of Us Part II 1.09 Debug Enabled");
                    break;
                case UC1100:
                    UC1100_Patches(Type);
                    Inf("Uncharted 1 1.00 Default Debug Enabled");
                    break;
                case UC1102:
                    UC1102_Patches(Type);
                    GameInfoLabel.Text += "Debug Mode Disabled";
                    break;
                case UC2100:
                    UC2100_Patches(Type);
                    Inf("Uncharted 2 1.00 Default Debug Enabled");
                    break;
                case UC2102:
                    UC2102_Patches(Type);
                    break;
                case UC3100:
                    UC3100_Patches(Type);
                    Inf("Uncharted 3 1.00 Default Debug Enabled");
                    break;
                case UC3102:
                    UC3102_Patches(Type);
                    break;
                case UC4100:
                    UC4100_Patches(Type);
                    Inf("Uncharted 4: A Thief's End 1.00 Debug Enabled");
                    break;
                case UC413X:
                    UC4133_Patches(Type);
                    Inf("Uncharted 4: A Thief's End 1.32/1.33 Debug Enabled");
                    break;
                case UC4133MP:
                    UC4MP133_Patches(Type);
                    Inf("Uncharted 4: A Thief's End 1.32/1.33 MP Debug Enabled");
                    break;
                case TLL100:
                    TLL100_Patches(Type);
                    Inf("Uncharted: The Lost Legacy 1.00 Debug Enabled");
                    break;
                case TLL10X:
                    TLL109_Patches(Type);
                    Inf("Uncharted: The Lost Legacy 1.08/1.09 Debug Enabled");
                    break;
            }
        }


        public void EnableDebugBtn_Click(object sender, EventArgs e) {
            if (game == 0) {
                if (!FlashThreadHasStarted) {
                    Dev.FlashThread.Start();
                    FlashThreadHasStarted = true;
                }
                LabelShouldFlash = true;
                Inf("Please Select A Game's Executable First");
                Dobby.InfoHasImportantStr = true;
                return;
            }
            BaseDebugFunction(on);
        }
        public void EnableDebugBtnMH(object sender, EventArgs e) => HoverString(EnableDebugBtn, "Enable Debug Mode As-Is With No Edits");
        public void EnableDebugBtnML(object sender, EventArgs e) => HoverLeave(EnableDebugBtn, 1);


        public void DisableDebugBtn_Click(object sender, EventArgs e) {
            if (game == 0) {
                if (!FlashThreadHasStarted) {
                    Dev.FlashThread.Start();
                    FlashThreadHasStarted = true;
                }
                LabelShouldFlash = true;
                Inf("Please Select A Game's Executable First");
                Dobby.InfoHasImportantStr = true;
                return;
            }
            BaseDebugFunction(off);
        }
        public void DisableDebugBtnMH(object sender, EventArgs e) => HoverString(DisableDebugBtn, "Disable Debug Mode. Doesn't Undo Other Patches");
        public void DisableDebugBtnML(object sender, EventArgs e) => HoverLeave(DisableDebugBtn, 1);

        public void RestoredDebugBtn_Click(object sender, EventArgs e) {
            if (game == 0) {
                if (!FlashThreadHasStarted) {
                    Dev.FlashThread.Start();
                    FlashThreadHasStarted = true;
                }
                LabelShouldFlash = true;
                Inf("Please Select A Game's Executable First");
                Dobby.InfoHasImportantStr = true;
                return;
            }

            switch (game) {
                default:
                    MessageBox.Show("Couldn't Determine The Game This Executable Belongs To, Send It To Blob To Have It's Title ID Supported\n" + game);
                    break;
                case T1R100:
                    Inf("No Restored Menu Available Yet (I'm Workin' on It). Try 1.11");
                    break;
                case T1R109:
                    Inf("No Restored Menu Available, Try 1.10/1.11");
                    break;
                case T1R11X:
                    T1R11X_Patches("Restored");
                    Inf($"The Last Of Us Remastered 1.1X Restored Menu Applied");
                    break;
                case T2100:
                    Inf("The Last Of Us Part II 1.00 Has Nothing To Restore");
                    break;
                case T2101:
                    Inf("The Last Of Us Part II 1.01 Has Nothing To Restore");
                    break;
                case T2102:
                    Inf("The Last Of Us Part II 1.02 Has Nothing To Restore");
                    break;
                case T2105:
                    Inf("The Last Of Us Part II 1.05 Has Nothing To Restore");
                    break;
                case T2107:
                    Inf("The Last Of Us Part II 1.07 Has Nothing To Restore");
                    break;
                case T2108:
                    Inf("The Last Of Us Part II 1.08 Has Nothing To Restore");
                    break;
                case T2109:
                    Inf("The Last Of Us Part II 1.09 Has Nothing To Restore");
                    break;
                case UC1100: // Uncharted 1 1.00 Restored Debug Ver. 2.6.1
                    UC1100_Patches("Restored");
                    Inf("Restored Debug Menu Patch Applied");
                    break;
                case UC1102: // Uncharted 1 1.02 Restored Debug Ver. 2.7
                    UC1102_Patches("Restored");
                    Inf("Restored Debug Menu Patch Applied");
                    break;
                case UC2100: // Uncharted 2 1.00 Restored Debug Ver. 1.0 (Diff 1.11) //!
                    UC2100_Patches("Restored");
                    Inf("Restored Debug Menu Patch Applied");
                    break;
                case UC2102: // Uncharted 2 1.02 Restored Debug Ver. 1.0
                    UC2102_Patches("Restored");
                    Inf("Restored Debug Menu Patch Applied");
                    break;
                case UC3100:
                    UC3100_Patches("Restored");
                    Inf("Uncharted 3 1.00 Restored Debug Applied");
                    break;
                case UC3102:
                    Inf("Uncharted 3 1.02 Restored Debug N/A Yet");
                    break;
                case UC4100:
                    Inf("Uncharted 4 1.00 Restoration Not Available (Try 1.33 MP)");
                    break;
                case UC413X:
                    Inf("Uncharted 4 1.3X Restoration Not Available, Try MP");
                    break;
                case UC4133MP:
                    UC4MP133_Patches("Restored");
                    Inf("Restored Multiplayer Debug Menu Patch Applied");
                    break;
                case TLL100:
                    Inf("The Lost Legacy 1.00 Restoration Not Available");
                    break;
                case TLL10X:
                    Inf("The Lost Legacy 1.0X Restoration Not Available");
                    break;
            }
        }

        public void RestoredDebugBtnMH(object sender, EventArgs e) => HoverString(RestoredDebugBtn, "Restores The Menu As Authentically As Possible");
        public void RestoredDebugBtnML(object sender, EventArgs e) => HoverLeave(RestoredDebugBtn, 1);

        public void CustomDebugBtn_Click(object sender, EventArgs e) { // Just Edited Debug Menus, Some Things May Be Replaced
            if (game == 0) {
                if (!FlashThreadHasStarted) {
                    Dev.FlashThread.Start();
                    FlashThreadHasStarted = true;
                }
                LabelShouldFlash = true;
                Inf("Please Select A Game's Executable First");
                Dobby.InfoHasImportantStr = true;
                return;
            }

            switch (game) {
                default:
                    MessageBox.Show("Couldn't Determine The Game This Executable Belongs To, Send It To Blob To Have It's Title ID Supported");
                    break;
                case T1R100:
                    break;
                case T1R109:
                    break;
                case T1R11X:
                    T1R11X_Patches("Restored");
                    Inf("\"Custom\" Menu Applied");
                    break;
                case T2100:
                    Inf("Try 1.09");
                    break;
                case T2101:
                    Inf("Try 1.09");
                    break;
                case T2102:
                    Inf("Try 1.09");
                    break;
                case T2105:
                    Inf("Try 1.09");
                    break;
                case T2107:
                    Inf("Try 1.09");
                    break;
                case T2108:
                    Inf("Try 1.09");
                    break;
                case T2109:
                    T2109_Patches("Custom");
                    Inf("The Last Of Us Part II 1.09 Custom Debug Enabled");
                    break;

                case UC1100: // UC1 1.00
                    break;
                case UC1102:
                    break;
                case UC2100: // UC2 1.00 ?
                    byte[] skip = E9Jump;
                    WriteByte(0x1EB296, 0x01);
                    WriteByte(new int[] { 0x6C9C, 0x436CEE }, 0x1C);
                    WriteBytes(new int[] { 0x6D5E, 0x1C4708, 0x1C4C60, 0x436D71 }, new byte[][] { skip, new byte[] { 0x1C, 0x00, 0x00, 0x00 }, skip, skip });
                    Inf("Uncharted 2 1.00 Restored Debug Applied");
                    break;
                case UC3100:
                    Inf("Sorry, This Version Isn't Supported Just Yet");
                    break;
                case UC4100:
                    Inf("Sorry, Uncharted 4 1.00 Isn't Supported Just Yet");
                    break;
                case UC413X:
                    Inf("Sorry, Uncharted 4 1.3X Isn't Supported Just Yet");
                    break;
                case UC4133MP: // UC4 1.33 MP
                    UC4MP133_Patches("Restored");
                    Inf("Resto- I Mean Custom Menu Applied");
                    break;
                case TLL100:
                    break;
                case TLL10X:
                    break;
            }
        }

        public void CustomDebugBtnMH(object sender, EventArgs e) => HoverString(CustomDebugBtn, "Patches In My Customized Version Of The Debug Menu");
        public void CustomDebugBtnML(object sender, EventArgs e) => HoverLeave(CustomDebugBtn, 1);


        public void CustomOptDebugBtn_Click(object sender, EventArgs e) {
            if (Dev.REL) return;
            if (game == 0) {
                if (!FlashThreadHasStarted) {
                    Dev.FlashThread.Start();
                    FlashThreadHasStarted = true;
                }
                LabelShouldFlash = true;
                Inf("Please Select A Game's Executable First");
                Dobby.InfoHasImportantStr = true;
                return;
            }

            CDO = new bool[10]; CDO[7] = CDO[8] = true; MenuOpacity = 2;

            MessageBox.Show("This Page Is Hardly Even Added, It Only Supports Tlou2 1.08/1.09 At The Moment", "Note:");
            
            switch (game) {
                default:
                    MessageBox.Show("Couldn't Determine The Game This Executable Belongs To, Send It To Blob To Have It's Title ID Supported");
                    break;
                case T1R100:
                    Inf("Sorry, The Last Of Us Remastered 1.00 Isn't Supported Just Yet");
                    break;
                case T1R109:
                    Inf("Sorry, The Last Of Us Remastered 1.09 Isn't Supported Just Yet");
                    break;
                case T1R11X:
                    Inf("Sorry, The Last Of Us Remastered 1.10/1.11 Isn't Supported Just Yet");
                    break;
                case T2100:
                    MessageBox.Show("Please Get The 1.00, 1.07, or 1.09 Version Of The Game For This I'm Not Doing It For 6 Versions, 3 is Enough");
                    Inf("Sorry, The Last Of Us Part II 1.00 Isn't Supported Just Yet");
                    break;
                case T2101:
                    MessageBox.Show("Please Get The 1.00, 1.07, or 1.09 Version Of The Game For This I'm Not Doing It For 6 Versions, 3 is Enough");
                    Inf("Sorry, The Last Of Us Part II 1.01 Isn't Supported");
                    break;
                case T2102:
                    MessageBox.Show("Please Get The 1.00, 1.07, or 1.09 Version Of The Game For This I'm Not Doing It For 6 Versions, 3 is Enough");
                    Inf("Sorry, The Last Of Us Part II 1.02 Isn't Supported");
                    break;
                case T2105:
                    MessageBox.Show("Please Get The 1.00, 1.07, or 1.09 Version Of The Game For This I'm Not Doing It For 6 Versions, 3 is Enough");
                    Inf("Sorry, The Last Of Us Part II 1.05 Isn't Supported");
                    break;
                case T2107:
                    MessageBox.Show("Please Get The 1.00, 1.07, or 1.09 Version Of The Game For This I'm Not Doing It For 6 Versions, 3 is Enough");
                    Inf("Sorry, The Last Of Us Part II 1.07 Isn't Supported Just Yet");
                    break;
                case T2108:
                    MessageBox.Show("Please Get The 1.00, 1.07, or 1.09 Version Of The Game For This I'm Not Doing It For 6 Versions, 3 is Enough");
                    Inf("Sorry, The Last Of Us Part II 1.08 Isn't Supported");
                    break;

                case T2109:
                    T2CustomOptionsDebug NewPage = new T2CustomOptionsDebug();
                    NewPage.ShowDialog();
                    //!
                    Inf("The Last Of Us Part II 1.09 Custom Debug Enabled");
                    break;

                case UC1100: // UC1 1.00
                    Inf("Sorry, Uncharted 1 1.00 Isn't Supported Yet. Use The Restored Debug");
                    break;
                case UC2100:
                    Inf("Sorry, Uncharted 2 1.00 Debug Isn't Supported Yet");
                    break;
                case UC3100:
                    Inf("Sorry, Uncharted 3 1.00 Isn't Supported Just Yet. Use The Restored Debug");
                    break;
                case UC4100:
                    Inf("Sorry, Uncharted 4 1.00 Isn't Supported Just Yet");
                    break;
                case UC413X:
                    Inf("Sorry, Uncharted 4 1.3X Isn't Supported Just Yet");
                    break;
                case TLL100:
                    Inf("Sorry, The Lost Legacy 1.00 Isn't Supported Just Yet");
                    break;
                case TLL10X:
                    Inf("Sorry, The Lost Legacy 1.08\\1.09 Isn't Supported Just Yet");
                    break;
            }
        }
        public void CustomOptDebugBtnMH(object sender, EventArgs e) => HoverString(CustomOptDebugBtn, Dev.REL ? "Temporarily Disabled" : "change me //!");
        public void CustomOptDebugBtnML(object sender, EventArgs e) => HoverLeave(CustomOptDebugBtn, 1);


        /*======================================================================================================================
        |                                               Patch Application Functions
        ======================================================================================================================*/
        void UC1100_Patches(string type) { // String over an int for readability
            switch (type) {      // I Have A Very Good Reason For Using goto here:       I Wanted To. Don't Like It? goto Fuck_Yourself
                case "Enable":
                    goto Default;
                case "Disable":
                    goto Default;
                case "Restored":
                    goto Restored;
                case "Custom":
                    goto Custom;
            }
Default:
            WriteByte(0x102057, type == "Enable" ? (byte)0xEB : (byte)0x74);
            return;
Restored:
            int[] WhiteJumpsOneByte = new int[] {
                0xE20E3,  // BP UCC...
                0xE373A,  // Collision...
                0xE379B,  // Gameplay...
                0xE37FC,  // Game Objects...
                0xE385E,  // Levels...
                0xE395E,  // Npc...
                0xE39BF,  // Nav-Mesh...
                0xE3A58,  // Interactive Background...
                0xE3A65,  // Interactive Background... (Pt.2)
                0xE3A9E,  // Actors...
                0xE3AB0,  // Animation...
                0xE3AC2,  // Water...
                0xE3B23,  // Fx...
                0xE3B84,  // Camera... (Literally Just The String, Unfortunately :/)
                0xE3E18,  // Physics...
                0xE52F2,  // Particles...
                0x39F37C, // Some PlayGo... Options
                0x9FF43,  // CutScenes Menu Nest
                0xD41B4   // CutScenes...
            };
            int[] WhiteJumps = new int[] {
                0x2A7E08, // Quick Menu Character Options
                0xE2125,  // Rendering, BP Rendering, And Rendering PS3
                0xE2EA1,  // Spawn Character...
                0xE35BA,  // Spawn Vehicle...
                0x271F0D, // Player...
                0x272161, // Player... (Pt.2)
                0x1027BD, // Gameplay... (Pt.2)
                0x104B47, // Gameplay... (Pt.3)
                0xE3BBE,  // Clock...
                0xE3E7C,  // Menu...
                0xE4033,  // Audio...
                0xE536E   // Language...
            };
            int[] FunctionNops = new int[] {
                0x4462F6, // Particles Push
                0x447399, // Particles Pop
                0xD3BC9,  // CutScenes Push
                0xD3DCE,  // CutScenes Pop
                0xD4548   // Skip Crashing CutScenes... Function
            };

            WriteByte (0x102050, 0xC3);                                        // Keep Debug Mode Enabled (It Gets Disabled On Boot, It's Actually On By Default).

            WriteBytes(0x2D6AD3, new byte[] { 0xE9, 0x27, 0x00, 0x00, 0x00 }); // Skip Crashing Shader Variables Code
            WriteBytes(0x2D6B26, new byte[] { 0xEB, 0x05 });                   // Skip Some Code That Causes The Material Debug... Menu To Crash When Selected
            WriteBytes(0x2D6C87, new byte[] { 0xE9, 0x76 });                   // Skip Crashing Shader Variables Submenu (Crashes The Game Mid-Boot)
            WriteByte (new int[] { 0x2D6A70, 0x2D6A50 }, 0xEB);                // Fix The Material Debug... Options

            WriteBytes(0x77B2E0, new byte[] { 0x5A, 0x7D, 0x0C, 0x00 });       // Add Valid Build Number. This Enables The "Build: " & "Built: " Debug Text As Well

            WriteBytes(0x354650, new byte[] { 0xB0, 0x01 });                   // Load HYBRID Text
          //WriteByte (0x354681, 0x00);                                        // Change HYBRID To DEBUG

            WriteBytes(0x2C7230, new byte[] { 0xB0, 0x01, 0xC3 });             // Stop "Create New Level Render Settings..." From Crashing The Game When "Default Render Settings..." Is Opened
            WriteBytes(0x2C7220, new byte[] { 0xB0, 0x01, 0xC3 });             // Stop "Load Existing Render Settings..." From Crashing The Game When "Default Render Settings..." Is Opened
            WriteByte (0x2C71A1, 0xEB);                                        // Stop "Save Current Render Settings..." From Crashing When Selected

            foreach (int Address in WhiteJumpsOneByte)
                WriteByte(Address, 0x00);

            foreach (int Address in WhiteJumps)
                WriteBytes(Address, new byte[] { 0x00, 0x00 });

            foreach (int Address in FunctionNops)
                WriteBytes(Address, E9Jump);

            return;

Custom:
            WhiteJumpsOneByte = new int[] {
                0xE20E3,  // BP UCC...
                0xE373A,  // Collision...
                0xE379B,  // Gameplay...
                0xE37FC,  // Game Objects...
                0xE385E,  // Levels...
                0xE395E,  // Npc...
                0xE39BF,  // Nav-Mesh...
                0xE3A58,  // Interactive Background...
                0xE3A65,  // Interactive Background... (Pt.2)
                0xE3A9E,  // Actors...
                0xE3AB0,  // Animation...
                0xE3AC2,  // Water...
                0xE3B23,  // Fx...
                0xE3B84,  // Camera... (Literally Just The String, Unfortunately :/)
                0xE3E18,  // Physics...
                0xE52F2,  // Particles...
                0x39F37C, // Some PlayGo... Options
                0x9FF43,  // CutScenes Menu Nest
                0xD41B4   // CutScenes...
            };
            WhiteJumps = new int[] {
                0x2A7E08, // Quick Menu Character Options
                0xE2125,  // Rendering, BP Rendering, And Rendering PS3
                0xE2EA1,  // Spawn Character...
                0xE35BA,  // Spawn Vehicle...
                0x271F0D, // Player...
                0x272161, // Player... (Pt.2)
                0x1027BD, // Gameplay... (Pt.2)
                0x104B47, // Gameplay... (Pt.3)
                0xE3BBE,  // Clock...
                0xE3E7C,  // Menu...
                0xE4033,  // Audio...
                0xE536E   // Language...
            };
            FunctionNops = new int[] {
                0x4462F6, // Particles Push
                0x447399, // Particles Pop
                0xD3BC9,  // CutScenes Push
                0xD3DCE,  // CutScenes Pop
                0xD4548   // Skip Crashing CutScenes... Function
            };

            WriteByte (0x102050, 0xC3);                                        // Keep Debug Mode Enabled (It Gets Disabled On Boot, It's Actually On By Default).

            WriteBytes(0x2D6AD3, new byte[] { 0xE9, 0x27, 0x00, 0x00, 0x00 }); // Skip Crashing Shader Variables Code
            WriteBytes(0x2D6B26, new byte[] { 0xEB, 0x05 });                   // Skip Some Code That Causes The Material Debug... Menu To Crash When Selected
            WriteBytes(0x2D6C87, new byte[] { 0xE9, 0x76 });                   // Skip Crashing Shader Variables Submenu (Crashes The Game Mid-Boot)
            WriteByte (new int[] { 0x2D6A70, 0x2D6A50 }, 0xEB);                // Fix The Material Debug... Options

            WriteBytes(0x77B2E0, new byte[] { 0x5A, 0x7D, 0x0C, 0x00 });       // Add Valid Build Number. This Enables The "Build: " & "Built: " Debug Text As Well

            WriteBytes(0x354650, new byte[] { 0xB0, 0x01 });                   // Load HYBRID Text
          //WriteByte (0x354681, 0x00);                                        // Change HYBRID To DEBUG

            WriteBytes(0x2C7230, new byte[] { 0xB0, 0x01, 0xC3 });             // Stop "Create New Level Render Settings..." From Crashing The Game When "Default Render Settings..." Is Opened
            WriteBytes(0x2C7220, new byte[] { 0xB0, 0x01, 0xC3 });             // Stop "Load Existing Render Settings..." From Crashing The Game When "Default Render Settings..." Is Opened
            WriteByte (0x2C71A1, 0xEB);                                        // Stop "Save Current Render Settings..." From Crashing When Selected

            foreach (int Address in WhiteJumpsOneByte)
                WriteByte(Address, 0x00);

            foreach (int Address in WhiteJumps)
                WriteBytes(Address, new byte[] { 0x00, 0x00 });

            foreach (int Address in FunctionNops)
                WriteBytes(Address, E9Jump);

            Inf("\"Custom\" Debug Patch Applied");
            return;
        }


        void UC1102_Patches(string type) {
            int[] WhiteJumpsOneByte = new int[] {
                0xE21D3,    // BP UCC...
                0xE382A,    // Collision...
                0xE388B,    // Gameplay...
                0xE38EC,    // Game Objects...
                0xE394E,    // Levels...
                0xE3A4E,    // Npc...
                0xE3AAF,    // Nav-Mesh...
                0xE3B48,    // Interactive Background...
                0xE3B8E,    // Actors...
                0xE3BA0,    // Animation...
                0xE3BB2,    // Water...
                0xE3C13,    // Fx...
                0xE3C74,    // Camera... (Literally Just The String, Unfortunately :/)
                0xE3F08,    // Physics...
                0xE53E2,    // Particles...
                0x9FF63,    // CutScenes Menu Nest
                0xD42A4     // CutScenes...
            };
            int[] WhiteJumps = new int[] {
                0x2A83F8, // Quick Menu Character Options
                0xE2215,  // Rendering, BP Rendering, And Rendering PS3
                0xE2F91,  // Spawn Character...
                0xE36AA,  // Spawn Vehicle...
                0x27247D, // Player...
                0x2726D1, // Player... (Second Chunk)
                0x1028ED, // Gameplay... (Pt.2)
                0x104C77, // Gameplay... (Pt.3)
                0xE3CAE,  // Clock...
                0xE3F6C,  // Menu...
                0xE4123,  // Audio...
                0xE545E,  // Language...
                0x498DC8  // Some PlayGo... Options
            };
            int[] FunctionNops = new int[] {
                0x31B8F7,   // State Objects Push
                0x31BA73,   // State Objects Pop
                0x55F8E7,   // Particles Push
                0xD3CB9,    // CutScenes Push
                0xD3EBE,    // CutScenes Pop
                0xD4638     // Skip Crashing CutScenes Function
            };

            WriteByte(new int[] { 0x102187, 0x31B967 }, 0xEB);                 /* Keep Debug Mode Enabled (It Gets Disabled On Boot, It's Actually On By Default).
                                                                                               Also Puts The State Objects Menu In The Main Dev Menu, Which Is Where It Shows When The
                                                                                               Gameplay Menu Isn't Loaded. It Looks Cooler, Heh.                                    */


            WriteBytes(0x772B80, new byte[] { 0x46, 0x7F, 0x0C, 0x00 });       // Add Valid Build Number. This Enables The "Build: " & "Built: " Debug Text As Well

            WriteBytes(0x44AE30, new byte[] { 0xB0, 0x01 });                   // Load HYBRID Debug Text
          //WriteByte (0x44AE41, 0x00);                                        // Change HYBRID To DEBUG

            WriteBytes(new int[] { 0x30FF09, 0x30FF3C }, new byte[][] { new byte[] { 0xEB, 0x2C }, new byte[] { 0xEB, 0x17 } });
            //                          /\       Skip Some Code In Two Spots In The State Objects Menu To Stop Tasks From Crashing The Game Mid-Load       /\

            WriteBytes(0x2D70C3, new byte[] { 0xE9, 0x27, 0x00, 0x00, 0x00 }); // Skip Crashing Shader Variables Code
            WriteBytes(0x2D7116, new byte[] { 0xEB, 0x05 });                   // Skip Some Code That Causes The Material Debug... Menu To Crash When Selected
            WriteBytes(0x2D7277, new byte[] { 0xE9, 0x76 });                   // Skip Crashing Shader Variables Submenu
            WriteByte (new int[] { 0x2D7060, 0x2D7040 }, 0xEB);                // Fix The Material Debug... Options

            WriteBytes(0x2C7810, new byte[] { 0xB0, 0x01, 0xC3 });             // Stop "Create New Level Render Settings..." From Crashing The Game When "Default Render Settings..." Is Opened
            WriteBytes(0x2C7820, new byte[] { 0xB0, 0x01, 0xC3 });             // Stop "Load Existing Render Settings..." From Crashing The Game When "Default Render Settings..." Is Opened
            WriteByte(0x2C7791, 0xEB);                                         // Stop "Save Current Render Settings..." From Crashing When Selected

            WriteBytes(0x561BB0, new byte[] { 0xE9, 0xB5, 0x00, 0x00, 0x00 }); // Particles Pop

            foreach (int Address in WhiteJumpsOneByte)
                WriteByte(Address, 0x00);

            foreach (int Address in WhiteJumps)
                WriteBytes(Address, new byte[] { 0x00, 0x00 });

            foreach (int Address in FunctionNops)
                WriteBytes(Address, E9Jump);

            Inf("Restored Debug Patch Applied");
        }


        void UC2100_Patches(string type) {
            WriteByte(0x4D7BE7, (byte)(type == "Disable" ? 0x74 : 0xEB));
            switch (type) {
                default: return;
                case "Restored":
                    goto Restored;
            }

Restored:
            int[] WhiteJumpsOneByte = new int[] {
                0x6C9C,   // Actor Viewer... (Quick Menu)
                0x1C46C7, // BP UCC...
                0x1C4CC4, // Net...
                0x1C4D52, // Collision (Havok)...
                0x1C4DD3, // Gameplay... (Root Entry)
                0x1C4E33, // Game Objects...
                0x1C525E, // Npc... & Navigating Character...
                0x1C5339, // Nav-Mesh...
                0x1C53BA, // Profile...
                0x1C5449, // Actors... & Process...
                0x1C547B, // Animation...
                0x1C54AD, // Camera... (String Only :/)
                0x1C76E4, // Particles...
                0x1C7A51, // Scripts...
                0x5262A6, // Some Miscellaneous PLayGo... Options
                0x436CED, // Complete Tasks...
                0x14EE64, // CutScenes... Jump 1
                0x14EE6D, // CutScenes... Jump 2
                0x1B4135, // CutScenes...
            };
            int[] WhiteJumps = new int[] {
                0x1C4708, // Rendering... & BP Rendering... & System...
                0x545C9C, // Rendering... -> Optimization... (Load Rest Of Contents)
                0x37A0DB, // Player Menu (Chunk 1)
                0x37A2EC, // Player Menu (Chunk 2)
                0x23CDBB, // Gameplay... (Chunk 1)
                0x2401F1, // Gameplay... (Chunk 2)
                0x1C4EB5, // Levels...
                0x1C54E6, // Clock...
                0x1C593A, // Menu...
                0x1C5CB2, // Audio...
                0x1C7746, // Language...
            };
            int[] FunctionNops = new int[] {
                0x6CB7,   // Actor Viewer Push
                0x6D5E,   // Actor Viewer Pop
                0x1C4723, // System Push
                0x1C4C60, // System Pop
                0x37A0F6, // Player Menu Chunk 1 Push
                0x37A2A6, // Player Menu Chunk 1 Pop
                0x37A317, // Player Menu Chunk 2 Push
                0x37B699, // Player Menu Chunk 2 Pop
                0x1C4CDC, // Net Menu Push
                0x1C4D38, // Net Menu Pop
                0x2C514C, // Net -> Boosters Push
                0x2C5327, // Net -> Boosters Pop
                0x1C4D6A, // Collision (Havok) Push
                0x1C4DC6, // Collision (Havok) Pop
                0x23CDD6, // Gameplay Push 1
                0x23FF08, // Gameplay Pop  1
                0x24020C, // Gameplay Push 2
                0x2404BD, // Gameplay Pop  2
                0x428D3A, // Gameplay -> State Scripts Push
                0x42980A, // Gameplay -> State Scripts Pop
                0x1C4E4B, // Game Objects Push
                0x1C4EA7, // Game Objects Pop
                0x1C4ED0, // Levels Push
                0x1C5250, // Levels Pop
                0x1C5279, // Npc Push
                0x1C532C, // Npc Pop
                0x1C5351, // Nav-Mesh Push
                0x1C53AD, // Nav-Mesh Pop
                0x1C5461, // Actors & Process Push
                0x1C546E, // Actors & Process Pop
                0x1C5493, // Animation Push
                0x1C54A0, // Animation Pop
                0x1C5955, // Menu Push
                0x1C5CA4, // Menu Pop
                0x1C76FC, // Particles Outer Push
                0x5D3C66, // Particles Inner Push
                0x5D4D09, // Particles Inner Pop
                0x1C7738, // Particles Outer Pop
                0x1C7761, // Language Push
                0x1C7A44, // Language Pop
                0x436D08, // Complete Tasks Outer Push
                0x436D71, // Complete Tasks Outer Pop
                0x437173, // Complete Tasks Inner Push
                0x4371A4, // Complete Tasks Inner Pop
                0x1B41BD, // CutScenes Outer Push
                0x1B41E5, // CutScenes Outer Pop
                0x1CEAA5, // CutScenes Inner Push 1
                0x1CEB0C, // CutScenes Inner Pop  1
                0x1B3B89, // CutScenes Inner Push 2
                0x1B3E7B, // CutScenes Inner Pop  2
            };
            int[] Returns = new int[] {
                0x429840, // State Scripts Func
                0x1C2650, // Selects Objects 
            };

            // Miscellaneous Patches \\
            WriteByte(0x1EB297, 0xEB);  // Skip Debug Disable

            // Mass Apply Duplicate Patches \\
            foreach (int address in WhiteJumps)
                WriteBytes(address, new byte[] { 0x00, 0x00, 0x00, 0x00 });

            foreach (int address in WhiteJumpsOneByte)
                WriteByte(address, 0x00);

            foreach (int address in FunctionNops)
                WriteBytes(address, E9Jump);

            foreach (int address in Returns)
                WriteByte(address, 0xC3);

            Inf("Restored Debug Menu Patch Applied");
        }

        void UC2102_Patches(string type) {
            WriteByte(0x4D7BE7, (byte)(type == "Disable" ? 0x74 : 0xEB));
            switch (type) {
                default: return;
            }
        }

        void UC3100_Patches(string type) {
            WriteByte(0x168EB7, (byte)(type == "Disable" ? 0x74 : 0xEB));

            int[] FunctionNops = new int[] {
                0x151743, // System Push
                0x15183D, // System Pop
                0x151862, // Spawn Character Push
                0x15186F, // Spawn Character Pop
                0x151898, // Spawn Vehicle Push
                0x15191F, // Spawn Vehicle Pop
                0x15199B, // Collision Push
                0x1519F7, // Collision Pop
                0x170126, // Gameplay Push 1
                0x172B13, // Gameplay Pop  1
                0x172DF1, // Gameplay Push 2
                0x1730F7, // Gameplay Pop  2
                0x8699DA, // State Scripts Push
                0x86A612, // State Scripts Pop
                0x151A7C, // Game Objects Push
                0x151AD0, // Game Objects Pop
                0x151AFD, // Levels Push
                0x15205F, // Levels Pop
                0x152088, // Navigating Character Push
                0x15212B, // Navigating Character Pop
                0x152150, // Nav-Mesh Push
                0x1521A4, // Nav-Mesh Pop
                0x152226, // Interactive Background Push
                0x152267, // Interactive Background Pop
                0x15228C, // Actors / Process Push
                0x152299, // Actors / Process Pop
                0x1522BE, // Animation Push
                0x1522CB, // Animation Pop
                0x1522F0, // Water Push
                0x15234C, // Water Pop
                0x152371, // Fx Push
                0x1523CD, // Fx Pop
                0x16454D, // Camera Outer Push
                0x164557, // Camera Outer Pop
                0x12FE70, // Camera Middle Push
                0x12FE8A, // Camera Middle Pop
                0x1301F8, // Camera Inner Push
                0x131DAB, // Camera Inner Pop
                0x152921, // Menu Push
                0x152DDD, // Menu Pop
                0x154951, // Language / Recorder Push
                0x154C5C, // Language / Recorder Pop
              //0x833CE5, // Scripts Push
              //0x833FE6, // Scripts Pop
            };
            int[] WhiteJumpsSmol = new int[] {
                0x1516E7, // BP UCC...
                0x15184A, // Spawn Character...
                0x15187D, // Spawn Vehicle...
                0x151983, // Collision (Havok)...
                0x151A04, // Gameplay...
                0x151A64, // Game Objects...
                0x151E7E, // Load Misc. Levels... Option
                0x15206D, // Navigating Character...
                0x152138, // Nav-Mesh
                0x15220E, // Interactive Background...
                0x152274, // Process...
                0x1522A6, // Animation...
                0x1522D8, // Water...
                0x152359, // Fx...
                0x16452F, // Camera (Outer)
                0x1523DA, // Camera (inner)
                0x152412, // Clock...
                0x152902, // Menu...
            };
            int[] WhiteJumpsLorge = new int[] {
                0x151728, // System...
                0x17010B, // Gameplay Chunk 1
                0x172DD6, // Gameplay Chunk 2
                0x151ADE, // Levels...
                0x152412, // Clock...
                0x152902, // Menu...
                0x152DEB, // Audio...
                0x154936, // Language... / Recorder...
              //0x833CCA, // Scripts...
            };
            int[] Returns = new int[] {
                0x3F89E0, // Skip Schema Spawn Menu Update
                0x3F93D0, // Skip DCSpawn Menu Update
                0x86B170, // Skip IGC Menu Update
            };

            switch (type) {
                default: return;
                case "Restored":
                    goto Restored;
                case "Custom":
                    goto Custom;
            }
Custom: //! tmp
Restored:
            WriteBytes(0x6cff50, new byte[] { 0x80, 0x34, 0x25, 0x6b, 0x95, 0x7f, 0x01, 0x01 }); // Change Debug Rendering Toggle To Novis One Until I Get The Rendering Menu Loaded
            WriteBytes(0x1517A0, new byte[] { 0xe8, 0xeb, 0x4a, 0x3a, 0x00, 0x49, 0x89, 0xc7 }); // Load Mini-Rendering Menu For Now
            WriteBytes(0x15355f, new byte[] { 0xe9, 0x66, 0x13, 0x00, 0x00 });                   // Skip Four Audio... Submenus


            foreach (int addr in FunctionNops)
                WriteBytes(addr, new byte[] { 0xE9, 0x00, 0x00, 0x00, 0x00 });
            foreach (int addr in WhiteJumpsLorge)
                WriteBytes(addr, new byte[] { 0x00, 0x00 });
            foreach (int addr in WhiteJumpsSmol)
                WriteByte(addr, 0x00);
            foreach (int addr in Returns)
                WriteByte(addr, 0xC3);
            return;

//Custom: //!

            foreach (int addr in FunctionNops)
                WriteBytes(addr, new byte[] { 0xE9, 0x00, 0x00, 0x00, 0x00 });
            foreach (int addr in WhiteJumpsSmol)
                WriteBytes(addr, new byte[] { 0x00, 0x00 });
            return;
        }


        void UC3102_Patches(string type) {
            WriteByte(0x578227, (byte)(type == "Disable" ? 0x74 : 0xEB));
        }

        void UC4100_Patches(string type) {
            WriteByte(0x1297ED, (byte)(type == "Disable" ? 0x74 : 0xEB));
        }

        void UC4133_Patches(string type) {
            WriteByte(0x1CCDFD, (byte)(type == "Disable" ? 0x74 : 0xEB));
        }


        void UC4MP133_Patches(string type) {
            WriteByte(0x1CCEB8, (byte)(type == "Disable" ? 0x74 : 0xEB));
            switch (type) {
                default: return;
                case "Restored":
                    goto Restored;
            }

Restored:
            int[] WhiteJumps = new int[] {
                0x2409ED,  // Relaunch...
                0x18725CA, // Switch On/Off Neo Resolution Mode...
                0x18737BF, // Optimization...
                0x18762C6, // Render Pause
                0x18768C7, // Rendering...            (Chunk 1)
                0x187D6E0, // Rendering...            (Chunk 2)
                0x3DA85A,  // IGCs...
                0x1B4ABB8, // Post-Processing...      (Chunk 1)
                0x1B52536, // Post-Processing...      (Chunk 2)
                0x1894772, // Lighting...             (Chunk 1)
                0x189F096, // Lighting...             (Chunk 2)
                0x187F975, // Rendering...            (Chunk 3)
                0x404833,  // Spawn Character...
                0x405065,  // Spawn Vehicle...
                0x407016,  // Collision (Havok)...
                //3D7D50,  // Gameplay Menu           [Chunk 1 | SKIPPED FOR MEMORY REASONS]
                0x3E87C8,  // Gameplay Menu           (Chunk 2)
                0x40727F,  // Game Objects...
                0x4073D0,  // Levels...
                0x4085D9,  // A Misc. Levels... Option
                0x40912D,  // Navigation...
                0x4BD0EF,  // NavMesh...
                0x40927F,  // Interactive Background...
                0x409559,  // Actors... & Process...
                0x40C78A,  // Animation...
                0x241158,  // Camera...
                0x40FF86,  // Menu...
                //15673A5, // Audio...                [Chunk 1 | SKIPPED FOR MEMORY REASONS]
                0x156E3BA, // Audio Output...
                0x156F366, // Audio Output... Chunk 2
                0x1570B25, // Audio... Chunk 2
                0x4130D6,  // Music...
                0x413475,  // Vox...
                0x414DB0,  // Misc. Vox... Options
                0x173236A, // Scripts... (Menu Contents)
                0x41500A,  // Particles...
                0x415272,  // Level BugFix...
                0x24BE58,  // Cinematics              (Chunk 1)
                0x24CB24,  // Cinematics              (Chunk 2)
                0x24E347,  // Designer...
                0x18B01A5, // Load A Few Extra Particle Menu Options
                0x24E854,  // Tasks...                (Extras)
                0x24E92A,  // Play Test Tasks...
                0x24ED5A,  // Complete Test Tasks...
                0x1643865  // Stop SP Tasks From Crashing In Coop/MP
            };
            int[] FunctionNops = new int[] {
                0x18768E9, // Rendering Push 1
                0x187C132, // Rendering Pop  1
                0x187D702, // Rendering Push 2
                0x187F8D0, // Rendering Pop  2
                0x187D84D, // Rendering Menu Double Line Fix
                0x40485B,  // Spawn Character... Push
                0x405057,  // Spawn Character... Pop
                0x40508D,  // Spawn Vehicle Push
                0x405311,  // Spawn Vehicle Pop
                0x7F6659,  // Stop The Game From Booting SP If The X Button Is Pressed On The Menu

                //These Next 8 Are Only Needed For The Gameplay Menu's First Chunk Which I've Not Loaded, So These Are Commented Out
                //3D7D79,  // Gameplay Push
                //3DA63D,  // Gameplay Pop
                //3B0EB2,  // Demo Mode Push 1
                //3B10F3,  // Demo Mode Pop  1
                //3D7D9C,  // StateScripts Push
                //3DA87C,  // IGCs Push
                //3DA9BA,  // IGCs Pop
                //3E806C,  // State Scripts Pop

                0x3E87EA,  // Gameplay Part 2 Push
                0x3E9506,  // Gameplay Part 2 Pop
                0x40703E,  // Collision (Havok)... Push (Outside The Submenu, So Gotta Skip 'EM Still)
                0x40715A,  // Collision (Havok)... Pop
                0x4072A7,  // Game Objects... Push
                0x4073C2,  // Game Objects... Pop
                0x4073F8,  // Levels... Push
                0x408CF3,  // Levels... Pop
                0x241182,  // InitGuiWidgets() Push
                0x2412D3,  // Misc. Pop (Needed?)
                0x2412FE,  // GameInitInternal() Push (Needed?)
                0x241329,  // SpawnCameraMenu() Push
                0x241351,  // Skip Some Pops By The Camera Menu
                0x241356,  // /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
                0x409155,  // Navigation Push
                0x409271,  // Navigation Pop
                0x4BD11D,  // NavMesh Push
                0x4BD14F,  // NavMesh Pop
                0x4092A7,  // Interactive Background... Push
                0x40954B,  // Interactive Background... Pop
                0x409581,  // Actors... & Process... Push
                0x40C77C,  // Actors... & Process... Pop
                0x40C7B2,  // Animation... Push
                0x40FF02,  // Animation... Pop
                0x7E074F,  // Camera... Push
                0x7E73A9,  // Camera... Pop
                0x40FFB5,  // Menu... Push
                0x4115BF,  // Menu... Pop
                //15673D2, // Audio... Chunk 1 Push   [SKIPPED FOR MEMORY REASONS]
                //156E314, // Audio... Chunk 1 Pop    [SKIPPED FOR MEMORY REASONS]
                0x156E3DC, // Audio Output... Push
                0x156EEC6, // Audio Output... Pop
                0x156F388, // Audio Output... Chunk 2 Push
                0x1570A85, // Audio Output... Chunk 2 Pop
                0x1570B47, // Audio... Chunk 2 Push
                0x1570E96, // Audio... Chunk 2 Pop
                0x41310E,  // Music... Push
                0x4133C8,  // Music... Pop
                0x41349D,  // Vox... Push
                0x414F6B,  // Vox... Pop
                0x1733078, // Scripts... Push
                0x173238C, // Scripts... Pop
                0x41529A,  // Level BugFix... Push
                0x415A38,  // Level BugFix... Pop
                0x24BE82,  // Cinematics Push 1
                0x24C5DB,  // Cinematics Pop 1
                0x24CB4E,  // Cinematics Push 2
                0x24E28D,  // Cinematics Pop 2
                0x19CA02F, // Demo Mode Push 2
                0x19CA23A, // Demo Mode Pop  2
                0x1B4ABE1, // Post-Processing Chunk 1 Push
                0x1B5209A, // Post-Processing Chunk 1 Pop
                0x1B52558, // Post-Processing Chunk 2 Push
                0x1B55062, // Post-Processing Chunk 2 Pop
                0x189479B, // Lighting Chunk 1 Push
                0x189B921, // Lighting Chunk 1 Pop
                0x189F0B8, // Lighting Chunk 2 Push
                0x18A06E7, // Lighting Chunk 2 Pop
                0x187F997, // Rendering Chunk 3 Push
                0x188DB53, // Rendering Chunk 3 Pop
                0x415032,  // Particles Push 1
                0x4150BF,  // Particles Pop  1
                0x18AF7DF, // Particles Push 2
                0x18B3691, // Particles Pop  2
                0x24E371,  // Designer Push  1
                0x24E3A8,  // Designer Push  2
                0x24E444,  // Designer Pop   1
                0x24E4DF,  // Designer Pop   2
                0x24E88B,  // Extra Tasks... Options Push
                0x24EE94   // Extra Tasks... Options Pop
            };
            int[] Returns = new int[] {
                0x421960,  // Skip Schema Spawn Menu
                0x423590,  // Skip DC Spawn Menu
                0x9D5430,  // Skip Select Nav-Mesh
                0x39B1E0   // Designer Content Loop

                //These Last 5 Are Only Needed For The Gameplay Menu's First Chunk Which I've Not Loaded, So These Are Commented Out
                //161AC50, // Skip IGCs Menu
                //17176A0, // Skip Select Region By Name Menu
                //72D480,  // Skip Gestures Menu                    
                //16186D0, // Skip Select State Script Menu
                //16186D0  // State Scripts Menu For Memory Reasons
            };

            // Main Patches \\
            WriteByte (new int[] { 0x1CCEB8, 0x24E5C8 }, 0x01);                 // Enables The Debug Mode, Then The UC4 Tasks Menu
            WriteBytes(0xA37DE1, new byte[] { 0xE9, 0x08, 0x00, 0x00, 0x00 });  // Skip PSN Sign-In Check

            // Misc Patches \\
            WriteBytes(0x187B1F4, new byte[] { 0x90, 0x90, 0x90 });             // Skip Crashing Pre-Material Debug Function Call
            WriteBytes(0x187B214, new byte[] { 0xE9, 0x07, 0x00, 0x00, 0x00 }); // Skip Material Debug Code That Breaks Some SP Tasks
            WriteBytes(0x1B5A9C0, new byte[] { 0xE9, 0x0F, 0x00, 0x00, 0x00 }); // Stop Various Material Debug Options From Crashing After The Above Patch
            WriteBytes(0x187B6CE, new byte[] { 0xE9, 0x27, 0x01, 0x00, 0x00 }); // Skip Shader Variables, As It Now Crashes After The Above Patch (It's Empty Anyway, No Big Deal)
            WriteByte (0x1876A1A, 0xC8);                                        // Lower The Amount Of Loops For The Draw Mode Options By 3 To Skip The Ones That Cause Orbis Crashes
            WriteBytes(0x1CB63D0, new byte[] { 0xB0, 0x01, 0xC3 });             // Stop "Choose Lut File..." From Crashing The Game
            WriteBytes(0x15E8AE0, new byte[] { 0xB0, 0x01, 0xC3 });             // Stop "Play Cinematic..." From Crashing The Game
            WriteBytes(0x15E9340, new byte[] { 0xB0, 0x01, 0xC3 });             // Stop "Select Cinematic..." From Crashing The Game
            WriteByte (0x18B7547, 0xEB);                                        // Stop Particles Menu From Fully Initializing And Crashing Game On Boot
            WriteBytes(0x18AF8FD, new byte[] { 0xE9, 0x0A, 0x01, 0x00, 0x00 }); // Skip Two Unfixable "Particles..." Submenus
            WriteBytes(0x18AFC31, new byte[] { 0xE9, 0x28, 0x03, 0x00, 0x00 }); // Skip Three More Unfixable "Particles..." Submenus
            WriteBytes(0x166BF6B, new byte[] { 0xE9, 0x5B, 0x04, 0x00, 0x00 }); // Skip Select Spawner By Name Menu
            WriteBytes(0x18E1900, new byte[] { 0xE9, 0x89, 0xC5, 0x00, 0x00 }); // Skip Most Of "Collision (Havok)..." Starting After "Destruction..."

            // Mass Apply Duplicate Patches \\
            foreach (int Address in WhiteJumps)
                WriteBytes(Address, new byte[] { 0x00, 0x00, 0x00, 0x00 });
            foreach (int Address in FunctionNops)
                WriteBytes(Address, E9Jump);
            foreach (int Address in Returns)
                WriteByte(Address, 0xC3);

        }


        void TLL100_Patches(string type) {
            WriteByte(0x1CCFED, (byte)(type == "Disable" ? off : on));
        }


        void TLL109_Patches(string type) {
            WriteByte(0x1CD02D, (byte)(type == "Disable" ? off : on));
        }


        void T1R100_Patches(string type) {
            WriteByte(T1R100Debug, (byte)(type == "Disable" ? off : on));
            switch (type) {
                default: return;
                case "Restored":
                    goto Restored;
                case "Custom":
                    goto Custom;
            }

Restored:
            WriteBytes(0x6363C,  new byte[] { 0xE8, 0xEF, 0x24, 0x6D, 0x00 }); // Replace Call To Mini-Rendering Menu With One To The Full Rendering Menu
            WriteBytes(0x94DD35, new byte[] { 0xE9, 0x00, 0x00, 0x00, 0x00 }); // Skip A Function In The Material Debug Menu That Causes The Game To Crash While Booting
            WriteBytes(0x38282C, new byte[] { 0x00, 0x00 });                   // Load Net... Contents
            return;

Custom:
            WriteBytes(0x6363C, new byte[] { 0xE8, 0xEF, 0x24, 0x6D, 0x00 }); // Replace Call To Mini-Rendering Menu With One To The Full Rendering Menu
            WriteBytes(0x94DD35, new byte[] { 0xE9, 0x00, 0x00, 0x00, 0x00 }); // Skip A Function In The Material Debug Menu That Causes The Game To Crash While Booting
            WriteBytes(0x38282C, new byte[] { 0x00, 0x00 });                   // Load Net... Contents

            return;
        }


        void T1R11X_Patches(string type) {
            WriteByte(0x61B3, (byte)(type == "Disable" ? off : on));
            switch (type) {
                default: return;
                case "Restored":
                    goto Restored;
            }

Restored:
            var FunctionsToSkip = new int[] {
                0x76E62C, // State Scripts Push
                0x76F0CF, // State Scripts Pop
                0x28102A, // Skip Part Of Gestures Menu Init
                0x7AAC30, // Skip Outer UpdateSelectSpawnerByNameMenu Call
                0x7AB035, // Skip Inner UpdateSelectSpawnerByNameMenu Call
                0x79E60,  // Skip Outer UpdateDCSpawnMenu Call
                0x7ABD5,  // Skip Inner UpdateDCSpawnMenu Call
                0xA40E2B, // Skip Splashers... Content Loop Outer
                0x8492E0, // Skip Splashers... Content Loop Inner
                0xA46208, // Lens Flare Push
                0xA46542, // Lens Flare Pop
                0x75408A, // Camera Shake Push
                0x7541E4  // Camera Shake Pop
            };
            var Returns = new int[] {
                0x76F0F0, // Skip Select State Scripts Menu Population
                0x770D00, // Skip Select IGC... Menu Population
                0x6FAD80, // Skip Spawn Actor... Content Loop
                0x7A050   // Skip Schema Spawn... Content Loop
            };

            foreach (int addr in FunctionsToSkip)
                WriteBytes(addr, new byte[] { 0xE9, 0x00, 0x00, 0x00, 0x00 });
            foreach (int addr in Returns)
                WriteByte(addr, 0xC3);


            // Write The 5 Chunks With The Majority Of Function Calls \\
            WriteBytes(0x1457571, Resources.T1R_11X_Restored_Chunk1);
            WriteBytes(0x1457D2E, Resources.T1R_11X_Restored_Chunk2);
            WriteBytes(0x7AA10, Resources.T1R_11X_Restored_Chunk3);
            WriteBytes(0x8492F0, Resources.T1R_11X_Restored_Chunk4);
            WriteBytes(0x7AAC7D, Resources.T1R_11X_Restored_Chunk5);

            // Root Menu Function Calls \\
            WriteBytes(0x71F6C, new byte[] { 0xE8, 0x4F, 0x6B, 0x84, 0x00 }); // Call Large Rendering Menu Instead Of Tiny One (Yeah, That's All It Takes...)
            WriteBytes(0x8BA76A, new byte[] { 0xe8, 0x41, 0xd9, 0xb9, 0x00 }); // Call Additional Rendering Related Functions Inside Rendering Menu)
            WriteBytes(0x71FA8, new byte[] { 0x49, 0x8b, 0xfe, 0xe8, 0xc0, 0x8c, 0x73, 0x00, 0xeb, 0x0e }); // Call System, Spawn Character, And Custom Player Menu
            WriteBytes(0x72012, new byte[] { 0xe8, 0xd4, 0x8a, 0x00, 0x00, 0xeb, 0x03 }); // Call Custom Collision (Havok) Menu
            WriteBytes(0x72044, new byte[] { 0xe8, 0xa6, 0x5a, 0x3e, 0x01 }); // Call Custom Gameplay Menu
            WriteBytes(0x721A1, new byte[] { 0xe8, 0x77, 0x8d, 0x73, 0x00 }); // Call Npc, Navigating Character, Simple Npc, Nav-Mesh
            WriteBytes(0x722CF, new byte[] { 0x48, 0x8B, 0x5D, 0xB8, 0x48, 0x89, 0xDF, 0xE8, 0x35, 0x87, 0x00, 0x00, 0xEB, 0x1A }); // Call Interactive Background, Actors, Process, Animation, Water, Fx, And Camera
            WriteBytes(0x7290D, new byte[] { 0xe8, 0x12, 0x57, 0x3e, 0x01 }); // Call Custom Menu & Audio Menus

            // Misc Functionality Patches \\
            WriteByte(0x61A4, 0xEB); // Enable Debug Menu
            WriteByte(0xA34FCB, 0x87); // Change Useless Debug Rendering Toggle To A On-Screen Debug Text Toggle (L3 & Triangle)
            WriteBytes(new int[] { 0x56F1A8, 0x56F157 }, new byte[] { 0x90, 0x90 }); // Allow Aim Sensitivity To Go Over 1.00 And Under 0.00
            WriteBytes(0xAF2A85, new byte[] { 0xBF, 0xB0, 0x00, 0x00, 0x00, 0xEB, 0x2A }); // Skip Some Broken Material Debug Stuff
            WriteBytes(0xAF2CD2, new byte[] { 0xEB, 0x79 }); // Skip Broken Shader Variables Menu
            WriteBytes(0xAF255E, new byte[] { 0xEB, 0x29 }); // Force Material Debug Text To Out Of Index To Avoid Crashing (What Did They Change? Wish I Knew Enough To Find Out)
            WriteBytes(0xAF25E6, new byte[] { 0xEB, 0x57 }); // More Of The Above
            WriteBytes(0x405405, new byte[] { 0x89, 0x3d, 0xbd, 0xbe, 0x1d, 0x01, 0x4c, 0x8b, 0x25, 0xb6, 0xbe, 0x1d, 0x01, 0xeb, 0x11, 0x48, 0x8b, 0x3d, 0xad, 0xbe, 0x1d, 0x01, 0xe8, 0x3D, 0x26, 0x05, 0x01, 0xe9, 0x37, 0x0b, 0x00, 0x00 }); // Call Custom Server Menu, Jump Like A Rabbit To Call It Last lol
            WriteBytes(0x405F57, new byte[] { 0xe9, 0xb8, 0xf4, 0xff, 0xff, 0x48, 0x81, 0xc4, 0xc8, 0x00, 0x00, 0x00, 0x5b, 0x41, 0x5c, 0x41, 0x5d, 0x41, 0x5e, 0x41, 0x5f, 0x5d, 0xc3 }); // Another Jump, And Moved Return Instructions To Fit It
            WriteBytes(0x280E42, new byte[] { 0xE9, 0x79, 0x00, 0x00, 0x00 });  // Skip The Broken First Half Of The Gestures Submenu
            WriteBytes(0x280FA5, new byte[] { 0xEB, 0x42 }); // Skip Gestures Menu .cfg Check And A Pop | \/ (That One) Rewrite Jumps Menu To Call The One Option In There Instead Of Letting It Be Empty
            WriteBytes(0x51CE08, new byte[] { 0xe8, 0xf3, 0x4a, 0x51, 0x00, 0x48, 0x8d, 0x15, 0x6c, 0xc3, 0x0d, 0x01, 0x48, 0x8d, 0x35, 0x4a, 0xbc, 0xbd, 0x00, 0x49, 0x8b, 0xff, 0xe8, 0xcd, 0xc4, 0x32, 0x00, 0xbf, 0xa0, 0x00, 0x00, 0x00, 0xe8, 0xe3, 0x81, 0x76, 0x00, 0x48, 0x89, 0xc3, 0x48, 0x8d, 0x35, 0x5d, 0xf4, 0xbc, 0x00, 0x31, 0xc9, 0x45, 0x31, 0xc0, 0x4c, 0x89, 0xfa, 0x48, 0x89, 0xdf, 0xe8, 0x79, 0x3f, 0x51, 0x00, 0x4c, 0x89, 0xf7, 0x48, 0x89, 0xde, 0xe8, 0x6e, 0x4e, 0x51, 0x00, 0x48, 0x83, 0xc4, 0x08, 0x5b, 0x41, 0x5e, 0x41, 0x5f, 0x5d, 0xc3 });
            WriteBytes(0x4060DE, new byte[] { 0xE9, 0xA6, 0x02, 0x00, 0x00 }); // "Fix" Skins Menu
            WriteBytes(0x7371F, new byte[] { 0xed, 0x4e, 0xfd, 0xff }); // Call Bonuses Menu In Quick Menu. Might As Well
            return;
        }


        void T2100_Patches(string type) {
            WriteBytes(0x1D639C, type == "Disable" ? T2DebugOff : T2Debug);
        }


        void T2107_Patches(string type) {
            WriteBytes(0x1D66BC, type == "Disable" ? T2DebugOff : T2Debug);
        }


        void T2109_Patches(string type) { // 1.08 as well, same offsets
            WriteBytes(0x6181FA, type == "Disable" ? T2DebugOff : T2Debug);
            switch (type) {
                default: return;
                case "Custom":
                    goto Custom;
            }

Custom:
            // Enable Debug + Change L3 & Triangle Toggle First \\
            WriteBytes(0x6181F9, T2Debug);
            WriteByte (new int[] { 0x1C45085, 0x1C45092 }, 0xB8);

            int i = 0;
            int[] addrs = new int[] { 0x25AE9DA, 0x25AE990, 0x2DF3B50, 0x25B231B, 0x25B2279, 0x2DF3B67, 0x7A4ECF };
            byte[][] dat = new byte[7][] {
                                new byte[] { 0x5f, 0x16, 0x9c, 0x01 },
                                new byte[] { 0xbc, 0x51, 0x84 },
                                new byte[] { 0x44, 0x69, 0x73, 0x61, 0x62, 0x6C, 0x65, 0x20, 0x41, 0x6C, 0x6C, 0x20, 0x56, 0x69, 0x73, 0x69, 0x62, 0x69, 0x6C, 0x69, 0x74, 0x79 },
                                new byte[] { 0x29, 0xc3, 0xca, 0x00 },
                                new byte[] { 0xea, 0x18, 0x84, 0x00 },
                                new byte[] { 0x41, 0x64, 0x6A, 0x75, 0x73, 0x74, 0x20, 0x44, 0x65, 0x62, 0x75, 0x67, 0x20, 0x4D, 0x65, 0x6E, 0x75, 0x20, 0x53, 0x63, 0x61, 0x6C, 0x65 },
                                new byte[] { 0xcd, 0xcc, 0x4c, 0x3f }
                            };

            foreach (int addr in addrs) {
                MainStream.Position = addr;
                MainStream.Write(dat[i], 0, dat[i].Length);
                i++;
            }
            return;
        }
    }
}
