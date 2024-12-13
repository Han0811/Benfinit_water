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
        public static usermodel GetUserById(int id, List<usermodel> users)
        {
            // Trả về đối tượng usermodel tìm thấy
            return users.FirstOrDefault(u => u.Id == id);
        }
    }
}
