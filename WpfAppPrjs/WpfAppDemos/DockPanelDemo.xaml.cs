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
using HRMSBusinessLib;
using HRMSEntitiesLib;

namespace WpfAppDemos
{
    /// <summary>
    /// Interaction logic for DockPanelDemo.xaml
    /// </summary>
    public partial class DockPanelDemo : Window
    {
        public DockPanelDemo()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BusinessLayer bll = new BusinessLayer();
                Employee emp = new Employee
                {
                    Ecode = int.Parse(txtEcode.Text),
                    Ename = txtEname.Text,
                    Salary = int.Parse(txtSalary.Text),
                    Deptid = int.Parse(txtDeptid.Text)
                };
                bll.AddEmployee(emp);
                MessageBox.Show("Record Inserted");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Record Inserted");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Record Inserted");
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Record Inserted");
        }
    }
}
