using iText7Wrapper;
using Studentska_služba.ViewModels.PotvrdeUverenja;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Studentska_služba.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PotvrdeUverenjaView : Page
    {
        PotvrdeUverenjaViewModel vm;

        public PotvrdeUverenjaView()
        {
            this.InitializeComponent();
            vm = new PotvrdeUverenjaViewModel();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = ApplicationData.Current.TemporaryFolder;
            StorageFile file = await folder.CreateFileAsync("temp.pdf", CreationCollisionOption.ReplaceExisting);

            var lista = new StudentskaSluzbaDBContext().Profesor
                .Where(p => p.Pol == "musko")
                .Select(p => new
                {
                    p.Ime,
                    p.Prezime,
                    p.Pol,
                    p.DatumRodjenja
                })
                .ToList();

            using (var doc = new PdfWrapper(file))
            {
                doc.DodajSliku("Assets/logo.png", 0.5f);
                doc.DodajNaslov("Državni univerzitet u Novom Pazaru", 14);
                doc.DodajNaslov("Uverenje o polozenom ispitu", 22);
                doc.DodajParagraf("Ovo je lista profesora koji rade na fakultetu. U listi je prikazano ime, prezime, pol i datum rodjenja profesora. I ja ovde sad pisem neki tekst da bi imas sta da stampam.");
                doc.DodajTabelu(lista);
                doc.DodajMPiPotpis();
            }

            await PdfWrapper.OtvoriFile(file);
        }

    }
}
