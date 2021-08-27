using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public enum Role
    {
        Admin=0,Customer
    }
    public class User
    {
        public int User_ID { get; set; }
        public Role Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
