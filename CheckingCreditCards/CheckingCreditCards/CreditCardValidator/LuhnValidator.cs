﻿using System;
using System.Linq;

namespace CheckingCreditCards.CreditCardValidator
{
    public class LuhnValidator : ICreditCardValidator
    {
        const byte ASCII_CHAR_ZERO = 48;

        public bool IsValid(string cardNumber)
        {
            int result = 0;

            var reversed = cardNumber.Replace(" ", String.Empty).ToCharArray().Reverse().ToArray();

            if (reversed.Length == 0)
            {
                return false;
            }

            for (var idx = 0; idx < reversed.Length; idx++)
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
