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

        public static string processname = "Jack Shit";

        public void InitializeComponent() {
            MainLabel = new System.Windows.Forms.Label();
            TLL100Btn = new System.Windows.Forms.Button();
            MainBox = new System.Windows.Forms.GroupBox();
            ExitBtn = new System.Windows.Forms.Button();
            MinimizeBtn = new System.Windows.Forms.Button();
            ManualConnectBtn = new System.Windows.Forms.Button();
            IPBOX_E = new System.Windows.Forms.TextBox();
            Info = new System.Windows.Forms.Label();
            T1RBtn = new System.Windows.Forms.Button();
            T2100Btn = new System.Windows.Forms.Button();
            UC4100Btn = new System.Windows.Forms.Button();
            BackBtn = new System.Windows.Forms.Button();
            UC1Btn = new System.Windows.Forms.Button();
            UC2Btn = new System.Windows.Forms.Button();
            UC3Btn = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            DebugPayloadBtn = new System.Windows.Forms.Button();
            PortBox = new System.Windows.Forms.TextBox();
            IPLabelBtn = new System.Windows.Forms.Button();
            PortLabelBtn = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            InfoHelpBtn = new System.Windows.Forms.Button();
            CreditsBtn = new System.Windows.Forms.Button();
            UC4MPBetaBtn = new System.Windows.Forms.Button();
            MainBox.SuspendLayout();
            SuspendLayout();
            // 
            // ExitBtn
            // 
            ExitBtn.BackColor = System.Drawing.Color.DimGray;
            ExitBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            ExitBtn.FlatAppearance.BorderSize = 0;
            ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ExitBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ExitBtn.ForeColor = System.Drawing.SystemColors.Control;
            ExitBtn.Location = new System.Drawing.Point(293, 7);
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
            MinimizeBtn.Location = new System.Drawing.Point(270, 7);
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
            // MainBox
            // 
            MainBox.Controls.Add(ExitBtn);
            MainBox.Controls.Add(MinimizeBtn);
            MainBox.Controls.Add(MainLabel);
            MainBox.Location = new System.Drawing.Point(3, 17);
            MainBox.Name = "MainBox";
            MainBox.Size = new System.Drawing.Size(317, 32);
            MainBox.TabIndex = 5;
            MainBox.TabStop = false;
            MainBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            MainBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            MainBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
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
            MainLabel.Text = "PS4Debug Menu";
            MainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            MainLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            MainLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // ManualConnectBtn
            // 
            ManualConnectBtn.BackColor = System.Drawing.Color.DimGray;
            ManualConnectBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            ManualConnectBtn.FlatAppearance.BorderSize = 0;
            ManualConnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ManualConnectBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            ManualConnectBtn.ForeColor = System.Drawing.SystemColors.Control;
            ManualConnectBtn.Location = new System.Drawing.Point(-5, 309);
            ManualConnectBtn.Name = "ManualConnectBtn";
            ManualConnectBtn.Size = new System.Drawing.Size(164, 23);
            ManualConnectBtn.TabIndex = 6;
            ManualConnectBtn.Text = "Connect To PS4Debug";
            ManualConnectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ManualConnectBtn.UseVisualStyleBackColor = false;
            ManualConnectBtn.Click += new System.EventHandler(ManualConnectBtn_Click);
            ManualConnectBtn.MouseEnter += new System.EventHandler(ManualConnectBtnMH);
            ManualConnectBtn.MouseLeave += new System.EventHandler(ManualConnectBtnML);
            ManualConnectBtn.MouseWheel += new System.Windows.Forms.MouseEventHandler(ManualConnectBtn_Click);
            // 
            // IPBOX_E
            // 
            IPBOX_E.BackColor = System.Drawing.Color.DimGray;
            IPBOX_E.BorderStyle = System.Windows.Forms.BorderStyle.None;
            IPBOX_E.Cursor = System.Windows.Forms.Cursors.Cross;
            IPBOX_E.ForeColor = System.Drawing.SystemColors.Control;
            IPBOX_E.Location = new System.Drawing.Point(90, 245);
            IPBOX_E.MaxLength = 15;
            IPBOX_E.Name = "IPBOX_E";
            IPBOX_E.Size = new System.Drawing.Size(100, 13);
            IPBOX_E.TabIndex = 8;
            IPBOX_E.Text = "IP()";
            IPBOX_E.TextChanged += new System.EventHandler(IPBOX_TextChanged);
            // 
            // Info
            // 
            Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            Info.Location = new System.Drawing.Point(2, 409);
            Info.Name = "Info";
            Info.Size = new System.Drawing.Size(304, 17);
            Info.TabIndex = 7;
            Info.Text = "=======================================";
            Info.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            Info.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            Info.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // T1RBtn
            // 
            T1RBtn.BackColor = System.Drawing.Color.DimGray;
            T1RBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            T1RBtn.FlatAppearance.BorderSize = 0;
            T1RBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            T1RBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            T1RBtn.ForeColor = System.Drawing.SystemColors.Control;
            T1RBtn.Location = new System.Drawing.Point(-5, 50);
            T1RBtn.Name = "T1RBtn";
            T1RBtn.Size = new System.Drawing.Size(193, 22);
            T1RBtn.TabIndex = 8;
            T1RBtn.Text = "The Last of Us: Remastered";
            T1RBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            T1RBtn.UseVisualStyleBackColor = false;
            T1RBtn.Click += new System.EventHandler(T1RBtn_Click);
            T1RBtn.MouseEnter += new System.EventHandler(T1R100MH);
            T1RBtn.MouseLeave += new System.EventHandler(T1R100ML);
            // 
            // T2100Btn
            // 
            T2100Btn.BackColor = System.Drawing.Color.DimGray;
            T2100Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            T2100Btn.FlatAppearance.BorderSize = 0;
            T2100Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            T2100Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            T2100Btn.ForeColor = System.Drawing.SystemColors.Control;
            T2100Btn.Location = new System.Drawing.Point(-5, 73);
            T2100Btn.Name = "T2100Btn";
            T2100Btn.Size = new System.Drawing.Size(150, 22);
            T2100Btn.TabIndex = 9;
            T2100Btn.Text = "The Last of Us Part II";
            T2100Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            T2100Btn.UseVisualStyleBackColor = false;
            T2100Btn.Click += new System.EventHandler(T2100Btn_Click);
            T2100Btn.MouseEnter += new System.EventHandler(T2100MH);
            T2100Btn.MouseLeave += new System.EventHandler(T2100ML);
            // 
            // UC1Btn
            // 
            UC1Btn.BackColor = System.Drawing.Color.DimGray;
            UC1Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            UC1Btn.FlatAppearance.BorderSize = 0;
            UC1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UC1Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            UC1Btn.ForeColor = System.Drawing.SystemColors.Control;
            UC1Btn.Location = new System.Drawing.Point(-5, 96);
            UC1Btn.Name = "UC1Btn";
            UC1Btn.Size = new System.Drawing.Size(190, 22);
            UC1Btn.TabIndex = 15;
            UC1Btn.Text = "Uncharted: Drakes Fortune";
            UC1Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UC1Btn.UseVisualStyleBackColor = false;
            UC1Btn.Click += new System.EventHandler(UC1Btn_Click);
            UC1Btn.MouseEnter += new System.EventHandler(UC1BtnMH);
            UC1Btn.MouseLeave += new System.EventHandler(UC1BtnML);
            // 
            // UC2Btn
            // 
            UC2Btn.BackColor = System.Drawing.Color.DimGray;
            UC2Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            UC2Btn.FlatAppearance.BorderSize = 0;
            UC2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UC2Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            UC2Btn.ForeColor = System.Drawing.SystemColors.Control;
            UC2Btn.Location = new System.Drawing.Point(-5, 119);
            UC2Btn.Name = "UC2Btn";
            UC2Btn.Size = new System.Drawing.Size(201, 23);
            UC2Btn.TabIndex = 16;
            UC2Btn.Text = "Uncharted 2: Among Thieves";
            UC2Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UC2Btn.UseVisualStyleBackColor = false;
            UC2Btn.Click += new System.EventHandler(UC2Btn_Click);
            UC2Btn.MouseEnter += new System.EventHandler(UC2BtnMH);
            UC2Btn.MouseLeave += new System.EventHandler(UC2BtnML);
            // 
            // UC3Btn
            // 
            UC3Btn.BackColor = System.Drawing.Color.DimGray;
            UC3Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            UC3Btn.FlatAppearance.BorderSize = 0;
            UC3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UC3Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            UC3Btn.ForeColor = System.Drawing.SystemColors.Control;
            UC3Btn.Location = new System.Drawing.Point(-5, 143);
            UC3Btn.Name = "UC3Btn";
            UC3Btn.Size = new System.Drawing.Size(219, 23);
            UC3Btn.TabIndex = 17;
            UC3Btn.Text = "Uncharted 3: Drakes Deception";
            UC3Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UC3Btn.UseVisualStyleBackColor = false;
            UC3Btn.Click += new System.EventHandler(UC3Btn_Click);
            UC3Btn.MouseEnter += new System.EventHandler(UC3BtnMH);
            UC3Btn.MouseLeave += new System.EventHandler(UC3BtnML);
            // 
            // UC4100Btn
            // 
            UC4100Btn.BackColor = System.Drawing.Color.DimGray;
            UC4100Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            UC4100Btn.FlatAppearance.BorderSize = 0;
            UC4100Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UC4100Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            UC4100Btn.ForeColor = System.Drawing.SystemColors.Control;
            UC4100Btn.Location = new System.Drawing.Point(-5, 166);
            UC4100Btn.Name = "UC4100Btn";
            UC4100Btn.Size = new System.Drawing.Size(95, 22);
            UC4100Btn.TabIndex = 12;
            UC4100Btn.Text = "Uncharted 4";
            UC4100Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UC4100Btn.UseVisualStyleBackColor = false;
            UC4100Btn.Click += new System.EventHandler(UC4100Btn_Click);
            UC4100Btn.MouseEnter += new System.EventHandler(UC4100MH);
            UC4100Btn.MouseLeave += new System.EventHandler(UC4100ML);
            // 
            // UC4MPBetaBtn
            // 
            UC4MPBetaBtn.BackColor = System.Drawing.Color.DimGray;
            UC4MPBetaBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            UC4MPBetaBtn.FlatAppearance.BorderSize = 0;
            UC4MPBetaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UC4MPBetaBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            UC4MPBetaBtn.ForeColor = System.Drawing.SystemColors.Control;
            UC4MPBetaBtn.Location = new System.Drawing.Point(-5, 189);
            UC4MPBetaBtn.Name = "UC4MPBetaBtn";
            UC4MPBetaBtn.Size = new System.Drawing.Size(153, 22);
            UC4MPBetaBtn.TabIndex = 29;
            UC4MPBetaBtn.Text = "Uncharted 4 MP Beta";
            UC4MPBetaBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UC4MPBetaBtn.UseVisualStyleBackColor = false;
            UC4MPBetaBtn.Click += new System.EventHandler(UC4MPBetaBtn_Click);
            UC4MPBetaBtn.MouseEnter += new System.EventHandler(UC4MPBetaBtnMH);
            UC4MPBetaBtn.MouseLeave += new System.EventHandler(UC4MPBetaBtnML);
            // 
            // TLL100Btn
            // 
            TLL100Btn.BackColor = System.Drawing.Color.DimGray;
            TLL100Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            TLL100Btn.FlatAppearance.BorderSize = 0;
            TLL100Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            TLL100Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            TLL100Btn.ForeColor = System.Drawing.SystemColors.Control;
            TLL100Btn.Location = new System.Drawing.Point(-5, 212);
            TLL100Btn.Name = "TLL100Btn";
            TLL100Btn.Size = new System.Drawing.Size(192, 23);
            TLL100Btn.TabIndex = 0;
            TLL100Btn.Text = "Uncharted: The Lost Legacy";
            TLL100Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TLL100Btn.UseVisualStyleBackColor = false;
            TLL100Btn.Click += new System.EventHandler(TLL100);
            TLL100Btn.MouseEnter += new System.EventHandler(TLL100MH);
            TLL100Btn.MouseLeave += new System.EventHandler(TLL100ML);
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(-5, 222);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(320, 16);
            label2.TabIndex = 20;
            label2.Text = "______________________________________________________________";
            label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            label2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // DebugPayloadBtn
            // 
            DebugPayloadBtn.BackColor = System.Drawing.Color.DimGray;
            DebugPayloadBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            DebugPayloadBtn.FlatAppearance.BorderSize = 0;
            DebugPayloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            DebugPayloadBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            DebugPayloadBtn.ForeColor = System.Drawing.SystemColors.Control;
            DebugPayloadBtn.Location = new System.Drawing.Point(-5, 285);
            DebugPayloadBtn.Name = "DebugPayloadBtn";
            DebugPayloadBtn.Size = new System.Drawing.Size(124, 23);
            DebugPayloadBtn.TabIndex = 22;
            DebugPayloadBtn.Text = "Send PS4Debug";
            DebugPayloadBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            DebugPayloadBtn.UseVisualStyleBackColor = false;
            DebugPayloadBtn.Click += new System.EventHandler(DebugPayloadBtn_Click);
            DebugPayloadBtn.MouseEnter += new System.EventHandler(DebugPayloadBtnMH);
            DebugPayloadBtn.MouseLeave += new System.EventHandler(DebugPayloadBtnML);
            // 
            // PortBox
            // 
            PortBox.BackColor = System.Drawing.Color.DimGray;
            PortBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            PortBox.Cursor = System.Windows.Forms.Cursors.Cross;
            PortBox.ForeColor = System.Drawing.SystemColors.Control;
            PortBox.Location = new System.Drawing.Point(40, 268);
            PortBox.MaxLength = 4;
            PortBox.Name = "PortBox";
            PortBox.Size = new System.Drawing.Size(24, 13);
            PortBox.TabIndex = 23;
            PortBox.Text = "port";
            PortBox.TextChanged += new System.EventHandler(PortBox_TextChanged);
            // 
            // IPLabelBtn
            // 
            IPLabelBtn.BackColor = System.Drawing.Color.DimGray;
            IPLabelBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            IPLabelBtn.FlatAppearance.BorderSize = 0;
            IPLabelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            IPLabelBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            IPLabelBtn.ForeColor = System.Drawing.Color.Silver;
            IPLabelBtn.Location = new System.Drawing.Point(-5, 239);
            IPLabelBtn.Name = "IPLabelBtn";
            IPLabelBtn.Size = new System.Drawing.Size(97, 22);
            IPLabelBtn.TabIndex = 24;
            IPLabelBtn.Text = "I.P. Address:";
            IPLabelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            IPLabelBtn.UseVisualStyleBackColor = false;
            IPLabelBtn.Click += new System.EventHandler(IPLabelBtn_Click);
            // 
            // PortLabelBtn
            // 
            PortLabelBtn.BackColor = System.Drawing.Color.DimGray;
            PortLabelBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            PortLabelBtn.FlatAppearance.BorderSize = 0;
            PortLabelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            PortLabelBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            PortLabelBtn.ForeColor = System.Drawing.Color.Silver;
            PortLabelBtn.Location = new System.Drawing.Point(-5, 262);
            PortLabelBtn.Name = "PortLabelBtn";
            PortLabelBtn.Size = new System.Drawing.Size(47, 22);
            PortLabelBtn.TabIndex = 25;
            PortLabelBtn.Text = "Port:";
            PortLabelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            PortLabelBtn.UseVisualStyleBackColor = false;
            PortLabelBtn.Click += new System.EventHandler(PortLabelBtn_Click);
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(-4, 319);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(320, 16);
            label3.TabIndex = 26;
            label3.Text = "______________________________________________________________";
            label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            // 
            // InfoHelpBtn
            // 
            InfoHelpBtn.BackColor = System.Drawing.Color.DimGray;
            InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            InfoHelpBtn.FlatAppearance.BorderSize = 0;
            InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            InfoHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            InfoHelpBtn.Location = new System.Drawing.Point(-5, 336);
            InfoHelpBtn.Name = "InfoHelpBtn";
            InfoHelpBtn.Size = new System.Drawing.Size(135, 23);
            InfoHelpBtn.TabIndex = 27;
            InfoHelpBtn.Text = "Information / Help";
            InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            InfoHelpBtn.UseVisualStyleBackColor = false;
            InfoHelpBtn.Click += new System.EventHandler(InfoHelpBtn_Click);
            InfoHelpBtn.MouseEnter += new System.EventHandler(InfoHelpBtnMH);
            InfoHelpBtn.MouseLeave += new System.EventHandler(InfoHelpBtnML);
            // 
            // CreditsBtn
            // 
            CreditsBtn.BackColor = System.Drawing.Color.DimGray;
            CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            CreditsBtn.FlatAppearance.BorderSize = 0;
            CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CreditsBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            CreditsBtn.Location = new System.Drawing.Point(-5, 360);
            CreditsBtn.Name = "CreditsBtn";
            CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            CreditsBtn.Size = new System.Drawing.Size(75, 23);
            CreditsBtn.TabIndex = 28;
            CreditsBtn.Text = "Credits...";
            CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            CreditsBtn.UseVisualStyleBackColor = false;
            CreditsBtn.Click += new System.EventHandler(CreditsBtn_Click);
            CreditsBtn.MouseEnter += new System.EventHandler(CreditsBtnMH);
            CreditsBtn.MouseLeave += new System.EventHandler(CreditsBtnML);
            // 
            // BackBtn
            // 
            BackBtn.BackColor = System.Drawing.Color.DimGray;
            BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            BackBtn.FlatAppearance.BorderSize = 0;
            BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            BackBtn.Location = new System.Drawing.Point(-5, 384);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new System.Drawing.Size(60, 22);
            BackBtn.TabIndex = 14;
            BackBtn.Text = "Back...";
            BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            BackBtn.UseVisualStyleBackColor = false;
            BackBtn.Click += new System.EventHandler(BackBtn_Click);
            BackBtn.MouseEnter += new System.EventHandler(BackBtnMH);
            BackBtn.MouseLeave += new System.EventHandler(BackBtnML);
            // 
            // PS4DebugPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.DimGray;
            ClientSize = new System.Drawing.Size(320, 430);
            Controls.Add(PortBox);
            Controls.Add(IPBOX_E);
            Controls.Add(UC4MPBetaBtn);
            Controls.Add(InfoHelpBtn);
            Controls.Add(ManualConnectBtn);
            Controls.Add(PortLabelBtn);
            Controls.Add(IPLabelBtn);
            Controls.Add(DebugPayloadBtn);
            Controls.Add(UC3Btn);
            Controls.Add(UC1Btn);
            Controls.Add(UC4100Btn);
            Controls.Add(TLL100Btn);
            Controls.Add(T1RBtn);
            Controls.Add(T2100Btn);
            Controls.Add(Info);
            Controls.Add(MainBox);
            Controls.Add(UC2Btn);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(BackBtn);
            Controls.Add(CreditsBtn);
            Cursor = System.Windows.Forms.Cursors.Default;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "PS4DebugPage";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "Main";
            MainBox.ResumeLayout(false);
            MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunc);
            MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunc);
            ResumeLayout(false);
            PerformLayout();

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
        public void CreditsBtnMH(object sender, EventArgs e) => HoverString(CreditsBtn,  "View Credits For The Tool And Included Patches");
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
                        if (prc.name == id) { {
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
            catch (Exception tabarnack) { Dev.DebugOutStr(tabarnack.Message + $"\n{tabarnack.StackTrace}");}
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

        public string CheckGame(int Game) {
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
            string Game = CheckGame(0);
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
        public Label label2;
        public Label label3;
        public Button EPPBackBtn;
        public Button UC4MPBetaBtn;
        public Button button2;
        public Button InfoHelpBtn;
        public Button CreditsBtn;
        public Button BackBtn;
        public Label Info;


    }
}
