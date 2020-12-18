using System;
using System.Collections.Generic;

namespace LogicalPatternMatching001
{
    class Program
    {
        static void Main(string[] _)
        {

            foreach (var student in Create())
            {
                Console.WriteLine($"{student.Name} is {GetGrades(student)}");
            }

            foreach (var person in Create())
            {
                if (person is Student { Gender: Gender.Male , Score: >= 60, Name: string Name  })
                {
                    Console.WriteLine($"及格的男生:  {Name}");
                }
            }
        }

        static string GetGrades(Student student) => student.Score switch
        {
            >= 90 or < 10 => "特別高或特別低",
            _ => "一般"
        };




        static List<Student> Create() => new()
        {
                       new Student{ Name = "魯夫",  Gender = Gender.Male , Score= 5},
                       new Student{ Name = "妮可羅賓",  Gender = Gender.Female , Score= 82},
                       new Student{ Name = "娜美",   Gender = Gender.Female, Score= 70 },
                       new Student{ Name = "騙人布" ,Gender = Gender.Male, Score= 55 },
                       new Student{ Name = "香吉士",  Gender = Gender.Male, Score= 58 },
                       new Student{ Name = "喬巴",   Gender = Gender.Male, Score= 67 },
                       new Student{ Name = "布魯克",  Gender = Gender.Male, Score= 99 },
                       new Student{ Name = "索隆",  Gender = Gender.Male, Score= 80 },

                   };

    }

    interface IPerson
    {
        Guid ID { get; set; }
        string Name { get; set; }
    }

    class Teacher : IPerson
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
    }

    class Student : IPerson
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public bool IsPassed
        {
            get { return Score > 59; }
        }

        public Gender Gender { get; set; }

        public int Score { get; set; }
    }

    public enum Gender
    {
        Male, Female
    }
}
