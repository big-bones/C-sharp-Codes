using System;
using System.Collections.Generic;

class Person : IComparable<Person>{
    public string Name {get;set;}
    public int Age{get;set;}
    public decimal Salary{get;set;}
    public int CompareTo(Person p){
        if(p == null){return 1;}
        if(this.Age > p.Age){
            return 1;
        }else if(this.Age < p.Age){
            return -1;
        }else{
            return 0;
        }
    }
    public override string ToString(){
        return $"Age:{Age},Name:{Name}";
    }
}

class PersonComparer : IComparer<Person>{
    public int Compare(Person a,Person p){
        if(p == null){return 1;}
        if(a.Age < p.Age){
            return 1;
        }else if(a.Age > p.Age){
            return -1;
        }else{
            return 0;
        }
    }
}

class Practice{
  static void Main() {
    Person p1 = new Person { Name = "Alice", Age = 28 , Salary = 235.65m };
    Person p2 = new Person { Name = "Bob", Age = 30 , Salary = 239.65m };
    List<Person> p = new List<Person>();
    p.Add(p1);p.Add(p2);
    p.Sort();
    foreach(var x in p){
        Console.WriteLine(x);
    }
    p.Sort(new PersonComparer());
    foreach(var x in p){
        Console.WriteLine(x);
    }
  }
}