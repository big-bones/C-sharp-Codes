using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


class Program
{
    static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(2);

    static void SharedResource(int id)
    {
        semaphoreSlim.Wait();
        try
        {
            Console.WriteLine($"Thread with id {id} acquired the lock");
            Task.Delay(1000).Wait();    
        }
        finally
        {
            semaphoreSlim.Release();
            Console.WriteLine($"Thread with id {id} is released the lock");
        }

        
    }
    static void Main()
    {
        List<Task> tasks = new List<Task>();
        for(int i = 0; i < 6; i++)
        {
            int id = i;
            tasks.Add(Task.Run(() => SharedResource(id)));
        }
        Task.WaitAll(tasks.ToArray());

    }
}