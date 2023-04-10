using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz5
{
    internal class Task2
    {
        public static void Run()
        {
            Shop shop1 = new Shop(), shop2 = new Shop();
            Console.WriteLine("Enter first shop's parameters: ");
            shop1.Init();
            Console.WriteLine("Enter second shop's parameters: ");
            shop2.Init();
            string action, shop;
            do
            {
                Console.Write("Enter what to do( rise(square), cut(square), compare, show, exit): ");
                action = Console.ReadLine();
                switch (action)
                {
                    case "rise":
                        Console.Write("Enter which shop to work with(first, second): ");
                        shop = Console.ReadLine();
                        Console.Write("Enter num of rising: ");
                        int rise;
                        int.TryParse(Console.ReadLine(), out rise);
                        if (shop == "first")
                            shop1 = shop1 + rise;
                        else if (shop == "second")
                            shop2 = shop2 + rise;
                        break;

                    case "cut":
                        Console.Write("Enter which shop to work with(first, second): ");
                        shop = Console.ReadLine();
                        Console.Write("Enter num of cutting: ");
                        int cut;
                        int.TryParse(Console.ReadLine(), out cut);
                        if (shop == "first")
                            shop1 = shop1 - cut;
                        else if (shop == "second")
                            shop2 = shop2 - cut;
                        break;

                    case "compare":
                        Console.Write("Which compare result you want(>, <, ==, !=, Equals): ");
                        string compare = Console.ReadLine();
                        switch (compare)
                        {
                            case ">":
                                Console.WriteLine($"Result(shop1 > shop2): {shop1 > shop2}");
                                break;
                            case "<":
                                Console.WriteLine($"Result(shop1 < shop2): {shop1 < shop2}");
                                break;
                            case "==":
                                Console.WriteLine($"Result(shop1 == shop2): {shop1 == shop2}");
                                break;
                            case "!=":
                                Console.WriteLine($"Result(shop1 != shop2): {shop1 != shop2}");
                                break;
                            case "Equals":
                                Console.WriteLine($"Result(shop1.Equals(shop2)): {shop1.Equals(shop2)}");
                                break;
                        }
                        break;

                    case "show":
                        Console.WriteLine("First magasines's info:");
                        shop1.ShowInfo();
                        Console.WriteLine("Second magasines's info:");
                        shop2.ShowInfo();
                        break;
                }

            } while (action != "exit");
        }
    }

    class Shop
    {
        private string _name { get; set; }
        private string _adress { get; set; }
        private string _description { get; set; }
        private string _phone { get; set; }
        private string _email { get; set; }
        private int _square { get; set; }

        public Shop()
        {
            this._name = "None";
            this._adress = "None";
            this._description = "None";
            this._phone = "None";
            this._email = "None";
            this._square = 0;
        }

        public void Init()
        {
            int num;
            Console.Write("Enter name: ");
            this._name = Console.ReadLine();
            Console.Write("Enter adress: ");
            this._adress = Console.ReadLine();
            Console.Write("Enter description: ");
            this._description = Console.ReadLine();
            Console.Write("Enter phone: ");
            this._phone = Console.ReadLine();
            Console.Write("Enter e-mail: ");
            this._email = Console.ReadLine();
            Console.Write("Enter square: ");
            int.TryParse(Console.ReadLine(), out num);
            this._square = num;
        }

        public Shop(string name, string adress, string description, string phone, string email, int square)
        {
            this._name = name;
            this._adress = adress;
            this._description = description;
            this._phone = phone;
            this._email = email;
            this._square = square;
        }

        public void SetName(string name)
        {
            this._name = name;
        }
        public void SetAdress(string adress)
        {
            this._adress = adress;
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
        public void SetSquare(int square)
        {
            this._square = square;
        }

        public string GetName()
        {
            return this._name;
        }
        public string GetAdress()
        {
            return this._adress;
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
        public int GetSquare()
        {
            return this._square;
        }

        public void ShowInfo()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Shop's name: {this._name}");
            Console.WriteLine($"Shop's adress: {this._adress}");
            Console.WriteLine($"Shop's desctiption: {this._description}");
            Console.WriteLine($"Shop's phone: {this._phone}");
            Console.WriteLine($"Shop's e-mail: {this._email}");
            Console.WriteLine($"Shop's square: {this._square}");
            Console.WriteLine("----------------------------------------------------");
        }

        public static Shop operator +(Shop shop, int num)
        {
            shop.SetSquare(shop.GetSquare() + num);
            return shop ;
        }
        public static Shop operator +(int num, Shop shop)
        {
            shop.SetSquare(shop.GetSquare() + num);
            return shop;
        }

        public static Shop operator -(Shop shop, int num)
        {
            shop.SetSquare(shop.GetSquare() - num);
            return shop;
        }
        public static Shop operator -(int num, Shop shop)
        {
            shop.SetSquare(shop.GetSquare() - num);
            return shop;
        }

        public static bool operator >(Shop shop1, Shop shop2)
        {
            return shop1.GetSquare() > shop2.GetSquare();
        }
        public static bool operator <(Shop shop1, Shop shop2)
        {
            return shop1.GetSquare() < shop2.GetSquare();
        }

        public static bool operator ==(Shop shop1, Shop shop2)
        {
            return shop1.GetSquare() == shop2.GetSquare();
        }
        public static bool operator !=(Shop shop1, Shop shop2)
        {
            return shop1.GetSquare() != shop2.GetSquare();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Shop))
                return false;
            Shop other = (Shop)obj;
            if (this._name != other._name)
                return false;
            if (this._adress != other._adress)
                return false;
            if (this._description != other._description)
                return false;
            if (this._phone != other._phone)
                return false;
            if (this._email != other._email)
                return false;
            if (this._square != other._square)
                return false;

            return true;
        }
    }
}
