namespace SEDOLValidatorApp
{
    public interface ISedolValidator
    {
        ISedolValidatorResult ValidateSedol(string input);
    }
}
