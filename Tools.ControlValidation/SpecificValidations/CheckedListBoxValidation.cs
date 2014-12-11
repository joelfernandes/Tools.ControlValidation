using System.Windows.Forms;

namespace Tools.ControlValidation
{
    /// <summary>
    /// Validations specific to <see cref="CheckedListBox"/> control. 
    /// Available through <see cref="ExtendedValidation{CheckedListBox}"/> as extension methods.
    /// </summary>
    public static class CheckedListBoxValidation
    {
        /// <summary>
        /// Validates that at least one CheckBox is checked.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<CheckedListBox> IsAtLeastOneCheckedItem(this ExtendedValidation<CheckedListBox> val)
        {
            val.IsValid = val.Control.CheckedIndices.Count >= 1;
            return val;
        }

        /// <summary>
        /// Validates that every CheckBox item is checked.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<CheckedListBox> AreAllItemsSelected(this ExtendedValidation<CheckedListBox> val)
        {
            val.IsValid = val.Control.CheckedIndices.Count == val.Control.Items.Count;
            return val;
        }

        /// <summary>
        /// Validates that at least <paramref name="count"/> CheckBoxes are checked.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="count">Number of checked checkboxes to validate.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<CheckedListBox> HasMinimumSelectionCount(this ExtendedValidation<CheckedListBox> val, int count)
        {
            val.IsValid = val.Control.CheckedIndices.Count >= count;
            return val;
        }

        /// <summary>
        /// Validates that <paramref name="item"/> object has its corresponding CheckBox checked.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="item">Object to validate for selection.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<CheckedListBox> IsItemSelected(this ExtendedValidation<CheckedListBox> val, object item)
        {
            val.IsValid = val.Control.CheckedIndices.Count > 0 && val.Control.CheckedItems.Contains(item);
            return val;
        }

    }
}
