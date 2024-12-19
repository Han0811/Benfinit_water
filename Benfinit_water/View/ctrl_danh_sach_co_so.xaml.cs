using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using Benfinit_water.View;
namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for ctrl_danh_sach_co_so.xaml
    /// </summary>
    public partial class ctrl_danh_sach_co_so : UserControl
    {
        public static List<_CoSoModel> newCoSo = _CoSoProvider.getCoSo();
        public int id;
        private List<usermodel> users = _userprovider.GetUsers();
        private usermodel myuser;
        public ContentControl noi_dung;
        public ctrl_danh_sach_co_so(int _id,ContentControl _noi_dung)
        { 
            InitializeComponent();
            noi_dung = _noi_dung;
            id = _id;
            myuser = _thong_tin_user.GetUserById(id, users);
            listBoxCoSo.ItemsSource = newCoSo;
        }
       
        private void ListBoxCoSo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Lấy mục đã chọn từ ListBox
            var selectedItem = listBoxCoSo.SelectedItem as _CoSoModel;

            // Kiểm tra nếu có mục nào được chọn
            if (selectedItem != null)
            {
                win_CapNhatCoSo mywin = new win_CapNhatCoSo(selectedItem.id,id,noi_dung);
                mywin.Show();
                newCoSo = _CoSoProvider.getCoSo();
                listBoxCoSo.ItemsSource = newCoSo;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!myuser.IsAdmin)
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa");
                return;
            }
            win_themCoSo mywin = new win_themCoSo(id,noi_dung);
            mywin.Show();
            newCoSo = _CoSoProvider.getCoSo();
            listBoxCoSo.ItemsSource = newCoSo;
        }

        public List<string> items = _CoSoProvider.GetNamesFromCoSoModels(newCoSo);


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
            if (SuggestionList.Items.Count > 0)
            {
                List<_CoSoModel> temp = _CoSoProvider.SearchByNameCoSo(newCoSo, SearchBox.Text);
                listBoxCoSo.ItemsSource = temp;
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

            // Tìm kiếm gợi ý trong danh sách các chuỗi
            var suggestions = items
                .Where(item => item.ToLower().Contains(input))  // So sánh chuỗi không phân biệt hoa thường
                .ToList();

            if (suggestions.Any())
            {
                SuggestionList.ItemsSource = suggestions;
                SuggestionList.Visibility = Visibility.Visible;
            }
            else
            {
                SuggestionList.Visibility = Visibility.Collapsed;
                SuggestionList.ItemsSource = null;
            }
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
                    List<_CoSoModel> temp = _CoSoProvider.SearchByNameCoSo(newCoSo, SearchBox.Text);
                    listBoxCoSo.ItemsSource = temp;
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
    }
  
}
