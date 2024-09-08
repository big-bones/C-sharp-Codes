using System;
using System.IO;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;


class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
}

class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}

class Order
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
}


class Program
{

    static List<Category> categories = new List<Category>
    {
        new Category { CategoryId = 1, CategoryName = "Electronics" },
        new Category { CategoryId = 2, CategoryName = "Clothing" },
        new Category { CategoryId = 3, CategoryName = "Groceries" },
        new Category { CategoryId = 4, CategoryName = "Random" }
    };

    static List<Product> products = new List<Product>
    {
        new Product { ProductId = 1, ProductName = "Laptop", CategoryId = 1, Price = 1000 },
        new Product { ProductId = 2, ProductName = "Smartphone", CategoryId = 1, Price = 800 },
        new Product { ProductId = 3, ProductName = "T-Shirt", CategoryId = 2, Price = 20 },
        new Product { ProductId = 4, ProductName = "Jeans", CategoryId = 2, Price = 50 },
        new Product { ProductId = 5, ProductName = "Bread", CategoryId = 3, Price = 2 },
        new Product { ProductId = 6, ProductName = "Milk", CategoryId = 3, Price = 1.5M },
        new Product { ProductId = 7, ProductName = "AlmondMilk", CategoryId = -1, Price = 1.5M },
        new Product { ProductId = 8, ProductName = "GameStation", CategoryId = -1, Price = 1000 },

    };

    static List<Order> orders = new List<Order>
    {
        new Order { OrderId = 1, ProductId = 1, Quantity = 2, OrderDate = new DateTime(2023, 8, 10) },
        new Order { OrderId = 2, ProductId = 3, Quantity = 5, OrderDate = new DateTime(2023, 8, 11) },
        new Order { OrderId = 3, ProductId = 2, Quantity = 1, OrderDate = new DateTime(2023, 8, 12) },
        new Order { OrderId = 4, ProductId = 5, Quantity = 10, OrderDate = new DateTime(2023, 8, 12) },
        new Order { OrderId = 5, ProductId = 6, Quantity = 8, OrderDate = new DateTime(2023, 8, 13) },
        new Order { OrderId = 6, ProductId = 4, Quantity = 3, OrderDate = new DateTime(2023, 8, 14) },
        new Order { OrderId = 1, ProductId = 1, Quantity = 4, OrderDate = new DateTime(2023, 8, 10) }
    };

    static void Product_Category()
    {
        var ProductCategory = products.GroupJoin(
                                       categories,
                                       p => p.CategoryId,
                                       c => c.CategoryId,
                                       (p, x) => new
                                       {
                                           ProductName = p.ProductName,
                                           SomeList = x.ToList().FirstOrDefault() == null ? "No Category" :
                                                      x.ToList().First().CategoryName
                                       }
                                );
        foreach ( var x in ProductCategory )
        {
            Console.WriteLine(x);
        }
    }

    static void Second()
    {
        var CategoryProduct = categories.GroupJoin(
                                products,
                                c => c.CategoryId,
                                p => p.CategoryId,
                                (c,p) => new
                                {
                                    CategoryName = c.CategoryName,
                                    Products = p.ToList().Count() == 0 ? new List<Product>() : p.ToList()
                                }
                            );

        foreach(var  x in CategoryProduct)
        {
            Console.WriteLine(x.CategoryName);
            foreach(var y in x.Products)
            {
                Console.Write(y.ProductName + " ");
            }
            Console.WriteLine();
        }
    }

    static void Third()
    {
        var anotherGroup = products.GroupJoin(
                            orders,
                            p => p.ProductId,
                            o => o.ProductId,
                            (p, o) => new
                            {
                                ProductName = p.ProductName,
                                TotlPriceOrder = (o.Sum(x => x.Quantity))*p.Price
                            }
                        );
        foreach (var x in anotherGroup)
        {
            Console.WriteLine(x);
        }
    }

    static void Fourth()
    {
        var someGrouping = products.GroupBy(x => x.ProductName)
                                   .Select(x => new
                                   {
                                       ProductName = x.Key,
                                       TotalQuantities = x.Sum(y => y.Price)
                                   });

        foreach(var x in someGrouping)
        {
            Console.WriteLine(x);
        }
    }

    static void Fifth()
    {
        var firstHalf = products.GroupJoin(
                        orders,
                        p => p.ProductId,
                        o => o.ProductId,
                        (p,o) => new
                        {
                            CategoryID = p.CategoryId,
                            ProductName = p.ProductName,
                            TotalQuantity = o.Sum(x => x.Quantity)
                        }
                    );
        var secondHalf = categories.GroupJoin(
                        firstHalf,
                        c => c.CategoryId,
                        f => f.CategoryID,
                        (c,f) => new
                        {
                            CateogryName = c.CategoryName,
                            TotalPurchases = f.Sum(x => x.TotalQuantity)
                        }
                );

        foreach (var x in secondHalf)
        {
            Console.WriteLine(x);
        }
    }

    static void Sixth()
    {
        var categoryWiseMaxPrice = categories.GroupJoin(
                                            products,
                                            c => c.CategoryId,
                                            p => p.CategoryId,
                                            (c,p) => new
                                            {
                                               CategoryName = c.CategoryName,
                                               ProductPrice = p.ToList().Count() != 0 ? p.Max(x => x.Price).ToString() : "No Price",
                                               ProductName = p.ToList().Count() != 0 ? p.Where(x => x.Price == (p.Max(y => y.Price))).First().ToString() : "No max element"
                                            }
                                            );
        foreach(var x in categoryWiseMaxPrice)
        {
            Console.WriteLine(x);
        }
    }

    static void Seventh()
    {
        var groupAndOrder = orders.GroupBy(x => x.OrderDate)
                        .Select(x => new
                        {
                            OrderDate = x.Key,
                            Orders = x.Count()
                        }).OrderBy(x => x.OrderDate);
        foreach(var x in groupAndOrder)
        {
            Console.WriteLine(x);
        }
    }

    static void Main()
    {
        Seventh();
    }
}