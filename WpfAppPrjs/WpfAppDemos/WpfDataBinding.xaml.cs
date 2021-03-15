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
    /// Interaction logic for WpfDataBinding.xaml
    /// </summary>
    public partial class WpfDataBinding : Window
    {
        public WpfDataBinding()
        {
            InitializeComponent();
        }

        private void btnSetBkColor_Click(object sender, RoutedEventArgs e)
        {
            //access the resource from the resource collection
            //var yellowBrush = (SolidColorBrush)Resources["yellowBrush"];

            //set the background color of the label
            //lblData.Background = yellowBrush;
            string msg = "Hello";
            Application.Current.Properties["msg"] = msg;//like 
            DockPanelDemo form = new DockPanelDemo();
            form.Show();
        }
    }
}
