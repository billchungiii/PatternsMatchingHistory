using System;
using System.Collections.Generic;

namespace RelationalPatternMatching001
{
    class Program
    {
        static void Main(string[] _)
        {
            var shapes = new List<Rectangle>
            {
                new Rectangle {Width = 10, Height = 9 },
                new Rectangle {Width = 11, Height = 12 },
                new Rectangle {Width = 2, Height = 3 },
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(Display8(shape));
            }

            foreach (var shape in shapes)
            {
                Console.WriteLine(Display9(shape));
            }

            Console.ReadLine();
        }

        // C# 8
        static string Display8(Rectangle rect) => rect.GetArea() switch
        {
            double area when area < 10 => "小矩形",
            double area when area >= 100 => "大矩形",
            _ => "中矩形"
        };


        // C# 9
        static string Display9(Rectangle rect) => rect.GetArea() switch
        {
            < 10 => "小矩形",
            >= 100 => "大矩形",
            _ => "中矩形"
        };
    }
    class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double GetArea()
        {
            return Width * Height;
        }
    }
}
