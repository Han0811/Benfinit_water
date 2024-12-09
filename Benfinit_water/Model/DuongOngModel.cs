using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benfinit_water.Model
{
    public class DuongOngModel
    {
        private string connectionString = "Server=localhost;Database=benfinit_water;Uid=root;Pwd=123456;";

        public DataTable GetAllDuongOng()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM duongong";
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

        //public void AddQuy_hoach(string TenKyQuyHoach, string ThoiGian, string MoTa)
        //{
        //    try
        //    {
        //        using (MySqlConnection connection = new MySqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            string sql = "INSERT INTO quyhoach (TenKyQuyHoach, ThoiGian, MoTa) VALUES (@TenKyQuyHoach, @ThoiGian, @MoTa)";
        //            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
        //            {
        //                cmd.Parameters.AddWithValue("@TenKyQuyHoach", TenKyQuyHoach);

        //                cmd.Parameters.AddWithValue("@ThoiGian", ThoiGian);

        //                cmd.Parameters.AddWithValue("@MoTa", MoTa);
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi khi thêm dữ liệu: " + ex.Message);
        //    }
        //}

        public void DeleteDuongOng(string id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM duongong WHERE ID_DuongOng = @id";
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
