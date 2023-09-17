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
        public T2CustomOptionsDebug() { if (Dev.REL) return;
            InitializeComponent();
            AddControlEventHandlers(Controls);
        }

        public bool[] CustomDebugOptions = new bool[11]; //Custom Debug Options - 11th is For Eventually Keeping Track Of Whether The Options Were Left Default (true if changed)
        public byte FPSMode;
        public static float f1, f2;

        public int
            MenuScale,
            MenuOpacity = 2
        ;
        private Label SeperatorLabel2;
        private Label SeperatorLabel1;
        private Label SeperatorLabel0;

        public void Invert(Control Control, int OptionIndex) {
            if (MouseScrolled == 1 || MouseIsDown == 0 || CurrentControl != Control.Name) {
                Dev.DebugOut($"MouseScrolled: {MouseScrolled}\nMouseIsDown: {MouseIsDown}\n CurrentControl: {CurrentControl}\nC.Name: {Control.Name}");
                return;
            }
            TempStringStore = Control.Text;
            CustomDebugOptions[OptionIndex] = !CustomDebugOptions[OptionIndex];
            TempStringStore = $"{TempStringStore.Remove(TempStringStore.LastIndexOf(' '))} {(CustomDebugOptions[OptionIndex] ? "On" : "Off")}";
            Control.Text = TempStringStore;
        }

        public void ConfirmBtn_Click(object sender, EventArgs e) {

            using (FileStream MainStream = new FileStream(@"No Path, Fix.", FileMode.Open, FileAccess.ReadWrite)) {
                MainStream.Read(LocalExecutableCheck, 0, 4);
                switch (Game) {

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

                        if (CustomDebugOptions[0]) WriteBytes(0x25B0BB2, new byte[] { 0x41, 0xc6, 0x85, 0xed, 0x3e, 0x00, 0x00, 0x01 });
                        if (CustomDebugOptions[1]) WriteBytes(0x25B0BBA, new byte[] { 0xc6, 0x05, 0x06, 0x3c, 0xf4, 0x01, 0x01 });
                        if (CustomDebugOptions[2]) WriteBytes(0x25B0BC1, new byte[] { 0xc6, 0x05, 0x03, 0x3c, 0xf4, 0x01, 0x01 });
                        if (CustomDebugOptions[3]) WriteBytes(0x25B0BC8, new byte[] { 0xc6, 0x05, 0x6f, 0xda, 0xca, 0x00, 0x01 });
                        if (CustomDebugOptions[4]) WriteBytes(0x25B0BCF, new byte[] { 0xc6, 0x05, 0x67, 0xda, 0xca, 0x00, 0x01 });
                        if (CustomDebugOptions[5]) WriteBytes(0x25B0BD6, new byte[] { 0xc6, 0x05, 0x5b, 0xda, 0xca, 0x00, 0x01 });
                        if (CustomDebugOptions[6]) WriteBytes(0x25B0BDD, new byte[] { 0xc6, 0x05, 0x48, 0xd2, 0xa9, 0x00, 0x01 });
                        if (!CustomDebugOptions[7]) WriteBytes(0x25B0BE4, new byte[] { 0xc6, 0x05, 0x4e, 0xda, 0xca, 0x00, 0x00 });
                        if (!CustomDebugOptions[8]) WriteBytes(0x25B0BEB, new byte[] { 0xc6, 0x05, 0x48, 0xda, 0xca, 0x00, 0x00 });
                        if (MenuScale != 0) { WriteBytes(0x25B0BF2, new byte[] { 0xc7, 0x05, 0x4c, 0xda, 0xca, 0x00 }); WriteBytes(0x25B0BF8, BitConverter.GetBytes(f1)); }
                        if (MenuOpacity != 2) { WriteBytes(0x25B0BFC, new byte[] { 0xc7, 0x05, 0x3e, 0xda, 0xca, 0x00 }); WriteBytes(0x25B0C02, BitConverter.GetBytes(f2)); }
                        if (CustomDebugOptions[9]) WriteBytes(0x25B0C06, new byte[] { 0x41, 0xc6, 0x85, 0xb8, 0x3a, 0x00, 0x00, 0x01 });
                        if (FPSMode != 0) WriteBytes(0x25B0C0E, new byte[] { 0x41, 0xc7, 0x85, 0xb4, 0x3a, 0x00, 0x00, FPSMode, 0x00, 0x00, 0x00 });
                        if (true)//!!OptionsUnchanged)
                            WriteBytes(0x25B0C19, new byte[] { 0xEB, 0x1E });
                        break;
                }
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
            this.SeperatorLabel0 = new System.Windows.Forms.Label();
            this.SeperatorLabel1 = new System.Windows.Forms.Label();
            this.SeperatorLabel2 = new System.Windows.Forms.Label();
            this.MainBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new Font("Franklin Gothic Medium", 12.25F, FontStyle.Bold);
            this.MainLabel.ForeColor = SystemColors.Control;
            this.MainLabel.Location = new Point(2, 10);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new Size(314, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Custom Debug: Choose Options";
            // 
            // MainBox
            // 
            this.MainBox.Controls.Add(this.SeperatorLabel2);
            this.MainBox.Controls.Add(this.SeperatorLabel1);
            this.MainBox.Controls.Add(this.MainLabel);
            this.MainBox.Controls.Add(this.SeperatorLabel0);
            this.MainBox.Location = new Point(0, -6);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new Size(319, 404);
            this.MainBox.TabIndex = 5;
            this.MainBox.TabStop = false;
            // 
            // Info
            // 
            this.Info.Font = new Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new Point(1, 375);
            this.Info.Name = "Info";
            this.Info.Size = new Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "   All Options Start Set To Their In-Game Defaults";
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = Color.DimGray;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new Font("Franklin Gothic Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = SystemColors.Control;
            this.ExitBtn.Location = new Point(293, 3);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new Size(23, 23);
            this.ExitBtn.TabIndex = 18;
            this.ExitBtn.Text = "X";
            this.ExitBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            this.ExitBtn.MouseEnter += new System.EventHandler(this.ExitBtnMH);
            this.ExitBtn.MouseLeave += new System.EventHandler(this.ExitBtnML);
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.BackColor = Color.DimGray;
            this.MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MinimizeBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBtn.Font = new Font("Franklin Gothic Medium", 8F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBtn.ForeColor = SystemColors.Control;
            this.MinimizeBtn.Location = new Point(270, 3);
            this.MinimizeBtn.Name = "MinimizeBtn";
            this.MinimizeBtn.Size = new Size(23, 23);
            this.MinimizeBtn.TabIndex = 19;
            this.MinimizeBtn.Text = "--";
            this.MinimizeBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.MinimizeBtn.UseVisualStyleBackColor = false;
            this.MinimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            this.MinimizeBtn.MouseEnter += new System.EventHandler(this.MinimizeBtnMH);
            this.MinimizeBtn.MouseLeave += new System.EventHandler(this.MinimizeBtnML);
            // 
            // Option1Btn
            // 
            this.Option1Btn.BackColor = Color.DimGray;
            this.Option1Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option1Btn.FlatAppearance.BorderSize = 0;
            this.Option1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option1Btn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.Option1Btn.ForeColor = SystemColors.Control;
            this.Option1Btn.Location = new Point(1, 32);
            this.Option1Btn.Name = "Option1Btn";
            this.Option1Btn.Size = new Size(170, 23);
            this.Option1Btn.TabIndex = 8;
            this.Option1Btn.Text = "Enable Stat Posting: Off";
            this.Option1Btn.TextAlign = ContentAlignment.MiddleLeft;
            this.Option1Btn.UseVisualStyleBackColor = false;
            this.Option1Btn.Click += new System.EventHandler(this.Option1Btn_Click);
            this.Option1Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option1Btn_SClick);
            this.Option1Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option1Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // Option2Btn
            // 
            this.Option2Btn.BackColor = Color.DimGray;
            this.Option2Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option2Btn.FlatAppearance.BorderSize = 0;
            this.Option2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option2Btn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.Option2Btn.ForeColor = SystemColors.Control;
            this.Option2Btn.Location = new Point(1, 56);
            this.Option2Btn.Name = "Option2Btn";
            this.Option2Btn.Size = new Size(210, 22);
            this.Option2Btn.TabIndex = 20;
            this.Option2Btn.Text = "Show Save Slot On Screen: Off";
            this.Option2Btn.TextAlign = ContentAlignment.MiddleLeft;
            this.Option2Btn.UseVisualStyleBackColor = false;
            this.Option2Btn.Click += new System.EventHandler(this.Option2Btn_Click);
            this.Option2Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option2Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option2Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option2Btn_SClick);
            // 
            // Option3Btn
            // 
            this.Option3Btn.BackColor = Color.DimGray;
            this.Option3Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option3Btn.FlatAppearance.BorderSize = 0;
            this.Option3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option3Btn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.Option3Btn.ForeColor = SystemColors.Control;
            this.Option3Btn.Location = new Point(1, 79);
            this.Option3Btn.Name = "Option3Btn";
            this.Option3Btn.Size = new Size(196, 22);
            this.Option3Btn.TabIndex = 21;
            this.Option3Btn.Text = "Show Game Completion: Off";
            this.Option3Btn.TextAlign = ContentAlignment.MiddleLeft;
            this.Option3Btn.UseVisualStyleBackColor = false;
            this.Option3Btn.Click += new System.EventHandler(this.Option3Btn_Click);
            this.Option3Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option3Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option3Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option3Btn_SClick);
            // 
            // Option4Btn
            // 
            this.Option4Btn.BackColor = Color.DimGray;
            this.Option4Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option4Btn.FlatAppearance.BorderSize = 0;
            this.Option4Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option4Btn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.Option4Btn.ForeColor = SystemColors.Control;
            this.Option4Btn.Location = new Point(1, 103);
            this.Option4Btn.Name = "Option4Btn";
            this.Option4Btn.Size = new Size(206, 23);
            this.Option4Btn.TabIndex = 22;
            this.Option4Btn.Text = "Align Debug Menus Right: Off";
            this.Option4Btn.TextAlign = ContentAlignment.MiddleLeft;
            this.Option4Btn.UseVisualStyleBackColor = false;
            this.Option4Btn.Click += new System.EventHandler(this.Option4Btn_Click);
            this.Option4Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option4Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option4Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option4Btn_SClick);
            // 
            // Option5Btn
            // 
            this.Option5Btn.BackColor = Color.DimGray;
            this.Option5Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option5Btn.FlatAppearance.BorderSize = 0;
            this.Option5Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option5Btn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.Option5Btn.ForeColor = SystemColors.Control;
            this.Option5Btn.Location = new Point(1, 126);
            this.Option5Btn.Name = "Option5Btn";
            this.Option5Btn.Size = new Size(317, 24);
            this.Option5Btn.TabIndex = 23;
            this.Option5Btn.Text = "Swap Square With Circle In Debug Menus: Off";
            this.Option5Btn.TextAlign = ContentAlignment.MiddleLeft;
            this.Option5Btn.UseVisualStyleBackColor = false;
            this.Option5Btn.Click += new System.EventHandler(this.Option5Btn_Click);
            this.Option5Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option5Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option5Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option5Btn_SClick);
            // 
            // Option6Btn
            // 
            this.Option6Btn.BackColor = Color.DimGray;
            this.Option6Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option6Btn.FlatAppearance.BorderSize = 0;
            this.Option6Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option6Btn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.Option6Btn.ForeColor = SystemColors.Control;
            this.Option6Btn.Location = new Point(1, 149);
            this.Option6Btn.Name = "Option6Btn";
            this.Option6Btn.Size = new Size(224, 23);
            this.Option6Btn.TabIndex = 24;
            this.Option6Btn.Text = "Debug Menu Shadowed Text: Off";
            this.Option6Btn.TextAlign = ContentAlignment.MiddleLeft;
            this.Option6Btn.UseVisualStyleBackColor = false;
            this.Option6Btn.Click += new System.EventHandler(this.Option6Btn_Click);
            this.Option6Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option6Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option6Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option6Btn_SClick);
            // 
            // Option7Btn
            // 
            this.Option7Btn.BackColor = Color.DimGray;
            this.Option7Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option7Btn.FlatAppearance.BorderSize = 0;
            this.Option7Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option7Btn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.Option7Btn.ForeColor = SystemColors.Control;
            this.Option7Btn.Location = new Point(1, 173);
            this.Option7Btn.Name = "Option7Btn";
            this.Option7Btn.Size = new Size(219, 23);
            this.Option7Btn.TabIndex = 25;
            this.Option7Btn.Text = "Disable All Visibility (novis): Off";
            this.Option7Btn.TextAlign = ContentAlignment.MiddleLeft;
            this.Option7Btn.UseVisualStyleBackColor = false;
            this.Option7Btn.Click += new System.EventHandler(this.Option7Btn_Click);
            this.Option7Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option7Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option7Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option7Btn_SClick);
            // 
            // Option8Btn
            // 
            this.Option8Btn.BackColor = Color.DimGray;
            this.Option8Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option8Btn.FlatAppearance.BorderSize = 0;
            this.Option8Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option8Btn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.Option8Btn.ForeColor = SystemColors.Control;
            this.Option8Btn.Location = new Point(1, 197);
            this.Option8Btn.Name = "Option8Btn";
            this.Option8Btn.Size = new Size(267, 23);
            this.Option8Btn.TabIndex = 26;
            this.Option8Btn.Text = "Pause Game On Debug Menu Open: On";
            this.Option8Btn.TextAlign = ContentAlignment.MiddleLeft;
            this.Option8Btn.UseVisualStyleBackColor = false;
            this.Option8Btn.Click += new System.EventHandler(this.Option8Btn_Click);
            this.Option8Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option8Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option8Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option8Btn_SClick);
            // 
            // Option9Btn
            // 
            this.Option9Btn.BackColor = Color.DimGray;
            this.Option9Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option9Btn.FlatAppearance.BorderSize = 0;
            this.Option9Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option9Btn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.Option9Btn.ForeColor = SystemColors.Control;
            this.Option9Btn.Location = new Point(1, 221);
            this.Option9Btn.Name = "Option9Btn";
            this.Option9Btn.Size = new Size(270, 23);
            this.Option9Btn.TabIndex = 27;
            this.Option9Btn.Text = "Pause Game On Debug Menu Close: On";
            this.Option9Btn.TextAlign = ContentAlignment.MiddleLeft;
            this.Option9Btn.UseVisualStyleBackColor = false;
            this.Option9Btn.Click += new System.EventHandler(this.Option9Btn_Click);
            this.Option9Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option9Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option9Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option9Btn_SClick);
            // 
            // Option10Btn
            // 
            this.Option10Btn.BackColor = Color.DimGray;
            this.Option10Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option10Btn.FlatAppearance.BorderSize = 0;
            this.Option10Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option10Btn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.Option10Btn.ForeColor = SystemColors.Control;
            this.Option10Btn.Location = new Point(1, 245);
            this.Option10Btn.Name = "Option10Btn";
            this.Option10Btn.Size = new Size(228, 23);
            this.Option10Btn.TabIndex = 28;
            this.Option10Btn.Text = "Debug Menu Scale: 0.6 (Default)";
            this.Option10Btn.TextAlign = ContentAlignment.MiddleLeft;
            this.Option10Btn.UseVisualStyleBackColor = false;
            this.Option10Btn.Click += new System.EventHandler(this.Option10Btn_Click);
            this.Option10Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option10Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option10Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option10Btn_Scroll);
            // 
            // Option11Btn
            // 
            this.Option11Btn.BackColor = Color.DimGray;
            this.Option11Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option11Btn.FlatAppearance.BorderSize = 0;
            this.Option11Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option11Btn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.Option11Btn.ForeColor = SystemColors.Control;
            this.Option11Btn.Location = new Point(1, 269);
            this.Option11Btn.Name = "Option11Btn";
            this.Option11Btn.Size = new Size(284, 23);
            this.Option11Btn.TabIndex = 29;
            this.Option11Btn.Text = "Menu Background Opacity: 0.85 (Default)";
            this.Option11Btn.TextAlign = ContentAlignment.MiddleLeft;
            this.Option11Btn.UseVisualStyleBackColor = false;
            this.Option11Btn.Click += new System.EventHandler(this.Option11Btn_Click);
            this.Option11Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option11Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option11Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option11Btn_Scroll);
            // 
            // Option12Btn
            // 
            this.Option12Btn.BackColor = Color.DimGray;
            this.Option12Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option12Btn.FlatAppearance.BorderSize = 0;
            this.Option12Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option12Btn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.Option12Btn.ForeColor = SystemColors.Control;
            this.Option12Btn.Location = new Point(1, 292);
            this.Option12Btn.Name = "Option12Btn";
            this.Option12Btn.Size = new Size(249, 23);
            this.Option12Btn.TabIndex = 30;
            this.Option12Btn.Text = "Disable FPS + Other Debug Text: Off";
            this.Option12Btn.TextAlign = ContentAlignment.MiddleLeft;
            this.Option12Btn.UseVisualStyleBackColor = false;
            this.Option12Btn.Click += new System.EventHandler(this.Option12Btn_Click);
            this.Option12Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option12Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option12Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option12Btn_SClick);
            // 
            // Option13Btn
            // 
            this.Option13Btn.BackColor = Color.DimGray;
            this.Option13Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Option13Btn.FlatAppearance.BorderSize = 0;
            this.Option13Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Option13Btn.Font = new Font("Franklin Gothic Medium", 9.25F, FontStyle.Bold);
            this.Option13Btn.ForeColor = SystemColors.Control;
            this.Option13Btn.Location = new Point(2, 315);
            this.Option13Btn.Name = "Option13Btn";
            this.Option13Btn.Size = new Size(245, 23);
            this.Option13Btn.TabIndex = 31;
            this.Option13Btn.Text = "FPS Display Mode:             FPS Only";
            this.Option13Btn.TextAlign = ContentAlignment.MiddleLeft;
            this.Option13Btn.UseVisualStyleBackColor = false;
            this.Option13Btn.Click += new System.EventHandler(this.Option13Btn_Click);
            this.Option13Btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Option13Btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.Option13Btn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Option13Btn_Scroll);
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.BackColor = Color.DimGray;
            this.ConfirmBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ConfirmBtn.FlatAppearance.BorderSize = 0;
            this.ConfirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmBtn.Font = new Font("Franklin Gothic Medium", 10.25F, FontStyle.Bold);
            this.ConfirmBtn.ForeColor = SystemColors.Control;
            this.ConfirmBtn.Location = new Point(1, 343);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new Size(216, 24);
            this.ConfirmBtn.TabIndex = 32;
            this.ConfirmBtn.Text = "Confirm Options And Finish...";
            this.ConfirmBtn.TextAlign = ContentAlignment.MiddleLeft;
            this.ConfirmBtn.UseVisualStyleBackColor = false;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // SeperatorLabel0
            // 
            this.SeperatorLabel0.Font = new Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel0.ForeColor = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel0.Location = new Point(2, 21);
            this.SeperatorLabel0.Name = "SeperatorLabel0";
            this.SeperatorLabel0.Size = new Size(316, 20);
            this.SeperatorLabel0.TabIndex = 34;
            this.SeperatorLabel0.Text = "____________________________________________";
            // 
            // SeperatorLabel1
            // 
            this.SeperatorLabel1.Font = new Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel1.ForeColor = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel1.Location = new Point(2, 333);
            this.SeperatorLabel1.Name = "SeperatorLabel1";
            this.SeperatorLabel1.Size = new Size(316, 20);
            this.SeperatorLabel1.TabIndex = 35;
            this.SeperatorLabel1.Text = "____________________________________________";
            // 
            // SeperatorLabel2
            // 
            this.SeperatorLabel2.Font = new Font("Franklin Gothic Medium", 10F);
            this.SeperatorLabel2.ForeColor = Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLabel2.Location = new Point(2, 361);
            this.SeperatorLabel2.Name = "SeperatorLabel2";
            this.SeperatorLabel2.Size = new Size(316, 20);
            this.SeperatorLabel2.TabIndex = 36;
            this.SeperatorLabel2.Text = "____________________________________________";
            // 
            // T2CustomOptionsDebug
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.DimGray;
            this.ClientSize = new Size(319, 397);
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

        public void Option2Btn_SClick(object sender, EventArgs e) {
            Option2Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option2Btn_Click(object sender, EventArgs e) => Invert(Option2Btn, 1);

        public void Option3Btn_SClick(object sender, EventArgs e) {
            Option3Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option3Btn_Click(object sender, EventArgs e) => Invert(Option3Btn, 2);

        public void Option4Btn_SClick(object sender, EventArgs e) {
            Option4Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option4Btn_Click(object sender, EventArgs e) => Invert(Option4Btn, 3);

        public void Option5Btn_SClick(object sender, EventArgs e) {
            Option5Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option5Btn_Click(object sender, EventArgs e) => Invert(Option5Btn, 4);

        public void Option6Btn_SClick(object sender, EventArgs e) {
            Option6Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option6Btn_Click(object sender, EventArgs e) => Invert(Option6Btn, 5);

        public void Option7Btn_SClick(object sender, EventArgs e) {
            Option7Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option7Btn_Click(object sender, EventArgs e) => Invert(Option7Btn, 6);

        public void Option8Btn_SClick(object sender, EventArgs e) {
            Option8Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option8Btn_Click(object sender, EventArgs e) => Invert(Option8Btn, 7);

        public void Option9Btn_SClick(object sender, EventArgs e) {
            Option9Btn_Click(sender, e); MouseScrolled = 1;
        }
        public void Option9Btn_Click(object sender, EventArgs e) => Invert(Option9Btn, 8);

        public void Option10Btn_Click(object sender, EventArgs e) {
            if (MouseScrolled == 1) return;
            if (MenuScale < 2) {
                MenuScale++;
            }
            else {
                MenuScale = 0;
                TempStringStore = "Set Debug Menu Scale: 0.6 (Small)";
                f1 = 0.6f;
                Option10Btn.Text = ">" + TempStringStore;
                return;
            }

            if (MenuScale == 1) {
                TempStringStore = "Set Debug Menu Scale: 0.7 (Medium)";
                f1 = 0.7f;
                Option10Btn.Text = ">" + TempStringStore;
            }
            else if (MenuScale == 2) {
                TempStringStore = "Set Debug Menu Scale: 0.8 (Large)";
                f1 = 0.8f;
                Option10Btn.Text = ">" + TempStringStore;
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
                    TempStringStore = "Set Debug Menu Scale: 0.8 (Large)";
                    Option10Btn.Text = ">" + TempStringStore;
                    return;
                }

                if (MenuScale == 0) {
                    f1 = 0.6f;
                    TempStringStore = "Set Debug Menu Scale: 0.6 (Small)";
                    Option10Btn.Text = ">" + TempStringStore;
                }
                else if (MenuScale == 1) {
                    f1 = 0.7f;
                    TempStringStore = "Set Debug Menu Scale: 0.7 (Medium)";
                    Option10Btn.Text = ">" + TempStringStore;
                }
            }
            else if (e.Delta > 0) {
                MenuScale++;
                if (MenuScale == 3 || MenuScale == 0) {
                    f1 = 0.6f;
                    MenuScale = 0;
                    TempStringStore = "Set Debug Menu Scale: 0.6 (Small)";
                    Option10Btn.Text = ">" + TempStringStore;
                    return;
                }

                if (MenuScale == 1) {
                    f1 = 0.7f;
                    TempStringStore = "Set Debug Menu Scale: 0.7 (Medium)";
                    Option10Btn.Text = ">" + TempStringStore;
                }
                if (MenuScale == 2) {
                    f1 = 0.8f;
                    TempStringStore = "Set Debug Menu Scale: 0.8 (Large)";
                    Option10Btn.Text = ">" + TempStringStore;
                }
            }
        }

        public void Option11Btn_Click(object sender, EventArgs e) {
            if (MouseScrolled == 1 || CurrentControl != "Option11Btn") return;

            MenuOpacity++;

            if (MenuOpacity == 4 || MenuOpacity == 0) {
                f2 = 0F;
                MenuOpacity = 0;
                TempStringStore = "Menu Background Opacity:         0 - No BG";
                Option11Btn.Text = ">" + TempStringStore;
                return;
            }

            if (MenuOpacity == 1) {
                f2 = 0.45F;
                TempStringStore = "Menu Background Opacity:                0.45";
                Option11Btn.Text = ">" + TempStringStore;
            }
            else if (MenuOpacity == 2) {
                f2 = 0.85F;
                TempStringStore = "Menu Background Opacity: 0.85 (Default)";
                Option11Btn.Text = ">" + TempStringStore;
            }
            else if (MenuOpacity == 3) {
                f2 = 1F;
                TempStringStore = "Menu Background Opacity:                1.00";
                Option11Btn.Text = ">" + TempStringStore;
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
                    TempStringStore = "Menu Background Opacity:                1.00";
                    Option11Btn.Text = ">" + TempStringStore;
                    return;
                }

                if (MenuOpacity == 0) {
                    f2 = 0F;
                    TempStringStore = "Menu Background Opacity:         0 - No BG";
                    Option11Btn.Text = ">" + TempStringStore;
                }
                else if (MenuOpacity == 1) {
                    f2 = 0.45F;
                    TempStringStore = "Menu Background Opacity:                0.45";
                    Option11Btn.Text = ">" + TempStringStore;
                }
                else if (MenuOpacity == 2) {
                    f2 = 0.85F;
                    TempStringStore = "Menu Background Opacity: 0.85 (Default)";
                    Option11Btn.Text = ">" + TempStringStore;
                }
            }
            else if (e.Delta > 0) {
                MenuOpacity++;
                if (MenuOpacity == 4 || MenuOpacity == 0) {
                    MenuOpacity = 0;
                    f2 = 0F;
                    TempStringStore = "Menu Background Opacity:         0 - No BG";
                    Option11Btn.Text = ">" + TempStringStore;
                    return;
                }

                if (MenuOpacity == 1) {
                    f2 = 0.45F;
                    TempStringStore = "Menu Background Opacity:                0.45";
                    Option11Btn.Text = ">" + TempStringStore;
                }
                if (MenuOpacity == 2) {
                    f2 = 0.85F;
                    TempStringStore = "Menu Background Opacity: 0.85 (Default)";
                    Option11Btn.Text = ">" + TempStringStore;
                }
                if (MenuOpacity == 3) {
                    f2 = 1F;
                    TempStringStore = "Menu Background Opacity:                1.00";
                    Option11Btn.Text = ">" + TempStringStore;
                }
            }
        }

        public void Option12Btn_SClick(object sender, EventArgs e) {
            Option12Btn_Click(sender, e); MouseScrolled = 1; // Can Ya Tell I Don't Know What The Hell I'm Doing Yet?
        }
        public void Option12Btn_Click(object sender, EventArgs e) => Invert(Option12Btn, 9);

        public void Option13Btn_Click(object sender, EventArgs e) {
            if (MouseScrolled == 1 || CurrentControl != "Option13Btn") return;

            FPSMode++;

            if (FPSMode == 4 || FPSMode == 0) {
                FPSMode = 0;
                TempStringStore = "FPS Display Mode:             FPS Only";
                Option13Btn.Text = ">" + TempStringStore;
                return;
            }

            if (FPSMode == 1) {
                TempStringStore = "FPS Display Mode:              Verbose";
                Option13Btn.Text = ">" + TempStringStore;
            }
            else if (FPSMode == 2) {
                TempStringStore = "FPS Display Mode: Verbose Percent";
                Option13Btn.Text = ">" + TempStringStore;
            }
            else if (FPSMode == 3) {
                TempStringStore = "FPS Display Mode:              Minimal";
                Option13Btn.Text = ">" + TempStringStore;
            }
        }
        public void Option13Btn_Scroll(object sender, MouseEventArgs e) {
            if (MouseIsDown == 0 || CurrentControl != "Option13Btn") return;

            MouseScrolled = 1;
            if (e.Delta < 0) {
                FPSMode--;
                if (FPSMode < 0 || FPSMode >= 3) {
                    FPSMode = 3;
                    TempStringStore = "FPS Display Mode:              Minimal";
                    Option13Btn.Text = ">" + TempStringStore;
                    return;
                }

                if (FPSMode == 0) {
                    TempStringStore = "FPS Display Mode:             FPS Only";
                    Option13Btn.Text = ">" + TempStringStore;
                }
                else if (FPSMode == 1) {
                    TempStringStore = "FPS Display Mode:              Verbose";
                    Option13Btn.Text = ">" + TempStringStore;
                }
                else if (FPSMode == 2) {
                    TempStringStore = "FPS Display Mode: Verbose Percent";
                    Option13Btn.Text = ">" + TempStringStore;
                }
            }
            else if (e.Delta > 0) {
                FPSMode++;
                if (FPSMode == 4 || FPSMode == 0) {
                    FPSMode = 0;
                    TempStringStore = "FPS Display Mode:             FPS Only";
                    Option13Btn.Text = ">" + TempStringStore;
                    return;
                }

                if (FPSMode == 1) {
                    TempStringStore = "FPS Display Mode:              Verbose";
                    Option13Btn.Text = ">" + TempStringStore;
                }
                if (FPSMode == 2) {
                    TempStringStore = "FPS Display Mode: Verbose Percent";
                    Option13Btn.Text = ">" + TempStringStore;
                }
                if (FPSMode == 3) {
                    TempStringStore = "FPS Display Mode:              Minimal";
                    Option13Btn.Text = ">" + TempStringStore;
                }
            }
        }


        Button ConfirmBtn;
        GroupBox MainBox;
        Label Info;
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
