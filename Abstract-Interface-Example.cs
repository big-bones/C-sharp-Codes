using System;

public abstract class AbstractAddition {
    public abstract int Add(int a, int b);
}

public interface IAddition{
    int Add(int a, int b);
}

public class ConcreteAddition : AbstractAddition, IAddition{
    public override int Add(int a, int b){
        return a + b;
    }

    int IAddition.Add(int a, int b){
        return Add(a, b);  
    }
}

class Program
{
    static void Main(string[] args){
        ConcreteAddition addition = new ConcreteAddition();
        IAddition additionInterface = addition;
        Console.WriteLine(addition.Add(10,12));
        Console.WriteLine(additionInterface.Add(10,12));
    }
}