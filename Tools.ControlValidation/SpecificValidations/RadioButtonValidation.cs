using System.Linq;
using System.Windows.Forms;

namespace Tools.ControlValidation
{
    /// <summary>
    /// Validations specific to <see cref="RadioButton"/> control. 
    /// Available through <see cref="ExtendedValidation{RadioButton}"/> as extension methods.
    /// </summary>
    public static class RadioButtonValidation
    {
        /// <summary>
        /// Validates that <see cref="RadioButton"/> is checked.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<RadioButton> IsChecked(this ExtendedValidation<RadioButton> val)
        {
            val.IsValid = val.Control.Checked;
            return val;
        }

        /// <summary>
        /// Validates that any <see cref="RadioButton"/> from same container (group) is checked.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<RadioButton> IsAnyCheckedFromSameGroup(this ExtendedValidation<RadioButton> val)
        {
            // Parent should be a container - group box, panel, etc.
            val.IsValid = val.Control.Parent.Controls.OfType<RadioButton>().Any(x => x.Checked);
            return val;
        }

    }
}
