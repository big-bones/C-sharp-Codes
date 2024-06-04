using System;

public delegate void MyDelegate(int a,int b);

class Publisher{
    
    private MyDelegate myDelegate;
    
    public event MyDelegate MyEvent{
        add{
            myDelegate += value;
        }
        remove{
            myDelegate -= value;
        }
    }
    
    public void RaiseEvent(int a,int b){
        myDelegate(a,b);
    }
    
}

class Subscriber{
    public void Add(int a,int b){
        Console.WriteLine(a + b);
    }
    public void Multiply(int a,int b){
        Console.WriteLine(a*b);
    }
}

class Practice{
  static void Main() {
    Subscriber sc = new Subscriber();
    Publisher pbs = new Publisher();
    pbs.MyEvent += sc.Add;
    pbs.MyEvent += sc.Multiply;
    pbs.RaiseEvent(10,20);
  }
}


