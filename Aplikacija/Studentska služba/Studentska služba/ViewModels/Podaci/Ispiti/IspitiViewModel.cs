using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Ispiti
{
    public class IspitiViewModel : GenericCRUDViewModel<Ispit>
    {

        protected async override Task<IList<Ispit>> GetItems()
        {
            return await dataProvider.GetIspitiAsync();
        }

        protected override async Task AddItemAsync()
        {
            await dataProvider.AddIspitAsync(SelectedItem);
        }

        protected override async Task UpdateItem()
        {
            await dataProvider.UpdateIspitAsync(SelectedItem);
        }

        protected override async Task RemoveItemAsync()
        {
            await dataProvider.DeleteIspitAsync(SelectedItem);
        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }

        protected override async Task<ObservableCollection<Ispit>> SearchForItemAsync(string text)
        {
            var list = (await GetItems() as List<Ispit>)
                .Where(t =>
                    Sadrzi(t.IdIspita, text) ||
                    Sadrzi(t.BrojIndeksaStudenta, text) ||
                    Sadrzi(t.BrojIndeksaStudentaNavigation.Ime, text) ||
                    Sadrzi(t.BrojIndeksaStudentaNavigation.Prezime, text) ||
                    Sadrzi(t.NazivRoka, text) ||
                    Sadrzi(t.Godina, text) ||
                    Sadrzi(t.IdPredmetaNavigation.Naziv, text))
                .ToList();
            return new ObservableCollection<Ispit>(list);
        }
    }
}
