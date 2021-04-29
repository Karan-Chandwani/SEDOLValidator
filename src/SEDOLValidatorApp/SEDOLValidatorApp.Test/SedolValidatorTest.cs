using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SEDOLValidatorApp.Test
{
    [TestClass]
    public class SedolValidatorTest
    {
        private ISedolValidator sedolValidator;
        private const string LengthValidationErrorMessage = "Input string was not 7-characters long";
        private const string InvalidCharsErrorMessage = "SEDOL contains invalid characters";
        private const string ChecksumValidationErrorMessage = "Checksum digit does not agree with rest of the input";


        [TestInitialize]
        public void Setup()
        {
            sedolValidator = new SedolValidator();
        }

        [TestMethod]
        public void ValidateSedol_NullInput_ReturnsResultWithAppropriateError()
        {
            string input = null;
            ISedolValidatorResult result = sedolValidator.ValidateSedol(input);

            Assert.IsNull(result.InputString);
            Assert.IsFalse(result.IsValidSedol);
            Assert.IsFalse(result.IsUserDefined);
            Assert.AreEqual(LengthValidationErrorMessage, result.ValidationDetails);
        }

        [TestMethod]
        public void ValidateSedol_EmptyInput_ReturnsResultWithAppropriateError()
        {
            string input = string.Empty;
            ISedolValidatorResult result = sedolValidator.ValidateSedol(input);

            Assert.AreEqual(string.Empty, result.InputString);
            Assert.IsFalse(result.IsValidSedol);
            Assert.IsFalse(result.IsUserDefined);
            Assert.AreEqual(LengthValidationErrorMessage, result.ValidationDetails);
        }

        [TestMethod]
        public void ValidateSedol_LessThanSevenChars_ReturnsResultWithAppropriateError()
        {
            string input = "123456";
            ISedolValidatorResult result = sedolValidator.ValidateSedol(input);

            Assert.AreEqual(input, result.InputString);
            Assert.IsFalse(result.IsValidSedol);
            Assert.IsFalse(result.IsUserDefined);
            Assert.AreEqual(LengthValidationErrorMessage, result.ValidationDetails);
        }

        [TestMethod]
        public void ValidateSedol_MoreThanSevenChars_ReturnsResultWithAppropriateError()
        {
            string input = "92345abce0";
            ISedolValidatorResult result = sedolValidator.ValidateSedol(input);

            Assert.AreEqual(input, result.InputString);
            Assert.IsFalse(result.IsValidSedol);
            Assert.IsFalse(result.IsUserDefined);
            Assert.AreEqual(LengthValidationErrorMessage, result.ValidationDetails);
        }

        [TestMethod]
        public void ValidateSedol_InvalidChars_ReturnsResultWithAppropriateError()
        {
            string input = "12345_6";
            ISedolValidatorResult result = sedolValidator.ValidateSedol(input);

            Assert.AreEqual(input, result.InputString);
            Assert.IsFalse(result.IsValidSedol);
            Assert.IsFalse(result.IsUserDefined);
            Assert.AreEqual(InvalidCharsErrorMessage, result.ValidationDetails);
        }

        [TestMethod]
        public void ValidateSedol_InvalidCharsWithStartingNine_ReturnsResultWithAppropriateError()
        {
            string input = "92345!6";
            ISedolValidatorResult result = sedolValidator.ValidateSedol(input);

            Assert.AreEqual(input, result.InputString);
            Assert.IsFalse(result.IsValidSedol);
            Assert.IsFalse(result.IsUserDefined);
            Assert.AreEqual(InvalidCharsErrorMessage, result.ValidationDetails);
        }

        [TestMethod]
        public void ValidateSedol_InvalidChecksumWithUserDefined_ReturnsResultWithAppropriateError()
        {
            string input = "9234516";
            ISedolValidatorResult result = sedolValidator.ValidateSedol(input);

            Assert.AreEqual(input, result.InputString);
            Assert.IsFalse(result.IsValidSedol);
            Assert.IsTrue(result.IsUserDefined);
            Assert.AreEqual(ChecksumValidationErrorMessage, result.ValidationDetails);
        }

        [TestMethod]
        public void ValidateSedol_InvalidChecksumWithNonUserDefined_ReturnsResultWithAppropriateError()
        {
            string input = "12345A1";
            ISedolValidatorResult result = sedolValidator.ValidateSedol(input);

            Assert.AreEqual(input, result.InputString);
            Assert.IsFalse(result.IsValidSedol);
            Assert.IsFalse(result.IsUserDefined);
            Assert.AreEqual(ChecksumValidationErrorMessage, result.ValidationDetails);
        }

        [TestMethod]
        public void ValidateSedol_ValidChecksumWithUserDefined_ReturnsValidResultWithoutAnyErrorMessage()
        {
            string input = "9133457";
            ISedolValidatorResult result = sedolValidator.ValidateSedol(input);

            Assert.AreEqual(input, result.InputString);
            Assert.IsTrue(result.IsValidSedol);
            Assert.IsTrue(result.IsUserDefined);
            Assert.IsNull(result.ValidationDetails);
        }

        [TestMethod]
        public void ValidateSedol_ValidChecksumWithNonUserDefined_ReturnsValidResultWithoutAnyErrorMessage()
        {
            string input = "81C3459";
            ISedolValidatorResult result = sedolValidator.ValidateSedol(input);

            Assert.AreEqual(input, result.InputString);
            Assert.IsTrue(result.IsValidSedol);
            Assert.IsFalse(result.IsUserDefined);
            Assert.IsNull(result.ValidationDetails);
        }
    }
}
