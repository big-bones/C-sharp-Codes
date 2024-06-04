 using System;

public class Program
{
    public static void Main()
    {
        Predicate<int> isEven = value => value % 2 == 0;
        bool result = isEven(4);
        Console.WriteLine(result);  // Outputs: True
    }
}
