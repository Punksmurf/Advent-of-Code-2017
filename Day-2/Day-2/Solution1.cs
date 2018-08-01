using System;
using System.IO;
using System.Linq;

namespace Day2
{
    public class Solution1
    {
        public string Run() {
            var input = File.ReadLines("input.txt");

            var checksum = 0;

            foreach (var line in input) {
                var values = line.Split("\t").Select(int.Parse);
                checksum += values.Max() - values.Min();
            }


            return checksum.ToString();
        }
    }
}
