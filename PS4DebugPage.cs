using libdebug;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Drawing;
using System.Net.Sockets;
using static Dobby.Common;
using System.Windows.Forms;

namespace Dobby {
    public class PS4DebugPage : Form {

        public PS4DebugPage() {
            InitializeComponent();
            IPBOX_E.Text = IP();
            PortBox.Text = Port().ToString();
            if (!Dev.REL) PageInfo(Controls);
            SetPageInfo(this);
        }

        PS4DBG geo = new PS4DBG(IPAddress.Parse("127.0.0.1"));

        readonly byte
            on = 0x01,
            off = 0x00
        ;

        bool PS4DebugIsConnected;

        int
            exec,
            attempts = 0
        ;

        readonly string[] executables = new string[] {
            "eboot.bin",
            "t2.elf",
            "t2-rtm.elf",
            "t2-final.elf",
            "t2-final-pgo-lto.elf",
            "big2-ps4_Shipping.elf",
            "big3-ps4_Shipping.elf",
            "big4.elf",
            "big4-",
            "big4-mp.elf",
            "big4-final-pgo-lto.elf",
            "eboot-mp.elf",
        };
        public Label SeperatorLine1;
        public static string processname = "Jack Shit";

        public void InitializeComponent() {
            this.MainLabel = new System.Windows.Forms.Label();
            this.TLL100Btn = new System.Windows.Forms.Button();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.ManualConnectBtn = new System.Windows.Forms.Button();
            this.IPBOX_E = new System.Windows.Forms.TextBox();
            this.Info = new System.Windows.Forms.Label();
            this.T1RBtn = new System.Windows.Forms.Button();
            this.T2100Btn = new System.Windows.Forms.Button();
            this.UC4100Btn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.UC1Btn = new System.Windows.Forms.Button();
            this.UC2Btn = new System.Windows.Forms.Button();
            this.UC3Btn = new System.Windows.Forms.Button();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.DebugPayloadBtn = new System.Windows.Forms.Button();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.IPLabelBtn = new System.Windows.Forms.Button();
            this.PortLabelBtn = new System.Windows.Forms.Button();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.UC4MPBetaBtn = new System.Windows.Forms.Button();
            this.MainBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.25F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(1, 9);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(314, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "PS4Debug Menu";
            this.MainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MainLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // TLL100Btn
            // 
            this.TLL100Btn.BackColor = System.Drawing.Color.DimGray;
            this.TLL100Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.TLL100Btn.FlatAppearance.BorderSize = 0;
            this.TLL100Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TLL100Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.TLL100Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.TLL100Btn.Location = new System.Drawing.Point(1, 192);
            this.TLL100Btn.Name = "TLL100Btn";
            this.TLL100Btn.Size = new System.Drawing.Size(192, 23);
            this.TLL100Btn.TabIndex = 0;
            this.TLL100Btn.Text = "Uncharted: The Lost Legacy";
            this.TLL100Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TLL100Btn.UseVisualStyleBackColor = false;
            this.TLL100Btn.Click += new System.EventHandler(this.TLL100);
            this.TLL100Btn.MouseEnter += new System.EventHandler(this.TLL100MH);
            this.TLL100Btn.MouseLeave += new System.EventHandler(this.TLL100ML);
            // 
            // MainBox
            // 
            this.MainBox.Controls.Add(this.MinimizeBtn);
            this.MainBox.Controls.Add(this.ExitBtn);
            this.MainBox.Controls.Add(this.MainLabel);
            this.MainBox.Controls.Add(this.SeperatorLine1);
            this.MainBox.Location = new System.Drawing.Point(0, -6);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(320, 420);
            this.MainBox.TabIndex = 5;
            this.MainBox.TabStop = false;
            this.MainBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MainBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.MainBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            // 
            // MinimizeBtn
            // 
            this.MinimizeBtn.BackColor = System.Drawing.Color.DimGray;
            this.MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MinimizeBtn.FlatAppearance.BorderSize = 0;
            this.MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimizeBtn.Location = new System.Drawing.Point(273, 7);
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
            this.ExitBtn.Location = new System.Drawing.Point(296, 7);
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
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 19);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine1.TabIndex = 30;
            this.SeperatorLine1.Text = "______________________________________________________________";
            // 
            // ManualConnectBtn
            // 
            this.ManualConnectBtn.BackColor = System.Drawing.Color.DimGray;
            this.ManualConnectBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ManualConnectBtn.FlatAppearance.BorderSize = 0;
            this.ManualConnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManualConnectBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.ManualConnectBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ManualConnectBtn.Location = new System.Drawing.Point(1, 293);
            this.ManualConnectBtn.Name = "ManualConnectBtn";
            this.ManualConnectBtn.Size = new System.Drawing.Size(164, 23);
            this.ManualConnectBtn.TabIndex = 6;
            this.ManualConnectBtn.Text = "Connect To PS4Debug";
            this.ManualConnectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ManualConnectBtn.UseVisualStyleBackColor = false;
            this.ManualConnectBtn.Click += new System.EventHandler(this.ManualConnectBtn_Click);
            this.ManualConnectBtn.MouseEnter += new System.EventHandler(this.ManualConnectBtnMH);
            this.ManualConnectBtn.MouseLeave += new System.EventHandler(this.ManualConnectBtnML);
            this.ManualConnectBtn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ManualConnectBtn_Click);
            // 
            // IPBOX_E
            // 
            this.IPBOX_E.BackColor = System.Drawing.Color.DimGray;
            this.IPBOX_E.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IPBOX_E.Cursor = System.Windows.Forms.Cursors.Cross;
            this.IPBOX_E.ForeColor = System.Drawing.SystemColors.Control;
            this.IPBOX_E.Location = new System.Drawing.Point(102, 228);
            this.IPBOX_E.MaxLength = 15;
            this.IPBOX_E.Name = "IPBOX_E";
            this.IPBOX_E.Size = new System.Drawing.Size(100, 13);
            this.IPBOX_E.TabIndex = 8;
            this.IPBOX_E.Text = "IP()";
            this.IPBOX_E.TextChanged += new System.EventHandler(this.IPBOX_TextChanged);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(9, 391);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=======================================";
            this.Info.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.Info.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.Info.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // T1RBtn
            // 
            this.T1RBtn.BackColor = System.Drawing.Color.DimGray;
            this.T1RBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.T1RBtn.FlatAppearance.BorderSize = 0;
            this.T1RBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.T1RBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.T1RBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.T1RBtn.Location = new System.Drawing.Point(1, 30);
            this.T1RBtn.Name = "T1RBtn";
            this.T1RBtn.Size = new System.Drawing.Size(193, 22);
            this.T1RBtn.TabIndex = 8;
            this.T1RBtn.Text = "The Last of Us: Remastered";
            this.T1RBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.T1RBtn.UseVisualStyleBackColor = false;
            this.T1RBtn.Click += new System.EventHandler(this.T1RBtn_Click);
            this.T1RBtn.MouseEnter += new System.EventHandler(this.T1R100MH);
            this.T1RBtn.MouseLeave += new System.EventHandler(this.T1R100ML);
            // 
            // T2100Btn
            // 
            this.T2100Btn.BackColor = System.Drawing.Color.DimGray;
            this.T2100Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.T2100Btn.FlatAppearance.BorderSize = 0;
            this.T2100Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.T2100Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.T2100Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.T2100Btn.Location = new System.Drawing.Point(1, 53);
            this.T2100Btn.Name = "T2100Btn";
            this.T2100Btn.Size = new System.Drawing.Size(150, 22);
            this.T2100Btn.TabIndex = 9;
            this.T2100Btn.Text = "The Last of Us Part II";
            this.T2100Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.T2100Btn.UseVisualStyleBackColor = false;
            this.T2100Btn.Click += new System.EventHandler(this.T2100Btn_Click);
            this.T2100Btn.MouseEnter += new System.EventHandler(this.T2100MH);
            this.T2100Btn.MouseLeave += new System.EventHandler(this.T2100ML);
            // 
            // UC4100Btn
            // 
            this.UC4100Btn.BackColor = System.Drawing.Color.DimGray;
            this.UC4100Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.UC4100Btn.FlatAppearance.BorderSize = 0;
            this.UC4100Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UC4100Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.UC4100Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.UC4100Btn.Location = new System.Drawing.Point(1, 146);
            this.UC4100Btn.Name = "UC4100Btn";
            this.UC4100Btn.Size = new System.Drawing.Size(95, 22);
            this.UC4100Btn.TabIndex = 12;
            this.UC4100Btn.Text = "Uncharted 4";
            this.UC4100Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UC4100Btn.UseVisualStyleBackColor = false;
            this.UC4100Btn.Click += new System.EventHandler(this.UC4100Btn_Click);
            this.UC4100Btn.MouseEnter += new System.EventHandler(this.UC4100MH);
            this.UC4100Btn.MouseLeave += new System.EventHandler(this.UC4100ML);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 367);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 22);
            this.BackBtn.TabIndex = 14;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            this.BackBtn.MouseEnter += new System.EventHandler(this.BackBtnMH);
            this.BackBtn.MouseLeave += new System.EventHandler(this.BackBtnML);
            // 
            // UC1Btn
            // 
            this.UC1Btn.BackColor = System.Drawing.Color.DimGray;
            this.UC1Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.UC1Btn.FlatAppearance.BorderSize = 0;
            this.UC1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UC1Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.UC1Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.UC1Btn.Location = new System.Drawing.Point(1, 76);
            this.UC1Btn.Name = "UC1Btn";
            this.UC1Btn.Size = new System.Drawing.Size(190, 22);
            this.UC1Btn.TabIndex = 15;
            this.UC1Btn.Text = "Uncharted: Drakes Fortune";
            this.UC1Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UC1Btn.UseVisualStyleBackColor = false;
            this.UC1Btn.Click += new System.EventHandler(this.UC1Btn_Click);
            this.UC1Btn.MouseEnter += new System.EventHandler(this.UC1BtnMH);
            this.UC1Btn.MouseLeave += new System.EventHandler(this.UC1BtnML);
            // 
            // UC2Btn
            // 
            this.UC2Btn.BackColor = System.Drawing.Color.DimGray;
            this.UC2Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.UC2Btn.FlatAppearance.BorderSize = 0;
            this.UC2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UC2Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.UC2Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.UC2Btn.Location = new System.Drawing.Point(1, 99);
            this.UC2Btn.Name = "UC2Btn";
            this.UC2Btn.Size = new System.Drawing.Size(201, 23);
            this.UC2Btn.TabIndex = 16;
            this.UC2Btn.Text = "Uncharted 2: Among Thieves";
            this.UC2Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UC2Btn.UseVisualStyleBackColor = false;
            this.UC2Btn.Click += new System.EventHandler(this.UC2Btn_Click);
            this.UC2Btn.MouseEnter += new System.EventHandler(this.UC2BtnMH);
            this.UC2Btn.MouseLeave += new System.EventHandler(this.UC2BtnML);
            // 
            // UC3Btn
            // 
            this.UC3Btn.BackColor = System.Drawing.Color.DimGray;
            this.UC3Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.UC3Btn.FlatAppearance.BorderSize = 0;
            this.UC3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UC3Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.UC3Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.UC3Btn.Location = new System.Drawing.Point(1, 123);
            this.UC3Btn.Name = "UC3Btn";
            this.UC3Btn.Size = new System.Drawing.Size(219, 23);
            this.UC3Btn.TabIndex = 17;
            this.UC3Btn.Text = "Uncharted 3: Drakes Deception";
            this.UC3Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UC3Btn.UseVisualStyleBackColor = false;
            this.UC3Btn.Click += new System.EventHandler(this.UC3Btn_Click);
            this.UC3Btn.MouseEnter += new System.EventHandler(this.UC3BtnMH);
            this.UC3Btn.MouseLeave += new System.EventHandler(this.UC3BtnML);
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 204);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine2.TabIndex = 20;
            this.SeperatorLine2.Text = "______________________________________________________________";
            this.SeperatorLine2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.SeperatorLine2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.SeperatorLine2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // DebugPayloadBtn
            // 
            this.DebugPayloadBtn.BackColor = System.Drawing.Color.DimGray;
            this.DebugPayloadBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.DebugPayloadBtn.FlatAppearance.BorderSize = 0;
            this.DebugPayloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DebugPayloadBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.DebugPayloadBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.DebugPayloadBtn.Location = new System.Drawing.Point(1, 268);
            this.DebugPayloadBtn.Name = "DebugPayloadBtn";
            this.DebugPayloadBtn.Size = new System.Drawing.Size(124, 23);
            this.DebugPayloadBtn.TabIndex = 22;
            this.DebugPayloadBtn.Text = "Send PS4Debug";
            this.DebugPayloadBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DebugPayloadBtn.UseVisualStyleBackColor = false;
            this.DebugPayloadBtn.Click += new System.EventHandler(this.DebugPayloadBtn_Click);
            this.DebugPayloadBtn.MouseEnter += new System.EventHandler(this.DebugPayloadBtnMH);
            this.DebugPayloadBtn.MouseLeave += new System.EventHandler(this.DebugPayloadBtnML);
            // 
            // PortBox
            // 
            this.PortBox.BackColor = System.Drawing.Color.DimGray;
            this.PortBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PortBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PortBox.ForeColor = System.Drawing.SystemColors.Control;
            this.PortBox.Location = new System.Drawing.Point(52, 251);
            this.PortBox.MaxLength = 4;
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(24, 13);
            this.PortBox.TabIndex = 23;
            this.PortBox.Text = "port";
            this.PortBox.TextChanged += new System.EventHandler(this.PortBox_TextChanged);
            // 
            // IPLabelBtn
            // 
            this.IPLabelBtn.BackColor = System.Drawing.Color.DimGray;
            this.IPLabelBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.IPLabelBtn.FlatAppearance.BorderSize = 0;
            this.IPLabelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IPLabelBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.IPLabelBtn.ForeColor = System.Drawing.Color.Silver;
            this.IPLabelBtn.Location = new System.Drawing.Point(1, 222);
            this.IPLabelBtn.Name = "IPLabelBtn";
            this.IPLabelBtn.Size = new System.Drawing.Size(97, 22);
            this.IPLabelBtn.TabIndex = 24;
            this.IPLabelBtn.Text = "I.P. Address:";
            this.IPLabelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IPLabelBtn.UseVisualStyleBackColor = false;
            this.IPLabelBtn.Click += new System.EventHandler(this.IPLabelBtn_Click);
            // 
            // PortLabelBtn
            // 
            this.PortLabelBtn.BackColor = System.Drawing.Color.DimGray;
            this.PortLabelBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PortLabelBtn.FlatAppearance.BorderSize = 0;
            this.PortLabelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PortLabelBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.PortLabelBtn.ForeColor = System.Drawing.Color.Silver;
            this.PortLabelBtn.Location = new System.Drawing.Point(1, 245);
            this.PortLabelBtn.Name = "PortLabelBtn";
            this.PortLabelBtn.Size = new System.Drawing.Size(47, 22);
            this.PortLabelBtn.TabIndex = 25;
            this.PortLabelBtn.Text = "Port:";
            this.PortLabelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PortLabelBtn.UseVisualStyleBackColor = false;
            this.PortLabelBtn.Click += new System.EventHandler(this.PortLabelBtn_Click);
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 303);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 16);
            this.SeperatorLine3.TabIndex = 26;
            this.SeperatorLine3.Text = "_______________________________________________________________";
            this.SeperatorLine3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.SeperatorLine3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.SeperatorLine3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.DimGray;
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 319);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(135, 23);
            this.InfoHelpBtn.TabIndex = 27;
            this.InfoHelpBtn.Text = "Information / Help";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            this.InfoHelpBtn.MouseEnter += new System.EventHandler(this.InfoHelpBtnMH);
            this.InfoHelpBtn.MouseLeave += new System.EventHandler(this.InfoHelpBtnML);
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.DimGray;
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 343);
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
            // UC4MPBetaBtn
            // 
            this.UC4MPBetaBtn.BackColor = System.Drawing.Color.DimGray;
            this.UC4MPBetaBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.UC4MPBetaBtn.FlatAppearance.BorderSize = 0;
            this.UC4MPBetaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UC4MPBetaBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.UC4MPBetaBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.UC4MPBetaBtn.Location = new System.Drawing.Point(1, 169);
            this.UC4MPBetaBtn.Name = "UC4MPBetaBtn";
            this.UC4MPBetaBtn.Size = new System.Drawing.Size(153, 22);
            this.UC4MPBetaBtn.TabIndex = 29;
            this.UC4MPBetaBtn.Text = "Uncharted 4 MP Beta";
            this.UC4MPBetaBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UC4MPBetaBtn.UseVisualStyleBackColor = false;
            this.UC4MPBetaBtn.Click += new System.EventHandler(this.UC4MPBetaBtn_Click);
            this.UC4MPBetaBtn.MouseEnter += new System.EventHandler(this.UC4MPBetaBtnMH);
            this.UC4MPBetaBtn.MouseLeave += new System.EventHandler(this.UC4MPBetaBtnML);
            // 
            // PS4DebugPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 413);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.IPBOX_E);
            this.Controls.Add(this.UC4MPBetaBtn);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.ManualConnectBtn);
            this.Controls.Add(this.PortLabelBtn);
            this.Controls.Add(this.IPLabelBtn);
            this.Controls.Add(this.DebugPayloadBtn);
            this.Controls.Add(this.UC3Btn);
            this.Controls.Add(this.UC1Btn);
            this.Controls.Add(this.UC4100Btn);
            this.Controls.Add(this.TLL100Btn);
            this.Controls.Add(this.T1RBtn);
            this.Controls.Add(this.T2100Btn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.UC2Btn);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.MainBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PS4DebugPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Main";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            this.MainBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
            Form f = ActiveForm; //!
            LastPos = f.Location;
            MainForm.Show();
            Dobby.Page = MainForm.Name;
            ActiveForm.Location = LastPos;
            f.Close();
            Dobby.Page = ActiveForm.Name;
            SetPageInfo(MainForm);
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
        public void InfoHelpBtnMH(object sender, EventArgs e) => HoverString(InfoHelpBtn, "Additional Information On Verious Pages");
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

        public byte Connect() {
            try {
                geo = new PS4DBG(IPBOX_E.Text);
                geo.Connect();
                foreach (libdebug.Process prc in geo.GetProcessList().processes) {
                    foreach (string id in executables) {
                        if (prc.name == id) {
                            {
                                string title = geo.GetProcessInfo(prc.pid).titleid;
                                if (title == "FLTZ00003" || title == "ITEM00003") {
                                    Dev.DebugOutStr($"Skipping Lightning's Stuff {title}");
                                    break;
                                }
                            } // Code To Avoid Connecting To HB Store Stuff
                            exec = prc.pid;
                            processname = prc.name;
                            PS4DebugIsConnected = true;
                            Inf($"Connected And Attached To {geo.GetProcessInfo(exec).titleid}");
                            Dev.DebugOutStr($"{processname} | pid: {exec} | PS4DebugIsConnected == {PS4DebugIsConnected}");
                        }
                    }
                }
                return 0;
            }
            catch (Exception tabarnack) {
                if (Dev.REL) {
                    int tst = 420691337;
                    Dev.DebugOutStr($"{tabarnack.Message};{tabarnack.StackTrace}");
                }
                Inf($"Connection To {IPBOX_E.Text} Failed");
                return 1;
            }
        }
        public byte Connect(object sender, EventArgs e) {
            try {
                geo = new PS4DBG(IPBOX_E.Text);
                geo.Connect();
                foreach (libdebug.Process prc in geo.GetProcessList().processes) {
                    foreach (string id in executables) {
                        if (prc.name == id) {
                            exec = prc.pid;
                            processname = prc.name;
                            PS4DebugIsConnected = true;
                            Inf($"Connected And Attached To {geo.GetProcessInfo(exec).titleid}");
                            Dev.DebugOutStr($"{prc.name} | {exec} | PS4DebugIsConnected == {PS4DebugIsConnected}");
                        }
                    }
                }
                UC4133_Click(sender, e);
                return 0;
            }
            catch (Exception tabarnack) {
                if (!Dev.REL) Dev.DebugOutStr($"{tabarnack.Message};{tabarnack.StackTrace}");
                return 1;
            }
        }
        public static string IP() {
            try {
                var file = File.OpenText(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB");
                string v = file.ReadToEnd(); file.Dispose();
                Dev.DebugOutStr(v.Remove(v.IndexOf(";")));
                return v.Remove(v.IndexOf(";"));
            }
            catch (FileNotFoundException) {
                using (FileStream f = new FileStream(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB", FileMode.Create, FileAccess.Write)) {
                    Dev.DebugOutStr($"IP(); No Settings File Was Found, Made A New One At:\n{f.Name}");
                    f.Position = 0; f.Write(Encoding.UTF8.GetBytes("192.168.137."), 0, 12);
                    f.Position = 15; f.WriteByte(0x3B); f.Write(BitConverter.GetBytes(9020), 0, 4);
                    return "192.168.137.";
                }
            }
        }

        public void IPBOX_TextChanged(object sender, EventArgs e) {
            try {
                using (FileStream f = new FileStream(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB", FileMode.Open, FileAccess.Write)) {
                    f.Write(Encoding.UTF8.GetBytes(IPBOX_E.Text + ";"), 0, IPBOX_E.Text.Length + 1);
                    if (IPBOX_E.Text.Length > 12) Dev.DebugOutStr($"Saved {IPBOX_E.Text} As I.P.");
                }
            }
            catch (FileNotFoundException) { IP(); }
            catch (Exception tabarnack) { Dev.DebugOutStr(tabarnack.Message + $"\n{tabarnack.StackTrace}"); }
        }

        public int Port() {
            try {
                byte[] dat = new byte[4];
                var file = File.OpenRead(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB");
                file.Position = 16; file.Read(dat, 0, 4); file.Close();
                return BitConverter.ToInt32(dat, 0);
            }
            catch (FileNotFoundException) {
                using (FileStream f = new FileStream(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB", FileMode.Open, FileAccess.Write)) {
                    Dev.DebugOutStr($"Port(); No Settings File Was Found, Made A New One At:\n{f.Name}");
                    f.Write(Encoding.UTF8.GetBytes("192.168.137."), 0, 12);
                    f.Position = 15; f.WriteByte(0x3B); f.Write(BitConverter.GetBytes(9020), 0, 4);
                    return 9020;
                }
            }
        }

        public void PortBox_TextChanged(object sender, EventArgs e) {
            if (PortBox.Text.Length < 4) return;
            try {
                using (FileStream f = new FileStream(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB", FileMode.Open, FileAccess.Write)) {
                    f.Position = 16; f.Write(BitConverter.GetBytes(int.Parse(PortBox.Text)), 0, 4);
                    Dev.DebugOutStr($"Saved {PortBox.Text} As Port");
                }
            }
            catch (Exception tabarnack) {
                Dev.DebugOutStr($"{tabarnack.Message};{tabarnack.StackTrace}");
                Port();
            }
        }

        public void Toggle(ulong addr) {
            if (addr == 0) {
                Dev.DebugOutStr("addr was 0, this is caused when CheckGame(int) returns UnknownGame");
                MessageBox.Show("The Current Game Couldn't Be Determined");
                return;
            }
            Dev.DebugOutStr($"About To Toggle Byte At 0x{addr:X}");
            try {
                if (PS4DebugIsConnected && geo.GetProcessInfo(exec).name == processname) {
                    geo.WriteMemory(exec, addr, geo.ReadMemory(exec, addr, 1)[0] == 0x00 ? on : off);
                    Dev.DebugOutStr($"Wrote To {geo.GetProcessInfo(exec).name}/{exec} At 0x{addr:X}");
                    attempts = 0;
                }
                else {
                    Dev.DebugOutStr($"{(PS4DebugIsConnected ? $"geo.GetProcessInfo(exec).name ({geo.GetProcessInfo(exec).name}) != processname ({processname})" : "PS4Debug Isn't Connected, Connecting Now...")}");
                    attempts++;
                    if (attempts < 2) {
                        Connect(); Toggle(addr);
                    }
                    else Inf("Connection Failed");
                }
            }
            catch (Exception tabarnack) {
                attempts++;
                if (attempts < 2) {
                    Connect(); Toggle(addr);
                }
                else {
                    MessageBox.Show($"There Was An Error Writing To The Game's Executable\n\n{tabarnack}", "An Oh-Fuck Has Occured!");
                }
            }
        }
        public void ToggleAlt(ulong addr) {
            if (addr == 0) {
                Dev.DebugOutStr("addr was 0, this is caused when CheckGame(int) returns UnknownGame");
                MessageBox.Show("The Current Game Couldn't Be Determined");
                return;
            }
            Dev.DebugOutStr($"About To Toggle Byte At 0x{addr:X}");
            try {
                if (PS4DebugIsConnected && geo.GetProcessInfo(exec).name == processname) {
                    geo.WriteMemory(exec, addr, geo.ReadMemory(exec, addr, 1)[0] == 0x00 ? on : off);
                    Dev.DebugOutStr($"Wrote To {geo.GetProcessInfo(exec).name}/{exec} At 0x{addr:X}");
                    attempts = 0;
                }
            }
            catch (Exception tabarnack) {
                attempts++;
                if (attempts < 2) {
                    Connect(); Toggle(addr);
                }
                else {
                    MessageBox.Show($"There Was An Error Writing To The Game's Executable\n\n{tabarnack}", "An Oh-Fuck Has Occured!");
                }
            }
        }

        public void Toggle(ulong[] array) { // Just For The Uncharted Collection
            try {
                if (PS4DebugIsConnected && geo.GetProcessInfo(exec).name == processname)
                    foreach (ulong addr in array) {
                        geo.WriteMemory(exec, addr, geo.ReadMemory(exec, addr, 1)[0] == 0x00 ? on : off);
                        attempts = 0;
                    }
                else {
                    Dev.DebugOutStr("Game Changed (Or Was Never Connected?), Reconnecting...");
                    attempts++; if (attempts < 2) {
                        Connect(); Toggle(array);
                    }
                    else {
                        Dev.DebugOutStr("Failed To Re-Connect");
                    }
                }
            }
            catch (Exception tabarnack) {
                attempts++; if (attempts < 2) {
                    Connect(); Toggle(array);
                }
                else {
                    MessageBox.Show($"There Was An Error Writing To The Game's Executable\n{tabarnack}", "An Oh-Fuck Has Occured!");
                }
            }
        }

        public string CheckGame(int Game) { // the fuck!?
            try {
                if (PS4DebugIsConnected && geo.GetProcessInfo(exec).name == processname || Connect() == 0)
                    switch (Game) { // T1R
                        case 0:
                            Int16 chk = BitConverter.ToInt16(geo.ReadMemory(exec, 0x4000F4, 2), 0);
                            //BeginDebug
                            if (!Dev.REL) {
                                string additive;
                                switch (chk) {
                                    default:
                                        additive = "Unknown Game Or Patch";
                                        break;
                                    case 18432:
                                        additive = "Base Game";
                                        break;
                                    case 3480:
                                        additive = "1.09 Patch";
                                        break;
                                    case 4488:
                                        additive = "1.10 Patch";
                                        break;
                                    case 4472:
                                        additive = "1.11 Patch (Final Patch)";
                                        break;
                                }
                                Dev.DebugOutStr($"CheckGame chk == {chk} ({additive})");
                            }//EndDebug

                            string T1RErr() {
                                Dev.DebugOutStr($"Error 1 (T1R)\n{chk}");
                                return "UnknownGame";
                            }
                            return
                                chk == 18432 ? "1.00"
                                : chk == 3480 ? "1.XX"
                                : chk == 4488 ? "1.XX"
                                : chk == 4472 ? "1.XX"
                                : T1RErr();
                        case 1: // T2
                            int T2Check = BitConverter.ToInt32(geo.ReadMemory(exec, 0x40009A, 4), 0);

                            //BeginDebug
                            if (!Dev.REL) {
                                string additive;
                                switch (T2Check) {
                                    default:
                                        additive = "Unknown Game Or Patch";
                                        break;
                                    case 25384434:
                                        additive = "Base Game";
                                        break;
                                    case 25548706:
                                        additive = "1.01 Patch";
                                        break;
                                    case 25502882:
                                        additive = "1.02 Patch";
                                        break;
                                    case 25588450:
                                        additive = "1.05 Patch";
                                        break;
                                    case 25593522:
                                        additive = "1.07 Patch";
                                        break;
                                    case 30024882:
                                        additive = "1.08 Patch";
                                        break;
                                    case 30024914:
                                        additive = "1.09 Patch (Final Patch)";
                                        break;
                                }
                                Dev.DebugOutStr($"CheckGame chk == {T2Check} ({additive})");
                            }//EndDebug

                            string T2Err() {
                                Dev.DebugOutStr($"Error 1 (T2)\n{T2Check}");
                                return "UnknownGame";
                            }
                            return
                                T2Check == 25384434 ? "1.00"
                                : T2Check == 25548706 ? "1.01"
                                : T2Check == 25502882 ? "1.02"
                                : T2Check == 25588450 ? "1.05"
                                : T2Check == 25593522 ? "1.07"
                                : T2Check == 30024882 ? "1.08"
                                : T2Check == 30024914 ? "1.09"
                                : T2Err();
                            return "UnknownGame";
                        case 2: // UC1
                            return "UnknownGame";
                        case 3: // UC2
                            return "UnknownGame";
                        case 4: // UC3
                            return "UnknownGame";
                        case 5: // UC4
                            return "UnknownGame";
                        case 6: // TLL
                            return "UnknownGame";

                    }
                return "Error 2";
            }
            catch (Exception Tabarnack) {
                Dev.DebugOutStr($"{Tabarnack.Message};{Tabarnack.StackTrace}");
                return Tabarnack.StackTrace;
            }
        }
        public void IPLabelBtn_Click(object sender, EventArgs e) => IPBOX_E.Focus();
        public void PortLabelBtn_Click(object sender, EventArgs e) => PortBox.Focus();

        public void DebugPayloadBtn_Click(object sender, EventArgs e) {
            Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            S.Connect(new IPEndPoint(IPAddress.Parse(IPBOX_E.Text), int.Parse(PortBox.Text)));
            S.Send(Properties.Resources.PS4Debug1_1_15);
            Inf("Payload Injected Successfully");
            S.Close();
            if (true)//Dev.REL) // Excessive Credits To Try Avoiding Beef
                MessageBox.Show("PS4Debug Paylod Sent Without Issue\n\nPS4Debug Update 1.1.15 By ctn123\nPS4Debug Created By Golden", "Payload Injected Successfully, Here's Some Credits");
        }
        public void DebugPayloadBtnMH(object sender, EventArgs e) => HoverString(DebugPayloadBtn, "Sends ctn123's Port Of PS4Debug");
        public void DebugPayloadBtnML(object sender, EventArgs e) => HoverLeave(DebugPayloadBtn, 1);

        public void ManualConnectBtn_Click(object sender, EventArgs e) => Connect();
        public void ManualConnectBtnMH(object sender, EventArgs e) => HoverStringAlt(Info, ManualConnectBtn, "Tool Also Auto-Connects When An Option's Selected", 9F);
        public void ManualConnectBtnML(object sender, EventArgs e) => HoverLeave(ManualConnectBtn, 1);

        public void T1RBtn_Click(object sender, EventArgs e) {
            string Game = CheckGame(0); // The Fuck?
            Toggle(Game == "1.00" ? 0x114ED32E81 : Game == "UnknownGame" ? (ulong)0x0 : 0x114F536E81);
        }
        public void T1R100MH(object sender, EventArgs e) => HoverString(T1RBtn, "Supports: 1.00 | 1.09 | 1.10 | 1.11");
        public void T1R100ML(object sender, EventArgs e) => HoverLeave(T1RBtn, 1);

        public void T2100Btn_Click(object sender, EventArgs e) => ToggleAlt(CheckGame(1) == "1.00" ? (ulong)0x110693FAA1 : 0x11069DFAA1);
        public void T2100MH(object sender, EventArgs e) => HoverString(T2100Btn, "Supports: 1.00 | 1.07 | 1.08 | 1.09");
        public void T2100ML(object sender, EventArgs e) => HoverLeave(T2100Btn, 1);

        public void UC1Btn_Click(object sender, EventArgs e) {
            if (!PS4DebugIsConnected) Connect(); // Temporary debug code to get it working for Chandler
            if (geo.ReadMemory(exec, 0x4DE188, 1)[0] == 0x61) {
                Toggle(new ulong[] { 0xD5CA4C, 0xD5C9F0, 0xD5BBC1 }); // 1.02
                return;
            }
            Toggle(new ulong[] { 0xD989CC, 0xD97B41, 0xD98970 }); // 1.00
        }
        public void UC1BtnMH(object sender, EventArgs e) => HoverString(UC1Btn, "Supports: 1.00 | 1.02");
        public void UC1BtnML(object sender, EventArgs e) => HoverLeave(UC1Btn, 1);

        public void UC2Btn_Click(object sender, EventArgs e) => Toggle(new ulong[] { 0x127149C, 0x12705C9 });
        public void UC2BtnMH(object sender, EventArgs e) => HoverString(UC2Btn, "Supports: 1.00");
        public void UC2BtnML(object sender, EventArgs e) => HoverLeave(UC2Btn, 1);

        public void UC3Btn_Click(object sender, EventArgs e) => Toggle(new ulong[] { 0x18366C4, 0x1835481 });
        public void UC3BtnMH(object sender, EventArgs e) => HoverString(UC3Btn, "Supports: 1.00");
        public void UC3BtnML(object sender, EventArgs e) => HoverLeave(UC3Btn, 1);

        public void UC4100Btn_Click(object sender, EventArgs e) => Toggle(0x1104FC2E95);
        public void UC4100MH(object sender, EventArgs e) => HoverString(UC4100Btn, "Supports: 1.00 | 1.32 | 1.33");
        public void UC4100ML(object sender, EventArgs e) => HoverLeave(UC4100Btn, 1);

        public void UC4133_Click(object sender, EventArgs e) => Toggle(PS4DebugIsConnected ? geo.GetProcessInfo(exec).name != "eboot.bin" ? (ulong)0x1104B1AE79 : 0x110491AE79 : Connect(sender, e));

        private void UC4MPBetaBtn_Click(object sender, EventArgs e) => Toggle(0x113408AE83);
        public void UC4MPBetaBtnMH(object sender, EventArgs e) => HoverString(UC4MPBetaBtn, "Supports: 1.09 - Use .bin Patch For 1.00");
        public void UC4MPBetaBtnML(object sender, EventArgs e) => HoverLeave(UC4MPBetaBtn, 1);

        public void TLL100(object sender, EventArgs e) => Toggle(0x1105D1AEF9);
        public void TLL100MH(object sender, EventArgs e) => HoverLeave(TLL100Btn, 0);
        public void TLL100ML(object sender, EventArgs e) => HoverLeave(TLL100Btn, 1);

        public void TLL109(object sender, EventArgs e) => Toggle(0x1105D1AEF9);



        public Button ExitBtn;
        public Button MinimizeBtn;
        public GroupBox MainBox;
        public Label MainLabel;
        public Button T1RBtn;
        public Button T2100Btn;
        public Button UC1Btn;
        public Button UC2Btn;
        public Button UC3Btn;
        public Button UC4100Btn;
        public Button TLL100Btn;
        public Label label1;
        public Button IPLabelBtn;
        public TextBox IPBOX_E;
        public Button ManualConnectBtn;
        public Button PortLabelBtn;
        public TextBox PortBox;
        public Button DebugPayloadBtn;
        public Label SeperatorLine2;
        public Label SeperatorLine3;
        public Button EPPBackBtn;
        public Button UC4MPBetaBtn;
        public Button button2;
        public Button InfoHelpBtn;
        public Button CreditsBtn;

        private void ManualConnectBtn_Click(object sender, MouseEventArgs e) {

        }

        public Button BackBtn;
        public Label Info;


    }
}
