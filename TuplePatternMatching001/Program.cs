using System;
using System.Collections.Generic;

namespace TuplePatternMatching001
{
    class Program
    {
        static void Main(string[] _)
        {
            foreach (var (first, second) in Create())
            {
                Console.WriteLine(GetResult(first,second));

            }
            Console.ReadLine();
        }

        static Result GetResult(Morra x, Morra y) => (x, y) switch
        {
            (Morra.剪刀, Morra.布) => Result.勝,
            (Morra.布, Morra.石頭) => Result.勝,
            (Morra.石頭, Morra.剪刀) => Result.勝,            
            _ when x.Equals(y) => Result.平,
            _ => Result.敗
        };

        static List<(Morra first, Morra second)> Create()
        {
            return new List<(Morra first, Morra second)>
            {
                ( Morra.剪刀, Morra.布 ),
                ( Morra.布 , Morra.石頭 ),
                ( Morra.石頭 , Morra.剪刀 ),
                ( Morra.剪刀 , Morra.剪刀 ),
                ( Morra.石頭 , Morra.石頭 ),
                ( Morra.布  , Morra.布 ),
                ( Morra.剪刀, Morra.石頭 ),
                ( Morra.布 , Morra.剪刀 ),
                ( Morra.石頭 , Morra.布 ),

            };
        }
    }

    enum Morra
    {
        剪刀,
        石頭,
        布
    }

    enum Result
    {
        勝,
        敗,
        平
    }
}
