using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Benfinit_water.Model
{

    internal class _PhanQuyenProvider
    {
        public static string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        // Hàm gọi stored procedure f_phan_quyen_theo_nhom_co_so
        public static void CallFPhanQuyenTheoNhomCoSo(int id, int trucThuocCu, int trucThuocMoi)
        {
            
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    using (var command = new MySqlCommand("f_phan_quyen_theo_nhom_co_so", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm tham số
                        command.Parameters.AddWithValue("_id", id);
                        command.Parameters.AddWithValue("_truc_thuoc_cu", trucThuocCu);
                        command.Parameters.AddWithValue("_truc_thuoc_moi", trucThuocMoi);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Stored procedure thực thi thành công!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Lỗi SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}");
            }
        }

        // Hàm gọi stored procedure f_dieu_chuyen_cong_tac_1_nhom
        public static void CallFDieuChuyenCongTac1Nhom(int id, int donViCongTacCu, int donViCongTacMoi)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    using (var command = new MySqlCommand("f_dieu_chuyen_cong_tac_1_nhom", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm tham số
                        command.Parameters.AddWithValue("_id", id);
                        command.Parameters.AddWithValue("_don_vi_cong_tac_cu", donViCongTacCu);
                        command.Parameters.AddWithValue("_don_vi_cong_tac_moi", donViCongTacMoi);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Stored procedure thực thi thành công!");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Lỗi SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}");
            }
        }


    }
}
