using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Profesori
{
    public class ProfesoriViewModel : GenericCRUDViewModel<Profesor>
    {
        protected override object GetDbSet()
        {
            return context.Profesor;
        }

        protected override bool NoEmptyFiels()
        {
            throw new NotImplementedException();
        }

        protected override List<Profesor> SearchForItem(string text)
        {
            throw new NotImplementedException();
        }
    }
}
