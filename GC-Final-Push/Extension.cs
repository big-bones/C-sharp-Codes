using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

abstract class Random
{
    public abstract void Something();

    public static void SomeMethod()
    {
        Console.Write("Some Method");
    }

}

class Derived : Random
{
    public override void Something()
    {
        Console.WriteLine("Something in the way....");
    }
}

static class ExtendRandom
{
    public static void AddedSomething(this Random r,int a)
    {
        Console.WriteLine("Added this feature with " + a);
    }
}

class Program
{ 
    public static void Main()
    {
        Derived d = new Derived();
        d.Something();
        d.AddedSomething(10);
        Random.SomeMethod();
        Derived.SomeMethod();
    }
}





