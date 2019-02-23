using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class SlusaPredmet
    {
        public int IdPredmeta { get; set; }
        public int BrojIndeksaStudenta { get; set; }

        public virtual Student BrojIndeksaStudentaNavigation { get; set; }
        public virtual Predmet IdPredmetaNavigation { get; set; }
    }
}
