
namespace Dobby
{
    internal partial class PS4DebugPage
    {

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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public void InitializeComponent()
        {
            this.MainLabel = new System.Windows.Forms.Label();
            this.TLLBtn = new Dobby.Button();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.ManualConnectBtn = new Dobby.Button();
            this.IPBOX = new Dobby.TextBox();
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
            this.PortBox = new Dobby.TextBox();
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
    }
}
