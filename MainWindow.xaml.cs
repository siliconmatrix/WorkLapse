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
using System.IO;
using System.Drawing;
// ------
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Microsoft.Win32;

namespace WorkLapse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string OutDir;

        public MainWindow()
        {
            // initial memory and some I/O prep
            string base_out = String.Format(@"C:\Users\{0}\Videos\WorkLapse",Environment.UserName);
            DirectoryInfo di = new DirectoryInfo(base_out);
            if(!di.Exists) Directory.CreateDirectory(base_out);
            // initialize the GUI (not sure what happens under the covers in WPF)
            InitializeComponent();
            // pre GUI
            txtOutDir.Text = base_out;
        }

        private void btnBrowsOut_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfdBrowseOut = new SaveFileDialog();
            sfdBrowseOut.FileOk += sfdBrowseOut_FileOk;
            sfdBrowseOut.AddExtension = false;
            sfdBrowseOut.CheckFileExists = false;
            sfdBrowseOut.InitialDirectory = txtOutDir.Text;
            sfdBrowseOut.Title = @"Choose location and base name for output.";
            sfdBrowseOut.OverwritePrompt = true;
            sfdBrowseOut.DefaultExt = "png";
            sfdBrowseOut.Filter = "Image Sequence|.png";
            sfdBrowseOut.FileName = "frames";
            sfdBrowseOut.ShowDialog();
        }

        void sfdBrowseOut_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var sfd = (SaveFileDialog)sender;
            MessageBox.Show(sfd.FileName);
        }
    }
}
