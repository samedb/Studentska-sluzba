using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Studentska_služba
{
    public class StudentiViewModel : GenericCRUDViewModel<Student>
    {

        protected async override Task<IList<Student>> GetItems()
        {
            return await dataProvider.GetStudentsAsync();
        }

        protected override async Task AddItemAsync()
        {
            await dataProvider.AddStudentAsync(SelectedItem);
        }

        protected override async Task UpdateItem()
        {
            await dataProvider.UpdateStudentAsync(SelectedItem);
        }

        protected override async Task RemoveItemAsync()
        {
            await dataProvider.DeleteStudentAsync(SelectedItem);
        }

        protected override bool NoEmptyFiels()
        {
            return SelectedItem != null &&
                    !(string.IsNullOrEmpty(SelectedItem.Ime) ||
                     string.IsNullOrEmpty(SelectedItem.Prezime) ||
                     string.IsNullOrEmpty(SelectedItem.Jmbg) ||
                     string.IsNullOrEmpty(SelectedItem.Pol));
        }

        protected override async Task<ObservableCollection<Student>> SearchForItemAsync(string text)
        {
            var list = (await GetItems() as List<Student>)
                          .Where(t =>
                              t.Ime.Contains(text) ||
                              t.Prezime.Contains(text) ||
                              t.Jmbg.Contains(text) ||
                              t.Pol.Contains(text) ||
                              t.BrojIndeksa.ToString().Contains(text))
                          .ToList();
            return new ObservableCollection<Student>(list);
        }
    }
}
