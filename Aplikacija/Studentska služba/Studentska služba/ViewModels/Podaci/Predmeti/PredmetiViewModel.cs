using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Predmeti
{
    public class PredmetiViewModel : GenericCRUDViewModel<Predmet>
    {
        protected override object GetDbSet()
        {
            return context.Predmet;
        }

        protected override bool NoEmptyFiels()
        {
            throw new NotImplementedException();
        }

        protected override List<Predmet> SearchForItem(string text)
        {
            throw new NotImplementedException();
        }
    }
}
