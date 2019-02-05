using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Ispiti
{
    public class IspitiViewModel : GenericCRUDViewModel<Ispit>
    {
        protected override object GetDbSet()
        {
            return context.Ispit;
        }

        protected override bool NoEmptyFiels()
        {
            throw new NotImplementedException();
        }

        protected override List<Ispit> SearchForItem(string text)
        {
            throw new NotImplementedException();
        }
    }
}
