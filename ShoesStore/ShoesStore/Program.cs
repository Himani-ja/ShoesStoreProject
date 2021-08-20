using System;
using ShoesLibrary;
using ShoesData;
using CustData;
using StoreData;
using OrderData;
using LoginCredential;
using InputValidation;


namespace ShoesStore
{
    public class Program
    {
        InputValidation.Validation choice = new InputValidation.Validation();
        static void Main(string[] args)
        {
           
            Program programobj = new Program();
            programobj.Home();

        }
        public void Home()
        {

            Console.WriteLine("\n---------------------Welcome to ShoesStore-----------------------\n");
            CustomerLogin csl = new CustomerLogin();
            AdminLogin adLogin = new AdminLogin();
            Customer_Registeration customecredential = new Customer_Registeration();
            int action = menu();
            while (action != 0)
            {
                Console.WriteLine(" You choose : " + action);

                string username, password;
                switch (action)
                {
                    case 1:
                        Console.Write("\n Enter Username: ");
                        username = Console.ReadLine();
                        username = choice.CheckName(username);
                        Console.Write(" Enter Password: ");
                        password = Console.ReadLine();
                        password = choice.CheckName(password);
                        csl.Login(username, password);
                        break;
                    case 2:
                        customecredential.AddCustomer();
                        break;
                    case 3:
                        Console.Write("\n Enter Username: ");
                        username = Console.ReadLine();
                        username = choice.CheckName(username);
                        Console.Write(" Enter Password: ");
                        password = Console.ReadLine();
                        password = choice.CheckName(password);
                        adLogin.Login(username, password);
                        break;
                    case 4:
                        ContinueOrExit();
                        Console.Clear();
                        Console.ReadLine();
                        break;
                }
              
                Console.Clear();
                action = menu();
    

            }

            static int menu()
            {
                
                Console.WriteLine("\n <1> Customer Login\n <2> Customer Registeration\n <3> Admin Login\n");
                Console.Write("\n Choose the above option: ");
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
}
