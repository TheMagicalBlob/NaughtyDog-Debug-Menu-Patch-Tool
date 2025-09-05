using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dobby
{
    public static class HelpPageCommon
    {
        /// <summary>
        /// Enable/Disable the HelpPage.Question associated with the selected control, as well as reset the others.<br/>
        /// Also runs a possible function tied to said button.
        /// </summary>
        /// <param name="HelpPage"> The Help Page instance to interact with</param>
        /// <param name="Index"> The index of the question associated with the selected button. </param>
        public static void LoadHelpPageQuestion(dynamic HelpPage, int Index)
        {
            var questions = HelpPage.Questions;

            // Reset The Other Buttons
            for (int i = 0; i < questions.Length; questions[i] = Index == i ? !questions[i] : Index == i, i++);


            // Reset to the default help text if the current question was just disabled
            if(!questions[Index])
            {
                HelpPage.DefaultQuestion = true;
                HelpPage.ActiveQuestionBtn.Text = HelpPage.DefaultButtonText;


            }
            // Enable seelcted question, then do any question-specific stuff if applicable
            else {
                HelpPage.DefaultQuestion = false;
                HelpPage.ActiveQuestionBtn.Text = (HelpPage.Controls.Find($"Question{Index}Btn", true)?[0].Tag ?? $"\"Question{Index}Btn\" Not Found.").ToString();
            }
        }
    }
}
