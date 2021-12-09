using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task17
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/9/ task
        /// </summary>
        public static int Function(List<List<int>> input)
        {
            Dictionary<(int i, int j), int> data = new();
            input.Aggregate(0, (index1, item1) =>
            {
                item1.Aggregate(0, (index2, item2) =>
                {
                    data[(index1, index2)] = item2;
                    return index2 + 1;
                });
                return index1 + 1;
            });

            return data.Keys.Where(key => 
                (!data.ContainsKey((key.i - 1, key.j)) || data[(key.i - 1, key.j)] > data[key]) &&
                (!data.ContainsKey((key.i + 1, key.j)) || data[(key.i + 1, key.j)] > data[key]) &&
                (!data.ContainsKey((key.i, key.j -1 )) || data[(key.i, key.j - 1)] > data[key]) &&
                (!data.ContainsKey((key.i, key.j + 1)) || data[(key.i, key.j + 1)] > data[key]))
                .Sum(key => data[key] + 1);

        }
    }
}