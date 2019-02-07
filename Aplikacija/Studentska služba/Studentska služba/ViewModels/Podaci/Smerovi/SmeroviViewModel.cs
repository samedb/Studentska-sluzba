using Microsoft.EntityFrameworkCore;
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

        protected override void GetItems()
        {
            ItemList = (GetDbSet() as DbSet<Smer>)
                .Include(s => s.IdDepartmanaNavigation)
                .Include(s => s.UsernameReferentaNavigation)
                .ToList();
        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }

        protected override List<Smer> SearchForItem(string text)
        {
            return context.Smer
                .Include(s => s.IdDepartmanaNavigation)
                .Include(s => s.UsernameReferentaNavigation)
                .Where(t =>
                    t.Naziv.Contains(text) ||
                    t.IdDepartmanaNavigation.Naziv.Contains(text) ||
                    t.UsernameReferentaNavigation.Ime.Contains(text) ||
                    t.UsernameReferentaNavigation.Prezime.Contains(text))
                .ToList();
        }
    }
}
