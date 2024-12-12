using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benfinit_water.Model;
using MySql.Data.MySqlClient;
using System.Windows;
using Benfinit_water.Model;

namespace Benfinit_water.Controller
{
    internal class _doi_mat_khau
    {
        public static bool IsNoExistsUsername(string username)
        {
            List<usermodel> users = _userprovider.GetUsers();
            // Kiểm tra danh sách và username có hợp lệ không
            if (string.IsNullOrEmpty(username) || users == null || users.Count == 0)
            {
                return true; // Không tồn tại username nếu danh sách trống hoặc null
            }

            // Sử dụng LINQ để kiểm tra sự tồn tại
            bool exists = users.Any(user => user.UserName == username);

            // Trả về giá trị ngược của exists (nếu không tồn tại thì trả về true)
            return !exists;
        }

        public static bool IsUserExistsPhone(string phone, string username)
        {
            List<usermodel> users = _userprovider.GetUsers();
            var Phone = users
            .Where(u => u.UserName == username)
            .Select(u => u.Phone)
            .FirstOrDefault();
            if (Phone == phone)
            {
                return true;
            }
            return false;
        }
        public static bool UpdateUserPassword(string username, string newPassword)
        {
            List<usermodel> users = _userprovider.GetUsers();
            var Id = users
            .Where(u => u.UserName == username)
            .Select(u => u.Id)
            .FirstOrDefault();
            return _userprovider.f_sql(null,null,null,null, null, null,newPassword,false,false,0,0,Id,Id,false);
            
        }
    }
}
