using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static Dobby.Common;
using System.Text;

namespace Dobby {
    internal partial class PCDebugMenuPage : Form {
        
        /// <summary>
        /// Initialize a new instance of the PCDebugMenuPage Form.
        /// </summary>
        public PCDebugMenuPage()
        {
            InitializeComponent();
            InitializeAdditionalEventHandlers(Controls);

            UpdateGameInfoLabel = (str) =>
            {
                GameInfoLabel.Text = str?.ToString();
            };
        }
        
        

        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]

        /// <summary>
        /// Byte Array Used To Find The Address To Enable The Debug Mode In T1X PC. (why tf is this one so long?)
        /// </summary>
        private readonly byte[] T1XDebugDat = new byte[] { 0x8a, 0x8f, 0xf2, 0x3e, 0x00, 0x00, 0x84, 0xc9, 0x0f, 0x94, 0xc2, 0x84, 0xc9, 0x0f, 0x95, 0xc1, 0x88, 0x8f, 0x3d, 0x3f, 0x00, 0x00, 0x88, 0x97, 0x2f, 0x3f, 0x00, 0x00 };
        
        /// <summary>
        /// 0: 0ff <br/> 1: On
        /// </summary>
        private readonly byte[] T1xJumpDat = new byte[] { 0x97, 0x8f };

        /// <summary>
        /// Byte Array Used To Find The Address To Enable The Debug Mode In T2R PC.
        /// </summary>
        private readonly byte[] T2RDebugDat = new byte[] { 0x13, 0x3f, 0x00, 0x00, 0x84, 0xc9, 0x0f, 0x94, 0xc2 };
        
        /// <summary>
        /// 0: 0ff <br/> 1: On
        /// </summary>
        private readonly byte[] T2RJumpDat = new byte[] { 0x94, 0x95 };

        private DebugJumpAddress JumpAddress = DebugJumpAddress.Empty;

        private byte[] JumpPatch;

        private Thread DebugScanThread;

        private delegate void GameInfoLabelUpdater(object message);
        private readonly GameInfoLabelUpdater UpdateGameInfoLabel;
        #endregion



        
        //=============================================\\
        //--|   Background Function Delcarations   |---\\
        //=============================================\\
        #region [Background Function Delcarations]

        private void UpdateGILabel(object str) => ActiveForm.Invoke(UpdateGameInfoLabel, str);

        
        private void LoadGameExecutable(string filePath)
        {
            DebugScanThread = new Thread(new ParameterizedThreadStart(ScanForDebugJumpAddress), 4);
            DebugScanThread.Start(filePath);
        }


        /// <summary>
        /// Attempt to find the instruction to be patched through byte pattern scan
        /// </summary>
        private void ScanForDebugJumpAddress(object FilePath)
        {
            // Variable Declarations
            byte[] array;
            int guessedDebug;
            int buildNumberAddress;
            var game = GameID.Empty;
            var gameID = string.Empty;
            var result = string.Empty;
            var filePath = FilePath.ToString().ToLower();


            // Load executable in to an array for faster reading
            UpdateGILabel("Scanning executable for build version...");
            array = File.ReadAllBytes(filePath);


            // Check for a build number
            buildNumberAddress = FindSubArray(array, Encoding.UTF8.GetBytes("BUILD_NUMBER="));
                
            if (buildNumberAddress != -1)
            {
                while (array[buildNumberAddress + 13] != (byte)0x00)
                {
                    gameID += (char)array[(buildNumberAddress++) + 13];
                }
                if (ActiveGameID == string.Empty)
                {
                    gameID = "Unknown Build";
                }

                foreach (var @char in gameID) {
                    game += (@char);
                }
                
                
                result = $"Build: {gameID}";
            }

            
            // Determine the game and executable type, assuming the name hasn't been changed for whatever reason
            if (filePath.Contains("tlou-ii"))
            {
                result = "Tlou Part II " + result;
            }
            else if (filePath.Contains("tlou-i"))
            {
                result = "Tlou Part I " + result;
            }
            if (filePath.Contains("i-l"))
            {
                result += " (non-avx)";
            }



            // Attempt to find the instructions responsible for setting the debug mode
            UpdateGILabel("Scanning executable for patch address...");

            if ((guessedDebug = FindSubArray(File.ReadAllBytes(FilePath?.ToString() ?? "Empty File Path"), T1XDebugDat)) != -1)
            {
                JumpPatch = new byte[] { 0x97, 0x8f };
                JumpAddress = (DebugJumpAddress) guessedDebug - 5;

                UpdateGILabel($"T1x PC Patch Address Found, Choose a Patch");
            }
            else if ((guessedDebug = FindSubArray(File.ReadAllBytes(FilePath?.ToString() ?? "Empty File Path"), T2RDebugDat)) != -1)
            {
                JumpPatch = new byte[] { 0x94, 0x95 };
                JumpAddress = (DebugJumpAddress) guessedDebug - 1;
                
                UpdateGILabel($"T2R PC Patch Address Found, Choose a Patch");
            }




            // Set related instance variables or bitch & moan depending on whether the instructions were found
            if (guessedDebug != -1)
            {
                Game = game;
                ActiveGameID = gameID;
                ActiveFilePath = FilePath?.ToString() ?? "Empty File Path";
                
                UpdateGILabel(result + " | Choose a Patch");
            }
            else {
                ActiveFilePath = string.Empty;

                UpdateGILabel("Patch address scanning failed");
                UpdateLabel("Unable to find instruction to patch. (sorry!)", true);
            }
        }


        /// <summary>
        /// Enable or disable the debug mode depending on the patch selected.
        /// </summary>
        /// <param name="patch">true: enable<br/>false: disable</param>
        private void ToggleDebug(byte patch)
        {
            if (JumpAddress == DebugJumpAddress.Empty) {
                UpdateLabel("Please Select A Game's Executable First", true);
                return;
            }

            using (fileStream = File.OpenWrite(ActiveFilePath))
            {
                fileStream.Position = (int) JumpAddress;
                fileStream.WriteByte(patch);
                fileStream.Flush();
            }


            UpdateLabel("Debug Patch Applied");
        }

        #endregion


        

        
        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using(var fileDialogue = new OpenFileDialog {
                Filter = "Executable|*.exe",
                Title = "Select Either Of The Game's Executables"
            })
                
            if(fileDialogue.ShowDialog() == DialogResult.OK)
            {
                ExecutablePathBox.Set(fileDialogue.FileName);
            }
        }



        /// <summary> Load A File For Checking/Patching If The Path In The ExecutablePathBox Exists </summary>
        private void ExecutablePathBox_TextChanged(object sender, EventArgs e)
        {
            if (!((TextBox)sender).IsDefault() && File.Exists(((TextBox)sender).Text))
            {
                LoadGameExecutable(((TextBox)sender).Text);
            }
        }

        
        private void DisableDebugBtn_Click(object sender, EventArgs e) => ToggleDebug(JumpPatch[0]);
        
        private void BaseDebugBtn_Click(object sender, EventArgs e) => ToggleDebug(JumpPatch[1]);
        #endregion
    }
}
