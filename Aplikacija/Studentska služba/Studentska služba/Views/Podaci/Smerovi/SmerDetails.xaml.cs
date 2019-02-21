using StudentskaSluzba.Model.Models;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Studentska_služba.Views.Podaci.Smerovi
{
    public sealed partial class SmerDetails : UserControl
    {


        public Smer Smer
        {
            get { return (Smer)GetValue(SmerProperty); }
            set
            {
                try
                {
                    SetValue(SmerProperty, value);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        // Using a DependencyProperty as the backing store for Smer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SmerProperty =
            DependencyProperty.Register("Smer", typeof(Smer), typeof(SmerDetails), new PropertyMetadata(0));


        public List<Referent> Referenti { get; private set; }
        public List<Departman> Departmani { get; private set; }

        public SmerDetails()
        {
            this.InitializeComponent();
            var context = new StudentskaSluzbaDBContext();
            PopuniListe();
        }

        private async void PopuniListe()
        {
            var dataProvider = new EFCoreDataProvider();
            Referenti = await dataProvider.GetReferentsAsync() as List<Referent>;
            Departmani = await dataProvider.GetDepartmaniAsync() as List<Departman>;
        }
    }
}
