using HRMSEntitiesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HRMSDataAccessLib
{
    public class AdoDisconnected : IDataAccess
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        public AdoDisconnected()
        {
            //create and configure the connection object
            con = new SqlConnection();
            //con.ConnectionString = @"Data Source=DESKTOP-SDB1BH2\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True";
            
            //another way to add ConnectionString(xml file configuration)
            string conStr = ConfigurationManager.ConnectionStrings["sqlconstr"].ConnectionString;
            con.ConnectionString = conStr;

            //configure DataAdapter
            da = new SqlDataAdapter("select ecode,ename,salary,deptid from tbl_employee",con);
            //create dataset and fill the result using DataAdapter
            ds = new DataSet();
            da.Fill(ds, "tbl_employee");

            //add constraints inside dataset table also by C#
            ds.Tables[0].Constraints.Add("pk1", ds.Tables[0].Columns[0], true);//where ever we call find() we need pk
            //in disconnected mode... we can use stored procedure only for 
        }
        public void DeleteEmployee(int ecode)
        {
            //1.Find the row to be deleted in the dataset table's rows
            DataRow row = ds.Tables[0].Rows.Find(ecode);
            //2.Delete the row found
            if (row != null)
            {
                row.Delete();
                //save to database using DataAdapter
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "tbl_employee");
            }
            else
            {
                throw new Exception("Ecode does not exist");
            }
        }
        public void InsertEmployee(Employee emp)
        {
            /*Create an empty datarow as per the datatable structure of dataset*/
            DataRow row = ds.Tables[0].NewRow();
            //2.Supply values to the columns if the newly created datarow
            row[0] = emp.Ecode;
            row[1] = emp.Ename;
            row[2] = emp.Salary;
            row[3] = emp.Deptid;
            //3.Add the newly created row to the Rows of the dataset table
            ds.Tables[0].Rows.Add(row);
            //4.save the changes from DataSet to Database using DataAdapter
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(ds, "tbl_employee");
        }
        public List<Employee> SelectAllEmps()
        {
            List<Employee> lstEmps = new List<Employee>();
            //TODO Travers each record of the Dataset table and add them to the collection
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Employee emp = new Employee
                {
                    Ecode = (int)row[0],
                    Ename = row[1].ToString(),
                    Salary = (int)row[2],
                    Deptid = (int)row[3]
                };
                //Add all the current row to the collection
                lstEmps.Add(emp);
            }
            return lstEmps;
        }
        public Employee SelectEmpById(int ecode)
        {
            //find the row :- find is only for the primary key.. constraints needed
            //but Select is for selecting the rows for all purposes.. no constraints needed
            /*
            DataRow[] rows = ds.Tables[0].Select("ecode=" + ecode);
            foreach (DataRow dr in rows)
            {
                Employee emp = new Employee
                {
                    Ecode = (int)dr[0],
                    Ename = dr[1].ToString(),
                    Salary = (int)dr[2],
                    Deptid = (int)dr[3]
                };
                return emp;
            }*/

            //find the row using primary key value
            DataRow row = ds.Tables[0].Rows.Find(ecode);
            if (row != null)
            {
                Employee emp = new Employee()
                {
                    Ecode = (int)row[0],
                    Ename = row[1].ToString(),
                    Salary = (int)row[2],
                    Deptid = (int)row[3]
                };
                return emp;
            }
            else
            {
                throw new Exception("Ecode does not exist... Details can't be displayed");
            }
        }
        public void UpdateEmpById(Employee emp)
        {
            //1.Find the row to be deleted in the dataset table's rows
            DataRow row = ds.Tables[0].Rows.Find(emp.Ecode);
            //2.Update the row found
            if (row != null)
            {
                row[1] = emp.Ename;
                row[2] = emp.Salary;
                row[3] = emp.Deptid;
                //save to database using DataAdapter
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "tbl_employee");
            }
            else
            {
                throw new Exception("Ecode does not exist, could not perform updation");
            }
        }
    }
}
