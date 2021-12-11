using adventofcode_2021.Task21;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task21Tests
    {
        [Fact]
        public void Task21_RealExample_Correct()
        {
            Assert.Equal(1656, Solution.Function(ReadFileAsync(Path.Combine("Task21", "Data.txt")).ToList()));
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
