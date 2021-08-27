using System;
using System.Collections.Generic;
using Users;
using ShoesLibrary;
using ProductData;
using CustData;
using StoreData;
using OrderData;
using InputValidation;
namespace ShoesStore
{
    public class CustomerLogin
    {
        Validation validatechoice = new Validation();
        public void Login(string username, string password)
        {
            Orderclass Cart = new Orderclass();
            Program program = new Program();
            CustomerLoginRepo loginobj = new CustomerLoginRepo();
            var username1 = loginobj.GetUserlogin(username);
            if (username1 == null)
            {
                validatechoice.username(username);
                Console.ReadLine();
                program.Home();

            }
            else
            {
                int user_id = username1.User_ID;
                string user_name = Convert.ToString(username1.UserName);
                string user_pass = Convert.ToString(username1.Password);
                if (user_name == username && user_pass == password)
                {
                    int action = menu1();
                    switch (action)
                    {
                        case 1:
                           // Cart.StoreSelection(user_id);
                            break;
                        case 2:
                            //Cart.OrderHistory(user_id);
                            break;
                        case 3:
                            //Console.Clear();
                            Console.ReadLine();
                            break;
                    }

                }
                else
                {
                    Console.WriteLine(" Wrong Password");
                    Console.ReadLine();
                   
                    program.Home();

                }

            }

               static int menu1()
            {
                Console.Clear();
                Console.WriteLine("\n--------------------Customer Module----------------------\n");
                Console.WriteLine("\n <1> Place Order\n <2> Order history\n <3> Exit");
                Console.Write("Choose above option: ");
                int ip = Int32.Parse(Console.ReadLine());
                return ip;

            }

        }
 }   }
