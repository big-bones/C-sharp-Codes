using System;

public delegate void OperationDelegate(int a,int b);

class Operations{
    public void Add(int a,int b){
        Console.WriteLine(a+b);
    }
    public void Subtract(int a,int b){
        Console.WriteLine(Math.Abs(a - b));
    }
    public OperationDelegate CreateMethod(string type){
        switch (type){
            case "Divide" : 
                return (a,b) => { 
                    try{
                     if(b == 0){
                         throw new Exception("Divide by zero");
                     }else{
                         Console.WriteLine(a/b);
                     }   
                    }catch(Exception e){
                        Console.WriteLine(-1);
                    }
                };
            case "multiply" :
                return (a,b) => { Console.WriteLine(a*b) ;};
            default:
                return (a,b) => {Console.WriteLine(-1);};
        }
    }
}


class DelegateDemo {
  static void Main() {
    // Operations os = new Operations();
    // OperationDelegate AddDelegate = new OperationDelegate(os.Add);
    // OperationDelegate SubtractDelegate = new OperationDelegate(os.Subtract);
    // OperationDelegate MultiplyDelegate = delegate(int a,int b){
    //     return a*b;  
    // };
    // OperationDelegate DivideDelegate = (int a,int b) => { 
    //         try{
    //             if(b == 0){
    //                 throw new Exception("Divide by zero");
    //             }else{
    //                 return a/b;
    //             }
    //         }catch(Exception e){
    //             return -1;
    //         }
    // };
    // Console.WriteLine(DivideDelegate(20,0));
    // Console.WriteLine(MultiplyDelegate(20,10));
    // Console.WriteLine(AddDelegate(20,10));
    // Console.WriteLine(SubtractDelegate(20,10));
        Operations o = new Operations();
        OperationDelegate multiCast = o.Add;
        multiCast += o.Subtract;
        multiCast += o.CreateMethod("Divide");
        multiCast += o.CreateMethod("multiply");
        multiCast(20,10);
  }
}
