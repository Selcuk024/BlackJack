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

        public int bet { get; set; }

        public int balance {get; set;}
        public bool Passed { get; set; }
        public int PlayerNumber { get; } 
        public Player(int playerNumber)
        {
            PlayerNumber = playerNumber;
        }
        public int getBalance()
        {
            return balance;
        }
        public int placeBets(int number)
        {

            bet = number;
            balance = balance - bet;

            Console.WriteLine($"Player {PlayerNumber}'s bet is: " + bet);
            Console.WriteLine($"Player {PlayerNumber}'s chips left: " + balance);
            return balance;
        }
        public void giveBets(int number)
        {
            balance = bet + number;
            Console.WriteLine($"Player {PlayerNumber}'s amount of chips left is:");
        }
        public void removeBets()
        {
            balance = balance - bet;
            Console.WriteLine($"Player {PlayerNumber}'s amount of chips left is:");
        }
        public void addToHand(Card cards) {
            hand.Add(cards);
        }
        public void showHand()
        {
            for (int i = 0; i < hand.Count; i++)
            {
                Console.WriteLine(  hand[i]);
            }
        }
        public int calculateHandValue()
        {
            int value = 0;
            foreach (var card in hand)
            {
                value += card.value;
            }
            return value;
        }
    }
}
