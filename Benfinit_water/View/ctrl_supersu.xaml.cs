using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for ctrl_supersu.xaml
    /// </summary>
    public partial class ctrl_supersu : UserControl
    {
        private List<usermodel> users = _userprovider.GetUsers();
        private usermodel myuser;
        public int id;
        public ctrl_supersu(int _id)
        {
            InitializeComponent();
            id = _id;
            myuser = _thong_tin_user.GetUserById(id, users);
            listBoxCoSo.ItemsSource = users;
        }
        private void ListBoxCoSo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Lấy mục đã chọn từ ListBox
            var selectedItem = listBoxCoSo.SelectedItem as usermodel;

            // Kiểm tra nếu có mục nào được chọn
            if (selectedItem != null)
            {
                
                win_CapNhatSuperSU mywin = new win_CapNhatSuperSU(id, selectedItem.Id); // Pass user ID
                mywin.Show();
                listBoxCoSo.ItemsSource = users;
            }
        }



    }
}
