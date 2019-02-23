using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class Predmet
    {
        public Predmet()
        {
            Ispit = new HashSet<Ispit>();
            SlusaPredmet = new HashSet<SlusaPredmet>();
        }

        public int IdPredmeta { get; set; }
        public string Naziv { get; set; }
        public int IdProfesora { get; set; }
        public int Espb { get; set; }

        public virtual Profesor IdProfesoraNavigation { get; set; }
        public virtual ICollection<Ispit> Ispit { get; set; }
        public virtual ICollection<SlusaPredmet> SlusaPredmet { get; set; }
    }
}
