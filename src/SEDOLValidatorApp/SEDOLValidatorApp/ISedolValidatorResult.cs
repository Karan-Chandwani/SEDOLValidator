namespace SEDOLValidatorApp
{
    public interface ISedolValidatorResult
    {
        string InputString { get; set; }

        bool IsValidSedol { get; set; }

        bool IsUserDefined { get; set; }

        string ValidationDetails { get; set; }
    }
}