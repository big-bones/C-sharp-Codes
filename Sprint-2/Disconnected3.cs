using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data.Common;

class Program
{
    static DataSet ds;
    static SqlDataAdapter adapter;

   static void Print()
    {
        foreach (DataRow r in ds.Tables[0].Rows)
        {
            Console.WriteLine($"ID:{r[0]},Name:{r[1]},Salary:{r[2]}");
        }
        Console.WriteLine();
    }

    static void AddRow()
    {
        DataRow dr = ds.Tables[0].NewRow();
        dr["Name"] = "C";
        dr["Salary"] = 300.5m;
        ds.Tables[0].Rows.Add(dr);
    }

    static void UpdateQuery()
    {
        Int32 id = 4;
        decimal slry = 412.5m;
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            if ((Int32)row[0] == id)
            {
                row[2] = slry;
                break;
            }  
        }
        adapter.Update(ds);
    }

    static void DeleteQuery()
    {
        Int32 id = 4;
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            if ((Int32)row[0] == id)
            {
                row.Delete();
                break;
            }
        }
        adapter.Update(ds);
    }

    static void Main()
    {
        using (SqlConnection conn = new SqlConnection("Data Source=EPINHYDW0FCC\\SQLEXPRESS;Initial Catalog=learming;Integrated Security=SSPI;"))
        {
            conn.Open();
            ds = new DataSet();
            adapter = new SqlDataAdapter("select * from Employee", conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);    
            adapter.Fill(ds);
            DeleteQuery();
        }
    }
}

