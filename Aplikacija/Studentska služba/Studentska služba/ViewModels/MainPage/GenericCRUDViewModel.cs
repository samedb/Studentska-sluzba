using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
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

        protected StudentskaSluzbaDBContext context;

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
            context = new StudentskaSluzbaDBContext();
            DetailsMode = DetailsMode.View;
            AddNewItemCommand = new RelayCommand(AddNewItem);
            UpdateItemCommand = new RelayCommand(BeginEdit, IsAnySelected);
            DeleteItemCommand = new RelayCommand(DeleteSelectedStudent, IsAnySelected);
            SaveChangesCommand = new RelayCommand(SaveChanges/*, NoEmptyFiels*/);
            CancelCommand = new RelayCommand(Cancel);
            RefreshTableCommand = new RelayCommand(RefreshTable);
            RefreshTable();
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

        private bool IsAnySelected()
        {
            return SelectedItem != null;
        }

        virtual protected async void DeleteSelectedStudent()
        {
            RemoveItem();
            ItemList.Remove(SelectedItem);
            SelectedItem = default(TModel);
            await context.SaveChangesAsync();
            //RefreshTable();
        }
        
        private async void SaveChanges()
        {
            if (NoEmptyFiels())
            {
                if (DetailsMode == DetailsMode.Add)
                {
                    AddItem();
                }
                await context.SaveChangesAsync();
                RefreshTable();
            }
        }

        private void Cancel()
        {
            ReloadItem();
            RefreshTable();
        }

        public async void RefreshTable()
        {
            ItemList = new ObservableCollection<TModel>(await GetItems());
            SelectedItem = default(TModel); // Sa promenom studenta automatski se i DetailsMode stavlja na View
            if (!string.IsNullOrEmpty(SearchBoxText))
                SearchBoxText = string.Empty;
        }

        virtual protected void RemoveItem()
        {
            (GetDbSet() as DbSet<TModel>).Remove(SelectedItem);
        }

        virtual protected void AddItem()
        {
            (GetDbSet() as DbSet<TModel>).Add(SelectedItem);
        }

        virtual protected void ReloadItem()
        {
            context.Entry(SelectedItem).Reload();
        }

        virtual protected async Task<List<TModel>>  GetItems()
        {
            return await (GetDbSet() as DbSet<TModel>).ToListAsync();
        }

        #endregion

        #region Search i sort

        internal IList<TModel> SortData(string tag, bool asc)
        {
            var list = ItemList.AsQueryable().OrderBy($"{tag} ASC").ToList();

            if (!asc)
                list.Reverse();

            return list;

        }

        // Ovo mora da se uradi asinhrono jer blokira aplikaciju, ali kasnije
        public async Task SearchAsync()
        {
            string text = SearchBoxText;
            if (text.Length > 1)
            {
                //Ovo nije dobro, mora da se porpravi
                // Uopste ne radi asinhrono
                // Treba da procitam kako to tacno da uradim
                ItemList = new ObservableCollection<TModel>(await Task<IList>.Run(() => SearchForItem(text)));
            }
        }

        #endregion

        #region Abstraktne funkcije

        /// <summary>
        /// Ovo su funkcije koje pojedini ViewModel treba da prekolopi
        /// </summary>
  

        abstract protected List<TModel> SearchForItem(string text);

        abstract protected object GetDbSet();

        abstract protected bool NoEmptyFiels();

        #endregion
    }
}
