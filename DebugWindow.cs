# if DEBUG
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static Dobby.Common;
using static Dobby.Testing;

namespace Dobby
{
    /// <summary>
    /// Class for standard debug display / logging;
    /// </summary>
    partial class DebugWindow : Form
    {
        public DebugWindow()
        {
            InitializeComponent();
            InitializeAdditionalEventHandlers(this, true);

            foreach (var control in Controls.OfType<Dobby.Button>())
            {
                control.Click += (sender, args) => Common.Venat.Focus();
            }



            
            DebugWindowPtr = this;
            Venat.LocationChanged += (sender, args) => MoveDebugWindowToAppEdge();


            // LogWindow Event Handlers
            MouseDown  += Common.MouseDownFunc;
            MouseUp    += MouseUpFunc;
            MouseMove  += (sender, args) => Common.MouseMoveFunc(sender as Form);
            
            var fuckIt = Controls.Find(nameof(DebugLogTextBox), true);

            if (fuckIt?.Any() ?? false)
            {
                DebugLogPtr = fuckIt.First() as RichTextBox;
            }
            
            
            
            
            this.PopupTestIndexBtn.Variable = 0;

            /*
            //#
            //## old shit I still may rework and use
            //#
            LogWindowRenderer = CreateGraphics();

            LogFile = File.CreateText($"{Directory.GetCurrentDirectory()}\\out.txt");
            (LogThread = new Thread(new ThreadStart(UpdateConsoleOutput))).Start();
            */
        }

        
        
        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]

        public static Form DebugWindowPtr;

        public static RichTextBox DebugLogPtr;

        
        public static Size FormScale;

        private static Graphics LogWindowRenderer;

        private static StreamWriter LogFile;

        public static string[] LogBuffer;

        public static bool LogShouldRefresh, LogShouldPause;

        public static string[] OutputStrings = new string[35];

        private readonly Thread LogThread;

        private delegate void DebugWindowLogUpdateCallback(string[] Messages);

        private int TempMBBIndex = 0;
        #endregion




        
        
        //=================================\\
        //--|   Function Declarations   |--\\
        //=================================\\
        #region [Function Declarations]

        private DebugWindowLogUpdateCallback UpdateLogWindow = (messages) =>
        {
            DebugLogPtr.Lines = messages;
            DebugLogPtr.Update();
        };


        public void MoveDebugWindowToAppEdge()
        {
            if (DebugWindowPtr == null)
            {
                Dev?.Print($"WARNING: An attempt to call {nameof(MoveDebugWindowToAppEdge)} was made while {nameof(DebugWindowPtr)} was null.");
                return;
            }


            Venat.BringToFront(); //! fuck sake

            DebugWindowPtr.BringToFront();
            DebugWindowPtr.Location = new Point(Venat.Location.X - DebugWindowPtr.Size.Width, Venat.Location.Y);
            DebugWindowPtr.Update();
        }

            
        private void MouseDownFunc(object sender, MouseEventArgs e) => MouseIsDown = true;
        private void MouseUpFunc(object sender, MouseEventArgs e) => MouseScrolled = MouseIsDown = false;






        /// <summary> ugly, uuglyy, UGLY!!! </summary>
        public void LogOut(string str)
        {
            LogFile?.WriteLine(str);
            LogFile?.Flush();

            var OutputStringIndex = OutputStrings.Count(@string => @string != null);
            int ShiftIndex;


            if(OutputStringIndex != OutputStrings.Length - 1)
            {
                for(; OutputStringIndex < OutputStrings.Length - 1; OutputStringIndex++)
                {
                    if(OutputStrings[OutputStringIndex] == null)
                    {
                        OutputStrings[OutputStringIndex] = str;
                        break;
                    }
                }
            }

            else {
                for (ShiftIndex = 0; ShiftIndex < OutputStrings.Length - 1; ShiftIndex++)
                {
                    OutputStrings[ShiftIndex] = OutputStrings[ShiftIndex + 1];
                }

                OutputStrings[ShiftIndex] = str;
            }
  
            Elidibus.Invoke(UpdateLogWindow, new object[] { OutputStrings });
        }
        #endregion




        
        
        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]

        private void NoDrawBtn_Click(object sender, EventArgs e) => NoDraw ^= true;


        private void PopupTestBtn_Click(object sender, EventArgs e)
        {
/*
public enum DialogResult
{
    None,
    OK,
    Cancel,
    Abort,
    Retry,
    Ignore,
    Yes,
    No
}
public enum MessageBoxButtons
{
    OK,
    OKCancel,
    AbortRetryIgnore,
    YesNoCancel,
    YesNo,
    RetryCancel
}*/

            var f = ShowPopup("", "", (MessageBoxButtons) TempMBBIndex);

            if (f == DialogResult.OK)
            {

            }
            else if (f == DialogResult.Cancel)
            {

            }
            else
            {
                Dev?.Print($"None?: {f}");
            }
        }

        private void EditorModeBtn_Click(object sender, EventArgs e)
        {
            Testing.EditorMode = (bool) ((Button)sender).Variable;
        }
        #endregion
    }
}
#endif
