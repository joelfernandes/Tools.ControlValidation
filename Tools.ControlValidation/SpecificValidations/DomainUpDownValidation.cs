using System.Windows.Forms;

namespace Tools.ControlValidation
{
    /// <summary>
    /// Validations specific to <see cref="DomainUpDown"/> control. 
    /// Available through <see cref="ExtendedValidation{DomainUpDown}"/> as extension methods.
    /// </summary>
    public static class DomainUpDownValidation
    {
        /// <summary>
        /// Validates that this <see cref="DomainUpDown"/> has a selected Item.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<DomainUpDown> HasSelection(this ExtendedValidation<DomainUpDown> val)
        {
            val.IsValid = val.Control.SelectedIndex != -1;
            return val;
        }

    }
}
