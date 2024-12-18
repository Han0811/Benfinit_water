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
    /// Interaction logic for win_CapNhatSuperSU.xaml
    /// </summary>
    public partial class win_CapNhatSuperSU : Window
    {
        public int id;
        public int idtarget;
        private List<usermodel> users = _userprovider.GetUsers();
        private usermodel myuser;

        public win_CapNhatSuperSU(int _id,int _idtarget)
        {
            InitializeComponent();
            id = _id;
            idtarget = _idtarget;

            myuser = _thong_tin_user.GetUserById(_idtarget, users);
            // Gán giá trị cho các TextBox từ đối tượng myCoSo
            idtbx.Text = myuser.Id.ToString();
            usernametbx.Text = myuser.UserName;
            admintbx.Text = myuser.IsAdmin.ToString();
            donvicongtactbx.Text = myuser.DonViCongTac.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Biến tạm để lưu giá trị mới nếu có thay đổi
            string tempUserName = null;
            int tempIsAdmin = 2;
            bool trangthaihoatdong = false;
            int tempdonvicongtac = int.Parse(donvicongtactbx.Text);

            if (!_thong_tin_user.ischange(admintbx.Text, myuser.IsAdmin.ToString()))
            tempIsAdmin = bool.Parse(admintbx.Text)?1:0;
            if (!_thong_tin_user.ischange(donvicongtactbx.Text , myuser.DonViCongTac.ToString()))
            trangthaihoatdong = true;



            // Gọi phương thức để cập nhật thông tin
            bool isUpdated = _userprovider.ff_sql(
                tempUserName,  // Tên người dùng (nếu có thay đổi)
                null,          // Các tham số khác, truyền null nếu không cần
                null,
                null,
                null,
                null,
                null,
                tempIsAdmin,   // Nếu tempIsAdmin có giá trị, dùng giá trị đó, nếu không thì dùng 2
                0,             // Mã chế độ (Giả sử là 2)
                tempdonvicongtac,  // Nếu tempDonViCongTac có giá trị, dùng giá trị đó, nếu không thì dùng 2
                0,             // Một tham số khác nếu cần
                id,            // ID người dùng
                idtarget ,     // ID mục tiêu
                trangthaihoatdong       // Trạng thái hoạt động
            );

            // Thông báo kết quả
            if (isUpdated)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                users = _userprovider.GetUsers();
                // Cập nhật lại thông tin từ nguồn
                myuser = _thong_tin_user.GetUserById(idtarget, users);

                // Cập nhật lại các TextBox
                idtbx.Text = myuser.Id.ToString();
                usernametbx.Text = myuser.UserName;
                admintbx.Text = myuser.IsAdmin.ToString();
                donvicongtactbx.Text = myuser.DonViCongTac.ToString();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại dữ liệu!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }





        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn xóa cơ sở này?",
                                     "Xác nhận",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Nếu người dùng chọn Yes
                if (_userprovider.ff_sql(
                null,  // Tên người dùng (nếu có thay đổi)
                null,          // Các tham số khác, truyền null nếu không cần
                null,
                null,
                null,
                null,
                null,
                2,   // Nếu tempIsAdmin có giá trị, dùng giá trị đó, nếu không thì dùng 2
                -1,             // Mã chế độ (Giả sử là 2)
                2,  // Nếu tempDonViCongTac có giá trị, dùng giá trị đó, nếu không thì dùng 2
                0,             // Một tham số khác nếu cần
                id,            // ID người dùng
                idtarget,      // ID mục tiêu
                true           // Trạng thái hoạt động
            )) MessageBox.Show("Xóa cơ sở thành công");

            }
            else
            {
                // Nếu người dùng chọn No
                MessageBox.Show("Đã hủy thao tác cập nhật.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
