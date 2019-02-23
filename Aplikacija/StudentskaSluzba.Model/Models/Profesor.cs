using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class Profesor
    {
        public Profesor()
        {
            Departman = new HashSet<Departman>();
            Predmet = new HashSet<Predmet>();
            RadiNaDepartmanu = new HashSet<RadiNaDepartmanu>();
        }

        public int IdProfesora { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string PunoIme { get => Ime + " " + Prezime; }
        public DateTime DatumRodjenja { get; set; }
        public string Pol { get; set; }
        public string Jmbg { get; set; }
        public int IdSmera { get; set; }

        public virtual ICollection<Departman> Departman { get; set; }
        public virtual ICollection<Predmet> Predmet { get; set; }
        public virtual ICollection<RadiNaDepartmanu> RadiNaDepartmanu { get; set; }
    }
}
