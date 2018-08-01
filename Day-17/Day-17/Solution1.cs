using System;
using System.Collections.Generic;

namespace Day17
{
    public class Solution1
    {
        public string Run(int stepSize = 3) {

            var buffer = new LinkedList<int>();

            var position = buffer.AddLast(0);

            for (var counter = 1; counter <= 2017; counter++) {
                for (var step = 0; step < stepSize; step++)
                {
                    position = position.Next ?? buffer.First;
                }
                position = buffer.AddAfter(position, counter);

                //foreach (var node in buffer) {
                //    if (node == position.Value) {
                //        Console.Write('(');
                //    }
                //    Console.Write(node);
                //    if (node == position.Value)
                //    {
                //        Console.Write(')');
                //    }
                //    Console.Write(' ');
                //}
                //Console.WriteLine();
            }

            return position.Next.Value.ToString();
        }
    }
}
