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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Benfinit_water.Controller;
using Benfinit_water.Model;
using MySql.Data.MySqlClient;

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for ctrl_dang_nhap.xaml
    /// </summary>
    public partial class ctrl_dang_nhap : UserControl
    {
        public ContentControl UserControlContainer { get; set; }
        public Window newscreen { get; set; }
        public ctrl_dang_nhap()
        {
            InitializeComponent();
        }
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

        private void LoginButton_Click(object sender, MouseButtonEventArgs e)
        {
            // Lấy dữ liệu từ TextBox và PasswordBox
            string username = used_name.Text;
            string password = pass.Password;

            List<usermodel> users = _userprovider.GetUsers();

            // Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(username))
            {
                ten_dang_nhap_tbl.Text = "Tên đăng nhập trống:";
                ten_dang_nhap_tbl.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                bool userExists = users.Any(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
                if (!userExists)
                {
                    ten_dang_nhap_tbl.Text = "Tên đăng nhập không chính xác:";
                    ten_dang_nhap_tbl.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    ten_dang_nhap_tbl.Text = "Tên đăng nhập:";
                    ten_dang_nhap_tbl.Foreground = new SolidColorBrush(Colors.Black);
                }
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(password))
            {
                mat_khau_tbl.Text = "Mật khẩu trống:";
                mat_khau_tbl.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                bool userExistsWithPassword = users
                    .Any(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password.Equals(password, StringComparison.OrdinalIgnoreCase));

                if (!userExistsWithPassword)
                {
                    mat_khau_tbl.Text = "Mật khẩu không chính xác:";
                    mat_khau_tbl.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    mat_khau_tbl.Text = "Mật khẩu nhập:";
                    mat_khau_tbl.Foreground = new SolidColorBrush(Colors.Black);
                }
            }

            // Kiểm tra và thực hiện đăng nhập nếu cả tên đăng nhập và mật khẩu hợp lệ
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                bool isValidUser = users
                    .Any(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password.Equals(password, StringComparison.OrdinalIgnoreCase));

                if (isValidUser)
                {
                    var userId = users
                        .Where(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password.Equals(password, StringComparison.OrdinalIgnoreCase))
                        .Select(u => u.Id)
                        .FirstOrDefault();

                    win_menu mywin = new win_menu(userId);
                    _userprovider.ff_sql(null, null, null, null, null, null, null, 2, 1, 2, 0, userId, userId, false);
                    mywin.Show();
                    newscreen.Close();
                }
                else
                {
                    mat_khau_tbl.Text = "Tên đăng nhập hoặc mật khẩu không chính xác.";
                    mat_khau_tbl.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
        }




        private void Chua_co_tai_khoan(object sender, MouseButtonEventArgs e)
        {
            var myControl = new ctrl_dang_ki_1();

            myControl.UserControlContainer = UserControlContainer;
            myControl.newscreen = newscreen;
            UserControlContainer.Content = myControl;



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

        private void Quen_mat_khau(object sender, MouseButtonEventArgs e)
        {
            var myControl = new ctrl_quen_mat_khau();

            myControl.UserControlContainer = UserControlContainer;
            myControl.newscreen = newscreen;
            UserControlContainer.Content = myControl;

        }

        private void Quen_mat_khau_enter(object sender, MouseEventArgs e)
        {
            if (quen_mat_khau != null)
            {
                // Thay đổi màu nền khi chuột di vào
                quen_mat_khau.Foreground = new SolidColorBrush(Colors.Blue);
            }
        }

        private void Quen_mat_khau_leave(object sender, MouseEventArgs e)
        {
            if (quen_mat_khau != null)
            {
                // Đặt lại màu nền khi chuột rời khỏi
                quen_mat_khau.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

    }
}
