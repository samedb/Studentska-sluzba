using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Smerovi
{
    public class SmeroviViewModel : GenericCRUDViewModel<Smer>
    {

        protected async override Task<IList<Smer>> GetItems()
        {
            return await dataProvider.GetSmeroviAsync();
        }

        protected override async Task AddItemAsync()
        {
            await dataProvider.AddSmerAsync(SelectedItem);
        }

        protected override async Task UpdateItem()
        {
            await dataProvider.UpdateSmerAsync(SelectedItem);
        }

        protected override async Task RemoveItemAsync()
        {
            await dataProvider.DeleteSmerAsync(SelectedItem);
        }

        protected override bool NoEmptyFiels()
        {
            return SelectedItem != null &&
                    !(string.IsNullOrEmpty(SelectedItem.IdSmera.ToString()) ||
                     string.IsNullOrEmpty(SelectedItem.Naziv) ||
                     string.IsNullOrEmpty(SelectedItem.UsernameReferenta) ||
                     string.IsNullOrEmpty(SelectedItem.IdDepartmana.ToString()));
        }

        protected override async Task<ObservableCollection<Smer>> SearchForItemAsync(string text)
        {
            var list = (await GetItems() as List<Smer>)
                .Where(t =>
                    Sadrzi(t.IdSmera, text) ||
                    Sadrzi(t.Naziv, text) ||
                    Sadrzi(t.IdDepartmanaNavigation.Naziv, text) ||
                    Sadrzi(t.UsernameReferentaNavigation.Ime, text) ||
                    Sadrzi(t.UsernameReferentaNavigation.Prezime, text))
                .ToList();
            return new ObservableCollection<Smer>(list);
        }
    }
}
