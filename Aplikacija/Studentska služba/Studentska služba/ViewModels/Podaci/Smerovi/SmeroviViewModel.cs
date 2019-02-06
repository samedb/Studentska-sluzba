using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Smerovi
{
    public class SmeroviViewModel : GenericCRUDViewModel<Smer>
    {
        protected override object GetDbSet()
        {
            return context.Smer;
        }

        protected override bool NoEmptyFiels()
        {
            throw new NotImplementedException();
        }

        protected override List<Smer> SearchForItem(string text)
        {
            throw new NotImplementedException();
        }

        public static implicit operator SmeroviViewModel(StudentiViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
