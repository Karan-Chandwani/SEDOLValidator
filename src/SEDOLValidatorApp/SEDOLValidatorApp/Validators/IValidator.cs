namespace SEDOLValidatorApp.Validators
{
    internal interface IValidator
    {
        IValidationResult Validate(string input);

        bool CanBeUserDefined { get; }
    }
}