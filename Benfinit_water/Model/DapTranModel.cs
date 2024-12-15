using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benfinit_water.Model
{
    public class DapTranModel
    {
        private string connectionString = "Server=localhost;Database=benfinit_water;Uid=root;Pwd=123456;";

        public DataTable GetAllDapTran()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM daptran";
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

        public void AddDapTran(string TenDapTran, float ChieuCao, float ChieuDai, string VatLieu, string TinhTrang, string ViTri, int ID_CongTrinh )
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO congtrinhthuyloi (TenDapTran, ChieuCao, ChieuDai, VatLieu, TinhTrang, ViTri,ID_CongTrinh) VALUES (@TenDapTran, ChieuCao, ChieuDai, @VatLieu, @TinhTrang, @ViTri,@ID_CongTrinh)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@TenDapTran", TenDapTran);
                        cmd.Parameters.AddWithValue("@ChieuCao", ChieuCao);
                        cmd.Parameters.AddWithValue("@ChieuDai", ChieuDai);

                        cmd.Parameters.AddWithValue("@VatLieu", VatLieu);

                        cmd.Parameters.AddWithValue("@TinhTrang", TinhTrang);
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

        public void DeleteDapTran(string id)
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
