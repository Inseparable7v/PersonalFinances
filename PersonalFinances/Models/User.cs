using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalFinances.Models
{
    public partial class User
    {
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
