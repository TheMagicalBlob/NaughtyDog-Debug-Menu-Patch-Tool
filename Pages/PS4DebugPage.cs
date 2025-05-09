﻿using libdebug;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Dobby.Resources;
using static Dobby.Common;



namespace Dobby {
    internal partial class PS4DebugPage : Form {
        
        /// <summary>
        /// Initialize a new instance of the PS4DebugPage Form.
        /// </summary>
        public PS4DebugPage()
        {
            InitializeComponent();
            InitializeAdditionalEventHandlers(Controls);

            var settingsFilePath = Directory.GetCurrentDirectory() + @"\PS4_IP.BLB";

            // Create and set event handlers for the IP and Port text boxes
            IpBox.LostFocus += (control, args) =>
            {
                if (!File.Exists(settingsFilePath))
                    CreateSettingsFile();


                if (IPAddress.TryParse(IpBox.Text, out IP))
                    using (FileStream settingsFile = new FileStream(settingsFilePath, FileMode.Open, FileAccess.ReadWrite))
                    {
                        Dev?.Print($"Saving \"{IP}\" as new IPAddress.");
                        settingsFile.Write(Encoding.UTF8.GetBytes(IP + ";"), 0, IpBox.Text.Length + 1);
                    }

                else
                    UpdateLabel($"Invalid IP specified; save aborted. ({IP})");
            };
            PortBox.LostFocus += (control, args) =>
            {
                if (!File.Exists(settingsFilePath))
                    CreateSettingsFile();
    

                if (short.TryParse(PortBox.Text, out Port)) {
                    using (FileStream settingsFile = new FileStream(settingsFilePath, FileMode.Open, FileAccess.Write))
                    {
                        Dev?.Print($"Saving \"{Port}\" as new Port");
                        settingsFile.Position = 16;
                        settingsFile.Write(BitConverter.GetBytes(Port), 0, 2);
                    }
                }
                else
                    UpdateLabel($"Invalid Port specified; save aborted. ({Port})");
            };



            if (!File.Exists(settingsFilePath))
                CreateSettingsFile();

            var settings = ReadSettingsFile();

            IpBox.Text = (IP = (IPAddress) settings[0]).ToString();
            PortBox.Text = (Port = (short) settings[1]).ToString();

        }



        
        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]

        public PS4DBG Geo;
        
        /// <summary> Thread for connecting a new PS4DBG instance to a client PS4, specified by the IP box. </summary>
        public Thread ConnectionThread;

        /// <summary> Thread for sending the ps4debug payload to a client PS4 "bin loader", specified by the IP and Port boxes. </summary>
        public Thread PayloadThread;

        /// <summary> Active PS4DBG Process ID </summary>
        private int Executable;

        private int DebugModePointerOffset = 0xDEADDAD;

        public readonly string[] ExecutableNames = new string[] {
            "eboot.bin",
            "t2.elf",
            "t2-rtm.elf",
            "t2-final.elf",
            "t2-final-pgo-lto.elf",
            "big2-ps4_Shipping.elf",
            "big3-ps4_Shipping.elf",
            "big4.elf",
            "big4-final.elf",
            "big4-mp.elf",
            "big4-final-pgo-lto.elf",
            "eboot-mp.elf"
        };

        private readonly string[] T1RIDs = new string[]
        {
            "CUSA00552",
            "CUSA00554",
            "CUSA00556",
            "CUSA00557",
            "CUSA00559"
        };

        
        private readonly string[] T2IDs = new string[]
        {
            "CUSA10249",
            "CUSA14006",
            "CUSA07820",
            "CUSA13986"
        };
        
        
        private readonly string[] UCCIDs = new string[]
        {
            "CUSA01399",
            "CUSA02320",
            "CUSA02343",
            "CUSA02344",
            "CUSA02826"
        };
        
        private readonly string[] UC4IDs = new string[]
        {
            "CUSA00341",
            "CUSA08342",
            "CUSA00912",
            "CUSA00917",
            "CUSA00918",
            "CUSA04529"
        };

        private readonly string[] UC4BetaIDs = new string[]
        {
            "CUSA04030",
            "CUSA04032",
            "CUSA04034",
            "CUSA04051"
        };
        
        private readonly string[] TLLIDs = new string[]
        {
            "CUSA07737",
            "CUSA07875",
            "CUSA09564",
            "CUSA08347",
            "CUSA08352"
        };


        public string ProcessName;
        public string GameVersion;
        public string TitleID;

        public short Port;
        public IPAddress IP;

        #endregion




        
        //=============================================\\
        //--|   Background Function Delcarations   |---\\
        //=============================================\\
        #region [Background Function Delcarations]
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultTitleID"></param>
        /// <param name="validIDs"></param>
        /// <returns> True if the button pressed is valid for the connected game. </returns>
        private bool CheckGameIsValid(string defaultTitleID, string[] validIDs)
        {
            if ((bool)IgnoreTitleIDBtn.Variable)
            {
                TitleID = defaultTitleID;
            }

            if (GameVersion.Contains("Unknown"))
            {
                UpdateLabel($"Unknown Game Version Connected.");
                return false;
            }
            
            if (!validIDs.Contains(TitleID))
            {
                UpdateLabel($"Invalid TitleID for Selected Game ({TitleID}).");
                return false;
            }

            return true;
        }


        private void SendPayload(dynamic args)
        {
            using(var payloadSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                // Load Passed Parameters
                var port = (int)args.Port;
                var ip   = (IPAddress)args.IP;
                var form = (Form)args.ActiveForm;


                UpdateLabel("Sending ps4debug Payload...");
                Dev?.Print($"^- Payload Destination: {ip}:{port}.");

                try {
                    payloadSocket.Connect(new IPEndPoint(ip, port));
                    payloadSocket.Send(Resource.ps4debug);
                }
                catch(Exception e) {
                    Dev?.Print($"Failed To Connect To Specified Server at [{ip}:{port}]\nError: {e.Message}\n{e.StackTrace}");
                    UpdateLabel("Failed To Connect To Specified Address/Port");
                }
                finally {
                    payloadSocket.Close();
                }


                if(payloadSocket.Connected)
                {
                    UpdateLabel("Payload Injected Successfully");
                    MessageBox.Show("PS4Debug Update 1.1.15 By ctn123\nPS4Debug Created By Golden", "Payload Injected Successfully, Here's Some Credits"); // Excessive Credits To Try Avoiding Beef lol
                }
            }
        }

        

        /// <summary>
        /// An ugly sack of gross which determines the patch version of a specified game by checking the Int16 value of 2 bytes at a game-specific address because I have no idea how or if I can check the .sfo
        /// </summary>
        /// <returns> The Current Game Version If Successful, Or UnknownGameVersion \ UnknownTitleID If It Failed At Some Stage </returns>
        private string GetGameTitleIDVersionAndDMenuOffset(string titleID) {
            try {
                //if(Geo.IsConnected && Geo.GetProcessInfo(Executable).name == ProcessName) {
                if(true) {
                    // Read A Spot In Memory To Determine Which Patch the Executable's From
                    switch(TitleID) {
                        case "CUSA00552":
                        case "CUSA00554":
                        case "CUSA00556":
                        case "CUSA00557":
                        case "CUSA00559":
                            var T1RCheck = BitConverter.ToInt16(Geo.ReadMemory(Executable, 0x4000F4, 2), 0);
                            DebugModePointerOffset = 0x2E81;
                            switch(T1RCheck) {
                                case 18432: return "1.00";
                                case 1288:  return "1.08";
                                case 3480:  return "1.09";
                                case 4488:  return "1.10";
                                case 4472:  return "1.11";

                                default:
                                    Dev?.Print($"Error, Game Was T1R But None of The Checks Matched! || {T1RCheck}");
                                    MessageBox.Show($"The Game Was Determined To Be The Last of Us: Remastered, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{T1RCheck} {TitleID}", "Error Finding App Version");
                                    return "UnknownT1RGameVersion";
                            }
                        case "CUSA10249":
                        case "CUSA14006":
                        case "CUSA07820":
                        case "CUSA13986":
                            var T2Check = BitConverter.ToInt32(Geo.ReadMemory(Executable, 0x40009A, 4), 0);
                            DebugModePointerOffset = 0x3aa1;
                            switch(T2Check) {
                                case 25384434: return "1.00";
                                case 25548706: return "1.01";
                                case 25502882: return "1.02";
                                case 25588450: return "1.05";
                                case 25593522: return "1.07";
                                case 30024882: return "1.08";
                                case 30024914: return "1.09";

                                default:
                                    Dev?.Print($"Error, Game Was T2 But None of The Checks Matched! || chk:{T2Check}");
                                    MessageBox.Show($"The Game Was Determined To Be The Last of Us Part II, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{T2Check} {TitleID}", "Error Finding App Version");
                                    DebugModePointerOffset = 0xDEADDAD;
                                    return "UnknownT2GameVersion";
                            }
                        case "CUSA01399":
                        case "CUSA02320":
                        case "CUSA02343":
                        case "CUSA02344":
                        case "CUSA02826":
                            var UCCCheck = BitConverter.ToInt32(SHA256.Create().ComputeHash(Geo.ReadMemory(Executable, 0x400000, 100)), 0);
                            switch(UCCCheck) {
                                case 455457367:   return "U2 1.00";
                                case -1951784656: return "U3 1.00";
                                case -1805287883: return "U2 1.02";
                                case 750078581:   return "U3 1.02";
                                case -136556654:  return "U1 1.00";
                                case -1120900838: return "U1 1.02";

                                default:
                                    Dev?.Print($"Error, Game Was UCC But None of The Checks Matched! || chk:{UCCCheck}");
                                    MessageBox.Show($"The Game Was Determined To Be The Uncharted Collection, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{UCCCheck} {TitleID}", "Error Finding App Version");
                                    return "UnknownUCCGameVersion";
                            }
                        case "CUSA00341":
                        case "CUSA08342":
                        case "CUSA00912":
                        case "CUSA00917":
                        case "CUSA00918":
                        case "CUSA04529":
                            var U4Check = BitConverter.ToInt32(SHA256.Create().ComputeHash(Geo.ReadMemory(Executable, 0x400000, 450)), 0);
                            switch(U4Check) {
                                case -164231569:  DebugModePointerOffset = 0x2E95; return "1.00 SP";
                                case 561124052:   DebugModePointerOffset = 0x2E95; return "1.01 SP";
                                case 1001438826:  DebugModePointerOffset = 0x2E95; return "1.02 SP";
                                case -240761314:  DebugModePointerOffset = 0x2E95; return "1.03 SP";
                                case 642668739:   DebugModePointerOffset = 0x2E95; return "1.04 SP";
                                case 1863246975:  DebugModePointerOffset = 0x2E95; return "1.05 SP";
                                case -34645433:   DebugModePointerOffset = 0x2E95; return "1.06 SP";
                                case -1502336242: DebugModePointerOffset = 0x2E95; return "1.08 SP";
                                case -315414364:  DebugModePointerOffset = 0x2E95; return "1.10 SP";
                                case 593054491:   DebugModePointerOffset = 0x2E95; return "1.11 SP";
                                case 949549480:   DebugModePointerOffset = 0x2E95; return "1.12 SP";
                                case -1656215082: DebugModePointerOffset = 0x2E95; return "1.13 SP";
                                case 200885124:   DebugModePointerOffset = 0x2E95; return "1.15 SP";
                                case -593963332:  DebugModePointerOffset = 0x2E95; return "1.16 SP";
                                case 791591403:   DebugModePointerOffset = 0x2E95; return "1.17 SP";
                                case 1243873737:  DebugModePointerOffset = 0x2E79; return "1.18";
                                case -627230760:  DebugModePointerOffset = 0x2E79; return "1.19";
                                case 1270660743:  DebugModePointerOffset = 0x2E79; return "1.20 MP";
                                case -2117982988: DebugModePointerOffset = 0x2E79; return "1.20 SP";
                                case 719837740:   DebugModePointerOffset = 0x2E79; return "1.21 MP";
                                case 722113371:   DebugModePointerOffset = 0x2E79; return "1.21 SP";
                                case 211448500:   DebugModePointerOffset = 0x2E79; return "1.22 MP";
                                case -437432800:  DebugModePointerOffset = 0x2E79; return "1.22/23 SP";
                                case 1317147345:  DebugModePointerOffset = 0x2E79; return "1.23 MP";
                                case 1514442958:  DebugModePointerOffset = 0x2E79; return "1.24 MP";
                                case 407306374:   DebugModePointerOffset = 0x2E79; return "1.24/25 SP";
                                case 590571900:   DebugModePointerOffset = 0x2E79; return "1.25 MP";
                                case 190499529:   DebugModePointerOffset = 0x2E79; return "1.27/28 MP";
                                case -66801341:   DebugModePointerOffset = 0x2E79; return "1.27+ SP";
                                case -1852061601: DebugModePointerOffset = 0x2E79; return "1.29 MP";
                                case 898227952:   DebugModePointerOffset = 0x2E79; return "1.30 MP";
                                case 1025301972:  DebugModePointerOffset = 0x2E79; return "1.31 MP";
                                case -71032229:   DebugModePointerOffset = 0x2E79; return "1.32 MP";
                                case 145928122:   DebugModePointerOffset = 0x2E79; return "1.33 MP";

                                default:
                                    Dev?.Print($"Error, Game Was UC4, But None of The Checks Matched! || chk:{U4Check}");
                                    MessageBox.Show($"The Game Was Determined To Be UC4, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{U4Check} {TitleID}", "Error Finding App Version");
                                    return "UnknownUC4GameVersion";
                            }
                        case "CUSA04030":
                        case "CUSA04032":
                        case "CUSA04034":
                        case "CUSA04051":
                            var U4MPBetaCheck = BitConverter.ToInt32(Geo.ReadMemory(Executable, 0x403000, 4), 0);
                            switch(U4MPBetaCheck) {
                                case 759883849:  DebugModePointerOffset = 0x2E83; return "1.00 MP Beta";
                                case 2067458121: DebugModePointerOffset = 0x2E83; return "1.09 MP Beta";

                                default:
                                    Dev?.Print($"Error, Game Was UC4 MP Beta, But None of The Checks Matched! || chk:{U4MPBetaCheck}");
                                    MessageBox.Show($"The Game Was Determined To Be The UC4 MP Beta (Nice), But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{U4MPBetaCheck} {TitleID}", "Error Finding App Version");
                                    return "UnknownUC4GameVersion";
                            }
                        
                        case "CUSA07737":
                        case "CUSA07875":
                        case "CUSA09564":
                        case "CUSA08347":
                        case "CUSA08352":
                            var TLLCheck = BitConverter.ToInt16(Geo.ReadMemory(Executable, 0x40003B, 2), 0);
                            switch(TLLCheck) {
                                case 3777:   DebugModePointerOffset = 0x2EF9; return "1.00 SP";
                                case -9759:  DebugModePointerOffset = 0x2EF9; return "1.0X SP";  // 1.08 and 1.09 have identical eboot.bin's
                                case -23679: DebugModePointerOffset = 0x2E79; return "1.00 MP";
                                case 27793:  DebugModePointerOffset = 0x2E79; return "1.08 MP";
                                case 27841:  DebugModePointerOffset = 0x2E79; return "1.09 MP";

                                default:
                                    Dev?.Print($"Error, Game Was UCC But None of The Checks Matched! || chk:{TLLCheck}");
                                    MessageBox.Show($"The Game Was Determined To Be The The Lost Legacy, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{TLLCheck} {TitleID}", "Error Finding App Version");
                                    return "UnknownTLLGameVersion";
                            }

                        default: Dev?.Print($"!!! PS4DebugPage -> GetGameVersion() Fell Through. (GameVersion: {GameVersion})"); return "UnknownGameVersion";
                    }
                }
            }
            catch(Exception Tabarnack)
            {
                Dev?.Print($"{Tabarnack.Message};{Tabarnack.StackTrace}");
                return "UnknownGameVersion";
            }
        }
        
        

        /// <summary>
        /// Attempt to connect to a new PS4DBG instance with the current IP address
        /// </summary>
        /// <param name="IP">A dynamic[] containing the form and IP. </param>
        private void ConnectionFunction(object IP)
        {
            try {
                // Load Passed Parameters
                var ip = (IPAddress)IP;
                Executable = 0;

                UpdateLabel($"Connecting to Console at \"{ip}\"");

                // Establish a connection for the new PS4Debug instance
                try {
                    Geo = new PS4DBG(ip);
                    Geo.Connect();
                }
                catch (SocketException oops)
                {
                    UpdateLabel($"Error Connecting to \"{ip}\"");
                    Dev?.PrintError(oops);
                    return;
                }


                Dev?.Print($"Connection Status: {Geo.IsConnected}");
                UpdateLabel("PS4Debug Connected, Searching for Game...");


                foreach(libdebug.Process process in Geo.GetProcessList().processes) { // processprocessprocessprocessprocessprocessprocess
                    
                    // Ignore unrelated processes
                    if(!ExecutableNames.Contains(process.name))
                        continue;
                    


                    string titleId;
                    int exectuable = process.pid;
                    
                    // Check To Avoid Connecting To HB Store Stuff
                    if((titleId = Geo.GetProcessInfo(exectuable).titleid) == "FLTZ00003" || titleId == "ITEM00003")
                    {
                        #if DEBUG
                        Dev?.Print($"Skipping Lightning's Stuff {titleId}");
                        #endif
                        continue;
                    }

                    Executable = exectuable;
                    TitleID = titleId;
                    ProcessName = process.name;
                    Dev?.Print($"Process Name: [{ProcessName}]");


                    // Detect the currently loaded game and app_ver (clunkily.)
                    GameVersion = GetGameTitleIDVersionAndDMenuOffset(titleId);

                    UpdateLabel($"Attached to {titleId} ({GameVersion})");
                    return;
                }

                // Error out if no eboot.bin (or other expected executable) was found.
                ProcessName = "No Valid Process";
                UpdateLabel("Couldn't Find a Valid Game Process.");
            }
            catch(Exception tabarnack) {
                UpdateLabel($"Connection to {IP} Failed.");
                Dev?.Print(tabarnack);
            }
        }


        /// <summary>
        /// Start a new instance of the connection thread, killing any currently active one (//! this is a weird way to do this.)
        /// </summary>
        private void InitializeConnectionThread()
        {
            UpdateLabel("Connecting to Console");

            if (ConnectionThread?.ThreadState == 0)
                ConnectionThread.Abort();

            (ConnectionThread = new Thread(ConnectionFunction)).Start(IP);
        }


        /// <summary>
        /// Avoid Attempting To Toggle The Selected Bool In Memory Before The Connection Process Is Finished
        /// </summary>
        private void CheckConnectionStatus()
        {
            try {
                if((ConnectionThread == null || ConnectionThread.ThreadState == ThreadState.Unstarted) || (Geo == null || !Geo.IsConnected || Geo?.GetProcessInfo(Executable).name != ProcessName || !ExecutableNames.Contains(Geo?.GetProcessInfo(Executable).name)))
                {
                    GameVersion = null;
                    Dev?.Print("Task.Run(CheckConnectionStatus) Initializing connection thread");
                    InitializeConnectionThread();

                    while(GameVersion == null) Thread.Sleep(1);
                }
            }
            catch (Exception calice) {
                Dev?.Print($"Error checking connection status:\n{calice.Message}");
            }
        }




        /// <summary>
        /// Create a new settings file for use in saving the selected Address and Port used for ps4debug operations.
        /// <br/>
        /// <br/> Name: PS4_IP.BLB
        /// <br/> Default data: 192.168.137.115;9090
        /// <br/> Destination: Current program working directory.
        /// </summary>
        private void CreateSettingsFile()
        {
            var settingsFilePath = Directory.GetCurrentDirectory() + @"\PS4_IP.BLB";

            Dev?.Print($"No settings file was found in current folder, creating new one...\n{settingsFilePath}");
            UpdateLabel("Created new settings file.");

            using (var newSettingsFile = new FileStream(settingsFilePath, FileMode.Create, FileAccess.Write))
            {
                newSettingsFile.Write(Encoding.UTF8.GetBytes("192.168.137.115;"), 0, 16);
                newSettingsFile.Write(BitConverter.GetBytes((short)9090), 0, 2);
                newSettingsFile.Flush(true);

                newSettingsFile.Dispose();
            }
        }



        /// <summary>
        ///   Read the saved IP address from the PS4_IP.BLB file in the app directory, or create a new one if it's not present
        /// </summary>
        /// <returns>
        ///   A string array containing the current ip and port if the file's present, otherwise the default value of "192.168.137.115". \m/
        /// </returns>
        private object[] ReadSettingsFile()
        {
            var settingsFilePath = Directory.GetCurrentDirectory() + @"\PS4_IP.BLB";
            
            // Read port & ip from settings file in app directory
            if (File.Exists(settingsFilePath))
                using (var settingsFile = new FileStream(settingsFilePath, FileMode.Open, FileAccess.Read))
                {
                    int seperator;
                    byte[] buffer;

                    settingsFile.Read(buffer = new byte[settingsFile.Length], 0, (int) settingsFile.Length);
                    seperator = buffer.ToList().FindLastIndex(item => item == 0x3B);


                    if (!IPAddress.TryParse(Encoding.UTF8.GetString(buffer, 0, seperator), out IPAddress ip))
                    {
                        Dev?.Print($"!! ERROR: Unable to part IP Address from settings file. (attempted to parse: {Encoding.UTF8.GetString(buffer, 0, seperator)})");
                        UpdateLabel("Unable to parse settings file.");

                        // use the default IP.
                        ip = IPAddress.Parse(IpBox.Text = "192.168.137.115");
                    }

                    settingsFile.Dispose();
                    return new object[] { ip, BitConverter.ToInt16(buffer, seperator + 1) };
                }
            else
            {
                Dev?.Print("!! ERROR: An attempt to read the settings file was made, but the file doesn't exist.");
                return new object[0];
            }
        }



        /// <summary>
        /// Toggles the byte at an address specified by 
        /// </summary>
        /// <param name="Addresses">Array Of Addresses To Read The Int64 From Depending On The Version</param>
        /// <param name="Versions">Version Strings To Check Against GameVersion</param>
        private void Toggle(ulong[] Addresses, string[] Versions) {
            try {
                if(Geo.IsConnected && Geo.GetProcessInfo(Executable).name == ProcessName) //! pretty sure this check is unnecessary, if it isn't then that's an issue on it's own
                {
                    for (int i = 0; i < Versions.Length; i++)
                    {
                        if (GameVersion == Versions[i])
                        {
                            var pointer = (ulong)(BitConverter.ToInt64(Geo.ReadMemory(Executable, Addresses[i], 8), 0) + DebugModePointerOffset);

                            Geo.WriteMemory(Executable, pointer, !Geo.ReadMemory<bool>(Executable, pointer));

                            UpdateLabel($"{(Geo.ReadMemory<bool>(Executable, pointer) ? "Enabled" : "Disabled")} Debug Mode.");
                            return;
                        }
                    }

                    UpdateLabel($"Version {GameVersion} not found.");
                }
                else {
                    Dev?.Print(
                        $"Error Toggling Byte.\nPS4Debug {(Geo.IsConnected ? "" : "Not ")}Connected\n"
                        + $"{Geo.GetProcessInfo(Executable).name} {(Geo.GetProcessInfo(Executable).name == ProcessName ? "=" : "!")}= {ProcessName}"
                    );

                    UpdateLabel("Unable to toggle byte (Possible connection issues)");
                }
            }
            catch(Exception tabarnack)
            {
                Dev?.PrintError(tabarnack);
            }
        }



        /// <summary>
        /// Toggles A Byte At Multiple Fixed Addresses (Only used for Uncharted: The Nathan Drake Collection)
        /// </summary>
        /// <param name="AddressArray">Array Of Addresses To Read/Write To</param>
        private void Toggle(ulong[] AddressArray) {
            try {
                if (Geo.IsConnected && Geo.GetProcessInfo(Executable).name == ProcessName)
                {
                    Array.ForEach(AddressArray, Address => Geo.WriteMemory(Executable, Address, !Geo.ReadMemory<bool>(Executable, Address)));

                    UpdateLabel($"Patches Applied");
                }

            }
            catch(Exception tabarnack) { Dev?.Print(tabarnack.Message); }
        }

        #endregion


        
        //======================================\\
        //--|   Event Handler Declarations   |--\\
        //======================================\\
        #region [Event Handler Declarations]

        private void IPLabelBtn_Click(object sender, EventArgs e) => IpBox.Focus();
        private void PortLabelBtn_Click(object sender, EventArgs e) => PortBox.Focus();

        private void SendPayloadBtn_Click(object sender, EventArgs e) {
            UpdateLabel("Sending ps4debug Payload to PS4");

            if (PayloadThread?.ThreadState == 0)
                PayloadThread.Abort();


            (PayloadThread = new Thread(SendPayload)).Start(new { ActiveForm, IP, Port });
        }

        /// <summary>
        /// Manually attempt to connect to the target ps4. (You Never Need To Press This, But People May Get Confused If It's Left Out)
        /// </summary>
        private void ManualConnectBtn_Click(object sender, EventArgs e)
        {
            if (ConnectionThread?.ThreadState == ThreadState.Running)
            {
                try
                {
                    ConnectionThread?.Abort();
                }
                catch (ThreadAbortException){}
            }
            else
                InitializeConnectionThread();
        }
        #endregion




        //=====================================================\\
        //--|   Debug Mode Toggle Functions For Each Game   |--\\
        //=====================================================\\
        #region [Debug Mode Toggle Functions For Each Game]
        
        private async void T1RBtn_Click(object sender, EventArgs e)
        {
            await Task.Run(CheckConnectionStatus);
            
            if (Geo != null && Geo.IsConnected && CheckGameIsValid("CUSA00552", T1RIDs))
            {
                Toggle(new ulong[] { 0x1B8FA20, 0x1924a70, 0x1924a70, 0x1924a70, 0x1924a70 }, new string[] { "1.00", "1.08", "1.09", "1.10", "1.11" });
            }
            else
                UpdateLabel("Error Connecting to PS4");
        }


        private async void T2Btn_Click(object sender, EventArgs e)
        {
            await Task.Run(CheckConnectionStatus);

            if (Geo != null && Geo.IsConnected && CheckGameIsValid("CUSA10249", T2IDs))
            {
                Toggle(new ulong[] { 0x3b61900, 0x3b62d00, 0x3b67130, 0x3b67530, 0x3b675b0, 0x3b7b430, 0x3b7b430 }, new string[] { "1.00", "1.01", "1.02", "1.05", "1.07", "1.08", "1.09" });
            }
            else
                UpdateLabel("Error Connecting to PS4");
        }


        private async void UC1Btn_Click(object sender, EventArgs e)
        {
            await Task.Run(CheckConnectionStatus);

            if (Geo != null && Geo.IsConnected && CheckGameIsValid("CUSA02320", UCCIDs))
            {
                Toggle(GameVersion == "U1 1.00" ? new ulong[] { 0xD97B41, 0xD989CC, 0xD98970 } : new ulong[] { 0xD5C9F0, 0xD5CA4C, 0xD5BBC1 });
            }
            else
                UpdateLabel("Error Connecting to PS4");
        }

        
        private async void UC2Btn_Click(object sender, EventArgs e)
        {
            await Task.Run(CheckConnectionStatus);
            
            if (Geo != null && Geo.IsConnected && CheckGameIsValid("CUSA02320", UCCIDs))
            {
                Toggle(GameVersion == "U2 1.00" ? new ulong[] { 0x1271431, 0x127149C, 0x12705C9 } : new ulong[] { 0x145decc, 0x145cff9, 0x145de61 });
            }
            else
                UpdateLabel("Error Connecting to PS4");
        }


        private async void UC3Btn_Click(object sender, EventArgs e)
        {
            await Task.Run(CheckConnectionStatus);
            
            if (Geo != null && Geo.IsConnected && CheckGameIsValid("CUSA02320", UCCIDs))
            {
                Toggle(GameVersion == "U3 1.00" ? new ulong[] { 0x18366c9, 0x18366c4, 0x1835481 } : new ulong[] { 0x1bbaf69, 0x1bbaf64, 0x1BB9D21 });
            }
            else
                UpdateLabel("Error Connecting to PS4");
        }
        

        private async void UC4Btn_Click(object sender, EventArgs e)
        {
            await Task.Run(CheckConnectionStatus);

            if (Geo != null && Geo.IsConnected && CheckGameIsValid("CUSA00341", UC4IDs))
            {
                Toggle(new ulong[] { 0x27a3c30, 0x2889370, 0x288d370, 0x288d370, 0x2891370, 0x2891370, 0x2891370, 0x24ed968, 0x24ed968, 0x24f1978, 0x24fd958, 0x2501738, 0x2739a20, 0x2739a20, 0x2739a20, 0x2570748, 0x2570748, 0x2580888, 0x2570748, 0x2738dc0, 0x2570748, 0x273cdc0, 0x2570748, 0x273cdc0, 0x274ccd0, 0x2570748, 0x274ccd0, 0x2750d00, 0x2570748, 0x2758d00, 0x275cd00, 0x275cd00, 0x275cd00, 0x275cd00 }, new string[] { "1.00 SP", "1.01 SP", "1.02 SP", "1.03 SP", "1.04 SP", "1.05 SP", "1.06 SP", "1.08 SP", "1.10 SP", "1.11 SP", "1.12 SP", "1.13 SP", "1.15 SP", "1.16 SP", "1.17 SP", "1.18", "1.19", "1.20 MP", "1.20 SP", "1.21 MP", "1.21 SP", "1.22 MP", "1.22/23 SP", "1.23 MP", "1.24 MP", "1.24/25 SP", "1.25 MP", "1.27/28 MP", "1.27+ SP", "1.29 MP", "1.30 MP", "1.31 MP", "1.32 MP", "1.33 MP" });
            }
            else
                UpdateLabel("Error Connecting to PS4");
        }


        private async void UC4MPBetaBtn_Click(object sender, EventArgs e)
        {
            await Task.Run(CheckConnectionStatus);
            
            if (Geo != null && Geo.IsConnected && CheckGameIsValid("CUSA00341", UC4BetaIDs))
            {
                Toggle(new ulong[] { 0x2bbf720, 0x2bc3720 }, new string[] { "1.00", "1.09" });
            }   
            else
                UpdateLabel("Error Connecting to PS4");
        }


        private async void UCTLLBtn(object sender, EventArgs e)
        {
            await Task.Run(CheckConnectionStatus);
            
            if (Geo != null && Geo.IsConnected && CheckGameIsValid("CUSA07737", TLLIDs))
            {
                Toggle(new ulong[] { 0x26b4558, 0x26c0698, 0x0274cd00, 0x275cd00, 0x275cd00 }, new string[] { "1.00 SP", "1.0X SP", "1.00 MP", "1.08 MP", "1.09 MP" });
            }
            else
                UpdateLabel("Error Connecting to PS4");
        }
        #endregion
    }
}
