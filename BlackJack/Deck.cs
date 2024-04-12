using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Deck
    {
        List<Card> cards = new List<Card>();
        Random random = new Random();


        public Deck()
        {
        string[] category = { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] type = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (string suit in category)
            {
                foreach (string rank in type)
                {
                    cards.Add(new Card(suit, rank));
                }
}
        }
        public void Shuffle()
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int randomInt = random.Next(n + 1);
                Card value = cards[randomInt];
                cards[randomInt] = cards[n];
                cards[n] = value;
            }
        }
        public Card drawCard()
        {
            if (cards.Count == 0)
            {
                Console.WriteLine("The deck is empty");
                return null;
            }
           // for (int i = 0; i < cards.Count; i++)
            //{
              //  Console.WriteLine(cards[i]);
            ///}
            Card drawnCard = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return drawnCard;
        }
    }
}
