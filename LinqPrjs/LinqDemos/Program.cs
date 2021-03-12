using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            var lstEmps = EmployeeBusiness.GetAllEmps();
            var lstDepts = EmployeeBusiness.GetAllDepts();

            //find the employees whose salary is greater than 5000
            //using linq operators
            //var result = from emp in lstEmps
            //             //where emp.Salary >= 50000
            //              order by emp.Ecode descending            
            //             select new 
            //             { 
            //                 emp.Ecode, 
            //                 emp.Ename 
            //             };

            //using Linq extension method(uses lambda expression)
            //var result = lstEmps.Where(o => o.Salary >= 50000)
            //                    .Select(o => new
            //                    {
            //                        o.Ecode,
            //                        o.Ename
            //                    }).OrderByDescending(o=>o.Ecode);

            //group query : select deptid,sum(salary), avg(salary),max(salary), min(salary) from employee group by deptid
            //var result2 = from emp in lstEmps
            //              group emp by emp.Deptid into g
            //              select new
            //              {
            //                  Deptid=g.Key,
            //                  TotalSal= g.Sum(o=>o.Salary),
            //                  AvgSal=g.Average(o=>o.Salary),
            //                  MinSal=g.Min(o=>o.Salary),
            //                  MaxSal=g.Max(o=>o.Salary),
            //                  NoOfEmps=g.Count()
            //              };

            //using Extension method syntax
            var result2 = lstEmps.GroupBy(o => o.Deptid)
                                 .Select(o => new
                                 {
                                     Deptid = o.Key,
                                     TotalSal = o.Sum(p => p.Salary),
                                     AvgSal = o.Average(p => p.Salary),
                                     MinSal = o.Min(p => p.Salary),
                                     MaxSal = o.Max(p => p.Salary), 
                                     NoOfEmps = o.Count()
                                 });

            //nested query: find the employees who are working in the deptid of employee id 101
            //select * from employee where deptid = (select deptid from employee where ecode=101)
            //var nestedRes = from emp in lstEmps
            //                where emp.Deptid == (from e in lstEmps 
            //                                     where e.Ecode==101 
            //                                     select e.Deptid).SingleOrDefault()
            //                select emp;

            //using extension method
            //var nestedRes = lstEmps.Where(o => o.Deptid == (lstEmps.Where(e => e.Ecode == 101)
            //                                                       .Select(e => e.Deptid))
            //                                                       .SingleOrDefault());

            //foreach (var r in nestedRes)
            //{
            //    Console.WriteLine(r.Ecode + "\t" + r.Ename + "\t" + r.Salary + "\t" + r.Deptid);
            //}

            //foreach (var r in result2)
            //{
            //    Console.WriteLine(r.Deptid +"\t"+r.TotalSal+"\t"+r.AvgSal+"\t"+r.MinSal+"\t"+r.MaxSal+"\t"+r.NoOfEmps);
            //}

            //display the result
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Ecode + "\t" + item.Ename);// +"\t"+item.Salary+"\t"+item.Deptid);
            //}

            //JOIN OPERATION
            var joinres = from emp in lstEmps
                         join dept in lstDepts on emp.Deptid equals dept.Deptid
                         select new
                         {
                             Ecode = emp.Ecode,
                             Ename = emp.Ename,
                             Salary = emp.Salary,
                             Deptid = emp.Deptid,
                             Dname = dept.Dname,
                             Dhead = dept.Dhead
                         };
            foreach (var item in joinres)
            {
                Console.WriteLine(item.Ecode + "\t" + item.Ename + "\t" + item.Salary + "\t" + item.Deptid +
                    "\t" + item.Dname + "\t" + item.Dhead);
            }


        }
        static void Linq_Basic()
        {
            //var numbers = new int[] { 2, 7, 10, 11, 20, 5, 6, 8 };
            //find the numbers which are greater than 5 and even number, also order them in descending number
            //var result = new List<int>();
            //foreach (var item in numbers)
            //{
            //    if(item>5 && item % 2 == 0)
            //    {
            //        result.Add(item);
            //    }
            //}
            //result.Sort();

            //using linq
            //var result = from n in numbers
            //             where n > 5 && n % 2 == 0
            //             orderby n descending
            //             select n;

            //displaying result
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //Type inference
            //var x = new int[] { 10, 20 };
            //var is to specify what is the value of right hand side....
            //it's not a dynamic type... once it's defined of one type...
            //For this example life of x is int array
            //var y;    //not allowing.. have to assign while declaring only
            //y = 100;
            //var can't be used for method arguments
            //var can't be used for class fields

            //Anonymous type
            //var emp = new
            //{
            //    Ecode=100,
            //    Ename="Ankit",
            //};
            //Console.WriteLine(emp.Ecode+"\t"+emp.Ename);

            //var needs to be declared and assigned in the same line
            //var cannot be used for method argument while defining
            //var cannot be used for class fields
        }

    }
}