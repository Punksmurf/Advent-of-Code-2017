using System;
using System.Collections;
using System.Linq;

namespace Day14
{
    public class Solution1
    {
        public string Run(string input) {
            //input = "flqrgnkx";

            var disk = Enumerable.Range(0, 128).Select(r => CreateRow(input, r)).ToList();

            for (var r = 0; r < 8; r++) {
                for (var c = 0; c < 16; c++) {
                    Console.Write(disk[r][c] ? "#" : ".");
                }
                Console.WriteLine(" -->");
            }

            var count = 0;
            for (var r = 0; r < 128; r++) {
                for (var c = 0; c < 128; c++) {
                    if (disk[r][c]) count++;
                }
            }

            return count.ToString();
        }

        BitArray CreateRow(string input, int rowNumber) {
            var bits = new BitArray(Shared.KnotHash($"{input}-{rowNumber}").ToArray());

            var row = new BitArray(128);
            for (var x = 0; x < 128; x += 8) {
                for (var y = 0; y < 8; y ++) {
                    row[x + y] = bits[x + (7 - y)];
                }
            }

            return row;

        }
    }
}
