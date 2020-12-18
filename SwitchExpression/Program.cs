using System;
using System.Collections.Generic;

namespace SwitchExpression
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
                try
                {
                    Console.WriteLine($"{shape?.Name} 的面積是 {GetArea(shape)}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                try
                {
                    Console.WriteLine($"{shape?.Name} 的面積是 {GetArea2(shape)}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadLine();
        }

        // null 的位置要正確
        static double GetArea(IShape shape) => shape switch
        {
            null => throw new ArgumentNullException(nameof(shape), "不要傳 null"),
            Rectangle r => r.Width * r.Height,
            Circle c => Math.Pow(c.Radius, 2),
            _ => throw new ArgumentException($"{shape.Name} 形狀不符"),

        };


        //這樣寫也行
        static double GetArea2(IShape shape)
        {
            var result = shape switch
            {
                null => throw new ArgumentNullException(nameof(shape), "不要傳 null"),
                Rectangle r => r.Width * r.Height,
                Circle c => Math.Pow(c.Radius, 2),
                _ => throw new ArgumentException($"{shape.Name} 形狀不符"),
            };
            return result;
        }
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
