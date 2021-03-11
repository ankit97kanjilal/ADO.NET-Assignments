using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMSBusinessLib;//for Business Layer
using HRMSEntitiesLib;//for Entities Layer

namespace HRMSConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("1.Add Employee");
                Console.WriteLine("2.Delete Employee By Id");
                Console.WriteLine("3.Update Employee By Id");
                Console.WriteLine("4.Display All Employees");
                Console.WriteLine("5.Search Employee By Id");
                //Console.WriteLine("6.Update Salary by using SP");
                //Console.WriteLine("7.Get Salary by using SP by ecode");
                Console.WriteLine("0.Exit");
                Console.Write("Enter Choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        DeleteEmpById();
                        break;
                    case 3:
                        UpdateEmpById();
                        break;
                    case 4:
                        DisplayAllEmps();
                        break;
                    case 5:                        
                        SearchEmpById();
                        break;
                    //case 6:
                    //    UpdateSalaryUsingSP();
                    //    break;
                    //case 7:
                    //    GetEmpSalByUsingSP();
                    //    break;
                    case 0:
                        Console.WriteLine("Exiting......");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (choice != 0);
        }
        static void DeleteEmpById()
        {
            try
            {
                BusinessLayer bll = new BusinessLayer();
                Console.Write("Enter the ecode to delete the employee detail : ");
                int ecode = int.Parse(Console.ReadLine());
                bll.DeleteEmployee(ecode);
                Console.WriteLine("Record deleted successfully....");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void UpdateEmpById()
        {
            Employee emp = new Employee();
            Console.Write("Enter the ecode for update : ");
            emp.Ecode = int.Parse(Console.ReadLine());
            Console.Write("Enter the ename for update : ");
            emp.Ename = Console.ReadLine();
            Console.Write("Enter the salary for update : ");
            emp.Salary = int.Parse(Console.ReadLine());
            Console.Write("Enter the deptid for update : ");
            emp.Deptid = int.Parse(Console.ReadLine());

            BusinessLayer bll = new BusinessLayer();
            bll.UpdateEmployee(emp);
            Console.WriteLine("Updated record successfully");
        }
        static void SearchEmpById()
        {
            try
            {
                int ecode;
                Employee emp = null;
                Console.Write("Enter ecode for search : ");
                ecode = int.Parse(Console.ReadLine());
                //search emp using business layer
                BusinessLayer bll = new BusinessLayer();
                emp = bll.SelectEmpById(ecode);
                Console.WriteLine(emp.Ecode+"\t"+emp.Ename+"\t"+emp.Salary+"\t"+emp.Deptid);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void AddEmployee()
        {
            Employee emp = new Employee();
            Console.Write("enter ecode: ");
            emp.Ecode = int.Parse(Console.ReadLine());
            Console.Write("enter ename: ");
            emp.Ename = Console.ReadLine();
            Console.Write("enter salary: ");
            emp.Salary = int.Parse(Console.ReadLine());
            Console.Write("enter deptid: ");
            emp.Deptid = int.Parse(Console.ReadLine());

            //insert using Business Layer
            BusinessLayer bll = new BusinessLayer();
            bll.AddEmployee(emp);
            Console.WriteLine("Record inserted successfully");
        }
        static void DisplayAllEmps()
        {
            BusinessLayer bll = new BusinessLayer();
            List<Employee> lstEmps = bll.GetAllEmps();
            foreach (Employee emp in lstEmps)
            {
                Console.WriteLine(emp.Ecode + "\t" + emp.Ename + "\t" + emp.Salary + "\t" + emp.Deptid);
            }
        }
        static void UpdateSalaryUsingSP()
        {
            try
            {
                Console.Write("Enter the ecode for update : ");
                int ecode = int.Parse(Console.ReadLine());
                Console.Write("Enter the salary for update : ");
                int salary = int.Parse(Console.ReadLine());
                BusinessLayer bll = new BusinessLayer();
                bll.UpdateSalaryUsingSP(ecode, salary);
                Console.WriteLine("Updated record successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void GetEmpSalByUsingSP()
        {
            try
            {
                int ecode, salary;
                Console.Write("Enter ecode to display salary : ");
                ecode = int.Parse(Console.ReadLine());

                //Get salary using Business layer
                BusinessLayer bll = new BusinessLayer();
                salary = bll.GetEmpSalUsingSP(ecode);
                Console.WriteLine("Salary is : " + salary);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
