using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using static Dobby.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.AxHost;
using System.Diagnostics;

namespace Dobby {
    public class EbootPatchPage : Form {

        public EbootPatchPage() {
            InitializeComponent();
            SetPageInfo(this);
            if (!Dev.REL) PageInfo(Controls);
            else CustomOptDebugBtn.Font = new Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout);
        }

        public bool[] CDO = new bool[11]; //Custom Debug Options - 11th is For Eventually Keeping Track Of Whether The Options Were Left Default (true if changed)

        const byte
            on = 0x01,
            off = 0x00
        ;

        public readonly byte[]
            T2Debug = new byte[] { 0xb2, 0x00, 0xb0, 0x01 }, // Turns "Disable Debug Rendering" Off (b2 00) & Debug Mode On (b0 01)
            T2DebugOff = new byte[] { 0xb2, 0x01, 0x31, 0xc0 }
        ;

        byte[] chk = new byte[4];
        
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
            TLL10X = 35227448
        ;

        
        public byte FPSMode;

        public FileStream fs;



        public void InitializeComponent() {
            this.MainLabel = new System.Windows.Forms.Label();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.BaseDebugBtn = new System.Windows.Forms.Button();
            this.CustomOptDebugBtn = new System.Windows.Forms.Button();
            this.DisableDebugModeBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.CustomDebugBtn = new System.Windows.Forms.Button();
            this.RestoredDebugBtn = new System.Windows.Forms.Button();
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
            this.MainLabel.Size = new System.Drawing.Size(314, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Eboot Patch Page";
            this.MainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MainLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // MainBox
            // 
            this.MainBox.Controls.Add(this.ExitBtn);
            this.MainBox.Controls.Add(this.MinimizeBtn);
            this.MainBox.Controls.Add(this.MainLabel);
            this.MainBox.Location = new System.Drawing.Point(1, -4);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(317, 32);
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
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.DimGray;
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(-5, 205);
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
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(4, 254);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(313, 19);
            this.Info.TabIndex = 7;
            this.Info.Text = "======================================";
            // 
            // BaseDebugBtn
            // 
            this.BaseDebugBtn.BackColor = System.Drawing.Color.DimGray;
            this.BaseDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BaseDebugBtn.FlatAppearance.BorderSize = 0;
            this.BaseDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BaseDebugBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BaseDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BaseDebugBtn.Location = new System.Drawing.Point(-6, 61);
            this.BaseDebugBtn.Name = "BaseDebugBtn";
            this.BaseDebugBtn.Size = new System.Drawing.Size(205, 23);
            this.BaseDebugBtn.TabIndex = 9;
            this.BaseDebugBtn.Text = "Enable Debug Mode - Default";
            this.BaseDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BaseDebugBtn.UseVisualStyleBackColor = false;
            this.BaseDebugBtn.Click += new System.EventHandler(this.MakeBaseDebugBtn_Click);
            this.BaseDebugBtn.MouseEnter += new System.EventHandler(this.MakeBaseDebugBtnMH);
            this.BaseDebugBtn.MouseLeave += new System.EventHandler(this.MakeBaseDebugBtnML);
            // 
            // CustomOptDebugBtn
            // 
            this.CustomOptDebugBtn.BackColor = System.Drawing.Color.DimGray;
            this.CustomOptDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CustomOptDebugBtn.FlatAppearance.BorderSize = 0;
            this.CustomOptDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomOptDebugBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CustomOptDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CustomOptDebugBtn.Location = new System.Drawing.Point(-5, 145);
            this.CustomOptDebugBtn.Name = "CustomOptDebugBtn";
            this.CustomOptDebugBtn.Size = new System.Drawing.Size(292, 23);
            this.CustomOptDebugBtn.TabIndex = 21;
            this.CustomOptDebugBtn.Text = "Enable Debug Mode - Custom With Options";
            this.CustomOptDebugBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CustomOptDebugBtn.UseVisualStyleBackColor = false;
            this.CustomOptDebugBtn.Click += new System.EventHandler(this.CustomOptDebugBtn_Click);
            this.CustomOptDebugBtn.MouseEnter += new System.EventHandler(this.CustomOptDebugBtnMH);
            this.CustomOptDebugBtn.MouseLeave += new System.EventHandler(this.CustomOptDebugBtnML);
            // 
            // DisableDebugModeBtn
            // 
            this.DisableDebugModeBtn.BackColor = System.Drawing.Color.DimGray;
            this.DisableDebugModeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DisableDebugModeBtn.FlatAppearance.BorderSize = 0;
            this.DisableDebugModeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DisableDebugModeBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.DisableDebugModeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DisableDebugModeBtn.Location = new System.Drawing.Point(-5, 33);
            this.DisableDebugModeBtn.Name = "DisableDebugModeBtn";
            this.DisableDebugModeBtn.Size = new System.Drawing.Size(150, 23);
            this.DisableDebugModeBtn.TabIndex = 12;
            this.DisableDebugModeBtn.Text = "Disable Debug Mode";
            this.DisableDebugModeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DisableDebugModeBtn.UseVisualStyleBackColor = false;
            this.DisableDebugModeBtn.Click += new System.EventHandler(this.DisableDebugModeBtn_Click);
            this.DisableDebugModeBtn.MouseEnter += new System.EventHandler(this.DisableDebugModeBtnMH);
            this.DisableDebugModeBtn.MouseLeave += new System.EventHandler(this.DisableDebugModeBtnML);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(-4, 231);
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
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(-10, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "________________________________________________________";
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(-5, 181);
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
            // CustomDebugBtn
            // 
            this.CustomDebugBtn.BackColor = System.Drawing.Color.DimGray;
            this.CustomDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CustomDebugBtn.FlatAppearance.BorderSize = 0;
            this.CustomDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomDebugBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CustomDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CustomDebugBtn.Location = new System.Drawing.Point(-5, 117);
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
            // RestoredDebugBtn
            // 
            this.RestoredDebugBtn.BackColor = System.Drawing.Color.DimGray;
            this.RestoredDebugBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.RestoredDebugBtn.FlatAppearance.BorderSize = 0;
            this.RestoredDebugBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestoredDebugBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.RestoredDebugBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.RestoredDebugBtn.Location = new System.Drawing.Point(-5, 89);
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
            // EbootPatchPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 273);
            this.Controls.Add(this.RestoredDebugBtn);
            this.Controls.Add(this.CustomDebugBtn);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.DisableDebugModeBtn);
            this.Controls.Add(this.CustomOptDebugBtn);
            this.Controls.Add(this.BaseDebugBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.MainBox);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EbootPatchPage";
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

        public void BackBtn_Click(object sender, EventArgs e) { // Making This Universal Is Too Much Trouble, Give Each Page Their Own
            Form f = ActiveForm;
            LastPos = f.Location;
            Dev.DebugOutStr($"Loading: {LastForm.Name}");
            if (LastForm.Name == ActiveForm.Name) {
                Dev.DebugOutStr("We're trying to boot the same form again. Showing Main Form Instead");
                MainForm.Show();
                Dobby.Page = MainForm.Name;
                goto skip;
            }
            LastForm.Show();
skip: ActiveForm.Location = LastPos;
            f.Close();
            Dobby.Page = ActiveForm.Name;
            if (!Dev.REL) PageInfo(ActiveForm.Controls);
        }
        public void BackBtnMH(object sender, EventArgs e) => HoverString(BackBtn, $"{(Dev.REL ? "" : LastForm.Name)}");
        public void BackBtnML(object sender, EventArgs e) => HoverLeave(BackBtn, 1);

        public void InfoHelpBtn_Click(object sender, EventArgs e) {
            if (MainForm == null && ActiveForm.Name == "Dobby")
                MainForm = ActiveForm;
            LastForm = ActiveForm;
            LastPos = LastForm.Location;
            InfoHelpPage NewPage = new InfoHelpPage();
            NewPage.Show();
            LastForm.Hide();
            if (!Dev.REL) PageInfo(ActiveForm.Controls);
        }
        public void InfoHelpBtnMH(object sender, EventArgs e) => HoverString(InfoHelpBtn, "Get Additional Information On Verious Pages");
        public void InfoHelpBtnML(object sender, EventArgs e) => HoverLeave(InfoHelpBtn, 1);

        public void CreditsBtn_Click(object sender, EventArgs e) {
            if (MainForm == null && ActiveForm.Name == "Dobby")
                MainForm = ActiveForm;
            LastForm = ActiveForm;
            LastPos = LastForm.Location;
            CreditsPage NewPage = new CreditsPage();
            NewPage.Show();
            LastForm.Hide();
            if (!Dev.REL) PageInfo(ActiveForm.Controls);
        }
        public void CreditsBtnMH(object sender, EventArgs e) => HoverString(CreditsBtn, "View Credits For The Tool And Included Patches");
        public void CreditsBtnML(object sender, EventArgs e) => HoverLeave(CreditsBtn, 1);

        /* End Of Repeated Functions
============================================================================================================================================================================
        // Start Of PS4Debug Page Specific Functions                                                                                                                      */

        public void WriteBytes(int offset, byte[] data) {
            fs.Position = offset;
            fs.Write(data, 0, data.Length);
        }
        public void WriteByte(int offset, byte data) {
            fs.Position = offset;
            fs.WriteByte(data);
        }
        public void WriteBytes(int[] offset, byte[][] data) {
            int i = 0;
            foreach (byte[] bytes in data) {
                fs.Position = offset[i];
                fs.Write(bytes, 0, data.Length);
                i++;
            }
        }
        public void WriteByte(int[] offset, byte data) {
            foreach (int ofs in offset) {
                fs.Position = ofs;
                fs.WriteByte(data);
            }
        }
        public void WriteBytes(int[] offset, byte[] data) {
            foreach (int ofs in offset) {
                fs.Position = ofs;
                fs.Write(data, 0, data.Length);
            }
        }

        public void MakeBaseDebugBtn_Click(object sender, EventArgs e) {
            FileDialog f = new OpenFileDialog {
                Filter = "Unsigned/Decrypted Executable|*.bin;*.elf",
                Title = "Select A .elf/.bin Format Executable. The File Must Be Unsigned (The First 4 Bytes Will Be .elf If It Is)"
            };
            if (f.ShowDialog() == DialogResult.OK) {
                using (fs = new FileStream(f.FileName, FileMode.Open, FileAccess.ReadWrite)) {
                    fs.Position = 0x60;
                    fs.Read(chk, 0, 4);
                    switch (BitConverter.ToInt32(chk, 0)) {
                        default:
                            MessageBox.Show("Couldn't Determine The Game This Executable Belongs To, Send It To Blob To Have It's Title ID Supported");
                            break;
                        case T1R100:
                            WriteByte(0x5C79, on);
                            Inf("The Last Of Us Remastered 1.00 Debug Enabled");
                            break;
                        case T1R109:
                            WriteByte(0x61B3, on);
                            Inf("The Last Of Us Remastered 1.09 Debug Enabled");
                            break;
                        case T1R11X:
                            WriteByte(0x61B3, on);
                            fs.Position = 0x18;
                            if ((byte)fs.ReadByte() == 0x10)
                                Inf("The Last Of Us Remastered 1.11 Debug Enabled");
                            else
                                Inf("The Last Of Us Remastered 1.10 Debug Enabled");
                            break;
                        case T2100:
                            WriteBytes(0x1D639C, T2Debug);
                            Inf("The Last Of Us Part II 1.00 Debug Enabled");
                            break;
                        case T2101:
                            Inf("Sorry, This Old Version Isn't Supported Just Yet");
                            //Inf("The Last Of Us Part II 1.01 Debug Enabled");
                            break;
                        case T2102:
                            Inf("Sorry, This Old Version Isn't Supported Just Yet");
                            //Inf("The Last Of Us Part II 1.02 Debug Enabled");
                            break;
                        case T2105:
                            Inf("Sorry, This Old Version Isn't Supported Just Yet");
                            //Inf("The Last Of Us Part II 1.05 Debug Enabled");
                            break;
                        case T2107:
                            WriteBytes(0x1D66BC, T2Debug);
                            Inf("The Last Of Us Part II 1.07 Debug Enabled");
                            break;
                        case T2108:
                            WriteBytes(0x6181FA, T2Debug);
                            Inf("The Last Of Us Part II 1.08 Debug Enabled");
                            break;
                        case T2109:
                            WriteBytes(0x6181FA, T2Debug);
                            Inf("The Last Of Us Part II 1.09 Debug Enabled");
                            break;
                        case UC1100:
                            WriteByte(0x102056, on);
                            Inf("Uncharted 1 1.00 Default Debug Enabled");
                            break;
                        case UC1102:
                            WriteByte(0x102180, 0xC3);
                            Inf("Uncharted 1 1.02 Default Debug Enabled");
                            break;
                        case UC2100:
                            WriteByte(0x1EB296, on);
                            Inf("Uncharted 2 1.00 Default Debug Enabled");
                            break;
                        case UC3100:
                            WriteByte(0x168EB6, on);
                            Inf("Uncharted 3 1.00 Default Debug Enabled");
                            break;
                        case UC4100:
                            WriteByte(0x1297ED, on);
                            Inf("Uncharted 4: A Thief's End 1.00 Debug Enabled");
                            break;
                        case UC413X:
                            WriteByte(0x1CCDFD, on);
                            Inf("Uncharted 4: A Thief's End 1.32/1.33 Debug Enabled");
                            break;
                        case TLL100:
                            WriteByte(0x1CCFED, on);
                            Inf("Uncharted: The Lost Legacy 1.00 Debug Enabled");
                            break;
                        case TLL10X:
                            WriteByte(0x1CD02D, on);
                            Inf("Uncharted: The Lost Legacy 1.08/1.09 Debug Enabled");
                            break;
                    }
                }
            }
        }
        public void MakeBaseDebugBtnMH(object sender, EventArgs e) => HoverString(BaseDebugBtn, "Enable Debug Mode As-Is With No Edits");
        public void MakeBaseDebugBtnML(object sender, EventArgs e) => HoverLeave(BaseDebugBtn, 1);


        public void RestoredDebugBtn_Click(object sender, EventArgs e) {
            if (Dev.REL) MessageBox.Show("Note:\nCurrently Supported Games Are:\n- Uncharted 1 1.00\n- Uncharted 1 1.02\n- Uncharted 4 1.33 MP\n\n..yeah, that's it.", "This Part Isn't Entirely Finished");
            FileDialog f = new OpenFileDialog {
                Filter = "Unsigned/Decrypted Executable|*.bin;*.elf",
                Title = "Select A .elf/.bin Format Executable. The File Must Be Unsigned (The First 4 Bytes Will Be .elf If It Is)"
            };

            // Declare The Common Byte Patterns Here Instead Of Having It Declared In Almost Every One Of The Switch Cases... Even Though That's Probably Stupid. \\ Future Blob: it is.
            byte[] E9Jump   = new byte[] { 0xE9, 0x00, 0x00, 0x00, 0x00 };
            byte[] TwoZero  = new byte[] { 0x00, 0x00 };
            byte[] FourZero = new byte[] { 0x00, 0x00, 0x00, 0x00 };
            int[] WhiteJumpsOneByte;
            int[] WhiteJumps;
            int[] FunctionNops;
            if (f.ShowDialog() == DialogResult.OK) {
                using (fs = new FileStream(f.FileName, FileMode.Open, FileAccess.ReadWrite)) {
                    
                    fs.Position = 0x60; fs.Read(chk, 0, 4);
                    game = BitConverter.ToInt32(chk, 0);

                    DialogResult Check;

                    switch (game) {
                        default:
                            MessageBox.Show("Couldn't Determine The Game This Executable Belongs To, Send It To Blob To Have It's Title ID Supported");
                            break;
                        case T1R100:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("The Last Of Us Remastered 1.00 Isn't Supported Yet");
                                break;
                            }
                            fs.Position = 0x5C79;
                            fs.WriteByte(on);
                            Inf("The Last Of Us Remastered 1.00 Debug Enabled");
                            break;
                        case T1R109:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("The Last Of Us Remastered 1.09 Isn't Supported Yet");
                                break;
                            }
                            fs.Position = 0x61B3;
                            fs.WriteByte(on);
                            Inf("The Last Of Us Remastered 1.09 Debug Enabled");
                            break;
                        case T1R11X:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("The Last Of Us Remastered 1.10/11 Isn't Supported Yet");
                                break;
                            }
                            fs.Position = 0x61B3;
                            fs.WriteByte(on);
                            Inf($"The Last Of Us Remastered 1.1{((byte)fs.ReadByte() == 0x10 ? "1" : "0")} WIP");
                            break;
                        case T2100:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("The Last Of Us Part II 1.00 Has Nothing To Restore");
                                break;
                            }
                            WriteBytes(0x1D639C, T2Debug);
                            Inf("The Last Of Us Part II 1.00 Debug Enabled");
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
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("The Last Of Us Part II 1.07 Has Nothing To Restore");
                                break;
                            }
                            WriteBytes(0x1D66BC, T2Debug);
                            Inf("The Last Of Us Part II 1.07 Debug Enabled");
                            break;
                        case T2108:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("The Last Of Us Part II 1.08 Has Nothing To Restore");
                                break;
                            }
                            WriteBytes(0x6181FA, T2Debug);
                            Inf("The Last Of Us Part II 1.08 Debug Enabled");
                            break;
                        case T2109:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("The Last Of Us Part II 1.09 Has Nothing To Restore");
                                break;
                            }
                            WriteBytes(0x6181FA, T2Debug);
                            Inf("The Last Of Us Part II 1.09 Debug Enabled");
                            break;
                        case UC1100: // Uncharted 1 1.00 Restored Debug Ver. 2
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

                            WriteByte(0x102050, 0xC3);                                         // Keep Debug Mode Enabled (It Gets Disabled On Boot, It's Actually On By Default).

                            foreach(int Address in WhiteJumpsOneByte)
                                WriteByte(Address, 0x00);

                            foreach(int Address in WhiteJumps)
                                WriteBytes(Address, TwoZero);

                            foreach(int Address in FunctionNops)
                                WriteBytes(Address, E9Jump);
                            

                            WriteBytes(0x2D6AD3, new byte[] { 0xE9, 0x27, 0x00, 0x00, 0x00 }); // Skip Crashing Shader Variables Code
                            WriteBytes(0x2D6B26, new byte[] { 0xEB, 0x05 });                   // Skip Some Code That Causes The Material Debug... Menu To Crash When Selected
                            WriteBytes(0x2D6C87, new byte[] { 0xE9, 0x76 });                   // Skip Crashing Shader Variables Submenu (Crashes The Game Mid-Boot)
                            WriteByte(new int[] { 0x2D6A70, 0x2D6A50 }, 0xEB);                 // Fix The Material Debug... Options

                            WriteBytes(0x77B2E0, new byte[] { 0x5A, 0x7D, 0x0C, 0x00 });       // Add Valid Build Number. This Enables The "Build: " & "Built: " Debug Text As Well

                            WriteBytes(0x354650, new byte[] { 0xB0, 0x01 });                   // Load HYBRID Text
                          //WriteByte(0x354681, 0x00);                                         // Change HYBRID To DEBUG

                            WriteBytes(0x2C7230, new byte[] { 0xB0, 0x01, 0xC3 });             // Stop "Create New Level Render Settings..." From Crashing The Game When "Default Render Settings..." Is Opened
                            WriteBytes(0x2C7220, new byte[] { 0xB0, 0x01, 0xC3 });             // Stop "Load Existing Render Settings..." From Crashing The Game When "Default Render Settings..." Is Opened
                            WriteByte (0x2C71A1, 0xEB);                                        // Stop "Save Current Render Settings..." From Crashing When Selected
                            
                            Inf("Uncharted 1 1.00 Restored Debug Applied");
                            break;

                        case UC1102:        // Uncharted 1 1.02 Restored Debug Ver. 2.7
                            WhiteJumpsOneByte = new int[] {
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
                            WhiteJumps = new int[] {
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
                            FunctionNops = new int[] {
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

                            foreach (int Address in WhiteJumpsOneByte)
                                WriteByte(Address, 0x00);

                            foreach (int Address in WhiteJumps)
                                WriteBytes(Address, TwoZero);

                            foreach (int Address in FunctionNops)
                                WriteBytes(Address, E9Jump);

                            WriteBytes(0x772B80, new byte[] { 0x46, 0x7F, 0x0C, 0x00 });       // Add Valid Build Number. This Enables The "Build: " & "Built: " Debug Text As Well

                            WriteBytes(0x44AE30, new byte[] { 0xB0, 0x01});                    // Load HYBRID Debug Text
                          //WriteByte(0x44AE41, 0x00);                                         // Change HYBRID To DEBUG

                            WriteBytes( new int[] { 0x30FF09, 0x30FF3C }, new byte[][] { new byte[] { 0xEB, 0x2C }, new byte[] { 0xEB, 0x17 } });
//                          /\       Skip Some Code In Two Spots In The State Objects Menu To Stop Tasks From Crashing The Game Mid-Load       /\

                            WriteBytes(0x2D70C3, new byte[] { 0xE9, 0x27, 0x00, 0x00, 0x00 }); // Skip Crashing Shader Variables Code
                            WriteBytes(0x2D7116, new byte[] { 0xEB, 0x05 });                   // Skip Some Code That Causes The Material Debug... Menu To Crash When Selected
                            WriteBytes(0x2D7277, new byte[] { 0xE9, 0x76 });                   // Skip Crashing Shader Variables Submenu
                            WriteByte(new int[] { 0x2D7060, 0x2D7040 }, 0xEB);                 // Fix The Material Debug... Options
                            
                            WriteBytes(0x2C7810, new byte[] { 0xB0, 0x01, 0xC3 });             // Stop "Create New Level Render Settings..." From Crashing The Game When "Default Render Settings..." Is Opened
                            WriteBytes(0x2C7820, new byte[] { 0xB0, 0x01, 0xC3 });             // Stop "Load Existing Render Settings..." From Crashing The Game When "Default Render Settings..." Is Opened
                            WriteByte(0x2C7791, 0xEB);                                         // Stop "Save Current Render Settings..." From Crashing When Selected

                            WriteBytes(0x561BB0, new byte[] { 0xE9, 0xB5, 0x00, 0x00, 0x00 }); // Particles Pop

                            Inf("Uncharted 1 1.02 Restored Debug Applied");
                            break;

                        case UC2100:
                            byte[] skip = new byte[] { 0xE9, 0x00, 0x00, 0x00, 0x00 };
                            WriteByte(0x1EB296, 0x01);
                            WriteByte(new int[] { 0x6C9C, 0x436CEE }, 0x1C);
                            WriteBytes(new int[] { 0x6D5E, 0x1C4708, 0x1C4C60, 0x436D71 }, new byte[][] { skip, new byte[] { 0x1C, 0x00, 0x00, 0x00 }, skip, skip });
                            Inf("Uncharted 2 1.00 WIP Restored Debug Applied");
                            break;
                        case UC3100:
                            Inf("Uncharted 3 1.00 Restored Debug N/A");
                            break;

                        case UC4100:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("Sorry, No Restored Uncharted 4 1.00 Debug Yet");
                                break;
                            }
                            WriteByte(0x1297ED, on);
                            Inf("Uncharted 4: A Thief's End 1.00 Debug Enabled");
                            break;

                        case UC413X:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("Sorry, No Restored Uncharted 4 1.33 Debug Yet");
                                break;
                            }
                            WriteByte(0x1CCDFD, on);
                            Inf("Uncharted 4: A Thief's End 1.32/1.33 Debug Enabled");
                            break;

                        case UC4133MP: // Uncharted 4 1.33 Multiplayer
                            WhiteJumps = new int[] {
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
                            FunctionNops = new int[] {
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
                            var Returns = new int[] {
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
                                WriteBytes(Address, new byte[] {0x00, 0x00, 0x00, 0x00});
                            foreach (int Address in FunctionNops)
                                WriteBytes(Address, E9Jump);
                            foreach (int Address in Returns)
                                WriteByte(Address, 0xC3);
                            Inf("Restored Uncharted 4 1.33 MP Debug Menu Applied");
                            break;
                        case TLL100:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("Sorry, The Lost Legacy 1.00 Isn't Supported By This");
                                break;
                            }
                            WriteByte(0x1CCFED, on);
                            Inf("Uncharted: The Lost Legacy 1.00 Debug Enabled");
                            break;
                        case TLL10X:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("Sorry, The Lost Legacy 1.08/1.09 Isn't Supported By This");
                                break;
                            }
                            WriteByte(0x1CD02D, on);
                            Inf("Uncharted: The Lost Legacy 1.08/1.09 Debug Enabled");
                            break;
                    }
                }
            }
        }

        public void RestoredDebugBtnMH(object sender, EventArgs e) => HoverString(RestoredDebugBtn, "Only Restores Options, Replaces No Code");
        public void RestoredDebugBtnML(object sender, EventArgs e) => HoverLeave(RestoredDebugBtn, 1);

        public void CustomDebugBtn_Click(object sender, EventArgs e) { // Just Edited Debug Menus, Some Things May Be Replaced
            if (Dev.REL) MessageBox.Show("Note:\nThe Only Currently Supported Games Are\nThe Last Of Us Part II\nUncharted 2 1.00\n\nThe Restored Debug Menus Are My Current Priority", "This Part Isn't Entirely Finished");
            FileDialog f = new OpenFileDialog {
                Filter = "Unsigned/Decrypted Executable|*.bin;*.elf",
                Title = "Select A .elf/.bin Format Executable. The File Must Be Unsigned (The First 4 Bytes Will Be .elf If It Is)"
            };
            if (f.ShowDialog() == DialogResult.OK) {
                using (fs = new FileStream(f.FileName, FileMode.Open, FileAccess.ReadWrite)) {
                    fs.Position = 0x60;
                    fs.Read(chk, 0, 4);

                    game = BitConverter.ToInt32(chk, 0);

                    DialogResult Check;

                    switch (game) {
                        default:
                            MessageBox.Show("Couldn't Determine The Game This Executable Belongs To, Send It To Blob To Have It's Title ID Supported");
                            break;
                        case T1R100:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("The Last Of Us Remastered 1.00 Isn't Supported Yet");
                                break;
                            }
                            fs.Position = 0x5C79;
                            fs.WriteByte(on);
                            Inf("The Last Of Us Remastered 1.00 Debug Enabled");
                            break;
                        case T1R109:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("The Last Of Us Remastered 1.09 Isn't Supported Yet");
                                break;
                            }
                            fs.Position = 0x61B3;
                            fs.WriteByte(on);
                            Inf("The Last Of Us Remastered 1.09 Debug Enabled");
                            break;
                        case T1R11X:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("The Last Of Us Remastered 1.10/1.11 Isn't Supported Yet");
                                break;
                            }
                            fs.Position = 0x61B3;
                            fs.WriteByte(on);
                            fs.Position = 0x18;
                            Inf($"The Last Of Us Remastered 1.1{((byte)fs.ReadByte() == 0x10 ? "1" : "0")} Debug Enabled");
                            break;
                        case T2100:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("The Last Of Us Part II 1.00 Isn't Supported Just Yet");
                                break;
                            }
                            WriteBytes(0x1D639C, T2Debug);
                            Inf("The Last Of Us Part II 1.00 Debug Enabled");
                            break;
                        case T2101:
                            Inf("Sorry, The Last Of Us Part II 1.01 Isn't Supported Just Yet");
                            break;
                        case T2102:
                            Inf("Sorry, The Last Of Us Part II 1.02 Isn't Supported Just Yet");
                            break;
                        case T2105:
                            Inf("Sorry, The Last Of Us Part II 1.05 Isn't Supported Just Yet");
                            break;
                        case T2107:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("The Last Of Us Part II 1.07 Isn't Supported Just Yet");
                                break;
                            }
                            WriteBytes(0x1D66BC, T2Debug);
                            Inf("The Last Of Us Part II 1.07 Debug Enabled");
                            break;
                        case T2108:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("The Last Of Us Part II 1.08 Isn't Supported Just Yet");
                                break;
                            }
                            WriteBytes(0x6181FA, T2Debug);
                            Inf("The Last Of Us Part II 1.08 Debug Enabled");
                            break;
                        case T2109:
                            fs.Position = 0x6181FA; // Enable Debug + Change L3 & Triangle Toggle First
                            fs.Write(T2Debug, 0, 2);
                            WriteByte(0x1C45085, 0xB8);
                            fs.Position = 0x1C45092;
                            fs.WriteByte(0xB8);

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
                                fs.Position = addr;
                                fs.Write(dat[i], 0, dat[i].Length);
                                i++;
                            }
                            Inf("The Last Of Us Part II 1.09 Enhanced Debug Enabled");
                            break;

                        case UC1100: // UC1 1.00
                            Check = MessageBox.Show("There Is No Custom Debug For Uncharted 1 1.00, Only Restored And Default.\nEnable Default Debug Instead?", "Only Restored And Default Uncharted 1 Debug's Available", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("Try The Restored 1.00 Debug Instead");
                                break;
                            }
                            WriteByte(0x102056, on);
                            Inf("Uncharted 1 1.00 Default Debug Enabled");
                            break;
                        case UC1102:
                            Check = MessageBox.Show("There Is No Custom Debug For Uncharted 1 1.02, Only Restored And Default.\nEnable Default Debug Instead?", "Only Restored And Default Uncharted 1 Debug's Available", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("Try The Restored 1.02 Debug Instead");
                                break;
                            }
                            WriteByte(0x102187, 0xEB);
                            Inf("Uncharted 1 1.02 Default Debug Enabled");
                            break;
                        case UC2100: // UC2 1.00 ?
                            byte[] skip = new byte[] { 0xE9, 0x00, 0x00, 0x00, 0x00 };
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
                            break;
                        case TLL100:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("Sorry, The Lost Legacy 1.00 Isn't Supported By This");
                                break;
                            }
                            WriteByte(0x1CCFED, on);
                            Inf("Uncharted: The Lost Legacy 1.00 Debug Enabled");
                            break;
                        case TLL10X:
                            Check = MessageBox.Show("Only The Default Debug Mode Is Available For This ATM, Would You Like To Apply That Instead?", "", MessageBoxButtons.YesNo);
                            if (Check == DialogResult.No) {
                                Inf("Sorry, The Lost Legacy 1.08/1.09 Isn't Supported By This");
                                break;
                            }
                            WriteByte(0x1CD02D, on);
                            Inf("Uncharted: The Lost Legacy 1.08/1.09 Debug Enabled");
                            break;
                    }
                }
            }
        }
        public void CustomDebugBtnMH(object sender, EventArgs e) => HoverString(CustomDebugBtn, "Enables A Customized Version Of The Debug Menu");
        public void CustomDebugBtnML(object sender, EventArgs e) => HoverLeave(CustomDebugBtn, 1);


        public void CustomOptDebugBtn_Click(object sender, EventArgs e) {
            if (Dev.REL) return;

            FileDialog f = new OpenFileDialog {
                Filter = "Unsigned/Decrypted Executable|*.bin;*.elf",
                Title = "Select A .elf/.bin Format Executable. The File Must Be Unsigned (The First 4 Bytes Will Be .elf If It Is)"
            };

            CDO = new bool[10]; CDO[7] = CDO[8] = true; MenuOpacity = 2;

            if (true) {//f.ShowDialog() == DialogResult.OK) {
                using (fs = new FileStream(@"D:\PS4\CUSA10249-patch\CUSA07820_1.09_eboot - Copy.bin" /*f.FileName*/, FileMode.Open, FileAccess.ReadWrite)) {

                    fs.Position = 0x60; fs.Read(chk, 0, 4); // Converts The Data Here To An Int To See Which Game & Patch Is Selected, It's Unique For All But One.

                    game = T2109; //BitConverter.ToInt32(chk, 0); //!
                    Dev.DebugOutStr("Eboot Selection Skipped, D:\\PS4\\CUSA10249-patch\\CUSA07820_1.09_eboot - Copy.bin Auto-Selected And Defaulted To T2109 For Testing");

                    switch (game) {
                        default:
                            MessageBox.Show("Couldn't Determine The Game This Executable Belongs To, Send It To Blob To Have It's Title ID Supported");
                            break;
                        case T1R100:/*
                            fs.Position = 0x5C79;
                            fs.WriteByte(on);
                            */
                            Inf("Sorry, The Last Of Us Remastered 1.00 Isn't Supported Just Yet");
                            break;
                        case T1R109:/*
                            fs.Position = 0x61B3;
                            fs.WriteByte(on);
                            */
                            Inf("Sorry, The Last Of Us Remastered 1.09 Isn't Supported Just Yet");
                            break;
                        case T1R11X:/*
                            fs.Position = 0x61B3;
                            fs.WriteByte(on);
                            */
                            Inf("Sorry, The Last Of Us Remastered 1.10/1.11 Isn't Supported Just Yet");
                            break;
                        case T2100:
                            MessageBox.Show("Please Get The 1.00, 1.07, or 1.09 Version Of The Game For  I'm Not Doing It For 6 Versions, 3 is Enough");
                            Inf("Sorry, The Last Of Us Part II 1.00 Isn't Supported Just Yet");
                            break;
                        case T2101:
                            MessageBox.Show("Please Get The 1.00, 1.07, or 1.09 Version Of The Game For  I'm Not Doing It For 6 Versions, 3 is Enough");
                            Inf("Sorry, The Last Of Us Part II 1.01 Isn't Supported");
                            break;
                        case T2102:
                            MessageBox.Show("Please Get The 1.00, 1.07, or 1.09 Version Of The Game For  I'm Not Doing It For 6 Versions, 3 is Enough");
                            Inf("Sorry, The Last Of Us Part II 1.02 Isn't Supported");
                            break;
                        case T2105:
                            MessageBox.Show("Please Get The 1.00, 1.07, or 1.09 Version Of The Game For  I'm Not Doing It For 6 Versions, 3 is Enough");
                            Inf("Sorry, The Last Of Us Part II 1.05 Isn't Supported");
                            break;
                        case T2107:
                            MessageBox.Show("Please Get The 1.00, 1.07, or 1.09 Version Of The Game For  I'm Not Doing It For 6 Versions, 3 is Enough");
                            Inf("Sorry, The Last Of Us Part II 1.07 Isn't Supported Just Yet");
                            break;
                        case T2108:
                            MessageBox.Show("Please Get The 1.00, 1.07, or 1.09 Version Of The Game For  I'm Not Doing It For 6 Versions, 3 is Enough");
                            Inf("Sorry, The Last Of Us Part II 1.08 Isn't Supported");
                            break;

                        case T2109:
                            T2CustomOptionsDebug NewPage = new T2CustomOptionsDebug();
                            NewPage.ShowDialog();

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
            }
        }
        public void CustomOptDebugBtnMH(object sender, EventArgs e) => HoverString(CustomOptDebugBtn, Dev.REL ? "Temporarily Disabled" : "Enables A Customized Version Of The Debug Menu");
        public void CustomOptDebugBtnML(object sender, EventArgs e) => HoverLeave(CustomOptDebugBtn, 1);
        #region |
        public static void CatchThatAnnoyingCrash() => Environment.Exit(0);
        #endregion
        public void DisableDebugModeBtn_Click(object sender, EventArgs e) {
            FileDialog f = new OpenFileDialog {
                Filter = "Unsigned/Decrypted Executable|*.bin;*.elf",
                Title = "Select A .elf/.bin Format Executable. The File Must Be Unsigned (The First 4 Bytes Will Be .elf If It Is)"
            };
            if (f.ShowDialog() == DialogResult.OK) {
                using (fs = new FileStream(f.FileName, FileMode.Open, FileAccess.ReadWrite)) {
                    fs.Position = 0x60;
                    fs.Read(chk, 0, 4);
                    game = BitConverter.ToInt32(chk, 0);
                    switch (game) {
                        default:
                            MessageBox.Show("Couldn't Determine The Game This Executable Belongs To, Send It To Blob To Have It's Title ID Supported");
                            break;
                        case T1R100:
                            fs.Position = 0x5C79;
                            fs.WriteByte(off);
                            Inf("The Last Of Us Remastered 1.00 Debug Disabled");
                            break;
                        case T1R109:
                            fs.Position = 0x61B3;
                            fs.WriteByte(off);
                            Inf("The Last Of Us Remastered 1.09 Debug Disabled");
                            break;
                        case T1R11X:
                            fs.Position = 0x61B3;
                            fs.WriteByte(off);
                            fs.Position = 0x18;
                            if ((byte)fs.ReadByte() == 0x10)
                                Inf("The Last Of Us Remastered 1.11 Debug Disabled");
                            else
                                Inf("The Last Of Us Remastered 1.10 Debug Disabled");
                            break;
                        case T2100:
                            fs.Position = 0x1D639C;
                            fs.Write(T2DebugOff, 0, 2);
                            Inf("The Last Of Us Part II 1.00 Debug Disabled");
                            break;
                        case T2101:
                            Inf("Sorry, This Old Version Isn't Supported Just Yet");
                            //Inf("The Last Of Us Part II 1.01 Debug Disabled");
                            break;
                        case T2102:
                            Inf("Sorry, This Old Version Isn't Supported Just Yet");
                            //Inf("The Last Of Us Part II 1.02 Debug Disabled");
                            break;
                        case T2105:
                            Inf("Sorry, This Old Version Isn't Supported Just Yet");
                            //Inf("The Last Of Us Part II 1.05 Debug Disabled");
                            break;
                        case T2107:
                            WriteBytes(0x1D66BC, T2DebugOff);
                            Inf("The Last Of Us Part II 1.07 Debug Disabled");
                            break;
                        case T2108:
                            WriteBytes(0x6181FA, T2DebugOff);
                            Inf("The Last Of Us Part II 1.08 Debug Disabled");
                            break;
                        case T2109:
                            WriteBytes(0x6181FA, T2DebugOff);
                            Inf("The Last Of Us Part II 1.09 Debug Disabled");
                            break;
                        case UC1100:
                            fs.Position = 0x102056;
                            fs.WriteByte(off);
                            Inf("Uncharted 1 1.00 Default Debug Disabled");
                            break;
                        case UC2100:
                            fs.Position = 0x1EB296;
                            fs.WriteByte(off);
                            Inf("Uncharted 2 1.00 Default Debug Disabled");
                            break;
                        case UC3100:
                            fs.Position = 0x168EB6;
                            fs.WriteByte(off);
                            Inf("Uncharted 3 1.00 Default Debug Disabled");
                            break;
                        case UC4100:
                            fs.Position = 0x1297ED;
                            fs.WriteByte(off);
                            Inf("Uncharted 4: A Thief's End 1.00 Debug Disabled");
                            break;
                        case UC413X:
                            fs.Position = 0x1CCDFD;
                            fs.WriteByte(off);
                            Inf("Uncharted 4: A Thief's End 1.32/1.33 Debug Disabled");
                            break;
                        case 3:
                            fs.Position = 0x3;
                            fs.WriteByte(off);
                            Inf("Uncharted 4: A Thief's End 1.32/1.33 MP Debug Disabled");
                            break;
                        case TLL100:
                            fs.Position = 0x1CCFED;
                            fs.WriteByte(off);
                            Inf("Uncharted: The Lost Legacy 1.00 Debug Disabled");
                            break;
                        case TLL10X:
                            fs.Position = 0x1CD02D;
                            fs.WriteByte(off);
                            Inf("Uncharted: The Lost Legacy 1.08/1.09 Debug Disabled");
                            break;
                    }
                }
            }
        }
        public void DisableDebugModeBtnMH(object sender, EventArgs e) => HoverString(DisableDebugModeBtn, "Disable Debug Mode. Doesn't Undo Other Patches");
        public void DisableDebugModeBtnML(object sender, EventArgs e) => HoverLeave(DisableDebugModeBtn, 1);


        GroupBox MainBox;

        Label Info;
        Label label4;
        Label MainLabel;
        Button CreditsBtn;
        public Button BackBtn;
        Button ExitBtn;
        Button InfoHelpBtn;
        Button MinimizeBtn;
        Button BaseDebugBtn;
        Button CustomDebugBtn;
        Button RestoredDebugBtn;
        Button CustomOptDebugBtn;
        Button DisableDebugModeBtn;
    }
}
