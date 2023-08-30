using libdebug;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Drawing;
using System.Net.Sockets;
using static Dobby.Common;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace Dobby {
    public class PS4DebugPage : Form {

        public PS4DebugPage() {
            InitializeComponent();
            IPBOX_E.Text = IP();
            PortBox.Text = Port().ToString();
            AddControlEventHandlers(Controls);
        }

        public void InitializeComponent() {
            MainLabel = new System.Windows.Forms.Label();
            TLLBtn = new System.Windows.Forms.Button();
            MainBox = new System.Windows.Forms.GroupBox();
            MinimizeBtn = new System.Windows.Forms.Button();
            ExitBtn = new System.Windows.Forms.Button();
            SeperatorLine1 = new System.Windows.Forms.Label();
            ManualConnectBtn = new System.Windows.Forms.Button();
            IPBOX_E = new System.Windows.Forms.TextBox();
            Info = new System.Windows.Forms.Label();
            T1RBtn = new System.Windows.Forms.Button();
            T2Btn = new System.Windows.Forms.Button();
            UC4Btn = new System.Windows.Forms.Button();
            BackBtn = new System.Windows.Forms.Button();
            UC1Btn = new System.Windows.Forms.Button();
            UC2Btn = new System.Windows.Forms.Button();
            UC3Btn = new System.Windows.Forms.Button();
            SeperatorLine2 = new System.Windows.Forms.Label();
            PS4DebugPayloadBtn = new System.Windows.Forms.Button();
            PortBox = new System.Windows.Forms.TextBox();
            IPLabelBtn = new System.Windows.Forms.Button();
            PortLabelBtn = new System.Windows.Forms.Button();
            SeperatorLine3 = new System.Windows.Forms.Label();
            InfoHelpBtn = new System.Windows.Forms.Button();
            CreditsBtn = new System.Windows.Forms.Button();
            UC4MPBetaBtn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // MainLabel
            // 
            MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            MainLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12.25F, System.Drawing.FontStyle.Bold);
            MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            MainLabel.Location = new System.Drawing.Point(1, 2);
            MainLabel.Name = "MainLabel";
            MainLabel.Size = new System.Drawing.Size(318, 22);
            MainLabel.TabIndex = 0;
            MainLabel.Text = "PS4Debug Menu";
            // 
            // TLLBtn
            // 
            TLLBtn.BackColor = System.Drawing.Color.DimGray;
            TLLBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            TLLBtn.FlatAppearance.BorderSize = 0;
            TLLBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            TLLBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            TLLBtn.ForeColor = System.Drawing.SystemColors.Control;
            TLLBtn.Location = new System.Drawing.Point(1, 192);
            TLLBtn.Name = "TLLBtn";
            TLLBtn.Size = new System.Drawing.Size(192, 23);
            TLLBtn.TabIndex = 0;
            TLLBtn.Text = "Uncharted: The Lost Legacy";
            TLLBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TLLBtn.UseVisualStyleBackColor = false;
            TLLBtn.Click += new System.EventHandler(UCTLLBtn);
            // 
            // MainBox
            // 
            MainBox.Location = new System.Drawing.Point(0, -6);
            MainBox.Name = "MainBox";
            MainBox.Size = new System.Drawing.Size(320, 420);
            MainBox.TabIndex = 5;
            MainBox.TabStop = false;
            // 
            // MinimizeBtn
            // 
            MinimizeBtn.BackColor = System.Drawing.Color.DimGray;
            MinimizeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            MinimizeBtn.FlatAppearance.BorderSize = 0;
            MinimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            MinimizeBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            MinimizeBtn.ForeColor = System.Drawing.SystemColors.Control;
            MinimizeBtn.Location = new System.Drawing.Point(273, 1);
            MinimizeBtn.Name = "MinimizeBtn";
            MinimizeBtn.Size = new System.Drawing.Size(23, 23);
            MinimizeBtn.TabIndex = 19;
            MinimizeBtn.Text = "--";
            MinimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            MinimizeBtn.UseVisualStyleBackColor = false;
            // 
            // ExitBtn
            // 
            ExitBtn.BackColor = System.Drawing.Color.DimGray;
            ExitBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            ExitBtn.FlatAppearance.BorderSize = 0;
            ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ExitBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ExitBtn.ForeColor = System.Drawing.SystemColors.Control;
            ExitBtn.Location = new System.Drawing.Point(296, 1);
            ExitBtn.Name = "ExitBtn";
            ExitBtn.Size = new System.Drawing.Size(23, 23);
            ExitBtn.TabIndex = 18;
            ExitBtn.Text = "X";
            ExitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ExitBtn.UseVisualStyleBackColor = false;
            // 
            // SeperatorLine1
            // 
            SeperatorLine1.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            SeperatorLine1.Location = new System.Drawing.Point(2, 11);
            SeperatorLine1.Name = "SeperatorLine1";
            SeperatorLine1.Size = new System.Drawing.Size(316, 16);
            SeperatorLine1.TabIndex = 30;
            SeperatorLine1.Text = "______________________________________________________________";
            // 
            // ManualConnectBtn
            // 
            ManualConnectBtn.BackColor = System.Drawing.Color.DimGray;
            ManualConnectBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            ManualConnectBtn.FlatAppearance.BorderSize = 0;
            ManualConnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ManualConnectBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            ManualConnectBtn.ForeColor = System.Drawing.SystemColors.Control;
            ManualConnectBtn.Location = new System.Drawing.Point(1, 291);
            ManualConnectBtn.Name = "ManualConnectBtn";
            ManualConnectBtn.Size = new System.Drawing.Size(164, 23);
            ManualConnectBtn.TabIndex = 6;
            ManualConnectBtn.Text = "Connect To PS4Debug";
            ManualConnectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ManualConnectBtn.UseVisualStyleBackColor = false;
            ManualConnectBtn.Click += new System.EventHandler(ManualConnectBtn_Click);
            ManualConnectBtn.MouseWheel += new System.Windows.Forms.MouseEventHandler(ManualConnectBtn_Click);
            // 
            // IPBOX_E
            // 
            IPBOX_E.BackColor = System.Drawing.Color.DimGray;
            IPBOX_E.BorderStyle = System.Windows.Forms.BorderStyle.None;
            IPBOX_E.Cursor = System.Windows.Forms.Cursors.Cross;
            IPBOX_E.ForeColor = System.Drawing.SystemColors.Control;
            IPBOX_E.Location = new System.Drawing.Point(102, 228);
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
            Info.Location = new System.Drawing.Point(9, 391);
            Info.Name = "Info";
            Info.Size = new System.Drawing.Size(304, 17);
            Info.TabIndex = 7;
            Info.Text = "=======================================";
            // 
            // T1RBtn
            // 
            T1RBtn.BackColor = System.Drawing.Color.DimGray;
            T1RBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            T1RBtn.FlatAppearance.BorderSize = 0;
            T1RBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            T1RBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            T1RBtn.ForeColor = System.Drawing.SystemColors.Control;
            T1RBtn.Location = new System.Drawing.Point(1, 30);
            T1RBtn.Name = "T1RBtn";
            T1RBtn.Size = new System.Drawing.Size(193, 22);
            T1RBtn.TabIndex = 8;
            T1RBtn.Text = "The Last of Us: Remastered";
            T1RBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            T1RBtn.UseVisualStyleBackColor = false;
            T1RBtn.Click += new System.EventHandler(T1RBtn_Click);
            // 
            // T2Btn
            // 
            T2Btn.BackColor = System.Drawing.Color.DimGray;
            T2Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            T2Btn.FlatAppearance.BorderSize = 0;
            T2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            T2Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            T2Btn.ForeColor = System.Drawing.SystemColors.Control;
            T2Btn.Location = new System.Drawing.Point(1, 53);
            T2Btn.Name = "T2Btn";
            T2Btn.Size = new System.Drawing.Size(150, 22);
            T2Btn.TabIndex = 9;
            T2Btn.Text = "The Last of Us Part II";
            T2Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            T2Btn.UseVisualStyleBackColor = false;
            T2Btn.Click += new System.EventHandler(T2Btn_Click);
            // 
            // UC4Btn
            // 
            UC4Btn.BackColor = System.Drawing.Color.DimGray;
            UC4Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            UC4Btn.FlatAppearance.BorderSize = 0;
            UC4Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UC4Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            UC4Btn.ForeColor = System.Drawing.SystemColors.Control;
            UC4Btn.Location = new System.Drawing.Point(1, 146);
            UC4Btn.Name = "UC4Btn";
            UC4Btn.Size = new System.Drawing.Size(95, 22);
            UC4Btn.TabIndex = 12;
            UC4Btn.Text = "Uncharted 4";
            UC4Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UC4Btn.UseVisualStyleBackColor = false;
            UC4Btn.Click += new System.EventHandler(UC4Btn_Click);
            // 
            // BackBtn
            // 
            BackBtn.BackColor = System.Drawing.Color.DimGray;
            BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            BackBtn.FlatAppearance.BorderSize = 0;
            BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            BackBtn.Location = new System.Drawing.Point(1, 367);
            BackBtn.Name = "BackBtn";
            BackBtn.Size = new System.Drawing.Size(60, 22);
            BackBtn.TabIndex = 14;
            BackBtn.Text = "Back...";
            BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            BackBtn.UseVisualStyleBackColor = false;
            BackBtn.Click += new System.EventHandler(BackBtn_Click);
            // 
            // UC1Btn
            // 
            UC1Btn.BackColor = System.Drawing.Color.DimGray;
            UC1Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            UC1Btn.FlatAppearance.BorderSize = 0;
            UC1Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UC1Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            UC1Btn.ForeColor = System.Drawing.SystemColors.Control;
            UC1Btn.Location = new System.Drawing.Point(1, 76);
            UC1Btn.Name = "UC1Btn";
            UC1Btn.Size = new System.Drawing.Size(190, 22);
            UC1Btn.TabIndex = 15;
            UC1Btn.Text = "Uncharted: Drakes Fortune";
            UC1Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UC1Btn.UseVisualStyleBackColor = false;
            UC1Btn.Click += new System.EventHandler(UC1Btn_Click);
            // 
            // UC2Btn
            // 
            UC2Btn.BackColor = System.Drawing.Color.DimGray;
            UC2Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            UC2Btn.FlatAppearance.BorderSize = 0;
            UC2Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UC2Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            UC2Btn.ForeColor = System.Drawing.SystemColors.Control;
            UC2Btn.Location = new System.Drawing.Point(1, 99);
            UC2Btn.Name = "UC2Btn";
            UC2Btn.Size = new System.Drawing.Size(201, 23);
            UC2Btn.TabIndex = 16;
            UC2Btn.Text = "Uncharted 2: Among Thieves";
            UC2Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UC2Btn.UseVisualStyleBackColor = false;
            UC2Btn.Click += new System.EventHandler(UC2Btn_Click);
            // 
            // UC3Btn
            // 
            UC3Btn.BackColor = System.Drawing.Color.DimGray;
            UC3Btn.Cursor = System.Windows.Forms.Cursors.Cross;
            UC3Btn.FlatAppearance.BorderSize = 0;
            UC3Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UC3Btn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            UC3Btn.ForeColor = System.Drawing.SystemColors.Control;
            UC3Btn.Location = new System.Drawing.Point(1, 123);
            UC3Btn.Name = "UC3Btn";
            UC3Btn.Size = new System.Drawing.Size(219, 23);
            UC3Btn.TabIndex = 17;
            UC3Btn.Text = "Uncharted 3: Drakes Deception";
            UC3Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UC3Btn.UseVisualStyleBackColor = false;
            UC3Btn.Click += new System.EventHandler(UC3Btn_Click);
            // 
            // SeperatorLine2
            // 
            SeperatorLine2.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            SeperatorLine2.Location = new System.Drawing.Point(2, 204);
            SeperatorLine2.Name = "SeperatorLine2";
            SeperatorLine2.Size = new System.Drawing.Size(316, 16);
            SeperatorLine2.TabIndex = 20;
            SeperatorLine2.Text = "______________________________________________________________";
            // 
            // PS4DebugPayloadBtn
            // 
            PS4DebugPayloadBtn.BackColor = System.Drawing.Color.DimGray;
            PS4DebugPayloadBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            PS4DebugPayloadBtn.FlatAppearance.BorderSize = 0;
            PS4DebugPayloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            PS4DebugPayloadBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            PS4DebugPayloadBtn.ForeColor = System.Drawing.SystemColors.Control;
            PS4DebugPayloadBtn.Location = new System.Drawing.Point(1, 268);
            PS4DebugPayloadBtn.Name = "PS4DebugPayloadBtn";
            PS4DebugPayloadBtn.Size = new System.Drawing.Size(124, 23);
            PS4DebugPayloadBtn.TabIndex = 22;
            PS4DebugPayloadBtn.Text = "Send PS4Debug";
            PS4DebugPayloadBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            PS4DebugPayloadBtn.UseVisualStyleBackColor = false;
            PS4DebugPayloadBtn.Click += new System.EventHandler(DebugPayloadBtn_Click);
            // 
            // PortBox
            // 
            PortBox.BackColor = System.Drawing.Color.DimGray;
            PortBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            PortBox.Cursor = System.Windows.Forms.Cursors.Cross;
            PortBox.ForeColor = System.Drawing.SystemColors.Control;
            PortBox.Location = new System.Drawing.Point(52, 251);
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
            IPLabelBtn.Location = new System.Drawing.Point(1, 222);
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
            PortLabelBtn.Location = new System.Drawing.Point(1, 245);
            PortLabelBtn.Name = "PortLabelBtn";
            PortLabelBtn.Size = new System.Drawing.Size(47, 22);
            PortLabelBtn.TabIndex = 25;
            PortLabelBtn.Text = "Port:";
            PortLabelBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            PortLabelBtn.UseVisualStyleBackColor = false;
            PortLabelBtn.Click += new System.EventHandler(PortLabelBtn_Click);
            // 
            // SeperatorLine3
            // 
            SeperatorLine3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            SeperatorLine3.Location = new System.Drawing.Point(2, 303);
            SeperatorLine3.Name = "SeperatorLine3";
            SeperatorLine3.Size = new System.Drawing.Size(316, 16);
            SeperatorLine3.TabIndex = 26;
            SeperatorLine3.Text = "_______________________________________________________________";
            // 
            // InfoHelpBtn
            // 
            InfoHelpBtn.BackColor = System.Drawing.Color.DimGray;
            InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            InfoHelpBtn.FlatAppearance.BorderSize = 0;
            InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            InfoHelpBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            InfoHelpBtn.Location = new System.Drawing.Point(1, 319);
            InfoHelpBtn.Name = "InfoHelpBtn";
            InfoHelpBtn.Size = new System.Drawing.Size(135, 23);
            InfoHelpBtn.TabIndex = 27;
            InfoHelpBtn.Text = "Information / Help";
            InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            InfoHelpBtn.UseVisualStyleBackColor = false;
            InfoHelpBtn.Click += new System.EventHandler(InfoHelpBtn_Click);
            // 
            // CreditsBtn
            // 
            CreditsBtn.BackColor = System.Drawing.Color.DimGray;
            CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            CreditsBtn.FlatAppearance.BorderSize = 0;
            CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CreditsBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            CreditsBtn.Location = new System.Drawing.Point(1, 343);
            CreditsBtn.Name = "CreditsBtn";
            CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            CreditsBtn.Size = new System.Drawing.Size(75, 23);
            CreditsBtn.TabIndex = 28;
            CreditsBtn.Text = "Credits...";
            CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            CreditsBtn.UseVisualStyleBackColor = false;
            CreditsBtn.Click += new System.EventHandler(CreditsBtn_Click);
            // 
            // UC4MPBetaBtn
            // 
            UC4MPBetaBtn.BackColor = System.Drawing.Color.DimGray;
            UC4MPBetaBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            UC4MPBetaBtn.FlatAppearance.BorderSize = 0;
            UC4MPBetaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            UC4MPBetaBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            UC4MPBetaBtn.ForeColor = System.Drawing.SystemColors.Control;
            UC4MPBetaBtn.Location = new System.Drawing.Point(1, 169);
            UC4MPBetaBtn.Name = "UC4MPBetaBtn";
            UC4MPBetaBtn.Size = new System.Drawing.Size(153, 22);
            UC4MPBetaBtn.TabIndex = 29;
            UC4MPBetaBtn.Text = "Uncharted 4 MP Beta";
            UC4MPBetaBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            UC4MPBetaBtn.UseVisualStyleBackColor = false;
            UC4MPBetaBtn.Click += new System.EventHandler(UC4MPBetaBtn_Click);
            // 
            // PS4DebugPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.DimGray;
            ClientSize = new System.Drawing.Size(320, 413);
            Controls.Add(ExitBtn);
            Controls.Add(MinimizeBtn);
            Controls.Add(PortBox);
            Controls.Add(IPBOX_E);
            Controls.Add(UC4MPBetaBtn);
            Controls.Add(InfoHelpBtn);
            Controls.Add(ManualConnectBtn);
            Controls.Add(PortLabelBtn);
            Controls.Add(IPLabelBtn);
            Controls.Add(PS4DebugPayloadBtn);
            Controls.Add(UC3Btn);
            Controls.Add(UC1Btn);
            Controls.Add(UC4Btn);
            Controls.Add(TLLBtn);
            Controls.Add(T1RBtn);
            Controls.Add(T2Btn);
            Controls.Add(Info);
            Controls.Add(UC2Btn);
            Controls.Add(SeperatorLine2);
            Controls.Add(SeperatorLine3);
            Controls.Add(BackBtn);
            Controls.Add(CreditsBtn);
            Controls.Add(MainLabel);
            Controls.Add(SeperatorLine1);
            Controls.Add(MainBox);
            Cursor = System.Windows.Forms.Cursors.Default;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "PS4DebugPage";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "Main";
            ResumeLayout(false);
            PerformLayout();

        }

        public void BackBtn_Click(object sender, EventArgs e) {
            BackFunc();
            HoverLeave(BackBtn, false); // What Did This Fix, Again?
        }
        public void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(5, false);
        public void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(8, false);


        /* End Of Repeated Functions
        ============================================================================================================================================================================
        // Start Of PS4Debug Page Specific Functions                                                                                                                      */

        public delegate void LabelTextDel(string message);
        public static LabelTextDel SetLabelText = SetInfoLabelText;
        public static Thread ConnectionThread = new Thread(new ThreadStart(Connect));
        public static void Connect() {
            try {
            Wait:
                if (PS4DebugIsConnected) goto Wait;

                ActiveForm?.Invoke(SetLabelText, "Connecting To Console");
                Dev.DebugOut($"{PS4DebugIsConnected} | {geo?.GetProcessInfo(Executable).name != ProcessName} | {geo?.GetProcessList().processes.Length == ProcessCount}");

                geo = new PS4DBG(IPBOX_E.Text);
                geo.Connect();
                PS4DebugIsConnected = true;

                foreach(libdebug.Process process in geo.GetProcessList().processes) { // processprocessprocessprocessprocess
                    if(ExecutablesNames.Contains(process.name)) {
                        string title = geo.GetProcessInfo(process.pid).titleid;
                        if(title == "FLTZ00003" || title == "ITEM00003") {
                            Dev.DebugOut($"Skipping Lightning's Stuff {title}");
                            break;
                        } // Check To Avoid Connecting To HB Store Stuff

                        Executable = process.pid;
                        ProcessName = process.name;
                        TitleID = geo.GetProcessInfo(process.pid).titleid;
                        GameVersion = GetGameVersion();
                        ProcessCount = geo.GetProcessList().processes.Length;

                        ActiveForm?.Invoke(SetLabelText, $"Connected And Attached To {TitleID} ({GameVersion})");
                        WaitForConnection = false;
                        goto Wait;
                    }
                }
                ProcessName = "No Valid Process";
                ProcessCount = geo.GetProcessList().processes.Length;

                ActiveForm?.Invoke(SetLabelText, "Connected To PS4, But Couldn't Find The Game Process");
                WaitForConnection = false;
                goto Wait;
            }
            catch(Exception tabarnack) { if(!Dev.REL) MessageBox.Show($"{tabarnack.Message}\n{tabarnack.StackTrace}"); ActiveForm?.Invoke(SetLabelText, $"Connection To {IPBOX_E.Text} Failed"); }
        }

        public static Task CheckConnectionStatus() {
            if(ConnectionThread.ThreadState == System.Threading.ThreadState.Unstarted || ConnectionThread.ThreadState == System.Threading.ThreadState.Stopped) ConnectionThread.Start();

            else if(geo.GetProcessInfo(Executable).name != ProcessName || !ExecutablesNames.Contains(geo.GetProcessInfo(Executable).name))
            { PS4DebugIsConnected = false; WaitForConnection = true; Dev.DebugOut("!!!"); }

            while(WaitForConnection) Thread.Sleep(1);
            Dev.DebugOut("!!! " + WaitForConnection);
            return Task.CompletedTask;
        }

        public static string GetGameVersion() { // An ugly sack of WHY which determines the patch version of a specified game by just checking the int32 value of 2 bytes at a game-specific address because I have no idea how or if I can check the .sfo
            try {
                if(PS4DebugIsConnected && geo.GetProcessInfo(Executable).name == ProcessName) {

                    switch(TitleID) {     // Determine The Game That's Running
                        case "CUSA00552":
                        case "CUSA00554":
                        case "CUSA00556":
                        case "CUSA00557":
                            GameVersion = "T1R";
                            break;
                        case "CUSA10249":
                        case "CUSA14006":
                        case "CUSA07820":
                        case "CUSA13986":
                            GameVersion = "T2";
                            break;
                        case "CUSA07737":
                        case "CUSA07875":
                        case "CUSA09564":
                        case "CUSA08347":
                        case "CUSA08352":
                            GameVersion = "TLL";
                            break;
                        default: return "UnknownTitleID";
                    }

                    switch(GameVersion) { // Read A Spot In Memory To Determine Which Patch the Executable's From
                        case "T1R":
                            Int16 chk = BitConverter.ToInt16(geo.ReadMemory(Executable, 0x4000F4, 2), 0);

                            string T1RErr() {
                                Dev.DebugOut($"Error 1 (T1R)\n{chk}");
                                return "UnknownGameVersion";
                            }
                            return
                                chk == 18432 ? "1.00"
                                : chk == 3480 ? "1.XX"
                                : chk == 4488 ? "1.XX"
                                : chk == 4472 ? "1.XX"
                                : T1RErr();

                        case "T2":
                            int T2Check = BitConverter.ToInt32(geo.ReadMemory(Executable, 0x40009A, 4), 0);

                            string T2Err() {
                                Dev.DebugOut($"Error, Game Was T2 But None of The Checks Matched! || chk:{T2Check}");
                                return $"{GameVersion} UnknownGameVersion";
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

                        case "UC1": //! FINISH THIS
                            if(geo.ReadMemory(Executable, 0x4DE188, 1)[0] == 0x61) return "1.00";
                            else if(geo.ReadMemory(Executable, 0x4DE188, 1)[0] == 0x61) return "1.02";

                            break;

                        case "UC2": //! FINISH THIS
                            if(geo.ReadMemory(Executable, 0x4DE188, 1)[0] == 0x0) return "1.00";
                            else if(geo.ReadMemory(Executable, 0x4DE188, 1)[0] == 0x0F) return "1.02";

                            break;
                        case "UC3":
                            if(geo.ReadMemory(Executable, 0x4DE188, 1)[0] == 0x0) return "1.00";
                            else if(geo.ReadMemory(Executable, 0x4DE188, 1)[0] == 0x0F) return "1.02";

                            break;
                        case "UC4":
                            switch(geo.ReadMemory(Executable, 0x40002D, 1)[0]) {
                                case 0x00: return "1.00 SP";
                                case 0x01: return "1.3X SP";  // 1.32 and 1.33 have identical eboot.bin's
                                case 0x02: return "1.32 MP";
                                case 0x03: return "1.33 MP";
                            }
                            break;
                        case "TLL":
                            switch(BitConverter.ToInt16(geo.ReadMemory(Executable, 0x40003B, 2), 0)) {
                                case 3777:   return "1.00 SP";
                                case -9759:  return "1.0X SP";  // 1.08 and 1.09 have identical eboot.bin's
                                case -23679: return "1.00 MP";
                                case 27793:  return "1.08 MP";
                                case 27841:  return "1.09 MP";
                            }
                            break;
                        default: Dev.DebugOut("!!! " + tmp); return "UnknownGameVersion";
                    }
                }
                Dev.DebugOut($"Fell Out The Window, Ow");
                return "UnknownGameVersion";
            }
            catch(Exception Tabarnack) {
                Dev.DebugOut($"{Tabarnack.Message};{Tabarnack.StackTrace}");
                return "UnknownGameVersion";
            }
        }

        public static string IP() {
            try {
                var file = File.OpenText(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB");
                string v = file.ReadToEnd(); file.Dispose();
                Dev.DebugOut(v.Remove(v.IndexOf(";")));
                return v.Remove(v.IndexOf(";"));
            }
            catch(FileNotFoundException) {
                using(FileStream f = new FileStream(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB", FileMode.Create, FileAccess.Write)) {
                    Dev.DebugOut($"IP(); No Settings File Was Found, Made A New One At:\n{f.Name}");
                    f.Position = 0; f.Write(Encoding.UTF8.GetBytes("192.168.137."), 0, 12);
                    f.Position = 15; f.WriteByte(0x3B); f.Write(BitConverter.GetBytes(9020), 0, 4);
                    return "192.168.137.";
                }
            }
        }

        public void IPBOX_TextChanged(object sender, EventArgs e) {
            try {
                using(FileStream f = new FileStream(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB", FileMode.Open, FileAccess.Write)) {
                    f.Write(Encoding.UTF8.GetBytes(IPBOX_E.Text + ";"), 0, IPBOX_E.Text.Length + 1);
                  //if(IPBOX_E.Text.Length > 12) Dev.DebugOut($"Saved {IPBOX_E.Text} As I.P.");
                }
            }
            catch(FileNotFoundException) { IP(); }
            catch(Exception tabarnack) { Dev.DebugOut(tabarnack.Message + $"\n{tabarnack.StackTrace}"); }
        }

        public int Port() {
            try {
                byte[] dat = new byte[4];
                var file = File.OpenRead(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB");
                file.Position = 16; file.Read(dat, 0, 4); file.Close();
                return BitConverter.ToInt32(dat, 0);
            }
            catch(FileNotFoundException) {
                using(FileStream f = new FileStream(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB", FileMode.Open, FileAccess.Write)) {
                    Dev.DebugOut($"Port(); No Settings File Was Found, Made A New One At:\n{f.Name}");
                    f.Write(Encoding.UTF8.GetBytes("192.168.137."), 0, 12);
                    f.Position = 15; f.WriteByte(0x3B); f.Write(BitConverter.GetBytes(9020), 0, 4);
                    return 9020;
                }
            }
        }

        public void PortBox_TextChanged(object sender, EventArgs e) {
            if(PortBox.Text.Length < 4) return;
            try {
                using(FileStream f = new FileStream(Directory.GetCurrentDirectory() + @"\PS4_IP.BLB", FileMode.Open, FileAccess.Write)) {
                    f.Position = 16; f.Write(BitConverter.GetBytes(int.Parse(PortBox.Text)), 0, 4);
                    Dev.DebugOut($"Saved {PortBox.Text} As Port");
                }
            }
            catch(Exception tabarnack) {
                Dev.DebugOut($"{tabarnack.Message};{tabarnack.StackTrace}");
                Port();
            }
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
                            var RawPointer = BitConverter.ToInt64(geo.ReadMemory(Executable, Addresses[AddressIndex], 8), 0);

                            Dev.DebugOut($"Pointer: {RawPointer:X}");
                            ulong pointer = (ulong)(RawPointer + (GameVersion.Contains("SP") ? 0x2EF9 : 0x2E79));
                            Dev.DebugOut($"About To Toggle Byte At 0x{pointer:X}");
                            geo.WriteMemory(Executable, pointer, geo.ReadMemory(Executable, pointer, 1)[0] == 0x00 ? on : off);

                            Dev.DebugOut($"Version Was {Version}, Wrote To 0x{pointer:X} in {geo.GetProcessInfo(Executable).name}/{Executable}");
                        }
                        else if(AddressIndex != Addresses.Length - 1) AddressIndex++;
                }
            }
            catch(Exception tabarnack) { Dev.DebugOut(tabarnack.Message); }
        }

        /// <summary>
        /// Toggles A Byte At The Given Address
        /// </summary>
        /// <param name="Address">Address To Read/Write To</param>
        public static void Toggle(ulong Address) {
            try {
                if (PS4DebugIsConnected && geo.GetProcessInfo(Executable).name == ProcessName) {
                    geo.WriteMemory(Executable, Address, geo.ReadMemory(Executable, Address, 1)[0] == 0x00 ? on : off);
                    Dev.DebugOut($"Wrote To 0x{Address:X} in {geo.GetProcessInfo(Executable).name}/{Executable}");
                }
            }
            catch (Exception tabarnack) { Dev.DebugOut(tabarnack.Message); }
        }

        public void Toggle(ulong[] AddressArray) { // Just For The Uncharted Collection
            try {
                if (PS4DebugIsConnected && geo.GetProcessInfo(Executable).name == ProcessName)
                    foreach (ulong Address in AddressArray) {
                        geo.WriteMemory(Executable, Address, geo.ReadMemory(Executable, Address, 1)[0] == 0x00 ? on : off);
                        Dev.DebugOut($"Wrote To 0x{Address:X} in {geo.GetProcessInfo(Executable).name}/{Executable}");
                    }
            }
            catch (Exception tabarnack) { Dev.DebugOut(tabarnack.Message); }
        }



        public void IPLabelBtn_Click(object sender, EventArgs e) => IPBOX_E.Focus();
        public void PortLabelBtn_Click(object sender, EventArgs e) => PortBox.Focus();

        public void DebugPayloadBtn_Click(object sender, EventArgs e) {
            Socket S = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            S.Connect(new IPEndPoint(IPAddress.Parse(IPBOX_E.Text), int.Parse(PortBox.Text)));
            S.Send(Properties.Resources.PS4Debug1_1_15);
            SetInfoLabelText("Payload Injected Successfully");
            S.Close();
            // Excessive Credits To Try Avoiding Beef lol
            MessageBox.Show("PS4Debug Paylod Sent Without Issue\n\nPS4Debug Update 1.1.15 By ctn123\nPS4Debug Created By Golden", "Payload Injected Successfully, Here's Some Credits");
        }

        private void ManualConnectBtn_Click(object sender, EventArgs e) {
            if(ConnectionThread.ThreadState == System.Threading.ThreadState.Unstarted)
            ConnectionThread.Start();
            PS4DebugIsConnected = false;
        }
        private async void T1RBtn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(!GameVersion.Contains("Unknown"))
                Toggle(GameVersion == "1.00" ? 0x114ED32E81 : GameVersion == "UnknownGameVersion" ? (ulong)0x0 : 0x114F536E81);
        }
        private async void T2Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(!GameVersion.Contains("Unknown"))
                Toggle(GameVersion == "1.00" ? (ulong)0x110693FAA1 : 0x11069DFAA1);
        }
        private async void UC1Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(!GameVersion.Contains("Unknown"))
                Toggle(GameVersion == "1.00" ? new ulong[] { 0xD97B41, 0xD989CC, 0xD98970 } : new ulong[] { 0xD5C9F0, 0xD5CA4C, 0xD5BBC1 });
        }
        private async void UC2Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(!GameVersion.Contains("Unknown"))
                Toggle(GameVersion == "1.00" ? new ulong[] { 0x127149C, 0x12705C9 } : new ulong[] { 0x145decc, 0x145cff9, 0x145de61 });
        }
        private async void UC3Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(!GameVersion.Contains("Unknown"))
                Toggle(new ulong[] { 0x18366c9, 0x1e21f90, 0x18366C4 });
        }
        private async void UC4Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(!GameVersion.Contains("Unknown"))
                Toggle(new ulong[] { 0x1104FC2E95 }, new string[] { "1.00" });
        }
        private async void UC4MPBetaBtn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(!GameVersion.Contains("Unknown"))
                Toggle(0x113408AE83);
        }
        private async void UCTLLBtn(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(GameVersion.Contains("Unknown")) return;
            Toggle(new ulong[] { 0x26b4558, 0x26c0698, 0x0274cd00, 0x275cd00, 0xDEADBEEF }, new string[] { "1.00 SP", " 1.0X SP", "1.00 MP", "1.08 MP", "1.09 MP" });
        }

        public Button ExitBtn;
        public Button MinimizeBtn;
        public GroupBox MainBox;
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
        public static TextBox IPBOX_E;
        public Button ManualConnectBtn;
        public Button PortLabelBtn;
        public TextBox PortBox;
        public Button PS4DebugPayloadBtn;
        public Label SeperatorLine1;
        public Label SeperatorLine2;
        public Label SeperatorLine3;
        public Button EPPBackBtn;
        public Button UC4MPBetaBtn;
        public Button button2;
        public Button InfoHelpBtn;
        public Button CreditsBtn;
        public Button BackBtn;
        public Label Info;
    }
}
