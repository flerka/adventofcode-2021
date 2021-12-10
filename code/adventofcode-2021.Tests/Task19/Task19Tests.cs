using adventofcode_2021.Task19;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task19Tests
    {
        [Fact]
        public void Task19_RealExample_Correct()
        {
            Assert.Equal(26397, Solution.Function(ReadFileAsync(Path.Combine("Task19", "Data.txt")).ToList()));
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
