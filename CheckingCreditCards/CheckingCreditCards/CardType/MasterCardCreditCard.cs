using CheckingCreditCards.CreditCardValidator;

namespace CheckingCreditCards.CardType
{
    public class MasterCardCreditCard : CreditCard
    {
        public MasterCardCreditCard(string cardNumber, ICreditCardValidator validator): base(cardNumber, validator){}

        public override string ToString()
        { 
            return base.ToString("MasterCard");
        }
    }
}
