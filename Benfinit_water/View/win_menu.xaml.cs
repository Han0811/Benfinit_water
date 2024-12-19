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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using Benfinit_water.Model;
using Org.BouncyCastle.Tls;
using Benfinit_water.Controller;
using System.Globalization;

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for win_menu.xaml
    /// </summary>
    public partial class win_menu : Window
    {
        public static timkiem newtimkiem = _QuanLyMenuProvider.GetTimKiem();
        public int id;
        private List<usermodel> users;
        private usermodel myuser;
        public win_menu(int _id)
        {
            InitializeComponent();


            id = _id;
            this.Closing += MainWindow_Closing;
            // Khởi tạo danh sách người dùng
            users = _userprovider.GetUsers();
            // Tìm kiếm người dùng với ID từ danh sách
            myuser = _thong_tin_user.GetUserById(id, users);
            noi_dung.Content = new ctrl_chao_mung();

        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to close?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; // Ngăn không cho cửa sổ đóng
            }
            else
            {
                _userprovider.ff_sql(null, null, null, null, null, null, null, 2, 0, 2, 0, id, id, false);
            }
        }

        private bool home = false;
        private bool quy_hoach = false;
        private bool dap_nuoc = false;
        private bool bom_nuoc = false;
        private bool duong_ong = false;
        private bool ban_do = false;
        private bool he_thong = false;
        private bool menu = true;
        private bool btn_nguoi_dung = false;
        public void enter035(string den, string trang)
        {

            Border button1 = this.FindName(den) as Border;
            Border button1_trang = this.FindName(trang) as Border;
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
                Duration = TimeSpan.FromSeconds(0.35),
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
                Duration = TimeSpan.FromSeconds(0.35),
                EasingFunction = new QuadraticEase()
            };
            shadowEffect_white.BeginAnimation(DropShadowEffect.OpacityProperty, opacityAnimation_white);

            var thicknessAnimation = new ThicknessAnimation
            {
                To = new Thickness(1),
                Duration = TimeSpan.FromSeconds(0.35), // Thời gian chuyển đổi
                EasingFunction = new QuadraticEase() // Hiệu ứng chuyển động mượt
            };
            button1.BeginAnimation(BorderThicknessProperty, thicknessAnimation);

            // Tạo hiệu ứng thay đổi BorderBrush
            var colorAnimation = new ColorAnimation
            {
                To = Color.FromArgb(0xFF, 0xB4, 0xB4, 0xB4),
                Duration = TimeSpan.FromSeconds(0.35)
            };
            var brush = new SolidColorBrush();
            brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
            button1.BorderBrush = brush;
        }

        public void leave035(string den, string trang)
        {
            Border button1 = this.FindName(den) as Border;
            Border button1_trang = this.FindName(trang) as Border;

            if (button1 == null || button1_trang == null) return;

            // Tạo mới DropShadowEffect cho button1
            var shadowEffectBlack = new DropShadowEffect
            {
                Direction = -45,
                Opacity = 0.2, // Đặt giá trị ban đầu
                BlurRadius = 10,
                ShadowDepth = 6,
                Color = Colors.Black
            };
            button1.Effect = shadowEffectBlack;

            // Animation giảm dần Opacity cho button1
            var opacityAnimationBlack = new DoubleAnimation
            {
                From = shadowEffectBlack.Opacity,
                To = 0.2, // Giảm dần về 0.2
                Duration = TimeSpan.FromSeconds(0.35),
                EasingFunction = new QuadraticEase()
            };
            shadowEffectBlack.BeginAnimation(DropShadowEffect.OpacityProperty, opacityAnimationBlack);

            // Tạo mới DropShadowEffect cho button1_trang
            var shadowEffectWhite = new DropShadowEffect
            {
                Direction = 135,
                Opacity = 0.8, // Đặt giá trị ban đầu
                BlurRadius = 10,
                ShadowDepth = 6,
                Color = Colors.White
            };
            button1_trang.Effect = shadowEffectWhite;

            // Animation giảm dần Opacity cho button1_trang
            var opacityAnimationWhite = new DoubleAnimation
            {
                From = shadowEffectWhite.Opacity,
                To = 0.8, // Giảm dần về 0.4
                Duration = TimeSpan.FromSeconds(0.35),
                EasingFunction = new QuadraticEase()
            };
            shadowEffectWhite.BeginAnimation(DropShadowEffect.OpacityProperty, opacityAnimationWhite);
            // Tạo hiệu ứng chuyển đổi BorderThickness về 0
            var thicknessAnimation = new ThicknessAnimation
            {
                To = new Thickness(0),
                Duration = TimeSpan.FromSeconds(0.35),
                EasingFunction = new QuadraticEase()
            };
            button1.BeginAnimation(BorderThicknessProperty, thicknessAnimation);

            // Loại bỏ BorderBrush bằng hiệu ứng
            var colorAnimation = new ColorAnimation
            {
                To = Colors.Transparent,
                Duration = TimeSpan.FromSeconds(0.35)
            };
            var brush = new SolidColorBrush(Color.FromArgb(0xFF, 0xB4, 0xB4, 0xB4)); // Giá trị khởi tạo
            brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
            button1.BorderBrush = brush;
        }
        public void enter(string den, string trang)
        {

            Border button1 = this.FindName(den) as Border;
            Border button1_trang = this.FindName(trang) as Border;
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
                Duration = TimeSpan.FromSeconds(0.2),
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
                Duration = TimeSpan.FromSeconds(0.2),
                EasingFunction = new QuadraticEase()
            };
            shadowEffect_white.BeginAnimation(DropShadowEffect.OpacityProperty, opacityAnimation_white);

            var thicknessAnimation = new ThicknessAnimation
            {
                To = new Thickness(1),
                Duration = TimeSpan.FromSeconds(0.2), // Thời gian chuyển đổi
                EasingFunction = new QuadraticEase() // Hiệu ứng chuyển động mượt
            };
            button1.BeginAnimation(BorderThicknessProperty, thicknessAnimation);

            // Tạo hiệu ứng thay đổi BorderBrush
            var colorAnimation = new ColorAnimation
            {
                To = Color.FromArgb(0xFF, 0xB4, 0xB4, 0xB4),
                Duration = TimeSpan.FromSeconds(0.2)
            };
            var brush = new SolidColorBrush();
            brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
            button1.BorderBrush = brush;
        }

        public void leave(string den, string trang)
        {
            Border button1 = this.FindName(den) as Border;
            Border button1_trang = this.FindName(trang) as Border;

            if (button1 == null || button1_trang == null) return;

            // Tạo mới DropShadowEffect cho button1
            var shadowEffectBlack = new DropShadowEffect
            {
                Direction = -45,
                Opacity = 0.2, // Đặt giá trị ban đầu
                BlurRadius = 10,
                ShadowDepth = 6,
                Color = Colors.Black
            };
            button1.Effect = shadowEffectBlack;

            // Animation giảm dần Opacity cho button1
            var opacityAnimationBlack = new DoubleAnimation
            {
                From = shadowEffectBlack.Opacity,
                To = 0.2, // Giảm dần về 0.2
                Duration = TimeSpan.FromSeconds(0.2),
                EasingFunction = new QuadraticEase()
            };
            shadowEffectBlack.BeginAnimation(DropShadowEffect.OpacityProperty, opacityAnimationBlack);

            // Tạo mới DropShadowEffect cho button1_trang
            var shadowEffectWhite = new DropShadowEffect
            {
                Direction = 135,
                Opacity = 0.8, // Đặt giá trị ban đầu
                BlurRadius = 10,
                ShadowDepth = 6,
                Color = Colors.White
            };
            button1_trang.Effect = shadowEffectWhite;

            // Animation giảm dần Opacity cho button1_trang
            var opacityAnimationWhite = new DoubleAnimation
            {
                From = shadowEffectWhite.Opacity,
                To = 0.8, // Giảm dần về 0.4
                Duration = TimeSpan.FromSeconds(0.2),
                EasingFunction = new QuadraticEase()
            };
            shadowEffectWhite.BeginAnimation(DropShadowEffect.OpacityProperty, opacityAnimationWhite);
            // Tạo hiệu ứng chuyển đổi BorderThickness về 0
            var thicknessAnimation = new ThicknessAnimation
            {
                To = new Thickness(0),
                Duration = TimeSpan.FromSeconds(0.2),
                EasingFunction = new QuadraticEase()
            };
            button1.BeginAnimation(BorderThicknessProperty, thicknessAnimation);

            // Loại bỏ BorderBrush bằng hiệu ứng
            var colorAnimation = new ColorAnimation
            {
                To = Colors.Transparent,
                Duration = TimeSpan.FromSeconds(0.2)
            };
            var brush = new SolidColorBrush(Color.FromArgb(0xFF, 0xB4, 0xB4, 0xB4)); // Giá trị khởi tạo
            brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
            button1.BorderBrush = brush;
        }


        private void doi_anh(string anh_cu, string anh_moi)
        {
            // Lấy đối tượng Image từ giao diện WPF (giả sử bạn đã khai báo Image có tên là "imageControl" trong XAML)
            Image imageControl = this.FindName(anh_cu) as Image;

            if (imageControl != null)
            {
                // Tạo ImageBrush cho hình ảnh mới (ảnh pha trộn)
                var imageBrush = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(anh_moi, UriKind.Relative)),
                    Stretch = Stretch.UniformToFill
                };

                // Tạo một GradientBrush (pha trộn) từ ảnh cũ đến ảnh mới
                var blendMask = new LinearGradientBrush
                {
                    StartPoint = new System.Windows.Point(0, 0),
                    EndPoint = new System.Windows.Point(1, 0)
                };

                // Gradient bắt đầu từ ảnh cũ (hoàn toàn đen) đến ảnh mới (hoàn toàn trắng)
                blendMask.GradientStops.Add(new GradientStop(Colors.Black, 0));   // Ảnh cũ hoàn toàn đen
                blendMask.GradientStops.Add(new GradientStop(Colors.White, 1));   // Ảnh mới hoàn toàn trắng

                // Áp dụng GradientMask cho ảnh, tạo hiệu ứng pha trộn
                imageControl.OpacityMask = blendMask;

                // Thay đổi nguồn hình ảnh sau khi pha trộn
                imageControl.Source = new BitmapImage(new Uri(anh_moi, UriKind.Relative));
            }
        }
        private void RotateButton_Click()
        {
            // Tạo animation cho thuộc tính Angle (xoay hình chữ nhật)
            DoubleAnimation rotateAnimation1 = new DoubleAnimation
            {
                From = 0,       // Góc bắt đầu
                To = 45,        // Góc kết thúc (xoay 45 độ)
                Duration = new Duration(TimeSpan.FromSeconds(0.2)), // Thời gian xoay
                RepeatBehavior = new RepeatBehavior(1)           // Số lần lặp
            };


            // Tạo animation thay đổi độ mờ (Opacity)
            DoubleAnimation opacityAnimation2 = new DoubleAnimation
            {
                From = 1,        // Độ mờ ban đầu (hiển thị hoàn toàn)
                To = 0,          // Độ mờ kết thúc (biến mất)
                Duration = new Duration(TimeSpan.FromSeconds(0.2))  // Thời gian biến mất
            };

            // Tạo animation xoay hình chữ nhật 2
            DoubleAnimation rotateAnimation3 = new DoubleAnimation
            {
                From = 0,       // Góc bắt đầu
                To = -45,       // Góc kết thúc (xoay 45 độ ngược chiều kim đồng hồ)
                Duration = new Duration(TimeSpan.FromSeconds(0.2)), // Thời gian xoay
                RepeatBehavior = new RepeatBehavior(1)           // Số lần lặp
            };

            // Tạo animation thay đổi chiều rộng của hình chữ nhật 3
            DoubleAnimation widthAnimation3 = new DoubleAnimation
            {
                From = MyRectangle1.Width,    // Chiều rộng ban đầu
                To = 54.57,                    // Chiều rộng kết thúc
                Duration = new Duration(TimeSpan.FromSeconds(0.2)), // Thời gian thay đổi
                RepeatBehavior = new RepeatBehavior(1)           // Số lần lặp
            };

            // Bắt đầu animation xoay hình chữ nhật 1
            RectangleRotateTransform1.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation1);

            // Bắt đầu animation thay đổi chiều rộng của MyRectangle1
            MyRectangle1.BeginAnimation(WidthProperty, widthAnimation3); // Sửa lại widthAnimation1 thành widthAnimation3

            // Bắt đầu animation xoay hình chữ nhật 3
            RectangleRotateTransform3.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation3);

            // Bắt đầu animation thay đổi chiều rộng của MyRectangle3
            MyRectangle3.BeginAnimation(WidthProperty, widthAnimation3); // Sửa lại widthAnimation1 thành widthAnimation3

            // Bắt đầu animation thay đổi độ mờ của hình chữ nhật 2 (biến mất)
            MyRectangle2.BeginAnimation(UIElement.OpacityProperty, opacityAnimation2); // Sửa lại opacity animation đúng thuộc tính
        }
        private void ReverseRotateButton_Click()
        {
            // Tạo animation cho thuộc tính Angle (xoay ngược lại hình chữ nhật 1)
            DoubleAnimation rotateAnimation1Reverse = new DoubleAnimation
            {
                From = 45,       // Góc ban đầu (45 độ)
                To = 0,          // Góc kết thúc (trở về góc 0 độ)
                Duration = new Duration(TimeSpan.FromSeconds(0.2)), // Thời gian xoay
                RepeatBehavior = new RepeatBehavior(1)             // Số lần lặp
            };

            // Tạo animation thay đổi độ mờ (Opacity) của hình chữ nhật 2 (hiện lại)
            DoubleAnimation opacityAnimation2Reverse = new DoubleAnimation
            {
                From = 0,        // Độ mờ ban đầu (ẩn)
                To = 1,          // Độ mờ kết thúc (hiển thị hoàn toàn)
                Duration = new Duration(TimeSpan.FromSeconds(0.2))  // Thời gian làm hiện lại
            };

            // Tạo animation xoay ngược lại hình chữ nhật 3
            DoubleAnimation rotateAnimation3Reverse = new DoubleAnimation
            {
                From = -45,      // Góc bắt đầu (-45 độ)
                To = 0,          // Góc kết thúc (trở về góc 0 độ)
                Duration = new Duration(TimeSpan.FromSeconds(0.2)), // Thời gian xoay
                RepeatBehavior = new RepeatBehavior(1)             // Số lần lặp
            };

            // Tạo animation thay đổi chiều rộng của hình chữ nhật 3 (quay lại chiều rộng ban đầu)
            DoubleAnimation widthAnimation3Reverse = new DoubleAnimation
            {
                From = MyRectangle1.Width,                // Chiều rộng ban đầu
                To = 40,     // Chiều rộng kết thúc (trở về chiều rộng ban đầu của MyRectangle1)
                Duration = new Duration(TimeSpan.FromSeconds(0.2)), // Thời gian thay đổi
                RepeatBehavior = new RepeatBehavior(1)             // Số lần lặp
            };

            // Bắt đầu animation xoay hình chữ nhật 1 (xoay trở lại góc 0 độ)
            RectangleRotateTransform1.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation1Reverse);

            // Bắt đầu animation thay đổi chiều rộng của MyRectangle1 (quay lại chiều rộng ban đầu)
            MyRectangle1.BeginAnimation(WidthProperty, widthAnimation3Reverse);

            // Bắt đầu animation xoay hình chữ nhật 3 (xoay trở lại góc 0 độ)
            RectangleRotateTransform3.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation3Reverse);

            // Bắt đầu animation thay đổi chiều rộng của MyRectangle3 (quay lại chiều rộng ban đầu)
            MyRectangle3.BeginAnimation(WidthProperty, widthAnimation3Reverse);

            // Bắt đầu animation thay đổi độ mờ của hình chữ nhật 2 (hiện lại hình chữ nhật 2)
            MyRectangle2.BeginAnimation(UIElement.OpacityProperty, opacityAnimation2Reverse);
        }

        private void home_enter(object sender, MouseEventArgs e)
        {
            enter("home_den", "home_trang");
            doi_anh("home_png", "png/home_2.png");
        }

        private void home_leave(object sender, MouseEventArgs e)
        {
            if (home)
            {
                leave("home_den", "home_trang");
                doi_anh("home_png", "png/home_3.png");
            }
            else
            {
                leave("home_den", "home_trang");
                doi_anh("home_png", "png/home_1.png");
            }

        }

        private void home_down(object sender, MouseButtonEventArgs e)
        {


            home = true;
            quy_hoach = false;
            dap_nuoc = false;
            bom_nuoc = false;
            duong_ong = false;
            ban_do = false;
            he_thong = false;
            doi_anh("home_png", "png/home_3.png");
            doi_anh("quy_hoach_png", "png/quy_hoach_1.png");
            doi_anh("dap_nuoc_png", "png/dap_nuoc_1.png");
            doi_anh("bom_nuoc_png", "png/bom_nuoc_1.png");
            doi_anh("duong_ong_png", "png/duong_ong_1.png");
            doi_anh("ban_do_png", "png/ban_do_1.png");
            doi_anh("he_thong_png", "png/he_thong_1.png");
            var myctrl = new ctrl_danh_sach_co_so(id, noi_dung);
            noi_dung.Content = myctrl;

        }
        private void quy_hoach_enter(object sender, MouseEventArgs e)
        {
            enter("quy_hoach_den", "quy_hoach_trang");
            doi_anh("quy_hoach_png", "png/quy_hoach_2.png");

        }

        private void quy_hoach_leave(object sender, MouseEventArgs e)
        {
            if (quy_hoach)
            {
                leave("quy_hoach_den", "quy_hoach_trang");
                doi_anh("quy_hoach_png", "png/quy_hoach_3.png");
            }
            else
            {
                leave("quy_hoach_den", "quy_hoach_trang");
                doi_anh("quy_hoach_png", "png/quy_hoach_1.png");
            }

        }

        private void quy_hoach_down(object sender, MouseButtonEventArgs e)
        {
            noi_dung.Content = new ctrl_quy_hoach();
            home = false;
            quy_hoach = true;
            dap_nuoc = false;
            bom_nuoc = false;
            duong_ong = false;
            ban_do = false;
            he_thong = false;
            doi_anh("home_png", "png/home_1.png");
            doi_anh("quy_hoach_png", "png/quy_hoach_3.png");
            doi_anh("dap_nuoc_png", "png/dap_nuoc_1.png");
            doi_anh("bom_nuoc_png", "png/bom_nuoc_1.png");
            doi_anh("duong_ong_png", "png/duong_ong_1.png");
            doi_anh("ban_do_png", "png/ban_do_1.png");
            doi_anh("he_thong_png", "png/he_thong_1.png");
        }
        private void dap_nuoc_enter(object sender, MouseEventArgs e)
        {
            enter("dap_nuoc_den", "dap_nuoc_trang");
            doi_anh("dap_nuoc_png", "png/dap_nuoc_2.png");

        }

        private void dap_nuoc_leave(object sender, MouseEventArgs e)
        {
            if (dap_nuoc)
            {
                leave("dap_nuoc_den", "dap_nuoc_trang");
                doi_anh("dap_nuoc_png", "png/dap_nuoc_3.png");
            }
            else
            {
                leave("dap_nuoc_den", "dap_nuoc_trang");
                doi_anh("dap_nuoc_png", "png/dap_nuoc_1.png");
            }

        }

        private void dap_nuoc_down(object sender, MouseButtonEventArgs e)
        {
            noi_dung.Content = new ctrl_CongTrinh();
            home = false;
            quy_hoach = false;
            dap_nuoc = true;
            bom_nuoc = false;
            duong_ong = false;
            ban_do = false;
            he_thong = false;
            doi_anh("home_png", "png/home_1.png");
            doi_anh("quy_hoach_png", "png/quy_hoach_1.png");
            doi_anh("dap_nuoc_png", "png/dap_nuoc_3.png");
            doi_anh("bom_nuoc_png", "png/bom_nuoc_1.png");
            doi_anh("duong_ong_png", "png/duong_ong_1.png");
            doi_anh("ban_do_png", "png/ban_do_1.png");
            doi_anh("he_thong_png", "png/he_thong_1.png");
        }
        private void bom_nuoc_enter(object sender, MouseEventArgs e)
        {
            enter("bom_nuoc_den", "bom_nuoc_trang");
            doi_anh("bom_nuoc_png", "png/bom_nuoc_2.png");
        }

        private void bom_nuoc_leave(object sender, MouseEventArgs e)
        {
            if (bom_nuoc)
            {
                leave("bom_nuoc_den", "bom_nuoc_trang");
                doi_anh("bom_nuoc_png", "png/bom_nuoc_3.png");
            }
            else
            {
                leave("bom_nuoc_den", "bom_nuoc_trang");
                doi_anh("bom_nuoc_png", "png/bom_nuoc_1.png");
            }

        }

        private void bom_nuoc_down(object sender, MouseButtonEventArgs e)
        {
            var myctrl = new ctrl_TramBom();
            noi_dung.Content = myctrl;
            home = false;
            quy_hoach = false;
            dap_nuoc = false;
            bom_nuoc = true;
            duong_ong = false;
            ban_do = false;
            he_thong = false;
            doi_anh("home_png", "png/home_1.png");
            doi_anh("quy_hoach_png", "png/quy_hoach_1.png");
            doi_anh("dap_nuoc_png", "png/dap_nuoc_1.png");
            doi_anh("bom_nuoc_png", "png/bom_nuoc_3.png");
            doi_anh("duong_ong_png", "png/duong_ong_1.png");
            doi_anh("ban_do_png", "png/ban_do_1.png");
            doi_anh("he_thong_png", "png/he_thong_1.png");
        }
        private void duong_ong_enter(object sender, MouseEventArgs e)
        {
            enter("duong_ong_den", "duong_ong_trang");
            doi_anh("duong_ong_png", "png/duong_ong_2.png");
        }

        private void duong_ong_leave(object sender, MouseEventArgs e)
        {
            if (duong_ong)
            {
                leave("duong_ong_den", "duong_ong_trang");
                doi_anh("duong_ong_png", "png/duong_ong_3.png");
            }
            else
            {
                leave("duong_ong_den", "duong_ong_trang");
                doi_anh("duong_ong_png", "png/duong_ong_1.png");
            }

        }

        private void duong_ong_down(object sender, MouseButtonEventArgs e)
        {
            var myctrl = new ctrl_DuongOng();
            noi_dung.Content = myctrl;
            home = false;
            quy_hoach = false;
            dap_nuoc = false;
            bom_nuoc = false;
            duong_ong = true;
            ban_do = false;
            he_thong = false;
            doi_anh("home_png", "png/home_1.png");
            doi_anh("quy_hoach_png", "png/quy_hoach_1.png");
            doi_anh("dap_nuoc_png", "png/dap_nuoc_1.png");
            doi_anh("bom_nuoc_png", "png/bom_nuoc_1.png");
            doi_anh("duong_ong_png", "png/duong_ong_3.png");
            doi_anh("ban_do_png", "png/ban_do_1.png");
            doi_anh("he_thong_png", "png/he_thong_1.png");
        }
        private void ban_do_enter(object sender, MouseEventArgs e)
        {
            enter("ban_do_den", "ban_do_trang");
            doi_anh("ban_do_png", "png/ban_do_2.png");
        }

        private void ban_do_leave(object sender, MouseEventArgs e)
        {
            if (ban_do)
            {
                leave("ban_do_den", "ban_do_trang");
                doi_anh("ban_do_png", "png/ban_do_3.png");
            }
            else
            {
                leave("ban_do_den", "ban_do_trang");
                doi_anh("ban_do_png", "png/ban_do_1.png");
            }

        }

        private void ban_do_down(object sender, MouseButtonEventArgs e)
        {
            var myctrl = new MapControlUserControl();
            noi_dung.Content = myctrl;
            home = false;
            quy_hoach = false;
            dap_nuoc = false;
            bom_nuoc = false;
            duong_ong = false;
            ban_do = true;
            he_thong = false;
            doi_anh("home_png", "png/home_1.png");
            doi_anh("quy_hoach_png", "png/quy_hoach_1.png");
            doi_anh("dap_nuoc_png", "png/dap_nuoc_1.png");
            doi_anh("bom_nuoc_png", "png/bom_nuoc_1.png");
            doi_anh("duong_ong_png", "png/duong_ong_1.png");
            doi_anh("ban_do_png", "png/ban_do_3.png");
            doi_anh("he_thong_png", "png/he_thong_1.png");
        }
        private void he_thong_enter(object sender, MouseEventArgs e)
        {
            enter("he_thong_den", "he_thong_trang");
            doi_anh("he_thong_png", "png/he_thong_2.png");
        }

        private void he_thong_leave(object sender, MouseEventArgs e)
        {
            if (he_thong)
            {
                leave("he_thong_den", "he_thong_trang");
                doi_anh("he_thong_png", "png/he_thong_3.png");
            }
            else
            {
                leave("he_thong_den", "he_thong_trang");
                doi_anh("he_thong_png", "png/he_thong_1.png");
            }

        }

        private void he_thong_down(object sender, MouseButtonEventArgs e)
        {
            var myctrl = new ctrl_DapTran();
            noi_dung.Content = myctrl;
            home = false;
            quy_hoach = false;
            dap_nuoc = false;
            bom_nuoc = false;
            duong_ong = false;
            ban_do = false;
            he_thong = true;
            doi_anh("home_png", "png/home_1.png");
            doi_anh("quy_hoach_png", "png/quy_hoach_1.png");
            doi_anh("dap_nuoc_png", "png/dap_nuoc_1.png");
            doi_anh("bom_nuoc_png", "png/bom_nuoc_1.png");
            doi_anh("duong_ong_png", "png/duong_ong_1.png");
            doi_anh("ban_do_png", "png/ban_do_1.png");
            doi_anh("he_thong_png", "png/he_thong_3.png");
        }

        private void btn_nguoi_dung_enter(object sender, MouseEventArgs e)
        {
            enter("btn_nguoi_dung_den", "btn_nguoi_dung_trang");
            doi_anh("btn_nguoi_dung_png", "png/nguoi_dung_2.png");
        }

        private void btn_nguoi_dung_leave(object sender, MouseEventArgs e)
        {
            if (btn_nguoi_dung)
            {
                leave("btn_nguoi_dung_den", "btn_nguoi_dung_trang");
                doi_anh("btn_nguoi_dung_png", "png/nguoi_dung_3.png");
            }
            else
            {
                leave("btn_nguoi_dung_den", "btn_nguoi_dung_trang");
                doi_anh("btn_nguoi_dung_png", "png/nguoi_dung_1.png");
            }

        }

        private void btn_nguoi_dung_down(object sender, MouseButtonEventArgs e)
        {
            if (btn_nguoi_dung)
            {
                btn_nguoi_dung = false;
                menu_nguoi_dung_trang.Visibility = Visibility.Collapsed;
            }
            else
            {
                btn_nguoi_dung = true;
                menu_nguoi_dung_trang.Visibility = Visibility.Visible;
            }


            doi_anh("btn_nguoi_dung_png", "png/nguoi_dung_3.png");
            doi_anh("btn_nguoi_dung_png", "png/nguoi_dung_3.png");

        }

        private void menu_enter(object sender, MouseEventArgs e)
        {
            enter("menu_den", "menu_trang");
            doi_anh("menu_png", "png/ban_do_2.png");
        }

        private void menu_leave(object sender, MouseEventArgs e)
        {
            if (menu)
            {
                leave("menu_den", "menu_trang");
                doi_anh("menu_png", "png/ban_3.png");
            }
            else
            {
                leave("menu_den", "menu_trang");
                doi_anh("menu_png", "png/ban_do_1.png");
            }

        }

        private void menu_down(object sender, MouseButtonEventArgs e)
        {
            if (menu)
            {
                menu = false;
                RotateButton_Click();
                DoubleAnimation withmenu = new DoubleAnimation
                {
                    From = 1280,                // Chiều rộng ban đầu
                    To = 1188.89,  // Chiều rộng kết thúc (trở về chiều rộng ban đầu của MyRectangle1)
                    Duration = new Duration(TimeSpan.FromSeconds(0.35)), // Thời gian thay đổi
                    RepeatBehavior = new RepeatBehavior(1)             // Số lần lặp
                };
                man_hinh_den.BeginAnimation(WidthProperty, withmenu);  // Thực thi trên Border menu_trang
                man_hinh_trang.BeginAnimation(WidthProperty, withmenu);
                enter035("man_hinh_den", "man_hinh_trang");
            }
            else
            {
                menu = true;
                ReverseRotateButton_Click();

                DoubleAnimation withmenu = new DoubleAnimation
                {
                    From = 1188.89,                // Chiều rộng ban đầu
                    To = 1280,  // Chiều rộng kết thúc (trở về chiều rộng ban đầu của MyRectangle1)
                    Duration = new Duration(TimeSpan.FromSeconds(0.35)), // Thời gian thay đổi
                    RepeatBehavior = new RepeatBehavior(1)             // Số lần lặp
                };
                man_hinh_den.BeginAnimation(WidthProperty, withmenu);  // Thực thi trên Border menu_trang
                man_hinh_trang.BeginAnimation(WidthProperty, withmenu);
                leave035("man_hinh_den", "man_hinh_trang");

            }



        }
        private void bao_cao_enter(object sender, MouseEventArgs e)
        {
            enter("bao_cao_den", "bao_cao_trang");

        }

        private void bao_caon_leave(object sender, MouseEventArgs e)
        {
            if (true)
            {
                leave("bao_cao_den", "bao_cao_trang");

            }
        }
        private void bao_cao_down(object sender, MouseButtonEventArgs e)
        {

            noi_dung.Content = new ctrl_baocao();
        }




        private void thong_tin_enter(object sender, MouseEventArgs e)
        {
            enter("thong_tin_den", "thong_tin_trang");

        }

        private void thong_tin_leave(object sender, MouseEventArgs e)
        {
            if (true)
            {
                leave("thong_tin_den", "thong_tin_trang");

            }
        }
        private void thong_tin_down(object sender, MouseButtonEventArgs e)
        {

            noi_dung.Content = new ctrl_thong_tin_user(id);
        }
        private void lich_su_down(object sender, MouseButtonEventArgs e)
        {

            noi_dung.Content = new ctrl_lich_su_tac_dong_he_thong(id);
        }
        private void lich_su_enter(object sender, MouseEventArgs e)
        {
            enter("lich_su_den", "lich_su_trang");

        }

        private void lich_su_leave(object sender, MouseEventArgs e)
        {
            if (true)
            {
                leave("lich_su_den", "lich_su_trang");

            }


        }


        private void admin_enter(object sender, MouseEventArgs e)
        {
            enter("admin_den", "admin_trang");

        }

        private void admin_leave(object sender, MouseEventArgs e)
        {
            if (true)
            {
                leave("admin_den", "admin_trang");

            }


        }
        private void admin_down(object sender, MouseButtonEventArgs e)
        {

            if (myuser.IsAdmin)
                noi_dung.Content = new ctrl_supersu(id, noi_dung);
            else MessageBox.Show("Bạn không có quyền truy cập");
        }

        private void dang_xuat_enter(object sender, MouseEventArgs e)
        {
            enter("dang_xuat_den", "dang_xuat_trang");

        }

        private void dang_xuat_leave(object sender, MouseEventArgs e)
        {
            if (true)
            {
                leave("dang_xuat_den", "dang_xuat_trang");

            }


        }

        private void dang_xuat_down(object sender, MouseButtonEventArgs e)
        {
            win_dang_nhap mywin = new win_dang_nhap();

            this.Close();
            mywin.Show();

        }

        private readonly  List<string> items = new List<string>
{
                "Quản lý danh mục đơn vị hành chính cấp huyện",
                "Tìm kiếm đơn vị hành chính cấp huyện",
                "Quản lý danh mục đơn vị hành chính cấp xã",
                "Tìm kiếm danh mục đơn vị hành chính cấp xã",
                "Quản lý người dùng",
                "Tìm kiếm người dùng",
                "Quản lý trạng thái người dùng",
                "Quản lý Định nghĩa quyền",
                "Quản lý nhóm người dùng",
                "Quản trị trạng thái nhóm người dùng",
                "Tra cứu nhóm người dùng",
                "Phân quyền cho nhóm người dùng",
                "Tra cứu phân quyền cho nhóm người dùng",
                "Phân quyền cho người dùng",
                "Tra cứu phân quyền cho người dùng",
                "Quản lý Menu",
                "Quản lý lịch sử truy cập người dùng",
                "Tra cứu lịch sử truy cập người dùng",
                "Quản lý lịch sử tác động hệ thống",
                "Tra cứu lịch sử tác động hệ thống",
                "Báo cáo - thống kê người dùng",
                "Báo cáo - thống kê lịch sử truy cập người dùng",
                "Báo cáo - thống kê lịch sử tác động hệ thống",
                "Báo cáo - thống kê tổng hợp",
                "Đăng nhập hệ thống",
                "Quên mật khẩu",
                "Quản lý thông tin tài khoản",
                "Đổi mật khẩu",
                "Đăng xuất khỏi hệ thống"
            };


    private void btn_seach_enter(object sender, MouseEventArgs e)
        {
            enter("btn_seach_den", "btn_seach_trang");
            doi_anh("btn_seach_png", "png/seach_2.png");
        }

        private void btn_seach_leave(object sender, MouseEventArgs e)
        {
            if (true)
            {
                leave("btn_seach_den", "btn_seach_trang");
                doi_anh("btn_seach_png", "png/seach_1.png");
            }
            else
            {
                leave("btn_seach_den", "btn_seach_trang");
                doi_anh("btn_seach_png", "png/seach_1.png");
            }

        }

        private void btn_seach_down(object sender, MouseButtonEventArgs e)
        {
                        if (SearchBox.Text is null) ;
            else
            {
                switch (SearchBox.Text)
                {
                    case "Quản lý danh mục đơn vị hành chính cấp huyện":
                        noi_dung.Content = new ctrl_danh_sach_co_so(id, noi_dung);
                        break;
                    case "Tìm kiếm đơn vị hành chính cấp huyện":
                        noi_dung.Content = new ctrl_danh_sach_co_so(id, noi_dung);
                        break;
                    case "Quản lý danh mục đơn vị hành chính cấp xã":
                        noi_dung.Content = new ctrl_danh_sach_co_so(id, noi_dung);
                        break;
                    case "Tìm kiếm danh mục đơn vị hành chính cấp xã":
                        noi_dung.Content = new ctrl_danh_sach_co_so(id, noi_dung);
                        break;
                    case "Quản lý người dùng":
                        noi_dung.Content= new ctrl_supersu(id , noi_dung);
                        break;
                    case "Tìm kiếm người dùng":
                        noi_dung.Content = new ctrl_supersu(id, noi_dung);
                        break;
                    case "Quản lý trạng thái người dùng":
                        noi_dung.Content = new ctrl_supersu(id, noi_dung);
                        break;
                    case "Quản lý Định nghĩa quyền":
                        noi_dung.Content = new ctrl_supersu(id, noi_dung);
                        break;
                    case "Quản lý nhóm người dùng":
                        noi_dung.Content = new ctrl_supersu(id, noi_dung);
                        break;
                    case "Quản trị trạng thái nhóm người dùng":
                        noi_dung.Content = new ctrl_supersu(id, noi_dung);
                        break;
                    case "Tra cứu nhóm người dùng":
                        noi_dung.Content = new ctrl_supersu(id, noi_dung);
                        break;
                    case "Phân quyền cho nhóm người dùng":
                        noi_dung.Content = new ctrl_supersu(id, noi_dung);
                        break;
                    case "Tra cứu phân quyền cho nhóm người dùng":
                        noi_dung.Content = new ctrl_supersu(id, noi_dung);
                        break;
                    case "Phân quyền cho người dùng":
                        noi_dung.Content = new ctrl_supersu(id, noi_dung);
                        break;
                    case "Tra cứu phân quyền cho người dùng":
                        noi_dung.Content = new ctrl_supersu(id, noi_dung);
                        break;
                    case "Quản lý Menu":
                        btn_nguoi_dung = true;
                        menu_nguoi_dung_trang.Visibility = Visibility.Visible;
                        break;
                    case "Quản lý lịch sử truy cập người dùng":
                        noi_dung.Content =new ctrl_lich_su_tac_dong_he_thong(id);
                        break;
                    case "Tra cứu lịch sử truy cập người dùng":
                        noi_dung.Content = new ctrl_lich_su_tac_dong_he_thong(id);
                        break;
                    case "Quản lý lịch sử tác động hệ thống":
                        noi_dung.Content = new ctrl_lich_su_tac_dong_he_thong(id);
                        break;
                    case "Tra cứu lịch sử tác động hệ thống":
                        noi_dung.Content = new ctrl_lich_su_tac_dong_he_thong(id);
                        break;
                    case "Báo cáo - thống kê người dùng":
                        noi_dung.Content = new ctrl_baocao();
                        break;
                    case "Báo cáo - thống kê lịch sử truy cập người dùng":
                        noi_dung.Content = new ctrl_baocao();
                        break;
                    case "Báo cáo - thống kê lịch sử tác động hệ thống":
                        noi_dung.Content = new ctrl_baocao();
                        break;
                    case "Báo cáo - thống kê tổng hợp":
                        noi_dung.Content = new ctrl_baocao();
                        break;
                    case "Đăng nhập hệ thống":
                        win_dang_nhap mywin = new win_dang_nhap();
                        mywin.Show();
                        this.Close();
                        break;
                    case "Quên mật khẩu":
                        win_dang_nhap mywin1 = new win_dang_nhap();
                        mywin1.Show();
                        this.Close();
                        break;
                    case "Quản lý thông tin tài khoản":
                        noi_dung.Content = new ctrl_thong_tin_user(id);
                        break;
                    case "Đổi mật khẩu":
                        win_dang_nhap mywin2 = new win_dang_nhap();
                        mywin2.Show();
                        this.Close();
                        break;
                    case "Đăng xuất khỏi hệ thống":
                        win_dang_nhap mywin3 = new win_dang_nhap();

                        this.Close();
                        mywin3.Show();
                        break;
                    default:
                        Console.WriteLine("Không có mục này trong danh sách.");
                        break;
                }
            }

            doi_anh("btn_seach_png", "png/seach_3.png");
            doi_anh("btn_seach_dung_png", "png/seach_3.png");

        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = SearchBox.Text.ToLower();

            // Nếu không có từ khóa, ẩn danh sách gợi ý
            if (string.IsNullOrWhiteSpace(input))
            {
                SuggestionList.Visibility = Visibility.Collapsed;
                SuggestionList.ItemsSource = null;
                return;
            }

            // Loại bỏ dấu tiếng Việt trong input
            string inputWithoutTones = RemoveVietnameseTone(input);

            // Tìm kiếm gợi ý trong danh sách các chuỗi
            var suggestions = items
                .Where(item => RemoveVietnameseTone(item.ToLower()).Contains(inputWithoutTones))  // So sánh chuỗi không phân biệt dấu
                .ToList();

            // Nếu có kết quả tìm kiếm
            if (suggestions.Any())
            {
                SuggestionList.ItemsSource = suggestions;
                SuggestionList.Visibility = Visibility.Visible;
            }
            else
            {
                SuggestionList.ItemsSource = null;
                SuggestionList.Visibility = Visibility.Collapsed;
            }
        }

        // Hàm loại bỏ dấu tiếng Việt và các dấu khác
        private string RemoveVietnameseTone(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            // Chuyển đổi thành dạng chuẩn (dấu được phân tách khỏi các ký tự)
            input = input.Normalize(NormalizationForm.FormD);

            // Loại bỏ các ký tự dấu
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in input)
            {
                // Kiểm tra nếu ký tự là một ký tự có dấu
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            // Chuyển đổi lại thành dạng chuẩn không dấu
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        private void SuggestionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SuggestionList.SelectedItem is string selected)
            {
                // Đưa từ gợi ý vào TextBox
                SearchBox.Text = selected;

                // Ẩn danh sách gợi ý
                SuggestionList.Visibility = Visibility.Collapsed;

                // Đưa con trỏ về cuối TextBox
                SearchBox.CaretIndex = SearchBox.Text.Length;
            }
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Xử lý nếu danh sách gợi ý có ít nhất một mục
                if (SuggestionList.Items.Count > 0)
                {
                    SuggestionList.SelectedIndex = 0; // Chọn mục đầu tiên
                    var firstItem = SuggestionList.SelectedItem?.ToString();

                    if (firstItem != null)
                    {
                        SearchBox.Text = firstItem; // Đưa vào TextBox
                        SuggestionList.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    MessageBox.Show($"No results found for: {SearchBox.Text}", "Search", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị kết quả tìm kiếm
            string keyword = SearchBox.Text;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show($"Searching for: {keyword}", "Search", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please enter a search term.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
