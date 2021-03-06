﻿using Studentska_služba.Views.Podaci;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Studentska_služba.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PodaciView : Page
    {
        bool AdminMode { get; set; }

        private readonly Dictionary<string, Type> pages = new Dictionary<string, Type>
        {
            {"Studenti", typeof(StudentiView) },
            {"Ocene", typeof(OceneView) },
            {"Ispiti", typeof(IspitiView) },
            {"Predmeti", typeof(PredmetiView) },
            {"Departmani", typeof(DepartmaniView) },
            {"Smerovi", typeof(SmeroviView) },
            {"Profesori", typeof(ProfesoriView) },
            {"Referenti", typeof(ReferentiView) }
        };

        public PodaciView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MyNavigationView.SelectedItem = MyNavigationView.MenuItems[0];

            AdminMode = App.TrenutniKorisnik.Usertype == "admin";

            if (!AdminMode)
            {
                foreach (NavigationViewItem item in MyNavigationView.MenuItems)
                {
                    string tag = item.Tag.ToString();
                    if (tag == "Smerovi" || tag == "Departmani" || tag == "Profesori" || tag == "Referenti")
                        item.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void MyNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            Type selectedPage;

            var item = (NavigationViewItem)args.SelectedItem;
            string tag = item.Tag.ToString();
            selectedPage = pages[tag];


            if (selectedPage != null)
                ContentFrame.Navigate(selectedPage);
        }

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            //using (var context = new StudentskaSluzbaDBContext()) {}
        }
    }
}
