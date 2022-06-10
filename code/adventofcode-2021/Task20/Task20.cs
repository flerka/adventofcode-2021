using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task20
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/10/ task
        /// </summary>
        public static long Function(List<List<char>> input)
        {
            var closingScored = new Dictionary<char, long>
            { ['('] = 1, ['['] = 2, ['{'] = 3, ['<'] = 4 };

            var results = new List<long>();
            foreach (var item in input)
            {
                var result = GetUnclosed(item);
                if (result != null)
                {
                    results.Add(result.Aggregate(0L, (res, c) => (5L * res) + closingScored[c]));
                }
            }

            return results.OrderBy(x => x).ElementAt(results.Count / 2);
        }

        private static List<char> GetUnclosed(List<char> line)
        {
            Stack<char> openingBrackets = new();
            var isLineValid = true;
            var closedBrackets = new List<char> { ']', ')', '}', '>' };

            foreach (char c in line)
            {
                if (!closedBrackets.Contains(c))
                {
                    openingBrackets.Push(c);
                }
                else
                {
                    var lastOpening = openingBrackets.Pop();
                    var isCharValid = (lastOpening, c) switch
                    {
                        ('[', ']') or ('{', '}') or ('(', ')') or ('<', '>') => true,
                        _ => false
                    };

                    if (!isCharValid)
                    {
                        isLineValid = false;
                    }
                }
            }

            return isLineValid ? openingBrackets.ToList() : null;
        }
    }
}