using adventofcode_2021.Task17;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task17Tests
    {
        [Fact]
        public void Task17_RealExample_Correct()
        {
            Assert.Equal(15, Solution.Function(ReadFileAsync(Path.Combine("Task17", "Data.txt")).ToList()));
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
