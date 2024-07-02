using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class LinqDemo
    {
        static async Task Even()
        {
            for (int i = 2; i < 11; i += 2)
            {
                Console.WriteLine(i);
                await Task.Yield();
            }
        }

        static async Task Odd()
        {
            for (int i = 1; i < 11; i += 2)
            {
                Console.WriteLine(i);
                await Task.Yield();
            }
        }

        static async Task<int> Sum()
        {
            int sum = 0;
            for(int i = 1; i <= 100; i++)
            {
                sum += i;
            }
            return sum;
        }


        static async Task Main(string[] args)
        {
            Task b = Odd();
            Task a = Even();
            await Task.WhenAll(a, b);
            Task<int> temp = Sum();
            Console.WriteLine(temp.Result);

        }
    }
}
