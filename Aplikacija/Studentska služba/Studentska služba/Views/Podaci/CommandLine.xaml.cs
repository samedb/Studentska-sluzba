using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
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

namespace Studentska_služba.Views.Podaci
{
    public sealed partial class CommandLine : UserControl
    {



        public ICommand AddNewItemCommand
        {
            get { return (ICommand)GetValue(AddNewItemCommandProperty); }
            set { SetValue(AddNewItemCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddNewItemCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddNewItemCommandProperty =
            DependencyProperty.Register("AddNewItemCommand", typeof(ICommand), typeof(CommandLine), new PropertyMetadata(0));



        public ICommand UpdateItemCommand
        {
            get { return (ICommand)GetValue(UpdateItemCommandProperty); }
            set { SetValue(UpdateItemCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UpdateItemCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpdateItemCommandProperty =
            DependencyProperty.Register("UpdateItemCommand", typeof(ICommand), typeof(CommandLine), new PropertyMetadata(0));



        public ICommand DeleteItemCommand
        {
            get { return (ICommand)GetValue(DeleteItemCommandProperty); }
            set { SetValue(DeleteItemCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteItemCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteItemCommandProperty =
            DependencyProperty.Register("DeleteItemCommand", typeof(ICommand), typeof(CommandLine), new PropertyMetadata(0));




        public ICommand RefreshTableCommand
        {
            get { return (ICommand)GetValue(RefreshTableCommandProperty); }
            set { SetValue(RefreshTableCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RefreshTableCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RefreshTableCommandProperty =
            DependencyProperty.Register("RefreshTableCommand", typeof(ICommand), typeof(CommandLine), new PropertyMetadata(0));



        public string SearchBoxText
        {
            get { return (string)GetValue(SearchBoxTextProperty); }
            set { SetValue(SearchBoxTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SearchBoxText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchBoxTextProperty =
            DependencyProperty.Register("SearchBoxText", typeof(string), typeof(CommandLine), new PropertyMetadata(0));



        public CommandLine()
        {
            this.InitializeComponent();
        }
    }
}
