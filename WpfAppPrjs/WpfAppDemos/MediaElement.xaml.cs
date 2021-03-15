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

namespace WpfAppDemos
{
    /// <summary>
    /// Interaction logic for MediaElement.xaml
    /// </summary>
    public partial class MediaElement : Window
    {
        public MediaElement()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                var fileName = openFileDlg.FileName;
                txtFileName.Text = fileName;
                media1.Source = new Uri(fileName);
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            media1.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            media1.Pause();
        }

        private void btnResume_Click(object sender, RoutedEventArgs e)
        {
            media1.Play();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            media1.Stop();
        }
    }
}
