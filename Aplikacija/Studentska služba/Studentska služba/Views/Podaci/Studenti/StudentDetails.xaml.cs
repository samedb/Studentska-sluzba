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

namespace Studentska_služba
{
    public sealed partial class StudentDetails : UserControl
    {

        public Student Student
        {
            get { return (Student)GetValue(StudentProperty); }
            set
            {
                try {
                    SetValue(StudentProperty, value);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        // Using a DependencyProperty as the backing store for Student.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StudentProperty =
            DependencyProperty.Register("Student", typeof(Student), typeof(StudentDetails), new PropertyMetadata(0));

        public string[] Polovi { get; private set; }
        public Smer[] Smerovi { get; private set; }

        public StudentDetails()
        {
            this.InitializeComponent();
            Polovi = new string[]{ "musko", "zensko"};
            Smerovi = new StudentskaSluzbaDBContext().Smer.ToArray();
        }
    }
}
