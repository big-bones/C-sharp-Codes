 using System;

//Use this when you want to enforce a callback on Client class
//Multiple callback methods to use


// Define the callback interface
public interface IWorkDoneCallback
{
    void OnWorkDone(string message);
}

// Worker class that performs work and uses the callback interface
public class Worker
{
    private readonly IWorkDoneCallback callback;

    // Constructor that takes an instance of the callback interface
    public Worker(IWorkDoneCallback callback)
    {
        this.callback = callback;
    }

    // Method that simulates work and triggers the callback
    public void DoWork()
    {
        // Simulate some work
        System.Threading.Thread.Sleep(1000);
        
        // Call the callback method
        callback.OnWorkDone(Work is done!);
    }
}

// Client class that implements the callback interface
public class Client : IWorkDoneCallback
{
    public void OnWorkDone(string message)
    {
        Console.WriteLine(message);
    }
}

// Main program
class Program
{
    static void Main()
    {
        // Create an instance of the client class
        Client client = new Client();
        
        // Pass the client instance to the worker class
        Worker worker = new Worker(client);
        
        // Start the work
        worker.DoWork();
    }
}

