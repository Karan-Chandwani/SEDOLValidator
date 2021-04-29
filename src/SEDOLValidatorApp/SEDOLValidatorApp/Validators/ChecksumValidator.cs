namespace SEDOLValidatorApp.Validators
{
    internal class ChecksumValidator : IValidator
    {
        // Value of 'A' or 'a' character.
        private const int AlphabetStartValue = 10;

        private readonly int[] digitWeights = new int[] { 1,3,1,7,3,9,1 };

        private const string ChecksumValidationErrorMessage = "Checksum digit does not agree with rest of the input";

        public bool CanBeUserDefined { get { return true; } }

        public IValidationResult Validate(string input)
        {
            IValidationResult result = new ValidationResult() { IsValid = true, Message = string.Empty };

            int weightedSum = CalculateWeightedSum(input);

            int expectedChecksumDigit = (10 - (weightedSum % 10)) % 10;
            int checksumDigit = (input[input.Length - 1] - '0');

            if (expectedChecksumDigit != checksumDigit)
            {
                result.IsValid = false;
                result.Message = ChecksumValidationErrorMessage;
            }

            return result;
        }

        private int CalculateWeightedSum(string input)
        {
            int weightedSum = 0;

            // Assumption is input is of 7 chars long, as length and null validation is already done as a separate validator.
            for (int i = 0; i < input.Length - 1; i++)
            {
                int digitValue = GetValue(input[i]);
                weightedSum += (digitValue * digitWeights[i]);
            }

            return weightedSum;
        }

        private int GetValue(char c)
        {
            if (c >= 'a' && c <= 'z')
            {
                return c - 'a' + AlphabetStartValue;
            }
            else if (c >= 'A' && c <= 'Z')
            {
                return c - 'A' + AlphabetStartValue;
            }
            else
            {
                return c - '0';
            }
        }
    }
}
