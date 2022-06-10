using adventofcode_2021.Task23;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task23Tests
    {
        [Fact]
        public void Task23_RealExample_Correct()
        {
            Assert.Equal(10, Solution.Function(ReadFileAsync(Path.Combine("Task23", "Data.txt"))));
        }

        private IEnumerable<(string, string)> ReadFileAsync(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                var splited = line.Split("-");
                yield return (splited[0], splited[1]);
            }
        }
    }
}
