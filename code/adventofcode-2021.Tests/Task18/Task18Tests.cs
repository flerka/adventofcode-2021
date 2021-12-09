using adventofcode_2021.Task18;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task18Tests
    {
        [Fact]
        public void Task18_RealExample_Correct()
        {
            Assert.Equal(1134, Solution.Function(ReadFileAsync(Path.Combine("Task18", "Data.txt")).ToList()));
        }

        private IEnumerable<List<int>> ReadFileAsync(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                yield return line.ToCharArray().Select(item => item - '0').ToList();
            }
        }
    }
}
