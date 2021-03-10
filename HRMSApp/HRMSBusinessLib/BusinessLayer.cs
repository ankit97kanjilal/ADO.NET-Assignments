﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMSEntitiesLib;//for Entities
using HRMSDataAccessLib;//for DAL

namespace HRMSBusinessLib
{
    public class BusinessLayer
    {
        public List<Employee> GetAllEmps()
        {
            List<Employee> lstEmps = new List<Employee>();

            //get the records from Data Access Layer
            AdoConnected dal = new AdoConnected();
            lstEmps = dal.SelectAllEmps();

            return lstEmps;
        }
        public void AddEmployee(Employee emp)
        {
            AdoConnected dal = new AdoConnected();
            dal.InsertEmployee(emp);
        }
        public void DeleteEmployee(int ecode)
        {
            AdoConnected dal = new AdoConnected();
            dal.DeleteEmployee(ecode);
        }
        public void UpdateEmployee(Employee emp)
        {
            //update using dal layer
            AdoConnected dal = new AdoConnected();
            dal.UpdateEmpById(emp);
        }
        public Employee SelectEmpById(int ecode)
        {
            AdoConnected dal = new AdoConnected();
            Employee emp = dal.SelectEmpById(ecode);
            return emp;
        }
        public void UpdateSalaryUsingSP(int ecode,int salary)
        {
            //update using dal layer
            AdoConnected dal = new AdoConnected();
            dal.UpdateSalUsingSP(ecode, salary);
        }

        public int GetEmpSalUsingSP(int ecode)
        {
            int salary = 0;
            AdoConnected dal = new AdoConnected();
            salary = dal.GetEmpSalUsingSP(ecode);
            return salary;
        }
    }
}
