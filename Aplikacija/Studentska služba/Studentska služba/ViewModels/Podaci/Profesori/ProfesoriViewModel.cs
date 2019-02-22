using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Profesori
{
    public class ProfesoriViewModel : GenericCRUDViewModel<Profesor>
    {

        protected async override Task<IList<Profesor>> GetItems()
        {
            return await dataProvider.GetProfesorsAsync();
        }

        protected override async Task AddItemAsync()
        {
            await dataProvider.AddProfesorAsync(SelectedItem);
        }

        protected override async Task UpdateItem()
        {
            await dataProvider.UpdateProfesorAsync(SelectedItem);
        }

        protected override async Task RemoveItemAsync(params Profesor[] items)
        {
            await dataProvider.DeleteProfesorAsync(items);
        }

        protected override bool NoEmptyFiels()
        {
            return SelectedItem != null &&
                    !(string.IsNullOrEmpty(SelectedItem.Ime) ||
                     string.IsNullOrEmpty(SelectedItem.Prezime) ||
                     string.IsNullOrEmpty(SelectedItem.DatumRodjenja.ToString()) ||
                     string.IsNullOrEmpty(SelectedItem.Jmbg) ||
                     string.IsNullOrEmpty(SelectedItem.Pol));
        }
        protected override async Task<ObservableCollection<Profesor>> SearchForItemAsync(string text)
        {
            var list = (await GetItems() as List<Profesor>)
                .Where(t =>
                    Sadrzi(t.IdProfesora, text) ||
                    Sadrzi(t.Ime, text) ||
                    Sadrzi(t.Prezime, text) ||
                    Sadrzi(t.Pol, text))
                .ToList();
            return new ObservableCollection<Profesor>(list);
        }
    }
}
