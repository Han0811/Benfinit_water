using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benfinit_water.Model;

namespace Benfinit_water.Controller
{
    class _TimKiem
    {
        public static List<string> SearchData(List<data> _data, string searchTerm)
        {
            // Sử dụng LINQ để tìm kiếm tất cả các TABLE_NAME có data_seach là "a"
            var result = _data.Where(d => d.data_seach == searchTerm)
                              .Select(d => d.TABLE_NAME)
                              .ToList();

            return result;
        }
    }
}
