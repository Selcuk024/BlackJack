namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("this is a test, write down something");
            string message = Console.ReadLine();
            Console.WriteLine("you chose this, correct?:" + message);
        }
    }
}
