using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Benfinit_water.Model
{
    class _baocaoProvider
    {
        public static _baocaoModel GetBaocaoData()
        {
            _baocaoModel baocao = new _baocaoModel();
            baocao.hours = new List<hour>();
            baocao.days = new List<day>();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Truy vấn dữ liệu từ view baocao
                string baocaoQuery = "SELECT so_tai_khoan_hien_co, sotaikhoanonline, sotaikhoanoffline FROM baocao";

                MySqlCommand cmd = new MySqlCommand(baocaoQuery, connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        baocao.so_tai_khoan_hien_co = reader["so_tai_khoan_hien_co"].ToString();
                        baocao.sotaikhoanonline = reader["sotaikhoanonline"].ToString();
                        baocao.sotaikhoanoffline = reader["sotaikhoanoffline"].ToString();
                    }
                }

                // Truy vấn dữ liệu truy cập theo giờ từ view
                string hourQuery = "SELECT access_hour, total_accesses FROM view_access_by_hour";
                cmd = new MySqlCommand(hourQuery, connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        baocao.hours.Add(new hour
                        {
                            time = Convert.ToDateTime(reader["access_hour"]),
                            total_accesses = Convert.ToInt32(reader["total_accesses"])
                        });
                    }
                }

                // Truy vấn dữ liệu truy cập theo ngày từ view
                string dayQuery = "SELECT access_date, total_accesses FROM view_access_by_day";
                cmd = new MySqlCommand(dayQuery, connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        baocao.days.Add(new day
                        {
                            time = Convert.ToDateTime(reader["access_date"]),
                            total_accesses = Convert.ToInt32(reader["total_accesses"])
                        });
                    }
                }
            }

            return baocao;
        }

    }
}
