
using System;
using System.Threading;

class Program
{
    private static ManualResetEvent manualEvent = new ManualResetEvent(false); // Initial state is non-signaled
    private static int counter = 0;
   
    static void Main()
    {

        Thread t1 = new Thread(Worker);
        Thread t2 = new Thread(Worker);

        t1.Start();
        t2.Start();

        Thread.Sleep(2000); // Simulate some work in the main thread
        Console.WriteLine("Main thread signaling event {0}...", Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(1000);
        manualEvent.Set(); // Signal the event

        t1.Join();
        t2.Join();
        Console.WriteLine("Final counter value: " + counter);
    }

    static void Worker()
    {
        Console.WriteLine("Thread {0} waiting...", Thread.CurrentThread.ManagedThreadId);
        manualEvent.WaitOne(); // Wait for the signal
        Console.WriteLine("Thread {0} proceeding...", Thread.CurrentThread.ManagedThreadId);
        Interlocked.Increment(ref counter);
        manualEvent.Reset();
    }
}
