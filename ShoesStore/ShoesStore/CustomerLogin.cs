using System;

using ShoesLibrary;
using ShoesData;
using CustData;
using StoreData;

namespace ShoesStore
{
    public class CustomerLogin
    {
        public void Login(string username, string password)
        {
            if(username == "user" && password == "123")
            {
                //Console.Clear();
                int action = menu1();
                //   Console.WriteLine("<1> Add Customer\n <2>Exit");
                //  int action = int.Parse(Console.ReadLine());
                switch (action)
                    {
                        case 1:
                        AddCustomer();
                            break;
                        case 2:
                            Console.Clear();
                            Console.ReadLine();
                            
                            break;
                    }
                action = menu1();

            }
            else
            {
                Console.WriteLine("Wrong Credentials...");
                
                
            }

        }


        public int menu1()
        {
            Console.Clear();
            Console.WriteLine("<1> Add Customer\n <0>Exit");
            Console.Write("Selection : ");
            int ip = Int32.Parse(Console.ReadLine());
            return ip;
            // performSelectionAction(ip);
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

            var addcustomer = c_repo.Init(customer.C_Id, customer.C_name, customer.C_Email, customer.C_contact, customer.C_location);
            c_repo.AddCustomer(addcustomer);
        }
    }
}
