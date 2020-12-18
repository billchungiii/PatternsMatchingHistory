using System;
using System.Collections.Generic;

namespace PropertyPatternMatching001
{
    class Program
    {
        static void Main(string[] _)
        {
            foreach (var p in Create())
            {

                if (p is { FirstName: string firstName, LastName: "Chung", Address: { City: string city, ZipCode: "100" } })
                {
                    Console.WriteLine($"Hi {firstName} from {city}");
                }
            }
            Console.ReadLine();
        }



        static List<Person> Create()
        {
            return new List<Person>()
            {
                { "Bill" , "Chung" , "台北", "100"  },
                { "Tom", "Chung", "台中", "200" },
                { "John" ,  "Lee" , "台北" , "100"},
                { "John" ,  "Lee" , "台中" , "200"},
            };
        }
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

    }


    class Address
    {
        public string City { get; set; }

        public string ZipCode { get; set; }

    }
}
