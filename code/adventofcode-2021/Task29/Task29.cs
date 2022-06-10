using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task29
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/15/ task
        /// </summary>
        public static int Function(List<List<int>> input)
        {
            Dictionary<(int, int), bool> visited = new();
            Dictionary<(int, int), int> distances = new();
            for (int i = 0; i < input.Count; i++)
            {
                for (int k = 0; k < input.Count; k++)
                {
                    distances[(k, i)] = int.MaxValue;
                }
            }
            distances[(0, 0)] = 0;
            var last = (0, 0);
            while (last != (input.Count - 1, input.Count - 1))
            {
                visited[last] = true;
                var neighbors = GetNeighbors(last, (input.Count, input.Count));
                foreach (var neighbor in neighbors)
                {
                    if (distances[neighbor] > distances[last] + input[neighbor.Item2][neighbor.Item1])
                    {
                        distances[neighbor] = distances[last] + input[neighbor.Item2][neighbor.Item1];
                    }
                }

                var distance = int.MaxValue;
                foreach (var key in distances.Keys)
                {
                    if (!visited.ContainsKey(key) && distances[key] < distance)
                    {
                        distance = distances[key];
                        last = key;
                    }
                }
            }

            return distances[(input.Count - 1, input.Count - 1)];
        }

        private static List<(int, int)> GetNeighbors((int i, int j) point, (int x, int y) size) =>
            (new List<(int i, int j)> { (point.i - 1, point.j), (point.i + 1, point.j), (point.i, point.j + 1), (point.i, point.j - 1) })
            .Where(item => item.i >= 0 && item.i < size.x && item.j >= 0 && item.j < size.y)
            .ToList();
    }
}