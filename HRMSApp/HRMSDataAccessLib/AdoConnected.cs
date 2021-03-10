using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMSEntitiesLib;  //for Entities Layer
using System.Data.SqlClient; //Sql Server Provider
using System.Data;

namespace HRMSDataAccessLib
{
    public class AdoConnected : IDataAccess   //don't give this name in real time project
    {
        SqlConnection con;
        SqlCommand cmd;
        public AdoConnected()
        {
            //create and configure the connection object
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-SDB1BH2\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True";

        }
        public void DeleteEmployee(int ecode)
        {
            //TODO DELETE using AD0.NET
            //configure SqlCommand for DELETE
            cmd = new SqlCommand();
            cmd.CommandText = "delete from tbl_employee where ecode=@ec";
            cmd.CommandType = CommandType.Text;

            //Supply parameters values
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ec", ecode);

            //attach the connection
            cmd.Connection = con;

            //open connection
            con.Open();

            try
            {
                //Execute the command
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new Exception("Ecode does not exist, could not perform delete");
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                //close the connection
                con.Close();
            }
        }
        public void InsertEmployee(Employee emp)
        {
            //TODO INSERT using AD0.NET
            //configure sqlcommand for INSERT
            cmd = new SqlCommand();
            cmd.CommandText = "insert into tbl_employee values(@ec,@en,@sal,@did)";//value of parameters supplied from emp
            cmd.CommandType = CommandType.Text;

            //supply parameters values
            cmd.Parameters.Clear(); //always clear that
            cmd.Parameters.AddWithValue("@ec", emp.Ecode);
            cmd.Parameters.AddWithValue("@en", emp.Ename);
            cmd.Parameters.AddWithValue("@sal", emp.Salary);
            cmd.Parameters.AddWithValue("@did", emp.Deptid);

            //attaching the connection
            cmd.Connection = con;

            //open connection
            con.Open();

            //execute the command
            int recordsAffected = cmd.ExecuteNonQuery();
            if(recordsAffected == 0)
            {
                throw new Exception("Could not insert record");
            }

            //close connection
            con.Close();
        }
        public List<Employee> SelectAllEmps()
        {
            List<Employee> lstEmps = new List<Employee>();

            //configure SQL command for select all
            cmd = new SqlCommand();
            cmd.CommandText = "select ecode,ename,salary,deptid from tbl_employee";
            cmd.CommandType = CommandType.Text;

            //attach connection with the command
            cmd.Connection = con;

            //open the connection
            con.Open();
            
            //execute the command
            SqlDataReader sdr = cmd.ExecuteReader();
            
            //traverse the records of the DataReader one-by-one
            while(sdr.Read())
            {
                Employee emp = new Employee
                {
                    Ecode = (int)sdr[0],
                    Ename = sdr[1].ToString(),
                    Salary = (int)sdr[2],
                    Deptid = (int)sdr[3]
                };
                //add the employee record to the collection
                lstEmps.Add(emp);
            }
            sdr.Close();
            con.Close();
            return lstEmps;
        }
        public Employee SelectEmpById(int ecode)
        {
            Employee emp;
            try
            {
                //TODO SELECT by Emp ID using AD0.NET
                //configure sqlcommand for Select
                cmd = new SqlCommand();
                cmd.CommandText = "select ecode,ename,salary,deptid from tbl_employee where ecode=@ec";
                //value of parameters supplied from emp
                cmd.CommandType = CommandType.Text;

                //supply parameter
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", ecode);

                cmd.Connection = con;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    emp = new Employee
                    {
                        Ecode = (int)sdr[0],
                        Ename = sdr[1].ToString(),
                        Salary = (int)sdr[2],
                        Deptid = (int)sdr[3]
                    };
                    sdr.Close();
                }
                else
                {
                    throw new Exception("ecode does not exist.......");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return emp;
        }
        public void UpdateEmpById(Employee emp)
        {
            //TODO UPDATE using AD0.NET
            //configure sqlcommand for UPDATE
            cmd = new SqlCommand();
            cmd.CommandText = "update tbl_employee set salary=@sal,ename=@en,deptid=@did where ecode=@ec";
            //value of parameters supplied from emp
            cmd.CommandType = CommandType.Text;

            //supply parameters values
            cmd.Parameters.Clear(); //always clear that
            cmd.Parameters.AddWithValue("@ec", emp.Ecode);
            cmd.Parameters.AddWithValue("@en", emp.Ename);              //this way is more secure
            cmd.Parameters.AddWithValue("@sal", emp.Salary);
            cmd.Parameters.AddWithValue("@did", emp.Deptid);

            //attaching the connection
            cmd.Connection = con;

            //open connection
            con.Open();

            //execute the command
            try
            {
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new Exception("Ecode does not exist, Could not perform the update");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close connection
                con.Close();
            }
        }
        public void UpdateSalUsingSP(int ecode,int salary)
        {
            try
            {
                //configure Sql Command for calling Stored Procedure
                cmd = new SqlCommand();
                cmd.CommandText = "sp_UpdateEmpSal";
                cmd.CommandType = CommandType.StoredProcedure;

                //supply parameters for the SP
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", ecode);
                cmd.Parameters.AddWithValue("@sal", salary);

                //attach connection
                cmd.Connection = con;

                //Open connection
                con.Open();

                //execute the command(SP)
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close the connection
                con.Close();
            }            
        }
        public int GetEmpSalUsingSP(int ecode)
        {
            int salary = 0;
            try
            {
                //configure the sql command for stored procedure
                cmd = new SqlCommand();
                cmd.CommandText = "sp_getempsal";
                cmd.CommandType = CommandType.StoredProcedure;

                //supply parameters
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", ecode);
                cmd.Parameters.AddWithValue("@sal", salary);

                //specifying the parameter direction
                cmd.Parameters[1].Direction = ParameterDirection.Output;

                //attaching
                cmd.Connection = con;

                //open the connection
                con.Open();

                //execute the command(SP)
                cmd.ExecuteNonQuery();

                //access the parameter value from SP
                salary = (int)cmd.Parameters[1].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close
                con.Close();
            }
            return salary;
        }
    }
}
