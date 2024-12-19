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
using Benfinit_water.Controller;
using Benfinit_water.Model;

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for win_phan_quyen_theo_nhom.xaml
    /// </summary>
    public partial class win_phan_quyen_theo_nhom : Window
    {
        private List<usermodel> users;
        private usermodel myuser;
        public int id;
        public win_phan_quyen_theo_nhom(int _id)
        {
            InitializeComponent();
            id = _id;
            users = _userprovider.GetUsers();
            myuser = _thong_tin_user.GetUserById(id, users);
            if (!myuser.IsAdmin)
            {
                MessageBox.Show("Bạn không có quyền truy cập");
                this.Close();
            }
            this.DataContext = new MainViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(oldctbx.Text, out int result1)&& int.TryParse(newctbx.Text, out int result2))
            {
                _PhanQuyenProvider.CallFPhanQuyenTheoNhomCoSo(id, Convert.ToInt32(oldctbx.Text), Convert.ToInt32(newctbx.Text));
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số cho tất cár các ô");
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(oldutbx.Text, out int result1) && int.TryParse(newutbx.Text, out int result2))
            {
                
                _PhanQuyenProvider.CallFDieuChuyenCongTac1Nhom(id, Convert.ToInt32(oldctbx.Text), Convert.ToInt32(newctbx.Text));
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số cho tất cár các ô");
            }
        }
    }
}
