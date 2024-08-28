using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public decimal Salary { get; set; }
}

public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeId = 1, Name = "Alice", DepartmentId = 1, Salary = 50000 },
            new Employee { EmployeeId = 2, Name = "Bob", DepartmentId = 2, Salary = 60000 },
            new Employee { EmployeeId = 3, Name = "Charlie", DepartmentId = 1, Salary = 55000 },
            new Employee { EmployeeId = 4, Name = "Dave", DepartmentId = 3, Salary = 70000 },
            new Employee { EmployeeId = 5, Name = "Eve", DepartmentId = 2, Salary = 65000 }
        };

        List<Department> departments = new List<Department>
        {
            new Department { DepartmentId = 1, DepartmentName = "HR" },
            new Department { DepartmentId = 2, DepartmentName = "IT" },
            new Department { DepartmentId = 3, DepartmentName = "Finance" }
        };

        var groupedCollection = from e in employees
                                join d in departments
                                on e.DepartmentId equals d.DepartmentId
                                group new { e, d } by d.DepartmentId into grp
                                orderby grp.Key
                                select new
                                {
                                    DepartmentId = grp.Key,
                                    DepartmentName = grp.Where(x => x.d.DepartmentId == grp.Key)
                                                        .Select(x => x.d.DepartmentName).First(),
                                    EmployeeList = grp.Select(x => x.e)
                                };
        foreach (var x in groupedCollection)
        {
            Console.WriteLine(x.DepartmentId + " " + x.DepartmentName);
            foreach (var e in x.EmployeeList)
            {
                Console.Write(e.Name + " ");
            }
            Console.WriteLine();
        }

        var grouppedCollections = employees.Join(
                                    departments,
                                    e => e.DepartmentId,
                                    d => d.DepartmentId,
                                    (e, d) => new { e, d }
                                    ).GroupBy(x => x.d.DepartmentId).
                                    OrderBy(x => x.Key).
                                    Select(
                                        (g) => new {
                                            DepartmentID = g.Key,
                                            DepartmentName = g.Where(x => x.d.DepartmentId == g.Key).
                                                               Select(x => x.d.DepartmentName).First(),
                                            EmployeeList = g.Select(x => x.e).ToList()
                                        }
        );

        foreach (var x in grouppedCollections)
        {
            Console.WriteLine(x.DepartmentID + " " + x.DepartmentName);
            foreach (var e in x.EmployeeList)
            {
                Console.Write(e.Name + " ");
            }
            Console.WriteLine();
        }

        var joinKardiyaGuru = employees.Join(
                        departments,
                        emp => emp.DepartmentId,
                        dept => dept.DepartmentId,
                        (emp, dept) =>
                        new
                        {
                            Name = emp.Name,
                            DepartmentId = emp.DepartmentId,
                            Salary = emp.Salary,
                            DepartmentName = dept.DepartmentName
                        }
                    ).GroupBy(
                        grp => grp.DepartmentName
                    ).Select(
                        grp => new
                        {
                            Key = grp.Key,
                            Count = grp.Count()
                        }
                    );
foreach (var x in joinKardiyaGuru)
{
    Console.WriteLine(x);
}

        var simpleGroups = from e in employees
                           group e by e.DepartmentId into g
                           select new
                           {
                               DepartmentID = g.Key,
                               Count = g.Count()
                           };

        var simpleGroupsMethod = employees.GroupBy(x => x.DepartmentId)
                                          .Select((g) => new
                                          {
                                              DepartmentID = g.Key,
                                              Count = g.Count() 
                                          });

    }
}
