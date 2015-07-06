using System;
using System.Windows.Forms;

namespace Tools.ControlValidation.Tests
{
    public partial class ValidatorTestForm : Form
    {
        public ValidatorTestForm()
        {
            InitializeComponent();
        }

        private void ButtonExamplesOnDemand_Click(object sender, EventArgs e)
        {
            using (var form = new OnDemanExampleValidationForm())
            {
                form.ShowDialog();
            }
        }

        private void ButtonExamples_Click(object sender, EventArgs e)
        {
            using (var form = new ExampleValidationForm())
            {
                form.ShowDialog();
            }
        }

        private void ButtonCustomizeError_Click(object sender, EventArgs e)
        {
            using (var form = new ErrorCustomizerForm())
            {
                form.ShowDialog();
            }
        }
    }

}
