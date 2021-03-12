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
using HRMSEntitiesLib;
using HRMSBusinessLib;

namespace WpfAppDemos
{
    /// <summary>
    /// Interaction logic for DataTemplateDemo.xaml
    /// </summary>
    public partial class DataTemplateDemo : Window
    {
        public DataTemplateDemo()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BusinessLayer bll = new BusinessLayer();
            var lstEmps = bll.GetAllEmps();

            //bind the source to listView control
            lvEmps.ItemsSource = lstEmps;
        }
    }
}
