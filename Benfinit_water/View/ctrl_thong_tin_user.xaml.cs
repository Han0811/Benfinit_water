using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
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
using Benfinit_water.Model;
using Benfinit_water.View;
using GMap.NET.MapProviders;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for ctrl_thong_tin_user.xaml
    /// </summary>
    public partial class ctrl_thong_tin_user : UserControl
    {
        public int ID;
        private List<usermodel> users;
        private usermodel myuser;
        public ctrl_thong_tin_user(int _ID)
        {
            InitializeComponent();


            // Gán ID từ tham số
            ID = _ID;

            // Khởi tạo danh sách người dùng
            users = _userprovider.GetUsers();

            // Tìm kiếm người dùng với ID từ danh sách
            myuser = _thong_tin_user.GetUserById(ID, users);
            Id_tb.Text = myuser.Id.ToString();
            IsAdmin_tb.Text = myuser.IsAdmin.ToString();
            UserName_tb.Text = myuser.UserName.ToString();
            IsActive_tb.Text = myuser.IsActive.ToString();

            DonViCongTac_tb.Text = myuser.DonViCongTac.ToString();
            Address_tb.Text = myuser.Address.ToString();
            Email_tb.Text = myuser.Email.ToString();
            Phone_tb.Text = myuser.Phone.ToString();
            Password_tb.Text = myuser.Password.ToString();
            DateJoined_tb.Text = myuser.DateJoined.ToString();
            FirstName_tb.Text = myuser.FirstName.ToString();
            LastName_tb.Text = myuser.LastName.ToString();
        }
        public static bool ischange(string _object, string target)
        {
            if (_object != target) return false;
            else return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Khai báo biến để truyền vào SQL
            string lastName = ischange(LastName_tb.Text, myuser.LastName) ? LastName_tb.Text : null;
            string firstName = ischange(FirstName_tb.Text, myuser.FirstName) ? FirstName_tb.Text : null;
            string address = ischange(Address_tb.Text, myuser.Address) ? Address_tb.Text : null;
            string email = ischange(Email_tb.Text, myuser.Email) ? Email_tb.Text : null;
            string username = ischange(UserName_tb.Text, myuser.UserName) ? UserName_tb.Text : null;
            string phone = ischange(Phone_tb.Text, myuser.Phone) ? Phone_tb.Text : null;
            string password = ischange(Password_tb.Text, myuser.Password) ? Password_tb.Text : null;
            int donViCongTac = myuser.DonViCongTac; // Giá trị mặc định là giá trị cũ
            if (ischange(DonViCongTac_tb.Text, myuser.DonViCongTac.ToString()) &&
                int.TryParse(DonViCongTac_tb.Text, out int parsedValue))
            {
                donViCongTac = parsedValue; // Nếu chuyển đổi thành công, gán giá trị mới
            }

            bool is_update_user = false;
            if (myuser.IsAdmin)
            {
                is_update_user = true;
            }
            else
            {
                MessageBox.Show("Bạn không có quyền sửa cơ sở làm việc");
                Id_tb.Text = myuser.Id.ToString();
                IsAdmin_tb.Text = myuser.IsAdmin.ToString();
                UserName_tb.Text = myuser.UserName.ToString();
                IsActive_tb.Text = myuser.IsActive.ToString();

                DonViCongTac_tb.Text = myuser.DonViCongTac.ToString();
                Address_tb.Text = myuser.Address.ToString();
                Email_tb.Text = myuser.Email.ToString();
                Phone_tb.Text = myuser.Phone.ToString();
                Password_tb.Text = myuser.Password.ToString();
                DateJoined_tb.Text = myuser.DateJoined.ToString();
                FirstName_tb.Text = myuser.FirstName.ToString();
                LastName_tb.Text = myuser.LastName.ToString();
                return;
            }


            // Các giá trị mặc định
            int mode = 0; // Ví dụ giá trị cập nhật
            int userId = myuser.Id;
            int targetId = myuser.Id;


            // Gọi phương thức f_sql
            if (_userprovider.f_sql(
                lastName, firstName, address, email, username,
                phone, password, myuser.IsAdmin, myuser.IsActive, donViCongTac,
                mode, userId, targetId, is_update_user)) MessageBox.Show("Cập nhật thành công");
            else MessageBox.Show("Cập nhật thất bại");

            
            users = _userprovider.GetUsers();

            // Tìm kiếm người dùng với ID từ danh sách
            myuser = _thong_tin_user.GetUserById(ID, users);
            Id_tb.Text = myuser.Id.ToString();
            IsAdmin_tb.Text = myuser.IsAdmin.ToString();
            UserName_tb.Text = myuser.UserName.ToString();
            IsActive_tb.Text = myuser.IsActive.ToString();

            DonViCongTac_tb.Text = myuser.DonViCongTac.ToString();
            Address_tb.Text = myuser.Address.ToString();
            Email_tb.Text = myuser.Email.ToString();
            Phone_tb.Text = myuser.Phone.ToString();
            Password_tb.Text = myuser.Password.ToString();
            DateJoined_tb.Text = myuser.DateJoined.ToString();
            FirstName_tb.Text = myuser.FirstName.ToString();
            LastName_tb.Text = myuser.LastName.ToString();
        }
    }

}


