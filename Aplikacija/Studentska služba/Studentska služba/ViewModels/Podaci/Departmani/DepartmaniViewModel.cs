using Microsoft.EntityFrameworkCore;
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

        protected async override Task<List<Departman>> GetItems()
        {
            return await (GetDbSet() as DbSet<Departman>).Include(dep => dep.IdSefaDepartmanaNavigation).ToListAsync();
        }


        protected override bool NoEmptyFiels()
        {
            return true;
        }

        protected override List<Departman> SearchForItem(string text)
        {
            return context.Departman
                .Include(d => d.IdSefaDepartmanaNavigation)
                .Where(t =>
                    t.Naziv.Contains(text) ||
                    t.IdSefaDepartmanaNavigation.Ime.Contains(text) ||
                    t.IdSefaDepartmanaNavigation.Prezime.Contains(text))
                .ToList();
        }
    }
}
