using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static int counter = 0;

    private static Object _lock = new object();

    static void Increment()
    {
        for(int i = 0;i < 10; i++)
        {
            lock (_lock) {
                counter++;
            }
        }
    }
    static void Decrement()
    {
        for (int i = 0; i < 10; i++)
        {
            lock (_lock)
            {
                counter--;
            }
        }
    }
    static void Main()
    {
       Thread increment = new Thread(Increment);
        Thread decrement = new Thread(Decrement);
        increment.Start();
        decrement.Start();  
        // although threads are foreground threads
        // there is no guarentee that the counter is sensible values since threads have not completed their work
        increment.Join();
        decrement.Join();   
        Console.WriteLine(counter);
    }
}
