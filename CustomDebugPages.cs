using System.Windows.Forms;
using System;
using System.Diagnostics;
using System.IO;
using static Dobby.Common;
using System.Drawing;

namespace Dobby {
    /// <summary>
    /// This Class File Contains All The Custom Debug Options Pages
    /// </summary>
    public class T2CustomOptionsDebug : Form {
        public T2CustomOptionsDebug() {
            Environment.Exit(0);
            if (Dev.REL) return;
            InitializeComponent();
            Dobby.Page = "T2CustomOptionsDebug";
            if (!Dev.REL) PageInfo(Controls);
        }

        public bool[] CDO = new bool[11]; //Custom Debug Options - 11th is For Eventually Keeping Track Of Whether The Options Were Left Default (true if changed)
        public byte FPSMode;
        public FileStream fs;
        public static float f1, f2;

        public byte[]
            chk = new byte[4],
            T2Debug = new byte[] { 0xb2, 0x00, 0xb0, 0x01 }, // Turns "Disable Debug Rendering" Off (b2 00) & Debug Mode On (b0 01)
            T2DebugOff = new byte[] { 0xb2, 0x01, 0x31, 0xc0 }
        ;
        public int
            MenuScale,
            MenuOpacity = 2
        ;
        public void ConfirmBtn_Click(object sender, EventArgs e) {

            using (FileStream fs = new FileStream(@"No Path, Fix.", FileMode.Open, FileAccess.ReadWrite)) {
                fs.Read(chk, 0, 4);
                switch (game) {

                    case 48176456: // T2 1.09

                        // Debug Mode => On
                        WriteBytes(0x6181FA, T2Debug);

                        // Draw World Axes => Disable All Visibility | novis
                        WriteBytes(0x25AE9DA, new byte[] { 0x4E, 0xF4, 0xA9, 0x00 }); // byte addr
                        WriteBytes(0x25AE990, new byte[] { 0xbc, 0x51, 0x84 }); // string addr (To fit larger string)
                        WriteBytes(0x2DF3B50, new byte[] { 0x44, 0x69, 0x73, 0x61, 0x62, 0x6C, 0x65, 0x20, 0x41, 0x6C, 0x6C, 0x20, 0x56, 0x69, 0x73, 0x69, 0x62, 0x69, 0x6C, 0x69, 0x74, 0x79 }); // New String

                        WriteByte(new int[] { 0x1C45085, 0x1C45092 }, 0xB8); // Change Debug Rendering Toggle To A Debug Text Toggle

                        //                      \/ Disable Debug Rendering Because Fuck You I Said So xD \/
                        WriteBytes(0x25B0BAA, /*FixItLater*/false ? new byte[] { 0x41, 0xc6, 0x85, 0xaa, 0x3a, 0x00, 0x00, 0x00, 0x48, 0xe9, 0x81, 0x00, 0x00, 0x00 } : new byte[] { 0x41, 0xc6, 0x85, 0xaa, 0x3a, 0x00, 0x00, 0x00 });

                        if (true) { //FixItLater //!
                            int i = 0;
                            byte[] nop = new byte[111];
                            foreach (byte v in nop) {
                                nop[i] = 0x90;
                                i++;
                            }
                            // nop
                            WriteBytes(0x25B0BB2, nop);
                        }
                        else break;

                        if (CDO[0]) WriteBytes(0x25B0BB2, new byte[] { 0x41, 0xc6, 0x85, 0xed, 0x3e, 0x00, 0x00, 0x01 });
                        if (CDO[1]) WriteBytes(0x25B0BBA, new byte[] { 0xc6, 0x05, 0x06, 0x3c, 0xf4, 0x01, 0x01 });
                        if (CDO[2]) WriteBytes(0x25B0BC1, new byte[] { 0xc6, 0x05, 0x03, 0x3c, 0xf4, 0x01, 0x01 });
                        if (CDO[3]) WriteBytes(0x25B0BC8, new byte[] { 0xc6, 0x05, 0x6f, 0xda, 0xca, 0x00, 0x01 });
                        if (CDO[4]) WriteBytes(0x25B0BCF, new byte[] { 0xc6, 0x05, 0x67, 0xda, 0xca, 0x00, 0x01 });
                        if (CDO[5]) WriteBytes(0x25B0BD6, new byte[] { 0xc6, 0x05, 0x5b, 0xda, 0xca, 0x00, 0x01 });
                        if (CDO[6]) WriteBytes(0x25B0BDD, new byte[] { 0xc6, 0x05, 0x48, 0xd2, 0xa9, 0x00, 0x01 });
                        if (!CDO[7]) WriteBytes(0x25B0BE4, new byte[] { 0xc6, 0x05, 0x4e, 0xda, 0xca, 0x00, 0x00 });
                        if (!CDO[8]) WriteBytes(0x25B0BEB, new byte[] { 0xc6, 0x05, 0x48, 0xda, 0xca, 0x00, 0x00 });
                        if (MenuScale != 0) { WriteBytes(0x25B0BF2, new byte[] { 0xc7, 0x05, 0x4c, 0xda, 0xca, 0x00 }); WriteBytes(0x25B0BF8, BitConverter.GetBytes(f1)); }
                        if (MenuOpacity != 2) { WriteBytes(0x25B0BFC, new byte[] { 0xc7, 0x05, 0x3e, 0xda, 0xca, 0x00 }); WriteBytes(0x25B0C02, BitConverter.GetBytes(f2)); }
                        if (CDO[9]) WriteBytes(0x25B0C06, new byte[] { 0x41, 0xc6, 0x85, 0xb8, 0x3a, 0x00, 0x00, 0x01 });
                        if (FPSMode != 0) WriteBytes(0x25B0C0E, new byte[] { 0x41, 0xc7, 0x85, 0xb4, 0x3a, 0x00, 0x00, FPSMode, 0x00, 0x00, 0x00 });
                        if (true)//!!OptionsUnchanged)
                            WriteBytes(0x25B0C19, new byte[] { 0xEB, 0x1E });
                        break;
                }
            }
        }
        public void Invert(Control C, int f) {
            if (MouseScrolled == 1 || MouseIsDown == 0 || CurrentControl != C.Name) {
                Dev.DebugOutStr($"MouseScrolled: {MouseScrolled}\nMouseIsDown: {MouseIsDown}\n CurrentControl: {CurrentControl}\nC.Name: {C.Name}");
                return;
            }
            tmp = C.Text;
            CDO[f] = !CDO[f];
            tmp = $"{tmp.Remove(tmp.LastIndexOf(' '))} {(CDO[f] ? "On" : "Off")}";
            C.Text = tmp;
        }
        public void ConfirmBtnMH(object sender, EventArgs e) => HoverLeave(ConfirmBtn, 0);
        public void ConfirmBtnML(object sender, EventArgs e) => HoverLeave(ConfirmBtn, 1);

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
            foreach (byte[] ar in data) {
                fs.Position = offset[i];
                fs.Write(ar, 0, data.Length);
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

        public void InitializeComponent() {
            this.MainLabel = new System.Windows.Forms.Label();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.Info = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.Option1Btn = new System.Windows.Forms.Button();
            this.Option2Btn = new System.Windows.Forms.Button();
            this.Option3Btn = new System.Windows.Forms.Button();
            this.Option4Btn = new System.Windows.Forms.Button();
            this.Option5Btn = new System.Windows.Forms.Button();
            this.Option6Btn = new System.Windows.Forms.Button();
            this.Option7Btn = new System.Windows.Forms.Button();
            this.Option8Btn = new System.Windows.Forms.Button();
            this.Option9Btn = new System.Windows.Forms.Button();
            this.Option10Btn = new System.Windows.Forms.Button();
            this.Option11Btn = new System.Windows.Forms.Button();
            this.Option12Btn = new System.Windows.Forms.Button();
            this.Option13Btn = new System.Windows.Forms.Button();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            this.MainLabel.Text = "Custom Debug: Choose Options";
            // 
            // MainBox
            // 
            this.MainBox.Controls.Add(this.MainLabel);
            this.MainBox.Location = new System.Drawing.Point(1, -4);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(317, 32);
            this.MainBox.TabIndex = 5;
            this.MainBox.TabStop = false;
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(1, 377);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "   All Options Start Set To Their In-Game Defaults";
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.DimGray;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ExitBtn.Location = new System.Drawing.Point(293, 3);
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
            this.MinimizeBtn.Location = new System.Drawing.Point(270, 3);
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
            // Option1Btn
            // 
            this.Option1Btn.BackColor = System.Drawing.Color.DimGray;
            this.Option1Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option1Btn.FlatAppearance.BorderSize = 0;
            this.Option1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option1Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Option1Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Option1Btn.Location = new System.Drawing.Point(-5, 32);
            this.Option1Btn.Name = "Option1Btn";
            this.Option1Btn.Size = new System.Drawing.Size(170, 23);
            this.Option1Btn.TabIndex = 8;
            this.Option1Btn.Text = "Enable Stat Posting: Off";
            this.Option1Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option1Btn.UseVisualStyleBackColor = false;
            this.Option1Btn.Click += new System.EventHandler(this.Option1Btn_Click);
            this.Option1Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option1Btn.MouseEnter += new System.EventHandler(this.Option1BtnMH);
            this.Option1Btn.MouseLeave += new System.EventHandler(this.Option1BtnML);
            this.Option1Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option1Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option1Btn_SClick);
            // 
            // Option2Btn
            // 
            this.Option2Btn.BackColor = System.Drawing.Color.DimGray;
            this.Option2Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option2Btn.FlatAppearance.BorderSize = 0;
            this.Option2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option2Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Option2Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Option2Btn.Location = new System.Drawing.Point(-5, 56);
            this.Option2Btn.Name = "Option2Btn";
            this.Option2Btn.Size = new System.Drawing.Size(210, 22);
            this.Option2Btn.TabIndex = 20;
            this.Option2Btn.Text = "Show Save Slot On Screen: Off";
            this.Option2Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option2Btn.UseVisualStyleBackColor = false;
            this.Option2Btn.Click += new System.EventHandler(this.Option2Btn_Click);
            this.Option2Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option2Btn.MouseEnter += new System.EventHandler(this.Option2BtnMH);
            this.Option2Btn.MouseLeave += new System.EventHandler(this.Option2BtnML);
            this.Option2Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option2Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option2Btn_SClick);
            // 
            // Option3Btn
            // 
            this.Option3Btn.BackColor = System.Drawing.Color.DimGray;
            this.Option3Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option3Btn.FlatAppearance.BorderSize = 0;
            this.Option3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option3Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Option3Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Option3Btn.Location = new System.Drawing.Point(-5, 79);
            this.Option3Btn.Name = "Option3Btn";
            this.Option3Btn.Size = new System.Drawing.Size(196, 22);
            this.Option3Btn.TabIndex = 21;
            this.Option3Btn.Text = "Show Game Completion: Off";
            this.Option3Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option3Btn.UseVisualStyleBackColor = false;
            this.Option3Btn.Click += new System.EventHandler(this.Option3Btn_Click);
            this.Option3Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option3Btn.MouseEnter += new System.EventHandler(this.Option3BtnMH);
            this.Option3Btn.MouseLeave += new System.EventHandler(this.Option3BtnML);
            this.Option3Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option3Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option3Btn_SClick);
            // 
            // Option4Btn
            // 
            this.Option4Btn.BackColor = System.Drawing.Color.DimGray;
            this.Option4Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option4Btn.FlatAppearance.BorderSize = 0;
            this.Option4Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option4Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Option4Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Option4Btn.Location = new System.Drawing.Point(-5, 103);
            this.Option4Btn.Name = "Option4Btn";
            this.Option4Btn.Size = new System.Drawing.Size(206, 23);
            this.Option4Btn.TabIndex = 22;
            this.Option4Btn.Text = "Align Debug Menus Right: Off";
            this.Option4Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option4Btn.UseVisualStyleBackColor = false;
            this.Option4Btn.Click += new System.EventHandler(this.Option4Btn_Click);
            this.Option4Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option4Btn.MouseEnter += new System.EventHandler(this.Option4BtnMH);
            this.Option4Btn.MouseLeave += new System.EventHandler(this.Option4BtnML);
            this.Option4Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option4Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option4Btn_SClick);
            // 
            // Option5Btn
            // 
            this.Option5Btn.BackColor = System.Drawing.Color.DimGray;
            this.Option5Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option5Btn.FlatAppearance.BorderSize = 0;
            this.Option5Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option5Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Option5Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Option5Btn.Location = new System.Drawing.Point(-5, 126);
            this.Option5Btn.Name = "Option5Btn";
            this.Option5Btn.Size = new System.Drawing.Size(317, 24);
            this.Option5Btn.TabIndex = 23;
            this.Option5Btn.Text = "Swap Square With Circle In Debug Menus: Off";
            this.Option5Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option5Btn.UseVisualStyleBackColor = false;
            this.Option5Btn.Click += new System.EventHandler(this.Option5Btn_Click);
            this.Option5Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option5Btn.MouseEnter += new System.EventHandler(this.Option5BtnMH);
            this.Option5Btn.MouseLeave += new System.EventHandler(this.Option5BtnML);
            this.Option5Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option5Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option5Btn_SClick);
            // 
            // Option6Btn
            // 
            this.Option6Btn.BackColor = System.Drawing.Color.DimGray;
            this.Option6Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option6Btn.FlatAppearance.BorderSize = 0;
            this.Option6Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option6Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Option6Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Option6Btn.Location = new System.Drawing.Point(-5, 149);
            this.Option6Btn.Name = "Option6Btn";
            this.Option6Btn.Size = new System.Drawing.Size(224, 23);
            this.Option6Btn.TabIndex = 24;
            this.Option6Btn.Text = "Debug Menu Shadowed Text: Off";
            this.Option6Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option6Btn.UseVisualStyleBackColor = false;
            this.Option6Btn.Click += new System.EventHandler(this.Option6Btn_Click);
            this.Option6Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option6Btn.MouseEnter += new System.EventHandler(this.Option6BtnMH);
            this.Option6Btn.MouseLeave += new System.EventHandler(this.Option6BtnML);
            this.Option6Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option6Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option6Btn_SClick);
            // 
            // Option7Btn
            // 
            this.Option7Btn.BackColor = System.Drawing.Color.DimGray;
            this.Option7Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option7Btn.FlatAppearance.BorderSize = 0;
            this.Option7Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option7Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Option7Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Option7Btn.Location = new System.Drawing.Point(-5, 173);
            this.Option7Btn.Name = "Option7Btn";
            this.Option7Btn.Size = new System.Drawing.Size(219, 23);
            this.Option7Btn.TabIndex = 25;
            this.Option7Btn.Text = "Disable All Visibility (novis): Off";
            this.Option7Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option7Btn.UseVisualStyleBackColor = false;
            this.Option7Btn.Click += new System.EventHandler(this.Option7Btn_Click);
            this.Option7Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option7Btn.MouseEnter += new System.EventHandler(this.Option7BtnMH);
            this.Option7Btn.MouseLeave += new System.EventHandler(this.Option7BtnML);
            this.Option7Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option7Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option7Btn_SClick);
            // 
            // Option8Btn
            // 
            this.Option8Btn.BackColor = System.Drawing.Color.DimGray;
            this.Option8Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option8Btn.FlatAppearance.BorderSize = 0;
            this.Option8Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option8Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Option8Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Option8Btn.Location = new System.Drawing.Point(-5, 197);
            this.Option8Btn.Name = "Option8Btn";
            this.Option8Btn.Size = new System.Drawing.Size(267, 23);
            this.Option8Btn.TabIndex = 26;
            this.Option8Btn.Text = "Pause Game On Debug Menu Open: On";
            this.Option8Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option8Btn.UseVisualStyleBackColor = false;
            this.Option8Btn.Click += new System.EventHandler(this.Option8Btn_Click);
            this.Option8Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option8Btn.MouseEnter += new System.EventHandler(this.Option8BtnMH);
            this.Option8Btn.MouseLeave += new System.EventHandler(this.Option8BtnML);
            this.Option8Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option8Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option8Btn_SClick);
            // 
            // Option9Btn
            // 
            this.Option9Btn.BackColor = System.Drawing.Color.DimGray;
            this.Option9Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option9Btn.FlatAppearance.BorderSize = 0;
            this.Option9Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option9Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Option9Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Option9Btn.Location = new System.Drawing.Point(-5, 221);
            this.Option9Btn.Name = "Option9Btn";
            this.Option9Btn.Size = new System.Drawing.Size(270, 23);
            this.Option9Btn.TabIndex = 27;
            this.Option9Btn.Text = "Pause Game On Debug Menu Close: On";
            this.Option9Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option9Btn.UseVisualStyleBackColor = false;
            this.Option9Btn.Click += new System.EventHandler(this.Option9Btn_Click);
            this.Option9Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option9Btn.MouseEnter += new System.EventHandler(this.Option9BtnMH);
            this.Option9Btn.MouseLeave += new System.EventHandler(this.Option9BtnML);
            this.Option9Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option9Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option9Btn_SClick);
            // 
            // Option10Btn
            // 
            this.Option10Btn.BackColor = System.Drawing.Color.DimGray;
            this.Option10Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option10Btn.FlatAppearance.BorderSize = 0;
            this.Option10Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option10Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Option10Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Option10Btn.Location = new System.Drawing.Point(-5, 245);
            this.Option10Btn.Name = "Option10Btn";
            this.Option10Btn.Size = new System.Drawing.Size(228, 23);
            this.Option10Btn.TabIndex = 28;
            this.Option10Btn.Text = "Debug Menu Scale: 0.6 (Default)";
            this.Option10Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option10Btn.UseVisualStyleBackColor = false;
            this.Option10Btn.Click += new System.EventHandler(this.Option10Btn_Click);
            this.Option10Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option10Btn.MouseEnter += new System.EventHandler(this.Option10BtnMH);
            this.Option10Btn.MouseLeave += new System.EventHandler(this.Option10BtnML);
            this.Option10Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option10Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option10Btn_Scroll);
            // 
            // Option11Btn
            // 
            this.Option11Btn.BackColor = System.Drawing.Color.DimGray;
            this.Option11Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option11Btn.FlatAppearance.BorderSize = 0;
            this.Option11Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option11Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Option11Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Option11Btn.Location = new System.Drawing.Point(-5, 269);
            this.Option11Btn.Name = "Option11Btn";
            this.Option11Btn.Size = new System.Drawing.Size(284, 23);
            this.Option11Btn.TabIndex = 29;
            this.Option11Btn.Text = "Menu Background Opacity: 0.85 (Default)";
            this.Option11Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option11Btn.UseVisualStyleBackColor = false;
            this.Option11Btn.Click += new System.EventHandler(this.Option11Btn_Click);
            this.Option11Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option11Btn.MouseEnter += new System.EventHandler(this.Option11BtnMH);
            this.Option11Btn.MouseLeave += new System.EventHandler(this.Option11BtnML);
            this.Option11Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option11Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option11Btn_Scroll);
            // 
            // Option12Btn
            // 
            this.Option12Btn.BackColor = System.Drawing.Color.DimGray;
            this.Option12Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option12Btn.FlatAppearance.BorderSize = 0;
            this.Option12Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option12Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Option12Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Option12Btn.Location = new System.Drawing.Point(-5, 293);
            this.Option12Btn.Name = "Option12Btn";
            this.Option12Btn.Size = new System.Drawing.Size(249, 23);
            this.Option12Btn.TabIndex = 30;
            this.Option12Btn.Text = "Disable FPS + Other Debug Text: Off";
            this.Option12Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option12Btn.UseVisualStyleBackColor = false;
            this.Option12Btn.Click += new System.EventHandler(this.Option12Btn_Click);
            this.Option12Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option12Btn.MouseEnter += new System.EventHandler(this.Option12BtnMH);
            this.Option12Btn.MouseLeave += new System.EventHandler(this.Option12BtnML);
            this.Option12Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option12Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option12Btn_SClick);
            // 
            // Option13Btn
            // 
            this.Option13Btn.BackColor = System.Drawing.Color.DimGray;
            this.Option13Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option13Btn.FlatAppearance.BorderSize = 0;
            this.Option13Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option13Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.Option13Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.Option13Btn.Location = new System.Drawing.Point(-4, 317);
            this.Option13Btn.Name = "Option13Btn";
            this.Option13Btn.Size = new System.Drawing.Size(245, 23);
            this.Option13Btn.TabIndex = 31;
            this.Option13Btn.Text = "FPS Display Mode:             FPS Only";
            this.Option13Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Option13Btn.UseVisualStyleBackColor = false;
            this.Option13Btn.Click += new System.EventHandler(this.Option13Btn_Click);
            this.Option13Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option13Btn.MouseEnter += new System.EventHandler(this.Option13BtnMH);
            this.Option13Btn.MouseLeave += new System.EventHandler(this.Option13BtnML);
            this.Option13Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option13Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option13Btn_Scroll);
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.BackColor = System.Drawing.Color.DimGray;
            this.ConfirmBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ConfirmBtn.FlatAppearance.BorderSize = 0;
            this.ConfirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.25F, System.Drawing.FontStyle.Bold);
            this.ConfirmBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ConfirmBtn.Location = new System.Drawing.Point(-5, 350);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(216, 24);
            this.ConfirmBtn.TabIndex = 32;
            this.ConfirmBtn.Text = "Confirm Options And Finish...";
            this.ConfirmBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConfirmBtn.UseVisualStyleBackColor = false;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            this.ConfirmBtn.MouseEnter += new System.EventHandler(this.ConfirmBtnMH);
            this.ConfirmBtn.MouseLeave += new System.EventHandler(this.ConfirmBtnML);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(-4, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "________________________________________________________________";
            // 
            // T2CustomOptionsDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 400);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.Option13Btn);
            this.Controls.Add(this.Option12Btn);
            this.Controls.Add(this.Option11Btn);
            this.Controls.Add(this.Option10Btn);
            this.Controls.Add(this.Option9Btn);
            this.Controls.Add(this.Option8Btn);
            this.Controls.Add(this.Option7Btn);
            this.Controls.Add(this.Option6Btn);
            this.Controls.Add(this.Option5Btn);
            this.Controls.Add(this.Option4Btn);
            this.Controls.Add(this.Option3Btn);
            this.Controls.Add(this.Option2Btn);
            this.Controls.Add(this.MinimizeBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.Option1Btn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.MainBox);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "T2CustomOptionsDebug";
            this.Text = "Main";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMouseUp);
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

        public void Option1Btn_SClick(object sender, EventArgs e) {
            Option1Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option1Btn_Click(object sender, EventArgs e) => Invert(Option1Btn, 0);
        public void Option1BtnMH(object sender, EventArgs e) => HoverLeave(Option1Btn, 0);
        public void Option1BtnML(object sender, EventArgs e) => HoverLeave(Option1Btn, 1);

        public void Option2Btn_SClick(object sender, EventArgs e) {
            Option2Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option2Btn_Click(object sender, EventArgs e) => Invert(Option2Btn, 1);
        public void Option2BtnMH(object sender, EventArgs e) => HoverLeave(Option2Btn, 0);
        public void Option2BtnML(object sender, EventArgs e) => HoverLeave(Option2Btn, 1);

        public void Option3Btn_SClick(object sender, EventArgs e) {
            Option3Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option3Btn_Click(object sender, EventArgs e) => Invert(Option3Btn, 2);
        public void Option3BtnMH(object sender, EventArgs e) => HoverLeave(Option3Btn, 0);
        public void Option3BtnML(object sender, EventArgs e) => HoverLeave(Option3Btn, 1);

        public void Option4Btn_SClick(object sender, EventArgs e) {
            Option4Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option4Btn_Click(object sender, EventArgs e) => Invert(Option4Btn, 3);
        public void Option4BtnMH(object sender, EventArgs e) => HoverLeave(Option4Btn, 0);
        public void Option4BtnML(object sender, EventArgs e) => HoverLeave(Option4Btn, 1);

        public void Option5Btn_SClick(object sender, EventArgs e) {
            Option5Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option5Btn_Click(object sender, EventArgs e) => Invert(Option5Btn, 4);
        public void Option5BtnMH(object sender, EventArgs e) => HoverLeave(Option5Btn, 0);
        public void Option5BtnML(object sender, EventArgs e) => HoverLeave(Option5Btn, 1);

        public void Option6Btn_SClick(object sender, EventArgs e) {
            Option6Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option6Btn_Click(object sender, EventArgs e) => Invert(Option6Btn, 5);
        public void Option6BtnMH(object sender, EventArgs e) => HoverLeave(Option6Btn, 0);
        public void Option6BtnML(object sender, EventArgs e) => HoverLeave(Option6Btn, 1);

        public void Option7Btn_SClick(object sender, EventArgs e) {
            Option7Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option7Btn_Click(object sender, EventArgs e) => Invert(Option7Btn, 6);
        public void Option7BtnMH(object sender, EventArgs e) => HoverLeave(Option7Btn, 0);
        public void Option7BtnML(object sender, EventArgs e) => HoverLeave(Option7Btn, 1);

        public void Option8Btn_SClick(object sender, EventArgs e) {
            Option8Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option8Btn_Click(object sender, EventArgs e) => Invert(Option8Btn, 7);
        public void Option8BtnMH(object sender, EventArgs e) => HoverLeave(Option8Btn, 0);
        public void Option8BtnML(object sender, EventArgs e) => HoverLeave(Option8Btn, 1);

        public void Option9Btn_SClick(object sender, EventArgs e) {
            Option9Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option9Btn_Click(object sender, EventArgs e) => Invert(Option9Btn, 8);

        public void Option9BtnMH(object sender, EventArgs e) => HoverLeave(Option9Btn, 0);
        public void Option9BtnML(object sender, EventArgs e) => HoverLeave(Option9Btn, 1);

        public void Option10Btn_Click(object sender, EventArgs e) {
            if (MouseScrolled == 1) return;
            if (MenuScale < 2) {
                MenuScale++;
            }
            else {
                MenuScale = 0;
                tmp = "Set Debug Menu Scale: 0.6 (Small)";
                f1 = 0.6f;
                Option10Btn.Text = ">" + tmp;
                return;
            }

            if (MenuScale == 1) {
                tmp = "Set Debug Menu Scale: 0.7 (Medium)";
                f1 = 0.7f;
                Option10Btn.Text = ">" + tmp;
            }
            else if (MenuScale == 2) {
                tmp = "Set Debug Menu Scale: 0.8 (Large)";
                f1 = 0.8f;
                Option10Btn.Text = ">" + tmp;
            }
        }

        public void Option10Btn_Scroll(object sender, MouseEventArgs e) {
            if (MouseIsDown == 0 || CurrentControl != "Option10Btn") return;

            MouseScrolled = 1;
            if (e.Delta < 0) {
                MenuScale--;
                if (MenuScale < 0 || MenuScale == 2) {
                    f1 = 0.8f;
                    MenuScale = 2;
                    tmp = "Set Debug Menu Scale: 0.8 (Large)";
                    Option10Btn.Text = ">" + tmp;
                    return;
                }

                if (MenuScale == 0) {
                    f1 = 0.6f;
                    tmp = "Set Debug Menu Scale: 0.6 (Small)";
                    Option10Btn.Text = ">" + tmp;
                }
                else if (MenuScale == 1) {
                    f1 = 0.7f;
                    tmp = "Set Debug Menu Scale: 0.7 (Medium)";
                    Option10Btn.Text = ">" + tmp;
                }
            }
            else if (e.Delta > 0) {
                MenuScale++;
                if (MenuScale == 3 || MenuScale == 0) {
                    f1 = 0.6f;
                    MenuScale = 0;
                    tmp = "Set Debug Menu Scale: 0.6 (Small)";
                    Option10Btn.Text = ">" + tmp;
                    return;
                }

                if (MenuScale == 1) {
                    f1 = 0.7f;
                    tmp = "Set Debug Menu Scale: 0.7 (Medium)";
                    Option10Btn.Text = ">" + tmp;
                }
                if (MenuScale == 2) {
                    f1 = 0.8f;
                    tmp = "Set Debug Menu Scale: 0.8 (Large)";
                    Option10Btn.Text = ">" + tmp;
                }
            }
        }


        public void Option10BtnMH(object sender, EventArgs e) => HoverLeave(Option10Btn, 0);

        public void Option10BtnML(object sender, EventArgs e) => HoverLeave(Option10Btn, 1);
        public void Option11Btn_Click(object sender, EventArgs e) {
            if (MouseScrolled == 1 || CurrentControl != "Option11Btn") return;

            MenuOpacity++;

            if (MenuOpacity == 4 || MenuOpacity == 0) {
                f2 = 0F;
                MenuOpacity = 0;
                tmp = "Menu Background Opacity:         0 - No BG";
                Option11Btn.Text = ">" + tmp;
                return;
            }

            if (MenuOpacity == 1) {
                f2 = 0.45F;
                tmp = "Menu Background Opacity:                0.45";
                Option11Btn.Text = ">" + tmp;
            }
            else if (MenuOpacity == 2) {
                f2 = 0.85F;
                tmp = "Menu Background Opacity: 0.85 (Default)";
                Option11Btn.Text = ">" + tmp;
            }
            else if (MenuOpacity == 3) {
                f2 = 1F;
                tmp = "Menu Background Opacity:                1.00";
                Option11Btn.Text = ">" + tmp;
            }
        }
        public void Option11Btn_Scroll(object sender, MouseEventArgs e) {
            if (MouseIsDown == 0 || CurrentControl != "Option11Btn") return;

            MouseScrolled = 1;
            if (e.Delta < 0) {
                MenuOpacity--;
                if (MenuOpacity < 0 || MenuOpacity == 4) {
                    f2 = 1F;
                    MenuOpacity = 3;
                    tmp = "Menu Background Opacity:                1.00";
                    Option11Btn.Text = ">" + tmp;
                    return;
                }

                if (MenuOpacity == 0) {
                    f2 = 0F;
                    tmp = "Menu Background Opacity:         0 - No BG";
                    Option11Btn.Text = ">" + tmp;
                }
                else if (MenuOpacity == 1) {
                    f2 = 0.45F;
                    tmp = "Menu Background Opacity:                0.45";
                    Option11Btn.Text = ">" + tmp;
                }
                else if (MenuOpacity == 2) {
                    f2 = 0.85F;
                    tmp = "Menu Background Opacity: 0.85 (Default)";
                    Option11Btn.Text = ">" + tmp;
                }
            }
            else if (e.Delta > 0) {
                MenuOpacity++;
                if (MenuOpacity == 4 || MenuOpacity == 0) {
                    MenuOpacity = 0;
                    f2 = 0F;
                    tmp = "Menu Background Opacity:         0 - No BG";
                    Option11Btn.Text = ">" + tmp;
                    return;
                }

                if (MenuOpacity == 1) {
                    f2 = 0.45F;
                    tmp = "Menu Background Opacity:                0.45";
                    Option11Btn.Text = ">" + tmp;
                }
                if (MenuOpacity == 2) {
                    f2 = 0.85F;
                    tmp = "Menu Background Opacity: 0.85 (Default)";
                    Option11Btn.Text = ">" + tmp;
                }
                if (MenuOpacity == 3) {
                    f2 = 1F;
                    tmp = "Menu Background Opacity:                1.00";
                    Option11Btn.Text = ">" + tmp;
                }
            }
        }
        public void Option11BtnMH(object sender, EventArgs e) => HoverLeave(Option11Btn, 0);
        public void Option11BtnML(object sender, EventArgs e) => HoverLeave(Option11Btn, 1);

        public void Option12Btn_SClick(object sender, EventArgs e) {
            Option12Btn_Click(sender, e); MouseScrolled = 1; // Can Ya Tell I Don't Know What The Hell I'm Doing Yet?
        }
        public void Option12Btn_Click(object sender, EventArgs e) => Invert(Option12Btn, 9);
        public void Option12BtnMH(object sender, EventArgs e) => HoverLeave(Option12Btn, 0);
        public void Option12BtnML(object sender, EventArgs e) => HoverLeave(Option12Btn, 1);

        public void Option13Btn_Click(object sender, EventArgs e) {
            if (MouseScrolled == 1 || CurrentControl != "Option13Btn") return;

            FPSMode++;

            if (FPSMode == 4 || FPSMode == 0) {
                FPSMode = 0;
                tmp = "FPS Display Mode:             FPS Only";
                Option13Btn.Text = ">" + tmp;
                return;
            }

            if (FPSMode == 1) {
                tmp = "FPS Display Mode:              Verbose";
                Option13Btn.Text = ">" + tmp;
            }
            else if (FPSMode == 2) {
                tmp = "FPS Display Mode: Verbose Percent";
                Option13Btn.Text = ">" + tmp;
            }
            else if (FPSMode == 3) {
                tmp = "FPS Display Mode:              Minimal";
                Option13Btn.Text = ">" + tmp;
            }
        }
        public void Option13Btn_Scroll(object sender, MouseEventArgs e) {
            if (MouseIsDown == 0 || CurrentControl != "Option13Btn") return;

            MouseScrolled = 1;
            if (e.Delta < 0) {
                FPSMode--;
                if (FPSMode < 0 || FPSMode >= 3) {
                    FPSMode = 3;
                    tmp = "FPS Display Mode:              Minimal";
                    Option13Btn.Text = ">" + tmp;
                    return;
                }

                if (FPSMode == 0) {
                    tmp = "FPS Display Mode:             FPS Only";
                    Option13Btn.Text = ">" + tmp;
                }
                else if (FPSMode == 1) {
                    tmp = "FPS Display Mode:              Verbose";
                    Option13Btn.Text = ">" + tmp;
                }
                else if (FPSMode == 2) {
                    tmp = "FPS Display Mode: Verbose Percent";
                    Option13Btn.Text = ">" + tmp;
                }
            }
            else if (e.Delta > 0) {
                FPSMode++;
                if (FPSMode == 4 || FPSMode == 0) {
                    FPSMode = 0;
                    tmp = "FPS Display Mode:             FPS Only";
                    Option13Btn.Text = ">" + tmp;
                    return;
                }

                if (FPSMode == 1) {
                    tmp = "FPS Display Mode:              Verbose";
                    Option13Btn.Text = ">" + tmp;
                }
                if (FPSMode == 2) {
                    tmp = "FPS Display Mode: Verbose Percent";
                    Option13Btn.Text = ">" + tmp;
                }
                if (FPSMode == 3) {
                    tmp = "FPS Display Mode:              Minimal";
                    Option13Btn.Text = ">" + tmp;
                }
            }
        }
        public void Option13BtnMH(object sender, EventArgs e) => HoverLeave(Option13Btn, 0);
        public void Option13BtnML(object sender, EventArgs e) => HoverLeave(Option13Btn, 1);


        Button ConfirmBtn;
        GroupBox MainBox;
        Label Info;
        Label label1;
        Label label4;
        Label MainLabel;
        Button BackBtn;
        Button ExitBtn;
        Button InfoHelpBtn;
        Button MinimizeBtn;
        public System.Windows.Forms.Button Option1Btn;
        public System.Windows.Forms.Button Option2Btn;
        public System.Windows.Forms.Button Option3Btn;
        public System.Windows.Forms.Button Option4Btn;
        public System.Windows.Forms.Button Option5Btn;
        public System.Windows.Forms.Button Option6Btn;
        public System.Windows.Forms.Button Option7Btn;
        public System.Windows.Forms.Button Option8Btn;
        public System.Windows.Forms.Button Option9Btn;

        private void FormMouseDown(object sender, MouseEventArgs e) => MouseIsDown = 1;
        private void FormMouseUp(object sender, MouseEventArgs e) => MouseIsDown = 0;

        public System.Windows.Forms.Button Option10Btn;
        public System.Windows.Forms.Button Option11Btn;
        public System.Windows.Forms.Button Option12Btn;
        public System.Windows.Forms.Button Option13Btn;
    }
}
