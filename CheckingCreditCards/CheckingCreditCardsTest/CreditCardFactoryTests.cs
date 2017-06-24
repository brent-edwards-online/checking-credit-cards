using CheckingCreditCards.CardType;
using CheckingCreditCards.Factory;
using CheckingCreditCards.CreditCardValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Text.RegularExpressions;

namespace CheckingCreditCardsTest
{
    [TestClass]
    public class TestCreditCardFactory
    {
        private ICreditCardFactory _factory;
        private CreditCard _actual;

        readonly static Tuple<Regex, Type>[] CARDDEFINITIONS =
        {
           new Tuple<Regex, Type>(new Regex("^4([0-9]{12}|[0-9]{15})$"), typeof(VisaCreditCard)),
           new Tuple<Regex, Type>(new Regex("^3(4|7)[0-9]{13}$"), typeof(AmexCreditCard)),
           new Tuple<Regex, Type>(new Regex("^6011[0-9]{12}$"), typeof(DiscoverCreditCard)),
           new Tuple<Regex, Type>(new Regex("^5[1-5][0-9]{14}$"), typeof(MasterCardCreditCard))
        };

        [TestInitialize()]
        public void Initialize()
        {
            ICreditCardValidator validator = Substitute.For<ICreditCardValidator>();
            _factory = new CreditCardFactory(validator, CARDDEFINITIONS);
        }

        [TestMethod]
        [TestCategory("Test Credit Card Factory")]
        public void TestReturnsVisaCard()
        {
            _actual = _factory.CreateCreditCard("4111111111111111");
            Assert.IsInstanceOfType(_actual, typeof(VisaCreditCard));

            _actual = _factory.CreateCreditCard("4111111111111");
            Assert.IsInstanceOfType(_actual, typeof(VisaCreditCard));

            _actual = _factory.CreateCreditCard("411111111111");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("41111111111119");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("411111111111199");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("41111111111119999");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("4111111111111111");
            Assert.IsInstanceOfType(_actual, typeof(VisaCreditCard));
        }

        [TestMethod]
        [TestCategory("Test Credit Card Factory")]
        public void TestReturnsAmexCard()
        {
            _actual = _factory.CreateCreditCard("378282246310005");
            Assert.IsInstanceOfType(_actual, typeof(AmexCreditCard));

            _actual = _factory.CreateCreditCard("348282246310005");
            Assert.IsInstanceOfType(_actual, typeof(AmexCreditCard));

            _actual = _factory.CreateCreditCard("37828224631000");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("34828224631000");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("3782822463100051");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("3482822463100051");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));
        }

        [TestMethod]
        [TestCategory("Test Credit Card Factory")]
        public void TestReturnsDiscoverCard()
        {
            _actual = _factory.CreateCreditCard("6011111111111117");
            Assert.IsInstanceOfType(_actual, typeof(DiscoverCreditCard));

            _actual = _factory.CreateCreditCard("601111111111111");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("60111111111111110");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));
        }

        [TestMethod]
        [TestCategory("Test Credit Card Factory")]
        public void TestReturnsMasterCardCard()
        {
            _actual = _factory.CreateCreditCard("5105 1051 0510 5106");
            Assert.IsInstanceOfType(_actual, typeof(MasterCardCreditCard));

            _actual = _factory.CreateCreditCard("5105105105105100");
            Assert.IsInstanceOfType(_actual, typeof(MasterCardCreditCard));

            _actual = _factory.CreateCreditCard("5205105105105100");
            Assert.IsInstanceOfType(_actual, typeof(MasterCardCreditCard));

            _actual = _factory.CreateCreditCard("5305105105105100");
            Assert.IsInstanceOfType(_actual, typeof(MasterCardCreditCard));

            _actual = _factory.CreateCreditCard("5405105105105100");
            Assert.IsInstanceOfType(_actual, typeof(MasterCardCreditCard));

            _actual = _factory.CreateCreditCard("5505105105105100");
            Assert.IsInstanceOfType(_actual, typeof(MasterCardCreditCard));

            // 16 Characters
            _actual = _factory.CreateCreditCard("510510510510510");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("520510510510510");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("530510510510510");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("540510510510510");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("550510510510510");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            // 17 Characters
            _actual = _factory.CreateCreditCard("51051051051051099");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("52051051051051099");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("53051051051051099");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("54051051051051099");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));

            _actual = _factory.CreateCreditCard("55051051051051099");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));
        }

        [TestMethod]
        [TestCategory("Test Credit Card Factory")]
        public void TestReturnsUnknownCard()
        {
            _actual = _factory.CreateCreditCard("9111111111111111");
            Assert.IsInstanceOfType(_actual, typeof(UnknownCreditCard));  
        }
    }
}
