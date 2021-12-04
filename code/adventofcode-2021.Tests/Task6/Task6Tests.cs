using adventofcode_2021.Task6;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task6Tests
    {
        [Fact]
        public void Task6_RealExample_Correct()
        {
            Assert.Equal(230, Solution.Function(ReadFileAsync(Path.Combine("Task6", "Data.txt")).ToList()));
        }

        private IEnumerable<short[]> ReadFileAsync(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                yield return line.ToCharArray().Select(c => (short)Char.GetNumericValue(c)).ToArray();
            }
        }

    }
}
