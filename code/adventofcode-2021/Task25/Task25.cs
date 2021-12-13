using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task25
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/13/ task
        /// </summary>
        public static int Function((List<(int x, int y)> coord, List<(string ax, int val)> foldings) input)
        {
            Dictionary<(int x, int y), bool> coordinates = FillDictionary(input.coord);
            var folding = input.foldings[0];

            if (folding.ax == "y")
            {
                coordinates.Keys.Where(val => val.y > folding.val).ToList().ForEach(item =>
                {
                    var y = item.y % folding.val;
                    if (y == 0)
                    {
                        y = folding.val;
                    }
                    coordinates[(item.x, folding.val - y)] = true;
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
                    coordinates[(folding.val - x, item.y)] = true;
                    coordinates[item] = false;
                });
            }

            return coordinates.Values.Count(item => item == true);
        }

        private static Dictionary<(int, int), bool> FillDictionary(List<(int x, int y)> coord)
        {
            var result = new Dictionary<(int, int), bool>();
            coord.ForEach(item => result[item] = true);

            return result;
        }
    }
}