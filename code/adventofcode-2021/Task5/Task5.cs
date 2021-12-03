using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace adventofcode_2021.Task5
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/3/ task
        /// </summary>
        public static int Function(List<short[]> input)
        {
            var resVector = input.Aggregate(
                new Vector<short>(0),
                (r, next) => new Vector<short>(next, 0) + r);
            var result = new short[16];
            resVector.CopyTo(result, 0);

            var first = Convert.ToInt16(
                result.Aggregate(string.Empty, (r, x) => r + (x > input.Count / 2 ? "1" : "0")),
                2);Convert.ToInt16(
                result.Aggregate(string.Empty, (r, x) => r + (x > input.Count / 2 ? "1" : "0")),
                2);

            // take only last 12 bits
            var inverted = ~first & 0x00000FFF;

            return first * inverted;
        }
    }
}