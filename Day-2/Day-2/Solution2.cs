using System;
using System.IO;
using System.Linq;

namespace Day2
{
    public class Solution2
    {
        public string Run() {
            var input = File.ReadLines("input.txt");

            var checksum = 0;

            foreach (var line in input) {
                var values = line.Split("\t").Select(int.Parse);
                foreach (var left in values) {
                    foreach (var right in values) {
                        if (left == right) continue;
                        if (left % right != 0) continue;
                        checksum += left / right;
                        break;
                    }
                }
            }


            return checksum.ToString();
        }
    }
}
