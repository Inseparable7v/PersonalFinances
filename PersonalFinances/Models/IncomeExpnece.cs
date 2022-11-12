using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalFinances.Models
{
    public partial class IncomeExpnece
    {
        public IncomeExpnece()
        {
            DossierDetails = new HashSet<DossierDetail>();
        }

        public decimal IncexpId { get; set; }
        public string IncexpName { get; set; }
        public string IncexpType { get; set; }

        public virtual ICollection<DossierDetail> DossierDetails { get; set; }
    }
}
