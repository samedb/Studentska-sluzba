using Studentska_služba.ViewModels.Podaci.Departmani;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Studentska_služba.Views.Podaci
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DepartmaniView : Page
    {
        public DepartmaniViewModel vm;
        public DepartmaniView()
        {
            try
            {
                vm = new DepartmaniViewModel();
                this.InitializeComponent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            vm.RefreshTable();
        }

    }
}
