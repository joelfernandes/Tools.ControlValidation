using System;
using System.Windows.Forms;
using Tools.ControlValidation.Properties;

namespace Tools.ControlValidation
{
    /// <summary>
    /// A validation object that presents success/error icons and provides core validation capabilities.
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Gets or sets default error message to present in <see cref="DisplayOnError(bool)"/>
        /// method if no text is provided.
        /// </summary>
        public static string DefaultErrorMessage = "Invalid field";
        /// <summary>
        /// Gets or sets default success message to present in <see cref="DisplayOnSuccess()"/>
        /// method if no text is provided.
        /// </summary>
        public static string DefaultSuccessMessage = "This field is valid";
        /// <summary>
        /// The error/success icon alignment.
        /// </summary>
        public static ErrorIconAlignment DefaultAlignment = ErrorIconAlignment.MiddleRight;
        /// <summary>
        /// The error/success icon padding.
        /// </summary>
        public static int DefaultPadding = 0;
        /// <summary>
        /// The error/success icon blink style.
        /// </summary>
        public static ErrorBlinkStyle DefaultBlinkStyle = ErrorBlinkStyle.NeverBlink;
        /// <summary>
        /// The error/success icon blink rate. This property does nothing if <see cref="DefaultBlinkStyle"/> is <see cref="ErrorBlinkStyle.NeverBlink"/>.
        /// </summary>
        public static int DefaultBlinkRate = 250;

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
        /// The error message to present in <see cref="_errorProvider"/>.
        /// </summary>
        private string _errorMessage = string.Empty;
        /// <summary>
        /// The error message to present in <see cref="_successProvider"/>.
        /// </summary>
        private string _successMessage = string.Empty;
        /// <summary>
        /// The alignment of icons from <see cref="_errorProvider"/> and <see cref="_successProvider"/>.
        /// </summary>
        private ErrorIconAlignment _errorAlignment = ErrorIconAlignment.MiddleRight;
        /// <summary>
        /// The padding of icons from <see cref="_errorProvider"/> and <see cref="_successProvider"/>.
        /// </summary>
        private int _errorPadding = 0;
        /// <summary>
        /// The blink style of icons from <see cref="_errorProvider"/> and <see cref="_successProvider"/>.
        /// </summary>
        private ErrorBlinkStyle _errorBlinkStyle;
        /// <summary>
        /// The blink rate of icons from <see cref="_errorProvider"/> and <see cref="_successProvider"/>.
        /// </summary>
        private int _errorBlinkRate = 250;

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
        /// <param name="optional">Whether to create an opcional validation. 
        /// If true, validation will always return true, no matter what. 
        /// This parameter is used by <see cref="Validator.StartIf{T}"/> method.</param>
        internal Validation(Control control, bool optional = false)
        {
            if (control == null)
                throw new ArgumentNullException("control");

            Control = control;
            _isValid = true;
            _optional = optional;
            _errorProvider = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
            _successProvider = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink, Icon = Resources.Success };
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
            message = message ?? DefaultErrorMessage;

            if (IsValid)
            {
                _errorMessage = string.Empty;
            }
            else if (_errorMessage.Equals(string.Empty) == false)
            {
                _errorMessage = overwriteLastError ? message : _errorMessage;
            }
            else
            {
                _errorMessage = message;
            }

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
            _successMessage = message ?? DefaultSuccessMessage;
            _successMessage = !IsValid ? string.Empty : message;

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
        /// Ends the validation process. This method updates the validators on the UI.
        /// </summary>
        /// <returns>True if validation is valid, otherwise false.</returns>
        public bool End()
        {
            if (_errorProvider.GetError(Control) != _errorMessage)
                _errorProvider.SetError(Control, _errorMessage);

            if (_errorProvider.GetIconAlignment(Control) != _errorAlignment)
                _errorProvider.SetIconAlignment(Control, _errorAlignment);

            if (_errorProvider.GetIconPadding(Control) != _errorPadding)
                _errorProvider.SetIconPadding(Control, _errorPadding);

            _errorProvider.BlinkStyle = _errorBlinkStyle;
            _errorProvider.BlinkRate = _errorBlinkRate;


            if (_successProvider.GetError(Control) != _successMessage)
                _successProvider.SetError(Control, _successMessage);

            if (_successProvider.GetIconAlignment(Control) != _errorAlignment)
                _successProvider.SetIconAlignment(Control, _errorAlignment);

            if (_successProvider.GetIconPadding(Control) != _errorPadding)
                _successProvider.SetIconPadding(Control, _errorPadding);

            _successProvider.BlinkStyle = _errorBlinkStyle;
            _successProvider.BlinkRate = _errorBlinkRate;

            return IsValid;
        }

        /// <summary>
        /// Reset validation status (IsValid). Also, remove any pending negation operator.
        /// </summary>
        public void SoftReset()
        {
            _isValid = true;
            Negate = false;
            _errorMessage = _successMessage = string.Empty;
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

            SoftReset();

            if (!wasValid)
                OnErrorStateChange(true); // Fire the event, signaling that the validation is valid again.

            _optional = optional;

            End(); // Force UI refresh
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
        /// <param name="iconAlignment">The alignment of the icons related to validated control.</param>
        /// <returns>This validation.</returns>
        protected Validation SetErrorLocation(ErrorIconAlignment iconAlignment)
        {
            _errorAlignment = iconAlignment;
            return this;
        }

        /// <summary>
        /// Specify a padding value for error/success provider icons of this control.
        /// </summary>
        /// <param name="padding">The alignment of the icons related to validated control.</param>
        /// <returns>This validation.</returns>
        protected Validation SetErrorPadding(int padding)
        {
            _errorPadding = padding;
            return this;
        }

        /// <summary>
        /// Specify a blink style (and rate) for the icons. Parameter <paramref name="blinkRate"/> 
        /// is not used if <paramref name="blinkStyle"/> is set to <see cref="ErrorBlinkStyle.NeverBlink"/>.
        /// </summary>
        /// <param name="blinkStyle">Blinks tyle to apply to icons.</param>
        /// <param name="blinkRate">Blink rate to apply to icons.</param>
        protected void SetBlinkStyle(ErrorBlinkStyle blinkStyle, int blinkRate)
        {
            if(blinkStyle != ErrorBlinkStyle.NeverBlink && blinkRate < 1)
                throw new ArgumentException("Blink rate must be > 0");

            _errorBlinkStyle = blinkStyle;
            _errorBlinkRate = blinkRate;
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
        /// <param name="isValid">True if validator is valid, otherwise false</param>
        public ValidationStateEventArgs(bool isValid)
        {
            IsValid = isValid;
        }
    }
}
