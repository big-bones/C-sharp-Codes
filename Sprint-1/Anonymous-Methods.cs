using System;
using static System.Console;

public delegate void MyDelegate(int a,int b);

class Publisher{
    
    public event MyDelegate MyEvent;
    
    public void RaiseEvent(int a,int b){
        MyEvent?.Invoke(a,b);
    }
}

class Practice{
  static void Main() {
    
    Publisher pbs = new Publisher();
    
    pbs.MyEvent += delegate(int a,int b){
        int total = 0;
        for(int i=a;i<=b;i++){
            if(i == b-1){
                break;
            }else{
                total += i;
            }
        } 
        WriteLine(total);
    };
    
    pbs.MyEvent += delegate(int a,int b){
        int total = 0;
        for(int i=b;i>=a;i--){
            if(i == a+1){
                break;
            }else{
                total += i;
            }
        }
        WriteLine(total);
    };
    
    pbs.RaiseEvent(10,30);
    
    
  }
}
