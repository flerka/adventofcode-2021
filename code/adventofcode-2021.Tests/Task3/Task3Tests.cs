using Xunit;
using adventofcode_2021.Task3;
using System.Collections.Generic;
using System.IO;

namespace adventofcode_2021.Tests
{
    public class Task3Tests
    {
        [Fact]
        public void Task3_IfEmpty_Correct()
        {
            Assert.Equal(0, Solution.Function(new List<string>()));
        }

        [Fact]
        public void Task3_IfOneElement_Correct()
        {
            Assert.Equal(0, Solution.Function(new List<string> { "forward 5" }));
        }

        [Fact]
        public void Task3_IfSeveralElements_Correct()
        {
            Assert.Equal(150, Solution.Function(
                new List<string> {
                    "forward 5",
                    "down 5",
                    "forward 8",
                    "up 3",
                    "down 8",
                    "forward 2"
                }));
        }

        [Fact]
        public void Task3_RealExample_Correct()
        {
            Assert.Equal(150, Solution.Function(ReadFileAsync(Path.Combine("Task3", "Data.txt"))));
        }

        private IEnumerable<string> ReadFileAsync(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                yield return line;
            }
        }

    }
}
