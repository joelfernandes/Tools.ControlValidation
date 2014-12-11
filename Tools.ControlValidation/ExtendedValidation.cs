using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Tools.ControlValidation
{
    /// <summary>
    /// An extended validation object that presents success/error icons and provides validation capabilities.
    /// </summary>
    public class ExtendedValidation<T> : Validation where T : Control
    {
        /// <summary>
        /// Gets the control being validated.
        /// </summary>
        public new T Control { get { return (T)base.Control; } }

        /// <summary>
        /// Create an extended validation object for given control.
        /// </summary>
        /// <param name="control">control to validate.</param>
        /// <param name="errorProvider">Error provider to display error messages.</param>
        /// <param name="successProvider">Error provider to display success messages.</param>
        /// <param name="optional">Whether this validation is optional or not.</param>
        public ExtendedValidation(Control control, ErrorProvider errorProvider,
            ErrorProvider successProvider, bool optional = false) :
            base(control, errorProvider, successProvider, optional) { }

        /// <summary>
        /// Apply Negation operator to the next validation. Next validtion will
        /// be considered valid if validation condition is NOT met. 
        /// For instance, [...].Not().HasText() will validate as valid if control 
        /// has no text. 
        /// This operator will affect only the next validation, having
        /// no effect on further chained validations. 
        /// To negate multiple validations multiple operators can be chained. 
        /// For isntance, [...].Not().HasText().Not().Other(...) 
        /// will be validated as valid if both validations fail.
        /// If two negations are together -> .Not().Not() no negation is applied.
        /// </summary>
        /// <returns>This validation</returns>
        public ExtendedValidation<T> Not()
        {
            Negate = !Negate;
            return this;
        }

        /// <summary>
        /// Validates whether validated control has text or not. By default, space characters are ignored.
        /// </summary>
        /// <param name="ignoreWitheSpace">Whether to ignore spaces when validating or not.</param>
        /// <returns>This validation.</returns>
        public ExtendedValidation<T> HasText(bool ignoreWitheSpace = true)
        {
            if (ignoreWitheSpace == false)
            {
                IsValid = !string.IsNullOrEmpty(Control.Text);
            }
            else
            {
                IsValid = !string.IsNullOrWhiteSpace(Control.Text);
            }

            return this;
        }
        /// <summary>
        /// Validates that the Text of the validated control is a number (non-decimal, no spaces or other characters, just numbers).
        /// </summary>
        /// <returns>This validation.</returns>
        public ExtendedValidation<T> IsNumber()
        {
            const string pattern = "\\b\\d+\\b"; // Instead of long.Parse, this does not limit the number lenght.
            IsValid = Regex.IsMatch(Control.Text, pattern);
            return this;
        }
        /// <summary>
        /// <para>This method lets you specify a custom function to serve as validation.</para> 
        /// <para>That validation is treated in the same way as any other existing validation.</para>
        /// </summary>
        /// <param name="evaluateExpr">Custom expression to be evaluated.</param>
        /// <returns>This validation.</returns>
        public ExtendedValidation<T> Other(Func<bool> evaluateExpr)
        {
            IsValid = evaluateExpr();
            return this;
        }
        /// <summary>
        /// <para>This method lets you specify a custom validation to be executed.</para> 
        /// <para>That validation is treated in the same way as any other existing validation. </para>
        /// </summary>
        /// <param name="evaluateExpr">Custom expression to be evaluated.</param>
        /// <returns>This validation.</returns>
        public ExtendedValidation<T> Other(Func<T, bool> evaluateExpr)
        {
            IsValid = evaluateExpr(Control);
            return this;
        }

        /// <summary>
        /// <para>This method gets fired if the validation status of the control is invalid.</para>
        /// <para>A given action gets executed in this case.</para>
        /// </summary>
        /// <param name="errorAction">Action to be executed if an error occurrs.</param>
        /// <returns>This validation.</returns>
        public ExtendedValidation<T> OnError(Action<T> errorAction)
        {
            if (IsValid == false)
            {
                errorAction(Control);
            }
            return this;
        }
        /// <summary>
        /// <para>This method gets fired if the validation status of the control is valid.</para>
        /// <para>A given action gets executed in this case.</para>
        /// </summary>
        /// <param name="successAction">Action to be executed on success.</param>
        /// <returns>This validation.</returns>
        public ExtendedValidation<T> OnSuccess(Action<T> successAction)
        {
            if (IsValid)
            {
                successAction(Control);
            }
            return this;
        }

        /// <summary>
        /// Display an error message using the error provider. It is possible 
        /// to show only the first error (and subsequent calls will do nothing
        /// since there is already an error being shown) or overwrite the message and 
        /// display the latest error instead of the first.
        /// </summary>
        /// <param name="message">Message to set in provider.</param>
        /// <param name="overwriteLastError">Whether to overwrite
        /// last error (true) or leave always the first error visible
        /// even if multiple validations fail.</param>
        /// <returns>This validation.</returns>
        new public ExtendedValidation<T> DisplayOnError(string message, bool overwriteLastError = false)
        {
            base.DisplayOnError(message, overwriteLastError);
            return this;
        }
        /// <summary>
        /// Display an error message using the error provider. It is possible 
        /// to show only the first error (and subsequent calls will do nothing
        /// since there is already an error being shown) or overwrite the message and 
        /// display the latest error instead of the first.
        /// <para> </para>
        /// This overload presents the default message (<see cref="Validator.GlobalDefaultErrorMessage"/>).
        /// </summary>
        /// <param name="overrideLastError">Whether to overwrite
        /// last error (true) or leave always the first error visible
        /// even if multiple validations fail.</param>
        /// <returns>This validation.</returns>
        public new ExtendedValidation<T> DisplayOnError(bool overrideLastError = false)
        {
            return DisplayOnError(null, overrideLastError);
        }

        /// <summary>
        /// Display a message on success (IsValid is true) using the success
        /// errorProvider, with a green icon, meaning that the field is valid.
        /// </summary>
        /// <param name="message">Message to set in provider.</param>
        /// <returns>This validation.</returns>
        new public ExtendedValidation<T> DisplayOnSuccess(string message)
        {
            base.DisplayOnSuccess(message);
            return this;
        }
        /// <summary>
        /// Display a message on success (IsValid is true) using the success
        /// errorProvider, with a green icon, meaning that the field is valid.
        /// <para> </para>
        /// This overload presents the default message.
        /// </summary>
        /// <returns>This validation.</returns>
        new public ExtendedValidation<T> DisplayOnSuccess()
        {
            base.DisplayOnSuccess();
            return this;
        }

        /// <summary>
        /// Calling this method will make the validation fail. 
        /// Let this be a warn for you. Muahahah.
        /// </summary>
        /// <returns>This validation.</returns>
        public ExtendedValidation<T> Fail()
        {
            IsValid = false;
            return this;
        }
        /// <summary>
        /// Calling this method will make the validation fail. 
        /// Let this be a warn for you. Muahahah. 
        /// <para> </para>
        /// This overload is a shortcut to <code>Fail().DisplayOnError(errorMessage)</code>.
        /// </summary>
        /// <param name="errorMessage">Error message to display.</param>
        /// <returns>This validation.</returns>
        public ExtendedValidation<T> Fail(string errorMessage)
        {
            return Fail().DisplayOnError(errorMessage);
        }

        /// <summary>
        /// <para>Execute a validation that may invalidate previous validations.</para>
        /// <para>Consider an invalid validation. This means that somewhere along
        /// the chain of validations, at least one of validations has failed and thus the validation is
        /// deemed invalid (after first failed test, validation is invalid no matter what).</para>
        /// <para>That is... unless... this method is called, and if this test passes, validation is valid again.</para>
        /// E.g. <code></code>
        /// </summary>
        /// <param name="evaluateExpr">Custom expression to be evaluated.</param>
        /// <returns>This validation.</returns>
        public ExtendedValidation<T> Unless(Func<T, bool> evaluateExpr)
        {
            if(evaluateExpr(Control))
                Reset();

            return this;
        }

        /// <summary>
        /// This aligns the error/success icon according to given value. The alignment is related to the control being validated.
        /// <para>To align all validations at the same time set <see cref="Validation.GeneralAlignment"/> instead of calling this method.</para>
        /// </summary>
        /// <param name="alignment">New alignment for icons.</param>
        /// <returns>This validation.</returns>
        public ExtendedValidation<T> Align(ErrorIconAlignment alignment)
        {
            SetErrorLocation(alignment);
            return this;
        }
        /// <summary>
        /// This aligns the error/success icon to <see cref="ErrorIconAlignment.MiddleLeft"/>. The alignment is related to the control being validated.
        /// <para>To align all validations at the same time set <see cref="Validation.GeneralAlignment"/> instead of calling this method.</para>
        /// <para>This method is a shortcut to <code>SetErrorLocation(ErrorIconAlignment.MiddleLeft)</code>.</para>
        /// </summary>
        /// <returns>This validation.</returns>
        public ExtendedValidation<T> AlignLeft()
        {
            SetErrorLocation(ErrorIconAlignment.MiddleLeft);
            return this;
        }
        /// <summary>
        /// This aligns the error/success icon  to <see cref="ErrorIconAlignment.MiddleRight"/>. The alignment is related to the control being validated.
        /// <para>To align all validations at the same time set <see cref="Validation.GeneralAlignment"/> instead of calling this method.</para>
        /// <para>This method is a shortcut to <code>SetErrorLocation(ErrorIconAlignment.MiddleRight)</code>.</para>
        /// <para>Unless <see cref="Validation.GeneralAlignment"/> has been set otherwise, this is the default behavior.</para>
        /// </summary>
        /// <returns>This validation.</returns>
        public ExtendedValidation<T> AlignRight()
        {
            SetErrorLocation(ErrorIconAlignment.MiddleRight);
            return this;
        }

        /// <summary>
        /// This sets a padding value for error/success icon according to given value. The padding is related to the control being validated.
        /// <para>To specify the value for all validations at the same time set <see cref="Validation.GeneralPadding"/> instead of calling this method.</para>
        /// </summary>
        /// <param name="padding">New padding value for icons.</param>
        /// <returns>This validation.</returns>
        public ExtendedValidation<T> Pad(int padding)
        {
            SetErrorPadding(padding);
            return this;
        }


    }

}
