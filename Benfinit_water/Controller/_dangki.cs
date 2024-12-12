using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using Benfinit_water.Model;
using System.Windows.Controls;
using Benfinit_water.Model;

namespace Benfinit_water.Controller
{
    public class _dangki
    {
        public static bool IsUserExistsUsername(string username)
        {
            try
            {
                // Lấy tất cả người dùng từ cơ sở dữ liệu
                List<usermodel> users = _userprovider.GetUsers();

                // Kiểm tra xem tên người dùng đã tồn tại trong danh sách hay chưa
                bool userExists = users.Any(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));

                return userExists;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
        }
        public static bool SaveUserToDatabase(
                            string lastName, string firstName, string address, string email,
                            string username, string phone, string password
                            )
        {
            return _userprovider.f_sql(lastName, firstName, address, email, username, phone, password, false, false, 0, 1, 0, 0, true);
        }
        public static bool IsUserExistsPhone(string phone)
        {
            try
            {
                // Lấy tất cả người dùng từ cơ sở dữ liệu
                List<usermodel> users = _userprovider.GetUsers();

                // Kiểm tra xem số điện thoại đã tồn tại trong danh sách hay chưa
                bool userExists = users.Any(u => u.Phone.Equals(phone, StringComparison.OrdinalIgnoreCase));

                return userExists;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return true; // Trả về true nếu có lỗi, có thể tùy chỉnh theo nhu cầu.
            }
        }
        public static void ShowErrorMessage(string errorMessage)
        {
            // Tạo một cửa sổ mới để hiển thị lỗi
            Window errorWindow = new Window
            {
                Title = "Lỗi",
                Width = 400,
                Height = 200,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };

            // Tạo TextBox để hiển thị lỗi
            TextBox errorTextBox = new TextBox
            {
                Text = errorMessage,
                IsReadOnly = true,  // Để không thể chỉnh sửa, chỉ có thể sao chép
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };

            // Thêm TextBox vào cửa sổ
            errorWindow.Content = errorTextBox;

            // Hiển thị cửa sổ lỗi
            errorWindow.ShowDialog();
        }
    }
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _numberInput;

        public string NumberInput
        {
            get => _numberInput;
            set
            {
                if (_numberInput != value)
                {
                    // Kiểm tra chỉ nhập số
                    if (string.IsNullOrEmpty(value) || int.TryParse(value, out _))
                    {
                        _numberInput = value;
                        OnPropertyChanged(nameof(NumberInput));
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
