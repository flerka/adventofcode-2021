using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task26
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/13/ task
        /// </summary>
        public static int Function((List<(int x, int y)> coord, List<(string ax, int val)> foldings) input)
        {
            Dictionary<(int x, int y), bool> coordinates = FillDictionary(input.coord);
            var foldings = input.foldings;

            foreach (var folding in foldings)
            {
                if (folding.ax == "y")
                {
                    coordinates.Keys.Where(val => val.y > folding.val).ToList().ForEach(item =>
                    {
                        var y = item.y % folding.val;
                        if (y == 0)
                        {
                            y = folding.val;
                        }
                        coordinates[(item.x, folding.val - y)] = coordinates[item] ||
                            (coordinates.ContainsKey((item.x, folding.val - y)) && coordinates[(item.x, folding.val - y)]);
                        coordinates[item] = false;
                    });
                }
                else
                {
                    coordinates.Keys.Where(val => val.x > folding.val).ToList().ForEach(item =>
                    {
                        var x = item.x % folding.val;
                        if (x == 0)
                        {
                            x = folding.val;
                        }
                        coordinates[(folding.val - x, item.y)] = coordinates[item] ||
                            (coordinates.ContainsKey((folding.val - x, item.y)) && coordinates[(folding.val - x, item.y)]); ;
                        coordinates[item] = false;
                    });
                }
            }

            var result = coordinates.Where(i => i.Value == true).ToDictionary(i => i.Key, i => i.Value);
            OutputResult(result);

            return result.Count();
        }

        private static void OutputResult(Dictionary<(int x, int y), bool> result)
        {
            (int x, int y) size = (result.Keys.Max(i => i.x), result.Keys.Max(i => i.y));
            for (int i = 0; i <= size.y; i++)
            {

                for (int k = 0; k <= size.x; k++)
                {
                    var text = result.ContainsKey((k, i)) ? "*" : ".";
                    Console.Write(text);
                }
                Console.WriteLine();
            }
        }

        private static Dictionary<(int, int), bool> FillDictionary(List<(int x, int y)> coord)
        {
            var result = new Dictionary<(int, int), bool>();
            coord.ForEach(item => result[item] = true);

            return result;
        }
    }
}