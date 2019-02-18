using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Studentska_služba
{
    class DatabaseController
    {
        private readonly string connectionString = @"Data Source=DESKTOP-B80M3RM\SQLEXPRESS;Initial Catalog=StudentskaSluzbaDB;User Id=sa;
Password=sifra123;";

        private SqlConnection connection = new SqlConnection();

        public DatabaseController()
        {
            connection.ConnectionString = connectionString;
            //TODO: singelton da uradim
        }

        public DataTable GetTable(string query) 
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                dt.Columns.Add("Greska");
                dt.Rows.Add(new object[] { ex.Message });
            }

            return dt;
        }

        public void ExecuteQuery(string query)
        {
            try
            {
                connection.Open();
                new SqlCommand(query, connection).ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public async void FillDataGrid(DataGrid grid, string query)
        {
            try
            {
                DataTable dt = await Task.Run(() => GetTable(query));

                grid.Columns.Clear();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    grid.Columns.Add(new DataGridTextColumn()
                    {
                        Header = dt.Columns[i].ColumnName,
                        Binding = new Binding { Path = new PropertyPath("[" + i.ToString() + "]") }
                    });
                }

                var collection = new ObservableCollection<object>();
                foreach (DataRow row in dt.Rows)
                {
                    collection.Add(row.ItemArray);
                }

                grid.ItemsSource = collection;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }


        /// <summary>
        /// Vrsi enkripciju ulaznog string i vraca ga
        /// </summary>
        /// <param name="password">ulazni string koji treba enkriptovati</param>
        /// <returns>Enkriptovan string</returns>
        private string EnkripcijaPassworda(string password)
        {
            // Funkcija ComputeHash prima i vraca byte[] pa zbog toga ova konverzija string u byte[] i nazad
            // Osim toga ova klasa nasledju IDisposable pa mora u using bloku
            using (var sha256 = new SHA256CryptoServiceProvider())
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(password);
                byte[] encrypted = sha256.ComputeHash(byteArray);
                return Encoding.ASCII.GetString(encrypted);
            }
        }
    }
}
