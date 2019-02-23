using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Models
{
    public class ChartData
    {
        public string Name { get; set; }
        public double Amount { get; set; }

        public ChartData()
        {

        }

        public ChartData(string name, double amount)
        {
            Name = name;
            Amount = amount;
        }

        public ChartData(DataRow row)
        {
            Name = row[0].ToString();
            Amount = (double) row[1];
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
