using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class RezultatPrijemnog
    {
        public int IdPrijemnog { get; set; }
        public int BrojBodova { get; set; }

        public virtual PrijemniIspit IdPrijemnogNavigation { get; set; }
    }
}
