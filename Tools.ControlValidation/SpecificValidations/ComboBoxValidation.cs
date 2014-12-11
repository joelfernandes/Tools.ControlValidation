using System.Windows.Forms;

namespace Tools.ControlValidation
{
    /// <summary>
    /// Validations specific to <see cref="ComboBox"/> control. 
    /// Available through <see cref="ExtendedValidation{ComboBox}"/> as extension methods.
    /// </summary>
    public static class ComboBoxValidation
    {
        /// <summary>
        /// Validates that at least one CheckBox is checked.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<ComboBox> HasSelection(this ExtendedValidation<ComboBox> val)
        {
            val.IsValid = val.Control.SelectedIndex >= 0;
            return val;
        }

        /// <summary>
        /// Validates that <paramref name="item"/> object has its corresponding CheckBox checked.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="item">Object to validate for selection.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<ComboBox> IsItemSelected(this ExtendedValidation<ComboBox> val, object item)
        {
            val.IsValid = val.Control.SelectedIndex >= 0 && val.Control.SelectedItem.Equals(item);
            return val;
        }

    }
}
