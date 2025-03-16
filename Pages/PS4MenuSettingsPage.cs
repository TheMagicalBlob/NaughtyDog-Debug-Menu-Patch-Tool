using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using static Dobby.Common;
using System.Linq;



namespace Dobby {
    public partial class PS4MenuSettingsPage : Form {

        /// <summary>
        /// Initialize a new instance of the PS4MenuSettingsPage Form.
        /// </summary>
        public PS4MenuSettingsPage()
        {
            try // this crashed while opening once and I can't reproduce it, so meh (may have been a debug-only issue, anyway)
            {
                InitializeComponent();
                InitializeAdditionalEventHandlers(Controls);
            
                //DisableDebugTextBtn.Variable = UniversalPatchValues[0];
                //DisablePausedIconBtn.Variable = UniversalPatchValues[1];
                //ProgPauseOnOpenBtn.Variable = UniversalPatchValues[2];
                //ProgPauseOnCloseBtn.Variable = UniversalPatchValues[3];
                //NovisBtn.Variable = UniversalPatchValues[4];

                DynamicButtonsState = 0;

                if(Game != 0 && GSButtons?.Buttons != null)
                    ResetCustomDebugOptions();
            
#if DEBUG
                Dev.OverrideMsgOut = true;
#endif
            }
            catch (Exception darn) {
                PrintError(darn);
                Print("\nError initializing PS4MenuSettingsPage, returning to main page.");
                ChangeForm(null);
            }
        }



        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]

        /// <summary> Array of Controls to Move When Loading >1 Game-Specific Debug Options
        ///</summary>
        private static Control[] ControlsToMove;
        private static DynamicPatchButtons GSButtons;


        private static int DynamicButtonsState;
        
        /// <summary>
        /// 0: UC1100<br/>1: UC1102<br/>2: UC2100<br/>3: UC2102<br/>4: UC3100<br/>5: UC3102<br/>6: UC4100<br/>7: UC4101<br/>8: UC4133<br/>9: UC4133MP<br/>10 TLL100<br/>11 TLL10X<br/>12 T1R100<br/>13 T1R109<br/>14 T1R11X<br/>15 T2100<br/>16 T2107<br/>17 T2109<br/>
        /// </summary>
        private readonly int _GameIndex;


        
#if DEBUG
        /// <summary>
        ///      Booleans Used For Universal Patch Values
        ///<br/>
        ///<br/> 0: Disable FPS
        ///<br/> 1: Disable Paused Indicator
        ///<br/> 2: Prog Pause On Open 
        ///<br/> 3: Prog Pause On Close
        ///<br/> 4: novis TODO: //! Add Me!
        /// </summary>
        public static bool[] UniversalPatchValues { get; private set; }
#else
        private static bool[] UniversalPatchValues
#endif
         = new bool[5] { false, true, true, true, false };

        internal readonly bool[] DefaultUniveralPatchValues = new bool[5] { false, true, true, true, false };


        private FileStream fileStream;

        private Button ConfirmPatchesBtn;
        private Button ResetBtn;
        #endregion





        //=============================================\\
        //--|   Background Function Delcarations   |---\\
        //=============================================\\
        #region [Background Function Delcarations]
        
        public static object[] PeekGameSpecificPatchValues() { return DynamicPatchButtons.GSPatchValues; }
        
        private void WriteBytes(int? offset = null, byte[] data = null) {
#if DEBUG
            var msg = $"Data {BitConverter.ToString(data).Replace("-", "")} Written To ";
            if(offset != null)
                fileStream.Position = (int)offset;
            msg += fileStream.Position.ToString("X"); // trust issues

            fileStream.Write(data, 0, data.Length);
            Print(msg);
            Print();
#else
            if (offset != null)
            fileStream.Position = (int)offset;
            fileStream.Write(data, 0, data.Length);
#endif
        }
        private void WriteByte(int? offset = null, byte data = 0) {
#if DEBUG
            var msg = $"Byte {data:X} Written To ";
            if(offset != null)
                fileStream.Position = (int)offset;
            msg += fileStream.Position.ToString("X"); // trust issues

            fileStream.WriteByte(data);
            Print(msg);
#else
            if(offset != null)
            fileStream.Position = (int)offset;
            fileStream.WriteByte(data);
#endif
        }

        private void WriteVar<T>(object data)
        {
            var msg = " Written To ";

            msg += fileStream.Position.ToString("X");

            try {
                if(typeof(T) == typeof(byte))
                {
                    fileStream.WriteByte((byte)data);
                    msg = (byte)data + msg;
                }
                if(typeof(T) == typeof(byte[]))
                {
                    fileStream.Write((byte[])data, 0, ((byte[])data).Length);
                    msg = Encoding.UTF8.GetString((byte[])data) + msg;
                }
                else if(typeof(T) == typeof(bool))
                {
                    fileStream.WriteByte((byte) ((bool)data ? 1 : 0));
                    msg = (bool)data + msg;
                }

                else if(typeof(T) == typeof(float))
                {
                    fileStream.Write(BitConverter.GetBytes((float)data), 0, BitConverter.GetBytes((float)data).Length);
                    msg = (float)data + msg;
                }
            }
            catch (Exception) {
                Print($"Error Writing Var: {data ?? 0xDEADDAD:X} (Type: {typeof(T)})");
            }
        }


        
        private void TestGSButtons(object sender, EventArgs e)
        {
            if (GSButtons == null)
            {
                //gsButtons = new DynamicPatchButtons(new int?[] { 0, 1, 2, 3, 4 }, GameSpecificPatchesLabel.Location.Y + GameSpecificPatchesLabel.Size.Height);
            }
        }



        /// <summary>
        /// Load a decrypted/unsigned executable specified by the provided fileName.<br/><br/>
        /// Determines the current game via an odd hashing process (redo that ffs, why the hell is it 160 bytes??? And why is a sha256 hash being read as a byte array and turned in to a 32 bit integer???)
        /// </summary>
        /// <param name="filePath"> The path to the executable being loaded </param>
        private int LoadGameExecutable(string filePath)
        {
            // Dispose (if in use) and initialize the file stream
            fileStream?.Dispose();
            fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);


            // Read the selected executable to determine the game and patch &amp; update the Info label
            GameInfoLabel.Text = GetCurrentGame(fileStream);
            

            return GetPatchDataGameIndex(Game);
        }

        
        
        
        private string ApplyMenuSettings(int gameIndex)
        {
            var Message = string.Empty;

              try {
                using(fileStream) {
                    if(UniversalPatchValues.Length != UniversalBootSettingsPointers.Length || DynamicPatchButtons.GSPatchValues.Length != GameSpecificBootSettingsPointers.Length)
                    {
                        Print($"Mismatch In Array Value vs pointer Length:\n  Universal:\n  Vars: {UniversalPatchValues.Length}\n  Pointers: {UniversalBootSettingsPointers.Length}\nDynamic:\n  Vars: {DynamicPatchButtons.GSPatchValues.Length}\n  Pointers: {GameSpecificBootSettingsPointers.Length}");
                    }

                    else if(BootSettingsCallAddress[gameIndex] == 0 || BootSettingsFunctionAddress[gameIndex] == 0) {
                        MessageBox.Show($"Game #{gameIndex} Has Is Missing An Address For BootSettings (Function Call: {BootSettingsCallAddress[gameIndex]} / Function Data: {BootSettingsFunctionAddress[gameIndex]})");
                        return "error";
                    }

                    // Write Function Call To Call BootSettings
                    WriteBytes(BootSettingsCallAddress[gameIndex], GetBootSettingsFunctionCall(Game));

                    // Write BootSettings Function's Assembly constructed in GetBootSettingsMethodData(gameIndex)
                    WriteBytes(BootSettingsFunctionAddress[gameIndex], GetBootSettingsMethodData(gameIndex));

                    byte pointerTypeIdentifier = 0x42;
                    byte[] patchData;
                    object patchValue;
                    int patchCount = 2;

                    // Apply Universal Options
                    for(var index = 0; index < UniversalPatchValues.Length; index++)
                    {
                        patchData = UniversalBootSettingsPointers[index][gameIndex];

                        if (UniversalPatchValues[index] == DefaultUniveralPatchValues[index])
                        {
                            Print("Skipping Unchanged Patch Value...");
                            continue;
                        }


                        else if (patchData.Length == 4)
                        {
                            pointerTypeIdentifier = 0xFE;
                        }
                        else if (patchData.Length == 8)
                        {
                            pointerTypeIdentifier = 0xFF;
                        }
                        else
                        {
                            Print($"Default Patch Value Pointer Data {(patchData.Length == 0 ? "Null Somehow." : $"Size Invalid ({patchData.Length})")}");
                            continue;
                        }


                        WriteByte(data: pointerTypeIdentifier);
                        WriteByte(data: 0);
                        WriteBytes(data: patchData);
                        WriteByte(data: (byte)(UniversalPatchValues[index] ? 1 : 0));

                        Print();
                        patchCount++;
                    }


                    // Apply Game-Specific Options
                    for(var i = 0; i < DynamicPatchButtons.GSPatchValues.Length; i++ )
                    {
                        patchValue = DynamicPatchButtons.GSPatchValues[i];
                        patchData = GameSpecificBootSettingsPointers[i][gameIndex]; //! wait, what? this seems like a mistake

                        if (patchValue.Equals(DynamicPatchButtons.DefaultGSPatchValues[i]))
                        {
                            Print("Skipping Unchanged Patch Value...");
                            continue;
                        }

                        else if (patchData.Length == 4)
                        {
                            pointerTypeIdentifier = 0xFE;
                        }
                        else if (patchData.Length == 8)
                        {
                            pointerTypeIdentifier = 0xFF;
                        }
                        else {
                            Print($"ERROR: Invalid Length for Provided Path Value! ({patchData.Length} != 4 | 8)");
                            continue;
                        }


                        // Write the identifier for Pointers vs hard Addresses
                        WriteVar<byte>(pointerTypeIdentifier);

                        // The fuck was this about??
                        WriteVar<byte>((byte)(patchValue.GetType() == typeof(byte) || patchValue.GetType() == typeof(bool) ? 0 : 1));

                        // Write path pointer/address
                        WriteVar<byte[]>(patchData);

                        // Write the patch data itself
                        WriteVar<byte[]>(patchValue);

                        patchCount++;
                        Print();
                    }

                    // padding to avoid issues with overlapping previous larger patches
                    WriteBytes(data: new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x81, 0x08 });

                    Message = $" {patchCount + 1} Patches Applied";
                }
            }
            catch(Exception tabarnack)
            {
                Print($"{tabarnack.GetType()} | Error Applying Patches");
                MessageBox.Show(tabarnack.Message + $"\n{tabarnack.StackTrace}", $"Exception Type {tabarnack.GetType()}");
                return "error";
            }

            return (Message == string.Empty ? null : Message);
        }




        ///<summary>
        ///</summary>
        /// <param name="GameIndex"> Index Of The Selected Game, Excluding Versions I Don't Plan To Suppport </param>
        /// <returns> A byte[] containing the constructed bootsettings function data </returns>
        private static byte[] GetBootSettingsMethodData(int GameIndex) {

            // new byte { (Quick Menu Function Call), (Ptr to Base Addr) }
            var BootSettingsBaseAddressPointers = new byte[][] {
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC1 1.00 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC1 1.02 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC2 1.00 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC2 1.02 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC3 1.00 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC3 1.02 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC4 1.00 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC4 1.01 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC4 1.33 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // UC4 1.33 MP //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // TLL 1.00 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // TLL 1.09 //!
                new byte [] { 0xe8, 0x6b, 0x32, 0x04, 0x00, 0x53, 0x48, 0x8d, 0x05, 0x33, 0x28, 0xfe, 0xff }, // T1R 1.00 //! TEST ME
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // T1R 1.09 //!
                new byte [] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, // T1R 1.11 //!
                new byte [] { 0xe8, 0x8b, 0x9c, 0x3d, 0x00, 0x53, 0x48, 0x8d, 0x05, 0xc3, 0x8c, 0xff, 0xff }, // T2 1.00  //! TEST ME
                new byte [] { 0xe8, 0xcb, 0xd0, 0x3d, 0x00, 0x53, 0x48, 0x8d, 0x05, 0xc3, 0x8c, 0xff, 0xff }, // T2 1.07
                new byte [] { 0xe8, 0x9b, 0x45, 0x82, 0x00, 0x53, 0x48, 0x8d, 0x05, 0x03, 0xea, 0xff, 0xff }  // T2 1.09
            };

            byte[] 
                BootSettingsFunction = new byte[] { 0x48, 0x8d, 0x0d, 0x64, 0x00, 0x00, 0x00, 0x80, 0x3c, 0x21, 0xfe, 0x75, 0x22, 0x8b, 0x54, 0x21, 0x02, 0x01, 0xc2, 0x80, 0x79, 0x01, 0x00, 0x75, 0x0b, 0x8a, 0x59, 0x06, 0x88, 0x1a, 0x48, 0x83, 0xc1, 0x07, 0xeb, 0xe3, 0x8b, 0x59, 0x06, 0x89, 0x1a, 0x48, 0x83, 0xc1, 0x0a, 0xeb, 0xd8, 0x80, 0x39, 0xff, 0x75, 0x35, 0x8b, 0x94, 0x21, 0x02, 0x00, 0x00, 0x00, 0x01, 0xc2, 0x48, 0x8d, 0x14, 0x22, 0x48, 0x8b, 0x12, 0x8b, 0x5c, 0x21, 0x06, 0x48, 0x01, 0xda, 0x80, 0x79, 0x01, 0x00, 0x75, 0x0c, 0x8a, 0x59, 0x0a, 0x40, 0x88, 0x1a, 0x48, 0x83, 0xc1, 0x0b, 0xeb, 0xaa, 0x8b, 0x59, 0x0a, 0x48, 0x89, 0x1a, 0x48, 0x83, 0xc1, 0x0e, 0xeb, 0x9e, 0x5b, 0xc3 },
                BootSettingsData = new byte[BootSettingsFunction.Length + BootSettingsBaseAddressPointers[GameIndex].Length]
            ;


            Buffer.BlockCopy
            (
                BootSettingsBaseAddressPointers[GameIndex], 0,
                BootSettingsData, 0,
                BootSettingsBaseAddressPointers[GameIndex].Length
            );

            Buffer.BlockCopy
            (
                BootSettingsFunction, 0,
                BootSettingsData, BootSettingsBaseAddressPointers[GameIndex].Length,
                BootSettingsFunction.Length
            );

            return BootSettingsData;
        }


        /// <summary>
        /// Get the game index used for the patch data's jagged array.<br/>
        ///  - eg: array[patchIndex][gameIndex]
        /// <br/><br/>
        /// Does Not Include Game Versions I Don't Indend To Support, Just Oldest And Latest<br/>
        /// (Plus A Couple Still Commonly Used In-Between Ones)
        /// </summary>
        private int GetPatchDataGameIndex(GameID game) {
            switch(game) {
                default:
                    return 0xDEADDAD;

                case GameID.UC1100:
                case GameID.UC1102:
                case GameID.UC2100:
                case GameID.UC2102:
                case GameID.UC3100:
                case GameID.UC3102:
                    return 0xBADBEEF;

                case GameID.UC4100:
                    return 6;
                case GameID.UC4101:
                    return 7;
                case GameID.UC4127_133:
                    return 8;
                case GameID.UC4133MP:
                    return 0xBADBEEF;
                case GameID.TLL100:
                    return 10;
                case GameID.TLL10X:
                    return 11;

                case GameID.T1R100:
                    return 11;
                case GameID.T1R109:
                    return 13;
                case GameID.T1R110:
                case GameID.T1R111:
                    return 14;
                case GameID.T2100:
                    return 15;
                case GameID.T2107:
                    return 16;
                case GameID.T2108:
                case GameID.T2109:
                    return 17;
            }
        }



        /// <summary>
        /// Get the data required to call the custom BootSettings function, generally redirecting the Quick Menu function call
        /// </summary>
        /// <returns>
        /// A byte array containing the function call to write at the address provided by 
        /// </returns>
        private static byte[] GetBootSettingsFunctionCall(GameID GameID) {
            switch(GameID) {
                case GameID.UC1100: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case GameID.UC1102: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case GameID.UC2100: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case GameID.UC2102: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case GameID.UC3100: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case GameID.UC3102: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case GameID.T1R100: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case GameID.T1R109: return new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 }; // 

                case GameID.T1R110:
                case GameID.T1R111: return new byte[] { 0xe8, 0xc0, 0x15, 0x01, 0x00 }; // 

                case GameID.T2100: return new byte[] { 0xe8, 0x43, 0x95, 0xe1, 0xff };  // CALL 0x7e0fc0

                case GameID.T2107: return new byte[] { 0xe8, 0xb1, 0x91, 0xe1, 0xff };  // CALL 0x407330

                case GameID.T2108:
                case GameID.T2109: return new byte[] { 0xe8, 0x31, 0x19, 0x9d, 0xff };  // CALL 0x4015f0
                default:
                    return Array.Empty<byte>();
            }
        }


        /// <summary>
        /// Resize Form And Move Buttons, Then Add Enabled Custom Buttons To Form Based On The Current Game And Patch
        /// </summary>
        public void CreateAndAddGameSpecificButtons(int gameIndex)
        {
            // Assign values to variables made to keep track of the default form size/control postions for the reset button. Doing it on page init is annoying 'cause designer memes
            if(OriginalFormScale == Size.Empty) {
                Print("Setting Original Scale Variables");

                // Every Control Below The "Game Specific Patches" Label
                ControlsToMove = new Control[] {
                    SeperatorLine2,
                    BrowseButton,
                    ExecutablePathBox,
                    GameInfoLabel,
                    SeperatorLine3,
                    InfoHelpBtn,
                    CreditsBtn,
                    BackBtn,
                    Info
                };
                OriginalFormScale = Size;
                OriginalControlPositions = new Point[ControlsToMove.Length];


                // Save the original Y-Axis positions of the controls being moved down to fit the custom controls
                for(var i = 0; i < ControlsToMove.Length;)
                    OriginalControlPositions[i] = ControlsToMove[i++].Location;
            }

            CustomDebugOptionsLabel.Visible = false;


            // Initialize DynamicPatchButtons instance and populate the form with the created buttons
            GSButtons = new DynamicPatchButtons(gameIndex, this, (GameSpecificPatchesLabel.Location.Y + 1 + GameSpecificPatchesLabel.Size.Height), (GameInfoLabel.Location.Y + 1 + GameInfoLabel.Size.Height));


            // Attempt to reseize the form to fit the newly added buttons, unless only one has been enabled
            if(GSButtons.Buttons.Count > 1)
            {
                for (int i = GSButtons.Buttons.Count - 1; i >= 0; i--)
                {
                    var button = GSButtons.Buttons[i];
                    if (button == null)
                        continue;

                    // Move Each Control, Then Resize The BorderBox & Form
                    Array.ForEach(ControlsToMove, control =>
                    {
                        control.Location = new Point(control.Location.X, (control.Location.Y + 20));
                        Size = new Size(Size.Width, Size.Height + 20);
                    });
                    break;
                }
            }


            // Finish resizing the PS4MenuSettingPage
            //Size = new Size(Size.Width, Size.Height + 46);

            // Move The Controls Below The Confirm And Reset Buttons A Bit Farther Down To Make Room For Them
            for(int i = 4; i < ControlsToMove.Length; i++)
                ControlsToMove[i].Location = new Point(ControlsToMove[i].Location.X, ControlsToMove[i].Location.Y + 46);

        }



        /// <summary>
        /// 
        /// </summary>
        private void ResetCustomDebugOptions(object _ = null, EventArgs __ = null)
        {
            if (Game == GameID.Empty) {
                Print("ResetCustomDebugOptions(): Game was unset, aborting.");
                return;
            }
            
            Print("Resetting Form And Main Stream");
            

            // Reset Form Size
            if(ActiveForm.Name != "Dobby") //! Lazy Fix 
                ActiveForm.Size = OriginalFormScale;
            OriginalFormScale = Size.Empty;

            // Kill MainStream
            fileStream?.Dispose();

            // Nuke Dynamic Patch Buttons
            GSButtons.ResetButtons();

            // Move Controls Back To Their Original Positions
            for(var i = 0; i < ControlsToMove.Length; ControlsToMove[i].Location = OriginalControlPositions[i++]);



            // Nudge Remaining Controls Back To Their Default Positions
            try
            {
                if (ActiveForm != null)
                {
                    ActiveForm?.Controls.Find("ResetBtn", true)[0]?.Dispose();
                    ActiveForm?.Controls.Find("ConfirmPatchesBtn", true)[0]?.Dispose();
                    CustomDebugOptionsLabel.Visible = true;
                    ExecutablePathBox.Text = " Select A .elf To Patch";
                }
            }
            catch (IndexOutOfRangeException) {
                Print("ERROR: Unable to fully reset control positions!!! (Unable to find one or more controls.)");
            }
            catch (Exception oops) {
                Print("ERROR: Unable to fully reset control positions!!!");
                PrintError(oops);
            }


            ExecutablePathBox.ResetControl();
            Game = GameID.Empty;
            DynamicButtonsState = 0;
        }


        private void ProcessSelectedGame(string filePath)
        {
            if (!File.Exists(filePath))
            {
                // Bitch & moan if the provided file doesn't exist
                UpdateLabel("Invalid Executable Path Provided.", true);
                return;
            }
            if(OriginalFormScale != Size.Empty)
            {
                // Reset form before repeat uses
                ResetCustomDebugOptions();
            }


            
            // Load the provided executable
            var gameIndex = LoadGameExecutable(filePath);

            if (gameIndex == 0xBADBEEF)
            {
                MessageBox.Show("Selected Game Not Currently Supported", $"Patches For {GameInfoLabel.Text} Not Added Yet");
                UpdateLabel("Unsupported Game Selected", true);
                return;
            }
            if (gameIndex == 0xDEADDAD)
            {
                MessageBox.Show("Unknown Game Provided", $"Game unlikely to be Uncharted or Tlou");
                UpdateLabel("Unknown Game Selected", true);
                return;
            }
            #if DEBUG
            Print($"LoadGameExecutable()::gameIndex: {gameIndex}");
            #endif

            // Load the selected executable
            CreateAndAddGameSpecificButtons(gameIndex);
        }

        #endregion




        
        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            #if DEBUG
            if (ExecutablePathBox.IsDefault && Testing.TestEbootPath != null && File.Exists(Testing.TestEbootPath))
            {
                ExecutablePathBox.Set(Testing.TestEbootPath);
            }
            #endif

            if (ExecutablePathBox.IsDefault)
            {
                var fileDialogue = new OpenFileDialog {
                    Filter = "Executable|*.elf;*.bin",
                    Title = "Please select the executable you would like to patch."
                };

                
                if (fileDialogue.ShowDialog() == DialogResult.OK & ((((Control)sender).ForeColor = NDYellow) != Color.Empty))
                {
                    ExecutablePathBox.Set(fileDialogue.FileName);
                }
                else return;
            }
            Print($"control was not default ({ExecutablePathBox.IsDefault}:{ExecutablePathBox.Text})");


            ProcessSelectedGame(ExecutablePathBox.Text);
        }


        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            var result = ApplyMenuSettings(GetPatchDataGameIndex(Game));
            if(result == "error")
            {
                MessageBox.Show($"An Unexpected Error Occured While Applying The Patches, Please Ensure You're Running The Latest Release Build\nIf You Are, Report It To The Moron Typing Out This Error Message", "Internal Error Applying Patch Data");
                Print("ApplyMenuSettings Returned Null");
                return;
            }

            #if !DEBUG
            // Reset the form automatically for debugging purposes
            ResetCustomDebugOptions();
            #endif

            // Append the return status to the game id & version
            GameInfoLabel.Text += result;
        }
        

        private void ExecutablePathBox_TextChanged(object sender, EventArgs e)
        {
            var box = ((TextBox)sender);

            if (!box.IsDefault && box.Text?.Length > 3)
            {
                BrowseButton.Text = "Load...";
            }
            else
                BrowseButton.Text = "Browse...";
        }
        #endregion



        
        //===========================================================\\
        //--|   Quality-of-life / Boot Settings Offset Pointers   |--\\
        //===========================================================\\
        #region [Quality-of-life / Boot Settings Offset Pointers]

        /*|Template
        new byte[][] {
            new byte[] {  }, // 0x | UC1100
            new byte[] {  }, // 0x | UC1102
            new byte[] {  }, // 0x | UC2100
            new byte[] {  }, // 0x | UC2102
            new byte[] {  }, // 0x | UC3100
            new byte[] {  }, // 0x | UC3102
            new byte[] {  }, // 0x | UC4100
            new byte[] {  }, // 0x | UC4101
            new byte[] {  }, // 0x | UC4133
            new byte[] {  }, // 0x | UC4133MP
            new byte[] {  }, // 0x | TLL100
            new byte[] {  }, // 0x | TLL109
            new byte[] {  }, // 0x | T1R100
            new byte[] {  }, // 0x | T1R109
            new byte[] {  }, // 0x | T1R111
            new byte[] {  }, // 0x | T2100
            new byte[] {  }, // 0x | T2107
            new byte[] {  }  // 0x | T2109
        }
        */

        /// <summary>
        /// Byte arrays to be used as pointers with the BootSettings custom function<br/><br/>
        /// 32-Bit Ones Are Pointers To Data In Executable Space.<br/>
        /// Chunky Fucks Are a 32-bit Pointer to A 64-bit Pointer + An Offset to Add.
        /// <br/><br/>
        /// Patch Type Index:<br/>
        ///   0:  Disable FPS<br/>
        ///   1:  Show Paused Indicator<br/>
        ///   2:  ProgPauseOnMenuOpen<br/>
        ///   3:  ProgPauseOnMenuClose<br/>
        ///   4:  novis<br/>
        ///</summary>
        private static readonly byte[][][] UniversalBootSettingsPointers = new byte[][][] {  // fill null bytes just in case of repeat uses with alternate options
                // 4 = 0xfe | 8 = 0xff

            //|Disable FPS
            new byte[][] {
                new byte[] { 0x70, 0x89, 0x99, 0x00 }, // UC1100
                new byte[] { 0xF0, 0xC9, 0x95, 0x00 }, // UC1102
                new byte[] { 0x31, 0x14, 0xE7, 0x00 }, // UC2100
                new byte[] { 0x61, 0xDE, 0x05, 0x01 }, // UC2102
                new byte[] { 0xC9, 0x66, 0x43, 0x01 }, // UC3100
                new byte[] { 0x69, 0xAF, 0x7B, 0x01 }, // UC3102
                new byte[] {  }, // UC4100
                new byte[] {  }, // UC4101
                new byte[] {  }, // UC4133
                new byte[] {  }, // UC4133MP
                new byte[] {  }, // TLL100
                new byte[] {  }, // TLL109
                new byte[] { 0x20, 0xFA, 0x78, 0x01, 0x87, 0x2e, 0x00, 0x00 }, // T1R100
                new byte[] {  }, // T1R109
                new byte[] {  }, // T1R111
                new byte[] { 0x00, 0x19, 0x76, 0x03, 0xb8, 0x3a, 0x00, 0x00 }, // T2100
                new byte[] { 0xB0, 0x75, 0x76, 0x03, 0xb8, 0x3a, 0x00, 0x00 }, // T2107
                new byte[] { 0x30, 0xb4, 0x77, 0x03, 0xb8, 0x3a, 0x00, 0x00 }  // T2109
            },
            
            //|Show Paused Indicator
            new byte[][] {
                new byte[] { 0x8A, 0xF9, 0xA9, 0x00 }, // 0xD98970  | UC1100
                new byte[] { 0x8A, 0x38, 0xA6, 0x00 }, // 0xE6388A  | UC1102
                new byte[] { 0x7A, 0xC7, 0xEB, 0x00 }, // 0x12bc77a | UC2100
                new byte[] { 0xE2, 0x95, 0x05, 0x00 }, // 0x14595e2 | UC2102
                new byte[] { 0x32, 0xFA, 0x42, 0x00 }, // 0x182fa32 | UC3100
                new byte[] { 0x52, 0x4A, 0x7B, 0x00 }, // 0x1bb4a52 | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] { 0x9B, 0x68, 0x24, 0x03 }, // 0x364689B | T2100
                new byte[] { 0xBB, 0x67, 0x24, 0x03 }, // 0x36467bb | T2107
                new byte[] { 0x3B, 0xA6, 0x25, 0x03 }  // 0x365a63b | T2109
            },

            //|ProgPauseOnMenuOpen
            new byte[][] {
                new byte[] { 0x88, 0xF9, 0xA9, 0x00 }, // 0xE9F988  | UC1100 
                new byte[] { 0x88, 0x38, 0xA6, 0x00 }, // 0xE63888  | UC1102
                new byte[] { 0x78, 0xC7, 0xEB, 0x00 }, // 0x12bc778 | UC2100
                new byte[] { 0xE0, 0x95, 0x05, 0x01 }, // 0x14595e0 | UC2102
                new byte[] { 0x30, 0xFA, 0x42, 0x01 }, // 0x182fa30 | UC3100
                new byte[] { 0x50, 0x4A, 0x7B, 0x01 }, // 0x1bb4a50 | UC3102
                new byte[] {  }, // UC4100
                new byte[] {  }, // UC4101
                new byte[] {  }, // UC4133
                new byte[] {  }, // UC4133MP
                new byte[] {  }, // TLL100
                new byte[] {  }, // TLL109
                new byte[] {  }, // T1R100
                new byte[] {  }, // T1R109
                new byte[] {  }, // T1R111
                new byte[] { 0x99, 0x68, 0x24, 0x03 }, // 0x3646899 | T2100
                new byte[] { 0xB9, 0x67, 0x24, 0x03 }, // 0x36467b9 | T2107
                new byte[] { 0x39, 0xA6, 0x25, 0x03 }  // 0x365a639 | T2109
            },

            //|ProgPauseOnMenuClose
            new byte[][] {
                new byte[] { 0x8C, 0xF9, 0xA9, 0x00 }, // 0xE9F98C  | UC1100
                new byte[] { 0x89, 0x38, 0xA6, 0x00 }, // 0xE63889  | UC1102
                new byte[] { 0x79, 0xC7, 0xEB, 0x00 }, // 0x12bc779 | UC2100
                new byte[] { 0xE1, 0x95, 0x05, 0x01 }, // 0x14595e1 | UC2102
                new byte[] {  }, // 0x | UC3100
                new byte[] {  }, // 0x | UC3102 USELESS?
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] { 0x9A, 0x68, 0x24, 0x03 }, // 0x364689a | T2100
                new byte[] { 0xBA, 0x67, 0x24, 0x03 }, // 0x36467ba | T2107
                new byte[] { 0x3a, 0xA6, 0x25, 0x03 }  // 0x365a63a | T2109
            },

            //|novis
            new byte[][] {
                new byte[] { 0x6B, 0xF9, 0x98, 0x00 }, // 0xd8f96b  | UC1100
                new byte[] { 0x9B, 0x59, 0x95, 0x00 }, // 0xD5599B  | UC1102
                new byte[] { 0xFB, 0x61, 0xE6, 0x00 }, // 0x12661fb | UC2100
                new byte[] { 0xCB, 0x0D, 0x05, 0x01 }, // 0x1450dcb | UC2102
                new byte[] { 0x34, 0xFA, 0x42, 0x01 }, // 0x182FA34 | UC3100
                new byte[] { 0x8B, 0x80, 0x6E, 0x01 }, // 0x1ae808b | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] { 0x67, 0x93, 0x89, 0x01 }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] { 0x2C, 0x62, 0x01, 0x03 }, // 0x341622c | T2100
                new byte[] { 0x2C, 0x60, 0x01, 0x03 }, // 0x341602c | T2107
                new byte[] { 0x2C, 0x9E, 0x04, 0x03 }  // 0x3449e2c | T2109
            }
            
            /*
            //|Show Build Info
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] {  }, // 0x | UC3100
                new byte[] {  }, // 0x | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] {  }, // 0x | T2100
                new byte[] { 0xB0, 0x75, 0x76, 0x03, 0xcd, 0x3a, 0x00, 0x00 }, // T2107
                new byte[] { 0x30, 0xb4, 0x77, 0x03, 0xcd, 0x3a, 0x00, 0x00 }  // T2109
            },

            //|Suppress Active task Display
            new byte[][] {
                new byte[] { 0x41, 0x7B, 0x99, 0x00 }, // 0xD97B41  | UC1100
                new byte[] { 0x41, 0x7B, 0x99, 0x00 }, // 0xFA7E41  | UC1102
                new byte[] { 0xC9, 0x05, 0xE7, 0x00 }, // 0x12705C9 | UC2100
                new byte[] { 0xF9, 0xCF, 0x05, 0x01 }, // 0x145cff9 | UC2102
                new byte[] { 0x90, 0x1F, 0xA2, 0x01 }, // 0x1e21f90 | UC3100
                new byte[] { 0x60, 0xEE, 0xB3, 0x01 }, // 0x1f3ee60 | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] {  }, // 0x | T2100
                new byte[] {  }, // T2107
                new byte[] {  }  // T2109
            },
            */
        };

        /// <summary>
        /// Byte arrays to be used as pointers with the BootSettings custom function<br/><br/>
        /// 32-Bit Ones Are Pointers To Data In Executable Space.<br/>
        /// Chunky Fucks Are a 32-bit Pointer to A 64-bit Pointer + An Offset to Add.
        /// 0 to UC1100 - UC4100
        /// <br/><br/>
        /// Patch Type Index:<br/>
        ///   0:  Menu Alpha<br/>
        ///   1:  Menu Scale<br/>
        ///   2:  Main Camera Fov<br/>
        ///   3:  Shadow Menu Text<br/>
        ///   4:  Swap Circle And Square<br/>
        ///   5:  Right Margin<br/>
        ///   6:  Right Align<br/>
        ///</summary>
        private static readonly byte[][][] GameSpecificBootSettingsPointers = new byte[][][] {  // fill null bytes just in case of repeat uses with alternate options
                

            //|Menu Alpha
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] {  }, // 0x | UC3100
                new byte[] {  }, // 0x | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] { 0xA4, 0x68, 0x24, 0x03 }, // 0x36468A4 | T2100
                new byte[] { 0xC4, 0x67, 0x24, 0x03 }, // 0x36467c4 | T2107
                new byte[] { 0x44, 0xA6, 0x25, 0x03 }  // 0x365a644 | T2109
            },

            //|Menu Scale
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] {  }, // 0x | UC3100
                new byte[] {  }, // 0x | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] { 0xA8, 0x68, 0x24, 0x03 }, // 0x36468A8 | T2100
                new byte[] { 0xC8, 0x67, 0x24, 0x03 }, // 0x36467c8 | T2107
                new byte[] { 0x48, 0xA6, 0x25, 0x03 }  // 0x365a648 | T2109
            },
            
            //|Main Camera Fov (camera-fov)
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] {  }, // 0x | UC3100
                new byte[] {  }, // 0x | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] { 0x00, 0x9C, 0x02, 0x03 }, // 0x3429c00 | T2100
                new byte[] { 0x00, 0x9A, 0x02, 0x03 }, // 0x3429a00 | T2107
                new byte[] { 0x00, 0xD8, 0x05, 0x03 }  // 0x345d800 | T2109
            },

            //|Main Camera X-Alignment (camera-distance)
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] {  }, // 0x | UC3100
                new byte[] {  }, // 0x | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] { 0xFC, 0x9B, 0x02, 0x03 }, // 0x3429bfc | T2100
                new byte[] { 0xFC, 0x99, 0x02, 0x03 }, // 0x34299fc | T2107
                new byte[] { 0xFC, 0xD7, 0x05, 0x03 }  // 0x345d7fc | T2109
            },

            //|Shadow Menu Text
            new byte[][] {
                new byte[] { 0x87, 0xF9, 0xA9, 0x00 }, // 0xE9F988  | UC1100 
                new byte[] { 0x87, 0x38, 0xA6, 0x00 }, // 0xE63888  | UC1102
                new byte[] { 0x77, 0xC7, 0xEB, 0x00 }, // 0x12bc778 | UC2100
                new byte[] { 0xDF, 0x95, 0x05, 0x01 }, // 0x14595df | UC2102
                new byte[] { 0x2f, 0xFA, 0x42, 0x01 }, // 0x182fa2f | UC3100
                new byte[] { 0x4f, 0x4A, 0x7B, 0x01 }, // 0x1bb4a4f | UC3102
                new byte[] {  }, // UC4100
                new byte[] {  }, // UC4101
                new byte[] {  }, // UC4133
                new byte[] {  }, // UC4133MP
                new byte[] {  }, // TLL100
                new byte[] {  }, // TLL109
                new byte[] {  }, // T1R100
                new byte[] {  }, // T1R109
                new byte[] {  }, // T1R111
                new byte[] { 0x98, 0x68, 0x24, 0x03 }, // 0x3646898 | T2100
                new byte[] { 0xB8, 0x67, 0x24, 0x03 }, // 0x36467b8 | T2107
                new byte[] { 0x38, 0xA6, 0x25, 0x03 }  // 0x365a638 | T2109
            },
            
            //|Swap Circle & Square
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] {  }, // 0x | UC3100
                new byte[] {  }, // 0x | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] { 0x9D, 0x68, 0x24, 0x03 }, // 0x364689D | T2100
                new byte[] { 0xBD, 0x67, 0x24, 0x03 }, // 0x36467bd | T2107
                new byte[] { 0x3D, 0xA6, 0x25, 0x03 }  // 0x365a63d | T2109
            },

            //|Right Align
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] { 0x34, 0xFA, 0x42, 0x01 }, // 0x182FA34 | UC3100
                new byte[] { 0x54, 0x4A, 0x7B, 0x01 }, // 0x1bb4a54 | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] { 0x9E, 0x68, 0x24, 0x03 }, // 0x364689E | T2100
                new byte[] { 0xBE, 0x67, 0x24, 0x03 }, // 0x36467be | T2107
                new byte[] { 0x3E, 0xA6, 0x25, 0x03 }  // 0x365a63e | T2109
            },
            
            //|Right Margin
            new byte[][] {
                new byte[] {  }, // 0x | UC1100
                new byte[] {  }, // 0x | UC1102
                new byte[] {  }, // 0x | UC2100
                new byte[] {  }, // 0x | UC2102
                new byte[] { 0x38, 0xFA, 0x42, 0x01 }, // 0x182FA38 | UC3100
                new byte[] { 0x58, 0x4A, 0x7B, 0x01 }, // 0x1bb4a58 | UC3102
                new byte[] {  }, // 0x | UC4100
                new byte[] {  }, // 0x | UC4101
                new byte[] {  }, // 0x | UC4133
                new byte[] {  }, // 0x | UC4133MP
                new byte[] {  }, // 0x | TLL100
                new byte[] {  }, // 0x | TLL109
                new byte[] {  }, // 0x | T1R100
                new byte[] {  }, // 0x | T1R109
                new byte[] {  }, // 0x | T1R111
                new byte[] { 0xA0, 0x68, 0x24, 0x03 }, // 0x36468A0 | T2100
                new byte[] { 0xC0, 0x67, 0x24, 0x03 }, // 0x36467c0 | T2107
                new byte[] { 0x40, 0xA6, 0x25, 0x03 }  // 0x365a640 | T2109
            }
        };

        

        /// <summary>
        /// An array of addresses at which to place the function call to the custom BootSettings function, generally redirecting the Quick Menu initialization method
        /// </summary>
        private static readonly int[] BootSettingsCallAddress = new int[] {
                0, // 0x | UC1100
                0, // 0x | UC1102
                0, // 0x | UC2100
                0, // 0x | UC2102
                0, // 0x | UC3100
                0, // 0x | UC3102
                0, // 0x | UC4100
                0, // 0x | UC4101
                0, // 0x | UC4133
                0, // 0x | UC4133MP
                0, // 0x | TLL100
                0, // 0x | TLL109
                0x101FB,  // 0x40c1fb | T1R100
                0, // 0x | T1R109
                0, // 0x | T1R111
                0x1F1DE8, // 0x53dde8 | T2100
                0x1f217a, // 0x5ee17a | T2107
                0x633cba  // 0xa2fcba | T2109
        };

        /// <summary>
        /// An array of addresses at which to place the consructed BootSettings function assembly/data
        /// </summary>
        private static readonly int[] BootSettingsFunctionAddress = new int[] {
            0, // 0x | UC1100
            0, // 0x | UC1102
            0, // 0x | UC2100
            0, // 0x | UC2102
            0, // 0x | UC3100
            0, // 0x | UC3102
            0, // 0x | UC4100
            0, // 0x | UC4101
            0, // 0x | UC4133
            0, // 0x | UC4133MP
            0, // 0x | TLL100
            0, // 0x | TLL109
            0x217C0, // 0x41d7c0 | T1R100
            0, // 0x | T1R109
            0, // 0x | T1R111
            0xB330,  // 0x407330 | T2100
            0xB330,  // 0x407330 | T2107
            0x55f0   // 0x4015f0 | T2109
        };



        #endregion

        /// <summary>
        /// Class For Creating Dynamic Patch Buttons
        /// </summary>
        internal class DynamicPatchButtons
        {
            /// <summary>
            /// Initialize a new instance of the DynamicPatchButtons class, and create the buttons available for the current game &amp; patch version
            /// </summary>
            /// <param name="GameIndex"></param>
            /// <param name="Venat"></param>
            /// <param name="ButtonsVerticalStartOffset"></param>
            /// <param name="ResetButtonVerticalOffset"></param>
            public DynamicPatchButtons(int GameIndex, PS4MenuSettingsPage Venat, int ButtonsVerticalStartOffset, int ResetButtonVerticalOffset)
            {
                
                // Determine which patches have data associated with them
                var IDs = new List<bool>(GameSpecificBootSettingsPointers.Length);
                for (int i = 0; i < GameSpecificBootSettingsPointers.Length;)
                {
                        IDs.Add(GameSpecificBootSettingsPointers[i++][GameIndex].Length > 0);
                }
                
            

                Buttons = new List<Button>(IDs.Count);
                ButtonsVerticalStartPosition = ButtonsVerticalStartOffset;
                for (var patchIndex = 0; patchIndex < IDs.Count; patchIndex++)
                {
                    // Skip disabled buttons
                    if (IDs.Last())
                    {
                        continue;
                    }
                    

                    // Create The Button
                    Buttons[patchIndex] = new Button();
                    Buttons[patchIndex].Name = GSButtonNames[patchIndex];
                    Buttons[patchIndex].TabIndex = patchIndex;
                    Buttons[patchIndex].Variable = GSPatchValues[patchIndex];
                    Buttons[patchIndex].TextAlign = ContentAlignment.MiddleLeft;
                    Buttons[patchIndex].FlatAppearance.BorderSize = 0;
                    Buttons[patchIndex].FlatStyle = FlatStyle.Flat;
                    Buttons[patchIndex].ForeColor = SystemColors.Control;
                    Buttons[patchIndex].BackColor = MainColour;
                    Buttons[patchIndex].Cursor = Cursors.Cross;

                    Buttons[patchIndex].Location = new Point(1, ButtonsVerticalStartPosition);
                    Buttons[patchIndex].Size = new Size(ActiveForm.Width - 2, 23);
                    Buttons[patchIndex].Font = ControlFont;
                    Buttons[patchIndex].Text = GSButtonsText[patchIndex];
                    Buttons[patchIndex].Tag = GSButtonHints[patchIndex];

                    Buttons[patchIndex].MouseDown += MouseDownFunc;
                    Buttons[patchIndex].MouseUp += MouseUpFunc;
                    Buttons[patchIndex].MouseEnter += HoverString;  // For Info Label Text
                    Buttons[patchIndex].MouseEnter += (sender, e) => HoverLeave(((Control)sender), true); 
                    Buttons[patchIndex].MouseLeave += (sender, e) => HoverLeave(((Control)sender), false);
                    Buttons[patchIndex].BringToFront();


                    if (patchIndex == Buttons.Count - 2)
                    {
                        break;
                    }
                        
                    ButtonsVerticalStartPosition += Buttons[patchIndex++].Size.Height;
                }



                // Create the "Confirm Patches" button
                var ConfirmPatchesBtn = new Button
                {
                    Name = "ConfirmPatchesBtn",
                    Size = new Size(Venat.Width - 11, 23),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Cambria", 9.25F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = "Confirm And Apply Patches",
                    ForeColor = SystemColors.Control,
                    BackColor = Color.FromArgb(100, 100, 100),
                    Cursor = Cursors.Cross
                };
                ConfirmPatchesBtn.FlatAppearance.BorderSize = 0;

                Venat.Controls.Add(ConfirmPatchesBtn);
                ConfirmPatchesBtn.Location = new Point(1, ResetButtonVerticalOffset); // Right Below The GameInfoLabel
                ConfirmPatchesBtn.MouseEnter += (sender, e) => HoverLeave(((Control)sender), true);
                ConfirmPatchesBtn.MouseLeave += (sender, e) => HoverLeave(((Control)sender), false);
                ConfirmPatchesBtn.Click += Venat.ConfirmBtn_Click;
                ConfirmPatchesBtn.BringToFront();


                // Create the "Reset Page"
                var ResetBtn = new Button
                {
                    Name = "ResetBtn",
                    Size = new Size(Venat.Width - 11, 23),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Cambria", 9.25F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = "Reset Page",
                    ForeColor = SystemColors.Control,
                    BackColor = Color.FromArgb(100, 100, 100),
                    Cursor = Cursors.Cross
                };
                ResetBtn.FlatAppearance.BorderSize = 0;
            
                Venat.Controls.Add(ResetBtn);
                ResetBtn.Location = new Point(1, ResetButtonVerticalOffset + 24);
                ResetBtn.MouseEnter += (sender, e) => HoverLeave(((Control)sender), true);
                ResetBtn.MouseLeave += (sender, e) => HoverLeave(((Control)sender), false);
                ResetBtn.Click += Venat.ResetCustomDebugOptions;
                ResetBtn.BringToFront();
            }


            
            //=====================================================\\
            //--|   DynamicPatchButton Variable Declarations   |--\\
            //=====================================================\\
            #region [DynamicPatchButton Variable Declarations]

            /// <summary>
            /// 0: Menu Alpha<br/> 1: Menu Scale <br/> 2: Non-ADS FOV <br/> 3: Main Camera X-Alignment <br/> 4: Swap Square And Circle In Debug <br/> 5: Menu Shadowed Text <br/> 6: Align Menus Right <br/> 7: Right Margin <br/>
            /// </summary>
            internal static object[] GSPatchValues { get; private set; } = new object[] {
                0.85f,
                0.60f,
                1f,
                1f,
                false,
                false,
                false,
                (byte)10
            };
            internal static readonly object[] DefaultGSPatchValues = GSPatchValues;


            /// <summary>
            /// Variable Used In Dynamic Button Cration For Game-Specific Patches
            /// </summary>
            private static readonly string[] GSButtonNames = new string[] {
                    "MenuAlphaBtn",
                    "MenuScaleBtn",
                    "FOVBtn",
                    "XAlignBtn",
                    "MenuShadowTextBtn",
                    "SwapCircleInDebugBtn",
                    "MenuRightAlignBtn",
                    "RightMarginBtn"
            };

            private static readonly string[] GSButtonsText = new string[] {
                    "Set DMenu BG Opacity:",             // default=0.85
                    "Set Dev Menu Scale:",               // default=0.60
                    "Adjust Non-ADS FOV:",               // default=1.00
                    "Adjust Camera X-Alignment:",        // default=1.00
                    "Enable Debug Menu Text Shadow:",    // default=No
                    "Swap Circle With Square In DMenu:", // default=No
                    "Align Debug Menus To The Right:",   // default=No
                    "Set Distance From Right Side:"      // default=10
            };

            private static readonly string[] GSButtonHints = new string[] {
                    "Adjusts The Visibilty of The Debug Menu Backgrounds",
                    "Adjusts The Debug Menu Scaling",
                    "Only Effects The Camera While Not Aiming",
                    "Adjust Camera Position On The X-Axis (smaller == left, larger == right)",
                    "Improves Debug Menu Text Readability By Adding A Light Shadow Effect To The Text",
                    " ",
                    "Moves The Dev/Quick Menus To The Right Of The Screen",
                    "Adjust the Menu's Distance From The Right Of The Screen",
            };

            /// <summary> Buttons For Game-Specific Debug Options Loaded Based On The Game Chosen <br/><br/>
            /// 0: MenuAlphaBtn                                                                        <br/>
            /// 1: MenuScaleBtn                                                                        <br/>
            /// 2: FOVBtn                                                                              <br/>
            /// 3: XAlign                                                                              <br/>
            /// 4: MenuShadowTextBtn                                                                   <br/>
            /// 5: SwapCircleInDebugBtn                                                                <br/>
            /// 6: RightAlignBtn                                                                       <br/>
            /// 7: RightMarginBtn
            /// </summary>
            public List<Button> Buttons; // Initialized Once An Executable's Selected


            private int ButtonsVerticalStartPosition;
            #endregion




            //====================================================\\
            //--|   DynamicPatchButton Function Declarations   |--\\
            //====================================================\\
            #region [DynamicPatchButton Function Declarations]


            /// <summary> Remove and dispose of dynamic patch buttons and reset options to default
            ///</summary>
            public void ResetButtons() {
                foreach(Button button in Buttons)
                    button?.Dispose();

                Buttons = null;
                GSPatchValues = DefaultGSPatchValues;
            }

            #endregion




            //=========================================================\\
            //--|   DynamicPatchButton Event Handler Declarations   |--\\
            //=========================================================\\
            #region [DynamicPatchButton Event Handler Declarations]

            private void ToggleFunc(Button Control, int ButtonIndex)
            {
                if(MouseScrolled || !MouseIsDown || CurrentControl != Control.Name)
                    return;

                GSPatchValues[ButtonIndex] = !(bool)GSPatchValues[ButtonIndex];
                Control.Variable = GSPatchValues[ButtonIndex];
                Control.Refresh();
            }


            private void FloatClickFunc(Button Control, int ButtonIndex, MouseButtons Button)
            {
                if(CurrentControl != Control.Name)
                    return;

                var inc = 0.1f;

                if (Button == MouseButtons.Right) inc = -inc;



                GSPatchValues[ButtonIndex] = (float)Math.Round((float)(GSPatchValues[ButtonIndex] = (float)GSPatchValues[ButtonIndex] + inc), 4);

                Control.Variable = GSPatchValues[ButtonIndex];
                Control.Refresh();
            }
            private void FloatScrollFunc(Button Control, int ButtonIndex, int WheelDelta) {
                if(CurrentControl != Control.Name) return;
                var currentFloat = (float)GSPatchValues[ButtonIndex]; // Avoid CS0445

                GSPatchValues[ButtonIndex] = (float)Math.Round(currentFloat += WheelDelta / 12000.0F, 4);
                Control.Variable = GSPatchValues[ButtonIndex];
                Control.Refresh();
            }


            private void IntClickFunc(Button Control, int ButtonIndex, MouseButtons Button) {
                if(CurrentControl != Control.Name) return;
                var currentInt = (byte)GSPatchValues[ButtonIndex]; // Avoid CS0445

                if(Button == MouseButtons.Left) currentInt += 5;
                else currentInt -= 5;

                GSPatchValues[ButtonIndex] = currentInt;
             
                Control.Variable = GSPatchValues[ButtonIndex];
                Control.Refresh();
            }
            private void IntScrollFunc(Button Control, int ButtonIndex, int WheelDelta) {
                if(CurrentControl != Control.Name) return;
                var currentInt = (byte)GSPatchValues[ButtonIndex]; // Avoid CS0445

                currentInt += (byte)(WheelDelta / 120);
                GSPatchValues[ButtonIndex] = currentInt;

                Control.Variable = GSPatchValues[ButtonIndex];
                Control.Refresh();
            }
            #endregion
        }
    }
}