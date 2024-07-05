using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static ReaderWriterLockSlim lockSlim = new ReaderWriterLockSlim();
    static List<int> sharedList = new List<int>();

    static void Main()
    {
        Thread writerThread = new Thread(Writer);
        Thread readerThread1 = new Thread(Reader);
        Thread readerThread2 = new Thread(Reader);

        writerThread.Start();
        readerThread1.Start();
        readerThread2.Start();

        writerThread.Join();
        readerThread1.Join();
        readerThread2.Join();
    }

    static void Writer()
    {
        for (int i = 0; i < 5; i++)
        {
            lockSlim.EnterWriteLock();
            try
            {
                Console.WriteLine("Writing: " + i);
                sharedList.Add(i);
                Thread.Sleep(100);
            }
            finally
            {
                lockSlim.ExitWriteLock();
            }
        }
    }

    static void Reader()
    {
        for (int i = 0; i < 5; i++)
        {
            lockSlim.EnterReadLock();
            try
            {
                Console.WriteLine("Reading: " + string.Join(", ", sharedList));
                Thread.Sleep(100); // Simulate some work
            }
            finally
            {
                lockSlim.ExitReadLock();
            }
        }
    }
}