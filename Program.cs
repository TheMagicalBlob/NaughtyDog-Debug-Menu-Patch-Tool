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


            // A dummy form to always keep alive as a host for the rest of them, while also copying the looks of the main page becau- okay this is dumb
            var baseApp = new MainPageDummy();
            baseApp.Visible = false;

            Application.Run(baseApp);
        }
    }
}
