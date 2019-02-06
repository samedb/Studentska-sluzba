using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Studentska_služba.Views.Podaci.Base
{
    public class ListBase<TModel> : UserControl where TModel : class, new()
    {

        public GenericCRUDViewModel<TModel> vm
        {
            get { return (GenericCRUDViewModel<TModel>)GetValue(vmProperty); }
            set { SetValue(vmProperty, value); }
        }

        // Using a DependencyProperty as the backing store for vm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty vmProperty =
            DependencyProperty.Register("vm", typeof(GenericCRUDViewModel<TModel>), typeof(ListBase<TModel>), new PropertyMetadata(0));

        public ListBase()
        {
        }
    }
}
