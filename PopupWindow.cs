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
                MainLabel = new Dobby.Label();
                separatorLine0 = new Dobby.Label();
                PopupMessageTextBox = new Dobby.RichTextBox();
                SuspendLayout();
                // 
                // MainLabel
                // 
                MainLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                MainLabel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
                MainLabel.ForeColor = System.Drawing.SystemColors.Control;
                MainLabel.IsSeparatorLine = false;
                MainLabel.Location = new System.Drawing.Point(1, 1);
                MainLabel.Name = "MainLabel";
                MainLabel.Size = new System.Drawing.Size(359, 22);
                MainLabel.StretchToFitForm = false;
                MainLabel.TabIndex = 0;
                MainLabel.Text = "ERROR";
                MainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                // 
                // separatorLine0
                // 
                separatorLine0.Font = new System.Drawing.Font("Cambria", 10F);
                separatorLine0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
                separatorLine0.IsSeparatorLine = true;
                separatorLine0.StretchToFitForm = true;
                separatorLine0.Location = new System.Drawing.Point(1, 20);
                separatorLine0.Name = "separatorLine0";
                separatorLine0.Size = new System.Drawing.Size(336, 15);
                separatorLine0.TabIndex = 39;
                separatorLine0.Text = "--------------------------------------------------------------";
                // 
                // PopupMessageTextBox
                // 
                PopupMessageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
                PopupMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
                PopupMessageTextBox.ForeColor = System.Drawing.SystemColors.Control;
                PopupMessageTextBox.Location = new System.Drawing.Point(1, 31);
                PopupMessageTextBox.Name = "PopupMessageTextBox";
                PopupMessageTextBox.ReadOnly = true;
                PopupMessageTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
                PopupMessageTextBox.ShowSelectionMargin = true;
                PopupMessageTextBox.Size = new System.Drawing.Size(359, 152);
                PopupMessageTextBox.TabIndex = 40;
                PopupMessageTextBox.TabStop = false;
                PopupMessageTextBox.Text = "";
                // 
                // PopupWindow
                // 
                AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
                ClientSize = new System.Drawing.Size(361, 188);
                Controls.Add(PopupMessageTextBox);
                Controls.Add(MainLabel);
                Controls.Add(separatorLine0);
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                Name = "PopupWindow";
                ResumeLayout(false);
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
                    Location = new Point(Size.Width - 24, 1),
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
                
                ExitBtn.Click += new EventHandler((sender, args) => { Close(); });
                ExitBtn.MouseEnter += new EventHandler(Common.WindowBtnMH);
                ExitBtn.MouseLeave += new EventHandler(Common.WindowBtnML);





                //#
                //## Create and add the relevant MessageBoxButtons to the PopupWindow
                //#
                Button previousButton = null;

                // Create whichever other buttons bite me
                for (int i = 0; i < MessageBoxButtonText[(int)buttons].Length; i++)
                {
                    var buttonText = MessageBoxButtonText[(int)buttons][i];

                    var newButton = new Button()
                    {
                        Text = buttonText,
                        Name = $"{buttonText}Btn",
                        Size = TryAutosize(buttonText),
                        Tag = Array.IndexOf(ResultStrings, buttonText)
                    };
                    


                    // Event Handlers
                    newButton.Click += new EventHandler((sender, args) =>
                    {
                        DialogResult = (DialogResult) ((Button)sender).Tag;
                        Close();
                    });
                    newButton.MouseEnter += new EventHandler(Common.WindowBtnMH);
                    newButton.MouseLeave += new EventHandler(Common.WindowBtnML);


                    // Set the button position before adding it to the PopupWindow, and layering it above the window's main text box.
                    newButton.Location = getButtonOffset(previousButton, newButton, i, MessageBoxButtonText[(int)buttons].Length);
                    Controls.Add(newButton);
                    newButton.BringToFront();

                    previousButton = newButton;
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

            private readonly string[][] MessageBoxButtonText = new string[][]
            {
                 new [] { "OK" },
                 new [] { "OK", "Cancel" },
                 new [] { "Abort", "Retry", "Ignore" },
                 new [] { "Yes", "No", "Cancel" },
                 new [] { "Yes", "No" },
                 new [] { "Abort", "Cancel" },
            };
            
            private readonly string[] ResultStrings = new[]
            {
                "None",
                "OK",
                "Cancel",
                "Abort",
                "Retry",
                "Ignore",
                "Yes",
                "No"
            };
            #endregion






            //=================================\\
            //--|   Function Declarations   |--\\
            //=================================\\
            #region [Function Declarations]

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



            private Point getButtonOffset(Button previousButton, Button button, int buttonIndex, int buttonArrayLength)
            {
                var horiOffset = Size.Height - (Size.Height / 5);

                switch (buttonArrayLength)
                {
                    // One "OK" button
                    case 1:
                        return new Point((Size.Width / 2) - (button.Width / 2), horiOffset);
                            

                    // Two buttons
                    case 2 when buttonIndex == 0:
                        return new Point((Size.Width / 2) - button.Width, horiOffset);
                            
                    case 2 when buttonIndex == 1:
                        return new Point((Size.Width / 2) + 1, horiOffset);
                            

                    // Three buttons
                    case 3 when buttonIndex == 1: // Middle button ()
                        var newButtonPos = new Point((Size.Width / 2) - (button.Width / 2), horiOffset);

                        previousButton.Location = new Point(newButtonPos.X - button.Width, horiOffset);
                        return newButtonPos;
                            
                    case 3 when buttonIndex == 2: // Rightmost button
                        return new Point(previousButton.Location.X + previousButton.Width, horiOffset);


                    // Nani??
                    default:
                        Dev?.Print($"ERROR; {nameof(getButtonOffset)} was called {(buttonArrayLength == 0 ? "despite there not being any buttons" : $"with {buttonArrayLength} buttons expected")}!!!");
                        return Point.Empty;
                }
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
            private readonly Label MainLabel;
            private readonly Label separatorLine0;
            private readonly RichTextBox PopupMessageTextBox;
            #endregion
        }
    }
}
