using CheckingCreditCards.CardType;

namespace CheckingCreditCards.Factory
{
    public interface ICreditCardFactory
    {
        CreditCard CreateCreditCard(string cardNumber);
    }
}
