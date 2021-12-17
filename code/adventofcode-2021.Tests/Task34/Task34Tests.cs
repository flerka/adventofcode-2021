using adventofcode_2021.Task34;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2022.Tests
{
    public class Task34Tests
    {
        [Fact]
        public void Task34_RealExample_Correct()
        {
            var result = ReadFileAsync(Path.Combine("Task34", "Data.txt"));
            Assert.Equal(112, Solution.Function(result[0], result[1]));
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
