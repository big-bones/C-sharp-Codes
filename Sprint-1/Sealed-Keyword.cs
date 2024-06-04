using System;
using static System.Console;

class A{
    public virtual void M(){
        WriteLine("This is in class A");
    }
}

class B : A{
    public sealed override void M(){
        WriteLine("This is in B class");
    }
}

class C : B{
    
}



class Practice {
  static void Main() {
    C c = new C();
    c.M();
  }
}