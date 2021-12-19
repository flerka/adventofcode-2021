using adventofcode_2021.Task35;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2022.Tests
{
    public class Task35Tests
    {
        [Fact]
        public void Task35_RealExample_Correct()
        {
            Assert.Equal(112, Solution.Function(ReadFileAsync(Path.Combine("Task35", "Data.txt"))));
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
