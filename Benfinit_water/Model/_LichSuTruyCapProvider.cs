using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benfinit_water.Model;
using Benfinit_water.View;
using MySql.Data.MySqlClient;
using Benfinit_water.View;

namespace Benfinit_water.Model
{

    public class _LichSuTruyCapProvider
    {



        public static List<_danhsachlichsutruycap> GetLichSuTruyCap(int ID)
        {
            string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            List<_danhsachlichsutruycap> data = new List<_danhsachlichsutruycap>();

            string query = "SELECT data FROM DanhSachLichSuTruyCap WHERE id = @ID";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Truyền tham số ID vào truy vấn
                        command.Parameters.AddWithValue("@ID", ID);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                _danhsachlichsutruycap record = new _danhsachlichsutruycap
                                {
                                    data = reader.GetString("data")
                                };

                                data.Add(record);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi trong cửa sổ
                err mywin = new err(ex.Message);
                mywin.Show();
            }

            return data;
        }

    }

}
