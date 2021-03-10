using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRMSBusinessLib;// for Business Layer
using HRMSEntitiesLib;// for 

namespace HRMSWinFormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee
                {
                    Ecode = int.Parse(txtEcode.Text),
                    Ename = txtEname.Text,
                    Salary = int.Parse(txtSalary.Text),
                    Deptid = int.Parse(txtDeptid.Text)
                };
                BusinessLayer bll = new BusinessLayer();
                bll.AddEmployee(emp);
                MessageBox.Show("Record Inserted");

                //display records 
                List<Employee> lstEmps = bll.GetAllEmps();
                dgvEmps.DataSource = lstEmps;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = new Employee
                {
                    Ecode = int.Parse(txtEcode.Text),
                    Ename = txtEname.Text,
                    Salary = int.Parse(txtSalary.Text),
                    Deptid = int.Parse(txtDeptid.Text)
                };
                BusinessLayer bll = new BusinessLayer();
                bll.UpdateEmployee(emp);
                MessageBox.Show("Record Updated");

                //display records 
                List<Employee> lstEmps = bll.GetAllEmps();
                dgvEmps.DataSource = lstEmps;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int ecode = int.Parse(txtEcode.Text);
                BusinessLayer bll = new BusinessLayer();
                bll.DeleteEmployee(ecode);
                MessageBox.Show("Record Deleted");

                //display records 
                List<Employee> lstEmps = bll.GetAllEmps();
                dgvEmps.DataSource = lstEmps;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFindEmp_Click(object sender, EventArgs e)
        {
            try
            {
                int ecode = int.Parse(txtEcode.Text);
                BusinessLayer bll = new BusinessLayer();
                Employee emp = bll.SelectEmpById(ecode);
                MessageBox.Show("Record Details....... ");
                
                txtEname.Text = emp.Ename;
                txtSalary.Text = emp.Salary.ToString();
                txtDeptid.Text = emp.Deptid.ToString();

                //display records 
                List<Employee> lstEmps = bll.GetAllEmps();
                dgvEmps.DataSource = lstEmps;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BusinessLayer bll = new BusinessLayer();           
            //display records from beginning
            List<Employee> lstEmps = bll.GetAllEmps();
            dgvEmps.DataSource = lstEmps;
        }
    }
}
