using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task1
{
    public class Solution
    {
        /// <summary>
        /// Solution for https://adventofcode.com/2021/day/1/ task
        /// </summary>
        public static int Function(IEnumerable<int> input)
        {
            return input.Skip(1).Zip(input, (curr, prev) => curr > prev ? 1 : 0).Sum();
        }
    }
}
