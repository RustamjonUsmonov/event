using System;

namespace EventApp
{
    class Firedepartment
    {
        public void Work(string pname)
        {
            Console.WriteLine($"Пожарные едут в {pname}!!!");
        }
    }
    class Ambulance
    {
        public void Work(string pname)
        {
            Console.WriteLine($"Скорая едет в {pname}!!!");
        }
    }
    class Help
    {
        public void Work(string pname)
        {
            Console.WriteLine($"Помощь едет в {pname}!!!");

        }
    }
    class Station
    {
        public string Name { get; set; }
        public int CurrentTemp { get; set; }
        public int MaxTemp { get; set; }

        public event Action<string> Burning;

        public Station(string name, int cur, int max)
        {
            Name = name;
            CurrentTemp = cur;
            MaxTemp = max;
        }
        public void TempUp()
        {
            CurrentTemp += 100;
            if (CurrentTemp >= MaxTemp)
                Burning?.Invoke(Name);
        }

        public override string ToString()
        {
            return $"{Name} Current - {CurrentTemp}    Max - {MaxTemp}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Station p1 = new Station("Казань", 300, 1000);
            Station p2 = new Station("Винтерхол", 300, 1100);

            Firedepartment fd = new Firedepartment();
            Ambulance amb = new Ambulance();
            Help help = new Help();

            p1.Burning += fd.Work;
            p1.Burning += amb.Work;
            p1.Burning += help.Work;

            p2.Burning += fd.Work;
            p2.Burning += amb.Work;
            p2.Burning += help.Work;

            for (int i = 0; i < 20; i++)
            {
                if (p2.CurrentTemp >= p2.MaxTemp)
                {
                    break;
                }
                else
                {
                    p2.TempUp();
                }

                if (p1.CurrentTemp >= p1.MaxTemp)
                {
                }
                else
                {
                    p1.TempUp();
                }
                Console.WriteLine(p1);
                Console.WriteLine(p2);
            }
            Console.ReadKey();
        }
    }
}