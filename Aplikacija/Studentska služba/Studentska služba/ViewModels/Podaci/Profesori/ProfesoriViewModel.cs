using Microsoft.EntityFrameworkCore;
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
            return true;
        }

        protected override List<Profesor> SearchForItem(string text)
        {
            return context.Profesor
                .Where(t =>
                    t.Ime.Contains(text) ||
                    t.Prezime.Contains(text) ||
                    t.Pol.Contains(text))
                .ToList();
        }
    }
}
