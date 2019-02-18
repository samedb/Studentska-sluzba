using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Statistika
{
    public class ChartData
    {
        public string Name { get; set; }
        public double Amount { get; set; }

        public ChartData(string name, double amount)
        {
            Name = name;
            Amount = amount;
        }

        public ChartData(DataRow dr)
        {
            Name = dr[0].ToString();
            Amount = (double) dr[1];
        }

        public static List<ChartData> GetDummyData()
        {
            List<ChartData> list = new List<ChartData>();
            list.Add(new ChartData("iPhone", 35));
            list.Add(new ChartData("Android", 55));
            list.Add(new ChartData("Windows Phone", 5));
            list.Add(new ChartData("Others", 5));
            return list;
        }
    }
}
