using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StudentskaSluzba.Model;
using StudentskaSluzba.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace Studentska_služba.ViewModels.Settings
{
    public class PromenaLozinkeViewModel : ViewModelBase
    {
        private Frame frame;

        private string _staraLozinka;

        public string StaraLozinka
        {
            get { return _staraLozinka; }
            set { Set(nameof(StaraLozinka), ref _staraLozinka, value); PromeniLozinkuCommand.RaiseCanExecuteChanged(); }
        }

        private string _novaLozinka1;

        public string NovaLozinka1
        {
            get { return _novaLozinka1; }
            set { Set(nameof(NovaLozinka1), ref _novaLozinka1, value); PromeniLozinkuCommand.RaiseCanExecuteChanged(); }
        }

        private string _novaLozinka2;

        public string NovaLozinka2
        {
            get { return _novaLozinka2; }
            set { Set(nameof(NovaLozinka2), ref _novaLozinka2, value); PromeniLozinkuCommand.RaiseCanExecuteChanged(); }
        }

        public RelayCommand PromeniLozinkuCommand { get; private set; }
        public RelayCommand GoBackCommand { get; private set; }

        public PromenaLozinkeViewModel(Frame f)
        {
            frame = f;
            PromeniLozinkuCommand = new RelayCommand(PromeniLozinku, SvaPoljaPopunjena);
            GoBackCommand = new RelayCommand(GoBack);

        }

        private void GoBack()
        {
            if (frame.CanGoBack)
                frame.GoBack();
        }

        private async void PromeniLozinku()
        {
            if (App.TrenutniKorisnik.Password != Enkripcija.Enkriptuj(StaraLozinka))
                await new MessageDialog("Stara lozinka nije tacna!").ShowAsync();
            else if (NovaLozinka1 != NovaLozinka2)
                await new MessageDialog("Nove lozinke se ne poklapaju!").ShowAsync();
            else
            {
                await new EFCoreDataProvider().PromeniLozinku(App.TrenutniKorisnik, NovaLozinka1);
                await new MessageDialog("Uspesno promenjena lozinka").ShowAsync();
                GoBack();
            }
        }

        private bool SvaPoljaPopunjena()
        {
            return !string.IsNullOrEmpty(StaraLozinka) 
                && !string.IsNullOrEmpty(NovaLozinka1) 
                && !string.IsNullOrEmpty(NovaLozinka2);
        }
    }
}
