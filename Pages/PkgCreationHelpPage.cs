using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Dobby.Common;


namespace Dobby {
    public partial class PkgCreationHelpPage : Form
    {
        /// <summary>
        /// Initialize a new instance of the PkgCreationHelpPage Form.
        /// </summary>
        public PkgCreationHelpPage()
        {
            InitializeComponent();
            
            InitializeAdditionalEventHandlers(this);

            Question0Btn.Text = "- Button Text Here";
            Question1Btn.Text = "- Button Text Here";
            Question2Btn.Text = "- Button Text Here";
            Question3Btn.Text = "- Button Text Here";
        }

        

        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]

        private static readonly string[] Headers = new []
        {
            "\t\t\t\t[Page Title]\n",
            "\t\t\t\t[Page Title]\n",
            "\t\t\t\t[Page Title]\n",
            "\t\t\t\t[Page Title]\n"
        };

        private static bool[] Questions = new bool[4];
        private static bool DefaultQuestionIsActive = true;
        #endregion





        //=============================================\\
        //--|   Background Function Delcarations   |---\\
        //=============================================\\
        #region [Background Function Delcarations]

        private void LoadQuestions(int questionIndex) {

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PkgCreationHelpPage));

            for(int i = 0; i < Questions.Length;) // Reset The Other Buttons
            {
                Questions[i] = i ++ == questionIndex;
            }

            Questions[questionIndex] = !Questions[questionIndex];

            if(Questions[questionIndex] == false)
            {
                DefaultQuestionIsActive = true;
                DefaultQuestionBtn.Text = resources.GetString("DefaultQuestionBtn.Text");
                return;
            }
            else
                DefaultQuestionIsActive = false;


            DefaultQuestionBtn.Text = Headers[questionIndex] + resources.GetString($"Question{questionIndex}Btn.Text");
            PopupLabel.Visible = DefaultQuestionIsActive;
        }
        #endregion
        


        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]

        private void Question1Btn_Click(object sender, EventArgs e) => LoadQuestions(0);
        private void Question2Btn_Click(object sender, EventArgs e) => LoadQuestions(1);
        private void Question3Btn_Click(object sender, EventArgs e) => LoadQuestions(2);
        private void Question4Btn_Click(object sender, EventArgs e) => LoadQuestions(3);


        private void PopupLabel_Click(object sender, EventArgs e) { }
        private void PopupLabelMH(object sender, EventArgs e) => PopupLabel.ForeColor = Color.Aqua;
        private void PopupLabelML(object sender, EventArgs e) => PopupLabel.ForeColor = Color.White;
        #endregion
    }
}
