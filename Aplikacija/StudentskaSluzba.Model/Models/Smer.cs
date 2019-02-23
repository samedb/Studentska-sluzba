using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class Smer
    {
        public Smer()
        {
            PrijemniIspit = new HashSet<PrijemniIspit>();
            Student = new HashSet<Student>();
        }

        public int IdSmera { get; set; }
        public string Naziv { get; set; }
        public string UsernameReferenta { get; set; }
        public int IdDepartmana { get; set; }

        public virtual Departman IdDepartmanaNavigation { get; set; }
        public virtual Referent UsernameReferentaNavigation { get; set; }
        public virtual ICollection<PrijemniIspit> PrijemniIspit { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
