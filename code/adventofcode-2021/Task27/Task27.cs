using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task27
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/14/ task
        /// </summary>
        public static int Function((string start, List<(string, string)> pattern) data)
        {
            var pairsCount = GetPairOccurances(data.start);
            var pattern = data.pattern.ToDictionary(x => x.Item1, x => x.Item2);
            Dictionary<string, int> byLetter = new();
            foreach(var ch in data.start)
            {
                byLetter[ch.ToString()] = byLetter.ContainsKey(ch.ToString()) ? (byLetter[ch.ToString()] + 1) : 1; ;
            }

            for (var i = 0; i < 10; i++)
            {
                List<string> newPairs = new();
                foreach (var pair in pairsCount.Keys)
                {
                    for (var b = pairsCount[pair]; b > 0; b--)
                    {
                        if (pairsCount[pair] > 0)
                        {
                            pairsCount[pair]--;
                            var patternItem = pattern[pair];
                            
                            newPairs.Add(string.Join(string.Empty, pair[0], patternItem));
                            newPairs.Add(string.Join(string.Empty, patternItem, pair[1]));

                            byLetter[patternItem] = byLetter.ContainsKey(patternItem) ? (byLetter[patternItem] + 1) : 1;
                        }
                    }
                }

                foreach (var newPair in newPairs)
                {
                    pairsCount[newPair] = pairsCount.ContainsKey(newPair) ? (pairsCount[newPair] + 1) : 1;
                }
            }

            return byLetter.Values.Max() - byLetter.Values.Min();
        }

        private static Dictionary<string, int> GetPairOccurances(string input)
        {
            var pairs = new List<string>();
            for (int i = 0; i < (input.Length - 1); i++)
            {
                pairs.Add(string.Join(string.Empty, input[i], input[i + 1]));
            }

            return pairs.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        }
    }
}