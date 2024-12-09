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

        //public void AddQuy_hoach(string TenKyQuyHoach, string ThoiGian, string MoTa)
        //{
        //    model.AddQuy_hoach(TenKyQuyHoach, ThoiGian, MoTa);
        //}

        public void DeleteCongTrinh(string id)
        {
            model.DeleteCongTrinh(id);
        }
    }
}
