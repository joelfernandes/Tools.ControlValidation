using System.Linq;
using System.Windows.Forms;

namespace Tools.ControlValidation
{
    /// <summary>
    /// Validations specific to <see cref="CheckBox"/> control. 
    /// Available through <see cref="ExtendedValidation{CheckBox}"/> as extension methods.
    /// </summary>
    public static class CheckBoxValidation
    {
        /// <summary>
        /// Validates that <see cref="CheckBox"/> is checked.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<CheckBox> IsChecked(this ExtendedValidation<CheckBox> val)
        {
            val.IsValid = val.Control.Checked;
            return val;
        }

        /// <summary>
        /// Validates that any <see cref="CheckBox"/> from same container (group) is checked.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<CheckBox> IsAnyCheckedFromSameGroup(this ExtendedValidation<CheckBox> val)
        {
            // Parent should be a container - group box, panel, etc.
            val.IsValid = val.Control.Parent.Controls.OfType<CheckBox>().Any(x => x.Checked);
            return val;
        }
    }
}
