using System;
using System.Collections.Generic;

#nullable disable

namespace PersonalFinances.Models
{
    public partial class Dossier
    {
        public Dossier()
        {
            DossierDetails = new HashSet<DossierDetail>();
        }

        public Dossier(decimal year, decimal minBalance)
        {
            this.DossierYear = year;
            this.DossierMinBalance = minBalance;
        }

        public decimal DossierNo { get; set; }
        public decimal ClientId { get; set; }
        public decimal DossierYear { get; set; }
        public string DossierStatus { get; set; }
        public decimal? DossierMinBalance { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<DossierDetail> DossierDetails { get; set; }
    }
}
