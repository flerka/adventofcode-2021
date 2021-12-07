using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task13
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/7/ task
        /// </summary>
        public static long Function(List<int> input)
        {
            input.Sort();
            var median = input.Count % 2 != 0 ?
                input[input.Count / 2] :
                (input[input.Count / 2] + input[input.Count / 2 - 1]) / 2;

            return input.Select(x => Math.Abs(median - x)).Sum();
        }
    }
}