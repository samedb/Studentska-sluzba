using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StudentskaSluzba.Model.Models;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace Studentska_služba.ViewModels.Login
{
    public class LoginViewModel: ViewModelBase
    {
        Frame frame;

        private string _username;

        public string Username
        {
            get { return _username; }
            set { Set(nameof(Username), ref _username, value); LoginCommand.RaiseCanExecuteChanged(); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { Set(nameof(Password), ref _password, value); LoginCommand.RaiseCanExecuteChanged(); }
        }

        public RelayCommand LoginCommand { get; private set; }

        public LoginViewModel(Frame f)
        {
            frame = f;
            LoginCommand = new RelayCommand(Login, PopunjenaPolja);
        }

        private async void Login()
        {
            IDataProvider dataProvider = new EFCoreDataProvider();
            Korisnik korisnik = await dataProvider.LoginIspravan(Username, Password);
            if (korisnik != default(Korisnik))
            {
                App.TrenutniKorisnik = korisnik;
                frame.Navigate(typeof(MainPage));
            }
            else
            {
                Username = Password = string.Empty;
                await new MessageDialog("Neispravano korisnicko ime ili lozinka!").ShowAsync();
            }
        }

        private bool PopunjenaPolja()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }
    }
}
