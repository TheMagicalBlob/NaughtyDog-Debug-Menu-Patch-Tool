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
        public void ExtraBtn2MH(object sender, EventArgs e) => HoverLeave(ExtraBtn, 0);
        public void ExtraBtn2ML(object sender, EventArgs e) => HoverLeave(ExtraBtn, 30);
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
            MainLabel = new System.Windows.Forms.Label();
            MainBox = new System.Windows.Forms.GroupBox();
            Info = new System.Windows.Forms.Label();
            ExitBtn = new System.Windows.Forms.Button();
            MinimizeBtn = new System.Windows.Forms.Button();
            Option1Btn = new System.Windows.Forms.Button();
            Option2Btn = new System.Windows.Forms.Button();
            Option3Btn = new System.Windows.Forms.Button();
            Option4Btn = new System.Windows.Forms.Button();
            Option5Btn = new System.Windows.Forms.Button();
            Option6Btn = new System.Windows.Forms.Button();
            Option7Btn = new System.Windows.Forms.Button();
            Option8Btn = new System.Windows.Forms.Button();
            Option9Btn = new System.Windows.Forms.Button();
            Option10Btn = new System.Windows.Forms.Button();
            Option11Btn = new System.Windows.Forms.Button();
            Option12Btn = new System.Windows.Forms.Button();
            Option13Btn = new System.Windows.Forms.Button();
            ExtraBtn = new System.Windows.Forms.Button();
            ConfirmBtn = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            MainBox.SuspendLayout();
            SuspendLayout();
            // 
            // MainLabel
            // 
            MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            MainLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.25F, System.Drawing.FontStyle.Bold);
            MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            MainLabel.Location = new System.Drawing.Point(2, 7);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new System.Drawing.Size(314, 22);
            MainLabel.TabIndex = 0;
            MainLabel.Text = "Custom Debug: Choose Options";
            // 
            // MainBox
            // 
            MainBox.Controls.Add(MainLabel);
            MainBox.Location = new System.Drawing.Point(3, 22);
            MainBox.Name = "MainBox";
            MainBox.Size = new System.Drawing.Size(317, 32);
            MainBox.TabIndex = 5;
            MainBox.TabStop = false;
            // 
            // Info
            // 
            Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            Info.Location = new System.Drawing.Point(1, 426);
            Info.Name = "Info";
            Info.Size = new System.Drawing.Size(304, 17);
            Info.TabIndex = 7;
            Info.Text = "   All Options Start Set To Their In-Game Defaults";
            // 
            // ExitBtn
            // 
            ExitBtn.BackColor = System.Drawing.Color.DimGray;
            ExitBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            ExitBtn.FlatAppearance.BorderSize = 0;
            ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ExitBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ExitBtn.ForeColor = System.Drawing.SystemColors.Control;
            ExitBtn.Location = new System.Drawing.Point(285, 0);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.Size = new System.Drawing.Size(23, 23);
            ExitBtn.TabIndex = 18;
            ExitBtn.Text = "X";
            ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ExitBtn.UseVisualStyleBackColor = false;
            ExitBtn.Click += new System.EventHandler(ExitBtn_Click);
            ExitBtn.MouseEnter += new System.EventHandler(ExitBtnMH);
            ExitBtn.MouseLeave += new System.EventHandler(ExitBtnML);
            // 
            // MinimizeBtn
            // 
            MinimizeBtn.BackColor = System.Drawing.Color.DimGray;
            MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            MinimizeBtn.FlatAppearance.BorderSize = 0;
            MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            MinimizeBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            MinimizeBtn.ForeColor = System.Drawing.SystemColors.Control;
            MinimizeBtn.Location = new System.Drawing.Point(262, 0);
            MinimizeBtn.Name = "MinimizeBtn";
            MinimizeBtn.Size = new System.Drawing.Size(23, 23);
            MinimizeBtn.TabIndex = 19;
            MinimizeBtn.Text = "--";
            MinimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            MinimizeBtn.UseVisualStyleBackColor = false;
            MinimizeBtn.Click += new System.EventHandler(MinimizeBtn_Click);
            MinimizeBtn.MouseEnter += new System.EventHandler(MinimizeBtnMH);
            MinimizeBtn.MouseLeave += new System.EventHandler(MinimizeBtnML);
            // 
            // Option1Btn
            // 
            Option1Btn.BackColor = System.Drawing.Color.DimGray;
            Option1Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            Option1Btn.FlatAppearance.BorderSize = 0;
            Option1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Option1Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            Option1Btn.ForeColor = System.Drawing.SystemColors.Control;
            Option1Btn.Location = new System.Drawing.Point(-5, 57);
            Option1Btn.Name = "Option1Btn";
            Option1Btn.Size = new System.Drawing.Size(170, 23);
            Option1Btn.TabIndex = 8;
            Option1Btn.Text = "Enable Stat Posting: Off";
            Option1Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Option1Btn.UseVisualStyleBackColor = false;
            Option1Btn.Click += new System.EventHandler(Option1Btn_Click);
            Option1Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownFunc);
            Option1Btn.MouseEnter += new System.EventHandler(Option1BtnMH);
            Option1Btn.MouseLeave += new System.EventHandler(Option1BtnML);
            Option1Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUpFunc);
            Option1Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(Option1Btn_SClick);
            // 
            // Option2Btn
            // 
            Option2Btn.BackColor = System.Drawing.Color.DimGray;
            Option2Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            Option2Btn.FlatAppearance.BorderSize = 0;
            Option2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Option2Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            Option2Btn.ForeColor = System.Drawing.SystemColors.Control;
            Option2Btn.Location = new System.Drawing.Point(-5, 81);
            Option2Btn.Name = "Option2Btn";
            Option2Btn.Size = new System.Drawing.Size(210, 22);
            Option2Btn.TabIndex = 20;
            Option2Btn.Text = "Show Save Slot On Screen: Off";
            Option2Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Option2Btn.UseVisualStyleBackColor = false;
            Option2Btn.Click += new System.EventHandler(Option2Btn_Click);
            Option2Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownFunc);
            Option2Btn.MouseEnter += new System.EventHandler(Option2BtnMH);
            Option2Btn.MouseLeave += new System.EventHandler(Option2BtnML);
            Option2Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUpFunc);
            Option2Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(Option2Btn_SClick);
            // 
            // Option3Btn
            // 
            Option3Btn.BackColor = System.Drawing.Color.DimGray;
            Option3Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            Option3Btn.FlatAppearance.BorderSize = 0;
            Option3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Option3Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            Option3Btn.ForeColor = System.Drawing.SystemColors.Control;
            Option3Btn.Location = new System.Drawing.Point(-5, 104);
            Option3Btn.Name = "Option3Btn";
            Option3Btn.Size = new System.Drawing.Size(196, 22);
            Option3Btn.TabIndex = 21;
            Option3Btn.Text = "Show Game Completion: Off";
            Option3Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Option3Btn.UseVisualStyleBackColor = false;
            Option3Btn.Click += new System.EventHandler(Option3Btn_Click);
            Option3Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownFunc);
            Option3Btn.MouseEnter += new System.EventHandler(Option3BtnMH);
            Option3Btn.MouseLeave += new System.EventHandler(Option3BtnML);
            Option3Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUpFunc);
            Option3Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(Option3Btn_SClick);
            // 
            // Option4Btn
            // 
            Option4Btn.BackColor = System.Drawing.Color.DimGray;
            Option4Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            Option4Btn.FlatAppearance.BorderSize = 0;
            Option4Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Option4Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            Option4Btn.ForeColor = System.Drawing.SystemColors.Control;
            Option4Btn.Location = new System.Drawing.Point(-5, 128);
            Option4Btn.Name = "Option4Btn";
            Option4Btn.Size = new System.Drawing.Size(206, 23);
            Option4Btn.TabIndex = 22;
            Option4Btn.Text = "Align Debug Menus Right: Off";
            Option4Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Option4Btn.UseVisualStyleBackColor = false;
            Option4Btn.Click += new System.EventHandler(Option4Btn_Click);
            Option4Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownFunc);
            Option4Btn.MouseEnter += new System.EventHandler(Option4BtnMH);
            Option4Btn.MouseLeave += new System.EventHandler(Option4BtnML);
            Option4Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUpFunc);
            Option4Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(Option4Btn_SClick);
            // 
            // Option5Btn
            // 
            Option5Btn.BackColor = System.Drawing.Color.DimGray;
            Option5Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            Option5Btn.FlatAppearance.BorderSize = 0;
            Option5Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Option5Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            Option5Btn.ForeColor = System.Drawing.SystemColors.Control;
            Option5Btn.Location = new System.Drawing.Point(-5, 151);
            Option5Btn.Name = "Option5Btn";
            Option5Btn.Size = new System.Drawing.Size(317, 24);
            Option5Btn.TabIndex = 23;
            Option5Btn.Text = "Swap Square With Circle In Debug Menus: Off";
            Option5Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Option5Btn.UseVisualStyleBackColor = false;
            Option5Btn.Click += new System.EventHandler(Option5Btn_Click);
            Option5Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownFunc);
            Option5Btn.MouseEnter += new System.EventHandler(Option5BtnMH);
            Option5Btn.MouseLeave += new System.EventHandler(Option5BtnML);
            Option5Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUpFunc);
            Option5Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(Option5Btn_SClick);
            // 
            // Option6Btn
            // 
            Option6Btn.BackColor = System.Drawing.Color.DimGray;
            Option6Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            Option6Btn.FlatAppearance.BorderSize = 0;
            Option6Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Option6Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            Option6Btn.ForeColor = System.Drawing.SystemColors.Control;
            Option6Btn.Location = new System.Drawing.Point(-5, 174);
            Option6Btn.Name = "Option6Btn";
            Option6Btn.Size = new System.Drawing.Size(224, 23);
            Option6Btn.TabIndex = 24;
            Option6Btn.Text = "Debug Menu Shadowed Text: Off";
            Option6Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Option6Btn.UseVisualStyleBackColor = false;
            Option6Btn.Click += new System.EventHandler(Option6Btn_Click);
            Option6Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownFunc);
            Option6Btn.MouseEnter += new System.EventHandler(Option6BtnMH);
            Option6Btn.MouseLeave += new System.EventHandler(Option6BtnML);
            Option6Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUpFunc);
            Option6Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(Option6Btn_SClick);
            // 
            // Option7Btn
            // 
            Option7Btn.BackColor = System.Drawing.Color.DimGray;
            Option7Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            Option7Btn.FlatAppearance.BorderSize = 0;
            Option7Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Option7Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            Option7Btn.ForeColor = System.Drawing.SystemColors.Control;
            Option7Btn.Location = new System.Drawing.Point(-5, 198);
            Option7Btn.Name = "Option7Btn";
            Option7Btn.Size = new System.Drawing.Size(219, 23);
            Option7Btn.TabIndex = 25;
            Option7Btn.Text = "Disable All Visibility (novis): Off";
            Option7Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Option7Btn.UseVisualStyleBackColor = false;
            Option7Btn.Click += new System.EventHandler(Option7Btn_Click);
            Option7Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownFunc);
            Option7Btn.MouseEnter += new System.EventHandler(Option7BtnMH);
            Option7Btn.MouseLeave += new System.EventHandler(Option7BtnML);
            Option7Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUpFunc);
            Option7Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(Option7Btn_SClick);
            // 
            // Option8Btn
            // 
            Option8Btn.BackColor = System.Drawing.Color.DimGray;
            Option8Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            Option8Btn.FlatAppearance.BorderSize = 0;
            Option8Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Option8Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            Option8Btn.ForeColor = System.Drawing.SystemColors.Control;
            Option8Btn.Location = new System.Drawing.Point(-5, 222);
            Option8Btn.Name = "Option8Btn";
            Option8Btn.Size = new System.Drawing.Size(267, 23);
            Option8Btn.TabIndex = 26;
            Option8Btn.Text = "Pause Game On Debug Menu Open: On";
            Option8Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Option8Btn.UseVisualStyleBackColor = false;
            Option8Btn.Click += new System.EventHandler(Option8Btn_Click);
            Option8Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownFunc);
            Option8Btn.MouseEnter += new System.EventHandler(Option8BtnMH);
            Option8Btn.MouseLeave += new System.EventHandler(Option8BtnML);
            Option8Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUpFunc);
            Option8Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(Option8Btn_SClick);
            // 
            // Option9Btn
            // 
            Option9Btn.BackColor = System.Drawing.Color.DimGray;
            Option9Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            Option9Btn.FlatAppearance.BorderSize = 0;
            Option9Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Option9Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            Option9Btn.ForeColor = System.Drawing.SystemColors.Control;
            Option9Btn.Location = new System.Drawing.Point(-5, 246);
            Option9Btn.Name = "Option9Btn";
            Option9Btn.Size = new System.Drawing.Size(270, 23);
            Option9Btn.TabIndex = 27;
            Option9Btn.Text = "Pause Game On Debug Menu Close: On";
            Option9Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Option9Btn.UseVisualStyleBackColor = false;
            Option9Btn.Click += new System.EventHandler(Option9Btn_Click);
            Option9Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownFunc);
            Option9Btn.MouseEnter += new System.EventHandler(Option9BtnMH);
            Option9Btn.MouseLeave += new System.EventHandler(Option9BtnML);
            Option9Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUpFunc);
            Option9Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(Option9Btn_SClick);
            // 
            // Option10Btn
            // 
            Option10Btn.BackColor = System.Drawing.Color.DimGray;
            Option10Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            Option10Btn.FlatAppearance.BorderSize = 0;
            Option10Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Option10Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            Option10Btn.ForeColor = System.Drawing.SystemColors.Control;
            Option10Btn.Location = new System.Drawing.Point(-5, 270);
            Option10Btn.Name = "Option10Btn";
            Option10Btn.Size = new System.Drawing.Size(228, 23);
            Option10Btn.TabIndex = 28;
            Option10Btn.Text = "Debug Menu Scale: 0.6 (Default)";
            Option10Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Option10Btn.UseVisualStyleBackColor = false;
            Option10Btn.Click += new System.EventHandler(Option10Btn_Click);
            Option10Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownFunc);
            Option10Btn.MouseEnter += new System.EventHandler(Option10BtnMH);
            Option10Btn.MouseLeave += new System.EventHandler(Option10BtnML);
            Option10Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUpFunc);
            Option10Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(Option10Btn_Scroll);
            // 
            // Option11Btn
            // 
            Option11Btn.BackColor = System.Drawing.Color.DimGray;
            Option11Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            Option11Btn.FlatAppearance.BorderSize = 0;
            Option11Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Option11Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            Option11Btn.ForeColor = System.Drawing.SystemColors.Control;
            Option11Btn.Location = new System.Drawing.Point(-5, 294);
            Option11Btn.Name = "Option11Btn";
            Option11Btn.Size = new System.Drawing.Size(284, 23);
            Option11Btn.TabIndex = 29;
            Option11Btn.Text = "Menu Background Opacity: 0.85 (Default)";
            Option11Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Option11Btn.UseVisualStyleBackColor = false;
            Option11Btn.Click += new System.EventHandler(Option11Btn_Click);
            Option11Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownFunc);
            Option11Btn.MouseEnter += new System.EventHandler(Option11BtnMH);
            Option11Btn.MouseLeave += new System.EventHandler(Option11BtnML);
            Option11Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUpFunc);
            Option11Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(Option11Btn_Scroll);
            // 
            // Option12Btn
            // 
            Option12Btn.BackColor = System.Drawing.Color.DimGray;
            Option12Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            Option12Btn.FlatAppearance.BorderSize = 0;
            Option12Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Option12Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            Option12Btn.ForeColor = System.Drawing.SystemColors.Control;
            Option12Btn.Location = new System.Drawing.Point(-5, 318);
            Option12Btn.Name = "Option12Btn";
            Option12Btn.Size = new System.Drawing.Size(249, 23);
            Option12Btn.TabIndex = 30;
            Option12Btn.Text = "Disable FPS + Other Debug Text: Off";
            Option12Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Option12Btn.UseVisualStyleBackColor = false;
            Option12Btn.Click += new System.EventHandler(Option12Btn_Click);
            Option12Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownFunc);
            Option12Btn.MouseEnter += new System.EventHandler(Option12BtnMH);
            Option12Btn.MouseLeave += new System.EventHandler(Option12BtnML);
            Option12Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUpFunc);
            Option12Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(Option12Btn_SClick);
            // 
            // Option13Btn
            // 
            Option13Btn.BackColor = System.Drawing.Color.DimGray;
            Option13Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            Option13Btn.FlatAppearance.BorderSize = 0;
            Option13Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Option13Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            Option13Btn.ForeColor = System.Drawing.SystemColors.Control;
            Option13Btn.Location = new System.Drawing.Point(-4, 342);
            Option13Btn.Name = "Option13Btn";
            Option13Btn.Size = new System.Drawing.Size(245, 23);
            Option13Btn.TabIndex = 31;
            Option13Btn.Text = "FPS Display Mode:             FPS Only";
            Option13Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            Option13Btn.UseVisualStyleBackColor = false;
            Option13Btn.Click += new System.EventHandler(Option13Btn_Click);
            Option13Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownFunc);
            Option13Btn.MouseEnter += new System.EventHandler(Option13BtnMH);
            Option13Btn.MouseLeave += new System.EventHandler(Option13BtnML);
            Option13Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(MouseUpFunc);
            Option13Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(Option13Btn_Scroll);
            // 
            // ExtraBtn
            // 
            ExtraBtn.Location = new System.Drawing.Point(0, 0);
            ExtraBtn.Name = "ExtraBtn";
            ExtraBtn.Size = new System.Drawing.Size(75, 23);
            ExtraBtn.TabIndex = 33;
            // 
            // ConfirmBtn
            // 
            ConfirmBtn.BackColor = System.Drawing.Color.DimGray;
            ConfirmBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            ConfirmBtn.FlatAppearance.BorderSize = 0;
            ConfirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ConfirmBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.25F, System.Drawing.FontStyle.Bold);
            ConfirmBtn.ForeColor = System.Drawing.SystemColors.Control;
            ConfirmBtn.Location = new System.Drawing.Point(-5, 375);
            ConfirmBtn.Name = "ConfirmBtn";
            ConfirmBtn.Size = new System.Drawing.Size(216, 24);
            ConfirmBtn.TabIndex = 32;
            ConfirmBtn.Text = "Confirm Options And Finish...";
            ConfirmBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ConfirmBtn.UseVisualStyleBackColor = false;
            ConfirmBtn.Click += new System.EventHandler(ConfirmBtn_Click);
            ConfirmBtn.MouseEnter += new System.EventHandler(ConfirmBtnMH);
            ConfirmBtn.MouseLeave += new System.EventHandler(ConfirmBtnML);
            // 
            // label1
            // 
            label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.25F);
            label1.ForeColor = System.Drawing.SystemColors.Control;
            label1.Location = new System.Drawing.Point(-4, 354);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(324, 22);
            label1.TabIndex = 1;
            label1.Text = "________________________________________________________________";
            // 
            // T2CustomOptionsDebug
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.DimGray;
            ClientSize = new System.Drawing.Size(320, 449);
            Controls.Add(ConfirmBtn);
            Controls.Add(Option13Btn);
            Controls.Add(Option12Btn);
            Controls.Add(Option11Btn);
            Controls.Add(Option10Btn);
            Controls.Add(Option9Btn);
            Controls.Add(Option8Btn);
            Controls.Add(Option7Btn);
            Controls.Add(Option6Btn);
            Controls.Add(Option5Btn);
            Controls.Add(Option4Btn);
            Controls.Add(Option3Btn);
            Controls.Add(Option2Btn);
            Controls.Add(MinimizeBtn);
            Controls.Add(ExitBtn);
            Controls.Add(ExtraBtn);
            Controls.Add(Option1Btn);
            Controls.Add(Info);
            Controls.Add(MainBox);
            Controls.Add(label1);
            Cursor = System.Windows.Forms.Cursors.Default;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "T2CustomOptionsDebug";
            Text = "Main";
            MouseDown += new MouseEventHandler(FormMouseDown);
            MouseUp += new System.Windows.Forms.MouseEventHandler(FormMouseUp);
            MainBox.ResumeLayout(false);
            ResumeLayout(false);

        }
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
        Button ExtraBtn;
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
