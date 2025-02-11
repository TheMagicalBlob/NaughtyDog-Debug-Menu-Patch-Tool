using System;
using System.Drawing;
using static Dobby.Common;
using System.Windows.Forms;
using libgp4;



namespace Dobby {
    internal partial class Gp4CreationPage : Form {

        public Gp4CreationPage() { //! Page Unfinished, Only Base Functionality Added
            InitializeComponent();
            
            InitializeAdditionalEventHandlers(Controls);


            //! Why am I doing this?
            foreach(Control control in Controls) {
                if(control.Name.Contains("PathLabel")) {
                    control.MouseEnter += new EventHandler(HighlightPathLabel);
                    control.MouseLeave += new EventHandler(HighlightPathLabel);
                }
            }
            
            AbsoluteFilePathsBtn.Variable = false;
            IgnoreKeystoneBtn.Variable = false;

            gp4 = new GP4Creator();
        }


        //=================================\\
        //--|   Variable Declarations   |--\\
        //=================================\\
        #region [Variable Declarations]
        private GP4Creator gp4;
        #endregion



        
        //=================================\\
        //--|   Function Declarations   |--\\
        //=================================\\
        #region [Function Declarations]


        /// <summary> Load orbis-pub-cmd.exe Binary And The Reqired .gp4 file If The Path Is Right
        private void FilterArrayTextBox_TextChanged(object sender, EventArgs e) { // tst : eboot.bin, keystone, discname.txt; param.sfo

        }

        private void StartGp4CreationBtn_Click(object sender, EventArgs e) {
        }
        
        void HighlightPathLabel(object sender, EventArgs e) {
            var Sender = sender as Control;

            Sender.Font = new Font(Sender.Font.FontFamily, Sender.Font.Size, Sender.Font.Underline ? FontStyle.Bold : FontStyle.Bold | FontStyle.Underline);
        }

        private void SourcePkgPathBrowseBtn_Click(object sender, EventArgs e) {
            FileDialog file = new OpenFileDialog {
                Filter = ".gp4 Project File|*.gp4",
                Title = "Select Your .gp4 File"
            };

            if(file.ShowDialog() == DialogResult.OK)
                gp4.BasePackagePath = file.FileName;
            else return;
        }

        
        private void GamedataPathBtn_Click(object sender, EventArgs e)
        {

        }

        private void Gp4OutputDirectoryBrowseBtn_Click(object sender, EventArgs e)
        {

        }

        private void BaseGamePackageBrowseBtn_Click(object sender, EventArgs e)
        {

        }

        private void FileBlacklistBrowseBtn_Click(object sender, EventArgs e)
        {

        }

        

        private void AbsoluteFilePathsBtn_Click(object control, EventArgs _) => ((Dobby.Button)control).Variable = !(bool) ((Dobby.Button)control).Variable;
        
        private void IgnoreKeystoneBtn_Click(object control, EventArgs e) => ((Dobby.Button)control).Variable = !(bool) ((Dobby.Button)control).Variable;

        #endregion





        //================================\\
        //--|   Control Declarations   |--\\
        //================================\\
        #region [Control Declarations]
        private Label GamedataPathLabel;
        private TextBox GamedataPathTextBox;
        private Button GamedataPathBrowseBtn;
        private Label SeperatorLine1;
        private Button Gp4OutputDirectoryBrowseBtn;
        private TextBox Gp4OutputDirectoryTextBox;
        private Label Gp4OutputPathLabel;
        private Label PasscodeLabel;
        private TextBox PasscodeTextBox;
        private Label FileBlacklistPathLabel;
        private TextBox FileBlacklistTextBox;
        private Button FileBlacklistBrowseBtn;
        private Label BaseGamePackagePathLabel;
        private TextBox BaseGamePackagePathTextBox;
        private Button BaseGamePackageBrowseBtn;
        private Label SeperatorLine2;
        private Label SeperatorLine3;
        private Button AbsoluteFilePathsBtn;
        private Button IgnoreKeystoneBtn;
        private Button InfoHelpBtn;
        private Button BackBtn;
        private Label Info;
        private Button CreditsBtn;
        private Label MainLabel;
        private Button StartGp4CreationBtn;
        private Label SeperatorLine4;
        private Label SeperatorLine0;
        #endregion
    }
}
