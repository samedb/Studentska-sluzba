using Microsoft.EntityFrameworkCore;
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

        protected async override Task<List<Predmet>> GetItems()
        {
            return await (GetDbSet() as DbSet<Predmet>)
                .Include(p => p.IdProfesoraNavigation).ToListAsync();
        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }

        protected override List<Predmet> SearchForItem(string text)
        {
            return context.Predmet
                .Include(p => p.IdProfesoraNavigation)
                .Where(t =>
                    t.Naziv.Contains(text) ||
                    t.IdProfesoraNavigation.Ime.Contains(text) ||
                    t.IdProfesoraNavigation.Prezime.Contains(text))
                .ToList();
        }
    }
}
