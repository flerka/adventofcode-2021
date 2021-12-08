using adventofcode_2021.Task16;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task16Tests
    {
        [Fact]
        public void Task16_RealExample_Correct()
        {
            Assert.Equal(61229, Solution.Function(ReadFileAsync(Path.Combine("Task16", "Data.txt"))));
        }

        private IEnumerable<(List<string> alphabet, List<string> numbers)> ReadFileAsync(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                var lines = line.Split(" | ");
                var alphabet = lines[0].Split(" ").Select(x => string.Join(string.Empty, x.OrderBy(i => i))).ToList();
                var numbers = lines[1].Split(" ").Select(x => string.Join(string.Empty, x.OrderBy(i => i))).ToList();
                yield return (alphabet, numbers);
            }
        }
    }
}
