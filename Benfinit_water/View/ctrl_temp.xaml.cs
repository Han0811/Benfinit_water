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

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for ctrl_temp.xaml
    /// </summary>
    public partial class ctrl_temp : UserControl
    {
        public int id;
        public ctrl_temp(int _id)
        {
            InitializeComponent();
            id= _id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            noi_dung.Content = new ctrl_lich_su_tac_dong_he_thong(id);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            noi_dung.Content = new ctrl_danh_sach_co_so();
        }
    }
}
