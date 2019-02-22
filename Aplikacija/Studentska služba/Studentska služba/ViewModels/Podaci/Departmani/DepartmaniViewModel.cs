using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Model.Models;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Departmani
{
    public class DepartmaniViewModel : GenericCRUDViewModel<Departman>
    {

        protected async override Task<IList<Departman>> GetItems()
        {
            return await dataProvider.GetDepartmaniAsync();
        }

        protected override async Task AddItemAsync()
        {
            await dataProvider.AddDepartmanAsync(SelectedItem);
        }

        protected override async Task UpdateItem()
        {
            await dataProvider.UpdateDepartmanAsync(SelectedItem);
        }

        protected override async Task RemoveItemAsync()
        {
            await dataProvider.DeleteDepartmanAsync(SelectedItem);
        }

        protected override bool NoEmptyFiels()
        {
            return SelectedItem != null &&
                    !(string.IsNullOrEmpty(SelectedItem.Naziv) ||
                     string.IsNullOrEmpty(SelectedItem.IdSefaDepartmana.ToString()));
        }

        protected override async Task<ObservableCollection<Departman>> SearchForItemAsync(string text)
        {
            var list =  (await GetItems() as List<Departman>)
                .Where(t =>
                    Sadrzi(t.IdDepartmana, text) ||
                    Sadrzi(t.Naziv, text) ||
                    Sadrzi(t.IdSefaDepartmanaNavigation.Ime, text) ||
                    Sadrzi(t.IdSefaDepartmanaNavigation.Prezime, text))
                .ToList();
            return new ObservableCollection<Departman>(list);
        }
    }
}
