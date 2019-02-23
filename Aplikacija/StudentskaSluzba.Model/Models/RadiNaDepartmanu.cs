using System;
using System.Collections.Generic;

namespace StudentskaSluzba.Models
{
    public partial class RadiNaDepartmanu
    {
        public int IdProfesora { get; set; }
        public int IdDepartmana { get; set; }
        public DateTime? DatumZaposlenja { get; set; }

        public virtual Departman IdDepartmanaNavigation { get; set; }
        public virtual Profesor IdProfesoraNavigation { get; set; }
    }
}
