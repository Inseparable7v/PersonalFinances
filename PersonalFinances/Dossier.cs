using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinances
{
    public class Dossier
    {
        public int DossierId { get; set; }

        public User Client { get; set; }

        public DateTime DossierYear { get; set; }

        public bool DossierStatus { get; set; }
    }
}
