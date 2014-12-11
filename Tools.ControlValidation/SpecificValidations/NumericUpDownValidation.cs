using System.Windows.Forms;

namespace Tools.ControlValidation
{
    /// <summary>
    /// Validations specific to <see cref="NumericUpDown"/> control. 
    /// Available through <see cref="ExtendedValidation{NumericUpDown}"/> as extension methods.
    /// </summary>
    public static class NumericUpDownValidation
    {
        /// <summary>
        /// Validates that <see cref="NumericUpDown"/> value is greater than given value.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="value">Value to compare.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<NumericUpDown> IsGreaterThan(
            this ExtendedValidation<NumericUpDown> val, decimal value)
        {
            val.IsValid = val.Control.Value > value;
            return val;
        }

        /// <summary>
        /// Validates that <see cref="NumericUpDown"/> value is equal or greater than given value.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="value">Value to compare.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<NumericUpDown> IsEqualOrGreaterThan(
            this ExtendedValidation<NumericUpDown> val, decimal value)
        {
            val.IsValid = val.Control.Value >= value;
            return val;
        }

        /// <summary>
        /// Validates that <see cref="NumericUpDown"/> value is less than given value.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="value">Value to compare.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<NumericUpDown> IsLessThan(
            this ExtendedValidation<NumericUpDown> val, decimal value)
        {
            val.IsValid = val.Control.Value < value;
            return val;
        }

        /// <summary>
        /// Validates that <see cref="NumericUpDown"/> value is equal or less than given value.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="value">Value to compare.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<NumericUpDown> IsEqualOrLessThan(
            this ExtendedValidation<NumericUpDown> val, decimal value)
        {
            val.IsValid = val.Control.Value <= value;
            return val;
        }

        /// <summary>
        /// Validates that <see cref="NumericUpDown"/> value is between given range of values.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="min">Min value to compare.</param>
        /// <param name="max">Min value to compare.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<NumericUpDown> IsBetween
            (this ExtendedValidation<NumericUpDown> val, decimal min, decimal max)
        {
            var numericCtrl = val.Control;
            val.IsValid = numericCtrl.Value >= min && numericCtrl.Value <= max;
            return val;
        }
    }
}
