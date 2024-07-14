using System;

namespace Builder
{
    public class Computer
    {
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string GraphicsCard { get; set;}
        public override string ToString()
        {
            return $"CPU: {CPU}, RAM: {RAM}, Storage: {Storage}, Graphics Card: {GraphicsCard}";
        }
    }

    public interface IComputerBuilder
    {
        void SetCPU();
        void SetRAM();
        void SetStorage();
        void SetGraphicsCard();

        Computer GetComputer();

    }

    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetCPU()
        {
            _computer.CPU = "Intel Core i9";
        }

        public void SetRAM()
        {
            _computer.RAM = "32GB";
        }

        public void SetStorage()
        {
            _computer.Storage = "1TB SSD";
        }

        public void SetGraphicsCard()
        {
            _computer.GraphicsCard = "NVIDIA GeForce RTX 3080";
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }

    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetCPU()
        {
            _computer.CPU = "Intel Core i5";
        }

        public void SetRAM()
        {
            _computer.RAM = "16GB";
        }

        public void SetStorage()
        {
            _computer.Storage = "512GB SSD";
        }

        public void SetGraphicsCard()
        {
            _computer.GraphicsCard = "Integrated Graphics";
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }

    public class Director
    {
        private IComputerBuilder _builder;

        public void SetBuilder(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructComputer()
        {
            _builder.SetCPU();
            _builder.SetRAM();
            _builder.SetStorage();
            _builder.SetGraphicsCard();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Director director = new Director();

            // Building a Gaming Computer
            IComputerBuilder gamingBuilder = new GamingComputerBuilder();
            director.SetBuilder(gamingBuilder);
            director.ConstructComputer();
            Computer gamingComputer = gamingBuilder.GetComputer();
            Console.WriteLine("Gaming Computer Configuration:");
            Console.WriteLine(gamingComputer);

            // Building an Office Computer
            IComputerBuilder officeBuilder = new OfficeComputerBuilder();
            director.SetBuilder(officeBuilder);
            director.ConstructComputer();
            Computer officeComputer = officeBuilder.GetComputer();
            Console.WriteLine("\nOffice Computer Configuration:");
            Console.WriteLine(officeComputer);
        }
    }




}