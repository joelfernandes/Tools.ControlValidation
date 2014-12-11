using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Tools.ControlValidation;

namespace ControlValidationTests
{
    public partial class ExampleValidationForm : Form, IUIValidator
    {
        public readonly DateTime Birthdate = DateTime.ParseExact("1989-09-29", "yyyy-MM-dd", CultureInfo.InvariantCulture);

        public bool IsArmageddon { get { return _comboBox.SelectedItem != null && _comboBox.SelectedItem.ToString() == "Bring the Armageddon!"; } }

        public Validator Validator { get; private set; }

        public ExampleValidationForm()
        {
            InitializeComponent();
            Validator = new Validator(this);
        }

        private void ValidateAll()
        {
            ValidateTextBox();
            ValidateDateTimePicker();
            ValidateGroupBox();
            ValidateComboBox();
            ValidateCheckedListBox();
            ValidateCheckBox();
        }

        private void ValidateTextBox()
        {
            /*
             Rules: 
              1) Text is mandatory
              2) Minimum 20 characters
              3) Maximum 30 characters
              4) Must write "cool"
             */

            Validator.Validate(_textBox)
                .HasText()
                .DisplayOnError("Text is mandatory")
                .HasMinumTextLenght(20)
                .DisplayOnError("Minimum 20 characters")
                .HasMaximumTextLenght(30)
                .DisplayOnError("maximum 30 characters")
                .Other(tb => tb.Text.ToLowerInvariant().Contains("cool"))
                .DisplayOnError("Must write \"cool\"")
                .DisplayOnSuccess("TextBox: pass!");
        }

        public void ValidateDateTimePicker()
        {
            /*
             Rules: 
              1) You must guess my birthdate
              2) Answer is not in the future
              3) On error you get a hint
             */

            Validator.Validate(_dateTimePicker)
                .IsDateBeforeCurrent()
                .DisplayOnError("Answer is not in the future")
                .Other(dtp => dtp.Value.Date == Birthdate)
                .DisplayOnError("That's not my birthdate (check the form header)")
                .OnError(dtp => Text = "1989-09-29 [yyyy-MM-dd]")
                .DisplayOnSuccess("DateTimePicker: pass!");
        }

        private void ValidateGroupBox()
        {
            /*
             Rules: 
              1) Must say "Yes, yes! 
                  I want a new computer!"

            Rule breaker:
              a) You wrote "pirate" in the 
                   above TextBox. In this 
                   case being a pirate is fine.
             */

            Validator.Validate(_groupBox)
                .Other(gb => _radioButtonGoodBoy.Checked)
                .Unless(gb => _radioButtonPirateArgh.Checked && _textBox.Text.ToLowerInvariant().Contains("pirate"))
                .DisplayOnError("Must say \"Yes, yes! I want a new computer!\"")
                .DisplayOnSuccess(_radioButtonPirateArgh.Checked ? "Let's sail t' seas!" : "B good :)");
        }

        private void ValidateComboBox()
        {
            /* 
             Options:
             --------------
             Lisbon
             Beer & Pizza
             Pirate
             Kitten
             Bring the Armageddon!
             
             Rules: 
              1) Selection is mandatory
              2) Choose my favorite fruit
              3) Don't bring the armageddon
             */

            Validator.Validate(_comboBox)
                .HasSelection()
                .DisplayOnError("Selection is mandatory")
                .IsItemSelected("Beer & Pizza")
                .DisplayOnError(IsArmageddon ? "Why would you do that?" : "Nope, that's not my favorite fruit!")
                .OnError(cb =>
                {
                    if (IsArmageddon)
                    {
                        MessageBox.Show("You should not end the world like that!", 
                            "Do fear, for the end is near", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                })
                .DisplayOnSuccess("I really could use some fruit");
        }

        private void ValidateCheckedListBox()
        {
            /*
             Options:
             -------------
             Lorem ipsum dolor sit amet
             Arghhh, I'm a pirate!
             Chuck Norris Once sold eBay to eBay on eBay
             Humm! I love 3.14159265359
             There is no place like 127.0.0.1
             I solemnly swear that I am up to no good
             
             Rules: 
              1) Select your top 3 favorite 
                  citations from list
              2 ) Must include pie in selection
             */

            Validator.Validate(_checkedListBox)
                .HasMinimumSelectionCount(3)
                .DisplayOnError("Must select 3 citations from list")
                .IsItemSelected("Humm! I love 3.14159265359")
                .DisplayOnError("Must include pie in selection")
                .DisplayOnSuccess("Good choice");
        }

        private void ValidateCheckBox()
        {
            /*
             Rules: 
              1) Must comply with 
                  the biggest lie on the web
             */

            Validator.Validate(_checkBox)
                .IsChecked()
                .DisplayOnError("Must agree to the terms & conditions")
                .DisplayOnSuccess("Yes you agree :)");
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            ValidateAll();

            _buttonSubmit.Text = Validator.HasErrors ? "Submit" : "------------- All good -------------";
            _buttonSubmit.FlatAppearance.BorderColor = Validator.HasErrors ? Color.Red : Color.Green;
        }


    }
}
