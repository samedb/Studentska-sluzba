using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class Departman
    {
        public Departman()
        {
            RadiNaDepartmanu = new HashSet<RadiNaDepartmanu>();
            Smer = new HashSet<Smer>();
        }

        public int IdDepartmana { get; set; }
        public string Naziv { get; set; }
        public int IdSefaDepartmana { get; set; }

        public virtual Profesor IdSefaDepartmanaNavigation { get; set; }
        public virtual ICollection<RadiNaDepartmanu> RadiNaDepartmanu { get; set; }
        public virtual ICollection<Smer> Smer { get; set; }
    }
}
