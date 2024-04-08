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
            Card drawnCard = Deck.drawCard();
            
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


            var randomIndex = random.Next(0, Array.Length);


            Console.WriteLine(Array[randomIndex]);
            Console.WriteLine("How many people will play?");
            do
            {
                if(people >= 5)
                {
                    Console.WriteLine("The maximum amount of people allowed on this table is 4 people");
                }
              people = Convert.ToInt32(Console.ReadLine());
            } while (people > 7);

            for(int i = 0; i < people; i++)
            {
                Console.WriteLine("Please wait until the player has told you their move");
                Thread.Sleep(300);
                Console.WriteLine(Array[randomIndex]);
                Console.WriteLine("Hit or Pass to the player depending on their move");
                string dealerMove = Console.ReadLine();
                if(dealerMove == "hit")
                {


                }

            }
        }
        
    }
}
