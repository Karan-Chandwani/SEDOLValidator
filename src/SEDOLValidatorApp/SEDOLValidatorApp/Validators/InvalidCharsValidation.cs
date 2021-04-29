using System.Text.RegularExpressions;

namespace SEDOLValidatorApp.Validators
{
    internal class InvalidCharsValidation : IValidator
    {
        private const string InvalidCharsErrorMessage = "SEDOL contains invalid characters";

        public bool CanBeUserDefined { get { return false; } }

        public IValidationResult Validate(string input)
        {
            IValidationResult result = new ValidationResult() { IsValid = true, Message = string.Empty };

            Regex regex = new Regex(@"[^a-zA-Z\d]");

            if (string.IsNullOrEmpty(input) || regex.IsMatch(input))
            {
                result.IsValid = false;
                result.Message = InvalidCharsErrorMessage;
            }

            return result;
        }
    }
}
