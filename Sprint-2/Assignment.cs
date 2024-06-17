using System;
using System.Collections;
using System.Collections.Generic;

class Person {
    public Person(){
        
    }
    public string Name {get;set;}
     public string Email {get;set;}
    public DateTime DateOfBirth {get;set;}
    public string Passport {get;set;}
    public string Country {get;set;}
    public override string ToString(){
        return $"{Name},{Country}";
    }
}

class PersonComparer : IEqualityComparer<Person>{
    public bool Equals(Person a,Person b){
        if((a.Name == b.Name) && (a.Email == b.Email) && (a.Country == b.Country) ){
            return true;
        }else{
            return false;
        }
    }
    public int GetHashCode(Person p){
        return 1;
    }
}



class Visa{
    public List<Person> FindDuplicates(List<Person>lp){
        HashSet<Person> hs = new HashSet<Person>(new PersonComparer());
        foreach(Person p in lp){
            hs.Add(p);
        }
        List<Person> unique = new List<Person>(hs);
        return unique;
    }
    public Dictionary<string,List<Person>> FilterByCountry(List<Person>people,Dictionary<string,string>countryMap,List<string>shortForms){
        Dictionary<string,List<Person>> FilteredList = new Dictionary<string,List<Person>>();
        try{
        foreach(Person p in people){
            if(shortForms.Contains(countryMap[p.Country])){
                if(!FilteredList.ContainsKey(countryMap[p.Country])){
                    FilteredList[countryMap[p.Country]] = new List<Person>();
                    FilteredList[countryMap[p.Country]].Add(p);
                }else{
                 FilteredList[countryMap[p.Country]].Add(p);   
                }
            }
        }
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
        return FilteredList;
    }
}


class GenericAssignment{
  static void Main() {
       List<Person> people = new List<Person>
        {
            new Person { Name = "John Smith", Email = "john.smith@example.com", DateOfBirth = new DateTime(1980, 1, 15), Passport = "A1234567", Country = "USA" },
            new Person { Name = "Emma Johnson", Email = "emma.johnson@example.com", DateOfBirth = new DateTime(1990, 5, 23), Passport = "B7654321", Country = "Canada" },
            new Person { Name = "Raj Patel", Email = "raj.patel@example.com", DateOfBirth = new DateTime(1985, 3, 10), Passport = "C9876543", Country = "India" },
            new Person { Name = "Olivia Brown", Email = "olivia.brown@example.com", DateOfBirth = new DateTime(1992, 7, 30), Passport = "D2345678", Country = "England" },
            new Person { Name = "Liam Davis", Email = "liam.davis@example.com", DateOfBirth = new DateTime(1975, 12, 5), Passport = "E3456789", Country = "USA" },
            new Person { Name = "Sophia Martinez", Email = "sophia.martinez@example.com", DateOfBirth = new DateTime(1988, 4, 18), Passport = "F4567890", Country = "Canada" },
            new Person { Name = "Daniel Wilson", Email = "daniel.wilson@example.com", DateOfBirth = new DateTime(1995, 11, 9), Passport = "G5678901", Country = "India" },
            new Person { Name = "Ava Garcia", Email = "ava.garcia@example.com", DateOfBirth = new DateTime(1982, 9, 14), Passport = "H6789012", Country = "England" },
            new Person { Name = "Michael Lee", Email = "michael.lee@example.com", DateOfBirth = new DateTime(1978, 6, 25), Passport = "I7890123", Country = "USA" },
            new Person { Name = "Michael Lee", Email = "michael.lee@example.com", DateOfBirth = new DateTime(1987, 2, 3), Passport = "J8901234", Country = "USA" },
            new Person { Name = "Carlos Silva", Email = "carlos.silva@example.com", DateOfBirth = new DateTime(1983, 4, 20), Passport = "K1234567", Country = "Brazil" },
            new Person { Name = "Ana Costa", Email = "ana.costa@example.com", DateOfBirth = new DateTime(1991, 8, 14), Passport = "L2345678", Country = "Portugal" },
            new Person { Name = "Miguel Pereira", Email = "miguel.pereira@example.com", DateOfBirth = new DateTime(1985, 10, 25), Passport = "M3456789", Country = "Brazil" },
            new Person { Name = "Maria Sousa", Email = "maria.sousa@example.com", DateOfBirth = new DateTime(1987, 6, 19), Passport = "N4567890", Country = "Portugal" }
        };
        
        Visa vs = new Visa();
        // foreach(Person  p in  vs.FindDuplicates(people)){
        //     Console.WriteLine(p);
        // }
        List<string> shortForms = new List<string>();
        Dictionary<string,string> countryMap = new Dictionary<string,string>();
        foreach(Person p in people){
            string firstTwo = p.Country.Substring(0,2);
            if(p.Country.Equals("Portugal") || p.Country.Equals("Brazil")){
                continue;
            }
            firstTwo = firstTwo.ToUpper();
            if(!shortForms.Contains(firstTwo)){
                countryMap.Add(p.Country , firstTwo);
                shortForms.Add(firstTwo);
            }
        }
        foreach(string s in shortForms){
            Console.Write(s + " ");
        }
        Console.WriteLine();
        foreach(KeyValuePair<string,string> val in countryMap){
            Console.WriteLine(val.Key + " " + val.Value);
        }
        foreach(KeyValuePair<string,List<Person>> filter in vs.FilterByCountry(people,countryMap,shortForms)){
            Console.WriteLine(filter.Key);
            foreach(Person p in filter.Value){
                Console.WriteLine(p);
            }
            Console.WriteLine();
        }
  }
}