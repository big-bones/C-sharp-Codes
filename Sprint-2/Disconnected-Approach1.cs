using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=EPINHYDW0FCC\\SQLEXPRESS;Initial Catalog=learming;Integrated Security=SSPI;";
        DataSet dataSet = new DataSet();

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            Console.WriteLine("Connected to the database.");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employee", conn);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dataSet, "Employee");

            Console.WriteLine("1. Display all employees");
            Console.WriteLine("2. Add a new employee");
            Console.WriteLine("3. Update an employee's salary");
            Console.WriteLine("4. Remove an employee");
            Console.WriteLine("5. Display total number of employees");
            Console.Write("Enter your choice: ");
            int input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                DataTable table = dataSet.Tables["Employee"];
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"ID: {row["id"]}, Name: {row["name"]}");
                }
            }
            else if (input == 2)
            {
                DataTable table = dataSet.Tables["Employee"];
                DataRow newRow = table.NewRow();

                Console.Write("Enter the ID: ");
                newRow["id"] = int.Parse(Console.ReadLine());

                Console.Write("Enter the Name: ");
                newRow["name"] = Console.ReadLine();

                Console.Write("Enter the Salary: ");
                newRow["salary"] = double.Parse(Console.ReadLine());

                table.Rows.Add(newRow);
                adapter.Update(dataSet, "Employee");
                Console.WriteLine("New employee added successfully.");
            }
            else if (input == 3)
            {
                Console.WriteLine("Enter the id of the user");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter the new salary: ");
                double salary = double.Parse(Console.ReadLine());

                DataTable table = dataSet.Tables["Employee"];
                DataRow[] rows = table.Select($"id = {id}");
                if (rows.Length == 1)
                {
                    rows[0]["salary"] = salary;
                    adapter.Update(dataSet, "Employee");
                    Console.WriteLine("Salary updated successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to update salary.");
                }
            }
            else if (input == 4)
            {
                Console.Write("Enter the ID to remove: ");
                int id = int.Parse(Console.ReadLine());

                DataTable table = dataSet.Tables["Employee"];
                DataRow[] rows = table.Select($"id = {id}");
                if (rows.Length == 1)
                {
                    rows[0].Delete();
                    adapter.Update(dataSet, "Employee");
                    Console.WriteLine("Employee removed successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to remove employee.");
                }
            }
            else
            {
                DataTable table = dataSet.Tables["Employee"];
                Console.WriteLine($"Total Employees are {table.Rows.Count}");
            }
        }
    }
}


