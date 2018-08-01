using System;
namespace Day15
{
    public class Solution2
    {
        public String Run() {
            //var genA = new Generator(65, 16807, 4);
            //var genB = new Generator(8921, 48271, 8);

            var genA = new Generator(289, 16807, 4);
            var genB = new Generator(629, 48271, 8);

            int matches = 0;

            for (var i = 0; i < 5e6; i++) {
                var valA = genA.Next() & 0xffff;
                var valB = genB.Next() & 0xffff;
                if (valA == valB)
                {
                    Console.WriteLine($"Match at {i}! {valA} = {valB}");
                    matches++;
                }

                //if (i % 100000 == 0) Console.WriteLine($"{i} - {matches}");
            }

            return matches.ToString();
        }
    }
}
