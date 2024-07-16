using System;

namespace Facade{


    public class Subsytem1
    {
        public string operation1()
        {
            return "Subsystem1: Ready!\n";
        }

        public string operationN()
        {
            return "Subsystem1: Go!\n";
        }

    }

    public class Subsytem2
    {
        public string operation1()
        {
            return "Subsystem2: Get ready!\n";
        }

        public string operationZ()
        {
            return "Subsystem2: Fire!\n";
        }

    }
    public class Facade
    {
        protected Subsytem1 subsytem1;
        protected Subsytem2 subsytem2;
        public Facade(Subsytem1 subsytem1, Subsytem2 subsytem2)
        {
            this.subsytem1 = subsytem1;
            this.subsytem2 = subsytem2;
        }

        public string Operation()
        {
            string result = "";
            result += subsytem1.operation1();
            result += subsytem2.operation1();
            result += subsytem2.operationZ();
            result += subsytem1.operationN();
            return result;
        }

    }

    class Client
    {
        public static void ClientCode(Facade facade)
        {
            Console.WriteLine(facade.Operation());
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            Subsytem1 subsystem1 = new Subsytem1();
            Subsytem2 subsystem2 = new Subsytem2();
            Facade facade = new Facade(subsystem1, subsystem2);
            Client.ClientCode(facade);
        }
    }
}