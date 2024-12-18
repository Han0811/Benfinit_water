using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benfinit_water.Model;

namespace Benfinit_water.Model
{

    public class timkiem
    {
        public List<string> _string { get; set; } = new List<string>();
        public List<data> _data { get; set; } = new List<data>();


    }

        public class data
    {
        public string TABLE_NAME { get; set; }
        public string data_seach { get; set; }
    }

}
