using StudentskaSluzba.Model.Models;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Studentska_služba.Views.Podaci.Ispiti
{
    public sealed partial class IspitDetails : UserControl
    {


        public Ispit Ispit
        {
            get { return (Ispit)GetValue(IspitProperty); }
            set
            {
                try
                {
                    SetValue(IspitProperty, value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        // Using a DependencyProperty as the backing store for Ispit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IspitProperty =
            DependencyProperty.Register("Ispit", typeof(Ispit), typeof(IspitDetails), new PropertyMetadata(0));



        public List<Student> Studenti;
        public List<Predmet> Predmeti;
        public int[] Godine;
        public string[] Rokovi;


        public IspitDetails()
        {
            this.InitializeComponent();
            var context = new StudentskaSluzbaDBContext();
            PopuniStudenteIPredmeteAsync();
            Godine = new int[] { 2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030 };
            Rokovi = new string[] { "Januar", "Februar", "Mart", "Jun", "Jul", "Septembar", "Oktobar", "Oktobar II", "Novembar" };   
        }

        private async void PopuniStudenteIPredmeteAsync()
        {
            var dataProvider = new EFCoreDataProvider();
            Studenti = await dataProvider.GetStudentsAsync() as List<Student>;
            Predmeti = await dataProvider.GetPredmetiAsync() as List<Predmet>;
        }
    }
}
