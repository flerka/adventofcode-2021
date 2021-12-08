using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task16
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/8/ task
        /// </summary>
        public static int Function(IEnumerable<(List<string> alphabet, List<string> numbers)> items)
        {
            var mySortedAlphabet = new Dictionary<string, int>
            {
                ["abcdeg"] = 0,
                ["bc"] = 1,
                ["abdef"] = 2,
                ["abcdf"] = 3,
                ["bcfg"] = 4,
                ["acdfg"] = 5,
                ["acdefg"] = 6,
                ["abc"] = 7,
                ["abcdefg"] = 8,
                ["abcdfg"] = 9
            };

            var albpabetCount = new Dictionary<char, int>
            {
                ['c'] = 9,
                ['e'] = 4,
                ['g'] = 6
            };

            var result = 0;
            List<int> results = new();
            foreach (var pair in items)
            {
                var albpabetConversion = new Dictionary<char, char>();
                var temp = string.Join(string.Empty, pair.alphabet).GroupBy(c => c).ToDictionary(item => item.Key, item => item.Count());
                foreach (var key in albpabetCount.Keys)
                {
                    albpabetConversion[temp.Keys.Where(item => temp[item] == albpabetCount[key]).FirstOrDefault()] = key;
                }

                // only number 1 contains 2 characters and we know one of therm
                albpabetConversion[pair.alphabet.FirstOrDefault(item => item.Length == 2).FirstOrDefault(item => !albpabetConversion.Keys.Contains(item))] = 'b';
                // only number 7 contains 3 characters and we know two of therm
                albpabetConversion[pair.alphabet.FirstOrDefault(item => item.Length == 3).FirstOrDefault(item => !albpabetConversion.Keys.Contains(item))] = 'a';
                // only number 4 contains 4 characters and we know three of therm
                albpabetConversion[pair.alphabet.FirstOrDefault(item => item.Length == 4).FirstOrDefault(item => !albpabetConversion.Keys.Contains(item))] = 'f';
                // only number 8 contains 7 characters and we know six of therm
                albpabetConversion[pair.alphabet.FirstOrDefault(item => item.Length == 7).FirstOrDefault(item => !albpabetConversion.Keys.Contains(item))] = 'd';

                // convert to alphabet 
                var converted = pair.numbers.Select(item => string.Join(string.Empty, item.Select(character => albpabetConversion[character]).OrderBy(x => x))).ToList();
                result += int.Parse(string.Join(string.Empty, converted.Select(item => mySortedAlphabet[item])));
            }

            return result;
        }
    }
}