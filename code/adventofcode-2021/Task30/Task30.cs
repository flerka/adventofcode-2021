using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task30
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/15/ task
        /// </summary>
        public static int Function(List<List<int>> input)
        {
            var data = new Dictionary<(int, int), int>();

            Dictionary<(int, int), int> distances = new();
            for (int i = 0; i < input.Count; i++)
            {
                for (int k = 0; k < input.Count; k++)
                {
                    data[(k, i)] = input[i][k];
                    distances[(k, i)] = int.MaxValue;
                }
            }

            Dictionary<(int, int), bool> visited = new();
            distances[(0, 0)] = 0;

            var pq = new PriorityQueue<(int, int), int>();
            pq.Enqueue((0, 0), 0);
            while (pq.Count > 0)
            {
                var last = pq.Dequeue();
                visited[last] = true;
                var neighbors = GetNeighbors(last, (input.Count, input.Count));
                foreach (var neighbor in neighbors)
                {
                    if (visited.ContainsKey(neighbor))
                    {
                        continue;
                    }

                    if (distances[neighbor] > distances[last] + data[neighbor])
                    {
                        distances[neighbor] = distances[last] + data[neighbor];
                        pq.Enqueue(neighbor, distances[last] + data[neighbor]);
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