using System;

namespace SEDOLValidatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ISedolValidator sedolValidator = new SedolValidator();
            Console.WriteLine("Enter an input SEDOL");
            string input = Console.ReadLine();

            ISedolValidatorResult result = sedolValidator.ValidateSedol(input);

            Console.WriteLine($"{result.InputString}|{result.IsValidSedol}|{result.IsUserDefined}|{result.ValidationDetails}");
        }
    }
}
