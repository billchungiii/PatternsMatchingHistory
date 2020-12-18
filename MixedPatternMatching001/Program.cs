using System;
using System.Collections.Generic;

namespace MixedPatternMatching001
{
    class Program
    {
        static void Main(string[] _)
        {
            foreach (var p in Create())
            {
                // 混用 position 和 property patterns
                if (p is (string firstName, "Chung", _) { Address: { City: string city, ZipCode: "100" } })
                {
                    Console.WriteLine($"Hi {firstName} from {city}");
                }
            }
            Console.ReadLine();
        }

        static List<Person> Create() => new List<Person>()
            {
                { "Bill" , "Chung" , "台北", "100"  },
                { "Tom", "Chung", "台中", "200" },
                { "John" ,  "Lee" , "台北" , "100"},
                { "John" ,  "Lee" , "台中" , "200"},
            };
    }

    static class PersonExtensions
    {
        public static void Add(this ICollection<Person> people, string firstName, string lastName, string city, string zipCode)
        {
            people.Add(new Person { FirstName = firstName, LastName = lastName, Address = new Address { City = city, ZipCode = zipCode } });
        }
    }

    class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        public void Deconstruct(out string firstName, out string lastName, out Address address)
        {
            firstName = FirstName;
            lastName = LastName;
            address = Address;
        }
    }


    class Address
    {
        public string City { get; set; }

        public string ZipCode { get; set; }

    }
}
