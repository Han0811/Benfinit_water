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

namespace Benfinit_water
{
    /// <summary>
    /// Interaction logic for wintest.xaml
    /// </summary>
    public partial class wintest : Window
    {
        public wintest()
        {
            InitializeComponent();
        }
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            var users = _userprovider.GetUsers(); // Lấy danh sách người dùng từ cơ sở dữ liệu
            UserDataGrid.ItemsSource = users; // Hiển thị dữ liệu lên DataGrid
        }
    }
}
