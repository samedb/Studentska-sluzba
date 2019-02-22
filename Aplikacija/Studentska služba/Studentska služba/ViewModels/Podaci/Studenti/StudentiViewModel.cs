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

        protected override async Task RemoveItemAsync(params Student[] items)
        {
            await dataProvider.DeleteStudentAsync(items);
        }

        protected override bool NoEmptyFiels()
        {
            return SelectedItem != null &&
                    !(string.IsNullOrEmpty(SelectedItem.Ime) ||
                     string.IsNullOrEmpty(SelectedItem.Prezime) ||
                     string.IsNullOrEmpty(SelectedItem.IdSmera.ToString()) ||
                     string.IsNullOrEmpty(SelectedItem.DatumRodjenja.ToString()) ||
                     string.IsNullOrEmpty(SelectedItem.Jmbg) ||
                     string.IsNullOrEmpty(SelectedItem.Pol));
        }

        protected override async Task<ObservableCollection<Student>> SearchForItemAsync(string text)
        {
            var list = (await GetItems() as List<Student>)
                          .Where(t =>
                              Sadrzi(t.BrojIndeksa, text) ||
                              Sadrzi(t.Ime, text) ||
                              Sadrzi(t.Prezime, text) ||
                              Sadrzi(t.Jmbg, text) ||
                              Sadrzi(t.IdSmeraNavigation.Naziv, text) ||
                              Sadrzi(t.Pol, text))
                          .ToList();
            return new ObservableCollection<Student>(list);
        }
    }
}
