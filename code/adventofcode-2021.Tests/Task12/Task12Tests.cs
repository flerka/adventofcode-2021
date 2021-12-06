using adventofcode_2021.Task12;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task12Tests
    {
        [Fact]
        public void Task12_RealExample_Correct()
        {
            Assert.Equal(26984457539, Solution.Function(ReadFileAsync(Path.Combine("Task12", "Data.txt"))));
        }

        private List<long> ReadFileAsync(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            return lines[0].Split(',').Select(long.Parse).ToList();
        }
    }
}
