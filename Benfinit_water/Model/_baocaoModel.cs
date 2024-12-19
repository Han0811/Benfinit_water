using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benfinit_water.Model
{
    class _baocaoModel
    {
        public string so_tai_khoan_hien_co { get; set; }
        public string sotaikhoanonline { get; set; }
        public string sotaikhoanoffline { get; set; }
        public List<hour> hours { get; set; }
        public List<day> days { get; set; }
    }
    class hour
    {
        public DateTime time { get; set; }
        public int total_accesses { get; set; }
    }
    class day
    {
        public DateTime time { get; set; }
        public int total_accesses { get; set; }
    }
}
