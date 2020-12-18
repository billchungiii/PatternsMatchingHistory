using System;
using System.Collections.Generic;

namespace SimpleTypePatternMatching001
{
    class Program
    {
        static void Main(string[] _)
        {
            var shapes = new List<IShape>{ new Rectangle { Width = 10, Height = 10, Name ="矩形"  },
                                           new Circle { Radius = 3.2 , Name= "圓形"},
                                           new Line { Length = 4.9 , Name="直線"},
                                           null };
            foreach (var shape in shapes)
            {
                Console.WriteLine(GetShape(shape));
            }
        }

        static string GetShape(IShape shape) => shape switch
        {
            null => "null",
            Rectangle => "矩形",
            Circle => "圓形",
            _ => "不知道是啥"
        };
    }

    interface IShape
    {
        string Name { get; set; }
    }

    class Rectangle : IShape
    {
        public string Name { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

    }
    class Circle : IShape
    {
        public string Name { get; set; }

        public double Radius { get; set; }
    }

    class Line : IShape
    {
        public string Name { get; set; }

        public double Length { get; set; }
    }
}
