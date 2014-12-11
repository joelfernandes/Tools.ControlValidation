using System;
using System.Windows.Forms;

namespace Tools.ControlValidation
{
    /// <summary>
    /// Validations specific to <see cref="DateTimePicker"/> control. 
    /// Available through <see cref="ExtendedValidation{DateTimePicker}"/> as extension methods.
    /// </summary>
    public static class DateTimePickerValidation
    {
        /// <summary>
        /// Validates if the selected date is before current datetime.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<DateTimePicker> IsDateBeforeCurrent(this ExtendedValidation<DateTimePicker> val)
        {
            return IsDateBefore(val, DateTime.Now);
        }
        /// <summary>
        /// Validates if the selected date is before provided date.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="date">Date to validate against (will be parsed using Datetime.Parse() method)</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<DateTimePicker> IsDateBefore(this ExtendedValidation<DateTimePicker> val, string date)
        {
            val.IsValid = val.Control.Value < DateTime.Parse(date);
            return val;
        }
        /// <summary>
        /// Validates if the selected date is before provided date.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="date">Date to validate against</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<DateTimePicker> IsDateBefore(this ExtendedValidation<DateTimePicker> val, DateTime date)
        {
            val.IsValid = val.Control.Value < date;
            return val;
        }

        /// <summary>
        /// Validates if the selected date is after current datetime.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<DateTimePicker> IsDateAfterCurrent(this ExtendedValidation<DateTimePicker> val)
        {
            return IsDateAfter(val, DateTime.Now);
        }
        /// <summary>
        /// Validates if the selected date is after provided date.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="date">Date to validate against (will be parsed using Datetime.Parse() method)</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<DateTimePicker> IsDateAfter(this ExtendedValidation<DateTimePicker> val, string date)
        {
            val.IsValid = val.Control.Value > DateTime.Parse(date);
            return val;
        }
        /// <summary>
        /// Validates if the selected date is after provided date.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="date">Date to validate against</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<DateTimePicker> IsDateAfter(this ExtendedValidation<DateTimePicker> val, DateTime date)
        {
            val.IsValid = val.Control.Value > date;
            return val;
        }

        /// <summary>
        /// Validates if the selected date is between two provided dates.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="minimumDate">Minimum date to validate against </param>
        /// <param name="maximumDate">Maximum date to validate against </param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<DateTimePicker> IsDateBetween(this ExtendedValidation<DateTimePicker> val, 
            DateTime minimumDate, DateTime maximumDate)
        {
            var date = val.Control.Value;
            val.IsValid = date > minimumDate && date < maximumDate;
            return val;
        }
        /// <summary>
        /// Validates if the selected date is between two provided dates.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="minimumDate">Minimum date to validate against (will be parsed using Datetime.Parse() method)</param>
        /// <param name="maximumDate">Maximum date to validate against (will be parsed using Datetime.Parse() method)</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<DateTimePicker> IsDateBetween(this ExtendedValidation<DateTimePicker> val,
            string minimumDate, string maximumDate)
        {
            var date = val.Control.Value;
            val.IsValid = date > DateTime.Parse(minimumDate) && date < DateTime.Parse(maximumDate);
            return val;
        }

    }
}
