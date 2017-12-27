using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Day19
{
    public class Solution2
    {
        public string Run() {

            var tubes = new Tubes(File.ReadAllText("input.txt"));

            // return tubes.GetTubes().Sum(t => t.Length).ToString();

            var sw = Stopwatch.StartNew();

            var solution = "";
            var steps = 0;

            foreach (var tube in tubes.GetTubes()) {
                solution += String.Concat(tube.Letters);
                steps += tube.Length;
            }



            Console.Write($"Solution: {solution}, steps: {steps}, time: {sw.Elapsed}");


            return steps.ToString();
        }
    }
}
