using Benfinit_water.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benfinit_water.Controller
{
    public class QuyHoachController
    {

        private QuyHoachModel model;

        public QuyHoachController()
        {
            model = new QuyHoachModel();
        }

        public DataTable LoadAllQuy_Hoach()
        {
            return model.GetAllQuy_hoach();
        }

        public void AddQuy_hoach(string TenKyQuyHoach, string ThoiGian, string MoTa)
        {
            model.AddQuy_hoach(TenKyQuyHoach, ThoiGian, MoTa);
        }

        public void DeleteQuy_Hoach(string id)
        {
            model.DeleteQuy_hoach(id);
        }
    }
}
