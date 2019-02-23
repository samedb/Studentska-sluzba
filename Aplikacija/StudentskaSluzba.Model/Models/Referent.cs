using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class Referent
    {
        public Referent()
        {
            Smer = new HashSet<Smer>();
        }

        public string UsernameReferenta { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string PunoIme { get => Ime + " " + Prezime; }
        public DateTime DatumRodjenja { get; set; }
        public string Pol { get; set; }
        public string Jmbg { get; set; }
        public string Adresa { get; set; }

        public virtual Korisnik UsernameReferentaNavigation { get; set; }
        public virtual ICollection<Smer> Smer { get; set; }
    }
}
