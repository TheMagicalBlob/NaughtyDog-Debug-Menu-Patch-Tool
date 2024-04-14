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
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace Dobby {
    public class PkgCreationPage : Form {
        public PkgCreationPage() {
            InitializeComponent();
            
            AddEventHandlersToControls(Controls);

            foreach(Control control in Controls) {
                if(control.Name.Contains("PathBox") || control.Name.Contains("DirectoryBox")) {
                    control.MouseEnter += new EventHandler(UnderlinePathLabel);
                    control.MouseLeave += new EventHandler(UnderlinePathLabel);
                    //control.MouseLeave += new EventHandler(ResetPathLabel);
                }
            }


            OutputPath = Directory.GetCurrentDirectory();
        }




        //////////////////\\\\\\\\\\\\\\\\\
        ///--     Page Variables      --\\\
        //////////////////\\\\\\\\\\\\\\\\\

        #if DEBUG
        public static bool debug = false;
        public static object[] DebugPeek() {
            return new object[] {
                OrbisToolPath,
                GP4Path,
                TMPDirectory,
                OutputPath,
                VerboseOutput,
                UseCstmTMPDirectory
            };
        }

        private static string
        #else
        private string
#endif
            OrbisToolPath = "?",
            GP4Path       = "?",
            TMPDirectory  = "?",
            OutputPath    = "?"
        ;

        #if DEBUG
        private static string[]
        #else
        private string[]
#endif
            VerbosityExt = new string[] { "Details", "Progress Bar" },
            TMPDirExt    = new string[] { "On"     , "Off" }
        ;
        
        #if DEBUG
        private static int
        #else
        private int
#endif
            VerboseOutput = 0,
            UseCstmTMPDirectory = 0
        ;


        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Page Background Functions      --\\\
        ///////////////////////\\\\\\\\\\\\\\\\\\\\\\\
        #region Page Background Functions
        private void ScanForOrbisPubTools() {
            return; // Too Sus

            FileStream stream;
            byte[] Check = new byte[4];
            
            var FilesInCurrentDirectory = Directory.GetFiles(Directory.GetCurrentDirectory());

            foreach(var file in FilesInCurrentDirectory) {
                if(file.Contains("out.txt"))
                    continue;

                using(stream = File.OpenRead(file)) {
                    stream.Position = 0x100;
                    stream.Read(Check, 0, 4);

                    if(Check.SequenceEqual(new byte[] { 0x46, 0xD1, 0xB8 }) || Check.SequenceEqual(new byte[] { 0x50, 0x45, 0x00 }) || file.Contains("orbis-pub-cmd") || file.Contains("-keystone")) {
                        CmdPathBox.Text = OrbisToolPath = file;

                        Dev.MsgOut($"{file}\\{OrbisToolPath} Set As OrbisPubCmdPath");
                        return;
                    }
                }
            }


            /* A Bit Of An Intrusion, And Still Sus Even If The Exact Intent's Explicitly Stated
            for(; i < FoldersInCurrentDirectory.Length; ) {
                FilesInCurrentDirectory = Directory.GetFiles(FoldersInCurrentDirectory[i++]);
                goto CheckFiles;
            }
            */
        }


        /// <summary> "Toggle" Underline Font Styling To Path Boxes </summary>
        private void UnderlinePathLabel(object sender, EventArgs e) {
            var Sender = sender as TextBox;

            Sender.Font = Sender.Font.Underline ? new Font("Cambria", Sender.Font.Size) : new Font("Cambria", Sender.Font.Size, FontStyle.Underline);
        }


        /// <summary>
        /// addme
        /// </summary>
        private void LaunchOrbisPubCmdBtn_Click(object sender, EventArgs e) {
            if(!File.Exists(OrbisToolPath)) {
                if (MessageBox.Show("A Valid Path To The Fake Package / fpkg Toolset Was Not Provided, Would You Like To Scan The Current Folder For Publishing Tools Folder?", "Toolset Not Found, Provide A Valid Path",
                    MessageBoxButtons.YesNo) == DialogResult.OK)
                    ScanForOrbisPubTools(); // Maybe Just Remove This And Make Them Do It Themselves
                return;
            }

            else if(!File.Exists(GP4Path)) {
                if(MessageBox.Show("orbis-pub-cmd.exe And A .gp4 Are Necessary For .pkg Creation, Create New .gp4?", string.Empty,
                    MessageBoxButtons.YesNo) == DialogResult.OK)
                  //CreateNewGP4();
                return;
            }


            // Set Output Directory As The Current Directory Dobby's In
            if(!Directory.Exists(OutputPath))
                OutputPath = GP4Path.Remove(GP4Path.LastIndexOf(@"\"));

            string Parameters = $"img_create --oformat pkg  {((VerboseOutput == 1) ? "--no_progress_bar" : string.Empty)} --skip_digest {((UseCstmTMPDirectory == 1) ? $"--tmp_path \"{TMPDirectory}\"" : string.Empty)} \"{GP4Path}\" \"{OutputPath}\" > \"C:\\Users\\Blob\\Desktop\\out.txt\"";
#if DEBUG
            Dev.StartReadLogTest();
#endif
            System.Diagnostics.Process.Start(OrbisToolPath, Parameters);
            Dev.MsgOut(Parameters);
#if !DEBUG
            MessageBox.Show(Parameters);
#endif

            MessageBox.Show(".pkg Creation Started; If The CMD Window Just Closes Immediately, Something Is Wrong With Your .gp4 Or Gamedata (Likely The Latter). Check Info/Help Page -> Pkg Creation Page Help");
        }


        /// <summary> Invert the VerboseOutput bool And Replace The Last Word In The Button Text To Reflect The Change
        /// </summary>
        private void VerbosityBtn_Click(object sender, EventArgs e) =>
            ((Control)sender).Text = ((Control)sender).Text.Remove(((Control)sender).Text.IndexOf(VerbosityExt[VerboseOutput]) )
                                   + VerbosityExt[VerboseOutput ^= 1];


        /// <summary> Toggle Whether Or Not To Add The -tmp-
        /// </summary>
        private void TempDirectoryBtn_Click(object sender, EventArgs e) {
            var Sender = ((Control)sender);
            Sender.Text = Sender.Text.Remove(Sender.Text.LastIndexOf(' ') + 1) + TMPDirExt[UseCstmTMPDirectory ^= 1];

            if(UseCstmTMPDirectory == 0) {
                TMPDirectory = string.Empty;
                TMPDirectoryBox.Text = "Using This PC's Default TMP Directory";
                return;
            }

            TMPDirectoryBox.Text = TMPDirectory = $"{Directory.GetCurrentDirectory()}\\TMP";
            Update();
        }
#endregion


        /////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Path Box/Button Interactions      --\\\
        /////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary> Load orbis-pub-cmd.exe Binary And The Reqired .gp4 file If The Path Is Right
        /// </summary>
        private void CmdPath_Interact(object sender, EventArgs e) {
            if(((Control)sender).GetType() == typeof(Button)) {
                using(FileDialog fileDialog = new OpenFileDialog { Filter = "Executable|*.exe", Title = "Select orbis-pub-cmd.exe" })
                    if(fileDialog.ShowDialog() == DialogResult.OK)
                        CmdPathBox.Text = OrbisToolPath = fileDialog.FileName;
            }
            else
                if(File.Exists(((Control)sender).Text.Replace("\"", "")))
                    CmdPathBox.Text = OrbisToolPath = ((Control)sender).Text.Replace("\"", "");
        }

        /// <summary>
        /// addme
        /// </summary>
        private void GP4Path_Interact(object sender, EventArgs e) {
            if(((Control)sender).GetType() == typeof(Button)) {
                using(FileDialog fileDialog = new OpenFileDialog { Filter = ".gp4 Project File|*.gp4", Title = "Select Your .gp4 File"  })
                    if(fileDialog.ShowDialog() == DialogResult.OK)
                        GP4PathBox.Text = GP4Path = fileDialog.FileName;
            }
            else
                if(File.Exists(((Control)sender).Text.Replace("\"", "")))
                    GP4PathBox.Text = GP4Path = ((Control)sender).Text.Replace("\"", "");
        }

        /// <summary>
        /// addme
        /// </summary>
        private void OutputDirectory_Interact(object sender, EventArgs e) {
            if(((Control)sender).GetType() == typeof(Button)) {
                using(FolderBrowserDialog Folder = new FolderBrowserDialog { Description = "Chose A Directory You Want The Finished .pkg To Go, Or Close This Window To Use The App Directory" })
                    if(Folder.ShowDialog() == DialogResult.OK)
                        OutputDirectoryBox.Text = OutputPath = Folder.SelectedPath;
            }
            else
                if(Directory.Exists(((Control)sender).Text.Replace("\"", "")))
                    OutputDirectoryBox.Text = OutputPath = ((Control)sender).Text.Replace("\"", "");
        }

        /// <summary>
        /// addme
        /// </summary>
        private void TMPDirectoryItem_Interaction(object sender, EventArgs e) {
            if(((Control)sender).GetType() == typeof(Button)) {
                using(FolderBrowserDialog Folder = new FolderBrowserDialog { Description = "Chose A Temp Directory For Files Created During The .pkg Build Process" })
                    if(Folder.ShowDialog() == DialogResult.OK)
                        TMPDirectoryBox.Text = TMPDirectory = Folder.SelectedPath;
            }
            else
                if(Directory.Exists(((Control)sender).Text.Replace("\"", "")))
                TMPDirectoryBox.Text = TMPDirectory = ((Control)sender).Text.Replace("\"", "");
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
        private void InitializeComponent() {
            this.InfoHelpBtn = new System.Windows.Forms.Button();
            this.SeperatorLine2 = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.CreditsBtn = new System.Windows.Forms.Button();
            this.MainLabel = new System.Windows.Forms.Label();
            this.SeperatorLine0 = new System.Windows.Forms.Label();
            this.LaunchOrbisPubCmdBtn = new System.Windows.Forms.Button();
            this.VerbosityBtn = new System.Windows.Forms.Button();
            this.SeperatorLine1 = new System.Windows.Forms.Label();
            this.TempDirectoryBtn = new System.Windows.Forms.Button();
            this.CmdPathBox = new System.Windows.Forms.TextBox();
            this.CmdPathBtn = new System.Windows.Forms.Button();
            this.GP4PathBox = new System.Windows.Forms.TextBox();
            this.GP4PathBtn = new System.Windows.Forms.Button();
            this.OutputDirectoryBox = new System.Windows.Forms.TextBox();
            this.OutputDirectoryBtn = new System.Windows.Forms.Button();
            this.TMPDirectoryBox = new System.Windows.Forms.TextBox();
            this.TMPDirectoryBtn = new System.Windows.Forms.Button();
            this.OrbisToolPathLabel = new System.Windows.Forms.Label();
            this.Gp4PathLabel = new System.Windows.Forms.Label();
            this.OutputDirectoryLabel = new System.Windows.Forms.Label();
            this.TmpDirectoryLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InfoHelpBtn
            // 
            this.InfoHelpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.InfoHelpBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InfoHelpBtn.FlatAppearance.BorderSize = 0;
            this.InfoHelpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InfoHelpBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.InfoHelpBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.InfoHelpBtn.Location = new System.Drawing.Point(1, 293);
            this.InfoHelpBtn.Name = "InfoHelpBtn";
            this.InfoHelpBtn.Size = new System.Drawing.Size(151, 21);
            this.InfoHelpBtn.TabIndex = 15;
            this.InfoHelpBtn.Text = "Information / Help...";
            this.InfoHelpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InfoHelpBtn.UseVisualStyleBackColor = false;
            this.InfoHelpBtn.Click += new System.EventHandler(this.InfoHelpBtn_Click);
            // 
            // SeperatorLine2
            // 
            this.SeperatorLine2.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine2.Location = new System.Drawing.Point(2, 279);
            this.SeperatorLine2.Name = "SeperatorLine2";
            this.SeperatorLine2.Size = new System.Drawing.Size(391, 15);
            this.SeperatorLine2.TabIndex = 14;
            this.SeperatorLine2.Text = "--------------------------------------------------------------";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(1, 340);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(151, 21);
            this.BackBtn.TabIndex = 13;
            this.BackBtn.Text = "Back...";
            this.BackBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(1, 368);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(393, 19);
            this.Info.TabIndex = 7;
            this.Info.Text = "================================================";
            // 
            // CreditsBtn
            // 
            this.CreditsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CreditsBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CreditsBtn.FlatAppearance.BorderSize = 0;
            this.CreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.CreditsBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CreditsBtn.Location = new System.Drawing.Point(1, 316);
            this.CreditsBtn.Name = "CreditsBtn";
            this.CreditsBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CreditsBtn.Size = new System.Drawing.Size(151, 20);
            this.CreditsBtn.TabIndex = 28;
            this.CreditsBtn.Text = "Credits...";
            this.CreditsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreditsBtn.UseVisualStyleBackColor = false;
            this.CreditsBtn.Click += new System.EventHandler(this.CreditsBtn_Click);
            // 
            // MainLabel
            // 
            this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.MainLabel.Location = new System.Drawing.Point(1, 1);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(393, 22);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "fPKG Creation Page";
            // 
            // SeperatorLine0
            // 
            this.SeperatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine0.Location = new System.Drawing.Point(2, 15);
            this.SeperatorLine0.Name = "SeperatorLine0";
            this.SeperatorLine0.Size = new System.Drawing.Size(391, 15);
            this.SeperatorLine0.TabIndex = 33;
            this.SeperatorLine0.Text = "--------------------------------------------------------------";
            // 
            // LaunchOrbisPubCmdBtn
            // 
            this.LaunchOrbisPubCmdBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.LaunchOrbisPubCmdBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.LaunchOrbisPubCmdBtn.FlatAppearance.BorderSize = 0;
            this.LaunchOrbisPubCmdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LaunchOrbisPubCmdBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.LaunchOrbisPubCmdBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.LaunchOrbisPubCmdBtn.Location = new System.Drawing.Point(1, 29);
            this.LaunchOrbisPubCmdBtn.Name = "LaunchOrbisPubCmdBtn";
            this.LaunchOrbisPubCmdBtn.Size = new System.Drawing.Size(101, 23);
            this.LaunchOrbisPubCmdBtn.TabIndex = 23;
            this.LaunchOrbisPubCmdBtn.Text = "Build .pkg File";
            this.LaunchOrbisPubCmdBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LaunchOrbisPubCmdBtn.UseVisualStyleBackColor = false;
            this.LaunchOrbisPubCmdBtn.Click += new System.EventHandler(this.LaunchOrbisPubCmdBtn_Click);
            // 
            // VerbosityBtn
            // 
            this.VerbosityBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.VerbosityBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.VerbosityBtn.FlatAppearance.BorderSize = 0;
            this.VerbosityBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VerbosityBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.VerbosityBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.VerbosityBtn.Location = new System.Drawing.Point(1, 54);
            this.VerbosityBtn.Name = "VerbosityBtn";
            this.VerbosityBtn.Size = new System.Drawing.Size(270, 23);
            this.VerbosityBtn.TabIndex = 35;
            this.VerbosityBtn.Text = "orbis-pub-cmd Output Mode: Details";
            this.VerbosityBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VerbosityBtn.UseVisualStyleBackColor = false;
            this.VerbosityBtn.Click += new System.EventHandler(this.VerbosityBtn_Click);
            // 
            // SeperatorLine1
            // 
            this.SeperatorLine1.Font = new System.Drawing.Font("Cambria", 10F);
            this.SeperatorLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.SeperatorLine1.Location = new System.Drawing.Point(2, 100);
            this.SeperatorLine1.Name = "SeperatorLine1";
            this.SeperatorLine1.Size = new System.Drawing.Size(391, 15);
            this.SeperatorLine1.TabIndex = 29;
            this.SeperatorLine1.Text = "--------------------------------------------------------------";
            // 
            // TempDirectoryBtn
            // 
            this.TempDirectoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TempDirectoryBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.TempDirectoryBtn.FlatAppearance.BorderSize = 0;
            this.TempDirectoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TempDirectoryBtn.Font = new System.Drawing.Font("Cambria", 9.25F, System.Drawing.FontStyle.Bold);
            this.TempDirectoryBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.TempDirectoryBtn.Location = new System.Drawing.Point(1, 79);
            this.TempDirectoryBtn.Name = "TempDirectoryBtn";
            this.TempDirectoryBtn.Size = new System.Drawing.Size(209, 23);
            this.TempDirectoryBtn.TabIndex = 39;
            this.TempDirectoryBtn.Text = "Use Custom Temp Directory: No";
            this.TempDirectoryBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TempDirectoryBtn.UseVisualStyleBackColor = false;
            this.TempDirectoryBtn.Click += new System.EventHandler(this.TempDirectoryBtn_Click);
            // 
            // CmdPathBox
            // 
            this.CmdPathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CmdPathBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.CmdPathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.CmdPathBox.Location = new System.Drawing.Point(11, 130);
            this.CmdPathBox.Name = "CmdPathBox";
            this.CmdPathBox.Size = new System.Drawing.Size(335, 23);
            this.CmdPathBox.TabIndex = 50;
            this.CmdPathBox.Text = "No Program Path Loaded";
            this.CmdPathBox.TextChanged += new System.EventHandler(this.CmdPath_Interact);
            // 
            // CmdPathBtn
            // 
            this.CmdPathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CmdPathBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CmdPathBtn.FlatAppearance.BorderSize = 0;
            this.CmdPathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmdPathBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.CmdPathBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CmdPathBtn.Location = new System.Drawing.Point(350, 130);
            this.CmdPathBtn.Name = "CmdPathBtn";
            this.CmdPathBtn.Size = new System.Drawing.Size(51, 19);
            this.CmdPathBtn.TabIndex = 55;
            this.CmdPathBtn.Text = "Browse";
            this.CmdPathBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmdPathBtn.UseVisualStyleBackColor = false;
            this.CmdPathBtn.Click += new System.EventHandler(this.CmdPath_Interact);
            // 
            // GP4PathBox
            // 
            this.GP4PathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GP4PathBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.GP4PathBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.GP4PathBox.Location = new System.Drawing.Point(11, 172);
            this.GP4PathBox.Name = "GP4PathBox";
            this.GP4PathBox.Size = new System.Drawing.Size(335, 23);
            this.GP4PathBox.TabIndex = 53;
            this.GP4PathBox.Text = "No .gp4 Or Gamedata Folder Path Selected";
            this.GP4PathBox.TextChanged += new System.EventHandler(this.GP4Path_Interact);
            // 
            // GP4PathBtn
            // 
            this.GP4PathBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.GP4PathBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GP4PathBtn.FlatAppearance.BorderSize = 0;
            this.GP4PathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GP4PathBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.GP4PathBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.GP4PathBtn.Location = new System.Drawing.Point(350, 171);
            this.GP4PathBtn.Name = "GP4PathBtn";
            this.GP4PathBtn.Size = new System.Drawing.Size(51, 19);
            this.GP4PathBtn.TabIndex = 56;
            this.GP4PathBtn.Text = "Browse";
            this.GP4PathBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GP4PathBtn.UseVisualStyleBackColor = false;
            this.GP4PathBtn.Click += new System.EventHandler(this.GP4Path_Interact);
            // 
            // OutputDirectoryBox
            // 
            this.OutputDirectoryBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.OutputDirectoryBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.OutputDirectoryBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.OutputDirectoryBox.Location = new System.Drawing.Point(11, 214);
            this.OutputDirectoryBox.Name = "OutputDirectoryBox";
            this.OutputDirectoryBox.Size = new System.Drawing.Size(335, 23);
            this.OutputDirectoryBox.TabIndex = 51;
            this.OutputDirectoryBox.Text = "Using App Folder For .pkg Output";
            this.OutputDirectoryBox.Click += new System.EventHandler(this.OutputDirectory_Interact);
            // 
            // OutputDirectoryBtn
            // 
            this.OutputDirectoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.OutputDirectoryBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.OutputDirectoryBtn.FlatAppearance.BorderSize = 0;
            this.OutputDirectoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OutputDirectoryBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.OutputDirectoryBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.OutputDirectoryBtn.Location = new System.Drawing.Point(350, 212);
            this.OutputDirectoryBtn.Name = "OutputDirectoryBtn";
            this.OutputDirectoryBtn.Size = new System.Drawing.Size(51, 19);
            this.OutputDirectoryBtn.TabIndex = 57;
            this.OutputDirectoryBtn.Text = "Browse";
            this.OutputDirectoryBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutputDirectoryBtn.UseVisualStyleBackColor = false;
            this.OutputDirectoryBtn.Click += new System.EventHandler(this.OutputDirectory_Interact);
            // 
            // TMPDirectoryBox
            // 
            this.TMPDirectoryBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TMPDirectoryBox.Font = new System.Drawing.Font("Cambria", 10F);
            this.TMPDirectoryBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.TMPDirectoryBox.Location = new System.Drawing.Point(11, 256);
            this.TMPDirectoryBox.Name = "TMPDirectoryBox";
            this.TMPDirectoryBox.Size = new System.Drawing.Size(335, 23);
            this.TMPDirectoryBox.TabIndex = 52;
            this.TMPDirectoryBox.Text = "Using This PC\'s Default TMP Directory";
            this.TMPDirectoryBox.TextChanged += new System.EventHandler(this.TMPDirectoryItem_Interaction);
            // 
            // TMPDirectoryBtn
            // 
            this.TMPDirectoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TMPDirectoryBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.TMPDirectoryBtn.FlatAppearance.BorderSize = 0;
            this.TMPDirectoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TMPDirectoryBtn.Font = new System.Drawing.Font("Cambria", 7F);
            this.TMPDirectoryBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.TMPDirectoryBtn.Location = new System.Drawing.Point(350, 253);
            this.TMPDirectoryBtn.Name = "TMPDirectoryBtn";
            this.TMPDirectoryBtn.Size = new System.Drawing.Size(51, 19);
            this.TMPDirectoryBtn.TabIndex = 58;
            this.TMPDirectoryBtn.Text = "Browse";
            this.TMPDirectoryBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TMPDirectoryBtn.UseVisualStyleBackColor = false;
            this.TMPDirectoryBtn.Click += new System.EventHandler(this.TMPDirectoryItem_Interaction);
            // 
            // OrbisToolPathLabel
            // 
            this.OrbisToolPathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OrbisToolPathLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.OrbisToolPathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.OrbisToolPathLabel.Location = new System.Drawing.Point(4, 113);
            this.OrbisToolPathLabel.Name = "OrbisToolPathLabel";
            this.OrbisToolPathLabel.Size = new System.Drawing.Size(201, 14);
            this.OrbisToolPathLabel.TabIndex = 59;
            this.OrbisToolPathLabel.Text = "FPKG/Fake Package Tools Folder Path:";
            // 
            // Gp4PathLabel
            // 
            this.Gp4PathLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Gp4PathLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.Gp4PathLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.Gp4PathLabel.Location = new System.Drawing.Point(5, 155);
            this.Gp4PathLabel.Name = "Gp4PathLabel";
            this.Gp4PathLabel.Size = new System.Drawing.Size(209, 14);
            this.Gp4PathLabel.TabIndex = 60;
            this.Gp4PathLabel.Text = ".gp4 Project File/Gamedata Folder Path:";
            // 
            // OutputDirectoryLabel
            // 
            this.OutputDirectoryLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputDirectoryLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.OutputDirectoryLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.OutputDirectoryLabel.Location = new System.Drawing.Point(4, 197);
            this.OutputDirectoryLabel.Name = "OutputDirectoryLabel";
            this.OutputDirectoryLabel.Size = new System.Drawing.Size(152, 14);
            this.OutputDirectoryLabel.TabIndex = 61;
            this.OutputDirectoryLabel.Text = "Finished .pkg Output Folder:";
            // 
            // TmpDirectoryLabel
            // 
            this.TmpDirectoryLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TmpDirectoryLabel.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.TmpDirectoryLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.TmpDirectoryLabel.Location = new System.Drawing.Point(4, 239);
            this.TmpDirectoryLabel.Name = "TmpDirectoryLabel";
            this.TmpDirectoryLabel.Size = new System.Drawing.Size(177, 14);
            this.TmpDirectoryLabel.TabIndex = 62;
            this.TmpDirectoryLabel.Text = "Temp Directory For .pkg Creation:";
            // 
            // PkgCreationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(402, 393);
            this.Controls.Add(this.TmpDirectoryLabel);
            this.Controls.Add(this.OutputDirectoryLabel);
            this.Controls.Add(this.Gp4PathLabel);
            this.Controls.Add(this.OrbisToolPathLabel);
            this.Controls.Add(this.TempDirectoryBtn);
            this.Controls.Add(this.VerbosityBtn);
            this.Controls.Add(this.MainLabel);
            this.Controls.Add(this.LaunchOrbisPubCmdBtn);
            this.Controls.Add(this.InfoHelpBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.TMPDirectoryBox);
            this.Controls.Add(this.TMPDirectoryBtn);
            this.Controls.Add(this.CmdPathBox);
            this.Controls.Add(this.CmdPathBtn);
            this.Controls.Add(this.GP4PathBox);
            this.Controls.Add(this.GP4PathBtn);
            this.Controls.Add(this.OutputDirectoryBox);
            this.Controls.Add(this.OutputDirectoryBtn);
            this.Controls.Add(this.CreditsBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.SeperatorLine2);
            this.Controls.Add(this.SeperatorLine1);
            this.Controls.Add(this.SeperatorLine0);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PkgCreationPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

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
        private Label SeperatorLine0;
        private Label SeperatorLine1;
        private Label SeperatorLine2;
        private Label OrbisToolPathLabel;
        private Label Gp4PathLabel;
        private Label OutputDirectoryLabel;
        private Label TmpDirectoryLabel;
        private Button CreditsBtn;
        private Label MainLabel;
        private Button VerbosityBtn;
        private Button LaunchOrbisPubCmdBtn;
        private Button TempDirectoryBtn;
        private TextBox CmdPathBox;
        private Button CmdPathBtn;
        private TextBox GP4PathBox;
        private Button GP4PathBtn;
        private TextBox OutputDirectoryBox;
        private Button OutputDirectoryBtn;
        private TextBox TMPDirectoryBox;
        private Button TMPDirectoryBtn;
        private Button InfoHelpBtn;
        private Button BackBtn;
        private Label Info;
        #endregion
    }
}
