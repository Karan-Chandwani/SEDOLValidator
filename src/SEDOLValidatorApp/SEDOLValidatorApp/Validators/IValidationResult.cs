namespace SEDOLValidatorApp.Validators
{
    internal interface IValidationResult
    {
        bool IsValid { get; set; }

        string Message { get; set; }
    }
}