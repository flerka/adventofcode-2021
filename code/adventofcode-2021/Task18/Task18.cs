using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task18
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/9/ task
        /// </summary>
        public static int Function(List<List<int>> input)
        {
            var size = (input[0].Count, input.Count);
            var result = new List<List<(int, int)>>();
            var data = ConvetInputToDictionary(input);
            var lowerPoints = GetLowerPointsCoordinate(data, size);

            foreach (var point in lowerPoints)
            {
                var basin = new List<(int, int)> { point };
                FillBasin(point, data, basin, size);
                result.Add(basin);
            }

            return result.OrderByDescending(x => x.Count).Take(3).Aggregate(1, (result, next) => result * next.Count);

        }

        private static void FillBasin((int, int) point, Dictionary<(int i, int j), int> data, List<(int, int)> basin, (int, int) size)
        {
            var neighBors = GetNeighbors(point, size).Where(item => data[item] != 9).ToList();
            if (!basin.Contains(point))
            {
                basin.Add(point);
            }

            foreach (var neighbor in neighBors)
            {
                if (!basin.Contains(neighbor))
                {
                    FillBasin(neighbor, data, basin, size);
                }
            }
        }

        private static Dictionary<(int i, int j), int> ConvetInputToDictionary(List<List<int>> input)
        {
            Dictionary<(int i, int j), int> data = new();
            input.Aggregate(0, (index1, item1) =>
            {
                item1.Aggregate(0, (index2, item2) =>
                {
                    data[(index2, index1)] = item2;
                    return index2 + 1;
                });
                return index1 + 1;
            });

            return data;
        }

        private static List<(int i, int j)> GetLowerPointsCoordinate(Dictionary<(int i, int j), int> data, (int, int) size)
            => data.Keys
                .Where(key => GetNeighbors(key, size).All(neigbor => !data.ContainsKey(neigbor) || data[neigbor] > data[key]))
                .ToList();

        private static List<(int, int)> GetNeighbors((int i, int j) point, (int x, int y) size) =>
            (new List<(int i, int j)> { (point.i - 1, point.j), (point.i + 1, point.j), (point.i, point.j + 1), (point.i, point.j - 1) })
            .Where(item => item.i >= 0 && item.i < size.x && item.j >= 0 && item.j < size.y)
            .ToList();
    }
}