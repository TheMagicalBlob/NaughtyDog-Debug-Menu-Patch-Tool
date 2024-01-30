using System.Windows.Forms;
using System;
using System.Drawing;
using static Dobby.Common;

namespace Dobby
{
    public partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        #endregion

        public Button CreditsBtn;
        public Button InfoHelpBtn;
        public Label Playstation4Label;
        public Label PCLabel;
        public Button DownloadSourceBtn;
        
    }
}

