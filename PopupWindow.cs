using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Policy;

namespace Dobby
{

    internal partial class Common
    {
        private partial class PopupWindow : Form
        {
            /// <summary>
            /// Custom MessageBox class for stuff and things
            /// </summary>
            /// <param name="ParentForm"> </param>
            /// <param name="Message"> </param>
            /// <param name="Title"> </param>
            /// <param name="buttons"> </param>
            public PopupWindow(Form ParentForm, string Message, string Title, MessageBoxButtons buttons)
            {
                
                //#
                //## Set a few things I'd rather be set as soon as possible, jic
                //#
                FormClosed += (_, __) => HasActiveWindow = false;
                HasActiveWindow = true;



                //#
                //## Create and decorate the form
                //#
                Dev?.Print("Creating Popup Window...");
                #region [Create and decorate the form]
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
                this.PopupMessageTextBox.TabStop = false;
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

                var Renderer = CreateGraphics();


                
                //#
                //## Create and add relevant buttons
                //#
                #region [Create and decorate the form]
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
                
                ExitBtn.Click += new EventHandler((sender, args) => { this.Close(); });
                ExitBtn.MouseEnter += new EventHandler(Common.WindowBtnMH);
                ExitBtn.MouseLeave += new EventHandler(Common.WindowBtnML);




                //#
                //## Create and add the relevant MessageBoxButtons to the PopupWindow
                //#
                switch (buttons)
                {
                    case MessageBoxButtons.OK:
                        break;
                }
                if (buttons != MessageBoxButtons.OK)
                {
                    var measuredConfirmButtonWidth = TryAutosize(MessageBoxButtonText[(int)buttons][0]);
                    var ConfirmBtn = new Button()
                    {
                        Location = new Point((this.Size.Width / 2) - measuredConfirmButtonWidth, this.Size.Height - 30),
                        Name = "ConfirmBtn",
                        Font = MainControlFont,
                        Text = MessageBoxButtonText[(int)buttons][0],
                        Size = new Size(measuredConfirmButtonWidth, 23),
                        FlatStyle = FlatStyle.Flat,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Cursor = Cursors.Cross
                    };
           
                    ConfirmBtn.Click += new EventHandler((sender, args) =>
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    });
                    ConfirmBtn.MouseEnter += new EventHandler(Common.WindowBtnMH);
                    ConfirmBtn.MouseLeave += new EventHandler(Common.WindowBtnML);

                    Controls.Add(ConfirmBtn);
                    ConfirmBtn.BringToFront();

                    
                    var CancelBtn = new Button()
                    {
                        Location = new Point((this.Size.Width / 2) + 1, this.Size.Height - 30),
                        Size = new Size(TryAutosize(MessageBoxButtonText[(int)buttons][1]), 23),
                        Name = "CancelBtn",
                        Font = MainControlFont,
                        Text = MessageBoxButtonText[(int)buttons][1],
                        FlatStyle = FlatStyle.Flat,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Cursor = Cursors.Cross
                    };

                    CancelBtn.Click += new EventHandler((sender, args) =>
                    {
                        DialogResult = DialogResult.Cancel;
                        this.Close();
                    });
                    CancelBtn.MouseEnter += new EventHandler(Common.WindowBtnMH);
                    CancelBtn.MouseLeave += new EventHandler(Common.WindowBtnML);
                    
                    Controls.Add(CancelBtn);
                    CancelBtn.BringToFront();


                    
                    var RetryBtn = new Button()
                    {
                        Location = new Point((this.Size.Width / 2) + 1, this.Size.Height - 30),
                        Size = new Size(TryAutosize(MessageBoxButtonText[(int)buttons][2]), 23),
                        Name = "RetryBtn",
                        Font = MainControlFont,
                        Text = MessageBoxButtonText[(int)buttons][2],
                        FlatStyle = FlatStyle.Flat,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Cursor = Cursors.Cross
                    };

                    RetryBtn.Click += new EventHandler((sender, args) =>
                    {
                        DialogResult = DialogResult.Cancel;
                        this.Close();
                    });
                    RetryBtn.MouseEnter += new EventHandler(Common.WindowBtnMH);
                    RetryBtn.MouseLeave += new EventHandler(Common.WindowBtnML);
                    
                    Controls.Add(RetryBtn);
                    RetryBtn.BringToFront();
                }

                // Just create the "OK" Button
                else {
                    var ConfirmBtn = new Button()
                    {
                        Location = new Point((this.Size.Width / 2) - 30, this.Size.Height - 30),
                        Size = new Size(32, 23),
                        Name = "ConfirmBtn",
                        Font = new Font("Franklin Gothic Medium", 7.5F, FontStyle.Bold),
                        Text = MessageBoxButtonText[(int)buttons][0],
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Gray,
                        ForeColor = SystemColors.Control,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Cursor = Cursors.Cross
                    };
           
                    ConfirmBtn.Click += new EventHandler((sender, args) =>
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    });
                    ConfirmBtn.MouseEnter += new EventHandler(Common.WindowBtnMH);
                    ConfirmBtn.MouseLeave += new EventHandler(Common.WindowBtnML);

                    Controls.Add(ConfirmBtn);
                    ConfirmBtn.BringToFront();
                }
                #endregion



                
                //#
                //## Apply basic event handlers and line decorations
                //#
                InitializeAdditionalEventHandlers(this, true);

                

                
                //#
                //## Words
                //#
                #region [Words]

                // Fix inconsistent margins (left-side spacing is ~17 while the right gets left to 1 - 2)
                PopupMessageTextBox.RightMargin = PopupMessageTextBox.Width - 17;


                // Assign title & nessage box text
                if (Title?.Length < 1)
                {
                    MainLabel.Text = "Empty Title Provided. (???)";
                }
                else {
                    MainLabel.Text = Title ?? "Null Title Provided. (???)";
                }

                if (Message?.Length < 1)
                {
                    PopupMessageTextBox.Text = "Empty Message Provided. (???)";
                }
                else {
                    PopupMessageTextBox.Text = Message ?? "Null Message Provided. (???)";
                }




                Shown += (dont, care) =>
                {
                    BringToFront();
                    var @switch = Width < ParentForm.Width ? 1 : -1;
                    var horizontalOffset = ParentForm.Location.X + (Width - ParentForm.Width) / 2 * @switch;


                    Location = new Point(horizontalOffset, ParentForm.Location.Y + 30);
                    Update();

                    LocationChanged += (eat, pant) => CenterParent(ParentForm);
                };
                #endregion
            }







            //=================================\\
            //--|   Variable Declarations   |--\\
            //=================================\\
            #region [Variable Declarations]
            internal static bool HasActiveWindow = false;

            internal DialogResult PreviousResult;

            private readonly string[][] MessageBoxButtonText = new string[][]
            {
                 new [] { "OK" },
                 new [] { "Ok", "Cancel" },
                 new [] { "Abort", "Retry", "Ignore" },
                 new [] { "Yes", "No", "Cancel" },
                 new [] { "Yes", "No" },
                 new [] { "Retry", "Cancel" },
            };

            //public enum essageBoxButtons
            //{
            //    OK,
            //    OKCancel,
            //    AbortRetryIgnore,
            //    YesNoCancel,
            //    YesNo,
            //    RetryCancel
            //}
            #endregion






            //=================================\\
            //--|   Function Declarations   |--\\
            //=================================\\
            #region [Function Declarations]

            #if DEBUG
            /// <summary>
            /// Move the PopupWindow to the center(-ish) of the parent form, after ensuring it's still on the right layer. (don't think I need to do that anymore, but meh)
            /// </summary>
            /// <param name="parentForm"> The form which opened the PopupWindow. </param>
            private void Center(Form parentForm)
            {
                BringToFront();
                var @switch = Width < parentForm.Width ? 1 : -1;
                var horizontalOffset = parentForm.Location.X + (Width - parentForm.Width) / 2 * @switch;


                Location = new Point(horizontalOffset, parentForm.Location.Y + 30);
                Update();
            }
            #endif

            
            /// <summary>
            /// Move the ParentForm back behind the PopupWindow
            /// </summary>
            /// <param name="parentForm"> The form which opened the PopupWindow. </param>
            private void CenterParent(Form parentForm)
            {
                var @switch = Width < parentForm.Width ? 1 : -1;
                var horizontalOffset = Location.X + (parentForm.Width - Width) / 2 * @switch;


                BringToFront();
                parentForm.Location = new Point(horizontalOffset, Location.Y - 30);
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
