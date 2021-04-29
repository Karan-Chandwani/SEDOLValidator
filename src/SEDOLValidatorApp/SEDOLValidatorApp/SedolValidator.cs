using SEDOLValidatorApp.Validators;
using System.Collections.Generic;

namespace SEDOLValidatorApp
{
    public class SedolValidator : ISedolValidator
    {
        private IList<IValidator> validators;

        public SedolValidator()
        {
            InitializeValidators();
        }

        private void InitializeValidators()
        {
            validators = new List<IValidator>();

            // Ideally this should be a dependency in the construtor, but since requirement is for parameterless constructor, create a new factory object here.
            IValidatorsFactory validatorsFactory = new ValidatorsFactory();

            // Ideally set of validators should be defined in some external configuration. For brevity, hard coding it here.
            // Note: Order of validators is also carefully defined with consideration. In case of multiple violation, first validation error will only occur.

            validators.Add(validatorsFactory.GetValidator(Constants.LengthValidatorName));
            validators.Add(validatorsFactory.GetValidator(Constants.InvalidCharValidatorName));
            validators.Add(validatorsFactory.GetValidator(Constants.ChecksumValidatorName));
        }

        public ISedolValidatorResult ValidateSedol(string input)
        {
            ISedolValidatorResult sedolValidatorResult = new SedolValidatorResult() { InputString = input, IsUserDefined = IsUserDefiendSedol(input), IsValidSedol = true};

            foreach (IValidator validator in validators)
            {
                IValidationResult result = validator.Validate(input);

                if(!result.IsValid)
                {
                    sedolValidatorResult.IsValidSedol = false;
                    sedolValidatorResult.ValidationDetails = result.Message;

                    // Assumption: If length or valid characters validation fails, then string can not be identified to be user defined.
                    sedolValidatorResult.IsUserDefined = sedolValidatorResult.IsUserDefined && validator.CanBeUserDefined;

                    // In case of multiple violation, first validation error will only occur.
                    break;
                }
            }

            return sedolValidatorResult;
        }

        private bool IsUserDefiendSedol(string input)
        {
            if(!string.IsNullOrEmpty(input) && input[0] == '9')
            {
                return true;
            }

            return false;
        }
    }
}
