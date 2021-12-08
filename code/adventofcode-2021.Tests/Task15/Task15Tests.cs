using adventofcode_2021.Task15;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task15Tests
    {
        [Fact]
        public void Task15_RealExample_Correct()
        {
            Assert.Equal(26, Solution.Function(ReadFileAsync(Path.Combine("Task15", "Data.txt"))));
        }

        private IEnumerable<(List<string> alphabet, List<string> numbers)> ReadFileAsync(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                var lines = line.Split(" | ");
                var alphabet = lines[0].Split(" ").ToList();
                var numbers = lines[1].Split(" ").ToList();
                yield return (alphabet, numbers);
            }
        }
    }
}
