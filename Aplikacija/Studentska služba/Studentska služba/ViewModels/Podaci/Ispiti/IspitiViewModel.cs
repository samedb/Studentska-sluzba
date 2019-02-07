using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Ispiti
{
    public class IspitiViewModel : GenericCRUDViewModel<Ispit>
    {
        protected override object GetDbSet()
        {
            return context.Ispit;
        }

        protected override void GetItems()
        {
            ItemList = (GetDbSet() as DbSet<Ispit>)
                .Include(i => i.BrojIndeksaStudentaNavigation)
                .Include(i => i.IdPredmetaNavigation)
                .ToList();

        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }

        protected override List<Ispit> SearchForItem(string text)
        {
            int broj = -1;
            int.TryParse(text, out broj);


            return context.Ispit
                .Include(i => i.BrojIndeksaStudentaNavigation)
                .Include(i => i.IdPredmetaNavigation)
                .Where( t =>
                    t.IdIspita == broj ||
                    t.BrojIndeksaStudenta == broj ||
                    t.BrojIndeksaStudentaNavigation.Ime.Contains(text) ||
                    t.BrojIndeksaStudentaNavigation.Prezime.Contains(text) ||
                    t.NazivRoka.Contains(text) ||
                    t.Godina == broj ||
                    t.IdPredmetaNavigation.Naziv.Contains(text))
                .ToList();
        }
    }
}
