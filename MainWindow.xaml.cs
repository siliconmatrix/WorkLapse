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
// ------
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Microsoft.Win32;
using System.Drawing;
using System.IO;

namespace WorkLapse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Properties.Settings uData;
        private string out_directory;
        private string out_filename;
        private bool have_output = false;
        private ScreenSelector screenSelect;

        public MainWindow()
        {
            // load user data
            //uData = Properties.Settings.Default;
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
            sfdBrowseOut.AddExtension = true;
            sfdBrowseOut.CheckFileExists = false;
            sfdBrowseOut.InitialDirectory = txtOutDir.Text;
            sfdBrowseOut.Title = @"Choose location and base name for output.";
            sfdBrowseOut.OverwritePrompt = true;
            sfdBrowseOut.DefaultExt = "jpg";
            sfdBrowseOut.Filter = "Image Sequence|.jpg";
            sfdBrowseOut.FileName = "frames";
            sfdBrowseOut.ShowDialog();
        }

        void sfdBrowseOut_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var sfd = (SaveFileDialog)sender;
            MessageBox.Show(sfd.FileName);
            have_output = true;
        }

        private void Main_OnLoad(object sender, RoutedEventArgs e)
        {
            // test
            screenSelect = new ScreenSelector();
            screenSelect.Show();
            screenSelect.Activate();
        }

        private void Main_OnClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (screenSelect != null) screenSelect.Close();
        }
    }
}
