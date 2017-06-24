using CheckingCreditCards.CardType;
using CheckingCreditCards.CreditCardValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CheckingCreditCardsTest
{
    [TestClass]
    public class TestCreditCard
    {
        private CreditCard _card;
        private ICreditCardValidator _validator;

        [TestInitialize()]
        public void Initialize()
        {
            _validator = Substitute.For<ICreditCardValidator>();
        }

        [TestMethod]
        [TestCategory("Test Credit Card")]
        public void TestVisa()
        {
            string expected, actual;
            _card = new VisaCreditCard("4111111111111111", _validator);

            _validator.IsValid(Arg.Any<string>()).Returns(true);
            expected = "VISA: 4111111111111111       (valid)";
            actual = _card.ToString();
            Assert.AreEqual(expected, actual);

            _validator.IsValid(Arg.Any<string>()).Returns(false);
            expected = "VISA: 4111111111111111       (invalid)";
            actual = _card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Test Credit Card")]
        public void TestAmex()
        {
            string expected, actual;
            _card = new AmexCreditCard("378282246310005", _validator);

            _validator.IsValid(Arg.Any<string>()).Returns(true);
            expected = "AMEX: 378282246310005        (valid)";
            actual = _card.ToString();
            Assert.AreEqual(expected, actual);

            _validator.IsValid(Arg.Any<string>()).Returns(false);
            expected = "AMEX: 378282246310005        (invalid)";
            actual = _card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Test Credit Card")]
        public void TestDiscover()
        {
            string expected, actual;
            _card = new DiscoverCreditCard("6011111111111117", _validator);

            _validator.IsValid(Arg.Any<string>()).Returns(true);
            expected = "Discover: 6011111111111117   (valid)";
            actual = _card.ToString();
            Assert.AreEqual(expected, actual);

            _validator.IsValid(Arg.Any<string>()).Returns(false);
            expected = "Discover: 6011111111111117   (invalid)";
            actual = _card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Test Credit Card")]
        public void TestMasterCard()
        {
            string expected, actual;
            _card = new MasterCardCreditCard("5105105105105100", _validator);

            _validator.IsValid(Arg.Any<string>()).Returns(true);
            expected = "MasterCard: 5105105105105100 (valid)";
            actual = _card.ToString();
            Assert.AreEqual(expected, actual);

            _validator.IsValid(Arg.Any<string>()).Returns(false);
            expected = "MasterCard: 5105105105105100 (invalid)";
            actual = _card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Test Credit Card")]
        public void TestUnknown()
        {
            string expected, actual;
            _card = new UnknownCreditCard("9111111111111111", _validator);

            _validator.IsValid(Arg.Any<string>()).Returns(true);
            expected = "Unknown: 9111111111111111    (valid)";
            actual = _card.ToString();
            Assert.AreEqual(expected, actual);

            _validator.IsValid(Arg.Any<string>()).Returns(false);
            expected = "Unknown: 9111111111111111    (invalid)";
            actual = _card.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
