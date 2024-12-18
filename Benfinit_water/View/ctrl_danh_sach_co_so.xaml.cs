﻿using System;
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
using Benfinit_water.View;
namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for ctrl_danh_sach_co_so.xaml
    /// </summary>
    public partial class ctrl_danh_sach_co_so : UserControl
    {
        internal List<_CoSoModel> newCoSo = _CoSoProvider.getCoSo();
        public int id;
        private List<usermodel> users = _userprovider.GetUsers();
        private usermodel myuser;
        public ctrl_danh_sach_co_so(int _id)
        { 
            InitializeComponent();
            id = _id;
            myuser = _thong_tin_user.GetUserById(id, users);
            listBoxCoSo.ItemsSource = newCoSo;
        }
       
        private void ListBoxCoSo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Lấy mục đã chọn từ ListBox
            var selectedItem = listBoxCoSo.SelectedItem as _CoSoModel;

            // Kiểm tra nếu có mục nào được chọn
            if (selectedItem != null)
            {
                win_CapNhatCoSo mywin = new win_CapNhatCoSo(selectedItem.id,id);
                mywin.Show();
                newCoSo = _CoSoProvider.getCoSo();
                listBoxCoSo.ItemsSource = newCoSo;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!myuser.IsAdmin)
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa");
                return;
            }
            win_themCoSo mywin = new win_themCoSo(id);
            mywin.Show();
            newCoSo = _CoSoProvider.getCoSo();
            listBoxCoSo.ItemsSource = newCoSo;
        }

        
    }
  
}
