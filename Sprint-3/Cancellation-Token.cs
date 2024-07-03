using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cts = cancellationTokenSource.Token;
        Task task = Task.Run(() =>
                    {
                        for(int i = 0; i < 1000; i++)
                        {
                            Console.WriteLine("Working ..." + i);
                            Thread.Sleep(100);
                            if (cts.IsCancellationRequested)
                            {
                                Console.WriteLine("Cancelling the process....");
                                break;
                            }
                            /*
                            
                            cts.ThrowIfCancellationRequested();
                            Throws the exception that reads
                            This operation was cancelled

                             */

                        }
                    }
        ,cts);
        await Task.Delay(2000);
        cancellationTokenSource.Cancel();
        try
        {
            await task;
        }catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
