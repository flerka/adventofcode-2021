using adventofcode_2021.Task43;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq;
using Xunit;

namespace adventofcode_2022.Tests
{
    public class Task43Tests
    {
        [Fact]
        public void Task43_RealExample_Correct()
        {
            Assert.Equal(590784, Solution.Function(ReadFileAsync(Path.Combine("Task43", "Data.txt"))));
        }

        private IEnumerable<Cuboid> ReadFileAsync(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                var result = new Cuboid();
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

                result.lowerX = int.Parse(ranges[0]);
                result.upperX = int.Parse(ranges[1]);
                result.lowerY = int.Parse(ranges[2]);
                result.upperY = int.Parse(ranges[3]);
                result.lowerZ = int.Parse(ranges[4]);
                result.upperZ = int.Parse(ranges[5]);
                yield return result;
            }
        }
    }
}