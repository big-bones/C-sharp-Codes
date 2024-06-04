using System;

class Program
{
    static void Main()
    {
        try
        {
            ProcessData();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception caught in Main: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
        }
    }

    static void ProcessData()
    {
        try
        {
            PerformCalculation();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while processing data.", ex);
        }
    }

    static void PerformCalculation()
    {
        try
        {
            int result = 10 / int.Parse("0"); // This will cause a DivideByZeroException
        }
        catch (Exception ex)
        {
            throw new ArithmeticException("An error occurred during calculation.", ex);
        }
    }
}
