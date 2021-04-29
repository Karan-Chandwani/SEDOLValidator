namespace SEDOLValidatorApp.Validators
{
    internal interface IValidatorsFactory
    {
        IValidator GetValidator(string name);
    }
}
