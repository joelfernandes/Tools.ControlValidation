using System;
using System.Linq;
using System.Windows.Forms;
using Tools.ControlValidation;

namespace ControlValidationTests
{
    public partial class ErrorCustomizerForm : Form, IUIValidator
    {
        public Validator Validator { get; private set; }

        public ErrorCustomizerForm()
        {
            InitializeComponent();
            Validator = new Validator(this);

            // Populate icon alignment combobox
            _comboBoxErrorAlign.DataSource = Enum.GetValues(typeof(ErrorIconAlignment)).Cast<ErrorIconAlignment>(); 
            _comboBoxErrorAlign.SelectedItem = ErrorIconAlignment.MiddleRight;

            // Populate blink styles combobox
            _comboBoxBlinkStyle.DataSource = Enum.GetValues(typeof(ErrorBlinkStyle)).Cast<ErrorBlinkStyle>(); 
            _comboBoxBlinkStyle.SelectedItem = ErrorBlinkStyle.NeverBlink;

            // When selection changes, enable or disable blink rate input based on selected item.
            _comboBoxBlinkStyle.SelectedIndexChanged += (sender, e) =>
            {
                _numericUpDownBlinkRate.Enabled = ((ErrorBlinkStyle)_comboBoxBlinkStyle.SelectedItem) != ErrorBlinkStyle.NeverBlink;
            };
        }

        private void ButtonTest_Click(object sender, EventArgs e)
        {
            if (!_labelBadass.Visible)
                _labelBadass.Visible = true;

            // Following two lines affect ALL control validations (cannot be customized per validation).
            // Usually I place them at the beginning of the program execution (they are here for demo purposes).
            Validation.GeneralBlinkRate = (int)_numericUpDownBlinkRate.Value;
            Validation.GeneralBlinkStyle = (ErrorBlinkStyle)_comboBoxBlinkStyle.SelectedItem;
            
            Validator.Validate(_buttonTest)
                .Fail("I said not to click me")                               // Just add the error icon
                .Align((ErrorIconAlignment)_comboBoxErrorAlign.SelectedItem)  // Add an alignment to the provider of this control according to UI value
                .Pad((int)_numericUpDownPadding.Value);                       // Add a padding to the provider of this control according to UI value

            Validator.Validate(_labelBadass)
                .DisplayOnSuccess("Achievement: badass");                     // No validation is performed, just add the success icon and message
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                _buttonTest.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }

}
