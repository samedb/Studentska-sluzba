using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class PrijemniIspit
    {
        public int IdPrijemnogIspita { get; set; }
        public int Godina { get; set; }
        public string NazivRoka { get; set; }
        public string JmbgKandidata { get; set; }
        public int IdSmera { get; set; }

        public virtual Smer IdSmeraNavigation { get; set; }
        public virtual Kandidat JmbgKandidataNavigation { get; set; }
        public virtual RezultatPrijemnog RezultatPrijemnog { get; set; }
    }
}
