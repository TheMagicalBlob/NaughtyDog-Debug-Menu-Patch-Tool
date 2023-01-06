using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using static Dobby.Common;

namespace Dobby {
    internal class CreditsPage : Form {
        public CreditsPage() {
            InitializeComponent();
            SetPageInfo(this);
        }
        public Label label1;
        public Label BlobGithubBtn;
        public Label IllusionBlogBtn;
        public Label label2;
        public Label label3;
        public Label label4;

        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditsPage));
            this.MainLabel = new System.Windows.Forms.Label();
            this.BackBtn = new System.Windows.Forms.Button();
            this.MainBox = new System.Windows.Forms.GroupBox();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MinimizeBtn = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BlobGithubBtn = new System.Windows.Forms.Label();
            this.IllusionBlogBtn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.MainLabel.Text = "Credits";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.DimGray;
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.25F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BackBtn.Location = new System.Drawing.Point(-4, 362);
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
            // MainBox
            // 
            this.MainBox.Controls.Add(this.ExitBtn);
            this.MainBox.Controls.Add(this.MinimizeBtn);
            this.MainBox.Controls.Add(this.MainLabel);
            this.MainBox.Location = new System.Drawing.Point(1, -4);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(317, 32);
            this.MainBox.TabIndex = 5;
            this.MainBox.TabStop = false;
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.DimGray;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ExitBtn.Location = new System.Drawing.Point(293, 7);
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
            this.MinimizeBtn.Location = new System.Drawing.Point(270, 7);
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
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(227)))), ((int)(((byte)(0)))));
            this.Info.Location = new System.Drawing.Point(3, 384);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(304, 17);
            this.Info.TabIndex = 7;
            this.Info.Text = "=====================================";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(-2, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(324, 19);
            this.label5.TabIndex = 30;
            this.label5.Text = "___________________________________________________";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(2, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 36);
            this.label1.TabIndex = 20;
            this.label1.Text = "App And Game Patches Developed By:\r\nTheMagicalBlob";
            // 
            // BlobGithubBtn
            // 
            this.BlobGithubBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlobGithubBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlobGithubBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.BlobGithubBtn.Location = new System.Drawing.Point(-1, 308);
            this.BlobGithubBtn.Name = "BlobGithubBtn";
            this.BlobGithubBtn.Size = new System.Drawing.Size(170, 23);
            this.BlobGithubBtn.TabIndex = 31;
            this.BlobGithubBtn.Text = "TheMagicalBlob\'s Github";
            this.BlobGithubBtn.Click += new System.EventHandler(this.BlobGithubBtn_Click);
            this.BlobGithubBtn.MouseEnter += new System.EventHandler(this.BlobGithubBtnMH);
            this.BlobGithubBtn.MouseLeave += new System.EventHandler(this.BlobGithubBtnML);
            // 
            // IllusionBlogBtn
            // 
            this.IllusionBlogBtn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IllusionBlogBtn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IllusionBlogBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.IllusionBlogBtn.Location = new System.Drawing.Point(2, 331);
            this.IllusionBlogBtn.Name = "IllusionBlogBtn";
            this.IllusionBlogBtn.Size = new System.Drawing.Size(100, 23);
            this.IllusionBlogBtn.TabIndex = 32;
            this.IllusionBlogBtn.Text = "illusion\'s Blog";
            this.IllusionBlogBtn.Click += new System.EventHandler(this.IllusionBlogBtn_Click);
            this.IllusionBlogBtn.MouseEnter += new System.EventHandler(this.IllusionBlogBtnMH);
            this.IllusionBlogBtn.MouseLeave += new System.EventHandler(this.IllusionBlogBtnML);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "___________________________________________________";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-8, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 19);
            this.label3.TabIndex = 34;
            this.label3.Text = "___________________________________________________";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(0, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 231);
            this.label4.TabIndex = 35;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // CreditsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(320, 404);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.IllusionBlogBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BlobGithubBtn);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.MainBox);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreditsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.MainBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        void ExitBtn_Click(object sender, EventArgs e) => Environment.Exit(0);
        void ExitBtnMH(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 227, 0);
        void ExitBtnML(object sender, EventArgs e) => ExitBtn.ForeColor = Color.FromArgb(255, 255, 255);
        void MinimizeBtn_Click(object sender, EventArgs e) => ActiveForm.WindowState = FormWindowState.Minimized;
        void MinimizeBtnMH(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 227, 0);
        void MinimizeBtnML(object sender, EventArgs e) => MinimizeBtn.ForeColor = Color.FromArgb(255, 255, 255);

        void BackBtn_Click(object sender, EventArgs e) {//!!
            Form f = ActiveForm;
            LastPos = f.Location;
            if (LastForm.Name == MainForm.Name) {
                MainForm.Show();
                Dobby.Page = MainForm.Name;
                LastForm = null;
                goto skip;
            }
            LastForm.Show();
       skip:ActiveForm.Location = LastPos;
            f.Close();
            Dobby.Page = ActiveForm.Name;
            if (!Dev.REL) PageInfo(ActiveForm.Controls);
        }
        public void BackBtnMH(object sender, EventArgs e) => HoverString(BackBtn, $"{(Dev.REL ? "" : LastForm.Name)}");
        public void BackBtnML(object sender, EventArgs e) => HoverLeave(BackBtn, 1);

        public void BlobGithubBtn_Click(object sender, EventArgs e) => Process.Start("https://github.com/TheMagicalBlob");
        public void BlobGithubBtnMH(object sender, EventArgs e) => BlobGithubBtn.ForeColor = Color.MediumBlue;
        public void BlobGithubBtnML(object sender, EventArgs e) => BlobGithubBtn.ForeColor = Color.White;

        public void IllusionBlogBtn_Click(object sender, EventArgs e) => Process.Start("https://illusion0001.com/");
        public void IllusionBlogBtnMH(object sender, EventArgs e) => IllusionBlogBtn.ForeColor = Color.MediumBlue;
        public void IllusionBlogBtnML(object sender, EventArgs e) => IllusionBlogBtn.ForeColor = Color.White;
        public Button BackBtn;
        public Label MainLabel;
        public GroupBox MainBox;
        public Button ExitBtn;
        public Button MinimizeBtn;
        public Label Info;
        public Label label5;
        #region CodeList
        /*(F; == Find | R; == Replace With)

(M) Means The Address Is For Memory Editors Like PS4Cheater

                                                                                               --------------------------
                                                                                               |Mafia II 1.00 CUSA00000 |
                                                                                               --------------------------
Shooting Fills Clip 12CCD84 (reloading drains ammo)

Drain; 017010 { 0x01, 0x70, 0x10 }
Fill; 297010 { 0x29, 0x70, 0x10 }
-----------------------------------
Infinite Cash 0x801E04A7

F; 4C29F1 { 0x4C, 0x29, 0xF1 }
R; 909090 { 0x90, 0x90, 0x90 }
------------------------------
Buying Things Raises Cash 0x801E04A7 [mov [r14+r12], rcx] The Fuck Is This?

F; 4C29F1 { 0x4C, 0x29, 0xF1 }
R; 4C01F1 { 0x4C, 0x01, 0xF1 }
------------------------------
Infinite Ammo 150C574

Drains; 44 89 60 10 { 0x44, 0x89, 0x60, 0x10 }
Infinite; 44 89 68 10 { 0x44, 0x89, 0x68, 0x10 }

HP 14C288D (effects everyone for fuck sake. again.)
Mortal; C5-FA-5C-C0
Inf; C5-F2-5C-C9
------------------------------------------------------------------------------------------------------------
Super Reload 150C57E

F; 41 89 DD { 0x41, 0x89, 0xDD }
R; 41 89 DC { 0x41, 0x89, 0xDC }
--------------------------------

--------------------------
|Mafia III 1.00 CUSA03617|
--------------------------
Infinite Cash 0x3402F07
Drain; 89 B0 D8 02 00 00 {0x89, 0xB0, 0xD8, 0x02, 0x00, 0x00}
Inf; 90 90 90 90 90 90 {0x90, 0x90, 0x90, 0x90, 0x90, 0x90}



Infinite Clip Ammo 0x2A1E30B
Drain; 89 41 18 { 0x89 0x41, 0x18 }
Infinite; nop { 0x90, 0x90, 0x90 }

Infinite Reserve Ammo 0x2A1C54D
Drain; 89 70 04 { 0x89, 0x70, 0x04 }
Infinite; nop { 0x90, 0x90, 0x90 }

Borderlands 3 1.00
{With Alignment Checked
Shield (& Health?)
-----------------
4 bytes - Unknown Initial: 166C011
Still Drains, Crashes The Game On Shield Regen
4 bytes - Exact Value: ??? Probably The Same Result
-----------------
8 bytes - Unknown Initial: ???
8 bytes  - Exact Value: ???
-----------------
float - Unknown Initial: ???
float  - Exact Value: ???
-----------------
double - Unknown Initial: ???
double  - Exact Value: ???
-----------------------------
Health 
-----------------
4 bytes - Unknown Initial: ???
4 bytes  - Exact Value: ???
-----------------
8 bytes - Unknown Initial: ???
8 bytes - Exact Value: ???
-----------------
Float - Unknown Initial: 0x4DCDAC8 vmovss [rbx+0xa0], xmm1
Drain: C5-FA-11-8B-A0-00-00-00
Infinite: C5-FA-11-93-A0-00-00-00
Always 1 HP (Helps Moze): C5-7A-11-83-A0-00-00-00 or C5-FA-11-B3-A0-00-00-00
-----------------
Double - Unknown Initial: ???
Double - Exact Value: ???
-----------------------------
End Of Alignment}

1.26

Infinite Clip Ammo (OG Clip Drain Addr 0x5838EF4)
Address 5838EC2
Drain; 0x45, 0x29, 0xF4
Infinite; 0x45, 0x29, 0xF6

Shooting Increases Stach Ammo
off;
on; 

Infinite Stash Ammo
Address;
Drain; 
Infinite;


                                                                                               ----------------------------
                                                                                               |Red Dead Redemption 2 1.29|
                                                                                               ----------------------------

Reloading Restores Ammo 0x
F; 
-
R; 

// fuck forgot to even add it 
                                                                                               ----------------------
                                                                                               |Resident Evil 3 1.00| CUSA14123 & CUSA14168
                                                                                               ----------------------
No Reload

F; 0x223203A 0x89, 0x51, 0x20
R; 0x223203A 0x90, 0x90, 0x90
some cloth physics float, idk 0x53DB75C(M)
-------------------------------------------------------

Borderlands 3
Infinite Ammo
Offset;
Drain;
Infinite;
-
Infinite Health (Float - 0x4DCDAC0 vmovss [rbx+0xa0], xmm1 - C5-FA-11-8B-A0-00-00-00)
Offset; 0x4DCDAC3
Drain; 0x8B
Infinite; 0x93
Always 1 HP (Helps Moze): 0xB3

                                                                                                        -----------------------------
                                                                                                        |The Last of Us Part II 1.00|
                                                                                                        -----------------------------
t2100

Regular Find/Replace Style Patches:

Debug Mode

F; 31 c0 eb 49 4c
R; b0 01 eb 49 4c
------------------
Disable Weapon sway on startup

F; c6 05 ac 8b 65 02 00
R; c6 05 8f 8b 65 02 01
------------------------
Depth of Field Disabled on startup

F; c6 05 54 1a 60 02 00
R; c6 05 53 1a 60 02 01
------------------------
L3 + Triangle to FPS toggle

F; 41 8a 84 24 aa 3a 00 00 89 c1 80 f1 01 41 88 8c 24 aa 3a 00 00
R; 41 8a 84 24 b8 3a 00 00 89 c1 80 f1 01 41 88 8c 24 b8 3a 00 00
------------------------------------------------------------------
Show Save Slot On Startup

F; c6 05 d8 af 2f 04 00
R; c6 05 e8 af 2f 04 01
------------------------
Disable Build Text On Startup

F; 66 41 c7 85 c4 3a 00 00 01 01
R; 66 41 c7 85 c4 3a 00 00 00 00
---------------------------------
Debug Menu Transparency Float (This Makes It Transparent)

F; B8 0A 00 00 00 9A 99 59 3F
R; B8 0A 00 00 00 00 00 00 00
------------------------------
Menu Scale Float

F; C7 05 65 85 EE 02 9A 99 19 3F
R; C7 05 65 85 EE 02 cd cc 4c 3f
---------------------------------
Draw World Axes To Novis 
(second is just for the string)

F; 48 8d 05 8b 45 e0 01
R; 48 8d 05 9e ce ec 00
-- 
F; 48 8d 35 20 4c 81 00
R; 48 8d 35 1e 20 75 00
------------------------ T2 1.00 Offsets

Disable Debug Rendering; 0x110693FAAA(Useless)
Debug Menu 0x110693FAA1
Menu Background Opacity: 0x32231E
Menu Scale: 0x32468A8
Novis: 0x341622c



Good Spot For Strings, Hopefully: 0x2E1C0C0











                                                                                                       -----------------------------
                                                                                                       |The Last of Us Part II 1.07|
                                                                                                       -----------------------------
t27

007dd9ba camera shit Ghid
Debug Mode

F; 31 c0 eb 4c 4c
R; b0 01 eb 4c 4c
------------------
Disable All Visibility

F; 48 8d 05 4f 35 dd 01
R; 48 8d 05 3e 11 e9 00
------------------------
No More Render Pause Or Reload Ingame Shaders Options

F; 48 8d 15 b8 f6 83 00
R; 48 e9 ca 02 00 00 00
------------------------
No More Debug "Paused" Icon

F; 74 10 41 c6 85 aa 3a 00 00 01 41 c6 85 b8 3a 00 00 01
R; 75 10 67 c6 05 8f 40 07 03 00 41 c6 85 b8 3a 00 00 00
---------------------------------------------------------
Movie/Audio Frame Sync Threshold To Non-ADS FOV

F: 48 8d 15 bf da e9 00
R: 48 8d 15 bf 4b e9 00
------------------------
Fixed GPU Frame Delay To X Sensitivity 1

F; 48 8d 15 54 77 e9 00
R; 48 8d 15 20 2b 68 01
------------------------
Game Frame Headstart To X Sensitivity 2

F; 48 8d 15 a0 9a dc 01
R; 48 8d 15 ac 28 68 01
------------------------
Msg Con Scale To Menu Scale

F; 48 8d 05 29 ea e7 00
R; 48 8d 05 99 df 0b 01
------------------------
Msg Con Scale To Fov Slider

F; 48 8d 05 29 ea e7 00
R; 48 8d 05 d1 11 ea 00
------------------------
Completion Text To Build Text

F; 00 43 48 45 41 54 45 44 00 43 6F 6D 70 6C 65 74 69 6F 6E 20 25 2E 31 66 25 25 25 73 20 25 73 0A 00 28 25 64 20 2F 20 25 64 29 20 25 73 0A 00 46 61 64 65 20 25 2E 33 66 0A 00 56 6F 6C 20 53 61 6D 70 6C 65 73 20 25 75 0A 00
R; 00 44 65 62 75 67 20 20 00 54 32 20 44 65 76 20 4D 65 6E 75 20 2B 20 20 20 20 20 20 20 20 20 0A 00 42 75 69 6C 64 20 35 2E 36 36 20 20 20 00 20 20 20 20 20 20 20 20 20 0A 00 20 20 20 20 20 20 20 20 20 20 20 20 20 20 0A 00
-------
Vol Samples And Fade Text 

F; 00 46 61 64 65 20 25 2E 33 66 0A 00 56 6F 6C 20 53 61 6D 70 6C 65 73 20 25 75 0A 00
R; 00 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 00
-------
Debug Menu Transparency Float (This Makes It Transparent)

F; B8 0A 00 00 00 9A 99 59 3F
R; B8 0A 00 00 00 00 00 00 00
------------------------------
Allow Screen Tear

F; c6 05 73 b2 d3 02 00
R; c6 05 73 b2 d3 02 01
------------------------
Allow Screen Tear Through Loading Screens

F; c6 05 45 c1 d3 02 00
R; c6 05 45 c1 d3 02 01
------------------------
No Screan Tear Change After Loading? needs more oned nop'd

F; c6 05 45 c1 d3 02 00
R; 90 90 90 90 90 90 90
------------------------
Show Save Slot On start-up

F; 49 8d 46 28 c6 05 5f 95 59 02 00
R; 49 8d 46 28 c6 05 6d 95 59 02 01
------------------------------------
Show Game Completion (Needs Save Slot On Screen)

F; 48 c7 05 39 c8 59 02 00 00 00 00
R; 48 c7 05 3d c8 59 02 01 00 00 00
------------------------------------
lut gamma curve to NPC Scale ( Look For "Fell Out Of The World" )

F; 00 48 64 72 20 6C 75 74 20 67 61 6D 6D 61 20 63 75 72 76 65 00
R; 00 43 68 61 6E 67 65 20 4E 50 43 20 53 63 61 6C 65 20 20 20 00
-
F; 48 8d 15 cb be dc 01
R; 48 8d 15 1b 79 42 02
------------------------
Menu Scale

F; c7 05 b5 70 ee 02 9a 99 19 3f
R; c7 05 b5 70 ee 02 cd cc 4c 3f
---------------------------------
FPS Mode Change

F; 41 c7 85 b4 3a 00 00 00 00 00 00 FPS Only
R;                       1          Verbose MS
R;                       2          Verbose Percent
R;                       3          Minimalistic
----------------------------------------------------
Verbose Addatives Bytes

F; 41 c7 85 b9 3a 00 00 01 01 01 01
R; 41 c7 85 b9 3a 00 00 01 00 00 01
------------------------------------
Broken GPU Thing Disabled (There's A Patch From illusion To Fix This)

F; 41 c7 85 b9 3a 00 00 01 01 01 01
R; 41 c7 85 b9 3a 00 00 01 01 01 00
---------------------------------
Msg con scale 0.7 on boot

F; 00 00 00 00 10 00 00 00 00 00 00 3f
R; 00 00 00 00 10 00 00 00 00 00 34 3f
---------------------------------------------------
L3 + Triangle to FPS toggle

F; 41 8a 84 24 aa 3a 00 00 89 c1 80 f1 01 41 88 8c 24 aa 3a 00 00
R; 41 8a 84 24 b8 3a 00 00 89 c1 80 f1 01 41 88 8c 24 b8 3a 00 00
---------------------------------
Enable Stat Posting On Boot

F; 66 41 c7 85 ec 3e 00 00 00 00
R; 66 41 c7 85 ed 3e 00 00 01 00
---------------------------------
Upscale Merge Threshold To NPC Scale

F; 00 55 70 73 63 61 6C 65 20 4D 65 72 67 65 20 54 68 72 65 73 68 6F 6C 64 00
R; 00 43 68 61 6E 67 65 20 4E 50 43 20 53 63 61 6C 65 20 20 20 20 20 20 20 00
-
F; 48 8d 15 d3 7b dc 01
R; 48 8d 15 1b 36 42 02
------------------------

{MsgCon +}


Culling Toggle [Option 1]

Addr
F; 48 8d 05 4f 35 dd 01
R; 48 8d 05 3e 11 e9 00
---
Str
F; 48 8d 35 a4 9f 81 00
R; 48 8d 35 81 31 75 00
------------------------
Prog Pause On Menu Open [Option 2]

F; 49 8d 8d aa 3a 00 00
R; 48 8d 0d ef 15 0c 01
------------------------
Menu Right Align [Option 3]

F; 48 8d 05 e7 33 dd 01
R; 48 8d 05 67 17 0c 01
------------------------
Debug Menu Bold Text [Option 4]

F; 49 8d 8d a9 3a 00 00
R; 48 8d 0d 82 14 0c 01
---
On By Default

F; c6 05 9a 71 ee 02 00
R; c6 05 9a 71 ee 02 01
------------------------
Swap O With Square In Debug [Option 4?]

F; 00 55 73 65 20 56 65 72 74 65 78 20 4C 69 73 74 20 28 4E 6F 20 49 6E 64 69 63 65 73 29 00
R; 00 53 77 61 70 20 4F 20 57 69 74 68 20 53 71 75 61 72 65 20 49 6E 20 44 65 62 75 67 20 00
-
F; 48 8d 05 99 d1 e8 00
R; 48 8d 05 36 d8 0b 01
------------------------------
O And Square Swapped In Debug Meny By Default

F; 66 c7 05 8c 71 ee 02 00 00
R; 66 c7 05 8c 71 ee 02 01 00
------------------------------
[Memory Plus V2] W.I.P.

-- Remove All Weapons
F; 48 8d 35 41 11 73 02
R; 48 8d 35 f9 f6 78 02
---keep vsync as is?
F; 48 8d 05 d8 bc 04 03
R; 48 8d 05 09 45 14 00
-- 
F; 
R; 
---
F; 
R; 
-- Novis
F; 48 8d 35 c3 0e 73 02
R; 48 8d 35 a8 1d 73 02
---
F; 48 8d 05 89 bb 04 03
R; 48 8d 05 73 fd e6 02
---
F; 
R; 
---
F; 
R; 
---
F; 
R; 
---
F; 
R; 
---
F; 
R; 
---
F; 
R; 
---
F; 
R; 
------------------------ T2 1.07 Offsets

Invincible Player
0x35aed44 G

Novis / Disable All Visibility: Ghid 0x301602c Memory 0x341602C  str 0x28d8025 / 0x2cd8025


byte;
Debug Mode; 0x11069DFAA1
Menu Bold Text: 0x32467b8
Menu Pause: 0x032467b9
Menu Pause: On Exit 0x032467ba (With Triangle or Touchpad)
Debug PAUSED Icon: 0x32467bb
Swap O and Square: 0x32467Bd
Menu Right Align: 0x032467be
Build info Display Byte: 0x1CB7B2 offset HEX 48 b8 00 00 00 00 01 01 00 01
? yellow debug text and build text position: 0x28919a4
FPS Text Colour Red: 0x28919b8
FPS Text Colour Yellow: 0x2C919BC
Something To Do With FPS Text, Not Sure: 0x289199c

float;
Menu Background Opacity: 0x0035f6ed
Main Camera Field of View: 0x3029a00
Menu Scale: 0x32467c8
Look Sensitivity1 X: 0x3811B78
Look Sensitivity2 X: 0x3811B80
NPC Scale: 0x45b3bcc
Jump Height/Length: 0x11087123B0
FPS Text Size Float: 0x28919a0

debug menu code spot: 652b90

T2 1.07 Functions
Remove All Player Weapons: 0x169f610
Give All Guns And Upgrades: 0x0f12250



                                                                                                       -----------------------------
                                                                                                       |The Last of Us Part II 1.09|
t2109                                                                                                  -----------------------------


       --------------------------------
       |Regular Find & Replace Patches|
       --------------------------------
----------
Debug Mode

F; 41 80 bd b8 41 00 00 00 74 10
R; 41 80 bd b8 41 00 00 00 75 10
---------------------------------
Novis

F; 48 8d 05 5f 16 9c 01
R; 48 8d 05 4e f4 a9 00
------------------------
Debug Rendering Toggle To FPS Toggle [L3 & Triangle]

F; 41 8a 84 24 aa 3a 00 00 89 c1 80 f1 01 41 88 8c 24 aa 3a 00 00
R; 41 8a 84 24 b8 3a 00 00 89 c1 80 f1 01 41 88 8c 24 b8 3a 00 00
------------------------------------------------------------------
Skip Problematic Render Pause And Reload Ingame Shaders Options

F; 48 8d 15 00 b8 4e
R; 48 e9 ca 02 00 00
------------------------
Increase Debug Menu Scale To Match Previous Games (Or In Other Words, Make It F*cking Visible...)

F; c7 05 75 97 ab 02 9a 99 19 3f
R; c7 05 75 97 ab 02 cd cc 4c 3f
---------------------------------



       ---------------------
       |Misc Custom Patches| Not To Be Used With The Enhanced Debug Menu! Things Will Overlap
       ---------------------
__________________________________________
Custom String Offsets Log To Avoid Overlapping:

String                     .elf addresses

Disable All Visibility + Info Str 0x2DF3B41 to 0x2DF3BB8
__________________________________________

Add Disable All Visibility To MsgCon Menu:

dat addr { 25AE98D }
-
data  { 0x48, 0x8d, 0x35, 0xad, 0x51, 0x84, 0x00, 0x48, 0x89, 0xc7, 0x49, 0x89, 0xc4, 0xe8, 0xc1, 0x19, 0x68, 0xff, 0x48, 0xb8, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x48, 0x8d, 0x35, 0x30, 0xb4, 0x9b, 0x00, 0x48, 0x8d, 0x15, 0xa1, 0x51, 0x84, 0x00, 0x49, 0x89, 0x84, 0x24, 0xa0, 0x00, 0x00, 0x00, 0x49, 0x89, 0x94, 0x24, 0x80, 0x00, 0x00, 0x00, 0x48, 0x8d, 0x15, 0x32, 0x02, 0x69, 0xff, 0x49, 0x89, 0x34, 0x24, 0x49, 0x89, 0x94, 0x24, 0xa8, 0x00, 0x00, 0x00, 0x48, 0x8d, 0x05, 0x4b, 0xf4, 0xa9, 0x00, 0x8a, 0x0d, 0x45, 0xf4, 0xa9, 0x00, 0x41, 0x88, 0x8c, 0x24, 0xb0, 0x00, 0x00, 0x00, 0x4c, 0x89, 0xf1, 0x49, 0x89, 0x44, 0x24, 0x60, 0x49, 0xc7, 0x44, 0x24, 0x58, 0x00, 0x00, 0x00, 0x00, 0x41, 0xc7, 0x84, 0x24, 0x9c, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0f, 0x1f, 0x80, 0x00, 0x00, 0x00, 0x00, 0x48, 0x89, 0xd8, 0x48, 0x8b, 0x19, 0x48, 0x85, 0xdb, 0x48, 0x8d, 0x4b, 0x40, 0x75, 0xf1, 0x48, 0x85, 0xc0, 0x48, 0x8d, 0x40, 0x40, 0x49, 0x0f, 0x44, 0xc6, 0x4c, 0x89, 0x20, 0x49, 0xc7, 0x44, 0x24, 0x40, 0x00, 0x00, 0x00, 0x00, 0x4d, 0x89, 0x7c, 0x24, 0x38, 0x41, 0xff, 0x87, 0xa0, 0x00, 0x00, 0x00, 0x41, 0xc6, 0x87, 0xa8, 0x00, 0x00, 0x00, 0x01, 0x48, 0x8d, 0x15, 0x3c, 0xb9, 0x4f, 0x00, 0xbe, 0x10, 0x00, 0x00, 0x00, 0xbf, 0xb8, 0x00, 0x00, 0x00, 0x31, 0xdb, 0x31, 0xc9, 0x49, 0x89, 0xd0, 0xe8, 0x46, 0xc2, 0x59, 0xff, 0x48, 0x8d, 0x35, 0x9d, 0x58, 0x50, 0x00, 0x48, 0x89, 0xc7, 0x49, 0x89, 0xc4, 0xe8, 0xe4, 0x18, 0x68, 0xff, 0x48, 0xb8, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x48, 0x8d, 0x35, 0x53, 0xb3, 0x9b, 0x00, 0x48, 0x8d, 0x15, 0x6c, 0x01, 0x69, 0xff, 0x49, 0x89, 0x84, 0x24, 0xa0, 0x00, 0x00, 0x00, 0x49, 0xc7, 0x84, 0x24, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x49, 0x89, 0x34, 0x24, 0x49, 0x89, 0x94, 0x24, 0xa8, 0x00, 0x00, 0x00, 0x48, 0x8d, 0x05, 0x82, 0x15, 0x9c, 0x01, 0x8a, 0x0d, 0x7c, 0x15, 0x9c, 0x01, 0x41, 0x88, 0x8c, 0x24, 0xb0, 0x00, 0x00, 0x00, 0x4c, 0x89, 0xf1, 0x49, 0x89, 0x44, 0x24, 0x60, 0x49, 0xc7, 0x44, 0x24, 0x58, 0x00, 0x00, 0x00, 0x00, 0x41, 0xc7, 0x84, 0x24, 0x9c, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x66, 0x66, 0x66, 0x66, 0x66, 0x2e, 0x0f, 0x1f, 0x84, 0x00, 0x00, 0x00, 0x00, 0x00, 0x48, 0x89, 0xd8, 0x48, 0x8b, 0x19, 0x48, 0x85, 0xdb, 0x48, 0x8d, 0x4b, 0x40, 0x75, 0xf1, 0x48, 0x85, 0xc0, 0x48, 0x8d, 0x40, 0x40, 0x49, 0x0f, 0x44, 0xc6, 0x4c, 0x89, 0x20, 0x49, 0xc7, 0x44, 0x24, 0x40, 0x00, 0x00, 0x00, 0x00, 0x4d, 0x89, 0x7c, 0x24, 0x38, 0x41, 0xff, 0x87, 0xa0, 0x00, 0x00, 0x00, 0x41, 0xc6, 0x87, 0xa8, 0x00, 0x00, 0x00, 0x01, 0x48, 0x8d, 0x15, 0x5b, 0xb8, 0x4f, 0x00, 0xbe, 0x10, 0x00, 0x00, 0x00, 0xbf, 0xb8, 0x00, 0x00, 0x00, 0x31, 0xdb, 0x31, 0xc9, 0x49, 0x89, 0xd0, 0xe8, 0x65, 0xc1, 0x59, 0xff, 0x48, 0x8d, 0x35, 0xcc, 0x57, 0x50, 0x00, 0x48, 0x89, 0xc7, 0x49, 0x89, 0xc4, 0xe8, 0x03, 0x18, 0x68, 0xff, 0x48, 0xb8, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x48, 0x8d, 0x35, 0x72, 0xb2, 0x9b, 0x00, 0x48, 0x8d, 0x15, 0x8b, 0x00, 0x69, 0xff, 0x49, 0x89, 0x84, 0x24, 0xa0, 0x00, 0x00, 0x00, 0x49, 0xc7, 0x84, 0x24, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x49, 0x89, 0x34, 0x24, 0x49, 0x89, 0x94, 0x24, 0xa8, 0x00, 0x00, 0x00, 0x48, 0x8d, 0x05, 0xa2, 0x14, 0x9c, 0x01, 0x8a, 0x0d, 0x9c, 0x14, 0x9c, 0x01, 0x41, 0x88, 0x8c, 0x24, 0xb0, 0x00, 0x00, 0x00, 0x4c, 0x89, 0xf1, 0x49, 0x89, 0x44, 0x24, 0x60, 0x49, 0xc7, 0x44, 0x24, 0x58, 0x00, 0x00, 0x00, 0x00, 0x41, 0xc7, 0x84, 0x24, 0x9c, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x66, 0x66, 0x66, 0x66, 0x66, 0x2e, 0x0f, 0x1f, 0x84, 0x00, 0x00, 0x00, 0x00, 0x00, 0x48, 0x89, 0xd8, 0x48, 0x8b, 0x19, 0x48, 0x85, 0xdb, 0x48, 0x8d, 0x4b, 0x40, 0x75, 0xf1, 0x48, 0x85, 0xc0, 0x48, 0x8d, 0x40, 0x40, 0x49, 0x0f, 0x44, 0xc6, 0x4c, 0x89, 0x20, 0x49, 0xc7, 0x44, 0x24, 0x40, 0x00, 0x00, 0x00, 0x00, 0x4d, 0x89, 0x7c, 0x24, 0x38, 0x41, 0xff, 0x87, 0xa0, 0x00, 0x00, 0x00, 0x41, 0xc6, 0x87, 0xa8, 0x00, 0x00, 0x00, 0x01, 0x48, 0x8d, 0x15, 0x7a, 0xb7, 0x4f, 0x00, 0xbe, 0x10, 0x00, 0x00, 0x00, 0xbf, 0xb8, 0x00, 0x00, 0x00, 0x4c, 0x89, 0x6d, 0xb0, 0x31, 0xdb, 0x31, 0xc9, 0x49, 0x89, 0xd0, 0xe8, 0x80, 0xc0, 0x59, 0xff, 0x4c, 0x8b, 0x2d, 0xf9, 0x07, 0x1d, 0x01, 0x48, 0x8d, 0x35, 0x02, 0x57, 0x50, 0x00, 0x48, 0x89, 0xc7, 0x49, 0x89, 0xc4, 0xe8, 0x17, 0x17, 0x68, 0xff, 0x48, 0xb8, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x48, 0x8d, 0x0d, 0x86, 0xb1, 0x9b, 0x00, 0x49, 0x89, 0x84, 0x24, 0xa0, 0x00, 0x00, 0x00, 0x48, 0x8d, 0x05, 0x97, 0xff, 0x68, 0xff, 0x49, 0xc7, 0x84, 0x24, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x49, 0x89, 0x0c, 0x24, 0x49, 0x8d, 0x8d, 0xaa, 0x3a, 0x00, 0x00, 0x49, 0x89, 0x84, 0x24, 0xa8, 0x00, 0x00, 0x00, 0x41, 0x8a, 0x85, 0xaa, 0x3a, 0x00, 0x00, 0x41, 0x88, 0x84, 0x24, 0xb0, 0x00, 0x00, 0x00, 0x49, 0x89, 0x4c, 0x24, 0x60, 0x4c, 0x89, 0xf1, 0x49, 0xc7, 0x44, 0x24, 0x58, 0x00, 0x00, 0x00, 0x00, 0x41, 0xc7, 0x84, 0x24, 0x9c, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x66, 0x90, 0x48, 0x89, 0xd8, 0x48, 0x8b, 0x19, 0x48, 0x85, 0xdb, 0x48, 0x8d, 0x4b, 0x40, 0x75, 0xf1, 0x48, 0x85, 0xc0, 0x48, 0x8d, 0x40, 0x40, 0x49, 0x0f, 0x44, 0xc6, 0x4c, 0x89, 0x20, 0x49, 0xc7, 0x44, 0x24, 0x40, 0x00, 0x00, 0x00, 0x00, 0x4d, 0x89, 0x7c, 0x24, 0x38, 0x41, 0xff, 0x87, 0xa0, 0x00, 0x00, 0x00, 0x41, 0xc6, 0x87, 0xa8, 0x00, 0x00, 0x00, 0x01, 0x48, 0x8d, 0x15, 0x99, 0xb6, 0x4f, 0x00, 0xbe, 0x10, 0x00, 0x00, 0x00, 0xbf, 0xb8, 0x00, 0x00, 0x00, 0x31, 0xdb, 0x31, 0xc9, 0x49, 0x89, 0xd0, 0xe8, 0xa3, 0xbf, 0x59, 0xff, 0x4c, 0x8b, 0x2d, 0x1c, 0x07, 0x1d, 0x01, 0x48, 0x8d, 0x35, 0x3d, 0x56, 0x50, 0x00, 0x48, 0x89, 0xc7, 0x49, 0x89, 0xc4, 0xe8, 0x3a, 0x16, 0x68, 0xff, 0x48, 0xb8, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x48, 0x8d, 0x0d, 0xa9, 0xb0, 0x9b, 0x00, 0x49, 0x89, 0x84, 0x24, 0xa0, 0x00, 0x00, 0x00, 0x48, 0x8d, 0x05, 0xba, 0xfe, 0x68, 0xff, 0x49, 0xc7, 0x84, 0x24, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x49, 0x89, 0x0c, 0x24, 0x49, 0x8d, 0x8d, 0xa9, 0x3a, 0x00, 0x00, 0x49, 0x89, 0x84, 0x24, 0xa8, 0x00, 0x00, 0x00, 0x41, 0x8a, 0x85, 0xa9, 0x3a, 0x00, 0x00, 0x41, 0x88, 0x84, 0x24, 0xb0, 0x00, 0x00, 0x00, 0x49, 0x89, 0x4c, 0x24, 0x60, 0x4c, 0x89, 0xf1, 0x49, 0xc7, 0x44, 0x24, 0x58, 0x00, 0x00, 0x00, 0x00, 0x41, 0xc7, 0x84, 0x24, 0x9c, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x66, 0x0f, 0x1f, 0x44, 0x00, 0x00, 0x48, 0x89, 0xd8, 0x48, 0x8b, 0x19, 0x48, 0x85, 0xdb, 0x48, 0x8d, 0x4b, 0x40, 0x75, 0xf1, 0x48, 0x85, 0xc0, 0x48, 0x8d, 0x40, 0x40, 0x49, 0x0f, 0x44, 0xc6, 0x4c, 0x89, 0x20, 0x49, 0xc7, 0x44, 0x24, 0x40, 0x00, 0x00, 0x00, 0x00, 0x4d, 0x89, 0x7c, 0x24, 0x38, 0x41, 0xff, 0x87, 0xa0, 0x00, 0x00, 0x00, 0x41, 0xc6, 0x87, 0xa8, 0x00, 0x00, 0x00, 0x01, 0xe9, 0x53, 0x01, 0x00, 0x00 }


str addr { 2DF3B41 }
-
string { 0x56, 0x45, 0x31, 0x43, 0x62, 0x47, 0x39, 0x69, 0x00, 0x00, 0x00, 0x00, 0x44, 0x69, 0x73, 0x61, 0x62, 0x6C, 0x65, 0x20, 0x41, 0x6C, 0x6C, 0x20, 0x56, 0x69, 0x73, 0x69, 0x62, 0x69, 0x6C, 0x69, 0x74, 0x79, 0x00, 0x53, 0x74, 0x6F, 0x70, 0x73, 0x20, 0x54, 0x68, 0x65, 0x20, 0x4C, 0x65, 0x76, 0x65, 0x6C, 0x20, 0x46, 0x72, 0x6F, 0x6D, 0x20, 0x42, 0x65, 0x69, 0x6E, 0x67, 0x20, 0x43, 0x75, 0x6C, 0x6C, 0x65, 0x64, 0x20, 0x4F, 0x75, 0x74, 0x20, 0x57, 0x68, 0x69, 0x6C, 0x65, 0x20, 0x4F, 0x75, 0x74, 0x20, 0x4F, 0x66, 0x20, 0x42, 0x6F, 0x75, 0x6E, 0x64, 0x73, 0x20, 0x2D, 0x20, 0x49, 0x6D, 0x70, 0x61, 0x63, 0x74, 0x73, 0x20, 0x50, 0x65, 0x72, 0x66, 0x6F, 0x72, 0x6D, 0x61, 0x6E, 0x63, 0x65 }
-------------------------------------------------
L3 & Triangle To FPS & Other Debug Text Toggle 

{ 0x1C45085, 0x1C45092 } | 0xB8
_________________________________________________




       --------------------------------------
       |Enhanced Debug Menu (.elf addresses)|
       --------------------------------------
_________________________________________________
Custom String Offsets Log To Avoid Overlapping:

String                   .elf addr   ghidra addr

Disable All Visibility | 0x??????? | 0x???????
_________________________________________________
Write Values:

Disable Debug Rendering { 0x25B0BAA } | { 0x41, 0xc6, 0x85, 0xaa, 0x3a, 0x00, 0x00, 0x00 }
Enable Stat Posting { 0x25B0BB2 } | { 0x41, 0xc6, 0x85, 0xed, 0x3e, 0x00, 0x00, 0x01 }
Show Save Slot On-Screen { 0x25B0BBA } | { 0xc6, 0x05, 0x06, 0x3c, 0xf4, 0x01, 0x01 }
Show Game Completion { 0x25B0BC1 } | { 0xc6, 0x05, 0x03, 0x3c, 0xf4, 0x01, 0x01 }
Align Debug Menus Right { 0x25B0BC8 } | { 0xc6, 0x05, 0x6f, 0xda, 0xca, 0x00, 0x01 }
Swap Square And Circle In Debug { 0x25B0BCF } | { 0xc6, 0x05, 0x67, 0xda, 0xca, 0x00, 0x01 }
Debug Menu Shadowed Text { 0x25B0BD6 } | { 0xc6, 0x05, 0x5b, 0xda, 0xca, 0x00, 0x01 }
Disable All Visibility { 0x25B0BDD } | { 0xc6, 0x05, 0x48, 0xd2, 0xa9, 0x00, 0x01 }
Prog Pause On Menu Open { 0x25B0BE4 } | { 0xc6, 0x05, 0x4e, 0xda, 0xca, 0x00, 0x00 }
Prog Pause On Menu Close { 0x25B0BEB } | { 0xc6, 0x05, 0x48, 0xda, 0xca, 0x00, 0x00 }
Set Menu Scale To 0.7 { 0x25B0BF2 } | { 0xc7, 0x05, 0x4c, 0xda, 0xca, 0x00, 0x33, 0x33, 0x33, 0x3f }
Set Menu Opacity To 0.5 { 0x25B0BFC } | { 0xc7, 0x05, 0x3e, 0xda, 0xca, 0x00, 0x00, 0x00, 0x00, 0x3f }
Disable FPS { 0x25B0C06 } | { 0x41, 0xc6, 0x85, 0xb8, 0x3a, 0x00, 0x00, 0x01 }
Set FPS Disaplay Mode To 3 { 0x25B0C0E } | { 0x41, 0xc7, 0x85, 0xb4, 0x3a, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00 } // 0 FPS | 1 Verbose | 2 Verbose Percent | 3 Minimal
Jump { 0x25B0C19 } { 0xEB, 0x1E }
________________________________________________

Good Spot For Strings
0x2DF3B50(.elf addr)
More Room?
0x3df0e09(.elf)

----------------------


Tlou2 1.09 Offsets - All (M)

byte;
Draw Stationary vs Moving Widgets: 0x3A28f0c
Debug Mode: 0x11069DFAA1
Novis: 0x3449e2c
Debug Menu Shadowed Text: 0x365A638
Debug Pause On Menu Open: 0x365A639
Debug Pause On Menu Close: 0x365A63A (Unless Closed With L3 Combo)
Swap Square And Circle In Debug: 0x365A63D
Align Debug Menus Right: 0x365A63E
Show Save Slot On Screen: 0x48F07C7
Show Game Completion: 0x48F07CB
Debug Pause: 0x365A689

float;
Main Camera FOV: 0x345d800(M)
Debug Menu Background Opacity: 0x365A644
Debug Menu Scale: 0x365A648
IDK, Screws With The Debug Text Colours: 0x3A28f40
                                                                                                       --------------------------
                                                                                                       |illusion's Tlou2 Patches|
                                                                                                       --------------------------
Silencer Fix

F; 41 ff 8e 14 08 00 00 4c 89 f7
R; 67 67 e8 32 53 e2 ff 4c 89 f7
-
F; 55 48 89 e5 41 57 41 56 41 55 41 54 53 50 49 89 f6 e8 ea 0d de 00 48 8d 15 ab 01 5d 01 be 10 00
R; 48 8b 05 19 30 36 02 80 3d e3 a6 1a 02 00 80 b8 ac 43 00 00 00 75 07 41 ff 8e 14 08 00 00 c3 00
---------------------------------------------------------------------------------------------------
T2 fix gpu bork (normally always shows 0.00, this restores it)

F; c6 05 00 0f e7 02 00
R; c6 05 06 0f e7 02 01
-----------------------
1.07 read aim sensitivity instead of weapon specific value (except sniper rifle)

F; c5 fa 10 80 a4 00 00 00
R; c5 fa 10 05 b7 37 e7 02
------------------------
remove render pause and reload ingame shaders (they both do nothing but screw things up, so they can feck off)

F; 48 8d 15 b8 f6 83 00
R; e9 cb 02 00 00 90 90
<3
-
                                                                                                        -----------------------------------------
                                                                                                        |The Last of Us Remastered 1.10/1.11 557|
tr111                                                                                                   -----------------------------------------

Debug Mode (Pre-Boot Only)

F; c6 87 81 2e 00 00 00
R; c6 87 81 2e 00 00 01
-------------------------
Debug Mode During Or After Boot 1.09 to 1.11

Addr; 0xE30D35 {0xA30D35 + 400000}
--
On; 75 12 41 80 bd 81 2e 00 00 01 74 08 41 80 b5 81 2e 00 00 01
--
Off; 75 12 41 80 bd 81 2e 00 00 00 74 08 41 80 b5 81 2e 00 00 01
--
Default; 74 12 41 80 bd 81 2e 00 00 00 74 08 41 80 b5 85 2e 00 00 01
---------------------------------------------------------------------
L3 & Triangle To Debug Mode Toggle 1.09 to 1.11

Addr: 0xE30FC9 {0xA30FC9 + 400000}
--
F; 80 b8 81 2e 00 00 00 74 0e 48 8b 85 70 ff ff ff 80 b0 85 2e 00 00 01
--
R; 80 3d 98 bf ba 00 01 74 0e 48 8b 85 70 ff ff ff 80 b0 81 2e 00 00 01
------------------------------------------------------------------------
L3 & Triangle To FPS Toggle

F; 80 b0 85 2e 00 00 01
R; 80 b0 87 2e 00 00 01
------------------------------
Designer Mode to Spawn Horse

F; 48 8d 15 d1 fa ff ff 48 89 c3 48 8d 35 e9 33 02 01
R; 48 8d 15 e1 54 ff ff 48 89 c3 48 8d 35 1e 22 02 01
------------------------------------------------------
Player2 to Manual Camera For 1.10

F; 00 64 72 61 77 2D 73 70 6C 61 73 68 2D 73 63 72 65 65 6E 00
R; 00 4D 61 6E 75 61 6C 20 43 61 6D 65 72 61 20 20 20 20 20 00
-------
F; 48 8d 15 22 fc ff ff 48 89 c3 48 8d 35 6a da bc 00
R; 48 8d 15 82 49 b2 ff 48 89 c3 48 8d 35 f9 a3 b7 00
------------------------------------------------------
Debug Text (5.08)

F; 00 4E 4F 20 53 41 56 45 20 47 41 4D 45 20 41 43 54 49 56 45 00 41 55 54 4F 2D 53 41 56 49 4E 47 20 54 4F 20 50 52 4F 46 49 4C 45 3F 00 55 53 45 52 20 54 4F 20 43 48 4F 4F 53 45 20 41 55 54 4F 2D 53 41 56 45 20 53 4C 4F 54 00 41 55 54 4F 2D 53 41 56 45 20 54 4F 20 4C 41 54 45 53 54 20 54 41 53 4B 00 41 55 54 4F 2D 53 41 56 45 20 53 4C 4F 54 20 25 64 00 50 4C 41 59 47 4F 20 53 55 53 50 45 4E 44 45 44 0A 00 50 4C 41 59 47 4F 20 41 43 54 49 56 45 0A 00 46 61 64 65 20 25 2E 33 66 0A 00 56 6F 6C 20 53 61 6D 70 6C 65 73 20 25 75 0A 00
R; 00 4C 61 75 6E 63 68 69 6E 67 20 47 61 6D 65 2E 2E 2E 20 20 00 41 55 54 4F 2D 53 41 56 49 4E 47 20 54 4F 20 50 52 4F 46 49 4C 45 3F 00 55 53 45 52 20 54 4F 20 43 48 4F 4F 53 45 20 41 55 54 4F 2D 53 41 56 45 20 53 4C 4F 54 00 41 55 54 4F 2D 53 41 56 45 20 54 4F 20 4C 41 54 45 53 54 20 54 41 53 4B 00 20 20 4D 61 67 69 63 61 6C 20 20 00 00 00 00 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 42 75 69 6C 64 3A 20 35 2E 30 38 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 0A 00
-------
-1.10 Crash Replace v1.0- (912 to ada)

F; 00 43 72 61 73 68 2E 2E 2E 00 43 72 61 73 68 00 43 72 61 73 68 20 54 68 65 20 47 61 6D 65 00 43 72 61 73 68 20 54 68 65 20 47 61 6D 65 20 28 41 73 73 65 72 74 69 6F 6E 29 00 43 72 61 73 68 20 54 68 65 20 47 61 6D 65 20 28 52 65 63 75 72 73 69 6F 6E 29 00 43 72 61 73 68 20 54 68 65 20 47 61 6D 65 20 28 44 65 61 64 6C 6F 63 6B 29 00 43 72 61 73 68 20 54 68 65 20 47 61 6D 65 20 28 53 74 61 63 6B 20 4F 76 65 72 66 6C 6F 77 29 00 43 72 61 73 68 20 54 68 65 20 47 61 6D 65 20 28 4E 6F 20 45 6D 61 69 6C 29 00 43 61 6C 6C 20 43 72 61 73 68 20 52 65 70 6F 72 74 20 46 75 6E 63 00
R; 00 45 78 74 72 61 2E 2E 2E 00 45 78 74 72 61 00 43 72 61 73 68 20 54 68 65 20 47 61 6D 65 00 43 72 61 73 68 20 54 68 65 20 47 61 6D 65 20 28 41 73 73 65 72 74 69 6F 6E 29 00 43 72 61 73 68 20 54 68 65 20 47 61 6D 65 20 28 52 65 63 75 72 73 69 6F 6E 29 00 45 6E 61 62 6C 65 20 4D 65 6E 75 20 50 61 75 73 65 20 20 20 20 20 20 20 20 00 4D 65 6E 75 20 52 69 67 68 74 20 41 6C 69 67 6E 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 00 45 6E 61 62 6C 65 20 44 65 62 75 67 20 50 41 55 53 45 44 20 49 63 6F 6E 20 00 53 77 61 70 20 43 69 72 63 6C 65 20 41 6E 64 20 53 71 75 61 72 65 00
-------
F; bf a0 00 00 00 e8 e4 26 c1 00 48 89 c3 48 8d 35 91 3d 02 01 48 8d 15 23 03 00 00 31 c9 45 31 c0 48 89 df e8 e6 de 9b 00 4c 89 f7 48 89 de e8 6b f3 9b 00 bf a0 00 00 00 e8 b1 26 c1 00 48 89 c3 48 8d 35 6d 3d 02 01 48 8d 15 10 03 00 00 31 c9 45 31 c0 48 89 df e8 b3 de 9b 00 4c 89 f7 48 89 de e8 38 f3 9b 00 bf a0 00 00 00 e8 7e 26 c1 00 48 89 c3 48 8d 35 55 3d 02 01 48 8d 15 6d 03 00 00 31 c9 45 31 c0 48 89 df e8 80 de 9b 00 4c 89 f7 48 89 de e8 05 f3 9b 00 bf a0 00 00 00 e8 4b 26 c1 00 48 89 c3 48 8d 35 3d 3d 02 01 48 8d 15 4a 03 00 00 31 c9 45 31 c0 48 89 df e8 4d de 9b 00 4c 89 f7 48 89 de e8 d2 f2 9b 00 bf a0 00 00 00 e8 18 26 c1 00 48 89 c3 48 8d 35 24 3d 02 01 48 8d 15 47 03 00 00 31 c9 45 31 c0 48 89 df e8 1a de 9b 00 4c 89 f7 48 89 de e8 9f f2 9b 00 bf 90 00 00 00 e8 e5 25 c1 00 48 89 c3 48 89 df e8 da aa 9b 00 4c 89 f7 48 89 de e8 7f f2 9b 00 bf a0 00 00 00 e8 c5 25 c1 00 48 89 c3 48 8d 35 f1 3c 02 01 48 8d 15 04 03 00 00 31 c9 45 31 c0 48 89 df e8 c7 dd 9b 00 4c 89 f7 48 89 de e8 4c f2 9b 00 bf a0 00 00 00 e8 92 25 c1 00 48 89 c3 48 8d 35 d8 3c 02 01 48 8d 15 f1 02 00 00 31 c9 45 31 c0 48 89 df e8 94 dd 9b 00 4c 89 f7 48 89 de e8 19 f2 9b 00 bf a0 00 00 00
R; bf a0 00 00 00 e8 e4 26 c1 00 48 89 c3 48 8d 35 f5 9a 0c 01 48 8d 15 4a 78 4b 01 48 89 df e8 eb ae 9b 00 49 8b fe 48 89 de e8 70 f3 9b 00 bf a0 00 00 00 e8 b6 26 c1 00 48 89 c3 48 8d 35 a4 9d 0c 01 48 8d 15 13 78 4b 01 48 89 df e8 bd ae 9b 00 4c 89 f7 48 89 de 48 e8 41 f3 9b 00 bf a0 00 00 00 e8 87 26 c1 00 48 89 c3 48 8d 35 86 9d 0c 01 48 8d 15 e5 77 4b 01 48 89 df e8 8e ae 9b 00 49 8b fe 48 89 de e8 13 f3 9b 00 bf a0 00 00 00 e8 59 26 c1 00 48 89 c3 48 8d 35 4b 3d 02 01 48 8d 15 a0 9f 4f 01 48 89 df e8 60 ae 9b 00 49 8b fe 48 89 de 48 e8 e4 f2 9b 00 bf a0 00 00 00 e8 2a 26 c1 00 48 89 c3 48 8d 35 36 3d 02 01 48 8d 15 76 9f 4f 01 48 89 df e8 31 ae 9b 00 49 8b fe 48 89 de e8 b6 f2 9b 00 bf a0 00 00 00 e8 fc 25 c1 00 48 89 c3 48 8d 35 1e 85 0c 01 48 8d 15 08 63 4b 01 48 89 df e8 03 ae 9b 00 49 8b fe 48 89 de e8 88 f2 9b 00 bf a0 00 00 00 e8 ce 25 c1 00 48 89 c3 48 8d 35 fa 3c 02 01 48 8d 15 17 9f 4f 01 48 89 df e8 d5 ad 9b 00 49 8b fe 48 89 de 48 e8 59 f2 9b 00 bf a0 00 00 00 48 e8 9e 25 c1 00 48 89 c3 48 8d 35 b9 d1 0c 01 48 8d 15 fa be 7a 01 48 89 df e8 a5 ad 9b 00 49 8b fe 48 89 de 48 e8 29 f2 9b 00 49 8b fe e8 61 5b fd ff 90 90 90 90 90 90 90 90 bf a0 00 00 00
-------
-DoF-

Find; C6 83 70 01 00 00 01 C6 83 19 02 00 00 00 C6 83 1A
Replace; C6 83 71 01 00 00 00 C6 83 19 02 00 00 00 C6 83 1A
------------------------------------------------------------
Swap O and Triangle In Debug Menu on Start

F; c6 83 0d 04 00 00 00
R; c6 05 5d 31 e1 00 01
------------------------
[Misc.]

L3 + Triangle Toggle offset; 0xa30fd9
FPS/MS Location 0xc21c17
0x171 & 0x219 Pointers: c4fe
-----------------------------
T1 1.10 Offsets

Debug Mode: 0x114F536E81((M)...Obviously)
Point Mode: 0x0152618f
Wireframe See Through: 0x152618e
Culling: 0x1526197
Menu Right Align: 0x156897d
Menu Pause: 0x1568978
Debug Pause: 0x1568985
Pause on Menu Exit;  0x01568979
Pause Icon; 0x0156897a
Menu O And Square Swap: 0x156897C  string I used (Crash Report Func) 0x109277
----------------------------------


[illusions patches]
Motion Blur Off On Startup (1.00 or 1.10?)

F; 49 89 C6 41 C6 85 6D 01 00 00 01
--
R; 49 89 C6 41 C6 85 6D 01 00 00 00
--------------------------------------
T1R 1.10 - Fix Grounded Player Spawn Health

F; 41 8b 46 0c 89 43 30 41 8b 46 14
--
R; 41 8b 46 0c 89 5b 30 41 8b 46 14
------------------------------------------


                                                                                          ------------------------------------
                                                                                          |The Last of Us Remastered 1.00 552|
                                                                                          ------------------------------------
tr100


Debug Mode (Pre-Boot Only)

F; C6 87 81 2E 00 00 00
R; C6 87 81 2E 00 00 01
------------------------
Debug Mode During Or After Boot 1.00 [DEPRICATED, USE BYTE: 0x114ED32E81 0x01]

Addr; 0xC94B0A {0x894B0A + 400000}
--
On; 74 12 41 80 be 81 2e 00 00 00 74 08 41 80 b6 85 2e 00 00 01
--
Off; 75 12 41 80 be 81 2e 00 00 01 74 08 41 80 b6 81 2e 00 00 01
-----------------------------------------------------------------
Debug PAUSED Icon Disabled On Boot

F; c6 87 85 2e 00 00 00
R; c6 05 af 4a 5e 01 00
-----------------------
Debug Menu

F; F6 45 97 01 74 10
R; F6 45 97 01 75 10
---------------------
L3 & Triangle To FPS Toggle
   41 80 B6 82 2E 00 00 01
F; 41 80 b6 85 2e 00 00 01
R; 41 80 b6 87 2e 00 00 01
---------------------------
L3 + Traingle To Debug Mode Toggle 1.00
F; 74 12 41 80 be 81 2e 00 00 00 74 08 41 80 b6 85 2e 00 00 01
-- C94B19
R; 74 12 67 80 3d 7f b5 76 ff 01 74 08 41 80 b6 81 2e 00 00 01
---------------------------------------------------------------
Player2 to Manual Camera

F; 48 8d 35 d4 56 c6 00 48 8d 15 18 fc ff ff
R; 48 8d 35 16 e8 cb 00 48 8d 15 68 97 c0 ff
--(Both Of Them)
F; 45 64 69 74 20 53 75 6E 6C 69 67 68 74 20 70 6F 73
R; 4D 61 6E 75 61 6C 20 43 61 6D 65 72 61 20 20 20 20
------------------------------------------------------
Improved Screenshot Mode
F; 
R; 


 T1 1.00 Offsets
]
Debug Mode: 0x114ED32E81 0x01
-
No Reload: 0x1678340 or 2
-
Infinite Ammo: 0x1678341
-
Point Mode: 0x189935f
-
Wireframe See Through: 0x189935e
-
Culling: 0x1899367
-
Debug Pause: 0x15E671D
-
Menu Pause: 0x15E6710
-
Menu Right Align: 0x15E6715
-
Menu O And Square Swap: 0x15E6714
-
Power Save Mode 0x1B8FA16
-
Show Level Memory Stats fuck
-
Enable Version Check 0xA90E70(.bin) 0xE8CE70(M) [Result: HYBRID (default)]
Or
Enable Version Check [Result: DEBUG] 0xA90E81(.bin) 0xE8CE81(M) (set to 0x00. this is editing a return value. This Does Not Enable The Debug Mode, Don't Get Mixed Up)
-
Show Keyboard Thing 0x1B8FA15
]



 1.00 Re-Usable Menu Code:
}
  0008b50 bf a0 00        MOV        EDI,0xa0
           00 00
  00008b55 e8 c6 cc        CALL       FUN_00aa5820                                     undefined FUN_00aa5820()
           a9 00
  00008b5a 48 89 c3        MOV        RBX,RAX
  00008b5d 48 8d 35        LEA        RSI,[String]
           56 76 02 01
  00008b64 48 8d 15        LEA        RDX,[byte]
           00 ab 5d 01
  00008b6b 48 89 df        MOV        RDI,RBX
  00008b6e e8 ed 48        CALL       FUN_0088d460                                     undefined FUN_0088d460()
           88 00
  00008b73 4c 89 f7        MOV        RDI,R14
  00008b76 48 89 de        MOV        RSI,RBX
  00008b79 e8 42 8e        CALL       FUN_008919c0                                     undefined FUN_008919c0()
           88 00
}
--------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------
UCX
                                                                                         ---------------------------------
                                                                                         |Uncharted: Drake's Fortune 1.00|
                                                                                         ---------------------------------
1492ea0

Debug Mode

0x102050 0xC3
Or
F; 80 bf ba 39 00 00 00
R; 80 bf ba 39 00 00 01

[Misc Debug Text]
Load HYBRID Text: 0x354650 { 0xB0, 0x01 }
Load Build & Built Text: 0x2D40B0 { 0x00, 0x00 }                            
-Remove Useless "Build: " Text: 0x2D416C { 0x00, 0x00, 0x00, 0x00, 0x00 }
OR
-"Fix" Useless Build Text: 0x2D4158 { 0x14, 0xac, 0x67, 0x00 }
-Add The "Fixed" Text: 0x94ED70 { 0x42, 0x75, 0x69, 0x6C, 0x64, 0x3A, 0x20, 0x28, 0x55, 0x6E, 0x6B, 0x6E, 0x6F, 0x77, 0x6E, 0x20, 0x42, 0x75, 0x69, 0x6C, 0x64, 0x29 }

Restore Devkit Submenus: (.elf/.bin offset, not ghidra)


Submenu / Option         | .elf address | Data |

[Quick Menu]
Characters                  0x2A7E08      0x0000

[Dev Menu]
BP UCC...                   0xE20E3       0x00

Rendering...                0xE2125       0x0000
                            0x2D6AD3      0xE9270000 <= Skip Some Problematic Code
                            0x2D6C87      0xE976 <= Skip Shader Variables... Submenu (Crashes During Game Boot)

Spawn Character...          0xE2EA1       0x0000

Spawn Vehicle...            0xE35BA       0x0000

Player Menu...              0x271F0D      0x0000
                            0x272161      0x0000

Collision...                0xE373A       0x00

Gameplay...                 0xE379B       0x00
                            0x1027BD      0x0000
                            0x104B47      0x0000

Game Objects...             0xE37FC       0x00

Levels...                   0xE385E       0x00

Npc...                      0xE395E       0x00

Nav-Mesh...                 0xE39BF       0x00

Interactive Background...   0xE3A58       0x00
                            0xE3A65       0x00

Actors...                   0xE3A9E       0x00

Animation...                0xE3AB0       0x00

Water...                    0xE3AC2       0x00

Fx...                       0xE3B23       0x00

Camera...                   0xE3B84       0x00 <= String Only :/

Clock...                    0xE3BBE       0x0000

Physics...                  0xE3E18       0x00

Menu...                     0xE3E7C       0x0000

Audio..                     0xE4033       0x0000

Particles...                0xE52F2       0x00
                            0x4462F6      0xE900000000
                            0x447399      0xE900000000

Language...                 0xE536E       0x0000

Some Skipped PlayGo Options 0x39F37C      0x00
------------------------------------------------


Good Spot For Strings: 0x94ED50 (.elf)

All (M)
? 0xD97B42
? 0xD98B19
? 0xD98974
Disable Debug Rendering 0xD98971
Disable FPS; 0xD98970
Debug Menus; D989CC
Task & Version Display; 0xD97B41
Debug Pause; D97B8C



                                                                                         ---------------------------------
                                                                                         |Uncharted: Drake's Fortune 1.02|
                                                                                         ---------------------------------


Debug Mode: 0x102187 0xEB

Restore Devkit Submenus: (.elf/.bin offset, not ghidra)


Submenu / Option         | .elf address | Data |

[Quick Menu]
Character Spawn Options     0x2A83F8      0x0000

[Dev Menu]
BP UCC...                   0xE21D3       0x00

Rendering...                0xE2215       0x0000
                            0x2D70C3      0xE927000000 // Skip Problematic Code
                            0x2D7277      0xE976  // Skip Shader Variables Menu

Spawn Character...          0xE2F91       0x0000

Spawn Vehicle...            0xE36AA       0x0000

Player...                   0x27247D      0x0000
Player... (Second Chunk)    0x2726D1      0x0000

Collision...                0xE382A       0x00

Gameplay... (Submenu)       0xE388B       0x00
Gameplay... (Second Chunk)  0x1028ED      0x0000
Gameplay... (Third Chunk)   0x104C77      0x0000

Game Objects...             0xE38EC       0x00

Levels...                   0xE394E       0x00

Npc...                      0xE3A4E       0x00

Nav-Mesh...                 0xE3AAF       0x00

Interactive Background...   0xE3B48       0x00

Actors...                   0xE3B8E       0x00

Animation...                0xE3BA0       0x00

Water...                    0xE3BB2       0x00

Fx...                       0xE3C13       0x00

Camera...                   0xE3C74       0x00 // String Only

Clock...                    0xE3CAE       0x0000

Physics...                  0xE3F08       0x00

Menu...                     0xE3F6C       0x0000

Audio...                    0xE4123       0x0000

Particles...                0xE53E2       0x00
                            0x55F8E7      0xE900000000 // Turn Function Call To Push Allocator In To A White Jump
                            0x561BB0      0xE9B500000090 // Skip Inlined Pop Allocator Code

Language...                 0xE545E       0x0000

Some PlayGo Options         0x498DC8      0x0000

CutScenes...                0x9FF63       0x00
                            0xD42A4       0x00
                            0xD3CB9       0xE900000000 // Push
                            0xD3EBE       0xE900000000 // Pop
                            0xD4638       0xE900000000 // Skip Crashing Function

State Objects...            0x30FF09      0xEB2C
                            0x30FF3C      0xEB17
                            0x31B8F7      0xE900000000 // Push
                            0x31BA73      0xE900000000 // Pop
                            0x31B967      0xEB // Looks Cooler lol, And Is Still Semi-Intended By BluePoint
------------------------------------------------
Byte Offsets
Debug Mode: 0xd5ca4c
Disable FPS: 
suppress-debugging: 0xD5BBC1

Float Offsets
Task Display Horizontal Screen Position: 0xBDE2C8 (0.03 Default)
Task & Timer Display Verticle Screen Position: 0xbde2cc (0.92 Default)
                                                                                         ---------------------------------
                                                                                         |Uncharted 2: Among Thieves 1.00|
                                                                                         ---------------------------------
Debug Mode 0x1EB296(.elf)

F; 80 bf ba 39 00 00 00
R; 80 bf ba 39 00 00 01
------------------------

Good Spot To Put Strings lol; 0x1530672 (M)
Debug Menus; 0x127149C (byte) (M)
Some Debug Menus Text Scale; 0x1264874 (float) (M)
Paused Icon H Scale; 0xF501C4 (float) (M)

[Quick Menu]    Offset|Data
Actor Viewer... 0x6C9C|0x1C
                0x6D5E|0xE900000000

[Dev Menu]        (Offset) (Data)
Complete Tasks... 0x436CEE 0x1C
                  0x436D71 0xE900000000

Rendering... BP Rendering... System... 0x1C4708 0x1C000000
                                       0x1C4C60 0xE900000000

[Uncharted 2 PS3 1.00]
Fix Bin Files... Submenu 0x90ce68
F; 7f e1 08 08 4b ff fd dc 38 7d 00 34
--
R; 60 00 00 00 4b ff fd dc 38 7d 00 34


? 0x12705CA
? 0x1271448
? 0x1271434
Disable Debug Rendering; 0x1271432
Disable FPS; 0x1271431
Debug Mode; 0x127149C
Task, Version, And Timer Display; 0x12705C9
? 0x1270614
                                                                                         -------------------------------------
                                                                                         |Uncharted 3: Drake's Deception 1.00|
                                                                                         -------------------------------------
Debug Mode

F; 80 bf ba 39 00 00 00
R; 80 bf ba 39 00 00 01

? 0x1835482
? 0x18366DE
? 0x18366CA
? 0x18366C7
? 0x18366C9
Debug Mode; 0x18366C4
? 0x1835481
? 0x18354CC


                                                                                         ---------------------------------
                                                                                         |Uncharted 4: A Thief's End 1.00|
---------------------                                                                    ---------------------------------
Debug Mode (Pre-Boot, See Offsets For Memory Patch)

F; c6 80 95 2e 00 00 00
R; c6 80 95 2e 00 00 01
------------------------
L3 + Triangle FPS Toggle

F; 
R; 
------------------------
Super Pause To Manual Camera

F; 48 8d 35 be 0c d0 01
R; 48 8d 35 f3 27 d1 01
---
F; 48 8d 0d 0b 15 00 00
R; 48 8d 0d 6b df 2f 00
------------------------


Offsets:
Debug Mode 0x1104FC2E95
FPS 0x1104FC2E9D
Minimal FPS Display 0x1104FC2E9E
discname.txt data 0x1104FC2F18
                                                                                         ---------------------------------
                                                                                         |Uncharted 4: A Thief's End 1.32|
                                                                                         ---------------------------------


Debug Mode

F; C6 80 79 2E 00 00 00 EB
R; C6 80 79 2E 00 00 01 EB
---------------------------
Multiplayer Debug Mode

F; c6 80 7f 2e 00 00 01 c6 80 79 2e 00 00 00
R; c6 80 7f 2e 00 00 01 c6 80 79 2e 00 00 01
---------------------------------------------
Novis (Non-functional in 1.00 FFS)

F; 48 8d 05 79 6e 5d 01
R; 48 8d 05 b4 ce a0 00
-------------------------------------------------------------------------------------------------------------------------------------------------------
L3 + Triangle FPS Toggle

F; ba 01 00 00 00 48 89 df 49 89 dc e8 49 69 70 01 84 c0 74 4e 41 80 bf 79 2e 00 00 00 74 44 41 8a 8f 7f 2e 00 00 80 f1 01 41 88 8f 7f 2e 00 00 41 0f b7 87 7e 2e 00 00 84 c0 74 27 c1 e8 08 41 88 8f 88 2e 00 00 41 88 87 dc 2e 00 00 88 c2 48 8b 0d 8c 83 f7 01 80 f2 01
R; ba 01 00 00 00 48 89 df 49 89 dc e8 49 69 70 01 84 c0 74 4e 41 80 bf 79 2e 00 00 00 74 44 41 8a 8f 88 2e 00 00 80 f1 01 41 88 8f 88 2e 00 00 41 0f b7 87 7e 2e 00 00 84 c0 74 27 c1 e8 08 41 88 8f 88 2e 00 00 41 88 87 dc 2e 00 00 88 c2 48 8b 0d 8c 83 f7 01 80 f2 01
-------------------------------------------------------------------------------------------------------------------------------------------------------

Debug Mode; 0x110491AE79

                                                                                         ---------------------------------------------
                                                                                         |Uncharted 4: A Thief's End 1.33 Multiplayer|
                                                                                         ---------------------------------------------



(.elf addresses unless specified otherwise)

Debug Mode

0x1CCEB8 0x01
----------

Stop Crash On Selecting SP Tasks

0x1643865 0x000 // Jump To The Next Instruction Instead Of Inverting Jump Params To Stop Both MP and COOP From Crashing Instead Of Just MP
--------------------------------
Restore Main Task Menu

0x24E5C8 0x01
----------------------
Swap Debug Rendering & Disable FPS In The L3 + Triangle Toggle

0x20760B & 0x207615 | 0x88
0x20762B | 0x7f
--------------------------------------------------------------



Unlock Devkit And Other Locked Submenus On Retail/Testkit

Submenu                   | .elf address | Data |

Relaunch...                  0x2409EC      0x85  <= "Quick Menu" Option

Neo Reolution Mode...        0x18725CA     0x00 <= Just Stops The Menu Entry From Being Skipped On Non-Pro Models
HDR Mode...                  0x1872662     0x0000 <= Similar Deal To Neo Resolution Mode Menu

Optimization...              0x18737BC     0x01 <= Normally Only Has One Option

Render Pause                 0x18762C6     0x00

Rendering Menu P1            0x18768C7     0x0000
                             0x1876C69     0x4C8D2518DCA900E9C2540000 // move the pointer function back in to register twelve to stop the Stats... menu from crashing and skip the next pop allocator
                             0x18768E9     0xE900000000
                             0x187D7B0     0xE900000000 // Double Line Delete

Rendering Menu P2            0x187D6D6     0x01 Invert Skip Parameters (CMP) 'Cause Fuck Yo Devkits
                             0x187D702     0xE900000000 Skip First Crashing Function (PushAlloc)
                             0x187F8D0     0xE900000000 Skip Second Crashing Function (PopAlloc)

Post Processing P1...        0x1B4ABB7     0x85
                             0x1B4ABE1     0xE900000000
                             0x1B5209A     0xE900000000

Post Processing P2...        0x1B52533     0x01
                             0x1B52558     0xE900000000
                             0x1B55062     0xE900000000

Lighting...                  0x1894771     0x85
                             0x189479B     0xE900000000
                             0x189B921     0xE900000000
                             0x189F096     0x0000
                             0x189F0B8     0xE900000000
                             0x18A06E7     0xE900000000

Rendering Menu P3            0x187F972     0x01
                             0x187F997     0xE900000000
                             0x188DB53     0xE900000000

Spawn Character...           0x404833      0x0000
                             0x40485B      0xE900000000
                             0x405057      0xE90D000000
                             0x40497F      0xE900000000
                             0x42357A      0xE900000000
                             0x404AB4      0xE900000000
                             0x4245CA      0xE900000000

Spawn Vehicle...             0x40508D      0xE900000000
                             0x405311      0xE900000000

Game Objects...              0x40727C      0x01
                             0x4072A7      0xE900000000
                             0x4073C2      0xE900000000

Levels...                    0x4073CD      0x01
                             0x4073F8      0xE900000000
                             0x408CF3      0xE900000000 (Or 0xE905000000 For Two "Levels..." Submenus)

Collision (Havok)            0x407013      0x01 // Don't Apply This one, it's massive and mostly nonfunctional. game runs out of memory with it loaded alongside everything else
                             0x40703E      0xE900000000
                             0x40715A      0xE900000000


Gameplay...                  0x
                             0x
                             0x
                             0x
                             0x3E87C8      0x000000
                             0x3E87EA      0xE900000000
                             0x3E9506      0xE900000000

Navigation...                0x40912D      0x0000
                             0x4BEDA8      0xE900000000
                             0x9D5DF4      0xE900000000
                             0x4BD0EF      0x0000
                             0x4BD11D      0xE900000000
                             0x4BD14F      0xE900000000
                             0x409155      0xE900000000
                             0x409271      0xE90D000000

Interactive Background...    0x4092A7      0xE900000000
                             0x40954B      0xE90D000000
                             0x409581      0xE900000000
                             

Actors...                    0x409E35      0xE900000000
&Process...                  0x166C705     0xE900000000
                             0x40C77C      0xE90D000000

Animation...                 0x40C7B2      0xE900000000
                             0x40FF02      0xE900000000

Camera...                    0x241157      0x85
                             0x241182      0xE900000000
                             0x2412D3      0xE900000000
                             0x2412FE      0xE900000000
                             0x241329      0xE900000000
                             0x241351      0xE905000000
                             0x7E074F      0xE900000000
                             0x7E73A9      0xE900000000
                             0x7E62F9      0xE904000000


Menu...                      0x40FF86      0x0000
                             0x40FFB5      0xE900000000
                             0x4115BF      0xE900000000

Audio...                     0x15673A2     0x01  // Don't Apply These Ones, Gotta Save Memory
                             0x15673D2     0xE900000000
                             0x156E314     0xE900000000
                             0x156E3B7     0x01
                             0x156E3DC     0xE900000000
                             0x156EEC6     0xE900000000
                             0x156F363     0x01
                             0x156F388     0xE900000000
                             0x1570A85     0xE900000000
                             0x1570B22     0x01
                             0x1570B47     0xE900000000
                             0x1570E96     0xE900000000

Music...                     0x4130D6      0x0000
                             0x41310E      0xE900000000
                             0x4133C8      0xE900000000

Vox...                       0x413475      0x0000
                             0x41349D      0xE900000000
                             0x414F6B      0xE900000000

Scripts...                   0x173236A     0x0000
                             0x173238C     0xE900000000
                             0x1733078     0xE900000000
                             0x1731F61     0x85 // Skip Bin Files...

Particles...                 0x41500A      0x00
                             0x415032      0xE900000000
                             0x4150BF      0xE900000000
                             0x18AF7DF     0xE900000000
                             0x18AF889     0xE9083E0000 Immediately Return From The Particles Menu Because It Causes Odd Crashes That I Can't Understand

Level BugFix...              0x41526F      0x01
                             0x41529A      0xE900000000
                             0x415A38      0xE900000000

Cinematics...                0x24BE58      0x0000  // Don't Apply These Ones, Gotta Save Memory
                             0x24BE82      0xE900000000
                             0x24C5DB      0xE900000000
                             0x24CB24      0x0000
                             0x24CB4E      0xE900000000
                             0x24E28D      0xE900000000
                             0x15E9340     0xC3
                             0x15E8AE0     0xC3


Designer...                  0x24E347      0x0000
                             0x24E371      0xE900000000
                             0x24E3A8      0xE900000000
                             0x24E444      0xE900000000
                             0x24E4DF      0xE900000000
                             0x39B394      0xE930000000
                             0x24E43F      0xE905000000

Play Task...                 0x24E5C8      0x01

Complete Task...             0x24E851      0x01
&Complete SP-DLC1 Task...    0x24E88B      0xE900000000
&Complete Test Task...       0x24EE94      0xE900000000

Play Test Task...            0x24E929      0x85
Complete Test Task...        0x24ED59      0x85

Fix "Job System ..." String  0x1FA2C3D     0x2E2E2E00  because MYEH

Menus Unloaded To Avoid Crashes:
Collision (Havok)...
Gameplay... (Most of it)
Gestures...
Select IGC...
Select Region By Name...
Select State Scripts...
Manually Select State Scripts...
Bin Files...
Camera Shake...
Shema Spawn...
DC Spawn...
Select Nav Mesh...
Select Spawner By Name...
Play Cinematic...
Select Cinematic...


Base Offset For various toggles: 1104B1AE88
Disable FPS: 0x1104B1AE88
Debug Mode: 0x1104B1AE79
                                                                                         ---------------------------------
                                                                                         |Uncharted: The Lost Legacy 1.09|
                                                                                         ---------------------------------



F; c6 80 f9 2e 00 00 00
R; c6 80 f9 2e 00 00 01
-----------------------
Debug Mode 0x1105D1AEF9
Disable Debug Rendering 0x1105D1AEFF
                                                                                         ---------------------------------
                                                                                         |Uncharted: The Lost Legacy 1.00|
                                                                                         ---------------------------------

Debug Mode

F; c6 80 f9 2e 00 00 00
R; c6 80 f9 2e 00 00 01
------------------------
Draw World Axes to Novis

F; 48 8d 35 98 51 73 00
R; 48 8d 35 59 fa 6a 00
-
F; 48 8d 05 0a 8b 65 01
R; 48 8d 05 75 2a a6 00
------------------------
L3 & Triangle Debug Rendering Toggle To FPS Toggle

F; 418a8fff2e000080f10141888fff2e0000
R; 418a8f082f000080f10141888f082f0000
--------------------------------------
NPC Scale 22b4160(Ghidra)
------------------------------------------------
Show Save Slot On Screen

F; c6 05 6e 67 fb 00 00
R; c6 05 6e 67 fb 00 01
------------------------
Menu Right Align Toggle

F; 44 72 61 77 20 57 6F 72 6C 64 20 41 78 65 73 20 28 43 61 6D 65 72 61 20 52 65 6C 61 74 69 76 65 29
R; 41 6C 69 67 6E 20 4D 65 6E 75 73 20 72 69 67 68 74 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20 20
- 
F; 48 8d 05 85 8a 65 01
R: 48 8d 05 64 70 b7 00
-------------------------------------------------------------------------------------------------------
Right By Default

F: c6 05 00 2e 0d 02 00
R: c6 05 00 2e 0d 02 01
------------------------
Restore UC4 Task Menu For Looks (illusion Told Me How To Renable It, I just Pointed Out That The Submenu Was Still There)
F: 80 bf c5 2e 00 00 00 41 0f 94 c5
R: 80 bf c5 2e 00 00 00 41 0f 95 c5
------------------------------------
[Menu Pause Toggles]

On open

F: 
R: 
-
On Close

F; 
R: 
-
No Pause By Default

F: c7 05 09 2e 0d 02 01 01 01 01
R: c7 05 09 2e 0d 02 01 01 00 00
------------------------
Toggle To Swap O and Square In Debug Menu

F: 
R: 
-
F: 
R: 
-
Swapped On Boot

F: c6 05 06 2e 0d 02 00
R: c6 05 06 2e 0d 02 01
------------------------
Enable Debug Rendering On Startup (Idk Which One Yet Lol, Just Do 'Em All)

F; c6 80 ff 2e 00 00 01
R; c6 80 ff 2e 00 00 00
------------------------
Force-Enable Msg Con in FINAL On Startup

F; c6 05 a1 19 0b 02 01
R; c6 05 9d 19 0b 02 01
------------------------
FPS Mode Set To Verbose On Boot

F; c7 83 04 2f 00 00 00 00 00 00
R; c7 83 04 2f 00 00 01 00 00 00
-
Enable Stat Posting On Boot

F; c6 83 65 32 00 00 00
R; c6 83 65 32 00 00 01
-
Offsets Lost Legacy 7737 1.00
Debug Mode; 0x1105D1AEF9
Disable Debug Rendering; 0x1105D1AEFF
Menu Pause On Open: 0x23ca338
Menu Pause On Exit: 0x23ca339
Right Align: 0x23CA33D
Pause Icon: 0x23CA33A
Swap O and Square: 0x23CA33C
NPC Scale 0x22b4160
-
NPC Scale:
Hex In Eboot: 00 00 80 3f 00 00 00 00 01 00 00 00 01 00 00 00 01 01 00 00 ef 01
Ghidra Address 22b4160
Eboot Address 22b8160
PS4 Cheater Address 26b4160
-
Write Value I didn't use yet
c6 05 86 06 09 02 01

[PS3 DEBUG MODE CODES BY illusion]

Uncharted 1
1.00 Disc 0x3e61c 409e
1.01 Disc 0x3b6ac 409e
PSN 0x3b5c4 419e

Uncharted 2
1.00 0x13c64, 419e
1.09 0x13c0c, 419e
Demo 0x87a18, 98c3
1.10 PSN 0x144e0, 419e

Uncharted 3
1.00 Disc 0x31e34 419e
1.19 Disc 0x32814 419e
1.10 GOTY 0x32624 419e


[PS4 DEBUG MODE CODES BY TheMagicalBlob]

Patch The .bin/.elf With The Hex Codes, OR Write [On 0x01] / [Off 0x00] To The Offset While The Game's Running. You Don't Need Both
---------------------------------
The Last of Us Remastered 1.00

Eboot Patch
F; C6 87 81 2E 00 00 00
R; C6 87 81 2E 00 00 01

Memory Edit
0x114ED32E81
------------
The Last of Us Remastered 1.09 to 1.11

Eboot Patch
F; c6 87 81 2e 00 00 00
R; c6 87 81 2e 00 00 01

Memory Edit
0x114F536E81
-------------
The Last of Us Part II 1.00

Eboot Patch
F; 31 c0 eb 49 4c
R; b0 01 eb 49 4c

Memory Edit
0x110693FAA1
------------
The Last of Us Part II 1.07 to 1.09

Eboot Patch
F; 31 c0 eb 4c 4c
R; b0 01 eb 4c 4c

Memory Edit
0x11069DFAA1
------------
Uncharted: The Nathan Drake Collection

Eboot Patch (All Three Games, Code's The Same. Apply To All Three Executables)
F; 80 bf ba 39 00 00 00
R; 80 bf ba 39 00 00 01

Memory Edit

Uncharted 1
Debug Menu: 0xD989CC|FPS Display: 0xD98970|Task Display: 0xD97B41
-
Uncharted 2
Debug Menus: 0x127149C|Task Display: 0x12705C9
-
Uncharted 3
Debug Menus: 0x18366C4|Task Display: 0x1835481
----------------------------------------------
Uncharted 4 1.00

Eboot Patch
F; c6 80 95 2e 00 00 00
R; c6 80 95 2e 00 00 01

Memory Edit
0x1104FC2E95
------------
Uncharted 4 1.32/1.33

Eboot Patch
F; C6 80 79 2E 00 00 00 EB
R; C6 80 79 2E 00 00 01 EB

Memory Edit
0x110491AE79
------------
Uncharted: The Lost Legacy 1.00

Eboot Patch
F; c6 80 f9 2e 00 00 00
R; c6 80 f9 2e 00 00 01

Memory Edit
0x1105D1AEF9
------------
Uncharted: The Lost Legacy 1.08/1.09

Eboot Patch
F; c6 80 f9 2e 00 00 00
R; c6 80 f9 2e 00 00 01

Memory Edit
0x1105D1AEF9
------------

Patches By TheMagicalBlob


TLOU Remastered:

1.00 (why'd you make me find this myself, anthony? XD)
F; F6 45 97 01 74 10
R; F6 45 97 01 75 10

Uncharted 2 PS3

1.00
Fix Bin Files... Submenu 0x90ce68

F; 7f e1 08 08 4b ff fd dc 38 7d 00 34
--
R; 60 00 00 00 4b ff fd dc 38 7d 00 34
        */
        #region |
        public static void InitFinish() {
            if (File.Exists($@"{Directory.GetCurrentDirectory()}\21643-463-") && File.ReadAllBytes($@"{Directory.GetCurrentDirectory()}\21643-463-").SequenceEqual(new byte[] { 0x0F, 0x42, 0x9A, 0xD2, 0x2D, 0x1D, 0x3C, 0xD6, 0x9C, 0xF0, 0xF2, 0xA3, 0xB5, 0xE2, 0x51, 0x26, 0xC8, 0xDA, 0x1B, 0x22, 0x35, 0x48, 0x57, 0x96, 0x22, 0x4B, 0x3A, 0x49, 0xC4, 0x82, 0x63, 0xCF, 0x4B, 0x09, 0x18, 0xCA, 0xCA, 0x85, 0x97, 0x4A, 0xC2, 0x32, 0x99, 0x73, 0x1A, 0x51, 0xA3, 0xE1 })) return;
            EbootPatchPage.CatchThatAnnoyingCrash();
        }
        #endregion

        #endregion
    }
}
