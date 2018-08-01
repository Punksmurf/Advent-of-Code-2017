using System;
using Day14;

namespace Day_14
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "amgozmfv";
            Console.WriteLine("1: " + new Solution1().Run(input));
            Console.WriteLine("2: " + new Solution2().Run(input));
        }
    }
}
