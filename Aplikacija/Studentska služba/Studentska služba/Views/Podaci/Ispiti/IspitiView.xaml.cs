using Studentska_služba.ViewModels.Podaci.Ispiti;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Studentska_služba.Views.Podaci
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IspitiView : Page
    {
        public IspitiViewModel vm;

        public IspitiView()
        {
                this.InitializeComponent();
        }

        // Ovo radim jer mi treba Frame u kome se trenutno nalazimo
        // A ta refernca je u konstruktoru jos null, pa je tek sad, kad se stranica ucita, 
        // prosledjujem viewmodelu kao parametar
        // Treba mi referenca na ContentFrame
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                vm = new IspitiViewModel(Frame);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
