using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Testing
    {
        public static void TestProgram()
        {
            Pack cardPack = new Pack();
            List<string> cards = packToStringConverter();

            //tests pack instantiation
            Console.WriteLine("instantiated pack: \n"); 
            foreach(var card in cards) { Console.WriteLine(card); };
            Console.WriteLine("\n \n");

            //tests all pack shuffles
            for (int i = 1; i  <= 3; i++)
            {
                Pack.shuffleCardPack(i);
                cards = packToStringConverter();
                Console.WriteLine("Pack after shuffle " + i + ": \n");
                foreach (var card in cards) { Console.WriteLine(card); };
                Console.WriteLine("\n");
            }

            //tests card dealing
            Console.WriteLine("\nDrawn card: " + Pack.deal());
            Console.WriteLine("first 10 drawn cards: " + Pack.dealCard(10));
            Console.WriteLine("\nPress enter to exit...");
            Console.ReadLine();     //'sleep' so the tester can read outputs
        }
        

        public static List<string> packToStringConverter()  //its inefficient but it works
        {
            List<string> cards = new List<string>();
            for (int i = 0; i <= Pack.pack.Count() - 1; i++)
            {
                string card;
                switch (Pack.pack[i].Suit)  //the suit that corresponds to each number is not given
                                            //for simplicity, it will be assumed that:
                                            //1 - clubs
                                            //2 - spades
                                            //3 - hearts
                                            //4 - diamonds
                {
                    case 1:                 //for further simplicity, when outputted, numbers (such as 1 or 11) will not be converted to their card equivalent (like ace or jack)
                        card = Pack.pack[i].Value.ToString() + " of clubs";
                        break;

                    case 2:
                        card = Pack.pack[i].Value.ToString() + " of spades";
                        break;

                    case 3:
                        card = Pack.pack[i].Value.ToString() + " of hearts";
                        break;

                    case 4:
                        card = Pack.pack[i].Value.ToString() + " of diamonds";
                        break;

                    default:
                        card = null;
                        break;
                }
                cards.Add(card);
            }

            return cards;
        }
    }
}
