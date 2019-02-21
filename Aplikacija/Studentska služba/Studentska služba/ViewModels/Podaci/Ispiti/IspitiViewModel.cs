using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Ispiti
{
    public class IspitiViewModel : GenericCRUDViewModel<Ispit>
    {

        protected async override Task<IList<Ispit>> GetItems()
        {
            return await dataProvider.GetIspitiAsync();
        }

        protected override async void AddItemAsync()
        {
            await dataProvider.AddIspitAsync(SelectedItem);
        }

        protected override void UpdateItem()
        {
            dataProvider.UpdateIspitAsync(SelectedItem);
        }

        protected override void RemoveItemAsync()
        {
            dataProvider.DeleteIspitAsync(SelectedItem);
        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }

        protected override async Task<ObservableCollection<Ispit>> SearchForItemAsync(string text)
        {
            int broj = -1;
            int.TryParse(text, out broj);


            var list = (await GetItems() as List<Ispit>)
                .Where( t =>
                    t.IdIspita == broj ||
                    t.BrojIndeksaStudenta == broj ||
                    t.BrojIndeksaStudentaNavigation.Ime.Contains(text) ||
                    t.BrojIndeksaStudentaNavigation.Prezime.Contains(text) ||
                    t.NazivRoka.Contains(text) ||
                    t.Godina == broj ||
                    t.IdPredmetaNavigation.Naziv.Contains(text))
                .ToList();
            return new ObservableCollection<Ispit>(list);
        }
    }
}
