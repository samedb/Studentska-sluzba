using Microsoft.Toolkit.Uwp.UI.Controls;
using Studentska_služba.ViewModels.Podaci.Ocene;
using Studentska_služba.ViewModels.PrijemniIspit;
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
    public sealed partial class PrijemniIspitView : Page
    {
        OceneViewModel vm;

        public PrijemniIspitView()
        {
            vm = new OceneViewModel();
            this.InitializeComponent();
        }

        //private void DataGrid_Sorting(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridColumnEventArgs e)
        //{
        //    foreach (DataGridColumn dataGridColumn in dataGrid.Columns)
        //    {
        //        if (dataGridColumn.Tag != null && e.Column.Tag != null && dataGridColumn.Tag.ToString() != e.Column.Tag.ToString())
        //            dataGridColumn.SortDirection = null;

        //    }

        //    if (e.Column.Tag != null)
        //    {
        //        if (e.Column.SortDirection == null || e.Column.SortDirection == DataGridSortDirection.Descending)
        //        {
        //            dataGrid.ItemsSource = vm.SortData(e.Column.Tag.ToString(), true);
        //            e.Column.SortDirection = DataGridSortDirection.Ascending;
        //        }
        //        else
        //        {
        //            dataGrid.ItemsSource = vm.SortData(e.Column.Tag.ToString(), false);
        //            e.Column.SortDirection = DataGridSortDirection.Descending;
        //        }
        //    }
        //}
    }
}
