namespace SEDOLValidatorApp.Validators
{
    internal class LengthCheckValidator: IValidator
    {
        private const int SEDOLLength = 7;

        private const string LengthValidationErrorMessage = "Input string was not 7-characters long";

        public bool CanBeUserDefined { get { return false; } }

        public IValidationResult Validate(string input)
        {
            IValidationResult result = new ValidationResult() { IsValid = true, Message = string.Empty };

            if(string.IsNullOrEmpty(input) || input.Length != SEDOLLength)
            {
                result.IsValid = false;
                result.Message = LengthValidationErrorMessage;
            }

            return result;
        }
    }
}
