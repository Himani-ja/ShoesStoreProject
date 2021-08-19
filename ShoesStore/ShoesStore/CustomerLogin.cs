using System;
using LoginCredential;
using ShoesLibrary;
using ShoesData;
using CustData;
using StoreData;
using OrderData;
namespace ShoesStore
{
    public class CustomerLogin
    {
        public void Login(string username, string password)
        {
            OrderData.Order Cart = new OrderData.Order();
            
            CustomerLoginRepo loginobj = new CustomerLoginRepo();
            var username1= loginobj.GetCustomerlogin(username);
            string user_name = Convert.ToString(username1.C_UserName);
            string user_pass = Convert.ToString(username1.C_Password);
            if (user_name == username && user_pass == password)
            {
                //Console.Clear();
                 int action = menu1();
                 
                 
                switch (action)
                    {
                        case 1:
                        Console.WriteLine("Hello ........");
                            Cart.StoreSelection();
                            
                            break;
                        case 2:
                            Console.Clear();
                            Console.ReadLine();
                            break;
                    }
                //action = menu1();

            }
            else
            {
                Console.WriteLine("Wrong Credentials...");
                Program program = new Program();
                program.Home();
                
            }

        }


        public int menu1()
        {
            Console.Clear();
            Console.WriteLine("<1>Do Shopping\n<2>Order history\n<3>Exit");
            Console.Write("Selection : ");
            int ip = Int32.Parse(Console.ReadLine());
            return ip;
            // performSelectionAction(ip);
        }
       
    }
}
