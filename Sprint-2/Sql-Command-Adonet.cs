using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=EPINHYDW0FCC\\SQLEXPRESS;Initial Catalog=learming;Integrated Security=SSPI"))
            {
                conn.Open();
                while (true)
                {
                    Console.WriteLine("Enter 1 to find all users");
                    Console.WriteLine("Enter 2 to enter the user");
                    Console.WriteLine("Enter 3 to update the user");
                    Console.WriteLine("Enter 4 to delete the user");
                    Console.WriteLine("Enter 5 to view all the users");
                    Console.WriteLine("Enter 6 to exit");
                    int input = int.Parse(Console.ReadLine());
                    if(input == 6){ break;}
                    if (input == 1)
                    {
                        using (SqlCommand cmd = new SqlCommand("select * from Employee", conn))
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string name = reader.GetString(1);
                                    decimal salary = reader.GetDecimal(2);
                                    Console.WriteLine($"ID:{id},Name:{name},Salary:{salary}");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                    else if (input == 2)
                    {
                        Console.Write("Enter a name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter salary: ");
                        decimal salary = decimal.Parse(Console.ReadLine());
                        using (SqlCommand cmd = new SqlCommand($"insert into Employee(name,salary) values('{name}',{salary})",conn))
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected == 1)
                            {
                                Console.WriteLine("Success");
                            }
                            else
                            {
                                Console.WriteLine("Failed");
                            }
                        }

                    }
                    else if (input == 3)
                    {
                        Console.WriteLine("Enter the id of the user");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter the new salary: ");
                        double salary = double.Parse(Console.ReadLine());
                        using (SqlCommand cmd = new SqlCommand($"update Employee set salary = {salary} where id = {id}", conn))
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected == 1)
                            {
                                Console.WriteLine("Success");
                            }
                            else
                            {
                                Console.WriteLine("Failed");
                            }
                        }
                    }
                    else if(input == 4) 
                    {
                        Console.Write("Enter the ID to remove: ");
                        int id = int.Parse(Console.ReadLine());
                        using (SqlCommand cmd = new SqlCommand($"delete from Employee where id = {id}", conn))
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected == 1)
                            {
                                Console.WriteLine("Success");
                            }
                            else
                            {
                                Console.WriteLine("Failed");
                            }
                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand("select count(*) from Employee",conn))
                        {
                            int totalRows = (int)cmd.ExecuteScalar();
                            Console.WriteLine($"Total Employees are {totalRows}");
                        }
                    }
                }
            }
        }
    }
}
