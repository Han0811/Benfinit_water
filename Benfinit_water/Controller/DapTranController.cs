using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benfinit_water.Model;

namespace Benfinit_water.Controller
{
    public class DapTranController
    {
        private DapTranModel model;

        public DapTranController()
        {
            model = new DapTranModel();
        }

        public DataTable GetAllDapTran()
        {
            return model.GetAllDapTran();
        }

        public void DeleteDapTran(string id)
        {
            model.DeleteDapTran(id);
        }

        public void AddDapTran(string TenDapTran, float ChieuCao, float ChieuDai, string VatLieu, string TinhTrang, string ViTri, int ID_CongTrinh)
        {
            model.AddDapTran(TenDapTran, ChieuCao, ChieuDai, VatLieu, TinhTrang, ViTri, ID_CongTrinh);
        }
    }
}
