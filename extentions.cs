using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dobby
{
    
    //=====================================\\
    //---|   Custom Class Extensions   |---\\
    //=====================================\\
    #region [Custom Class Extensions]
    


    /// <summary>
    /// Custom Button Class extention so I can attach a value to them. (saving the Tag property for hint text later on)
    /// </summary>
    public class Button : System.Windows.Forms.Button
    {
        /// <summary> Initialize a new instance of the Dobby.Button class extention. </summary>
        public Button()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.FromArgb(100, 100, 100);

            Font = new Font("Cambria", 9.25F, FontStyle.Bold);
            Cursor = Cursors.Cross;


            //Variable = null;
            VariableTags = null;
            hasEvents = false;
            

            MouseDown += (sender, _) => ForeColor = Color.FromArgb(255, 227, 0);
            MouseUp += (sender, _) => ForeColor = Color.FromArgb(255, 255, 255);
        }



        //#
        //## Variable Declarations
        //#

        /// <summary>
        /// Custom value associated with the control to be rendered alongside it, and edited via manually assigned per-control events.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // Designer autogenerates code settings the Variable & VariableTags properties to null, annoyingly. More of an issue for the former though, due to the Properties window not letting you edit objects
        [TypeConverter(typeof(BooleanConverter))]
        //[DefaultValue(false)]
        public object Variable
        {
            get => _Variable;

            set {
                if (value != null && value.ToString().Length > 0)
                {
                    _Variable = value;
                    this.ResetFlagsandPaint();

                    if (!hasEvents) {
                        Paint += DrawButtonVariable;

                        MouseDown += (eugh, meh) => SavePreInputVariable(Variable);
                        MouseUp += CycleButtonVariable;
                        MouseWheel += CycleButtonVariable;

                        hasEvents = true;
                    }
                }
                else {
                    if (hasEvents) {
                        Paint -= DrawButtonVariable;

                        MouseDown -= (eugh, meh) => SavePreInputVariable(Variable);
                        MouseUp -= CycleButtonVariable;
                        MouseWheel -= CycleButtonVariable;
                        
                        hasEvents = false;
                    }

                    _Variable = value;
                }
            }
        }
        private object _Variable;
        private object _preInputvariable;


        /// <summary>
        /// An Array of names to display in place of basic values.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        public string[] VariableTags;



        /// <summary>
        /// //! Write a fuckin' summary, dicksneeze.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object MinimumValue
        {
            get => minValue;

            set {
                if (value != null)
                {
                    if (MaximumValue != null)
                    {
                        if (!value.GetType().Equals(MaximumValue.GetType()))
                        {
                            Common.Dev?.Print($"ERROR: Mismatch in {Name} Min/Max Value Types. (Min: {MinimumValue.GetType()} && Max: {MaximumValue.GetType()})");
                        }
                    }

                    if (Variable != null)
                    {
                        if (!value.GetType().Equals(Variable.GetType()))
                        {
                            Common.Dev?.Print($"ERROR: Mismatch in {Name} MinimumValue and Variable Types. (Min: {MinimumValue.GetType()} && Variable: {Variable.GetType()})");
                        }
                    }
                }

                minValue = value;
            }
        }
        private object minValue;


        
        /// <summary>
        /// //! Write a fuckin' summary, dicksneeze.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object MaximumValue
        {
            get => maxValue;

            set {
                if (value != null)
                {
                    if (MinimumValue != null)
                    {
                        if (!value.GetType().Equals(MinimumValue.GetType()))
                        {
                            Common.Dev?.Print($"ERROR: Mismatch in {Name} Min/Max Value Types. (Min: {MinimumValue.GetType()} && Max: {MaximumValue.GetType()})");
                        }
                    }

                    if (Variable != null)
                    {
                        if (!value.GetType().Equals(Variable.GetType()))
                        {
                            Common.Dev?.Print($"ERROR: Mismatch in {Name} MaximumValue and Variable Types. (Max: {MaximumValue.GetType()} && Variable: {Variable.GetType()})");
                        }
                    }
                }

                maxValue = value;
            }
        }
        private object maxValue;


        private bool hasEvents; // Lazy Fix




        //#
        //## Function Declarations
        //#
        
        private void SavePreInputVariable(object variable)
        {
            _preInputvariable = variable;
        }

        private float _inc;
        private float inc
        {
            get => _inc;

            set
            {
                _inc = value;
            }
        }

        /// <summary>
        /// Toggle between various states of custom Button controls
        /// </summary>
        /// <param name="sender"> The control to edit the variable of. </param>
        private void CycleButtonVariable(object sender, MouseEventArgs eventArgs)
        {
            var type = Variable?.GetType();
            inc = 1f;


            // Not entirely certain this is actually required anymore
            if (((Control)sender) != Common.HoveredControl)
            {
                Common.Dev?.Print("CycleButtonVariable(): Control changed, aborting variable cycling.");
                return;
            }



            // Check for null variable / type.                (not that I know how the latter would be null without the former being null as well, rendering the following check redundant... meh, I'm leaving both checks anyway)
            if (Variable == null) {
                Common.Dev?.Print("CycleButtonVariable(): Control's variable type was somehow null (wtf??), fix your trash.");
                return;
            }
            if (type == null) {
                Common.Dev?.Print("CycleButtonVariable(): Control's variable was null, fix your trash.");
                return;
            }

            // Reimplement this properly after sleeping lmao
            if (MaximumValue != null || MinimumValue != null)
            {
                if (MaximumValue == null)
                {
                    Common.Dev?.Print("CycleButtonVariable(): No Maximum value provided to go with minumum, you didn't write the code below to account for that, dumbass. Aborting");
                    return;
                }

                if (MinimumValue == null)
                {
                    Common.Dev?.Print("No minimum value provided to go with maximum, defaulting it to 0.");
                    MinimumValue = 0;
                }
            }



            // Avoid incrementing options on MouseUp events when the scroll wheel was already used
            if (Variable != _preInputvariable && eventArgs.GetType().Name != "HandledMouseEventArgs")
            {
                Common.Dev?.Print("Variable has been scrolled, avoiding click incrementation");
                return;
            }



            // Skip number-related checks for boolean values
            if (type == typeof(bool))
                goto skipNumericalChecksForBooleans;


            // Assign the value that the control's variable is to be incremented by
            if (eventArgs.Delta != 0)
            {
                // 
                if (type == typeof(float))
                {
                    inc = eventArgs.Delta / 1200.0f;
                }
                if (type == typeof(int) || type == typeof(byte))
                {
                    inc = eventArgs.Delta / 120;

                }

                // Modify the incrementation value if the mouse is being held down
                if (Common.MouseIsDown)
                {
                    // Reduce it to a tenth
                    if (Common.ActiveMouseButton == MouseButtons.Right) {
                        inc *= .1f;
                    }
                    // Multiply it tenfold
                    else {
                        inc *= 10.0f;
                    }
                }
            }
            // Set the incrementation value for a mouse click depending on the button variable's type
            else
            {
                if (type == typeof(float))
                {
                    inc = 0.10f;
                }
                if (type == typeof(int) || type == typeof(byte))
                {
                    inc = 5;

                }


                if (eventArgs.Button == MouseButtons.Right) {
                    inc = -inc;
                }
            }



            //#
            //## Booleans (default)
            //#
            skipNumericalChecksForBooleans:
            if (type == typeof(bool))
            {
                if (MaximumValue != null)
                    Common.Dev?.Print("WARNING: A maximum value was for some reason provided for a button with a boolean variable attached");

                Variable = !(bool) Variable;
                return;
            }


            
            //#
            //## Integers
            //#
            if (type == typeof(int))
            {
                if (MaximumValue == null)
                {
                    Variable = (int) ((int)Variable + inc);
                }
                else {
                    // avoid going out of bounds in the VariableTags array
                    if (VariableTags.Length < (long)MaximumValue)
                    {
                        MaximumValue = VariableTags.Length;
                        Common.Dev?.Print($"ERROR: Maximum value for control Variable was larger than the amount of provided VariableTags; lowered maxValue to [{MaximumValue}]");
                    }

                    if (MaximumValue.Equals(Variable))
                    {
                        Variable = MinimumValue ?? 0;
                    }

                }

                return;
            }


            
            //#
            //## Bytes
            //#
            if (type == typeof(byte))
            {
                // Avoid going out of bounds in the VariableTags array
                if (MaximumValue != null && VariableTags?.Length < (byte)MaximumValue)
                {
                    MaximumValue = VariableTags.Length;
                    Common.Dev?.Print($"ERROR: Maximum value for control Variable was larger than the amount of provided VariableTags; lowered maxValue to [{MaximumValue}]");
                }



                // Increment control variable value
                Variable = (byte) ((byte)Variable + inc);
                
                #if DEBUG
                if (MaximumValue != null || MinimumValue != null)
                {
                    if (MaximumValue != null && (byte)MaximumValue < (byte)Variable)
                    {
                        Variable = (byte)(MinimumValue ?? (byte)Variable - inc);
                    }

                    else if (MinimumValue != null && (byte)MinimumValue > (byte)Variable)
                    {
                        Variable = (byte)(MaximumValue ?? (byte)Variable - inc);
                    }
                }
                else
                #endif
                if ((byte)((byte)Variable + inc - 1) <= (byte)Variable && 1 + inc > 0) //! this is hideous, get sleep and fucking fix it, jeez
                {
                    Variable = (byte)0;
                }
                else if ((byte)((byte)Variable + inc + 1) >= (byte)Variable && 1 + inc < 0)
                {
                    Variable = (byte)255;
                }

            }


            
            
            //#
            //## Floating-Points
            //#
            if (type == typeof(float))
            {
                Variable = (float) Math.Round((float)Variable + inc, 3);

                if (MaximumValue != null || MinimumValue != null)
                {
                    if ((float)Variable > (float)MaximumValue)
                    {
                        Variable = (float) Math.Round((float)(MinimumValue ?? 0), 2);
                    }

                    else if ((float)Variable < (float)MinimumValue)
                    {
                        Variable = (float) Math.Round((float)(MaximumValue ?? 10), 2);
                    }
                }
            }
        }




        /// <summary>
        /// Draw the string representation of the Dobby.Button's Variable property to the right of the control text.
        ///</summary>
        private void DrawButtonVariable(object item, PaintEventArgs paintEvent)
        {
            // Convert control to avoid constant casting
            var control = item as Dobby.Button;
            string variableText = null;
            var padding = 5; // distance from the right-most bounds of the control to the start of the control's Text (at least, seems to be for the font and size most of the buttons are using)


            float
                controlTextSize = paintEvent.Graphics.MeasureString(control.Text, control.Font).Width,
                variableSize,
                expectedSize,
                baseContentSize
            ;


            // Check for stupidity.
            if (control.Variable == null) {
                Common.Dev?.Print($"!! ERROR: Variable property for control \"{control.Name}\" was null");
                return;
            }

            
            

            //#
            //## Boolean
            //#
            if (control.Variable.GetType() == typeof(bool))
            {
                if (control.VariableTags != null)
                {
                    if (control.VariableTags.Length > 2)
                        Common.Dev?.Print($"WARNING: Invalid VariableTags array provided for boolean toggle; ignoring [{control.VariableTags.Length-2}] tag(s)");
                    
                    if (control.VariableTags.Length < 2)
                        Common.Dev?.Print($"ERROR: Invalid VariableTags array provided for boolean toggle; less than two options provided ({control.VariableTags.Length})"); // output tag array length in case it's somehow negative, I suppose

                    else
                        variableText = control.VariableTags[(bool)control.Variable ? 1 : 0];
                    
                }
                else {
                    variableText = (bool) control.Variable ? "Yes" : "No";
                }
            }

            
            //#
            //## Integer
            //#
            if (control.Variable.GetType() == typeof(int) || control.Variable.GetType() == typeof(byte))
            {
                if (control.VariableTags != null)
                {
                    if (control.VariableTags.Length > (int)control.Variable)
                        Common.Dev?.Print($"WARNING: Invalid VariableTags array provided for boolean toggle; ignoring [{control.VariableTags.Length-2}] tag(s)");
                    
                    else if (control.VariableTags.Length < (int)control.Variable)
                        Common.Dev?.Print($"ERROR: Invalid VariableTags array provided for boolean toggle; less than two options provided ({control.VariableTags.Length})"); // output tag array length in case it's somehow negative, I suppose

                    variableText = control.VariableTags[(int)control.Variable];
                    
                }
                else {
                    variableText = control.Variable.ToString();
                }
            }
            
            //#
            //## Floating-Points
            //#
            if (control.Variable.GetType() == typeof(float) || control.Variable.GetType() == typeof(double))
            {
                if (control.VariableTags != null)
                {
                    Common.Dev?.Print("WARNING: variable tags provided for floating-point button variable, cannot use a floating-point as array index. (obviously)");
                    return;
                }

                variableText = control.Variable.ToString();
            }


            //#
            //## Unexpected formats
            //#
            if (variableText == null)
            {
                Common.Dev?.Print($"WARNING: An unexpected data type was provided for the Variable tied to control \"{control.Name}\". Using unformatted string representation. (Type: {control.Variable.GetType()})");
                variableText = $"{(control.Variable ?? (object) "null")}";
            }




            // Design-related bits //!
            variableSize = paintEvent.Graphics.MeasureString(variableText, control.Font).Width;
            baseContentSize = controlTextSize + padding;
            expectedSize = baseContentSize + variableSize + (padding * 2);

            if (expectedSize != control.Width)
            {
                control.Width = (int) expectedSize - 1;
            }
            


            // Draw the Variable's string representation appended to the control's text (visually)
            paintEvent.Graphics.DrawString(variableText, Common.SmallControlFont, Brushes.LightGreen, new Point((int) baseContentSize + (padding * 2), 5));
        }

    }

    
    public class Label : System.Windows.Forms.Label
    {
        public bool IsSeparatorLine
        {
            get => _isSeparatorLine;
            set => _isSeparatorLine = value;
        }
        private bool _isSeparatorLine = false;


        public bool StretchToFitForm
        {
            get => _stretchToFitForm & IsSeparatorLine;
            set => _stretchToFitForm = value;
        }
        private bool _stretchToFitForm = false;
    }

    
    /// <summary> Custom TextBox Class to Better Handle Default TextBox Contents. </summary>
    public class TextBox : System.Windows.Forms.TextBox
    {
        /// <summary> Create New Control Instance. </summary>
        public TextBox()
        {
            TextChanged += SetDefaultText; // Save the first Text assignment as the DefaultText

            GotFocus += (sender, args) => ReadyControl();
            LostFocus += (sender, args) => ResetControl(false); // Reset control if nothing was entered, or the text is a portion of the default text
        }




        // Default Control Text to Be Displayed When "Empty".
        private string DefaultText;




        // Help Better Keep Track of Whether the User's Changed the Text, Because I'm a Moron.
        public bool IsDefault() => Text == DefaultText;

        /// <summary> Yoink Default Text From First Text Assignment (Ideally right after being created). </summary>
        private void SetDefaultText(object _, EventArgs __)
        {
            DefaultText = Text;
            Font = Common.DefaultTextFont;

            TextChanged -= SetDefaultText;

            TextChanged += (control, args) => Text = Text?.Replace("\"", string.Empty);
        }


        private void ReadyControl()
        {
            if(IsDefault()) {
                Clear();

                Font = Common.TextFont;
            }
        }

        public void Reset() => ResetControl(true);
        private void ResetControl(bool forceReset)
        {
            if(Text.Length < 1 || DefaultText.Contains(Text) || forceReset)
            {
                Text = DefaultText;
                Font = Common.DefaultTextFont;
            }
        }


        /// <summary> Set Control Text and State Properly (meh). </summary>
        public void Set(string text)
        {
            if (text != string.Empty && !DefaultText.Contains(text))
            {   
                Text = text;
                Font = Common.TextFont;
            }
        }
    }
    


    /// <summary>
    /// Custom RichTextBox class because bite me.
    /// </summary>
    public class RichTextBox : System.Windows.Forms.RichTextBox {

        /// <summary> Appends Text to The Currrent Text of A Text Box, Followed By The Standard Line Terminator.<br/>Scrolls To Keep The Newest Line In View. </summary>
        /// <param name="str"> The String To Output. </param>
        public void AppendLine(string str = "", bool scroll = true)
        {
            AppendText(str + '\n');
            Update();
                
            if (scroll) {
                ScrollToCaret();
            }
        }



        public void UpdateLine(string newMsg, int line, bool scroll = true)
        {
            while (line >= Lines.Length)
            {
                AppendText("\n");
            }

            var lines = Lines;
            lines[line] = newMsg ?? " ";

            Lines = lines;
            Update();

            if (scroll) {
                ScrollToCaret();
            }
        }
    }
    #endregion [Class Extensions]
}
