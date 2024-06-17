using System;
using System.Data;
using System.Data.SqlClient;


/*
 
stored procedure:

ALTER PROCEDURE GET_NAME_SALARY(
	@ID INT,
	@NAME VARCHAR(20) OUT,
	@SALARY NUMERIC(5,2) OUT
)
AS 
BEGIN 
	SELECT @NAME = NAME,@SALARY = SALARY
	FROM Employee WHERE ID = @ID
END
 
--Execution in SQL server 
DECLARE @EMP_NAME VARCHAR(20)
DECLARE @EMP_SALARY NUMERIC(5,2)

exec GET_NAME_SALARY 2,@NAME = @EMP_NAME OUTPUT,@SALARY = @EMP_SALARY OUTPUT

SELECT @EMP_NAME,@EMP_SALARY;
 
*/


class Program
{
    static void Main()
    {
        using (SqlConnection conn = new SqlConnection("Data Source=EPINHYDW0FCC\\SQLEXPRESS;Initial Catalog=learming;Integrated Security=SSPI"))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("GET_NAME_SALARY",conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@ID",SqlDbType.Int);
                SqlParameter idName = new SqlParameter("@Name",SqlDbType.VarChar,20);
                SqlParameter idSalary = new SqlParameter("@Salary", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output,
                    Precision = 5,
                    Scale = 2
                };
                idParameter.Value = 2;
                idName.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(idParameter);
                cmd.Parameters.Add(idName);
                cmd.Parameters.Add(idSalary);
                SqlDataReader reader = cmd.ExecuteReader(); 
                if(reader.Read()) {
                    Console.WriteLine("Name: " + reader["Name"]);
                    Console.WriteLine("Salary: " + reader["Salary"]);
                }
                else
                {
                    Console.WriteLine("No records found");
                }
                //reader.Close(); does not matter if we close this or not
                Console.WriteLine($"Name:{idName.Value},Salary:{idSalary.Value}");
            }
        }
    }
}