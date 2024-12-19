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
using Org.BouncyCastle.Asn1.Mozilla;

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for win_themCoSo.xaml
    /// </summary>
    public partial class win_themCoSo : Window
    {
        public int id;
        public ContentControl noi_dung;
        public win_themCoSo(int _id,ContentControl _noidung)
        {
            InitializeComponent();
            noi_dung= _noidung;
            id = _id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra các trường thông tin có được nhập đầy đủ hay không
            if (string.IsNullOrWhiteSpace(idtbx.Text) ||
                string.IsNullOrWhiteSpace(nametbx.Text) ||
                string.IsNullOrWhiteSpace(muc_do_hanh_chinh_idtbx.Text) ||
                string.IsNullOrWhiteSpace(truc_thuoctbx.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi tiếp tục!",
                                "Lỗi",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return; // Dừng thực hiện nếu thông tin chưa đầy đủ
            }

            try
            {
                // Chuyển đổi giá trị từ TextBox
                int idTarget = int.Parse(idtbx.Text);
                int? mucDoHanhChinhId = int.Parse(muc_do_hanh_chinh_idtbx.Text);
                int? trucThuoc = int.Parse(truc_thuoctbx.Text);

                // Gọi hàm f_coso để thêm/cập nhật cơ sở
                bool result = _CoSoProvider.f_coso(1, id, idTarget, nametbx.Text, mucDoHanhChinhId, trucThuoc);

                if (result)
                {
                    MessageBox.Show("Thao tác thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close(); // Đóng cửa sổ sau khi thành công
                    noi_dung.Content = new ctrl_danh_sach_co_so(id,noi_dung);
                }
                else
                {
                    MessageBox.Show("Thao tác thất bại. Vui lòng kiểm tra lại dữ liệu!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ. Vui lòng kiểm tra lại!",
                                "Lỗi",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}",
                                "Lỗi",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            win_PhanQuyenNhomCoSo mywin = new win_PhanQuyenNhomCoSo(id,noi_dung);
            mywin.Show();
            this.Close();
        }
    }
}
