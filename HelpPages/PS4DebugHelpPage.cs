using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dobby.Common;
using System.Drawing;

namespace Dobby {
    public partial class PS4DebugHelpPage : Form
    {
        /// <summary>
        /// Initialize a new instance of the PS4DebugHelpPage Form.
        /// </summary>
        public PS4DebugHelpPage()
        {
            InitializeComponent();
            InitializeAdditionalEventHandlers(this);
        }
    }
}
