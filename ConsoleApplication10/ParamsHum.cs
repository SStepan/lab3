using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    static class ParamsHum
    {
        public static string[] mas_male = new string[] { "Iван", "Степан", "Андрiй", "Антон", "Сергiй", "Михайло", "Миколай", "Василь" };
        public static string[] mas_female = new string[] { "Ольга", "Iрина", "Наталiя", "Роксолана", "Галина", "Оксана", "Христина" };
        public static Random rand = new Random();

        public static int Age_student
        {
            get
            {
                return rand.Next(17, 21);
            }
        }


        public static int Age_Parent
        {
            get
            {
                return rand.Next(35, 45);
            }
        }

        public static int size_children
        {
            get
            {
                return rand.Next(1, 5);
            }
        }

        public static double money
        {
            get
            {
                return rand.Next(100000, 1000000) * 0.1;
            }
        }
        public static string Name_male
        {
            get
            {
                return mas_male[rand.Next(0, mas_male.Length - 1)];
            }
        }
        public static string Name_female
        {
            get
            {
                return mas_female[rand.Next(0, mas_female.Length - 1)];
            }
        }
        public static string Patr_from_name(bool boo = true)
        {
            if (boo == true)
                return Name_male + "ович";
            else
                return
                    Name_male + "овна";
        }
        public static string Patr_from_name(string s, bool boo = true)
        {
            if (boo == true)
                return s + "ович";
            else
                return s + "овна";
        }

        public static double rating
        {
            get
            {
                return rand.Next(30, 50) * 0.1;
            }
        }

        public static string Name_from_patr(string s)
        {
                return s.Remove(s.Length - 4, 4);
        }

        public static IGod rand_factory()
        {
            int k = ParamsHum.rand.Next(0, 3);
            if (k == 0)
                return new StudenGod();
            else if (k == 1)
                return new BotanGod();
            else if (k == 2)
                return new ParentGod();
            else
                return new CoolParentGod();
        }
    }
}
