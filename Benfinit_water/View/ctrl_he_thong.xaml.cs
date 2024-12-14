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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for ctrl_he_thong.xaml
    /// </summary>
    public partial class ctrl_he_thong : UserControl
    {
        ContentControl noi_dung;
        public ctrl_he_thong(ContentControl _noi_dung)
        {
            InitializeComponent();
            noi_dung = _noi_dung;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
