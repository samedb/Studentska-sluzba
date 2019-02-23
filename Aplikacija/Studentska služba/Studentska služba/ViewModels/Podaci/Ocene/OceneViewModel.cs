using Microsoft.EntityFrameworkCore;
using Studentska_služba.Views.Podaci.Ocene;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Studentska_služba.ViewModels.Podaci.Ocene
{
    public class OceneViewModel : GenericCRUDViewModel<Ocena>
    {
        private Frame frame;
        public OceneViewModel(Frame f)
            :base()
        {
            frame = f;
            // Trenutno je ugasena mogucnost azuriranja ocena, moze samo da se doda i da se brise
            UpdateItemCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() => { }, () => false);
            UpdateItemCommand.RaiseCanExecuteChanged();
        }

        protected override void AddNewItem()
        {
            frame.Navigate(typeof(OceneAdd));
        }

        protected async override Task<IList<Ocena>> GetItems()
        {
            return await dataProvider.GetOceneAsync();
        }

        protected override async Task AddItemAsync()
        {
            await dataProvider.AddOCenaAsync(SelectedItem);
        }

        protected override async Task UpdateItem()
        {
            await dataProvider.UpdateOcenaAsync(SelectedItem);
        }

        protected override async Task RemoveItemAsync(params Ocena[] items)
        {
            await dataProvider.DeleteOcenaAsync(items);
        }

        protected override bool NoEmptyFiels()
        {
            return true;
        }

        protected override async Task<ObservableCollection<Ocena>> SearchForItemAsync(string text)
        {
            var list = (await GetItems() as List<Ocena>)
                .Where(t =>
                    Sadrzi(t.Ocena1, text) ||
                    Sadrzi(t.IdIspita, text) ||
                    Sadrzi(t.IdIspitaNavigation.BrojIndeksaStudenta, text) ||
                    Sadrzi(t.IdIspitaNavigation.BrojIndeksaStudentaNavigation.Ime, text) ||
                    Sadrzi(t.IdIspitaNavigation.BrojIndeksaStudentaNavigation.Prezime, text) ||
                    Sadrzi(t.IdIspitaNavigation.NazivRoka, text) ||
                    Sadrzi(t.IdIspitaNavigation.Godina, text) ||
                    Sadrzi(t.IdIspitaNavigation.IdPredmetaNavigation.Naziv, text))
                .ToList();

            return new ObservableCollection<Ocena>(list);
        }
    }
}
