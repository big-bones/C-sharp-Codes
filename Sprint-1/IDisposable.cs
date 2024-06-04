 using System;
using System.IO;


class ResourceUtilizer : IDisposable
{
    private bool _disposed;
    private FileStream fs;
    private string _path;

    public ResourceUtilizer(string path) { 
        _path = path;

    }

    public void Write()
    {
        fs = new FileStream(_path,FileMode.Create);
        byte[] buffer = new byte[1024];
        buffer = System.Text.Encoding.UTF8.GetBytes(This is the file in process);
        fs.Write(buffer,0,buffer.Length);
        fs.Flush();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }



    public void Dispose(bool disposing)
    {
        if(_disposed) return;
        if (disposing)
        {
            fs.Close();
            fs = null;
        }
    }

    ~ResourceUtilizer()
    {
        Dispose(false);
    }

}

class Program
{
    static void Main()
    {
        using(ResourceUtilizer rs = new ResourceUtilizer(@C:Userssarang_deshpandeDesktopTemp.txt))
        {
            rs.Write();
        }
    }
}
