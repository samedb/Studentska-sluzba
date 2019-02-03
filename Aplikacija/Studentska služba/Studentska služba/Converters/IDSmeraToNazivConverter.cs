using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Studentska_služba
{
    class IDSmeraToNazivConverter: IValueConverter
    {
        private Dictionary<int, string> dictionary;

        public IDSmeraToNazivConverter()
        {
            dictionary = new Dictionary<int, string>();
            foreach(var smer in new StudentskaSluzbaDBContext().Smer)
            {
                dictionary.Add(smer.IdSmera, smer.Naziv);
            }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return dictionary[(int)value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return dictionary.FirstOrDefault(x => x.Value == (string)value).Key;
        }
    }
}
