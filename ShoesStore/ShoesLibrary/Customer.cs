using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesLibrary
{
    public class Customer
    {
        int c_id;
        public int C_Id
        {
            get
            {
                return c_id;
            }
            set
            {
                c_id = value;
            }
        }
        
        string c_name;
        public string C_name
        {
            get
            {
                return c_name;
            }
            set
            {
                c_name = value;
            }
        }
        string c_Email;
        public string C_Email
        {
            get
            {
                return c_Email;
            }
            set
            {
                c_Email = value;
            }
        }
        string c_contact;
        public string C_contact
        {
            get
            {
                return c_contact;
            }
            set
            {
                c_contact = value;
            }
        }
        string c_location;
        public string C_location
        {
            get
            {
                return c_location;
            }
            set
            {
                c_location = value;
            }
        }
        
        


        public string AddShoes()
        {
            return $"\nId: {C_Id} \n Name {C_name}\n Contact no.: {C_contact}\nLocation:{C_location}";
        }
    }
    public class CustomerCredential
    {
        string c_username;
        public string C_UserName
        {
            get
            {
                return c_username;
            }
            set
            {
                c_username = value;
            }
        }
        string c_password;
        public string C_Password
        {
            get
            {
                return c_password;
            }
            set
            {
                c_password = value;
            }
        }
    }
}
