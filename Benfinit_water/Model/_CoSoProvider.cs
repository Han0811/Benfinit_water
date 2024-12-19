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
using Benfinit_water.View;

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
        public static List<_CoSoModel> FindCoSoById(List<_CoSoModel> list, int id)
        {
            // Tìm tất cả các phần tử có id bằng giá trị cụ thể
            return list.Where(x => x.id == id).ToList();
        }
        public static _CoSoModel FindCoSoFirstById(List<_CoSoModel> list, int id)
        {
            // Tìm phần tử đầu tiên có id khớp với giá trị được chỉ định
            return list.FirstOrDefault(x => x.id == id);
        }
        public static bool f_coso(
     int mode,
     int id,
     int idTarget,
     string name = null,
     int? mucDoHanhChinhId = null,
     int? trucThuoc = null)
        {
           
            string temp =null;
            // Chuỗi kết nối đến MySQL
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
           
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo một đối tượng Command để gọi stored procedure
                    using (MySqlCommand cmd = new MySqlCommand("f_co_so", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm các tham số cho stored procedure
                        cmd.Parameters.AddWithValue("mode", mode);
                        cmd.Parameters.AddWithValue("_id", id);
                        cmd.Parameters.AddWithValue("_id_target", idTarget);

                        // Các tham số có thể NULL
                        cmd.Parameters.AddWithValue("_name", string.IsNullOrEmpty(name) ? DBNull.Value : name);
                        cmd.Parameters.AddWithValue("_muc_do_hanh_chinh_id", mucDoHanhChinhId.HasValue ? mucDoHanhChinhId.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("_truc_thuoc", trucThuoc.HasValue ? trucThuoc.Value : DBNull.Value);

                        // Thực thi stored procedure
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"MySQL Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
            
            return true;
        }

    }

}
