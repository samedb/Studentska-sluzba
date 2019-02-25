using Studentska_služba.Views;
using Studentska_služba.Views.Login;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Studentska_služba
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly Dictionary<string, Type> pages = new Dictionary<string, Type>
        {
            { "Podaci", typeof(PodaciView) },
            { "Potvrde i uverenja", typeof(PotvrdeUverenjaView) },
            { "Statistika", typeof(StatistikaView) },
            { "Dokumentacija za profesore", typeof(DokumentacijaZaProfesoreView) },
            { "Settings", typeof(SettingsView) }
        };

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null && (bool)e.Parameter)
                ContentFrame.Navigate(typeof(SettingsView));
        }

        private async Task PrikaziHelpAsync()
        {
            await new MessageDialog("Ovo je help", "Help").ShowAsync();
        }

        private async void MyNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            Type selectedPage;

            if (args.IsSettingsSelected)
                selectedPage = typeof(SettingsView);
            else
            {
                var item = (NavigationViewItem)args.SelectedItem;
                string tag = item.Tag.ToString();
                selectedPage = pages[tag];
            }
            try
            {

                if (selectedPage != null)
                    ContentFrame.Navigate(selectedPage);
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message).ShowAsync();
            }
        }

        private void MyNavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack)
                ContentFrame.GoBack();
        }

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void PrikaziKod_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("https://github.com/samedb/Studentska-sluzba"));
        }

        private async void PrikaziHelp_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await new MessageDialog("Ovo je help", "Help").ShowAsync();
        }

        private void Settings_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(SettingsView));
        }

        private void SingOut_Tapped(object sender, TappedRoutedEventArgs e)
        {
            App.TrenutniKorisnik = null;
            Frame.BackStack.Clear();
            Frame.Navigate(typeof(LoginView));
        }
    }
}
