using Studentska_služba.ViewModels.Podaci.Ispiti;
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

namespace Studentska_služba.Views.Podaci.Ispiti
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IspitiAdd : Page
    {
        public int[] Godine { get; private set; }
        public string[] Rokovi { get; private set; }
        IspitiAddViewModel vm;

        public IspitiAdd()
        {
            this.InitializeComponent();

            Godine = new int[] { 2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030 };
            Rokovi = new string[] { "Januar", "Februar", "Mart", "Jun", "Jul", "Septembar", "Oktobar", "Oktobar II", "Novembar" };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            vm = new IspitiAddViewModel(Frame);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }
    }
}
