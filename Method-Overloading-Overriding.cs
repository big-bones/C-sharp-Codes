using System;

class A{
    public virtual void M(){
        Console.WriteLine(This is A);
    }
}

class B : A{
    public override void M(){
        Console.WriteLine(This is changed A);
    }
    new public void M(string message){
        Console.WriteLine($This is the hidden B {message});
    }
}


class Program
{
    static void Main(){
        A a = new A();
        a.M();
        B b = new B();
        b.M();
        a.M();
    }
}
