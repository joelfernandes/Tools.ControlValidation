using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tools.ControlValidation
{
    /// <summary>
    /// Entry point to the Validation API. One validator per control (Form or UserControl) gives access
    /// to control validating methods.
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Keeps track of whether last validation performed by this validator had errors or not.
        /// This is used to fire <see cref="ValidStateChange"/> event only when state actually changes.
        /// </summary>
        private bool _hadErrors = false;

        /// <summary>
        /// Keeps a collection of performed validations, so that (for instance), 
        /// ErrorCount can be retrieved.
        /// </summary>
        protected List<Validation> Validations { get; private set; }
        /// <summary>
        /// Gets the root control that harbours the controls to be validated.
        /// Typically a Form or a UserControl.
        /// </summary>
        public Control RootControl { get; private set; }
        /// <summary>
        /// Returns true if there are errors.
        /// Same as ErrorCount > 0
        /// </summary>
        /// <returns>True if there are any errors, false otherwise</returns>
        public bool HasErrors { get { return ErrorCount > 0; } }
        /// <summary>
        /// Gets current amount of controls that are in an error state.
        /// Note that this may not reflect current changes, one example where 
        /// this will fail is when an action amends the error - e.g. using OnError() on a TextBox
        /// to place "bad" input with a default text). The control will be still considered as
        /// having an error until Validate is called on the control again.
        /// </summary>
        public int ErrorCount { get { return Validations.Count(x => x.IsValid == false); } }
        /// <summary>
        /// Get the collection of controls that lastly validated with error.
        /// Note that this may not reflect current changes, one example where 
        /// this will fail is when an action amends the error - e.g. using OnError() on a TextBox
        /// to place "bad" input with a default text). The control will be still considered as
        /// having an error until Validate{T} is called on the control again.
        /// </summary>
        public IList<Validation> FaultedControls { get { return Validations.Where(x => !x.IsValid).ToList(); } }

        /// <summary>
        /// Event fired when <see cref="HasErrors"/> value changes.
        /// </summary>
        public event EventHandler<ValidationStateEventArgs> ValidStateChange;

        /// <summary>
        /// Creates a new <see cref="Validator"/> class for given control (Form or UserControl).
        /// </summary>
        /// <param name="rootControl">Control that will be validated with this validator.</param>
        public Validator(Control rootControl)
        {
            if (rootControl == null)
                throw new ArgumentNullException("rootControl");

            Validations = new List<Validation>();

            RootControl = rootControl;
        }

        /// <summary>
        /// Every validation starts by calling this method. With generics, it is
        /// way more flexible, allowing for intellisense to display only relevant 
        /// validations, since most of validations are nothing more than 
        /// extension methods. This also makes the API easy to extend, adding 
        /// new validations. This method returns a Validation object, on 
        /// which validation methods will be invoked. Chaining methods are supported.
        /// This method keeps track of existing validatiions, so they can be run 
        /// again. Calling Validate again on the same control will reset the 
        /// validation status for that control.
        /// </summary>
        /// <typeparam name="T">Type of control to validate.</typeparam>
        /// <param name="control">The control to validate.</param>
        /// <returns>Validation object.</returns>
        public ExtendedValidation<T> Start<T>(T control) where T : Control
        {
            var val = new ExtendedValidation<T>(control);
            var existing = Validations.FirstOrDefault(x => x.Equals(val));

            if (existing != null)
            {
                existing.SoftReset();
                return (ExtendedValidation<T>)existing;
            }
            
            val.ValidStateChange += Validation_ValidStateChange;
            Validations.Add(val);
            return val;
        }
        /// <summary>
        /// <para>Same as <see cref="Start{T}"/>, but with the exception that this 
        /// validation will only be carried if given condition is met. </para>
        /// <para>If given CONDITION IS NOT MET, validation will be set to OPTIONAL and thus will be 
        /// ALWAYS VALID. If given condition is met, validation occurrs as usual.</para>
        /// </summary>
        /// <typeparam name="T">Type of control to validate.</typeparam>
        /// <param name="condition">Condition to test. If condition is met, validation proceeds as usual.</param>
        /// <param name="control">The control to validate.</param>
        /// <returns>Validation object</returns>
        public ExtendedValidation<T> StartIf<T>(T control, Func<T, bool> condition) where T : Control
        {
            // if condition is not met, optional is true, hence the negate oprator before condition()
            var optional = !condition(control);

            var val = new ExtendedValidation<T>(control, optional);
            var existing = Validations.FirstOrDefault(x => x.Equals(val));

            if (existing != null)
            {
                existing.Reset(optional);
                return (ExtendedValidation<T>)existing;
            }

            val.ValidStateChange += Validation_ValidStateChange;
            Validations.Add(val);
            return val;
        }
        /// <summary>
        /// Same as <see cref="Start{T}"/> except that it does not keep track of validated control,
        /// meaning that it won't be added to the inner collection and won't be accounted 
        /// when calling <see cref="ErrorCount"/>.
        /// </summary>
        /// <typeparam name="T">Type of control to validate.</typeparam>
        /// <param name="control">The control to validate.</param>
        /// <returns>Validation object.</returns>
        public ExtendedValidation<T> StartOnce<T>(T control) where T : Control
        {
            return new ExtendedValidation<T>(control);
        }

        /// <summary>
        /// Clear all existing messages and remove them from inner collection. 
        /// Simply resets the validator.
        /// </summary>
        public void Reset()
        {
            Validations.ForEach(v => v.Reset());
            foreach (var validation in Validations)
            {
                validation.ValidStateChange -= Validation_ValidStateChange;
            }
            Validations.Clear();
        }

        /// <summary>
        /// Occurrs when a state changes in a validation contained in this validator. This is the trigger
        /// for <see cref="ValidStateChange"/> event.
        /// </summary>
        /// <param name="sender">Component that fired the event.</param>
        /// <param name="e">Event arguments.</param>
        private void Validation_ValidStateChange(object sender, ValidationStateEventArgs e)
        {
            if (_hadErrors != HasErrors)
                OnValidStateChange(!HasErrors);

            _hadErrors = HasErrors;
        }
        /// <summary>
        /// Fired when a <see cref="ValidStateChange"/> event occurrs.
        /// </summary>
        /// <param name="isValid">True if validator is valid (no errors), otherwise false.</param>
        private void OnValidStateChange(bool isValid)
        {
            if (ValidStateChange != null)
                ValidStateChange(this, new ValidationStateEventArgs(isValid));
        }

    }

}
