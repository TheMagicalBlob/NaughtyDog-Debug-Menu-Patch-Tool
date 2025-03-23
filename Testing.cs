using System;
using System.Drawing;
using System.Windows.Forms;
#if DEBUG
using System.IO;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using static Dobby.Common;
#endif


namespace Dobby {

    /// <summary>
    /// Lazy/Messy class for general debugging/testing-related stuff.
    /// </summary>
    public class Testing {
        //=======================================\\
        //--  Debug/Testing Class Declaration  --\\
        //=======================================\\
        
#if DEBUG
        /// <summary>
        /// Create the Dobby.Dev instance which will be running for the Program's whole runtime.
        /// </summary>
        /// <param name="Gaia"> Main form refference to set initial ActivePage value. (otherwise set during page change) </param>
        public Testing(Form Gaia)
        {
            Common.Dev = this;

            TestGamedataFolder = @"C:\Users\msblob\Misc\gp4_tst\CUSA00009-app";
            TestPubToolPath = @"C:\Users\msblob\App\FPackageTools3.87\orbis-pub-cmd.exe";
            TestEbootPath = @"C:\Users\blob\Misc\dobby tst\CUSA07820-app\eboot.bin";
            TestGP4Path = @"C:\Users\msblob\Misc\gp4_tst\CUSA00009-app.gp4";

            OverrideDynamicOutput = false;
        }
#endif

        



        
        //=======================================\\
        //--|   Debug Variable Declarations   |--\\
        //=======================================\\
        #region [Debug Variable Declarations]

#if DEBUG
        public static bool OverrideDynamicOutput;

        public static string TestGamedataFolder;
        public static string TestPubToolPath;
        public static string TestEbootPath;
        public static string TestGP4Path;


        internal int ClickErrors = 0;
        internal int ClickEventCheck = 0;



        public delegate void Rendering(Control control);

        public static Rendering RenderPause = new Rendering(PauseRendering);
        public static Rendering RenderResume = new Rendering(ResumeRendering);
#endif
        #endregion



        
        //========================================\\
        //--|   Debug Function Delcarations   |---\\
        //========================================\\
        #region [Debug Function Delcarations]

        /// <summary>
        /// Toggle a few different things to try and get a feel for which is prefferable
        /// </summary>
        public static void AddStyleTestButton(System.Windows.Forms.Form form)
        {
            // StyleTestBtn
            Button styleTestButton; 

            form.Controls.Add(styleTestButton = new Button()
            {
                Name = "StyleTestBtn",
                Size = new Size(120, 24),
                Location = new Point(272, 1),
                Text = "Toggle Style Test",
                Font = new Font("Verdana", 8F),
                BackColor = Color.FromArgb(100, 100, 100),
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                ForeColor = SystemColors.Control,
                Cursor = Cursors.Cross
            });
            styleTestButton.Click += (sender, args) => {
                foreach (var item in ((Control)sender).Parent.Controls)
                {
                    if (item.GetType() == typeof(TextBox) && !((TextBox)item).ReadOnly)
                    {
                        var control = (TextBox) item;
                        control.TextAlign ^= HorizontalAlignment.Center;
                    }
                }

                Common.StyleTest ^= true;
            };
            styleTestButton.FlatAppearance.BorderSize = 0;
            styleTestButton.BringToFront();
        }


        
        /// <summary>
        /// Default message output function. Prints to the debug window if present, as well as the standard output
        /// </summary>
        /// <param name="obj"> An object to print the string representation of. </param>
        public static void Print(object obj)
        {
            var str = obj?.ToString() ?? " ";

            void write(string _str) {
                System.Diagnostics.Debug.Write(_str);

                if (!Console.IsInputRedirected) {
                    Console.Write(_str);
                }
            }

            // Some formatting stuff
            if(str.Length < 1)
            {
                str = " ";
            }
            else {
                str = obj.ToString();

                if(!str.Contains("\r"))
                    str += "\n";
            }


            write(str);
        }



        /* [unused & incomplete test function]
        public static RichTextBox CreateTextBox(Form ActiveForm, string Title) {
            PopupGroupBox?.Dispose();

            PopupGroupBox = new GroupBox() {
                Cursor = Cursors.Cross,
                Size = new Size(250, ActiveForm.Size.Height - 65),
                Location = new Point(35, ActiveForm.Controls.Find("SeperatorLine0", true)[0].Location.Y + 8),
                BackColor = Color.FromArgb(255, Color.FromArgb(100, 100, 100))
            };

            var popupBoxLabel = new Label() {
                Text = Title,
                Font = new Font("Microsoft YaHei UI", 7.5F),
                Size = new Size(217, 21),
                Location = new Point(4, 8),
                ForeColor = SystemColors.Control,
                BackColor = Color.FromArgb(100, 100, 100)
            };
            var closeBtn = new Button() {
                Text = "X",
                Cursor = Cursors.Cross,
                Size = new Size(19, 19),
                BackColor = Color.FromArgb(100, 100, 100),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(228, 9),
                ForeColor = SystemColors.Control,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Cambria", 6.5F)

            };
            var textBox = new RichTextBox() {
                ReadOnly = true,
                Cursor = Cursors.Cross,
                Size = new Size(242, PopupGroupBox.Size.Height - 35),
                Location = new Point(4, 29),
                BackColor = Color.FromArgb(255, Color.DarkGray)
            };

            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.MouseClick += KillTextBox;
            PopupGroupBox.Controls.Add(textBox);
            PopupGroupBox.Controls.Add(closeBtn);
            PopupGroupBox.Controls.Add(popupBoxLabel);
            ActiveForm.Controls.Add(PopupGroupBox);

            PopupGroupBox.BringToFront(); textBox.BringToFront();
            closeBtn.BringToFront(); popupBoxLabel.BringToFront();

            return textBox;
        }
        private static void KillTextBox(object sender, MouseEventArgs e) => Common.PopupGroupBox?.Dispose();
        */



        #if DEBUG

        private static void PauseRendering(Control control) => UpdateRendering((IntPtr)0, control);
        private static void ResumeRendering(Control control) => UpdateRendering((IntPtr)1, control);
        private static void UpdateRendering(IntPtr toggle, Control control) {
            var Window = NativeWindow.FromHandle(control.Handle);
            var Msg = Message.Create(control.Handle, 11, toggle, IntPtr.Zero);

            Window.DefWndProc(ref Msg);

            if(toggle != IntPtr.Zero)
                control.Update();
        }



        public Control[] GetControlsInOrder(Form Parent) {
            var Cunts = new List<Control>();
            
            int X, Y = 0;
            do {
                X = 0;
                do
                    foreach(Control Item in Parent.Controls)
                        if(Item.Location.Y == Y & Item.Location.X == X)
                            Cunts.Add(Item);

                while(X++ < Parent.Size.Width);
            }
            while(Y++ < Parent.Size.Height);
            return Cunts.ToArray();
        }


        /// <summary>
        /// Calculates A Size Exactly Large Enough (Hopefully)
        /// To Fit The Item's Text Content
        /// </summary>
        /// <returns> A new size for the little cunt. </returns>
        internal Size TryAutosize(Control cunt) {
            var size = cunt.CreateGraphics().MeasureString(cunt.Text, cunt.Font);
            return new Size((int)size.Width + 15, (int)size.Height + 10);
        }


        #endif
        #endregion

    }
}