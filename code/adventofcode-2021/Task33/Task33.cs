using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task33
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/17/ task
        /// </summary>
        public static int Function((int start, int end) x, (int start, int end) y)
        {
            var n = Math.Abs(Math.Min(y.start, y.end)) - 1;
            return n * (n + 1) / 2;
        }
    }
}