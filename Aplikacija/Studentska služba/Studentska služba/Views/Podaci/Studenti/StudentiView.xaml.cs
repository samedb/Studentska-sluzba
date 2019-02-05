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

namespace Studentska_služba
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StudentiView : Page
    {
        public StudentiViewModel vm;
        public StudentiView()
        {
            try
            {
                vm = new StudentiViewModel();
                this.InitializeComponent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void StayWhite(object sender, DependencyPropertyChangedEventArgs e)
        {
            var b = sender as Button;
            b.Background = new SolidColorBrush(Windows.UI.Colors.White);
        }
    }
}
