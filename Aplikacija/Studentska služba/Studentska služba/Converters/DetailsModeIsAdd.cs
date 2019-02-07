using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Studentska_služba
{
    class DetailsModeIsAdd: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (DetailsMode)value == DetailsMode.Add;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
