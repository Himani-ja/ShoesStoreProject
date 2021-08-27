using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesLibrary
{
    public enum Role
    {
        Admin = 0, Customer
    }
    public class Customer
    {

        int user_id;
        public int User_Id
        {
            get
            {
                return user_id;
            }
            set
            {
                user_id = value;
            }
        }

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
        bool c_active;
        public bool C_Active
        {
            get
            {
                return c_active;
            }
            set
            {
                c_active = value;
            }
        }
        
        


        public string AddShoes()
        {
            return $"\nId: {C_Id} \n Name {C_name}\n Contact no.: {C_contact}\nLocation:{C_Active}";
        }
    }
    public class User
    {
        int user_id;
        public int User_Id
        {
            get
            {
                return user_id;
            }
            set
            {
                user_id = value;
            }
        }
        Role role;
        public Role Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
            }
        }
        string username;
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
