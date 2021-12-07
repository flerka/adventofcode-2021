using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task14
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/7/ task
        /// </summary>
        public static long Function(List<int> input)
        {
            var avg = (int)Math.Round((decimal)input.Sum() / (decimal)input.Count);
            // get sum of nth items of arithmetic progression with step 1
            return input.Select(x => (1 + Math.Abs(avg - x)) * (Math.Abs(avg - x)) / 2).Sum();
        }
    }
}