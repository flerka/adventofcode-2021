using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task23
{
    public class Solution
    {
        public class Cave
        {
            public string Name { get; set; }

            public bool IsSmall { get; set; }

            public bool IsStart { get { return this.Name == "start"; } }

            public bool IsEnd { get { return this.Name == "end"; } }

            public List<Cave> Neighbors { get; set; }
        }

        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/12/ task
        /// </summary>
        public static int Function(IEnumerable<(string start, string end)> input)
        {
            var caves = GetCavesWithNeighbors(input);
            var startCave = caves.FirstOrDefault(cave => cave.IsStart);

            var data = new Stack<(Cave cave, List<Cave> path)>(
                startCave.Neighbors
                .Select(item => (item, new List<Cave> { item })));

            var results = new List<Cave>();
            while (data.Count > 0)
            {
                var item = data.Pop();

                if (item.cave.IsEnd)
                {
                    results.Add(item.cave);
                }
                else
                {
                    item.cave.Neighbors.ForEach(neighbor =>
                    {
                        if (!neighbor.IsStart &&
                        (!neighbor.IsSmall || neighbor.IsEnd || !item.path.Contains(neighbor)))
                        {
                            var path = new List<Cave>(item.path);
                            path.Add(neighbor);
                            data.Push((neighbor, path));
                        }
                    });
                }

            }

            return results.Count;
        }

        private static List<Cave> GetCavesWithNeighbors(IEnumerable<(string start, string end)> input)
        {
            Dictionary<string, Cave> cavesByName = new();

            // fill dictionary
            input.ToList().ForEach(item =>
            {
                cavesByName[item.start] = new Cave
                {
                    Name = item.start,
                    IsSmall = item.start.All(char.IsLower)
                };
                cavesByName[item.end] = new Cave
                {
                    Name = item.end,
                    IsSmall = item.end.All(char.IsLower)
                };
            });

            foreach (var key in cavesByName.Keys)
            {
                cavesByName[key].Neighbors = input
                    .Where(item => item.start == key || item.end == key)
                    .Select(item => item.start == key ? cavesByName[item.end] : cavesByName[item.start])
                    .ToList();
            }

            return cavesByName.Values.ToList();
        }
    }
}