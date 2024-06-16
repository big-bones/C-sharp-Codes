using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

public delegate void EventHandlerDelegate<T1, ArgumentTypes >(T1 a, ArgumentTypes b);

public class ArgumentTypes<T>
{
    public T Value { get; }

    public ArgumentTypes(T val)
    {
        Value = val;
    }

    public override string ToString()
    {
        return "The entity has a value " + Value.ToString();
    }

}

class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }

    public override string ToString()
    {
        return $"The name of the movie is {Name} and the cost is {Cost}";
    }

}

class Movies
{
    public string Genre { get; set; }
    public string Title { get; set; }
    public double Rating { get; set; }

    public override string ToString()
    {
        return $"The name of the movie is {Title} and the rating is {Rating}";
    }

}


class EntityCollection<T1, T2> : ArrayList
{
    public string Category { get; set; }

    public EventHandlerDelegate<EntityCollection<T1, T2>, ArgumentTypes<T2>> OnAdditionEvent;
    public EventHandlerDelegate<EntityCollection<T1, T2>, ArgumentTypes<T2>> OnRemovalEvent;

    public EntityCollection(string Category)
    {
        this.Category = Category;
    }

    public void AddItem(T1 item, T2 o)
    {
        base.Add(item);
        OnAdditionEvent?.Invoke(this, new ArgumentTypes<T2>(o));
    }

    public void RemoveItem(T1 item,T2 o)
    {
        base.Remove(item);
        OnRemovalEvent?.Invoke(this, new ArgumentTypes<T2>(o));
    }

}

class Program
{
    static void OnAddMethod<T1, T2, T>(EntityCollection<T1, T2> a, ArgumentTypes<T> b)
    {
        Console.Write("A new entity has been added,");
        Console.Write($"Of defining type \"{b.Value.GetType().Name}\",");
        Console.WriteLine(b);
    }

    static void OnRemoveMethod<T1,T2,T>(EntityCollection<T1,T2>a , ArgumentTypes<T> b)
    {
        Console.Write("A new entity has been removed,");
        Console.Write($"Of defining type \"{b.Value.GetType().Name}\",");
        Console.WriteLine(b);
    }

    static void Main(string[] args)
    {
        EntityCollection<Movies, double> e = new EntityCollection<Movies, double>("Movie Category");
        Movies m = new Movies { Genre = "Drama" , Rating = 8.3  , Title = "POBW"};

        e.OnAdditionEvent = OnAddMethod;
        e.OnRemovalEvent = OnRemoveMethod;
        e.AddItem(m,m.Rating);
        e.RemoveItem(m,m.Rating);

        EntityCollection<Product, string> pc = new EntityCollection<Product, string>("Product Category");
        Product p = new Product { Cost = 200,ID = 1,Name = "Mango"};

        pc.OnAdditionEvent = OnAddMethod;
        pc.OnRemovalEvent = OnRemoveMethod;
        pc.AddItem(p,p.Name);
        pc.RemoveItem(p,p.Name);

    }
}

