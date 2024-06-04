using System;
using System.Text.Json;
using Newtonsoft.Json;

public class Person
{
    public string Name { get; set; }
    [JsonIgnore] // Ignoring the Age field during serialization with Newtonsoft.Json
    public int Age { get; set; }
    public string[] Hobbies { get; set; }
}

class Program
{
    static void Main()
    {
        // Serialization using System.Text.Json
        var person = new Person
        {
            Name = "John Doe",
            Age = 30,
            Hobbies = new[] { "Reading", "Hiking", "Gaming" }
        };

        // Serialize with System.Text.Json and print
        string jsonStringSystemTextJson = JsonSerializer.Serialize(person);
        Console.WriteLine("Serialized with System.Text.Json:");
        Console.WriteLine(jsonStringSystemTextJson);
        Console.WriteLine();

        // Deserialize with System.Text.Json and print
        Person deserializedPersonSystemTextJson = JsonSerializer.Deserialize<Person>(jsonStringSystemTextJson);
        Console.WriteLine("Deserialized with System.Text.Json:");
        Console.WriteLine($"Name: {deserializedPersonSystemTextJson.Name}, Age: {deserializedPersonSystemTextJson.Age}, Hobbies: {string.Join(", ", deserializedPersonSystemTextJson.Hobbies)}");
        Console.WriteLine();


        // Serialization using Newtonsoft.Json
        var settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore // Ignore null values, including the Age field
        };

        // Serialize with Newtonsoft.Json and print
        string jsonStringNewtonsoftJson = JsonConvert.SerializeObject(person, settings);
        Console.WriteLine("Serialized with Newtonsoft.Json:");
        Console.WriteLine(jsonStringNewtonsoftJson);
        Console.WriteLine();

        // Deserialize with Newtonsoft.Json and print
        Person deserializedPersonNewtonsoftJson = JsonConvert.DeserializeObject<Person>(jsonStringNewtonsoftJson);
        Console.WriteLine("Deserialized with Newtonsoft.Json:");
        Console.WriteLine($"Name: {deserializedPersonNewtonsoftJson.Name}, Age: {deserializedPersonNewtonsoftJson.Age}, Hobbies: {string.Join(", ", deserializedPersonNewtonsoftJson.Hobbies)}");
    }
}
