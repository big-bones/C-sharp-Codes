using System;
using System.Threading.Tasks;

class Program
{
    static async Task Temp(){
        await Task.Delay(2000);
    }

    static void Main()
    {
        Task first = Task.Run( async () => {
            Console.WriteLine("Yeah boy");
            await Temp();
            Console.WriteLine("Done");
        });
        Task second = first.ContinueWith((prevTask) => {
            Console.WriteLine("First task is done!!!");
        });
        Console.WriteLine("No");
        second.Wait();
    }
}
