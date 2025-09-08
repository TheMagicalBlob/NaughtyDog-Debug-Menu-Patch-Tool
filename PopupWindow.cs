using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace Dobby
{

    internal partial class Common
    {
        private partial class PopupWindow : Form
        {
            public PopupWindow(string Message, string Title, bool IsQuestion)
            {
                Dev?.Print("Creating Popup Window...");

                //#
                //## Create and decorate the form, then apply basic event handlers and line decorations
                //#
                #region go away
                this.MainLabel = new Dobby.Label();
                this.separatorLine0 = new Dobby.Label();
                this.PopupMessageTextBox = new Dobby.RichTextBox();
                this.SuspendLayout();
                // 
                // MainLabel
                // 
                this.MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.MainLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
                this.MainLabel.ForeColor = System.Drawing.SystemColors.Control;
                this.MainLabel.IsSeparatorLine = false;
                this.MainLabel.Location = new System.Drawing.Point(1, 1);
                this.MainLabel.Name = "MainLabel";
                this.MainLabel.Size = new System.Drawing.Size(359, 22);
                this.MainLabel.StretchToFitForm = false;
                this.MainLabel.TabIndex = 0;
                this.MainLabel.Text = "ERROR";
                this.MainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // separatorLine0
                // 
                this.separatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
                this.separatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
                this.separatorLine0.IsSeparatorLine = true;
                this.separatorLine0.StretchToFitForm = true;
                this.separatorLine0.Location = new System.Drawing.Point(1, 20);
                this.separatorLine0.Name = "separatorLine0";
                this.separatorLine0.Size = new System.Drawing.Size(336, 15);
                this.separatorLine0.TabIndex = 39;
                this.separatorLine0.Text = "--------------------------------------------------------------";
                // 
                // PopupMessageTextBox
                // 
                this.PopupMessageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
                this.PopupMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.PopupMessageTextBox.ForeColor = System.Drawing.SystemColors.Control;
                this.PopupMessageTextBox.Location = new System.Drawing.Point(1, 31);
                this.PopupMessageTextBox.Name = "PopupMessageTextBox";
                this.PopupMessageTextBox.ReadOnly = true;
                this.PopupMessageTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                this.PopupMessageTextBox.ShowSelectionMargin = true;
                this.PopupMessageTextBox.Size = new System.Drawing.Size(359, 152);
                this.PopupMessageTextBox.TabIndex = 40;
                this.PopupMessageTextBox.Text = "";
                // 
                // PopupWindow
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
                this.ClientSize = new System.Drawing.Size(361, 188);
                this.Controls.Add(this.PopupMessageTextBox);
                this.Controls.Add(this.MainLabel);
                this.Controls.Add(this.separatorLine0);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Name = "PopupWindow";
                this.ResumeLayout(false);
                #endregion




                Dev?.Print("Populating Popup Window...");

                // Create the exit button and related events
                var ExitBtn = new Button()
                {
                    Location = new Point(this.Size.Width - 24, 1),
                    Size = new Size(23, 23),
                    Name = "ExitBtn",
                    Font = new Font("Franklin Gothic Medium", 7.5F, FontStyle.Bold),
                    Text = "X",
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Gray,
                    ForeColor = SystemColors.Control,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Cursor = Cursors.Cross
                };
                ExitBtn.FlatAppearance.BorderSize = 0;
                Controls.Add(ExitBtn);
                ExitBtn.BringToFront();
            
                FormClosed += (sender, args) => HasActiveWindow = false;
                
                ExitBtn.Click += new EventHandler((sender, args) => { this.Close(); });
                ExitBtn.MouseEnter += new EventHandler(Common.WindowBtnMH);
                ExitBtn.MouseLeave += new EventHandler(Common.WindowBtnML);
                
                if (IsQuestion)
                {
                    var ConfirmBtn = new Button()
                    {
                        Location = new Point(this.Size.Width / 2 - 30, this.Size.Height - 30),
                        Size = new Size(32, 23),
                        Name = "ConfirmBtn",
                        Font = new Font("Franklin Gothic Medium", 7.5F, FontStyle.Bold),
                        Text = "Ok",
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Gray,
                        ForeColor = SystemColors.Control,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Cursor = Cursors.Cross
                    };
                    ConfirmBtn.FlatAppearance.BorderSize = 0;
                    Controls.Add(ConfirmBtn);
                    ConfirmBtn.BringToFront();
            
                    FormClosed += (sender, args) => HasActiveWindow = false;
                
                    ConfirmBtn.Click += new EventHandler((sender, args) => { PreviousResult = DialogResult.OK; this.Close(); });
                    ConfirmBtn.MouseEnter += new EventHandler(Common.WindowBtnMH);
                    ConfirmBtn.MouseLeave += new EventHandler(Common.WindowBtnML);

                    

                    var CancelBtn = new Button()
                    {
                        Location = new Point(this.Size.Width / 2 + 1, this.Size.Height - 30),
                        Size = new Size(50, 23),
                        Name = "CancelBtn",
                        Font = new Font("Franklin Gothic Medium", 7.5F, FontStyle.Bold),
                        Text = "Cancel",
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Gray,
                        ForeColor = SystemColors.Control,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Cursor = Cursors.Cross
                    };
                    CancelBtn.FlatAppearance.BorderSize = 0;
                    Controls.Add(ConfirmBtn);
                    CancelBtn.BringToFront();
            
                    FormClosed += (sender, args) => HasActiveWindow = false;
                
                    CancelBtn.Click += new EventHandler((sender, args) => { PreviousResult = DialogResult.Cancel; this.Close(); });
                    CancelBtn.MouseEnter += new EventHandler(Common.WindowBtnMH);
                    CancelBtn.MouseLeave += new EventHandler(Common.WindowBtnML);
                }
                
                InitializeAdditionalEventHandlers(this, true);


                

                
                // Fix inconsistent margins (left-side spacing is ~17 while the right gets left to 1 - 2)
                PopupMessageTextBox.RightMargin = PopupMessageTextBox.Width - 17;


                // Assign title text if applicable
                if (Title != null)
                {
                    MainLabel.Text = Title;
                }


                // Assign message box text
                if (Message?.Length < 1)
                {
                    PopupMessageTextBox.Text = "Empty Message Provided!!!";
                }
                else {
                    PopupMessageTextBox.Text = Message ?? "Null Message Provided!!!";
                }



                HasActiveWindow = true;

                Show();
                Center(Venat.Location);
                Focus();
            }







            //=================================\\
            //--|   Variable Declarations   |--\\
            //=================================\\
            #region [Variable Declarations]
            internal static bool HasActiveWindow = false;

            internal DialogResult PreviousResult;
            #endregion





            //=================================\\
            //--|   Function Declarations   |--\\
            //=================================\\
            #region [Function Declarations]
            public void Center(Point parentLocation)
            {
                var @switch = Width < Venat.Width ? 1 : -1;

                var horizontalOffset = parentLocation.X + (Width - Venat.Width) / 2 * @switch;


                
                Update();
                BringToFront();

                Location = new Point(horizontalOffset, parentLocation.Y + 30);
                Update();
            }
            #endregion





            //=====================================\\
            //--|   Designer Crap, No Touchie   |--\\
            //=====================================\\
            #region [Designer Crap, No Touchie]

            private System.ComponentModel.IContainer components = null;

            protected override void Dispose(bool disposing) {
                if(disposing && (components != null)) {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }





            //================================\\
            //--|   Control Declarations   |--\\
            //================================\\
            public Label MainLabel;
            public Label separatorLine0;
            private RichTextBox PopupMessageTextBox;
            #endregion
        }
    }
}
