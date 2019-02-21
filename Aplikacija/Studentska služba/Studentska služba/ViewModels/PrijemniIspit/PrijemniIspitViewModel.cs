using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Model.Models;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.PrijemniIspit
{
    class PrijemniIspitViewModel: ViewModelBase
    {
        private ObservableCollection<Ocena> ocene;

        public ObservableCollection<Ocena> Ocene
        {
            get { return ocene; }
            set { Set(nameof(Ocene), ref ocene, value); }
        }

        public RelayCommand UcitajCommand { get; private set; }

        public PrijemniIspitViewModel()
        {
            UcitajCommand = new RelayCommand(UcitajOcene);
        }

        private async void UcitajOcene()
        {
            Ocene = new ObservableCollection<Ocena>(await GetItems());
        }

        private async Task<IList<Ocena>> GetItems()
        {
            using (var context = new StudentskaSluzbaDBContext())
            {
                var list = await new EFCoreDataProvider().GetOceneAsync();
                return list;
            }
        }
    }
}
