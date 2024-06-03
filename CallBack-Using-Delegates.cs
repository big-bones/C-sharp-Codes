using System;

public delegate void CallBackDelegate(int a);

class Operate{
    public void Operation(int a,int b,CallBackDelegate cs){
        Console.WriteLine(a+b); // Some Operation
        cs(a+b);
    }
}

class Practice{
    static void CallBackConcrete(int x){
        Console.WriteLine($The method was a success and the result is {x});
    }
    static void Main(){
        Operate o = new Operate();
        o.Operation(10,20,CallBackConcrete);
    }
}
