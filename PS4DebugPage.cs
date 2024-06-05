using libdebug;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using static Dobby.Common;
using System.Windows.Forms;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Dobby {
    public class PS4DebugPage : Form {

        public PS4DebugPage() {
            InitializeComponent();

            IP = IPBOX.Text = GetIPFromSettingsFile();
            Port = PortBox.Text = GetPortFromSettingsFile().ToString();
            AddEventHandlersToControls(Controls);
        }


        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Designer Crap, No Touchie      --\\\
        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        #region Designer Crap, No Touchie
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public void InitializeComponent() {
            this.MainLabel = new System.Windows.Forms.Label();
            this.TLLBtn = new Dobby.Button();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.ManualConnectBtn = new Dobby.Button();
            this.IPBOX = new System.Windows.Forms.TextBox();
            this.Info = new System.Windows.Forms.Label();
            this.T1RBtn = new Dobby.Button();
            this.T2Btn = new Dobby.Button();
            this.UC4Btn = new Dobby.Button();
            this.BackBtn = new Dobby.Button();
            this.UC1Btn = new Dobby.Button();
            this.UC2Btn = new Dobby.Button();
            this.UC3Btn = new Dobby.Button();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.PS4DebugPayloadBtn = new Dobby.Button();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.IPLabelBtn = new Dobby.Button();
            this.PortLabelBtn = new Dobby.Button();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.InfoHelpBtn = new Dobby.Button();
            this.CreditsBtn = new Dobby.Button();
            this.UC4MPBetaBtn = new Dobby.Button();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.IgnoreTitleIDBtn = new Dobby.Button();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(1, 1);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(318, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "PS4Debug Menu";
            // 
            // TLLBtn
            // 
            this.TLLBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TLLBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.TLLBtn.FlatAppearance.BorderSize = 0;
            this.TLLBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TLLBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.TLLBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.TLLBtn.Location = new System.Drawing.Point(1, 192);
            this.TLLBtn.Name = "TLLBtn";
            this.TLLBtn.Size = new System.Drawing.Size(192, 23);
            this.TLLBtn.TabIndex = 0;
            this.TLLBtn.Text = "Uncharted: The Lost Legacy";
            this.TLLBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TLLBtn.UseVisualStyleBackColor = false;
            this.TLLBtn.Click += new System.EventHandler(this.UCTLLBtn);
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine0.TabIndex = 30;
            this.SeperatorLine0.Text = "--------------------------------------------------------------";
            // 
            // ManualConnectBtn
            // 
            this.ManualConnectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ManualConnectBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ManualConnectBtn.FlatAppearance.BorderSize = 0;
            this.ManualConnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ManualConnectBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.ManualConnectBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ManualConnectBtn.Location = new System.Drawing.Point(1, 291);
            this.ManualConnectBtn.Name = "ManualConnectBtn";
            this.ManualConnectBtn.Size = new System.Drawing.Size(164, 23);
            this.ManualConnectBtn.TabIndex = 6;
            this.ManualConnectBtn.Text = "Connect To PS4Debug";
            this.ManualConnectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ManualConnectBtn.UseVisualStyleBackColor = false;
            this.ManualConnectBtn.Click += new System.EventHandler(this.ManualConnectBtn_Click);
            this.ManualConnectBtn.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ManualConnectBtn_Click);
            // 
            // IPBOX
            // 
            this.IPBOX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.IPBOX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.IPBOX.Cursor = System.Windows.Forms.Cursors.Cross;
            this.IPBOX.ForeColor = System.Drawing.SystemColors.Control;
            this.IPBOX.Location = new System.Drawing.Point(102, 228);
            this.IPBOX.MaxLength = 15;
            this.IPBOX.Name = "IPBOX";
            this.IPBOX.Size = new System.Drawing.Size(100, 13);
            this.IPBOX.TabIndex = 8;
            this.IPBOX.Text = "IP()";
            this.IPBOX.TextChanged += new System.EventHandler(this.IPBOX_TextChanged);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(9, 417);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=======================================";
            // 
            // T1RBtn
            // 
            this.T1RBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.T1RBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.T1RBtn.FlatAppearance.BorderSize = 0;
            this.T1RBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.T1RBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.T1RBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.T1RBtn.Location = new System.Drawing.Point(1, 30);
            this.T1RBtn.Name = "T1RBtn";
            this.T1RBtn.Size = new System.Drawing.Size(193, 22);
            this.T1RBtn.TabIndex = 8;
            this.T1RBtn.Text = "The Last of Us: Remastered";
            this.T1RBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.T1RBtn.UseVisualStyleBackColor = false;
            this.T1RBtn.Click += new System.EventHandler(this.T1RBtn_Click);
            // 
            // T2Btn
            // 
            this.T2Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.T2Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.T2Btn.FlatAppearance.BorderSize = 0;
            this.T2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.T2Btn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.T2Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.T2Btn.Location = new System.Drawing.Point(1, 53);
            this.T2Btn.Name = "T2Btn";
            this.T2Btn.Size = new System.Drawing.Size(150, 22);
            this.T2Btn.TabIndex = 9;
            this.T2Btn.Text = "The Last of Us Part II";
            this.T2Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.T2Btn.UseVisualStyleBackColor = false;
            this.T2Btn.Click += new System.EventHandler(this.T2Btn_Click);
            // 
            // UC4Btn
            // 
            this.UC4Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.UC4Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.UC4Btn.FlatAppearance.BorderSize = 0;
            this.UC4Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UC4Btn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.UC4Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.UC4Btn.Location = new System.Drawing.Point(1, 146);
            this.UC4Btn.Name = "UC4Btn";
            this.UC4Btn.Size = new System.Drawing.Size(95, 22);
            this.UC4Btn.TabIndex = 12;
            this.UC4Btn.Text = "Uncharted 4";
            this.UC4Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UC4Btn.UseVisualStyleBackColor = false;
            this.UC4Btn.Click += new System.EventHandler(this.UC4Btn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 393);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(60, 22);
            this.BackBtn.TabIndex = 14;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // UC1Btn
            // 
            this.UC1Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.UC1Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.UC1Btn.FlatAppearance.BorderSize = 0;
            this.UC1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UC1Btn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.UC1Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.UC1Btn.Location = new System.Drawing.Point(1, 76);
            this.UC1Btn.Name = "UC1Btn";
            this.UC1Btn.Size = new System.Drawing.Size(190, 22);
            this.UC1Btn.TabIndex = 15;
            this.UC1Btn.Text = "Uncharted: Drakes Fortune";
            this.UC1Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UC1Btn.UseVisualStyleBackColor = false;
            this.UC1Btn.Click += new System.EventHandler(this.UC1Btn_Click);
            // 
            // UC2Btn
            // 
            this.UC2Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.UC2Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.UC2Btn.FlatAppearance.BorderSize = 0;
            this.UC2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UC2Btn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.UC2Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.UC2Btn.Location = new System.Drawing.Point(1, 99);
            this.UC2Btn.Name = "UC2Btn";
            this.UC2Btn.Size = new System.Drawing.Size(201, 23);
            this.UC2Btn.TabIndex = 16;
            this.UC2Btn.Text = "Uncharted 2: Among Thieves";
            this.UC2Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UC2Btn.UseVisualStyleBackColor = false;
            this.UC2Btn.Click += new System.EventHandler(this.UC2Btn_Click);
            // 
            // UC3Btn
            // 
            this.UC3Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.UC3Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.UC3Btn.FlatAppearance.BorderSize = 0;
            this.UC3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UC3Btn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.UC3Btn.ForeColor = System.Drawing.SystemColors.Control;
            this.UC3Btn.Location = new System.Drawing.Point(1, 123);
            this.UC3Btn.Name = "UC3Btn";
            this.UC3Btn.Size = new System.Drawing.Size(219, 23);
            this.UC3Btn.TabIndex = 17;
            this.UC3Btn.Text = "Uncharted 3: Drakes Deception";
            this.UC3Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UC3Btn.UseVisualStyleBackColor = false;
            this.UC3Btn.Click += new System.EventHandler(this.UC3Btn_Click);
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 208);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine1.TabIndex = 20;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // PS4DebugPayloadBtn
            // 
            this.PS4DebugPayloadBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PS4DebugPayloadBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PS4DebugPayloadBtn.FlatAppearance.BorderSize = 0;
            this.PS4DebugPayloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PS4DebugPayloadBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.PS4DebugPayloadBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PS4DebugPayloadBtn.Location = new System.Drawing.Point(1, 268);
            this.PS4DebugPayloadBtn.Name = "PS4DebugPayloadBtn";
            this.PS4DebugPayloadBtn.Size = new System.Drawing.Size(124, 23);
            this.PS4DebugPayloadBtn.TabIndex = 22;
            this.PS4DebugPayloadBtn.Text = "Send PS4Debug";
            this.PS4DebugPayloadBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PS4DebugPayloadBtn.UseVisualStyleBackColor = false;
            this.PS4DebugPayloadBtn.Click += new System.EventHandler(this.DebugPayloadBtn_Click);
            // 
            // PortBox
            // 
            this.PortBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
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
            this.IPLabelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.IPLabelBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.IPLabelBtn.FlatAppearance.BorderSize = 0;
            this.IPLabelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IPLabelBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
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
            this.PortLabelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PortLabelBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PortLabelBtn.FlatAppearance.BorderSize = 0;
            this.PortLabelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PortLabelBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
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
            this.SeperatorLine3.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(2, 334);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine3.TabIndex = 26;
            this.SeperatorLine3.Text = "--------------------------------------------------------------_";
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 347);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(135, 23);
            this.InfoHelpBtn.TabIndex = 27;
            this.InfoHelpBtn.Text = "Information / Help";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 370);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(75, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // UC4MPBetaBtn
            // 
            this.UC4MPBetaBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.UC4MPBetaBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.UC4MPBetaBtn.FlatAppearance.BorderSize = 0;
            this.UC4MPBetaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UC4MPBetaBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.UC4MPBetaBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.UC4MPBetaBtn.Location = new System.Drawing.Point(1, 169);
            this.UC4MPBetaBtn.Name = "UC4MPBetaBtn";
            this.UC4MPBetaBtn.Size = new System.Drawing.Size(153, 22);
            this.UC4MPBetaBtn.TabIndex = 29;
            this.UC4MPBetaBtn.Text = "Uncharted 4 MP Beta";
            this.UC4MPBetaBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UC4MPBetaBtn.UseVisualStyleBackColor = false;
            this.UC4MPBetaBtn.Click += new System.EventHandler(this.UC4MPBetaBtn_Click);
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 306);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine2.TabIndex = 31;
            this.SeperatorLine2.Text = "--------------------------------------------------------------_";
            // 
            // IgnoreTitleIDBtn
            // 
            this.IgnoreTitleIDBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.IgnoreTitleIDBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.IgnoreTitleIDBtn.FlatAppearance.BorderSize = 0;
            this.IgnoreTitleIDBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IgnoreTitleIDBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.IgnoreTitleIDBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.IgnoreTitleIDBtn.Location = new System.Drawing.Point(1, 318);
            this.IgnoreTitleIDBtn.Name = "IgnoreTitleIDBtn";
            this.IgnoreTitleIDBtn.Size = new System.Drawing.Size(213, 23);
            this.IgnoreTitleIDBtn.TabIndex = 32;
            this.IgnoreTitleIDBtn.Text = "Ignore Game Title ID: Disabled";
            this.IgnoreTitleIDBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IgnoreTitleIDBtn.UseVisualStyleBackColor = false;
            this.IgnoreTitleIDBtn.Click += new System.EventHandler(this.IgnoreTitleIDBtn_Click);
            // 
            // PS4DebugPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(320, 440);
            this.Controls.Add(this.IgnoreTitleIDBtn);
            this.Controls.Add(this.ManualConnectBtn);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.IPBOX);
            this.Controls.Add(this.UC4MPBetaBtn);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.PortLabelBtn);
            this.Controls.Add(this.IPLabelBtn);
            this.Controls.Add(this.PS4DebugPayloadBtn);
            this.Controls.Add(this.UC3Btn);
            this.Controls.Add(this.UC1Btn);
            this.Controls.Add(this.UC4Btn);
            this.Controls.Add(this.TLLBtn);
            this.Controls.Add(this.T1RBtn);
            this.Controls.Add(this.T2Btn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.UC2Btn);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.SeperatorLine0);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PS4DebugPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        //////////////////\\\\\\\\\\\\\\\\\
        ///-- PS4DEBUG PAGE VARIABLES --\\\
        //////////////////\\\\\\\\\\\\\\\\\
        #region PS4Debug Page Variables

        public static PS4DBG geo;
        internal static InfoLabelUpdateCallback SetInfoText = value => {
            if(ActiveForm != null)
                InfoLabel.Text = value;
        };
        public static Thread ConnectionThread = new Thread(Connect);
        public static SHA256 hash;


        public static readonly byte
            on = 0x01, off = 0x00
        ;
        public static bool PS4DebugIsConnected, WaitForConnection = true, IgnoreTitleID = false;

        public static int
            Executable,   // Active PS4DBG Process ID
            attempts = 0, // Connect() retries
            ProcessCount = 0,
            DebugModePointerOffset = 0xDEADDAD
        ;

        public static ulong BaseAddress;

        public static readonly string[] ExecutablesNames = new string[] {
            "eboot.bin",
            "t2.elf",
            "t2-rtm.elf",
            "t2-final.elf",
            "t2-final-pgo-lto.elf",
            "big2-ps4_Shipping.elf",
            "big3-ps4_Shipping.elf",
            "big4.elf",
            "big4-final.elf",
            "big4-mp.elf",
            "big4-final-pgo-lto.elf",
            "eboot-mp.elf",
        };

        public static string
            IP,
            Port,
            ProcessName = "Jack Shit",
            GameVersion = "UnknownGameVersion",
            TitleID = "?"
        ;
        #endregion

        //////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     FUNCTIONS FOR BASIC PS4DEBUG PAGE FUNCTIONALITY     --\\\
        //////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Functions For Basic PS4Debug Page Functionality

        internal static bool ThreadSleep;
        internal Thread PayloadThread = new Thread(delegate (object Parameters) {
            while(true) {
                using(var S = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) {

                    dynamic parameters = Parameters;

                    ActiveForm.Invoke(SetInfoText, "Sending ps4debug Payload...");

                    try {
                        S.Connect(new IPEndPoint(IPAddress.Parse(parameters.IP), int.Parse(parameters.Port)));
                        S.Send(Properties.Resources.PS4Debug1_1_15);
                    }
                    catch(Exception e) {
                        Dev.MsgOut($"Failed To Connect To Specified Address/Port\nError: {e.Message}\n{e.StackTrace}");
                        ActiveForm.Invoke(SetInfoText, "Failed To Connect To Specified Address/Port");
                    }
                    finally { S.Close(); ThreadSleep = true; }

                    if(S.Connected) {
                        ActiveForm.Invoke(SetInfoText, "Payload Injected Successfully");
                        MessageBox.Show("PS4Debug Update 1.1.15 By ctn123\nPS4Debug Created By Golden", "Payload Injected Successfully, Here's Some Credits");
                        // ^^^ Excessive Credits To Try Avoiding Beef lol
                    }
                }

                while(ThreadSleep) ; // Wait For Another Try
            }
        });

        public static void Connect() {
            try {
            Wait:
                if(PS4DebugIsConnected) goto Wait;

                Dev.MsgOut($"Connecting To Console at {GetIPFromSettingsFile()}");
                ActiveForm?.Invoke(SetInfoText, "Connecting To Console");
                Dev.MsgOut($"PDIC?: {PS4DebugIsConnected} | {geo?.GetProcessInfo(Executable).name != ProcessName} | {geo?.GetProcessList().processes.Length == ProcessCount}");

                geo = new PS4DBG(GetIPFromSettingsFile());
                geo.Connect();
                PS4DebugIsConnected = true;

                foreach(libdebug.Process process in geo.GetProcessList().processes) { // processprocessprocessprocessprocessprocessprocess
                    if(ExecutablesNames.Contains(process.name)) {

                        string title = geo.GetProcessInfo(process.pid).titleid;

                        if(title == "FLTZ00003" || title == "ITEM00003") {
                            Dev.MsgOut($"Skipping Lightning's Stuff {title}");
                            continue;
                        } // Check To Avoid Connecting To HB Store Stuff

                        Executable = process.pid;
                        ProcessName = process.name;
                        TitleID = geo.GetProcessInfo(process.pid).titleid;
                        GameVersion = GetGameTitleIDVersionAndDMenuOffset();
                        ProcessCount = geo.GetProcessList().processes.Length;


                        ActiveForm?.Invoke(SetInfoText, $"Attached To {TitleID} ({GameVersion})");
                        WaitForConnection = false;
                        goto Wait;
                    }
                }
                ProcessName = "No Valid Process";
                ProcessCount = geo.GetProcessList().processes.Length;

                ActiveForm?.Invoke(SetInfoText, "Connected To PS4, But Couldn't Find The Game Process");
                WaitForConnection = false;
                goto Wait;
            }
            catch(Exception tabarnack) { if(!Dev.REL) MessageBox.Show($"{tabarnack.Message}\n{tabarnack.StackTrace}"); ActiveForm?.Invoke(SetInfoText, $"Connection To {PS4DebugPage.GetIPFromSettingsFile()} Failed"); }
        }


        /// <summary> Avoid Attempting To Toggle The Selected Bool In Memory Before The Connection Process Is Finished
        ///</summary>
        public static Task CheckConnectionStatus() {
            if(ConnectionThread.ThreadState == System.Threading.ThreadState.Unstarted)
                ConnectionThread.Start();

            else if(!PS4DebugIsConnected || geo?.GetProcessInfo(Executable).name != ProcessName || !ExecutablesNames.Contains(geo?.GetProcessInfo(Executable).name)) {
                PS4DebugIsConnected = false; WaitForConnection = true;
                Dev.MsgOut("CheckConnectionStatus Second Case, Now On WaitForConnection");
            }

            while(WaitForConnection) Thread.Sleep(2);
            return Task.CompletedTask;
        }
        
        /// <summary>
        /// An ugly sack of gross which determines the patch version of a specified game by just checking the int32 value of 2 bytes at a game-specific address because I have no idea how or if I can check the .sfo
        /// </summary>
        /// <returns> The Current Game Version If Successful, Or UnknownGameVersion \ UnknownTitleID If It Failed At Some Stage </returns>
        public static string GetGameTitleIDVersionAndDMenuOffset() {
            try {
                if(PS4DebugIsConnected && geo.GetProcessInfo(Executable).name == ProcessName) {

                    // Determine The Game That's Running
                    switch(TitleID) {
                        case "CUSA00552":
                        case "CUSA00554":
                        case "CUSA00556":
                        case "CUSA00557":
                        case "CUSA00559":
                            GameVersion = "T1R";
                            break;
                        case "CUSA10249":
                        case "CUSA14006":
                        case "CUSA07820":
                        case "CUSA13986":
                            GameVersion = "T2";
                            break;
                        case "CUSA01399":
                        case "CUSA02320":
                        case "CUSA02343":
                        case "CUSA02344":
                        case "CUSA02826":
                            GameVersion = "UCC";
                            break;
                        case "CUSA00341":
                        case "CUSA08342":
                        case "CUSA00912":
                        case "CUSA00917":
                        case "CUSA00918":
                        case "CUSA04529":
                            GameVersion = "UC4";
                            break;
                        case "CUSA04030":
                        case "CUSA04032":
                        case "CUSA04034":
                        case "CUSA04051":
                            GameVersion = "UC4 MP Beta";
                            break;
                        case "CUSA07737":
                        case "CUSA07875":
                        case "CUSA09564":
                        case "CUSA08347":
                        case "CUSA08352":
                            GameVersion = "TLL";
                            break;

                        default:
                            MessageBox.Show("Title ID Doesn't Match Any Known ID's, Try Enabling \"Ignore Title ID\" If You've Changed The Game's Title ID Yourself", "No Idea Which Game This Is");
                            return "UnknownTitleID";
                    }

                    // Read A Spot In Memory To Determine Which Patch the Executable's From
                    switch(GameVersion) {
                        case "T1R":
                            var T1RCheck = BitConverter.ToInt16(geo.ReadMemory(Executable, 0x4000F4, 2), 0);
                            switch(T1RCheck) {
                                case 18432: DebugModePointerOffset = 0x2E81; return "1.00";
                                case 3480: DebugModePointerOffset = 0x2E81; return "1.09";
                                case 4488: DebugModePointerOffset = 0x2E81; return "1.10";
                                case 4472: DebugModePointerOffset = 0x2E81; return "1.11";

                                default: Dev.MsgOut($"Error, Game Was T1R But None of The Checks Matched! || {T1RCheck}");
                                    MessageBox.Show($"The Game Was Determined To Be The Last of Us: Remastered, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{T1RCheck} {TitleID}", "Error Finding App Version");
                                    return "UnknownT1RGameVersion";
                            }
                        case "T2":
                            var T2Check = BitConverter.ToInt32(geo.ReadMemory(Executable, 0x40009A, 4), 0);
                            DebugModePointerOffset = 0x3aa1;
                            switch(T2Check) {
                                case 25384434: DebugModePointerOffset = 0x3aa1; return "1.00";
                                case 25548706: DebugModePointerOffset = 0x3aa1; return "1.01";
                                case 25502882: DebugModePointerOffset = 0x3aa1; return "1.02";
                                case 25588450: DebugModePointerOffset = 0x3aa1; return "1.05";
                                case 25593522: DebugModePointerOffset = 0x3aa1; return "1.07";
                                case 30024882: DebugModePointerOffset = 0x3aa1; return "1.08";
                                case 30024914: DebugModePointerOffset = 0x3aa1; return "1.09";

                                default: Dev.MsgOut($"Error, Game Was T2 But None of The Checks Matched! || chk:{T2Check}");
                                    MessageBox.Show($"The Game Was Determined To Be The Last of Us Part II, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{T2Check} {TitleID}", "Error Finding App Version");
                                    return "UnknownT2GameVersion";
                            }
                        case "UCC":
                            hash = SHA256.Create();
                            var UCCCheck = BitConverter.ToInt32(hash.ComputeHash(geo.ReadMemory(Executable, 0x400000, 100)), 0);
                            switch(UCCCheck) {
                                case 455457367: return "U2 1.00";
                                case -1951784656: return "U3 1.00";
                                case -1805287883: return "U2 1.02";
                                case 750078581: return "U3 1.02";
                                case -136556654: return "U1 1.00";
                                case -1120900838: return "U1 1.02";

                                default: Dev.MsgOut($"Error, Game Was UCC But None of The Checks Matched! || chk:{UCCCheck}");
                                    MessageBox.Show($"The Game Was Determined To Be The Uncharted Collection, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{UCCCheck} {TitleID}", "Error Finding App Version");
                                    return "UnknownUCCGameVersion";
                            }
                        case "UC4":
                            hash = SHA256.Create();
                            var U4Check = BitConverter.ToInt32(hash.ComputeHash(geo.ReadMemory(Executable, 0x400000, 450)), 0);
                            switch(U4Check) {
                                case -164231569:  DebugModePointerOffset = 0x2E95; return "1.00 SP";
                                case 561124052:   DebugModePointerOffset = 0x2E95; return "1.01 SP";
                                case 1001438826:  DebugModePointerOffset = 0x2E95; return "1.02 SP";
                                case -240761314:  DebugModePointerOffset = 0x2E95; return "1.03 SP";
                                case 642668739:   DebugModePointerOffset = 0x2E95; return "1.04 SP";
                                case 1863246975:  DebugModePointerOffset = 0x2E95; return "1.05 SP";
                                case -34645433:   DebugModePointerOffset = 0x2E95; return "1.06 SP";
                                case -1502336242: DebugModePointerOffset = 0x2E95; return "1.08 SP";
                                case -315414364:  DebugModePointerOffset = 0x2E95; return "1.10 SP";
                                case 593054491:   DebugModePointerOffset = 0x2E95; return "1.11 SP";
                                case 949549480:   DebugModePointerOffset = 0x2E95; return "1.12 SP";
                                case -1656215082: DebugModePointerOffset = 0x2E95; return "1.13 SP";
                                case 200885124:   DebugModePointerOffset = 0x2E95; return "1.15 SP";
                                case -593963332:  DebugModePointerOffset = 0x2E95; return "1.16 SP";
                                case 791591403:   DebugModePointerOffset = 0x2E95; return "1.17 SP";
                                case 1243873737:  DebugModePointerOffset = 0x2E79; return "1.18";
                                case -627230760:  DebugModePointerOffset = 0x2E79; return "1.19";
                                case 1270660743:  DebugModePointerOffset = 0x2E79; return "1.20 MP";
                                case -2117982988: DebugModePointerOffset = 0x2E79; return "1.20 SP";
                                case 719837740:   DebugModePointerOffset = 0x2E79; return "1.21 MP";
                                case 722113371:   DebugModePointerOffset = 0x2E79; return "1.21 SP";
                                case 211448500:   DebugModePointerOffset = 0x2E79; return "1.22 MP";
                                case -437432800:  DebugModePointerOffset = 0x2E79; return "1.22/23 SP";
                                case 1317147345:  DebugModePointerOffset = 0x2E79; return "1.23 MP";
                                case 1514442958:  DebugModePointerOffset = 0x2E79; return "1.24 MP";
                                case 407306374:   DebugModePointerOffset = 0x2E79; return "1.24/25 SP";
                                case 590571900:   DebugModePointerOffset = 0x2E79; return "1.25 MP";
                                case 190499529:   DebugModePointerOffset = 0x2E79; return "1.27/28 MP";
                                case -66801341:   DebugModePointerOffset = 0x2E79; return "1.27+ SP";
                                case -1852061601: DebugModePointerOffset = 0x2E79; return "1.29 MP";
                                case 898227952:   DebugModePointerOffset = 0x2E79; return "1.30 MP";
                                case 1025301972:  DebugModePointerOffset = 0x2E79; return "1.31 MP";
                                case -71032229:   DebugModePointerOffset = 0x2E79; return "1.32 MP";
                                case 145928122:   DebugModePointerOffset = 0x2E79; return "1.33 MP";

                                default: Dev.MsgOut($"Error, Game Was UC4, But None of The Checks Matched! || chk:{U4Check}");
                                    MessageBox.Show($"The Game Was Determined To Be UC4, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{U4Check} {TitleID}", "Error Finding App Version");
                                    return "UnknownUC4GameVersion";
                            }

                        case "UC4 MP Beta":
                            var U4MPBetaCheck = BitConverter.ToInt32(geo.ReadMemory(Executable, 0x403000, 4), 0);
                            switch(U4MPBetaCheck) {
                                case 759883849:  DebugModePointerOffset = 0x2E83; return "1.00 MP Beta";
                                case 2067458121: DebugModePointerOffset = 0x2E83; return "1.09 MP Beta";

                                default:
                                    Dev.MsgOut($"Error, Game Was UC4 MP Beta, But None of The Checks Matched! || chk:{U4MPBetaCheck}");
                                    MessageBox.Show($"The Game Was Determined To Be The UC4 MP Beta (Nice), But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{U4MPBetaCheck} {TitleID}", "Error Finding App Version");
                                    return "UnknownUC4GameVersion";
                            }

                        case "TLL":
                            var TLLCheck = BitConverter.ToInt16(geo.ReadMemory(Executable, 0x40003B, 2), 0);
                            switch(TLLCheck) {
                                case 3777:   DebugModePointerOffset = 0x2EF9; return "1.00 SP";
                                case -9759:  DebugModePointerOffset = 0x2EF9; return "1.0X SP";  // 1.08 and 1.09 have identical eboot.bin's
                                case -23679: DebugModePointerOffset = 0x2E79; return "1.00 MP";
                                case 27793:  DebugModePointerOffset = 0x2E79; return "1.08 MP";
                                case 27841:  DebugModePointerOffset = 0x2E79; return "1.09 MP";

                                default: Dev.MsgOut($"Error, Game Was UCC But None of The Checks Matched! || chk:{TLLCheck}");
                                    MessageBox.Show($"The Game Was Determined To Be The The Lost Legacy, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{TLLCheck} {TitleID}", "Error Finding App Version");
                                    return "UnknownTLLGameVersion";
                            }

                        default: Dev.MsgOut($"!!! PS4DebugPage -> GetGameVersion() Fell Through. (GameVersion: {GameVersion})"); return "UnknownGameVersion";
                    }
                }
                return "UnknownGameVersion";
            }
            catch(Exception Tabarnack) {
                Dev.MsgOut($"{Tabarnack.Message};{Tabarnack.StackTrace}");
                return "UnknownGameVersion";
            }
        }

        public static string GetIPFromSettingsFile() {
            try {
                var file = File.OpenText(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB");
                string v = file.ReadToEnd(); file.Dispose();
                return v.Remove(v.IndexOf(";"));
            }
            catch(FileNotFoundException) {
                using(FileStream f = new FileStream(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB", FileMode.Create, FileAccess.Write)) {
                    Dev.MsgOut($"IP(); No Settings File Was Found, Made A New One At:\n{f.Name}");
                    f.Position = 0; f.Write(Encoding.UTF8.GetBytes("192.168.137."), 0, 12);
                    f.Position = 15; f.WriteByte(0x3B); f.Write(BitConverter.GetBytes(9020), 0, 4);
                }
            }
            catch(Exception tabarnack) {
                Dev.MsgOut(tabarnack.Message + $"\n{tabarnack.StackTrace}");
            }

            return "192.168.137.";
        }

        public void IPBOX_TextChanged(object sender, EventArgs e) {
            try {
                using(FileStream f = new FileStream(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB", FileMode.Open, FileAccess.Write)) {
                    f.Write(Encoding.UTF8.GetBytes(IPBOX.Text + ";"), 0, IPBOX.Text.Length + 1);
                }
            }
            catch(FileNotFoundException) { GetIPFromSettingsFile(); }
            catch(Exception tabarnack) {
                Dev.MsgOut(tabarnack.Message + $"\n{tabarnack.StackTrace}");
            }
        }

        public int GetPortFromSettingsFile() {
            try {
                byte[] dat = new byte[4];
                var file = File.OpenRead(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB");
                file.Position = 16; file.Read(dat, 0, 4); file.Close();
                return BitConverter.ToInt32(dat, 0);
            }
            catch(FileNotFoundException) {
                using(FileStream f = new FileStream(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB", FileMode.Create, FileAccess.Write)) {
                    Dev.MsgOut($"Port(); No Settings File Was Found, Made A New One At:\n{f.Name}");
                    f.Write(Encoding.UTF8.GetBytes("192.168.137."), 0, 12);
                    f.Position = 15; f.WriteByte(0x3B); f.Write(BitConverter.GetBytes(9020), 0, 4);
                }
            }
            catch(Exception tabarnack) {
                Dev.MsgOut(tabarnack.Message + $"\n{tabarnack.StackTrace}");
            }

            return 9020;
        }

        public void PortBox_TextChanged(object sender, EventArgs e) {
            if(PortBox.Text.Length < 4) return;
            try {
                using(FileStream f = new FileStream(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB", FileMode.Open, FileAccess.Write)) {
                    f.Position = 16; f.Write(BitConverter.GetBytes(int.Parse(PortBox.Text)), 0, 4);
                }
            }
            catch(Exception tabarnack) {
                Dev.MsgOut($"{tabarnack.Message};{tabarnack.StackTrace}");
                GetPortFromSettingsFile();
            }
        }

        public void IgnoreTitleIDBtn_Click(object sender, EventArgs e) {
            var ControlText = ((Control)sender).Text;
            IgnoreTitleID = !IgnoreTitleID;
            ((Control)sender).Text = $"{ControlText.Remove(ControlText.LastIndexOf(' '))} {(IgnoreTitleID ? "Enable" : "Disabled")}";
        }

        /// <summary>
        /// Takes The Address For A Pointer, Adds The Offset For Debug Mode, And Writes To That Byte
        /// </summary>
        /// <param name="Addresses">Array Of Addresses To Read The Int64 From Depending On The Version</param>
        /// <param name="Versions">Version Strings To Check Against GameVersion</param>
        public static void Toggle(ulong[] Addresses, string[] Versions) {
            try {
                if(PS4DebugIsConnected && geo.GetProcessInfo(Executable).name == ProcessName) {
                    var AddressIndex = 0;
                    foreach(string Version in Versions)
                        if(GameVersion == Version) {
                            var pointer = (ulong)(BitConverter.ToInt64(geo.ReadMemory(Executable, Addresses[AddressIndex], 8), 0) + DebugModePointerOffset);
                            geo.WriteMemory(Executable, pointer, geo.ReadMemory(Executable, pointer, 1)[0] == 0x00 ? on : off);
                            Dev.MsgOut($"Toggle(ulong[] Addresses, string[] Versions) Wrote To {pointer:X}");
                        }
                        else if(AddressIndex != Addresses.Length - 1) AddressIndex++;
                }
                else {
                    Dev.MsgOut(
                        $"Error Toggling Byte.\nPS4Debug {(PS4DebugIsConnected ? "" : "Not ")}Connected\n"
                        + $"{geo.GetProcessInfo(Executable).name} {(geo.GetProcessInfo(Executable).name == ProcessName ? "=" : "!")}= {ProcessName}"
                    );
                }
            }
            catch(Exception tabarnack) { Dev.MsgOut(tabarnack.Message); }
        }

        /// <summary>
        /// Toggles A Byte At A Fixed Address
        /// </summary>
        /// <param name="Address">Address To Read/Write To</param>
        public static void Toggle(ulong Address) {
            try {
                if(PS4DebugIsConnected && geo.GetProcessInfo(Executable).name == ProcessName) {
                    geo.WriteMemory(Executable, Address, geo.ReadMemory(Executable, Address, 1)[0] == 0x00 ? on : off);
                    Dev.MsgOut($"Wrote To 0x{Address:X} in {geo.GetProcessInfo(Executable).name}/{Executable}");
                }
            }
            catch(Exception tabarnack) { Dev.MsgOut(tabarnack.Message); }
        }

        /// <summary>
        /// Toggles A Byte At Multiple Fixed Addresses (Just For The Uncharted Collection)
        /// </summary>
        /// <param name="AddressArray">Array Of Addresses To Read/Write To</param>
        public void Toggle(ulong[] AddressArray) {
            try {
                if(PS4DebugIsConnected && geo.GetProcessInfo(Executable).name == ProcessName)
                    foreach(ulong Address in AddressArray)
                        geo.WriteMemory(Executable, Address, geo.ReadMemory(Executable, Address, 1)[0] == 0x00 ? on : off);
            }
            catch(Exception tabarnack) { Dev.MsgOut(tabarnack.Message); }
        }



        public void IPLabelBtn_Click(object sender, EventArgs e) => IPBOX.Focus();
        public void PortLabelBtn_Click(object sender, EventArgs e) => PortBox.Focus();

        public void DebugPayloadBtn_Click(object sender, EventArgs e) {
            if(PayloadThread.ThreadState == ThreadState.Unstarted)
                PayloadThread.Start(new { IP, Port });
            ThreadSleep = false;
        }

        private void ManualConnectBtn_Click(object sender, EventArgs e) { // You Never Need To Press This, But People May Get Confused If It's Left Out.
            if(ConnectionThread.ThreadState == System.Threading.ThreadState.Unstarted)
                ConnectionThread.Start();
            PS4DebugIsConnected = false;
        }
        #endregion


        ///////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Debug Mode Toggle Functions For Each Game     --\\\
        ///////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private async void T1RBtn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA00552";
            if(!GameVersion.Contains("Unknown"))
                Toggle(new ulong[] { 0x1B8FA20, 0x1924a70, 0x1924a70, 0x1924a70 }, new string[] { "1.00", "1.09", "1.10", "1.11" });
        }
        private async void T2Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA10249";
            if(!GameVersion.Contains("Unknown"))
                Toggle(new ulong[] { 0x3b61900, 0x3b62d00, 0x3b67130, 0x3b67530, 0x3b675b0, 0x3b7b430, 0x3b7b430 }, new string[] { "1.00", "1.01", "1.02", "1.05", "1.07", "1.08", "1.09" });
            else Dev.MsgOut("Unknown Game Version");
        }
        private async void UC1Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA02320";
            if(!GameVersion.Contains("Unknown"))
                Toggle(GameVersion == "U1 1.00" ? new ulong[] { 0xD97B41, 0xD989CC, 0xD98970 } : new ulong[] { 0xD5C9F0, 0xD5CA4C, 0xD5BBC1 });
        }
        private async void UC2Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA02320";
            if(!GameVersion.Contains("Unknown"))
                Toggle(GameVersion == "U2 1.00" ? new ulong[] { 0x1271431, 0x127149C, 0x12705C9 } : new ulong[] { 0x145decc, 0x145cff9, 0x145de61 });
        }
        private async void UC3Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA02320";
            if(!GameVersion.Contains("Unknown"))
                Toggle(GameVersion == "U3 1.00" ? new ulong[] { 0x18366c9, 0x18366c4, 0x1835481 } : new ulong[] { 0x1bbaf69, 0x1bbaf64, 0x1BB9D21 });
        }
        private async void UC4Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA00341";
            if(!GameVersion.Contains("Unknown"))
                Toggle(new ulong[] { 0x27a3c30, 0x2889370, 0x288d370, 0x288d370, 0x2891370, 0x2891370, 0x2891370, 0x24ed968, 0x24ed968, 0x24f1978, 0x24fd958, 0x2501738, 0x2739a20, 0x2739a20, 0x2739a20, 0x2570748, 0x2570748, 0x2580888, 0x2570748, 0x2738dc0, 0x2570748, 0x273cdc0, 0x2570748, 0x273cdc0, 0x274ccd0, 0x2570748, 0x274ccd0, 0x2750d00, 0x2570748, 0x2758d00, 0x275cd00, 0x275cd00, 0x275cd00, 0x275cd00 }, new string[] { "1.00 SP", "1.01 SP", "1.02 SP", "1.03 SP", "1.04 SP", "1.05 SP", "1.06 SP", "1.08 SP", "1.10 SP", "1.11 SP", "1.12 SP", "1.13 SP", "1.15 SP", "1.16 SP", "1.17 SP", "1.18", "1.19", "1.20 MP", "1.20 SP", "1.21 MP", "1.21 SP", "1.22 MP", "1.22/23 SP", "1.23 MP", "1.24 MP", "1.24/25 SP", "1.25 MP", "1.27/28 MP", "1.27+ SP", "1.29 MP", "1.30 MP", "1.31 MP", "1.32 MP", "1.33 MP" });
        }
        private async void UC4MPBetaBtn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA00341";
            if(!GameVersion.Contains("Unknown"))
                Toggle(new ulong[] { 0x2bbf720, 0x2bc3720 }, new string[] { "1.00", "1.09" });
        }
        private async void UCTLLBtn(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA07737";
            if(!GameVersion.Contains("Unknown"))
                Toggle(new ulong[] { 0x26b4558, 0x26c0698, 0x0274cd00, 0x275cd00, 0x275cd00 }, new string[] { "1.00 SP", "1.0X SP", "1.00 MP", "1.08 MP", "1.09 MP" });
        }


        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Repeated Page Functions & Control Declarations     --\\\
        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Repeat Functions & Control Declarations
        public void BackBtn_Click(object sender, EventArgs e) {
            ReturnToPreviousPage();
            HoverLeave(BackBtn, false); // What Did This Fix, Again?
        }
        private void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.InfoHelpPage);
        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.CreditsPage);
        public TextBox IPBOX;
        public Label MainLabel;
        public Button T1RBtn;
        public Button T2Btn;
        public Button UC1Btn;
        public Button UC2Btn;
        public Button UC3Btn;
        public Button UC4Btn;
        public Button TLLBtn;
        public Label label1;
        public Button IPLabelBtn;
        public Button ManualConnectBtn;
        public Button PortLabelBtn;
        public TextBox PortBox;
        public Button PS4DebugPayloadBtn;
        public Label SeperatorLine0;
        public Label SeperatorLine1;
        public Label SeperatorLine3;
        public Button EPPBackBtn;
        public Button UC4MPBetaBtn;
        public Button button2;
        public Button InfoHelpBtn;
        public Button CreditsBtn;
        public Button BackBtn;
        public Label Info;
        public Label SeperatorLine2;
        public Button IgnoreTitleIDBtn;
        #endregion
    }
}
