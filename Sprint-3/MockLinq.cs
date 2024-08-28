using System;
using System.Collections;
using System.IO;



class Program
{
    static void FilterQuery()
    {
        var filteredList = employees.Where(x => x.Age > 30 && x.Department == IT).OrderByDescending(x => x.Age);

        foreach (var employee in filteredList)
        {
            Console.WriteLine(employee);
        }
    }

    static void ProjectionQuery()
    {
        var filteredList = products.Select((x) => new
        {
            Name = x.ProductName,
            ProductPrice = x.Price
        });
        foreach (var product in filteredList)
        {
            Console.WriteLine(product);
        }
    }

    static void GroupingExample()
    {
        var resultSet = orders.GroupBy(x => x.CustomerId);
        foreach (var x in resultSet)
        {
            Console.WriteLine(CustomerID:  + x.Key +   +
                              Total Amount:  + x.Sum(y => y.OrderAmount));
        }
    }

    static void JoinExample()
    {
        var joinedResult = customers.Join(
                                        orders,
                                        c => c.CustomerId,
                                        o => o.CustomerId,
                                        (c, o) => new
                                        {
                                            c.Name,
                                            Product = o.ProductName,
                                            ID = o.OrderId
                                        }
                                    );
        foreach (var x in joinedResult)
        {
            Console.WriteLine(x);
        }
    }

    static void GroupJoinExample()
    {
        var leftJoin = customers.GroupJoin(
                            orders,
                            c => c.CustomerId,
                            o => o.CustomerId,
                            (c, o) => new
                            {
                                Name = c.Name,
                                Orders = o.ToList()
                            }
                        );
        foreach (var x in leftJoin)
        {
            Console.Write(x.Name + : );
            if (x.Orders.Count == 0)
            {
                Console.WriteLine(No orders...);
                continue;
            }
            foreach (var y in x.Orders)
            {
                Console.Write(y.ProductName + ,);
            }
            Console.WriteLine();
        }
    }

    static void OrderData()
    {
        var orderedList = students.OrderBy(x => x);
        foreach (var student in orderedList)
        {
            Console.WriteLine(student.Name +   + student.Grade);
        }
    }

    static void ThenBySorting()
    {
        var orderedList = students.OrderBy(x => x.Grade).ThenByDescending(x => x.Name).ToList();
        foreach (var x in orderedList)
        {
            Console.WriteLine(x.Name +   + x.Grade);
        }
    }

    static void Print(IEnumerable<string>a)
    {
        foreach (var x in a)
        {
            Console.Write(x +  );
        }
        Console.WriteLine();
    }
    public static void Main()
    {


    }
}
