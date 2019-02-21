using Microsoft.EntityFrameworkCore;
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

namespace Studentska_služba.Views.Podaci.Ocene
{
    public sealed partial class OcenaDetails : UserControl
    {


        public Ocena Ocena
        {
            get { return (Ocena)GetValue(OcenaProperty); }
            set
            {
                try
                {
                    SetValue(OcenaProperty, value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        // Using a DependencyProperty as the backing store for Ocena.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OcenaProperty =
            DependencyProperty.Register("Ocena", typeof(Ocena), typeof(OcenaDetails), new PropertyMetadata(0));

        public List<Ispit> Ispiti;

        public OcenaDetails()
        {
            this.InitializeComponent();
            //Ispiti = new StudentskaSluzbaDBContext().Ispit
            //    .Include(i => i.BrojIndeksaStudentaNavigation)
            //    .Include(i => i.IdPredmetaNavigation)
            //    .ToList();
        }

       
    }
}
