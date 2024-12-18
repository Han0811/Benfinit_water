﻿using System;
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
using Benfinit_water.Model;
namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for ctrl_danh_sach_co_so.xaml
    /// </summary>
    public partial class ctrl_danh_sach_co_so : UserControl
    {
        internal List<_CoSoModel> newCoSo = _CoSoProvider.getCoSo();
        public ctrl_danh_sach_co_so()
        {
            
            
            InitializeComponent();
            listBoxCoSo.ItemsSource = newCoSo;
        }
       
        private void ListBoxCoSo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Lấy mục đã chọn từ ListBox
            var selectedItem = listBoxCoSo.SelectedItem as _CoSoModel;

            // Kiểm tra nếu có mục nào được chọn
            if (selectedItem != null)
            {
                // Hiển thị thông báo với ID của mục đã chọn
                MessageBox.Show($"Bạn đã chọn ID: {selectedItem.id}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
  
}
