using CheckingCreditCards.CreditCardValidator;
using System.Text;

namespace CheckingCreditCards.CardType
{
    public class AmexCreditCard : CreditCard
    {
        public AmexCreditCard(string cardNumber, ICreditCardValidator validator): base(cardNumber, validator){}

        public override string ToString()
        {
            return base.ToString("AMEX");
        }
    }
}
