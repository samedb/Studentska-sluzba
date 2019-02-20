using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using iText7Wrapper;
using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Studentska_služba.ViewModels.PotvrdeUverenja
{
    class PotvrdeUverenjaViewModel : ViewModelBase
    {
        #region Atributi klase
        private readonly string imeFakulteta = "Državni univerzitet u Novom Pazaru";

        private string _tipDokumenta;

        public string TipDokumenta
        {
            get { return _tipDokumenta; }
            set { Set(nameof(TipDokumenta), ref _tipDokumenta, value); StampajDokument.RaiseCanExecuteChanged(); }
        }

        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set { Set(nameof(TipDokumenta), ref _selectedStudent, value); StampajDokument.RaiseCanExecuteChanged(); }
        }

        private string _svrha;

        public string Svrha
        {
            get { return _svrha; }
            set { Set(nameof(Svrha), ref _svrha, value); StampajDokument.RaiseCanExecuteChanged(); }
        }

        private string _dodatniTekst;

        public string DodatniTekst
        {
            get { return _dodatniTekst; }
            set { Set(nameof(DodatniTekst), ref _dodatniTekst, value); }
        }

        public string[] TipoviDokumenata = { "Potvrda o studiranju", "Uverenje o položenim ispitiva" };
        public ObservableCollection<Student> Studenti;

        public RelayCommand StampajDokument { get; protected set; }

        #endregion

        #region Konstruktor

        public PotvrdeUverenjaViewModel()
        {
            Studenti = new ObservableCollection<Student>(new StudentskaSluzbaDBContext().Student
                                                            .Include(s => s.IdSmeraNavigation)
                                                            .ThenInclude(s => s.IdDepartmanaNavigation)
                                                            .ToArray());

            StampajDokument = new RelayCommand(Stampaj, PopunjenaPolja);
            KreirajFajl();
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

        private void Stampaj()
        {
            switch(TipDokumenta)
            {
                case "Potvrda o studiranju":
                    StampajPotvrduOStudiranju(SelectedStudent);
                    break;
                case "Uverenje o položenim ispitiva":
                    StampajUverenjeOPolozenimIspitima(SelectedStudent);
                    break;
            }
        }

        private bool PopunjenaPolja()
        {
            return !(string.IsNullOrEmpty(TipDokumenta) || SelectedStudent == null || string.IsNullOrEmpty(Svrha));
        }

        private string Uvod(Student s)
        {
            return $"Student {s.Ime} {s.Prezime}, broj indeksa {s.BrojIndeksa}, matični broj {s.Jmbg}, podneo je zahtev, na osnovu člana 171. Zakona o opštem upravnom postupku izdaje se";
        }

        private async void StampajPotvrduOStudiranju(Student s)
        {
            using (var doc = new PdfWrapper(file))
            {
                doc.DodajSliku("Assets/logo.png", 0.5f);
                doc.DodajNaslov(imeFakulteta, 14);
                doc.DodajParagraf(Uvod(s));
                doc.DodajNaslov("Potvrda o studiranju");
                doc.DodajParagraf($"{s.Ime} {s.Prezime}, rođen {s.DatumRodjenja.ToShortDateString()}, upisan je kao redovni student na {imeFakulteta}," +
                                  $" departman za {s.IdSmeraNavigation.IdDepartmanaNavigation.Naziv}, smer {s.IdSmeraNavigation.Naziv}.");
                doc.DodajParagraf($"Potvrda koja se izdaje služi za {Svrha} i u druge svrhe se ne može upotrebljavati.");
                doc.DodajParagraf(DodatniTekst);
                doc.DodajMPiPotpis();
            }

            await PdfWrapper.OtvoriFile(file);
        }

        private async void StampajUverenjeOPolozenimIspitima(Student s)
        {
            var lista = await new StudentskaSluzbaDBContext().Ocena
                .Include(o => o.IdIspitaNavigation)
                .ThenInclude(o => o.IdPredmetaNavigation)
                .Where(o => o.IdIspitaNavigation.BrojIndeksaStudenta == s.BrojIndeksa)
                .Select(o => new
                {
                    Predmet = o.IdIspitaNavigation.IdPredmetaNavigation.Naziv,
                    Rok = o.IdIspitaNavigation.NazivRoka + " " + o.IdIspitaNavigation.Godina,
                    Ocena = o.Ocena1
                }).ToListAsync();

            using (var doc = new PdfWrapper(file))
            {
                doc.DodajSliku("Assets/logo.png", 0.5f);
                doc.DodajNaslov(imeFakulteta, 14);
                doc.DodajParagraf(Uvod(s));
                doc.DodajNaslov("Uverenje o položenim ispitima");
                doc.DodajParagraf($"{s.Ime} {s.Prezime}, upisan je kao redovni student na {imeFakulteta}, departman za {s.IdSmeraNavigation.IdDepartmanaNavigation.Naziv}," +
                                  $" smer {s.IdSmeraNavigation.Naziv} položio je sledeće ispite");
                doc.DodajTabelu(lista);
                double prosek = lista.Average(o => o.Ocena);
                doc.DodajParagraf($"Uz prosečnu ocenu {prosek:F2}");
                doc.DodajParagraf($"Uverenje koje se izdaje služi za {Svrha} i u druge svrhe se ne može upotrebljavati.");
                doc.DodajParagraf(DodatniTekst);
                doc.DodajMPiPotpis();
            }

            await PdfWrapper.OtvoriFile(file);
        }
    }
    #endregion 
}
