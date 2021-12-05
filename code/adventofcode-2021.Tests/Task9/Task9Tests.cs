using adventofcode_2021.Task9;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task9Tests
    {
        [Fact]
        public void Task9_RealExample_Correct()
        {
            Assert.Equal(5, Solution.Function(ReadFileAsync(Path.Combine("Task9", "Data.txt"))));
        }

        private List<(Point, Point)> ReadFileAsync(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            return lines
                .Select(item =>
                {
                    var temp = item.Split(" -> ").Select(x => x.Split(',')).ToList();
                    var start = new Point(int.Parse(temp[0][0]), int.Parse(temp[0][1]));
                    var end = new Point(int.Parse(temp[1][0]), int.Parse(temp[1][1]));

                    return (start.x < end.x || start.y < end.y) ? (start, end) : (end, start);
                })
                .ToList();
        }
    }
}
