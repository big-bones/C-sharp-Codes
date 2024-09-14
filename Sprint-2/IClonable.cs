using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

class Address : ICloneable
{
    public Address() { 
    
    }
    public string City { get; set; }
    public string Country { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}
class Person : ICloneable
{
    public Person()
    {

    }
    public int Id { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }

    public object Clone()
    {
        //Person cloneInstance = (Person)MemberwiseClone();
        //Address cloneAddress = (Address)Address.Clone();
        //cloneInstance.Address = cloneAddress;
        return this.MemberwiseClone();
    }

    public override string ToString()
    {
        return $"{Address.City},{Address.Country},{Id},{Name}";
    }

}

class Program
{
    static void Main()
    {
        Person p = new Person { Name = "Sarang", Id = 1, Address = new Address { City = "Akola", Country = "India" } };
        Person clone = (Person)p.Clone();
        clone.Id = 2;
        clone.Name = "Sarang2";
        clone.Address.Country = "Something";
        clone.Address.City = "Somewhere";
        Console.WriteLine(p);
        Console.WriteLine(clone);
    }
}