using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    abstract class Human
    {
        int Age { get; set; }
        string Name { get; set; }
        bool sex;

        public Human(int a, string n, bool s)
        {
            Age = a;
            Name = n;
            sex = s;
        }

        public void Info()
        {
            Console.Write("Age: {0} \n", Age);
            Console.Write("Name: {0} \n", Name);
            if (sex == true)
                Console.Write("Sex: чоловік \n");
            else
                Console.Write("Sex: жінка \n");
        }
    }

    class Student : Human
    {
        string patronomyk { get; set; }

        public Student(int a, string n, bool s, string pat) : base(a,n,s)
        {
            patronomyk = pat;
        }

        public void Info()
        {
            base.Info();
            Console.WriteLine("Patronomyk: {0}", patronomyk);
        }
    }

    class Botan : Student
    {
        double ratint { get; set; }

        public Botan(int a, string n, bool s, string pat, double r) : base(a,n,s,pat)
        {
            ratint = r;
        }

        public void Info()
        {
            base.Info();
            Console.Write("rating: {0}", ratint);
        }
    }


    class Parent : Human
    {
        public int size { get; set; }

        public Parent(int a, string name, bool s, int Size) :
            base(a, name, s)
        {
            size = Size;
        }

        virtual public void Info()
        {
            base.Info();
            Console.WriteLine("\nsize: " + size);
        }
    }

    class CoolParent : Parent
    {
        public double money { get; set; }

        public CoolParent(int a, string name, bool s, int Size, double mon) :
            base(a, name, s, Size)
        {
            money = mon;
        }

        public void Info()
        {
            base.Info();
            Console.WriteLine("money: " + money);
        }
    }

    static class Names
    {
        public static string[] mas_male = new string[] { "Іван", "Степан", "Андрій", "Антон", "Сергій", "Михайло", "Микола", "Василь" };
        public static string[] mas_female = new string[] { "Ольга", "Ірина", "Наталія", "Роксолана", "Галина", "Оксана", "Христина" };
    }

    abstract class HumanFactory
    {
        public Random rand = new Random();
        public abstract Human CreateHuman();
        public abstract Human CreateHuman(bool sex);
    }

    class StudenFactory : HumanFactory
    {
        public override Human CreateHuman()
        {
            if (rand.Next(0, 1) == 0)
                return new Student(rand.Next(17, 21), Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)], true, Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)] + "ович");
            else
                return new Student(rand.Next(17, 21), Names.mas_female[rand.Next(0, Names.mas_male.Length - 1)], false, Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)] + "овна");
        }
        public override Human CreateHuman(bool sex)
        {
            if(sex == true)
                return new Student(rand.Next(17, 21), Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)], true, Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)] + "ович");
            else
                return new Student(rand.Next(17, 21), Names.mas_female[rand.Next(0, Names.mas_male.Length - 1)], false, Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)] + "овна");
        }
    }

    class BotanFactory : HumanFactory
    {
        public override Human CreateHuman()
        {
            if (rand.Next(0, 1) == 0)
                return new Botan(rand.Next(17, 21), Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)], true, Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)] + "ович", rand.Next(30, 50) * 0.1);
            else
                return new Botan(rand.Next(17, 21), Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)], false, Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)] + "овна", rand.Next(30, 50) * 0.1);
        }
        public override Human CreateHuman(bool sex)
        {
            if(sex == true)
                return new Botan(rand.Next(17, 21), Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)], true, Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)] + "ович", rand.Next(30, 50) * 0.1);
            else
                return new Botan(rand.Next(17, 21), Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)], false, Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)] + "овна", rand.Next(30, 50) * 0.1);
        }
    }

    class ParentFactory : HumanFactory
    {
        public override Human CreateHuman()
        {
            if (rand.Next(0, 1) == 0)
                return new Parent(rand.Next(35, 45), Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)], true, rand.Next(1, 5));
            else
                return new Parent(rand.Next(35, 45), Names.mas_female[rand.Next(0, Names.mas_male.Length - 1)], false, rand.Next(1, 5));
        }
        public override Human CreateHuman(bool sex)
        {
            if(sex == true)
                return new Parent(rand.Next(35, 45), Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)], true, rand.Next(1, 5));
            else
                return new Parent(rand.Next(35, 45), Names.mas_female[rand.Next(0, Names.mas_male.Length - 1)], false, rand.Next(1, 5));
        }
    }

    class CoolParentFactory : HumanFactory
    {
        public override Human CreateHuman()
        {
            if (rand.Next(0, 1) == 0)
                return new CoolParent(rand.Next(35, 45), Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)], true, rand.Next(1, 5), rand.Next(100000, 1000000) * 0.1);
            else
                return new CoolParent(rand.Next(35, 45), Names.mas_female[rand.Next(0, Names.mas_male.Length - 1)], false, rand.Next(1, 5), rand.Next(100000, 1000000) * 0.1);
        }
        public override Human CreateHuman(bool sex)
        {
            if(sex == true)
                return new CoolParent(rand.Next(35, 45), Names.mas_male[rand.Next(0, Names.mas_male.Length - 1)], true, rand.Next(1, 5), rand.Next(100000, 1000000) * 0.1);
            else
                return new CoolParent(rand.Next(35, 45), Names.mas_female[rand.Next(0, Names.mas_male.Length - 1)], false, rand.Next(1, 5), rand.Next(100000, 1000000) * 0.1);
        }
    }

    class Person
    {
        public List<Human> humans = new List<Human>();

        public void CreateHuman(HumanFactory factory)
        {
            humans.Add(factory.CreateHuman());
        }
        public void CreateHuman(HumanFactory fact, bool sex)
        {
            humans.Add(fact.CreateHuman(sex));
        }
        
        public void Hit()
        {
            humans[0].Info();
        }
    }
}
