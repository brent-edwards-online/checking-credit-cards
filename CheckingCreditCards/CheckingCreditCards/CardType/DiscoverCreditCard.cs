using CheckingCreditCards.CreditCardValidator;

namespace CheckingCreditCards.CardType
{
    public class DiscoverCreditCard : CreditCard
    {
        public DiscoverCreditCard(string cardNumber, ICreditCardValidator validator): base(cardNumber, validator){}

        public override string ToString()
        {
            return base.ToString("Discover");
        }
    }
}
