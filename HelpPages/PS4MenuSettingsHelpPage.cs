using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using static Dobby.Common;
using System.Linq;
using System.IO;

namespace Dobby {
    public partial class PS4MenuSettingsHelpPage : Form
    {
        //================================\\
        //--|   Class Initialization   |--\\
        //================================\\
        /// <summary>
        /// Initialize a new instance of the PS4MenuSettingsHelpPage Form.
        /// </summary>
        public PS4MenuSettingsHelpPage()
        {
            InitializeComponent();
            InitializeAdditionalEventHandlers(this);


            // Get the question buttons by just checking the names of each button
            var questionButtons = Controls.OfType<Dobby.Button>().Where(button => button.Name.Contains("Question")).ToArray<Dobby.Button>();

            // An array of the answers to be displayed when the corresponding button is clicked
            // (Just write the contents inside the designer's little editor for the Text property, then paste here. Still better than the previous method)
            var Answers = new[]
            {
                "",
                "",
                "",
                "",
            };
            

            // Save the default question for later resetting
            DefaultQuestion = ActiveQuestionBtn.Text;

            QuestionBooleans = new bool[questionButtons.Count()];



            // An array of Actions to be ran when the corresponding question button is activated
            Actions = new[]
            {
                new Action(() =>
                {
                    
                }),
            };

            // The action to be ran when the default question is restored
            DefaultAction = new Action(() =>
            {
            });





            for (var i = 0; i < QuestionBooleans.Length; ++i)
            {
                questionButtons[i].Click += (sender, e) => LoadHelpPageQuestion(this, i);
                
                if (i < Answers.Length)
                {
                    questionButtons[i].Tag = Answers[i];
                }
            }



            if (Actions.Length != QuestionBooleans.Length)
            {
                var message = $"Mismatched sizes for Actions and Questions array! (Actions.Length {(Actions.Length < QuestionBooleans.Length ? '<' : '>')} Questions.Length)";
                #if DEBUG
                    ShowPopup(message, "ERROR INITIALIZING " + nameof(PkgCreationHelpPage).ToUpper() + ';');
                #else
                    throw new InvalidDataException(message);
                #endif
            }
            else
                Dev?.Print(QuestionBooleans.Length);
        }





        
        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]

        /// <summary>
        /// #1 <br/>
        /// #2 <br/>
        /// #3 <br/>
        /// #4 <br/>
        /// </summary>
        public readonly bool[] QuestionBooleans;

        private readonly string DefaultQuestion;

        public bool IsDefaultQuestion = true;

        public readonly Action[] Actions;

        public readonly Action DefaultAction;



        private enum QuestionIDs : byte
        {
        }
        #endregion





        //==================================\\
        //--|   Function Delcarations   |---\\
        //==================================\\
        #region [Function Delcarations]        
        public void ResetActiveAnswerText()
        {
            ActiveQuestionBtn.Text = DefaultQuestion;
        }

        public void SetActiveAnswerText(string answer)
        {
            ActiveQuestionBtn.Text = answer;
        }
        #endregion





        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]
        
        #endregion
    }
}
