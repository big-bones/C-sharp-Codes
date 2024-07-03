using System;
using System.Threading;

class Program
{
    private static SpinLock _lock = new SpinLock();
    private static int counter = 0;

    static void Increment()
    {
        for(int i = 0; i < 100; i++)
        {
            bool lockTaken = false;
            try
            {
                _lock.Enter(ref lockTaken);
                counter++;
            }
            finally {
                if (lockTaken)
                {
                    _lock.Exit();
                }
            }   
        }
    }


  

    static void Main()
    {
        Thread[] threads = new Thread[5];

        for(int i=0; i<threads.Length; i++)
        {
            threads[i] = new Thread(Increment);
            threads[i].Start(); 
        }

        for(int i=0;i<threads.Length; i++)
        {
            threads[i].Join(); 
        }

        Console.WriteLine($"The value of the counter {counter}");

    }

}