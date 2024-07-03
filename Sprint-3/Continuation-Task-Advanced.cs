using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Task<int> firstTask = Task.Run(() =>
        {
            Console.WriteLine("First task is running.");
            Task.Delay(1000).Wait();
            throw new Exception("Something went wrong in the first task.");
            return 42; // This line will not be reached
        });

        Task secondTask = firstTask.ContinueWith(previousTask =>
        {
            if (previousTask.IsFaulted)
            {
                Console.WriteLine($"First task failed with exception: {previousTask.Exception.InnerException.Message}");
            }
            else
            {
                int result = previousTask.Result;
                Console.WriteLine($"First task completed with result: {result}");
            }
            Console.WriteLine("Second task is running.");
        }, TaskContinuationOptions.None);

        Task thirdTask = firstTask.ContinueWith(previousTask =>
        {
            Console.WriteLine("Second task is running because the first task faulted.");
        }, TaskContinuationOptions.OnlyOnFaulted);

        try
        {
            Task.WaitAll(secondTask, thirdTask);
        }
        catch (AggregateException ex)
        {
            foreach (var innerEx in ex.InnerExceptions)
            {
                Console.WriteLine($"Exception: {innerEx.Message}");
            }
        }

        Console.WriteLine("All tasks completed.");
    }
}
w