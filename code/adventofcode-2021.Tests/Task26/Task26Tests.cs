using adventofcode_2021.Task26;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task26Tests
    {
        [Fact]
        public void Task26_RealExample_Correct()
        {
            Assert.Equal(16, Solution.Function(
                ReadFileAsync(Path.Combine("Task26", "DataP1.txt"), Path.Combine("Task26", "DataP2.txt"))));
        }

        private (List<(int, int)>, List<(string, int)>) ReadFileAsync(string fileP1, string fileP2)
        {
            var coordLines = File.ReadAllLines(fileP1);
            var coords = coordLines.Select(line =>
            {
                var items = line.Split(",");
                return (int.Parse(items[0]), int.Parse(items[1]));
            }).ToList();

            var foldLines = File.ReadAllLines(fileP2);
            var foldings = foldLines.Select(line =>
            {
                var items = line.Split("fold along ")[1].Split("=");
                return (items[0], int.Parse(items[1]));
            }).ToList();

            return (coords, foldings);
        }
    }
}
