using System;
using System.IO;
using System.Drawing;
using static Dobby.Common;
using System.Windows.Forms;
using libdebug;
using libgp4;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Dobby {
    public class Gp4CreationPage : Form {

        public Gp4CreationPage() { //! Page Unfinished, Only Base Functionality Added
            InitializeComponent();
            
            InitializeAdditionalEventHandlers(Controls);


            foreach(Control control in Controls) {
                if(control.Name.Contains("PathLabel")) {
                    control.MouseEnter += new EventHandler(HighlightPathLabel);
                    control.MouseLeave += new EventHandler(HighlightPathLabel);
                }
            }
        }

        bool VerboseOutput = true, SpecifyTMPDirectory = false, IsFirstOpen = true, IsBuildReady;
        private GP4Creator gp4;
        private Label AppDataPathLabel;
        private TextBox AppDataPathBox;
        private Button AppDataPathBtn;
        private Label SeperatorLine1;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Label label3;
        private TextBox textBox2;
        private Button PasscodeBtn;
        private Label label4;
        private TextBox textBox3;
        private Button button3;
        private Label label5;
        private TextBox textBox4;
        private Button button2;
        private Label SeperatorLine2;
        private Label SeperatorLine3;
        private Button VerbosityBtn;
        private Button button4;


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
            this.Info = new System.Windows.Forms.Label();
            this.MainLabel = new System.Windows.Forms.Label();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.SeperatorLine4 = new System.Windows.Forms.Label();
            this.AppDataPathLabel = new System.Windows.Forms.Label();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.textBox4 = new Dobby.TextBox();
            this.button2 = new Dobby.Button();
            this.textBox2 = new Dobby.TextBox();
            this.PasscodeBtn = new Dobby.Button();
            this.textBox3 = new Dobby.TextBox();
            this.button3 = new Dobby.Button();
            this.textBox1 = new Dobby.TextBox();
            this.button1 = new Dobby.Button();
            this.AppDataPathBox = new Dobby.TextBox();
            this.AppDataPathBtn = new Dobby.Button();
            this.StartGp4CreationBtn = new Dobby.Button();
            this.InfoHelpBtn = new Dobby.Button();
            this.BackBtn = new Dobby.Button();
            this.CreditsBtn = new Dobby.Button();
            this.SeperatorLine3 = new System.Windows.Forms.Label();
            this.VerbosityBtn = new Dobby.Button();
            this.button4 = new Dobby.Button();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(6, 451);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(395, 19);
            this.Info.TabIndex = 7;
            this.Info.Text = "======================================";
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(1, 1);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(314, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "GP4 Creation Page";
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine0.TabIndex = 33;
            this.SeperatorLine0.Text = "--------------------------------------------------------------";
            // 
            // SeperatorLine4
            // 
            this.SeperatorLine4.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine4.Location = new System.Drawing.Point(0, 368);
            this.SeperatorLine4.Name = "SeperatorLine4";
            this.SeperatorLine4.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine4.TabIndex = 29;
            this.SeperatorLine4.Text = "--------------------------------------------------------------";
            // 
            // AppDataPathLabel
            // 
            this.AppDataPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppDataPathLabel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.AppDataPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.AppDataPathLabel.Location = new System.Drawing.Point(4, 64);
            this.AppDataPathLabel.Name = "AppDataPathLabel";
            this.AppDataPathLabel.Size = new System.Drawing.Size(166, 14);
            this.AppDataPathLabel.TabIndex = 73;
            this.AppDataPathLabel.Text = "Application/Patch Data Path:";
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(-2, 48);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(391, 15);
            this.SeperatorLine1.TabIndex = 64;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(4, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 14);
            this.label1.TabIndex = 76;
            this.label1.Text = ".gp4 Project Output Directory:";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(4, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 14);
            this.label3.TabIndex = 82;
            this.label3.Text = "Package Passcode:";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(4, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 14);
            this.label4.TabIndex = 79;
            this.label4.Text = "File/Folder Blacklist:";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(4, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 14);
            this.label5.TabIndex = 85;
            this.label5.Text = "Base Game Package Directory:";
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(-2, 104);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(391, 15);
            this.SeperatorLine2.TabIndex = 86;
            this.SeperatorLine2.Text = "--------------------------------------------------------------";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.textBox4.Font = new System.Drawing.Font("Cambria", 10F);
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.textBox4.Location = new System.Drawing.Point(11, 184);
            this.textBox4.MaxLength = 32;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(335, 23);
            this.textBox4.TabIndex = 83;
            this.textBox4.Text = "Leave Empty During Application Creation";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Cambria", 7F);
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(350, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 19);
            this.button2.TabIndex = 84;
            this.button2.Text = "Browse";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.textBox2.Font = new System.Drawing.Font("Cambria", 10F);
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.textBox2.Location = new System.Drawing.Point(11, 274);
            this.textBox2.MaxLength = 32;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(335, 23);
            this.textBox2.TabIndex = 80;
            this.textBox2.Text = "00000000000000000000000000000000000";
            // 
            // PasscodeBtn
            // 
            this.PasscodeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.PasscodeBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PasscodeBtn.FlatAppearance.BorderSize = 0;
            this.PasscodeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasscodeBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.PasscodeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.PasscodeBtn.Location = new System.Drawing.Point(350, 274);
            this.PasscodeBtn.Name = "PasscodeBtn";
            this.PasscodeBtn.Size = new System.Drawing.Size(51, 19);
            this.PasscodeBtn.TabIndex = 81;
            this.PasscodeBtn.Text = "Browse";
            this.PasscodeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PasscodeBtn.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.textBox3.Font = new System.Drawing.Font("Cambria", 10F);
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.textBox3.Location = new System.Drawing.Point(11, 229);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(335, 23);
            this.textBox3.TabIndex = 77;
            this.textBox3.Text = "Blacklisted Files/Folders To Exclude, Seperated By ; or ,";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Cross;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Cambria", 7F);
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(350, 229);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 19);
            this.button3.TabIndex = 78;
            this.button3.Text = "Browse";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.textBox1.Font = new System.Drawing.Font("Cambria", 10F);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.textBox1.Location = new System.Drawing.Point(11, 139);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 23);
            this.textBox1.TabIndex = 74;
            this.textBox1.Text = "Using Default Output Directory";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Cambria", 7F);
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(350, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 19);
            this.button1.TabIndex = 75;
            this.button1.Text = "Browse";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // AppDataPathBox
            // 
            this.AppDataPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.AppDataPathBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.AppDataPathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.AppDataPathBox.Location = new System.Drawing.Point(11, 82);
            this.AppDataPathBox.Name = "AppDataPathBox";
            this.AppDataPathBox.Size = new System.Drawing.Size(335, 23);
            this.AppDataPathBox.TabIndex = 65;
            this.AppDataPathBox.Text = "Add Application Data Path Here";
            // 
            // AppDataPathBtn
            // 
            this.AppDataPathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.AppDataPathBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.AppDataPathBtn.FlatAppearance.BorderSize = 0;
            this.AppDataPathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AppDataPathBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.AppDataPathBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.AppDataPathBtn.Location = new System.Drawing.Point(350, 82);
            this.AppDataPathBtn.Name = "AppDataPathBtn";
            this.AppDataPathBtn.Size = new System.Drawing.Size(51, 19);
            this.AppDataPathBtn.TabIndex = 69;
            this.AppDataPathBtn.Text = "Browse";
            this.AppDataPathBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AppDataPathBtn.UseVisualStyleBackColor = false;
            // 
            // StartGp4CreationBtn
            // 
            this.StartGp4CreationBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.StartGp4CreationBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.StartGp4CreationBtn.FlatAppearance.BorderSize = 0;
            this.StartGp4CreationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartGp4CreationBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.StartGp4CreationBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.StartGp4CreationBtn.Location = new System.Drawing.Point(3, 28);
            this.StartGp4CreationBtn.Name = "StartGp4CreationBtn";
            this.StartGp4CreationBtn.Size = new System.Drawing.Size(309, 23);
            this.StartGp4CreationBtn.TabIndex = 23;
            this.StartGp4CreationBtn.Text = "Build .gp4 File";
            this.StartGp4CreationBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StartGp4CreationBtn.UseVisualStyleBackColor = false;
            this.StartGp4CreationBtn.Click += new System.EventHandler(this.StartGp4CreationBtn_Click);
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(-1, 382);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(309, 23);
            this.InfoHelpBtn.TabIndex = 15;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(-1, 428);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(309, 23);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(-1, 404);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(309, 23);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // SeperatorLine3
            // 
            this.SeperatorLine3.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine3.Location = new System.Drawing.Point(-2, 300);
            this.SeperatorLine3.Name = "SeperatorLine3";
            this.SeperatorLine3.Size = new System.Drawing.Size(316, 15);
            this.SeperatorLine3.TabIndex = 87;
            this.SeperatorLine3.Text = "--------------------------------------------------------------";
            // 
            // VerbosityBtn
            // 
            this.VerbosityBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.VerbosityBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.VerbosityBtn.FlatAppearance.BorderSize = 0;
            this.VerbosityBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerbosityBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.VerbosityBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.VerbosityBtn.Location = new System.Drawing.Point(3, 318);
            this.VerbosityBtn.Name = "VerbosityBtn";
            this.VerbosityBtn.Size = new System.Drawing.Size(225, 23);
            this.VerbosityBtn.TabIndex = 88;
            this.VerbosityBtn.Text = "Verbose Program Output: Disabled";
            this.VerbosityBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VerbosityBtn.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Cross;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.SystemColors.Control;
            this.button4.Location = new System.Drawing.Point(3, 343);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(225, 23);
            this.button4.TabIndex = 89;
            this.button4.Text = "Ignore Old Keystone File: Disabled";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // Gp4CreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(405, 474);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.VerbosityBtn);
            this.Controls.Add(this.SeperatorLine3);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.PasscodeBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AppDataPathLabel);
            this.Controls.Add(this.AppDataPathBox);
            this.Controls.Add(this.AppDataPathBtn);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.StartGp4CreationBtn);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.SeperatorLine4);
            this.Controls.Add(this.SeperatorLine0);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Gp4CreationPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion



        private void LabelTextBoxToggle(Control sender) {

        }


        private void PasscodeLabel_Click(object sender, EventArgs e) {

        }

        /// <summary> Load orbis-pub-cmd.exe Binary And The Reqired .gp4 file If The Path Is Right
        private void FilterArrayTextBox_TextChanged(object sender, EventArgs e) { // tst : eboot.bin, keystone, discname.txt; param.sfo
        }

        private void StartGp4CreationBtn_Click(object sender, EventArgs e) {
        }

        void HighlightPathLabel(object sender, EventArgs e) {
            var Sender = sender as Control;

            if(Sender.Font.Underline)
                Sender.Font = new Font("Georgia", 9.75F);
            else
                Sender.Font = new Font("Georgia", 9.75F, FontStyle.Underline);
        }

        private void SourcePkgPathBrowseBtn_Click(object sender, EventArgs e) {
            FileDialog file = new OpenFileDialog {
                Filter = ".gp4 Project File|*.gp4",
                Title = "Select Your .gp4 File"
            };

            if(file.ShowDialog() == DialogResult.OK)
                gp4.BasePackagePath = file.FileName;
            else return;
        }

        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Repeated Page Functions & Control Declarations     --\\\
        /////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region Repeat Functions & Control Declarations
        public void BackBtn_Click(object sender, EventArgs e) {
            LabelShouldFlash = false;
            ReturnToPreviousPage();
        }

        private void InfoHelpBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.InfoHelpPage);
        private void CreditsBtn_Click(object sender, EventArgs e) => ChangeForm(PageID.CreditsPage);

        private Button InfoHelpBtn;
        private Button BackBtn;
        private Label Info;
        private Button CreditsBtn;
        private Label MainLabel;
        private Button StartGp4CreationBtn;
        private Label SeperatorLine4;
        private Label SeperatorLine0;
        #endregion
    }
}
