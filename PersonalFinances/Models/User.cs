using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances
{
    public class User
    {
        public User()
        {
             
        }

        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string SurrName { get; set; }
        public string LastName { get; set; }

        public int IdentificationNumber { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
