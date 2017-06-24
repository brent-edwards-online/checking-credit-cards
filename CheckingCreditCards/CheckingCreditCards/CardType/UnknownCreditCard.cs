using CheckingCreditCards.CreditCardValidator;
using System.Text;

namespace CheckingCreditCards.CardType
{
    public class UnknownCreditCard : CreditCard
    {
        public UnknownCreditCard(string cardNumber, ICreditCardValidator validator): base(cardNumber, validator){}

        public override string ToString()
        {
            return base.ToString("Unknown");
        }
    }
}
