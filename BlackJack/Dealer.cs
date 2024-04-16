using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Dealer
    {
        List<Card> dealerHand = new List<Card>();

        int points = 0;

        public void removePoints()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-1 point deduction");
            Console.ResetColor();
            points--;
            Console.WriteLine("    Your current points are: " + points);
        }
        public void addPoints()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Goodjob! +1 point");
            Console.ResetColor();
            points++;
            Console.WriteLine("    Your current points are: " + points);

        }
        public int calculateHandValue()
        {
            int value = 0;
            foreach (var card in dealerHand)
            {
                value += card.value;
            }
            return value;
        }
        public void addToDealerHand(Card cards)
        {
            dealerHand.Add(cards);
        }
        public void showDealerHand()
        {
            for (int i = 0; i < dealerHand.Count; i++)
            {
                Console.WriteLine(dealerHand[i]);
            }
        }
    }
}
