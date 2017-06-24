using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckingCreditCards.CreditCardValidator
{
    public class LuhnValidator : ICreditCardValidator
    {
        const byte ASCII_CHAR_ZERO = 48;

        public bool IsValid(string cardNumber)
        {
            int result = 0;

            if(cardNumber.Length == 0)
            {
                return false;
            }

            var reversed = cardNumber.ToCharArray().Reverse().ToArray();

            for(var idx = 0; idx < reversed.Length; idx++)
            {
                char character = reversed[idx];
                
                if (Char.IsDigit(character))
                {
                    byte nextDigit = Convert.ToByte(character);
                    nextDigit -= ASCII_CHAR_ZERO;

                    if (idx % 2 == 0)
                    {
                        result += nextDigit;
                    }
                    else
                    {
                        result += nextDigit < 5 ? 2 * nextDigit : (2 * nextDigit) - 9;
                    }
                }
                else
                {
                    return false;
                }
            }

            if(result % 10 == 0 )
            {
                return true;
            }
            return false;
        }
    }
}
