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

namespace WorkLapse
{
    /// <summary>
    /// Interaction logic for ScreenSelector.xaml
    /// </summary>
    public partial class ScreenSelector : Window
    {
        public ScreenSelector()
        {
            InitializeComponent();
        }

        Point mouse_down_pt;
        private void Drag_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            mouse_down_pt = e.GetPosition(e.Device.Target);
        }

        private void Drag_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            Point mup = e.GetPosition(e.Device.Target);
            double dx = mup.X - mouse_down_pt.X;
            double dy = mup.Y - mouse_down_pt.Y;
        }


    }
}
