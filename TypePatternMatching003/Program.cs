using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypePatternMatching003
{
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<object>
            {
                { 0, 9, "矩形1" },
                { 10, 11, "矩形2" },
                { 3, 3, "矩形3" },
                { 10, 10, "矩形4"},
                new Circle () { Radius = 4, Name = "圓形"},
                new Line (),
                new object(),
                null,
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(Display(shape));
            }

            Console.ReadLine();
        }

        static string Display<T>(T shape) where T : class
        {
            switch (shape)
            {
                case null:
                    return "請不要亂丟 null 進來";
                case Rectangle r when r.Width <= 0 || r.Height <= 0:
                    return "矩形長寬不符規定";
                case Rectangle r when r.Width * r.Height < 10:
                    return "小矩形";
                case Rectangle r when r.Width * r.Height > 100:
                    return "大矩形";
                case Rectangle _:
                    return "中矩形";
                case IShape _:
                    return "不是矩形";
                default:
                    return "甚麼玩意";
            }
        }
    }

    /// <summary>
    /// 純粹為了偷懶
    /// </summary>
    static class ShapeExtensions
    {
        public static void Add(this ICollection<object> shapes, double width, double height, string name)
        {
            shapes.Add(new Rectangle { Width = width, Height = height, Name = name });
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
