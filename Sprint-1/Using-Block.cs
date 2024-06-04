using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = "example.txt";

        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine("Hello, world!");
        }

        using (StreamReader reader = new StreamReader(path))
        {
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
        }
    }
}
