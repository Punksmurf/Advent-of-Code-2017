using System;
using System.IO;
using System.Linq;

namespace Day11
{
    public class Solution2
    {
        public string Run() {
            var x = 0;
            var y = 0;
            var z = 0;

            var farthest = 0;

            var moves = File.ReadAllText("input.txt").Split(',').Select(m => m.Trim());

            foreach (var move in moves) {
                switch(move) {
                    case "n":
                        y++;
                        z--;
                        break;
                    case "ne":
                        x++;
                        z--;
                        break;
                    case "se":
                        x++;
                        y--;
                        break;
                    case "s":
                        y--;
                        z++;
                        break;
                    case "sw":
                        x--;
                        z++;
                        break;
                    case "nw":
                        x--;
                        y++;
                        break;
                }

                if (x + y + z != 0) {
                    throw new Exception($"{x} + {y} + {z} = {x+y+z} but must equal 0");
                }
                farthest = Math.Max(
                    Math.Max(farthest, Math.Abs(x)), 
                    Math.Max(Math.Abs(y), Math.Abs(z)));

            }
            return farthest.ToString();

        }
    }
}
