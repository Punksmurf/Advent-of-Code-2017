using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    public class Solution2
    {
        public string Run(string input) {
            //input = "flqrgnkx";

            var diskRaw = Enumerable.Range(0, 128).Select(r => CreateRow(input, r)).ToList();
            var diskRegions = new int[128, 128];

            for (var r = 0; r < 128; r++) {
                for (var c = 0; c < 128; c++) {
                    if (diskRaw[r][c]) {
                        diskRegions[r, c] = -1;
                    }
                }
            }

            var regionCount = 0;
            for (var r = 0; r < 128; r++) {
                for (var c = 0; c < 128; c++) {
                    if (diskRegions[r, c] == -1) {
                        Console.WriteLine($"New region at {r}, {c} - {regionCount + 1}");
                        FillInRegion(diskRegions, r, c, ++regionCount);
                    }
                }
            }

            for (var r = 0; r < 8; r++) {
                for (var c = 0; c < 8; c++)
                {
                    Console.Write(diskRegions[r, c]);
                }
                Console.WriteLine();
            }

            return regionCount.ToString();
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

        void FillInRegion(int[,] regions, int row, int col, int region)
        {
            regions[row, col] = region;
            var nbs = GetNeighbors(row, col);
            foreach (var nb in nbs)
            {
                if (regions[nb.row, nb.col] == -1)
                {
                    Console.WriteLine($"{region} -> {nb.row},{nb.col}");
                    FillInRegion(regions, nb.row, nb.col, region);
                }
            }
        }

        (int row, int col)[] GetNeighbors(int row, int col) {
            var retVal = new List<(int x, int y)>(4);
            //for (var xx = row-1; xx <= row+1; xx++) {
            //    for (var yy = col-1; yy <= col+1; yy++) {
            //        if (xx >= 0 && xx < 128 && yy >= 0 && yy < 128 && !(xx == row && yy == col)) {
            //            retVal.Add((xx, yy));
            //        }
            //    }
            //}

            // no diagonals!
            if (row > 0) {
                retVal.Add((row - 1, col));
            }
            if (row < 127) {
                retVal.Add((row + 1, col));
            }

            if (col > 0) {
                retVal.Add((row, col - 1));
            }
            if (col < 127) {
                retVal.Add((row, col + 1));
            }

            return retVal.ToArray();
        }
    }
}
