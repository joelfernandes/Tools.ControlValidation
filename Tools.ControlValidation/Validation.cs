using System;
using System.Windows.Forms;

namespace Tools.ControlValidation
{
    /// <summary>
    /// A validation object that presents success/error icons and provides core validation capabilities.
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// The error provider that dsiplays error messages.
        /// </summary>
        private ErrorProvider _errorProvider;
        /// <summary>
        /// Good guy success provider displays success messages.
        /// </summary>
        private ErrorProvider _successProvider;
        /// <summary>
        /// Whether next Validation method shall be negated.
        /// </summary>
        protected bool Negate = false;
        /// <summary>
        /// Whether current validation total result is valid or not.
        /// </summary>
        private bool _isValid = true;
        /// <summary>
        /// Whether current validation is optional or has to be enforced.
        /// </summary>
        private bool _optional = false;

        /// <summary>
        /// The error/success icon alignment.
        /// </summary>
        public static ErrorIconAlignment GeneralAlignment = ErrorIconAlignment.MiddleRight;
        /// <summary>
        /// The error/success icon padding.
        /// </summary>
        public static int GeneralPadding = 0;
        /// <summary>
        /// The error/success icon blink style.
        /// </summary>
        public static ErrorBlinkStyle GeneralBlinkStyle = ErrorBlinkStyle.NeverBlink;
        /// <summary>
        /// The error/success icon blink rate. This property does nothing if <see cref="GeneralBlinkStyle"/> is <see cref="ErrorBlinkStyle.NeverBlink"/>.
        /// </summary>
        public static int GeneralBlinkRate = 250;

        /// <summary>
        /// <para>Gets whether this validation output is valid or not.</para> 
        /// <para>For a validation to become permanently, all that is needed is for one of the validation methods to fail.</para>
        /// </summary>
        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                if (_isValid)
                {
                    if (Negate)
                    {
                        value = !value;
                        Negate = false;
                    }

                    if (_optional)
                    {
                        value = true;
                    }

                    var wasValid = _isValid;

                    // using setter, only the first false is accepted. Once false, always false until Reset() is called.
                    _isValid = value;

                    if (wasValid != _isValid)
                        OnErrorStateChange(false);
                }
            }
        }

        /// <summary>
        /// Keep the control that is to be validated.
        /// </summary>
        protected Control Control { get; private set; }

        /// <summary>
        /// Event fired when <see cref="IsValid"/> value changes.
        /// </summary>
        internal event EventHandler<ValidationStateEventArgs> ValidStateChange;

        /// <summary>
        /// Create a new <see cref="Validation"/> object for a given control.
        /// </summary>
        /// <param name="control">Control to validate.</param>
        /// <param name="errorProvider">Error provider to display error messages.</param>
        /// <param name="successProvider">Error provider to display success messages.</param>
        /// <param name="optional">Whether to create an opcional validation. 
        /// If true, validation will always return true, no matter what. 
        /// This parameter is used by <see cref="Validator.ValidateIf{T}(System.Func{bool},T)"/> method.</param>
        internal Validation(Control control, ErrorProvider errorProvider,
            ErrorProvider successProvider, bool optional = false)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            Control = control;
            _errorProvider = errorProvider;
            _successProvider = successProvider;
            _isValid = true;
            _optional = optional;
        }

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current System.Object.
        /// This overriden method returns true of both validations have the same control.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current System.Object.</param>
        /// <returns>True if the specified System.Object is equal to the current System.Object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            
            var otherVal = obj as Validation;
            return otherVal != null && Control.Equals(otherVal.Control);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current System.Object.</returns>
        public override int GetHashCode()
        {
            return Control.GetHashCode();
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
        public Validation DisplayOnError(string message, bool overwriteLastError = false)
        {
            // if message is null (empty is another story!) it assumes the default message from its
            // validator, or the global message otherwise.
            message = message ?? Validator.GlobalDefaultErrorMessage;

            if (IsValid || message == null) // if message is still null at this point or validation succeeds
                message = string.Empty;     // doing this error will be cleared

            string oldMessage = _errorProvider.GetError(Control);
            if (oldMessage.Equals(string.Empty) == false)
            {
                message = overwriteLastError ? message : oldMessage;
            }
            _errorProvider.SetError(Control, message);
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
        public Validation DisplayOnError(bool overrideLastError = false)
        {
            return DisplayOnError(null, overrideLastError);
        }

        /// <summary>
        /// Display a message on success (IsValid is true) using the success
        /// errorProvider, with a green icon, meaning that the field is valid.
        /// </summary>
        /// <param name="message">Message to set in provider.</param>
        /// <returns>This validation.</returns>
        public Validation DisplayOnSuccess(string message)
        {
            // if message is null (empty is another story!) it assumes the default message from its
            // validator, or the global message otherwise
            message = message ?? Validator.GlobalDefaultSuccessMessage;

            if (IsValid == false || message == null) // if message is still null at this point or validation fails
                message = string.Empty; // doing this error will be cleared
            
            _successProvider.SetError(Control, message);
            return this;
        }
        /// <summary>
        /// Display a message on success (IsValid is true) using the success
        /// errorProvider, with a green icon, meaning that the field is valid.
        /// <para> </para>
        /// This overload presents the default message.
        /// </summary>
        /// <returns>This validation.</returns>
        public Validation DisplayOnSuccess()
        {
            return DisplayOnSuccess(null);
        }

        /// <summary>
        /// Reset error and success messages, <see cref="_isValid"/> and <see cref="Negate"/> also get 
        /// their default values. Once reset is called, the validation is ready
        /// to be called again from scratch. This method is internal, only 
        /// usable by the Validation API. 
        /// By default, reset will set optional to false. This can be 
        /// configured using "optional" parameter. An optional validation will
        /// always pass.
        /// </summary>
        /// <param name="optional">Whether this validation is set to optional.</param>
        internal void Reset(bool optional = false)
        {
            var wasValid = _isValid;
            _isValid = true;

            if (!wasValid)
                OnErrorStateChange(true); // Fire the event, signaling that the validation is valid again.

            _optional = optional;
            Negate = false;
            
            SetErrorLocation(GeneralAlignment);
            SetErrorPadding(GeneralPadding);
            SetErrorBlinkStyle(GeneralBlinkStyle);
            SetErrorBlinkRate(GeneralBlinkRate);

            _errorProvider.SetError(Control, "");
            _successProvider.SetError(Control, "");
        }

        /// <summary>
        /// Fired when a <see cref="ValidStateChange"/> event occurrs.
        /// </summary>
        /// <param name="isValid">True if validator is valid (no errors), otherwise false.</param>
        protected virtual void OnErrorStateChange(bool isValid)
        {
            if (ValidStateChange != null)
                ValidStateChange(this, new ValidationStateEventArgs(isValid));
        }

        /// <summary>
        /// Specify an alignment for the location of error/success provider icons of this control.
        /// </summary>
        /// <param name="iconLocation">The alignment of the icons related to validated control.</param>
        /// <returns>This validation.</returns>
        internal Validation SetErrorLocation(ErrorIconAlignment iconLocation)
        {
            _errorProvider.SetIconAlignment(Control, iconLocation);
            _successProvider.SetIconAlignment(Control, iconLocation);
            return this;
        }

        /// <summary>
        /// Specify a padding value for error/success provider icons of this control.
        /// </summary>
        /// <param name="padding">The alignment of the icons related to validated control.</param>
        /// <returns>This validation.</returns>
        internal Validation SetErrorPadding(int padding)
        {
            _errorProvider.SetIconPadding(Control, padding);
            _successProvider.SetIconPadding(Control, padding);
            return this;
        }

        /// <summary>
        /// Specify a blink style for error/success provider icons of this control.
        /// </summary>
        /// <param name="blinkStyle">The blink style of the icons.</param>
        /// <returns>This validation.</returns>
        internal Validation SetErrorBlinkStyle(ErrorBlinkStyle blinkStyle)
        {
            _errorProvider.BlinkStyle = blinkStyle;
            _successProvider.BlinkStyle = blinkStyle;
            return this;
        }

        /// <summary>
        /// Specify a blink rate for error/success provider icons of this control.
        /// </summary>
        /// <param name="blinkRate">The blink style of the icons.</param>
        /// <returns>This validation.</returns>
        internal Validation SetErrorBlinkRate(int blinkRate)
        {
            _errorProvider.BlinkRate = blinkRate;
            _successProvider.BlinkRate = blinkRate;
            return this;
        }

    }

    /// <summary>
    /// A class that contains arguments related to a <see cref="Validation.ValidStateChange"/> event.
    /// </summary>
    public class ValidationStateEventArgs : EventArgs
    {
        /// <summary>
        /// Gets whether validator is valid (has NO errors) or not.
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        /// Creates a new <see cref="ValidationStateEventArgs"/>.
        /// </summary>
        /// <param name="isValid">True if validator has no errors, otherwise false</param>
        public ValidationStateEventArgs(bool isValid)
        {
            IsValid = isValid;
        }
    }
}
