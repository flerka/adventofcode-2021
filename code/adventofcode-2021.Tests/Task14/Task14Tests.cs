using adventofcode_2021.Task14;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task14Tests
    {
        [Fact]
        public void Task14_RealExample_Correct()
        {
            Assert.Equal(168, Solution.Function(ReadFileAsync(Path.Combine("Task14", "Data.txt"))));
        }

        private List<int> ReadFileAsync(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            return lines[0].Split(',').Select(int.Parse).ToList();
        }
    }
}
