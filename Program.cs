using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Dobby.Common;

namespace Dobby {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[MTAThread]
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);


            var baseApp = new MainPageDummy();
            baseApp.Visible = false;
            Application.Run(baseApp);
        }
    }
}
