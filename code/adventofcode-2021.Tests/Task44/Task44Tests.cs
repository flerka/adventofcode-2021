using adventofcode_2021.Task44;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task44Tests
    {
        [Fact]
        public void Task44_RealExample_Correct()
        {
            Assert.Equal(2758514936282235L, Solution.Function(ReadFileAsync(Path.Combine("Task44", "Data.txt"))));
        }

        private IEnumerable<InputData> ReadFileAsync(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                var result = new InputData();
                string input = string.Empty;

                if (line.StartsWith("on "))
                {
                    result.op = true;
                    input = line.Split("on ")[1];
                }
                else
                {
                    input = line.Split("off ")[1];
                }

                var ranges = input.Split(',')
                    .Select(item => item.Split("=")[1])
                    .SelectMany(item => item.Split(".."))
                    .ToList();

                result.ux = long.Parse(ranges[0]);
                result.vx = long.Parse(ranges[1]);
                result.uy = long.Parse(ranges[2]);
                result.vy = long.Parse(ranges[3]);
                result.uz = long.Parse(ranges[4]);
                result.vz = long.Parse(ranges[5]);
                yield return result;
            }
        }
    }
}