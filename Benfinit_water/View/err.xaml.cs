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

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for err.xaml
    /// </summary>
    public partial class err : Window
    {
        public err(string errorMessage)
        {
            InitializeComponent();
            ErrorTextBox.Text = errorMessage; // Hiển thị nội dung lỗi
        }

        private void CopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(ErrorTextBox.Text); // Sao chép nội dung vào Clipboard
            MessageBox.Show("Error message copied to clipboard!", "Copied", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}