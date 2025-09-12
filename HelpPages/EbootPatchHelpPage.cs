using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using static Dobby.HelpPageCommon;
using static Dobby.Common;
using System.Linq;
using System.IO;

namespace Dobby {
    public partial class EbootPatchHelpPage : Form
    {
        //================================\\
        //--|   Class Initialization   |--\\
        //================================\\
        /// <summary>
        /// Initialize a new instance of the EbootPatchHelpPage Form.
        /// </summary>
        public EbootPatchHelpPage()
        {
            InitializeComponent();
            InitializeAdditionalEventHandlers(this);

            // Just write the contents inside the designer's little editor for the Text property, then paste here. Still better than the previous method
            Question0Btn.Tag = "\n- FTP: Have Your PC And PS4 On The Same Network,\n  And Either Send The FTP Payload To Your PS4,\n  Or Enable FTP In GoldHEN's Settings.\n  Then, Go To mnt/sandbox/CUSAXXXXX/app0,\n  You Game's Executables And\n  Other Files Will Be There.\n\n- App Dumper: Dump The App Via The\n  Homebrew Store, Or Vortex Dumper\n  1.8 Payload. The Unsigned Eboot Will\n  Be In The Dumped Game Data,\n  Ready To Be Patched.\n\n- orbis-pub-chk.exe: Extract The .pkg With The\n  Hacked PS4 SDK Tool orbis-pub-chk.exe, Then\n  Unsign/Decrypt The eboot With Unfself.exe/.py\n";
            Question1Btn.Tag = "\n- App Dumper: Dump The App Via The\n   Homebrew Store Or Vtx Dumper 1.8\n   Payload By Running The Game,\n   Then Sending The Dumper Payload To\n   The PS4 With An Ext HDD/SSD Connected.\n\n- fPKG/.pkg: Open orbis-pub-chk And\n  Import The .pkg You Want To Extract\n  By Dragging It, Or With The \"Add Image\" Button.\n  Select The eboot.bin And Choose An Output\n  Directory, And Then Extract.\n  (fPKG Passcode Is 32 Zeros)\n";
            Question2Btn.Tag = "\n- The First Way Is With The Official PS4 SDK Tools,\n  Which I Can Not Include In My Projects Due To\n  Them Being Copyrighted Sony PS4 SDK Tools.\n\n  Use The PkgCreationPage To Build A New\n  .pkg Once You've Got The FakePKGTools\n  Downloaded, And Have Made A .gp4\n  \n\n- The Second Way Is With The Patch Builder\n  App From ModdedWarfrare, Which You\n  Can Easily Find With A Quick Google\n  Or Even Youtube Search\n\n";
            Question3Btn.Tag = "\nBecause Depending On The Game, There May\nEither Be A Large Amount Of Skipped Or \nUncalled Code That Can Be Restored With\nVarrying Levels Of Effort-\n\nOr, There May Only Be Small Things Leftover\nWhich I Just Add To Existing Submenus For\nThe \"Custom Debug\".\n\nHowever- I'm not Gonna Sit Around And\nMake These Patches For Every Version Of\nEvery Game. For These, The Button's Disabled";
            
            DefaultQuestion = ActiveQuestionBtn.Text;




            Questions = new bool[Controls.OfType<Dobby.Button>().Where(button => button.Name.Contains("Question")).Count()];


            Actions = new[]
            {
                new Action(() =>
                {
                    AdditionalInfoButton.Visible = false;
                }),

                new Action(() =>
                {
                    AdditionalInfoButton.Text = "Homebrew Store";

                    AdditionalInfoButton.Size = new Size(108, 15);
                    AdditionalInfoButton.Location = new Point(12, 80);
                    AdditionalInfoButton.Font = new Font("Cambria", 9.5F, FontStyle.Bold | FontStyle.Underline);

                    AdditionalInfoButton.Visible = true;
                }),
                
                new Action(() =>
                {
                    AdditionalInfoButton.Visible = false;
                }),
                
                new Action(() =>
                {
                    AdditionalInfoButton.Visible = false;
                }),
            };

            DefaultAction = new Action(() =>
            {
                AdditionalInfoButton.Text = "*(with some exceptions)";

                AdditionalInfoButton.Size = new Size(130, 17);
                AdditionalInfoButton.Location = new Point(184, 83);
                AdditionalInfoButton.Font = new Font("Cambria", 8F, FontStyle.Bold);

                AdditionalInfoButton.Visible = true;
            });



            if (Actions.Length != Questions.Length)
            {
                var message = $"Mismatched sizes for Actions and Questions array! (Actions.Length {(Actions.Length < Questions.Length ? '<' : '>')} Questions.Length)";
                #if DEBUG
                    ShowPopup(message, "ERROR INITIALIZING " + nameof(EbootPatchHelpPage).ToUpper() + ';');
                #else
                    throw new InvalidDataException(message);
                #endif
            }
            else
                Dev?.Print(Questions.Length);
        }





        
        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]
        /// <summary>
        /// #1 How Do I Get My Game's eboot.bin?<br/>
        /// #2 How Do I Extract My Game's .pkg?<br/>
        /// #3 How Do I Make A New .pkg Afterwards?<br/>
        /// #4 Why Is The Restored/Custom Button Disabled?<br/>
        /// </summary>
        public readonly bool[] Questions;

        public readonly string DefaultQuestion;

        public bool IsDefaultQuestion = true;

        public Action[] Actions;

        public Action DefaultAction;



        private enum QuestionIDs : byte
        {
            HowToGetEboot,
            HowToExtractPkg,
            HowToBuildNewPkg,
            WhyRestoredAndCustomDisabled
        }
        #endregion





        //==================================\\
        //--|   Function Delcarations   |---\\
        //==================================\\
        #region [Function Delcarations]

        #endregion





        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]

        private void Question0Btn_Click(object sender, EventArgs e) => LoadHelpPageQuestion(this, 0);
        private void Question1Btn_Click(object sender, EventArgs e) => LoadHelpPageQuestion(this, 1);
        private void Question2Btn_Click(object sender, EventArgs e) => LoadHelpPageQuestion(this, 2);
        private void Question3Btn_Click(object sender, EventArgs e) => LoadHelpPageQuestion(this, 3);


        private void WithSomeExceptionsLabel_Click(object sender, EventArgs e)
        {
            if (IsDefaultQuestion)
            {
                ShowPopup("Some Misc. Patches Will Be Applied To Uncharted 4/Lost Legacy Multiplayer Eboots To Make The Game Playable");
            }
            else if (ShowPopup("Do You Want To Open Your Browser To The Homebrew Store/Itemzflow Download Page?", "Open Itemzflow Download Page On pkg-zone?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Process.Start("https://pkg-zone.com/details/ITEM00001");
            }
        }
        private void WithSomeExceptionsLabelMH(object sender, EventArgs e) => AdditionalInfoButton.ForeColor = Color.Aqua;
        private void WithSomeExceptionsLabelML(object sender, EventArgs e) => AdditionalInfoButton.ForeColor = Color.White;
        #endregion
    }
}
