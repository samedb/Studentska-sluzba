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

        protected override async void AddItemAsync()
        {
            await dataProvider.AddPredmetAsync(SelectedItem);
        }

        protected override void UpdateItem()
        {
            dataProvider.UpdatePredmetAsync(SelectedItem);
        }

        protected override void RemoveItemAsync()
        {
            dataProvider.DeletePredmetAsync(SelectedItem);
        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }

        protected override async Task<ObservableCollection<Predmet>> SearchForItemAsync(string text)
        {
            var list = (await GetItems() as List<Predmet>)
                .Where(t =>
                    t.Naziv.Contains(text) ||
                    t.IdProfesoraNavigation.Ime.Contains(text) ||
                    t.IdProfesoraNavigation.Prezime.Contains(text))
                .ToList();
            return new ObservableCollection<Predmet>(list);
        }
    }
}
