using System;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Threading;
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

        public bool IsActiveFilePCExe, MainStreamIsOpen;

        private string ActiveFilePath;

        private string BuildNumber;
        private string Timestamp;

        /// <summary> Byte Array Used To Find The Address To Enable The Debug Mode In T1X PC. </summary>
        private readonly byte[]
            T1XDebugDat = new byte[] { 0x8a, 0x8f, 0xf2, 0x3e, 0x00, 0x00, 0x84, 0xc9, 0x0f, 0x94, 0xc2, 0x84, 0xc9, 0x0f, 0x95, 0xc1, 0x88, 0x8f, 0x3d, 0x3f, 0x00, 0x00, 0x88, 0x97, 0x2f, 0x3f, 0x00, 0x00 } // Used To Find Debug Mode Addr In PC Executables, From What I Remember
        ;

        private Thread DebugScanThread;
        #endregion



        
        //=============================================\\
        //--|   Background Function Delcarations   |---\\
        //=============================================\\
        #region [Background Function Delcarations]
        
        private void LoadGameExecutable(string filePath)
        {
            var executableCheckBuffer = new byte[8];
            ActiveFilePath = filePath;

            var array = File.ReadAllBytes(filePath);
            var buildNumberAddress = FindSubArray(array, Encoding.UTF8.GetBytes("BUILD_NUMBER="));
                
            if (buildNumberAddress == -1)
            {
                UpdateLabel("Unable to determine game verion");
            }
            else
            {
                int timestampAddress = buildNumberAddress - 16;


                while (array[buildNumberAddress + 13] != (byte)0x00)
                {
                    BuildNumber += (char)array[(buildNumberAddress++) + 13];
                }
                
                while (array[timestampAddress] != (byte)0x00)
                {
                    Timestamp += (char)array[timestampAddress++];
                }
                

                foreach (var @char in BuildNumber) {
                    Game += (@char);
                }
                
                foreach (var @char in BuildNumber) {
                    Game += (@char);
                }

                Dev.Print(Game);

                GameInfoLabel.Text = ActiveGameID = UpdateGameInfoLabel();
            }
        }


        /// <summary>
        /// Attempt to find the instruction to be patched through byte pattern scan
        /// </summary>
        private void ScanForDebugJumpAddress()
        { 
            var tmpAddress = 0;
            var LocalExecutableCheck = new byte[28];

Read:       fileStream.Position = tmpAddress++;
            fileStream.Read(LocalExecutableCheck, 0, 28);
            if (!LocalExecutableCheck.SequenceEqual(T1XDebugDat))
                goto Read;

            var guessedDebug = (int)fileStream.Position - 5;
            fileStream.Position = guessedDebug;
            fileStream.WriteByte(0x8F);
            
            MessageBox.Show($"0x8F Written At {guessedDebug:X}", "That Should Work");
        }

        private string UpdateGameInfoLabel()
        {
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
                        DebugScanThread = new Thread(ScanForDebugJumpAddress);
                        DebugScanThread.Start();
                    }
                    break;
            }

            return versionString;
        }


        private void ToggleDebug(byte @byte)
        {
            if (Game == GameID.Empty) {
                UpdateLabel("Please Select A Game's Executable First", true);
                return;
            }

            var jumpAddress = DebugJumpAddress.Empty;

            switch (Game) {
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
