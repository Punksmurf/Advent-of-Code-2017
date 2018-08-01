using System;
using System.IO;
using System.Linq;

namespace Day24
{
    public class Solution1
    {
        public string Run() {
            var input = File.ReadLines("input.txt").SkipLast(1).Select(line =>
            {
                var sides = line.Split('\n');
                return new Component(int.Parse(sides[0]), int.Parse(sides[1]));

            });
            return "done";
        }
    }
}
