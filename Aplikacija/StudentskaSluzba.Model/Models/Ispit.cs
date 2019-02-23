using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class Ispit
    {
        public int IdIspita { get; set; }
        public int BrojIndeksaStudenta { get; set; }
        public int IdPredmeta { get; set; }
        public int Godina { get; set; }
        public string NazivRoka { get; set; }

        public virtual Student BrojIndeksaStudentaNavigation { get; set; }
        public virtual Predmet IdPredmetaNavigation { get; set; }
        public virtual Ocena Ocena { get; set; }
    }
}
