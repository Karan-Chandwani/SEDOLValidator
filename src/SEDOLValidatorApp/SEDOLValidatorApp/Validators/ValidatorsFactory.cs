namespace SEDOLValidatorApp.Validators
{
    internal class ValidatorsFactory : IValidatorsFactory
    {
        public IValidator GetValidator(string name)
        {
            switch(name)
            {
                case Constants.LengthValidatorName:
                    return new LengthCheckValidator();
                case Constants.InvalidCharValidatorName:
                    return new InvalidCharsValidation();
                case Constants.ChecksumValidatorName:
                    return new ChecksumValidator();
                default:
                    throw new System.Exception("Validator not registered");
            }
        }
    }
}
