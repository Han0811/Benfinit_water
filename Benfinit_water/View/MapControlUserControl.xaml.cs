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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Maps.MapControl.WPF;

namespace Benfinit_water.View
{
    /// <summary>
    /// Interaction logic for MapControlUserControl.xaml
    /// </summary>
    public partial class MapControlUserControl : UserControl
    {
        public MapControlUserControl()
        {
            InitializeComponent();
            myMap.Center = new Location(20.4073, 106.1595); // Tọa độ Nam Định
            myMap.ZoomLevel = 12;
        }
    }
}
