using adventofcode_2021.Task24;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2022.Tests
{
    public class Task24Tests
    {
        [Fact]
        public void Task24_RealExample_Correct()
        {
            Assert.Equal(36, Solution.Function(ReadFileAsync(Path.Combine("Task24", "Data.txt"))));
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
