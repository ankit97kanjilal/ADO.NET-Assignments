using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMSEntitiesLib; //for Entities Layer
using System.Data.SqlClient;    //Sql Server Provider

namespace HRMSDataAccessLib
{
    interface IDataAccess
    {
        List<Employee> SelectAllEmps();
        Employee SelectEmpById(int ecode);
        void InsertEmployee(Employee emp);
        void DeleteEmpById(int ecode);
        void UpdateEmpById(Employee emp);
    }
}
