﻿using System;
using System.Collections.Generic;

namespace Day10
{
    public static class Extensions
    {
        public static IList<int> ReverseWrapped(this IList<int> list, int start, int end) 
        {

            while (start < end)
            {
                list.Swap(start, end);
                start++;
                end--;
            }
        
            return list;
        }

        public static IList<int> Swap(this IList<int> list, int a, int b)
        {
            //Console.WriteLine($"Swap {a}, {b} ({a % list.Count}, {b % list.Count})");

            a %= list.Count;
            b %= list.Count;

            var t = list[a];
            list[a] = list[b];
            list[b] = t;

            return list;
        }
    }
}
