using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player
    {
        List<Card> hand = new List<Card>();
        public void addToHand(Card cards) {
            hand.Add(cards);
        }
        public void showHand()
        {
            for (int i = 0; i < hand.Count; i++)
            {
                Console.WriteLine(hand[i]);
            }
        }
    }
}
