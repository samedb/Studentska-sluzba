using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using StudentskaSluzba.Model.Models;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska_služba.ViewModels.Statistika
{
    public class StatistikaViewModel: ViewModelBase
    {
        private List<ChartData> prijavljeniIspitiPoRokovima;

        public List<ChartData> PrijavljeniIspitiPoRokovima
        {
            get => prijavljeniIspitiPoRokovima;
            set { Set(nameof(PrijavljeniIspitiPoRokovima), ref prijavljeniIspitiPoRokovima, value); }
        }


        private List<ChartData> polozeniIspitiPoRokovima;

        public List<ChartData> PolozeniIspitiPoRokovima
        {
            get => polozeniIspitiPoRokovima;
            set { Set(nameof(PolozeniIspitiPoRokovima), ref polozeniIspitiPoRokovima, value); }
        }


        private List<ChartData> brojStudenataPoDepartmanima;

        public List<ChartData> BrojStudenataPoDepartmanima
        {
            get => brojStudenataPoDepartmanima;
            set { Set(nameof(BrojStudenataPoDepartmanima), ref brojStudenataPoDepartmanima, value); }
        }


        private List<ChartData> uspesnostPolaganjePredmeta;

        public List<ChartData> UspesnostPolaganjePredmeta
        {
            get => uspesnostPolaganjePredmeta;
            set { Set(nameof(UspesnostPolaganjePredmeta), ref uspesnostPolaganjePredmeta, value); }
        }


        private List<ChartData> prosecnaOcenaPoPredmetu;

        public List<ChartData> ProsecnaOcenaPoPredmetu
        {
            get => prosecnaOcenaPoPredmetu;
            set { Set(nameof(ProsecnaOcenaPoPredmetu), ref prosecnaOcenaPoPredmetu, value); }
        }


        private List<ChartData> prosecnaOcenaPoDepartmanu;

        public List<ChartData> ProsecnaOcenaPoDepartmanu
        {
            get => prosecnaOcenaPoDepartmanu;
            set { Set(nameof(ProsecnaOcenaPoDepartmanu), ref prosecnaOcenaPoDepartmanu, value); }
        }

        private List<ChartData> najboljiStudenti;

        public List<ChartData> NajboljiStudenti
        {
            get => najboljiStudenti;
            set { Set(nameof(NajboljiStudenti), ref najboljiStudenti, value); }
        }


        public StatistikaViewModel()
        {
            QueryData();
        }

        private async void QueryData()
        {
            var dataProvider = new EFCoreDataProvider();
            PrijavljeniIspitiPoRokovima = await dataProvider.GetPrijavljeniIspitiPoRokovima();
            PolozeniIspitiPoRokovima = await dataProvider.GetPolozeniIspitiPoRokovima();
            BrojStudenataPoDepartmanima = await dataProvider.GetBrojStudenataPoDepartmanima();

            // Nisam uspeo sve upite da implementiram u EF Core, neki su ostali u SQL-u
            UspesnostPolaganjePredmeta = GetUspesnostPolaganjePredmeta();
            ProsecnaOcenaPoPredmetu = GetProsecnaOcenaPoPredmetu();
            ProsecnaOcenaPoDepartmanu = GetProsecnaOcenaPoDepartmanu();
            NajboljiStudenti = GetNajboljiStudenti();
        }

        //private async Task<List<ChartData>> GetPrijavljeniIspitiPoRokovima()
        //{
        //    //string upit = $@"SELECT Ispit.naziv_roka + ' ' + CONVERT(varchar(15), Ispit.godina), Cast(COUNT(*) AS Float)
        //    //                 FROM Ispit
        //    //                 WHERE godina = 2018
        //    //                 GROUP BY Ispit.godina, Ispit.naziv_roka;";
        //    //return GetChartDataList(upit);
        //}

        //private async Task<List<ChartData>> GetPolozeniIspitiPoRokovima()
        //{
        //    //string upit = $@"SELECT Ispit.naziv_roka + ' ' + CONVERT(varchar(15), Ispit.godina), Cast(COUNT(*) AS Float)
        //    //                 FROM Ispit INNER JOIN Ocena ON Ispit.id_ispita = Ocena.id_ispita
        //    //                 WHERE godina = 2018
        //    //                 GROUP BY Ispit.godina, Ispit.naziv_roka;";
        //    //return GetChartDataList(upit);
        //}

        //private List<ChartData> GetBrojStudenataPoDepartmanima()
        //{
        //    string upit = $@"SELECT Departman.naziv, Cast(COUNT(*) AS Float)
        //              FROM Student INNER JOIN Smer ON Student.id_smera = Smer.id_smera
	       //                INNER JOIN Departman ON Departman.id_departmana = Smer.id_departmana
        //              GROUP BY Departman.naziv;";
        //    return GetChartDataList(upit);
                
        //}

        private List<ChartData> GetUspesnostPolaganjePredmeta()
        {
            return ChartData.GetDummyData();
        }

        private List<ChartData> GetProsecnaOcenaPoPredmetu()
        {
            string upit = $@"SELECT Predmet.naziv, ROUND(AVG(Cast(Ocena AS Float)), 2) AS Prosek
                             FROM Ocena INNER JOIN Ispit ON Ocena.id_ispita = Ispit.id_ispita
	                              INNER JOIN Predmet ON Ispit.id_predmeta = Predmet.id_predmeta
                             GROUP BY Predmet.naziv
                             ORDER BY Prosek DESC;";
            return GetChartDataList(upit);
        }

        private List<ChartData> GetProsecnaOcenaPoDepartmanu()
        {
            string upit = $@"SELECT Departman.naziv, ROUND(AVG(Cast(Ocena AS Float)), 2) AS Prosek
                             FROM Ocena INNER JOIN Ispit ON Ocena.id_ispita = Ispit.id_ispita
	                              INNER JOIN Student ON Ispit.broj_indeksa_studenta = Student.broj_indeksa
	                              INNER JOIN Smer ON Smer.id_smera = Student.id_smera
	                              INNER JOIN Departman ON Departman.id_departmana = Smer.id_departmana
                             GROUP BY Departman.naziv
                             ORDER BY Prosek DESC;";
            return GetChartDataList(upit);
        }

        private List<ChartData> GetNajboljiStudenti()
        {

            string upit = $@"SELECT TOP 10 Student.ime + ' ' + Student.prezime, ROUND(AVG(Cast(Ocena AS Float)), 2) AS Prosek
                             FROM Ocena INNER JOIN Ispit ON Ocena.id_ispita = Ispit.id_ispita
                                  INNER JOIN Student ON Ispit.broj_indeksa_studenta = Student.broj_indeksa
                             GROUP BY Student.ime, Student.prezime
                             ORDER BY Prosek DESC;";
            return GetChartDataList(upit);
        }


        /// <summary>
        /// Izvrsava upit, popunja listu tipa ChartData i vraca je
        /// </summary>
        /// <param name="query">SQL upit</param>
        /// <returns>Vraca listu tip chartData za tad upit</returns>
        private List<ChartData> GetChartDataList(string query)
        {
            List<ChartData> lista = new List<ChartData>();
            DataTable dt = new DatabaseController().GetTable(query);
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new ChartData(row));
            }
            lista.Reverse();
            return lista;
        }

        //private void popuniTabelu()
        //{

        //    if (context.Ocena.ToList().Count() < 20)
        //    {
        //        Random rng = new Random();
        //        var ispiti = context.Ispit.ToList();
        //        foreach (var i in ispiti)
        //        {
        //            if (rng.Next() % 4 == 1)
        //            {
        //                int ocena = 6 + rng.Next() % 5;
        //                try
        //                {
        //                    context.Ocena.Add(new Ocena { IdIspita = i.IdIspita, Ocena1 = ocena });
        //                    Debug.WriteLine($"Uneta ocena {i.IdIspita} {ocena}");
        //                }
        //                catch (Exception e)
        //                {
        //                    Debug.WriteLine(e);
        //                }
                        
        //                context.SaveChanges();
        //            }
        //        }
        //        context.SaveChanges();
        //    }
        //}

    }
}
