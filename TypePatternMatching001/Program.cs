using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypePatternMatching001
{
    class Program
    {
        static void Main(string[] args)
        {

            IfMattching(9);
            IfMattching(19.9);
            Console.WriteLine("-----------------------");
            SwitchMatching(null);
            SwitchMatching(DateTime.Now);
            SwitchMatching(new object());

            Console.ReadLine();
        }


        static void IfMattching(object o)
        {
            //if (o is int)
            //{
            //    var x = (int)o;
            //}

            if (o is int y)
            {
                Console.WriteLine($"int {y}");
            }
            else
            {
                Console.WriteLine("other type");
            }
        }

        static void SwitchMatching(object o)
        {
            switch (o)
            {
                case int x:
                    Console.WriteLine($"int {x}");
                    return;
                case DateTime y:
                    Console.WriteLine($"DateTime {y}");
                    return;
                case null:
                    Console.WriteLine($"null value");
                    return;
                default:
                    Console.WriteLine("other type");
                    return;
            }
        }
    }
}
