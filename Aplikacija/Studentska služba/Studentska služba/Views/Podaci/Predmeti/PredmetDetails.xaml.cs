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

namespace Studentska_služba.Views.Podaci.Predmeti
{
    public sealed partial class PredmetDetails : UserControl
    {


        public Predmet Predmet
        {
            get { return (Predmet)GetValue(PredmetProperty); }
            set
            {
                try
                {
                    SetValue(PredmetProperty, value);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        // Using a DependencyProperty as the backing store for Predmet.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PredmetProperty =
            DependencyProperty.Register("Predmet", typeof(Predmet), typeof(PredmetDetails), new PropertyMetadata(0));

        public Profesor[] Profesori { get; private set; }

        public PredmetDetails()
        {
            this.InitializeComponent();
            Profesori = new StudentskaSluzbaDBContext().Profesor.ToArray();
        }
    }
}
