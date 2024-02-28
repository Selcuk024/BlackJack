namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = 0;
            Console.WriteLine("How many people will play?");
            do
            {
                if(people >= 5)
                {
                    Console.WriteLine("The maximum amount of people allowed on this table is 4 people");
                }
              people = Convert.ToInt32(Console.ReadLine());
            } while (people > 7);

        }
    }
}
