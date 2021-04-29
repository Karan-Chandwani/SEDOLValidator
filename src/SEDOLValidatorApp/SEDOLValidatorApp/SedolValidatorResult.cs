namespace SEDOLValidatorApp
{
    public class SedolValidatorResult: ISedolValidatorResult
    {
        public string InputString { get; set; }

        public bool IsValidSedol { get; set; }

        public bool IsUserDefined { get; set; }

        public string ValidationDetails { get; set; }
    }
}
