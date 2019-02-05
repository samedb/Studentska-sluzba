using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Departmani
{
    public class DepartmaniViewModel : GenericCRUDViewModel<Departman>
    {
        protected override object GetDbSet()
        {
            return context.Departman;
        }

        protected override bool NoEmptyFiels()
        {
            throw new NotImplementedException();
        }

        protected override List<Departman> SearchForItem(string text)
        {
            throw new NotImplementedException();
        }
    }
}
