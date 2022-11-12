using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalFinances.Models
{
    public partial class Client
    {
        public Client()
        {
            Addresses = new HashSet<Address>();
            Dossiers = new HashSet<Dossier>();
        }

        public decimal ClientId { get; set; }
        public string ClientEgn { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientLastname { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhone { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Dossier> Dossiers { get; set; }
    }
}
