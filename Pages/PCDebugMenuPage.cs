﻿using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static Dobby.Common;
using System.Text;
using System.Linq;
using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;

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
        /// Path to the provided executable that's been scanned and found to likely have the debug menu
        /// </summary>
        private string ActiveFilePath = string.Empty; // Override the one in Common.cs, since there's no need for cross-page functionality for pc executables
        
        
        /// <summary>
        /// Byte Array Used To Find The Address To Enable The Debug Mode In T1X PC. (why tf is this one so long?)
        /// </summary>
        private readonly byte[] T1XDebugDat0 = new byte[] { 0xf3, 0x3e, 0x00, 0x00, 0x84, 0xc9, 0x0f, 0x94, 0xc2 }; // off
        private readonly byte[] T1XDebugDat1 = new byte[] { 0xf3, 0x3e, 0x00, 0x00, 0x84, 0xc9, 0x0f, 0x95, 0xc2 }; // on
        
        /// <summary>
        /// Byte Array Used To Find The Address To Enable The Debug Mode In T2R PC.
        /// </summary>
        private readonly byte[] T2RDebugDat0 = new byte[] { 0x13, 0x3f, 0x00, 0x00, 0x84, 0xc9, 0x0f, 0x94, 0xc2 }; // off
        private readonly byte[] T2RDebugDat1 = new byte[] { 0x13, 0x3f, 0x00, 0x00, 0x84, 0xc9, 0x0f, 0x95, 0xc2 }; // on
        


        private DebugJumpAddress JumpAddress = DebugJumpAddress.Empty;



        private Thread DebugScanThread;

        private delegate void GameInfoLabelUpdater(object message);
        private readonly GameInfoLabelUpdater UpdateGameInfoLabel;
        #endregion



        
        //=============================================\\
        //--|   Background Function Delcarations   |---\\
        //=============================================\\
        #region [Background Function Delcarations]

        private void UpdateGILabel(object str) => Invoke(UpdateGameInfoLabel, str);

        
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
            UpdateGILabel("Scanning executable for build version...");


            // Variable Declarations
            byte[] array;
            int guessedDebug;
            int buildNumberAddress;
            var game = GameID.Empty;
            var gameID = string.Empty;
            var result = string.Empty;
            var filePath = FilePath.ToString().ToLower();
            JumpAddress = DebugJumpAddress.Empty;
            game = GameID.Empty;



            // Load executable in to an array for faster reading
            array = File.ReadAllBytes(filePath);


            // Check for a build number
            buildNumberAddress = FindSubArray(array, Encoding.UTF8.GetBytes("BUILD_NUMBER="));
                
            if (buildNumberAddress != -1)
            {
                while (array[++buildNumberAddress] != (byte)0x00)
                {
                    gameID += (char)array[buildNumberAddress];
                }
                if (gameID == string.Empty)
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

            // check for patterns with both disabled and enabled debug patches (I don't want to make the pattern it's scanning for TOO small by simply removing the final two bytes)
            if ((guessedDebug = FindSubArray(array, T1XDebugDat0)) != -1 || (guessedDebug = FindSubArray(array, T1XDebugDat1)) != -1)
            {
                JumpAddress = (DebugJumpAddress) guessedDebug - 1;

            }
            else if ((guessedDebug = FindSubArray(array, T2RDebugDat0)) != -1 || (guessedDebug = FindSubArray(array, T2RDebugDat1)) != -1)
            {
                JumpAddress = (DebugJumpAddress) guessedDebug - 1;
                
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

                UpdateLabel("Patch address scanning failed.", true);
                UpdateGILabel("Unable to find instruction to patch. (sorry!)");
            }
        }


        /// <summary>
        /// Apply the provided debug patch byte to the current JumpAddress
        /// </summary>
        /// <param name="patch">true: enable<br/>false: disable</param>
        private void ApplyPatch(byte patch)
        {
            if (JumpAddress == DebugJumpAddress.Empty)
            {
                UpdateLabel("Please Select A Game's Executable First", true);
                return;
            }
            if (JumpAddress < 0)
            {
                Dev.Print($"ERROR: JumpAddress was negative. (fix your trash)");

                UpdateGILabel("Unable to Apply Debug Patch. (address > .exe length)");
                UpdateLabel("ERROR: Invalid Jump Address (please make a bug report!)", true);
            }
            if (!File.Exists(ActiveFilePath))
            {
                Dev.Print($"ERROR: The provided executable no longer exists.\n - Expected Path: [{ActiveFilePath ?? "null"}]");

                UpdateLabel("ERROR: Executable no longer exists.", true);
                return;
            }



            // Backup the file just in case we're both idiots.
            for (int? extention = null; File.Exists($"{ActiveFilePath}.bak{extention}"); ++extention)

            File.Copy(ActiveFilePath, $"{ActiveFilePath}.bak{extention}");



            // Re-open the executable and apply the selected debug patch.
            using (fileStream = File.OpenWrite(ActiveFilePath))
            {
                fileStream.Position = (int) JumpAddress;
                fileStream.WriteByte(patch);
                fileStream.Flush();

                #if DEBUG
                Dev.Print($"Wrote PC Menu Patch {patch:X} to {JumpAddress:X}.");
                #endif
            }


            UpdateGILabel("Debug Patch Applied");
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

        
        private void DisableDebugBtn_Click(object sender, EventArgs e) => ApplyPatch(0x94);
        
        private void BaseDebugBtn_Click(object sender, EventArgs e) => ApplyPatch(0x95);
        #endregion
    }
}
