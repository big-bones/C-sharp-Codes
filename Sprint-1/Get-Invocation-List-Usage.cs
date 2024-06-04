using System;
using System.Collections.Generic;

public delegate int OperateDelegate(int a,int b);

class Operate{
    public int Add(int a,int b){
        return a+b;
    }
    public int Subtract(int a,int b){
        return a-b;
    }
    public int Multiply(int a,int b){
        return a*b;
    }
}

class Practice{
    static void Main(){
        Operate o = new Operate();
        OperateDelegate opd = o.Add;
        opd += o.Subtract;
        opd += o.Multiply;
        // Console.WriteLine(opd(10,12)); (Just the last method is executed)
        // GetInvocationList returns a list of type delegate
        // is var is used instead of OperateDelegate we need to typecast it explicitly
        // then invoke using DynamicInvoke
        List<int>list = new List<int>();
        foreach(OperateDelegate oo in opd.GetInvocationList()){
            list.Add(oo(10,12));
        }
        foreach(var i in list){
            Console.Write(i +  );
        }
        Console.WriteLine();
    }
}
