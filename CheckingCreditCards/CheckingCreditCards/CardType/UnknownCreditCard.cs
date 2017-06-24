using CheckingCreditCards.CreditCardValidator;

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
