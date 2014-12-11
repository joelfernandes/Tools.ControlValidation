using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Tools.ControlValidation
{
    /// <summary>
    /// Validations specific to <see cref="TextBox"/> control. 
    /// Available through <see cref="ExtendedValidation{TextBox}"/> as extension methods.
    /// </summary>
    public static class TextBoxValidation
    {
        /// <summary>
        /// Check whether the text contains only letters or not.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<TextBox> ContainsTextOnly(this ExtendedValidation<TextBox> val)
        {
            val.IsValid = val.Control.Text.All(x => Char.IsLetter(x));
            return val;
        }

        /// <summary>
        /// Validate the text against a given regex pattern.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="regex">The pattern to validate text against.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<TextBox> IsRegexMatch(this ExtendedValidation<TextBox> val, string regex)
        {
            val.IsValid = Regex.IsMatch(val.Control.Text, regex);
            return val;
        }
        /// <summary>
        /// Validate the text against a given pattern.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="regex">The pattern to validate text against.</param>
        /// <param name="regexOptions">Regex options.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<TextBox> IsRegexMatch(this ExtendedValidation<TextBox> val, string regex,
            RegexOptions regexOptions)
        {
            string text = val.Control.Text;
            val.IsValid = Regex.IsMatch(text, regex, regexOptions);
            return val;
        }

        /// <summary>
        /// Validate whether the lenght of this text is at least <paramref name="minLenghtInclusive"/> characters or not.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="minLenghtInclusive">Minimum allowed characters.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<TextBox> HasMinumTextLenght(this ExtendedValidation<TextBox> val,
            int minLenghtInclusive)
        {
            val.IsValid = val.Control.Text.Length >= minLenghtInclusive;
            return val;
        }

        /// <summary>
        /// Validate whether the lenght of this text is at most <paramref name="maxLenghtInclusive"/> characters or not.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="maxLenghtInclusive">Minimum allowed characters.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<TextBox> HasMaximumTextLenght(this ExtendedValidation<TextBox> val,
            int maxLenghtInclusive)
        {
            val.IsValid = val.Control.Text.Length <= maxLenghtInclusive;
            return val;
        }

        /// <summary>
        /// Validate whether the lenght of this text is at least <paramref name="minLenghtInclusive"/>
        /// characters and at most <paramref name="maxLenghtInclusive"/> characters or not.
        /// </summary>
        /// <param name="val">This validation.</param>
        /// <param name="minLenghtInclusive">Maximum allowed characters.</param>
        /// <param name="maxLenghtInclusive">Minimum allowed characters.</param>
        /// <returns>Updated validation.</returns>
        public static ExtendedValidation<TextBox> HasTextLenghtBetween(this ExtendedValidation<TextBox> val,
             int minLenghtInclusive, int maxLenghtInclusive)
        {
            int lenght = val.Control.Text.Length;
            val.IsValid = lenght >= minLenghtInclusive && lenght <= maxLenghtInclusive;
            return val;
        }

    }

}
