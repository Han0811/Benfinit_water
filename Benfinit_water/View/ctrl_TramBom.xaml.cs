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
using Benfinit_water.Controller;

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for ctrl_TramBom.xaml
    /// </summary>
    public partial class ctrl_TramBom : UserControl
    {
        private TramBomController controller;
        private bool isAdding;

        public ctrl_TramBom()
        {
            InitializeComponent();
            controller = new TramBomController();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                DataTable data = controller.LoadAllTramBom();
                dataGrid.ItemsSource = data.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    controller.DeleteTramBom(id);
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
                string map = txtMap.Text;

                if (!string.IsNullOrWhiteSpace(name) && float.TryParse(txtCategory.Text, out float category) && !string.IsNullOrWhiteSpace(map) && int.TryParse(txtConst.Text, out int con) && int.TryParse(txtPrice.Text, out int price))
                {
                    try
                    {
                        // Thực hiện thêm sản phẩm vào database
                        controller.AddTramBom(name, category, price, map, con);
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
