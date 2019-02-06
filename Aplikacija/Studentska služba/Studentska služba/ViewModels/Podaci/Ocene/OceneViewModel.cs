using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Ocene
{
    public class OceneViewModel : GenericCRUDViewModel<Ocena>
    {
        protected override object GetDbSet()
        {
            return context.Ocena;
        }

        protected override bool NoEmptyFiels()
        {
            throw new NotImplementedException();
        }

        protected override List<Ocena> SearchForItem(string text)
        {
            throw new NotImplementedException();
        }
    }
}
