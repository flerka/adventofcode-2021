using adventofcode_2021.Task20;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task20Tests
    {
        [Fact]
        public void Task20_RealExample_Correct()
        {
            Assert.Equal(288957, Solution.Function(ReadFileAsync(Path.Combine("Task20", "Data.txt")).ToList()));
        }

        private IEnumerable<List<char>> ReadFileAsync(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                yield return line.ToCharArray().ToList();
            }
        }
    }
}
