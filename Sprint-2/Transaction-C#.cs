using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data.Common;

class Program
{
    
    static void Main()
    {
        using (SqlConnection conn = new SqlConnection("Data Source=EPINHYDW0FCC\\SQLEXPRESS;Initial Catalog=learming;Integrated Security=SSPI"))
        {
            conn.Open();
            using (SqlTransaction ctr = conn.BeginTransaction())
            {
                using(SqlCommand cmd1 = new SqlCommand("update employee set salary = salary-@amount where id=@id1",conn,ctr))
                using(SqlCommand cmd2 = new SqlCommand("update employee set salary = salary+@amount where id=@id2", conn,ctr))
                {
                    SqlParameter p1 = new SqlParameter("@id1",2);
                    SqlParameter p2 = new SqlParameter("@id2",3);
                    SqlParameter p3 = new SqlParameter("@amount",10);
                    SqlParameter p4 = new SqlParameter("@amount", 10);
                    cmd1.Parameters.Add(p1);
                    cmd1.Parameters.Add(p3);
                    cmd2.Parameters.Add(p2);
                    cmd2.Parameters.Add(p4);
                    int i1 = cmd1.ExecuteNonQuery();
                    int i2 = cmd2.ExecuteNonQuery();    
                    if(i1 == 1 && i2 == 1)
                    {
                        ctr.Commit();
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        ctr.Rollback();
                        Console.WriteLine("Failed");
                    }
                }
            }
        }
    }
}

