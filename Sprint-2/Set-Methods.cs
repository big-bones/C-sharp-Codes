using System;
using System.Collections.Generic;

class Practice{
  static void Main() {
      HashSet<int>a = new HashSet<int>(){1,2,3};
      HashSet<int>b = new HashSet<int>(){3,4,5,7};
      List<int>c = new List<int>(){1,2,3,4,5,6};
      a.Add(10);
       foreach(int i in a){
          Console.Write(i + " ");
      }
      Console.WriteLine();
      if(a.Remove(10)){
          Console.WriteLine("a had 10");
      }
      if(a.Contains(3)){
          Console.WriteLine("a has 3");
      }
      a.UnionWith(c);
      foreach(int i in a){
          Console.Write(i + " ");
      }
      Console.WriteLine();
      a.IntersectWith(b); // IEnumerable type so all the collections basicallyu
      foreach(int i in a){
          Console.Write(i + " ");
      }
      Console.WriteLine();
      SortedSet<int> ss = new SortedSet<int>(){7,5,2};
      foreach(int x in ss){
          Console.Write(x + " ");
      }
      Console.WriteLine();
  }
}