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
    /// Interaction logic for win_dang_nhap.xaml
    /// </summary>
    
    public partial class win_dang_nhap : Window
    {
        
        public win_dang_nhap()
        {
            InitializeComponent();
            var myControl = new ctrl_dang_nhap();
            myControl.UserControlContainer = UserControlContainer;
            myControl.newscreen = this;
            UserControlContainer.Content = myControl;
        }
    }
}
