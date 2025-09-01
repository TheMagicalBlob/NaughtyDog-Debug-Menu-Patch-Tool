using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dobby
{
    internal partial class MainPageDummy : System.Windows.Forms.Form
    {
        public MainPageDummy() 
        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            
            this.Paint += (sender, e) =>
            {
                var DummyForm = (Form)sender;

                DummyForm.FormBorderStyle = FormBorderStyle.None;
                DummyForm.Size = new System.Drawing.Size(0, 0);
                DummyForm.Visible = false; 
            };

            
            Common.YoshiP = this;
            new MainPage().Show();

            Common.ActivePage = Common.PageID.MainPage;
        }
    }
}
