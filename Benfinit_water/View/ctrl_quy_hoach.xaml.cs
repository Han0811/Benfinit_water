﻿using Benfinit_water.Controller;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ctrl_quy_hoach.xaml
    /// </summary>
    public partial class ctrl_quy_hoach : UserControl
    {

        private QuyHoachController controller;
        private bool isAdding;
        private DataTable originalData;

        public ctrl_quy_hoach()
        {
            InitializeComponent();
            controller = new QuyHoachController();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DataTable data = controller.LoadAllQuy_Hoach();
                originalData = data.Copy();
                dataGrid.ItemsSource = data.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchKeyword = txtSearch.Text.ToLower(); // Lấy từ khóa tìm kiếm và chuyển thành chữ thường

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                // Lọc dữ liệu theo cột "Tên sản phẩm" (TenCongTrinh)
                var filteredRows = originalData.AsEnumerable()
                    .Where(row => row["TenKyQuyHoach"].ToString().ToLower().Contains(searchKeyword));

                if (filteredRows.Any())
                {
                    // Tạo DataTable từ kết quả lọc
                    var filteredData = filteredRows.CopyToDataTable();
                    dataGrid.ItemsSource = filteredData.DefaultView; // Cập nhật DataGrid
                }
                else
                {
                    // Nếu không tìm thấy kết quả, hiển thị DataGrid rỗng
                    dataGrid.ItemsSource = null;
                }
            }
            else
            {
                // Nếu ô tìm kiếm rỗng, hiển thị lại dữ liệu gốc
                dataGrid.ItemsSource = originalData.DefaultView;
            }
        }


        private void ChiTiet_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is object data)
            {
                // Tìm dòng tương ứng
                var row = dataGrid.ItemContainerGenerator.ContainerFromItem(data) as DataGridRow;

                if (row != null)
                {
                    // Thay đổi trạng thái ẩn/hiện của RowDetails (chi tiết dòng)
                    row.DetailsVisibility = row.DetailsVisibility == Visibility.Visible
                        ? Visibility.Collapsed
                        : Visibility.Visible;
                }
            }
        }






        // Xóa sản phẩm
        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string id = button.Tag.ToString();

            // Hỏi xác nhận trước khi xóa
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm ID: {id}?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    controller.DeleteQuy_Hoach(id);
                    MessageBox.Show("Xóa thành công!");

                    // Tải lại dữ liệu sau khi xóa
                    LoadData();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            inputGrid.Visibility = Visibility.Visible;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra trạng thái của isAdding (nếu true, thực hiện thêm dữ liệu)
            if (isAdding)
            {
                string name = txtName.Text;
                string category = txtCategory.Text;
                string price = txtPrice.Text;

                if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(category) && !string.IsNullOrWhiteSpace(price))
                {
                    try
                    {
                        // Thực hiện thêm sản phẩm vào database
                        controller.AddQuy_hoach(name, category, price);
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Tải lại dữ liệu
                        LoadData();

                        // Ẩn Grid nhập liệu và reset trạng thái
                        inputGrid.Visibility = Visibility.Collapsed;
                        isAdding = false;

                        // Xóa các giá trị nhập liệu
                        txtName.Clear();
                        txtCategory.Clear();
                        txtPrice.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                // Hiển thị Grid nhập liệu
                inputGrid.Visibility = Visibility.Visible;
                isAdding = true;
            }
        }


        private void CloseInputGrid_Click(object sender, RoutedEventArgs e)
        {
            // Ẩn Grid nhập thông tin
            inputGrid.Visibility = Visibility.Collapsed;
            isAdding = false;

            // Xóa dữ liệu nhập liệu nếu có
            txtName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
        }

        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // Cập nhật Header của hàng theo chỉ số (index)
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

    }
}
