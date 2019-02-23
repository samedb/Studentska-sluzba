using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class Ocena
    {
        public int IdIspita { get; set; }
        public int Ocena1 { get; set; }

        public virtual Ispit IdIspitaNavigation { get; set; }
    }
}
