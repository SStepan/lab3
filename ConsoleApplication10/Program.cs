using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date_now = DateTime.Now;
            DateTime date_future = new DateTime(date_now.Year, date_now.Month, date_now.Day + 7);
            if (date_now < date_future)
            {
                Console.WriteLine("Введiть кiлькiсть людей: ");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine();
                God god = new God();
                int k = 0;
                for (int i = 0; i < n; i++)
                {
                    god.CreateHuman();
                    god.humans[i].Info();
                    Console.WriteLine();
                    if (i == 0)
                        k = Console.CursorTop;

                    Console.WriteLine();
                }
                for (int i = 0; i < n; i++)
                {
                    god.CreatePair(god.humans[i]);
                }


                Console.BackgroundColor = ConsoleColor.Magenta;
                for (int i = n; i < god.humans.Count; i++)
                {
                    Console.CursorTop = k;
                    Console.CursorLeft = 0;

                    god.humans[i].Info(false);
                    k += 2;
                }

                Console.WriteLine();
                Console.WriteLine();

                god.money_in_file();
            }
            else
            {
                Console.WriteLine("Sorry:)");
            }


            Console.ReadLine();
        }
    }
}

