using System;

public interface IA{
    void M();
}

public interface IB{
    void M();
}

class C : IA,IB{
    void IA.M(){
        Console.WriteLine("Systum");
    }
    
    void IB.M(){
        Console.WriteLine("Hang");
    }
}


class Practice {
  static void Main() {
    IA a = new C();
    a.M();
  }
}
