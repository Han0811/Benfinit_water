﻿using MySql.Data.MySqlClient;
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

        public void AddDuongOng(string TenDuongOng, float ChieuDai, float DuongKinh, string VatLieu, string ViTri, int ID_CongTrinh)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO duongong (TenDuongOng, ChieuDai, DuongKinh, VatLieu, ViTri, ID_CongTrinh) VALUES (@TenDuongOng, @ChieuDai, @DuongKinh, @VatLieu, @ViTri, @ID_CongTrinh)";
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@TenDuongOng", TenDuongOng);

                        cmd.Parameters.AddWithValue("@ChieuDai", ChieuDai);

                        cmd.Parameters.AddWithValue("@DuongKinh", DuongKinh);
                        cmd.Parameters.AddWithValue("@VatLieu", VatLieu);
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
