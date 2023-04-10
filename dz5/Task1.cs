using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace dz5
{
    internal class Task1
    {
        public static void Run()
        {
            Magasine magasine1 = new Magasine(), magasine2 = new Magasine();
            Console.WriteLine("Enter first magasine's parameters: ");
            magasine1.Init();
            Console.WriteLine("Enter second magasine's parameters: ");
            magasine2.Init();
            string action, magasine;
            do
            {
                Console.Write("Enter what to do( rise(workers), cut(workers), compare, show, exit): ");
                action = Console.ReadLine();
                switch (action)
                {
                    case "rise":
                        Console.Write("Enter which magasine to work with(first, second): ");
                        magasine = Console.ReadLine();
                        Console.Write("Enter num of rising: ");
                        int rise;
                        int.TryParse(Console.ReadLine(), out rise);
                        if (magasine == "first")
                            magasine1 = magasine1 + rise;
                        else if (magasine == "second")
                            magasine2 = magasine2 + rise;
                        break;

                    case "cut":
                        Console.Write("Enter which magasine to work with(first, second): ");
                        magasine = Console.ReadLine();
                        Console.Write("Enter num of cutting: ");
                        int cut;
                        int.TryParse(Console.ReadLine(), out cut);
                        if (magasine == "first")
                            magasine1 = magasine1 - cut;
                        else if (magasine == "second")
                            magasine2 = magasine2 - cut;
                        break;

                    case "compare":
                        Console.Write("Which compare result you want(>, <, ==, !=, Equals): ");
                        string compare = Console.ReadLine();
                        switch (compare)
                        {
                            case ">":
                                Console.WriteLine($"Result(magasine1 > magasine2): {magasine1 > magasine2}");
                                break;
                            case "<":
                                Console.WriteLine($"Result(magasine1 < magasine2): {magasine1 < magasine2}");
                                break;
                            case "==":
                                Console.WriteLine($"Result(magasine1 == magasine2): {magasine1 == magasine2}");
                                break;
                            case "!=":
                                Console.WriteLine($"Result(magasine1 != magasine2): {magasine1 != magasine2}");
                                break;
                            case "Equals":
                                Console.WriteLine($"Result(magasine1.Equals(magasine2)): {magasine1.Equals(magasine2)}");
                                break;
                        }
                        break;

                    case "show":
                        Console.WriteLine("First magasines's info:");
                        magasine1.ShowInfo();
                        Console.WriteLine("Second magasines's info:");
                        magasine2.ShowInfo();
                        break;
                }

            } while (action != "exit");
        }

    }
    class Magasine
    {
        private string _name { get; set; }
        private uint _found_year { get; set; }
        private string _description { get; set; }
        private string _phone { get; set; }
        private string _email { get; set; }
        private int _number_of_workers { get; set; }

        public Magasine()
        {
            this._name = "None";
            this._found_year = 0;
            this._description = "None";
            this._phone = "None";
            this._email = "None";
            this._number_of_workers = 0;
        }

        public Magasine(string name, uint found_year, string description, string phone, string email, int number_workers)
        {
            this._name = name;
            this._found_year = found_year;
            this._description = description;
            this._phone = phone;
            this._email = email;
            this._number_of_workers = number_workers;
        }

        public void Init()
        {
            uint num;
            int num2;
            Console.Write("Enter name: ");
            this._name = Console.ReadLine();
            Console.Write("Enter foundation year: ");
            uint.TryParse(Console.ReadLine(), out num);
            this._found_year = num;
            Console.Write("Enter description: ");
            this._description = Console.ReadLine();
            Console.Write("Enter phone: ");
            this._phone = Console.ReadLine();
            Console.Write("Enter e-mail: ");
            this._email = Console.ReadLine();
            Console.Write("Enter number of workers: ");
            int.TryParse(Console.ReadLine(), out num2);
            this._number_of_workers = num2;
        }

        public void SetName(string name)
        {
            this._name = name;
        }
        public void SetYear(uint year)
        {
            this._found_year = year;
        }
        public void SetDescription(string description)
        {
            this._description = description;
        }
        public void SetPhone(string phone)
        {
            this._phone = phone;
        }
        public void SetEmail(string email)
        {
            this._email = email;
        }
        public void SetWorkers(int workers)
        {
            this._number_of_workers = workers;
        }

        public string GetName()
        {
            return this._name;
        }
        public uint GetYear()
        {
            return this._found_year;
        }
        public string GetDescription()
        {
            return this._description;
        }
        public string GetPhone()
        {
            return this._phone;
        }
        public string GetEmail()
        {
            return this._email;
        }
        public int GetWorkers()
        {
            return this._number_of_workers;
        }

        public void ShowInfo()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Magasize's name: {this._name}");
            Console.WriteLine($"Magasize's foundation year: {this._found_year}");
            Console.WriteLine($"Magasize's desctiption: {this._description}");
            Console.WriteLine($"Magasize's phone: {this._phone}");
            Console.WriteLine($"Magasize's e-mail: {this._email}");
            Console.WriteLine($"Magasize's number of workers: {this._number_of_workers}");
            Console.WriteLine("----------------------------------------------------");
        }

        public static Magasine operator +(Magasine magasine, int num)
        {
            magasine.SetWorkers(magasine.GetWorkers() + num);
            return magasine;
        }
        public static Magasine operator +(int num, Magasine magasine)
        {
            magasine.SetWorkers(magasine.GetWorkers() + num);
            return magasine;
        }

        public static Magasine operator -(Magasine magasine, int num)
        {
            magasine.SetWorkers(magasine.GetWorkers() - num);
            return magasine;
        }
        public static Magasine operator -(int num, Magasine magasine)
        {
            magasine.SetWorkers(magasine.GetWorkers() - num);
            return magasine;
        }

        public static bool operator >(Magasine magasine1, Magasine magasine2)
        {
            return magasine1.GetWorkers() > magasine2.GetWorkers();
        }
        public static bool operator <(Magasine magasine1, Magasine magasine2)
        {
            return magasine1.GetWorkers() < magasine2.GetWorkers();
        }

        public static bool operator ==(Magasine magasine1, Magasine magasine2)
        {
            return magasine1.GetWorkers() == magasine2.GetWorkers();
        }
        public static bool operator !=(Magasine magasine1, Magasine magasine2)
        {
            return magasine1.GetWorkers() != magasine2.GetWorkers();
        }

        public override bool Equals(object? obj)
        {
            if(obj==null || !(obj is Magasine))
                return false;
            Magasine other = (Magasine)obj;
            if (this._name != other._name)
                return false;
            if (this._found_year != other._found_year)
                return false;
            if(this._description!=other._description)
                return false;
            if (this._phone != other._phone)
                return false;
            if (this._email != other._email)
                return false;
            if (this._number_of_workers != other._number_of_workers)
                return false;
            return true;
        }
    }
}
