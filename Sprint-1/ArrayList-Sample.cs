using System;
using System.Collections;

using static System.Console;

class Practice{
    
    // GetEnumerator is a method of IEnumerable interface
    // GetEnumerator returns a reference of IEnumerator type
    // which has MoveNext(Boolean) , Current(Returns object)
    
    static void Print(ArrayList arr){
        IEnumerator itr = arr.GetEnumerator();
        while(itr.MoveNext()){
            Console.Write(itr.Current +  );
        }
        Console.WriteLine();
    }
    
    static void Main(){
        ArrayList arr = new ArrayList();
        arr.Add(1);
        arr.Add(10);
        arr.Add(2);
        arr.Add(4);
        arr.Add(5);
        Print(arr);
        if(arr.Contains(2)){  Console.WriteLine(Yes);}
        Console.WriteLine(arr.Capacity); // Doubles and starts from 4
        Console.WriteLine(arr.Count); // Current number of elements 
        Console.WriteLine(arr[1]);
        Console.WriteLine(arr.IndexOf(2)); // The first index of passed object
        arr.Remove(2);
        Object [] ar = new Object[4];
        arr.CopyTo(ar);
        Print(arr);
        foreach(Object o in ar){
            Console.Write(o +  );
        }
        Console.WriteLine();
    }
}
