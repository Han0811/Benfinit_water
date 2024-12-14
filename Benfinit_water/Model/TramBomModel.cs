using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benfinit_water.Model
{
    public class TramBomModel
    {
        private string connectionString = "Server=localhost;Database=benfinit_water;Uid=root;Pwd=123456;";

        public DataTable GetAllTramBom()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM trambom";
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

        public void AddTramBom(string TenTramBom, float CongSuat, int SoMayBom, string ViTri, int ID_CongTrinh)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO trambom (TenTramBom, CongSuat, SoMayBom, ViTri, ID_CongTrinh) VALUES (@TenTramBom, @CongSuat, @SoMayBom, @ViTri, @ID_CongTrinh)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@TenTramBom", TenTramBom);

                        cmd.Parameters.AddWithValue("@CongSuat", CongSuat);

                        cmd.Parameters.AddWithValue("@SoMayBom", SoMayBom);
                        cmd.Parameters.AddWithValue("@ViTri", ViTri);
                        cmd.Parameters.AddWithValue("@ID_CongTrinh", ID_CongTrinh);
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
                    string query = "DELETE FROM trambom WHERE ID_TramBom = @id";
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
