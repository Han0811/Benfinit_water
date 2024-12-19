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
using System.Windows.Shapes;
using Benfinit_water.Model;
using Benfinit_water.View;
namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for win_PhanQuyenNhomCoSo.xaml
    /// </summary>
    public partial class win_PhanQuyenNhomCoSo : Window
    {
        public int id;
        public ContentControl noi_dung;
        public win_PhanQuyenNhomCoSo(int _id,ContentControl _noi_dung)
        {
            InitializeComponent();
            noi_dung = _noi_dung;
            id=_id;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(oldctbx.Text, out int result1) && int.TryParse(newctbx.Text, out int result2))
            {
                _PhanQuyenProvider.CallFPhanQuyenTheoNhomCoSo(id, Convert.ToInt32(oldctbx.Text), Convert.ToInt32(newctbx.Text));
                noi_dung.Content=new ctrl_danh_sach_co_so (id, noi_dung);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số cho tất cár các ô");
            }

        }
    }
}
