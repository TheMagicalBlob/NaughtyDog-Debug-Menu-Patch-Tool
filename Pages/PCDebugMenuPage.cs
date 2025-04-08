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
        /// Byte Array Used To Find The Address To Enable The Debug Mode In T2R PC.
        /// </summary>
        private readonly byte[] T2RDebugDat = new byte[] { 0x13, 0x3f, 0x00, 0x00, 0x84, 0xc9, 0x0f, 0x94, 0xc2 };


        private bool? partII;

        private Thread DebugScanThread;
        #endregion



        
        //=============================================\\
        //--|   Background Function Delcarations   |---\\
        //=============================================\\
        #region [Background Function Delcarations]
        
        private void LoadGameExecutable(string filePath)
        {
            UpdateLabel("Scanning executable for build version...");
            
            
            // Variable Declarations
            byte[] array;
            int buildNumberAddress;
            var result = string.Empty;


            // Load executable in to an array for faster reading
            array = File.ReadAllBytes(filePath);

            // Check for a build number
            buildNumberAddress = FindSubArray(array, Encoding.UTF8.GetBytes("BUILD_NUMBER="));
                
            if (buildNumberAddress != -1)
            {
                while (array[buildNumberAddress + 13] != (byte)0x00)
                {
                    ActiveGameID += (char)array[(buildNumberAddress++) + 13];
                }
                if (ActiveGameID == string.Empty)
                {
                    ActiveGameID = "Unknown Build";
                }

                foreach (var @char in ActiveGameID) {
                    Game += (@char);
                }
                
                
                result = $"Build: {ActiveGameID}";
            }

            

            if (filePath.ToLower().Contains("tlou-ii"))
            {
                partII = true;
                result = "Tlou Part II " + result;
            }
            else if (filePath.ToLower().Contains("tlou-i"))
            {
                partII = false;
                result = "Tlou Part I " + result;
            }
            if (partII != null && filePath.Contains("i-l"))
            {
                result += " (non-avx)";
            }

            GameInfoLabel.Text = result;



            UpdateLabel("Scanning executable for patch address...");

            DebugScanThread = new Thread(new ParameterizedThreadStart(ScanForDebugJumpAddress), 4);
            DebugScanThread.Start(new dynamic[] { array, filePath });
        }


        /// <summary>
        /// Attempt to find the instruction to be patched through byte pattern scan
        /// </summary>
        private void ScanForDebugJumpAddress(dynamic args)
        {
            var guessedDebug = FindSubArray(File.ReadAllBytes(args[1]), T1XDebugDat);

            Dev.Print(string.Join("", T1XDebugDat));

            if (guessedDebug != -1)
            {
                fileStream = File.OpenWrite(args.filePath);
                fileStream.Position = guessedDebug - 5;
                fileStream.WriteByte(0x8F);
                
                UpdateLabel($"T1x PC Debug Menus Enabled");
            }
            else if (guessedDebug = FindSubArray(File.ReadAllBytes(args[1]), T2RDebugDat) != -1)
            {
                fileStream = File.OpenWrite(args.filePath);
                fileStream.Position = guessedDebug - 1;
                fileStream.WriteByte(0x95);
                
                UpdateLabel($"T2R PC Debug Menus Enabled");
            }

            fileStream?.Dispose();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="byte"></param>
        private void ToggleDebug(byte @byte)
        {
            if (Game == GameID.Empty) {
                UpdateLabel("Please Select A Game's Executable First", true);
                return;
            }

            var jumpAddress = DebugJumpAddress.Empty;

            switch (Game)
            {
                // The Last of Us Part I (PC)
                case GameID.T1X101:
                    jumpAddress = DebugJumpAddress.T1X101Debug;
                    break;
                case GameID.T1XL101:
                    jumpAddress = DebugJumpAddress.T1XL101Debug;
                    break;
                case GameID.T1X1015:
                    jumpAddress = DebugJumpAddress.T1X1015Debug;
                    break;
                case GameID.T1XL1015:
                    jumpAddress = DebugJumpAddress.T1XL1015Debug;
                    break;
                case GameID.T1X1016:
                    jumpAddress = DebugJumpAddress.T1X1016Debug;
                    break;
                case GameID.T1XL1016:
                    jumpAddress = DebugJumpAddress.T1XL1016Debug;
                    break;
                case GameID.T1X1017:
                    jumpAddress = DebugJumpAddress.T1X1017Debug;
                    break;
                case GameID.T1XL1017:
                    jumpAddress = DebugJumpAddress.T1XL1017Debug;
                    break;
                case GameID.T1X102:
                    jumpAddress = DebugJumpAddress.T1X102Debug;
                    break;
                case GameID.T1XL102:
                    jumpAddress = DebugJumpAddress.T1XL102Debug;
                    break;

                // The Last of Us Part 2 Remastered (PC)
                case GameID.T2R100:
                    jumpAddress = DebugJumpAddress.T2R100;
                    break;
                case GameID.T2RL100:
                    jumpAddress = DebugJumpAddress.T2RL100;
                    break;
            }


            if (jumpAddress == DebugJumpAddress.Empty)
            {
                UpdateLabel("Error, Unknown Game Provided.");
                return;
            }


            fileStream.Position = (int) jumpAddress;
            fileStream.WriteByte(@byte);
            fileStream.Flush();
        }

        


        /// <summary>
        /// Return a string with which to update the GameInfoLabel, in order to reflect the detected game (or lack of detection).
        /// </summary>
        private string GetGameVersion(string filePath)
        {
            throw new NotSupportedException("Deprecated function mistakenly called, fix your damn code");

            #if DEBUG
            var versionString = $"Unknown Version {Game}";
            
            switch (Game)
            {
                //#
                //## The Last of Us Part I PC
                //#
                case GameID.T1X101:
                    versionString = "Original Release";
                    break;
                case GameID.T1XL101:
                    versionString = "Original Release Non-AVX";
                    break;
                case GameID.T1X1015:
                    versionString = "1.01.5 Release";
                    break;
                case GameID.T1XL1015:
                    versionString = "1.01.5 Release Non-AVX";
                    break;
                case GameID.T1X1016:
                    versionString = "1.01.6 Release";
                    break;
                case GameID.T1XL1016:
                    versionString = "1.01.6 Release Non-AVX";
                    break;
                case GameID.T1X1017:
                    versionString = "1.01.7 Release";
                    break;
                case GameID.T1XL1017:
                    versionString = "1.01.7 Release Non-AVX";
                    break;
                case GameID.T1X102:
                    versionString = "1.02 Release";
                    break;
                case GameID.T1XL102:
                    versionString = "1.02 Release Non-AVX";
                    break;
                    
                //#
                //## The Last of Us Part II PC
                //#
                case GameID.T2R100:
                    versionString = "Original Release";
                    break;
                case GameID.T2RL100:
                    versionString = "Original Release Non-AVX";
                    break;


                // Default case for unknown game versions
                default:
                    if(MessageBox.Show("Couldn't Determine The Version You Selected, So The Debug Offset Can't Be Guessed.\nScan Exe For Dev Menu Offset Instead?\n\n(If nothing's found after ~5 minutes, it probably never will.)", "This Might Take A Couple Minutes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DebugScanThread = new Thread(new ParameterizedThreadStart(ScanForDebugJumpAddress));
                        DebugScanThread.Start(filePath);
                    }
                    break;
            }

            return versionString;
            #endif
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

        
        private void DisableDebugBtn_Click(object sender, EventArgs e) => ToggleDebug(0x97);
        
        private void BaseDebugBtn_Click(object sender, EventArgs e) => ToggleDebug(0x8F);
        #endregion
    }
}
