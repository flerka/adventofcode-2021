using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task12
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/6/ task
        /// </summary>
        public static long Function(List<long> input)
        {
            var data = GetInitializedDictionary(input);

            for (long day = 0; day < 256; day++)
            {
                var toProduceNew = data[0];
                data[0] = 0;

                for (long j = 1; j <= 8; j++)
                {
                    data[(long)(j - 1)] = data[j];        
                }

                data[6] += toProduceNew;
                data[8] = toProduceNew;
            }

            return data.Values.Sum();
        }

        private static Dictionary<long, long> GetInitializedDictionary(List<long> input)
        {
            Dictionary<long, long> data = input.GroupBy(item => item).ToDictionary(item => item.Key, item => (long)item.Count());

            for (long i = 0; i <= 8; i++)
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