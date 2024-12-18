using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Benfinit_water.Model;
using MySql.Data.MySqlClient;

namespace Benfinit_water.Model
{
    public static class _CoSoProvider
    {
        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public static List<_CoSoModel> getCoSo()
        {
            List<_CoSoModel> coSoList = new List<_CoSoModel>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Câu lệnh SQL để lấy dữ liệu
                    string query = "SELECT data, id, name, muc_do_hanh_chinh_id, truc_thuoc FROM danh_sach_co_so";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();

                        // Đọc dữ liệu từ bảng và thêm vào danh sách
                        while (reader.Read())
                        {
                            if (Convert.ToInt32(reader["id"]) == 0) continue;
                            
                            _CoSoModel coSo = new _CoSoModel
                            {
                                
                                hienthi = reader["data"].ToString(),
                                id = Convert.ToInt32(reader["id"]),
                                name = reader["name"].ToString(),
                                muc_do_hanh_chinh_id = Convert.ToInt32(reader["muc_do_hanh_chinh_id"]),
                                truc_thuoc = Convert.ToInt32(reader["truc_thuoc"])
                            };

                            coSoList.Add(coSo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
            return coSoList;
        }
    }

}
