using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Studentska_služba.Views.Podaci.Base
{
    public class DetailsBase : UserControl
    {


        public GenericCRUDViewModel<object> MyProperty
        {
            get { return (GenericCRUDViewModel<object>)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(GenericCRUDViewModel<object>), typeof(DetailsBase), new PropertyMetadata(0));


        public DetailsBase()
        {
        }
    }
}
