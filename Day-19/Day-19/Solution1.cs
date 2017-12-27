using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Day19
{
    public class Solution1
    {
        public string Run() {

            var tubes = new Tubes(File.ReadAllText("input.txt"));
            var renderer = new Renderer(tubes);

            Console.CursorVisible = false;

            var sw = Stopwatch.StartNew();

            var solution = "";
            var steps = 0;

            var x = tubes.FindStartX();
            var y = 1;
            var from = Direction.NORTH;

            // so slow but fun
            var running = true;
            while (running) {
                steps++;
                renderer.Render(x, y);

                var c = tubes.GetLetter(x, y);
                if (c.HasValue) {
                    solution += c;
                }

                Console.CursorTop = Console.BufferHeight - 1;
                Console.CursorLeft = 0;
                Console.Write($"Solution: {solution}, steps: {steps}, time: {sw.Elapsed}");

                var direction = tubes.NextMove(x, y, from);
                switch(direction) {
                    case Direction.NORTH:
                        y--;
                        from = Direction.SOUTH;
                        break;
                    case Direction.SOUTH:
                        y++;
                        from = Direction.NORTH;
                        break;
                    case Direction.WEST:
                        x--;
                        from = Direction.EAST;
                        break;
                    case Direction.EAST:
                        x++;
                        from = Direction.WEST;
                        break;
                    case Direction.STOP:
                    default:
                        running = false;
                        break;
                                    
                }
                Thread.Sleep(25);
            }

            Console.CursorVisible = true;

            return solution;
        }
    }
}
