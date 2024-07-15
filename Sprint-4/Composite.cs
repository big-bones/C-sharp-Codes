using System;
using System.Collections.Generic;

namespace Composite
{

    public interface IGeneral
    {
        int CalculatePrice();
    }

    public class Product : IGeneral
    {
        public int Price { get; set; }

        public Product() { }    

        public Product(int price) { 
            Price = price;  
        }   

        public int CalculatePrice()
        {
            return this.Price;
        }

    }

    class Box : IGeneral
    {
        public List<IGeneral> elements = new List<IGeneral>();
        public int CalculatePrice()
        {
            int Price = 0;
            foreach (IGeneral element in elements)
            {
                Price += element.CalculatePrice();
            }
            return Price;
        }

        public void AddElement(IGeneral element)
        {
            elements.Add(element);
        }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Product cable = new Product(10);
            Product headPhones = new Product(10);
            Product hammer = new Product(5);
            Box electronics = new Box();
            electronics.AddElement(cable);
            electronics.AddElement(headPhones);
            Box amazonParcel = new Box();
            amazonParcel.AddElement(electronics);
            amazonParcel.AddElement(hammer);
            Console.WriteLine(amazonParcel.CalculatePrice());
        }
    }
}