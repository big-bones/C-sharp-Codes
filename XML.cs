using System;
using System.IO;
using System.Xml.Serialization;

public class Person
{
    public string Name { get; set; }
    [XmlIgnore] // Ignore Age field during XML serialization
    public int Age { get; set; }
    public string[] Hobbies { get; set; }
}

class Program
{
    static void Main()
    {
        // Serialization
        var person = new Person
        {
            Name = "John Doe",
            Age = 30,
            Hobbies = new[] { "Reading", "Hiking", "Gaming" }
        };

        // Serialize with XmlSerializer
        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        using (StringWriter stringWriter = new StringWriter())
        {
            serializer.Serialize(stringWriter, person);
            string xmlString = stringWriter.ToString();

            Console.WriteLine("Serialized XML:");
            Console.WriteLine(xmlString);
            Console.WriteLine();
        }

        // Deserialization
        string xmlData = @"<Person>
                              <Name>John Doe</Name>
                              <Age>30</Age>
                              <Hobbies>
                                  <string>Reading</string>
                                  <string>Hiking</string>
                                  <string>Gaming</string>
                              </Hobbies>
                           </Person>";

        using (StringReader stringReader = new StringReader(xmlData))
        {
            Person deserializedPerson = (Person)serializer.Deserialize(stringReader);

            Console.WriteLine("Deserialized Object:");
            Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}, Hobbies: {string.Join(", ", deserializedPerson.Hobbies)}");
        }
    }
}
