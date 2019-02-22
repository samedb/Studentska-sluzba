using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Model.Models;
using StudentskaSluzba.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Studentska_služba
{
    abstract public class GenericCRUDViewModel<TModel> : ViewModelBase where TModel : class, new() 
    {

        #region Atributi
        private ObservableCollection<TModel> _itemList;
        public ObservableCollection<TModel> ItemList
        {
            get => _itemList;
            set { Set(nameof(ItemList), ref _itemList, value); }
        }

        private TModel _selectedItem;

        public TModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                Set(nameof(SelectedItem), ref _selectedItem, value);
                DetailsMode = DetailsMode.View;
                /*DetailsAffirmativeCommand.RaiseCanExecuteChanged();*/
                UpdateItemCommand.RaiseCanExecuteChanged();
                DeleteItemCommand.RaiseCanExecuteChanged();
            }
        }

        private DetailsMode _detailsMode;

        public DetailsMode DetailsMode
        {
            get { return _detailsMode; }
            set { Set(nameof(DetailsMode), ref _detailsMode, value); }
        }

        private string _searchBoxText;

        public string SearchBoxText
        {
            get { return _searchBoxText; }
            set
            {
                Set(nameof(SearchBoxText), ref _searchBoxText, value);
                if (value == string.Empty)
                    RefreshTable();
                else
                    SearchAsync();
            }
        }

        protected IDataProvider dataProvider;

        #endregion

        #region Komande

        public RelayCommand AddNewItemCommand { get; protected set; }
        public RelayCommand UpdateItemCommand { get; protected set; }
        public RelayCommand DeleteItemCommand { get; protected set; }
        public RelayCommand RefreshTableCommand { get; protected set; }
        public RelayCommand SaveChangesCommand { get; protected set; }
        public RelayCommand CancelCommand { get; protected set; }

        #endregion

        #region Konstruktor
        public GenericCRUDViewModel()
        {
            dataProvider = new EFCoreDataProvider();
            DetailsMode = DetailsMode.View;
            AddNewItemCommand = new RelayCommand(AddNewItem);
            UpdateItemCommand = new RelayCommand(BeginEdit, IsAnySelected);
            DeleteItemCommand = new RelayCommand(DeleteSelectedStudent, IsAnySelected);
            SaveChangesCommand = new RelayCommand(SaveChanges/*, NoEmptyFiels*/);
            CancelCommand = new RelayCommand(Cancel);
            RefreshTableCommand = new RelayCommand(RefreshTable);
            RefreshTable();
        }

        private bool IsAnySelected()
        {
            return SelectedItem != null;
        }

        #endregion

        #region Pomocne Funkcije

        private void AddNewItem()
        {
            SelectedItem = new TModel();
            DetailsMode = DetailsMode.Add;
        }
        
        private void BeginEdit()
        {
            DetailsMode = DetailsMode.Edit;
        }


        virtual protected async void DeleteSelectedStudent()
        {
            var dialog = new MessageDialog("Da li ste sigurni da zelite da obrisete selektovane stavke?");
            dialog.Commands.Add(new UICommand("Da", new UICommandInvokedHandler(ObrisiSelektovaniItem)));
            dialog.Commands.Add(new UICommand("Ne"));
            dialog.CancelCommandIndex = 1;

            await dialog.ShowAsync();

            SelectedItem = default(TModel);
            RefreshTable();
        }

        private async void ObrisiSelektovaniItem(IUICommand command)
        {
            await RemoveItemAsync(SelectedItem);
        }


        private async void SaveChanges()
        {
            if (NoEmptyFiels())
            {
                if (DetailsMode == DetailsMode.Add)
                {
                    await AddItemAsync();
                }
                else
                {
                    await UpdateItem();
                }
                RefreshTable();
            }
            else
            {
                await new MessageDialog("Niste popunili sta polja!").ShowAsync();
            }
        }

        private void Cancel()
        {
            RefreshTable();
        }

        public async void RefreshTable()
        {
            ItemList = new ObservableCollection<TModel>(await GetItems());
            SelectedItem = default(TModel); // Sa promenom TModel-a automatski se i DetailsMode stavlja na View
            if (!string.IsNullOrEmpty(SearchBoxText))
                SearchBoxText = string.Empty;
        }



        #endregion

        #region Search i sort

        internal ObservableCollection<TModel> SortData(string tag, bool asc)
        {
            var list = ItemList.AsQueryable().OrderBy($"{tag} ASC").ToList();

            if (!asc)
                list.Reverse();

            return new ObservableCollection<TModel>(list);

        }

        // Ovo mora da se uradi asinhrono jer blokira aplikaciju, ali kasnije
        public async void SearchAsync()
        {
            string text = SearchBoxText;
            if (text.Length > 1)
            {
                // Ovo nije dobro, mora da se porpravi
                // Uopste ne radi asinhrono
                // Treba da procitam kako to tacno da uradim
                ItemList = await SearchForItemAsync(text);
            }
        }

        // Ove dve funkcije ispod se koriste u SearchForItemAsync pri pretrazi

        /// <summary>
        /// Proverava da li string a sadrzi string b, nije case sensitive
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>True ako a sadrzi b inace false</returns>
        protected bool Sadrzi(string a, string b)
        {
            return a.ToUpper().Contains(b.ToUpper());
        }

        // Radi isto sto i funkcija iznad kao prvi parametar prima double koji pretvara u string
        protected bool Sadrzi(double a, string b)
        {
            return a.ToString().ToUpper().Contains(b.ToUpper());
        }

        #endregion

        #region Abstraktne funkcije

        /// <summary>
        /// Ovo su funkcije koje pojedini ViewModel treba da prekolopi
        /// </summary>
        /// 

        protected abstract Task AddItemAsync();
        protected abstract Task UpdateItem();
        protected abstract Task RemoveItemAsync(params TModel[] items);
        protected abstract Task<IList<TModel>> GetItems();
        abstract protected Task<ObservableCollection<TModel>> SearchForItemAsync(string text);
        abstract protected bool NoEmptyFiels();

        #endregion
    }
}
