using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;



class Program
{
    static void Print(List<int>ls)
    {
        foreach (var x in ls)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }
    static void Main()
    {
        List<int> ls = new List<int>() { 1, 2, 3, 4, 5 };
        ls.Add(6);
        Print(ls);
        Console.WriteLine(ls.Remove(6));
        Print(ls);
        ls.RemoveAt(1);
        Print(ls);
        List<int> x = new List<int>() { 2, 4, 5 };
        ls.Insert(1,5);
        Print(ls);
        Console.WriteLine(ls.Contains(5));
        Predicate<int> predicate = (int b) =>
        {
            return b % 2 == 0;
        };
        int firstEvenIndex = ls.Find(predicate);
        Console.WriteLine(firstEvenIndex);
    }
}