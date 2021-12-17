using adventofcode_2021.Task33;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2022.Tests
{
    public class Task33Tests
    {
        [Fact]
        public void Task33_RealExample_Correct()
        {
            var result = ReadFileAsync(Path.Combine("Task33", "Data.txt"));
            Assert.Equal(7626, Solution.Function(result[0], result[1]));
        }

        private List<(int, int)> ReadFileAsync(string file)
        {
            return File.ReadLines(file)
                .ElementAt(0)
                .Split("target area: ")[1]
                .Split(", ")
                .Select(x =>
                {
                    var data = new string(x.Skip(2).ToArray()).Split("..");
                    return (int.Parse(data[0]), int.Parse(data[1]));
                })
                .ToList();
        }
    }
}
