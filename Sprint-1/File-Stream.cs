 using System;
using System.IO;

// Byte Stream
// The constructor takes 2 parameters at least
// path and FileMode
// FileMode has multiple enums some of them throw excpetions
// .Create rewrites the contents if file exists if does not exists it creates
// .CreateNew if the file does exists it throws exception
// .Open if the file does not exist throws Exception
// .OpenOrCreate
// .Truncate makes file a 0 byte or creates a new one
// .Append if file exists then we can append to file if it does not exist then created
// FileShare enum allows to share between different files
class Program
{
    static void Main()
    {
        string path = @C:Userssarang_deshpandeDesktopNew-File.txt;
        using(FileStream fs = new FileStream(path , FileMode.Create , FileAccess.ReadWrite))
        {
            byte[] buffer = new byte[4096];
            string toWrite = This is the text to be written;
            buffer = System.Text.Encoding.UTF8.GetBytes(toWrite);
            fs.Write(buffer, 0, buffer.Length); 
        }

        using(FileStream fs = new FileStream(path , FileMode.Open ))
        {
            byte[] bytes = new byte[4096];
            fs.Read(bytes, 0, bytes.Length);
            string toRead = System.Text.Encoding.UTF8.GetString(bytes);
            Console.WriteLine(toRead);
        }

    }
}
