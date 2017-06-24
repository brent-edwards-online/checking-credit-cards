namespace CheckingCreditCards.CreditCardValidator
{
    public interface ICreditCardValidator
    {
        bool IsValid(string cardNumber);
    }
}
