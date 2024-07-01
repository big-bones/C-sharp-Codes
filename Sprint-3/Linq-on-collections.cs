using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApp2
{
    

    internal class LinqDemo
    {

        static void MethodWhere()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNumbers = numbers.Where(x => x % 2 == 0);
            foreach (var x in evenNumbers)
            {
                Console.WriteLine(x);
            }

        }

        static void QueryWhere()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenNumbers = from e in numbers
                              where e % 2 == 0
                              select e;
            foreach (var x in evenNumbers)
            {
                Console.WriteLine(x);
            }
        }

        static void MethodSelect()
        {
            List<string> words = new List<string> { "apple", "banana", "cherry" };
            var selectWords = words.Select(x => x.ToUpper());
            foreach (var x in selectWords)
            {
                Console.WriteLine(x);
            }
            
        }

        static void QuerySelect()
        {
            List<string> words = new List<string> { "apple", "banana", "cherry" };
            var selectWords = from e in words
                              select new
                              {
                                  UpperCase = e.ToUpper()
                              };
            foreach(var x in selectWords)
            {
                Console.WriteLine(x);
            }   
        }

        static void MethodOrdering()
        {
            List<int> numbers = new List<int> { 5, 1, 8, 4, 2 };
            var ascendingOrder = numbers.OrderBy(x => x);   
            var descendingOrder = numbers.OrderByDescending(x => x);
            // To order by say Person age use people.OrderBy(p => p.Age)
            // To order by say Person age use people.OrderByDescending(p => p.Age)
            foreach (var x in ascendingOrder)
            {
                Console.WriteLine(x);
            }
            foreach (var x in descendingOrder)
            {
                Console.WriteLine(x);
            }
        }

        static void QueryOrdering()
        {
            List<int> numbers = new List<int> { 5, 1, 8, 4, 2 };
            var ascendingOrder = from x in numbers
                                 orderby x
                                 select x;
            var descendingOrder = from x in numbers
                                  orderby x descending
                                  select x;
            foreach (var x in ascendingOrder)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
            foreach (var x in descendingOrder)
            {
                Console.Write(x + " ");
            }
            /*
            Do not create anonymous object when it comes to order by
            var ascendingOrder = from p in people
                     order by new p.Age , p.FirstName
                     select new{
                        Name = p.FirstName + " " + p.LastName,
                        Age = p.Age,
                        Salary = p.Salary
                    };
             
             */
        }


        static void MethodAggregate()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            var sum = numbers.Sum();
            // same for min,max,average
        }
        
        static void QueryAggregate()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            var sum = from x in numbers
                      select x;
            sum.Sum();
            // Because it returns IEnumerable anyway

            /*
             
            var averageAgeOfGroup = from p in people
                                    group p by p.DepartmentName into g
                                    select new{
                                        DetName = g.Key,
                                        AverageAge = g.Average(x => x.Age)
                                    }
             
             
             */

        }

        static void Main()
        {

        }
    }
}

