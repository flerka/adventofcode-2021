using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task6
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/3/ task
        /// </summary>
        public static int Function(List<short[]> input)
        {
            List<short[]> filteredItems = input;
            for (var i=0; i <input.Count && filteredItems.Count > 1; i++)
            {
                var compare = filteredItems.Sum(x => x[i]) >= Math.Round((double)filteredItems.Count / 2d, MidpointRounding.ToPositiveInfinity) ? (short)1 : (short)0;
                filteredItems = filteredItems.Where(item => item[i] == compare).ToList();
            }

            var filteredNegativeItems = input;
            for (var i = 0; i < input.Count && filteredNegativeItems.Count > 1; i++)
            {
                var compare = filteredNegativeItems.Sum(x => x[i]) < Math.Round((double)filteredNegativeItems.Count / 2d, MidpointRounding.ToPositiveInfinity) ? (short)1 : (short)0;
                filteredNegativeItems = filteredNegativeItems.Where(item => item[i] == compare).ToList();
            }

            var first = Convert.ToInt16(string.Join("", filteredItems[0]),2);
            var second = Convert.ToInt16(string.Join("", filteredNegativeItems[0]), 2);

            return first * second;
        }
    }
}