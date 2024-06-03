 using System;


class Complex
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public Complex()
    {

    }

    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.Real + b.Real,a.Imaginary + b.Imaginary);
    }

    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }

    public static bool operator ==(Complex a, Complex b)
    {
        return ((a.Real == b.Real) && (b.Imaginary == a.Imaginary));
    }

    public static bool operator !=(Complex a, Complex b)
    {
    }

    public override string ToString()
    {
        return $Real:{Real} , Imaginary:{Imaginary};
    }

}


class Practice
{
    static void Main()
    {
        Complex a = new Complex{ Real = 12, Imaginary = 13 };
        Complex b = new Complex{ Real = 12, Imaginary = 13 };
        Complex c = a + b;
        Complex d = a - b;
        Console.WriteLine(c);
        Console.WriteLine(d);
        Console.WriteLine(a == b);
    }
}

