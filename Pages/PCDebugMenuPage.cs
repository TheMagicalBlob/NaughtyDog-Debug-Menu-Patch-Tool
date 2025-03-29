using System;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Threading;
using static Dobby.Common;

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

        public static bool IsActiveFilePCExe, MainStreamIsOpen;

        private static string ActiveFilePath;

        private int GuessedDebug;


        /// <summary> Byte Array Used To Find The Address To Enable The Debug Mode In T1X PC. </summary>
        private readonly byte[]
            DebugDat = new byte[] { 0x8a, 0x8f, 0xf2, 0x3e, 0x00, 0x00, 0x84, 0xc9, 0x0f, 0x94, 0xc2, 0x84, 0xc9, 0x0f, 0x95, 0xc1, 0x88, 0x8f, 0x3d, 0x3f, 0x00, 0x00, 0x88, 0x97, 0x2f, 0x3f, 0x00, 0x00 } // Used To Find Debug Mode Addr In PC Executables, From What I Remember
        ;

        private byte[] LocalExecutableCheck;

        
        /// <summary>
        /// The FileStream used for checking and patching the provided executable (well, ideally an executable. I'm not their boss).
        /// </summary>
        private FileStream fileStream;

        private Thread DebugScanThread;
        #endregion



        
        //=============================================\\
        //--|   Background Function Delcarations   |---\\
        //=============================================\\
        #region [Background Function Delcarations]

        private void BrowseButton_Click(object sender, EventArgs e) {
            using(var fileDialogue = new OpenFileDialog {
                Filter = "Executable|*.exe",
                Title = "Select Either Of The Game's Executables"
            })

            if(fileDialogue.ShowDialog() == DialogResult.OK) {
                LocalExecutableCheck = new byte[8];
                ActiveFilePath = ExecutablePathBox.Text = fileDialogue.FileName;

                using(var fileStream = new FileStream(fileDialogue.FileName, FileMode.Open, FileAccess.Read)) {

                    MainStreamIsOpen = true;

                    fileStream.Position = 0x1EC;
                    fileStream.Read(LocalExecutableCheck, 0, 4);
                    Game = (GameID) BitConverter.ToInt32(LocalExecutableCheck, 0);
                
                    fileStream.Position = 0x1F8;
                    fileStream.Read(LocalExecutableCheck, 0, 4);
                    Game += BitConverter.ToInt32(LocalExecutableCheck, 0);

                    ActiveGameID = GameInfoLabel.Text = UpdateGameInfoLabel();
                }
            }
        }



        /// <summary> Load A File For Checking/Patching If The Path In The ExecutablePathBox Exists </summary>
        private void ExecutablePathBox_TextChanged(object sender, EventArgs e) {

            var TextBox = ((Control)sender).Text.Replace("\"", "");
            if(!File.Exists(TextBox))
                return;

            ActiveFilePath = TextBox;
            fileStream = new FileStream(ActiveFilePath, FileMode.Open, FileAccess.ReadWrite);
            MainStreamIsOpen = true;
            
            var LocalExecutableCheck = new byte[8];
            fileStream.Position = 0x1EC; fileStream.Read(LocalExecutableCheck, 0, 4);
            Game = (GameID) BitConverter.ToInt32(LocalExecutableCheck, 0);
            fileStream.Position = 0x1F8; fileStream.Read(LocalExecutableCheck, 0, 4);
            Game += BitConverter.ToInt32(LocalExecutableCheck, 0);

            GameInfoLabel.Text = UpdateGameInfoLabel();
        }



        private void ScanForDebugJumpAddress() { 
            var TmpAddr = 0;
            LocalExecutableCheck = new byte[28];

Read:       fileStream.Position = TmpAddr++;
            fileStream.Read(LocalExecutableCheck, 0, 28);
            if (LocalExecutableCheck.SequenceEqual(DebugDat))
                goto Read;

            GuessedDebug = (int)fileStream.Position - 5;
            fileStream.Position = GuessedDebug;
            fileStream.WriteByte(0x8F);
            
            MessageBox.Show($"0x8F Written At {GuessedDebug:X}", "That Should Work");
        }

        public string UpdateGameInfoLabel()
        {
            var VersionString = $"Unknown Version {BitConverter.ToString(LocalExecutableCheck):X}";
            int debugAddr = 0xDEADDAD;

            bool CompareBytes(int Address, byte[] Bytes) {
                var BytesRead = new byte[Bytes.Length];

                fileStream.Position = Address;
                fileStream.Read(BytesRead, 0, Bytes.Length);

                return BytesRead.SequenceEqual(Bytes);
            }


            switch (Game) {
                case GameID.T1X101:
                    VersionString = "Original Release";
                    debugAddr = 0x3B66B6;
                    break;
                case GameID.T1XL101:
                    VersionString = "Original Release Non-AVX";
                    debugAddr = 0x3B64A2;
                    break;
                case GameID.T1X1015:
                    VersionString = "1.01.5 Release";
                    debugAddr = 0x3B68E6;
                    break;
                case GameID.T1XL1015:
                    VersionString = "1.01.5 Release Non-AVX";
                    debugAddr = 0x3B66D2;
                    break;
                case GameID.T1X1016:
                    VersionString = "1.01.6 Release";
                    debugAddr = 0x3B68F6;
                    break;
                case GameID.T1XL1016:
                    VersionString = "1.01.6 Release Non-AVX";
                    debugAddr = 0x3B66D2;
                    break;
                case GameID.T1X1017:
                    VersionString = "1.01.7 Release";
                    debugAddr = 0x3B6A17;
                    break;
                case GameID.T1XL1017:
                    VersionString = "1.01.7 Release Non-AVX";
                    debugAddr = 0x3B67F3;
                    break;
                case GameID.T1X102:
                    VersionString = "1.02 Release";
                    debugAddr = 0x3B6A92;
                    break;
                case GameID.T1XL102:
                    VersionString = "1.02 Release Non-AVX";
                    debugAddr = 0x3B686E;
                    break;

                default:
                    var response = MessageBox.Show("Couldn't Determine The Version You Selected, So The Debug Offset Can't Be Guessed.\nScan Exe For Dev Menu Offset Instead?\n\n(If nothing's found after ~5 minutes, it probably never will.)", "This Might Take A Couple Minutes", MessageBoxButtons.YesNo);

                    if(response == DialogResult.No)
                    {

                    }
                        
                    DebugScanThread = new Thread(ScanForDebugJumpAddress);
                    DebugScanThread.Start();

                    break;
            }

            
            if (!CompareBytes(debugAddr, DebugDat))
                VersionString += " | Debug Enabled";

            return VersionString;
        }

        private void DisableDebugBtn_Click(object sender, EventArgs e) => ToggleDebug(0x97);
        
        private void BaseDebugBtn_Click(object sender, EventArgs e) => ToggleDebug(0x8F);


        private void ToggleDebug(byte @byte)
        {
            
            if (Game == GameID.Empty) {
                UpdateLabel("Please Select A Game's Executable First", true);
                return;
            }

            var DebugAddr = DebugJumpAddress.Empty;

            switch (Game) {
                case GameID.T1X101:
                    DebugAddr = DebugJumpAddress.T1X101Debug;
                    break;
                case GameID.T1XL101:
                    DebugAddr = DebugJumpAddress.T1XL101Debug;
                    break;
                case GameID.T1X1015:
                    DebugAddr = DebugJumpAddress.T1X1015Debug;
                    break;
                case GameID.T1XL1015:
                    DebugAddr = DebugJumpAddress.T1XL1015Debug;
                    break;
                case GameID.T1X1016:
                    DebugAddr = DebugJumpAddress.T1X1016Debug;
                    break;
                case GameID.T1XL1016:
                    DebugAddr = DebugJumpAddress.T1XL1016Debug;
                    break;
                case GameID.T1X1017:
                    DebugAddr = DebugJumpAddress.T1X1017Debug;
                    break;
                case GameID.T1XL1017:
                    DebugAddr = DebugJumpAddress.T1XL1017Debug;
                    break;
                case GameID.T1X102:
                    DebugAddr = DebugJumpAddress.T1X102Debug;
                    break;
                case GameID.T1XL102:
                    DebugAddr = DebugJumpAddress.T1XL102Debug;
                    break;
            }


            if (DebugAddr == DebugJumpAddress.Empty)
            {
                UpdateLabel("Error ");
                Print("");
                return;
            }


            fileStream.Position = (int)DebugAddr;
            fileStream.WriteByte(@byte);
            fileStream.Flush();
        }
        #endregion
    }
}
