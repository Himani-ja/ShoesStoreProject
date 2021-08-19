using System;
using ShoesLibrary;
using ShoesData;
using CustData;
using StoreData;

namespace ShoesStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Mainmenu();
            //Display();

        }

        private static void Display()
        {
            FileRepo display = new FileRepo();
            var allshoes = display.GetAllShoes();
            Console.WriteLine("Shoes at our satore are");
            Console.WriteLine("--------+++++-------+++++--------");
            foreach (var shoes in allshoes)
            {

                Console.Write("| id:" + shoes.Id);
                Console.Write(" category:" + shoes.Category + "|");
                Console.Write(" Brand:" + shoes.Brand + "|");
                Console.Write(" Type:" + shoes.Type + "|");
                Console.Write(" Lace:" + shoes.Lace + "|");
                Console.Write(" Size:" + shoes.Size + "|");
                Console.Write(" Color:" + shoes.Color + "|");
                Console.Write(" Price:" + shoes.Price + "|");
                Console.Write(" Quantity:" + shoes.Quantity + "| \n");
            }
        }
        static void Mainmenu()
        {
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
                        Display();
                        // ContinueOrExit();
                        //Console.Clear();
                      //  System.Environment.Exit(0);
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
        }
           

            static int menu()
            {
                Console.WriteLine("<1> User Login\n <2>Admin Login<\n <3>Exit");
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
    }
