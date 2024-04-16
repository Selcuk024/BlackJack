using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerMove;
            Random random = new Random();
            Deck Deck = new Deck();
            List<Player> players = new List<Player>();
            Dealer dealer = new Dealer();
            List<Dealer> dealers = new List<Dealer>();
            int dealerCardValue = dealer.calculateHandValue();

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

            string[] Array = { "Hit", "Pass" };
            Console.WriteLine("The maximum amount of people allowed on this table is 4 people");
            dealers.Add(new Dealer());
            Console.WriteLine("Do you want to shuffle the deck?");
            string yesOrNo = Console.ReadLine();
            if (yesOrNo != "yes")
            {
                dealer.removePoints();
            }
            else
            {
                dealer.addPoints();
                Console.WriteLine("Shuffling deck...");
                Deck.Shuffle();
            }


            Console.WriteLine("How many people will play?");
            do
            {
                if (people >= 5)
                {
                    Console.WriteLine("The maximum amount of people allowed on this table is 4 people");
                }
                people = Convert.ToInt32(Console.ReadLine());
            } while (people >= 5);


            for (int i = 0; i < people; i++)
            {
                players.Add(new Player(i + 1));
            }

            foreach (var Player in players)
            {
                Player.balance = 1000;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"player {Player.PlayerNumber}'s bet: ");
                Console.ResetColor();
                int chooseBet = random.Next(0, Player.balance);
                Player.placeBets(chooseBet);
            }
            bool allPlayersFolded = false;
            bool dealerPassed = false;

            bool dealTwoCards = false;
            Console.WriteLine("Do you want to start dealing cards?");
            string dealTwo = Console.ReadLine().ToLower();
            if (dealTwo != "yes")
            {
                dealTwoCards = false;
            }
            else
            {
                Console.WriteLine("How many?");
                int numberOfCards = Convert.ToInt32(Console.ReadLine());
                if (numberOfCards != 2) {
                    dealer.removePoints();
                }
                else
                {
                    dealTwoCards = true;
                }
            }

            if (dealTwoCards == true)
            {
                for(int i = 0; i < 2; i++)
                {
                    foreach (var Player in players)
                    {
                        dealer.addPoints();
                        Card drawnCard = Deck.drawCard();
                        Player.addToHand(drawnCard);
                        Player.showHand();
                    }
                }
            }
            else
            {
                dealer.removePoints();
            }

            while (!allPlayersFolded && !dealerPassed)
            {
                allPlayersFolded = true;
                foreach (var Player in players)
                {

                    int playerCardValue = Player.calculateHandValue();
                    if (!Player.Passed)
                    {
                        allPlayersFolded = false;
                        Console.WriteLine($"Player {Player.PlayerNumber}'s turn: ");
                        Console.WriteLine($"Player's move is: {playerMove = Array[random.Next(0, Array.Length)]}");

                        if (!Player.Passed)
                        {
                            Console.WriteLine("Hit or Pass depending on the player's choice");
                            string dealerMove = Console.ReadLine().ToLower();

                            if (playerMove == "Hit" && dealerMove == "hit")
                            {
                                dealer.addPoints();
                                Card drawnCard = Deck.drawCard();
                                Player.addToHand(drawnCard);
                                Console.WriteLine($"Player {Player.PlayerNumber}'s current deck is:");
                                Player.showHand();

                            }
                            else if (playerMove == "Pass" && dealerMove == "pass")
                            {
                                dealer.addPoints();
                                Player.Passed = true;
                                Console.WriteLine("Player has passed.");
                                Console.WriteLine($"Player {Player.PlayerNumber}'s deck was:");
                                Player.showHand();
                                Console.WriteLine(playerCardValue);

                            }
                            else if (playerMove == "Hit" && dealerMove == "pass" || playerMove == "Pass" && dealerMove == "hit")
                            {
                                {
                                    dealer.removePoints();
                                }
                            }
                            else if (Player.calculateHandValue() > 21 && dealerMove == "hit")
                            {
                                dealer.removePoints();
                            }
                            else if (Player.calculateHandValue() > 21 && dealerMove == "busted")
                            {
                                dealer.addPoints();
                                Player.Passed = true;
                            }
                        }
                    }

                }
                if (allPlayersFolded)
                {
                    while (!dealerPassed)
                    {
                        Console.WriteLine("Dealer's turn:");
                        string dealerMove = Console.ReadLine().ToLower();

                        if (dealerMove == "hit" && dealerCardValue <= 17)
                        {
                            dealer.addPoints();
                            Card drawnCard = Deck.drawCard();
                            dealer.addToDealerHand(drawnCard);
                            Console.WriteLine("Dealer draws a card:");
                            dealer.showDealerHand();
                            dealerCardValue = dealer.calculateHandValue();
                        }
                        else if (dealerMove == "hit" && dealerCardValue >= 17)
                        {
                            dealer.removePoints();
                        }
                        else
                        {
                            dealer.addPoints();
                            Console.WriteLine("Dealer passes.");
                            dealerPassed = true;
                            break;
                        }
                    }
                }

            }
            Console.WriteLine("Game ended time for the payouts: ");
            foreach (var Player in players)
            {
                int playerCardValue = Player.calculateHandValue();

                Console.WriteLine($"Player {Player.PlayerNumber}'s payout is: ");
                Console.WriteLine($"(Player {Player.PlayerNumber}'s bet was:{Player.bet} )");

                int dealerMove = Convert.ToInt32(Console.ReadLine());
                if (playerCardValue > dealerCardValue && dealerMove != Player.bet * 2)
                {
                    dealer.removePoints();
                }
                else if (playerCardValue > dealerCardValue && dealerMove == Player.bet * 2)
                {
                    dealer.addPoints();
                    Player.giveBets(dealerMove);
                }

            }

        }
    }
}
