using System;
using System.Text.RegularExpressions;
using CustData;
using Users;

namespace InputValidation
{
    public class Validation
    {

        public string CheckName(string name)   // to check name (if name is empty it will return 0 value,otherwise it will return name)
        {
            while (string.IsNullOrEmpty(name))

            {
                Console.WriteLine(" Please enter valid input");
                name = Console.ReadLine();

            }
            return name;
        }

        public User CheckName(User username1)
        {
            throw new NotImplementedException();
        }

        public string checkmobnumber(string phoneNumber)  // to check valid mobile number
        {
            /*Regex mobPattern = new Regex(@"^\d{10}$"); //mobile number should match this pattern(eg.5543454324)
            while (!mobPattern.IsMatch(phoneNumber))
            {  
                Console.WriteLine(" Please enter valid phone number");
                phoneNumber = Console.ReadLine();
            }  
            return phoneNumber;*/
            if ((phoneNumber.Length != 10) || (phoneNumber == null))
            {
                Console.WriteLine("Please enter your 10 digit mobile number!");
                phoneNumber = Console.ReadLine();
                checkmobnumber(phoneNumber);
            }

            return phoneNumber;
        
        }

        public string checkEmail(string email)  // to check valid mobile number
        {
            Regex emailPattern = new Regex(@"([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            while (!emailPattern.IsMatch(email))
            {
                Console.WriteLine(" Please enter valid Email Id..");
                email = Console.ReadLine();

            }
            return email;
        }


        public void SearchName(string s_name) // to check store location is valid or not
        {
            CustRepo display = new CustRepo();
            if (display.GetCustomer(s_name) == null)
            {
                Console.WriteLine($" Sorry... there is no customer present with {s_name} name");
                //Console.ReadLine();
            }

        }
        public void searchusername(string u_name) // to check store location is valid or not
        {
            CustomerLoginRepo loginobj = new CustomerLoginRepo();
                       
            if (loginobj.GetUserlogin(u_name) == null)
            {
                Console.WriteLine($"Sorry... there is no customer present with {u_name} name");
                Console.ReadLine();
            }

        }
        public void username(string username)
        {
            CustomerLoginRepo loginobj = new CustomerLoginRepo();

            if (loginobj.GetUserlogin(username) == null)
            {
                Console.WriteLine(" Invalid username");
                
            }
        }
    }
}
