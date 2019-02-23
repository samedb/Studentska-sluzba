using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Model.Models;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Studentska_služba.ViewModels.Podaci.Ocene
{
    public class OceneAddViewModel: ViewModelBase
    {
        private Frame frame;

        private ObservableCollection<Predmet> _predmeti;

        public ObservableCollection<Predmet> Predmeti
        {
            get { return _predmeti; }
            set { Set(nameof(Predmeti), ref _predmeti, value); }
        }

        private Predmet _selectedPredmet;

        public Predmet SelectedPredmet
        {
            get { return _selectedPredmet; }
            set
            {
                Set(nameof(SelectedPredmet), ref _selectedPredmet, value);
                UnesiOceneCommand.RaiseCanExecuteChanged();
                if (SvaPoljaPopunjena())
                    UcitajIspite();
            }
        }

        private int _godina;

        public int Godina
        {
            get { return _godina; }
            set
            {
                Set(nameof(Godina), ref _godina, value);
                UnesiOceneCommand.RaiseCanExecuteChanged();
                if (SvaPoljaPopunjena())
                    UcitajIspite();
            }
        }


        private string _nazivRoka;

        public string NazivRoka
        {
            get { return _nazivRoka; }
            set
            {
                Set(nameof(NazivRoka), ref _nazivRoka, value);
                UnesiOceneCommand.RaiseCanExecuteChanged();
                if (SvaPoljaPopunjena())
                    UcitajIspite();
            }
        }

        private ObservableCollection<IspitOcena> _ispiti;

        public ObservableCollection<IspitOcena> Ispiti
        {
            get { return _ispiti; }
            set { Set(nameof(Ispiti), ref _ispiti, value); }
        }

        public RelayCommand UnesiOceneCommand { get; private set; }

        public OceneAddViewModel(Frame f)
        {
            frame = f;
            UcitajPredmete();
            UnesiOceneCommand = new RelayCommand(UnesiOcene, SvaPoljaPopunjena);
        }

        private async void UnesiOcene()
        {
            foreach (var i in Ispiti) 
                if (i.Ocena != 5)
                {
                    Ocena ocena = new Ocena
                    {
                        IdIspita = i.Ispit.IdIspita,
                        Ocena1 = i.Ocena
                    };
                    await new EFCoreDataProvider().AddOCenaAsync(ocena);
                    Debug.WriteLine($"Uneta ocena {ocena.Ocena1}");
                }
            if (frame.CanGoBack)
                frame.GoBack();
        }

        private bool SvaPoljaPopunjena()
        {
            return SelectedPredmet != null
                && !string.IsNullOrEmpty(NazivRoka)
                && Godina != 0;
        }

        private async void UcitajPredmete()
        {
            Predmeti = new ObservableCollection<Predmet>(await new EFCoreDataProvider().GetPredmetiAsync());
        }

        private async void UcitajIspite()
        {
            Ispiti = new ObservableCollection<IspitOcena>(
                await new EFCoreDataProvider().GetNepolozeneIspite(SelectedPredmet.IdPredmeta, Godina, NazivRoka));
        }
    }
}
