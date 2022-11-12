using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalFinances.Models
{
    public partial class Address
    {
        public decimal AddressId { get; set; }
        public decimal ClientId { get; set; }
        public string AddressType { get; set; }
        public string AddressRegion { get; set; }
        public string AddresMunicipality { get; set; }
        public string AddressPlace { get; set; }
        public string AddressPcode { get; set; }
        public string AddressText { get; set; }

        public virtual Client Client { get; set; }
    }
}
