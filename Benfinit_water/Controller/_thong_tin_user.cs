using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benfinit_water.Model;

namespace Benfinit_water.Controller
{
    internal class _thong_tin_user
    {
        public static bool ischange(string _object, string target)
        {
            if (_object != target) return false;
            else return true;
        }
        public static usermodel GetUserById(int id, List<usermodel> users)
        {
            // Trả về đối tượng usermodel tìm thấy
            return users.FirstOrDefault(u => u.Id == id);
        }
    }
}
