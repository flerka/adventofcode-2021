using adventofcode_2021.Task22;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2022.Tests
{
    public class Task22Tests
    {
        [Fact]
        public void Task22_RealExample_Correct()
        {
            Assert.Equal(195, Solution.Function(ReadFileAsync(Path.Combine("Task22", "Data.txt")).ToList()));
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
