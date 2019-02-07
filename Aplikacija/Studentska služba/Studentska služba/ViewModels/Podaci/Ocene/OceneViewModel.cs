using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Ocene
{
    public class OceneViewModel : GenericCRUDViewModel<Ocena>
    {
        public OceneViewModel()
            :base()
        {
            // Trenutno je ugasena mogucnost azuriranja ocena, moze samo da se doda i da se brise
            UpdateItemCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() => { }, () => { return false; } );
            UpdateItemCommand.RaiseCanExecuteChanged();
        }

        protected override object GetDbSet()
        {
            return context.Ocena;
        }

        protected override void GetItems()
        {
            ItemList = (GetDbSet() as DbSet<Ocena>)
                .Include(o => o.IdIspitaNavigation)
                    .ThenInclude(i => i.BrojIndeksaStudentaNavigation)
                .Include(o => o.IdIspitaNavigation)
                    .ThenInclude(i => i.IdPredmetaNavigation)
                .ToList();

        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }

        protected override List<Ocena> SearchForItem(string text)
        {
            int broj = -1;
            int.TryParse(text, out broj);

            return context.Ocena
                .Include(o => o.IdIspitaNavigation)
                    .ThenInclude(i => i.BrojIndeksaStudentaNavigation)
                .Include(o => o.IdIspitaNavigation)
                    .ThenInclude(i => i.IdPredmetaNavigation)
                .Where(t =>
                    t.Ocena1 == broj ||
                    t.IdIspita == broj ||
                    t.IdIspitaNavigation.BrojIndeksaStudenta == broj ||
                    t.IdIspitaNavigation.BrojIndeksaStudentaNavigation.Ime.Contains(text) ||
                    t.IdIspitaNavigation.BrojIndeksaStudentaNavigation.Prezime.Contains(text) ||
                    t.IdIspitaNavigation.NazivRoka.Contains(text) ||
                    t.IdIspitaNavigation.Godina == broj ||
                    t.IdIspitaNavigation.IdPredmetaNavigation.Naziv.Contains(text))
                .ToList();
        }
    }
}
