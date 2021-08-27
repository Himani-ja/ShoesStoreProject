using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustData;
using Users;
using InputValidation;

namespace ShoesStore
{
    public class Customer_Registeration
    {
        Validation validate = new Validation();
        public  void AddCustomer()
        {


            ShoesLibrary.Customer customer = new ShoesLibrary.Customer();
            ShoesLibrary.User user_credential = new ShoesLibrary.User();
            Random uniqueid = new Random();

            int randomuser = uniqueid.Next(1001, 10000);
            customer.User_Id = randomuser;
            user_credential.User_Id = randomuser;

            int randomnum = uniqueid.Next(10001, 100000);
            customer.C_Id = randomnum;

            Console.Write("\n Customer Name: ");
            customer.C_name = Console.ReadLine();
            customer.C_name = validate.CheckName(customer.C_name);

            Console.Write("\n Customer Email: ");
            customer.C_Email = Console.ReadLine();
            customer.C_Email = validate.checkEmail(customer.C_Email);

            Console.Write("\n Customer Contact number: ");
            customer.C_contact = Console.ReadLine();
            customer.C_contact = validate.checkmobnumber(customer.C_name);

            customer.C_Active = true;

            Console.WriteLine("\n-----------------------------------------\n");
            Console.Write("\n Create User Name: ");
            user_credential.UserName = Console.ReadLine();
            user_credential.UserName = validate.CheckName(user_credential.UserName);
        pass:
            Console.Write("\n Create Password: ");
            string pass1 = Console.ReadLine();
            pass1 = validate.CheckName(pass1);
            Console.Write("\n Confirm Password: ");
            string pass2 = Console.ReadLine();
            pass2 = validate.CheckName(pass2);
            if (pass1==pass2)
            {
               
                user_credential.Password = pass1;
                Console.WriteLine("\n------- You have successfully registered--------\n");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("\n------- Your password doesn't match--------\n");

                goto pass;
            }
        


            CustRepo c_repo = new CustRepo();
            CustomerLoginRepo c_loginrepo = new CustomerLoginRepo();
           
            var customercredential = c_loginrepo.UserInit(user_credential.User_Id,Role.Customer, user_credential.UserName, user_credential.Password);
            c_loginrepo.AddUser(customercredential);
            var addcustomer = c_repo.Init(customer.C_Id,customer.User_Id, customer.C_name, customer.C_Email, customer.C_contact, customer.C_Active);
            c_repo.AddCustomer(addcustomer);
        }
    }
}
