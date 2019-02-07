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

namespace Studentska_služba.Views.Podaci.Referenti
{
    public sealed partial class ReferentDetails : UserControl
    {


        public Referent Referent
        {
            get { return (Referent)GetValue(ReferentProperty); }
            set
            {
                try
                {
                    SetValue(ReferentProperty, value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        // Using a DependencyProperty as the backing store for Referent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReferentProperty =
            DependencyProperty.Register("Referent", typeof(Referent), typeof(ReferentDetails), new PropertyMetadata(0));


        public DetailsMode DetailsMode
        {
            get { return (DetailsMode)GetValue(DetailsModeProperty); }
            set
            {
                try
                {
                    SetValue(DetailsModeProperty, value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        // Using a DependencyProperty as the backing store for DetailsMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DetailsModeProperty =
            DependencyProperty.Register("DetailsMode", typeof(DetailsMode), typeof(ReferentDetails), new PropertyMetadata(0));

        public string[] Polovi = { "musko", "zensko" };

        public ReferentDetails()
        {
            this.InitializeComponent();
        }
    }
}
