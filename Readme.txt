This repository contains SEDOL Validator code, a coding excercise for M&G interview.

Coding Platform: .Net core 2.1, Console App.


Run Instructions:
1> To Run the program on console.

- You can open the project in visual studio and run the console app 'SEDOLValidatorApp'.
- Provide input string on the prompt.
- Result is outpted in format:  InputString|IsValid|UserDefined|ValidationDetails

2> To test it with your automation tester.

- Build the SEDOLValidatorApp
- Refer the SEDOLValidatorApp.dll file in your Tester project.
- Instantiate SedolValidator object with new SedolValidator() as pass it to your tester.

3> To run unit tests.
- Open the project in visual studio.
- Build the solution.
- Run all tests from 'Test Explorer'


Assumption:
- When an input string has less/greater than 7 characters and has invalid character, 
then only 'less than 7 characters' error is thrown.

- SEDOL with less/greater than 7 character or with invalid characters, cannot be a userdefined SEDOL.

