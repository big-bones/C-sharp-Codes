using System;

class Rectangle
{
    public int length;
    public int width;

    public void setlength(int x)
    {
        length = x;
    }

    public void setwidth(int x)
    {
        width = x;
    }

}


class Square : Rectangle
{

}


class Driver
{
    static void calculatearea(Rectangle r)
    {
        Console.Writeline(r.width * r.length);
    }
    static void Main()
    {
        Rectangle r = new Square();
        r.setlength(10);
        r.setwidth(20);
        calculatearea(r);
    }
}


interface CalculateArea
{
    void CalculateArea();
}

class Rectangle : CalculateArea
{
    public int Length;
    public int Width;
    public void CalculateArea()
    {
        Console.WriteLine(Length*Width);
    }
}


class Square : CalculateArea
{
    public int Side;
    public void CalculateArea()
    {
        Console.WriteLine(Side * Side);
    }
}

class Driver
{
    static void Main()
    {
        // Write Area Logic
    }
}