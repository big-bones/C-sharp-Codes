using System;
using System.IO;


abstract class SampleHandler
{
    protected SampleHandler _next = null;

    public void SetHandler(SampleHandler nextHandler)
    {
        _next = nextHandler;
    }

    public abstract void Handle(string request);
}

class BasicSupport : SampleHandler
{
    public override void Handle(string request)
    {
        if(request.Equals("Basic support request"))
        {
            Console.WriteLine("Request is handled by basic support.....");
        }
        else
        {
            _next.Handle(request);
        }
    }
}

class IntermediateSupport : SampleHandler
{
    public override void Handle(string request)
    {
        if (request.Equals("Intermediate support request"))
        {
            Console.WriteLine("Request is handled by intermediate support.....");
        }
        else
        {
            _next.Handle(request);
        }
    }

}

class AdvancedSupport : SampleHandler
{
    public override void Handle(string request)
    {
        Console.WriteLine("Request is handled by advanced support.....");
    }
}

class Program
{
    static void Main()
    {
        SampleHandler basic = new BasicSupport();
        SampleHandler intermediate = new IntermediateSupport();
        SampleHandler advanced = new AdvancedSupport();
        basic.SetHandler(intermediate);
        intermediate.SetHandler(advanced);

        string request_first = "Basic support request";
        string request_two = "Intermediate support request";
        string request_three = "Advanced support request";

        basic.Handle(request_first);
        basic.Handle(request_two);
        basic.Handle(request_three);

    }
}