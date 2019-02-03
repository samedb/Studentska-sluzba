using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Studentska_služba
{
    class DetailsModeToBoolean: IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (DetailsMode)value == DetailsMode.View ? false : true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
