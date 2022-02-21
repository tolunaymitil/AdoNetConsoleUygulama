using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AdoNetConsole
{
    public class TrendyolDal
    {
        public List<Trendyol> GetAll()
        {
            SqlConnection connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrendyol;integrated security=true");
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand("Select *from Trendyols", connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Trendyol> trendyols = new List<Trendyol>();

            while (reader.Read())
            {
                Trendyol trendyol = new Trendyol
                {
                    Id = Convert.ToInt32(reader["Id"]),
                     Name = reader["Name"].ToString(),
                    StockAmount= Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice= (int)Convert.ToDecimal(reader["UnitPrice"])
                };
                trendyols.Add(trendyol);
                Console.WriteLine(trendyol);
            }
            reader.Close();
            connection.Close();
            return trendyols;
        }
    }
}

