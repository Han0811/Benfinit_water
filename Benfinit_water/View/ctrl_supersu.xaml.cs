using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Globalization;

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for ctrl_supersu.xaml
    /// </summary>
    public partial class ctrl_supersu : UserControl
    {
        public static List<usermodel> users = _userprovider.GetUsers();
        public usermodel myuser;
        public ContentControl noi_dung;
        public int id;
        public ctrl_supersu(int _id,ContentControl _noi_dung)
        {
            InitializeComponent();
            id = _id;
            noi_dung = _noi_dung;
            users = _userprovider.GetUsers();
            myuser = _thong_tin_user.GetUserById(id, users);
            listBoxCoSo.ItemsSource = users;

        }
        private void ListBoxCoSo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Lấy mục đã chọn từ ListBox
            var selectedItem = listBoxCoSo.SelectedItem as usermodel;

            // Kiểm tra nếu có mục nào được chọn
            if (selectedItem != null)
            {
                
                win_CapNhatSuperSU mywin = new win_CapNhatSuperSU(id, selectedItem.Id,noi_dung); // Pass user ID
                mywin.Show();
                listBoxCoSo.ItemsSource = users;
                users = _userprovider.GetUsers();
                myuser = _thong_tin_user.GetUserById(id, users);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            win_phan_quyen_theo_nhom mywin= new win_phan_quyen_theo_nhom(id,noi_dung);
            mywin.Show();
        }
        public List<string> items = _userprovider.GetNamesFromuserModels(users);


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
                List<usermodel> temp = _userprovider.SearchByNameuser(users, SearchBox.Text);
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
                        List<usermodel> temp = _userprovider.SearchByNameuser(users, SearchBox.Text);
                        listBoxCoSo.ItemsSource = temp;
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
        private void active_Click(object sender, RoutedEventArgs e)
        {
            List<usermodel> temp =  _userprovider.SearchByTrangThaiuser(users, true);
            listBoxCoSo.ItemsSource = temp;
        }

        private void nonactive_Click(object sender, RoutedEventArgs e)
        {
            List<usermodel> temp = _userprovider.SearchByTrangThaiuser(users, false);
            listBoxCoSo.ItemsSource = temp;
        }
        private void yes_Click(object sender, RoutedEventArgs e)
        {
            List<usermodel> temp = _userprovider.SearchByIsAdminuser(users, true);
            listBoxCoSo.ItemsSource = temp;
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            List<usermodel> temp = _userprovider.SearchByIsAdminuser(users, false);
            listBoxCoSo.ItemsSource = temp;
        }
    }
}
