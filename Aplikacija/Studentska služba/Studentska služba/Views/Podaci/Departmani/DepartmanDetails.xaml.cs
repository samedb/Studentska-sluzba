using StudentskaSluzba.Models;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Studentska_služba.Views.Podaci.Departmani
{
    public sealed partial class DepartmanDetails : UserControl
    {

        public Departman Departman
        {
            get { return (Departman)GetValue(DepartmanProperty); }
            set
            {
                try
                {
                    SetValue(DepartmanProperty, value);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        // Using a DependencyProperty as the backing store for Departman.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DepartmanProperty =
            DependencyProperty.Register("Departman", typeof(Departman), typeof(DepartmanDetails), new PropertyMetadata(0));

        public Profesor[] Profesori { get; private set; }

        public DepartmanDetails()
        {
            this.InitializeComponent();
            using (var context = new StudentskaSluzbaDBContext())
            {
                Profesori = context.Profesor.ToArray();
            }
        }
    }
}
