using System;
using System.Linq;
using System.Collections.Generic;


class Program
{

   static List<Company> companies = new List<Company>
        {
            new Company
            {
                Name = "Company A",
                Employees = new List<Employee>
                {
                    new Employee
                    {
                        Name = "Alice",
                        Projects = new List<Project>
                        {
                            new Project { Name = "Project X", HoursSpent = 40 },
                            new Project { Name = "Project Y", HoursSpent = 35 },
                            new Project { Name = "Project Z", HoursSpent = 20 }
                        }
                    },
                    new Employee
                    {
                        Name = "Bob",
                        Projects = new List<Project>
                        {
                            new Project { Name = "Project X", HoursSpent = 25 }
                        }
                    }
                }
            },
            new Company
            {
                Name = "Company B",
                Employees = new List<Employee>
                {
                    new Employee
                    {
                        Name = "Charlie",
                        Projects = new List<Project>
                        {
                            new Project { Name = "Project A", HoursSpent = 20 },
                            new Project { Name = "Project B", HoursSpent = 30 }
                        }
                    },
                    new Employee
                    {
                        Name = "David",
                        Projects = new List<Project>
                        {
                            new Project { Name = "Project A", HoursSpent = 25 },
                            new Project { Name = "Project B", HoursSpent = 15 }
                        }
                    }
                }
            }
        };

    public static void Main()
    {
        var multiple = companies.Where(x => ((x.Employees.Where(y => y.Projects.Count > 2).ToList()).Count > 0))
                                .Select(x => new
                                {
                                    Company = x.Name,
                                    TotalHours = x.Employees.Sum(y => y.Projects.Sum(z => z.HoursSpent)),
                                    Employee = x.Employees.Where(y => y.Projects.Count > 2),    
                                });

        foreach (var x in multiple)
        {
            Console.Write(x.Company + " " + x.TotalHours + " ");
            foreach (var y in x.Employee)
            {
                Console.Write(y.Name + " ");
            }
            Console.WriteLine();
        }

        var ordered = companies.OrderByDescending(x => x.Employees.Sum(y => y.Projects.Sum(z => z.HoursSpent)))
                               .Select(z => z.Name);

        foreach (var x in ordered)
        {
            Console.WriteLine(x);
        }


        var groupedEmployees = companies.GroupBy(x => ((x.Employees.Where(y => y.Projects.Count > 2).ToList()).Count));

        foreach(var x in groupedEmployees)
        {
            Console.WriteLine(x.Key);
        }
                         
        

    }
}

