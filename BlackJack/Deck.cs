using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Deck
    {
        List<Card> cards = new List<Card>();

        public Deck()
        {
        string[] category = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] type = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        int index = 0;
            foreach (string suit in category)
            {
                foreach (string rank in type)
                {
                    cards.Add(new Card(suit, rank));
                }
}
        }
     
        public Card drawCard()
        {
            return cards[0];
        }
    }
}
