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
            try
            {
                Monitor.Enter(_lock);
                    counter++;
            }
            finally
            {
                Monitor.Exit(_lock);    
            }
        }
    }
    static void Decrement()
    {
        for (int i = 0; i < 10; i++)
        {
            try
            {
                Monitor.Enter(_lock);
                counter--;
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
    }
    static void Main()
    {
        Task increment = Task.Run(() => { Increment(); });
        Task decrement = Task.Run(() => { Decrement(); });
        Task.WaitAll(increment, decrement);
        Console.WriteLine(counter);
    }
}
