using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class Kandidat
    {
        public Kandidat()
        {
            PrijemniIspit = new HashSet<PrijemniIspit>();
        }

        public string Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string NazivSrednjeSkole { get; set; }
        public double ProsekUSrednjoj { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Adresa { get; set; }
        public string Pol { get; set; }

        public virtual ICollection<PrijemniIspit> PrijemniIspit { get; set; }
    }
}
