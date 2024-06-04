using System;
using static System.Console;

public delegate int MyDelegate(int a, int b);

class Publisher
{
    public event MyDelegate MyEvent;

    public int RaiseEvent(int a, int b)
    {
        return MyEvent?.Invoke(a, b) ?? 0; // If the delegate has no method referenced we need to return 0
    }
}

class Practice
{
    static void Main()
    {

        Publisher pbs = new Publisher();

        pbs.MyEvent += (int a, int b) =>
        {
            int total = 0;
            for (int i = a; i <= b; i++)
            {
                total += (i);
            }
            return total; 
        };

        WriteLine(pbs.RaiseEvent(10, 30));
    }
}
