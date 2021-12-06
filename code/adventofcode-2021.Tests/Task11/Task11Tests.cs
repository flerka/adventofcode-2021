using adventofcode_2021.Task11;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task11Tests
    {
        [Fact]
        public void Task11_RealExample_Correct()
        {
            Assert.Equal(5934, Solution.Function(ReadFileAsync(Path.Combine("Task11", "Data.txt"))));
        }

        private List<int> ReadFileAsync(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            return lines[0].Split(',').Select(int.Parse).ToList();
        }
    }
}
