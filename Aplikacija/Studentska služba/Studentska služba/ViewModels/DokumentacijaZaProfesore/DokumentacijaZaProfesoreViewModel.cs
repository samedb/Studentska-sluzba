using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using iText7Wrapper;
using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Model.Models;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Studentska_služba.ViewModels.DokumentacijaZaProfesore
{
    public class DokumentacijaZaProfesoreViewModel : ViewModelBase
    {

        #region Atributi klase
        private readonly string imeFakulteta = "Državni univerzitet u Novom Pazaru";

        private Predmet _selectedPredmet;

        public Predmet SelectedPredmet
        {
            get { return _selectedPredmet; }
            set { Set(nameof(SelectedPredmet), ref _selectedPredmet, value); StampajDokumentaCommand.RaiseCanExecuteChanged(); }
        }

        private string _nazivRoka;

        public string NazivRoka
        {
            get { return _nazivRoka; }
            set { Set(nameof(NazivRoka), ref _nazivRoka, value); StampajDokumentaCommand.RaiseCanExecuteChanged(); }
        }

        private int _godina;

        public int Godina
        {
            get { return _godina; }
            set { Set(nameof(Godina), ref _godina, value); StampajDokumentaCommand.RaiseCanExecuteChanged(); }
        }

        private List<Predmet> _predmeti;

        public List<Predmet> Predmeti
        {
            get { return _predmeti; }
            set { Set(nameof(Predmeti), ref _predmeti, value); }
        }

        public RelayCommand StampajDokumentaCommand { get; private set; }
        
        public string[] Rokovi;
        public int[] Godine;

        #endregion

        #region Konsturktor
        public DokumentacijaZaProfesoreViewModel()
        {
            Godine = new int[] { 2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030 };
            Rokovi = new string[] { "Januar", "Februar", "Mart", "Jun", "Jul", "Septembar", "Oktobar", "Oktobar II", "Novembar" };
            PopuniPredmeteAsync();
            StampajDokumentaCommand = new RelayCommand(StampajDokumenta, PopunjenaSvaPolja);
            KreirajFajl();
        }

        private async void PopuniPredmeteAsync()
        {
            Predmeti = await new EFCoreDataProvider().GetPredmetiAsync() as List<Predmet>;
        }
        #endregion

        #region Foderi i fajlovi
        private StorageFolder folder;
        private StorageFile file;

        private async void KreirajFajl()
        {
            folder = ApplicationData.Current.TemporaryFolder;
            file = await folder.CreateFileAsync("temp.pdf", CreationCollisionOption.ReplaceExisting);
        }

        #endregion

        #region Pomocne funkcije
        private async void StampajDokumenta()
        {
            var lista = (await new EFCoreDataProvider().GetIspitiAsync())
                .Where(i => i.IdPredmeta == SelectedPredmet.IdPredmeta &&
                       i.Godina == Godina && i.NazivRoka == NazivRoka)
                .Select(i => new
                {
                    BrojIndeksa = i.BrojIndeksaStudenta,
                    Student = i.BrojIndeksaStudentaNavigation.PunoIme,
                    Smer = i.BrojIndeksaStudentaNavigation.IdSmeraNavigation.Naziv,
                    Ocena = ""
                })
                .OrderBy(i => i.BrojIndeksa)
                .ToList();

            using (var doc = new PdfWrapper(file))
            {
                doc.DodajSliku("Assets/logo.png", 0.5f);
                doc.DodajNaslov(imeFakulteta, 14);
                doc.DodajNaslov("Lista prijavljenih studenata");
                doc.DodajParagraf($"Za polaganje ispita iz predmeta {SelectedPredmet.Naziv} u {NazivRoka}skom ispitnom roku {Godina} godine prijavili su se sledeći studenti");
                doc.DodajTabelu(lista);
                doc.DodajPotpisProfesora();
            }

            await PdfWrapper.OtvoriFile(file);
        }

        private bool PopunjenaSvaPolja()
        {
            return !(SelectedPredmet == null || string.IsNullOrEmpty(NazivRoka) || Godine.FirstOrDefault(g => g == Godina) == 0);
        }
        #endregion
    }
}
