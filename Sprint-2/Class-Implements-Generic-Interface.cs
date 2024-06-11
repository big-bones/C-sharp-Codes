using System;

interface A
{
    void Method();
}

interface B<T> : A
{
    void Method1();
}

class Temp<T> : B<T>
{
    public void Method()
    {
        Console.WriteLine(This is temp);
    }
    public void Method1()
    {
        Console.WriteLine(This is method1);
    }
}


class C<T> where T : B<T>{
    public C(){
        Console.WriteLine(This is c);
    }
}

class Practice
{
    static void Main()
    {
        Temp<int> t = new Temp<int>();
        t.Method();
        t.Method1(); 
        C<Temp<int>> c = new C<Temp<int>>();
    }
}
