using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Referenti
{
    public class ReferentiViewModel : GenericCRUDViewModel<Referent>
    {
        protected override object GetDbSet()
        {
            return context.Referent;
        }

        protected override bool NoEmptyFiels()
        {
            throw new NotImplementedException();
        }

        protected override List<Referent> SearchForItem(string text)
        {
            throw new NotImplementedException();
        }
    }
}
