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

            Console.Write("Customer name: ");
            customer.C_name = Console.ReadLine();

            Console.Write("Customer Email: ");
            customer.C_Email = Console.ReadLine();

            Console.Write("Customer contact number: ");
            customer.C_contact = Int32.Parse(Console.ReadLine());

            Console.Write("Customer Location: ");
            customer.C_location = Console.ReadLine();
            
            Console.WriteLine("\n-----------------------------------------\n");
            Console.WriteLine("Create User Name");
            cus_credential.C_UserName = Console.ReadLine();
        pass:
            Console.WriteLine("Create Password");
            string pass1 = Console.ReadLine();
            Console.WriteLine("Confirm Password");
            string pass2 = Console.ReadLine();
            if(pass1==pass2)
            {
                cus_credential.C_Password = pass1;
            }
            else
            {
                Console.WriteLine("Your password doesn't match ");
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
