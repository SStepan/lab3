using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        
        public string GetName()
        {
            return Name;
        }

        public virtual void Info(bool b = true)
        {
            Console.Write("Age: {0}; ", Age);
            Console.Write("Name: {0}; ", Name);
            if (sex == true)
                Console.Write("Стать: чоловiк; ");
            else
                Console.Write("Стать: жiнка; ");
        }
    }

    class Student : Human
    {
        string patronomyk { get; set; }

        public Student(int a, string n, bool s, string pat) : base(a,n,s)
        {
            patronomyk = pat;
        }

        public string GetPatr()
        {
            return patronomyk;
        }
        public override void Info(bool b = true)
        {
            if(b == true)
                Console.BackgroundColor = ConsoleColor.Green;
            
            base.Info();
            Console.Write("Patronomyk: {0}; ", patronomyk);
        }
    }

    class Botan : Student
    {
        double ratint { get; set; }

        public Botan(int a, string n, bool s, string pat, double r) : base(a,n,s,pat)
        {
            ratint = r;
        }

        public double GetRating()
        {
            return ratint;
        }

        public override void Info(bool b = true)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            base.Info(false);
            Console.Write("rating: {0}; ", ratint);
        }
    }


    class Parent : Human
    {
        public int size { get; set; }

        public Parent(int a, string name, int Size) :
            base(a, name, true)
        {
            size = Size;
        }

        public override void Info(bool b = true)
        {
            if(b == true)
                Console.BackgroundColor = ConsoleColor.Yellow;
            base.Info();
            Console.Write("кiлькiсть дiтей: {0}; ", size);
        }
    }

    class CoolParent : Parent
    {
        public double money { get; set; }

        public CoolParent(int a, string name, int Size, double mon) :
            base(a, name, Size)
        {
            money = mon;
        }

        public double GerMoney()
        {
            return money;
        }

        public override void Info(bool b = true)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            base.Info(false);
            Console.Write("money: {0:0.000}; ", money);
        }
    }

   

    interface IGod
    {
        Human CreateHuman();
        Human CreateHuman(bool sex);
        Human CreatePair(Human h);
    }

    class StudenGod : IGod
    {
        public Human CreateHuman()
        {
            if (ParamsHum.rand.Next(0, 1) == 0)
                return new Student(ParamsHum.Age_student, ParamsHum.Name_male, true, ParamsHum.Patr_from_name());
            else
                return new Student(ParamsHum.Age_student, ParamsHum.Name_female, false, ParamsHum.Patr_from_name(false));
        }
        public Human CreateHuman(bool sex)
        {
            if(sex == true)
                return new Student(ParamsHum.Age_student, ParamsHum.Name_male, true, ParamsHum.Patr_from_name());
            else
                return new Student(ParamsHum.Age_student, ParamsHum.Name_female, false, ParamsHum.Patr_from_name(false));
        }

        public Human CreatePair(Human s)
        {
            return new Parent(ParamsHum.Age_Parent, ParamsHum.Name_from_patr(((Student)s).GetPatr()), ParamsHum.size_children);
        }
    }

    class BotanGod : IGod
    {
        public Human CreateHuman()
        {
            if (ParamsHum.rand.Next(0, 1) == 0)
                return new Botan(ParamsHum.Age_student, ParamsHum.Name_male, true, ParamsHum.Patr_from_name(), ParamsHum.rating);
            else
                return new Botan(ParamsHum.Age_student, ParamsHum.Name_female, false, ParamsHum.Patr_from_name(false), ParamsHum.rating);
        }
        public Human CreateHuman(bool sex)
        {
            if(sex == true)
                return new Botan(ParamsHum.Age_student, ParamsHum.Name_male, true, ParamsHum.Patr_from_name(), ParamsHum.rating);
            else
                return new Botan(ParamsHum.Age_student, ParamsHum.Name_female, false, ParamsHum.Patr_from_name(false), ParamsHum.rating);
        }
        public Human CreatePair(Human s)
        {
            return new CoolParent(ParamsHum.Age_Parent, ParamsHum.Name_from_patr(((Student)s).GetPatr()), ParamsHum.size_children, Math.Pow(10.0,((Botan)s).GetRating()));
        }
    }

    class ParentGod : IGod
    {
        public Human CreateHuman()
        {
                return new Parent(ParamsHum.Age_Parent, ParamsHum.Name_male, ParamsHum.size_children);
        }
        public Human CreateHuman(bool sex)
        {
            if (sex == true)
               return CreateHuman();
            else
                throw new Exception("Батько може бути тільки чоловічої статі");
        }

        public Human CreatePair(Human h)
        {
            if (ParamsHum.rand.Next(1, 2) == 1)
                return new Student(ParamsHum.Age_student, ParamsHum.Name_male, true, ParamsHum.Patr_from_name(((Parent)h).GetName()));
            else
                return new Student(ParamsHum.Age_student, ParamsHum.Name_female, false, ParamsHum.Patr_from_name(((Parent)h).GetName()));
        }
    }

    class CoolParentGod : IGod
    {
        public Human CreateHuman()
        {
                return new CoolParent(ParamsHum.Age_Parent, ParamsHum.Name_male, ParamsHum.size_children, ParamsHum.money); 
        }
        public Human CreateHuman(bool sex)
        {
            if (sex == true)
                return new CoolParent(ParamsHum.Age_Parent, ParamsHum.Name_male, ParamsHum.size_children, ParamsHum.money);
            else
                throw new Exception("Батько може бути тільки чоловічої статі");
        }
        public Human CreatePair(Human h)
        {
            if (ParamsHum.rand.Next(1, 2) == 1)
                return new Botan(ParamsHum.Age_student, ParamsHum.Name_male, true, ParamsHum.Patr_from_name(((Parent)h).GetName()), Math.Log10(((CoolParent)h).GerMoney()));
            else
                return new Botan(ParamsHum.Age_student, ParamsHum.Name_female, false, ParamsHum.Patr_from_name(((Parent)h).GetName()), Math.Log10(((CoolParent)h).GerMoney()));
        }
    }
    
    class God : IGod
    {
        public List<Human> humans = new List<Human>();
        IGod hum;

        public Human CreateHuman()
        {
            if (humans.Count == 0)
            {
                hum = ParamsHum.rand_factory();

                humans.Add(hum.CreateHuman(true));
                return humans.Last();
            }
            else if (humans.Count == 1)
            {
                
                return CreateHuman(false);
            }
            else
            {
                hum = ParamsHum.rand_factory();
                humans.Add(hum.CreateHuman());
                return humans.Last();
            }
        }
        public Human CreateHuman(bool sex)
        {
            if (sex == false)
            {
                do
                {
                    hum = ParamsHum.rand_factory();
                }
                while (hum is ParentGod);
            }
            else
                hum = ParamsHum.rand_factory();

            humans.Add(hum.CreateHuman(sex));
            return humans.Last();
        }
        
        

        public Human CreatePair(Human h)
        {
            Human human;
            
            if (h is Botan)
            {
                hum = new BotanGod();
                human = hum.CreatePair(h);
                humans.Add(human);
                return human;
            }
            else if(h is CoolParent)
            {
                hum = new CoolParentGod();
                human = hum.CreatePair(h);
                humans.Add(human);
                return human;
            }
            else if (h is Student)
            {
                hum = new StudenGod();
                human = hum.CreatePair(h);
                humans.Add(human);
                return human;
            }
            else
            {
                hum = new ParentGod();
                human = hum.CreatePair(h);
                humans.Add(human);
                return human;
            }
        }

        public double this[int index]
        {
            get
            {
                if(humans[index] is CoolParent)
                    return ((CoolParent)humans[index]).GerMoney();
                else
                    return 0;
            }
        }

        public double GetTotalMoney()
        {
            double d = 0;
            for (int i = 0; i < humans.Count - 1; i++)
                d += this[i];
            return d;
        }

        public void money_in_file()
        {
            string text = "кiлькiсть грошей у крутих предкiв: " + Math.Round(this.GetTotalMoney(), 3);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(text);

            string path = @"F:\file.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(text);
            }
        }
    }
}
