using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Database;

namespace Game.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Get top 10 EASY wins\n");
            Db.getTopTen();

            String input = "";

            while (input != "exit")
            {
                Console.Write("Enter a userID: ");
                input = Console.ReadLine();

                if (input != "exit")
                    Db.getUser(input);

                Console.WriteLine("Grabbing Single User: {0}\n" + Db.getUser(input) + "\n", input);

            }

            /*Console.WriteLine("Grabbing Single User: Cindy\n" + Db.getUser("Cindy"));
            Console.WriteLine("Grabbing Single User: James\n" + Db.getUser("James"));*/
            Console.Write("\nFinished!");
            Console.ReadLine();
        }
    }
}
