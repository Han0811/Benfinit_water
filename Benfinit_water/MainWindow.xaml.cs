using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Benfinit_water.View;

namespace Benfinit_water
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn(object sender, RoutedEventArgs e)
        {
            myctrl.Content = new ctrl_quy_hoach();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            win_menu mywin =new win_menu(0);
            mywin.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            win_dang_nhap mywin = new win_dang_nhap();
            mywin.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            wintest mywin = new wintest();
            mywin.Show();
            this.Close();
        }
    }
}