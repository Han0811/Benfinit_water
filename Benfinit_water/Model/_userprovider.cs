using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Benfinit_water.Model;
using System.Windows;
using MySql.Data.MySqlClient;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using System.Windows.Media.Effects;
using System.Data;
using Benfinit_water.Controller;
using System.Diagnostics.Eventing.Reader;
using System.Xml;

namespace Benfinit_water.Model
{
    internal class _userprovider
    {
        // Làm cho connectionString thành static
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public static List<usermodel> GetUsers()
        {
            List<usermodel> users = new List<usermodel>();

            // Tạo kết nối tới cơ sở dữ liệu
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    conn.Open();

                    // Câu lệnh SQL để lấy dữ liệu từ bảng "users" và "thong_tin_user"
                    string query = "select * from users";

                    // Tạo câu lệnh MySqlCommand cho câu truy vấn JOIN
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Thực thi câu lệnh và lấy dữ liệu từ kết quả
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Đọc dữ liệu từ kết quả
                        while (reader.Read())
                        {
                            usermodel user = new usermodel
                            {

                                Id = reader.GetInt32("id"),
                                IsAdmin = reader.GetBoolean("is_admin"),
                                UserName = reader.GetString("user_name"),
                                IsActive = reader.GetBoolean("is_active"),
                                DonViCongTac = reader.GetInt32("don_vi_cong_tac"),
                                Address = reader.GetString("address"),
                                Email = reader.GetString("email"),
                                Phone = reader.GetString("phone"),
                                Password = reader.GetString("password"),
                                DateJoined = reader.GetDateTime("date_joined"),
                                FirstName = reader.GetString("first_name"),
                                LastName = reader.GetString("last_name")
                            };

                            // Thêm vào danh sách người dùng
                            users.Add(user);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return users;
        }


        public static bool IsBool(int value)
        {
            return value == 1 || value == 0; // Trả về true nếu là boolean hợp lệ
        }



        public static bool ff_sql(
    string lastName, string firstName, string address, string email,
    string username, string phone, string password, int isAdmin, int isActive,
    int donViCongTac, int mode, int userId, int targetId, bool is_update_user)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("f_users", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm các tham số cho mode
                        cmd.Parameters.AddWithValue("mode", mode);
                        cmd.Parameters.AddWithValue("@_id", userId);
                        cmd.Parameters.AddWithValue("@_id_target", targetId);
                        // Thêm tham số cho các trường cần chấp nhận giá trị null
                        if (is_update_user)
                        { 
                            cmd.Parameters.AddWithValue("@_don_vi_cong_tac", donViCongTac);
                        }
                        else
                        {

                            cmd.Parameters.AddWithValue("@_don_vi_cong_tac", DBNull.Value);
                        }
                        cmd.Parameters.AddWithValue("@_is_active", IsBool(isActive) ? isActive : DBNull.Value);
                        cmd.Parameters.AddWithValue("@_is_admin", IsBool(isAdmin) ? isAdmin : DBNull.Value);

                        // Chấp nhận giá trị null cho _user_name nếu không có giá trị
                        cmd.Parameters.AddWithValue("@_user_name", string.IsNullOrEmpty(username) ? DBNull.Value : username);

                        // Thêm các tham số khác với giá trị có thể là null
                        cmd.Parameters.AddWithValue("@_address", string.IsNullOrEmpty(address) ? DBNull.Value : address);
                        cmd.Parameters.AddWithValue("@_email", string.IsNullOrEmpty(email) ? DBNull.Value : email);
                        cmd.Parameters.AddWithValue("@_phone", string.IsNullOrEmpty(phone) ? DBNull.Value : phone);
                        cmd.Parameters.AddWithValue("@_password", string.IsNullOrEmpty(password) ? DBNull.Value : password);
                        cmd.Parameters.AddWithValue("@_first_name", string.IsNullOrEmpty(firstName) ? DBNull.Value : firstName);
                        cmd.Parameters.AddWithValue("@_last_name", string.IsNullOrEmpty(lastName) ? DBNull.Value : lastName);

                        // Thực thi thủ tục
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (nếu có)
                _dangki.ShowErrorMessage("Lỗi: " + ex.Message);
                return false;
            }
        }

    }

}
