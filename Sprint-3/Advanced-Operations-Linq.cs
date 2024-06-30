using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApp2
{
    [Table(Name = "Employees")]
    class Employee
    {
        [Column(IsPrimaryKey = true)]
        public int EmployeeID { get; set; }
        [Column]
        public string EmployeeName { get; set; }
        [Column]
        public int? DepartmentID { get; set; }
        [Column]
        public decimal Salary { get; set; }
        [Column]
        public int? ManagerID { get; set; }

        public override string ToString()
        {
            return $"{EmployeeName},{EmployeeID}";
        }
    }

    [Table(Name = "Departments")]
    class Department {
        [Column(IsPrimaryKey = true)]
        public int? DepartmentID { get; set; }
        [Column]
        public string DepartmentName { get; set; }
        [Column]
        public decimal Budget { get; set; }
    }


    class EmployeeContext : DataContext
    {
        public Table<Employee> Employees;
        public Table<Department> Departments;
        public  EmployeeContext(string connection) : base(connection) { }
    }

    class Pair
    {
        public Employee e;
        public IEnumerable<Department> d;
    }

    internal class LinqDemo
    {
        static string connection;
        
        static void SimpleJoinExample()
        {
            using(var db = new EmployeeContext(connection))
            {
                var simpleJoin = from d in db.Departments
                                 join
                                 e in db.Employees
                                 on d.DepartmentID equals e.DepartmentID
                                 select new
                                 {
                                     EmployeeName = e.EmployeeName,
                                     DepartmentName = d.DepartmentName,
                                     EmployeeID = e.EmployeeID,
                                 };
                foreach (var x in simpleJoin)
                {
                    Console.WriteLine(x.EmployeeID + " " + x.EmployeeName + " " + x.DepartmentName);
                }

            }
        }

        static void MethodSimpleJoin()
        {
            using (var db = new EmployeeContext(connection))
            {
                var simpleJoinExample = db.Employees
                                          .Join(
                                               db.Departments,
                                               emp => emp.DepartmentID,
                                               dept => dept.DepartmentID,
                                               (emp,dept) =>
                                               new {
                                                   EmployeeName = emp.EmployeeName,
                                                   DepartmentName = dept.DepartmentName,
                                                   EmployeeID = emp.EmployeeID,
                                               }
                                           );
                foreach (var x in simpleJoinExample)
                {
                    Console.WriteLine(x.EmployeeID + " " + x.EmployeeName + " " + x.DepartmentName);
                }
            }
        }

        static void QueryGrouping()
        {
            using (var db = new EmployeeContext(connection))
            {
                var salaryGroups = from e in db.Employees
                                   group e by e.DepartmentID into g
                                   select new
                                   {
                                       DepartmentID = g.Key == null ? 0 : g.Key,
                                       TotalEmployees = g.Count(),
                                       AverageSalary = g.Average(o => o.Salary),
                                       EmployeeList = g.ToList()

                                   };

                foreach (var group in salaryGroups)
                {
                    Console.WriteLine(group.DepartmentID + " " + group.TotalEmployees + " " + group.AverageSalary);
                    foreach (var x in group.EmployeeList)
                    {
                        Console.WriteLine(x);
                    }
                }
                //foreach (var x in salaryGroups)
                //{
                //    Console.WriteLine(x.DepartmentID);
                //    Console.WriteLine(x.EmployeeList.Average(o => o.Salary));
                //}
            }
        }

        static void MethodGrouping()
        {
            using (var db = new EmployeeContext(connection))
            {
                var salaryGroups = db.Employees
                                       .GroupBy(g => g.DepartmentID)
                                       .Select(
                                           (g) =>
                                           new {
                                               DepartmentID = g.Key,
                                               TotalEmployees = g.Count(),
                                               AverageSalary = g.Average(o => o.Salary),
                                               EmployeeList = g.ToList()    
                                           }
                                        );
                foreach (var group in salaryGroups)
                {
                    Console.WriteLine(group.DepartmentID + " " + group.TotalEmployees + " " + group.AverageSalary);
                    foreach (var x in group.EmployeeList)
                    {
                        Console.WriteLine(x);
                    }
                }
            }
        }

        static void LeftJoin()
        {
            using(var db = new EmployeeContext(connection))
            {
                var tempLeftJoin = from e in db.Employees
                                   join
                                   d in db.Departments
                                   on e.DepartmentID equals d.DepartmentID into empdeptJoin
                                   from subDepartment in empdeptJoin.DefaultIfEmpty()
                                   select new
                                   {
                                       Name = e.EmployeeName,
                                       ID = e.EmployeeID,
                                       DepartmentName = subDepartment.DepartmentName == null ? "No Department" : subDepartment.DepartmentName
                                   };
                foreach (var item in tempLeftJoin)
                {
                    Console.WriteLine(item.Name + " " + item.ID + " " + item.DepartmentName);        
                }
            
            }
        }

        static void MethodLeftJoin()
        {
            using (var db = new EmployeeContext(connection))
            {
                var tempLeftJoin = db.Employees
                                     .GroupJoin(
                                         db.Departments,
                                         emp => emp.DepartmentID,
                                         dept => dept.DepartmentID,
                                         (emp, deptList) => new Pair{
                                             e = emp, 
                                             d = deptList
                                         }
                                      )
                                     .SelectMany(
                                       x => x.d.DefaultIfEmpty(),
                                       (x,subdept) => new
                                       {
                                           x.e.EmployeeID,
                                           x.e.EmployeeName,
                                           DepartmentName = subdept != null ? subdept.DepartmentName : "No Department"
                                       }
                                       );
                foreach ( var item in tempLeftJoin)
                {
                    Console.WriteLine(item.EmployeeID + " " + item.EmployeeName + " " + item.DepartmentName);
                }
            } 
        }

        static void Main()
        {
            connection = "Data Source=EPINHYDW0FCC\\SQLEXPRESS;Initial Catalog=learming;Integrated Security=SSPI";
            //SimpleJoinExample();
            //MethodSimpleJoin();
            //LeftJoin();
            //MethodLeftJoin();
            //QueryGrouping();
            //MethodGrouping();
        }
    }
}

