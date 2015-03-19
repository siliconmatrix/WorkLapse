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
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Microsoft.Win32;
using System.Drawing;

namespace WorkLapse
{
    /// <summary>
    /// Interaction logic for ScreenSelector.xaml
    /// </summary>
    public partial class ScreenSelector : Window
    {

        public System.Windows.Point MinCorner { get; set; }
        public System.Windows.Point MaxCorner { get; set; }

        public ScreenSelector()
        {
            InitializeComponent();
            // bind closing
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close,
                            new ExecutedRoutedEventHandler(delegate(object sender, ExecutedRoutedEventArgs args) { this.Close(); })));
        }

        bool is_held = false;
        System.Windows.Point mouse_down_pt;

        private void RecalcRegion()
        {
            MinCorner = new System.Windows.Point(this.Left, this.Top);
            MaxCorner = new System.Windows.Point(this.Left + this.Width, this.Top + this.Height);
        }

        private void DisplayRegion()
        {
            txtTitle.Text = String.Format("Region Selector <{0}> to <{1}>", MinCorner, MaxCorner);
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            RecalcRegion();
            DisplayRegion();
            ResizeMode = ResizeMode.CanResizeWithGrip;
        }

        public void DragWindow(object sender, MouseButtonEventArgs args)
        {
            DragMove();
        }

        private void OnLocationChanged(object sender, EventArgs e)
        {
            RecalcRegion();
            DisplayRegion();
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            RecalcRegion();
            DisplayRegion();
        }

        private void OnActivated(object sender, EventArgs e)
        {
            ResizeMode = ResizeMode.CanResizeWithGrip;
        }

        private void btnMax_OnClick(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                btnMax.Content = "-";
            }
            else
            {
                WindowState = WindowState.Normal;
                btnMax.Content = "[O]";
            }
        }

        private void img_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            Bitmap res = new Bitmap((int)SystemParameters.PrimaryScreenWidth, (int)SystemParameters.PrimaryScreenHeight);
            Graphics g = Graphics.FromImage(res);
            
        }

    }
}
