using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day10
{
    public class Solution2
    {
        public string Run(string input) {

            var inputValues = input.Select(c => (int)c).Concat(new int[] { 17, 31, 73, 47, 23 });

            var list = Enumerable.Range(0, 256).ToList();
            var pos = 0;
            var skip = 0;

            for (var round = 0; round < 64; round++)
            {
                foreach (var length in inputValues)
                {
                    list.ReverseWrapped(pos, pos + length - 1);
                    pos = (pos + length + skip) % list.Count;
                    skip++;
                }
            }

            var sparse = Enumerable.Range(0, 16)
                      .Select(i => list.Skip(i * 16).Take(16))
                                   .Select(chunk =>
                                   {
                                       return chunk
                    .Aggregate((prev, next) => prev ^ next);
            });

            var sparseString = String.Join("", sparse.Select(b => b.ToString("x2")));

            return sparseString;
        }

    }


}
