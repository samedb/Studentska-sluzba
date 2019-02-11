using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Studentska_služba
{
    public class StudentiViewModel : GenericCRUDViewModel<Student>
    {
        protected override object GetDbSet()
        {
            return context.Student;
        }

        protected async override Task<List<Student>> GetItems()
        {
            return await (GetDbSet() as DbSet<Student>).Include(s => s.IdSmeraNavigation).ToListAsync();
        }

        protected override bool NoEmptyFiels()
        {
            return SelectedItem != null &&
                    !(string.IsNullOrEmpty(SelectedItem.Ime) ||
                     string.IsNullOrEmpty(SelectedItem.Prezime) ||
                     string.IsNullOrEmpty(SelectedItem.Jmbg) ||
                     string.IsNullOrEmpty(SelectedItem.Pol));
        }

        protected override List<Student> SearchForItem(string text)
        {
            return context.Student
                          .Where(t =>
                              t.Ime.Contains(text) ||
                              t.Prezime.Contains(text) ||
                              t.Jmbg.Contains(text) ||
                              t.Pol.Contains(text) ||
                              t.BrojIndeksa.ToString().Contains(text))
                          .ToList();
        }
    }
}
