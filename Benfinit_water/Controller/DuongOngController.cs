using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benfinit_water.Model;
using Org.BouncyCastle.Crypto.Agreement.Srp;

namespace Benfinit_water.Controller
{
    public class DuongOngController
    {
        private DuongOngModel model;

        public DuongOngController()
        {
            model = new DuongOngModel();        
        }

        public DataTable LoadAllDuongOng()
        {
            return model.GetAllDuongOng();
        }

        public void AddDuongOng(string TenDuongOng, float ChieuDai, float DuongKinh, string VatLieu, string ViTri, int ID_CongTrinh)
        {
            model.AddDuongOng(TenDuongOng, ChieuDai, DuongKinh, VatLieu, ViTri, ID_CongTrinh);
        }

        public void DeteleDuongOng(String id)
        {
            model.DeleteDuongOng(id);
        }
    }
}
