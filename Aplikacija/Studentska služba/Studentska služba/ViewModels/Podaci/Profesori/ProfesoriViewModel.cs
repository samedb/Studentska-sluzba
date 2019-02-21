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

        protected override async Task RemoveItemAsync()
        {
            await dataProvider.DeleteProfesorAsync(SelectedItem);
        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }
        protected override async Task<ObservableCollection<Profesor>> SearchForItemAsync(string text)
        {
            var list = (await GetItems() as List<Profesor>)
                .Where(t =>
                    t.Ime.Contains(text) ||
                    t.Prezime.Contains(text) ||
                    t.Pol.Contains(text))
                .ToList();
            return new ObservableCollection<Profesor>(list);
        }
    }
}
