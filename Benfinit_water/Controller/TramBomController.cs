using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benfinit_water.Model;

namespace Benfinit_water.Controller
{
    public class TramBomController
    {
        private TramBomModel model;

        public TramBomController()
        {
            model = new TramBomModel();
        }

        public DataTable LoadAllTramBom()
        {
            return model.GetAllTramBom();
        }

        public void AddTramBom(string TenTramBom, float CongSuat, int SoMayBom, string ViTri, int ID_CongTrinh)
        {
            model.AddTramBom(TenTramBom, CongSuat, SoMayBom, ViTri, ID_CongTrinh);
        }

        public void DeleteTramBom(String id)
        {
            model.DeleteCongTrinh(id);
        }
    }
}
