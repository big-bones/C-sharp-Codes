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
        public int DepartmentID { get; set; }
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

    internal class LinqDemo
    {
        static string connection;
        static void Query()
        {
            using (var db = new EmployeeContext(connection))
            {
                var employeeList = from emp in db.Employees
                                   where emp.ManagerID != null
                                   select emp;
                foreach (var x in employeeList)
                {
                    Console.WriteLine(x);
                }
                var tempList = db.Employees.Where(emp => emp.ManagerID != null)
                                           .Select(emp => new { Name = emp.EmployeeName, ID = emp.EmployeeID });
                foreach (var x in tempList)
                {
                    Console.WriteLine(x.ID + " " + x.Name);
                }
            }
        }

        static void AddElement()
        {

            using (var db = new EmployeeContext(connection)) {
                var dept = new Department
                {
                    DepartmentID = 7,
                    DepartmentName  = "Random",
                    Budget = 200
                };
                db.Departments.InsertOnSubmit(dept);  
                db.SubmitChanges();
            }
        }

        static void Update()
        {
            using(var db = new EmployeeContext(connection))
            {
                var tempEmpl = db.Employees.FirstOrDefault(e => e.EmployeeID == 9);
                if (tempEmpl != null)
                {
                    tempEmpl.Salary = 4000;
                }
                var emp = (from e in db.Employees
                          where e.EmployeeID == 9
                          select e).First();
                if(emp != null)
                {
                    emp.Salary = 200;
                }
                db.SubmitChanges();
            }
        }

        static void Delete() {
            using (var db = new EmployeeContext(connection)) { 
                var tempEmpl = db.Employees.FirstOrDefault(x => x.EmployeeID == 9);
                if(tempEmpl != null) {
                    db.Employees.DeleteOnSubmit(tempEmpl);  
                }
                var tempDept = (from d in db.Departments
                               where d.DepartmentID == 7
                               select d).First();
                if (tempDept != null)
                {
                    db.Departments.DeleteOnSubmit(tempDept);
                }
                db.SubmitChanges();
            }
        }

        static void Main()
        {
            connection = "Data Source=EPINHYDW0FCC\\SQLEXPRESS;Initial Catalog=learming;Integrated Security=SSPI";
            //AddElement();
            //Query();
            //Update();
            //Delete();
        }
    }
}

