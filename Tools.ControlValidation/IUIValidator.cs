namespace Tools.ControlValidation
{
    public interface IUIValidator
    {
        /// <summary>
        /// Gets the validator used when validating UI controls.
        /// </summary>
        Validator Validator { get; }
    }
}
