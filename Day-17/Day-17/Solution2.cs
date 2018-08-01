using System;
using System.Collections.Generic;

namespace Day17
{
    public class Solution2
    {
        public string RunNaive(int stepSize = 3) {
            var buffer = new LinkedList<int>();

            var position = buffer.AddLast(0);

            for (var counter = 1; counter <= 50_000_000; counter++) {
                if (counter % 100_000 == 0) Console.WriteLine(counter);
                for (var step = 0; step < stepSize; step++)
                {
                    position = position.Next ?? buffer.First;
                }
                position = buffer.AddAfter(position, counter);
            }

            position = buffer.First;
            while (position.Value != 0) position = position.Next;

            return position.Next.Value.ToString();
        }

        public string Run(int stepSize = 3) {
            //stepSize = 3;

            var lastValueAfter0 = 0;
            var position = 0;

            for (var counter = 1; counter <= 50_000_000; counter++) {
                position = WillInsertAfter(counter, position, stepSize) + 1;
                if (position == 1) {
                    Console.WriteLine("Inserting on position 1: " + counter);
                    lastValueAfter0 = counter;
                }
            }

            return lastValueAfter0.ToString();
        }

        public int WillInsertAfter(int listLength, int currentPosition, int stepSize) {
            return (currentPosition + stepSize) % listLength;
        }
    }
}
