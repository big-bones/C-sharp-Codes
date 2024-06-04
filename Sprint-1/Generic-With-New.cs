using System;
using static System.Console;

class GenericWithNew<T> where T : new(){
    public T CreateInstance(){
        return new T();
    }
}


class Example{
    public int A {get ; set ;}
    public Example(){
        A = 0;
    }
    public Example(int a){
        A = a;
    }
    public override string ToString(){
       return "Class B Instance";
    }
}

class Practice {
  static void Main() {
    GenericWithNew<Example> t = new GenericWithNew<Example>();
    Example e = t.CreateInstance();
    WriteLine(e);
  }
}
