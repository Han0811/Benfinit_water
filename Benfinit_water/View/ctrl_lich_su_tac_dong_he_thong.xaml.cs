using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Benfinit_water.Controller;
using Benfinit_water.Model;

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for ctrl_lich_su_tac_dong_he_thong.xaml
    /// </summary>
    public partial class ctrl_lich_su_tac_dong_he_thong : UserControl
    {
        public ctrl_lich_su_tac_dong_he_thong(int id)
        {
            
            InitializeComponent();
            List < _danhsachlichsutruycap > data = _LichSuTruyCapProvider.GetLichSuTruyCap(id);
            

            mylist.ItemsSource =  data;

        }
    }
}
