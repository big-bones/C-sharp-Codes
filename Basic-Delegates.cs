using System;
using static System.Console;

public delegate void OperationDelegate(int a,int b);

class Sample{
    public void Add(int a,int b){
        WriteLine(a + b);
    }
    public void Multiply(int a,int b){
        WriteLine(a * b);
    }
}

class DelegateDemo{
  static void Main(){
    Sample s = new Sample();
    OperationDelegate opd = s.Add;
    opd += s.Multiply;
    opd(10,20);
  }
}