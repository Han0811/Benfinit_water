using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benfinit_water.Model
{
     public class CongtrinhModel
        {
        private string connectionString = "Server=localhost;Database=benfinit_water;Uid=root;Pwd=1234CapCongTrinhID_QuyHoach;";

        public DataTable GetAllCongTrinh()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM congtrinhthuyloi";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải dữ liệu: " + ex.Message);
            }

            return dataTable;
        }

        public void AddCong_Trinh(string TenCongTrinh, string LoaiCongTrinh, string ViTri, string CapCongTrinh, string ID_QuyHoach)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO quyhoach (TenCongTrinh, LoaiCongTrinh, ViTri,CapCongTrinh,ID_QuyHoach) VALUES (@TenCongTrinh, @LoaiCongTrinh, @ViTri, @CapCongTrinh,@ID_QuyHoach)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@TenCongTrinh", TenCongTrinh);

                        cmd.Parameters.AddWithValue("@LoaiCongTrinh", LoaiCongTrinh);

                        cmd.Parameters.AddWithValue("@ViTri", ViTri);
                        cmd.Parameters.AddWithValue("@CapCongTrinh", CapCongTrinh);
                        cmd.Parameters.AddWithValue("@CapCongTrinh", ID_QuyHoach);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm dữ liệu: " + ex.Message);
            }
        }

        public void DeleteCongTrinh(string id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM congtrinhthuyloi WHERE ID_Congtrinh = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
        }
    }
}
