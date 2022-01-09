using adventofcode_2021.Task49;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task55Tests
    {
        [Fact]
        public void Task55_RealExample_Correct()
        {
            Assert.Equal(58, Solution.Function(ReadFileAsync(Path.Combine("Task49", "Data.txt")).ToList()));
        }

        private IEnumerable<char[]> ReadFileAsync(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                yield return line.ToCharArray();
            }
        }

    }
}
