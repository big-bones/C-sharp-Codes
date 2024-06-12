using System;
using System.Collections.Generic;

class Random{
    public static IEnumerable<int> Method(){
        int first = 1;
        Console.WriteLine(This is the first one);
        first++;
        yield return first;
        Console.WriteLine(Continue with the method);
        first++;
        yield return first;
    }
    public static IEnumerable<int> PrintNumbers(){
        for(int i=1;i<=3;i++){
            yield return i;
        }
    }
}

class Practice{
  static void Main() {
        var enumerable = Random.Method();
        var enumerator = enumerable.GetEnumerator();
        while(enumerator.MoveNext()){
            Console.WriteLine(enumerator.Current);
        }
        foreach(var x in Random.Method()){
            Console.WriteLine(x);
        }
        foreach(var x in Random.PrintNumbers()){
            Console.Write(x +  );
        }
  }
}
