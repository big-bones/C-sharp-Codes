 using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = @C:Userssarang_deshpandeDesktopA.txt;

        using(StreamWriter sr = new StreamWriter(path,true)) {
            sr.WriteLine(This is the new file);
            sr.WriteLine(This is the best file ever);
        }

        using(StreamReader sr = new StreamReader(path))
        {
            string line;
            while((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }


    }
}
