using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task22
{
    public class Solution
    {
        public class Octopus
        {
            public int Charge { get; set; }
            public bool IsFlashed { get; set; }
            public (int, int) Coordinates { get; set; }
            public List<Octopus> Neighbors { get; set; }

            public static void ToDefaultState(Octopus oct)
            {
                oct.Charge = 0;
                oct.IsFlashed = false;
            }
        }

        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/11/ task
        /// </summary>
        public static long Function(List<List<int>> input)
        {
            var result = 0;
            var octopuses = GetOctopusesWithRelation(input);
            for (var i = 0; i < 999; i++)
            {
                if (octopuses.Where(item => item.Charge == 0).Count() > 99)
                {
                    return i;
                }

                octopuses.ForEach(item => item.Charge++);
                var toFlash = new Stack<Octopus>(
                    octopuses.Where(neighbor => !neighbor.IsFlashed && neighbor.Charge > 9));

                while (toFlash.Count > 0)
                {
                    var item = toFlash.Pop();
                    result++;
                    item.IsFlashed = true;

                    item.Neighbors.ForEach(neighbor =>
                    {
                        neighbor.Charge++;
                        if (!neighbor.IsFlashed && neighbor.Charge > 9 && !toFlash.Contains(neighbor))
                        {
                            toFlash.Push(neighbor);
                        }
                    });

                }

                octopuses.Where(item => item.IsFlashed).ToList().ForEach(Octopus.ToDefaultState);
            }

            return 0;
        }

        private static List<(int, int)> GetNeighbors((int i, int j) point, (int x, int y) size) =>
            new List<(int i, int j)>
            {
                (point.i - 1, point.j),
                (point.i + 1, point.j),
                (point.i, point.j + 1),
                (point.i, point.j - 1),
                (point.i - 1, point.j - 1),
                (point.i - 1, point.j + 1),
                (point.i + 1, point.j - 1),
                (point.i + 1, point.j + 1),
            }
            .Where(item => item.i >= 0 && item.i < size.x && item.j >= 0 && item.j < size.y)
            .ToList();

        private static List<Octopus> GetOctopusesWithRelation(List<List<int>> input)
        {
            var size = (10, 10);
            Dictionary<(int, int), Octopus> byPoint = new();

            // fill dictionary
            input.Aggregate(0, (i1, x1) =>
            {
                x1.Aggregate(0, (i2, x2) =>
                {
                    byPoint[(i1, i2)] = new Octopus { Charge = x2 };
                    return i2 + 1;
                });
                return i1 + 1;
            });

            foreach (var key in byPoint.Keys)
            {
                byPoint[key].Neighbors = GetNeighbors(key, size).Select(item => byPoint[item]).ToList();
            }

            return byPoint.Values.ToList();
        }
    }
}