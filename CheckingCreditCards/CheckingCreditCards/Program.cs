using CheckingCreditCards.CardType;
using CheckingCreditCards.CreditCardValidator;
using CheckingCreditCards.Factory;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CheckingCreditCards
{

    class Program
    {
        readonly static Tuple<Regex, Type>[] CARDDEFINITIONS =
        {
           new Tuple<Regex, Type>(new Regex("^4([0-9]{12}|[0-9]{15})$"), typeof(VisaCreditCard)),
           new Tuple<Regex, Type>(new Regex("^3(4|7)[0-9]{13}$"), typeof(AmexCreditCard)),
           new Tuple<Regex, Type>(new Regex("^6011[0-9]{12}$"), typeof(DiscoverCreditCard)),
           new Tuple<Regex, Type>(new Regex("^5[1-5][0-9]{14}$"), typeof(MasterCardCreditCard))
        };

        static void Main(string[] args)
        {
            var keepGoing = true;
            Console.WriteLine("Enter individual credit card numbers at the prompt:");
            Console.WriteLine("Enter 'f' to enter an input file name:");
            Console.WriteLine("Enter 'x' to exit:");

            ICreditCardValidator validator = new LuhnValidator();
            ICreditCardFactory factory = new CreditCardFactory(validator, CARDDEFINITIONS);
                
            while(keepGoing)
            {
                Console.Write("Enter card number > ");
                var cardNumber = Console.ReadLine();

                if(cardNumber == "x")
                {
                    keepGoing = false;
                }
                else if (cardNumber == "f")
                {
                    Console.Write("Enter a file name of credit card numbers > ");
                    var filename = Console.ReadLine();

                    if(!File.Exists(filename))
                    {
                        Console.WriteLine("File does not exist: " + filename);
                    }
                    else
                    {
                        try
                        {
                            using (StreamReader sr = new StreamReader(filename))
                            {
                                while ((cardNumber = sr.ReadLine()) != null)
                                {
                                    CreditCard card = factory.CreateCreditCard(cardNumber);
                                    var result = card.ToString();
                                    Console.WriteLine(result);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("The file could not be read:");
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                else
                {
                    CreditCard card = factory.CreateCreditCard(cardNumber);
                    var result = card.ToString();
                    Console.WriteLine(result);
                }
            }
        }
    }
}
