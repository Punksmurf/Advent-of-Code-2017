using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    public class Solution1
    {
        public string Run(IEnumerable<int> input) {

            //input = new int[] { 3, 4, 1, 5 };

            var list = Enumerable.Range(0, 256).ToList();
            var pos = 0;
            var skip = 0;

            //Console.WriteLine($"{String.Join(",", list)}; {pos}, {skip}");

            foreach (var length in input) {
                list.ReverseWrapped(pos, pos + length - 1);
                pos = (pos + length + skip) % list.Count;
                skip++;

                //Console.WriteLine($"{length} => {String.Join(",", list)}; {pos}, {skip}");

            }

            var checksum = list[0] * list[1];

            return checksum.ToString();
        }




    }
}
