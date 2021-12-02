using Xunit;
using adventofcode_2021.Task4;
using System.Collections.Generic;
using System.IO;

namespace adventofcode_2021.Tests
{
    public class Task4Tests
    {
        [Fact]
        public void Task4_IfEmpty_Correct()
        {
            Assert.Equal(0, Solution.Function(new List<string>()));
        }

        [Fact]
        public void Task4_IfOneElement_Correct()
        {
            Assert.Equal(0, Solution.Function(new List<string> { "forward 5" }));
        }

        [Fact]
        public void Task4_IfSeveralElements_Correct()
        {
            Assert.Equal(900, Solution.Function(
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
        public void Task4_RealExample_Correct()
        {
            Assert.Equal(900, Solution.Function(ReadFileAsync(Path.Combine("Task4", "Data.txt"))));
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
