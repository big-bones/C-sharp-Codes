using System;
using System.Collections.Generic;
using System.Linq;

class Program
{ 
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student("Alice", 100),
            new Student("Bob", 90),
            new Student("Alice", 100),
            new Student("Charlie", 75),
            new Student("Bob", 88),
            new Student("Alice",100)
        };

        var Average = students.GroupBy(x => x.Name)
                                 .Select(x => new
                                 {
                                     Name = x.Key,
                                     Average = x.Average(y => y.Score)
                                 });

        Console.Write("Average of max as the greates is for " +
                       Average.Where(x => x.Average == Average.Max(y => y.Average))
                       .Select(x => x.Name).ToList().First());

    }
}