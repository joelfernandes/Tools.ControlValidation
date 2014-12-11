using System;
using System.Windows.Forms;

namespace Tools.ControlValidation
{
    /// <summary>
    /// Validations specific to <see cref="MonthCalendar"/> control. 
    /// Available through <see cref="ExtendedValidation{MonthCalendar}"/> as extension methods.
    /// </summary>
    public static class MonthCalendarValidation
    {
        /// <summary>
        /// Validates whether the selected date is before current datetime or not.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<MonthCalendar> IsDateBeforeCurrent(this ExtendedValidation<MonthCalendar> val)
        {
            return IsDateBefore(val, DateTime.Now);
        }
        /// <summary>
        /// Validates whether the selected date is before provided date.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="date">Date to validate against (will be parsed using Datetime.Parse() method).</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<MonthCalendar> IsDateBefore(this ExtendedValidation<MonthCalendar> val, string date)
        {
            val.IsValid = val.Control.SelectionStart < DateTime.Parse(date);
            return val;
        }
        /// <summary>
        /// Validates whether the selected date is before provided date or not.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="date">Date to validate against.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<MonthCalendar> IsDateBefore(this ExtendedValidation<MonthCalendar> val, DateTime date)
        {
            val.IsValid = val.Control.SelectionStart < date;
            return val;
        }

        /// <summary>
        /// Validates whether the selected date is after current datetime or not.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<MonthCalendar> IsDateAfterCurrent(this ExtendedValidation<MonthCalendar> val)
        {
            return IsDateAfter(val, DateTime.Now);
        }
        /// <summary>
        /// Validates whether the selected date is after provided date or not.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="date">Date to validate against (will be parsed using Datetime.Parse() method).</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<MonthCalendar> IsDateAfter(this ExtendedValidation<MonthCalendar> val, string date)
        {
            val.IsValid = val.Control.SelectionStart > DateTime.Parse(date);
            return val;
        }
        /// <summary>
        /// Validates whether the selected date is after provided date or not.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="date">Date to validate against.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<MonthCalendar> IsDateAfter(this ExtendedValidation<MonthCalendar> val, DateTime date)
        {
            val.IsValid = val.Control.SelectionStart > date;
            return val;
        }

        /// <summary>
        /// Validates whether the selected date is between two provided dates or not.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="minimumDate">Minimum date to validate against.</param>
        /// <param name="maximumDate">Maximum date to validate against.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<MonthCalendar> IsDateBetween(this ExtendedValidation<MonthCalendar> val, 
            DateTime minimumDate, DateTime maximumDate)
        {
            var date = val.Control.SelectionStart;
            val.IsValid = date > minimumDate && date < maximumDate;
            return val;
        }
        /// <summary>
        /// Validates whether the selected date is between two provided dates or not.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="minimumDate">Minimum date to validate against (will be parsed using Datetime.Parse() method).</param>
        /// <param name="maximumDate">Maximum date to validate against (will be parsed using Datetime.Parse() method).</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<MonthCalendar> IsDateBetween(this ExtendedValidation<MonthCalendar> val,
            string minimumDate, string maximumDate)
        {
            var date = val.Control.SelectionStart;
            val.IsValid = date > DateTime.Parse(minimumDate) && date < DateTime.Parse(maximumDate);
            return val;
        }

    }
}
