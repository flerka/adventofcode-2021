using adventofcode_2021.Task29;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task29Tests
    {
        [Fact]
        public void Task29_RealExample_Correct()
        {
            Assert.Equal(40, Solution.Function(ReadFileAsync(Path.Combine("Task29", "Data.txt"))));
        }

        private List<List<int>> ReadFileAsync(string file)
        {
            var lines = File.ReadLines(file);
            var result = new List<List<int>>();
            foreach (var line in lines)
            {
                result.Add(line.ToCharArray().Select(ch => ch - '0').ToList());
            }

            return result;
        }
    }
}
