using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using static Dobby.Common;

namespace Dobby
{
    public partial class PS4MenuSettingsHelpPage : Form
    {
        public PS4MenuSettingsHelpPage()
        {
            InitializeComponent();
            InitializeAdditionalEventHandlers(this);
        }
    }
}
