using System;
using System.Data;
using System.Data.SqlClient;


/*
 
 
 CREATE PROCEDURE UPDATE_EMPLOYEE_SALARY(
	@ID INT,
	@NEW_SALARY NUMERIC(5,2)
)	
AS 
BEGIN
	DECLARE @ROWS_UPDATED INT;
BEGIN TRANSACTION;
		UPDATE Employee SET Salary = @NEW_SALARY
		WHERE Id = @ID;
		SET @ROWS_UPDATED = @@ROWCOUNT
		IF @ROWS_UPDATED = 1
		BEGIN 
			COMMIT TRANSACTION;
			PRINT 'SUCCESS'
		END 
		ELSE 
		BEGIN 
			ROLLBACK TRANSACTION;
			PRINT 'FAILED'
		END
END;


exec UPDATE_EMPLOYEE_SALARY 3,300.5;
 */



class Program
{
    static void Main()
    {
		using (SqlConnection conn = new SqlConnection("Data Source=EPINHYDW0FCC\\SQLEXPRESS;Initial Catalog=learming;Integrated Security=SSPI"))
		{
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE_EMPLOYEE_SALARY",conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter idParameter = new SqlParameter("@ID",SqlDbType.Int);
                SqlParameter salaryParameter = new SqlParameter("@NEW_SALARY",SqlDbType.Decimal);
                idParameter.Value = 2;
                salaryParameter.Value = 500.75;
               cmd.Parameters.Add(idParameter);
               cmd.Parameters.Add(salaryParameter);
               int rowsChanged = cmd.ExecuteNonQuery();
                if(rowsChanged == 1)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
		}
    }
}