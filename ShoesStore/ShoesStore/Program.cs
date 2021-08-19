using System;
using ShoesLibrary;
using ShoesData;
using CustData;
using StoreData;
using OrderData;

namespace ShoesStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddShoes();
            DoOrder();
            //DisplayStores();
        }
        private static void AddShoes()
        {
            /*ShoesLibrary.shoes shoes1 = new ShoesLibrary.shoes();
            Console.Write("Please enter shoes Id: ");
            shoes1.Id = int.Parse(Console.ReadLine());
            Console.Write("Please enter shoes Category -\npress <1> for Casual_Wear \npress <2> for Sports \npress <3> for Loafer \npress <4> for Boots \npress <5> for Sneakers:");
            shoes1.Category = (ShoesLibrary.Category)int.Parse(Console.ReadLine());
            //var cate = shoes1.Category;
            //Console.Write(shoes1.AddShoes());
            Console.Write("Please enter shoes brand:");
            shoes1.Brand = Console.ReadLine();
            Console.Write("Please enter shoes Type - press <0> for male and press <1> for female: ");
            shoes1.Type = (ShoesLibrary.Types)int.Parse(Console.ReadLine());
            Console.Write("Please enter shoes has Lace - press <0> for yes and press <1> for no: ");
            shoes1.Lace = (ShoesLibrary.Lace)int.Parse(Console.ReadLine());
            Console.Write("Please enter shoes Color-(Black,White,Blue,Red,Brown,Grey): ");
            string color = Console.ReadLine();
            //Console.WriteLine(color);
            shoes1.Color = (ShoesLibrary.Colors)Enum.Parse(typeof(ShoesLibrary.Colors), color);
            Console.Write("Please enter shoes size: ");
            shoes1.Size = double.Parse(Console.ReadLine());
            Console.Write("Please enter shoes price: ");
            shoes1.Price = double.Parse(Console.ReadLine());
            Console.Write("Please enter shoes quantity: ");
            shoes1.Quantity = int.Parse(Console.ReadLine());



            FileRepo repo = new FileRepo();



            //Console.WriteLine(cate);
            var addshoes = repo.Init(shoes1.Id, (ShoesData.Category)shoes1.Category, shoes1.Size, shoes1.Price, (ShoesData.Colors)shoes1.Color, (ShoesData.Types)shoes1.Type, (ShoesData.Lace)shoes1.Lace, shoes1.Brand, shoes1.Quantity);
            repo.Addshoes(addshoes);*/

            CustomerLogin csl = new CustomerLogin();
            AdminLogin adLogin = new AdminLogin();
            int action = menu();
            while (action != 0)
            {
                Console.WriteLine("You choose : " + action);

                string username, password;
                switch (action)
                {
                    case 1:
                        Console.Write("Enter Username : ");
                        username = Console.ReadLine();
                        Console.Write("\nEnter Password : ");
                        password = Console.ReadLine();
                        csl.Login(username, password);
                        break;
                    case 2:
                        // string username1, password1;
                        Console.Write("Enter Username : ");
                        username = Console.ReadLine();
                        Console.Write("\nEnter Password : ");
                        password = Console.ReadLine();
                        adLogin.Login(username, password);

                        //ContinueOrExit();
                        break;
                    case 3:
                        ContinueOrExit();
                        Console.Clear();
                        Console.ReadLine();
                        break;
                }
              //  ContinueOrExit();
                Console.Clear();
                action = menu();

                //AddShoes();
                // AddCustomer();
                // AddStore();

            }


            static int menu()
            {
                Console.WriteLine("<1> User Login\n <2>Admin Login");
                Console.Write("Selection : ");
                int ip = Int32.Parse(Console.ReadLine());
                return ip;
                // performSelectionAction(ip);
            }
            static void ContinueOrExit()
            {
                Console.Write("Continue ? y/n : ");
                var res = Console.ReadLine();
                if (res == "y" || res == "Y")
                {
                    Console.Clear();
                    menu();
                }
            }
            

        }

        private static void DisplayShoes()
        {
            FileRepo display = new FileRepo();
            var allshoes = display.GetAllShoes();
            Console.WriteLine("Shoes at our store are");
            Console.WriteLine("--------+++++-------+++++--------");
            foreach (var shoes in allshoes)
            {

                Console.Write("| id:" + shoes.Id);
                Console.Write(" category:" + shoes.Category + "|");
                Console.Write(" Brand:" + shoes.Brand +"|");
                Console.Write(" Type:" + shoes.Type + "|");
                Console.Write(" Lace:" + shoes.Lace + "|");
                Console.Write(" Size:" + shoes.Size + "|");
                Console.Write(" Color:" + shoes.Color + "|");
                Console.Write(" Price:" + shoes.Price+ "|");
                Console.Write(" Quantity:"+ shoes.Quantity+ "| \n");



            }
        }
        private static void DisplayStores()
        {
            FileRepoStore display = new FileRepoStore();
            var allstores = display.GetAllStores();
            Console.WriteLine("Stores are");
            Console.WriteLine("--------+++++-------+++++--------");
            foreach (var store in allstores)
            {

                Console.Write("| Id:" + store.Id);
                Console.Write(" Location:" + store.Location + "|\n");

            }
        }
     private static void DoOrder()
        {
            Order ord = new Order();
            ord.StoreSelection();
        }
    }
}
