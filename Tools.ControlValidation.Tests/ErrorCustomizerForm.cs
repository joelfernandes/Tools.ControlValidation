using System;
using System.Linq;
using System.Windows.Forms;

namespace Tools.ControlValidation.Tests
{
    public partial class ErrorCustomizerForm : Form, IUIValidator
    {
        private string _error = "I said not to click me";

        public Validator Validator { get; private set; }

        public ErrorCustomizerForm()
        {
            InitializeComponent();
            Validator = new Validator(this);

            _buttonChangeError.Click += (sender, e) => _error += "!";

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

            var errorBlinkStyle = (ErrorBlinkStyle)_comboBoxBlinkStyle.SelectedItem;
            var blinkRate = (int)_numericUpDownBlinkRate.Value;

            Validator.Start(_buttonTest)
                .Align((ErrorIconAlignment)_comboBoxErrorAlign.SelectedItem)  // Add an alignment to the provider of this control according to UI value
                .Pad((int)_numericUpDownPadding.Value)                        // Add a padding to the provider of this control according to UI value
                .Blink(errorBlinkStyle, blinkRate)
                .Fail(_error);                                                 // Just add the error icon. No need to call End().

            Validator.Start(_labelBadass)
                .Pass("Achievement: badass");                                 // No validation is performed, just add the success icon and message. No need to call End()
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
