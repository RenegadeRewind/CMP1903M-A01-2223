using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        public static List<Card> pack;
        
        public Pack()
        {
            //Initialise the card pack here
            pack = new List<Card>();

            //creates 52 unique card instances 
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    Card a = new Card(i, j);
                    pack.Add(a);
                }
            }
        }

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle
            switch (typeOfShuffle)
            {
                case 1:
                    {
                        //fisher yates shuffle:
                        //each element is randomly drawn from a hat and placed into the pile

                        //tempList is like the hat in this case
                        List<Card> tempList = new List<Card>();
                        tempList.AddRange(pack);
                        int amount = tempList.Count();
                        for (int i = 1; i <= amount; i++)
                        {
                            Random randint = new Random();
                            int randomValue = randint.Next(0, tempList.Count()-1);
                            pack[i-1] = tempList[randomValue];
                            tempList.RemoveAt(randomValue);
                        }
                        break;
                    }

                case 2:
                    {
                        //riffle shuffle:
                        //the kinda cool one where the deck gets halved and then the two halves are joined back together
                        //you know that thing you do with books sometimes where you pull one half back and let the pages slide past your finger
                        //yeah that but with two piles of cards and the piles are combined into one by doing so
                        //thats the best description i can offer, no idea how you're supposed to describe this one with just text
                        // - a programmer who does not shuffle cards

                        for (int i = 1; i <= 3; i++)    //repeats the shuffle 3 times to increase randomness
                        {
                            //gets the amount of cards and splits the pack into two halves
                            int amount = pack.Count() / 2;
                            List<Card> tempListFirstHalf = new List<Card>();
                            List<Card> tempListSecondHalf = new List<Card>();
                            tempListFirstHalf = pack.GetRange(0, amount);
                            tempListSecondHalf = pack.GetRange(amount, pack.Count() - amount);

                            //recombines the two packs
                            for (int j = 1; j < pack.Count(); j++)
                            {
                                Random randint = new Random();  //the cards from each half have a 50/50 chance of being next to be added back into the pile
                                switch (randint.Next(1, 3))     //again, this further increases the randomness, if it was just one pack then the other, then it would not function correctly as a shuffle
                                {
                                    case 1:
                                        try
                                        {
                                            pack[j-1] = tempListFirstHalf[0];
                                            tempListFirstHalf.RemoveAt(0);
                                        }

                                        catch (ArgumentOutOfRangeException)    //if theres no cards left, add one from the other half instead
                                        {
                                            pack[j-1] = tempListSecondHalf[0];
                                            tempListSecondHalf.RemoveAt(0);
                                        }
                                        break;

                                    case 2:
                                        try
                                        {
                                            pack[j-1] = tempListSecondHalf[0];
                                            tempListSecondHalf.RemoveAt(0);
                                        }

                                        catch (ArgumentOutOfRangeException)    //if theres no cards left, add one from the first half instead
                                        {
                                            pack[j-1] = tempListFirstHalf[0];
                                            tempListFirstHalf.RemoveAt(0);
                                        }
                                        break;
                                }

                            }
                        }

                        break;
                    }

                case 3:
                    {
                        //no shuffle
                        //do nothing i guess??
                        break;
                    }

                default:
                    {
                        //just incase someone writes a value thats out of range
                        Console.WriteLine("Invalid shuffle request");
                        break;
                    }
            }
            return true;    //honestly, not entirely sure what to return so we'll just go with true for now
        }
        public static Card deal()
        {
            //Deals one card
            Card dealtCard = pack[0];
            pack.RemoveAt(0);
            return dealtCard;
        }
        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            List<Card> dealtCards = new List<Card>();

            for (int i = 1; i <= amount; i++)
            {
                dealtCards.Add(pack[0]);
                pack.RemoveAt(0);
            }

            return dealtCards;
        }
    }
}
