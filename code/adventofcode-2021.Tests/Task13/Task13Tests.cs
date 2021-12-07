using adventofcode_2021.Task13;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task13Tests
    {
        [Fact]
        public void Task13_RealExample_Correct()
        {
            Assert.Equal(37, Solution.Function(ReadFileAsync(Path.Combine("Task13", "Data.txt"))));
        }

        private List<int> ReadFileAsync(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            return lines[0].Split(',').Select(int.Parse).ToList();
        }
    }
}
