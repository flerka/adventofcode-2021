using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task28
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/14/ task
        /// </summary>
        public static ulong Function((string start, List<(string, string)> pattern) data)
        {
            var pairsCount = GetPairOccurances(data.start);
            var pattern = data.pattern.ToDictionary(x => x.Item1, x => x.Item2);
            Dictionary<string, ulong> byLetter = new();
            foreach (var ch in data.start)
            {
                byLetter[ch.ToString()] = byLetter.ContainsKey(ch.ToString()) ? (byLetter[ch.ToString()] + 1) : 1; ;
            }

            for (var i = 0; i < 40; i++)
            {
                Dictionary<string, ulong> newPair = new();
                foreach (var pair in pairsCount.Keys)
                {
                    ulong b = pairsCount[pair];
                    if (pairsCount[pair] > 0)
                    {
                        pairsCount[pair] -= b;
                        var patternItem = pattern[pair];

                        var first = string.Join(string.Empty, pair[0], patternItem);
                        var second = string.Join(string.Empty, patternItem, pair[1]);
                        newPair[first] = newPair.ContainsKey(first) ? newPair[first] + b : b;
                        newPair[second] = newPair.ContainsKey(second) ? newPair[second] + b : b;

                        byLetter[patternItem] = byLetter.ContainsKey(patternItem) ? (byLetter[patternItem] + b) : b;
                    }
                }

                foreach (var key in newPair.Keys)
                {
                    pairsCount[key] = pairsCount.ContainsKey(key) ? (pairsCount[key] + newPair[key]) : newPair[key];
                }
            }

            return byLetter.Values.Max() - byLetter.Values.Min();
        }

        private static Dictionary<string, ulong> GetPairOccurances(string input)
        {
            var pairs = new List<string>();
            for (int i = 0; i < (input.Length - 1); i++)
            {
                pairs.Add(string.Join(string.Empty, input[i], input[i + 1]));
            }

            return pairs.GroupBy(x => x).ToDictionary(x => x.Key, x => (ulong)x.Count());
        }
    }
}