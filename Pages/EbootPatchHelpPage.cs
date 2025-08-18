using System;
using System.Diagnostics;
using System.Windows.Forms;
using static Dobby.Common;
using System.Drawing;

namespace Dobby {
    public partial class EbootPatchHelpPage : Form {
        
        /// <summary>
        /// Initialize a new instance of the EbootPatchHelpPage Form.
        /// </summary>
        public EbootPatchHelpPage()
        {
            InitializeComponent();
            
            InitializeAdditionalEventHandlers(this);

            Question0Btn.Text = "- How Do I Get My Game's eboot.bin?";
            Question0Btn.Tag = "";
            Question1Btn.Text = "- How Do I Extract My Game's .pkg?";
            Question1Btn.Tag = "";
            Question2Btn.Text = "- How Do I Make A New .pkg Afterwards?";
            Question2Btn.Tag = "";
            Question3Btn.Text = "- Why Is The Restored/Custom Button Disabled?";
            Question3Btn.Tag = "";
        }


        
        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]

        private readonly string[] headers = new []
        {
            "                  [Getting The Game's Executable]\n",
            "       [Extracting Your Game's .pkg \\ Dumping It]\n",
            "                             [Building A New .pkg]\n",
            "           [Why Is \"Restored/Custom\" Disabled?]\n"
        };

        /// <summary>
        /// #1 How Do I Get My Game's eboot.bin?<br/>
        /// #2 How Do I Extract My Game's .pkg?<br/>
        /// #3 How Do I Make A New .pkg Afterwards?<br/>
        /// #4 Why Is The Restored/Custom Button Disabled?<br/>
        /// </summary>
        private bool[] Questions = new bool[4];
        private bool DefaultQuestion = true;
        #endregion




        
        //=============================================\\
        //--|   Background Function Delcarations   |---\\
        //=============================================\\
        #region [Background Function Delcarations]

        private void LoadQuestions(int Index) {
            
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EbootPatchHelpPage));

            for (int i = 0; i < Questions.Length; i++) // Reset The Other Buttons
                if(i != Index) Questions[i] = false;

            Questions[Index] = !Questions[Index];

            if(Questions[Index] == false) {
                DefaultQuestion = true;
                DefaultQuestionBtn.Text = resources.GetString("DefaultQuestionBtn.Text");

                WithSomeExceptionsLabel.Size = new Size(130, 17);
                WithSomeExceptionsLabel.Location = new Point(184, 83);
                WithSomeExceptionsLabel.Text = "*(With Some Exceptions)";
                WithSomeExceptionsLabel.Font = new Font("Cambria", 8F, FontStyle.Bold);
                WithSomeExceptionsLabel.Visible = true;
                return;
            }
            else DefaultQuestion = false;

            DefaultQuestionBtn.Text = headers[Index] + resources.GetString($"Question{Index}Btn.Text");
            WithSomeExceptionsLabel.Visible = DefaultQuestion;

            if(Questions[1])
            {
                WithSomeExceptionsLabel.Size = new Size(108, 15);
                WithSomeExceptionsLabel.Location = new Point(12, 80);
                WithSomeExceptionsLabel.Text = "Homebrew Store";
                WithSomeExceptionsLabel.Font = new Font("Cambria", 9.5F, FontStyle.Bold | FontStyle.Underline);
                WithSomeExceptionsLabel.Visible = true;
            }
        }
        #endregion

        

        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]

        private void Question0Btn_Click(object sender, EventArgs e) => LoadQuestions(0);
        private void Question1Btn_Click(object sender, EventArgs e) => LoadQuestions(1);
        private void Question2Btn_Click(object sender, EventArgs e) => LoadQuestions(2);
        private void Question3Btn_Click(object sender, EventArgs e) => LoadQuestions(3);

        private void WithSomeExceptionsLabel_Click(object sender, EventArgs e)
        {
            if (DefaultQuestion)
            {
                MessageBox.Show("Some Misc. Patches Will Be Applied To Uncharted 4/Lost Legacy Multiplayer Eboots To Make The Game Playable");
            }
            else if (MessageBox.Show("Do You Want To Open Your Browser To The Homebrew Store/Itemzflow Download Page?", "Open Itemzflow Download Page On pkg-zone?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Process.Start("https://pkg-zone.com/details/ITEM00001");
            }
        }
        private void WithSomeExceptionsLabelMH(object sender, EventArgs e) => WithSomeExceptionsLabel.ForeColor = Color.Aqua;
        private void WithSomeExceptionsLabelML(object sender, EventArgs e) => WithSomeExceptionsLabel.ForeColor = Color.White;
        #endregion
    }
}
