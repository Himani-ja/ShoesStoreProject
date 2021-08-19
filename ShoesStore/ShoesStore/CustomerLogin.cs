using System;
using System.Collections.Generic;
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
            Order Cart = new Order();
            
            CustomerLoginRepo loginobj = new CustomerLoginRepo();
            var username1= loginobj.GetCustomerlogin(username);
            int user_id = username1.Customer_ID;
            string user_name = Convert.ToString(username1.C_UserName);
            string user_pass = Convert.ToString(username1.C_Password);
            if (user_name == username && user_pass == password)
            {
                 int action = menu1();
                switch (action)
                    {
                        case 1:
                            Cart.StoreSelection(user_id);
                            
                            break;
                        case 2:
                            Cart.OrderHistory(user_id);
                            break;
                        case 3:
                            Console.Clear();
                            Console.ReadLine();
                            break;
                    }

            }
            else
            {
                Console.WriteLine(" Wrong Credentials");
                Program program = new Program();
                program.Home();
                
            }

        }

        public int menu1()
        {
            Console.Clear();
            Console.WriteLine("\n--------------------Customer Module----------------------\n");
            Console.WriteLine("\n <1> Place Order\n <2> Order history\n <3> Exit");
            Console.Write("Choose above option: ");
            int ip = Int32.Parse(Console.ReadLine());  
            return ip;

        }
       
    }
}
