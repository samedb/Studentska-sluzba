using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Podaci.Ocene
{
    public class OceneViewModel : GenericCRUDViewModel<Ocena>
    {
        public OceneViewModel()
            :base()
        {
            // Trenutno je ugasena mogucnost azuriranja ocena, moze samo da se doda i da se brise
            UpdateItemCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() => { });
            UpdateItemCommand.RaiseCanExecuteChanged();
        }


        protected async override Task<IList<Ocena>> GetItems()
        {
            return await dataProvider.GetOceneAsync();
        }

        protected override async void AddItemAsync()
        {
            await dataProvider.AddOCenaAsync(SelectedItem);
        }

        protected override void UpdateItem()
        {
            dataProvider.UpdateOcenaAsync(SelectedItem);
        }

        protected override void RemoveItemAsync()
        {
            dataProvider.DeleteOcenaAsync(SelectedItem);
        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }

        protected override async Task<ObservableCollection<Ocena>> SearchForItemAsync(string text)
        {
            int broj = -1;
            int.TryParse(text, out broj);

            var list = (await GetItems() as List<Ocena>)
                .Where(t =>
                    t.Ocena1 == broj ||
                    t.IdIspita == broj ||
                    t.IdIspitaNavigation.BrojIndeksaStudenta == broj ||
                    t.IdIspitaNavigation.BrojIndeksaStudentaNavigation.Ime.Contains(text) ||
                    t.IdIspitaNavigation.BrojIndeksaStudentaNavigation.Prezime.Contains(text) ||
                    t.IdIspitaNavigation.NazivRoka.Contains(text) ||
                    t.IdIspitaNavigation.Godina == broj ||
                    t.IdIspitaNavigation.IdPredmetaNavigation.Naziv.Contains(text))
                .ToList();

            return new ObservableCollection<Ocena>(list);
        }
    }
}
