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

            Console.WriteLine("Введiть кiлькiсть людей: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            God god = new God();
            int k = 0;
            for(int i =0; i < n; i++)
            {
                god.CreateHuman();
                god.humans[i].Info();
                Console.WriteLine();
                if (i == 0)
                    k = Console.CursorTop;
                
                Console.WriteLine();
            }
            for(int i =0; i< n; i++)
            {
                god.CreatePair(god.humans[i]);
            }


            Console.BackgroundColor = ConsoleColor.Magenta;
            for(int i=n; i<god.humans.Count; i++)
            {
                Console.CursorTop = k;
                Console.CursorLeft = 0;

                god.humans[i].Info(false);
                k += 2;
            }


            Console.WriteLine();
            Console.WriteLine();

            string text = "кiлькiсть грошей у крутих предкiв: " + Math.Round(god.GetTotalMoney(), 3);

            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(text);

            string path = @"F:\file.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(text);
            }


                Console.ReadLine();
        }
    }
}

