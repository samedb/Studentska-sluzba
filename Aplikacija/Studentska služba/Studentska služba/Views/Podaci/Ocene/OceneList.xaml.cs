﻿using Microsoft.Toolkit.Uwp.UI.Controls;
using Studentska_služba.ViewModels.Podaci.Ocene;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Studentska_služba.Views.Podaci.Ocene
{
    public sealed partial class OceneList : UserControl
    {


        public OceneViewModel vm
        {
            get { return (OceneViewModel)GetValue(vmProperty); }
            set { SetValue(vmProperty, value); }
        }

        // Using a DependencyProperty as the backing store for vm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty vmProperty =
            DependencyProperty.Register("vm", typeof(OceneViewModel), typeof(OceneList), new PropertyMetadata(0));



        public OceneList()
        {
            this.InitializeComponent();
        }

        // Ovo da ide u osnovnu klasu za sve liste
        private void DataGrid_Sorting(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridColumnEventArgs e)
        {
            foreach (DataGridColumn dataGridColumn in dataGrid.Columns)
            {
                if (dataGridColumn.Tag != null && e.Column.Tag != null && dataGridColumn.Tag.ToString() != e.Column.Tag.ToString())
                    dataGridColumn.SortDirection = null;

            }

            if (e.Column.Tag != null)
            {
                if (e.Column.SortDirection == null || e.Column.SortDirection == DataGridSortDirection.Descending)
                {
                    dataGrid.ItemsSource = vm.SortData(e.Column.Tag.ToString(), true);
                    e.Column.SortDirection = DataGridSortDirection.Ascending;
                }
                else
                {
                    dataGrid.ItemsSource = vm.SortData(e.Column.Tag.ToString(), false);
                    e.Column.SortDirection = DataGridSortDirection.Descending;
                }
            }
        }
    }
}
