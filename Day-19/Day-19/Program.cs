using System;
using System.IO;
using System.Threading;
using Day19;

namespace Day_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1: " + new Solution1().Run());
            Console.WriteLine("2: " + new Solution2().Run());
        }
    }
}
