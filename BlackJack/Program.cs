using System;
using System.Runtime.InteropServices;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Deck Deck = new Deck();
            Player player = new Player();
            List<Player> players = new List<Player>();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("C");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("A");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("S");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("I");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("N");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("O");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" R");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("O");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Y");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("A");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("L");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("E" + "\n");
            Console.ResetColor();

            int people = 0;

            string[] Array = { "Hit", "Pass", "Fold" };
            Console.WriteLine("The maximum amount of people allowed on this table is 4 people");
            Console.WriteLine("Do you want to shuffle the deck?");
            string yesOrNo = Console.ReadLine();
            if (yesOrNo != "yes")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-1 point deduction");
                Console.ResetColor();
            }
            else{
                Console.WriteLine("Shuffling deck...");
                Deck.Shuffle();
            }


            Console.WriteLine("How many people will play?");
            do
            {
                if(people >= 5)
                {
                    Console.WriteLine("The maximum amount of people allowed on this table is 4 people");
                }
              people = Convert.ToInt32(Console.ReadLine());
            } while (people >= 5);


             for(int i = 0; i < people; i++)
            {
                players.Add(new Player());
                Console.WriteLine(players[i]);
            }

                foreach (var hand in players)
                {
                Card drawnCard = Deck.drawCard();
                Console.WriteLine("players move is:");
                Console.WriteLine(Array[random.Next(0, Array.Length)]);
                Console.WriteLine("Hit or Fold depending on the player choice");
                string dealersMove = Console.ReadLine();
                if (dealersMove == "hit")
                    {
                        player.addToHand(drawnCard);
                        player.showHand();
                    }
                }
 

        }
        
    }
}
