using HRMSEntitiesLib; //for entities
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
            //create and configure the connection obejct
            con = new SqlConnection();
            string conStr = ConfigurationManager.ConnectionStrings["sqlconstr"].ConnectionString;
            con.ConnectionString = conStr;
            //con.ConnectionString = @"Data Source=DESKTOP-SDB1BH2\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True";

            //configure DataAdapter
            da = new SqlDataAdapter("select ecode,ename,salary,deptid from tbl_employee", con);
            //create dataset and fill the result using DataAdapter
            ds = new DataSet();
            da.Fill(ds, "tbl_employee");
            //add constraints
            ds.Tables[0].Constraints.Add("pk1", ds.Tables[0].Columns[0], true);
        }

        public void DeleteEmpById(int ecode)
        {
            //find the row in the DataSet Table's rows 
            DataRow row = ds.Tables[0].Rows.Find(ecode);
            //delete the row found
            if (row != null)
            {
                row.Delete();
                //save to database using DataAdapter
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "tbl_employee");
            }
            else
            {
                throw new Exception("Ecode does not exist, could not perform deletion");
            }
        }

        public void InsertEmployee(Employee emp)
        {
            //1. Create a new row from the DataSet Table
            DataRow row = ds.Tables[0].NewRow();
            //2. supply values to the newly created row
            row[0] = emp.Ecode;
            row[1] = emp.Ename;
            row[2] = emp.Salary;
            row[3] = emp.Deptid;
            //attach the newly created DataRow to the DataSet table's rows 
            ds.Tables[0].Rows.Add(row);
            //save the changes from DataSet to Database using DataAdapter
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(ds, "tbl_employee");
        }

        public List<Employee> SelectAllEmps()
        {
            List<Employee> lstEmps = new List<Employee>();
            //TODO Traverse each record of the DataSet Table and add them to the collection
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Employee emp = new Employee
                {
                    Ecode = (int)row[0],
                    Ename = row[1].ToString(),
                    Salary = (int)row[2],
                    Deptid = (int)row[3]
                };

                //add the current row to the collection
                lstEmps.Add(emp);
            }
            return lstEmps;
        }

        public Employee SelectEmpById(int ecode)
        {
            //find the row : select * from tbl_employee where ecode=" + ecode
            //DataRow[] rows = ds.Tables[0].Select("ecode=" + ecode);
            //foreach (DataRow dr in rows)
            //{
            //    Employee emp = new Employee
            //    {
            //        Ecode = (int)dr[0],
            //        Ename = dr[1].ToString(),
            //        Salary = (int)dr[2],
            //        Deptid = (int)dr[3]
            //    };
            //    return emp;
            //}


            //find the row using primary key value
            DataRow row = ds.Tables[0].Rows.Find(ecode);
            if (row != null)
            {
                Employee emp = new Employee
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
                throw new Exception("Ecode does not exist");
            }
        }

        public void UpdateEmpById(Employee emp)
        {
            //find the row in the DataSet Table's rows 
            DataRow row = ds.Tables[0].Rows.Find(emp.Ecode);
            //update the row found
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
