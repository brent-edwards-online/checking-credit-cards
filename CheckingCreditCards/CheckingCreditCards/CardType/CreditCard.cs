using CheckingCreditCards.CreditCardValidator;
using System;
using System.Text;

namespace CheckingCreditCards.CardType
{
    public abstract class CreditCard
    {
        protected string _cardNumber;
        protected ICreditCardValidator _validator;

        private CreditCard() { }

        public CreditCard(string cardNumber, ICreditCardValidator validator) {
            _cardNumber = cardNumber;
            _validator = validator;
        }

        public abstract override string ToString();

        protected string ToString(string cardType)
        {
            StringBuilder result = new StringBuilder();
            result.Append(cardType);
            result.Append(": ");
            result.Append(_cardNumber);

            int paddingLength = 28 - result.ToString().Length;
            if(paddingLength > 0)
            {
                result.Append(new String(' ', paddingLength));
            }
            
            result.Append(_validator.IsValid(_cardNumber) ? " (valid)" : " (invalid)");
            return result.ToString();
        }
    }
}
