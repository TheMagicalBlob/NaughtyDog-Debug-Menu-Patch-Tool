using libdebug;
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

        public PS4DebugPage() {
            InitializeComponent();

            // Run miscellaneous post-initialization setup (Variable assignment, event handler creation, etc.)
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
                        Dev.Print($"Saving \"{IP}\" as new IPAddress.");
                        settingsFile.Write(Encoding.UTF8.GetBytes(IP + ";"), 0, IpBox.Text.Length + 1);
                    }

                else
                    ActiveForm?.Invoke(SetInfoText, $"Invalid IP specified; save aborted. (provided address: {IP})");
            };
            PortBox.LostFocus += (control, args) =>
            {
                if (!File.Exists(settingsFilePath))
                    CreateSettingsFile();
    

                if (short.TryParse(settingsFilePath, out Port)) {
                    using (FileStream settingsFile = new FileStream(settingsFilePath, FileMode.Open, FileAccess.Write))
                    {
                        Dev.Print($"Saving \"{Port}\" as new Port");
                        settingsFile.Position = 16;
                        settingsFile.Write(BitConverter.GetBytes(Port), 0, 4);
                    }
                }
                else
                    ActiveForm?.Invoke(SetInfoText, $"Invalid Port specified; save aborted. (provided port: {Port})");
            };

            // Assign IgnoreTitleID variable property
            IgnoreTitleIDBtn.Variable = false;
            


            if (!File.Exists(settingsFilePath))
                CreateSettingsFile();

            var settings = ReadSettingsFile();

            IpBox.Text = (IP = (IPAddress) settings[0]).ToString();
            PortBox.Text = (Port = (short) settings[1]).ToString();

        }




        //=================================\\
        //|    PS4Debug Page Variables    |\\
        //=================================\\
        #region [PS4Debug Page Variables]

        public PS4DBG Geo;
        
        public Thread 
            ConnectionThread,
            PayloadThread
        ;

        private readonly byte
            On = 0x01,
            Off = 0x00
        ;

        /// <summary>
        /// Seperate boolean due to the PS4DBG.IsConnected property throwning an exception in certain cases. (TODO: rework and avoid this, lazy-arse //!)
        /// </summary>
    #if DEBUG
        internal static
    #else
        private
    #endif
        bool PS4DebugIsConnected;

        /// <summary>
        /// //! Maybe just remove this and rework stuff
        /// </summary>
        private bool WaitForConnection = true;


        /// <summary> If true, manually assigns a default title id matching the chosen game. </summary>
        private bool IgnoreTitleID = false;

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

        public string ProcessName;
        public string GameVersion;
        public string TitleID;

        public short Port;
        public IPAddress IP;
        #endregion



        //=========================================================\\
        //|    Functions For Basic PS4Debug Page Functionality    |\\
        //=========================================================\\
        #region [Functions For Basic PS4Debug Page Functionality]

        private void SendPayload(dynamic args)
        {
            using(var payloadSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                // Load Passed Parameters
                var port = (int)args.Port;
                var ip   = (IPAddress)args.IP;
                var form = (Form)args.ActiveForm;


                form?.Invoke(SetInfoText, "Sending ps4debug Payload...");
                Dev.Print($"^- Payload Destination: {ip}:{port}.");

                try {
                    payloadSocket.Connect(new IPEndPoint(ip, port));
                    payloadSocket.Send(Resource.ps4debug);
                }
                catch(Exception e) {
                    Dev.Print($"Failed To Connect To Specified Server at [{ip}:{port}]\nError: {e.Message}\n{e.StackTrace}");
                    form.Invoke(SetInfoText, "Failed To Connect To Specified Address/Port");
                }
                finally {
                    payloadSocket.Close();
                }


                if(payloadSocket.Connected)
                {
                    form?.Invoke(SetInfoText, "Payload Injected Successfully");
                    MessageBox.Show("PS4Debug Update 1.1.15 By ctn123\nPS4Debug Created By Golden", "Payload Injected Successfully, Here's Some Credits"); // Excessive Credits To Try Avoiding Beef lol
                }
            }
        }

        private void Connect(dynamic Parameters) {
            try {
                
                // Load Passed Parameters
                var ip = (IPAddress)Parameters.IP;
                var form = (Form)Parameters.ActiveForm;


                form?.Invoke(SetInfoText, $"Connecting to Console at \"{IP}\"");

                // Establish a connection for the new PS4Debug instance
                try {
                    Geo = new PS4DBG(IP);
                    Geo.Connect();
                }
                catch (SocketException oops) {
                    form.Invoke(SetInfoText, $"Error Connecting to \"{IP}\"");
                    Dev.Print($"!! ERROR: Unable to connect to PS4, see exception below.\n{oops.Message}\n{oops.StackTrace.Replace("\n", "  \n")}");
                    return;
                }


                PS4DebugIsConnected = Geo.IsConnected;
                Dev.Print($"Connection Status: {PS4DebugIsConnected}");
                form?.Invoke(SetInfoText, "PS4Debug Connected, Searching for Game...");


                foreach(libdebug.Process process in Geo.GetProcessList().processes) { // processprocessprocessprocessprocessprocessprocess
                    
                    // Ignore unrelated processes
                    if(!ExecutableNames.Contains(process.name))
                        continue;
                    


                    string titleId;
                    int exectuable = process.pid;
                    
                    // Check To Avoid Connecting To HB Store Stuff
                    if((titleId = Geo.GetProcessInfo(exectuable).titleid) == "FLTZ00003" || titleId == "ITEM00003") {
                        Dev.Print($"Skipping Lightning's Stuff {titleId}");
                        continue;
                    }

                    Executable = exectuable;
                    TitleID = titleId;
                    ProcessName = process.name;
                    Dev.Print($"Process Name: [{ProcessName}]");


                    // Detect the currently loaded game and app_ver (clunkily.)
                    GameVersion = GetGameTitleIDVersionAndDMenuOffset(titleId);

                    form?.Invoke(SetInfoText, $"Attached to {titleId} ({GameVersion})");
                    return;
                }

                // Error out if no eboot.bin (or other expected executable) was found.
                ProcessName = "No Valid Process";
                form?.Invoke(SetInfoText, "Couldn't Find a Valid Game Process.");
            }
            catch(Exception tabarnack) {
                ActiveForm?.Invoke(SetInfoText, $"Connection to {IP} Failed.");
                Dev.PrintError(tabarnack);
            }
        }


        /// <summary> Avoid Attempting To Toggle The Selected Bool In Memory Before The Connection Process Is Finished
        ///</summary>
        private Task CheckConnectionStatus() {
            if(ConnectionThread == null || ConnectionThread.ThreadState == ThreadState.Unstarted)
                ConnectionThread.Start();


            else if(!PS4DebugIsConnected || Geo?.GetProcessInfo(Executable).name != ProcessName || !ExecutableNames.Contains(Geo?.GetProcessInfo(Executable).name)) {
                PS4DebugIsConnected = false; WaitForConnection = true;
                Dev.Print("CheckConnectionStatus Second Case, Now On WaitForConnection");
            }

            while(WaitForConnection) Thread.Sleep(2);
            return Task.CompletedTask;
        }
        

        /// <summary>
        /// An ugly sack of gross which determines the patch version of a specified game by checking the Int16 value of 2 bytes at a game-specific address because I have no idea how or if I can check the .sfo
        /// </summary>
        /// <returns> The Current Game Version If Successful, Or UnknownGameVersion \ UnknownTitleID If It Failed At Some Stage </returns>
        private string GetGameTitleIDVersionAndDMenuOffset(string titleID) {
            try {
                if(PS4DebugIsConnected && Geo.GetProcessInfo(Executable).name == ProcessName) {

                    // Determine The Game That's Running
                    switch(titleID) {
                        case "CUSA00552":
                        case "CUSA00554":
                        case "CUSA00556":
                        case "CUSA00557":
                        case "CUSA00559":
                            GameVersion = "T1R";
                            break;
                        case "CUSA10249":
                        case "CUSA14006":
                        case "CUSA07820":
                        case "CUSA13986":
                            GameVersion = "T2";
                            break;
                        case "CUSA01399":
                        case "CUSA02320":
                        case "CUSA02343":
                        case "CUSA02344":
                        case "CUSA02826":
                            GameVersion = "UCC";
                            break;
                        case "CUSA00341":
                        case "CUSA08342":
                        case "CUSA00912":
                        case "CUSA00917":
                        case "CUSA00918":
                        case "CUSA04529":
                            GameVersion = "UC4";
                            break;
                        case "CUSA04030":
                        case "CUSA04032":
                        case "CUSA04034":
                        case "CUSA04051":
                            GameVersion = "UC4 MP Beta";
                            break;
                        case "CUSA07737":
                        case "CUSA07875":
                        case "CUSA09564":
                        case "CUSA08347":
                        case "CUSA08352":
                            GameVersion = "TLL";
                            break;

                        default:
                            MessageBox.Show("Title ID Doesn't Match Any Known ID's, Try Enabling \"Ignore Title ID\" If You've Changed The Game's Title ID Yourself", "No Idea Which Game This Is");
                            return "UnknownTitleID";
                    }

                    // Read A Spot In Memory To Determine Which Patch the Executable's From
                    switch(GameVersion) {
                        case "T1R":
                            var T1RCheck = BitConverter.ToInt16(Geo.ReadMemory(Executable, 0x4000F4, 2), 0);
                            switch(T1RCheck) {
                                case 18432: DebugModePointerOffset = 0x2E81; return "1.00";
                                case 1288:  DebugModePointerOffset = 0x2E81; return "1.08";
                                case 3480:  DebugModePointerOffset = 0x2E81; return "1.09";
                                case 4488:  DebugModePointerOffset = 0x2E81; return "1.10";
                                case 4472:  DebugModePointerOffset = 0x2E81; return "1.11";

                                default:
                                    Dev.Print($"Error, Game Was T1R But None of The Checks Matched! || {T1RCheck}");
                                    MessageBox.Show($"The Game Was Determined To Be The Last of Us: Remastered, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{T1RCheck} {TitleID}", "Error Finding App Version");
                                    return "UnknownT1RGameVersion";
                            }
                        case "T2":
                            var T2Check = BitConverter.ToInt32(Geo.ReadMemory(Executable, 0x40009A, 4), 0);
                            DebugModePointerOffset = 0x3aa1;
                            switch(T2Check) {
                                case 25384434: DebugModePointerOffset = 0x3aa1; return "1.00";
                                case 25548706: DebugModePointerOffset = 0x3aa1; return "1.01";
                                case 25502882: DebugModePointerOffset = 0x3aa1; return "1.02";
                                case 25588450: DebugModePointerOffset = 0x3aa1; return "1.05";
                                case 25593522: DebugModePointerOffset = 0x3aa1; return "1.07";
                                case 30024882: DebugModePointerOffset = 0x3aa1; return "1.08";
                                case 30024914: DebugModePointerOffset = 0x3aa1; return "1.09";

                                default:
                                    Dev.Print($"Error, Game Was T2 But None of The Checks Matched! || chk:{T2Check}");
                                    MessageBox.Show($"The Game Was Determined To Be The Last of Us Part II, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{T2Check} {TitleID}", "Error Finding App Version");
                                    return "UnknownT2GameVersion";
                            }
                        case "UCC":
                            var UCCCheck = BitConverter.ToInt32(SHA256.Create().ComputeHash(Geo.ReadMemory(Executable, 0x400000, 100)), 0);
                            switch(UCCCheck) {
                                case 455457367: return "U2 1.00";
                                case -1951784656: return "U3 1.00";
                                case -1805287883: return "U2 1.02";
                                case 750078581: return "U3 1.02";
                                case -136556654: return "U1 1.00";
                                case -1120900838: return "U1 1.02";

                                default:
                                    Dev.Print($"Error, Game Was UCC But None of The Checks Matched! || chk:{UCCCheck}");
                                    MessageBox.Show($"The Game Was Determined To Be The Uncharted Collection, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{UCCCheck} {TitleID}", "Error Finding App Version");
                                    return "UnknownUCCGameVersion";
                            }
                        case "UC4":
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
                                    Dev.Print($"Error, Game Was UC4, But None of The Checks Matched! || chk:{U4Check}");
                                    MessageBox.Show($"The Game Was Determined To Be UC4, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{U4Check} {TitleID}", "Error Finding App Version");
                                    return "UnknownUC4GameVersion";
                            }

                        case "UC4 MP Beta":
                            var U4MPBetaCheck = BitConverter.ToInt32(Geo.ReadMemory(Executable, 0x403000, 4), 0);
                            switch(U4MPBetaCheck) {
                                case 759883849:  DebugModePointerOffset = 0x2E83; return "1.00 MP Beta";
                                case 2067458121: DebugModePointerOffset = 0x2E83; return "1.09 MP Beta";

                                default:
                                    Dev.Print($"Error, Game Was UC4 MP Beta, But None of The Checks Matched! || chk:{U4MPBetaCheck}");
                                    MessageBox.Show($"The Game Was Determined To Be The UC4 MP Beta (Nice), But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{U4MPBetaCheck} {TitleID}", "Error Finding App Version");
                                    return "UnknownUC4GameVersion";
                            }

                        case "TLL":
                            var TLLCheck = BitConverter.ToInt16(Geo.ReadMemory(Executable, 0x40003B, 2), 0);
                            switch(TLLCheck) {
                                case 3777:   DebugModePointerOffset = 0x2EF9; return "1.00 SP";
                                case -9759:  DebugModePointerOffset = 0x2EF9; return "1.0X SP";  // 1.08 and 1.09 have identical eboot.bin's
                                case -23679: DebugModePointerOffset = 0x2E79; return "1.00 MP";
                                case 27793:  DebugModePointerOffset = 0x2E79; return "1.08 MP";
                                case 27841:  DebugModePointerOffset = 0x2E79; return "1.09 MP";

                                default:
                                    Dev.Print($"Error, Game Was UCC But None of The Checks Matched! || chk:{TLLCheck}");
                                    MessageBox.Show($"The Game Was Determined To Be The The Lost Legacy, But The Executable Didn't Match Anything. This Could Be Caused By A Backported .bin\nPlease Send It To TheMagicalBlob To Quickly Have It Supported.\n{TLLCheck} {TitleID}", "Error Finding App Version");
                                    return "UnknownTLLGameVersion";
                            }

                        default: Dev.Print($"!!! PS4DebugPage -> GetGameVersion() Fell Through. (GameVersion: {GameVersion})"); return "UnknownGameVersion";
                    }
                }
                return "UnknownGameVersion";
            }
            catch(Exception Tabarnack) {
                Dev.Print($"{Tabarnack.Message};{Tabarnack.StackTrace}");
                return "UnknownGameVersion";
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

            Dev.Print($"No settings file was found in current folder, creating new one...\n{settingsFilePath}");
            ActiveForm?.Invoke(SetInfoText, "Created new settings file.");

            using (var newSettingsFile = new FileStream(settingsFilePath, FileMode.Create, FileAccess.Write))
            {
                newSettingsFile.Write(Encoding.UTF8.GetBytes("192.168.137.115;"), 0, 16);
                newSettingsFile.Write(BitConverter.GetBytes((short)9090), 0, 2);
                newSettingsFile.Flush();

                newSettingsFile.Dispose();
            }
        }



        /// <summary>
        ///   Read the saved IP address from the PS4_IP.BLB file in the app directory, or create a new one if it's not present
        /// </summary>
        /// <returns>
        ///   A string array containing the current ip and port if the file's present, otherwise the default value of "192.168.137.115". \m/
        /// </returns>
        private object[] ReadSettingsFile() {
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
                        Dev.Print($"!! ERROR: Unable to part IP Address from settings file. (attempted to parse: {Encoding.UTF8.GetString(buffer, 0, seperator)})");
                        ActiveForm?.Invoke(SetInfoText, "Unable to parse settings file.");

                        // use the default IP.
                        ip = IPAddress.Parse(IpBox.Text = "192.168.137.115");
                    }

                    settingsFile.Dispose();
                    return new object[] { ip, BitConverter.ToInt16(buffer, seperator + 1) };
                }
            else
            {
                Dev.Print("!! ERROR: An attempt to read the settings file was made, but the file doesn't exist.");
                return new object[0];
            }
        }



        /// <summary>
        /// Toggle the IgnoreTitleID setting for use when the game has an edited title id, but is likele still supported.
        /// </summary>
        /// <param name="control"> The clicked control to which the Enabled/Disabled text will be appended to. </param>
        private void IgnoreTitleIDBtn_Click(object control, EventArgs _)
        {
            ((Dobby.Button)control).Variable = !(bool) ((Dobby.Button)control).Variable;
            
            return; ((Control)control).Text = $"{((Control)control).Text.Remove(((Control)control).Text.LastIndexOf(' '))} {((IgnoreTitleID ^= true) ? "Enable" : "Disabled")}";
        }


        /// <summary>
        /// Toggles the byte at an address specified by 
        /// </summary>
        /// <param name="Addresses">Array Of Addresses To Read The Int64 From Depending On The Version</param>
        /// <param name="Versions">Version Strings To Check Against GameVersion</param>
        private void Toggle(ulong[] Addresses, string[] Versions) {
            try {
                if(PS4DebugIsConnected && Geo.GetProcessInfo(Executable).name == ProcessName) {
                    var AddressIndex = 0;
                    foreach(string Version in Versions)
                        if(GameVersion == Version) {
                            var pointer = (ulong)(BitConverter.ToInt64(Geo.ReadMemory(Executable, Addresses[AddressIndex], 8), 0) + DebugModePointerOffset);
                            Geo.WriteMemory(Executable, pointer, Geo.ReadMemory(Executable, pointer, 1)[0] == 0x00 ? On : Off);
                            Dev.Print($"Toggle(ulong[] Addresses, string[] Versions) Wrote To {pointer:X}");
                        }
                        else if(AddressIndex != Addresses.Length - 1) AddressIndex++;
                }
                else {
                    Dev.Print(
                        $"Error Toggling Byte.\nPS4Debug {(PS4DebugIsConnected ? "" : "Not ")}Connected\n"
                        + $"{Geo.GetProcessInfo(Executable).name} {(Geo.GetProcessInfo(Executable).name == ProcessName ? "=" : "!")}= {ProcessName}"
                    );
                }
            }
            catch(Exception tabarnack) { Dev.Print(tabarnack.Message); }
        }



        /// <summary>
        /// Toggles A Byte At Multiple Fixed Addresses (Only used for Uncharted: The Nathan Drake Collection)
        /// </summary>
        /// <param name="AddressArray">Array Of Addresses To Read/Write To</param>
        private void Toggle(ulong[] AddressArray) {
            try {
                if(PS4DebugIsConnected && Geo.GetProcessInfo(Executable).name == ProcessName)
                    Array.ForEach(AddressArray, Address => Geo.WriteMemory(Executable, Address, Geo.ReadMemory<byte>(Executable, Address) == 0x00 ? On : Off));

            }
            catch(Exception tabarnack) { Dev.Print(tabarnack.Message); }
        }



        private void IPLabelBtn_Click(object sender, EventArgs e) => IpBox.Focus();
        private void PortLabelBtn_Click(object sender, EventArgs e) => PortBox.Focus();

        private void SendPayloadBtn_Click(object sender, EventArgs e) {
            ActiveForm?.Invoke(SetInfoText, "Sending ps4debug Payload to PS4");

            if (PayloadThread?.ThreadState == 0)
                PayloadThread.Abort();


            (PayloadThread = new Thread(SendPayload)).Start(new { ActiveForm, IP, Port });
        }

        /// <summary>
        /// Manually attempt to connect to the target ps4. (You Never Need To Press This, But People May Get Confused If It's Left Out)
        /// </summary>
        private void ManualConnectBtn_Click(object sender, EventArgs e)
        {
            ActiveForm?.Invoke(SetInfoText, "Connecting to Console");

            if (ConnectionThread?.ThreadState == 0)
                ConnectionThread.Abort();


            PS4DebugIsConnected = false;
            (ConnectionThread = new Thread(Connect)).Start(new { ActiveForm, IP, Port });
        }
        #endregion




        ///////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        ///--     Debug Mode Toggle Functions For Each Game     --\\\
        ///////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private async void T1RBtn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA00552";

            if(!GameVersion.Contains("Unknown"))
                Toggle(new ulong[] { 0x1B8FA20, 0x1924a70, 0x1924a70, 0x1924a70, 0x1924a70 }, new string[] { "1.00", "1.08", "1.09", "1.10", "1.11" });
            else
                Dev.Print($"Unknown Game Version \"{GameVersion}\".");
        }
        private async void T2Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA10249";
            if(!GameVersion.Contains("Unknown"))
                Toggle(new ulong[] { 0x3b61900, 0x3b62d00, 0x3b67130, 0x3b67530, 0x3b675b0, 0x3b7b430, 0x3b7b430 }, new string[] { "1.00", "1.01", "1.02", "1.05", "1.07", "1.08", "1.09" });
            else
                Dev.Print($"Unknown Game Version \"{GameVersion}\".");
        }
        private async void UC1Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA02320";
            if(!GameVersion.Contains("Unknown"))
                Toggle(GameVersion == "U1 1.00" ? new ulong[] { 0xD97B41, 0xD989CC, 0xD98970 } : new ulong[] { 0xD5C9F0, 0xD5CA4C, 0xD5BBC1 });
            else
                Dev.Print($"Unknown Game Version \"{GameVersion}\".");
        }
        private async void UC2Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA02320";
            if(!GameVersion.Contains("Unknown"))
                Toggle(GameVersion == "U2 1.00" ? new ulong[] { 0x1271431, 0x127149C, 0x12705C9 } : new ulong[] { 0x145decc, 0x145cff9, 0x145de61 });
            else
                Dev.Print($"Unknown Game Version \"{GameVersion}\".");
        }
        private async void UC3Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA02320";
            if(!GameVersion.Contains("Unknown"))
                Toggle(GameVersion == "U3 1.00" ? new ulong[] { 0x18366c9, 0x18366c4, 0x1835481 } : new ulong[] { 0x1bbaf69, 0x1bbaf64, 0x1BB9D21 });
            else
                Dev.Print($"Unknown Game Version \"{GameVersion}\".");
        }
        private async void UC4Btn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA00341";
            if(!GameVersion.Contains("Unknown"))
                Toggle(new ulong[] { 0x27a3c30, 0x2889370, 0x288d370, 0x288d370, 0x2891370, 0x2891370, 0x2891370, 0x24ed968, 0x24ed968, 0x24f1978, 0x24fd958, 0x2501738, 0x2739a20, 0x2739a20, 0x2739a20, 0x2570748, 0x2570748, 0x2580888, 0x2570748, 0x2738dc0, 0x2570748, 0x273cdc0, 0x2570748, 0x273cdc0, 0x274ccd0, 0x2570748, 0x274ccd0, 0x2750d00, 0x2570748, 0x2758d00, 0x275cd00, 0x275cd00, 0x275cd00, 0x275cd00 }, new string[] { "1.00 SP", "1.01 SP", "1.02 SP", "1.03 SP", "1.04 SP", "1.05 SP", "1.06 SP", "1.08 SP", "1.10 SP", "1.11 SP", "1.12 SP", "1.13 SP", "1.15 SP", "1.16 SP", "1.17 SP", "1.18", "1.19", "1.20 MP", "1.20 SP", "1.21 MP", "1.21 SP", "1.22 MP", "1.22/23 SP", "1.23 MP", "1.24 MP", "1.24/25 SP", "1.25 MP", "1.27/28 MP", "1.27+ SP", "1.29 MP", "1.30 MP", "1.31 MP", "1.32 MP", "1.33 MP" });
            else
                Dev.Print($"Unknown Game Version \"{GameVersion}\".");
        }
        private async void UC4MPBetaBtn_Click(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA00341";
            if(!GameVersion.Contains("Unknown"))
                Toggle(new ulong[] { 0x2bbf720, 0x2bc3720 }, new string[] { "1.00", "1.09" });
            else
                Dev.Print($"Unknown Game Version \"{GameVersion}\".");
        }
        private async void UCTLLBtn(object sender, EventArgs e) {
            await Task.Run(CheckConnectionStatus);
            if(IgnoreTitleID) TitleID = "CUSA07737";
            if(!GameVersion.Contains("Unknown"))
                Toggle(new ulong[] { 0x26b4558, 0x26c0698, 0x0274cd00, 0x275cd00, 0x275cd00 }, new string[] { "1.00 SP", "1.0X SP", "1.00 MP", "1.08 MP", "1.09 MP" });
            else
                Dev.Print($"Unknown Game Version \"{GameVersion}\".");
        }




        //==============================\\
        //|    Control Declarations    |\\
        //==============================\\
        #region [Control Declarations]
        public void BackBtn_Click(object sender, EventArgs e) =>
            HoverLeave(BackBtn, false); // What Did This Fix, Again?
        
        public TextBox IpBox;
        public Label MainLabel;
        public Button T1RBtn;
        public Button T2Btn;
        public Button UC1Btn;
        public Button UC2Btn;
        public Button UC3Btn;
        public Button UC4Btn;
        public Button TLLBtn;
        public Button IPLabelBtn;
        public Button ManualConnectBtn;
        public Button PortLabelBtn;
        public TextBox PortBox;
        public Button PS4DebugPayloadBtn;
        public Label SeperatorLine0;
        public Label SeperatorLine1;
        public Label SeperatorLine3;
        public Button EPPBackBtn;
        public Button UC4MPBetaBtn;
        public Button InfoHelpBtn;
        public Button CreditsBtn;
        public Button BackBtn;
        public Label Info;
        public Label SeperatorLine2;
        public Button IgnoreTitleIDBtn;
        #endregion
    }
}
