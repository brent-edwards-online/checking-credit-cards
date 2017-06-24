using CheckingCreditCards.CreditCardValidator;

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
