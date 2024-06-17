using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;



class Program
{
    static void Main()
    {
        Dictionary<int,string> nameDictionary = new Dictionary<int,string>();
        SortedDictionary<int,string> sortedNameDictionary = new SortedDictionary<int,string>(); 
        nameDictionary.Add(4,"A");
        nameDictionary.Add(3,"B");
        nameDictionary.Add(2,"C");
        nameDictionary.Add(1,"D");
        sortedNameDictionary.Add(4, "A");
        sortedNameDictionary.Add(3, "B");
        sortedNameDictionary.Add(2, "C");
        sortedNameDictionary.Add(1, "D");

        if (nameDictionary.ContainsKey(1))
        {
            Console.WriteLine(nameDictionary[1]);
        }
        if(nameDictionary.ContainsValue("B"))
        {
            Console.WriteLine("Exists");
        }
        Console.WriteLine(nameDictionary.Remove(1));
        nameDictionary.TryGetValue(6,out string value);
        if(value != null) {
            Console.WriteLine(value);
        }
        else
        {
            Console.WriteLine("No such value");
        }
        Console.WriteLine(nameDictionary.Count);
        foreach (KeyValuePair<int,string>pr in nameDictionary)
        {
            Console.WriteLine(pr.Key + " " + pr.Value);
        }
        foreach (KeyValuePair<int, string> pr in sortedNameDictionary)
        {
            Console.WriteLine(pr.Key + " " + pr.Value);
        }
    }
}