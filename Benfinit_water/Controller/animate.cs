using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using Benfinit_water.View;
namespace Benfinit_water.Controller
{
    public class animate
    {
        public void enter035(string den, string trang, UserControl thiss)
        {

            Border button1 = thiss.FindName(den) as Border;
            Border button1_trang = thiss.FindName(trang) as Border;
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
            button1.BeginAnimation(Border.BorderThicknessProperty, thicknessAnimation);

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

        public void leave035(string den, string trang, UserControl thiss)
        {
            Border button1 = thiss.FindName(den) as Border;
            Border button1_trang = thiss.FindName(trang) as Border;

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
            button1.BeginAnimation(Border.BorderThicknessProperty, thicknessAnimation);

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
        public void enter(string den, string trang, UserControl thiss)
        {

            Border button1 = thiss.FindName(den) as Border;
            Border button1_trang = thiss.FindName(trang) as Border;
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
            button1.BeginAnimation(Border.BorderThicknessProperty, thicknessAnimation);

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

        public void leave(string den, string trang, UserControl thiss)
        {
            Border button1 = thiss.FindName(den) as Border;
            Border button1_trang = thiss.FindName(trang) as Border;

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
            button1.BeginAnimation(Border.BorderThicknessProperty, thicknessAnimation);

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


        private void doi_anh(string anh_cu, string anh_moi, UserControl thiss)
        {
            // Lấy đối tượng Image từ giao diện WPF (giả sử bạn đã khai báo Image có tên là "imageControl" trong XAML)
            Image imageControl = thiss.FindName(anh_cu) as Image;

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

        private void ApplyAnimation(
    UIElement targetElement,
    string animationType,
    double fromValue,
    double toValue,
    TimeSpan duration,
    int repeatCount = 1)
        {
            if (animationType == "Rotate")
            {
                // Tạo animation xoay (Rotate)
                DoubleAnimation rotateAnimation = new DoubleAnimation
                {
                    From = fromValue,
                    To = toValue,
                    Duration = new Duration(duration),
                    RepeatBehavior = new RepeatBehavior(repeatCount)
                };

                // Áp dụng animation cho thuộc tính Angle (Rotate)
                targetElement.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
            }
            else if (animationType == "Width")
            {
                // Tạo animation thay đổi chiều rộng (Width)
                DoubleAnimation widthAnimation = new DoubleAnimation
                {
                    From = fromValue,
                    To = toValue,
                    Duration = new Duration(duration),
                    RepeatBehavior = new RepeatBehavior(repeatCount)
                };

                // Áp dụng animation cho thuộc tính WidthProperty của FrameworkElement
                if (targetElement is FrameworkElement frameworkElement)
                {
                    frameworkElement.BeginAnimation(FrameworkElement.WidthProperty, widthAnimation);
                }
                else
                {
                    throw new InvalidOperationException("The target element is not a FrameworkElement.");
                }
            }
            else if (animationType == "Opacity")
            {
                // Tạo animation thay đổi độ mờ (Opacity)
                DoubleAnimation opacityAnimation = new DoubleAnimation
                {
                    From = fromValue,
                    To = toValue,
                    Duration = new Duration(duration),
                    RepeatBehavior = new RepeatBehavior(repeatCount)
                };

                // Áp dụng animation cho thuộc tính Opacity
                targetElement.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
            }
        }

        //private void RotateButton_Click()
        //{
        //    // Gọi hàm ApplyAnimation để thực hiện các hoạt ảnh
        //    ApplyAnimation(RectangleRotateTransform1, "Rotate", 0, 45, TimeSpan.FromSeconds(0.2));
        //    ApplyAnimation(MyRectangle1, "Width", MyRectangle1.Width, 54.57, TimeSpan.FromSeconds(0.2));
        //    ApplyAnimation(RectangleRotateTransform3, "Rotate", 0, -45, TimeSpan.FromSeconds(0.2));
        //    ApplyAnimation(MyRectangle3, "Width", MyRectangle3.Width, 54.57, TimeSpan.FromSeconds(0.2));
        //    ApplyAnimation(MyRectangle2, "Opacity", 1, 0, TimeSpan.FromSeconds(0.2));
        //}



        private void ApplyReverseAnimations(
    UIElement targetElement1, double fromAngle1, double toAngle1,
    UIElement targetElement2, double fromOpacity2, double toOpacity2,
    UIElement targetElement3, double fromAngle3, double toAngle3,
    UIElement targetElement4, double fromWidth4, double toWidth4,
    TimeSpan duration)
        {
            // Tạo animation xoay ngược lại hình chữ nhật 1
            DoubleAnimation rotateAnimation1Reverse = new DoubleAnimation
            {
                From = fromAngle1,        // Góc bắt đầu
                To = toAngle1,            // Góc kết thúc
                Duration = new Duration(duration),
                RepeatBehavior = new RepeatBehavior(1)
            };
            targetElement1.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation1Reverse);

            // Tạo animation thay đổi độ mờ (Opacity) của hình chữ nhật 2
            DoubleAnimation opacityAnimation2Reverse = new DoubleAnimation
            {
                From = fromOpacity2,      // Độ mờ ban đầu
                To = toOpacity2,          // Độ mờ kết thúc
                Duration = new Duration(duration)
            };
            targetElement2.BeginAnimation(UIElement.OpacityProperty, opacityAnimation2Reverse);

            // Tạo animation xoay ngược lại hình chữ nhật 3
            DoubleAnimation rotateAnimation3Reverse = new DoubleAnimation
            {
                From = fromAngle3,        // Góc bắt đầu
                To = toAngle3,            // Góc kết thúc
                Duration = new Duration(duration),
                RepeatBehavior = new RepeatBehavior(1)
            };
            targetElement3.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation3Reverse);

            // Tạo animation thay đổi chiều rộng của hình chữ nhật 3
            DoubleAnimation widthAnimation3Reverse = new DoubleAnimation
            {
                From = fromWidth4,        // Chiều rộng ban đầu
                To = toWidth4,            // Chiều rộng kết thúc
                Duration = new Duration(duration),
                RepeatBehavior = new RepeatBehavior(1)
            };
            targetElement4.BeginAnimation(FrameworkElement.WidthProperty, widthAnimation3Reverse);
        }

        // Sử dụng hàm ApplyReverseAnimations trong sự kiện click
        //private void ReverseRotateButton_Click()
        //{
        //    ApplyReverseAnimations(
        //        RectangleRotateTransform1, 45, 0,           // Hình chữ nhật 1: xoay từ 45 về 0
        //        MyRectangle2, 0, 1,                         // Hình chữ nhật 2: độ mờ từ 0 về 1
        //        RectangleRotateTransform3, -45, 0,          // Hình chữ nhật 3: xoay từ -45 về 0
        //        MyRectangle1, MyRectangle1.Width, 40,      // Hình chữ nhật 1: chiều rộng từ ban đầu về 40
        //        TimeSpan.FromSeconds(0.2)                   // Thời gian hoạt ảnh
        //    );
        //}

    }
}
