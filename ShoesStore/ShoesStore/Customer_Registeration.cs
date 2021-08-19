using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustData;
using LoginCredential;

namespace ShoesStore
{
    public class Customer_Registeration
    {
        public  void AddCustomer()
        {

            ShoesLibrary.Customer customer = new ShoesLibrary.Customer();
            ShoesLibrary.CustomerCredential cus_credential = new ShoesLibrary.CustomerCredential();
            Random uniqueid = new Random();
            int randomnum = uniqueid.Next(10001, 100000);
            customer.C_Id = randomnum;

            Console.Write("\n Customer Name: ");
            customer.C_name = Console.ReadLine();

            Console.Write("\n Customer Email: ");
            customer.C_Email = Console.ReadLine();

            Console.Write("\n Customer Contact number: ");
            customer.C_contact = Console.ReadLine();

            Console.Write("\n Customer Location: ");
            customer.C_location = Console.ReadLine();
            
            Console.WriteLine("\n-----------------------------------------\n");
            Console.Write("\n Create User Name: ");
            cus_credential.C_UserName = Console.ReadLine();
        pass:
            Console.Write("\n Create Password: ");
            string pass1 = Console.ReadLine();
            Console.Write("\n Confirm Password: ");
            string pass2 = Console.ReadLine();
            if(pass1==pass2)
            {
                cus_credential.C_Password = pass1;
            }
            else
            {
                Console.WriteLine("\n------- Your password doesn't match--------\n");
                goto pass;
            }
        


            CustRepo c_repo = new CustRepo();
            CustomerLoginRepo c_loginrepo = new CustomerLoginRepo();
            int Customerid = customer.C_Id;
            var customercredential = c_loginrepo.CredentialInit(Customerid,cus_credential.C_UserName, cus_credential.C_Password);
            c_loginrepo.AddCustomerCredential(customercredential);
            var addcustomer = c_repo.Init(customer.C_Id, customer.C_name, customer.C_Email, customer.C_contact, customer.C_location);
            c_repo.AddCustomer(addcustomer);
        }
    }
}
