using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class Student
    {
        public Student()
        {
            Ispit = new HashSet<Ispit>();
            SlusaPredmet = new HashSet<SlusaPredmet>();
            Ime = Prezime = Pol = Jmbg = string.Empty;
        }

        public int BrojIndeksa { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string PunoIme { get => Ime + " " + Prezime; }
        public string PunoImeIndeks { get => BrojIndeksa + " " + PunoIme; }
        public DateTime DatumRodjenja { get; set; }
        public string Pol { get; set; }
        public string Jmbg { get; set; }
        public int IdSmera { get; set; }

        public virtual Smer IdSmeraNavigation { get; set; }
        public virtual ICollection<Ispit> Ispit { get; set; }
        public virtual ICollection<SlusaPredmet> SlusaPredmet { get; set; }
    }
}
