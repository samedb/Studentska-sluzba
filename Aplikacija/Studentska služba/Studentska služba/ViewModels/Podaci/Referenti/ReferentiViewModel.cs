using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Studentska_služba.ViewModels.Podaci.Referenti
{
    public class ReferentiViewModel : GenericCRUDViewModel<Referent>
    {

        protected async override Task<IList<Referent>> GetItems()
        {
            return await dataProvider.GetReferentsAsync();
        }

        protected override async Task AddItemAsync()
        {
            await dataProvider.AddReferentAsync(SelectedItem);
            await new MessageDialog("Dodat novi referent, lozinka je '1234'.").ShowAsync();
        }

        protected override async Task UpdateItem()
        {
            await dataProvider.UpdateReferentAsync(SelectedItem);
        }

        protected override async Task RemoveItemAsync(params Referent[] items)
        {
            await dataProvider.DeleteReferentAsync(items);
        }

        protected override bool NoEmptyFiels()
        {
            return SelectedItem != null &&
                    !(string.IsNullOrEmpty(SelectedItem.Ime) ||
                     string.IsNullOrEmpty(SelectedItem.Prezime) ||
                     string.IsNullOrEmpty(SelectedItem.DatumRodjenja.ToString()) ||
                     string.IsNullOrEmpty(SelectedItem.Jmbg) ||
                     string.IsNullOrEmpty(SelectedItem.Adresa) ||
                     string.IsNullOrEmpty(SelectedItem.Pol));
        }

        protected override async Task<ObservableCollection<Referent>> SearchForItemAsync(string text)
        {
            var list = (await GetItems() as List<Referent>)
                .Where(t =>
                    Sadrzi(t.UsernameReferenta, text) ||
                    Sadrzi(t.Ime, text) ||
                    Sadrzi(t.Prezime, text))
                .ToList();
            return new ObservableCollection<Referent>(list);
        }
    }
}
