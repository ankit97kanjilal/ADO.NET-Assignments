using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    class EmployeeBusiness
    {
        public static List<Employee> GetAllEmps()
        {
            var lstEmps = new List<Employee>
            {
                new Employee{Ecode=101,Ename="Ravi",Salary=1111,Deptid=201},
                new Employee{Ecode=102,Ename="Raman",Salary=2222,Deptid=202},
                new Employee{Ecode=103,Ename="Rai",Salary=3333,Deptid=203},
                new Employee{Ecode=104,Ename="Raja",Salary=4444,Deptid=201},
                new Employee{Ecode=105,Ename="Rama",Salary=5555,Deptid=202},
                new Employee{Ecode=106,Ename="Rajnath",Salary=6666,Deptid=201},
            };
            return lstEmps;
        }
        public static List<Department> GetAllDepts()
        {
            var lstDepts = new List<Department>
            {
                new Department{Deptid=201,Dname="Finance",Dhead=103},
                new Department{Deptid=202,Dname="Account",Dhead=101},
                new Department{Deptid=203,Dname="Sales",Dhead=105}
            };
            return lstDepts;
        }
    }
}
