using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Benfinit_water.Controller;
using MySql.Data.MySqlClient;
using Benfinit_water.Model;
using Benfinit_water.Controller;

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for ctrl_quen_mat_khau.xaml
    /// </summary>
    public partial class ctrl_quen_mat_khau : UserControl
    {
        public ctrl_quen_mat_khau()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
        public ContentControl UserControlContainer { get; set; }
        public Window newscreen { get; set; }


        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            // Tạo DropShadowEffect màu đen
            var shadowEffect_black = new DropShadowEffect
            {
                Color = Colors.Black,
                Direction = -45,
                ShadowDepth = 6,
                BlurRadius = 10,
                Opacity = 0.2 // Bắt đầu với opacity nhỏ
            };

            button1.Effect = shadowEffect_black;

            // Tạo animation tăng dần opacity
            var opacityAnimation_black = new DoubleAnimation
            {
                From = 0.2,
                To = 0, // Độ trong suốt tối đa
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase()
            };
            shadowEffect_black.BeginAnimation(DropShadowEffect.OpacityProperty, opacityAnimation_black);

            // Tạo DropShadowEffect màu trắng
            var shadowEffect_white = new DropShadowEffect
            {
                Color = Colors.White,
                Direction = 135,
                ShadowDepth = 6,
                BlurRadius = 10,
                Opacity = 0.8 // Bắt đầu với opacity nhỏ
            };

            button1_trang.Effect = shadowEffect_white;

            // Tạo animation tăng dần opacity
            var opacityAnimation_white = new DoubleAnimation
            {
                From = 0.8,
                To = 0, // Độ trong suốt tối đa
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase()
            };
            shadowEffect_white.BeginAnimation(DropShadowEffect.OpacityProperty, opacityAnimation_white);

            var thicknessAnimation = new ThicknessAnimation
            {
                To = new Thickness(1),
                Duration = TimeSpan.FromSeconds(0.3), // Thời gian chuyển đổi
                EasingFunction = new QuadraticEase() // Hiệu ứng chuyển động mượt
            };
            button1.BeginAnimation(BorderThicknessProperty, thicknessAnimation);

            // Tạo hiệu ứng thay đổi BorderBrush
            var colorAnimation = new ColorAnimation
            {
                To = Color.FromArgb(0xFF, 0xB4, 0xB4, 0xB4),
                Duration = TimeSpan.FromSeconds(0.3)
            };
            var brush = new SolidColorBrush();
            brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
            button1.BorderBrush = brush;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (button1.Effect is DropShadowEffect shadowEffect_black)
            {
                // Tạo animation giảm dần opacity
                var opacityAnimation_black = new DoubleAnimation
                {
                    From = shadowEffect_black.Opacity,
                    To = 0.2, // Mất bóng dần
                    Duration = TimeSpan.FromSeconds(0.3),
                    EasingFunction = new QuadraticEase()
                };

                // Bắt đầu animation
                shadowEffect_black.BeginAnimation(DropShadowEffect.OpacityProperty, opacityAnimation_black);

                // Xóa hiệu ứng sau khi animation kết thúc
                opacityAnimation_black.Completed += (s, a) => button1.Effect = null;
            }
            if (button1_trang.Effect is DropShadowEffect shadowEffect_white)
            {
                // Tạo animation giảm dần opacity
                var opacityAnimation_white = new DoubleAnimation
                {
                    From = shadowEffect_white.Opacity,
                    To = 0.8, // Mất bóng dần
                    Duration = TimeSpan.FromSeconds(0.3),
                    EasingFunction = new QuadraticEase()
                };

                // Bắt đầu animation
                shadowEffect_white.BeginAnimation(DropShadowEffect.OpacityProperty, opacityAnimation_white);

                // Xóa hiệu ứng sau khi animation kết thúc
                opacityAnimation_white.Completed += (s, a) => button1_trang.Effect = null;

            }
            // Tạo hiệu ứng chuyển đổi BorderThickness về 0
            var thicknessAnimation = new ThicknessAnimation
            {
                To = new Thickness(0),
                Duration = TimeSpan.FromSeconds(0.3),
                EasingFunction = new QuadraticEase()
            };
            button1.BeginAnimation(BorderThicknessProperty, thicknessAnimation);

            // Loại bỏ BorderBrush bằng hiệu ứng
            var colorAnimation = new ColorAnimation
            {
                To = Colors.Transparent,
                Duration = TimeSpan.FromSeconds(0.3)
            };
            var brush = new SolidColorBrush(Color.FromArgb(0xFF, 0xB4, 0xB4, 0xB4)); // Giá trị khởi tạo
            brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
            button1.BorderBrush = brush;
        }



        private void Da_co_tai_khoan(object sender, MouseButtonEventArgs e)
        {

            var myControl = new ctrl_dang_nhap();


            myControl.UserControlContainer = UserControlContainer;
            myControl.newscreen = newscreen;
            UserControlContainer.Content = myControl;




        }

        private void Da_co_tai_khoan_enter(object sender, DragEventArgs e)
        {
            if (da_co_tai_khoan != null)
            {
                // Thay đổi màu nền khi chuột di vào
                da_co_tai_khoan.Foreground = new SolidColorBrush(Colors.Blue);
            }
        }

        private void Da_co_tai_khoan_leave(object sender, DragEventArgs e)
        {
            if (da_co_tai_khoan != null)
            {
                // Đặt lại màu nền khi chuột rời khỏi
                da_co_tai_khoan.Foreground = new SolidColorBrush(Colors.Black);
            }
        }





        
        private void LoginButton_Click(object sender, MouseButtonEventArgs e)
        {

            // Lấy thông tin từ các trường nhập liệu
            string username = used_name.Text.Trim();
            string phone = so_dien_thoai.Text.Trim();
            string password = pass.Password;
            string rePassword = re_pass.Password;

            // Kiểm tra điều kiện
            int c = 0;

            // 1. Kiểm tra tên người dùng hoặc số điện thoại đã tồn tại
            if (username != "")
            {
                if (_doi_mat_khau.IsNoExistsUsername(username))
                {
                    log_used_name.Text = "Tên người dùng không tồn tại.";
                    log_used_name.Foreground = new SolidColorBrush(Colors.Red);
                    c++;

                }
                else
                {
                    log_used_name.Text = "Tên đăng nhập:";
                    log_used_name.Foreground = new SolidColorBrush(Colors.Black);
                }
            }
            else
            {
                log_used_name.Text = "Tên người dùng trống.";
                log_used_name.Foreground = new SolidColorBrush(Colors.Red); ;
            }
            if (phone != "")
            {
                if (!_doi_mat_khau.IsUserExistsPhone(phone, username))
                {
                    log_so_dien_thoai.Text = "Sai số điện thoại";
                    log_so_dien_thoai.Foreground = new SolidColorBrush(Colors.Red); ;
                    c++;
                }
                else
                {
                    log_so_dien_thoai.Text = "Số điện thoại:";
                    log_so_dien_thoai.Foreground = new SolidColorBrush(Colors.Black); ;
                }
            }
            else
            {
                log_so_dien_thoai.Text = "Số điện thoại trống.";
                log_so_dien_thoai.Foreground = new SolidColorBrush(Colors.Red); ;
            }


            if (password != "")
            {
                if (password.Length < 8 //||
                //!Regex.IsMatch(password, @"[a-z]") ||
                //!Regex.IsMatch(password, @"[A-Z]")
                )
                {
                    log_pass.Text = "Mật khẩu mới có ít nhất 8 ký tự.";
                    log_pass.Foreground = new SolidColorBrush(Colors.Red); ;
                    c++;
                }
                else
                {
                    log_pass.Text = "Mật khẩu mới:";
                    log_pass.Foreground = new SolidColorBrush(Colors.Black); ;
                }
            }
            else
            {
                log_pass.Text = "Mật khẩu trống.";
                log_pass.Foreground = new SolidColorBrush(Colors.Red);
            }


            if (rePassword != "")
            {             // 3. Kiểm tra mật khẩu nhập lại
                if (password != rePassword)
                {
                    log_re_pass.Text = "Mật khẩu không trùng khớp.";
                    log_re_pass.Foreground = new SolidColorBrush(Colors.Red);
                    c++;
                }
                else
                {
                    log_re_pass.Text = "Nhập lại mật khẩu:";
                    log_re_pass.Foreground = new SolidColorBrush(Colors.Black);
                }
            }
            else
            {
                log_re_pass.Text = "Mật khẩu không trống.";
                log_re_pass.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (username == "" || phone == "" || password == "" || rePassword == "") return;
            if (c > 0) return;

            // Nếu không có lỗi, ghi vào MySQL

            if (_doi_mat_khau.UpdateUserPassword(username, password))
            {

                var myControl = new ctrl_lay_lai_mat_khau_thanh_cong();

                myControl.UserControlContainer = UserControlContainer;
                myControl.newscreen = newscreen;
                UserControlContainer.Content = myControl;


            }



        }

        

        

        


        private void Chua_co_tai_khoan_enter(object sender, MouseEventArgs e)
        {
            if (chua_co_tai_khoan != null)
            {
                // Thay đổi màu nền khi chuột di vào
                chua_co_tai_khoan.Foreground = new SolidColorBrush(Colors.Blue);
            }
        }

        private void Chua_co_tai_khoan_leave(object sender, MouseEventArgs e)
        {
            if (chua_co_tai_khoan != null)
            {
                // Đặt lại màu nền khi chuột rời khỏi
                chua_co_tai_khoan.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void Chua_co_tai_khoan(object sender, MouseButtonEventArgs e)
        {
            var myControl = new ctrl_dang_ki_1();

            myControl.UserControlContainer = UserControlContainer;
            myControl.newscreen = newscreen;
            UserControlContainer.Content = myControl;
        }
    }
}
