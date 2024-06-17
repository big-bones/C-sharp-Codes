using System;
using System.Collections.Generic;
class Person : IEquatable<Person>{
    public int Age {get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    
    public Person(){
        
    }
    
    public bool Equals(Person p){
        if((p.FirstName == this.FirstName) && (p.LastName == this.LastName)){
            return true;
        }else{
            return false;
        }
    }
    
    public override bool Equals(object o){
        Person other = (Person)o;
        if(other is Person && other != null){
            return other.Age == this.Age;
        }else{
            return false;
        }
    }
    
    public override int GetHashCode(){
        // int first = this.FirstName.GetHashCode();
        // int second = this.LastName.GetHashCode();
        // return first ^ second;
        return 1;
    }
    
    public override string ToString(){
        return $"Name:{FirstName},Last:{LastName}";
    }
}

class PersonComparer : IEqualityComparer<Person>{
    
    public bool Equals(Person a,Person b){
        if(a.Age == b.Age){
            return true;
        }else{
            return false;
        }
    }
    
    public int GetHashCode(Person p){
        int first = p.Age.GetHashCode();
        return first;
    }
    
}

class Practice{
  static void Main() {

      Person a = new Person{Age = 23,FirstName = "A",LastName = "B"};
      Person b = new Person{Age = 23,FirstName = "D",LastName = "C"};
      Person c = new Person{Age = 24,FirstName = "A" , LastName = "B"};
    //   HashSet<Person> hs1 = new HashSet<Person>(new PersonComparer());
    //   hs1.Add(a);
    //   hs1.Add(b);
    //   foreach(Person p in hs1){
    //       Console.WriteLine(p);
    //   }
    //   Console.WriteLine();
    HashSet<Person>hs = new HashSet<Person>();
    hs.Add(a);hs.Add(b);hs.Add(c);
    Console.WriteLine(a.GetHashCode());
    Console.WriteLine(b.GetHashCode());
    Console.WriteLine(c.GetHashCode());
      foreach(Person p in hs){
          Console.WriteLine(p);
      }
  }
}