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

            AddShoes();
            
        }
        private static void AddShoes()
        {
            ShoesLibrary.shoes shoes1 = new ShoesLibrary.shoes();
            Console.Write("Please enter your shoes Id: ");
            shoes1.Id = int.Parse(Console.ReadLine());
            Console.Write("Please enter your shoes Category: ");
            shoes1.Category = (ShoesLibrary.Category)int.Parse(Console.ReadLine());
            Console.Write(shoes1.AddShoes());
            FileRepo repo = new FileRepo();
            var cate = shoes1.Category;
            //Console.WriteLine(cate);
            var addshoes = repo.Init(shoes1.Id, (ShoesData.Category)cate);
            repo.Addshoes(addshoes);

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











            /*
            private static void AddShoes()
            {
                ShoesLibrary.shoes shoes1 = new ShoesLibrary.shoes();
                Console.Write("shoes Id: ");
                shoes1.Id = int.Parse(Console.ReadLine());
                Console.Write(" shoes Category: ");
                shoes1.Category = (ShoesLibrary.Category)int.Parse(Console.ReadLine());
                Console.Write(shoes1.AddShoes());
                FileRepo repo = new FileRepo();
                var cate = shoes1.Category;
                //Console.WriteLine(cate);
                var addshoes = repo.Init(shoes1.Id, (ShoesData.Category)cate);
                repo.Addshoes(addshoes);

            }
            private static void AddCustomer()
            {
                ShoesLibrary.Customer customer = new ShoesLibrary.Customer();
                Console.Write("Customer Id: ");
                customer.C_Id = int.Parse(Console.ReadLine());

                Console.Write("Customer name: ");
                customer.C_name = Console.ReadLine();

                Console.Write("Customer Email: ");
                customer.C_Email = Console.ReadLine();

                Console.Write("Customer contact number: ");
                customer.C_contact = Int32.Parse(Console.ReadLine());

                Console.Write("Customer Location: ");
                customer.C_location = Console.ReadLine();
                CustRepo c_repo = new CustRepo();

                var addcustomer = c_repo.Init(customer.C_Id,customer.C_name, customer.C_Email, customer.C_contact,customer.C_location);
                c_repo.AddCustomer(addcustomer);
            }*/

            /* private static void AddStore()
             {
                 StoreData.Store store1 = new StoreData.Store();
                 Console.Write("Store Id: ");
                 store1.Id = int.Parse(Console.ReadLine());
                 Console.Write("Store Location: ");
                 store1.Location = Console.ReadLine();
                 StoreData.FileRepoStore Repo2 = new StoreData.FileRepoStore();
                 var addStore = Repo2.Init (store1.Id,store1.Location);
                 Repo2.Addstore(addStore);
             }
             */

        }
    }
}
