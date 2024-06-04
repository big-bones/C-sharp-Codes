using System;
using static System.Console;

class CustomData : EventArgs{
    public int First {get ; set;}
    public int Second {get ; set;}
}

class Publisher{
    public event EventHandler<CustomData> MyEvent; // Return Type of EventHandler delegate is always void
    
    public void RaiseEvent(int a,int b){
        if(MyEvent != null){
            CustomData cds = new CustomData{First = a , Second = b};
            MyEvent.Invoke(this , cds);
        }
    }
}

class Subscriber{
    public void Add(Object o , CustomData e){ // This should match the signature of EventHandler type
        WriteLine(e.First + e.Second);
    }
}


class Practice{
  static void Main() {
    Subscriber sc = new Subscriber();
    Publisher pbs = new Publisher();
    pbs.MyEvent += sc.Add;
    pbs.RaiseEvent(10,20);
  }
}
