using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    public static class Shared
    {
        public static IList<byte> KnotHash(string input)
        {
            var inputValues = input.Select(c => (byte)c).Concat(new byte[] { 17, 31, 73, 47, 23 });

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
                      .Select(chunk => (byte)chunk.Aggregate((prev, next) => prev ^ next));

            return sparse.ToList();
        }
    }
}
