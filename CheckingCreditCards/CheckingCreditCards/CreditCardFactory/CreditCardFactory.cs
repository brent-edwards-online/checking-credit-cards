using CheckingCreditCards.CardType;
using CheckingCreditCards.CreditCardValidator;
using System;
using System.Text.RegularExpressions;

namespace CheckingCreditCards.Factory
{
    public class CreditCardFactory : ICreditCardFactory
    {
        private ICreditCardValidator _validator;
        private Tuple<Regex, Type>[] _cardDefinitionList;

        private CreditCardFactory() { }

        public CreditCardFactory (ICreditCardValidator validator, Tuple<Regex, Type>[] cardDefinitionList)
        {
            _validator = validator;
            _cardDefinitionList = cardDefinitionList;
        }

        public CreditCard CreateCreditCard(string cardNumber)
        {
            string strippedCardNumber = cardNumber.Replace(" ", String.Empty);

            foreach(var definition in _cardDefinitionList)
            {
                if (definition.Item1.IsMatch(strippedCardNumber))
                {
                    var constructor = definition.Item2.GetConstructor(new[] { typeof(string), typeof(ICreditCardValidator) });
                    if(constructor != null)
                    {
                        var card = constructor.Invoke(new object[] { strippedCardNumber, _validator });
                        return card as CreditCard;
                    }
                }
            }

            return new UnknownCreditCard(strippedCardNumber, _validator);
        }
    }
}
