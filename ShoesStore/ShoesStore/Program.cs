using System;
using ShoesLibrary;
using ShoesData;
using CustData;
using StoreData;
using OrderData;
using LoginCredential;


namespace ShoesStore
{
    public class Program
    {
        static void Main(string[] args)
        {

            //AddShoes();
            //DoOrder();
            Program programobj = new Program();
            programobj.Home();

            //DisplayStores();
            //DisplayCredential();
        }
        public void Home()
        {


            CustomerLogin csl = new CustomerLogin();
            AdminLogin adLogin = new AdminLogin();
            Customer_Registeration customecredential = new Customer_Registeration();
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
                        customecredential.AddCustomer();
                        break;
                    case 3:
                        // string username1, password1;
                        Console.Write("Enter Username : ");
                        username = Console.ReadLine();
                        Console.Write("\nEnter Password : ");
                        password = Console.ReadLine();
                        adLogin.Login(username, password);

                        //ContinueOrExit();
                        break;
                    case 4:
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
                
                Console.WriteLine("<1> Customer Login\n<2> Customer Registeration\n<3>Admin Login");
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
        private static void DisplayCredential()
        {
            CustomerLoginRepo display = new CustomerLoginRepo();
            var allstores = display.GetAllCustomerCredential();
            Console.WriteLine("Stores are");
            Console.WriteLine("--------+++++-------+++++--------");
            foreach (var store in allstores)
            {

                Console.Write("| Id:" + store.C_UserName);
                Console.Write(" Location:" + store.C_Password + "|\n");


            }
        }
  
    }
}
