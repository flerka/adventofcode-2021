using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task15
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/8/ task
        /// </summary>
        public static int Function(IEnumerable<(List<string> alphabet, List<string> numbers)> items)
        {
            var result = 0;
            foreach(var pair in items)
            {
                foreach(var number in pair.numbers)
                {
                    result += number.Length switch
                    {
                        2 => 1,
                        4 => 1,
                        3 => 1,
                        7 => 1,
                        _ => 0
                    };
                }
            }

            return result;
        }
    }
}