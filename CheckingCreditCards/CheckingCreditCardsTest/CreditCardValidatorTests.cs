using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckingCreditCards.CreditCardValidator;

namespace CheckingCreditCardsTest
{
    [TestClass]
    public class CreditCardValidatorTests
    {
        private ICreditCardValidator validator;

        [TestInitialize()]
        public void Initialize()
        {
            validator = new LuhnValidator();
        }


        [TestMethod]
        [TestCategory("Test Credit Card Validator")]
        public void TestIsValidReturnsTrue()
        {
            bool result;

            result = validator.IsValid("4408041234567893");
            Assert.IsTrue(result);

            result = validator.IsValid("4111111111111111");
            Assert.IsTrue(result);

            result = validator.IsValid("4012888888881881");
            Assert.IsTrue(result);

            result = validator.IsValid("378282246310005");
            Assert.IsTrue(result);

            result = validator.IsValid("6011111111111117");
            Assert.IsTrue(result);

            result = validator.IsValid("5105105105105100");
            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("Test Credit Card Validator")]
        public void TestIsValidReturnsFalse()
        {
            bool result;

            result = validator.IsValid("4417123456789112");
            Assert.IsFalse(result);

            result = validator.IsValid("4111111111111");
            Assert.IsFalse(result);

            result = validator.IsValid("5105105105105106");
            Assert.IsFalse(result);

            result = validator.IsValid("9111111111111111");
            Assert.IsFalse(result);

            result = validator.IsValid("NOT A CREDIT CARD");
            Assert.IsFalse(result);

            result = validator.IsValid("");
            Assert.IsFalse(result);

            result = validator.IsValid("a105105105105100");
            Assert.IsFalse(result);
        }
    }
}
