using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        string suit;
        string rank;
        int value;

        public Card(string suit, string rank)
        {
            this.suit = suit;
            this.rank = rank;
            switch (rank)
            {
                case "Jack":
                case "Queen":
                case "King":
                    value = 10;
                    break;
                case "Ace":
                    value = 1;
                    break;
                case "1":
                    value = 1;
                    break;
                case "2":
                    value = 2; break;
                case "3":
                    value = 3; break;
                case "4":
                    value = 4; break;
                case "5":
                    value = 5; break;
                case "6":
                    value = 6; break;
                case "7":
                    value = 7; break;
                case "8":
                case "9":
                    value = 9; break;
            }
        }

        public override string ToString()
        {
            return $"{rank} of {suit}";
        }
    }
}

