using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StudentskaSluzba.Model.Models;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace Studentska_služba.ViewModels.Podaci.Ispiti
{
    public class IspitiAddViewModel: ViewModelBase
    {
        private Frame frame;

        private ObservableCollection<Student> _studenti;

        public ObservableCollection<Student> Studenti
        {
            get { return _studenti; }
            set { Set(nameof(Studenti), ref _studenti, value); }
        }

        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                Set(nameof(SelectedStudent), ref _selectedStudent, value);
                PrijaviIspiteCommand.RaiseCanExecuteChanged();
                if (SvaPoljaPopunjena())
                    UcitajPredmete();
            }
        }

        private int _godina;

        public int Godina
        {
            get { return _godina; }
            set
            {
                Set(nameof(Godina), ref _godina, value);
                PrijaviIspiteCommand.RaiseCanExecuteChanged();
                if (SvaPoljaPopunjena())
                    UcitajPredmete();
            }
        }

        private string _nazivRoka;

        public string NazivRoka
        {
            get { return _nazivRoka; }
            set
            {
                Set(nameof(NazivRoka), ref _nazivRoka, value);
                PrijaviIspiteCommand.RaiseCanExecuteChanged();
                if (SvaPoljaPopunjena())
                    UcitajPredmete();
            }
        }

        private ObservableCollection<PredmetPrijava> _predmeti;

        public ObservableCollection<PredmetPrijava> Predmeti
        {
            get { return _predmeti; }
            set { Set(nameof(Predmeti), ref _predmeti, value); }
        }

        public RelayCommand PrijaviIspiteCommand { get; private set; }

        public IspitiAddViewModel(Frame f)
        {
            frame = f;
            UcitajStudente();
            PrijaviIspiteCommand = new RelayCommand(PrijaviIspiteAsync, SvaPoljaPopunjena);
        }

        private bool PrijavljenBiloKojiIspit()
        {
            foreach (var p in Predmeti)
                if (p.Prijavljen)
                    return true;
            return false;
        }

        private async void UcitajStudente()
        {
            Studenti = new ObservableCollection<Student>(await new EFCoreDataProvider().GetStudentsAsync());
        }

        private async void PrijaviIspiteAsync()
        {
            if (PrijavljenBiloKojiIspit())
            {
                foreach(var p in Predmeti) 
                    if (p.Prijavljen)
                    {
                        Ispit ispit = new Ispit
                        {
                            BrojIndeksaStudenta = SelectedStudent.BrojIndeksa,
                            IdPredmeta = p.Predmet.IdPredmeta,
                            Godina = this.Godina,
                            NazivRoka = this.NazivRoka
                        };
                        await new EFCoreDataProvider().AddIspitAsync(ispit);
                    }

                if (frame.CanGoBack)
                    frame.GoBack();
            }
            else
                await new MessageDialog("Niste prijavili nijedan ispit!").ShowAsync();
        }

        private bool SvaPoljaPopunjena()
        {
            return SelectedStudent != null
                && !string.IsNullOrEmpty(NazivRoka)
                && Godina != 0;
        }

        private async void UcitajPredmete()
        {
                Predmeti = new ObservableCollection<PredmetPrijava>(
                    await new EFCoreDataProvider().GetNeprijavljeneINepolozenePredmete(SelectedStudent.BrojIndeksa, Godina, NazivRoka));
        }
    }
}
