using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization;
using Windows.UI.Xaml.Controls;

namespace Studentska_služba.ViewModels.Settings
{
    public class SettingsViewModel: ViewModelBase
    {
        private ObservableCollection<string> _jezici;

        public ObservableCollection<string> Jezici
        {
            get { return _jezici; }
            set { Set(nameof(Jezici), ref _jezici, value); }
        }

        private int  _odabraniJezik;

        public int  OdabraniJezik
        {
            get { return _odabraniJezik; }
            set { Set(nameof(OdabraniJezik), ref _odabraniJezik, value); }
        }

        private string[] jeziciRS = { "Engleski", "Sprski" };
        private string[] jeziciEN = { "English", "Serbian" };

        public SettingsViewModel()
        {
            //if (ApplicationLanguages.PrimaryLanguageOverride == "de")
            //    ApplicationLanguages.PrimaryLanguageOverride = "en";
            //else
            //    ApplicationLanguages.PrimaryLanguageOverride = "de";

            //Thread.Sleep(100);
            //Frame.Navigate(this.GetType());
        }

    }
}
