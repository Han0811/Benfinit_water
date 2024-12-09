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

        public void DeteleDuongOng(String id)
        {
            model.DeleteDuongOng(id);
        }
    }
}
