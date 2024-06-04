using System;
using System.Collections;


class Practice {
    static void Print(SortedList hp){
       IEnumerator KeyIterator = hp.Keys.GetEnumerator();
       while(KeyIterator.MoveNext()){
           Console.Write(KeyIterator.Current +  );
       }
       Console.WriteLine();
       IEnumerator ValueIterator = hp.Values.GetEnumerator();
       while(ValueIterator.MoveNext()){
           Console.Write(ValueIterator.Current +  );
       }
       Console.WriteLine();
        Console.Write(Just Keys: );
        foreach(var k in hp.Keys){
            Console.Write(k +  );
        }
        Console.WriteLine();
        Console.Write(Just values: );
        foreach(var v in hp.Values){
            Console.Write(v +  );
        }
        Console.WriteLine();
    }
    static void Main() {
        SortedList hp = new SortedList();
        hp.Add(1,abc);
        hp.Add(2,abd);
        hp.Add(3,abe);
        Console.WriteLine(hp.Contains(1));
        string s = (string)hp[1];
        Console.WriteLine(s);
        Console.WriteLine(hp.ContainsValue(abd));
        Console.WriteLine(hp.Count);
        Console.WriteLine(hp[1]);
        Print(hp);
    }
}
