using Benfinit_water.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benfinit_water.Model;
namespace Benfinit_water.Controller
{
    public class CongTrinhController
    {

        private CongtrinhModel model;

        public CongTrinhController()
        {
            model = new CongtrinhModel();
        }

        public DataTable LoadAllConTrinh()
        {
            return model.GetAllCongTrinh();
        }

        public void AddQuy_hoach(string TenCongTrinh, string LoaiCongTrinh, string ViTri, string CapCongTrinh, int ID_QuyHoach)
        {
            model.AddCong_Trinh(TenCongTrinh, LoaiCongTrinh, ViTri, CapCongTrinh, ID_QuyHoach);
        }

        public void DeleteCongTrinh(string id)
        {
            model.DeleteCongTrinh(id);
        }
    }
}
