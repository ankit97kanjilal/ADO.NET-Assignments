using HRMSEntitiesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSDataAccessLib
{
    public class AdoDisconnected : IDataAccess
    {
        public void DeleteEmployee(int ecode)
        {
            throw new NotImplementedException();
        }

        public void InsertEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> SelectAllEmps()
        {
            throw new NotImplementedException();
        }

        public Employee SelectEmpById(int ecode)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmpById(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
