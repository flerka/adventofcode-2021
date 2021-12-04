using adventofcode_2021.Task2;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task2Tests
    {
        [Fact]
        public void Task2_IfEmpty_Correct()
        {
            Assert.Equal(0, Solution.Function(new List<int>()));
        }

        [Fact]
        public void Task2_IfOneElement_Correct()
        {
            Assert.Equal(0, Solution.Function(new List<int> { 55 }));
        }

        [Fact]
        public void Task2_IfSeveralElements_Correct()
        {
            Assert.Equal(5, Solution.Function(
                new List<int> { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }));
        }

        [Fact]
        public void Task2_RealExample_Correct()
        {
            Assert.Equal(5, Solution.Function(ReadFileAsync(Path.Combine("Task2", "Data.txt"))));
        }

        private IEnumerable<int> ReadFileAsync(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                yield return int.Parse(line);
            }
        }

    }
}
