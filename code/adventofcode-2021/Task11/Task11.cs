using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task11
{
    public record struct Point(int x, int y);

    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/6/ task
        /// </summary>
        public static int Function(List<int> input)
        {
            var data = GetInitializedDictionary(input);

            for (int day = 0; day < 80; day++)
            {
                var toProduceNew = data[0];
                data[0] = 0;

                for (int j = 1; j <= 8; j++)
                {
                    data[j - 1] = data[j];        
                }

                data[6] += toProduceNew;
                data[8] = toProduceNew;
            }

            return data.Values.Sum();
        }

        private static Dictionary<int, int> GetInitializedDictionary(List<int> input)
        {
            var data = input.GroupBy(item => item).ToDictionary(item => item.Key, item => item.Count());

            for (int i = 0; i <= 8; i++)
            {
                if (!data.ContainsKey(i))
                {
                    data[i] = 0;
                }
            }

            return data;
        }
    }
}