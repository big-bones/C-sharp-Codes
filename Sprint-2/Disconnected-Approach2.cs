using System;
using System.Data;

namespace DataSetExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("School");

            // Create the DataTable
            DataTable table = new DataTable("Students");
            dataSet.Tables.Add(table);

            // Define the columns
            DataColumn idColumn = new DataColumn("ID", typeof(int));
            DataColumn nameColumn = new DataColumn("Name", typeof(string));
            DataColumn gradeColumn = new DataColumn("Grade", typeof(int));
            table.Columns.Add(idColumn);
            table.Columns.Add(nameColumn);
            table.Columns.Add(gradeColumn);

            // Add some rows
            table.Rows.Add(1, "Alice", 90);
            table.Rows.Add(2, "Bob", 85);
            table.Rows.Add(3, "Charlie", 88);

            // Iterate through the DataSet
            foreach (DataRow row in dataSet.Tables["Students"].Rows)
            {
                Console.WriteLine($"{row["ID"]}, {row["Name"]}, {row["Grade"]}");
            }
        }
    }
}
