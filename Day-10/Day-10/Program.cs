using System;
using System.Linq;
using Day10;

namespace Day_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "157,222,1,2,177,254,0,228,159,140,249,187,255,51,76,30";
            Console.WriteLine("1: " + new Solution1().Run(input.Split(",").Select(int.Parse)));
            Console.WriteLine("2: " + new Solution2().Run(input));
        }
    }
}
