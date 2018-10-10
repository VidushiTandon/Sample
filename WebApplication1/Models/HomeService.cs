using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.models.DB;

namespace WebApplication1.Models
{
    public class HomeService
    {
        niitContext context;
        private object temp;

        public object SumSalary { get; private set; }

        public HomeService(niitContext context)
        {
            this.context = context;
        }
        public List<string> EmpNames()
        {
            var result= (from e in context.Emp select e.Name).ToList();
            return result;
        }
        public List<EmpDeptt> GetEmpDepttDetails()
        {
            //var result = (from e in context.Emp
            //             join d in context.Deptt
            //             on e.Deptid equals d.Deptid
            //    select new EmpDeptt()
            //    {
            //        Code=e.Code,
            //        DeptId = d.Deptid,
            //        DepttName=d.Name,
            //        EmpName=e.Name,
            //        Salary=e.Salary.Value

            //    }).ToList();

            var result = (from e in context.Emp
                          join d in context.Deptt
                          on e.Deptid equals d.Deptid
                          where e.Salary > 3000 && e.Salary <=10000
                          orderby e.Salary descending
                          select new EmpDeptt()
                          {
                              Code = e.Code,
                              DeptId = d.Deptid,
                              DepttName = d.Name,
                              EmpName = e.Name,
                              Salary = e.Salary.Value

                          }).ToList();
            return result;
        }
        public void Grouping()
        {
            var result = (from e in context.Emp join d in context.Deptt on
                          e.Deptid equals d.Deptid
                          group e.Salary by d.Name
                        into temp
                          select new {

                                         temp.Key,
                                         SumSalary = temp.Sum()
                                     }).ToArray();

        }

        public void ExtensionMethods()
        {
            //    var result = context.Emp.
            //        Where(c => c.Salary > 10000).Select(a => new {Salary= a.Salary, Name=a.Name }).ToList();

            // var result = context.Emp.Where(c => c.Name.StartsWith("M")).Sum(c => c.Salary);
            //    var result = context.Emp.OrderByDescending(c => c.Salary).Skip(2).Take(3);
            /* var result = context.Emp.Join(context.Deptt,
                 e => e.Deptid, 
                 d => d.Deptid,
                 (eobj, dobj) => new{eobj.Salary,dobj.Name,empname=eobj.Name,dobj.Deptid});
                 */
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //Emp e = context.Emp.Where(c => c.Code == 100).First();
            //Emp e = context.Emp.Where(c => c.Code == 100).FirstOrDefault();
            //Emp e = context.Emp.Where(c => c.Code == 100).LastOrDefault();
           // Emp e = context.Emp.Single(c => c.Code == 100);
            //Emp e = context.Emp.SingleOrDefault(c => c.Code == 100);
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            var list = Enumerable.Range(1, 100).ToList();

            //var result = list.Where(c => c % 2 == 0);

            //  var odds = list.Except(result);

            //var result = list.Where(c => c % 2 != 0).SkipWhile(a => a < 50);
            var result = list.Where(c => c % 2 != 0).TakeWhile(a => a < 50);

        }
        public void AddRecord(Emp em)
        {
            context.Emp.Add(em);
            context.SaveChanges();
        }
    }
}
