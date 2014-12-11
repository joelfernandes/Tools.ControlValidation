using System.Windows.Forms;

namespace Tools.ControlValidation
{
    /// <summary>
    /// Validations specific to <see cref="ListBox"/> control. 
    /// Available through <see cref="ExtendedValidation{ListBox}"/> as extension methods.
    /// </summary>
    public static class ListBoxValidation
    {
        /// <summary>
        /// Validates that the <see cref="ListBox"/> has at least one selected Item.
        /// </summary>
        /// <param name="val">This validation</param>
        /// <returns>Updated Validation.</returns>
        public static ExtendedValidation<ListBox> IsAnyItemSelected(this ExtendedValidation<ListBox> val)
        {
            val.IsValid = val.Control.SelectedIndices.Count > 0;
            return val;
        }

    }
}
