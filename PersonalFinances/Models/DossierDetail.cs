using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalFinances.Models
{
    public partial class DossierDetail
    {
        public decimal DdId { get; set; }
        public decimal DossierNo { get; set; }
        public decimal IncexpId { get; set; }
        public DateTime DdDate { get; set; }
        public decimal DdValue { get; set; }
        public string DdDoc { get; set; }

        public virtual Dossier DossierNoNavigation { get; set; }
        public virtual IncomeExpnece Incexp { get; set; }
    }
}
