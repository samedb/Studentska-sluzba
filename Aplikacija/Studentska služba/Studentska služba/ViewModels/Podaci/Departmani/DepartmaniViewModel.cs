using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Model.Models;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        protected override async void AddItemAsync()
        {
            await dataProvider.AddDepartmanAsync(SelectedItem);
        }

        protected override void UpdateItem()
        {
            dataProvider.UpdateDepartmanAsync(SelectedItem);
        }

        protected override void RemoveItemAsync()
        {
            dataProvider.DeleteDepartmanAsync(SelectedItem);
        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }

        protected override async Task<ObservableCollection<Departman>> SearchForItemAsync(string text)
        {
            var list =  (await GetItems() as List<Departman>)
                .Where(t =>
                    t.Naziv.Contains(text) ||
                    t.IdSefaDepartmanaNavigation.Ime.Contains(text) ||
                    t.IdSefaDepartmanaNavigation.Prezime.Contains(text))
                .ToList();
            return new ObservableCollection<Departman>(list);
        }
    }
}
