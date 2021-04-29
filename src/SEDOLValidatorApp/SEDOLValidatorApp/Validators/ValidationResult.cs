namespace SEDOLValidatorApp.Validators
{
    internal class ValidationResult: IValidationResult
    {
        public bool IsValid { get; set; }

        public string Message { get; set; }
    }
}
