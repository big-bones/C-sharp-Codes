using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApp2
{
    internal class LinqDemo
    {
     
        /*
         Task.Delay(x)
         returns a Task object that would be executed in x milliseconds
         Chaining .Wait() implies that the task will be done in x milliseconds
         for the time the executing thread(thread that is executing the method)
         is blocked
         */
        static void Hello(int x)
        {
            Thread.CurrentThread.Name = "Worker Thread";
            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 1; i <= x; i++)
            {
                Console.WriteLine("Hello");
                Task.Delay(1000).Wait();
            }
        }

        static void Hi(int x)
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            for (int i = 1; i <= x; i++)
            {
                Console.WriteLine("Hi");
                Task.Delay(1000).Wait(); 
            }
        }
        
        static async Task Main()
        {
            Task a = Task.Run(() => { Hello(5); });
            Task b = Task.Run(() => { Hi(5); });
            Task.WaitAll(a, b);
        }
    }
}


