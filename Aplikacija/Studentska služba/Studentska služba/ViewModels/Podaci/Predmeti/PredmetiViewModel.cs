using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Predmeti
{
    public class PredmetiViewModel : GenericCRUDViewModel<Predmet>
    {

        protected async override Task<IList<Predmet>> GetItems()
        {
            return await dataProvider.GetPredmetiAsync();
        }

        protected override async Task AddItemAsync()
        {
            await dataProvider.AddPredmetAsync(SelectedItem);
        }

        protected override async Task UpdateItem()
        {
            await dataProvider.UpdatePredmetAsync(SelectedItem);
        }

        protected override async Task RemoveItemAsync()
        {
            await dataProvider.DeletePredmetAsync(SelectedItem);
        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }

        protected override async Task<ObservableCollection<Predmet>> SearchForItemAsync(string text)
        {
            var list = (await GetItems() as List<Predmet>)
                .Where(t =>
                    Sadrzi(t.IdPredmeta, text) ||
                    Sadrzi(t.Naziv, text) ||
                    Sadrzi(t.IdProfesoraNavigation.Ime, text) ||
                    Sadrzi(t.IdProfesoraNavigation.Prezime, text))
                .ToList();

            return new ObservableCollection<Predmet>(list);
        }
    }
}
