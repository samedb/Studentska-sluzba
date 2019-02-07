using StudentskaSluzba.Models;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Studentska_služba.Views.Podaci.Profesori
{
    public sealed partial class ProfesorDetails : UserControl
    {


        public Profesor Profesor
        {
            get { return (Profesor)GetValue(ProfesorProperty); }
            set
            {
                try
                {
                    SetValue(ProfesorProperty, value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        // Using a DependencyProperty as the backing store for Profesor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProfesorProperty =
            DependencyProperty.Register("Profesor", typeof(Profesor), typeof(ProfesorDetails), new PropertyMetadata(0));

        public string[] Polovi = { "musko", "zensko" };

        public ProfesorDetails()
        {
            this.InitializeComponent();
        }
    }
}
