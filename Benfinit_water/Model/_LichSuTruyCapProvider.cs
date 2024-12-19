using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benfinit_water.Model;
using Benfinit_water.View;
using MySql.Data.MySqlClient;
using Benfinit_water.View;
using Benfinit_water.Model;
using Benfinit_water.Controller;
namespace Benfinit_water.Model
{

    public class _LichSuTruyCapProvider
    {



        public static List<_danhsachlichsutruycap> GetLichSuTruyCap(int ID)
        {
            string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            List<_danhsachlichsutruycap> data = new List<_danhsachlichsutruycap>();
            List <usermodel> users =_userprovider.GetUsers();
            usermodel myuser= _thong_tin_user.GetUserById(ID, users);
            string query = null;
            if (myuser.IsAdmin)
            {
                query = "SELECT * FROM DanhSachLichSuTruyCap";
            }
            else {  query = "SELECT * FROM DanhSachLichSuTruyCap WHERE id_user = @ID"; }

            

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
                                    data = reader.GetString("data"),
                                    id = reader.GetInt32("id"),
                                    action_type = reader.GetString("action_type"),
                                    user_name = reader.GetString("user_name"),
                                    access_time = reader.GetDateTime("access_time")
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
        public static List<string> GetNamesFromUserName(List<usermodel> coSoModels)
        {
            // Kiểm tra nếu danh sách đầu vào null hoặc rỗng
            if (coSoModels == null || !coSoModels.Any())
            {
                return new List<string>(); // Trả về danh sách rỗng
            }

            // Sử dụng LINQ để chọn trường 'name' từ danh sách
            return coSoModels.Select(model => model.UserName).ToList();
        }

        public static List<_danhsachlichsutruycap> SearchByUserName(List<_danhsachlichsutruycap> coSoModels, string searchTerm)
        {
            // Kiểm tra nếu danh sách đầu vào null hoặc chuỗi tìm kiếm là null/rỗng
            if (coSoModels == null || string.IsNullOrEmpty(searchTerm))
            {
                return new List<_danhsachlichsutruycap>(); // Trả về danh sách rỗng
            }

            // Sử dụng LINQ để lọc danh sách dựa trên chuỗi tìm kiếm (không phân biệt hoa thường)
            return coSoModels
                   .Where(model => model.user_name != null && model.user_name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                   .ToList();
        }

    }

}
