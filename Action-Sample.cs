using System;
using static System.Console;

class Publisher{
    
    public event Action<int,int> MyEvent;
    
    public void RaiseEvent(int a,int b){
        MyEvent?.Invoke(a,b);
    }
}

class Practice{
  static void Main() {
    
    Publisher pbs = new Publisher();
    
    pbs.MyEvent += (int a,int b) =>{
        int total = 0;
        for(int i=a;i<=b;i++){
            total += (i);
        }
        Console.WriteLine(total);
    };
    
    pbs.RaiseEvent(10,30);
  }
}
