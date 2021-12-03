using Xunit;
using adventofcode_2021.Task5;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace adventofcode_2021.Tests
{
    public class Task5Tests
    {
        [Fact]
        public void Task5_RealExample_Correct()
        {
           Assert.Equal(4072886, Solution.Function(ReadFileAsync(Path.Combine("Task5", "Data.txt")).ToList()));
        }

        private IEnumerable<short[]> ReadFileAsync(string fileName)
        {
            foreach (var line in File.ReadLines(fileName))
            {
                // 16 bacause of processor register capacity for Vector<T>.Count
                yield return line.PadLeft(16, '0').ToCharArray().Select(c => (short)Char.GetNumericValue(c)).ToArray();
            }
        }

    }
}
