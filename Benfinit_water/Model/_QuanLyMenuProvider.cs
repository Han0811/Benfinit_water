using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benfinit_water.Controller;
using Benfinit_water.View;
using MySql.Data.MySqlClient;
using Benfinit_water.Model;
using System.Windows;
using System.Configuration;
namespace Benfinit_water.Model
{
    class _QuanLyMenuProvider
    {
        public static timkiem GetTimKiem()
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"]?.ConnectionString;

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Chuỗi kết nối không được định nghĩa trong tệp cấu hình.");
            }

            timkiem data = new timkiem();
            string query = "SELECT data_seach FROM allcolumns";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!reader.IsDBNull(reader.GetOrdinal("data_seach")))
                                {
                                    data._string.Add(reader["data_seach"].ToString());
                                }
                            }
                        }
                    }
                }

                data._data = RetrieveData() ?? new List<data>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thực thi GetTimKiem: {ex.Message}\nStackTrace: {ex.StackTrace}");
                err mywin = new err(ex.Message);
                mywin.Show();
            }

            return data;
        }

        public static List<data> RetrieveData()
        {
            // Chuỗi kết nối MySQL (cập nhật thông tin của bạn ở đây)
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString; ;

            // Danh sách để lưu dữ liệu
            List<data> dataList = new List<data>();

            // Truy vấn SQL
            string query = "SELECT TABLE_NAME, data_seach FROM allcolumns";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new data
                                {
                                    
                                    TABLE_NAME = reader["TABLE_NAME"].ToString(),
                                    data_seach = reader["data_seach"].ToString()
                                });
                                
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối hoặc truy xuất dữ liệu: " + ex.Message);
            }

            return dataList;
        }
    }
}
