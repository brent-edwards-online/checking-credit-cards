using CheckingCreditCards.CreditCardValidator;

namespace CheckingCreditCards.CardType
{
    public class VisaCreditCard : CreditCard
    {
        public VisaCreditCard(string cardNumber, ICreditCardValidator validator): base(cardNumber, validator){}

        public override string ToString()
        {
            return base.ToString("VISA");
        }
    }
}
