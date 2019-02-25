using Studentska_služba.Views.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.UI.Popups;
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
    public sealed partial class SettingsView : Page
    {
        public SettingsView()
        {
            this.InitializeComponent();
            switch (ApplicationLanguages.PrimaryLanguageOverride)
            {
                case "en":
                    MyCombobox.SelectedIndex = 0;
                    break;
                case "de":
                    MyCombobox.SelectedIndex = 1;
                    break;
            }
            MyCombobox.SelectionChanged += MyCombobox_SelectionChanged;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PromenaLozinkeView));
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
                if (Window.Current.Content is FrameworkElement frameworkElement)
                    frameworkElement.RequestedTheme = (sender as ToggleSwitch).IsOn ? ElementTheme.Dark : ElementTheme.Light;   
        }

        private void MyCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (MyCombobox.SelectedIndex)
            {
                case 0:
                    ApplicationLanguages.PrimaryLanguageOverride = "en";
                    break;
                case 1:
                    ApplicationLanguages.PrimaryLanguageOverride = "de";
                    break;
            }
            Thread.Sleep(200);
            RefreshMainPage();
        }

        private void RefreshMainPage()
        {
            var navigationView = this.Frame.Parent as NavigationView;
            var grid = navigationView.Parent as Grid;
            var page = grid.Parent as MainPage;
            //var mainframe = page.Parent as Frame;
            page.Frame.Navigate(typeof(MainPage), true);
        }
    }
}
